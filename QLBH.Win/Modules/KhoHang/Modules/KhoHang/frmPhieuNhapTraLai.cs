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
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Common.Objects;
using QLBanHang.Modules;
using QLBH.Core.Exceptions;

namespace QLBanHang.Forms
{
    public partial class frmPhieuNhapTraLai : Form
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
        string[] ThanhToan = { "Tiền mặt", "Chuyển khoản", "Thẻ ViSa", "Thẻ ViSa Master", "Thẻ ATM", "Đối trừ nội bộ" };
        private bool hasPX = false;
        private int idPhieuXuatGoc = -1;
        private bool ChuaDayOracle = true;
        private List<string> lstSoSeri = null;
        #endregion

        #region "Các phương thức khởi tạo"
        public frmPhieuNhapTraLai()
        {
            InitializeComponent();
            Common.LoadStyle(this);
       }

        public frmPhieuNhapTraLai(DataTable dtPX, int IndexPXSearch)
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
            this.Text = "Cập nhật phiếu nhập hàng trả lại.";
        }
        #endregion

        #region "Các phương thức"

        private void PhieuXuat_KhoiTaoSoPhieu()
        {
            this.txtPhieuNhap.Text = Common.TaoSoPhieuTuDong("NTL", "tbl_PhieuXuat", "SoPhieuXuat");
        }

        private string PhieuXuat_LaySoPhieuChi()
        {
            return Common.TaoSoPhieuTuDong("PXC", "tbl_ThuChi", "SoPhieu");
        }

        private bool PhieuXuat_ThemMoi()
        {
            this.hasPX = false;
            this.IdPhieuXuat = 0;
            this.idPhieuXuatGoc = 0;
            this.PhieuXuat_KhoiTaoSoPhieu();
            this.mstNgayNhap.Value = DateTime.Now;//();//.Text = DateTime.Today.ToString("dd/MM/yyyy");
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
            try { this.cboOrderType.SelectedIndex = -1; }
            catch { }
            try { this.cboOrderTypeKM.SelectedIndex = -1; }
            catch { }
            try { this.cboBillTo.SelectedIndex = -1; }
            catch { }
            try { this.cboShipTo.SelectedIndex = -1; }
            catch { }
            try { this.cboNhanVien.SelectedIndex = -1; }
            catch { }
            try { this.cboKhoXuat.SelectedValue = Declare.IdKho; }
            catch { }
            try { this.cboKhachHang.SelectedValue = -1;// Declare.IdKHMacDinh; 
            }
            catch { }
            try { this.cboGioiTinh.SelectedIndex = 0; }
            catch { }
            this.cboBangKeThue.SelectedIndex = 0;
            this.cboLoaiHoaDon.SelectedIndex = 0;
            this.cboMaDuAn.SelectedIndex = 0;
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
            try { this.cboHinhThucTT.SelectedIndex = 0; }
            catch { }
            try { this.cboLoaiTra.SelectedIndex = 0; }
            catch { }

            this.dgvSanPhamBan.Rows.Clear();
            this.dgvHangKhuyenMai.Rows.Clear();
            this.txtMaVach.Text = "";
            this.txtTenSanPham.Text = "";
            this.txtMaVach.Focus();
            this.txtMaVach.SelectAll();
            return true;
        }

        private bool PhieuXuat_SuHopLeCuaThongTin()
        {
            //Kiem tra xem phieu xuat nay da nhap tra lai chua
            string str = "SELECT IdPhieuXuat FROM tbl_PhieuXuat WHERE SoPhieuXuatGoc = (Select SoPhieuXuat From tbl_PhieuXuat Where IdPhieuXuat = " + idPhieuXuatGoc + ")";
            if (DBTools.ExistData(str))
            {
                MessageBox.Show("Phiếu xuất này đã được nhập trả lại. \nBạn không thể nhập lại lần nữa cho phiếu xuất này được");
                return false;
            }

            //
            //Sự hợp lệ của thông tin số phiếu nhập hàng trả lại
            //
            if (this.txtPhieuNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số phiếu chưa nhập." + "\n" + "-Hãy nhập số phiếu", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.txtPhieuNhap.Focus();
                return false;
            }

            //Kiem tra trung so phieu
            string sqlstr = "select * from tbl_PhieuXuat where SoPhieuXuat=N'" + this.txtPhieuNhap.Text.Trim() + "' and IdPhieuXuat!=" + this.IdPhieuXuat;
            if (DBTools.ExistData(sqlstr))
            {
                MessageBox.Show("Số phiếu này đã có." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.txtPhieuNhap.Focus();
                return false;
            }
            //Kiem tra hop le hoa don
            //if (cboQuyen.SelectedValue == null || !Common.CheckHoaDon(txtSoSerie.Text, (int)cboQuyen.SelectedValue))
            //{
            //    MessageBox.Show("Số serie hóa đơn không đúng định dạng hoặc không có số này trong quyển hóa đơn.\nHãy nhập số serie khác", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtSoSerie.Focus();
            //    return false;
            //}
            //
            if (this.txtKyHieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ký hiệu hóa đơn chưa nhập." + "\n" + "-Hãy nhập Ký hiệu hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.txtKyHieu.Focus();
                return false;
            }
            if (this.txtSoSerie.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số serie hóa đơn chưa nhập." + "\n" + "-Hãy nhập Số serie hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.txtSoSerie.Focus();
                return false;
            }
            //Sự hợp lệ của thông tin ngày xuất
            //
            if (this.mstNgayNhap.Text.Trim().Length == 4)
            {
                MessageBox.Show("Ngày nhập lại chưa nhập." + "\n" + "-Hãy nhập ngày nhập", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.mstNgayNhap.Focus();
                return false;
            }
            if (this.mstNgayNhap.Text.Trim().Length > 4 && this.mstNgayNhap.Text.Trim().Length < 10)
            {
                MessageBox.Show("Ngày nhập chưa đúng." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.mstNgayNhap.Focus();
                return false;
            }
            if (!Common.IsValidDate(mstNgayNhap.Text.Trim()))
            {
                MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.mstNgayNhap.Focus();
                return false;
            }

            //
            //Sự hợp lệ của thông tin khách hàng 
            //
            if (this.cboKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa chọn khách hàng." + "\n" + "-Hãy chọn khách hàng", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.cboKhachHang.Focus();
                return false;
            }
            if (this.cboNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa chọn nhân viên." + "\n" + "-Hãy chọn nhân viên", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.cboNhanVien.Focus();
                return false;
            }
            if (this.cboBillTo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn địa chỉ hóa đơn." + "\n" + "-Hãy chọn địa chi Bill To", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.cboBillTo.Focus();
                return false;
            }
            if (this.cboShipTo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn địa chỉ Ship To." + "\n" + "-Hãy chọn địa chỉ Ship To", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.cboShipTo.Focus();
                return false;
            }

            if (this.cboOrderType.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa chọn Order Type." + "\n" + "-Hãy chọn Order Type", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[1];
                this.cboOrderType.Focus();
                return false;
            }
            if (this.cboBangKeThue.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thông tin bảng kê thuế." + "\n" + "-Hãy chọn bảng kê thuế", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.cboBangKeThue.Focus();
                return false;
            }
            if (this.cboLoaiHoaDon.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thông tin loại hóa đơn." + "\n" + "-Hãy chọn loại hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabInfors.SelectedTab = tabInfors.TabPages[2];
                this.cboLoaiHoaDon.Focus();
                return false;
            }
            if (this.cboLoaiTra.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn thông tin thời hạn thanh toán." + "\n" + "-Hãy chọn thời hạn thanh toán", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboLoaiTra.Focus();
                return false;
            }
            if (dgvHangKhuyenMai.RowCount > 0)
            {
                if (this.cboOrderTypeKM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa chọn Order Type hàng khuyến mại." + "\n" + "-Hãy chọn Order Type Khuyến mại", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[1];
                    this.cboOrderTypeKM.Focus();
                    return false;
                }
                if (this.txtKyHieuKM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ký hiệu hóa đơn KM chưa nhập." + "\n" + "-Hãy nhập Ký hiệu hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[1];
                    this.txtKyHieuKM.Focus();
                    return false;
                }
                if (this.txtSoSerieKM.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Số serie hóa đơn KM chưa nhập." + "\n" + "-Hãy nhập Số serie hóa đơn", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabInfors.SelectedTab = tabInfors.TabPages[1];
                    this.txtSoSerieKM.Focus();
                    return false;
                }
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
                //if (Common.DoubleValue(this.txtTienThucTra.Text.Trim()) < 0 || Common.DoubleValue(this.txtTienThucTra.Text.Trim()) > Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()))
                //{
                //    MessageBox.Show("Tiền trả của khách hàng phải lớn hơn hoặc bằng 0 và nhỏ hơn hoặc bằng tổng tiền thanh toán" + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    this.txtTienThucTra.Focus();
                //    return false;
                //}
            }

            //
            //Sự hợp lệ của thông tin chi tiết phiếu nhập hàng trả lại
            //
            if (this.dgvSanPhamBan.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết phiếu nhập hàng trả lại.", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvSanPhamBan.Focus();
                return false;
            }
            Common.FormatText(this);

            return true;
        }

        private void ThuChi_InsertCommand(GtidCommand sqlcmd)
        {
            string phieuchi = PhieuXuat_LaySoPhieuChi();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Chi_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdPhieu", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@SoPhieu", phieuchi).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayLap", this.mstNgayNhap.Value).Direction = ParameterDirection.Input;
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
            sqlcmd.Parameters.AddWithValue("@ChungTuGoc", txtPhieuNhap.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdThuChi", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            this.IdPhieuThu = int.Parse(sqlcmd.Parameters["@IdPhieu"].Value.ToString());

        }
        private void PhieuXuat_InsertCommand(GtidCommand sqlcmd)
        {
            if (dgvHangKhuyenMai.RowCount == 0)
            {
                this.txtKyHieuKM.Text = "";
                this.txtSoSerieKM.Text = "";
            }
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuNhapTraLaiKM_Insert";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@LoaiXuatNhap", (int)TransactionType.NHAP_TRA_LAI).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtPhieuNhap.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuatGoc", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerie", this.txtSoSerie.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieuKM", this.txtKyHieuKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerieKM", this.txtSoSerieKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayXuat", this.mstNgayNhap.Value).Direction = ParameterDirection.Input;
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

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            this.IdPhieuXuat = int.Parse(sqlcmd.Parameters["@IdPhieuXuat"].Value.ToString());

        }

        private void PhieuXuat_UpdateCommand(GtidCommand sqlcmd)
        {
            if (dgvHangKhuyenMai.RowCount == 0)
            {
                this.txtKyHieuKM.Text = "";
                this.txtSoSerieKM.Text = "";
            }
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuNhapTraLaiKM_Update";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", this.IdPhieuXuat).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@LoaiXuatNhap", (int)TransactionType.NHAP_TRA_LAI).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtPhieuNhap.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuatGoc", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerie", this.txtSoSerie.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@KyHieuKM", this.txtKyHieuKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSerieKM", this.txtSoSerieKM.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayXuat", this.mstNgayNhap.Value).Direction = ParameterDirection.Input;
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

            if (!DBTools.UpdateRecord(sqlcmd))
                throw DBTools._LastError;

        }

        private void PhieuXuat_DeleteCommand(GtidCommand sqlcmd)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd))
                throw DBTools._LastError;

            //xoa chung tu cua cac phieu xuat gop
            string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
            DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dt != null && dt.Rows.Count > 0)
            {
                //xoa cac phieu xuat bi xuat gop cung
                string lstIdPX = dt.Rows[0]["listidphieuxuat"].ToString();
                string[] arrId = lstIdPX.Split(",".ToCharArray());
                foreach (string strId in arrId)
                {
                    int idPX = Common.IntValue(strId);
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", idPX).Direction = ParameterDirection.Input;
                    if (!DBTools.DeleteRecord(sqlcmd))
                        throw DBTools._LastError;
                }
            }
        }

        private bool ValidPhieuXuatGop()
        {
            try
            {
                //kiem tra xem chung tu nay co cua phieu xuat gop khong
                string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                    "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", idPhieuXuatGoc);
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("Phiếu xuất này được xuất gộp hóa đơn, phải sử dụng chức năng nhập trả lại xuất gộp hóa đơn", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool ValidNhapTraLaiGop()
        {
            try
            {
                //kiem tra xem chung tu nay co cua phieu xuat gop khong
                string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                    "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("Hóa đơn nhập trả lại này là của hóa đơn xuất gộp, hãy Hủy hóa đơn trước rồi mới nhập lại hóa đơn", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void CapNhat_HangHoaChiTiet(GtidCommand sqlcmd, string lstIdPNL)
        {
            try
            {
                string sql = "select SoLuong, IdChiTietHangHoa from tbl_PhieuXuat_ChiTiet_HangHoa where IdChiTietPhieuXuat in " +
                            "(select IdChitiet from tbl_PhieuXuat_Chitiet where IdPhieuXuat = " + this.IdPhieuXuat + ")";
                if (lstIdPNL != "")
                    sql = "select SoLuong, IdChiTietHangHoa from tbl_PhieuXuat_ChiTiet_HangHoa where IdChiTietPhieuXuat in " +
                            "(select IdChitiet from tbl_PhieuXuat_Chitiet where IdPhieuXuat in (" + lstIdPNL + "))";

                sqlcmd.CommandText = sql;
                sqlcmd.CommandType = CommandType.Text;
                IDataReader reader = sqlcmd.ExecuteReader();
                List<string> lstSql = new List<string>();
                while (reader.Read())
                {
                    //sql = "Update tbl_HangHoa_Chitiet Set SoLuong = (case when SoLuong > " + reader.GetInt32(0) + " then SoLuong-" + reader.GetInt32(0) + "	else 0 end)";
                    sql = "Update tbl_HangHoa_Chitiet Set SoLuong = SoLuong + " + reader.GetInt32(0);
                    sql += " Where IdChiTiet = " + reader.GetInt32(1);
                    lstSql.Add(sql);
                }

                reader.Close();

                foreach (string str in lstSql)
                {
                    sqlcmd.CommandType = CommandType.Text;
                    sqlcmd.CommandText = str;
                    if (!DBTools.UpdateRecord(sqlcmd))
                        throw DBTools._LastError;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void PhieuXuat_AllDetails_DeleteCommand(GtidCommand sqlcmd)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllDetails";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd))
                throw DBTools._LastError;
            //xoa chiet khau
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllDetails_CK";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd))
                throw DBTools._LastError;
        }

        private void PhieuXuat_AllChungTu_DeleteCommand(GtidCommand sqlcmd)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllChungTu";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd))
                throw DBTools._LastError;

            //xoa chung tu cua cac phieu xuat gop
            string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
            DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dt != null && dt.Rows.Count > 0)
            {
                //xoa cac chung tu cua cac phieu
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuXuat_Huy_AllChungTu_FromID";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idChungTu = Common.IntValue(dt.Rows[i]["idchungtu"]);
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@IdChungTu", idChungTu).Direction = ParameterDirection.Input;
                    if (!DBTools.DeleteRecord(sqlcmd))
                        throw DBTools._LastError;
                }
            }


        }

        private void PhieuXuat_AllThuChi_DeleteCommand(GtidCommand sqlcmd)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllThuChi";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            if (!DBTools.DeleteRecord(sqlcmd))
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
                if (!DBTools.DeleteRecord(sqlcmd))
                    throw DBTools._LastError;
            }
        }

        private int ChungTu_InsertCommand(GtidCommand sqlcmd, List<ChiTietPhieuXuat> hoadon, List<ChiTietPhieuXuat> hoadonCK, int loaiChungTu)
        {
            int idKhoDieuChuyen = -1;
            int orderType = (loaiChungTu == (int)TransactionType.NHAP_TRA_LAI) ? Common.IntValue(this.cboOrderType.SelectedValue) : Common.IntValue(this.cboOrderTypeKM.SelectedValue);
            int idLoaiHD = (loaiChungTu == (int)TransactionType.NHAP_TRA_LAI) ? 1 : 2;
            string kyhieu = (loaiChungTu == (int)TransactionType.NHAP_TRA_LAI) ? txtKyHieu.Text : txtKyHieuKM.Text;
            string strSoSerie = (loaiChungTu == (int)TransactionType.NHAP_TRA_LAI) ? SoSerie : txtSoSerieKM.Text;

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
            string sqlstr = String.Format("select * from tbl_ChungTu where SoSeri=N'{0}' and SoChungTu='{1}' and IdPhieuXuat!={2} and IdKho={3} and LoaiChungTu in ({4},{5})", strSoSerie, kyhieu, this.IdPhieuXuat, Common.IntValue(this.cboKhoXuat.SelectedValue), (int)TransactionType.NHAP_TRA_LAI, (int)TransactionType.TRA_LAI_KHUYEN_MAI);
            //string sqlstr = "select * from tbl_ChungTu where SoSeri=N'" + strSoSerie + "' and SoChungTu=N'" + kyhieu + "' and IdPhieuXuat != " + this.IdPhieuXuat + " and IdKho = " + Common.IntValue(this.cboKhoXuat.SelectedValue) + " and LoaiChungTu in (= " + (int)TransactionType.XUAT_BAN;
            if (DBTools.ExistData(sqlstr))
            {
                throw new Exception("Số hóa đơn " + strSoSerie + " đã được sử dụng trong một phiếu nhập lại khác!\nXem lại hóa đơn nhập lại hoặc hóa đơn Nhập Khuyến mại");
            }

            //string thanhtoan = (loaiChungTu == (int)TransactionType.NHAP_TRA_LAI) ? ThanhToan[cboHinhThucTT.SelectedIndex] : "Hàng KM trả lại ko thu tiền";
            string thanhtoan = ThanhToan[cboHinhThucTT.SelectedIndex];
            if (loaiChungTu != (int)TransactionType.NHAP_TRA_LAI || hoadon[0].TyLeVAT < 0)
                thanhtoan = "Hàng KM trả lại ko thu tiền";

            double tyLeVAT = hoadon.Count > 0 ? hoadon[0].TyLeVAT : hoadonCK[0].TyLeVAT;
            double tongTienHang = 0, tongTienCK = 0, tongTienSauCK = 0, tongTienVAT = 0, tongTienThanhToan = 0, tienThucTra = 0, tienNo = 0;
            foreach (ChiTietPhieuXuat px in hoadon)
            {
                tongTienHang += px.SoLuong * px.DonGia;
                tongTienCK += px.TienChietKhau;
                tongTienVAT += px.TienVAT;
            }
            foreach (ChiTietPhieuXuat px in hoadonCK)
            {
                tongTienHang += Common.Round(px.TienChietKhau);
                tongTienVAT += Common.Round(px.TienVAT);
            }
            tongTienSauCK = tongTienHang - tongTienCK;
            tongTienThanhToan = tongTienSauCK + tongTienVAT;
            tienThucTra = tongTienThanhToan;

            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_Insert";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdChungTu", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtPhieuNhap.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@LoaiChungTu", loaiChungTu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@QuyenSo", -1).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoSeri", strSoSerie).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoChungTu", kyhieu).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayLap", this.mstNgayNhap.Value).Direction = ParameterDirection.Input;
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
            sqlcmd.Parameters.AddWithValue("@BillTo", this.cboBillTo.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ShipTo", this.cboShipTo.SelectedValue).Direction = ParameterDirection.Input;
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
            sqlcmd.Parameters.AddWithValue("@SoChungTuTraLai", txtPhieuNhap.Text).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            int IdChungTu = int.Parse(sqlcmd.Parameters["@IdChungTu"].Value.ToString());
            //luu lai Id chung tu
            //HoaDon chungtu = new HoaDon(IdChungTu,(int)this.cboQuyen.SelectedValue, this.txtKyHieu.Text.Trim(), this.txtSoSerie.Text.Trim(), Common.ParseDate(this.mstNgayXuat.Text), "", "", "", "", this.cboNhanVien.SelectedText,
            //                     this.txtHoTenKhachHang.Text,(int)this.cboGioiTinh.SelectedIndex,Common.IntValue(this.txtTuoi.Text.Trim()), this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text, orderType, (int)this.cboBillTo.SelectedValue, (int)this.cboShipTo.SelectedValue,
            //                      tongTienHang, tongTienCK, tyLeVAT, tongTienVAT, tongTienThanhToan, Declare.KyHieuTienTe, ThanhToan[cboHinhThucTT.SelectedIndex], (int)this.cboLoaiTra.SelectedValue, this.txtGhiChu.Text);
            //listChungTu.Add(chungtu);
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
        private int ChiTietCK_InsertCommand(GtidCommand sqlcmd, int IdSP,
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

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());
        }
        private int ChiTietPX_InsertCommand(GtidCommand sqlcmd, int IdSP, int IdSPBan,
                                            int sLuong, double dongia, double tyleCK, double tienCK, double tyleVAT, double tienVAT, double tyleThuong, double thuongNong, double giaBangGia)
        {
            double tiensauCK = (sLuong * dongia - tienCK);
            double thanhtien = tiensauCK + tienVAT;
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

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

        }

        private void ChiTietPX_UpdateCommand(GtidCommand sqlcmd, GtidConnection sqlCon, GtidTransaction sqlTran, int idChithiet, int IdSP, int IdSPBan,
                                            int sLuong, double dongia, double tyleCK, double tienCK, double tyleVAT, double tienVAT, double tyleThuong, double thuongNong, double giaBangGia)
        {
            double tiensauCK = (sLuong * dongia - tienCK);
            double thanhtien = tiensauCK + tienVAT;
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
        private int ChietKhau_ChungTu_InsertCommand(GtidCommand sqlcmd, int IdChungTu, int IdSP,
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

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

        }
        private int ChiTiet_ChungTu_InsertCommand(GtidCommand sqlcmd, int IdChungTu, int IdSP,
                                            int sLuong, double dongia, double tyleCK, double tienCK)
        {
            double thanhtien = (sLuong * dongia - tienCK);
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

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

            return Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

        }


        private void ChiTietPX_HangHoa_InsertCommand(GtidCommand sqlcmd, int IdChitiet, int IdHanghoa, int Soluong, double TienCK, double TienVAT, double thuong, string ghichu)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChiTiet_Hanghoa_NhapTraLai_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitietPhieuXuat", IdChitiet).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdChitietHangHoa", IdHanghoa).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", Soluong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", TienCK).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienVAT", TienVAT).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThuongNong", thuong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", ghichu).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;

        }


        private void ChiTiet_ChungTu_HangHoa_InsertCommand(GtidCommand sqlcmd, int IdChitiet, int IdHanghoa, int Soluong, double TienCK)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_ChungTu_ChiTiet_Hanghoa_Insert";
            sqlcmd.Parameters.Clear();

            sqlcmd.Parameters.AddWithValue("@IdChitietChungTu", IdChitiet).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdChitietHangHoa", IdHanghoa).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoLuong", Soluong).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TienChietKhau", TienCK).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd))
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
                this.dtKhachHang = DBTools.getData("tbl_DM_DoiTuong", str).Tables["tbl_DM_DoiTuong"];
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

        private void LoadLoaiThuChi()
        {
            try
            {
                string str = "Select IdThuChi, KyHieu + ' - ' + Ten ThuChi From tbl_DM_LoaiThuChi " +
                      " Where SuDung=1 and Type=0 ";

                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    this.cboLoaiTra.DataSource = dt;
                    this.cboLoaiTra.DisplayMember = "ThuChi";
                    this.cboLoaiTra.ValueMember = "IdThuChi";

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
                //      " Where SuDung=1 and (Code like '%.3.1.%.%.%.%" + Declare.MAVUNG + "'" +
                //      " or Code like '%.4.1.%.%.%.%" + Declare.MAVUNG + "' or Code like '%.3.99.%.%.%.%" + Declare.MAVUNG + "'" +
                //      " or Code like '%.4.99.%.%.%.%" + Declare.MAVUNG + "')";//nhap hang + hang khuyen mai
                string str = "Select * From tbl_DM_OrderType Where Code like '%.TL.%'";//xuat.hang hoa

                this.dtOrderType = DBTools.getData("tmp", str).Tables["tmp"];
                if (this.dtOrderType != null)
                {
                    this.cboOrderType.DataSource = this.dtOrderType;
                    this.cboOrderType.DisplayMember = "Name";
                    this.cboOrderType.ValueMember = "IdOrderType";

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
                //      " Where SuDung=1 and (Code like '%.3.99.%.%.%.%" + Declare.MAVUNG + "'" +
                //      " or Code like '%.4.99.%.%.%.%" + Declare.MAVUNG + "')";//nhap hang khuyen mai
                str = "Select * From tbl_DM_OrderType Where Code like '%KM.%'";//xuat.hang hoa

                this.dtOrderTypeKM = DBTools.getData("tmp", str).Tables["tmp"];
                if (this.dtOrderTypeKM != null)
                {
                    this.cboOrderTypeKM.DataSource = this.dtOrderTypeKM;
                    this.cboOrderTypeKM.DisplayMember = "Name";
                    this.cboOrderTypeKM.ValueMember = "IdOrderType";

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
                            " Where hh.IdKho = " + Declare.IdKho + " and hh.SoLuong >= 0 order by hh.MaVach ASC";

                //string str;
                //str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
                //      " Where hh.IdKho in (Select DISTINCT kh.IdKho From tbl_DM_Kho kh " +
                //      " inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                //      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv.IdNhanVien " +
                //      " where kh.SuDung=1 and nd.IdNguoiDung = " + Declare.UserId + ") and hh.SoLuong >= 0 order by hh.MaVach ASC";
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
                string str = "Select DISTINCT kh.IdKho, kh.MaKho, kh.TenKho From tbl_DM_Kho kh " +
                      " Inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv.IdNhanVien " +
                      " Where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + " order by kh.TenKho ASC";

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
                string str = "Select DISTINCT nv.IdNhanVien, nv.MaNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                      " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien " +
                      " Where knv.IdKho in ( Select knv1.idKho From tbl_Kho_NhanVien knv1 " +
                      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv1.IdNhanVien " +
                      " Where nd.IdNguoiDung = " + Declare.UserId + ") and (nv.SuDung = 1)  order by nv.HoTen ASC";

                this.dtNhanVien = DBTools.getData("tbl_DM_NhanVien", str).Tables["tbl_DM_NhanVien"];
                if (this.dtNhanVien != null)
                {
                    //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                    this.cboNhanVien.DataSource = this.dtNhanVien;
                    this.cboNhanVien.DisplayMember = "HoTen";
                    this.cboNhanVien.ValueMember = "IdNhanVien";
                    //this.cboNhanVien.SelectedIndex = -1;
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

                this.dtDiaChi = DBTools.getData("tmp", str).Tables["tmp"];
                if (this.dtDiaChi != null)
                {
                    this.cboBillTo.DataSource = this.dtDiaChi;
                    this.cboBillTo.DisplayMember = "DiaChi";
                    this.cboBillTo.ValueMember = "IdDiaChi";

                    this.cboShipTo.DataSource = this.dtDiaChi;
                    this.cboShipTo.DisplayMember = "DiaChi";
                    this.cboShipTo.ValueMember = "IdDiaChi";

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

                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    DataRow r = dt.NewRow();
                    r[0] = 0;
                    r[1] = "";
                    dt.Rows.InsertAt(r, 0);
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

                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt != null)
                {
                    DataRow r = dt.NewRow();
                    r[0] = 0;
                    r[1] = "";
                    dt.Rows.InsertAt(r, 0);
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
                string str = "Select IdDuAn, MaDuAn + ' - ' + TenDuAn DuAn From tbl_DM_DuAn Where SuDung=1 ";

                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
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
            LoadKhachHang();
            LoadKhoXuat();
            LoadNhanVien();
            //LoadTienTe();
            LoadMaVach();
            //LoadHinhThucTra();
            //LoadQuyen();
            LoadLoaiThuChi();
            LoadOrderType();
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
                string str = "Select * From tbl_DM_HinhThucThanhToan";
                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
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
            this.txtSoPhieu.Text = row["SoPhieuXuat"].ToString();
            this.mstNgayXuat.Value = (DateTime)row["NgayXuat"];
            //this.cboQuyen.SelectedValue = Common.IntValue(row["QuyenSo"].ToString());
            this.txtKyHieu.Text = row["KyHieu"].ToString();
            this.txtSoSerie.Text = row["SoSerie"].ToString();
            this.txtKyHieuKM.Text = row["KyHieuKM"].ToString();
            this.txtSoSerieKM.Text = row["SoSerieKM"].ToString();
            this.cboKhoXuat.SelectedValue = Common.IntValue(row["IdKho"].ToString());
            this.cboNhanVien.SelectedValue = Common.IntValue(row["IdNhanVien"].ToString());
            this.cboKhachHang.SelectedValue = Common.IntValue(row["IdKhachHang"].ToString());
            this.txtHoTenKhachHang.Text = row["HoTen"].ToString();
            this.cboGioiTinh.SelectedIndex = Common.IntValue(row["GioiTinh"].ToString());
            this.txtTuoi.Text = row["DoTuoi"].ToString();
            this.txtDiaChi.Text = row["DiaChi"].ToString();
            this.txtDienThoai.Text = row["DienThoai"].ToString();
            this.txtMaSoThue.Text = row["MaSoThue"].ToString();
            this.SoTaiKhoan = row["SoTaiKhoan"].ToString();
            this.NganHang = row["NganHang"].ToString();
            this.cboOrderType.SelectedValue = Common.IntValue(row["OrderType"].ToString());
            this.cboOrderTypeKM.SelectedValue = Common.IntValue(row["OrderTypeKM"].ToString());
            this.cboBillTo.SelectedValue = Common.IntValue(row["BillTo"].ToString());
            this.cboShipTo.SelectedValue = Common.IntValue(row["ShipTo"].ToString());
            //this.cboLoaiTien.SelectedValue = Common.IntValue(row["IdTienTe"].ToString());
            //this.txtTyGia.Text = row["TyGia"].ToString();
            this.txtTongTienHang.Text = Common.Double2Str(-(double)row["TongTienHang"]);
            this.txtTongTienCK.Text = Common.Double2Str(-(double)row["TongTienChietKhau"]);
            this.txtTongTienSauCK.Text = Common.Double2Str(-(double)row["TongTienSauChietKhau"]);
            this.txtTongTienVAT.Text = Common.Double2Str(-(double)row["TongTienVAT"]);
            this.txtTongTienThanhToan.Text = Common.Double2Str(-(double)row["TongTienThanhToan"]);
            //this.txtTienThucTra.Text = Common.Double2Str(-(double)row["TienThanhToanThuc"]);
            this.txtTienConNo.Text = Common.Double2Str(-(double)row["TienConNo"]);
            this.cboHinhThucTT.SelectedIndex = 0;
            for (int i = 0; i < ThanhToan.Length; i++)
                if (row["HinhThucThanhToan"].ToString().Equals(ThanhToan[i]))
                {
                    this.cboHinhThucTT.SelectedIndex = i;
                    break;
                }
            //this.cboHinhThucTT.SelectedIndex = row["HinhThucThanhToan"].ToString().Equals(ThanhToan[0]) ? 0 : 1;
            this.cboLoaiTra.SelectedValue = Common.IntValue(row["HinhThucTra"].ToString());
            //this.cboThu.SelectedValue = Common.IntValue(row["LoaiThu"].ToString()); 
            this.cboBangKeThue.SelectedValue = Common.IntValue(row["IdBangKeThue"].ToString());
            this.cboLoaiHoaDon.SelectedValue = Common.IntValue(row["IdLoaiHDBanHang"].ToString());
            this.cboMaDuAn.SelectedValue = Common.IntValue(row["IdDuAn"].ToString());

            this.txtGhiChu.Text = row["GhiChu"].ToString();
        }

        private void PhieuXuat_NhapTraLai_HienThi(DataRow row)
        {
            this.txtPhieuNhap.Text = row["SoPhieuXuat"].ToString();
            this.txtSoPhieu.Text = row["SoPhieuXuatGoc"].ToString();
            this.mstNgayNhap.Value = (DateTime)row["NgayXuat"];
            //this.cboQuyen.SelectedValue = Common.IntValue(row["QuyenSo"].ToString());
            this.txtKyHieu.Text = row["KyHieu"].ToString();
            this.txtSoSerie.Text = row["SoSerie"].ToString();
            this.txtKyHieuKM.Text = row["KyHieuKM"].ToString();
            this.txtSoSerieKM.Text = row["SoSerieKM"].ToString();
            this.cboKhoXuat.SelectedValue = Common.IntValue(row["IdKho"].ToString());
            this.cboNhanVien.SelectedValue = Common.IntValue(row["IdNhanVien"].ToString());
            this.cboKhachHang.SelectedValue = Common.IntValue(row["IdKhachHang"].ToString());
            this.txtHoTenKhachHang.Text = row["HoTen"].ToString();
            this.cboGioiTinh.SelectedIndex = Common.IntValue(row["GioiTinh"].ToString());
            this.txtTuoi.Text = row["DoTuoi"].ToString();
            this.txtDiaChi.Text = row["DiaChi"].ToString();
            this.txtDienThoai.Text = row["DienThoai"].ToString();
            this.txtMaSoThue.Text = row["MaSoThue"].ToString();
            this.SoTaiKhoan = row["SoTaiKhoan"].ToString();
            this.NganHang = row["NganHang"].ToString();
            this.cboOrderType.SelectedValue = Common.IntValue(row["OrderType"].ToString());
            this.cboOrderTypeKM.SelectedValue = Common.IntValue(row["OrderTypeKM"].ToString());
            this.cboBillTo.SelectedValue = Common.IntValue(row["BillTo"].ToString());
            this.cboShipTo.SelectedValue = Common.IntValue(row["ShipTo"].ToString());
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
            for (int i = 0; i < ThanhToan.Length; i++)
                if (row["HinhThucThanhToan"].ToString().Equals(ThanhToan[i]))
                {
                    this.cboHinhThucTT.SelectedIndex = i;
                    break;
                }
            //this.cboHinhThucTT.SelectedIndex = row["HinhThucThanhToan"].ToString().Equals(ThanhToan[0]) ? 0 : 1;
            this.cboLoaiTra.SelectedValue = Common.IntValue(row["HinhThucTra"].ToString());
            //this.cboThu.SelectedValue = Common.IntValue(row["LoaiThu"].ToString()); 
            this.cboBangKeThue.SelectedValue = Common.IntValue(row["IdBangKeThue"].ToString());
            this.cboLoaiHoaDon.SelectedValue = Common.IntValue(row["IdLoaiHDBanHang"].ToString());
            this.cboMaDuAn.SelectedValue = Common.IntValue(row["IdDuAn"].ToString());

            this.txtGhiChu.Text = row["GhiChu"].ToString();
        }

        private void LoadAllPhieuXuat()
        {
            string str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.SoPhieuXuatGoc,px.NgayXuat,px.KyHieu,px.SoSerie,px.IdKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi,";
            str += " px.DienThoai,px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT,";
            str += " px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.KyHieuKM,px.SoSerieKM ";
            str += " from tbl_PhieuXuat px ";
            //str += string.Format(" where px.NgayXuat >= convert(datetime,'{0}',121) and px.NgayXuat >=  convert(datetime,'{1}',121)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2LongString(Declare.NgayLamViec));
            str += string.Format(" where (px.ThoigianSua >=  convert(datetime,'{0}',103) or px.NhapHoaDon is null or px.NhapHoaDon=0)", Common.Date2String(Declare.NgayLamViec));
            //str += string.Format(" where px.ThoigianSua > convert(datetime,'{0}',121) and px.ThoigianSua >=  convert(datetime,'{1}',103)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2String(Declare.NgayLamViec));
            str += " and px.LoaiXuatNhap = " + (int)TransactionType.NHAP_TRA_LAI;
            str += " and px.IdKho = " + Declare.IdKho;
            //str += " and px.NguoiSua = '" + Declare.UserName + "'";
            str += " order by px.NhapHoaDon, px.ThoigianSua desc ";
            dtPhieuXuat = DBTools.getData("Tmp", str).Tables["Tmp"];
            showInfors();
        }

        private void LoadHeaderPhieuXuatFromMavach()
        {
            string str;
            DataTable dt;
            str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.KyHieu,px.SoSerie,px.IdKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi," +
                         "px.DienThoai, px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                         "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.KyHieuKM,px.SoSerieKM " +
                  "from tbl_PhieuXuat px " +
                  "where IdPhieuXuat="+idPhieuXuatGoc;
            dt = DBTools.getData("Tmp", str).Tables["Tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                //this.idPhieuXuatGoc = Common.IntValue(dt.Rows[0]["IdPhieuXuat"]);
                this.txtSoPhieu.Text = dt.Rows[0]["SoPhieuXuat"].ToString();
                this.mstNgayXuat.Value = (DateTime)dt.Rows[0]["NgayXuat"];
                this.txtKyHieu.Text = dt.Rows[0]["KyHieu"].ToString();
                this.txtSoSerie.Text = dt.Rows[0]["SoSerie"].ToString();
                this.txtKyHieuKM.Text = dt.Rows[0]["KyHieuKM"].ToString();
                this.txtSoSerieKM.Text = dt.Rows[0]["SoSerieKM"].ToString();
                this.cboKhoXuat.SelectedValue = Common.IntValue(dt.Rows[0]["IdKho"].ToString());
                this.cboNhanVien.SelectedValue = Common.IntValue(dt.Rows[0]["IdNhanVien"].ToString());
                this.cboKhachHang.SelectedValue = Common.IntValue(dt.Rows[0]["IdKhachHang"].ToString());
                this.txtHoTenKhachHang.Text = dt.Rows[0]["HoTen"].ToString();
                this.cboGioiTinh.SelectedIndex = Common.IntValue(dt.Rows[0]["GioiTinh"].ToString());
                this.txtTuoi.Text = dt.Rows[0]["DoTuoi"].ToString();
                this.txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                this.txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                this.txtMaSoThue.Text = dt.Rows[0]["MaSoThue"].ToString();
                this.SoTaiKhoan = dt.Rows[0]["SoTaiKhoan"].ToString();
                this.NganHang = dt.Rows[0]["NganHang"].ToString();
                this.cboOrderType.SelectedValue = Common.IntValue(dt.Rows[0]["OrderType"].ToString());
                this.cboOrderTypeKM.SelectedValue = Common.IntValue(dt.Rows[0]["OrderTypeKM"].ToString());
                this.cboBillTo.SelectedValue = Common.IntValue(dt.Rows[0]["BillTo"].ToString());
                this.cboShipTo.SelectedValue = Common.IntValue(dt.Rows[0]["ShipTo"].ToString());
                this.cboBangKeThue.SelectedValue = Common.IntValue(dt.Rows[0]["IdBangKeThue"].ToString());
                this.cboLoaiHoaDon.SelectedValue = Common.IntValue(dt.Rows[0]["IdLoaiHDBanHang"].ToString());
                this.cboMaDuAn.SelectedValue = Common.IntValue(dt.Rows[0]["IdDuAn"].ToString());
                this.txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            }
        }
        private void LoadPhieuXuat(int IdPX)
        {
            string str;
            DataTable dt;

            str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.SoPhieuXuatGoc,px.NgayXuat,px.KyHieu,px.SoSerie,px.IdKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi," +
                         "px.DienThoai, px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                         "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.KyHieuKM,px.SoSerieKM " +
                  "from tbl_PhieuXuat px " +
                  "where IdPhieuXuat=" + IdPX + "";

            dt = DBTools.getData("Tmp", str).Tables["Tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                this.PhieuXuat_NhapTraLai_HienThi(dt.Rows[0]);

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
                            Common.Double2Str((double)dt.Rows[i]["DonGia"]),
                            Common.Double2Str((double)dt.Rows[i]["TyLeChietKhau"] * TyLe),
                            Common.Double2Str((double)dt.Rows[i]["TienChietKhau"]),
                            Common.Double2Str(tienSauCK),  
                            Common.Double2Str((double)dt.Rows[i]["TyLeVAT"]<0?(double)dt.Rows[i]["TyLeVAT"]:(double)dt.Rows[i]["TyLeVAT"] * TyLe),                          
                            //Common.Double2Str((double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str((double)dt.Rows[i]["TienVAT"]),
                            Common.Double2Str((double)dt.Rows[i]["ThanhTien"]),
                            Common.Double2Str((double)dt.Rows[i]["TienChietKhau"]),
                            dt.Rows[i]["GhiChu"],
                            Common.Double2Str(tienSauCK),
                            Common.Double2Str((double)dt.Rows[i]["TienVAT"]),
                            Common.Double2Str((double)dt.Rows[i]["ThanhTien"]),
                            dt.Rows[i]["TyLeThuong"],
                            Common.Double2Str((double)dt.Rows[i]["ThuongNong"]),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["GiaTheoBangGia"]))

                        };
                    this.dgvSanPhamBan.Rows.Add(arr);
                    DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];

                    newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + dt.Rows[0]["IdSanPham"].ToString()));
                    newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");//sửa giá bán
                    newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                }

                str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "IdSanPhamBan,MaSanPhamBan,TenSanPhamBan,SoLuong,ThanhTien " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + IdPX + " and IdSanPhamBan is not null ";
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
                            Common.Double2Str((double)dt.Rows[i]["ThanhTien"])};
                    this.dgvHangKhuyenMai.Rows.Add(arr);
                }
                ChuaDayOracle = Common.IsEnableCommandPX(IdPX);
            }
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
            this.Text = "Cập nhật phiếu nhập hàng trả lại.";
            if (dtPhieuXuat != null)
            {
                this.Text += " - Tổng số phiếu [" + dtPhieuXuat.Rows.Count + "]";
                if (dtPhieuXuat.Rows.Count > 0)
                    this.Text += " - Phiếu số [" + (this.IndexPX + 1) + "]";
            }
        }
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
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
                    this.cboKhachHang.SelectedValue = 0;
                    this.cboBillTo.SelectedValue = 0;
                    this.cboShipTo.SelectedValue = 0;
                    this.txtMaKhachHang.Text = "";
                    this.txtBillTo.Text = "";
                    this.txtShipTo.Text = "";
                }
                //Thiet lap trang thai item
                setEDItems(false);
                setEDFunctions();               
                setEDUpdate();                
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

        private bool ValidChiTietPhieuXuat()
        {
            try
            {
                //Kiem tra danh sach san pham ban
                string str = "SELECT MaVach,MaSanPham,IdSanPham,TenSanPham,SoLuong " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + idPhieuXuatGoc + " and IdSanPhamBan is null " +
                      "Union all " +
                      "SELECT MaVach,MaSanPham,IdSanPham,TenSanPham,SoLuong " +
                      "FROM vChietKhauPhieuXuat " +
                      "WHERE IdPhieuXuat=" + idPhieuXuatGoc;

                DataTable dt = DBTools.getData("Tmp", str).Tables["Tmp"];
                int count = 0;
                bool found = false;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        found = false;
                        foreach (DataGridViewRow dgr in dgvSanPhamBan.Rows)
                        {
                            string mavach = dgr.Cells["MaVach"].Value.ToString();
                            int soluong = Common.IntValue(dgr.Cells["SoLuong"].Value.ToString());
                            if (mavach == dt.Rows[i]["MaVach"].ToString() && soluong == -Common.IntValue(dt.Rows[i]["SoLuong"]))
                            {
                                count++;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            string sanpham = dt.Rows[i]["TenSanPham"].ToString();
                            MessageBox.Show("Sản phẩm khuyến mại '" + sanpham + "' chưa nhập đủ hoặc nhập mã vạch không đúng.\nSố lượng sản phẩm này có trong phiếu xuất là " + Common.IntValue(dt.Rows[i]["SoLuong"]) + ".\nHãy nhập lại đầy đủ để tiếp tục");
                            dgvSanPhamBan.Focus();
                            return false;
                        }
                    }
                }
                if (dgvSanPhamBan.Rows.Count != count)
                {

                    MessageBox.Show("Số lượng sản phẩm bán và nhập lại không khớp\n. Hãy nhập lại đầy đủ để tiếp tục");
                    return false;
                }

                //Kiem tra danh sach san pham khuyen mai
                str = "SELECT MaVach,MaSanPham,IdSanPham,TenSanPham,SoLuong " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + idPhieuXuatGoc + " and IdSanPhamBan is not null";

                dt = DBTools.getData("Tmp", str).Tables["Tmp"];
                count = 0;
                found = false;
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        found = false;
                        foreach (DataGridViewRow dgr in dgvHangKhuyenMai.Rows)
                        {
                            string mavach = dgr.Cells["MaVachKM"].Value.ToString();
                            int soluong = Common.IntValue(dgr.Cells["SoLuongKM"].Value.ToString());
                            if (mavach == dt.Rows[i]["MaVach"].ToString() && soluong == -Common.IntValue(dt.Rows[i]["SoLuong"]))
                            {
                                count++;
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            string sanpham = dt.Rows[i]["TenSanPham"].ToString();
                            MessageBox.Show("Sản phẩm khuyến mại '" + sanpham + "' chưa nhập đủ hoặc nhập mã vạch không đúng.\nSố lượng sản phẩm này có trong phiếu xuất là " + Common.IntValue(dt.Rows[i]["SoLuong"]) + ".\nHãy nhập lại đầy đủ để tiếp tục");
                            //MessageBox.Show("Sản phẩm '" + sanpham + "' chưa nhập lại hoặc số lượng nhập lại không khớp.\n Trong phiếu xuất chỉ có " + Common.IntValue(dt.Rows[i]["SoLuong"]) + " sản phẩm.\n Hãy nhập lại đầy đủ để tiếp tục");
                            dgvSanPhamBan.Focus();
                            return false;
                        }
                    }
                }

                if (dgvHangKhuyenMai.Rows.Count != count)
                {
                    MessageBox.Show("Số lượng sản phẩm khuyến mại và nhập lại không khớp\n. Hãy nhập lại đầy đủ để tiếp tục");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông tin phiếu xuất và nhập lại không khớp nhau\n. Hãy xem lại thông tin");

                return false;
            }

            return true;

        }

        private List<ChiTietPhieuXuat> GetChiTietPhieuXuat(GtidCommand sqlcmd, ref List<ChiTietPhieuXuat> lstChietKhau)
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
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlcmd.Connection));
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
                    detailPX.DonGia = GiaBan;// Common.DoubleValue(dgr.Cells["DonGia"].Value);
                    detailPX.TyLeChietKhau = Common.DoubleValue(dgr.Cells["TyLeChietKhau"].Value) / TyLe;
                    detailPX.TienChietKhau = Common.DoubleValueInt(dgr.Cells["TienChietKhau"].Value);
                    //detailPX.TyLeVAT = Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) / TyLe;
                    detailPX.TyLeVAT = Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) < 0 ? Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) : Common.DoubleValue(dgr.Cells["TyLeVAT"].Value) / TyLe;
                    detailPX.TienVAT = Common.DoubleValueInt(dgr.Cells["TienVAT"].Value);
                    detailPX.TyLeThuong = Common.DoubleValue(dgr.Cells["TyLeThuong"].Value);
                    detailPX.ThuongNong = Common.DoubleValueInt(dgr.Cells["ThuongNong"].Value);
                    detailPX.GiaTheoBangGia = Common.DoubleValueInt(dgr.Cells["GiaTheoBangGia"].Value);
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVach"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlcmd.Connection));
                    string ghichu = dgr.Cells["GhiChu"].Value.ToString();
                    ChiTietHangHoa hanghoa = new ChiTietHangHoa(IdHangHoa, detailPX.SoLuong, detailPX.TienChietKhau, detailPX.TienVAT, detailPX.ThuongNong, ghichu);
                    detailPX.DsHangHoa.Add(hanghoa);
                }
            }
            if (detailPX != null)
                listPX.Add(detailPX);

            return listPX;

        }

        private List<ChiTietPhieuXuat> GetChiTietKhuyenMai(GtidCommand sqlcmd)
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
                    double ck = 0;// -Common.DoubleValue(dgr.Cells["SoTienKM"].Value);
                    double vat = 0;
                    detailPX.SoLuong += sl;
                    detailPX.TienChietKhau += ck;
                    detailPX.TienVAT += vat;
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVachKM"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlcmd.Connection));
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
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVachKM"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlcmd.Connection));
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
                else if (e.KeyCode == Keys.F9 && tsbPrinter_Click.Enabled)
                    this.tsbPrinter_Click_Click(sender, e);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex) { }
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
                if (txtHoTenKhachHang.Text.Trim().Equals(""))
                    txtHoTenKhachHang.Text = this.dtKhachHang.Rows[index]["TenDoiTuong"].ToString();
                if (txtDiaChi.Text.Trim().Equals(""))
                    txtDiaChi.Text = this.dtKhachHang.Rows[index]["DiaChi"].ToString();
                if (txtDienThoai.Text.Trim().Equals(""))
                    txtDienThoai.Text = this.dtKhachHang.Rows[index]["DienThoai"].ToString();
                if (txtMaSoThue.Text.Trim().Equals(""))
                    txtMaSoThue.Text = this.dtKhachHang.Rows[index]["MaSoThue"].ToString();

                txtMaKhachHang.Text = this.dtKhachHang.Rows[index]["MaDoiTuong"].ToString();
                try
                {
                    if (this.dtKhachHang.Rows[index]["IdOrderType"] != null)
                        this.cboOrderType.SelectedValue = int.Parse(this.dtKhachHang.Rows[index]["IdOrderType"].ToString());
                }
                catch { }
                LoadDiaChiKH();
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
                    MessageBox.Show("Mã vạch này không tồn tại ở trong kho.\n Bạn không thể nhập sản phẩm này được");
                    return;
                }
                //Kiem tra trang thai san pham trong vChiTietPhieuXuat de xem hang hoa co hop le khong
                //string str = String.Format("Select IdSanPham From tbl_HangHoa_ChiTiet Where MaVach = '{0}' and IdKho = {1} and SoLuong >= 0 ",
                //                            code, cboKhoXuat.SelectedValue);
                string str = "SELECT IdPhieuXuat,SoPhieuXuat " +
                             " FROM vChiTietPhieuXuat " +
                             " WHERE MaVach = N'" + code + "' and LoaiXuatNhap = " + (int)TransactionType.XUAT_BAN;
                if (hasPX) str += " and IdPhieuXuat = " + idPhieuXuatGoc;
                dt = DBTools.getData("tmp", str).Tables["tmp"];
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Mã vạch cho sản phẩm này không phải mua từ cửa hàng này hoặc ở phiếu xuất khác.\n Bạn không thể nhập lại cho phiếu xuất này được");
                    return;
                }
                else
                {
                    //Nap phieu xuat tu ma vach
                    if (!hasPX)
                    {
                        if (dt.Rows.Count > 1)
                        {
                            frmPhieuNhapTraLai_ChonPhieuXuat frm = new frmPhieuNhapTraLai_ChonPhieuXuat(dt);
                            if (frm.ShowDialog() == DialogResult.OK)
                                idPhieuXuatGoc = frm.IdPhieuXuatChon;
                            else
                                idPhieuXuatGoc = Common.IntValue(dt.Rows[0]["IdPhieuXuat"]);
                        }
                        else
                            idPhieuXuatGoc = Common.IntValue(dt.Rows[0]["IdPhieuXuat"]);

                        //Kiem tra xem phieu xuat nay da nhap tra lai chua
                        str = "SELECT IdPhieuXuat FROM tbl_PhieuXuat WHERE SoPhieuXuatGoc = (Select SoPhieuXuat From tbl_PhieuXuat Where IdPhieuXuat = " + idPhieuXuatGoc + ")";
                        if (DBTools.ExistData(str))
                        {
                            MessageBox.Show("Phiếu xuất này đã được nhập trả lại. \nBạn không thể nhập lại lần nữa cho phiếu xuất này được");
                            return;
                        }

                        LoadHeaderPhieuXuatFromMavach();
                        hasPX = true;
                    }

                    str = "SELECT IdPhieuXuat,SoPhieuXuat,MaVach,IdSanPham,MaSanPham,TenSanPham,IdSanPhamBan,MaSanPhamBan,TenSanPhamBan,IdDonViTinh,TenDonViTinh," +
                                    "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                                 " FROM vChiTietPhieuXuat " +
                                 " WHERE MaVach = N'" + code + "' and LoaiXuatNhap = " + (int)TransactionType.XUAT_BAN +
                                 " and IdPhieuXuat = " + idPhieuXuatGoc;
                    dt = DBTools.getData("tmp", str).Tables["tmp"];

                    //Neu la san pham ban => them vao danh sach hang ban
                    if (rptHangBan.Checked)
                    {
                        if (Common.IntValue(dt.Rows[0]["IdSanPhamBan"]) > 0)
                        {
                            MessageBox.Show("Sản phẩm này là hàng khuyến mại, không thể thêm vào danh sách sản phẩm bán.\n Hãy chọn lựa chọn nhập Khuyến Mại");
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
                                    row.Cells["SoLuong"].Value = Common.IntValue(row.Cells["SoLuong"].Value.ToString()) - 1;
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
                            double tienck = Common.DoubleValue(dt.Rows[0]["DonGia"].ToString()) * (double)dt.Rows[0]["TyLeChietKhau"];
                            double tienSauCK = Common.DoubleValue(dt.Rows[0]["DonGia"].ToString()) - tienck;
                            double tienvat = tienSauCK * (double)dt.Rows[0]["TyLeVAT"];
                            double thanhtien = tienSauCK + tienvat;
                            object[] arr ={ 
                            dt.Rows[0]["MaVach"],
                            dt.Rows[0]["IdSanPham"],
                            dt.Rows[0]["MaSanPham"],
                            dt.Rows[0]["TenSanPham"],
                            dt.Rows[0]["TenDonViTinh"],
                            -1,
                            Common.Double2Str((double)dt.Rows[0]["DonGia"]),
                            Common.Double2Str((double)dt.Rows[0]["TyLeChietKhau"] * TyLe),
                            Common.Double2Str(-tienck),
                            Common.Double2Str(-tienSauCK),                            
                            Common.Double2Str((double)dt.Rows[0]["TyLeVAT"]<0?(double)dt.Rows[0]["TyLeVAT"]:(double)dt.Rows[0]["TyLeVAT"] * TyLe),
                            Common.Double2Str(-tienvat),
                            Common.Double2Str(-thanhtien),
                            "",
                            Common.Double2Str(-tienck),
                            Common.Double2Str(-tienSauCK),
                            Common.Double2Str(-tienvat),
                            Common.Double2Str(-thanhtien),
                            dt.Rows[0]["TyLeThuong"],
                            Common.Double2Str(-(double)dt.Rows[0]["ThuongNong"]),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[0]["GiaTheoBangGia"]))
                            };
                            this.dgvSanPhamBan.Rows.Add(arr);

                            DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                            newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + dt.Rows[0]["IdSanPham"].ToString()));
                            newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");//sửa giá bán
                            newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                            newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                        }
                    }
                    //Neu la hang khuyen mai => them vao hang khuyen mai
                    else if (rptKhuyenMai.Checked)
                    {
                        if (Common.IntValue(dt.Rows[0]["IdSanPhamBan"]) == 0)
                        {
                            MessageBox.Show("Sản phẩm này là sản phẩm bán, không thể thêm vào danh sách sản phẩm khuyến mại.\n Hãy chọn lựa chọn nhập Khuyến Mại");
                            return;
                        }
                        //Kiem tra san pham da nhap chua, neu nhap roi thi tang so luong
                        bool foundSP = false;
                        foreach (DataGridViewRow row in dgvHangKhuyenMai.Rows)
                        {
                            if (row.Cells["MaVachKM"].Value.ToString().Equals(code) && Common.IntValue(dt.Rows[0]["IdSanPhamBan"]) == Common.IntValue(row.Cells["IdSanPhamBan"].Value))
                            {
                                idSPBan = Common.IntValue(dt.Rows[0]["IdSanPham"]);
                                str = String.Format("Select case when TrungMaVach is null then 0 else TrungMaVach end TrungMaVach From tbl_SanPham Where IdSanPham = {0}", idSPBan);
                                if (DBTools.getValue(str).Equals("1"))
                                {
                                    row.Cells["SoLuongKM"].Value = Common.IntValue(row.Cells["SoLuongKM"].Value.ToString()) - 1;
                                    row.Cells["SoTienKM"].Value = Common.Double2Str(Common.DoubleValue(row.Cells["SoTienKM"].Value.ToString()) - Common.DoubleValue(dt.Rows[0]["ThanhTien"]) / Common.IntValue(dt.Rows[0]["SoLuong"]));
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
                            object[] arr ={dt.Rows[0]["MaVach"], dt.Rows[0]["IdSanPham"], dt.Rows[0]["MaSanPham"], dt.Rows[0]["TenSanPham"],
                            dt.Rows[0]["IdSanPhamBan"], dt.Rows[0]["TenSanPhamBan"], dt.Rows[0]["TenDonViTinh"],
                            -1, -Common.DoubleValue(dt.Rows[0]["ThanhTien"])/Common.IntValue(dt.Rows[0]["SoLuong"])};
                            this.dgvHangKhuyenMai.Rows.Add(arr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp thông tin sản phẩm từ mã vạch. Xem lại thông tin sản phẩm, chính sách giá, số tồn trong kho!");
                return;
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
            add();
            this.Text = "Cập nhật phiếu nhập hàng trả lại. Đang tạo phiếu nhập hàng trả lại mới ...";
        }
        private void add()
        {
            try
            {
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
            if (ValidNhapTraLaiGop())
            {
                edit();
                this.Text = "Cập nhật phiếu nhập hàng trả lại.";
                if (dtPhieuXuat != null)
                {
                    this.Text += " - Tổng số phiếu [" + dtPhieuXuat.Rows.Count + "]";
                    if (dtPhieuXuat.Rows.Count > 0)
                        this.Text += " - Đang sửa phiếu số [" + (this.IndexPX + 1) + "] ...";
                }

            }
            else
            {
                Updating = false;
                setEDItems(false);
                setEDUpdate();
            }
        }
        private void edit()
        {
            Updating = true;
            setEDItems(true);
            setEDUpdate();
        }
        private void setEDItems(bool status)
        {
            this.mstNgayXuat.Enabled = status;
            //this.cboQuyen.Enabled = status;
            this.txtKyHieu.Enabled = status;
            this.txtSoSerie.Enabled = status;
            this.txtSoPhieu.Enabled = status;
            this.txtKyHieuKM.Enabled = status;
            this.txtSoSerieKM.Enabled = status;
            this.cboNhanVien.Enabled = status;
            this.cboKhachHang.Enabled = status;
            this.txtHoTenKhachHang.Enabled = status;
            this.txtDiaChi.Enabled = status;
            this.txtDienThoai.Enabled = status;
            this.txtMaSoThue.Enabled = status;
            this.txtGhiChu.Enabled = status;
            this.txtMaKhachHang.Enabled = status;
            this.cboGioiTinh.Enabled = status;
            this.txtTuoi.Enabled = status;
            this.txtMaNhanVien.Enabled = status;
            this.txtBillTo.Enabled = status;
            this.txtShipTo.Enabled = status;
            this.cboBillTo.Enabled = status;
            this.cboShipTo.Enabled = status;
            this.txtOrderType.Enabled = status;
            this.cboOrderType.Enabled = status;
            this.txtOrderTypeKM.Enabled = status;
            this.cboOrderTypeKM.Enabled = status;
            //this.cboLoaiTien.Enabled = status;
            this.txtTienThucTra.Enabled = status;
            //this.dgvSanPhamBan.Enabled = status;
            this.dgvSanPhamBan.Columns["SoLuong"].ReadOnly = !status;
            this.dgvSanPhamBan.Columns["GhiChu"].ReadOnly = !status;
            //this.dgvHangKhuyenMai.Columns["SoLuong"].ReadOnly = !status;
            //this.dgvHangKhuyenMai.Enabled = status;
            this.txtMaVach.Enabled=status;
            //this.txtGiaSanPham.Enabled = status;
            this.btnThemHang.Enabled = status;
            //this.btnTimKiem.Enabled = status;
            this.btnXoaSanPham.Enabled = status;
            this.btnXoaKhuyenMai.Enabled = status;
            this.cboHinhThucTT.Enabled = status;
            this.cboLoaiTra.Enabled = status;
            this.cboBangKeThue.Enabled = status;
            this.cboLoaiHoaDon.Enabled = status;
            this.cboMaDuAn.Enabled = status;
            //this.cboThu.Enabled = status;
            this.btnTimPX.Enabled = status;
        }
        private void setEDFunctions()
        {
            if (IdPhieuXuat == 0)
            {
                this.tsbPrev.Enabled = false;
                this.tsbNext.Enabled = false;
                this.tsbEdit.Enabled = false;
                this.tsbDelete.Enabled = false;
                //this.tsbPrint.Enabled = false;
            }
            else
            {
                this.tsbPrev.Enabled = IndexPX > 0 ? true : false;
                this.tsbNext.Enabled = IndexPX < (dtPhieuXuat.Rows.Count - 1) ? true : false;
                this.tsbEdit.Enabled = ChuaDayOracle;
                this.tsbDelete.Enabled = ChuaDayOracle;
                this.tsbUpdate.Enabled = ChuaDayOracle;
                this.tsbPayment.Enabled = ChuaDayOracle;
                this.tsbPrinter_Click.Enabled = true;
            }
            this.tsbAdd.Enabled = true;// Common.IsEnableCommandPX(-1);
        }

        private void setEDUpdate()
        {
            this.tsbAdd.Enabled = !Updating;
            this.tsbEdit.Enabled = !Updating & ChuaDayOracle;
            this.tsbUpdate.Enabled = Updating;// &ChuaDayOracle;
            //this.tsbPrinter_Click.Enabled = Updating;
            this.tsbPayment.Enabled = Updating;// &ChuaDayOracle;
        }

        private void GenerateReceipt(GtidCommand sqlcmd, List<ChiTietPhieuXuat> hoadon, List<ChiTietPhieuXuat> hoadonCK, int LoaiChungTu, int stt)
        {
            //them bang tbl_chungtu
            if (stt > 0)
                SoSerie = Common.LoadNextHoaDon(SoSerie);
            int IdChungTu = this.ChungTu_InsertCommand(sqlcmd, hoadon, hoadonCK, LoaiChungTu);
            //them bang chi tiet
            foreach (ChiTietPhieuXuat px in hoadon)
            {
                //them bang chi tiet chung tu
                int idChitietCT = this.ChiTiet_ChungTu_InsertCommand(sqlcmd, IdChungTu, px.IdSanPham, px.SoLuong, px.DonGia,
                                                                px.TyLeChietKhau, px.TienChietKhau);
                //them bang chi tiet hang hoa
                foreach (ChiTietHangHoa hh in px.DsHangHoa)
                    this.ChiTiet_ChungTu_HangHoa_InsertCommand(sqlcmd, idChitietCT, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau);
            }
            //them chiet khau
            foreach (ChiTietPhieuXuat px in hoadonCK)
            {
                //them bang chi tiet chung tu
                int idChitietCT = this.ChietKhau_ChungTu_InsertCommand(sqlcmd, IdChungTu, px.IdSanPham, px.SoLuong, px.DonGia, px.TienVAT, px.GhiChu);
            }
        }
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            update(false);
            showInfors();
        }
        private bool update(bool print)
        {
            GtidCommand sqlCmd = null;
            string strMsg = "Tạo mới phiếu nhập hàng trả lại thành công!";
            bool isAdded = false;
            try
            {
                if (!this.PhieuXuat_SuHopLeCuaThongTin()) return false;
                if (!this.ValidPhieuXuatGop()) return false;
                if (!this.ValidChiTietPhieuXuat()) return false;

                sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                ConnectionUtil.Instance.BeginTransaction();
                //Cap nhat thong tin chung
                if (this.IdPhieuXuat == 0)
                {
                    //Them header
                    this.PhieuXuat_InsertCommand(sqlCmd);
                    isAdded = true;
                }
                else
                {
                    //sua header
                    this.PhieuXuat_UpdateCommand(sqlCmd);
                    //cap nhat lai bang hang hoa chi tiet
                    CapNhat_HangHoaChiTiet(sqlCmd, "");
                    //xoa het chi tiet cu
                    this.PhieuXuat_AllDetails_DeleteCommand(sqlCmd);
                    //xoa het cac chung tu tao ra tu phieu xuat nay
                    this.PhieuXuat_AllChungTu_DeleteCommand(sqlCmd);
                    //xoa het cac phieu thu tao ra tu phieu xuat nay
                    this.PhieuXuat_AllThuChi_DeleteCommand(sqlCmd);
                    strMsg = "Cập nhật phiếu nhập hàng trả lại thành công!";
                }

                //Them chi tiet san pham ban
                List<ChiTietPhieuXuat> listCK = new List<ChiTietPhieuXuat>();
                List<ChiTietPhieuXuat> listPX = GetChiTietPhieuXuat(sqlCmd, ref listCK);
                foreach (ChiTietPhieuXuat px in listPX)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietPX_InsertCommand(sqlCmd, px.IdSanPham, px.IdSanPhamBan, px.SoLuong, px.DonGia,
                                                                    px.TyLeChietKhau, px.TienChietKhau, px.TyLeVAT, px.TienVAT, px.TyLeThuong, px.ThuongNong, px.GiaTheoBangGia);
                    //them bang chi tiet hang hoa
                    foreach (ChiTietHangHoa hh in px.DsHangHoa)
                        this.ChiTietPX_HangHoa_InsertCommand(sqlCmd, idChitietPX, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau, hh.TienVAT, hh.ThuongNong, hh.GhiChu);
                }
                //Them hang chiet khau
                foreach (ChiTietPhieuXuat px in listCK)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietCK_InsertCommand(sqlCmd, px.IdSanPham, px.SoLuong, px.TienChietKhau, px.TyLeVAT, px.TienVAT, px.GhiChu);
                }
                //Them chi tiet san pham khuyen mai
                List<ChiTietPhieuXuat> listKM = GetChiTietKhuyenMai(sqlCmd);
                foreach (ChiTietPhieuXuat km in listKM)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietPX_InsertCommand(sqlCmd, km.IdSanPham, km.IdSanPhamBan, km.SoLuong, km.DonGia,
                                                                    km.TyLeChietKhau, km.TienChietKhau, km.TyLeVAT, km.TienVAT, km.TyLeThuong, km.ThuongNong, km.GiaTheoBangGia);
                    //them bang chi tiet hang hoa
                    foreach (ChiTietHangHoa hh in km.DsHangHoa)
                        this.ChiTietPX_HangHoa_InsertCommand(sqlCmd, idChitietPX, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau, hh.TienVAT, hh.ThuongNong, hh.GhiChu);
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
                    GenerateReceipt(sqlCmd, hoadon, hoadonCK, (int)TransactionType.NHAP_TRA_LAI, stt);
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
                    GenerateReceipt(sqlCmd, hoadon, hoadonCK, (int)TransactionType.XUAT_BAN, stt);
                    stt++;
                }
                //Tao hoa don cho cac san pham khuyen mai
                stt = 0;
                hoadonCK = new List<ChiTietPhieuXuat>();
                if (listKM.Count > 0)
                {
                    GenerateReceipt(sqlCmd, listKM, hoadonCK, (int)TransactionType.TRA_LAI_KHUYEN_MAI, stt);
                    stt++;
                }

                
                //Tao phieu thu
                ThuChi_InsertCommand(sqlCmd);

                ConnectionUtil.Instance.CommitTransaction();
                //Common.updateSoHoaDon(SoSerie, (int)cboQuyen.SelectedValue);

                Common.LogAction(strMsg, "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu nhập hàng trả lại = " + txtSoPhieu.Text, Declare.IdKho);
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
                setEDUpdate();
                setEDItems(false);
                setEDFunctions();
                
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogAction("Lỗi cập nhật phiếu nhập hàng trả lại" , "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu nhập hàng trả lại = " + txtSoPhieu.Text, Declare.IdKho);
                return false;
            }
            return true;
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            delete();
            showInfors();
        }
        private void delete()
        {
            //xoa chung tu cua cac phieu xuat gop
            string sql = String.Format("select idchungtu, listidphieuxuat from tbl_chungtu where idphieuxuat=0 and " +
                "(listidphieuxuat = '{0}' or listidphieuxuat like '{0},%' or listidphieuxuat like '%,{0}' or listidphieuxuat like '%,{0},%')", IdPhieuXuat);
            DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
            string msg = "Bạn có chắc chắn hủy dữ liệu này không?";
            string lstIdPNL = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                lstIdPNL = dt.Rows[0]["listidphieuxuat"].ToString();
                msg = "Đây là phiếu nhập trả lại cho hóa đơn xuất gộp.\nKhi xóa sẽ xóa toàn bộ các phiếu nhập khác trong hóa đơn xuất gộp.\nBạn có chắc chắn hủy dữ liệu này không?";
            }
            DialogResult rs = MessageBox.Show(msg, "Thông báo", MessageBoxButtons.YesNoCancel);
            if (rs == DialogResult.Cancel)
            {
                return;
            }
            else if (rs == DialogResult.Yes)
            {
                //if (MessageBox.Show("Bạn có chắc chắn hủy dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                //    return;

                //Xoa du lieu hien tai
                if (this.IdPhieuXuat != 0)
                {
                    GtidCommand sqlCmd = null;
                    try
                    {
                        sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                        ConnectionUtil.Instance.BeginTransaction();
                        //cap nhat lai hang hoa chi tiet
                        CapNhat_HangHoaChiTiet(sqlCmd, lstIdPNL);
                        //xoa phieu thu
                        this.PhieuXuat_AllThuChi_DeleteCommand(sqlCmd);
                        //xoa cac chung tu
                        this.PhieuXuat_AllChungTu_DeleteCommand(sqlCmd);
                        //xoa chi tiet phieu xuat
                        this.PhieuXuat_DeleteCommand(sqlCmd);
                        //sqlTran.Commit();
                        ConnectionUtil.Instance.CommitTransaction();
                        Common.LogAction("Xóa phiếu nhập hàng trả lại thành công", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu nhập hàng trả lại = " + txtSoPhieu.Text, Declare.IdKho);
                        MessageBox.Show("Hủy phiếu nhập hàng trả lại thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ////Dong trong truong hop sua tu danh sach tim kiem
                        //if (this.IndexPXSearch >= 0)
                        //{
                        //    this.dtPXSearch.Rows.RemoveAt(this.IndexPXSearch);
                        //    this.Close();
                        //    return;
                        //}
                        LoadAllPhieuXuat();
                        //dtPhieuXuat.Rows.RemoveAt(IndexPX);

                    }
                    catch (Exception ex)
                    {
                        ConnectionUtil.Instance.RollbackTransaction();
                        Common.LogAction("Xóa phiếu nhập hàng trả lại thất bại", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu nhập hàng trả lại = " + txtSoPhieu.Text, Declare.IdKho);
                        MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            //Hien thi du lieu tiep theo
            if (IndexPX >= dtPhieuXuat.Rows.Count || IndexPX < 0)
            {
                IndexPX = 0;
            }
            if (dtPhieuXuat.Rows.Count > 0)
            {
                this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdPhieuXuat"].ToString());
                this.LoadPhieuXuat(this.IdPhieuXuat);
            }
            else
                this.PhieuXuat_ThemMoi();
            //Thiet lap trang thai item
            Updating = false;
            setEDUpdate();
            setEDItems(false);
            setEDFunctions();
        }
        //private void tsbPrint_Click(object sender, EventArgs e)
        //{
        //    if (update(true))
        //        print();
        //}

        private void print()
        {
            string str = "Select kh.MaKho, kh.TenKho, kh.DiaChi, kh.DienThoai, tt.TenTrungTam " +
                         " From tbl_DM_Kho kh inner join tbl_DM_TrungTam tt on tt.IdTrungTam = kh.IdTrungTam" +
                         " Where kh.IdKho = " + this.cboKhoXuat.SelectedValue;

            DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
            string kho = dtKho.Rows[0]["MaKho"].ToString() + " - " + dtKho.Rows[0]["TenKho"].ToString();

            PhieuXuat px = new PhieuXuat(this.IdPhieuXuat, this.txtSoPhieu.Text, this.mstNgayXuat.Value, dtKho.Rows[0]["TenTrungTam"].ToString(), kho, dtKho.Rows[0]["DiaChi"].ToString(),
                             dtKho.Rows[0]["DienThoai"].ToString(), this.cboNhanVien.SelectedText, this.txtHoTenKhachHang.Text, this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text,
                            Common.DoubleValue(this.txtTongTienHang.Text.Trim()), Common.DoubleValue(this.txtTongTienCK.Text.Trim()), Common.DoubleValue(this.txtTongTienVAT.Text.Trim()),
                            Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()), Common.DoubleValue(this.txtTienThucTra.Text.Trim()), Common.DoubleValue(this.txtTienConNo.Text.Trim()),
                            Declare.KyHieuTienTe, ThanhToan[cboHinhThucTT.SelectedIndex], this.txtGhiChu.Text);
            frmPhieuNhapLai_LuaChonIn frmInPX = new frmPhieuNhapLai_LuaChonIn(px, this.txtPhieuNhap.Text);
            frmInPX.ShowDialog();
            Common.LogAction("In phiếu nhập hàng trả lại", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            search();
        }
        private void search()
        {
            int[] IdPhieu = new int[] { 0 };
            frmTimPhieuXuat frm = new frmTimPhieuXuat((int)TransactionType.NHAP_TRA_LAI, IdPhieu);
            if (frm.ShowDialog() == DialogResult.OK) {
                if (IdPhieu[0] > 0) {
                    this.IdPhieuXuat = IdPhieu[0];
                    if (dtPhieuXuat.PrimaryKey.Length == 0)
                        dtPhieuXuat.PrimaryKey = new DataColumn[] { dtPhieuXuat.Columns["IdPhieuXuat"] };
                    IndexPX = dtPhieuXuat.Rows.IndexOf(dtPhieuXuat.Rows.Find(this.IdPhieuXuat));
                    this.LoadPhieuXuat(this.IdPhieuXuat);
                    setEDFunctions();
                    if (ChuaDayOracle)
                        tsbEdit_Click(this, null);
                }
            }
            //frmTimPhieuXuat frm = new frmTimPhieuXuat((int)TransactionType.NHAP_TRA_LAI);
            //frm.MdiParent = this.ParentForm;
            //this.Close();
            //frm.Show();
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
                if (tienConNo < 0)
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
            Common.LogAction("Trả tiền thừa mua hàng", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu nhập = " + txtSoPhieu.Text, Declare.IdKho);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    double dongia = Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["DonGia"].Value);
                    double tyleCK = Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["TyleChietKhau"].Value);
                    double tyleVAT = Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["TyleVAT"].Value);
                    if (tyleVAT < 0) tyleVAT = 0;

                    double tongtien = soLuong * dongia;
                    double tienCK = tongtien * tyleCK / TyLe;
                    double tienSauCK = tongtien - tienCK;
                    double tienVAT = tienSauCK * tyleVAT / TyLe;
                    double thanhTien = tienSauCK + tienVAT;
                    dgvSanPhamBan.CurrentRow.Cells["TienChietKhau"].Value = Common.Double2Str(tienCK);
                    dgvSanPhamBan.CurrentRow.Cells["TienSauChietKhau"].Value = Common.Double2Str(tienSauCK);
                    dgvSanPhamBan.CurrentRow.Cells["TienVAT"].Value = Common.Double2Str(tienVAT);
                    dgvSanPhamBan.CurrentRow.Cells["ThanhTien"].Value = Common.Double2Str(thanhTien);
                }
                //if (dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["SoLuong"])
                //{
                //    int soLuong = Common.IntValue(dgvSanPhamBan.CurrentRow.Cells["SoLuong"].Value.ToString());
                //    double tienCK = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_CK"].Value.ToString());
                //    double tienSauCK = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_SauCK"].Value.ToString());
                //    double tienVAT = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_VAT"].Value.ToString());
                //    double thanhTien = soLuong * Common.DoubleValue(dgvSanPhamBan.CurrentRow.Cells["Unit_ThanhTien"].Value.ToString());
                //    dgvSanPhamBan.CurrentRow.Cells["TienChietKhau"].Value = Common.Double2Str(tienCK);
                //    dgvSanPhamBan.CurrentRow.Cells["TienSauChietKhau"].Value = Common.Double2Str(tienSauCK);
                //    dgvSanPhamBan.CurrentRow.Cells["TienVAT"].Value = Common.Double2Str(tienVAT);
                //    dgvSanPhamBan.CurrentRow.Cells["ThanhTien"].Value = Common.Double2Str(thanhTien);
                //}
                UpdateSummariesInfors();
            }

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
                    tongTienHang += soLuong * Common.DoubleValue(dgr.Cells["DonGia"].Value);
                    tongTienCK += Common.DoubleValue(dgr.Cells["TienChietKhau"].Value);
                    tongTienSauCK += Common.DoubleValue(dgr.Cells["TienSauChietKhau"].Value);
                    tongTienVAT += Common.DoubleValue(dgr.Cells["TienVAT"].Value);
                    tongThanhTien += Common.DoubleValue(dgr.Cells["ThanhTien"].Value);
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
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSanPhamBan.SelectedRows)
            {
                int idSPBan = int.Parse(row.Cells["IdSanPham"].Value.ToString());
                for (int i=dgvHangKhuyenMai.Rows.Count-1; i>=0; i--)
                    if (idSPBan== int.Parse(dgvHangKhuyenMai.Rows[i].Cells["IdSanPhamBan"].Value.ToString()))
                        dgvHangKhuyenMai.Rows.RemoveAt(i);
                dgvSanPhamBan.Rows.Remove(row);
            }
        }

        private void btnXoaKhuyenMai_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvHangKhuyenMai.SelectedRows)
            {
                int slKM = Common.IntValue(row.Cells["SoLuongKM"].Value.ToString());
                double tienKM = Common.DoubleValue(row.Cells["SoTienKM"].Value.ToString());
                int IdBan = Common.IntValue(row.Cells["IdSanPhamBan"].Value.ToString());
                double tienChuyen=0;
                int slChuyen = slKM;
                if (slChuyen > 1)
                {
                    InputDialog input = new InputDialog(0,slChuyen);
                    input.ShowDialog();
                    if (input.IsInput)
                        slChuyen = input.InputedNumber;
                    else
                        return;
                }
                tienChuyen = tienKM / slKM * slChuyen;
                //dieu chinh gia
                foreach (DataGridViewRow row1 in dgvSanPhamBan.Rows)
                {
                    int IdSP = Common.IntValue(row1.Cells["IdSanPham"].Value.ToString());
                    if (IdBan == IdSP)
                    {
                        int soluong = Common.IntValue(row1.Cells["SoLuong"].Value.ToString());
                        double dongia = Common.DoubleValue(row1.Cells["DonGia"].Value);
                        double tlck = Common.DoubleValue(row1.Cells["TyleChietKhau"].Value);
                        double tlvat = Common.DoubleValue(row1.Cells["TyleVAT"].Value);
                        double giamgia, giamoi, tongtien, tienck, tiensauck, tienvat, thanhtien;
                        giamgia = tienChuyen / (soluong * (1 - tlck / TyLe) * (1 + tlvat / TyLe));
                        giamoi = dongia - giamgia;
                        tongtien = giamoi * soluong;
                        tienck = tongtien * tlck / TyLe;
                        tiensauck = tongtien - tienck;
                        tienvat = tiensauck * tlvat / TyLe;
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
            catch { }
        }

        private void cboBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtBillTo.Text = dtDiaChi.Rows[cboBillTo.SelectedIndex]["SiteNumber"].ToString();
            }
            catch { }
        }

        private void cboShipTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtShipTo.Text = dtDiaChi.Rows[cboShipTo.SelectedIndex]["SiteNumber"].ToString();
            }
            catch { }
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
            txtMaNhanVien.Text = dtNhanVien.Rows[cboNhanVien.SelectedIndex]["MaNhanVien"].ToString();
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
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
            if (!found)
            {
                cboKhachHang.Text = "";
                txtBillTo.Text = "";
                cboBillTo.Text = "";
                txtShipTo.Text = "";
                cboShipTo.Text = "";
                txtOrderType.Text = "";
                cboOrderType.Text = "";
                txtOrderTypeKM.Text = "";
                cboOrderTypeKM.Text = "";
            }
        }

        private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtNhanVien.Rows.Count; i++)
            {
                if (txtMaNhanVien.Text.Equals(dtNhanVien.Rows[i]["MaNhanVien"].ToString()))
                {
                    cboNhanVien.SelectedIndex = i;
                    found = true;
                    break;
                }
            }
            if (!found)
                cboNhanVien.Text = "";
        }

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

        private void btnTimPX_Click(object sender, EventArgs e)
        {
            string where = "";
            if (!txtSoPhieu.Text.Equals(""))
            {
                where += " and px.SoPhieuXuat = '" + txtSoPhieu.Text.Trim() + "'";
            }
            else if (!txtSoSerie.Text.Equals("") && !txtKyHieu.Text.Equals(""))
            {
                where += " and px.SoSerie = '" + txtSoSerie.Text.Trim() + "'";
                where += " and px.KyHieu = '" + txtKyHieu.Text.Trim() + "'";                
            }

            if (!where.Equals(""))
            {
                string str;
                DataTable dt;

                str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.KyHieu,px.SoSerie,px.IdKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi," +
                             "px.DienThoai, px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                             "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.KyHieuKM,px.SoSerieKM " +
                      "from tbl_PhieuXuat px " +
                      "where px.LoaiXuatNhap=" + (int)TransactionType.XUAT_BAN +
                      " and px.IdKho = " + Declare.IdKho;
                str += where;

                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                if (dt != null && dt.Rows.Count > 0)
                {
                    idPhieuXuatGoc = int.Parse(dt.Rows[0]["IdPhieuXuat"].ToString());
                    this.PhieuXuat_HienThi(dt.Rows[0]);

                    str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                                 "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                          "FROM vChiTietPhieuXuat " +
                          "WHERE IdPhieuXuat=" + idPhieuXuatGoc + " and IdSanPhamBan is null " +
                          "Union all " +
                          "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                                 "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                          "FROM vChietKhauPhieuXuat " +
                          "WHERE IdPhieuXuat=" + idPhieuXuatGoc;
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
                            -int.Parse(dt.Rows[i]["SoLuong"].ToString()),
                            Common.Double2Str((double)dt.Rows[i]["DonGia"]),
                            Common.Double2Str((double)dt.Rows[i]["TyLeChietKhau"] * TyLe),
                            Common.Double2Str(-(double)dt.Rows[i]["TienChietKhau"]),
                            Common.Double2Str(-tienSauCK),                            
                            //Common.Double2Str((double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str((double)dt.Rows[i]["TyLeVAT"]<0?(double)dt.Rows[i]["TyLeVAT"]:(double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str(-(double)dt.Rows[i]["TienVAT"]),
                            Common.Double2Str(-(double)dt.Rows[i]["ThanhTien"]),
                            Common.Double2Str(-(double)dt.Rows[i]["TienChietKhau"]),
                            dt.Rows[i]["GhiChu"],
                            Common.Double2Str(tienSauCK),
                            Common.Double2Str(-(double)dt.Rows[i]["TienVAT"]),
                            Common.Double2Str(-(double)dt.Rows[i]["ThanhTien"]),
                            dt.Rows[i]["TyLeThuong"],
                            Common.Double2Str(-(double)dt.Rows[i]["ThuongNong"]),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["GiaTheoBangGia"]))
                        };
                        this.dgvSanPhamBan.Rows.Add(arr);

                        DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                        newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + dt.Rows[i]["IdSanPham"].ToString()));
                        newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");// &Updating;//sửa giá bán
                        newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                        newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    }

                    str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                                 "IdSanPhamBan,MaSanPhamBan,TenSanPhamBan,SoLuong,ThanhTien " +
                          "FROM vChiTietPhieuXuat " +
                          "WHERE IdPhieuXuat=" + idPhieuXuatGoc + " and IdSanPhamBan is not null ";
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
                            -int.Parse(dt.Rows[i]["SoLuong"].ToString()),
                            Common.Double2Str(-(double)dt.Rows[i]["ThanhTien"])};
                        this.dgvHangKhuyenMai.Rows.Add(arr);
                    }
                }
                else
                    MessageBox.Show("Không tìm thấy phiếu xuất!", Declare.titleNotice);
            }
            else
                MessageBox.Show("Phải nhập số phiếu xuất hoặc số hóa đơn xuất để tìm kiếm phiếu xuất!", Declare.titleNotice);


        }

        private void cboNhanVien_TextUpdate(object sender, EventArgs e)
        {
            if (cboNhanVien.Text.Trim().Length == 0)
                txtMaNhanVien.Text = "";
        }

        private void cboKhachHang_TextUpdate(object sender, EventArgs e)
        {
            if (cboKhachHang.Text.Trim().Length == 0)
            {
                txtMaKhachHang.Text = "";
                txtBillTo.Text = "";
                cboBillTo.Text = "";
                txtShipTo.Text = "";
                cboShipTo.Text = "";
                txtOrderType.Text = "";
                cboOrderType.Text = "";
                txtOrderTypeKM.Text = "";
                cboOrderTypeKM.Text = "";
            }
        }

        private void cboBillTo_TextUpdate(object sender, EventArgs e)
        {
            if (cboBillTo.Text.Trim().Length == 0)
                txtBillTo.Text = "";
        }

        private void cboShipTo_TextUpdate(object sender, EventArgs e)
        {
            if (cboShipTo.Text.Trim().Length == 0)
                txtShipTo.Text = "";
        }

        private void cboOrderType_TextUpdate(object sender, EventArgs e)
        {
            if (cboOrderType.Text.Trim().Length == 0)
                txtOrderType.Text = "";
        }

        private void dgvSanPhamBan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSanPhamBan.CurrentRow != null)
            {
                if (dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["SoLuong"])
                {
                    Utils ut = new Utils();
                    if (ut.getInt(e.FormattedValue) > 0)
                    {
                        MessageBox.Show("Số lượng phải <= 0");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void cboNhanVien_Leave(object sender, EventArgs e)
        {
            if (cboNhanVien.Text.Trim().Length > 0)
            {
                bool found = false;
                for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                {
                    if (dtNhanVien.Rows[i]["HoTen"].ToString().ToLower().Equals(cboNhanVien.Text.Trim().ToLower()))
                    {
                        cboNhanVien.SelectedIndex = i;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Nhân viên này không có trong danh sách, chọn nhân viên khác");
                    cboNhanVien.Text = "";
                }
            }
        }

        private void cboKhachHang_Leave(object sender, EventArgs e)
        {
            if (cboKhachHang.Text.Trim().Length > 0)
            {
                bool found = false;
                for (int i = 0; i < dtKhachHang.Rows.Count; i++)
                {
                    if (dtKhachHang.Rows[i]["TenDoiTuong"].ToString().ToLower().Equals(cboKhachHang.Text.Trim().ToLower()))
                    {
                        cboKhachHang.SelectedIndex = i;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
                    cboKhachHang.Text = "";
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
            catch { }
        }

        private void cboOrderTypeKM_TextUpdate(object sender, EventArgs e)
        {
            if (cboOrderTypeKM.Text.Trim().Length == 0)
                txtOrderTypeKM.Text = "";
        }

        private void tsbPrinter_Click_Click(object sender, EventArgs e)
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
                print();
            }
        }

        private void txtSoPhieu_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnTimPX_Click(sender, e);
            }
        }
   }
}