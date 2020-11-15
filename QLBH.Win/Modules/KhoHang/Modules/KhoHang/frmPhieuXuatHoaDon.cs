using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
//using QLBanHang.Class.Objects;
using QLBanHang.Modules.DanhMuc;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Common.Objects;
using QLBanHang.Modules;
using QLBH.Core.Exceptions;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuatHoaDon : Form
    {
        #region "Khai báo biến"
        DataTable dtKhachHang = null;
        DataTable dtNhanVien = null;
        DataTable dtPhieuXuat = null;
        DataTable dtPXSearch = null;
        DataTable dtDiaChi = null;
        DataTable dtOrderType = null;
        DataTable dtOrderTypeKM = null;
        public int IdPhieuXuat = 0;
        public int IndexPX = 0;
        public int IndexPXSearch = -1;
        private bool Updating = false;
        private int TyLe = 100;
        private List<HoaDon> listChungTu;
        private int IdPhieuThu = 0;
        private string SoTaiKhoan = "";
        private string NganHang = "";
        private string SoSerie = "";
        private bool ChuaDayOracle = true;
        string[] ThanhToan = { "Tiền mặt", "Chuyển khoản", "Thẻ ViSa", "Thẻ ViSa Master", "Thẻ ATM", "Đối trừ nội bộ" };
        private List<string> lstSoSeri = null;
        private bool NewHoaDon = true;

        //public int ChucNang = 1;//1: lập order; 2- lập hóa đơn
        public bool DaLapHoaDon = false;
        #endregion

        #region "Các phương thức khởi tạo"
        public frmPhieuXuatHoaDon()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmPhieuXuatHoaDon(DataTable dtPX, int IndexPXSearch)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.IndexPXSearch = IndexPXSearch;
            this.dtPXSearch = dtPX;
            this.IdPhieuXuat = int.Parse(this.dtPXSearch.Rows[IndexPXSearch]["IdPhieuXuat"].ToString());
            this.tsbPrev.Enabled = false;
            this.tsbNext.Enabled = false;
            this.tsbAdd.Enabled = false;
            this.tsbEdit.Enabled = false;
            this.tsbUpdate.Enabled = true;
            this.tsbDelete.Enabled = true;
            this.Text = "Cập nhật phiếu xuất kho.";
        }

        #endregion

        #region "Các phương thức"

        private void PhieuXuat_KhoiTaoSoPhieu()
        {
            this.txtSoPhieu.Text = Common.TaoSoPhieuTuDong("PX", "tbl_PhieuXuat", "SoPhieuXuat");
        }
        private string PhieuXuat_LaySoPhieuThu()
        {
            return Common.TaoSoPhieuTuDong("PXT", "tbl_ThuChi", "SoPhieu");
        }
        private bool PhieuXuat_ThemMoi()
        {
            this.IdPhieuXuat = 0;
            this.DaLapHoaDon = false;
            this.NewHoaDon = true;
            this.PhieuXuat_KhoiTaoSoPhieu();
            this.mstNgayXuat.Value = DateTime.Now;//.ResetText();//.Text = DateTime.Today.ToString("dd/MM/yyyy");
            this.txtMaNhanVien.ResetText();
            this.txtMaKhachHang.ResetText();
            this.txtHoTenKhachHang.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            this.txtMaSoThue.ResetText();
            this.txtOrderType.ResetText();
            this.txtOrderTypeKM.ResetText();
            this.txtTuoi.ResetText();
            this.txtGhiChu.ResetText();
            this.txtBillTo.ResetText();
            this.txtShipTo.ResetText();

            //try { this.cboOrderType.SelectedIndex = -1; }
            //catch { }
            //try { this.cboOrderTypeKM.SelectedIndex = -1; }
            //catch { }
            //try { this.cboBillTo.SelectedIndex = -1; }
            //catch { }
            //try { this.cboShipTo.SelectedIndex = -1; }
            //catch { }
            //try
            //{
            //    this.cboNhanVien.SelectedIndex = -1;// Declare.IdNhanVien; 
            //}
            //catch (Exception ex) { }
            //try { this.cboKhoXuat.SelectedValue = Declare.IdKho; }
            //catch { }
            //try {
            //    this.cboKhachHang.SelectedIndex = -1;
            //    //this.cboKhachHang.SelectedValue = Declare.IdKHMacDinh; 
            //}
            //catch { }
            //try { this.cboGioiTinh.SelectedIndex = 0; }
            //catch { }
            LoadHoaDon(false);
            //this.cboBangKeThue.SelectedIndex = 0;
            //this.cboLoaiHoaDon.SelectedIndex = 0;
            //this.cboMaDuAn.SelectedIndex = 0;

            //this.cboLoaiTien.SelectedValue = Declare.IdTienTe;
            //try
            //{
            //    string str = "Select DISTINCT tt.TyGia From dbo.tbl_DM_TienTe tt Where tt.IdTienTe = " + cboLoaiTien.SelectedValue;
            //    double tygia = Convert.ToDouble(DBTools.getValue(str));
            //    this.txtTyGia.Text = Common.Double2Str(tygia);
            //}
            //catch (Exception ex) { ex.ToString(); }
            this.txtTongTienHang.Text = Common.Double2Str(0);
            this.txtTongTienCK.Text = Common.Double2Str(0);
            this.txtTongTienSauCK.Text = Common.Double2Str(0);
            this.txtTongTienVAT.Text = Common.Double2Str(0);
            this.txtTongTienThanhToan.Text = Common.Double2Str(0);
            this.txtTienThucTra.Text = Common.Double2Str(0);
            this.txtTienConNo.Text = Common.Double2Str(0);
            
            //try { this.cboHinhThucTT.SelectedIndex = 0; }
            //catch { }
            //try { this.cboLoaiTra.SelectedIndex = 0; }
            //catch { }

            this.dgvSanPhamBan.Rows.Clear();
            this.dgvHangKhuyenMai.Rows.Clear();
            this.txtMaVach.Text = "";
            this.txtGiaSanPham.Text = "";
            this.txtTenSanPham.Text = "";
            this.txtMaVach.Focus();
            this.txtMaVach.SelectAll();
            return true;
        }

        private bool PhieuXuat_SuHopLeCuaThongTin()
        {
            //
            //Sự hợp lệ của thông tin số phiếu xuất
            //
            if (this.txtSoPhieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số phiếu chưa nhập." + "\n" + "-Hãy nhập số phiếu", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.txtSoPhieu.Focus();
                return false;
            }
            //Kiem tra trung so phieu
            string sqlstr = "select * from tbl_PhieuXuat where SoPhieuXuat=N'" + this.txtSoPhieu.Text.Trim() + "' and IdPhieuXuat!=" + this.IdPhieuXuat;
            if (DBTools.ExistData(sqlstr))
            {
                MessageBox.Show("Số phiếu này đã có." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.txtSoPhieu.Focus();
                return false;
            }
            //
            //Sự hợp lệ của thông tin khách hàng 
            //
            if (this.cboKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn khách hàng." + "\n" + "-Hãy chọn khách hàng", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.cboKhachHang.Focus();
                return false;
            }
            if (this.cboBillTo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn địa chỉ hóa đơn." + "\n" + "-Hãy chọn địa chi Bill To", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.cboBillTo.Focus();
                return false;
            }
            if (this.cboShipTo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn địa chỉ Ship To." + "\n" + "-Hãy chọn địa chỉ Ship To", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.cboShipTo.Focus();
                return false;
            }

            if (this.cboOrderType.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn Order Type." + "\n" + "-Hãy chọn Order Type", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.cboOrderType.Focus();
                return false;
            }
            if (dgvHangKhuyenMai.RowCount > 0)
            {
                if (this.cboOrderTypeKM.SelectedIndex < 0)
                {
                    MessageBox.Show("Chưa chọn Order Type hàng khuyến mại." + "\n" + "-Hãy chọn Order Type Khuyến mại", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[1];
                    this.cboOrderTypeKM.Focus();
                    return false;
                }
                if (cboQuyenKM.SelectedValue == null || !Common.CheckHoaDon(txtSoSerieKM.Text, int.Parse(cboQuyenKM.SelectedValue.ToString())))
                {
                    MessageBox.Show("Số serie hóa đơn không đúng định dạng hoặc không có số này trong quyển hóa đơn.\nHãy nhập số serie khác", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[2];
                    this.txtSoSerieKM.Focus();
                    return false;
                }
                if (this.txtKyHieuKM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ký hiệu hóa đơn chưa nhập." + "\n" + "-Hãy nhập Ký hiệu hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[2];
                    this.txtKyHieuKM.Focus();
                    return false;
                }
                if (this.txtSoSerieKM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Số serie hóa đơn chưa nhập." + "\n" + "-Hãy nhập Số serie hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[2];
                    this.txtSoSerieKM.Focus();
                    return false;
                }
            }
            //Kiem tra hop le hoa don
            if (cboQuyen.SelectedValue == null || !Common.CheckHoaDon(txtSoSerie.Text, int.Parse(cboQuyen.SelectedValue.ToString())))
            {
                MessageBox.Show("Số serie hóa đơn không đúng định dạng hoặc không có số này trong quyển hóa đơn.\nHãy nhập số serie khác", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.txtSoSerie.Focus();
                return false;
            }
            if (this.txtKyHieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ký hiệu hóa đơn chưa nhập." + "\n" + "-Hãy nhập Ký hiệu hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.txtKyHieu.Focus();
                return false;
            }
            if (this.txtSoSerie.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số serie hóa đơn chưa nhập." + "\n" + "-Hãy nhập Số serie hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.txtSoSerie.Focus();
                return false;
            }
            //
            //Sự hợp lệ của thông tin ngày xuất
            //
            if (this.mstNgayXuat.Text.Trim().Length == 4)
            {
                MessageBox.Show("Ngày xuất chưa nhập." + "\n" + "-Hãy nhập ngày xuất", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }
            if (this.mstNgayXuat.Text.Trim().Length > 4 && this.mstNgayXuat.Text.Trim().Length < 10)
            {
                MessageBox.Show("Ngày xuất nhập chưa đúng." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }
            if (!Common.IsValidDate(mstNgayXuat.Text.Trim()))
            {
                MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }


            if (this.cboNhanVien.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn nhân viên." + "\n" + "-Hãy chọn nhân viên", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.cboNhanVien.Focus();
                return false;
            }

            if (this.cboBangKeThue.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thông tin bảng kê thuế." + "\n" + "-Hãy chọn bảng kê thuế", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[3];
                this.cboBangKeThue.Focus();
                return false;
            }
            if (this.cboLoaiHoaDon.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thông tin loại hóa đơn." + "\n" + "-Hãy chọn loại hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[3];
                this.cboLoaiHoaDon.Focus();
                return false;
            }
            if (this.cboLoaiTra.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thông tin thời hạn thanh toán." + "\n" + "-Hãy chọn thời hạn thanh toán", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboLoaiTra.Focus();
                return false;
            }
            //
            //Sự hợp lệ của thông tin tiền trả nhà của khách hàng
            //
            if (this.txtTienThucTra.Text.Trim().Length > 0)
            {
                if (!Common.ValidateDouble(this.txtTienThucTra.Text.Trim()))
                {
                    MessageBox.Show("Tiền trả của khách hàng phải có kiểu số." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTienThucTra.Focus();
                    return false;
                }
                if (Common.DoubleValue(this.txtTienThucTra.Text.Trim()) < 0 || Common.DoubleValue(this.txtTienThucTra.Text.Trim()) > Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()))
                {
                    MessageBox.Show("Tiền trả của khách hàng phải lớn hơn hoặc bằng 0 và nhỏ hơn hoặc bằng tổng tiền thanh toán" + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTienThucTra.Focus();
                    return false;
                }
            }
            //
            //Sự hợp lệ của thông tin chi tiết phiếu xuất
            //
            if (this.dgvSanPhamBan.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết phiếu xuất.", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvSanPhamBan.Focus();
                return false;
            }
            Common.FormatText(this);

            return true;
        }

        private void ThuChi_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            string phieuthu = PhieuXuat_LaySoPhieuThu();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Thu_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdPhieu", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@SoPhieu", phieuthu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayLap", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdNhanVien", this.cboNhanVien.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdDoiTuong", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NoiDungThuChi", this.txtGhiChu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoTien", Common.DoubleValue(txtTienThucTra.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdTienTe", Declare.IdTienTe).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyGia", 1).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoTienChu", Common.ReadNumner_(txtTienThucTra.Text)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoChungTuKem", 1).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ChungTuGoc", txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdThuChi", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
            this.IdPhieuThu = int.Parse(sqlcmd.Parameters["@IdPhieu"].Value.ToString());

        }
        private void PhieuXuat_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            if (dgvHangKhuyenMai.RowCount == 0)
            {
                this.cboQuyenKM.SelectedIndex = -1;
                this.txtKyHieuKM.Text = "";
                this.txtSoSerieKM.Text = "";
            }

            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_HoaDonKM_Insert";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@LoaiXuatNhap", (int)TransactionType.XUAT_BAN).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayXuat", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@QuyenSo", Common.IntValue(this.cboQuyen.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerie", this.txtSoSerie.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@QuyenKM", Common.IntValue(this.cboQuyenKM.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieuKM", this.txtKyHieuKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerieKM", this.txtSoSerieKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdNhanVien", this.cboNhanVien.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKhachHang", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GioiTinh", this.cboGioiTinh.SelectedIndex).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DoTuoi", Common.IntValue(this.txtTuoi.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DienThoai", this.txtDienThoai.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@MaSoThue", this.txtMaSoThue.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@OrderType", Common.IntValue(this.cboOrderType.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@OrderTypeKM", Common.IntValue(this.cboOrderTypeKM.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@BillTo", Common.IntValue(this.cboBillTo.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ShipTo", Common.IntValue(this.cboShipTo.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(this.txtTongTienHang.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienChietKhau", Common.DoubleValue(this.txtTongTienCK.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienSauChietKhau", Common.DoubleValue(this.txtTongTienSauCK.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienVAT", Common.DoubleValue(this.txtTongTienVAT.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienThanhToan", Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdTienTe", Declare.IdTienTe).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyGia", 1).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienThanhToanThuc", Common.DoubleValue(this.txtTienThucTra.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienConNo", Common.DoubleValue(this.txtTienConNo.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTien_Chu", Common.ReadNumner_(this.txtTongTienThanhToan.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucTra", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdBangKeThue", Common.IntValue(cboBangKeThue.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdLoaiHDBanHang", Common.IntValue(cboLoaiHoaDon.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdDuAn", Common.IntValue(cboMaDuAn.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoOrderKH", this.txtSoOrderKH.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NhapHoaDon", DaLapHoaDon).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            this.IdPhieuXuat = int.Parse(sqlcmd.Parameters["@IdPhieuXuat"].Value.ToString());
        }

        private void PhieuXuat_UpdateCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, bool ChuaXuatHD)
        {
            if (dgvHangKhuyenMai.RowCount == 0)
            {
                this.cboQuyenKM.SelectedIndex = -1;
                this.txtKyHieuKM.Text = "";
                this.txtSoSerieKM.Text = "";
            }
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (ChuaXuatHD)
                sqlcmd.CommandText = "sp_PhieuXuat_HoaDonKM_Update_TG";
            else
                sqlcmd.CommandText = "sp_PhieuXuat_HoaDonKM_Update";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", this.IdPhieuXuat).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@LoaiXuatNhap", (int)TransactionType.XUAT_BAN).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayXuat", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@QuyenSo", Common.IntValue(this.cboQuyen.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerie", this.txtSoSerie.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@QuyenKM", Common.IntValue(this.cboQuyenKM.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieuKM", this.txtKyHieuKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerieKM", this.txtSoSerieKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdNhanVien", this.cboNhanVien.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKhachHang", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GioiTinh", this.cboGioiTinh.SelectedIndex).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DoTuoi", Common.IntValue(this.txtTuoi.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DienThoai", this.txtDienThoai.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@MaSoThue", this.txtMaSoThue.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@OrderType", Common.IntValue(this.cboOrderType.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@OrderTypeKM", Common.IntValue(this.cboOrderTypeKM.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@BillTo", Common.IntValue(this.cboBillTo.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ShipTo", Common.IntValue(this.cboShipTo.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(this.txtTongTienHang.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienChietKhau", Common.DoubleValue(this.txtTongTienCK.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienSauChietKhau", Common.DoubleValue(this.txtTongTienSauCK.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienVAT", Common.DoubleValue(this.txtTongTienVAT.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienThanhToan", Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdTienTe", Declare.IdTienTe).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyGia", 1).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienThanhToanThuc", Common.DoubleValue(this.txtTienThucTra.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienConNo", Common.DoubleValue(this.txtTienConNo.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTien_Chu", Common.ReadNumner_(this.txtTongTienThanhToan.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucTra", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdBangKeThue", Common.IntValue(cboBangKeThue.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdLoaiHDBanHang", Common.IntValue(cboLoaiHoaDon.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdDuAn", Common.IntValue(cboMaDuAn.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NhapHoaDon", DaLapHoaDon).Direction = ParameterDirection.Input;

            if (!DBTools.UpdateRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }

        private void PhieuXuat_DeleteCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;

            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }

        private void CapNhat_HangHoaChiTiet(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            try
            {
                string sql = "select SoLuong, IdChiTietHangHoa from tbl_PhieuXuat_ChiTiet_HangHoa where IdChiTietPhieuXuat in " +
                            "(select IdChitiet from tbl_PhieuXuat_Chitiet where IdPhieuXuat = " + this.IdPhieuXuat + ")";
                sqlcmd.CommandText = sql;
                sqlcmd.CommandType = CommandType.Text;
                IDataReader reader = sqlcmd.ExecuteReader();
                List<string> lstSql = new List<string>();
                while (reader.Read())
                {
                    sql = "Update tbl_HangHoa_Chitiet Set SoLuong = SoLuong + " + reader.GetInt32(0);
                    sql += " Where IdChiTiet = " + reader.GetInt32(1);
                    lstSql.Add(sql);

                }
                reader.Close();

                foreach (string str in lstSql)
                {
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = str;
                    if (!DBTools.UpdateRecord(sqlcmd, sqlCon, sqlTran))
                        throw DBTools._LastError;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void PhieuXuat_AllDetails_DeleteCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllDetails";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
            //xoa chiet khau
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllDetails_CK";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }

        private void PhieuXuat_AllChungTu_HuyCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            try
            {
                //xoa chung tu voi phieu xuat goc
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuXuat_Huy_AllChungTu";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
                if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                    throw DBTools._LastError;


                //xoa chung tu cua cac phieu xuat gop
                string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                    "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    //thiet lap trang thai phieu xuat
                    string lstIdPX = dt.Rows[0]["listidphieuxuat"].ToString();
                    string[] arrId = lstIdPX.Split(",".ToCharArray());
                    foreach (string strId in arrId)
                    {
                        sqlcmd.CommandType = CommandType.Text;
                        sqlcmd.CommandText = "update tbl_PhieuXuat set NhapHoaDon = 0 where IdPhieuXuat = " + strId;
                        if (!DBTools.UpdateRecord(sqlcmd, sqlCon, sqlTran))
                            throw DBTools._LastError;
                    }
                    //xoa cac chung tu cua cac phieu

                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_PhieuXuat_Huy_AllChungTu_FromID";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int idChungTu = Common.IntValue(dt.Rows[i]["idchungtu"]);
                        sqlcmd.Parameters.Clear();
                        sqlcmd.Parameters.AddWithValue("@IdChungTu", idChungTu).Direction = ParameterDirection.Input;
                        if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                            throw DBTools._LastError;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void PhieuXuat_AllChungTu_DeleteCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllChungTu";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }


        private void PhieuXuat_AllThuChi_DeleteCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllThuChi";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            //xoa phieu thu cua cac phieu xuat gop
            string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
            DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dt != null && dt.Rows.Count > 0)
            {
                //thiet lap trang thai phieu xuat
                string lstIdPX = dt.Rows[0]["listidphieuxuat"].ToString();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = "Delete from tbl_ThuChi where ListIdPhieuXuat = N'" + lstIdPX + "'";
                if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                    throw DBTools._LastError;
            }
        }

        private int ChungTu_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, List<ChiTietPhieuXuat> hoadon, List<ChiTietPhieuXuat> hoadonCK, int loaiChungTu)
        {
            int idKhoDieuChuyen = -1;
            int orderType = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? Common.IntValue(this.cboOrderType.SelectedValue) : Common.IntValue(this.cboOrderTypeKM.SelectedValue);
            int idLoaiHD = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? 1 : 2;
            int quyenso = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? Common.IntValue(this.cboQuyen.SelectedValue) : Common.IntValue(this.cboQuyenKM.SelectedValue);
            string kyhieu = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? txtKyHieu.Text.Trim() : txtKyHieuKM.Text.Trim();
            string strSoSerie = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? SoSerie : txtSoSerieKM.Text.Trim();

            if (lstSoSeri.Contains(strSoSerie))
            {
                string str = "";
                foreach (string s in lstSoSeri)
                    str += s + ";";
                throw new ManagedException("Số hóa đơn " + strSoSerie + " bị trùng!\nDanh sách hóa đơn đã có: " + str + "\nXem lại hóa đơn xuất bán hoặc hóa đơn Khuyến mại");
            }
            else
                lstSoSeri.Add(strSoSerie);

            //Kiem tra trung so hoa don
            string sqlstr = String.Format("select * from tbl_ChungTu where SoSeri=N'{0}' and SoChungTu='{1}' and IdPhieuXuat!={2} and IdKho={3} and LoaiChungTu in ({4},{5})", strSoSerie, kyhieu, this.IdPhieuXuat, Common.IntValue(this.cboKhoXuat.SelectedValue), (int)TransactionType.XUAT_BAN, (int)TransactionType.XUAT_KHUYEN_MAI);
            //string sqlstr = "select * from tbl_ChungTu where SoSeri=N'" + strSoSerie + "' and SoChungTu=N'" + kyhieu + "' and IdPhieuXuat != " + this.IdPhieuXuat + " and IdKho = " + Common.IntValue(this.cboKhoXuat.SelectedValue) + " and LoaiChungTu in (= " + (int)TransactionType.XUAT_BAN;
            if (DBTools.ExistData(sqlstr))
            {
                throw new Exception("Số hóa đơn " + strSoSerie + " đã được sử dụng trong một phiếu xuất khác!\nXem lại hóa đơn xuất bán hoặc hóa đơn Khuyến mại");
            }

            string thanhtoan = ThanhToan[cboHinhThucTT.SelectedIndex];
            if (loaiChungTu != (int)TransactionType.XUAT_BAN || hoadon[0].TyLeVAT < 0)
                thanhtoan = "Hàng KM ko thu tiền";
            double tyLeVAT = hoadon.Count > 0 ? hoadon[0].TyLeVAT : hoadonCK[0].TyLeVAT;
            double tongTienHang = 0, tongTienCK = 0, tongTienSauCK = 0, tongTienVAT = 0, tongTienThanhToan = 0, tienThucTra = 0, tienNo = 0;
            foreach (ChiTietPhieuXuat px in hoadon)
            {
                tongTienHang += Common.Round(px.SoLuong * px.DonGia);
                tongTienCK += Common.Round(px.TienChietKhau);
                tongTienVAT += Common.Round(px.TienVAT);
            }
            foreach (ChiTietPhieuXuat px in hoadonCK)
            {
                tongTienHang += Common.Round(px.TienChietKhau);
                tongTienVAT += Common.Round(px.TienVAT);
            }
            tongTienSauCK = tongTienHang - tongTienCK;
            //tongTienVAT += Math.Round(tongTienSauCK * tyLeVAT, 0);
            tongTienThanhToan = tongTienSauCK + tongTienVAT;
            tienThucTra = tongTienThanhToan;

            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_Insert";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdChungTu", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@LoaiChungTu", loaiChungTu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@QuyenSo", quyenso).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSeri", strSoSerie).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoChungTu", kyhieu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayLap", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKhoDieuChuyen", idKhoDieuChuyen).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdNhanVien", this.cboNhanVien.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdDoiTuong", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GioiTinh", this.cboGioiTinh.SelectedIndex).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DoTuoi", Common.IntValue(this.txtTuoi.Text.Trim())).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DienThoai", this.txtDienThoai.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@MaSoThue", this.txtMaSoThue.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@OrderType", orderType).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@BillTo", Common.IntValue(this.cboBillTo.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ShipTo", Common.IntValue(this.cboShipTo.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienHang", tongTienHang).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienChietKhau", tongTienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienSauChietKhau", tongTienSauCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyleVAT", tyLeVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienVAT", tongTienVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTienThanhToan", tongTienThanhToan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdTienTe", Declare.IdTienTe).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyGia", 1).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienThanhToanThuc", tienThucTra).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienConNo", tienNo).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TongTien_Chu", Common.ReadNumner_(Common.Dbl2Str(tongTienThanhToan))).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", thanhtoan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucTra", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdBangKeThue", Common.IntValue(cboBangKeThue.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdLoaiHDBanHang", idLoaiHD).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdDuAn", Common.IntValue(cboMaDuAn.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoChungTuTraLai", "").Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            int IdChungTu = int.Parse(sqlcmd.Parameters["@IdChungTu"].Value.ToString());
            //luu lai Id chung tu
            HoaDon chungtu = new HoaDon(IdChungTu, quyenso, kyhieu, strSoSerie, this.mstNgayXuat.Value, "", "", "", "", this.cboNhanVien.SelectedText,
                                 this.txtHoTenKhachHang.Text, (int)this.cboGioiTinh.SelectedIndex, Common.IntValue(this.txtTuoi.Text.Trim()), this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text, orderType, Common.IntValue(this.cboBillTo.SelectedValue), Common.IntValue(this.cboShipTo.SelectedValue),
                                  tongTienHang, tongTienCK, tyLeVAT, tongTienVAT, tongTienThanhToan, Declare.KyHieuTienTe, ThanhToan[cboHinhThucTT.SelectedIndex], Common.IntValue(this.cboLoaiTra.SelectedValue), this.txtGhiChu.Text);
            listChungTu.Add(chungtu);
            return IdChungTu;
        }

        private void ChungTu_DeleteCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdChungTu)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_Delete";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }
        private int ChiTietCK_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdSP,
                                            int sLuong, double tienCK, double tyleVAT, double tienVAT, string ghiChu)
        {
            double thanhtien = Common.Round(tienCK + tienVAT);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChietKhau_PhieuXuat_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", this.IdPhieuXuat).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", tienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyleVAT", tyleVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienVAT", tienVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThanhTien", thanhtien).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", ghiChu).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());
        }
        private int ChiTietPX_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdSP, int IdSPBan,
                                            int sLuong, double dongia, double tyleCK, double tienCK, double tyleVAT, double tienVAT, double tyleThuong, double thuongNong, double giaBangGia)
        {
            double tiensauCK = Common.Round(sLuong * dongia - tienCK);
            double thanhtien = Common.Round(tiensauCK + tienVAT);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChiTiet_PhieuXuat_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", this.IdPhieuXuat).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPhamBan", IdSPBan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DonGia", dongia).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyLeChietKhau", tyleCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", tienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienSauChietKhau", tiensauCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyleVAT", tyleVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienVAT", tienVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThanhTien", thanhtien).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyleThuong", tyleThuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThuongNong", thuongNong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GiaTheoBangGia", giaBangGia).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());
        }

        private void ChiTietPX_UpdateCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int idChithiet, int IdSP, int IdSPBan,
                                            int sLuong, double dongia, double tyleCK, double tienCK, double tyleVAT, double tienVAT, double tyleThuong, double thuongNong, double giaBangGia)
        {
            double tiensauCK = Common.Round(sLuong * dongia - tienCK);
            double thanhtien = Common.Round(tiensauCK + tienVAT);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChiTiet_PhieuXuat_Update";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitiet", idChithiet).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", this.IdPhieuXuat).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPhamBan", IdSPBan).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DonGia", dongia).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyLeChietKhau", tyleCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", tienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienSauChietKhau", tiensauCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyleVAT", tyleVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienVAT", tienVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThanhTien", thanhtien).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyleThuong", tyleThuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThuongNong", thuongNong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GiaTheoBangGia", giaBangGia).Direction = ParameterDirection.Input;

            if (!DBTools.UpdateRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }

        private void ChiTietPX_DeleteCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdChitiet)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChiTiet_PhieuXuat_Delete";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdChitiet", IdChitiet).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

        }

        private int ChietKhau_ChungTu_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdChungTu, int IdSP,
                                            int sLuong, double tienCK, double tienvat, string ghiChu)
        {
            double thanhtien = Common.Round(tienCK + tienvat);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_ChietKhau_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", tienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThanhTien", thanhtien).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", ghiChu).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

        }
        private int ChiTiet_ChungTu_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdChungTu, int IdSP,
                                            int sLuong, double dongia, double tyleCK, double tienCK)
        {
            double thanhtien = Common.Round(sLuong * dongia - tienCK);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_ChiTiet_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DonGia", dongia).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TyLeChietKhau", tyleCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", tienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThanhTien", thanhtien).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

        }

        private void ChiTietPX_HangHoa_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdChitiet, int IdHanghoa, int Soluong, double TienCK, double TienVAT, double thuong, string ghichu)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChiTiet_Hanghoa_PhieuXuat_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitietPhieuXuat", IdChitiet).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdChitietHangHoa", IdHanghoa).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", Soluong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", TienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienVAT", TienVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThuongNong", thuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", ghichu).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;

        }

        private void ChiTiet_ChungTu_HangHoa_InsertCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int IdChitiet, int IdHanghoa, int Soluong, double TienCK)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_ChiTiet_Hanghoa_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitietChungTu", IdChitiet).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdChitietHangHoa", IdHanghoa).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", Soluong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", TienCK).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran))
                throw DBTools._LastError;
        }

        private GtidCommand PhieuXuat_Update_HoaDonCommand(int PhieuXuat, int IdHoaDonBan)
        {
            GtidCommand sql = new GtidCommand("sp_PhieuXuat_Update_HoaDonBan");
            sql.Parameters.AddWithValue("@IdPhieuXuat", PhieuXuat).Direction = ParameterDirection.Input;
            sql.Parameters.AddWithValue("@IdHoaDonBan", IdHoaDonBan).Direction = ParameterDirection.Input;
            sql.CommandType = CommandType.StoredProcedure;
            return sql;
        }


        private void LoadKhachHang()
        {
            try
            {
                string str = "Select IdDoiTuong, MaDoiTuong, TenDoiTuong, DiaChi, DienThoai, MaSoThue, IdOrderType " +
                      "from tbl_DM_DoiTuong " +
                      "where SuDung = 1 and Type <> 2 and (MaVung is null or MaVung like '%' + (Select MaVung From tbl_DM_Kho Where IdKho = " + Declare.IdKho + ") + '%')" +
                      "order by TenDoiTuong ASC";
                string[] fields = { "IdDoiTuong", "MaDoiTuong", "TenDoiTuong", "DiaChi", "DienThoai", "MaSoThue", "IdOrderType" };
                string[] types = { "System.Int32", "System.String", "System.String", "System.String", "System.String", "System.String", "System.Int32" };
                this.dtKhachHang = DBTools.LoadDanhMuc(str, "tbl_DM_DoiTuong", fields, types);

                //this.dtKhachHang = DBTools.getData("tbl_DM_DoiTuong", str).Tables["tbl_DM_DoiTuong"];
                if (this.dtKhachHang != null)
                {
                    //this.dtKhachHang.Constraints.Add("fg_KhachHang", dtKhachHang.Columns["IdKhachHang"], true);
                    this.cboKhachHang.DataSource = this.dtKhachHang;
                    this.cboKhachHang.DisplayMember = "TenDoiTuong";
                    this.cboKhachHang.ValueMember = "IdDoiTuong";
                    this.cboKhachHang.SelectedIndex = -1;
                    //this.cboKhachHang.SelectedValue = Declare.IdKHMacDinh;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtKhachHang.Rows.Count; i++)
                    {
                        data.Add(dtKhachHang.Rows[i]["TenDoiTuong"].ToString());
                        data1.Add(dtKhachHang.Rows[i]["MaDoiTuong"].ToString());
                    }

                    cboKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboKhachHang.AutoCompleteCustomSource = data;

                    txtMaKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtMaKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtMaKhachHang.AutoCompleteCustomSource = data1;

                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
 
        private void LoadQuyen()
        {
            try
            {
                string str = "Select distinct QuyenSo From tbl_SuDung_HoaDon Where IdNhanVien=" + Declare.IdNhanVien +
                      " and SoHienTai<=SoKetThuc ";
                string[] fields = { "QuyenSo" };
                string[] types = { "System.Int32" };
                DataTable dt = DBTools.LoadDanhMuc(str, "tbl_SuDung_HoaDon", fields, types);
                DataTable dt1 = dt.Copy();

                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                //DataTable dt1 = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    this.cboQuyen.DataSource = dt;
                    this.cboQuyen.DisplayMember = "QuyenSo";
                    this.cboQuyen.ValueMember = "QuyenSo";

                    this.cboQuyenKM.DataSource = dt1;
                    this.cboQuyenKM.DisplayMember = "QuyenSo";
                    this.cboQuyenKM.ValueMember = "QuyenSo";
                    //this.cboQuyen.SelectedIndex = 0;
                    LoadHoaDon(false);
                    // AutoCompleteStringCollection 
                    //AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //    data.Add(dt.Rows[i]["QuyenSo"].ToString());

                    //cboQuyen.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    //cboQuyen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //cboQuyen.AutoCompleteCustomSource = data;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }

        }
        private void LoadHoaDon(bool show)
        {
            string kyhieu="", serie="";
            try
            {
                int quyen = Common.IntValue(cboQuyen.SelectedValue);

                Common.LoadHoaDon(ref kyhieu, ref serie, quyen, show);
                txtKyHieu.Text = kyhieu;
                txtSoSerie.Text = serie;

                if (dgvHangKhuyenMai.RowCount > 0)
                {
                    cboQuyenKM.SelectedValue = quyen;
                    txtKyHieuKM.Text = kyhieu;
                    txtSoSerieKM.Text = Common.LoadNextHoaDon(serie);
                }
                else
                {
                    cboQuyenKM.SelectedValue = 0;
                    txtKyHieuKM.Text = "";
                    txtSoSerieKM.Text = "";

                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadHoaDonKM(bool show)
        {
            string kyhieu = "", serie = "";
            try
            {
                if (cboQuyenKM.SelectedIndex == cboQuyen.SelectedIndex)
                {
                    txtKyHieuKM.Text = txtKyHieu.Text;
                    txtSoSerieKM.Text = Common.LoadNextHoaDon(txtSoSerie.Text);
                }
                else
                {
                    int quyen = Common.IntValue(cboQuyenKM.SelectedValue);
                    Common.LoadHoaDon(ref kyhieu, ref serie, quyen, show);
                    txtKyHieuKM.Text = kyhieu;
                    txtSoSerieKM.Text = serie;
                }

            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void LoadLoaiThuChi()
        {
            try
            {
                string str = "Select IdThuChi, KyHieu + ' - ' + Ten ThuChi From tbl_DM_LoaiThuChi " +
                      " Where SuDung=1 and Type=0 ";
                string[] fields = { "IdThuChi", "ThuChi" };
                string[] types = { "System.Int32", "System.String" };
                DataTable dt = DBTools.LoadDanhMuc(str, "tbl_DM_LoaiThuChi", fields, types);

                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    this.cboLoaiTra.DataSource = dt;
                    this.cboLoaiTra.DisplayMember = "ThuChi";
                    this.cboLoaiTra.ValueMember = "IdThuChi";
                    //this.cboLoaiTra.SelectedIndex = 0;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        data.Add(dt.Rows[i]["ThuChi"].ToString());

                    cboLoaiTra.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboLoaiTra.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboLoaiTra.AutoCompleteCustomSource = data;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void LoadOrderType()
        {
            try
            {
                //string str = "Select IdOrderType, Code, Name From tbl_DM_OrderType " +
                //      " Where SuDung=1 and (Code like '%.1.1.%.%.%.%" + Declare.MAVUNG + "' or Code like '%.1.1.%.%.%.%" + Declare.MAVUNG + ".')";//xuat.hang hoa
                //string str = "Select IdOrderType, Code, Name From tbl_DM_OrderType " +
                //      " Where SuDung=1 and (Code like '%.1.1.%.%.%.%" + Declare.MAVUNG + "' or Code like '%.1.1.%.%.%.%" + Declare.MAVUNG + ".' " + //xuat.hang hoa
                //        " or Code like '%.1.99.%.%.%.%" + Declare.MAVUNG + "' or Code like '%.1.99.%.%.%.%" + Declare.MAVUNG + ".')";//xuat.hang hoa
                string str = "Select * From tbl_DM_OrderType Where (Code not like '%KM.%' and Code not like '%.TL.%')";//xuat.hang hoa

                string[] fields = { "IdOrderType", "Code", "Name" };
                string[] types = { "System.Int32", "System.String", "System.String" };
                this.dtOrderType = DBTools.LoadDanhMuc(str, "tbl_DM_OrderType", fields, types);

                //this.dtOrderType = DBTools.getData("tmp", str).Tables["tmp"];
                if (this.dtOrderType != null)
                {
                    this.cboOrderType.DataSource = this.dtOrderType;
                    this.cboOrderType.DisplayMember = "Name";
                    this.cboOrderType.ValueMember = "IdOrderType";
                    this.cboOrderType.SelectedIndex = -1;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                    for (int i = 0; i < this.dtOrderType.Rows.Count; i++)
                    {
                        data.Add(this.dtOrderType.Rows[i]["Name"].ToString());
                        data1.Add(this.dtOrderType.Rows[i]["Code"].ToString());
                    }

                    cboOrderType.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboOrderType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboOrderType.AutoCompleteCustomSource = data;

                    txtOrderType.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtOrderType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtOrderType.AutoCompleteCustomSource = data1;
                }

                //str = "Select IdOrderType, Code, Name From tbl_DM_OrderType " +
                //      " Where SuDung=1 and (Code like '%.1.99.%.%.%.%" + Declare.MAVUNG + "' or Code like '%.1.99.%.%.%.%" + Declare.MAVUNG + ".')";//xuat.hang hoa
                str = "Select * From tbl_DM_OrderType Where Code like '%KM.%'";//xuat.hang hoa
                this.dtOrderTypeKM = DBTools.LoadDanhMuc(str, "tbl_DM_OrderType", fields, types);

                //this.dtOrderTypeKM = DBTools.getData("tmp", str).Tables["tmp"];
                if (this.dtOrderTypeKM != null)
                {
                    this.cboOrderTypeKM.DataSource = this.dtOrderTypeKM;
                    this.cboOrderTypeKM.DisplayMember = "Name";
                    this.cboOrderTypeKM.ValueMember = "IdOrderType";
                    this.cboOrderTypeKM.SelectedIndex = -1;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                    for (int i = 0; i < this.dtOrderTypeKM.Rows.Count; i++)
                    {
                        data.Add(this.dtOrderTypeKM.Rows[i]["Name"].ToString());
                        data1.Add(this.dtOrderTypeKM.Rows[i]["Code"].ToString());
                    }

                    cboOrderTypeKM.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboOrderTypeKM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboOrderTypeKM.AutoCompleteCustomSource = data;

                    txtOrderTypeKM.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtOrderTypeKM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtOrderTypeKM.AutoCompleteCustomSource = data1;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void LoadMaVach()
        {
            try
            {
                string str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
                            " Where hh.IdKho = " + Declare.IdKho + " and hh.SoLuong > 0 order by hh.MaVach ASC";
                //string str1 = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh ";
                DataTable dtMaVach = DBTools.getData("tbl_HangHoa_Chitiet", str).Tables["tbl_HangHoa_Chitiet"];
                if (dtMaVach != null)
                {
                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtMaVach.Rows.Count; i++)
                        data.Add(dtMaVach.Rows[i]["MaVach"].ToString());

                    txtMaVach.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtMaVach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtMaVach.AutoCompleteCustomSource = data;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void LoadKhoXuat()
        {
            try
            {
                //string str = "Select DISTINCT kh.IdKho, kh.MaKho, kh.TenKho From tbl_DM_Kho kh " +
                //      " Inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                //      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv.IdNhanVien " +
                //      " Where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + " order by kh.TenKho ASC";
                string str = "Select DISTINCT kh.IdKho, kh.MaKho, kh.TenKho From tbl_DM_Kho kh " +
                      " Where kh.SuDung =1 and kh.IdKho = " + Declare.IdKho + " order by kh.TenKho ASC";

                DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
                if (dtKho != null)
                {
                    //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                    this.cboKhoXuat.DataSource = dtKho;
                    this.cboKhoXuat.DisplayMember = "TenKho";
                    this.cboKhoXuat.ValueMember = "IdKho";
                    this.cboKhoXuat.SelectedValue = Declare.IdKho;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadNhanVien()
        {
            try
            {
                //string str = "Select DISTINCT nv.IdNhanVien, nv.MaNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                //      " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien " +
                //      " Where knv.IdKho in ( Select knv1.idKho From tbl_Kho_NhanVien knv1 " +
                //      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv1.IdNhanVien " +
                //      " Where nd.IdNguoiDung = " + Declare.UserId + ") and (nv.SuDung = 1)  order by nv.HoTen ASC";
                string str = "Select DISTINCT nv.IdNhanVien, nv.MaNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                      " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien and knv.IdKho = " + Declare.IdKho + " and nv.SuDung = 1  order by nv.HoTen ASC";
                string[] fields = { "IdNhanVien", "MaNhanVien", "HoTen" };
                string[] types = { "System.Int32", "System.String", "System.String" };
                this.dtNhanVien = DBTools.LoadDanhMuc(str, "tbl_DM_NhanVien", fields, types);
                //this.dtNhanVien = DBTools.getData("tbl_DM_NhanVien", str).Tables["tbl_DM_NhanVien"];
                

                if (this.dtNhanVien != null)
                {
                    //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                    this.cboNhanVien.DataSource = this.dtNhanVien;
                    this.cboNhanVien.DisplayMember = "HoTen";
                    this.cboNhanVien.ValueMember = "IdNhanVien";
                    this.cboNhanVien.SelectedIndex = -1;
                    //this.cboNhanVien.SelectedValue = Declare.IdNhanVien;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                    {
                        data.Add(dtNhanVien.Rows[i]["HoTen"].ToString());
                        data1.Add(dtNhanVien.Rows[i]["MaNhanVien"].ToString());
                    }

                    cboNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboNhanVien.AutoCompleteCustomSource = data;

                    txtMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtMaNhanVien.AutoCompleteCustomSource = data1;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadDiaChiKH()
        {
            try
            {
                string str = "Select IdDiaChi, SiteNumber, DiaChi From tbl_DM_DoiTuong_DiaChi " +
                 " Where IdDoiTuong = " + cboKhachHang.SelectedValue + " and (MaVung is null or MaVung = (Select MaVung From tbl_DM_Kho Where IdKho = " + Declare.IdKho + "))";
                string[] fields = { "IdDiaChi", "SiteNumber", "DiaChi" };
                string[] types = { "System.Int32", "System.String", "System.String" };
                this.dtDiaChi = DBTools.LoadDanhMuc(str, "tbl_DM_DoiTuong_DiaChi", fields, types);
                //this.dtDiaChi = DBTools.getData("tmp", str).Tables["tmp"];                
                if (this.dtDiaChi != null)
                {
                    this.cboBillTo.DataSource = this.dtDiaChi;
                    this.cboBillTo.DisplayMember = "DiaChi";
                    this.cboBillTo.ValueMember = "IdDiaChi";
                    //this.cboBillTo.SelectedIndex = -1;

                    this.cboShipTo.DataSource = this.dtDiaChi;
                    this.cboShipTo.DisplayMember = "DiaChi";
                    this.cboShipTo.ValueMember = "IdDiaChi";
                    //this.cboShipTo.SelectedIndex = -1;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtDiaChi.Rows.Count; i++)
                    {
                        data.Add(dtDiaChi.Rows[i]["DiaChi"].ToString());
                        data1.Add(dtDiaChi.Rows[i]["SiteNumber"].ToString());
                    }

                    cboBillTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboBillTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboBillTo.AutoCompleteCustomSource = data;

                    cboShipTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboShipTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboShipTo.AutoCompleteCustomSource = data;

                    txtBillTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtBillTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtBillTo.AutoCompleteCustomSource = data1;

                    txtShipTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtShipTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtShipTo.AutoCompleteCustomSource = data1;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadBangKeThue()
        {
            try
            {
                string str = "Select Id, KyHieu + ' - ' + Ten BangKe From tbl_DM_BangKeThue Where SuDung=1 ";
                string[] fields = { "Id", "BangKe" };
                string[] types = { "System.Int32", "System.String" };
                DataTable dt = DBTools.LoadDanhMuc(str, "tbl_DM_BangKeThue", fields, types);
                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    //DataRow r = dt.NewRow();
                    //r[0] = 0;
                    //r[1] = "";
                    //dt.Rows.InsertAt(r, 0);
                    this.cboBangKeThue.DataSource = dt;
                    this.cboBangKeThue.DisplayMember = "BangKe";
                    this.cboBangKeThue.ValueMember = "Id";
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadLoaiHoaDon()
        {
            try
            {
                string str = "Select Id, KyHieu + ' - ' + Ten HoaDon From tbl_DM_LoaiHD_BanHang Where SuDung=1 ";
                string[] fields = { "Id", "HoaDon" };
                string[] types = { "System.Int32", "System.String" };
                DataTable dt = DBTools.LoadDanhMuc(str, "tbl_DM_LoaiHD_BanHang", fields, types);

                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    //DataRow r = dt.NewRow();
                    //r[0] = 0;
                    //r[1] = "";
                    //dt.Rows.InsertAt(r, 0);
                    this.cboLoaiHoaDon.DataSource = dt;
                    this.cboLoaiHoaDon.DisplayMember = "HoaDon";
                    this.cboLoaiHoaDon.ValueMember = "Id";
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadMaDuAn()
        {
            try
            {
                string str = "Select IdDuAn, MaDuAn || ' - ' || TenDuAn DuAn From tbl_DM_DuAn Where SuDung=1 ";
                string[] fields = { "IdDuAn", "MaDuAn" };
                string[] types = { "System.Int32", "System.String" };
                DataTable dt = DBTools.LoadDanhMuc(str, "tbl_DM_DuAn", fields, types);

                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    DataRow r = dt.NewRow();
                    r[0] = 0;
                    r[1] = "";
                    dt.Rows.InsertAt(r, 0);
                    this.cboMaDuAn.DataSource = dt;
                    this.cboMaDuAn.DisplayMember = "DuAn";
                    this.cboMaDuAn.ValueMember = "IdDuAn";
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        //private void LoadTienTe()
        //{
        //    string str = "Select DISTINCT tt.IdTienTe, tt.KyHieu, tt.TenTienTe, tt.TyGia From dbo.tbl_DM_TienTe tt " +
        //         " Where tt.SuDung=1  Order by tt.TenTienTe ASC";

        //    DataTable dtTienTe = DBTools.getData("dbo.tbl_DM_TienTe", str).Tables["dbo.tbl_DM_TienTe"];
        //    if (dtTienTe != null)
        //    {
        //        this.cboLoaiTien.DataSource = dtTienTe;
        //        this.cboLoaiTien.DisplayMember = "KyHieu";
        //        this.cboLoaiTien.ValueMember = "IdTienTe";
        //        str = "Select DISTINCT TienTeMacDinh From tbl_ThamSo_Chung";
        //        try
        //        {
        //            Declare.IdTienTe = Common.IntValue(DBTools.getValue(str));
        //            this.cboLoaiTien.SelectedValue = Declare.IdTienTe;
        //        }
        //        catch (Exception ex) { }
        //    }
        //}
        private void LoadComboBoxData()
        {

            LoadKhoXuat();
            LoadNhanVien();
            LoadOrderType();
            LoadKhachHang();
            //LoadTienTe();
            //LoadMaVach();
            LoadQuyen();
            LoadLoaiThuChi();
            //LoadDiaChiKH();
            LoadBangKeThue();
            LoadLoaiHoaDon();
            LoadMaDuAn();
            LoadHinhThucTT();
        }
        private void LoadHinhThucTT()
        {
            try
            {
                string str = "Select HinhThucThanhToan From tbl_DM_HinhThucThanhToan";
                string[] fields = { "HinhThucThanhToan" };
                string[] types = { "System.String" };
                DataTable dt = DBTools.LoadDanhMuc(str, "tbl_DM_HinhThucThanhToan", fields, types);

                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ThanhToan = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ThanhToan[i] = dt.Rows[i]["HinhThucThanhToan"].ToString();
                    }
                }
            }
            catch { }


            cboHinhThucTT.Items.Clear();
            for (int i = 0; i < ThanhToan.Length; i++)
                cboHinhThucTT.Items.Add(ThanhToan[i]);
            cboHinhThucTT.SelectedIndex = 0;
        }
        private void PhieuXuat_HienThi(DataRow row)
        {
            if (row["SoSerie"] != DBNull.Value && row["SoSerie"].ToString().Length>0)
                NewHoaDon = false;
            else
                NewHoaDon = true;
            this.txtSoPhieu.Text = row["SoPhieuXuat"].ToString();
            this.mstNgayXuat.Value = (DateTime)row["NgayXuat"];
            this.cboQuyen.SelectedValue = Common.IntValue(row["QuyenSo"].ToString());
            this.txtKyHieu.Text = row["KyHieu"].ToString();
            this.txtSoSerie.Text = row["SoSerie"].ToString();
            this.cboQuyenKM.SelectedValue = Common.IntValue(row["QuyenKM"].ToString());
            this.txtKyHieuKM.Text = row["KyHieuKM"].ToString();
            this.txtSoSerieKM.Text = row["SoSerieKM"].ToString();

            this.cboKhoXuat.SelectedValue = Common.IntValue(row["IdKho"].ToString());
            if (row["IdNhanVien"] != DBNull.Value)
                this.cboNhanVien.SelectedValue = Common.IntValue(row["IdNhanVien"].ToString());
            else
                this.cboNhanVien.SelectedIndex = -1;
            if (row["IdKhachHang"] != DBNull.Value)
                this.cboKhachHang.SelectedValue = Common.IntValue(row["IdKhachHang"].ToString());
            else
                this.cboKhachHang.SelectedIndex = -1;
            if (row["OrderType"] != DBNull.Value)
                this.cboOrderType.SelectedValue = Common.IntValue(row["OrderType"].ToString());
            else
                this.cboOrderType.SelectedIndex = -1;
            if (row["OrderTypeKM"] != DBNull.Value)
                this.cboOrderTypeKM.SelectedValue = Common.IntValue(row["OrderTypeKM"].ToString());
            else
                this.cboOrderTypeKM.SelectedIndex = -1;
            if (row["BillTo"] != DBNull.Value)
                this.cboBillTo.SelectedValue = Common.IntValue(row["BillTo"].ToString());
            else
            {
                this.cboBillTo.SelectedIndex = -1;
                txtBillTo.Text = "";
                this.cboBillTo.Text = "";
            }
            if (row["ShipTo"] != DBNull.Value)
                this.cboShipTo.SelectedValue = Common.IntValue(row["ShipTo"].ToString());
            else
            {
                this.cboShipTo.SelectedIndex = -1;
                txtShipTo.Text = "";
                this.cboShipTo.Text = "";
            }
                
            this.txtHoTenKhachHang.Text = row["HoTen"].ToString();
            this.cboGioiTinh.SelectedIndex = Common.IntValue(row["GioiTinh"].ToString());
            this.txtTuoi.Text = row["DoTuoi"].ToString();
            this.txtDiaChi.Text = row["DiaChi"].ToString();
            this.txtDienThoai.Text = row["DienThoai"].ToString();
            this.txtMaSoThue.Text = row["MaSoThue"].ToString();
            this.SoTaiKhoan = row["SoTaiKhoan"].ToString();
            this.NganHang = row["NganHang"].ToString();
            //if (row["IdKhachHang"] != DBNull.Value)
            //this.cboLoaiTien.SelectedValue = Common.IntValue(row["IdTienTe"].ToString());
            //this.txtTyGia.Text = row["TyGia"].ToString();
            this.txtTongTienHang.Text = Common.Double2Str((double)row["TongTienHang"]);
            this.txtTongTienCK.Text = Common.Double2Str((double)row["TongTienChietKhau"]);
            this.txtTongTienSauCK.Text = Common.Double2Str((double)row["TongTienSauChietKhau"]);
            this.txtTongTienVAT.Text = Common.Double2Str((double)row["TongTienVAT"]);
            this.txtTongTienThanhToan.Text = Common.Double2Str((double)row["TongTienThanhToan"]);
            this.txtTienThucTra.Text = Common.Double2Str((double)row["TienThanhToanThuc"]);
            this.txtTienConNo.Text = Common.Double2Str((double)row["TienConNo"]);
            this.cboHinhThucTT.SelectedIndex = 0;
            for (int i=0; i< ThanhToan.Length; i++)
                if (row["HinhThucThanhToan"].ToString().Equals(ThanhToan[i]))
                {
                    this.cboHinhThucTT.SelectedIndex = i;
                    break;
                }
            this.cboLoaiTra.SelectedValue = Common.IntValue(row["HinhThucTra"].ToString());
            //this.cboThu.SelectedValue = Common.IntValue(row["LoaiThu"].ToString()); 
            this.cboBangKeThue.SelectedValue = Common.IntValue(row["IdBangKeThue"].ToString());
            this.cboLoaiHoaDon.SelectedValue = Common.IntValue(row["IdLoaiHDBanHang"].ToString());
            this.cboMaDuAn.SelectedValue = Common.IntValue(row["IdDuAn"].ToString());
            this.txtGhiChu.Text = row["GhiChu"].ToString();
            this.txtSoOrderKH.Text = row["SoOrderKH"].ToString();
            DaLapHoaDon = row["NhapHoaDon"] == DBNull.Value ? false : (bool)row["NhapHoaDon"];
        }

        private void LoadAllPhieuXuat()
        {
            string str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.QuyenSo,px.KyHieu,px.SoSerie,px.IdKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi,";
            str += " px.DienThoai,px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT,";
            str += " px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.SoOrderKH,px.NhapHoaDon,px.QuyenKM,px.KyHieuKM,px.SoSerieKM ";
            str += " from tbl_PhieuXuat px ";
            //str += string.Format(" where px.NgayXuat >= convert(datetime,'{0}',121) and px.NgayXuat >=  convert(datetime,'{1}',121)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2LongString(Declare.NgayLamViec));
            str += string.Format(" where (px.ThoigianSua >=  convert(datetime,'{0}',103) or px.NhapHoaDon is null or px.NhapHoaDon=0) ", Common.Date2String(System.DateTime.Now.AddDays(-1)));
            //str += string.Format(" where px.ThoigianSua > convert(datetime,'{0}',121) and px.ThoigianSua >=  convert(datetime,'{1}',103)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2String(Declare.NgayLamViec));
            str += " and px.LoaiXuatNhap = " + (int)TransactionType.XUAT_BAN;
            str += " and px.IdKho = " + Declare.IdKho;
            //str += " and px.NguoiSua = '" + Declare.UserName + "'";
            str += " order by px.NhapHoaDon, px.ThoigianSua desc ";
            dtPhieuXuat = DBTools.getData("Tmp", str).Tables["Tmp"];           
        }

        private void LoadPhieuXuat(int IdPX)
        {
            string str;
            DataTable dt;

            str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.QuyenSo,px.KyHieu,px.SoSerie,px.IdKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi," +
                         "px.DienThoai, px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                         "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.SoOrderKH,px.NhapHoaDon,px.QuyenKM,px.KyHieuKM,px.SoSerieKM " +
                  "from tbl_PhieuXuat px " +
                  "where IdPhieuXuat=" + IdPX + "";
            dt = DBTools.getData("Tmp", str).Tables["Tmp"];
            dgvSanPhamBan.Rows.Clear();
            dgvHangKhuyenMai.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                this.PhieuXuat_HienThi(dt.Rows[0]);

                str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + IdPX + " and IdSanPhamBan is null " +
                      "Union all " +
                      "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                      "FROM vChietKhauPhieuXuat " +
                      "WHERE IdPhieuXuat=" + IdPX;
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                this.dgvSanPhamBan.Rows.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    double tienSauCK = Common.IntValue(dt.Rows[i]["SoLuong"].ToString()) * Common.DoubleValue(dt.Rows[i]["DonGia"].ToString())
                                        - Common.DoubleValue(dt.Rows[i]["TienChietKhau"].ToString());
                    object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["DonGia"])),
                            Common.Double2Str((double)dt.Rows[i]["TyLeChietKhau"] * TyLe),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"])),
                            Common.Double2Str(tienSauCK),                      
                            Common.Double2Str((double)dt.Rows[i]["TyLeVAT"]<0?(double)dt.Rows[i]["TyLeVAT"]:(double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            //Common.Double2Str((double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienVAT"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"])),
                            dt.Rows[i]["GhiChu"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"])),
                            Common.Double2Str(tienSauCK),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienVAT"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"])),
                            dt.Rows[i]["TyLeThuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThuongNong"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["GiaTheoBangGia"]))
                        };
                    this.dgvSanPhamBan.Rows.Add(arr);
                    DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                    //newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + idSPBan));
                    newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");// &Updating;//sửa giá bán
                    newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                }

                str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "IdSanPhamBan,MaSanPhamBan,TenSanPhamBan,SoLuong,ThanhTien " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + this.IdPhieuXuat + " and IdSanPhamBan is not null ";
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                this.dgvHangKhuyenMai.Rows.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["IdSanPhamBan"],
                            dt.Rows[i]["TenSanPhamBan"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"]))};
                    this.dgvHangKhuyenMai.Rows.Add(arr);
                }
            }
            ChuaDayOracle = Common.IsEnableCommandPX(IdPX);
        }

        #endregion

        #region "Các sự kiên"
        private void dgvChiTietPhieuXuat_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                    e.Handled = true;

            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void dgvChiTietPhieuXuat_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void dgvChiTietPhieuXuat_Resize_1(object sender, EventArgs e)
        {
            try
            {
                //this.ResizeLuoiHienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showInfors()
        {
            this.Text = "Cập nhật phiếu xuất kho.";
            if (dtPhieuXuat != null)
            {
                this.Text += " - Tổng số phiếu [" + dtPhieuXuat.Rows.Count + "]";
                if (dtPhieuXuat.Rows.Count > 0)
                {
                    if (Updating)
                        this.Text += " - Đang sửa phiếu số [" + (this.IndexPX + 1) + "] ...";
                    else
                        this.Text += " - Phiếu số [" + (this.IndexPX + 1) + "]";
                    if (!DaLapHoaDon & !NewHoaDon)
                        this.Text += " - Phiếu này đã bị hủy hóa đơn!!!";
                    else if (!DaLapHoaDon)
                        this.Text += " - Phiếu này chưa xuất hóa đơn!!!";
                }
            }
        }
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                txtSoPhieu.ReadOnly=!Common.IsEnableCommand("12");//sửa giá bán
                //Neu la sua tu danh sach tim kiem
                if (this.IndexPXSearch >= 0)
                {
                    this.LoadPhieuXuat(this.IdPhieuXuat);
                    return;
                }
                LoadAllPhieuXuat();
               
                if (this.IdPhieuXuat == 0)
                {
                    if (dtPhieuXuat != null && dtPhieuXuat.Rows.Count > 0)
                    {
                        this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdPhieuXuat"].ToString());
                    }
                }
                if (this.IdPhieuXuat > 0)
                {
                    this.LoadPhieuXuat(this.IdPhieuXuat);
                }
                else
                {
                    this.PhieuXuat_ThemMoi();
                    //this.cboKhachHang.SelectedValue = 0;
                    //this.cboBillTo.SelectedValue = 0;
                    //this.cboShipTo.SelectedValue = 0;
                    //this.txtMaKhachHang.Text = "";
                    //this.txtBillTo.Text = "";
                    //this.txtShipTo.Text = "";
                }
                //Thiet lap trang thai item
                setEDItems(false);
                setEDFunctions();
                setEDUpdate();
                showInfors();
                timer1.Start();
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            } 
            txtMaVach.Focus();
            
        }

        private void frmPhieuXuat_Dispose(object sender, EventArgs e)
        {
            frmTimPhieuXuat.SQLSearch = "";
            //try
            //{
            //    Declare.HienThiPhieuXuat = chkDefault.Checked;
            //    Common.SetValue("HIENTHI_PHIEUXUAT", (chkDefault.Checked ? "1" : "0"));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private List<ChiTietPhieuXuat> GetChiTietPhieuXuat(GtidCommand sqlcmd, GtidConnection sqlCon, ref List<ChiTietPhieuXuat> lstChietKhau)
        {
            DataGridView data = dgvSanPhamBan;// new DataGridView();
            //foreach (DataGridViewRow row in dgvSanPhamBan.Rows)
            //    data.Rows.Add(row);
            data.Sort(data.Columns["IdSanPham"], ListSortDirection.Ascending);
            int IdSanPham = 0;
            double GiaBan = 0.0;
            List<ChiTietPhieuXuat> listPX = new List<ChiTietPhieuXuat>();
            ChiTietPhieuXuat detailPX = null;

            foreach (DataGridViewRow dgr in data.Rows)
            {
                //chiet khau
                if (Common.IntValue(dgr.Cells["GiaTheoBangGia"].Value) == -1)
                {
                    ChiTietPhieuXuat chietkhau = new ChiTietPhieuXuat();
                    chietkhau.IdSanPham = Common.IntValue(dgr.Cells["IdSanPham"].Value);
                    chietkhau.SoLuong = -1;
                    chietkhau.TienChietKhau = Common.DoubleValueInt(dgr.Cells["TienSauChietKhau"].Value);
                    chietkhau.TyLeVAT = Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) < 0 ? Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) : Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) / TyLe;
                    chietkhau.TienVAT = Common.DoubleValueInt(dgr.Cells["TienVAT"].Value);
                    chietkhau.GhiChu = dgr.Cells["GhiChu"].Value == null ? "" : dgr.Cells["GhiChu"].Value.ToString();

                    lstChietKhau.Add(chietkhau);
                    continue;
                }
                if (dgr.Cells["MaVach"].Value == null || dgr.Cells["MaVach"].Value.ToString().Equals("")) continue;
                int idSP = Common.IntValue(dgr.Cells["IdSanPham"].Value);
                double gia = Common.DoubleValueInt(dgr.Cells["DonGia"].Value);
                if (idSP == IdSanPham && GiaBan == gia)
                {
                    int sl = Common.IntValue(dgr.Cells["SoLuong"].Value);
                    double ck = Common.DoubleValueInt(dgr.Cells["TienChietKhau"].Value);
                    double vat = Common.DoubleValueInt(dgr.Cells["TienVAT"].Value);
                    double thuong = Common.DoubleValueInt(dgr.Cells["ThuongNong"].Value);
                    string ghichu = dgr.Cells["GhiChu"].Value == null ? "" : dgr.Cells["GhiChu"].Value.ToString();
                    detailPX.SoLuong += sl;
                    detailPX.TienChietKhau += ck;
                    detailPX.TienVAT += vat;
                    detailPX.ThuongNong += thuong;
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVach"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlCon));
                    ChiTietHangHoa hanghoa = new ChiTietHangHoa(IdHangHoa, sl, ck, vat, thuong, ghichu);
                    detailPX.DsHangHoa.Add(hanghoa);
                }
                else
                {
                    if (detailPX != null)
                        listPX.Add(detailPX);
                    IdSanPham = idSP;
                    GiaBan = gia;
                    detailPX = new ChiTietPhieuXuat();
                    detailPX.IdSanPham = idSP;
                    detailPX.IdSanPhamBan = -1;
                    detailPX.SoLuong = Common.IntValue(dgr.Cells["SoLuong"].Value);
                    detailPX.DonGia = GiaBan;// Common.DoubleValue(dgr.Cells["DonGia"].Value.ToString());
                    detailPX.TyLeChietKhau = Common.DoubleValue(dgr.Cells["TyLeChietKhau"].Value) / TyLe;
                    detailPX.TienChietKhau = Common.DoubleValueInt(dgr.Cells["TienChietKhau"].Value);
                    //detailPX.TyLeVAT = Common.DoubleValue(dgr.Cells["TyLeVAT"].Value.ToString()) / TyLe;
                    detailPX.TyLeVAT = Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) < 0 ? Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) : Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) / TyLe;
                    detailPX.TienVAT = Common.DoubleValueInt(dgr.Cells["TienVAT"].Value);
                    detailPX.TyLeThuong = Common.DoubleValue(dgr.Cells["TyLeThuong"].Value);
                    detailPX.ThuongNong = Common.DoubleValueInt(dgr.Cells["ThuongNong"].Value);
                    detailPX.GiaTheoBangGia = Common.DoubleValueInt(dgr.Cells["GiaTheoBangGia"].Value);
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVach"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlCon));
                    string ghichu = dgr.Cells["GhiChu"].Value == null ? "" : dgr.Cells["GhiChu"].Value.ToString();
                    ChiTietHangHoa hanghoa = new ChiTietHangHoa(IdHangHoa, detailPX.SoLuong, detailPX.TienChietKhau, detailPX.TienVAT, detailPX.ThuongNong, ghichu);
                    detailPX.DsHangHoa.Add(hanghoa);
                }
            }
            if (detailPX != null)
                listPX.Add(detailPX);

            return listPX;

        }

        private List<ChiTietPhieuXuat> GetChiTietKhuyenMai(GtidCommand sqlcmd, GtidConnection sqlCon)
        {
            DataGridView data = dgvHangKhuyenMai;// new DataGridView();
            //foreach (DataGridViewRow row in dgvHangKhuyenMai.Rows)
            //    data.Rows.Add(row);
            data.Sort(data.Columns["IdSanPhamKM"], ListSortDirection.Ascending);
            int IdSanPham = 0;
            int idSPBan = 0;
            List<ChiTietPhieuXuat> listPX = new List<ChiTietPhieuXuat>();
            ChiTietPhieuXuat detailPX = null;
            foreach (DataGridViewRow dgr in data.Rows)
            {
                if (dgr.Cells["MaVachKM"].Value == null || dgr.Cells["MaVachKM"].Value.ToString().Equals("")) continue;
                int idSP = Common.IntValue(dgr.Cells["IdSanPhamKM"].Value);
                int idban = Common.IntValue(dgr.Cells["IdSanPhamBan"].Value);
                if (idSP == IdSanPham && idSPBan == idban)
                {
                    int sl = Common.IntValue(dgr.Cells["SoLuongKM"].Value);
                    double ck = 0;// -Common.DoubleValue(dgr.Cells["SoTienKM"].Value.ToString());
                    double vat = 0;
                    detailPX.SoLuong += sl;
                    detailPX.TienChietKhau += ck;
                    detailPX.TienVAT += vat;
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVachKM"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlCon));
                    ChiTietHangHoa hanghoa = new ChiTietHangHoa(IdHangHoa, sl, ck, vat, 0, "");
                    detailPX.DsHangHoa.Add(hanghoa);
                }
                else
                {
                    if (detailPX != null)
                        listPX.Add(detailPX);
                    IdSanPham = idSP;
                    idSPBan = idban;
                    detailPX = new ChiTietPhieuXuat();
                    detailPX.IdSanPham = idSP;
                    detailPX.IdSanPhamBan = idSPBan;// Common.IntValue(dgr.Cells["IdSanPhamBan"].Value.ToString());
                    detailPX.SoLuong = Common.IntValue(dgr.Cells["SoLuongKM"].Value);
                    detailPX.DonGia = 0;
                    detailPX.TyLeChietKhau = 0;
                    detailPX.TienChietKhau = 0;// -Common.DoubleValue(dgr.Cells["SoTienKM"].Value.ToString());
                    detailPX.TyLeVAT = -1;
                    detailPX.TienVAT = 0;
                    detailPX.TyLeThuong = 0;
                    detailPX.ThuongNong = 0;
                    detailPX.GiaTheoBangGia = 0;
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVachKM"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlCon));
                    ChiTietHangHoa hanghoa = new ChiTietHangHoa(IdHangHoa, detailPX.SoLuong, detailPX.TienChietKhau, detailPX.TienVAT, 0, "");
                    detailPX.DsHangHoa.Add(hanghoa);
                }

            }
            if (detailPX != null)
                listPX.Add(detailPX);

            return listPX;

        }

        private void btnXoaDongPhieu_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.dtChiTietPX.Rows.Count == 1)
            //    {
            //        MessageBox.Show("Không có dòng phiếu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (this.dgvSanPhamBan.CurrentRow.Index == this.dgvSanPhamBan.Rows.Count - 1)
            //    {
            //        MessageBox.Show("Hãy chọn một dòng phiếu để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (MessageBox.Show(Declare.msgRemoveData, Declare.titleNotice, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {

            //        int IndexRow;
            //        IndexRow = this.dgvSanPhamBan.CurrentRow.Index;
            //        this.dtChiTietPX.Rows.RemoveAt(IndexRow);
            //        if (this.dtChiTietPX.Rows.Count == 1)
            //            return;
            //        else
            //        {
            //            if (IndexRow < this.dtChiTietPX.Rows.Count)
            //                this.ChiTietPX_CapNhatSoTT(this.dtChiTietPX, IndexRow);
            //            if (IndexRow == this.dtChiTietPX.Rows.Count - 1)
            //                this.dgvSanPhamBan.CurrentCell = this.dgvSanPhamBan.Rows[IndexRow - 1].Cells["SoTT"];

            //            this.dgvSanPhamBan.CurrentRow.Selected = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dtChiTietPhieuXuat_Rowchanged(object sender, DataRowChangeEventArgs e)
        {
            //Double TongTien = 0;
            //if (this.dtChiTietPX.Rows.Count > 0)
            //{

            //    for (int i = 0; i <= this.dtChiTietPX.Rows.Count - 2; i++)
            //    {
            //        TongTien += (Double)this.dtChiTietPX.Rows[i]["ThanhTien"];
            //    }
            //}

            //this.txtTongTienSauCK.Text = Common.Double2Str(TongTien);
        }

        private void frmPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (!this.txtGhiChu.Focused && !this.dgvSanPhamBan.Focused && !this.txtMaVach.Focused && !this.dgvHangKhuyenMai.Focused)
                //{
                //    if (e.KeyCode == Keys.Enter)
                //    {
                //        SendKeys.Send("{TAB}");
                //        e.Handled = true;
                //        return;
                //    }
                //    else if (e.KeyCode == Keys.F2)
                //    {
                //        if (this.WindowState == FormWindowState.Maximized)
                //            this.WindowState = FormWindowState.Normal;
                //        else
                //            this.WindowState = FormWindowState.Maximized;
                //        e.Handled = true;
                //        return;
                //    }
                //}
                if (e.KeyCode == Keys.F3 && tsbPrev.Enabled)
                    this.tsbPrev_Click(sender, e);
                else if (e.KeyCode == Keys.F4 && tsbNext.Enabled)
                    this.tsbNext_Click(sender, e);
                else if (e.KeyCode == Keys.F5 && tsbAdd.Enabled)
                    this.tsbAdd_Click(sender, e);
                else if (e.KeyCode == Keys.F6 && tsbEdit.Enabled)
                    this.tsbEdit_Click(sender, e);
                else if (e.KeyCode == Keys.F7 && tsbUpdate.Enabled)
                    this.tsbUpdate_Click(sender, e);
                else if (e.KeyCode == Keys.F8 && tsbDelete.Enabled)
                    this.tsbDelete_Click(sender, e);
                else if (e.KeyCode == Keys.F9 && tsbPrint.Enabled)
                    this.tsbPrint_Click(sender, e);
                else if (e.KeyCode == Keys.F10 && tsbSearch.Enabled)
                    this.tsbSearch_Click(sender, e);
                else if (e.KeyCode == Keys.F11 && tsbPayment.Enabled)
                    this.tsbPayment_Click(sender, e);
                else if (e.KeyCode == Keys.F12 && tsbClose.Enabled)
                    this.tsbClose_Click(sender, e);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }


        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //double TL_VAT;
                //TL_VAT = Common.DoubleValue(this.txtTyLeVAT.Text.Trim());
                //if (TL_VAT != 0)
                //{
                //    this.txtTongTienVAT.Text = Common.Double2Str((TL_VAT / 100) * Common.DoubleValue(this.txtTongTienSauCK.Text.Trim()));
                //}
                //else
                //{
                //    this.txtTongTienThanhToan.Text = this.txtTongTienSauCK.Text;
                //}
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void txtTienVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTongTienThanhToan.Text = Common.Double2Str(Common.DoubleValue(this.txtTongTienSauCK.Text.Trim()) + Common.DoubleValue(this.txtTongTienVAT.Text.Trim()));
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void txtTyLeVAT_TextChanged(object sender, EventArgs e)
        {
            //try
            //{

            //    this.txtTongTienVAT.Text = Common.Double2Str((Common.DoubleValue(this.txtTyLeVAT.Text.Trim()) / 100) * Common.DoubleValue(this.txtTongTienSauCK.Text.Trim()));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //} 
        }

        private void txtTienConNo_TextChanged(object sender, EventArgs e)
        {
            try
            {

                this.txtTienConNo.Text = Common.Double2Str(Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()) - Common.DoubleValue(this.txtTienThucTra.Text.Trim()));
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void txtTongTienThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTienThucTra.Text = this.txtTongTienThanhToan.Text;
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void txtTyLeVAT_LostFocus(object sender, System.EventArgs e)
        {
            //try
            //{
            //    this.txtTyLeVAT.Text = Common.Double2Str(Common.DoubleValue(this.txtTyLeVAT.Text.Trim()));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }


        private void frmPhieuXuat_Resize(object sender, EventArgs e)
        {

            tabInfors.Location = new Point(grSanPhamBan.Location.X + grSanPhamBan.Width + 10, tabInfors.Location.Y);
            grPayments.Location = new Point(grSanPhamBan.Location.X + grSanPhamBan.Width + 10, grPayments.Location.Y);
            //int x = grMaVach.Location.X + grMaVach.Width - btnThemHang.Location.X - btnThemHang.Width - 20;
            ////           if (x > 0)
            //{
            //    btnThemHang.Location = new Point(btnThemHang.Location.X + x, btnThemHang.Location.Y);
            //    lblGia.Location = new Point(lblGia.Location.X + x, lblGia.Location.Y);
            //    txtGiaSanPham.Location = new Point(txtGiaSanPham.Location.X + x, txtGiaSanPham.Location.Y);

            //    txtMaVach.Width = txtMaVach.Width + x;
            //    txtTenSanPham.Width = txtTenSanPham.Width + x;
            //    btnXoaSanPham.Location = new Point(btnXoaSanPham.Location.X + x, btnXoaSanPham.Location.Y);
            //    btnXoaKhuyenMai.Location = new Point(btnXoaKhuyenMai.Location.X + x, btnXoaKhuyenMai.Location.Y);
            //}
        }

        private void txtSoPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (this.IdPhieuXuat == 0)
                {
                    PhieuXuat_KhoiTaoSoPhieu();
                    this.txtSoPhieu.SelectionStart = this.txtSoPhieu.Text.Trim().Length;
                }
            }
        }

        #endregion

        private void txtMaVach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string str = "Select sp.TenSanPham, sp.DonGiaCoVAT From vSanPham sp ";
                str += " Inner Join tbl_HangHoa_Chitiet hh on sp.IdSanPham = hh.IdSanPham";
                str += " Where hh.MaVach = N'" + txtMaVach.Text.Trim() + "'";
                str += " and sp.IdTrungTam = " + Declare.IdTrungTam;

                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                txtTenSanPham.Text = dt.Rows[0]["TenSanPham"].ToString();
                txtGiaSanPham.Text = Common.Double2Str((double)dt.Rows[0]["DonGiaCoVAT"]);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void txtMaVach_TextEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtMaVach.Text.Trim() != "")
                    InputDataFromCode(txtMaVach.Text.Trim(), true);
            }
        }

        //private void cboLoaiTien_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string str = "Select DISTINCT tt.TyGia From tbl_DM_TienTe tt Where tt.IdTienTe = " + cboLoaiTien.SelectedValue;
        //        double tygia = Convert.ToDouble(DBTools.getValue(str));
        //        txtTyGia.Text = Common.Double2Str(tygia);
        //    }
        //    catch (Exception ex) { ex.ToString(); }

        //}

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = this.cboKhachHang.SelectedIndex;
                txtMaKhachHang.Text = this.dtKhachHang.Rows[index]["MaDoiTuong"].ToString();
                LoadDiaChiKH();
                if (txtHoTenKhachHang.Text.Trim().Equals(""))
                    txtHoTenKhachHang.Text = this.dtKhachHang.Rows[index]["TenDoiTuong"].ToString();
                if (txtDiaChi.Text.Trim().Equals(""))
                    txtDiaChi.Text = this.dtKhachHang.Rows[index]["DiaChi"].ToString();
                if (txtDienThoai.Text.Trim().Equals(""))
                    txtDienThoai.Text = this.dtKhachHang.Rows[index]["DienThoai"].ToString();
                if (txtMaSoThue.Text.Trim().Equals("")) 
                    txtMaSoThue.Text = this.dtKhachHang.Rows[index]["MaSoThue"].ToString();
                
                try
                {
                    if (Common.IntValue(this.dtKhachHang.Rows[index]["IdOrderType"]) > 0)
                        this.cboOrderType.SelectedValue = Common.IntValue(this.dtKhachHang.Rows[index]["IdOrderType"]);
                }
                catch { }
            }
            catch (System.Exception ex)
            {
                txtMaKhachHang.Text = "";
                LoadDiaChiKH();
                //txtHoTenKhachHang.Text = "";
                //txtDiaChi.Text = "";
                //txtDienThoai.Text = "";
                //txtMaSoThue.Text = "";
                txtOrderType.Text = "";
                cboOrderType.Text = "";
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void InputDataFromCode(string code, bool isEnter)
        {
            try
            {
                Utils ut = new Utils();
                int idSPBan = -1;
                DataTable dt;
                if (!ut.isStringNotEmpty(code)) return;
                string sql = string.Format(@"SELECT IdChiTiet FROM tbl_HangHoa_Chitiet   
                            WHERE tbl_HangHoa_Chitiet.MaVach=N'{0}'", code);
                if (ut.fGetID_sql(sql) == 0)
                {
                    frm_Chon_SanPham_MaVach frm = new frm_Chon_SanPham_MaVach(txtMaVach, int.Parse(cboKhoXuat.SelectedValue.ToString()));
                    frm.Show();
                    return;
                }
                //Kiem tra trang thai san pham
                string str = String.Format("Select IdSanPham From tbl_HangHoa_ChiTiet Where MaVach = N'{0}' and IdKho = {1} and SoLuong > 0 ",
                                            code, cboKhoXuat.SelectedValue);

                if (DBTools.getValue(str).Equals(""))
                {
                    MessageBox.Show("Sản phẩm này không tồn tại trong kho, bạn không thể bán được");
                    return;
                }
                //Kiem tra san pham da nhap chua, neu nhap roi thi tang so luong
                bool foundSP = false;
                foreach (DataGridViewRow row in dgvSanPhamBan.Rows)
                {
                    if (row.Cells["MaVach"].Value.ToString().Equals(code))
                    {

                        idSPBan = Common.IntValue(row.Cells["IdSanPham"].Value.ToString());
                        str = String.Format("Select case when TrungMaVach is null then 0 else TrungMaVach end TrungMaVach From tbl_SanPham Where IdSanPham = {0}", idSPBan);
                        if (DBTools.getValue(str).Equals("1"))
                        {
                            row.Cells["SoLuong"].Value = Common.IntValue(row.Cells["SoLuong"].Value.ToString()) + 1;
                            foundSP = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm có mã vạch này đã nhập rồi, bạn không thể nhập lại nữa!");
                            return;
                        }

                    }
                }
                if (!foundSP)//khong thi them moi
                {
                    //lay thong tin san pham
                    str = "Select hh.MaVach,sp.IdSanPham,sp.MaSanPham, sp.TenSanPham," +
                              "sp.TenDonViTinh,sp.DonGiaChuaVAT,sp.TyleChietKhau, " +
                              "sp.TienChietKhau, sp.TyLeVAT, sp.TienVAT, sp.DonGiaCoVAT, " +
                              "sp.TyLeThuong, sp.ThuongNong " +
                          " From tbl_HangHoa_Chitiet hh " +
                          " inner join vSanPham sp on hh.IdSanPham = sp.IdSanPham " +
                          " Where hh.MaVach=N'" + code + "' and hh.IdKho=" + this.cboKhoXuat.SelectedValue +
                            " and sp.IdTrungTam = " + Declare.IdTrungTam;
                    dt = DBTools.getData("tbl_HangHoa_Chitiet", str).Tables["tbl_HangHoa_Chitiet"];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        idSPBan = Common.IntValue(dt.Rows[0]["IdSanPham"].ToString());
                        int soLuong = 1;
                        double tienSauChietKhau = 0;
                        try
                        {
                            tienSauChietKhau = Common.DoubleValueInt(dt.Rows[0]["DonGiaChuaVAT"]) - Common.DoubleValueInt(dt.Rows[0]["TienChietKhau"]);
                        }
                        catch (Exception ex) { }
                        object[] arr ={dt.Rows[0]["MaVach"], dt.Rows[0]["IdSanPham"], dt.Rows[0]["MaSanPham"],
                                dt.Rows[0]["TenSanPham"], dt.Rows[0]["TenDonViTinh"], 
                                soLuong, Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["DonGiaChuaVAT"])), Common.Double2Str((double)dt.Rows[0]["TyLeChietKhau"]*TyLe), Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["TienChietKhau"])), 
                                Common.Double2Str(tienSauChietKhau), Common.Double2Str((double)dt.Rows[0]["TyLeVAT"]<0?(double)dt.Rows[0]["TyLeVAT"]:(double)dt.Rows[0]["TyLeVAT"]*TyLe), Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["TienVAT"])), Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["DonGiaCoVAT"])),"",
                                Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["TienChietKhau"])), Common.Double2Str(tienSauChietKhau), Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["TienVAT"])), Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["DonGiaCoVAT"])),
                                dt.Rows[0]["TyLeThuong"],Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["ThuongNong"])),
                                Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["DonGiaChuaVAT"]))};
                        this.dgvSanPhamBan.Rows.Add(arr);

                        DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                        //newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + dt.Rows[0]["IdSanPham"].ToString()));
                        newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");//sửa giá bán
                        newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                        newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                        //DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                        //newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + idSPBan));
                        //newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");//sửa giá bán
                        //newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm này không có trong kho hoặc ở trong kho khác.\nBạn không có quyền bán!");
                        return;
                    }

                }
                //lay danh sach hang khuyen mai
                str = "Select distinct km.IdKhuyenMai From vKhuyenMai km " +
                      "Where km.IdSanPhamBan = " + idSPBan + " and km.IdTrungTam = " + Declare.IdTrungTam;
                dt = DBTools.getData("KM", str).Tables["KM"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    frmPhieuXuat_ChonKhuyenMai frmKM = new frmPhieuXuat_ChonKhuyenMai(idSPBan);
                    frmKM.ShowDialog();
                    int idKhuyenMai = frmKM.IdKhuyenMai;
                    if (idKhuyenMai == 0) return;
                    List<STKhuyenMai> lstMavachKM = frmKM.getMaVachKM();
                    if (lstMavachKM.Count == 0) return;
                    str = "Select distinct km.IdSanPhamBan, km.TenSanPhamBan, km.IdSanPham, " +
                                 "km.MaSanPham, km.TenSanPham, km.TenDonViTinh, km.SoLuong, km.SoTien " +
                          "From vKhuyenMai km " +
                          "Where km.IdSanPhamBan = " + idSPBan + " and km.IdTrungTam = " + Declare.IdTrungTam + " and km.IdKhuyenMai = " + idKhuyenMai;


                    dt = DBTools.getData("KM", str).Tables["KM"];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            foreach (STKhuyenMai km in lstMavachKM)
                            {
                                if (km.MaSanPham.Equals(dt.Rows[i]["MaSanPham"]))
                                {
                                    bool found = false;
                                    //neu trung thi tang so luong len
                                    foreach (DataGridViewRow row in dgvHangKhuyenMai.Rows)
                                    {
                                        if (idSPBan == int.Parse(row.Cells["IdSanPhamBan"].Value.ToString()) &&
                                            row.Cells["MaVachKM"].Value.ToString().Equals(km.MaVach))
                                        {
                                            row.Cells["SoLuongKM"].Value = Common.IntValue(row.Cells["SoLuongKM"].Value.ToString()) + Common.IntValue(dt.Rows[i]["SoLuong"].ToString());
                                            row.Cells["SoTienKM"].Value = Common.Double2Str(Common.DoubleValueInt(row.Cells["SoTienKM"].Value.ToString()) + Common.DoubleValueInt(dt.Rows[i]["SoTien"]));
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (!found)//nguoc lai thi them moi
                                    {
                                        object[] arr ={km.MaVach, dt.Rows[i]["IdSanPham"], dt.Rows[i]["MaSanPham"], dt.Rows[i]["TenSanPham"],
                                            dt.Rows[i]["IdSanPhamBan"], dt.Rows[i]["TenSanPhamBan"], dt.Rows[i]["TenDonViTinh"],
                                            dt.Rows[i]["SoLuong"], Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["SoTien"]))};
                                        this.dgvHangKhuyenMai.Rows.Add(arr);

                                    }
                                    lstMavachKM.Remove(km);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }


        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (txtMaVach.Text.Trim() != "")
                InputDataFromCode(txtMaVach.Text.Trim(), true);
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            prev();
            showInfors();
        }
        private void prev()
        {
            if (IndexPX > 0)
            {
                if (Updating)
                {
                    if (MessageBox.Show("Dữ liệu đang cập nhật, bạn có muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                IndexPX--;
                this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdPhieuXuat"].ToString());
                this.LoadPhieuXuat(this.IdPhieuXuat);
                Updating = false;
                setEDFunctions();
                setEDUpdate();
                
            }
        }
        private void tsbNext_Click(object sender, EventArgs e)
        {
            next();
            showInfors();
        }
        private void next()
        {
            if (IndexPX < dtPhieuXuat.Rows.Count - 1)
            {
                if (Updating)
                {
                    if (MessageBox.Show("Dữ liệu đang cập nhật, bạn có muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }


                IndexPX++;
                this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdPhieuXuat"].ToString());
                this.LoadPhieuXuat(this.IdPhieuXuat);
                Updating = false;
                setEDFunctions();
                setEDUpdate();
                
            }
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            refress();
            //add();
            //this.Text = "Cập nhật phiếu xuất kho. Đang tạo phiếu xuất mới ...";
        }
        private void refress()
        {
            LoadAllPhieuXuat();
            if (dtPhieuXuat != null && dtPhieuXuat.Rows.Count > 0)
            {
                if (this.IdPhieuXuat == 0)
                {
                    this.IndexPX = 0;
                    this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdPhieuXuat"].ToString());
                }
                else
                {
                    for (int i = 0; i < dtPhieuXuat.Rows.Count; i++)
                    {
                        if (Common.IntValue(dtPhieuXuat.Rows[i]["IdPhieuXuat"]) == this.IdPhieuXuat)
                        {
                            IndexPX = i;
                            break;
                        }
                    }
                }
                this.LoadPhieuXuat(this.IdPhieuXuat);
            }

            setEDFunctions();
            showInfors();
        }
        private void add()
        {
            try
            {
                //DaLapHoaDon = false;
                Updating = true;
                setEDItems(true);
                setEDUpdate();
                this.PhieuXuat_ThemMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (Common.DaNhapTraLai(IdPhieuXuat))
            {
                MessageBox.Show("Phiếu xuất này đã được nhập lại. Bạn không thể xóa hoặc sửa được!\nHãy xóa phiếu nhập lại nếu muốn thay đổi thông tin phiếu xuất!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Updating = false;
                setEDItems(false);
                setEDUpdate();
                return;
            }
            else
            {
                if (ValidPhieuXuatGop())
                {
                    edit();
                }
                else
                {
                    Updating = false;
                    setEDItems(false);
                    setEDUpdate();
                }
                showInfors();
            }
        }
        private void edit()
        {            
            Updating = true;
            setEDItems(true);
            setEDUpdate();
        }
        private bool ValidPhieuXuatGop()
        {
            try
            {
                //kiem tra xem chung tu nay co cua phieu xuat gop khong
                string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                    "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("Hóa đơn được xuất gộp, hãy Hủy hóa đơn trước rồi xuất lại hóa đơn", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            return true;
        }

        
        private void setEDItems(bool status)
        {
            this.mstNgayXuat.Enabled = status;
            this.cboQuyen.Enabled = status;
            this.txtKyHieu.Enabled = status;
            this.txtSoSerie.Enabled = status;
            this.cboQuyenKM.Enabled = status & (dgvHangKhuyenMai.RowCount>0);
            this.txtKyHieuKM.Enabled = status & (dgvHangKhuyenMai.RowCount > 0);
            this.txtSoSerieKM.Enabled = status & (dgvHangKhuyenMai.RowCount > 0);
            this.txtSoPhieu.Enabled = status;
            this.cboNhanVien.Enabled = status;// false;
            this.txtMaNhanVien.Enabled = status;// false;
            this.cboKhachHang.Enabled = status;
            this.txtHoTenKhachHang.Enabled = status;
            this.txtDiaChi.Enabled = status;
            this.txtDienThoai.Enabled = status;
            this.txtMaSoThue.Enabled = status;
            this.txtGhiChu.Enabled = status;
            this.txtMaKhachHang.Enabled = status;
            this.cboGioiTinh.Enabled = status;
            this.txtTuoi.Enabled = status;
            //this.txtMaNhanVien.Enabled = status;
            this.txtBillTo.Enabled = status;
            this.txtShipTo.Enabled = status;
            this.cboBillTo.Enabled = status;
            this.cboShipTo.Enabled = status;
            this.txtOrderType.Enabled = status;
            this.cboOrderType.Enabled = status;
            this.txtOrderTypeKM.Enabled = status & (dgvHangKhuyenMai.RowCount > 0);
            this.cboOrderTypeKM.Enabled = status & (dgvHangKhuyenMai.RowCount > 0);
            //this.cboLoaiTien.Enabled = status;
            this.txtTienThucTra.Enabled = status;
            //this.dgvSanPhamBan.Enabled = status;
            //this.dgvSanPhamBan.Columns["SoLuong"].ReadOnly = !status;
            //this.dgvSanPhamBan.Columns["GhiChu"].ReadOnly = !status;
            //this.dgvHangKhuyenMai.Columns["SoLuong"].ReadOnly = !status;
            //this.dgvHangKhuyenMai.Enabled = status;
            this.txtMaVach.Enabled=status;
            this.txtGiaSanPham.Enabled = status;
            this.btnThemHang.Enabled = status;
            //this.btnTimKiem.Enabled = status;
            this.btnXoaSanPham.Enabled = status;
            this.btnChietKhau.Enabled = status;
            this.btnXoaKhuyenMai.Enabled = status;
            this.cboHinhThucTT.Enabled = status;
            this.cboLoaiTra.Enabled = status;
            this.cboBangKeThue.Enabled = status;
            this.cboLoaiHoaDon.Enabled = status;
            this.cboMaDuAn.Enabled = status;
            //this.cboThu.Enabled = status;
        }
        private void setEDFunctions()
        {
            if (IdPhieuXuat == 0)
            {
                this.tsbPrev.Enabled = false;
                this.tsbNext.Enabled = false;
                this.tsbEdit.Enabled = false;
                this.tsbDelete.Enabled = false;
                this.tsbPrint.Enabled = false;
            }
            else
            {
                this.tsbPrev.Enabled = IndexPX > 0 ? true : false;
                this.tsbNext.Enabled = IndexPX < (dtPhieuXuat.Rows.Count - 1) ? true : false;
                this.tsbEdit.Enabled = ChuaDayOracle;
                this.tsbDelete.Enabled = ChuaDayOracle;
                this.tsbUpdate.Enabled = ChuaDayOracle;
                this.tsbPayment.Enabled = ChuaDayOracle;
                this.tsbPrint.Enabled = true;
            }
            //this.tsbAdd.Enabled = Common.IsEnableCommandPX(-1) & this.tsbAdd.Visible;
            this.tsbPrint.Enabled = DaLapHoaDon & this.tsbPrint.Enabled;
        }

        private void setEDUpdate()
        {
            //this.tsbAdd.Enabled = !Updating;
            this.tsbEdit.Enabled = !Updating &ChuaDayOracle;
            this.tsbUpdate.Enabled = Updating;// &ChuaDayOracle;
            this.tsbPrint.Enabled = Updating | DaLapHoaDon;
            this.tsbPayment.Enabled = Updating;// &ChuaDayOracle;
        }

        private void GenerateReceipt(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, List<ChiTietPhieuXuat> hoadon, List<ChiTietPhieuXuat> hoadonCK, int LoaiChungTu, int stt)
        {
            //them bang tbl_chungtu
            if (stt > 0)
                SoSerie = Common.LoadNextHoaDon(SoSerie);
            int IdChungTu = this.ChungTu_InsertCommand(sqlcmd, sqlCon, sqlTran, hoadon, hoadonCK, LoaiChungTu);
            //them bang chi tiet
            foreach (ChiTietPhieuXuat px in hoadon)
            {
                //them bang chi tiet chung tu
                int idChitietCT = this.ChiTiet_ChungTu_InsertCommand(sqlcmd, sqlCon, sqlTran, IdChungTu, px.IdSanPham, px.SoLuong, px.DonGia,
                                                                px.TyLeChietKhau, px.TienChietKhau);
                //them bang chi tiet hang hoa
                foreach (ChiTietHangHoa hh in px.DsHangHoa)
                    this.ChiTiet_ChungTu_HangHoa_InsertCommand(sqlcmd, sqlCon, sqlTran, idChitietCT, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau);
            }
            //them chiet khau
            foreach (ChiTietPhieuXuat px in hoadonCK)
            {
                //them bang chi tiet chung tu
                int idChitietCT = this.ChietKhau_ChungTu_InsertCommand(sqlcmd, sqlCon, sqlTran, IdChungTu, px.IdSanPham, px.SoLuong, px.TienChietKhau, px.TienVAT, px.GhiChu);
            }
        }
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            RecalculateInfors();
            update(false);
            showInfors();
        }
        private void updateFields()
        {
            if (txtHoTenKhachHang.Text.Trim().Equals(""))
                txtHoTenKhachHang.Text = this.dtKhachHang.Rows[this.cboKhachHang.SelectedIndex]["TenDoiTuong"].ToString();
            if (txtDiaChi.Text.Trim().Equals(""))
                txtDiaChi.Text = this.dtDiaChi.Rows[this.cboBillTo.SelectedIndex]["DiaChi"].ToString();
        }
        private bool update(bool print)
        {
            GtidConnection sqlCon = null;
            GtidTransaction sqlTran = null;
            GtidCommand sqlCmd = null;
            string strMsg = "Tạo mới phiếu xuất thành công!";
            bool isAdded = false;
            bool chuaXuatHD = false;
            try
            {
                if (!this.PhieuXuat_SuHopLeCuaThongTin()) return false;
                updateFields();
                sqlCon = ConnectionUtil.Instance.GetConnection();
                sqlTran = ConnectionUtil.Instance.BeginTransaction();
                sqlCmd = new GtidCommand();//"", sqlCon, sqlTran);
                if (!DaLapHoaDon)
                    chuaXuatHD = true;
                DaLapHoaDon = true;
                //Cap nhat thong tin chung
                if (this.IdPhieuXuat == 0)
                {
                    //Them header
                    this.PhieuXuat_InsertCommand(sqlCmd, sqlCon, sqlTran);
                    isAdded = true;
                }
                else
                {
                    //sua header
                    this.PhieuXuat_UpdateCommand(sqlCmd, sqlCon, sqlTran, chuaXuatHD);
                    //cap nhat lai bang hang hoa chi tiet
                    CapNhat_HangHoaChiTiet(sqlCmd, sqlCon, sqlTran);
                    //xoa het chi tiet cu
                    this.PhieuXuat_AllDetails_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                    //this.PhieuXuat_AllChungTu_HuyCommand(sqlCmd, sqlCon, sqlTran);
                    //xoa het cac chung tu tao ra tu phieu xuat nay
                    this.PhieuXuat_AllChungTu_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                    //xoa het cac phieu thu tao ra tu phieu xuat nay
                    this.PhieuXuat_AllThuChi_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                    strMsg = "Cập nhật phiếu xuất thành công!";
                }

                //Them chi tiet san pham ban
                List<ChiTietPhieuXuat> listCK = new List<ChiTietPhieuXuat>();
                List<ChiTietPhieuXuat> listPX = GetChiTietPhieuXuat(sqlCmd, sqlCon, ref listCK);
                foreach (ChiTietPhieuXuat px in listPX)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietPX_InsertCommand(sqlCmd, sqlCon, sqlTran, px.IdSanPham, px.IdSanPhamBan, px.SoLuong, px.DonGia,
                                                                    px.TyLeChietKhau, px.TienChietKhau, px.TyLeVAT, px.TienVAT, px.TyLeThuong, px.ThuongNong, px.GiaTheoBangGia);
                    //them bang chi tiet hang hoa
                    foreach (ChiTietHangHoa hh in px.DsHangHoa)
                        this.ChiTietPX_HangHoa_InsertCommand(sqlCmd, sqlCon, sqlTran, idChitietPX, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau, hh.TienVAT, hh.ThuongNong, hh.GhiChu);
                }

                //Them hang chiet khau
                foreach (ChiTietPhieuXuat px in listCK)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietCK_InsertCommand(sqlCmd, sqlCon, sqlTran, px.IdSanPham, px.SoLuong, px.TienChietKhau, px.TyLeVAT, px.TienVAT, px.GhiChu);
                }

                //Them chi tiet san pham khuyen mai
                List<ChiTietPhieuXuat> listKM = GetChiTietKhuyenMai(sqlCmd, sqlCon);
                foreach (ChiTietPhieuXuat km in listKM)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietPX_InsertCommand(sqlCmd, sqlCon, sqlTran, km.IdSanPham, km.IdSanPhamBan, km.SoLuong, km.DonGia,
                                                                    km.TyLeChietKhau, km.TienChietKhau, km.TyLeVAT, km.TienVAT, km.TyLeThuong, km.ThuongNong, km.GiaTheoBangGia);
                    //them bang chi tiet hang hoa
                    foreach (ChiTietHangHoa hh in km.DsHangHoa)
                        this.ChiTietPX_HangHoa_InsertCommand(sqlCmd, sqlCon, sqlTran, idChitietPX, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau, hh.TienVAT, hh.ThuongNong, hh.GhiChu);
                }

                //Tu dong ghi vao bang hoa don
                //Tao hoa don cho chi tiet san pham ban
                listPX.Sort(new BillCompare());
                listChungTu = new List<HoaDon>();
                double vat = -1;
                SoSerie = txtSoSerie.Text;
                lstSoSeri = new List<string>();
                List<ChiTietPhieuXuat> hoadon = null;
                List<ChiTietPhieuXuat> hoadonCK = null;
                int stt = 0;
                while (listPX.Count > 0)
                {
                    hoadon = new List<ChiTietPhieuXuat>();
                    hoadon.Add(listPX[0]);
                    vat = listPX[0].TyLeVAT;
                    listPX.RemoveAt(0);
                    for (int i = listPX.Count - 1; i >= 0; i--)
                    {
                        if (vat == listPX[i].TyLeVAT)
                        {
                            hoadon.Add(listPX[i]);
                            listPX.RemoveAt(i);
                        }
                    }
                    hoadonCK = new List<ChiTietPhieuXuat>();
                    for (int i = listCK.Count - 1; i >= 0; i--)
                    {
                        if (vat == listCK[i].TyLeVAT)
                        {
                            hoadonCK.Add(listCK[i]);
                            listCK.RemoveAt(i);
                        }
                    }
                    //tao moi hoa don
                    GenerateReceipt(sqlCmd, sqlCon, sqlTran, hoadon, hoadonCK, (int)TransactionType.XUAT_BAN, stt);
                    stt++;
                }

                while (listCK.Count > 0)
                {
                    hoadon = new List<ChiTietPhieuXuat>();
                    hoadonCK = new List<ChiTietPhieuXuat>();
                    hoadonCK.Add(listCK[0]);
                    vat = listCK[0].TyLeVAT;
                    listCK.RemoveAt(0);
                    for (int i = listCK.Count - 1; i >= 0; i--)
                    {
                        if (vat == listCK[i].TyLeVAT)
                        {
                            hoadonCK.Add(listCK[i]);
                            listCK.RemoveAt(i);
                        }
                    }
                    //tao moi hoa don
                    GenerateReceipt(sqlCmd, sqlCon, sqlTran, hoadon, hoadonCK, (int)TransactionType.XUAT_BAN, stt);
                    stt++;
                }

                //Tao hoa don cho cac san pham khuyen mai
                stt = 0;
                hoadonCK = new List<ChiTietPhieuXuat>();
                if (listKM.Count > 0)
                {
                    GenerateReceipt(sqlCmd, sqlCon, sqlTran, listKM, hoadonCK, (int)TransactionType.XUAT_KHUYEN_MAI, stt);
                }
                
                //Tao phieu thu
                ThuChi_InsertCommand(sqlCmd, sqlCon, sqlTran);

                //if (NewHoaDon)
                //{
                    Common.updateSoHoaDon(txtSoSerie.Text, txtKyHieu.Text);
                    Common.updateSoHoaDon(SoSerie, txtKyHieu.Text);
                    if (dgvHangKhuyenMai.RowCount > 0 && cboQuyenKM.SelectedValue != null)
                        Common.updateSoHoaDon(txtSoSerieKM.Text, txtKyHieuKM.Text);
                //}
                ConnectionUtil.Instance.CommitTransaction();

                Common.LogAction(strMsg, "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
                if (!print)
                    MessageBox.Show(strMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Dong trong truong hop sua tu danh sach tim kiem
                if (this.IndexPXSearch >= 0)
                {
                    this.Close();
                    return true;
                }
                //Thiet lap trang thai item, load lai danh sach phieu xuat
                if (isAdded)
                {
                    LoadAllPhieuXuat();
                    IndexPX = dtPhieuXuat.Rows.Count - 1;
                }
                Updating = false;
                setEDFunctions();
                setEDUpdate();
                setEDItems(false);
                showInfors();
            }
            catch (Exception ex)
            {
                DaLapHoaDon = false;
                ConnectionUtil.Instance.RollbackTransaction();
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogAction("Lỗi cập nhật phiếu xuất" , "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
                //if (sqlTran != null)
                //    sqlTran.Rollback();
                return false;
            }
            return true;
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            //updateCSDL();
            if (Common.DaNhapTraLai(IdPhieuXuat))
            {
                MessageBox.Show("Phiếu xuất này đã được nhập lại. Bạn không thể xóa hoặc sửa được!\nHãy xóa phiếu nhập lại nếu muốn thay đổi thông tin phiếu xuất!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Updating = false;
                setEDItems(false);
                setEDUpdate();
                return;
            }
            else
            {
                delete();
                showInfors();
            }
        }
        private void updateCSDL()
        {
            string sql = "select db.* from tbl_LichSu_DongBo db inner join tbl_chungtu ct on db.idchungtu = ct.idchungtu and db.idkho != ct.idkho";
            DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idkho = Common.IntValue(dt.Rows[i]["IdKho"]);
                    int idct = Common.IntValue(dt.Rows[i]["IdChungTu"]);
                    string sr = dt.Rows[i]["SoSeri"].ToString();

                    //int idpx = Common.IntValue(dt.Rows[i]["IdPhieuXuat"]);
                    sql = String.Format("delete from tbl_LichSu_DongBo where idkho={0} and idchungtu={1} and soseri='{2}'",idkho,idct,sr);
//                    sql = String.Format(@"update tbl_chungtu set NguoiTao = (select NguoiTao from tbl_phieuxuat where Idphieuxuat = {0}) where idphieuxuat = {0}
//                             update tbl_chungtu set ThoigianTao = (select ThoigianTao from tbl_phieuxuat where Idphieuxuat = {0}) where idphieuxuat = {0}
//                             update tbl_chungtu set TenMayTao = (select TenMayTao from tbl_phieuxuat where Idphieuxuat = {0}) where idphieuxuat = {0}
//                             update tbl_chungtu set NguoiSua = (select NguoiSua from tbl_phieuxuat where Idphieuxuat = {0}) where idphieuxuat = {0}
//                             update tbl_chungtu set ThoigianSua = (select ThoigianSua from tbl_phieuxuat where Idphieuxuat = {0}) where idphieuxuat = {0}
//                             update tbl_chungtu set TenMaySua = (select TenMaySua from tbl_phieuxuat where Idphieuxuat = {0}) where idphieuxuat = {0}", idpx);
                    if (DBTools.ExecuteQuery(sql, CommandType.Text) == null)
                    {
                        MessageBox.Show("delete failed at bill[" + idkho + "] : " + idct);
                        return;
                    }
                    //DataTable dt1 = DBTools.getData("tmp", sql).Tables["tmp"];
                    //if (dt1 != null && dt1.Rows.Count > 0)
                    //{
                    //    sql = String.Format("update tbl_phieuxuat set soserieKM='{0}',kyhieuKM='{1}', quyenKM={2} where idphieuxuat={3}",
                    //                        dt1.Rows[0]["soseri"], dt1.Rows[0]["sochungtu"], dt1.Rows[0]["quyenso"], idpx);

                    //    if (DBTools.ExecuteQuery(sql, CommandType.Text) == null)
                    //    {
                    //        MessageBox.Show("Update failed at bill[" + i + "] : " + idpx);
                    //        return;
                    //    }
                    //}

                }
                MessageBox.Show("Update successfully for " + dt.Rows.Count + " bills!");
            }
        }
        private void delete()
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn hủy hóa đơn cho phiếu xuất này không?", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (rs == DialogResult.Cancel)
            {
                return;
            }
            else if (rs == DialogResult.Yes)
            {

                //if (MessageBox.Show("Bạn có chắc chắn hủy dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNoCancel) == DialogResult.No)
                //    return;

                //Xoa du lieu hien tai
                if (this.IdPhieuXuat != 0)
                {
                    GtidConnection sqlCon = null;
                    GtidTransaction sqlTran = null;
                    GtidCommand sqlCmd = null;
                    try
                    {
                        sqlCon = ConnectionUtil.Instance.GetConnection();
                        sqlTran = ConnectionUtil.Instance.BeginTransaction();
                        sqlCmd = new GtidCommand("", sqlCon, sqlTran);
                        //cap nhat lai hang hoa chi tiet
                        //CapNhat_HangHoaChiTiet(sqlCmd, sqlCon, sqlTran);
                        //xoa phieu thu
                        this.PhieuXuat_AllThuChi_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                        //xoa cac chung tu
                        this.PhieuXuat_AllChungTu_HuyCommand(sqlCmd, sqlCon, sqlTran);
                        //xoa chi tiet phieu xuat
                        //this.PhieuXuat_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                        ConnectionUtil.Instance.CommitTransaction();
                        Common.LogAction("Hủy hóa đơn cho phiếu xuất thành công", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
                        MessageBox.Show("Hủy hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Dong trong truong hop sua tu danh sach tim kiem
                        //if (this.IndexPXSearch >= 0)
                        //{
                        //    this.dtPXSearch.Rows.RemoveAt(this.IndexPXSearch);
                        //    this.Close();
                        //    return;
                        //}
                        //dtPhieuXuat.Rows.RemoveAt(IndexPX);
                        //DaLapHoaDon = false;
                        this.LoadPhieuXuat(this.IdPhieuXuat);
                    }
                    catch (Exception ex)
                    {
                        ConnectionUtil.Instance.RollbackTransaction();
                        Common.LogAction("Hủy hóa đơn bán hàng thất bại", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
                        MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //if (sqlTran != null)
                        //    sqlTran.Rollback();
                    }
                }
            }

            //Thiet lap trang thai item
            Updating = false;
            setEDFunctions();
            setEDUpdate();
            setEDItems(false);
        }
        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (dgvSanPhamBan.RowCount == 0)
            {
                MessageBox.Show("Chưa có sản phẩm bán");
                return;
            }
            if (Updating)
            {
                if (update(true))
                    print();
            }
            else
            {
                LoadChungTu();
                print();
            }
        }

        private void LoadChungTu()
        {
            string str = String.Format("select IdChungTu, QuyenSo, SoChungTu, SoSeri,NgayLap, OrderType, BillTo, ShipTo, TongTienHang, " +
                         " TongTienChietKhau, TyleVAT, TongTienVAT, TongTienThanhToan, HinhThucThanhToan, HinhThucTra, GhiChu" +
                         " from tbl_ChungTu" +
                         " where IdPhieuXuat = {0} or (idphieuxuat=0 and " +
                         "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%'))", IdPhieuXuat);

            DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
            listChungTu = new List<HoaDon>();
            //luu lai danh sach chung tu
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HoaDon chungtu = new HoaDon(Common.IntValue(row["IdChungTu"]), Common.IntValue(row["QuyenSo"]), row["SoChungTu"].ToString(), row["SoSeri"].ToString(), this.mstNgayXuat.Value, "", "", "", "", this.cboNhanVien.SelectedText,
                                         this.txtHoTenKhachHang.Text, (int)this.cboGioiTinh.SelectedIndex, Common.IntValue(this.txtTuoi.Text.Trim()), this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text, Common.IntValue(row["OrderType"]), Common.IntValue(row["BillTo"]), Common.IntValue(row["ShipTo"]),
                                          Common.DoubleValue(row["TongTienHang"]), Common.DoubleValue(row["TongTienChietKhau"]), Common.DoubleValue(row["TyleVAT"]), Common.DoubleValue(row["TongTienVAT"]), Common.DoubleValue(row["TongTienThanhToan"]), Declare.KyHieuTienTe, row["HinhThucThanhToan"].ToString(), Common.IntValue(row["HinhThucTra"]), row["GhiChu"].ToString());
                    listChungTu.Add(chungtu);
                }
            }

            //load IdPhieuThu
            str = String.Format("select IdPhieu from tbl_ThuChi where ChungTuGoc in " +
                         " (select SoPhieuXuat from tbl_PhieuXuat where IdPhieuXuat = {0}) or " +
                         "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);

            dt = DBTools.getData("tmp", str).Tables["tmp"];
            if (dt != null && dt.Rows.Count > 0)
                this.IdPhieuThu = Common.IntValue(dt.Rows[0]["IdPhieu"]);
            else
                this.IdPhieuThu = 0;
        }

        private void print()
        {
            string str = "Select kh.MaKho, kh.TenKho, kh.DiaChi, kh.DienThoai, tt.TenTrungTam " +
                         " From tbl_DM_Kho kh inner join tbl_DM_TrungTam tt on tt.IdTrungTam = kh.IdTrungTam" +
                         " Where kh.IdKho = " + this.cboKhoXuat.SelectedValue;

            DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
            string kho = dtKho.Rows[0]["MaKho"].ToString() + " - " + dtKho.Rows[0]["TenKho"].ToString();
            string khachhang = this.dtKhachHang.Rows[cboKhachHang.SelectedIndex]["MaDoiTuong"].ToString() + " - " + txtHoTenKhachHang.Text;
 
            PhieuXuat px = new PhieuXuat(this.IdPhieuXuat, this.txtSoPhieu.Text, this.mstNgayXuat.Value, dtKho.Rows[0]["TenTrungTam"].ToString(), kho, dtKho.Rows[0]["DiaChi"].ToString(),
                             dtKho.Rows[0]["DienThoai"].ToString(), this.cboNhanVien.SelectedText, khachhang, this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text,
                            Common.DoubleValue(this.txtTongTienHang.Text.Trim()), Common.DoubleValue(this.txtTongTienCK.Text.Trim()), Common.DoubleValue(this.txtTongTienVAT.Text.Trim()),
                            Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()), Common.DoubleValue(this.txtTienThucTra.Text.Trim()), Common.DoubleValue(this.txtTienConNo.Text.Trim()),
                            Declare.KyHieuTienTe, ThanhToan[cboHinhThucTT.SelectedIndex], this.txtGhiChu.Text);
            frmPhieuXuat_LuaChonIn frmInPX = new frmPhieuXuat_LuaChonIn(px, listChungTu, IdPhieuThu);
            frmInPX.ShowDialog();
            Common.LogAction("In phiếu xuất", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
        }
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            search();
            showInfors();
        }

        private void search()
        {
            int[] IdPhieu = new int[] { 0 };
            frmTimPhieuXuat frm = new frmTimPhieuXuat((int)TransactionType.XUAT_BAN, IdPhieu);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (IdPhieu[0] > 0) {
                    this.IdPhieuXuat = IdPhieu[0];
                    if (dtPhieuXuat.PrimaryKey.Length == 0)
                        dtPhieuXuat.PrimaryKey = new DataColumn[] { dtPhieuXuat.Columns["IdPhieuXuat"] };
                    IndexPX = dtPhieuXuat.Rows.IndexOf(dtPhieuXuat.Rows.Find(this.IdPhieuXuat));
                    //LoadQuyen();
                    this.LoadPhieuXuat(this.IdPhieuXuat);
                    setEDFunctions();
                    if (ChuaDayOracle)
                        tsbEdit_Click(this, null);
                }
            }
            //frm.MdiParent = this.ParentForm;
            //this.Close();            
        }

        private void tsbPayment_Click(object sender, EventArgs e)
        {
            payment();
        }
        private void payment()
        {
            this.Cursor = Cursors.WaitCursor;
            //ket qua
            if (this.cboHinhThucTT.SelectedIndex == 0)//tien mat
            {
                frmPhieuXuat_TraTienThua frm = new frmPhieuXuat_TraTienThua(this.txtTongTienThanhToan.Text,
                                this.txtTienThucTra.Text, this.txtTienConNo.Text, Declare.KyHieuTienTe, Common.IntValue(cboLoaiTra.SelectedValue));
                //frm.MdiParent = this.ParentForm;
                frm.ShowDialog();

                this.txtTienThucTra.Text = frm.txtTienThucTra.Text;
                double tienThanhToan = Common.DoubleValue(this.txtTongTienThanhToan.Text);
                double tienThucTra = Common.DoubleValue(this.txtTienThucTra.Text);
                double tienConNo = tienThanhToan - tienThucTra;
                if (tienConNo > 0)
                    this.txtTienConNo.Text = Common.Double2Str(tienConNo);
                else
                    this.txtTienConNo.Text = Common.Double2Str(0);
            }
            else//chuyen khoan
            {
                frmPhieuXuat_ChuyenKhoan frm = new frmPhieuXuat_ChuyenKhoan(this.txtTongTienThanhToan.Text,
                this.txtTienThucTra.Text, this.txtTienConNo.Text, Declare.KyHieuTienTe, SoTaiKhoan, NganHang, int.Parse(this.cboLoaiTra.SelectedValue.ToString()));
                //frm.MdiParent = this.ParentForm;
                frm.ShowDialog();

                SoTaiKhoan = frm.txtSoTaiKhoan.Text;
                NganHang = frm.txtNganHang.Text;
                cboLoaiTra.SelectedValue = frm.cboHinhThucTra.SelectedValue;
                txtTienConNo.Text = frm.txtTienConNo.Text;
            }
            this.Cursor = Cursors.Default;
            Common.LogAction("Trả tiền thừa mua hàng", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            close();
        }
        private void close()
        {
            try
            {
                this.Close();
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void dgvSanPhamBan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvSanPhamBan.EndEdit();
            if (dgvSanPhamBan.CurrentRow != null)
            {
                if (dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["SoLuong"] ||
                    dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["DonGia"] ||
                    dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["TyleChietKhau"] ||
                    dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["TyleVAT"])
                {
                    int soLuong = Common.IntValue(dgvSanPhamBan.CurrentRow.Cells["SoLuong"].Value);
                    double dongia = Common.DoubleValueInt(dgvSanPhamBan.CurrentRow.Cells["DonGia"].Value);
                    double tyleCK = Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["TyleChietKhau"].Value);
                    double tyleVAT = Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["TyleVAT"].Value);
                    if (tyleVAT < 0) tyleVAT = 0;

                    double tongtien = soLuong * dongia;
                    double tienCK = Common.Round(tongtien * tyleCK / TyLe);//soLuong * Common.DoubleValueInt(dgvSanPhamBan.CurrentRow.Cells["Unit_CK"].Value.ToString());
                    //double tienCK = tongtien * tyleCK / TyLe;
                    double tienSauCK = tongtien - tienCK;
                    double tienVAT = Common.Round(tienSauCK * tyleVAT / TyLe);
                    double thanhTien = tienSauCK + tienVAT;
                    dgvSanPhamBan.CurrentRow.Cells["TienChietKhau"].Value = Common.Double2Str(tienCK);
                    dgvSanPhamBan.CurrentRow.Cells["TienSauChietKhau"].Value = Common.Double2Str(tienSauCK);
                    dgvSanPhamBan.CurrentRow.Cells["TienVAT"].Value = Common.Double2Str(tienVAT);
                    dgvSanPhamBan.CurrentRow.Cells["ThanhTien"].Value = Common.Double2Str(thanhTien);

                    //int soLuong = Common.IntValue(dgvSanPhamBan.CurrentRow.Cells["SoLuong"].Value.ToString());
                    //double tienCK = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_CK"].Value.ToString());
                    //double tienSauCK = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_SauCK"].Value.ToString());
                    //double tienVAT = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_VAT"].Value.ToString());
                    //double thanhTien = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_ThanhTien"].Value.ToString());
                    //dgvSanPhamBan.CurrentRow.Cells["TienChietKhau"].Value = Common.Double2Str(tienCK);
                    //dgvSanPhamBan.CurrentRow.Cells["TienSauChietKhau"].Value = Common.Double2Str(tienSauCK);
                    //dgvSanPhamBan.CurrentRow.Cells["TienVAT"].Value = Common.Double2Str(tienVAT);
                    //dgvSanPhamBan.CurrentRow.Cells["ThanhTien"].Value = Common.Double2Str(thanhTien);
                }

                UpdateSummariesInfors();
            }

        }
        private void RecalculateInfors()
        {
            try
            {
                double tongTienHang = 0;
                double tongTienCK = 0;
                double tongTienSauCK = 0;
                double tongTienVAT = 0;
                double tongThanhTien = 0;
                double tienThucTra = Common.DoubleValue(this.txtTienThucTra.Text.Trim());
                dgvSanPhamBan.EndEdit();
                foreach (DataGridViewRow dgr in dgvSanPhamBan.Rows)
                {
                    
                    int soLuong = Common.IntValue(dgr.Cells["SoLuong"].Value);
                    double dongia = Common.DoubleValueInt(dgr.Cells["DonGia"].Value);
                    double tyleCK = Common.DoubleValue(dgr.Cells["TyleChietKhau"].Value);
                    double tyleVAT = Common.DoubleValue(dgr.Cells["TyleVAT"].Value);
                    if (tyleVAT < 0) tyleVAT = 0;

                    double tongtien = soLuong * dongia;
                    double tienCK = Common.Round(tongtien * tyleCK / TyLe);//soLuong * Common.DoubleValueInt(dgr.Cells["Unit_CK"].Value.ToString());
                    //double tienCK = tongtien * tyleCK / TyLe;
                    double tienSauCK = tongtien - tienCK;
                    double tienVAT = Common.Round(tienSauCK * tyleVAT / TyLe);
                    double thanhTien = tienSauCK + tienVAT;
                    //details
                    dgr.Cells["TienChietKhau"].Value = Common.Double2Str(tienCK);
                    dgr.Cells["TienSauChietKhau"].Value = Common.Double2Str(tienSauCK);
                    dgr.Cells["TienVAT"].Value = Common.Double2Str(tienVAT);
                    dgr.Cells["ThanhTien"].Value = Common.Double2Str(thanhTien);

                    //summeries
                    tongTienHang += tongtien;//soLuong * Common.DoubleValueInt(dgr.Cells["DonGia"].Value.ToString());
                    tongTienCK += tienCK;// Common.DoubleValueInt(dgr.Cells["TienChietKhau"].Value.ToString());
                    tongTienSauCK += tienSauCK;// Common.DoubleValueInt(dgr.Cells["TienSauChietKhau"].Value.ToString());
                    tongTienVAT += tienVAT;// Common.DoubleValueInt(dgr.Cells["TienVAT"].Value.ToString());
                    tongThanhTien += thanhTien;// Common.DoubleValueInt(dgr.Cells["ThanhTien"].Value.ToString());
                }
                this.txtTongTienHang.Text = Common.Double2Str(tongTienHang);
                this.txtTongTienCK.Text = Common.Double2Str(tongTienCK);
                this.txtTongTienSauCK.Text = Common.Double2Str(tongTienSauCK);
                this.txtTongTienVAT.Text = Common.Double2Str(tongTienVAT);
                this.txtTongTienThanhToan.Text = Common.Double2Str(tongThanhTien);
                this.txtTienConNo.Text = Common.Double2Str(tongThanhTien - tienThucTra);
            }
            catch (Exception ex) { }
        }
        private void UpdateSummariesInfors()
        {
            try
            {
                double tongTienHang = 0;
                double tongTienCK = 0;
                double tongTienSauCK = 0;
                double tongTienVAT = 0;
                double tongThanhTien = 0;
                double tienThucTra = Common.DoubleValue(this.txtTienThucTra.Text.Trim());
                foreach (DataGridViewRow dgr in dgvSanPhamBan.Rows)
                {
                    int soLuong = Common.IntValue(dgr.Cells["SoLuong"].Value);
                    tongTienHang += soLuong * Common.DoubleValueInt(dgr.Cells["DonGia"].Value);
                    tongTienCK += Common.DoubleValueInt(dgr.Cells["TienChietKhau"].Value);
                    tongTienSauCK += Common.DoubleValueInt(dgr.Cells["TienSauChietKhau"].Value);
                    tongTienVAT += Common.DoubleValueInt(dgr.Cells["TienVAT"].Value);
                    tongThanhTien += Common.DoubleValueInt(dgr.Cells["ThanhTien"].Value);
                }
                this.txtTongTienHang.Text = Common.Double2Str(tongTienHang);
                this.txtTongTienCK.Text = Common.Double2Str(tongTienCK);
                this.txtTongTienSauCK.Text = Common.Double2Str(tongTienSauCK);
                this.txtTongTienVAT.Text = Common.Double2Str(tongTienVAT);
                this.txtTongTienThanhToan.Text = Common.Double2Str(tongThanhTien);
                this.txtTienConNo.Text = Common.Double2Str(tongThanhTien - tienThucTra);
            }
            catch (Exception ex) { }            
        }

        private void txtTienThucTra_TextChanged(object sender, EventArgs e)
        {
            double tienThanhToan = Common.DoubleValue(txtTongTienThanhToan.Text.Trim());
            double tienThucTra = Common.DoubleValue(txtTienThucTra.Text.Trim());
            double tienConNo = tienThanhToan - tienThucTra;
            txtTienConNo.Text = Common.Double2Str(tienConNo);
        }
        private void txtTienThucTra_LostFocus(object sender, EventArgs e)
        {
            try
            {
                this.txtTienThucTra.Text = Common.Double2Str(Common.DoubleValue(this.txtTienThucTra.Text.Trim()));
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void txtTienThucTra_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtTienThucTra.Focus();
                this.txtTienThucTra.SelectAll();
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dgvSanPhamBan.SelectedRows)
            {
                int ck = Common.IntValue(row.Cells["GiaTheoBangGia"].Value);
                if (ck == -1)
                {
                    dgvSanPhamBan.Rows.Remove(row);
                    count++;
                }
            }
            if (count == 0)
                MessageBox.Show("Không có dòng chiết khấu nào được xóa!");
        }

        private void btnXoaKhuyenMai_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHangKhuyenMai.SelectedRows)
            {
                int slKM = Common.IntValue(row.Cells["SoLuongKM"].Value);
                double tienKM = Common.DoubleValueInt(row.Cells["SoTienKM"].Value);
                int IdBan = Common.IntValue(row.Cells["IdSanPhamBan"].Value);
                double tienChuyen = 0;
                int slChuyen = slKM;
                if (slChuyen > 1)
                {
                    InputDialog input = new InputDialog(0, slChuyen);
                    input.ShowDialog();
                    if (input.IsInput)
                        slChuyen = input.InputedNumber;
                    else
                        return;
                }
                tienChuyen = Common.Round(tienKM / slKM * slChuyen);
                //dieu chinh gia
                foreach (DataGridViewRow row1 in dgvSanPhamBan.Rows)
                {
                    int IdSP = Common.IntValue(row1.Cells["IdSanPham"].Value.ToString());
                    if (IdBan == IdSP)
                    {
                        int soluong = Common.IntValue(row1.Cells["SoLuong"].Value.ToString());
                        double dongia = Common.DoubleValueInt(row1.Cells["DonGia"].Value.ToString());
                        double tlck = Common.DoubleValue(row1.Cells["TyleChietKhau"].Value.ToString());
                        double tlvat = Common.DoubleValue(row1.Cells["TyleVAT"].Value.ToString());
                        if (tlvat < 0) tlvat = 0;
                        double giamgia, giamoi, tongtien, tienck, tiensauck, tienvat, thanhtien;
                        giamgia = Common.Round(tienChuyen / (soluong * (1 - tlck / TyLe) * (1 + tlvat / TyLe)));
                        giamoi = dongia - giamgia;
                        tongtien = giamoi * soluong;
                        tienck = Common.Round(tongtien * tlck / TyLe);
                        tiensauck = tongtien - tienck;
                        tienvat = Common.Round(tiensauck * tlvat / TyLe);
                        thanhtien = tiensauck + tienvat;// Common.DoubleValue(row1.Cells["ThanhTien"].Value.ToString()) - tienChuyen;

                        row1.Cells["DonGia"].Value = Common.Double2Str(giamoi);
                        row1.Cells["TienChietKhau"].Value = Common.Double2Str(tienck);
                        row1.Cells["TienSauChietKhau"].Value = Common.Double2Str(tiensauck);
                        row1.Cells["TienVAT"].Value = Common.Double2Str(tienvat);
                        row1.Cells["ThanhTien"].Value = Common.Double2Str(thanhtien);
                        break;
                    }
                }
                //thiet lap tien con lai
                if (slChuyen == slKM)
                    dgvHangKhuyenMai.Rows.Remove(row);
                else
                {
                    row.Cells["SoLuongKM"].Value = slKM - slChuyen;
                    row.Cells["SoTienKM"].Value = Common.Double2Str(tienKM - tienChuyen);
                }

                //UpdateSummariesInfors();
            }
        }

        private void dgvHangKhuyenMai_RowChanged(object sender, EventArgs e)
        {
            lblKMInfors.Text = "Tổng số khuyến mại: " + dgvHangKhuyenMai.Rows.Count;
        }
        private void dgvSanPhamBan_RowChanged(object sender, EventArgs e)
        {
            lblSPBInfors.Text = "Tổng số sản phẩm bán: " + dgvSanPhamBan.Rows.Count;
            UpdateSummariesInfors();
        }

        private void txtMaVach_Leave(object sender, EventArgs e)
        {
            //if (txtMaVach.Text.Trim() != "")
            //    InputDataFromCode(txtMaVach.Text.Trim(), false);
        }

        private void cboHinhThucTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHinhThucTT.SelectedIndex == 0)
                txtTienThucTra.Enabled = true;
            else
                txtTienThucTra.Enabled = false;
        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtOrderType.Text = dtOrderType.Rows[cboOrderType.SelectedIndex]["Code"].ToString();
            }
            catch { txtOrderType.Text = ""; }
        }

        private void cboBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                    txtBillTo.Text = dtDiaChi.Rows[cboBillTo.SelectedIndex]["SiteNumber"].ToString();
                    txtDiaChi.Text = cboBillTo.Text;
            }
            catch { txtBillTo.Text = ""; }
        }

        private void cboShipTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtShipTo.Text = dtDiaChi.Rows[cboShipTo.SelectedIndex]["SiteNumber"].ToString();
            }
            catch { txtShipTo.Text = ""; }
        }

        private void txtBillTo_TextChanged(object sender, EventArgs e)
        {
            for (int i=0; i<dtDiaChi.Rows.Count; i++)
            {
                if (txtBillTo.Text.Equals(dtDiaChi.Rows[i]["SiteNumber"].ToString()))
                {
                    cboBillTo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void txtShipTo_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtDiaChi.Rows.Count; i++)
            {
                if (txtShipTo.Text.Equals(dtDiaChi.Rows[i]["SiteNumber"].ToString()))
                {
                    cboShipTo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNhanVien.Text = dtNhanVien.Rows[cboNhanVien.SelectedIndex]["MaNhanVien"].ToString();
            }
            catch { txtMaNhanVien.Text = ""; }
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            return;
            bool found = false;
            for (int i = 0; i < dtKhachHang.Rows.Count; i++)
            {
                if (txtMaKhachHang.Text.Equals(dtKhachHang.Rows[i]["MaDoiTuong"].ToString()))
                {
                    cboKhachHang.SelectedIndex = i;
                    found = true;
                    break;
                }
            }
            //if (!found)
            //{
            //    //cboKhachHang.Text = "";
            //    //txtBillTo.Text = "";
            //    //cboBillTo.Text = "";
            //    //txtShipTo.Text = "";
            //    //cboShipTo.Text = "";
            //    //txtOrderType.Text = "";
            //    //cboOrderType.Text = "";
            //    //txtOrderTypeKM.Text = "";
            //    //cboOrderTypeKM.Text = "";
            //}
        }

        //private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        //{
        //    //bool found = false;
        //    for (int i = 0; i < dtNhanVien.Rows.Count; i++)
        //    {
        //        if (txtMaNhanVien.Text.Equals(dtNhanVien.Rows[i]["MaNhanVien"].ToString()))
        //        {
        //            cboNhanVien.SelectedIndex = i;
        //            //found = true;
        //            break;
        //        }
        //    }
        //    //if (!found)
        //    //    cboNhanVien.Text = "";
        //}

        private void txtOrderType_TextChanged(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtOrderType.Rows.Count; i++)
            {
                if (txtOrderType.Text.Equals(dtOrderType.Rows[i]["Code"].ToString()))
                {
                    cboOrderType.SelectedIndex = i;
                    found = true;
                    break;
                }
            }
            if (!found)
                cboOrderType.Text = "";
        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHoaDon(cboQuyen.Enabled);
        }

        private void cboKhachHang_TextUpdate(object sender, EventArgs e)
        {
            
            //if (cboKhachHang.Text.Trim().Length == 0)
            //{
            //    txtMaKhachHang.Text = "";
            //    txtBillTo.Text = "";
            //    cboBillTo.Text = "";
            //    txtShipTo.Text = "";
            //    cboShipTo.Text = "";
            //    txtOrderType.Text = "";
            //    cboOrderType.Text = "";
            //    //txtOrderTypeKM.Text = "";
            //    //cboOrderTypeKM.Text = "";
            //}
        }

        //private void cboNhanVien_TextUpdate(object sender, EventArgs e)
        //{
        //    //if (cboNhanVien.Text.Trim().Length == 0)
        //    //    txtMaNhanVien.Text = "";
        //}

        private void cboBillTo_TextUpdate(object sender, EventArgs e)
        {
            //if (cboBillTo.Text.Trim().Length == 0)
            //    txtBillTo.Text = "";
        }

        private void cboShipTo_TextUpdate(object sender, EventArgs e)
        {
            //if (cboShipTo.Text.Trim().Length == 0)
            //    txtShipTo.Text = "";
        }

        private void cboOrderType_TextUpdate(object sender, EventArgs e)
        {
            //if (cboOrderType.Text.Trim().Length == 0)
            //    txtOrderType.Text = "";
        }

        private void txtMaVach_Enter(object sender, EventArgs e)
        {
            this.txtMaVach.Focus();
            this.txtMaVach.SelectAll();
        }

        private void cboNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboNhanVien_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboNhanVien.Text.Trim().Length > 0)
            {
                for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                {
                    if (dtNhanVien.Rows[i]["HoTen"].ToString().ToLower().Equals(cboNhanVien.Text.Trim().ToLower()))
                    {
                        //cboNhanVien.SelectedIndex = i;
                        cboNhanVien.SelectedValue = dtNhanVien.Rows[i]["IdNhanVien"];
                        found = true;
                        break;
                    }
                }
           }
            if (!found || cboNhanVien.Text.Length == 0)
            {
               // MessageBox.Show("Nhân viên này không có trong danh sách, chọn nhân viên khác");
                cboNhanVien.Text = "";
            }
        }


        private void cboKhachHang_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboKhachHang.Text.Trim().Length > 0)
            {
                
                for (int i = 0; i < dtKhachHang.Rows.Count; i++)
                {
                    if (dtKhachHang.Rows[i]["TenDoiTuong"].ToString().ToLower().Equals(cboKhachHang.Text.Trim().ToLower()))
                    {
                        //cboKhachHang.SelectedIndex = i;
                        cboKhachHang.SelectedValue = dtKhachHang.Rows[i]["IdDoiTuong"];
                        found = true;
                        break;
                    }
                }
            }
            if (!found || cboKhachHang.Text.Length==0)
            {
                //MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
                cboKhachHang.Text = "";
                txtMaKhachHang.Text = "";
                txtBillTo.Text = "";
                cboBillTo.Text = "";
                txtShipTo.Text = "";
                cboShipTo.Text = "";
                txtOrderType.Text = "";
                cboOrderType.Text = "";
            }
        }

        private void dgvSanPhamBan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSanPhamBan.CurrentRow != null)
            {
                int ck = Common.IntValue(dgvSanPhamBan.CurrentRow.Cells["GiaTheoBangGia"].Value);
                if (ck == -1) return;

                if (dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["SoLuong"])
                {
                    Utils ut = new Utils();
                    if (ut.getInt(e.FormattedValue) < 0)
                    {
                        MessageBox.Show("Số lượng phải >=0");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void txtOrderTypeKM_TextChanged(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtOrderTypeKM.Rows.Count; i++)
            {
                if (txtOrderTypeKM.Text.Equals(dtOrderTypeKM.Rows[i]["Code"].ToString()))
                {
                    cboOrderTypeKM.SelectedIndex = i;
                    found = true;
                    break;
                }
            }
            if (!found)
                cboOrderTypeKM.Text = "";
        }

        private void cboOrderTypeKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtOrderTypeKM.Text = dtOrderTypeKM.Rows[cboOrderTypeKM.SelectedIndex]["Code"].ToString();
            }
            catch { txtOrderTypeKM.Text = ""; }
        }

        private void cboOrderTypeKM_TextUpdate(object sender, EventArgs e)
        {
            //if (cboOrderTypeKM.Text.Trim().Length == 0)
            //    txtOrderTypeKM.Text = "";
        }

        private void btnLoadQuyen_Click(object sender, EventArgs e)
        {
            LoadQuyen();
        }

        private void tabInfors_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void btnTimOrderKH_Click(object sender, EventArgs e)
        {
            string str;
            DataTable dt;

            str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.QuyenSo,px.KyHieu,px.SoSerie,px.IdKho,kh.TenKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi," +
                         "px.DienThoai, px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                         "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.SoOrderKH,px.NhapHoaDon,px.QuyenKM,px.KyHieuKM,px.SoSerieKM " +
                  "from tbl_PhieuXuat px inner join tbl_dm_kho kh on px.IdKho = kh.IdKho " +
                  "where SoOrderKH='" + txtSoOrderKH.Text.Trim() + "'";

            dt = DBTools.getData("Tmp", str).Tables["Tmp"];
            dgvSanPhamBan.Rows.Clear();
            dgvHangKhuyenMai.Rows.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Declare.IdKho != Common.IntValue(dt.Rows[0]["IdKho"]))
                {
                    MessageBox.Show("Giao dịch này xuất ở kho [" + dt.Rows[0]["TenKho"].ToString() + "].\nBạn không thể xuất hóa đơn được.\nHãy thiết lập lại kho hiện tại về kho [" + dt.Rows[0]["TenKho"].ToString() + "]");
                    if (this.IdPhieuXuat > 0)
                        LoadPhieuXuat(this.IdPhieuXuat);
                }
                else
                {
                    this.PhieuXuat_HienThi(dt.Rows[0]);
                    this.IdPhieuXuat = Common.IntValue(dt.Rows[0]["IdPhieuXuat"]);
                    ChuaDayOracle = Common.IsEnableCommandPX(this.IdPhieuXuat);
                    for (int i = 0; i < dtPhieuXuat.Rows.Count; i++)
                    {
                        if (Common.IntValue(dtPhieuXuat.Rows[i]["IdPhieuXuat"]) == this.IdPhieuXuat)
                        {
                            IndexPX = i;
                            break;
                        }
                    }
                    str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                                 "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                          "FROM vChiTietPhieuXuat " +
                          "WHERE IdPhieuXuat=" + this.IdPhieuXuat + " and IdSanPhamBan is null " +
                          "Union all " +
                          "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                                 "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                          "FROM vChietKhauPhieuXuat " +
                          "WHERE IdPhieuXuat=" + this.IdPhieuXuat;
                    dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                    this.dgvSanPhamBan.Rows.Clear();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        double tienSauCK = Common.IntValue(dt.Rows[i]["SoLuong"].ToString()) * Common.DoubleValue(dt.Rows[i]["DonGia"].ToString())
                                            - Common.DoubleValue(dt.Rows[i]["TienChietKhau"].ToString());
                        object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["DonGia"])),
                            Common.Double2Str((double)dt.Rows[i]["TyLeChietKhau"] * TyLe),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"])),
                            Common.Double2Str(tienSauCK),                            
                            //Common.Double2Str((double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str((double)dt.Rows[i]["TyLeVAT"]<0?(double)dt.Rows[i]["TyLeVAT"]:(double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienVAT"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"])),
                            dt.Rows[i]["GhiChu"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"])),
                            Common.Double2Str(tienSauCK),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienVAT"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"])),
                            dt.Rows[i]["TyLeThuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThuongNong"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["GiaTheoBangGia"]))
                        };
                        this.dgvSanPhamBan.Rows.Add(arr);
                        DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                        //newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + idSPBan));
                        newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");//sửa giá bán
                        newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                        newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    }

                    str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                                 "IdSanPhamBan,MaSanPhamBan,TenSanPhamBan,SoLuong,ThanhTien " +
                          "FROM vChiTietPhieuXuat " +
                          "WHERE IdPhieuXuat=" + this.IdPhieuXuat + " and IdSanPhamBan is not null ";
                    dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                    this.dgvHangKhuyenMai.Rows.Clear();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["IdSanPhamBan"],
                            dt.Rows[i]["TenSanPhamBan"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"]))};
                        this.dgvHangKhuyenMai.Rows.Add(arr);
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có phiếu xuất cho giao dịch số [" + txtSoOrderKH.Text + "]");
                if (this.IdPhieuXuat > 0)
                    LoadPhieuXuat(this.IdPhieuXuat);
            }
            Updating = false;
            setEDItems(false);
            setEDFunctions();
            setEDUpdate();
            showInfors();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string str = "select px.IdPhieuXuat from tbl_PhieuXuat px ";
            //str += string.Format(" where px.NgayXuat >= convert(datetime,'{0}',121) and px.NgayXuat >=  convert(datetime,'{1}',121)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2LongString(Declare.NgayLamViec));
            //str += string.Format(" where px.ThoigianSua > convert(datetime,'{0}',121) and px.ThoigianSua >=  convert(datetime,'{1}',103)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2String(Declare.NgayLamViec));
            //string.Format(" and convert(varchar,px.ThoigianSua,101) <= convert(datetime,'{0}',103) ", Common.Date2String(DateTime.Now));
            str += " where px.LoaiXuatNhap = " + (int)TransactionType.XUAT_BAN;
            str += " and px.IdKho=" + Declare.IdKho;
            str += " and (px.NhapHoaDon is null or px.NhapHoaDon=0)";
            DataTable dt = DBTools.getData("Tmp", str).Tables["Tmp"];
            if (dt != null && dt.Rows.Count > 0)
                ((IMain)(this.ParentForm)).ShowTTHoaDon(string.Format("Hiện có {0} order chưa xuất hóa đơn!!!", dt.Rows.Count));
            else
                ((IMain)(this.ParentForm)).ShowTTHoaDon("");
        }

        private void frmPhieuXuatHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((IMain)(this.ParentForm)).ShowTTHoaDon("");
            frmTimPhieuXuat.SQLSearch = "";
        }

        private void dgvSanPhamBan_Leave(object sender, EventArgs e)
        {
            dgvSanPhamBan.EndEdit();
        }

        private void txtMaKhachHang_Leave(object sender, EventArgs e)
        {           
            bool found = false;
            for (int i = 0; i < dtKhachHang.Rows.Count; i++)
            {
                if (txtMaKhachHang.Text.Equals(dtKhachHang.Rows[i]["MaDoiTuong"].ToString()))
                {
                    //cboKhachHang.SelectedIndex = i;
                    cboKhachHang.SelectedValue = dtKhachHang.Rows[i]["IdDoiTuong"];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                txtMaKhachHang.Text = "";
                cboKhachHang.Text = "";
                txtBillTo.Text = "";
                cboBillTo.Text = "";
                txtShipTo.Text = "";
                cboShipTo.Text = "";
                txtOrderType.Text = "";
                cboOrderType.Text = "";
                //txtOrderTypeKM.Text = "";
                //cboOrderTypeKM.Text = "";
            }
        }

        private void txtMaKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMaKhachHang_Leave(sender, e);
            }
        }

        private void cboKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboKhachHang_Leave(sender, e);
            }
        }

        private void txtBillTo_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtDiaChi.Rows.Count; i++)
            {
                if (txtBillTo.Text.Equals(dtDiaChi.Rows[i]["SiteNumber"].ToString()))
                {
                    //cboBillTo.SelectedIndex = i;
                    cboBillTo.SelectedValue = dtDiaChi.Rows[i]["IdDiaChi"];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                txtBillTo.Text = "";
                cboBillTo.Text = "";
            }
        }

        private void txtBillTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtBillTo_Leave(sender, e);
            }
        }

        private void cboBillTo_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboBillTo.Text.Trim().Length > 0)
            {

                for (int i = 0; i < dtDiaChi.Rows.Count; i++)
                {
                    if (dtDiaChi.Rows[i]["DiaChi"].ToString().ToLower().Equals(cboBillTo.Text.Trim().ToLower()))
                    {
                        //cboBillTo.SelectedIndex = i;
                        cboBillTo.SelectedValue = dtDiaChi.Rows[i]["IdDiaChi"];
                        found = true;
                        break;
                    }
                }
            }
            if (!found || cboBillTo.Text.Length == 0)
            {
                //MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
                txtBillTo.Text = "";
                cboBillTo.Text = "";
            }
        }

        private void cboBillTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboBillTo_Leave(sender, e);
            }
        }

        private void txtShipTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtShipTo_Leave(sender, e);
            }
        }

        private void txtShipTo_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtDiaChi.Rows.Count; i++)
            {
                if (txtShipTo.Text.Equals(dtDiaChi.Rows[i]["SiteNumber"].ToString()))
                {
                    //cboShipTo.SelectedIndex = i;
                    cboShipTo.SelectedValue = dtDiaChi.Rows[i]["IdDiaChi"];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                txtShipTo.Text = "";
                cboShipTo.Text = "";
            }
        }

        private void cboShipTo_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboShipTo.Text.Trim().Length > 0)
            {

                for (int i = 0; i < dtDiaChi.Rows.Count; i++)
                {
                    if (dtDiaChi.Rows[i]["DiaChi"].ToString().ToLower().Equals(cboShipTo.Text.Trim().ToLower()))
                    {
                        //cboShipTo.SelectedIndex = i;
                        cboShipTo.SelectedValue = dtDiaChi.Rows[i]["IdDiaChi"];
                        found = true;
                        break;
                    }
                }
            }
            if (!found || cboShipTo.Text.Length == 0)
            {
                //MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
                txtShipTo.Text = "";
                cboShipTo.Text = "";
            }
        }

        private void cboShipTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboShipTo_Leave(sender, e);
            }
        }

        private void txtOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtOrderType_Leave(sender, e);
            }
        }

        private void txtOrderType_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtOrderType.Rows.Count; i++)
            {
                if (txtOrderType.Text.Equals(dtOrderType.Rows[i]["Code"].ToString()))
                {
                    //cboOrderType.SelectedIndex = i;
                    cboOrderType.SelectedValue = dtOrderType.Rows[i]["IdOrderType"];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                txtOrderType.Text = "";
                cboOrderType.Text = "";
            }
        }

        private void cboOrderType_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboOrderType.Text.Trim().Length > 0)
            {
                for (int i = 0; i < dtOrderType.Rows.Count; i++)
                {
                    if (dtOrderType.Rows[i]["Name"].ToString().ToLower().Equals(cboOrderType.Text.Trim().ToLower()))
                    {
                        //cboOrderType.SelectedIndex = i;
                        cboOrderType.SelectedValue = dtOrderType.Rows[i]["IdOrderType"];
                        found = true;
                        break;
                    }
                }
            }
            if (!found || cboOrderType.Text.Length == 0)
            {
                //MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
                txtOrderType.Text = "";
                cboOrderType.Text = "";
            }
        }

        private void cboOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboOrderType_Leave(sender, e);
            }
        }

        private void txtOrderTypeKM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtOrderTypeKM_Leave(sender, e);
            }
        }

        private void txtOrderTypeKM_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtOrderTypeKM.Rows.Count; i++)
            {
                if (txtOrderTypeKM.Text.Equals(dtOrderTypeKM.Rows[i]["Code"].ToString()))
                {
                    //cboOrderTypeKM.SelectedIndex = i;
                    cboOrderTypeKM.SelectedValue = dtOrderTypeKM.Rows[i]["IdOrderType"];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                txtOrderTypeKM.Text = "";
                cboOrderTypeKM.Text = "";
            }
        }

        private void cboOrderTypeKM_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboOrderTypeKM.Text.Trim().Length > 0)
            {
                for (int i = 0; i < dtOrderTypeKM.Rows.Count; i++)
                {
                    if (dtOrderTypeKM.Rows[i]["Name"].ToString().ToLower().Equals(cboOrderTypeKM.Text.Trim().ToLower()))
                    {
                        //cboOrderTypeKM.SelectedIndex = i;
                        cboOrderTypeKM.SelectedValue = dtOrderTypeKM.Rows[i]["IdOrderType"];
                        found = true;
                        break;
                    }
                }
            }
            if (!found || cboOrderTypeKM.Text.Length == 0)
            {
                //MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
                txtOrderTypeKM.Text = "";
                cboOrderTypeKM.Text = "";
            }
        }

        private void cboOrderTypeKM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboOrderTypeKM_Leave(sender, e);
            }
        }

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMaNhanVien_Leave(sender, e);
            }
        }

        private void txtMaNhanVien_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtNhanVien.Rows.Count; i++)
            {
                if (txtMaNhanVien.Text.Equals(dtNhanVien.Rows[i]["MaNhanVien"].ToString()))
                {
                    //cboNhanVien.SelectedIndex = i;
                    cboNhanVien.SelectedValue = dtNhanVien.Rows[i]["IdNhanVien"];
                    found = true;
                    break;
                }
            }
            if (!found)
                cboNhanVien.Text = "";
        }

        private void cboNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                cboNhanVien_Leave(sender, e);
            }
        }



        private void cboQuyenKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHoaDonKM(cboQuyenKM.Enabled);
        }

        private void txtSoOrderKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnTimOrderKH_Click(sender, e);
            }
        }

        private void btnChietKhau_Click(object sender, EventArgs e)
        {
            try
            {
                frmPhieuXuatHoaDon_ChonChietKhau frm = new frmPhieuXuatHoaDon_ChonChietKhau();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvSanPhamBan.Rows)
                    {
                        if (row.Cells["MaVach"].Value.ToString().Equals(frm.MaChietKhau))
                        {
                            dgvSanPhamBan.Rows.Remove(row);
                            break;
                        }
                    }

                    object[] arr ={frm.MaChietKhau, frm.IdChietKhau, frm.MaChietKhau, frm.TenChietKhau, frm.DonViTinh, 
                            -1, Common.Double2Str(frm.TienChietKhau), Common.Double2Str(0), Common.Double2Str(0), 
                            Common.Double2Str(-frm.TienChietKhau), Common.Double2Str(frm.VAT), Common.Double2Str(-frm.TongTienChietKhau + frm.TienChietKhau), 
                            Common.Double2Str(-frm.TongTienChietKhau),"Chiết khấu", Common.Double2Str(-1), Common.Double2Str(-frm.TienChietKhau), 
                            Common.Double2Str(-frm.TongTienChietKhau + frm.TienChietKhau), Common.Double2Str(-frm.TongTienChietKhau),
                            0,Common.Double2Str(0),Common.Double2Str(frm.TienChietKhau)};
                    this.dgvSanPhamBan.Rows.Add(arr);

                    DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                    newRow.Cells["SoLuong"].ReadOnly = true;
                    newRow.Cells["DonGia"].ReadOnly = false;
                    newRow.Cells["TyLeVAT"].ReadOnly = false;
                    newRow.Cells["TyleChietKhau"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                            //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
    }
}