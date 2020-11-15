using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_NoteSanPhamA7 : DevExpress.XtraReports.UI.XtraReport
    {
        private int IdSanPham;
        public rpt_BC_NoteSanPhamA7(string tenSanPham,string maSanPham,string nhaCC,int IdSanPham)
        {
            InitializeComponent();
            lblTenHang.Text = tenSanPham;
            lblModel.Text = maSanPham;
            //lblNhaCC.Text = nhaCC;

            this.IdSanPham = IdSanPham;
        }
    }
}
