using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_NoteSanPhamA6Detail : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BC_NoteSanPhamA6Detail()
        {
            InitializeComponent();
            txtTenCauHinh.Font = new Font("Myriad Pro", 11, FontStyle.Bold);
            txtGiaTri.Font = new Font("Myriad Pro", 11, FontStyle.Regular);
            txtTenCauHinh.Width = 150;
            //txtGiaTri.Width = 180;
        }

        public void BindDetail()
        {
            txtTenCauHinh.DataBindings.Add("Text", DataSource, "TenCauHinh");
            txtGiaTri.DataBindings.Add("Text", DataSource, "GiaTri");
        }

        public List<NoteSanPhamReportInfor> GetListCauHinhDetail(string idSanPham,string thongTin)
        {
            return NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(idSanPham,thongTin);
        }
    }
}
