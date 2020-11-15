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
    public partial class rpt_BC_NoteSanPhamA6Detailnew : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BC_NoteSanPhamA6Detailnew()
        {
            InitializeComponent();
            txtTenCauHinh.Font = new Font("Myriad Pro", 11, FontStyle.Bold);
            txtGiaTri.Font = new Font("Myriad Pro", 11, FontStyle.Regular);
            txtTenCauHinh.Width = 140;
            txtGiaTri.Width = 212;
        }
        public void BindDetail()
        {
            txtTenCauHinh.DataBindings.Add("Text", DataSource, "TenCauHinh");
            txtGiaTri.DataBindings.Add("Text", DataSource, "GiaTri");
        }

        public List<NoteSanPhamReportInfor> GetListCauHinhDetail(string idSanPham, string thongTin)
        {
            return NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(idSanPham, thongTin);
        }
    }
}
