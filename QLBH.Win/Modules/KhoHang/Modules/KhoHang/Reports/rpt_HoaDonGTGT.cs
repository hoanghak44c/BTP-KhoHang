using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_HoaDonGTGT : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_HoaDonGTGT(DateTime Ngay,string TenDonVi,string DiaChi,string TenNguoiMua,string MaSoThue,
                    string BoPhan,string NhanVienBH,string SoPhieu,string DienThoai,
                    string DiaChiGiaoHang,string KhoXuat,string Thoigiangiaohang,string TienChu,string soBK)
        {
            InitializeComponent();
            lblNgay.Text = CommonProvider.Instance.GetSysDate().Day.ToString();
            lblThang.Text = CommonProvider.Instance.GetSysDate().Month.ToString();
            lblNam.Text = CommonProvider.Instance.GetSysDate().Year.ToString();
            lblNgay1.Text = CommonProvider.Instance.GetSysDate().Day.ToString();
            lblThang1.Text = CommonProvider.Instance.GetSysDate().Month.ToString();
            lblNam1.Text = CommonProvider.Instance.GetSysDate().Year.ToString();
            lblTenDonVi.Text = TenDonVi;
            lblDonViMuaHang.Text = TenDonVi;
            lblDiaChi.Text = DiaChi;
            lblHoTenNguoiMua.Text = TenNguoiMua;
            lblHoTen.Text = TenNguoiMua;
            lblMaSoThue.Text = MaSoThue;
            lblBoPhan.Text = BoPhan;
            lblNhanVienBH.Text = NhanVienBH;
            lblSoChungTu.Text = SoPhieu;
            lblSoChungtu1.Text = SoPhieu;
            lblDienThoai.Text = DienThoai;
            lblDiaChiGiaoHang.Text = DiaChiGiaoHang;
            lblKhoXuat.Text = KhoXuat;
            lblThoiGianGiaoHang.Text = Thoigiangiaohang;
            lblTienbangChu.Text = TienChu;
            lblTienBangChu2.Text = TienChu;
            lblNVBH.Text = NhanVienBH;
            txtTenSanPham.Text = "Điện Gia dụng, điện máy " + "/" + "In kèm bảng kê số " +  soBK + "tại thời điểm " + Ngay ;
            xrLabel7.Text = "180.405";
            xrLabel8.Text = "180.000.000";
            xrLabel5.Text = "175.485.000";
        }

    }
}
