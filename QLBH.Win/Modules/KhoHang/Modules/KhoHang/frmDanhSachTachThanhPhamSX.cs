using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.DongBoERP;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Form;
using QLBanHang.Properties;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmDanhSachTachThanhPhamSX : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        private DMTrungTamInfor currentTrungTam;
        private DMKhoInfo currentKho;
        //SanXuatLenhInfo sx = new SanXuatLenhInfo();
        //SanXuatCTietLenhInfo sxct = new SanXuatCTietLenhInfo();
        //private bool success;
        List<SanXuatNhapTachInfo> liSXNT = new List<SanXuatNhapTachInfo>();
        List<SanXuatNhapTachInfo> liChiTiet = new List<SanXuatNhapTachInfo>();
        public string MaLenh = "";
        public string TransactionID = "";
        public string MaThanhPham;
        public string TenThanhPham;
        public string TenLoaiSP;
        public int idThanhPham;
        public int SoLuongYC;
        public int SoLuongCT;
        public int IdSanPham;
        private string MaTrungTam;
        private string MaKho;
        public int TrangThai;
        public DateTime NgayLap;
        #endregion

        #region frmDanhSachTachThanhPhamSX
        public frmDanhSachTachThanhPhamSX()
        {
            InitializeComponent();
        }
        #endregion

        #region Action

        private string GetMaTrungTam()
        {
            currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
            return currentTrungTam.MaTrungTam;
        }
        private string GetMaKho()
        {
            currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);
            return currentKho.MaKho;
        }

        private void SynsNhapThanhPham()
        {
            try
            {
                currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
                currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);

                string inventoryOrg = currentTrungTam.MaTrungTam;
                string inventorySub = currentKho.MaKho;

                frmProgress.Instance.Description = "Đang xóa dữ liệu tạm...";

                SanXuatNhapTachDataProvider.Instance.DeleteTachThanhPham(inventoryOrg);

                frmProgress.Instance.Value += 1;

                frmProgress.Instance.Description = "Đang đồng bộ dữ liệu...";

                bool success = false;
                success = BusinessSynchronize.Instance.TachThanhPhamSync(dteLastSync.DateTime.ToString("yyyy/MM/dd hh:mm:ss"), inventoryOrg);

                frmProgress.Instance.Value += 1;

                frmProgress.Instance.Description = "Đang cập nhật lại lịch sử...";

                liSXNT = SanXuatNhapTachDataProvider.Instance.GetListAllTmpSanXuatNhapTach(MaTrungTam, Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT));
                for (int i = 0; i < liSXNT.Count; i++)
                {
                    if (SanXuatNhapTachDataProvider.Instance.Check(liSXNT[i].MaLenh, liSXNT[i].MaThanhPham, liSXNT[i].TransactionID) == 0)
                    {
                        SanXuatNhapTachDataProvider.Instance.Insert(new SanXuatNhapTachInfo
                        {
                            MaLenh = liSXNT[i].MaLenh,
                            MaThanhPham = liSXNT[i].MaThanhPham,
                            OrgCode = liSXNT[i].OrgCode,
                            LoaiGiaoDich = Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT),
                            SoLuongYC = liSXNT[i].SoLuongYC,
                            NguoiLap = liSXNT[i].NguoiLap,
                            NgayGiaoDich = liSXNT[i].NgayGiaoDich,
                            TransactionID = liSXNT[i].TransactionID
                        });
                    }
                    else
                    {
                        SanXuatNhapTachDataProvider.Instance.Update(new SanXuatNhapTachInfo
                        {
                            MaLenh = liSXNT[i].MaLenh,
                            MaThanhPham = liSXNT[i].MaThanhPham,
                            OrgCode = liSXNT[i].OrgCode,
                            LoaiGiaoDich = Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT),
                            SoLuongYC = liSXNT[i].SoLuongYC,
                            NguoiLap = liSXNT[i].NguoiLap,
                            NgayGiaoDich = liSXNT[i].NgayGiaoDich,
                            TransactionID = liSXNT[i].TransactionID
                        });
                    }

                }
                if (!success)
                {
                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                    frmProgress.Instance.Description = "Không hoàn thành.";
                    frmProgress.Instance.IsCompleted = true;
                    MessageBox.Show("Gọi webservice không thành công!");
                    return;
                }

                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.Description = "Đã hoàn thành.";
                frmProgress.Instance.IsCompleted = true;

                LockControl.Unlock("SynsTachThanhPham");
            }
            catch (Exception ex)
            {
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.Description = "Không hoàn thành.";
                frmProgress.Instance.IsCompleted = true;
                LockControl.Unlock("SynsTachThanhPham");
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void GetValue()
        {
            SanXuatNhapTachInfo sx = (SanXuatNhapTachInfo) grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);
            MaLenh = liChiTiet[liChiTiet.IndexOf(sx)].MaLenh;
            MaThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].MaThanhPham;
            TenThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].TenThanhPham;
            SoLuongYC = liChiTiet[liChiTiet.IndexOf(sx)].SoLuongYC;
            IdSanPham = liChiTiet[liChiTiet.IndexOf(sx)].idthanhpham;
            TrangThai = liChiTiet[liChiTiet.IndexOf(sx)].TrangThai;
            TransactionID = liChiTiet[liChiTiet.IndexOf(sx)].TransactionID.ToString();
            NgayLap = liChiTiet[liChiTiet.IndexOf(sx)].NgayLap;
            SoLuongCT = SanXuatLenhProvier.GetSoLuongChungTu(
                Convert.ToInt32(TransactionType.XUAT_THANH_PHAM),
                liChiTiet[liChiTiet.IndexOf(sx)].MaLenh, 1, liChiTiet[liChiTiet.IndexOf(sx)].TransactionID.ToString());
        }

        public void Reload()
        {
            liChiTiet = SanXuatNhapTachDataProvider.Instance.GetListAllSanXuatNhapTach(Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT), Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX), MaTrungTam, 2);
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                liChiTiet[i].SoLuongHT = SanXuatLenhProvier.GetSoLuongChungTu(
                Convert.ToInt32(TransactionType.XUAT_THANH_PHAM),
                liChiTiet[i].MaLenh, 2, liChiTiet[i].TransactionID.ToString());
            }

            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (liChiTiet[i].SoLuongHT == 0)
                {
                    liChiTiet[i].TenTrangThai = "Chờ tách";
                }
                if (liChiTiet[i].SoLuongHT > 0 && liChiTiet[i].SoLuongHT < liChiTiet[i].SoLuongYC)
                {
                    liChiTiet[i].TenTrangThai = "Đang tách";
                }
                if (liChiTiet[i].SoLuongHT == liChiTiet[i].SoLuongYC)
                {
                    liChiTiet[i].TenTrangThai = "Đã tách xong";
                }
            }
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = liChiTiet;
        }

        #endregion

        #region Event
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnDongBo_Click(object sender, EventArgs e)
        {
            try
            {
                string functionName = "SynsTachThanhPham";

                LockControl.Lock(functionName);
                frmProgress.Instance.Text = "Đồng bộ dữ liệu";
                frmProgress.Instance.MaxValue = 3;
                frmProgress.Instance.DoWork(SynsNhapThanhPham);
                liChiTiet = SanXuatNhapTachDataProvider.Instance.GetListAllSanXuatNhapTach(Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT), Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX), MaTrungTam, 2);
                for (int i = 0; i < liChiTiet.Count; i++)
                {
                    liChiTiet[i].SoLuongHT = SanXuatLenhProvier.GetSoLuongChungTu(
                    Convert.ToInt32(TransactionType.XUAT_THANH_PHAM),
                    liChiTiet[i].MaLenh, 1, liChiTiet[i].TransactionID.ToString());
                }
                for (int i = 0; i < liChiTiet.Count; i++)
                {
                    if (liChiTiet[i].SoLuongHT == 0)
                    {
                        liChiTiet[i].TenTrangThai = "Chờ tách";
                    }
                    if (liChiTiet[i].SoLuongHT > 0 && liChiTiet[i].SoLuongHT < liChiTiet[i].SoLuongYC)
                    {
                        liChiTiet[i].TenTrangThai = "Đang tách";
                    }
                    if (liChiTiet[i].SoLuongHT == liChiTiet[i].SoLuongYC)
                    {
                        liChiTiet[i].TenTrangThai = "Đã tách xong";
                    }
                }
                dgvChiTiet.DataSource = liChiTiet;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void frmDanhSachTachThanhPhamSX_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtngaylap);
            btnChiTiet.Text = Resources.btnInfor;
            MaTrungTam = GetMaTrungTam();
            MaKho = GetMaKho();
            dteLastSync.DateTime = SanXuatLenhProvier.GetMaxDateSanXuatLenh(MaTrungTam);
            liChiTiet = SanXuatNhapTachDataProvider.Instance.GetListAllSanXuatNhapTach(Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT), Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX), MaTrungTam, 2);
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                liChiTiet[i].SoLuongHT = SanXuatLenhProvier.GetSoLuongChungTu(
                Convert.ToInt32(TransactionType.XUAT_THANH_PHAM),
                liChiTiet[i].MaLenh, 1, liChiTiet[i].TransactionID.ToString());
            }
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (liChiTiet[i].SoLuongHT == 0)
                {
                    liChiTiet[i].TenTrangThai = "Chờ tách";
                }
                if (liChiTiet[i].SoLuongHT > 0 && liChiTiet[i].SoLuongHT < liChiTiet[i].SoLuongYC)
                {
                    liChiTiet[i].TenTrangThai = "Đang tách";
                }
                if (liChiTiet[i].SoLuongHT == liChiTiet[i].SoLuongYC)
                {
                    liChiTiet[i].TenTrangThai = "Đã tách xong";
                }
            }
            dgvChiTiet.DataSource = liChiTiet;
        }
       

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            GetValue();

            if (SoLuongYC > SoLuongCT && TrangThai != Convert.ToInt32(TrangThaiSanXuat.ChoXuat))
            {
                var frm = new frmChiTietTachThanhPhamSX(this);

                frm.ShowDialog();
            }
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle < 0)
            {
                return;
            }

            GetValue();
            
            if (SoLuongYC > SoLuongCT && TrangThai != Convert.ToInt32(TrangThaiSanXuat.ChoXuat))
            {
                var frm = new frmChiTietTachThanhPhamSX(this);

                frm.ShowDialog();
            }
        }

        private void frmDanhSachTachThanhPhamSX_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void btnListNTP_Click(object sender, EventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle < 0)
            {
                return;
            }
            SanXuatNhapTachInfo sx = (SanXuatNhapTachInfo)grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);

            frmDanhSachNhapThanhPham frm = new frmDanhSachNhapThanhPham(2, sx.MaLenh);

            frm.ShowDialog();
        }

        
    }
}