using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.BanHang.Infors;

namespace QLBanHang.Modules.BanHang.Reports
{
    public partial class rptInPhieuBHSX : DevExpress.XtraReports.UI.XtraReport
    {
        //public rptInPhieuBH(InPhieuBaoHanhInfor oDataSource,DateTime ngaymua)
        //{
        //    InitializeComponent();
        //    txtTenKhach.Text = oDataSource.TenDoiTuong;
        //    txtDiaChi.Text = oDataSource.DiaChi;
        //    txtNgayMua.Text = string.Format("{0:dd/MM/yyyy}", ngaymua);
        //    txtSoPhieuXuat.Text = oDataSource.SoPhieuXuat;
        //    txtNhomKH.Text = oDataSource.NhomKH;
        //}
        public rptInPhieuBHSX(string tenDoiTuong, string soPhieu,string Mavach)
        {
            InitializeComponent();
            txtTenKhach.Text = "TÊN THÀNH PHẨM :" + tenDoiTuong;
            txtNhomKH.Text = "MÃ VẠCH THÀNH PHẨM :" + Mavach;
            //txtNgayMua.Text = string.Format("{0:dd/MM/yyyy}", ngaymua);
            txtDiaChi.Text = "SỐ PHIẾU XUẤT :" + soPhieu;
           // txtNhomKH.Text = nhomKH;


        }
    }
}
