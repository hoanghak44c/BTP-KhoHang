using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Forms
{
    public partial class frmTimPhieuXuat : Form
    {
#region "Khai báo biến"
        DataTable dtPX;
        DataTable dtKhachHang;
        public int LoaiXuatNhap = (int)TransactionType.XUAT_BAN;
        public static string SQLSearch = "";
        int[] _IdPhieu;
#endregion

#region "Các phương thức khởi tạo"
        public frmTimPhieuXuat()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dgvPhieuXuat.Columns["NgayXuat"].DefaultCellStyle.Format = new System.Globalization.CultureInfo("vi-VN").DateTimeFormat.ShortDatePattern;
        }
        public frmTimPhieuXuat(int LoaiPhieu)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dgvPhieuXuat.Columns["NgayXuat"].DefaultCellStyle.Format = new System.Globalization.CultureInfo("vi-VN").DateTimeFormat.ShortDatePattern;
            this.LoaiXuatNhap = LoaiPhieu;
            if (this.LoaiXuatNhap == (int)TransactionType.XUAT_BAN)
                lblTieuDe.Text = "TÌM KIẾM PHIẾU XUẤT";
            else if (this.LoaiXuatNhap == (int)TransactionType.NHAP_TRA_LAI)
                lblTieuDe.Text = "TÌM KIẾM PHIẾU NHẬP TRẢ LẠI";
            else if (this.LoaiXuatNhap == (int)TransactionType.XUAT_KHAC)
                lblTieuDe.Text = "TÌM KIẾM PHIẾU XUẤT KHÁC";
        }
        public frmTimPhieuXuat(int LoaiPhieu, int[] IdPhieu)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dgvPhieuXuat.Columns["NgayXuat"].DefaultCellStyle.Format = new System.Globalization.CultureInfo("vi-VN").DateTimeFormat.ShortDatePattern;
            this.LoaiXuatNhap = LoaiPhieu;
            if (this.LoaiXuatNhap == (int)TransactionType.XUAT_BAN)
                lblTieuDe.Text = "TÌM KIẾM PHIẾU XUẤT";
            else if (this.LoaiXuatNhap == (int)TransactionType.NHAP_TRA_LAI)
                lblTieuDe.Text = "TÌM KIẾM PHIẾU NHẬP TRẢ LẠI";
            else if (this.LoaiXuatNhap == (int)TransactionType.XUAT_KHAC)
                lblTieuDe.Text = "TÌM KIẾM PHIẾU XUẤT KHÁC";
            _IdPhieu = IdPhieu;
        } 
#endregion

