using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BangGia : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BangGia()
        {
            InitializeComponent();
        }
        public rpt_BangGia(BangGiaReportInfo bg)
        {
            InitializeComponent();
            lblTenSP1.Text = bg.TenSanPham;
            lblMaSP.Text = bg.MaSanPham;
            lblDonGia.Text = bg.DonGia.ToString();
        }

    }
}
