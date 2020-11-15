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
    public partial class rpt_BC_NoteSanPhamA7Detail : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BC_NoteSanPhamA7Detail()
        {
            InitializeComponent();
            txtTenCauHinh.Font = new Font("Myriad pro", 9, FontStyle.Bold);
            txtGiaTri.Font = new Font("Myriad pro", 9, FontStyle.Regular);
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
