using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmThongKe_TonChiTietMaVachBy : DevExpress.XtraEditors.XtraForm
    {
        private KhoThongKeHangTonInfo khoThongKeHangTonInfo;
        public frmThongKe_TonChiTietMaVachBy(KhoThongKeHangTonInfo khoThongKeHangTonInfo)
        {
            InitializeComponent();
            this.khoThongKeHangTonInfo = khoThongKeHangTonInfo;
        }

        private void frmThongKe_TonChiTietMaVach_Load(object sender, EventArgs e)
        {
            grcHangTon.ContextMenuStrip.Items.Add("Export", null, btnExportData_Click);
        }

        private void frmThongKe_TonChiTietMaVach_Activated(object sender, EventArgs e)
        {
            grcHangTon.DataSource = KhoThongKeHangTonDataProvider.Instance.GetListThongKeTonMaVach(khoThongKeHangTonInfo.IdTrungTam, khoThongKeHangTonInfo.IdKho, khoThongKeHangTonInfo.IdSanPham);

            foreach (GridColumn column in this.grvThongKeHangTon.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
                column.OptionsColumn.ReadOnly = true;
            }
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            grvThongKeHangTon.ExportToXls(Application.StartupPath + "\\" + Application.ProductName + ".xls");
        }
    }
}