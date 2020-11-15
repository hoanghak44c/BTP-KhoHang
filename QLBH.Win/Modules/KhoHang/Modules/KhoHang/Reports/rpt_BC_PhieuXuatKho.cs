using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_PhieuXuatKho : DevExpress.XtraReports.UI.XtraReport
    {
        private PhieuXuatKhoInfo hoadon;
        public rpt_BC_PhieuXuatKho(PhieuXuatKhoInfo hoadon)
        {
            InitializeComponent();
                this.hoadon = hoadon;
                txtNguoiMua.Text = hoadon.NguoiMua;
                txtDiaChi.Text = hoadon.DiaChi;
                txtSoPhieu.Text = hoadon.SoChungTu;
                txtNgay.Text = string.Format("{0:dd/MM/yyyy}", hoadon.NgayLap);
                //txtNgay.Text = Convert.ToString(CommonProvider.Instance.GetSysDate());
        }
    }
}
