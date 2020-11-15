using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.BanHang.Infors;

namespace QLBanHang.Modules.BanHang.Reports
{
    public partial class rptInPhieuBH : DevExpress.XtraReports.UI.XtraReport
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
        public rptInPhieuBH(string tenDoiTuong,string soPhieu,string nhomKH,string DiaChi,DateTime ngaymua)
        {
            InitializeComponent();
            txtTenKhach.Text = tenDoiTuong;
            txtDiaChi.Text = DiaChi;
            txtNgayMua.Text = string.Format("{0:dd/MM/yyyy}", ngaymua);
            txtSoPhieuXuat.Text = soPhieu;
            txtNhomKH.Text = nhomKH;


        }
    }
}
