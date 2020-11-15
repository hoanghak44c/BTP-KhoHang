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
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmDanhSachNhapComBo : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        private DMTrungTamInfor currentTrungTam;
        private DMKhoInfo currentKho;
        SanXuatLenhInfo sx = new SanXuatLenhInfo();
        SanXuatCTietLenhInfo sxct = new SanXuatCTietLenhInfo();
        //private bool success;
        List<SanXuatLenhInfo> litmpSX = new List<SanXuatLenhInfo>();
        List<SanXuatLenhInfo> liChiTiet = new List<SanXuatLenhInfo>();
        List<SanXuatCTietLenhInfo> litmpCT = new List<SanXuatCTietLenhInfo>();
        public string MaLenh = "";
        public string MaThanhPham;
        public string TenThanhPham;
        public int idThanhPham;
        public int SoLuongYC;
        public int SoLuongCT;
        private string MaTrungTam;
        private string MaKho;
        private int Trangthai;
        private int status;
        public DateTime NgayLap;
        #endregion

        #region frmDanhSachNhapComBo
        public frmDanhSachNhapComBo()
        {
            InitializeComponent();
        }
        #endregion

        #region Action

        //private void LoadTrangThai()
        //{
        //    List<TrangThaiBH> ls = new List<TrangThaiBH>();
        //    ls = StringEnum.GetStringValue(TrangThaiSanXuat.ChoXuat, TrangThaiSanXuat.DangSX, TrangThaiSanXuat.DaSanXuatXong);
        //    colTrangThai.DataSource = ls;
        //    colTrangThai.DisplayMember = "Name";
        //    colTrangThai.ValueMember = "Id";
        //}

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
            currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
            currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);

            string inventoryOrg = currentTrungTam.MaTrungTam;
            string inventorySub = currentKho.MaKho;

            frmProgress.Instance.Description = "Đang xóa dữ liệu tạm...";

            //NhapHangProvider.ClearTemporary(inventoryOrg, inventorySub, Declare.UserId);
            SanXuatLenhProvier.tmpSanXuatDelete(inventoryOrg);
            SanXuatLenhProvier.tmpSanXuatCTietDelete(inventoryOrg);

            frmProgress.Instance.Value += 1;

            frmProgress.Instance.Description = "Đang đồng bộ dữ liệu...";

            bool success = false;
            success = BusinessSynchronize.Instance.LenhSanXuatSyncV2(dteLastSync.DateTime.ToString("yyyy/MM/dd hh:mm:ss"), inventoryOrg, "GHEPMA");

            frmProgress.Instance.Value += 1;

            frmProgress.Instance.Description = "Đang cập nhật lại lịch sử...";

            litmpSX = SanXuatLenhProvier.GetAlltmpSanXuatLenh(MaTrungTam,"GHEPMA");
            litmpCT = SanXuatLenhProvier.GetAlltmpCTSanXuatLenh(MaTrungTam);
            for (int i = 0; i < litmpSX.Count; i++)
            {
                sx.MaLenh = litmpSX[i].MaLenh;
                sx.MaThanhPham = litmpSX[i].MaThanhPham;
                sx.NgayLap = litmpSX[i].NgayLap;
                sx.NguoiLap = litmpSX[i].NguoiLap;
                sx.OrgCode = litmpSX[i].OrgCode;
                sx.SoLuongTP = litmpSX[i].SoLuongTP;
                sx.Status = litmpSX[i].Status;
                sx.Loai_Ma_Lenh = litmpSX[i].Loai_Ma_Lenh;
                sx.Last_update_date = litmpSX[i].Last_update_date;
                int SoLuongHT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                Convert.ToInt32(TransactionType.NHAP_COMBO), litmpSX[i].MaLenh, currentTrungTam.MaTrungTam);
                if (SoLuongHT == 0)
                {
                    liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.ChoXuat);
                }
                if (SoLuongHT > 0 && SoLuongHT < litmpSX[i].SoLuongTP &&
                    (litmpSX[i].Status != 2 || litmpSX[i].Status != 3))
                {
                    liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX);
                }
                if (SoLuongHT == litmpSX[i].SoLuongTP && litmpSX[i].Status != 2)
                {
                    liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.DaSanXuatXong);
                }
                if (litmpSX[i].Status == 2)
                {
                    liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.HuyLenh);
                }
                if (SoLuongHT != litmpSX[i].SoLuongTP && litmpSX[i].Status == 3)
                {
                    liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.NgungSanXuat);
                }

                
                if (SanXuatLenhProvier.CheckMaLenh(litmpSX[i].MaLenh, litmpSX[i].MaThanhPham,currentTrungTam.MaTrungTam) == 0)
                {
                    SanXuatLenhProvier.Insert(sx);
                }
                else
                {
                    SanXuatLenhProvier.Update(sx);
                }
            }
            for (int i = 0; i < litmpSX.Count; i++)
            {
                SanXuatCTietLenhProvider.Delete(litmpSX[i].MaLenh,currentTrungTam.MaTrungTam);
            }
            for (int i = 0; i < litmpCT.Count; i++)
            {
                sxct.MaLenh = litmpCT[i].MaLenh;
                sxct.MaLinhKien = litmpCT[i].MaLinhKien;
                sxct.NgayCanXuat = litmpCT[i].NgayCanXuat;
                sxct.OrgCode = litmpCT[i].OrgCode;
                sxct.SoLuongCanXuat = litmpCT[i].SoLuongCanXuat;
                sxct.SoLuongDaXuat = litmpCT[i].SoLuongDaXuat;
                sxct.SoLuongTrenTPham = litmpCT[i].SoLuongTrenTPham;
                sxct.KhoXuat = litmpCT[i].KhoXuat;
                if (SanXuatLenhProvier.CheckCtietMaLenh(litmpCT[i].MaLenh, currentTrungTam.MaTrungTam, litmpCT[i].MaLinhKien) == 0)
                {
                    SanXuatCTietLenhProvider.Insert(sxct);
                }
                else
                {
                    SanXuatCTietLenhProvider.Update(sxct);
                }
                //SanXuatCTietLenhProvider.Insert(sxct);
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

            LockControl.Unlock("SynsNhapThanhPham");
        }

        //private void LoadDateTime()
        //{
        //    DateTime dt = SanXuatLenhProvier.GetMaxDateSanXuatLenh(MaTrungTam);

        //    dtLanDongBoTruoc.Value = dt.AddDays(1);
        //}
        public void LoadTrangthai()
        {
            List<LookUp> lst = new List<LookUp>();
            lst.Add(new LookUp { OID = 1, Name = "Chờ xuất" });
            lst.Add(new LookUp { OID = 2, Name = "Đang xuất" });
            lst.Add(new LookUp { OID = 3, Name = "Đã xuất đủ" });
            lst.Add(new LookUp { OID = 4, Name = "Ngừng sản xuất" });
            lst.Add(new LookUp { OID = 5, Name = "Phiếu đã hủy" });
            repTrangThai.DataSource = lst;
        }
        private void GetValue()
        {
            if (grvChiTiet.FocusedRowHandle == null) throw new ManagedException("Xin hãy chọn dữ liệu !");
            SanXuatLenhInfo sx = (SanXuatLenhInfo)grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);
            MaLenh = liChiTiet[liChiTiet.IndexOf(sx)].MaLenh;
            MaThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].MaThanhPham;
            TenThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].TenThanhPham;
            SoLuongYC = liChiTiet[liChiTiet.IndexOf(sx)].SoLuongTP;
            idThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].idThanhPham;
            Trangthai = liChiTiet[liChiTiet.IndexOf(sx)].TrangThai;
            status = liChiTiet[liChiTiet.IndexOf(sx)].Status;
            NgayLap = liChiTiet[liChiTiet.IndexOf(sx)].NgayLap;
            SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                Convert.ToInt32(TransactionType.NHAP_COMBO), liChiTiet[liChiTiet.IndexOf(sx)].MaLenh,currentTrungTam.MaTrungTam);
        }

        private void CheckTrangthai()
        {
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                liChiTiet[i].SoLuongHT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                Convert.ToInt32(TransactionType.NHAP_COMBO), liChiTiet[i].MaLenh,currentTrungTam.MaTrungTam);

                if (liChiTiet[i].SoLuongHT == 0)
                {
                    sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.ChoXuat);
                }
                if (liChiTiet[i].SoLuongHT > 0 && liChiTiet[i].SoLuongHT < liChiTiet[i].SoLuongTP &&
                    (litmpSX[i].Status != 2 || litmpSX[i].Status != 3))
                {
                    sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX);
                }
                if (liChiTiet[i].SoLuongHT == liChiTiet[i].SoLuongTP && litmpSX[i].Status != 2)
                {
                    sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.DaSanXuatXong);
                }
                if (liChiTiet[i].Status == 2)
                {
                    sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.HuyLenh);
                }
                if (liChiTiet[i].SoLuongHT != liChiTiet[i].SoLuongTP && liChiTiet[i].Status == 3)
                {
                    sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.NgungSanXuat);
                }
                SanXuatLenhProvier.Update(liChiTiet[i]);
            }
            
            LoadTrangthai();
        }

        #endregion

        public void Reload()
        {
            liChiTiet = SanXuatLenhProvier.GetAllSanXuatLenh(MaKho, MaTrungTam,"GHEPMA");
            CheckTrangthai();
            dgvChiTiet.DataSource = liChiTiet;
        }

        private void btnDongBo_Click(object sender, EventArgs e)
        {
            string functionName = "SynsNhapThanhPham";

            LockControl.Lock(functionName);
            frmProgress.Instance.Text = "Đồng bộ dữ liệu";
            frmProgress.Instance.MaxValue = 3;
            frmProgress.Instance.DoWork(SynsNhapThanhPham);
            liChiTiet = SanXuatLenhProvier. GetAllSanXuatLenh(MaKho,MaTrungTam,"GHEPMA");
            
            CheckTrangthai();
            dgvChiTiet.DataSource = liChiTiet;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            LockControl.Unlock("SynsNhapThanhPham");
            this.Close();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            GetValue();
            if (status != 2)
            {
                if (MaLenh != "")
                {
                    frmChiTietNhapDoiMa frm = new frmChiTietNhapDoiMa(this, MaLenh, 0,currentTrungTam.MaTrungTam);
                    frm.ShowDialog();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Phiếu đã hủy không thể nhập cho phiếu này !");
                return;
            }
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            GetValue();
            if (status != 2)
            {
                if (MaLenh != "")
                {
                    frmChiTietNhapDoiMa frm = new frmChiTietNhapDoiMa(this, MaLenh, 0,currentTrungTam.MaTrungTam);
                    frm.ShowDialog();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Phiếu đã hủy không thể nhập cho phiếu này !");
                return;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (liChiTiet.Count > 0)
            {
                frmTimKiemMaVach frm = new frmTimKiemMaVach(this.MaTrungTam);
                frm.ShowDialog();
            }
        }

        private void frmDanhSachNhapThanhPham_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void btnListXLK_Click(object sender, EventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle == null) throw new ManagedException("Xin hãy chọn dữ liệu !");
            SanXuatLenhInfo sx = (SanXuatLenhInfo)grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);
            frmDanhSachXuatLinhKien frm = new frmDanhSachXuatLinhKien(sx.MaLenh, TransactionType.XUAT_COMBO);
            frm.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.DevExport2Excel(grvChiTiet);
        }

        private void frmDanhSachNhapComBo_Load(object sender, EventArgs e)
        {
            btnTim.Visible = false;
            clsUtils.NullColumnDateTimeGrid(repdtngaylap);
            LoadTrangthai();
            btnTim.Text = Resources.btnSearch;
            btnChiTiet.Text = Resources.btnInfor;
            MaTrungTam = GetMaTrungTam();
            MaKho = GetMaKho();
            dteLastSync.DateTime = SanXuatLenhProvier.GetMaxDateSanXuatLenh(MaTrungTam);
            //LoadDateTime();
            liChiTiet = SanXuatLenhProvier.GetAllSanXuatLenh(MaKho, MaTrungTam, "GHEPMA");
            CheckTrangthai();
            dgvChiTiet.DataSource = liChiTiet;
        }
    }
}