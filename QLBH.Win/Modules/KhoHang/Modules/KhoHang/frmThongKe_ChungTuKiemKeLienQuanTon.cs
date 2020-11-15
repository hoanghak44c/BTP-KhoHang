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
    public partial class frmThongKe_ChungTuKiemKeLienQuanTon : DevExpress.XtraEditors.XtraForm
    {
        private BCKiemKeChungTuLienQuanTon KiemKeInfor;
        BCChiTietKiemKeInfo kiemKeChiTietInfor;
        public frmThongKe_ChungTuKiemKeLienQuanTon(BCChiTietKiemKeInfo kiemKeChiTietInfor)
        {
            InitializeComponent();
            grcHangTon.ContextMenuStrip = new ContextMenuStrip();
            this.kiemKeChiTietInfor = kiemKeChiTietInfor;
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            Common.DevExport2Excel(grvThongKeHangTon);
        }

        private void frmThongKe_ChungTuKiemKeLienQuan_Load(object sender, EventArgs e)
        {
            grcHangTon.ContextMenuStrip.Items.Add("Export", null, btnExportData_Click);
        }

        private void frmThongKe_ChungTuKiemKeLienQuan_Activated(object sender, EventArgs e)
        {
            grcHangTon.DataSource = KiemKeDataProvider.Instance.GetListKiemKeChungTuLienQuanTon(kiemKeChiTietInfor);

            foreach (GridColumn column in this.grvThongKeHangTon.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
                column.OptionsColumn.ReadOnly = true;
            }
        }
    }
}