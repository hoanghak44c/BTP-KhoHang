using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using CrystalDecisions.Shared;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Common.Objects;
using QLBanHang.Modules.KhoHang.Reports;
using QLBanHang.Modules;
using QLBH.Core.Exceptions;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuatHangEmei : frmBCBase
    {
        #region "Khai báo biến"
        //DataTable dtKhachHang = null;
        DataTable dtNhanVien = null;
        DataTable dtPhieuXuat = null;
        DataTable dtPXSearch = null;
        DataTable dtSanPham = null;
        DataTable dtKhuyenMai = null;
        //DataTable dtDiaChi = null;
        //DataTable dtOrderType = null;
        //DataTable dtOrderTypeKM = null;
        public int IdPhieuXuat = 0;
        public int IndexPX = 0;
        public int IndexPXSearch = -1;
        private bool Updating = false;
        private int TyLe = 100;
        private bool ChuaDayOracle = true;
        //private List<HoaDon> listChungTu;
        //private int IdPhieuThu = 0;
        //private string SoTaiKhoan = "";
        //private string NganHang = "";
        //private string SoSerie = "";
        //string[] ThanhToan ={ "Tiền mặt", "Chuyển khoản" };

        //public int ChucNang = 1;//1: lập order; 2- lập hóa đơn
        public bool DaLapHoaDon = false;
        Utils ut = new Utils();
        #endregion

        #region "Các phương thức khởi tạo"
        public frmPhieuXuatHangEmei()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmPhieuXuatHangEmei(DataTable dtPX, int IndexPXSearch)
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
        //private string PhieuXuat_LaySoPhieuThu()
        //{
        //    string rs = txtSoPhieu.Text;
        //    try
        //    {
        //        SqlCommand sqlcmd = new SqlCommand("sp_PhieuXuat_Thu_SoPhieuTuDong");
        //        sqlcmd.Parameters.AddWithValue("@Code", "PXT").Direction = ParameterDirection.Input;
        //        sqlcmd.CommandType = CommandType.StoredProcedure;

        //        string str = DBTools.ExecuteScalar(sqlcmd).ToString();

        //        if (str.Trim().Length != 0 && str != "0")
        //            rs = str;
        //    }
        //    catch (Exception ex) { }
        //    return rs;
        //}
        private bool PhieuXuat_ThemMoi()
        {
            this.IdPhieuXuat = 0;
            DaLapHoaDon = false;
            this.PhieuXuat_KhoiTaoSoPhieu();
            txtSoOrderKH.Text = "";
            txtSoOrderKH.Focus();
            this.mstNgayXuat.Value = DateTime.Now;//.ResetText();//.Text = DateTime.Today.ToString("dd/MM/yyyy");
            this.txtMaNhanVien.ResetText();
            //this.txtMaKhachHang.ResetText();
            this.txtHoTenKhachHang.ResetText();
            //this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            //this.txtMaSoThue.ResetText();
            //this.txtOrderType.ResetText();
            //this.txtOrderTypeKM.ResetText();
            //this.txtTuoi.ResetText();
            this.txtGhiChu.ResetText();
            //this.txtBillTo.ResetText();
            //this.txtShipTo.ResetText();
            //try { this.cboOrderType.SelectedIndex = -1; }
            //catch { }
            //try { this.cboOrderTypeKM.SelectedIndex = -1; }
            //catch { }
            //try { this.cboBillTo.SelectedIndex = -1; }
            //catch { }
            //try { this.cboShipTo.SelectedIndex = -1; }
            //catch { }
            try
            {
                this.cboNhanVien.SelectedIndex = -1;// Declare.IdNhanVien; 
            }
            catch (Exception ex) { }
            //try { this.cboKhoXuat.SelectedValue = Declare.IdKho; }
            //catch { }
            //try { this.cboKhachHang.SelectedValue = Declare.IdKHMacDinh; }
            //catch { }
            //try { this.cboGioiTinh.SelectedIndex = 0; }
            //catch { }
            //LoadHoaDon();
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
            //Sự hợp lệ của thông tin order khách hàng
            //
            if (this.txtSoOrderKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số giao dịch khách hàng." + "\n" + "-Hãy nhập số Order", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtSoOrderKH.Focus();
                return false;
            }
            //Kiem tra trung so phieu
            string sqlstr = "select * from tbl_PhieuXuat where SoOrderKH=N'" + this.txtSoOrderKH.Text.Trim() + "' and IdPhieuXuat!=" + this.IdPhieuXuat + " and IdKho = " + Declare.IdKho;
            if (DBTools.ExistData(sqlstr))
            {
                MessageBox.Show("Số giao dịch này đã có." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSoOrderKH.Focus();
                return false;
            }
            //
            //Sự hợp lệ của thông tin số phiếu xuất
            //
            if (this.txtSoPhieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số phiếu chưa nhập." + "\n" + "-Hãy nhập số phiếu", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.txtSoPhieu.Focus();
                return false;
            }
            //Kiem tra trung so phieu
            sqlstr = "select * from tbl_PhieuXuat where SoPhieuXuat=N'" + this.txtSoPhieu.Text.Trim() + "' and IdPhieuXuat!=" + this.IdPhieuXuat;
            if (DBTools.ExistData(sqlstr))
            {
                MessageBox.Show("Số phiếu này đã có." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSoPhieu.Focus();
                return false;
            }
            ////Kiem tra hop le hoa don
            //if (cboQuyen.SelectedValue == null || !Common.CheckHoaDon(txtSoSerie.Text, (int)cboQuyen.SelectedValue))
            //{
            //    MessageBox.Show("Số serie hóa đơn không đúng định dạng hoặc không có số này trong quyển hóa đơn.\nHãy nhập số serie khác", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabInfors.SelectedTab = tabInfors.TabPages[1];
            //    this.txtSoSerie.Focus();
            //    return false;
            //}
            //
            //Sự hợp lệ của thông tin ngày xuất
            //
            if (this.mstNgayXuat.Text.Trim().Length == 4)
            {
                MessageBox.Show("Ngày xuất chưa nhập." + "\n" + "-Hãy nhập ngày xuất", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.mstNgayXuat.Focus();
                return false;
            }
            if (this.mstNgayXuat.Text.Trim().Length > 4 && this.mstNgayXuat.Text.Trim().Length < 10)
            {
                MessageBox.Show("Ngày xuất nhập chưa đúng." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }
            if (!Common.IsValidDate(mstNgayXuat.Text.Trim()))
            {
                MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }

            ////
            ////Sự hợp lệ của thông tin khách hàng 
            ////
            //if (this.cboKhachHang.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Chưa chọn khách hàng." + "\n" + "-Hãy chọn khách hàng", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabInfors.SelectedTab = tabInfors.TabPages[0];
            //    this.cboKhachHang.Focus();
            //    return false;
            //}
            //if (this.cboNhanVien.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Chưa chọn nhân viên." + "\n" + "-Hãy chọn nhân viên", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabInfors.SelectedTab = tabInfors.TabPages[0];
            //    this.cboNhanVien.Focus();
            //    return false;
            //}
            //if (this.cboOrderType.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Chưa chọn Order Type." + "\n" + "-Hãy chọn Order Type", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    tabInfors.SelectedTab = tabInfors.TabPages[2];
            //    this.cboOrderType.Focus();
            //    return false;
            //}
            //if (dgvHangKhuyenMai.RowCount > 0)
            //{
            //    if (this.cboOrderTypeKM.Text.Trim().Length == 0)
            //    {
            //        MessageBox.Show("Chưa chọn Order Type hàng khuyến mại." + "\n" + "-Hãy chọn Order Type Khuyến mại", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        tabInfors.SelectedTab = tabInfors.TabPages[2];
            //        this.cboOrderTypeKM.Focus();
            //        return false;
            //    }
            //}
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

//        private void ThuChi_InsertCommand(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran)
//        {
//            try
//            {
//                string phieuthu = PhieuXuat_LaySoPhieuThu();
//                sqlcmd.CommandType = CommandType.StoredProcedure;
//                sqlcmd.CommandText = "sp_PhieuXuat_Thu_Insert";
//                sqlcmd.Parameters.Clear();

//                sqlcmd.Parameters.AddWithValue("@IdPhieu", 0).Direction = ParameterDirection.Output;
//                sqlcmd.Parameters.AddWithValue("@SoPhieu", phieuthu).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NgayLap", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdNhanVien", this.cboNhanVien.SelectedValue).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdDoiTuong", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NoiDungThuChi", this.txtGhiChu.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoTien", Common.DoubleValue(txtTienThucTra.Text.Trim())).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdTienTe", Declare.IdTienTe).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TyGia", 1).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoTienChu", Common.ReadNumner_(txtTienThucTra.Text)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoChungTuKem", 1).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ChungTuGoc", txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdThuChi", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;

//                DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran);

//                this.IdPhieuThu = (int)sqlcmd.Parameters["@IdPhieu"].Value;
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }
        private void PhieuXuat_InsertCommand(GtidCommand sqlcmd)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Emei_Insert_NV_KH";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@LoaiXuatNhap", (int)TransactionType.XUAT_BAN).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayXuat", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@QuyenSo", Common.IntValue(this.cboQuyen.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@KyHieu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@SoSerie", this.txtSoSerie.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdNhanVien", Common.IntValue(this.cboNhanVien.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdKhachHang", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@GioiTinh", this.cboGioiTinh.SelectedIndex).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@DoTuoi", Common.IntValue(this.txtTuoi.Text.Trim())).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DienThoai", this.txtDienThoai.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@MaSoThue", this.txtMaSoThue.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@OrderType", Common.IntValue(this.cboOrderType.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@OrderTypeKM", Common.IntValue(this.cboOrderTypeKM.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@BillTo", Common.IntValue(this.cboBillTo.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@ShipTo", Common.IntValue(this.cboShipTo.SelectedValue)).Direction = ParameterDirection.Input;
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
            //sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@HinhThucTra", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdBangKeThue", Common.IntValue(cboBangKeThue.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdLoaiHDBanHang", Common.IntValue(cboLoaiHoaDon.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdDuAn", Common.IntValue(cboMaDuAn.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoOrderKH", this.txtSoOrderKH.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NhapHoaDon", DaLapHoaDon).Direction = ParameterDirection.Input;

            if (!DBTools.InsertRecord(sqlcmd))
                throw DBTools._LastError;
            this.IdPhieuXuat = int.Parse(sqlcmd.Parameters["@IdPhieuXuat"].Value.ToString());

        }


        private void PhieuXuat_UpdateCommand(GtidCommand sqlcmd)
        {
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_PhieuXuat_Emei_Update_NV_KH";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", this.IdPhieuXuat).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@LoaiXuatNhap", (int)TransactionType.XUAT_BAN).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NgayXuat", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@QuyenSo", Common.IntValue(this.cboQuyen.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@KyHieu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@SoSerie", this.txtSoSerie.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@IdNhanVien", Common.IntValue(this.cboNhanVien.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdKhachHang", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@GioiTinh", this.cboGioiTinh.SelectedIndex).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@DoTuoi", Common.IntValue(this.txtTuoi.Text.Trim())).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@DienThoai", this.txtDienThoai.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@MaSoThue", this.txtMaSoThue.Text.Trim()).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@OrderType", Common.IntValue(this.cboOrderType.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@OrderTypeKM", Common.IntValue(this.cboOrderTypeKM.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@BillTo", Common.IntValue(this.cboBillTo.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@ShipTo", Common.IntValue(this.cboShipTo.SelectedValue)).Direction = ParameterDirection.Input;
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
            //sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@HinhThucTra", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdBangKeThue", Common.IntValue(cboBangKeThue.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdLoaiHDBanHang", Common.IntValue(cboLoaiHoaDon.SelectedValue)).Direction = ParameterDirection.Input;
            //sqlcmd.Parameters.AddWithValue("@IdDuAn", Common.IntValue(cboMaDuAn.SelectedValue)).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@SoOrderKH", this.txtSoOrderKH.Text.Trim()).Direction = ParameterDirection.Input;
            sqlcmd.Parameters.AddWithValue("@NhapHoaDon", DaLapHoaDon).Direction = ParameterDirection.Input;

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
        }

        private void CapNhat_HangHoaChiTiet(GtidCommand sqlcmd)
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

        }

//        private void PhieuXuat_AllChungTu_DeleteCommand(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran)
//        {
//            try
//            {
//                sqlcmd.CommandType = CommandType.StoredProcedure;
//                sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllChungTu";
//                sqlcmd.Parameters.Clear();
//                sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
//                DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran);
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

//        private void PhieuXuat_AllThuChi_DeleteCommand(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran)
//        {
//            try
//            {
//                sqlcmd.CommandType = CommandType.StoredProcedure;
//                sqlcmd.CommandText = "sp_PhieuXuat_Delete_AllThuChi";
//                sqlcmd.Parameters.Clear();
//                sqlcmd.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
//                DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran);
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

//        private int ChungTu_InsertCommand(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran, List<ChiTietPhieuXuat> hoadon, int loaiChungTu, string soSerie)
//        {
//            try
//            {
//                int idKhoDieuChuyen = -1;
//                int orderType = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? Common.IntValue(this.cboOrderType.SelectedValue) : Common.IntValue(this.cboOrderTypeKM.SelectedValue);
//                int idLoaiHD = (loaiChungTu == (int)TransactionType.XUAT_BAN) ? 1 : 2;
//                double tyLeVAT = hoadon[0].TyLeVAT;
//                double tongTienHang = 0, tongTienCK = 0, tongTienSauCK = 0, tongTienVAT = 0, tongTienThanhToan = 0, tienThucTra = 0, tienNo = 0;
//                foreach (ChiTietPhieuXuat px in hoadon)
//                {
//                    tongTienHang += px.SoLuong * px.DonGia;
//                    tongTienCK += px.TienChietKhau;
//                    tongTienVAT += px.TienVAT;
//                }
//                tongTienSauCK = tongTienHang - tongTienCK;
//                tongTienThanhToan = tongTienSauCK + tongTienVAT;
//                tienThucTra = tongTienThanhToan;
//                sqlcmd.CommandType = CommandType.StoredProcedure;
//                sqlcmd.CommandText = "sp_ChungTu_Insert";
//                sqlcmd.Parameters.Clear();
//                sqlcmd.Parameters.AddWithValue("@IdChungTu", 0).Direction = ParameterDirection.Output;
//                sqlcmd.Parameters.AddWithValue("@SoPhieuXuat", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@LoaiChungTu", loaiChungTu).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@QuyenSo", Common.IntValue(this.cboQuyen.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoSeri", soSerie).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoChungTu", this.txtKyHieu.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NgayLap", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdKhoDieuChuyen", idKhoDieuChuyen).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdNhanVien", this.cboNhanVien.SelectedValue).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdDoiTuong", this.cboKhachHang.SelectedValue).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@HoTen", this.txtHoTenKhachHang.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@GioiTinh", this.cboGioiTinh.SelectedIndex).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@DoTuoi", Common.IntValue(this.txtTuoi.Text.Trim())).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@DienThoai", this.txtDienThoai.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@MaSoThue", this.txtMaSoThue.Text.Trim()).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NganHang", NganHang).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@OrderType", orderType).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@BillTo", Common.IntValue(this.cboBillTo.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ShipTo", Common.IntValue(this.cboShipTo.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TongTienHang", tongTienHang).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TongTienChietKhau", tongTienCK).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TongTienSauChietKhau", tongTienSauCK).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TyleVAT", tyLeVAT).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TongTienVAT", tongTienVAT).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TongTienThanhToan", tongTienThanhToan).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdTienTe", Declare.IdTienTe).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TyGia", 1).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TienThanhToanThuc", tienThucTra).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TienConNo", tienNo).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TongTien_Chu", Common.ReadNumner_(Common.Dbl2Str(tongTienThanhToan))).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@HinhThucThanhToan", ThanhToan[cboHinhThucTT.SelectedIndex]).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@HinhThucTra", Common.IntValue(cboLoaiTra.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());
//                sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ThoigianTao", System.DateTime.Now).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ThoigianSua", System.DateTime.Now).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdBangKeThue", Common.IntValue(cboBangKeThue.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdLoaiHDBanHang", idLoaiHD).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdDuAn", Common.IntValue(cboMaDuAn.SelectedValue)).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoChungTuTraLai", "").Direction = ParameterDirection.Input;

//                DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran);

//                int IdChungTu = (int)sqlcmd.Parameters["@IdChungTu"].Value;
//                //luu lai Id chung tu
//                HoaDon chungtu = new HoaDon(IdChungTu, Common.IntValue(this.cboQuyen.SelectedValue), this.txtKyHieu.Text.Trim(), soSerie, this.mstNgayXuat.Value, "", "", "", "", this.cboNhanVien.SelectedText,
//                                     this.txtHoTenKhachHang.Text, (int)this.cboGioiTinh.SelectedIndex, Common.IntValue(this.txtTuoi.Text.Trim()), this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text, orderType, Common.IntValue(this.cboBillTo.SelectedValue), Common.IntValue(this.cboShipTo.SelectedValue),
//                                      tongTienHang, tongTienCK, tyLeVAT, tongTienVAT, tongTienThanhToan, Declare.KyHieuTienTe, ThanhToan[cboHinhThucTT.SelectedIndex], Common.IntValue(this.cboLoaiTra.SelectedValue), this.txtGhiChu.Text);
//                listChungTu.Add(chungtu);
//                return IdChungTu;
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//            return -1;
//        }

//        private void ChungTu_DeleteCommand(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran, int IdChungTu)
//        {
//            try
//            {
//                sqlcmd.CommandType = CommandType.StoredProcedure;
//                sqlcmd.CommandText = "sp_ChungTu_Delete";
//                sqlcmd.Parameters.Clear();
//                sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu).Direction = ParameterDirection.Input;
//                DBTools.DeleteRecord(sqlcmd, sqlCon, sqlTran);
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

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

//        private int ChiTiet_ChungTu_InsertCommand(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran, int IdChungTu, int IdSP,
//                                            int sLuong, double dongia, double tyleCK, double tienCK)
//        {
//            try
//            {
//                double thanhtien = (sLuong * dongia - tienCK);
//                sqlcmd.CommandType = CommandType.StoredProcedure;
//                sqlcmd.CommandText = "sp_ChungTu_ChiTiet_Insert";
//                sqlcmd.Parameters.Clear();

//                sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
//                sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@DonGia", dongia).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TyLeChietKhau", tyleCK).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@TienChietKhau", tienCK).Direction = ParameterDirection.Input;
//                sqlcmd.Parameters.AddWithValue("@ThanhTien", thanhtien).Direction = ParameterDirection.Input;

//                DBTools.InsertRecord(sqlcmd, sqlCon, sqlTran);

//                int idChitiet = Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

//                return idChitiet;
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//            return -1;
//        }


        private void ChiTietPX_HangHoa_InsertCommand(GtidCommand sqlcmd, int IdChitiet, int IdHanghoa, int Soluong, double TienCK, double TienVAT, double thuong, string ghichu)
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

            if (!DBTools.InsertRecord(sqlcmd))
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


//        private void LoadKhachHang()
//        {
//            try
//            {
//                string str = "Select IdDoiTuong, MaDoiTuong, TenDoiTuong, DiaChi, DienThoai, MaSoThue, IdOrderType " +
//                      "from tbl_DM_DoiTuong " +
//                      "where SuDung = 1 and Type <> 2 " +
//                      "order by TenDoiTuong ASC";
//                this.dtKhachHang = DBTools.getData("tbl_DM_DoiTuong", str).Tables["tbl_DM_DoiTuong"];
//                if (this.dtKhachHang != null)
//                {
//                    //this.dtKhachHang.Constraints.Add("fg_KhachHang", dtKhachHang.Columns["IdKhachHang"], true);
//                    this.cboKhachHang.DataSource = this.dtKhachHang;
//                    this.cboKhachHang.DisplayMember = "TenDoiTuong";
//                    this.cboKhachHang.ValueMember = "IdDoiTuong";
//                    this.cboKhachHang.SelectedIndex = -1;
//                    //this.cboKhachHang.SelectedValue = Declare.IdKHMacDinh;

//                    // AutoCompleteStringCollection 
//                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
//                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
//                    for (int i = 0; i < dtKhachHang.Rows.Count; i++)
//                    {
//                        data.Add(dtKhachHang.Rows[i]["TenDoiTuong"].ToString());
//                        data1.Add(dtKhachHang.Rows[i]["MaDoiTuong"].ToString());
//                    }

//                    cboKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    cboKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    cboKhachHang.AutoCompleteCustomSource = data;

//                    txtMaKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    txtMaKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    txtMaKhachHang.AutoCompleteCustomSource = data1;

//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }
 
//        private void LoadQuyen()
//        {
//            try
//            {
//                string str = "Select distinct QuyenSo From tbl_SuDung_HoaDon Where IdNhanVien=" + Declare.IdNhanVien +
//                      " and SoHienTai<SoKetThuc ";

//                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
//                if (dt != null)
//                {
//                    this.cboQuyen.DataSource = dt;
//                    this.cboQuyen.DisplayMember = "QuyenSo";
//                    this.cboQuyen.ValueMember = "QuyenSo";
//                    //this.cboQuyen.SelectedIndex = 0;
//                    LoadHoaDon();
//                    // AutoCompleteStringCollection 
//                    //AutoCompleteStringCollection data = new AutoCompleteStringCollection();
//                    //for (int i = 0; i < dt.Rows.Count; i++)
//                    //    data.Add(dt.Rows[i]["QuyenSo"].ToString());

//                    //cboQuyen.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    //cboQuyen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    //cboQuyen.AutoCompleteCustomSource = data;
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }

//        }
//        private void LoadHoaDon()
//        {
//            string kyhieu="", serie="";
//            try
//            {
//                int quyen = (int)cboQuyen.SelectedValue;
//                Common.LoadHoaDon(ref kyhieu, ref serie, quyen);
//                txtKyHieu.Text = kyhieu;
//                txtSoSerie.Text = serie;
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }
//        private void LoadLoaiThuChi()
//        {
//            try
//            {
//                string str = "Select IdThuChi, KyHieu + ' - ' + Ten ThuChi From tbl_DM_LoaiThuChi " +
//                      " Where SuDung=1 and Type=0 ";

