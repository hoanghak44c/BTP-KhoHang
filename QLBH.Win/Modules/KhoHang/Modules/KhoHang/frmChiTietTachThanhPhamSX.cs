using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTietTachThanhPhamSX : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        private SanXuatNhapTachInfo sanXuatNhapTachInfo;
        List<ChungTuXuatNhapNccChiTietInfo> liChiTiet = new List<ChungTuXuatNhapNccChiTietInfo>();
        private frmDanhSachTachThanhPhamSX frm;
        private XuatThanhPhamSXBussiness XTP = new XuatThanhPhamSXBussiness(new ChungTuXuatNhapNccInfo());
        NhapLinhKienSXBussiness NLK = new NhapLinhKienSXBussiness(new ChungTuXuatNhapNccInfo());
        private int SLDN;
        #endregion

        #region frmChiTietTachThanhPhamSX
        public frmChiTietTachThanhPhamSX()
        {
            InitializeComponent();
        }
        public frmChiTietTachThanhPhamSX(frmDanhSachTachThanhPhamSX frm)
        {
            this.frm = frm;
            InitializeComponent();
        }
        #endregion

        #region Action

        private void LoadData()
        {
            SLDN = frm.SoLuongCT;
            txtMaSP.Text = frm.MaThanhPham;
            txtTenSP.Text = frm.TenThanhPham;
            txtMaLenh.Text = frm.MaLenh;
            txtSoLuongDN.Text = SLDN.ToString();
            txtSoLuongYC.Text = frm.SoLuongYC.ToString();
            txtMaThanhPham.Focus();
        }

        private void Clear()
        {
            txtMaThanhPham.Text = "";
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                liChiTiet[i].check = false;
            }
            SLDN++;
            txtSoLuongDN.Text = SLDN.ToString();
            dgvChiTiet.DataSource = null;
            txtMaThanhPham.Focus();
        }

        private void Save()
        {
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (liChiTiet[i].check == false)
                {
                    throw new ManagedException("Bạn chưa xác nhận đủ mã vạch linh kiện để tách thành phẩm !");
                }
            }
            int SoLuongCT = SanXuatLenhProvier.GetSoLuongChungTu(
                Convert.ToInt32(TransactionType.XUAT_THANH_PHAM),
                txtMaLenh.Text.Trim(), 1, frm.TransactionID);
            if (Convert.ToInt32(txtSoLuongYC.Text) <= SoLuongCT)
            {
                throw new ManagedException("Số lượng yêu cầu đã đủ không thể nhập thêm !");
            }
            if (string.IsNullOrEmpty(dtNgayLap.Text))
            {
                dtNgayLap.Focus();
                throw new ManagedException("Bạn chưa trọn ngày lập !");
            }
            if (Convert.ToDateTime(dtNgayLap.EditValue) < frm.NgayLap)
            {
                dtNgayLap.Focus();
                throw new ManagedException("Ngày nhập thành phẩm không được nhỏ hơn ngày lập của mã lệnh!");
            }
            try
            {
                SaveNhapLinhKien(SaveXuatThanhPham());

                string maLenh = txtMaVachLK.Text.Trim();
                string maThanhPham = txtMaSP.Text.Trim();
                int soLuongYc = frm.SoLuongYC;
                string transactionId = frm.TransactionID;

                frmProgress.Instance.Caption = Text;
                frmProgress.Instance.Description = "Đang thực hiện ...";
                frmProgress.Instance.MaxValue = 100;
                frmProgress.Instance.Value = 0;

                frmProgress.Instance.DoWork(
                    delegate
                    {
                        try
                        {
                            ConnectionUtil.Instance.BeginTransaction();

                            ChungTuBusinessBase businessCloned = XTP.Clone();

                            ((XuatThanhPhamSXBussiness)businessCloned).ChungTu.NgayLap =
                                CommonProvider.Instance.GetSysDate();

                            ((XuatThanhPhamSXBussiness)businessCloned).ChungTu.NgayXuatHang =
                                CommonProvider.Instance.GetSysDate();

                            businessCloned.SaveChungTu();

                            businessCloned = NLK.Clone();

                            ((NhapLinhKienSXBussiness)businessCloned).ChungTu.NgayLap =
                                CommonProvider.Instance.GetSysDate();

                            ((NhapLinhKienSXBussiness)businessCloned).ChungTu.NgayXuatHang =
                                CommonProvider.Instance.GetSysDate();

                            businessCloned.SaveChungTu();

                            KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(new ChungTuXuatNhapNccInfo { IdChungTu = sanXuatNhapTachInfo.IdChungTu, TrangThai = 2 });

                            if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX), maLenh, 1) != soLuongYc)
                            {
                                SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo
                                {
                                    MaLenh = maLenh,
                                    MaThanhPham = maThanhPham,
                                    TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX)
                                });
                            }

                            SoLuongCT = SanXuatLenhProvier.GetSoLuongChungTu(
                                Convert.ToInt32(TransactionType.XUAT_THANH_PHAM), maLenh, 1, transactionId);

                            if (soLuongYc < SoLuongCT)
                            {
                                throw new ManagedException("Số lượng yêu cầu đã đủ không thể nhập thêm!");
                            }    

                            ConnectionUtil.Instance.CommitTransaction();

                            frmProgress.Instance.Description = "Đã xong!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;

                        }
                        catch (Exception ex)
                        {
                            ConnectionUtil.Instance.RollbackTransaction();

                            MessageBox.Show(ex.Message);

                            frmProgress.Instance.Description = "Giao dịch không thành công!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;

                            if (!(ex is ManagedException))
                            {
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Tách thành phẩm SX");
                            }
                        }
                    });

                //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
                //    delegate
                //        {
                //            ChungTuBusinessBase businessCloned = XTP.Clone();
                            
                //            ((XuatThanhPhamSXBussiness)businessCloned).ChungTu.NgayLap =
                //                CommonProvider.Instance.GetSysDate();

                //            ((XuatThanhPhamSXBussiness)businessCloned).ChungTu.NgayXuatHang =
                //                CommonProvider.Instance.GetSysDate();

                //            businessCloned.SaveChungTu();

                //            businessCloned = NLK.Clone();

                //            ((NhapLinhKienSXBussiness) businessCloned).ChungTu.NgayLap =
                //                CommonProvider.Instance.GetSysDate();

                //            ((NhapLinhKienSXBussiness)businessCloned).ChungTu.NgayXuatHang =
                //                CommonProvider.Instance.GetSysDate();
                            
                //            businessCloned.SaveChungTu();

                //            KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(new ChungTuXuatNhapNccInfo { IdChungTu = sanXuatNhapTachInfo.IdChungTu, TrangThai = 2 });

                //            if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX), maLenh, 1) != soLuongYc)
                //            {
                //                SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo
                //                {
                //                    MaLenh = maLenh,
                //                    MaThanhPham = maThanhPham,
                //                    TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX)
                //                });
                //            }

                //            SoLuongCT = SanXuatLenhProvier.GetSoLuongChungTu(
                //                Convert.ToInt32(TransactionType.XUAT_THANH_PHAM), maLenh, 1, transactionId);

                //            if (soLuongYc < SoLuongCT)
                //            {
                //                throw new ManagedException("Số lượng yêu cầu đã đủ không thể nhập thêm!");
                //            }                            
                //        });

                Clear();
                frm.Reload();
                //clsUtils.MsgThongBao("Tách thành công 1 thành phẩm !");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SaveXuatThanhPham()
        {
            ChungTuXuatNhapNccInfo ct = XTP.ChungTu;
            ct.SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatThanhPham);
            ct.SoPhieuNhap = txtMaLenh.Text.Trim();
            ct.SoPO = frm.TransactionID;
            ct.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_THANH_PHAM);
            ct.IdKho = Declare.IdKho;
            ct.IdNhanVien = Declare.IdNhanVien;
            ct.NgayLap = CommonProvider.Instance.GetSysDate();
            ct.NgayXuatHang = CommonProvider.Instance.GetSysDate();
            ct.TrangThai = 1;
            XTP.ListChiTietChungTu.Clear();
            XTP.ListChiTietHangHoa.Clear();
            XTP.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                                           {
                                               IdSanPham = frm.IdSanPham,
                                               MaSanPham = txtMaSP.Text.Trim(),
                                               SoLuong = 1
                                           });

            XTP.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                                           {
                                               IdSanPham = frm.IdSanPham,
                                               SoLuong = 1,
                                               MaVach = txtMaThanhPham.Text.Trim()
                                           });
            //SaveNhapLinhKien(ct.SoChungTu);
            //hah: khong goi save chung tu tai day.
            //XTP.SaveChungTu();
            return ct.SoChungTu;
        }

        private void SaveNhapLinhKien(string sochungtugoc)
        {
            ChungTuXuatNhapNccInfo ct = NLK.ChungTu;
            ct.SoPO = sochungtugoc;
            ct.SoPhieuNhap = sochungtugoc;
            ct.SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapLinhKien);
            ct.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_LINH_KIEN);
            ct.IdKho = Declare.IdKho;
            ct.IdNhanVien = Declare.IdNhanVien;
            ct.NgayLap = CommonProvider.Instance.GetSysDate();
            ct.NgayXuatHang = CommonProvider.Instance.GetSysDate();
            ct.TrangThai = 1;
            NLK.ListChiTietChungTu.Clear();
            NLK.ListChiTietHangHoa.Clear();
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (!NLK.ListChiTietChungTu.Exists(delegate (ChungTuXuatNhapNccChiTietInfo match)
                                                       {
                                                          return match.IdSanPham == liChiTiet[i].IdSanPham;
                                                       }))
                {
                   NLK.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                                                  {
                                                      IdSanPham = liChiTiet[i].IdSanPham,
                                                      MaSanPham = liChiTiet[i].MaSanPham,
                                                      SoLuong = 1
                                                  }); 
                }
                else
                {
                    ChungTuXuatNhapNccChiTietInfo ChungTuXuatNhapNccChiTietInfo =
                        NLK.ListChiTietChungTu.Find(delegate(ChungTuXuatNhapNccChiTietInfo match)
                                                        {
                                                            return match.IdSanPham == liChiTiet[i].IdSanPham;
                                                        });
                    ChungTuXuatNhapNccChiTietInfo.SoLuong++;
                }
                NLK.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                                               {
                                                   IdSanPham = liChiTiet[i].IdSanPham,
                                                   SoLuong = liChiTiet[i].SoLuong,
                                                   MaVach = liChiTiet[i].MaVach
                                               });
            }
            //hah khong goi save chung tu tai day.
            //NLK.SaveChungTu();
        }

        private void Them()
        {
            bool check = false;
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (liChiTiet[i].MaVach.Equals(txtMaVachLK.Text.Trim()))
                {
                    liChiTiet[i].check = true;
                    txtMaVachLK.Text = "";
                    txtMaVachLK.Focus();
                    dgvChiTiet.DataSource = null;
                    dgvChiTiet.DataSource = liChiTiet;
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                txtMaVachLK.Focus();
                throw new InvalidOperationException("Linh kiện không tồn tại trong sản phẩm !");
            }
            
        }

        #endregion

        #region Event
        private void frmChiTietTachThanhPhamSX_Load(object sender, EventArgs e)
        {
            LoadData();
            dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            dtNgayLap.Enabled = false;
        }

        private void txtMaThanhPham_Leave(object sender, EventArgs e)
        {
            try
            {
                ChungTuXuatNhapNccChiTietInfo li =
                SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachCheckMaVach(
                    Convert.ToInt32(TransactionType.XUAT_THANH_PHAM), txtMaThanhPham.Text.Trim());
                if (li != null)
                {
                    throw new InvalidOperationException("Bạn đã tách thành phẩm có mã vạch: " + txtMaThanhPham.Text.Trim() + " ! Xin hãy kiểm tra lại");
                }
                if (txtMaThanhPham.Text != "")
                {
                    sanXuatNhapTachInfo =
                        SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachGetByMaVach(txtMaThanhPham.Text.Trim(),txtMaLenh.Text.Trim());

                    if (sanXuatNhapTachInfo != null)
                    {
                        DMChungTuNhapInfo ct = SanXuatNhapTachDataProvider.Instance.GetChungTuNhapThanhPhamBySoChungTuGoc(sanXuatNhapTachInfo.SoChungTu);
                        liChiTiet = SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachCTGetBySoChungTu(ct.SoChungTu, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX));
                        dgvChiTiet.AutoGenerateColumns = false;
                        dgvChiTiet.DataSource = null;
                        dgvChiTiet.DataSource = liChiTiet;
                        txtMaVachLK.Focus();
                    }
                    else
                    {
                        throw new InvalidOperationException("Không tìm thấy dữ liệu phù hợp trong hệ thống");
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Them();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void txtMaVachLK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Them();
                }
                catch (Exception ex)
                {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                    EventLogProvider.Instance.WriteLog(ex.ToString()
                        + "\nUser: " + Declare.UserName
                        + "\nKho: " + Declare.IdKho,
                        this.Name);
                }
            }
        }

        private void frmChiTietTachThanhPhamSX_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void txtMaThanhPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ChungTuXuatNhapNccChiTietInfo li =
                    SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachCheckMaVach(
                        Convert.ToInt32(TransactionType.XUAT_THANH_PHAM), txtMaThanhPham.Text.Trim());
                    if (li != null)
                    {
                        throw new InvalidOperationException("Bạn đã tách thành phẩm có mã vạch: " + txtMaThanhPham.Text.Trim() + " ! Xin hãy kiểm tra lại");
                    }
                    if (txtMaThanhPham.Text != "")
                    {
                        sanXuatNhapTachInfo =
                            SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachGetByMaVach(txtMaThanhPham.Text.Trim(),txtMaLenh.Text.Trim());

                        if (sanXuatNhapTachInfo != null)
                        {
                            DMChungTuNhapInfo ct = SanXuatNhapTachDataProvider.Instance.GetChungTuNhapThanhPhamBySoChungTuGoc(sanXuatNhapTachInfo.SoChungTu);
                            liChiTiet = SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachCTGetBySoChungTu(ct.SoChungTu, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX));
                            dgvChiTiet.AutoGenerateColumns = false;
                            dgvChiTiet.DataSource = null;
                            dgvChiTiet.DataSource = liChiTiet;
                            txtMaVachLK.Focus();
                        }
                        else
                        {
                            throw new InvalidOperationException("Không tìm thấy dữ liệu phù hợp trong hệ thống");
                        }
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                    EventLogProvider.Instance.WriteLog(ex.ToString()
                        + "\nUser: " + Declare.UserName
                        + "\nKho: " + Declare.IdKho,
                        this.Name);
                }
            }
        }
    }
}