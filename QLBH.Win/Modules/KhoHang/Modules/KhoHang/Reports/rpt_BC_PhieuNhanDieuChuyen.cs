using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_PhieuNhanDieuChuyen : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BC_PhieuNhanDieuChuyen(int IdKho,string soCTG)
        {
            InitializeComponent();
            DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(IdKho);
            txtKhoDi.Text = dmKho.TenKho;
            lblSoCTG.Text = soCTG;
        }

    }
}