//                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
//                if (dt != null)
//                {
//                    this.cboLoaiTra.DataSource = dt;
//                    this.cboLoaiTra.DisplayMember = "ThuChi";
//                    this.cboLoaiTra.ValueMember = "IdThuChi";

//                    // AutoCompleteStringCollection 
//                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
//                    for (int i = 0; i < dt.Rows.Count; i++)
//                        data.Add(dt.Rows[i]["ThuChi"].ToString());

//                    cboLoaiTra.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    cboLoaiTra.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    cboLoaiTra.AutoCompleteCustomSource = data;
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }
//        private void LoadOrderType()
//        {
//            try
//            {
//                string str = "Select IdOrderType, Code, Name From tbl_DM_OrderType " +
//                      " Where SuDung=1 and Code like '%.1.1.%.%.%.%" + Declare.MAVUNG + "'";//xuat.hang hoa

//                this.dtOrderType = DBTools.getData("tmp", str).Tables["tmp"];
//                if (this.dtOrderType != null)
//                {
//                    this.cboOrderType.DataSource = this.dtOrderType;
//                    this.cboOrderType.DisplayMember = "Name";
//                    this.cboOrderType.ValueMember = "IdOrderType";

//                    // AutoCompleteStringCollection 
//                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
//                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
//                    for (int i = 0; i < this.dtOrderType.Rows.Count; i++)
//                    {
//                        data.Add(this.dtOrderType.Rows[i]["Name"].ToString());
//                        data1.Add(this.dtOrderType.Rows[i]["Code"].ToString());
//                    }

