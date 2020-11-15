using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common.Providers;
using QLBanHang.Modules.BanHang.Infors;

namespace QLBanHang.Modules.BanHang.Reports
{
    public partial class rpt_HoaDonDieuChuyenGTGT : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_HoaDonDieuChuyenGTGT(BaoCao_ChiTietDCInfor hd)
        {
            InitializeComponent();
            lblNguoiVC.Text = hd.NguoiVanChuyen;
            lblKhoXuat.Text = hd.KhoDi;
            lblKhonhap.Text = hd.KhoDen;
            //lblPhuongTien.Text = hd.PhuongTien;
            //lblHDSo.Text = hd.SoChungTu;
            lblNgay.Text = hd.NgayLap.Day.ToString();
            lblThang.Text = hd.NgayLap.Month.ToString();
            lblNam.Text = hd.NgayLap.Year.ToString();
            lblSoChungTu.Text = hd.SoChungTu;
            lblngay1.Text = hd.NgayLap.Day.ToString();
            lblthang1.Text = hd.NgayLap.Month.ToString();
            lblnam1.Text = hd.NgayLap.Year.ToString();
            lblNguoiLap.Text = hd.NguoiLap;
            lblGhiChu.Text = hd.GhiChu;
            //lblTongTien.Text = hd.TongTienChuaVAT;
            //lblTongSL.Text = hd.TongTienVAT;
            xrLabel1.Height = 15;
        }
    }
}
