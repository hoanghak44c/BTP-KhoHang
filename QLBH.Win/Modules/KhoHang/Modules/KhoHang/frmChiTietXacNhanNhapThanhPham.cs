using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;
using QLBH.Common.Providers;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTietXacNhanNhapThanhPham : DevExpress.XtraEditors.XtraForm
    {
        #region Declare

        private SanXuatNhapTachInfo lst;
        List<ChungTuXuatNhapNccChiTietInfo> liChiTiet = new List<ChungTuXuatNhapNccChiTietInfo>();
        private frmDanhSachXacNhanNhapThanhPham frm;
        XacNhanNhapThanhPhanSanXuatBussiness XN ;
        private int SLDN;
        #endregion

        #region frmChiTietXacNhanNhapThanhPham
        public frmChiTietXacNhanNhapThanhPham()
        {
            InitializeComponent();
        }
        public frmChiTietXacNhanNhapThanhPham(frmDanhSachXacNhanNhapThanhPham frm)
        {
            this.frm = frm;
            InitializeComponent();
        }
        #endregion

        #region Action

        private void UpdateTrangthai()
        {
            if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX),
                                                                 txtMaLenh.Text.Trim(), 1) == frm.SoLuongYC)
            {
                SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo
                {
                    MaLenh = txtMaLenh.Text.Trim(),
                    MaThanhPham = txtMaSP.Text.Trim(),
                    TrangThai = Convert.ToInt32(TrangThaiSanXuat.DaSanXuatXong)
                });
            }
        }

        private void Save()
        {
            try
            {
                ConnectionUtil.Instance.BeginTransaction();
                if (liChiTiet.Count > 0)
                {
                    int SoLuongCT = SanXuatLenhProvier.GetSoLuongXacNhanNhap(
                    Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX),
                    txtMaLenh.Text.Trim(), 1, frm.TransactionID) +
                    SanXuatLenhProvier.GetSoLuongXacNhanNhap(
                    Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX),
                    txtMaLenh.Text.Trim(), 2, frm.TransactionID);
                    if (Convert.ToInt32(txtSoLuongYC.Text) <= SoLuongCT)
                    {
                        throw new ManagedException("Số lượng yêu cầu cho thành phẩm đã đủ,không thể nhập thêm !");
                    }
                    if (string.IsNullOrEmpty(dtNgayLap.Text))
                    {
                        dtNgayLap.Focus();
                        throw new ManagedException("Bạn chưa trọn ngày lập!");
                    }
                    if (Convert.ToDateTime(dtNgayLap.EditValue) < frm.NgayLap)
                    {
                        dtNgayLap.Focus();

                        throw new ManagedException("Ngày tách không được nhở hơn ngày lập của mã lệnh!");
                    }
                    if (string.IsNullOrEmpty(txtMaThanhPham.Text.Trim()))
                    {
                        throw new ManagedException("Mã vạch thành phẩm không được để trống !");
                    }

                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckXacNhanNhapMaVachTP(lst.IdChungTu, frm.idThanhPham, txtMaThanhPham.Text.Trim()) > 0)
                    {
                        txtMaThanhPham.Focus();

                        throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy đổi mã vạch khác !");
                    }
                    ChungTuXuatNhapNccInfo ct = new ChungTuXuatNhapNccInfo();
                    ct.IdChungTu = lst.IdChungTu;
                    ct.TrangThai = 1;
                    ct.SoChungTu = lst.SoChungTu;
                    ct.IdKho = lst.idKho;
                    ct.IdNhanVien = lst.idNhanVien;
                    ct.NgayLap = lst.NgayLap;
                    ct.SoPO = frm.TransactionID;
                    ct.SoPhieuNhap = lst.MaLenh;
                    ct.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX);
                    dtNgayLap.EditValue = ct.NgayXuatHang;
                    XN = new XacNhanNhapThanhPhanSanXuatBussiness(ct);
                    XN.ListChiTietHangHoa.Clear();
                    XN.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                    {
                        IdSanPham = frm.idThanhPham,
                        SoLuong = 1,
                        MaVach = XN.ListChiTietChungTu[0].DanhSachMaVach
                    });
                    ct.NgayXuatHang = CommonProvider.Instance.GetSysDate();
                    XN.SaveChungTu();
                    UpdateTrangthai();
                    SoLuongCT = SanXuatLenhProvier.GetSoLuongXacNhanNhap(
                    Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX),
                    txtMaLenh.Text.Trim(), 1, frm.TransactionID) +
                    SanXuatLenhProvier.GetSoLuongXacNhanNhap(
                    Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX),
                    txtMaLenh.Text.Trim(), 2, frm.TransactionID);
                    if (Convert.ToInt32(txtSoLuongYC.Text) < SoLuongCT)
                    {
                        throw new ManagedException("Số lượng yêu cầu cho thành phẩm đã đủ,không thể nhập thêm !");
                    }
                    ConnectionUtil.Instance.CommitTransaction();
                    clsUtils.MsgThongBao("Đã xác nhận 1 thành phẩm !");
                    Clear();
                    frm.ReLoad();
                }
            }
            catch (Exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw;
            }
        }

        private void Clear()
        {
            txtMaThanhPham.Text = "";
            txtMaThanhPham.Focus();
            liChiTiet.Clear();
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = liChiTiet;
            SLDN++;
            txtSoLuongDN.Text = SLDN.ToString();
        }

        private void LoadData()
        {
            SLDN = frm.SoLuongCT;
            txtMaThanhPham.Focus();
            txtMaLenh.Text = frm.MaLenh;
            txtMaSP.Text = frm.MaThanhPham;
            txtTenSP.Text = frm.TenThanhPham;
            txtSoLuongDN.Text = SLDN.ToString();
            txtSoLuongYC.Text = frm.SoLuongYC.ToString();
        }

        

        #endregion

        #region Event

        private void btnDong_Click(object sender, EventArgs e)
        {
            //frm.ReLoad();
            this.Close();
        }

        private void frmChiTietXacNhanNhapThanhPham_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }
        private void txtMaThanhPham_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMaThanhPham.Text != "")
                {
                    lst =
                        SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachGetByMaVach(txtMaThanhPham.Text.Trim(),txtMaLenh.Text.Trim());
                    
                    if (lst != null)
                    {
                        if (lst.TrangThai == 0)
                        {
                            DMChungTuNhapInfo ct = SanXuatNhapTachDataProvider.Instance.GetChungTuNhapThanhPhamBySoChungTuGoc(lst.SoChungTu);
                            if (ct != null)
                            {
                                liChiTiet = SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachCTGetBySoChungTu(ct.SoChungTu, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX));
                                dgvChiTiet.AutoGenerateColumns = false;
                                dgvChiTiet.DataSource = null;
                                dgvChiTiet.DataSource = liChiTiet;
                            }
                            else
                            {
                                txtMaThanhPham.Text = "";
                                txtMaThanhPham.Focus();
                                throw new ManagedException("Không tìm thấy dữ liệu phù hợp trong hệ thống");
                            }
                            
                        }
                        else
                        {
                            txtMaThanhPham.Text = "";
                            txtMaThanhPham.Focus();
                            throw new ManagedException("Bạn đã xác nhận nhập cho mã vạch này rồi ! Xin hãy kiểm tra lại");
                        }
                    }
                    else
                    {
                        txtMaThanhPham.Text = "";
                        txtMaThanhPham.Focus();
                        throw new ManagedException("Không tìm thấy dữ liệu phù hợp trong hệ thống");
                    }
                }
            }
            catch(ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif                
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

        private void frmChiTietXacNhanNhapThanhPham_Load(object sender, EventArgs e)
        {
            LoadData();
            dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            dtNgayLap.Enabled = false;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
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
        #endregion

        private void txtMaThanhPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtMaThanhPham.Text != "")
                    {
                        lst =
                            SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachGetByMaVach(txtMaThanhPham.Text.Trim(),txtMaLenh.Text.Trim());

                        if (lst != null)
                        {
                            if (lst.TrangThai != 2)
                            {
                                DMChungTuNhapInfo ct = SanXuatNhapTachDataProvider.Instance.GetChungTuNhapThanhPhamBySoChungTuGoc(lst.SoChungTu);
                                if (ct != null)
                                {
                                    liChiTiet = SanXuatNhapTachDataProvider.Instance.SanXuatNhapTachCTGetBySoChungTu(ct.SoChungTu, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX));
                                    dgvChiTiet.AutoGenerateColumns = false;
                                    dgvChiTiet.DataSource = null;
                                    dgvChiTiet.DataSource = liChiTiet;
                                }
                                else
                                {
                                    txtMaThanhPham.Text = "";
                                    txtMaThanhPham.Focus();
                                    throw new ManagedException("Không tìm thấy dữ liệu phù hợp trong hệ thống");
                                }
                            }
                            else
                            {
                                txtMaThanhPham.Text = "";
                                txtMaThanhPham.Focus();
                                throw new ManagedException("Bạn đã xác nhận nhập cho mã vạch này rồi ! Xin hãy kiểm tra lại");
                            }
                        }
                        else
                        {
                            txtMaThanhPham.Text = "";
                            txtMaThanhPham.Focus();
                            throw new ManagedException("Không tìm thấy dữ liệu phù hợp trong hệ thống");
                        }
                    }
                }
                catch (ManagedException ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                    MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
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