//                    cboOrderType.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    cboOrderType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    cboOrderType.AutoCompleteCustomSource = data;

//                    txtOrderType.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    txtOrderType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    txtOrderType.AutoCompleteCustomSource = data1;
//                }

//                str = "Select IdOrderType, Code, Name From tbl_DM_OrderType " +
//                      " Where SuDung=1 and Code like '%.1.99.%.%.%.%" + Declare.MAVUNG + "'";//xuat.hang hoa

//                this.dtOrderTypeKM = DBTools.getData("tmp", str).Tables["tmp"];
//                if (this.dtOrderTypeKM != null)
//                {
//                    this.cboOrderTypeKM.DataSource = this.dtOrderTypeKM;
//                    this.cboOrderTypeKM.DisplayMember = "Name";
//                    this.cboOrderTypeKM.ValueMember = "IdOrderType";

//                    // AutoCompleteStringCollection 
//                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
//                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
//                    for (int i = 0; i < this.dtOrderTypeKM.Rows.Count; i++)
//                    {
//                        data.Add(this.dtOrderTypeKM.Rows[i]["Name"].ToString());
//                        data1.Add(this.dtOrderTypeKM.Rows[i]["Code"].ToString());
//                    }

//                    cboOrderTypeKM.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    cboOrderTypeKM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    cboOrderTypeKM.AutoCompleteCustomSource = data;