#region "Các phương thức"
        private void LoadComboBoxData()
        {
            
            LoadKhoXuat();
            LoadKhachHang();
            LoadNhanVien();
        }
        private void LoadKhachHang()
        {
            string str = "Select IdDoiTuong, MaDoiTuong, TenDoiTuong, DiaChi, DienThoai, MaSoThue " +
                  "from tbl_DM_DoiTuong " +
                  "where SuDung = 1 and Type <> 2 and (MaVung is null or MaVung like '%' + (Select MaVung From tbl_DM_Kho Where IdKho = " + Declare.IdKho + ") + '%')" +
                  "order by TenDoiTuong ASC";
            dtKhachHang = DBTools.getData("tbl_DM_DoiTuong", str).Tables["tbl_DM_DoiTuong"];
            if (dtKhachHang != null)
            {
                DataRow r = dtKhachHang.NewRow();
                r[0] = -1;
                r[1] = "";
                dtKhachHang.Rows.InsertAt(r, 0);
                //this.dtKhachHang.Constraints.Add("fg_KhachHang", dtKhachHang.Columns["IdKhachHang"], true);
                this.cboKhachHang.DataSource = dtKhachHang;
                this.cboKhachHang.DisplayMember = "TenDoiTuong";
                this.cboKhachHang.ValueMember = "IdDoiTuong";
                this.cboKhachHang.SelectedValue = Declare.IdKHMacDinh;
            }
        }
        private void LoadKhoXuat()
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
                if (Declare.IdKho != 0)
                    this.cboKhoXuat.SelectedValue = Declare.IdKho;
            }
        }
        private void LoadNhanVien()
        {
            string str = "Select DISTINCT nv.IdNhanVien, nv.MaNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                  " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien " +
                  " Where knv.IdKho in ( Select knv1.idKho From tbl_Kho_NhanVien knv1 " +
                  " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv1.IdNhanVien " +
                  " Where nd.IdNguoiDung = " + Declare.UserId + ") and (nv.SuDung = 1)  order by nv.HoTen ASC";

            DataTable dtNhanVien = DBTools.getData("tbl_DM_NhanVien", str).Tables["tbl_DM_NhanVien"];
            if (dtNhanVien != null)
            {
                DataRow r = dtNhanVien.NewRow();
                r[0] = -1;
                r[1] = "";
                dtNhanVien.Rows.InsertAt(r, 0);
                //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                this.cboNhanVien.DataSource = dtNhanVien;
                this.cboNhanVien.DisplayMember = "HoTen";
                this.cboNhanVien.ValueMember = "IdNhanVien";
                if (Declare.IdNhanVien != 0)
                    this.cboNhanVien.SelectedValue = Declare.IdNhanVien;
                else
                    this.cboNhanVien.SelectedIndex = 0;
            }
        }

        private string TimPhieuXuat_ChuoiLoc()
        {
            string str1 = "";
            string str = "select distinct px.IdPhieuXuat,px.SoOrderKH,px.SoPhieuXuat,px.NgayXuat,case when (px.NhapHoaDon is null or px.NhapHoaDon=0) and px.SoSerie is not null then N'Hủy hóa đơn' when (px.NhapHoaDon is null or px.NhapHoaDon=0) and px.SoSerie is null then N'Chưa xuất hóa đơn' else N'Đã xuất hóa đơn' end NhapHoaDon, ";
            str += " kh.TenDoiTuong + ' - ' + px.HoTen TenKhachHang,nv.HoTen TenNhanVien ";
            str += " from tbl_PhieuXuat px";
            str += " left join tbl_DM_DoiTuong kh on kh.IdDoiTuong = px.IdKhachHang ";
            str += " left join tbl_DM_NhanVien nv on nv.IdNhanVien = px.IdNhanVien ";

            if (this.txtMaSanPham.Text.Trim().Length > 0 || this.txtTenSanPham.Text.Trim().Length > 0)
            {
                str += " inner join tbl_PhieuXuat_ChiTiet pxct on px.IdPhieuXuat = pxct.IdPhieuXuat ";
                str += " inner join tbl_SanPham sp on pxct.IdSanPham = sp.IdSanPham ";
            }

            if (this.txtMaVach.Text.Trim().Length > 0)
            {
                if (this.txtMaSanPham.Text.Trim().Length > 0 || this.txtTenSanPham.Text.Trim().Length > 0)
                {
                    str += " inner join tbl_PhieuXuat_ChiTiet_hanghoa pxcthh on pxct.IdChiTiet = pxcthh.IdChiTietPhieuXuat ";
                    str += " inner join tbl_hanghoa_chitiet hhct on pxcthh.IdChiTietHangHoa = hhct.IdChiTiet ";
                }
                else
                {
                    str += " inner join tbl_PhieuXuat_ChiTiet pxct on px.IdPhieuXuat = pxct.IdPhieuXuat ";
                    str += " inner join tbl_PhieuXuat_ChiTiet_hanghoa pxcthh on pxct.IdChiTiet = pxcthh.IdChiTietPhieuXuat ";
                    str += " inner join tbl_hanghoa_chitiet hhct on pxcthh.IdChiTietHangHoa = hhct.IdChiTiet ";
                }
            }
            if (txtSoSerie.Text.Trim().Length > 0)
            {
                str += " inner join tbl_chungtu ctu on ctu.IdPhieuXuat = px.IdPhieuXuat ";
            }

            str += " Where (1=1) ";
            str += " and LoaiXuatNhap = " + this.LoaiXuatNhap;
            //str += //" and px.ThoigianSua > convert(datetime,'" + Common.Date2LongString(Declare.NgayKhoaSo) + "',121) " +
            //       " and px.ThoigianSua >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103)";

            if (txtSoOrderKH.Text.Trim().Length > 0)
                str += " and px.SoOrderKH = N'" + this.txtSoOrderKH.Text.Trim() + "'";

            if (cboTrangThai.SelectedIndex == 2)
                str += " and px.NhapHoaDon = 1 and px.ThoigianSua >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103)";
            else if (cboTrangThai.SelectedIndex == 1)
                str += " and (px.NhapHoaDon IS NULL or px.NhapHoaDon=0) ";
            else
                str += " and (px.NhapHoaDon IS NULL or px.NhapHoaDon=0 or px.ThoigianSua >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103))";

            if (txtSoPhieu.Text.Trim().Length > 0)
            {
                if (this.LoaiXuatNhap == (int)TransactionType.NHAP_TRA_LAI)
                    str += " and (px.SoPhieuXuat like N'%" + this.txtSoPhieu.Text.Trim() + "%' or px.SoPhieuXuatGoc like N'%" + this.txtSoPhieu.Text.Trim() + "%') ";
                else
                    str += " and px.SoPhieuXuat like N'%" + this.txtSoPhieu.Text.Trim() + "%'";
            }

            if (txtSoSerie.Text.Trim().Length > 0)
            {
                str += " and (ctu.SoSeri like N'%" + this.txtSoSerie.Text.Trim() + "%'";
                str += " or px.SoSerie like N'%" + this.txtSoSerie.Text.Trim() + "%'";
                str += " or px.SoSerieKM like N'%" + this.txtSoSerie.Text.Trim() + "%') ";
            }

            if (mstTuNgay.Text.Trim().Length > 0)
                str += string.Format(" and px.NgayXuat >= convert(datetime,'{0}',103) ", Common.Date2String(mstTuNgay.Value));

            if (mstDenNgay.Text.Trim().Length > 0)
                str += string.Format(" and convert(varchar,px.NgayXuat,101) <= convert(datetime,'{0}',103) ", Common.Date2String(mstDenNgay.Value));

            if (Common.IntValue(this.cboKhoXuat.SelectedValue) > 0)
                str += " and px.IdKho=" + this.cboKhoXuat.SelectedValue.ToString();

            if (Common.IntValue(this.cboNhanVien.SelectedValue) > 0)
                str += " and px.IdNhanVien=" + this.cboNhanVien.SelectedValue.ToString();

            if (Common.IntValue(this.cboKhachHang.SelectedValue) > 0)
                str += " and px.IdKhachHang=" + this.cboKhachHang.SelectedValue.ToString();

            if (this.txtHoTenKhachHang.Text.Trim().Length > 0)
                str += " and px.HoTen like N'%" + this.txtHoTenKhachHang.Text.Trim() + "%'";

            if (this.txtDiaChi.Text.Trim().Length > 0)
                str += " and px.DiaChi like N'%" + this.txtDiaChi.Text.Trim() + "%'";

            if (this.txtMaSoThue.Text.Trim().Length > 0)
                str += " and px.MaSoThue like N'%" + this.txtMaSoThue.Text.Trim() + "%'";

            if (this.txtDienThoai.Text.Trim().Length > 0)
                str += " and px.DienThoai like N'%" + this.txtDienThoai.Text.Trim() + "%'";

            if (this.txtGhiChu.Text.Trim().Length > 0)
                str += " and px.GhiChu like N'%" + this.txtGhiChu.Text.Trim() + "%'";

            if (this.txtMaSanPham.Text.Trim().Length > 0)
                str += " and sp.MaSanPham = N'" + this.txtMaSanPham.Text.Trim() + "'";

            if (this.txtTenSanPham.Text.Trim().Length > 0)
                str += " and sp.TenSanPham like N'%" + this.txtTenSanPham.Text.Trim() + "%'";

            if (this.txtMaVach.Text.Trim().Length > 0)
                str += " and hhct.MaVach like N'%" + this.txtMaVach.Text.Trim() + "%'";

            if (txtSoSerie.Text.Trim().Length > 0)
            {
                string rs = DBTools.getValue("select listidphieuxuat from tbl_chungtu where soseri=N'" + this.txtSoSerie.Text.Trim() + "'");
                if (txtSoSerie.Text.Trim().Length > 0)
                {
                    if (rs != "")
                    {
                        str1 = "select distinct px.IdPhieuXuat,px.SoOrderKH,px.SoPhieuXuat,px.NgayXuat,case when (px.NhapHoaDon is null or px.NhapHoaDon=0) and px.SoSerie is not null then N'Hủy hóa đơn' when (px.NhapHoaDon is null or px.NhapHoaDon=0) and px.SoSerie is null then N'Chưa xuất hóa đơn' else N'Đã xuất hóa đơn' end NhapHoaDon, ";
                        str1 += " kh.TenDoiTuong + ' - ' + px.HoTen TenKhachHang,nv.HoTen TenNhanVien ";
                        str1 += " from tbl_PhieuXuat px";
                        str1 += " left join tbl_DM_DoiTuong kh on kh.IdDoiTuong = px.IdKhachHang ";
                        str1 += " left join tbl_DM_NhanVien nv on nv.IdNhanVien = px.IdNhanVien ";
                        if (this.txtMaSanPham.Text.Trim().Length > 0 || this.txtTenSanPham.Text.Trim().Length > 0)
                        {
                            str1 += " inner join tbl_PhieuXuat_ChiTiet pxct on px.IdPhieuXuat = pxct.IdPhieuXuat ";
                            str1 += " inner join tbl_SanPham sp on pxct.IdSanPham = sp.IdSanPham ";
                        }

                        if (this.txtMaVach.Text.Trim().Length > 0)
                        {
                            if (this.txtMaSanPham.Text.Trim().Length > 0 || this.txtTenSanPham.Text.Trim().Length > 0)
                            {
                                str1 += " inner join tbl_PhieuXuat_ChiTiet_hanghoa pxcthh on pxct.IdChiTiet = pxcthh.IdChiTietPhieuXuat ";
                                str1 += " inner join tbl_hanghoa_chitiet hhct on pxcthh.IdChiTietHangHoa = hhct.IdChiTiet ";
                            }
                            else
                            {
                                str1 += " inner join tbl_PhieuXuat_ChiTiet pxct on px.IdPhieuXuat = pxct.IdPhieuXuat ";
                                str1 += " inner join tbl_PhieuXuat_ChiTiet_hanghoa pxcthh on pxct.IdChiTiet = pxcthh.IdChiTietPhieuXuat ";
                                str1 += " inner join tbl_hanghoa_chitiet hhct on pxcthh.IdChiTietHangHoa = hhct.IdChiTiet ";
                            }
                        }
                        str1 += " where px.IdPhieuXuat in (" + rs + ")";

                        str1 += " and LoaiXuatNhap = " + this.LoaiXuatNhap;
                        //str += //" and px.ThoigianSua > convert(datetime,'" + Common.Date2LongString(Declare.NgayKhoaSo) + "',121) " +
                        //       " and px.ThoigianSua >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103)";

                        if (txtSoOrderKH.Text.Trim().Length > 0)
                            str1 += " and px.SoOrderKH = N'" + this.txtSoOrderKH.Text.Trim() + "'";

                        if (cboTrangThai.SelectedIndex == 2)
                            str1 += " and px.NhapHoaDon = 1 and px.NgayXuat >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103)";
                        else if (cboTrangThai.SelectedIndex == 1)
                            str1 += " and (px.NhapHoaDon IS NULL or px.NhapHoaDon=0) ";
                        else
                            str1 += " and (px.NhapHoaDon IS NULL or px.NhapHoaDon=0 or px.ThoigianSua >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103))";

                        if (txtSoPhieu.Text.Trim().Length > 0)
                        {
                            if (this.LoaiXuatNhap == (int)TransactionType.NHAP_TRA_LAI)
                                str1 += " and (px.SoPhieuXuat like N'%" + this.txtSoPhieu.Text.Trim() + "%' or px.SoPhieuXuatGoc like N'%" + this.txtSoPhieu.Text.Trim() + "%') ";
                            else
                                str1 += " and px.SoPhieuXuat like N'%" + this.txtSoPhieu.Text.Trim() + "%'";
                        }

                        if (mstTuNgay.Text.Trim().Length > 0)
                            str1 += string.Format(" and px.NgayXuat >= convert(datetime,'{0}',103) ", Common.Date2String(mstTuNgay.Value));

                        if (mstDenNgay.Text.Trim().Length > 0)
                            str1 += string.Format(" and convert(varchar,px.NgayXuat,101) <= convert(datetime,'{0}',103) ", Common.Date2String(mstDenNgay.Value));

                        if (Common.IntValue(this.cboKhoXuat.SelectedValue) > 0)
                            str1 += " and px.IdKho=" + this.cboKhoXuat.SelectedValue.ToString();

                        if (Common.IntValue(this.cboNhanVien.SelectedValue) > 0)
                            str1 += " and px.IdNhanVien=" + this.cboNhanVien.SelectedValue.ToString();

                        if (Common.IntValue(this.cboKhachHang.SelectedValue) > 0)
                            str1 += " and px.IdKhachHang=" + this.cboKhachHang.SelectedValue.ToString();

                        if (this.txtHoTenKhachHang.Text.Trim().Length > 0)
                            str1 += " and px.HoTen like N'%" + this.txtHoTenKhachHang.Text.Trim() + "%'";

                        if (this.txtDiaChi.Text.Trim().Length > 0)
                            str1 += " and px.DiaChi like N'%" + this.txtDiaChi.Text.Trim() + "%'";

                        if (this.txtMaSoThue.Text.Trim().Length > 0)
                            str1 += " and px.MaSoThue like N'%" + this.txtMaSoThue.Text.Trim() + "%'";

                        if (this.txtDienThoai.Text.Trim().Length > 0)
                            str1 += " and px.DienThoai like N'%" + this.txtDienThoai.Text.Trim() + "%'";

                        if (this.txtGhiChu.Text.Trim().Length > 0)
                            str1 += " and px.GhiChu like N'%" + this.txtGhiChu.Text.Trim() + "%'";

                        if (this.txtMaSanPham.Text.Trim().Length > 0)
                            str1 += " and sp.MaSanPham = N'" + this.txtMaSanPham.Text.Trim() + "'";

                        if (this.txtTenSanPham.Text.Trim().Length > 0)
                            str1 += " and sp.TenSanPham like N'%" + this.txtTenSanPham.Text.Trim() + "%'";

                        if (this.txtMaVach.Text.Trim().Length > 0)
                            str1 += " and hhct.MaVach like N'%" + this.txtMaVach.Text.Trim() + "%'";

                        str = str + " union all " + str1;
                    }
                }
            }
            
            return str;
        }

        private bool TimPhieuXuat_NgayXuatHopLe()
        {
            if (this.mstTuNgay.Text.Trim().Length >4 && this.mstTuNgay.Text.Trim().Length < 10)
            {
                MessageBox.Show("Mục 'Từ ngày' nhập chưa đúng!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mstTuNgay.Focus();
                return false;
            }
            if (this.mstTuNgay.Text.Trim().Length ==10)
            {
                if (!Common.IsValidDate(this.mstTuNgay.Text.Trim()))
                {
                    MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.mstTuNgay.Focus();
                    return false;
                }
            }

            if (  this.mstDenNgay.Text.Trim().Length >4 && this.mstDenNgay.Text.Trim().Length < 10)
            {
                MessageBox.Show("Mục 'Đến ngày' nhập chưa đúng!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mstDenNgay.Focus();
                return false;
            }
            if (this.mstDenNgay.Text.Trim().Length ==10)
            {
                if (!Common.IsValidDate(this.mstDenNgay.Text.Trim()))
                {
                    MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.mstDenNgay.Focus();
                    return false;
                }
            }

            if (mstTuNgay.Text.Trim().Length == 10 && mstDenNgay.Text.Trim().Length == 10)
            {
                if (DateTime.Compare(Common.ParseDate(this.mstDenNgay.Text.Trim()), Common.ParseDate(this.mstTuNgay.Text.Trim())) < 0)
                {
                    MessageBox.Show("Mục 'Từ ngày' phải nhỏ hơn Mục 'Đến ngày'.", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mstTuNgay.Focus();
                    return false;
                }
            }
           return true;
        }

        private void TimPhieuXuat_CapNhatSoTT(DataTable dt, int VitriRong)
        {
            for (int i = VitriRong; i <= dt.Rows.Count - 1; i++)
            {
                dt.Rows[i]["SoTT"] = i + 1;
            }
        }

        private void LuoiHienThi_AnCot()
        {
            for (int i = 0; i <= this.dtPX.Columns.Count - 1; i++)
            { 
                if(this.dtPX.Columns[i].ColumnName=="SoTT" ||
                    (this.dtPX.Columns[i].ColumnName == "SoOrderKH" && this.LoaiXuatNhap != (int)TransactionType.NHAP_TRA_LAI) ||
                    this.dtPX.Columns[i].ColumnName == "SoPhieuXuat" ||
                    this.dtPX.Columns[i].ColumnName=="NgayXuat"||
                    this.dtPX.Columns[i].ColumnName == "NhapHoaDon" ||
                    this.dtPX.Columns[i].ColumnName=="TenKhachHang"||
                    this.dtPX.Columns[i].ColumnName=="TenNhanVien")
                    this.dgvPhieuXuat.Columns[i].Visible=true;
                else
                    this.dgvPhieuXuat.Columns[i].Visible = false;
            }
        }

        private void TimPX_KhoiTaoViTriNutThucThi()
        {
            int Y = this.btnTim.Location.Y;
            int iKC = 3;
            int Width_ = this.btnTim.Width;
            this.btnTim.Location = new Point((this.Width - (5 * iKC) - (6 * Width_)) / 2, Y);
            this.btnChonLai.Location = new Point(this.btnTim.Location.X + iKC + Width_, Y);
            this.btnCapNhat.Location = new Point(this.btnChonLai.Location.X + iKC + Width_, Y);
            this.btnXoa.Location = new Point(this.btnCapNhat.Location.X + iKC + Width_, Y); ;
            //this.btnInPhieu.Location = new Point(this.btnXoa.Location.X + iKC + Width_, Y);
            //this.btnDong.Location = new Point(this.btnInPhieu.Location.X + iKC + Width_, Y);
            this.lblTieuDe.Location = new Point((this.Width - this.lblTieuDe.Width) / 2, this.lblTieuDe.Location.Y);
        }


        private void TimPhieuXuat_TimLai()
        {
            this.txtSoPhieu.Text = "";
            this.mstTuNgay.Text =(new DateTime(DateTime.Today.Year,DateTime.Today.Month,1)).ToString("dd/MM/yyyy");
            this.mstDenNgay.Text = DateTime.Today.ToString("dd/MM/yyyy");
            this.cboKhachHang.SelectedIndex = 0;
            this.cboNhanVien.SelectedIndex = 0;
            this.txtHoTenKhachHang.Text = "";
            this.txtDiaChi.Text = "";
            this.txtMaSanPham.Text = "";
            this.txtSoOrderKH.Text = "";
            this.txtSoSerie.Text = "";
            this.txtMaVach.Text = "";
            this.txtTenSanPham.Text = "";
            this.txtSoPhieu.Focus();
            this.cboTrangThai.SelectedIndex = 1;
        }

        private GtidCommand DeleteCommandPhieuXuat(int IdPhieuXuat)
        {
            GtidCommand sql = new GtidCommand("sp_PhieuXuat_Delete");
            sql.Parameters.AddWithValue("@IdPhieuXuat", IdPhieuXuat).Direction = ParameterDirection.Input;
            sql.CommandType = CommandType.StoredProcedure;
            return sql;
        }


        private void PhieuXuat_Sua()
        {
            if (this.dgvPhieuXuat.RowCount == 0) {
                MessageBox.Show("Không có phiếu xuất nào để sửa.", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.dgvPhieuXuat.CurrentRow == null) {
                MessageBox.Show("Bạn chưa chọn phiếu để sửa.", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _IdPhieu[0] = Convert.ToInt32(this.dgvPhieuXuat.CurrentRow.Cells["IdPhieuXuat"].Value);
            this.DialogResult = DialogResult.OK;

            //int IndexPX=-1;
            //for (int i = 0; i <= this.dtPX.Rows.Count - 1; i++)
            //{
            //    if ((int)this.dgvPhieuXuat.CurrentRow.Cells["IdPhieuXuat"].Value == (int)this.dtPX.Rows[i]["IdPhieuXuat"])
            //    {
            //        IndexPX = i;
            //        break;
            //    }
            //}
            //frmPhieuXuat frm = new frmPhieuXuat(this.dtPX, IndexPX);
            //frm.MdiParent = this.ParentForm;
            //frm.Show();
            //if (this.dtPX.Rows.Count > 0)
            //    this.dgvPhieuXuat.CurrentRow.Selected = true;
        }

#endregion 

#region "Các sự kiên"
        private void frmTimPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                TimPhieuXuat_TimLai();
                SearchPhieuXuat();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = this.cboKhachHang.SelectedIndex;
                txtHoTenKhachHang.Text = this.dtKhachHang.Rows[index]["TenDoiTuong"].ToString();
                txtDiaChi.Text = this.dtKhachHang.Rows[index]["DiaChi"].ToString();
            }
            catch (Exception ex) { ex.ToString(); }

        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!this.TimPhieuXuat_NgayXuatHopLe()) return;

            frmTimPhieuXuat.SQLSearch = this.TimPhieuXuat_ChuoiLoc();

            SearchPhieuXuat();
        }

        private void SearchPhieuXuat()
        {
            try
            {
                if (frmTimPhieuXuat.SQLSearch.Trim().Length == 0) return;

                if (this.dtPX != null)
                    this.dtPX = null;
                this.dtPX = DBTools.getData("tbl_PhieuXuat", frmTimPhieuXuat.SQLSearch.Trim()).Tables["tbl_PhieuXuat"];
                if (this.dtPX == null)
                {
                    MessageBox.Show("Lỗi tìm phiếu xuất: " + DBTools._LastError.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.dtPX.Columns.Add("SoTT", typeof(int));
                this.dgvPhieuXuat.DataSource = dtPX;
                this.TimPhieuXuat_CapNhatSoTT(this.dtPX, 0);
                this.LuoiHienThi_AnCot();
                this.grpKetQuaTimKiem.Text = "Kết quả tìm kiếm (" + dgvPhieuXuat.RowCount + " phiếu)";
                if (this.dtPX.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi nào thỏa mãn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.dtPX != null)
                    this.dtPX.Dispose();
                this.TimPhieuXuat_TimLai();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnChonLai_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dtPX!=null)
                this.dtPX.Rows.Clear();
                this.TimPhieuXuat_TimLai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                this.PhieuXuat_Sua();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }


        private void dgvPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (this.dgvPhieuXuat.RowCount > 0)
                    {
                        this.PhieuXuat_Sua();
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void dgvPhieuXuat_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPhieuXuat.RowCount > 0)
                {
                    this.PhieuXuat_Sua();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
           } 
        }
#endregion

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dtPX.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu xuất để in", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmBC_InHDPhieu frmBC = new frmBC_InHDPhieu("PX", this.dtPX.Rows[this.dgvPhieuXuat.CurrentRow.Index]["SoPhieuXuat"].ToString());
                frmBC.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in phiếu: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTimPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)   
                {
                    if (!this.dgvPhieuXuat.Focused)
                    {
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                        return;
                    }
                }
                if (e.KeyCode == Keys.F3)
                    this.btnTim_Click(sender, e);
                else if (e.KeyCode == Keys.F5)
                    this.btnChonLai_Click(sender, e);
                else if (e.KeyCode == Keys.F6)
                    this.btnCapNhat_Click(sender, e);
                else if (e.KeyCode == Keys.F8 && btnXoa.Enabled)
                    this.btnXoa_Click(sender, e);
                else if (e.KeyCode == Keys.F9)
                    this.btnInPhieu_Click(sender, e);
                else if (e.KeyCode == Keys.F12)
                    this.btnDong_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void dgvPhieuXuat_Sorted(object sender, EventArgs e)
        {
            this.dtPX.DefaultView.AllowEdit = true;
            for (int i = 0; i <= this.dtPX.DefaultView.Count - 1; i++)
            {
                this.dtPX.DefaultView[i]["SoTT"] = i + 1;
            }
            this.dtPX.DefaultView.AllowEdit = false;
        }


    }
}