using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BangKeHoaDonGTGT : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_BangKeHoaDonGTGT(DateTime Ngay,string TenDonVi,string DiaChi,string TenNguoiMua,string MaSoThue,
                    string BoPhan,string NhanVienBH,string SoPhieu,string DienThoai,
                    string DiaChiGiaoHang,string KhoXuat,string Thoigiangiaohang,string TienChu,string soBK)
        {
            InitializeComponent();
            //this.frm = frm;
            txtNgay.Text = CommonProvider.Instance.GetSysDate().Day.ToString();
            txtThang.Text = CommonProvider.Instance.GetSysDate().Month.ToString();
            txtNam.Text = CommonProvider.Instance.GetSysDate().Year.ToString();
            txtTenDonVi.Text = TenDonVi;
            txtSoBK.Text = soBK;
            txtSoHD.Text = "0165478";
            txtMaSoThue.Text = MaSoThue;
            txtHoTenNguoiMua.Text = TenNguoiMua;
            txtDiaChi.Text = DiaChi;
            lbltienbangchu.Text = TienChu;
        }

    }
}