//                    txtOrderTypeKM.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    txtOrderTypeKM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    txtOrderTypeKM.AutoCompleteCustomSource = data1;
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }
        private void LoadMaVach()
        {
            try
            {
                //string str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
                //            " Where hh.IdKho = " + Declare.IdKho + " and hh.SoLuong > 0 order by hh.MaVach ASC";
                ////string str1 = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh ";
                //DataTable dtMaVach = DBTools.getData("tbl_HangHoa_Chitiet", str).Tables["tbl_HangHoa_Chitiet"];
                if (dtSanPham != null)
                {
                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtSanPham.Rows.Count; i++)
                        data.Add(dtSanPham.Rows[i]["MaVach"].ToString());

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

//        private void LoadDiaChiKH()
//        {
//            try
//            {
//                string str = "Select IdDiaChi, SiteNumber, DiaChi From tbl_DM_DoiTuong_DiaChi " +
//                 " Where IdDoiTuong = " + cboKhachHang.SelectedValue;

//                this.dtDiaChi = DBTools.getData("tmp", str).Tables["tmp"];
//                if (this.dtDiaChi != null)
//                {
//                    this.cboBillTo.DataSource = this.dtDiaChi;
//                    this.cboBillTo.DisplayMember = "DiaChi";
//                    this.cboBillTo.ValueMember = "IdDiaChi";

//                    this.cboShipTo.DataSource = this.dtDiaChi;
//                    this.cboShipTo.DisplayMember = "DiaChi";
//                    this.cboShipTo.ValueMember = "IdDiaChi";

//                    // AutoCompleteStringCollection 
//                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
//                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
//                    for (int i = 0; i < dtDiaChi.Rows.Count; i++)
//                    {
//                        data.Add(dtDiaChi.Rows[i]["DiaChi"].ToString());
//                        data1.Add(dtDiaChi.Rows[i]["SiteNumber"].ToString());
//                    }

//                    cboBillTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    cboBillTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    cboBillTo.AutoCompleteCustomSource = data;

//                    cboShipTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    cboShipTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    cboShipTo.AutoCompleteCustomSource = data;

//                    txtBillTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    txtBillTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    txtBillTo.AutoCompleteCustomSource = data1;

//                    txtShipTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
//                    txtShipTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//                    txtShipTo.AutoCompleteCustomSource = data1;
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

//        private void LoadBangKeThue()
//        {
//            try
//            {
//                string str = "Select Id, KyHieu + ' - ' + Ten BangKe From tbl_DM_BangKeThue Where SuDung=1 ";

//                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
//                if (dt != null)
//                {
//                    DataRow r = dt.NewRow();
//                    r[0] = 0;
//                    r[1] = "";
//                    dt.Rows.InsertAt(r, 0);
//                    this.cboBangKeThue.DataSource = dt;
//                    this.cboBangKeThue.DisplayMember = "BangKe";
//                    this.cboBangKeThue.ValueMember = "Id";
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

//        private void LoadLoaiHoaDon()
//        {
//            try
//            {
//                string str = "Select Id, KyHieu + ' - ' + Ten HoaDon From tbl_DM_LoaiHD_BanHang Where SuDung=1 ";

//                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
//                if (dt != null)
//                {
//                    DataRow r = dt.NewRow();
//                    r[0] = 0;
//                    r[1] = "";
//                    dt.Rows.InsertAt(r, 0);
//                    this.cboLoaiHoaDon.DataSource = dt;
//                    this.cboLoaiHoaDon.DisplayMember = "HoaDon";
//                    this.cboLoaiHoaDon.ValueMember = "Id";
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

//        private void LoadMaDuAn()
//        {
//            try
//            {
//                string str = "Select IdDuAn, MaDuAn + ' - ' + TenDuAn DuAn From tbl_DM_DuAn Where SuDung=1 ";

//                DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
//                if (dt != null)
//                {
//                    DataRow r = dt.NewRow();
//                    r[0] = 0;
//                    r[1] = "";
//                    dt.Rows.InsertAt(r, 0);
//                    this.cboMaDuAn.DataSource = dt;
//                    this.cboMaDuAn.DisplayMember = "DuAn";
//                    this.cboMaDuAn.ValueMember = "IdDuAn";
//                }
//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }
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
            //LoadKhachHang();
            LoadKhoXuat();
            LoadNhanVien();
            //LoadTienTe();
            //LoadMaVach();
            //LoadQuyen();
            //LoadLoaiThuChi();
            //LoadOrderType();
            //LoadDiaChiKH();
            //LoadBangKeThue();
            //LoadLoaiHoaDon();
            //LoadMaDuAn();
            //cboHinhThucTT.SelectedIndex = 0;
            //LoadOfflineData();
        }

        private void PhieuXuat_HienThi(DataRow row)
        {
            this.txtSoPhieu.Text = row["SoPhieuXuat"].ToString();
            this.mstNgayXuat.Value = (DateTime)row["NgayXuat"];
            //this.cboQuyen.SelectedValue = Common.IntValue(row["QuyenSo"].ToString());
            //this.txtKyHieu.Text = row["KyHieu"].ToString();
            //this.txtSoSerie.Text = row["SoSerie"].ToString();
            this.cboKhoXuat.SelectedValue = Common.IntValue(row["IdKho"].ToString());
            if (row["IdNhanVien"] != DBNull.Value)
                this.cboNhanVien.SelectedValue = Common.IntValue(row["IdNhanVien"].ToString());
            else
                this.cboNhanVien.SelectedIndex = -1;
            //this.cboKhachHang.SelectedValue = Common.IntValue(row["IdKhachHang"].ToString());
            this.txtHoTenKhachHang.Text = row["HoTen"].ToString();
            //this.cboGioiTinh.SelectedIndex = Common.IntValue(row["GioiTinh"].ToString());
            //this.txtTuoi.Text = row["DoTuoi"].ToString();
            //this.txtDiaChi.Text = row["DiaChi"].ToString();
            this.txtDienThoai.Text = row["DienThoai"].ToString();
            //this.txtMaSoThue.Text = row["MaSoThue"].ToString();
            //this.SoTaiKhoan = row["SoTaiKhoan"].ToString();
            //this.NganHang = row["NganHang"].ToString();
            //this.cboOrderType.SelectedValue = Common.IntValue(row["OrderType"].ToString());
            //this.cboOrderTypeKM.SelectedValue = Common.IntValue(row["OrderTypeKM"].ToString());
            //this.cboBillTo.SelectedValue = Common.IntValue(row["BillTo"].ToString());
            //this.cboShipTo.SelectedValue = Common.IntValue(row["ShipTo"].ToString());
            //this.cboLoaiTien.SelectedValue = Common.IntValue(row["IdTienTe"].ToString());
            //this.txtTyGia.Text = row["TyGia"].ToString();
            this.txtTongTienHang.Text = Common.Double2Str((double)row["TongTienHang"]);
            this.txtTongTienCK.Text = Common.Double2Str((double)row["TongTienChietKhau"]);
            this.txtTongTienSauCK.Text = Common.Double2Str((double)row["TongTienSauChietKhau"]);
            this.txtTongTienVAT.Text = Common.Double2Str((double)row["TongTienVAT"]);
            this.txtTongTienThanhToan.Text = Common.Double2Str((double)row["TongTienThanhToan"]);
            this.txtTienThucTra.Text = Common.Double2Str((double)row["TienThanhToanThuc"]);
            this.txtTienConNo.Text = Common.Double2Str((double)row["TienConNo"]);
            //this.cboHinhThucTT.SelectedIndex = row["HinhThucThanhToan"].ToString().Equals(ThanhToan[0]) ? 0 : 1;
            //this.cboLoaiTra.SelectedValue = Common.IntValue(row["HinhThucTra"].ToString());
            //this.cboThu.SelectedValue = Common.IntValue(row["LoaiThu"].ToString()); 
            //this.cboBangKeThue.SelectedValue = Common.IntValue(row["IdBangKeThue"].ToString());
            //this.cboLoaiHoaDon.SelectedValue = Common.IntValue(row["IdLoaiHDBanHang"].ToString());
            //this.cboMaDuAn.SelectedValue = Common.IntValue(row["IdDuAn"].ToString());
            this.txtGhiChu.Text = row["GhiChu"].ToString();
            this.txtSoOrderKH.Text = row["SoOrderKH"].ToString();
            DaLapHoaDon = row["NhapHoaDon"] == DBNull.Value ? false : (bool)row["NhapHoaDon"];
        }

        private void LoadAllPhieuXuat()
        {
            string str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.IdKho,";
            str += " px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT,";
            str += " px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.SoOrderKH,px.NhapHoaDon ";
            str += " from tbl_PhieuXuat px ";
            //str += string.Format(" where px.NgayXuat >= convert(datetime,'{0}',121) and px.NgayXuat >=  convert(datetime,'{1}',121)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2LongString(Declare.NgayLamViec));
            str += string.Format(" where px.ThoigianSua >=  convert(datetime,'{0}',103)", Common.Date2String(System.DateTime.Now.AddDays(-1)));
            //str += string.Format(" where px.ThoigianSua > convert(datetime,'{0}',121) and px.ThoigianSua >=  convert(datetime,'{1}',103)",
            //              Common.Date2LongString(Declare.NgayKhoaSo), Common.Date2String(Declare.NgayLamViec));
            str += " and px.LoaiXuatNhap = " + (int)TransactionType.XUAT_BAN;
            str += " and px.IdKho = " + Declare.IdKho;
            //str += " and px.NguoiSua = '" + Declare.UserName + "'";
            str += " order by px.NhapHoaDon, px.ThoigianSua desc ";

            dtPhieuXuat = DBTools.getData("Tmp", str).Tables["Tmp"];
            showInfors();
        }
        private void LoadPhieuXuat(int IdPX)
        {
            string str;
            DataTable dt;

            str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.IdKho,px.IdNhanVien,px.HoTen,px.DienThoai," +
                         "px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                         "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.SoOrderKH,px.NhapHoaDon " +
                  "from tbl_PhieuXuat px " +
                  "where IdPhieuXuat=" + IdPX + "";
            dt = DBTools.getData("Tmp", str).Tables["Tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                this.PhieuXuat_HienThi(dt.Rows[0]);

                str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + IdPX + " and IdSanPhamBan is null ";
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                this.dgvSanPhamBan.Rows.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    double tienSauCK = Common.IntValue(dt.Rows[i]["SoLuong"].ToString()) * Common.DoubleValueInt(dt.Rows[i]["DonGia"].ToString())
                                        - Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"].ToString());
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
                    newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + Common.IntValue(dt.Rows[i]["IdSanPham"])));
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
                    if (!DaLapHoaDon)
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
                    showInfors();
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
        private bool ValidChiTietDuLieu(GtidCommand sqlcmd, GtidConnection sqlCon)
        {
            List<DataGridViewRow> lstGvKM = new List<DataGridViewRow>();
            foreach (DataGridViewRow dgr in dgvHangKhuyenMai.Rows)
                lstGvKM.Add(dgr);

            //kiem tra hang ban
            foreach (DataGridViewRow dgr in dgvSanPhamBan.Rows)
            {
                int idSP = Common.IntValue(dgr.Cells["IdSanPham"].Value);
                string tenSP = dgr.Cells["TenSanPham"].Value.ToString();
                string mavach = dgr.Cells["MaVach"].Value.ToString();
                int soluong = Common.IntValue(dgr.Cells["SoLuong"].Value);
                for (int i = lstGvKM.Count - 1; i >= 0; i--)
                {
                    if (idSP == Common.IntValue(lstGvKM[i].Cells["IdSanPhamKM"].Value) && mavach.Equals(lstGvKM[i].Cells["MaVachKM"].Value.ToString()))
                    {
                        soluong += Common.IntValue(lstGvKM[i].Cells["SoLuongKM"].Value);
                        lstGvKM.RemoveAt(i);
                    }
                }

                string str = String.Format("Select SoLuong From tbl_HangHoa_Chitiet Where MaVach=N'{0}' and IdKho = {1} and IdSanPham = {2}",
                                            mavach, Declare.IdKho, idSP);
                string sTon = DBTools.getValue(str);
                if (sTon.Equals(""))
                {
                    MessageBox.Show("Trong kho không còn sản phẩm " + tenSP + " có mã vạch " + mavach + "\nBạn không thể bán được");
                    return false;
                } 
                else if (Common.IntValue(sTon)<soluong)
                {
                    MessageBox.Show("Sản phẩm " + tenSP + " có mã vạch " + mavach + " chỉ còn " + sTon + "\nKhông đủ hàng để bán (" + soluong + "). Bạn không thể bán được");
                    return false;
                }
            }

            //kiem tra hang khuyen mai
            while (lstGvKM.Count > 0)
            {
                int idSP = Common.IntValue(lstGvKM[0].Cells["IdSanPhamKM"].Value);
                string tenSP = lstGvKM[0].Cells["TenSanPhamKM"].Value.ToString();
                string mavach = lstGvKM[0].Cells["MaVachKM"].Value.ToString();
                int soluong = Common.IntValue(lstGvKM[0].Cells["SoLuongKM"].Value);
                lstGvKM.RemoveAt(0);
                for (int i = lstGvKM.Count - 1; i >= 0; i--)
                {
                    if (idSP == Common.IntValue(lstGvKM[i].Cells["IdSanPhamKM"].Value) && mavach.Equals(lstGvKM[i].Cells["MaVachKM"].Value.ToString()))
                    {
                        soluong += Common.IntValue(lstGvKM[i].Cells["SoLuongKM"].Value);
                        lstGvKM.RemoveAt(i);
                    }
                }
                string str = String.Format("Select SoLuong From tbl_HangHoa_Chitiet Where MaVach=N'{0}' and IdKho = {1} and IdSanPham = {2}",
                                            mavach, Declare.IdKho, idSP);
                string sTon = DBTools.getValue(str);
                if (sTon.Equals(""))
                {
                    MessageBox.Show("Trong kho không còn sản phẩm " + tenSP + " có mã vạch " + mavach + "\nBạn không thể bán được");
                    return false;
                }
                else if (Common.IntValue(sTon) < soluong)
                {
                    MessageBox.Show("Sản phẩm " + tenSP + " có mã vạch " + mavach + " chỉ còn " + sTon + "\nKhông đủ hàng để bán (" + soluong + "). Bạn không thể bán được");
                    return false;
                }
            }

            return true;
        }
        private List<ChiTietPhieuXuat> GetChiTietPhieuXuat(GtidCommand sqlcmd, GtidConnection sqlCon)
        {
            DataGridView data = dgvSanPhamBan;
            data.Sort(data.Columns["IdSanPham"], ListSortDirection.Ascending);
            int IdSanPham = 0;
            double GiaBan = 0.0;
            List<ChiTietPhieuXuat> listPX = new List<ChiTietPhieuXuat>();
            ChiTietPhieuXuat detailPX = null;

            foreach (DataGridViewRow dgr in data.Rows)
            {
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
                    detailPX.DonGia = GiaBan;// Common.IntValue(dgr.Cells["DonGia"].Value);
                    detailPX.TyLeChietKhau = Common.DoubleValue(dgr.Cells["TyLeChietKhau"].Value) / TyLe;
                    detailPX.TienChietKhau = Common.DoubleValueInt(dgr.Cells["TienChietKhau"].Value);
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
            DataGridView data = dgvHangKhuyenMai;
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
                    detailPX.TienChietKhau = 0;// -Common.DoubleValue(dgr.Cells["SoTienKM"].Value);
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
                else if (e.KeyCode == Keys.F11 && tsbRefress.Enabled)
                    this.tsbRefress_Click(sender, e);
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

            //string str = "Select sp.TenSanPham, sp.DonGiaCoVAT From vSanPham sp ";
            //str += " Inner Join tbl_HangHoa_Chitiet hh on sp.IdSanPham = hh.IdSanPham";
            //str += " Where hh.MaVach = '" + txtMaVach.Text.Trim() + "'";
            //str += " and sp.IdTrungTam = " + Declare.IdTrungTam;
            try
            {
                DataRow[] row = dtSanPham.Select("MaVach='" + txtMaVach.Text.Trim() + "'");
                if (row.Length > 0)
                {
                    txtTenSanPham.Text = row[0]["TenSanPham"].ToString();
                    txtGiaSanPham.Text = Common.Double2Str((double)row[0]["DonGiaCoVAT"]);
                }
                //DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                //txtTenSanPham.Text = dt.Rows[0]["TenSanPham"].ToString();
                //txtGiaSanPham.Text = Common.Double2Str((double)dt.Rows[0]["DonGiaCoVAT"]);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            //((frmMain)(this.ParentForm)).ShowTTHoaDon(txtMaVach.Text);
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

//        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            try
//            {
//                int index = this.cboKhachHang.SelectedIndex;
//                txtHoTenKhachHang.Text = this.dtKhachHang.Rows[index]["TenDoiTuong"].ToString();
//                txtDiaChi.Text = this.dtKhachHang.Rows[index]["DiaChi"].ToString();
//                txtDienThoai.Text = this.dtKhachHang.Rows[index]["DienThoai"].ToString();
//                txtMaSoThue.Text = this.dtKhachHang.Rows[index]["MaSoThue"].ToString();
//                txtMaKhachHang.Text = this.dtKhachHang.Rows[index]["MaDoiTuong"].ToString();
//                try
//                {
//                    if (this.dtKhachHang.Rows[index]["IdOrderType"] != null)
//                        this.cboOrderType.SelectedValue = (int)this.dtKhachHang.Rows[index]["IdOrderType"];
//                }
//                catch { }
//                LoadDiaChiKH();

//            }
//            catch (System.Exception ex)
//            {
//#if DEBUG
//                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

        private void InputDataFromCode(string code, bool isEnter)
        {
            try
            {
                Utils ut = new Utils();
                int idSPBan = -1;
                string tenSPBan = "";
                string sTrungMV = "";
                int sTTMVChon = 0;
                if (!ut.isStringNotEmpty(code)) return;
                //            string sql = string.Format(@"SELECT IdChiTiet FROM tbl_HangHoa_Chitiet   
                //                            WHERE tbl_HangHoa_Chitiet.MaVach=N'{0}'", code);
                DataRow[] rowSP = dtSanPham.Select("MaVach='" + code + "'");
                if (rowSP.Length == 0)
                {
                    if (MessageBox.Show("Sản phẩm này không còn trong kho hoặc chưa có giá bán.\nBạn có muốn chọn mã vạch khác không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        frm_Chon_SanPham_MaVach frm = new frm_Chon_SanPham_MaVach(txtMaVach, int.Parse(cboKhoXuat.SelectedValue.ToString()));
                        frm.Show();
                        return;
                    }
                    else
                        return;


                }
                else if (rowSP.Length > 1)
                {
                    frmPhieuXuatHangEmei_ChonMaVach frmMV = new frmPhieuXuatHangEmei_ChonMaVach(rowSP);
                    frmMV.ShowDialog();
                    sTTMVChon = frmMV.sTTMVChon;
                    //sTrungMV = rowSP[sTTMVChon]["TrungMaVach"].ToString();
                    //txtTenSanPham.Text = rowSP[sTTMVChon]["TenSanPham"].ToString();
                    //txtGiaSanPham.Text = Common.Double2Str((double)rowSP[sTTMVChon]["DonGiaCoVAT"]);
                    //idSPBan = Common.IntValue(rowSP[sTTMVChon]["IdSanPham"].ToString());

                }

                sTrungMV = rowSP[sTTMVChon]["TrungMaVach"].ToString();
                txtTenSanPham.Text = rowSP[sTTMVChon]["TenSanPham"].ToString();
                txtGiaSanPham.Text = Common.Double2Str((double)rowSP[sTTMVChon]["DonGiaCoVAT"]);

                //Kiem tra trang thai san pham
                //string str = String.Format("Select IdSanPham From tbl_HangHoa_ChiTiet Where MaVach = '{0}' and IdKho = {1} and SoLuong > 0 ",
                //                            code, cboKhoXuat.SelectedValue);

                //if (DBTools.getValue(str).Equals(""))
                //{
                //    MessageBox.Show("Sản phẩm này không còn trong kho, bạn không thể bán được", );
                //    return;
                //}
                //Kiem tra san pham da nhap chua, neu nhap roi thi tang so luong
                bool foundSP = false;
                foreach (DataGridViewRow row in dgvSanPhamBan.Rows)
                {
                    if (row.Cells["MaVach"].Value.ToString().Equals(code))// && idSPBan == Common.IntValue(row.Cells["MaVach"].Value))
                    {
                        //trung voi san pham ban roi va cung co gia roi
                        //idSPBan = Common.IntValue(row.Cells["IdSanPham"].Value.ToString());
                        //str = String.Format("Select case when TrungMaVach is null then 0 else TrungMaVach end TrungMaVach From tbl_SanPham Where IdSanPham = {0}", idSPBan);
                        //if (DBTools.getValue(str).Equals("1"))
                        if (sTrungMV.Equals("1"))
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
                    //str = "Select hh.MaVach,sp.IdSanPham,sp.MaSanPham, sp.TenSanPham," +
                    //          "sp.TenDonViTinh,sp.DonGiaChuaVAT,sp.TyleChietKhau, " +
                    //          "sp.TienChietKhau, sp.TyLeVAT, sp.TienVAT, sp.DonGiaCoVAT, " +
                    //          "sp.TyLeThuong, sp.ThuongNong " +
                    //      " From tbl_HangHoa_Chitiet hh " +
                    //      " inner join vSanPham sp on hh.IdSanPham = sp.IdSanPham " +
                    //      " Where hh.MaVach='" + code + "' and hh.IdKho=" + this.cboKhoXuat.SelectedValue +
                    //        " and sp.IdTrungTam = " + Declare.IdTrungTam;
                    //dt = DBTools.getData("tbl_HangHoa_Chitiet", str).Tables["tbl_HangHoa_Chitiet"];

                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    idSPBan = Common.IntValue(rowSP[sTTMVChon]["IdSanPham"].ToString());
                    tenSPBan = rowSP[sTTMVChon]["TenSanPham"].ToString();
                    int soLuong = 1;
                    double tienSauChietKhau = 0;
                    try
                    {
                        tienSauChietKhau = Common.DoubleValueInt(rowSP[sTTMVChon]["DonGiaChuaVAT"]) - Common.DoubleValueInt(rowSP[sTTMVChon]["TienChietKhau"]);
                    }
                    catch (Exception ex) { }
                    object[] arr ={rowSP[sTTMVChon]["MaVach"], rowSP[sTTMVChon]["IdSanPham"], rowSP[sTTMVChon]["MaSanPham"],
                            rowSP[sTTMVChon]["TenSanPham"], rowSP[sTTMVChon]["TenDonViTinh"], 
                            soLuong, Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["DonGiaChuaVAT"])), Common.Double2Str((double)rowSP[sTTMVChon]["TyLeChietKhau"]*TyLe), Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["TienChietKhau"])), 
                            Common.Double2Str(tienSauChietKhau), Common.Double2Str((double)rowSP[sTTMVChon]["TyLeVAT"]<0?(double)rowSP[sTTMVChon]["TyLeVAT"]:(double)rowSP[sTTMVChon]["TyLeVAT"]*TyLe), Common.Double2Str(Common.DoubleValueInt(rowSP[0]["TienVAT"])), Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["DonGiaCoVAT"])),"",
                            Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["TienChietKhau"])), Common.Double2Str(tienSauChietKhau), Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["TienVAT"])), Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["DonGiaCoVAT"])),
                            rowSP[sTTMVChon]["TyLeThuong"],Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["ThuongNong"])),
                            Common.Double2Str(Common.DoubleValueInt(rowSP[sTTMVChon]["DonGiaChuaVAT"]))};
                    this.dgvSanPhamBan.Rows.Add(arr);

                    DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                    newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(sTrungMV);
                    newRow.Cells["DonGia"].ReadOnly = ! Common.IsEnableCommand("11");//sửa giá bán
                    newRow.Cells["TyLeVAT"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    newRow.Cells["TyleChietKhau"].ReadOnly = !Common.IsEnableCommand("25");//sửa ty le VAT
                    //newRow.Cells["DonGia"].ReadOnly = !Common.IsEnableCommand("11");//sửa giá bán
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Sản phẩm này chưa thiết lập giá bán.\nPhải thiết lập giá trước khi bán!");
                    //    return;
                    //}

                }
                //lay danh sach hang khuyen mai
                //str = "Select distinct km.IdKhuyenMai From vKhuyenMai km " +
                //      "Where km.IdSanPhamBan = " + idSPBan + " and km.IdTrungTam = " + Declare.IdTrungTam;
                //dt = DBTools.getData("KM", str).Tables["KM"];
                GtidCommand sqlcmd = new GtidCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_Nap_KhuyenMai_Header";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdTrungTam", Declare.IdTrungTam);
                sqlcmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                sqlcmd.Parameters.AddWithValue("@IdSanPhamBan", idSPBan);
                DataTable dtKMs = DBTools.getData(sqlcmd, "tmp").Tables["tmp"];

                //DataRow[] rowKM = dtKhuyenMai.Select("IdSanPhamBan = " + idSPBan);
                //if (rowKM.Length > 0)
                if (dtKMs != null && dtKMs.Rows.Count > 0)
                {
                    //frmPhieuXuat_ChonKhuyenMai frmKM = new frmPhieuXuat_ChonKhuyenMai(rowKM);
                    frmPhieuXuat_ChonKhuyenMai frmKM = new frmPhieuXuat_ChonKhuyenMai(dtKMs);
                    frmKM.ShowDialog();
                    int idKhuyenMai = frmKM.IdKhuyenMai;
                    if (idKhuyenMai == 0) return;
                    List<STKhuyenMai> lstMavachKM = frmKM.getMaVachKM();
                    //if (lstMavachKM.Count == 0) return;
                    //DataRow[] dtKM = dtKhuyenMai.Select("IdSanPhamBan = " + idSPBan + " and IdKhuyenMai = " + idKhuyenMai);
                    //str = "Select distinct km.IdSanPhamBan, km.TenSanPhamBan, km.IdSanPham, " +
                    //             "km.MaSanPham, km.TenSanPham, km.TenDonViTinh, km.SoLuong, km.SoTien " +
                    //      "From vKhuyenMai km " +
                    //      "Where km.IdSanPhamBan = " + idSPBan + " and km.IdTrungTam = " + Declare.IdTrungTam + " and km.IdKhuyenMai = " + idKhuyenMai;


                    //dt = DBTools.getData("KM", str).Tables["KM"];

                    //if (dt != null && dt.Rows.Count > 0)
                    if (lstMavachKM.Count > 0)
                    {
                        foreach (STKhuyenMai km in lstMavachKM)
                        {
                            bool found = false;
                            //neu trung thi tang so luong len
                            foreach (DataGridViewRow row in dgvHangKhuyenMai.Rows)
                            {
                                if (idSPBan == int.Parse(row.Cells["IdSanPhamBan"].Value.ToString()) &&
                                    row.Cells["MaVachKM"].Value.ToString().Equals(km.MaVach))
                                {
                                    row.Cells["SoLuongKM"].Value = Common.IntValue(row.Cells["SoLuongKM"].Value.ToString()) + km.SoLuong;
                                    row.Cells["SoTienKM"].Value = Common.Double2Str(Common.DoubleValueInt(row.Cells["SoTienKM"].Value.ToString()) + km.SoTien);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)//nguoc lai thi them moi
                            {
                                object[] arr ={km.MaVach, km.IdSanPham, km.MaSanPham, km.TenSanPham,
                                    idSPBan, tenSPBan, km.DonViTinh, km.SoLuong, Common.Double2Str(km.SoTien)};
                                this.dgvHangKhuyenMai.Rows.Add(arr);

                            }
                            //lstMavachKM.Remove(km);
                            //break;
                        }
                    }
                    //if (dtKM.Length > 0)
                    //{
                    //    for (int i = 0; i <= dtKM.Length - 1; i++)
                    //    {
                    //        foreach (STKhuyenMai km in lstMavachKM)
                    //        {
                    //            if (km.MaSanPham.Equals(dtKM[i]["MaSanPham"]))
                    //            {
                    //                bool found = false;
                    //                //neu trung thi tang so luong len
                    //                foreach (DataGridViewRow row in dgvHangKhuyenMai.Rows)
                    //                {
                    //                    if (idSPBan == (int)row.Cells["IdSanPhamBan"].Value &&
                    //                        row.Cells["MaVachKM"].Value.ToString().Equals(km.MaVach))
                    //                    {
                    //                        row.Cells["SoLuongKM"].Value = Common.IntValue(row.Cells["SoLuongKM"].Value.ToString()) + Common.IntValue(dtKM[i]["SoLuong"].ToString());
                    //                        row.Cells["SoTienKM"].Value = Common.Double2Str(Common.DoubleValueInt(row.Cells["SoTienKM"].Value.ToString()) + Common.DoubleValueInt(dtKM[i]["SoTien"]));
                    //                        found = true;
                    //                        break;
                    //                    }
                    //                }
                    //                if (!found)//nguoc lai thi them moi
                    //                {
                    //                    object[] arr ={km.MaVach, dtKM[i]["IdSanPham"], dtKM[i]["MaSanPham"], dtKM[i]["TenSanPham"],
                    //                        dtKM[i]["IdSanPhamBan"], dtKM[i]["TenSanPhamBan"], dtKM[i]["TenDonViTinh"],
                    //                        dtKM[i]["SoLuong"], Common.Double2Str(Common.DoubleValueInt(dtKM[i]["SoTien"]))};
                    //                    this.dgvHangKhuyenMai.Rows.Add(arr);

                    //                }
                    //                lstMavachKM.Remove(km);
                    //                break;
                    //           }

                    //        }
                    //    }
                    //}
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
            this.Text = "Cập nhật phiếu xuất kho. Đang tạo phiếu xuất mới ...";
        }
        private void LoadOfflineData()
        {
            try
            {
                GtidCommand sqlcmd = new GtidCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_Nap_SanPham";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdTrungTam", Declare.IdTrungTam);
                sqlcmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                dtSanPham = DBTools.getData(sqlcmd, "tmp").Tables["tmp"];

                //string str = "Select hh.MaVach,sp.IdSanPham,sp.MaSanPham, sp.TenSanPham," +
                //          "     sp.TenDonViTinh,sp.DonGiaChuaVAT,sp.TyleChietKhau, " +
                //          "     sp.TienChietKhau, sp.TyLeVAT, sp.TienVAT, sp.DonGiaCoVAT, " +
                //          "     sp.TyLeThuong, sp.ThuongNong, case when sp.TrungMaVach is null then 0 else sp.TrungMaVach end TrungMaVach " +
                //          " From tbl_HangHoa_Chitiet hh " +
                //          "     Inner join vSanPham sp on hh.IdSanPham = sp.IdSanPham and sp.IdTrungTam=" + Declare.IdTrungTam +
                //          "     and hh.IdKho=" + this.cboKhoXuat.SelectedValue +
                //          "   and hh.SoLuong>0 and sp.IdSanPham not in (select IdSanPham from vBangGia where IdKho = " + this.cboKhoXuat.SelectedValue + ")" +
                //          " Union All " +
                //          " Select hh.MaVach,sp.IdSanPham,sp.MaSanPham, sp.TenSanPham," +
                //          "     sp.TenDonViTinh,sp.DonGiaChuaVAT,sp.TyleChietKhau, " +
                //          "     sp.TienChietKhau, sp.TyLeVAT, sp.TienVAT, sp.DonGiaCoVAT, " +
                //          "     sp.TyLeThuong, sp.ThuongNong, case when sp.TrungMaVach is null then 0 else sp.TrungMaVach end TrungMaVach " +
                //          " From tbl_HangHoa_Chitiet hh " +
                //          "     Inner join vBangGia sp on hh.IdSanPham = sp.IdSanPham and sp.IdKho=" + this.cboKhoXuat.SelectedValue +
                //          "     and hh.SoLuong>0 and hh.IdKho = sp.IdKho";

                //dtSanPham = DBTools.getData("tmp", str).Tables["tmp"];
                LoadMaVach();

                //str = "Select distinct km.IdKhuyenMai, km.IdSanPhamBan, km.TenSanPhamBan, km.IdSanPham, " +
                //             "km.MaSanPham, km.TenSanPham, km.TenDonViTinh, km.SoLuong, km.SoTien " +
                //      "From vKhuyenMai km " +
                //      "Where km.IdTrungTam = " + Declare.IdTrungTam + " and km.IdSanPhamBan not in (select IdSanPhamBan from vBangGia_KhuyenMai where IdKho=" +this.cboKhoXuat.SelectedValue+ ") " +
                //      "Union all " +
                //      "Select distinct km.IdKhuyenMai, km.IdSanPhamBan, km.TenSanPhamBan, km.IdSanPham, " +
                //             "km.MaSanPham, km.TenSanPham, km.TenDonViTinh, km.SoLuong, km.SoTien " +
                //      "From vBangGia_KhuyenMai km " +
                //      "Where km.IdKho = " + this.cboKhoXuat.SelectedValue;

                //dtKhuyenMai = DBTools.getData("tmp", str).Tables["tmp"];

                //sqlcmd.CommandText = "sp_Nap_KhuyenMai";
                //sqlcmd.Parameters.Clear();
                //sqlcmd.Parameters.AddWithValue("@IdTrungTam", Declare.IdTrungTam);
                //sqlcmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                //dtKhuyenMai = DBTools.getData(sqlcmd, "tmp").Tables["tmp"];
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

        private void add()
        {
            try
            {
                this.LoadOfflineData();
                this.Updating = true;
                this.setEDItems(true);
                this.setEDUpdate();
                this.PhieuXuat_ThemMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            edit();
            showInfors();
        }
        private void edit()
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
                Updating = true;
                setEDItems(true);
                setEDUpdate();
                if (dtSanPham == null)
                    LoadOfflineData();
            }
        }
        private void setEDItems(bool status)
        {
            this.mstNgayXuat.Enabled = status;
            //this.cboQuyen.Enabled = status;
            //this.txtKyHieu.Enabled = status;
            //this.txtSoSerie.Enabled = status;
            //this.txtSoPhieu.Enabled = status;
            this.txtMaNhanVien.Enabled = status;
            this.cboNhanVien.Enabled = status;
            //this.cboKhachHang.Enabled = status;
            this.txtHoTenKhachHang.Enabled = status;
            //this.txtDiaChi.Enabled = status;
            this.txtDienThoai.Enabled = status;
            //this.txtMaSoThue.Enabled = status;
            this.txtGhiChu.Enabled = status;
            //this.txtMaKhachHang.Enabled = status;
            //this.cboGioiTinh.Enabled = status;
            //this.txtTuoi.Enabled = status;
            //this.txtMaNhanVien.Enabled = status;
            //this.txtBillTo.Enabled = status;
            //this.txtShipTo.Enabled = status;
            //this.cboBillTo.Enabled = status;
            //this.cboShipTo.Enabled = status;
            //this.txtOrderType.Enabled = status;
            //this.cboOrderType.Enabled = status;
            //this.txtOrderTypeKM.Enabled = status;
            //this.cboOrderTypeKM.Enabled = status;
            //this.cboLoaiTien.Enabled = status;
            //this.txtTienThucTra.Enabled = status;
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
            this.btnXoaKhuyenMai.Enabled = status;
            //this.cboHinhThucTT.Enabled = status;
            //this.cboLoaiTra.Enabled = status;
            //this.cboBangKeThue.Enabled = status;
            //this.cboLoaiHoaDon.Enabled = status;
            //this.cboMaDuAn.Enabled = status;
            //this.cboThu.Enabled = status;
        }
        private void setEDFunctions()
        {
            if (IdPhieuXuat == 0)
            {
                this.tsbPrev.Enabled = false;
                this.tsbNext.Enabled = false;
                this.tsbEdit.Enabled = false;
                //this.tsbDelete.Enabled = false;
                //this.tsbPrint.Enabled = false;
            }
            else
            {
                this.tsbPrev.Enabled = IndexPX > 0 ? true : false;
                this.tsbNext.Enabled = IndexPX < (dtPhieuXuat.Rows.Count - 1) ? true : false;
                this.tsbEdit.Enabled = ChuaDayOracle;
                this.tsbDelete.Enabled = ChuaDayOracle;
                this.tsbUpdate.Enabled = ChuaDayOracle;
                this.tsbPrint.Enabled = true;
            }
            this.tsbAdd.Enabled = true;// Common.IsEnableCommandPX(-1);
            this.tsbDelete.Enabled = this.tsbDelete.Enabled & !DaLapHoaDon;
            //this.tsbPrint.Enabled = DaLapHoaDon & this.tsbPrint.Enabled;
        }

        private void setEDUpdate()
        {
            this.tsbAdd.Enabled = !Updating;
            this.tsbEdit.Enabled = !Updating & ChuaDayOracle & !DaLapHoaDon;
            this.tsbUpdate.Enabled = Updating;// &ChuaDayOracle;
            //this.tsbPrint.Enabled = Updating;
            //this.tsbPayment.Enabled = Updating;
        }

        //private void GenerateReceipt(SqlCommand sqlcmd, SqlConnection sqlCon, SqlTransaction sqlTran, List<ChiTietPhieuXuat> hoadon, int LoaiChungTu, int stt)
        //{
        //    //them bang tbl_chungtu
        //    if (stt > 0)
        //        SoSerie = Common.LoadNextHoaDon(stt, (int)cboQuyen.SelectedValue);
        //    int IdChungTu = this.ChungTu_InsertCommand(sqlcmd, sqlCon, sqlTran, hoadon, LoaiChungTu, SoSerie);
        //    //them bang chi tiet
        //    foreach (ChiTietPhieuXuat px in hoadon)
        //    {
        //        //them bang chi tiet chung tu
        //        int idChitietCT = this.ChiTiet_ChungTu_InsertCommand(sqlcmd, sqlCon, sqlTran, IdChungTu, px.IdSanPham, px.SoLuong, px.DonGia,
        //                                                        px.TyLeChietKhau, px.TienChietKhau);
        //        //them bang chi tiet hang hoa
        //        foreach (ChiTietHangHoa hh in px.DsHangHoa)
        //            this.ChiTiet_ChungTu_HangHoa_InsertCommand(sqlcmd, sqlCon, sqlTran, idChitietCT, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau);
        //    }

        //}
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            RecalculateInfors();
            update(false);
            showInfors();
        }

        private bool update(bool print)
        {
            GtidCommand sqlCmd = null;
            string strMsg = "Tạo mới phiếu xuất thành công!";
            bool isAdded = false;
            try
            {
                if (!this.PhieuXuat_SuHopLeCuaThongTin()) return false;

                sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                ConnectionUtil.Instance.BeginTransaction();

                //Cap nhat thong tin chung
                if (this.IdPhieuXuat == 0)
                {
                    //Them header
                    this.PhieuXuat_InsertCommand(sqlCmd);
                    isAdded = true;
                    if (!ValidChiTietDuLieu(sqlCmd, sqlCmd.Connection))
                    {
                        throw new ManagedException("Dữ liệu tồn không đủ để xuất!\nXem lại các mặt hàng xuất bán.");
                    }
                }
                else
                {
                    //sua header
                    this.PhieuXuat_UpdateCommand(sqlCmd);
                    //cap nhat lai bang hang hoa chi tiet
                    CapNhat_HangHoaChiTiet(sqlCmd);
                    //xoa het chi tiet cu
                    this.PhieuXuat_AllDetails_DeleteCommand(sqlCmd);
                    //xoa het cac chung tu tao ra tu phieu xuat nay
                    //this.PhieuXuat_AllChungTu_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                    //xoa het cac phieu thu tao ra tu phieu xuat nay
                    //this.PhieuXuat_AllThuChi_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                    strMsg = "Cập nhật phiếu xuất thành công!";
                    if (!ValidChiTietDuLieu(sqlCmd, sqlCmd.Connection))
                    {
                        throw new Exception("Dữ liệu tồn không đủ để xuất!\nXem lại các mặt hàng xuất bán.");
                    }
                }

                //Them chi tiet san pham ban
                List<ChiTietPhieuXuat> listPX = GetChiTietPhieuXuat(sqlCmd, sqlCmd.Connection);
                foreach (ChiTietPhieuXuat px in listPX)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietPX_InsertCommand(sqlCmd, px.IdSanPham, px.IdSanPhamBan, px.SoLuong, px.DonGia,
                                                                    px.TyLeChietKhau, px.TienChietKhau, px.TyLeVAT, px.TienVAT, px.TyLeThuong, px.ThuongNong, px.GiaTheoBangGia);
                    //them bang chi tiet hang hoa
                    foreach (ChiTietHangHoa hh in px.DsHangHoa)
                        this.ChiTietPX_HangHoa_InsertCommand(sqlCmd, idChitietPX, hh.IdHangHoa, hh.SoLuong, hh.TienChietKhau, hh.TienVAT, hh.ThuongNong, hh.GhiChu);
                }

                //Them chi tiet san pham khuyen mai
                List<ChiTietPhieuXuat> listKM = GetChiTietKhuyenMai(sqlCmd, sqlCmd.Connection);
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
                //listPX.Sort(new BillCompare());
                //listChungTu = new List<HoaDon>();
                //double vat = -1;
                //SoSerie = txtSoSerie.Text;
                //List<ChiTietPhieuXuat> hoadon = null;
                //int stt = 0;
                //foreach (ChiTietPhieuXuat px in listPX)
                //{
                //    double v = px.TyLeVAT;
                //    if (v == vat)
                //        hoadon.Add(px);
                //    else
                //    {
                //        if (hoadon != null)//tao moi hoa don
                //        {
                //            GenerateReceipt(sqlCmd, sqlCon, sqlTran, hoadon, (int)TransactionType.XUAT_BAN, stt);
                //            stt++;
                //        }
                //        vat = v;
                //        hoadon = new List<ChiTietPhieuXuat>();
                //        hoadon.Add(px);
                //    }
                //}
                //if (hoadon != null)//tao moi hoa don
                //{
                //    GenerateReceipt(sqlCmd, sqlCon, sqlTran, hoadon, (int)TransactionType.XUAT_BAN, stt);
                //    stt++;
                //}

                ////Tao hoa don cho cac san pham khuyen mai
                //if (listKM.Count > 0)
                //{
                //    GenerateReceipt(sqlCmd, sqlCon, sqlTran, listKM, (int)TransactionType.XUAT_KHUYEN_MAI, stt);
                //    stt++;
                //}
                
                ////Tao phieu thu
                //ThuChi_InsertCommand(sqlCmd, sqlCon, sqlTran);

                //Common.updateSoHoaDon(SoSerie, (int)cboQuyen.SelectedValue);
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
                //LoadOfflineData();
                
            }
            catch (Exception ex)
            {
                if (isAdded) this.IdPhieuXuat = 0;
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
            delete();
            showInfors();
        }
        private void delete()
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
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn hủy dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNoCancel);
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

                        string sql = "Select NhapHoaDon From tbl_PhieuXuat Where IdPhieuXuat = " + this.IdPhieuXuat;

                        object tmp = DBTools.ExecuteScalar("Select NhapHoaDon From tbl_PhieuXuat Where IdPhieuXuat = " + this.IdPhieuXuat);
                        if (tmp != DBNull.Value)
                        {
                            DaLapHoaDon = (bool)tmp;
                        }
                        if (DaLapHoaDon)
                        {
                            MessageBox.Show("Phiếu Order này đã được xuất hóa đơn, thủ kho không được phép xóa.\nChỉ kế toán mới được phép xóa");
                            return;
                        }
                        GtidCommand sqlCmd = null;
                        try
                        {
                            sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                            ConnectionUtil.Instance.BeginTransaction();
                            //cap nhat lai hang hoa chi tiet
                            CapNhat_HangHoaChiTiet(sqlCmd);
                            //xoa phieu thu
                            //this.PhieuXuat_AllThuChi_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                            //xoa cac chung tu
                            //this.PhieuXuat_AllChungTu_DeleteCommand(sqlCmd, sqlCon, sqlTran);
                            //xoa chi tiet phieu xuat
                            this.PhieuXuat_DeleteCommand(sqlCmd);
                            ConnectionUtil.Instance.CommitTransaction();
                            Common.LogAction("Xóa phiếu xuất thành công", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
                            MessageBox.Show("Hủy phiếu xuất thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Dong trong truong hop sua tu danh sach tim kiem
                            if (this.IndexPXSearch >= 0)
                            {
                                this.dtPXSearch.Rows.RemoveAt(this.IndexPXSearch);
                                this.Close();
                                return;
                            }
                            dtPhieuXuat.Rows.RemoveAt(IndexPX);

                        }
                        catch (Exception ex)
                        {
                            ConnectionUtil.Instance.RollbackTransaction();
                            Common.LogAction("Xóa phiếu xuất thất bại", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
                            MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //if (sqlTran != null)
                            //    sqlTran.Rollback();
                        }
                    }
                }

                //Hien thi du lieu tiep theo
                //if (IndexPX == dtPhieuXuat.Rows.Count)
                //{
                //    IndexPX--;
                //}
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
        }
        //private void tsbPrint_Click(object sender, EventArgs e)
        //{
        //    if (Updating)
        //    {
        //        if (update(true))
        //            print();
        //    }
        //    else
        //    {
        //        LoadChungTu();
        //        print();
        //    }
        //}

        //private void LoadChungTu()
        //{
        //    string str = "select IdChungTu, QuyenSo, SoChungTu, SoSeri,NgayLap, OrderType, BillTo, ShipTo, TongTienHang, " +
        //                 " TongTienChietKhau, TyleVAT, TongTienVAT, TongTienThanhToan, HinhThucThanhToan, HinhThucTra, GhiChu" +
        //                 " from tbl_ChungTu" +
        //                 " where IdPhieuXuat = " + this.IdPhieuXuat;

        //    DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
        //    listChungTu = new List<HoaDon>();
        //    //luu lai danh sach chung tu
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            HoaDon chungtu = new HoaDon(Common.IntValue(row["IdChungTu"]), Common.IntValue(row["QuyenSo"]), row["SoChungTu"].ToString(), row["SoSeri"].ToString(), this.mstNgayXuat.Value, "", "", "", "", this.cboNhanVien.SelectedText,
        //                                 this.txtHoTenKhachHang.Text, (int)this.cboGioiTinh.SelectedIndex, Common.IntValue(this.txtTuoi.Text.Trim()), this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text, Common.IntValue(row["OrderType"]), Common.IntValue(row["BillTo"]), Common.IntValue(row["ShipTo"]),
        //                                  Common.DoubleValue(row["TongTienHang"]), Common.DoubleValue(row["TongTienChietKhau"]), Common.DoubleValue(row["TyleVAT"]), Common.DoubleValue(row["TongTienVAT"]), Common.DoubleValue(row["TongTienThanhToan"]), Declare.KyHieuTienTe, row["HinhThucThanhToan"].ToString(), Common.IntValue(row["HinhThucTra"]), row["GhiChu"].ToString());
        //            listChungTu.Add(chungtu);
        //        }
        //    }

        //    //load IdPhieuThu
        //    str = "select IdPhieu from tbl_ThuChi where ChungTuGoc in " +
        //          " (select SoPhieuXuat from tbl_PhieuXuat where IdPhieuXuat = " + this.IdPhieuXuat + ")";

        //    dt = DBTools.getData("tmp", str).Tables["tmp"];
        //    if (dt != null && dt.Rows.Count > 0)
        //        this.IdPhieuThu = Common.IntValue(dt.Rows[0]["IdPhieu"]);
        //    else
        //        this.IdPhieuThu = 0;
        //}

        //private void print()
        //{
        //    string str = "Select kh.MaKho, kh.TenKho, kh.DiaChi, kh.DienThoai, tt.TenTrungTam " +
        //                 " From tbl_DM_Kho kh inner join tbl_DM_TrungTam tt on tt.IdTrungTam = kh.IdTrungTam" +
        //                 " Where kh.IdKho = " + this.cboKhoXuat.SelectedValue;

        //    DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
        //    string kho = dtKho.Rows[0]["MaKho"].ToString() + " - " + dtKho.Rows[0]["TenKho"].ToString();
        //    string khachhang = cboKhachHang.SelectedValue.ToString() + " - " + txtHoTenKhachHang.Text;

        //    PhieuXuat px = new PhieuXuat(this.IdPhieuXuat, this.txtSoPhieu.Text, this.mstNgayXuat.Value, dtKho.Rows[0]["TenTrungTam"].ToString(), kho, dtKho.Rows[0]["DiaChi"].ToString(),
        //                     dtKho.Rows[0]["DienThoai"].ToString(), this.cboNhanVien.SelectedText, khachhang, this.txtDiaChi.Text, this.txtDienThoai.Text, this.txtMaSoThue.Text,
        //                    Common.DoubleValue(this.txtTongTienHang.Text.Trim()), Common.DoubleValue(this.txtTongTienCK.Text.Trim()), Common.DoubleValue(this.txtTongTienVAT.Text.Trim()),
        //                    Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()), Common.DoubleValue(this.txtTienThucTra.Text.Trim()), Common.DoubleValue(this.txtTienConNo.Text.Trim()),
        //                    Declare.KyHieuTienTe, ThanhToan[cboHinhThucTT.SelectedIndex], this.txtGhiChu.Text);
        //    frmPhieuXuat_LuaChonIn frmInPX = new frmPhieuXuat_LuaChonIn(px, listChungTu, IdPhieuThu);
        //    frmInPX.ShowDialog();
        //    QLBanHang.Class.Common.LogAction("In phiếu xuất", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
        //}
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            search();
            showInfors();
        }

        private void search()
        {
            int[] IdPhieu = new int[] { 0 };
            frmTimPhieuXuat frm = new frmTimPhieuXuat((int)TransactionType.XUAT_BAN, IdPhieu);
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
            //frm.MdiParent = this.ParentForm;
            //this.Close();            
        }

        //private void tsbPayment_Click(object sender, EventArgs e)
        //{
        //    payment();
        //}
        //private void payment()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    //ket qua
        //    if (this.cboHinhThucTT.SelectedIndex == 0)//tien mat
        //    {
        //        frmPhieuXuat_TraTienThua frm = new frmPhieuXuat_TraTienThua(this.txtTongTienThanhToan.Text,
        //                        this.txtTienThucTra.Text, this.txtTienConNo.Text, Declare.KyHieuTienTe, Common.IntValue(cboLoaiTra.SelectedValue));
        //        //frm.MdiParent = this.ParentForm;
        //        frm.ShowDialog();

        //        this.txtTienThucTra.Text = frm.txtTienThucTra.Text;
        //        double tienThanhToan = Common.DoubleValue(this.txtTongTienThanhToan.Text);
        //        double tienThucTra = Common.DoubleValue(this.txtTienThucTra.Text);
        //        double tienConNo = tienThanhToan - tienThucTra;
        //        if (tienConNo > 0)
        //            this.txtTienConNo.Text = Common.Double2Str(tienConNo);
        //        else
        //            this.txtTienConNo.Text = Common.Double2Str(0);
        //    }
        //    else//chuyen khoan
        //    {
        //        frmPhieuXuat_ChuyenKhoan frm = new frmPhieuXuat_ChuyenKhoan(this.txtTongTienThanhToan.Text,
        //        this.txtTienThucTra.Text, this.txtTienConNo.Text, Declare.KyHieuTienTe, SoTaiKhoan, NganHang, (int)this.cboLoaiTra.SelectedValue);
        //        //frm.MdiParent = this.ParentForm;
        //        frm.ShowDialog();

        //        SoTaiKhoan = frm.txtSoTaiKhoan.Text;
        //        NganHang = frm.txtNganHang.Text;
        //        cboLoaiTra.SelectedValue = frm.cboHinhThucTra.SelectedValue;
        //        txtTienConNo.Text = frm.txtTienConNo.Text;
        //    }
        //    this.Cursor = Cursors.Default;
        //    QLBanHang.Class.Common.LogAction("Trả tiền thừa mua hàng", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu xuất = " + txtSoPhieu.Text, Declare.IdKho);
        //}
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
                double tienKM = Common.DoubleValueInt(row.Cells["SoTienKM"].Value.ToString());
                int IdBan = Common.IntValue(row.Cells["IdSanPhamBan"].Value.ToString());
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

        //private void cboHinhThucTT_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cboHinhThucTT.SelectedIndex == 0)
        //        txtTienThucTra.Enabled = true;
        //    else
        //        txtTienThucTra.Enabled = false;
        //}

        //private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtOrderType.Text = dtOrderType.Rows[cboOrderType.SelectedIndex]["Code"].ToString();
        //    }
        //    catch { }
        //}

        //private void cboBillTo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtBillTo.Text = dtDiaChi.Rows[cboBillTo.SelectedIndex]["SiteNumber"].ToString();
        //        if (txtDiaChi.Text.Trim().Length == 0)
        //            txtDiaChi.Text = cboBillTo.Text;
        //    }
        //    catch { }
        //}

        //private void cboShipTo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtShipTo.Text = dtDiaChi.Rows[cboShipTo.SelectedIndex]["SiteNumber"].ToString();
        //    }
        //    catch { }
        //}

        //private void txtBillTo_TextChanged(object sender, EventArgs e)
        //{
        //    for (int i=0; i<dtDiaChi.Rows.Count; i++)
        //    {
        //        if (txtBillTo.Text.Equals(dtDiaChi.Rows[i]["SiteNumber"].ToString()))
        //        {
        //            cboBillTo.SelectedIndex = i;
        //            break;
        //        }
        //    }
        //}

        //private void txtShipTo_TextChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < dtDiaChi.Rows.Count; i++)
        //    {
        //        if (txtShipTo.Text.Equals(dtDiaChi.Rows[i]["SiteNumber"].ToString()))
        //        {
        //            cboShipTo.SelectedIndex = i;
        //            break;
        //        }
        //    }
        //}

        //private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txtMaNhanVien.Text = dtNhanVien.Rows[cboNhanVien.SelectedIndex]["MaNhanVien"].ToString();
        //}

        //private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        //{
        //    bool found = false;
        //    for (int i = 0; i < dtKhachHang.Rows.Count; i++)
        //    {
        //        if (txtMaKhachHang.Text.Equals(dtKhachHang.Rows[i]["MaDoiTuong"].ToString()))
        //        {
        //            cboKhachHang.SelectedIndex = i;
        //            found = true;
        //            break;
        //        }
        //    }
        //    if (!found)
        //    {
        //        cboKhachHang.Text = "";
        //        txtBillTo.Text = "";
        //        cboBillTo.Text = "";
        //        txtShipTo.Text = "";
        //        cboShipTo.Text = "";
        //        txtOrderType.Text = "";
        //        cboOrderType.Text = "";
        //        txtOrderTypeKM.Text = "";
        //        cboOrderTypeKM.Text = "";
        //    }
        //}

        //private void txtMaNhanVien_TextChanged(object sender, EventArgs e)
        //{
        //    bool found = false;
        //    for (int i = 0; i < dtNhanVien.Rows.Count; i++)
        //    {
        //        if (txtMaNhanVien.Text.Equals(dtNhanVien.Rows[i]["MaNhanVien"].ToString()))
        //        {
        //            cboNhanVien.SelectedIndex = i;
        //            found = true;
        //            break;
        //        }
        //    }
        //    if (!found)
        //        cboNhanVien.Text = "";
        //}

        //private void txtOrderType_TextChanged(object sender, EventArgs e)
        //{
        //    bool found = false;
        //    for (int i = 0; i < dtOrderType.Rows.Count; i++)
        //    {
        //        if (txtOrderType.Text.Equals(dtOrderType.Rows[i]["Code"].ToString()))
        //        {
        //            cboOrderType.SelectedIndex = i;
        //            found = true;
        //            break;
        //        }
        //    }
        //    if (!found)
        //        cboOrderType.Text = "";
        //}

        //private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadHoaDon();
        //}

        //private void cboKhachHang_TextUpdate(object sender, EventArgs e)
        //{
        //    if (cboKhachHang.Text.Trim().Length == 0)
        //    {
        //        txtMaKhachHang.Text = "";
        //        txtBillTo.Text = "";
        //        cboBillTo.Text = "";
        //        txtShipTo.Text = "";
        //        cboShipTo.Text = "";
        //        txtOrderType.Text = "";
        //        cboOrderType.Text = "";
        //        txtOrderTypeKM.Text = "";
        //        cboOrderTypeKM.Text = "";
        //    }
        //}

        //private void cboNhanVien_TextUpdate(object sender, EventArgs e)
        //{
        //    if (cboNhanVien.Text.Trim().Length == 0)
        //        txtMaNhanVien.Text = "";
        //}

        //private void cboBillTo_TextUpdate(object sender, EventArgs e)
        //{
        //    if (cboBillTo.Text.Trim().Length == 0)
        //        txtBillTo.Text = "";
        //}

        //private void cboShipTo_TextUpdate(object sender, EventArgs e)
        //{
        //    if (cboShipTo.Text.Trim().Length == 0)
        //        txtShipTo.Text = "";
        //}

        //private void cboOrderType_TextUpdate(object sender, EventArgs e)
        //{
        //    if (cboOrderType.Text.Trim().Length == 0)
        //        txtOrderType.Text = "";
        //}

        private void txtMaVach_Enter(object sender, EventArgs e)
        {
            this.txtMaVach.Focus();
            this.txtMaVach.SelectAll();
        }

        //private void cboNhanVien_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void cboNhanVien_Leave(object sender, EventArgs e)
        //{
        //    if (cboNhanVien.Text.Trim().Length > 0)
        //    {
        //        bool found = false;
        //        for (int i = 0; i < dtNhanVien.Rows.Count; i++)
        //        {
        //            if (dtNhanVien.Rows[i]["HoTen"].ToString().ToLower().Equals(cboNhanVien.Text.Trim().ToLower()))
        //            {
        //                cboKhachHang.SelectedIndex = i;
        //                found = true;
        //                break;
        //            }
        //        }
        //        if (!found)
        //        {
        //            MessageBox.Show("Nhân viên này không có trong danh sách, chọn nhân viên khác");
        //            cboNhanVien.Text = "";
        //        }
        //    }
        //}


        //private void cboKhachHang_Leave(object sender, EventArgs e)
        //{
        //    if (cboKhachHang.Text.Trim().Length > 0)
        //    {
        //        bool found = false;
        //        for (int i = 0; i < dtKhachHang.Rows.Count; i++)
        //        {
        //            if (dtKhachHang.Rows[i]["TenDoiTuong"].ToString().ToLower().Equals(cboKhachHang.Text.Trim().ToLower()))
        //            {
        //                cboKhachHang.SelectedIndex = i;
        //                found = true;
        //                break;
        //            }
        //        }
        //        if (!found)
        //        {
        //            MessageBox.Show("Khách hàng này không có trong danh sách, chọn khách hàng khác");
        //            cboKhachHang.Text = "";
        //        }
        //    }
        //}

        private void dgvSanPhamBan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSanPhamBan.CurrentRow != null)
            {
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

        private void btnTimOrderKH_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                DataTable dt;

                str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.QuyenSo,px.KyHieu,px.SoSerie,px.IdKho,kh.TenKho,px.IdNhanVien,px.IdKhachHang,px.HoTen,px.GioiTinh,px.DoTuoi,px.DiaChi," +
                             "px.DienThoai, px.MaSoThue,px.SoTaiKhoan,px.NganHang,px.OrderType,px.OrderTypeKM,px.BillTo,px.ShipTo,px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                             "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.HinhThucThanhToan,px.HinhThucTra,px.IdBangKeThue,px.IdLoaiHDBanHang,px.IdDuAn,px.SoOrderKH,px.NhapHoaDon " +
                      "from tbl_PhieuXuat px inner join tbl_dm_kho kh on px.IdKho = kh.IdKho " +
                      "where SoOrderKH='" + txtSoOrderKH.Text.Trim() + "'";

                dt = DBTools.getData("Tmp", str).Tables["Tmp"];
                dgvSanPhamBan.Rows.Clear();
                dgvHangKhuyenMai.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (Declare.IdKho != Common.IntValue(dt.Rows[0]["IdKho"]))
                    {
                        MessageBox.Show("Giao dịch này xuất ở kho [" + dt.Rows[0]["TenKho"].ToString() + "].\nBạn không thể xem được.\nHãy thiết lập lại kho hiện tại về kho [" + dt.Rows[0]["TenKho"].ToString() + "]");
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
                              "WHERE IdPhieuXuat=" + this.IdPhieuXuat + " and IdSanPhamBan is null ";
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
                            newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + dt.Rows[i]["IdSanPham"]));
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
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void dgvSanPhamBan_Leave(object sender, EventArgs e)
        {
            dgvSanPhamBan.EndEdit();
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

        private void frmPhieuXuatHangEmei_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((IMain)(this.ParentForm)).ShowTTHoaDon("");
            frmTimPhieuXuat.SQLSearch = "";
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
                print();
            }
            showInfors();
        }

        private void print()
        {
            ShowReport("In phiếu xuất");
            ShowReport("In phiếu xuất chi tiết theo IMEI");
            Common.LogAction("In phiếu xuất thủ kho", "Số phiếu xuất = " + this.txtSoPhieu.Text, Declare.IdKho);

        }

        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            string str = "Select kh.MaKho, kh.TenKho, kh.DiaChi, kh.DienThoai, tt.TenTrungTam " +
                         " From tbl_DM_Kho kh inner join tbl_DM_TrungTam tt on tt.IdTrungTam = kh.IdTrungTam" +
                         " Where kh.IdKho = " + this.cboKhoXuat.SelectedValue;

            DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
            string kho = dtKho.Rows[0]["MaKho"].ToString() + " - " + dtKho.Rows[0]["TenKho"].ToString();

            myParams.Clear();
            switch (base.Key)
            {
                case "In phiếu xuất":
                    ut.SetParameterReport(myParams, "TrungTam", dtKho.Rows[0]["TenTrungTam"].ToString());
                    ut.SetParameterReport(myParams, "Kho", kho);
                    ut.SetParameterReport(myParams, "DiaChiKho", dtKho.Rows[0]["DiaChi"].ToString());
                    ut.SetParameterReport(myParams, "DienThoai", dtKho.Rows[0]["DienThoai"].ToString());
                    ut.SetParameterReport(myParams, "TenNhanVien", this.cboNhanVien.SelectedText);
                    ut.SetParameterReport(myParams, "TenKhachHang", "");
                    ut.SetParameterReport(myParams, "DiaChiKH", "");
                    ut.SetParameterReport(myParams, "DienThoaiKH", "");
                    ut.SetParameterReport(myParams, "MaSoThueKH", "");
                    ut.SetParameterReport(myParams, "NoiDungXuat", this.txtGhiChu.Text);
                    ut.SetParameterReport(myParams, "NgayXuat", String.Format("Ngày {0} tháng {1} năm {2}", this.mstNgayXuat.Value.Day, this.mstNgayXuat.Value.Month, this.mstNgayXuat.Value.Year));
                    ut.SetParameterReport(myParams, "SoPhieuXuat", this.txtSoPhieu.Text);
                    ut.SetParameterReport(myParams, "TongTienHang", Common.DoubleValue(this.txtTongTienHang.Text.Trim()));
                    ut.SetParameterReport(myParams, "TongTienChietKhau", Common.DoubleValue(this.txtTongTienCK.Text.Trim()));
                    ut.SetParameterReport(myParams, "TongTienVAT", Common.DoubleValue(this.txtTongTienVAT.Text.Trim()));
                    ut.SetParameterReport(myParams, "TongTienThanhToan", Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()));
                    ut.SetParameterReport(myParams, "TongTienChu", Common.ReadNumner_(Common.Double2Str(Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()))));
                    ut.SetParameterReport(myParams, "HinhThucThanhToan", "");
                    ut.SetParameterReport(myParams, "TongTienThanhToan", Common.DoubleValue(this.txtTongTienThanhToan.Text.Trim()));
                    ut.SetParameterReport(myParams, "TienThucTra", Common.DoubleValue(this.txtTienThucTra.Text.Trim()));
                    ut.SetParameterReport(myParams, "TienConNo", Common.DoubleValue(this.txtTienConNo.Text.Trim()));
                    ut.SetParameterReport(myParams, "TienTe", Declare.KyHieuTienTe);
                    break;
                case "In phiếu xuất chi tiết theo IMEI":
                    ut.SetParameterReport(myParams, "TrungTam", dtKho.Rows[0]["TenTrungTam"].ToString());
                    ut.SetParameterReport(myParams, "Kho", kho);
                    ut.SetParameterReport(myParams, "DiaChiKho", dtKho.Rows[0]["DiaChi"].ToString());
                    ut.SetParameterReport(myParams, "DienThoai", dtKho.Rows[0]["DienThoai"].ToString());
                    ut.SetParameterReport(myParams, "TenNhanVien", this.cboNhanVien.SelectedText);
                    ut.SetParameterReport(myParams, "TenKhachHang", "");
                    ut.SetParameterReport(myParams, "DiaChiKH", "");
                    ut.SetParameterReport(myParams, "DienThoaiKH", "");
                    ut.SetParameterReport(myParams, "MaSoThueKH", "");
                    ut.SetParameterReport(myParams, "NoiDungXuat", this.txtGhiChu.Text);
                    ut.SetParameterReport(myParams, "NgayXuat", String.Format("Ngày {0} tháng {1} năm {2}", this.mstNgayXuat.Value.Day, this.mstNgayXuat.Value.Month, this.mstNgayXuat.Value.Year));
                    ut.SetParameterReport(myParams, "SoPhieuXuat", this.txtSoPhieu.Text);
                    ut.SetParameterReport(myParams, "MaKho", dtKho.Rows[0]["MaKho"].ToString());
                    break;
                default:
                    break;
            }
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            return String.Format(cmdTextFormatString, this.IdPhieuXuat);
        }
        protected override void OnLoadReport()
        {
            string sql = "";
            switch (base.Key)
            {
                case "In phiếu xuất":
                    rpt = new rptPhieuXuat_TKho();
                    sql = "SELECT MaVach,MaSanPham,TenSanPham,TenDonViTinh,DonGia,TyLeChietKhau,Case When TyleVAT < 0 Then 0 Else TyleVat End As TyleVat,ThanhTien,sum(SoLuong) SoLuong" +
                          " FROM vChiTietPhieuXuat where IdPhieuXuat={0}" +
                          " GROUP BY MaVach,MaSanPham,TenSanPham,TenDonViTinh,DonGia,TyLeChietKhau,TyleVAT,ThanhTien";
                    base.SetSqlParameters(sql, CommandType.Text, "vChiTietPhieuXuat");
                    break;
                case "In phiếu xuất chi tiết theo IMEI":
                    rpt = new rptPhieuXuat_IEMI_TKho();
                    sql = "SELECT MaVach,MaSanPham,TenSanPham,TenDonViTinh,sum(SoLuong) SoLuong" +
                          " FROM vChiTietPhieuXuat where IdPhieuXuat={0}" +
                          " GROUP BY MaVach,MaSanPham,TenSanPham,TenDonViTinh";
                    base.SetSqlParameters(sql, CommandType.Text, "vChiTietPhieuXuat");
                    break;

                default:
                    break;
            }
            base.SetParameterFields();
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNhanVien.Text = dtNhanVien.Rows[cboNhanVien.SelectedIndex]["MaNhanVien"].ToString();
            }
            catch { txtMaNhanVien.Text = ""; }
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

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMaNhanVien_Leave(sender, e);
            }
        }

        private void tsbRefress_Click(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }

        private void txtSoOrderKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnTimOrderKH_Click(sender, e);
            }
        }
        //private void txtOrderTypeKM_TextChanged(object sender, EventArgs e)
        //{
        //    bool found = false;
        //    for (int i = 0; i < dtOrderTypeKM.Rows.Count; i++)
        //    {
        //        if (txtOrderTypeKM.Text.Equals(dtOrderTypeKM.Rows[i]["Code"].ToString()))
        //        {
        //            cboOrderTypeKM.SelectedIndex = i;
        //            found = true;
        //            break;
        //        }
        //    }
        //    if (!found)
        //        cboOrderTypeKM.Text = "";
        //}

        //private void cboOrderTypeKM_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtOrderTypeKM.Text = dtOrderTypeKM.Rows[cboOrderTypeKM.SelectedIndex]["Code"].ToString();
        //    }
        //    catch { }
        //}

        //private void cboOrderTypeKM_TextUpdate(object sender, EventArgs e)
        //{
        //    if (cboOrderTypeKM.Text.Trim().Length == 0)
        //        txtOrderTypeKM.Text = "";
        //}

        //private void btnLoadQuyen_Click(object sender, EventArgs e)
        //{
        //    LoadQuyen();
        //}

        //private void tabInfors_Selecting(object sender, TabControlCancelEventArgs e)
        //{
        //    e.Cancel = true;
        //}
    }
}