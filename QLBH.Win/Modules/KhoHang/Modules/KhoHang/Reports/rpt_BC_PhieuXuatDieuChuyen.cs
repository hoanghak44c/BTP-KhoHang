using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_PhieuXuatDieuChuyen : DevExpress.XtraReports.UI.XtraReport
    {
        private int IdKhoDieuChuyen;
        public rpt_BC_PhieuXuatDieuChuyen( int idKhoDieuChuyen)
        {
            InitializeComponent();
            this.IdKhoDieuChuyen = idKhoDieuChuyen;
            DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(IdKhoDieuChuyen);
            txtKhoDen.Text = dmKho.TenKho;
        }
        public rpt_BC_PhieuXuatDieuChuyen(ChungTuXuatDieuChuyenInfo info)
        {
            InitializeComponent();
            this.IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            var dmKho = DMKhoDataProvider.GetKhoByIdInfo(IdKhoDieuChuyen);
            txtKhoDen.Text = dmKho.TenKho;
            lblGhiChu.Text = info.GhiChu;
        }
    }
}
