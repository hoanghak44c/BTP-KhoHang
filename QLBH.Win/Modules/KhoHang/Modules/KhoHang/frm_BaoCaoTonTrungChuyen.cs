using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoTonTrungChuyen : DevExpress.XtraEditors.XtraForm
    {
        public frm_BaoCaoTonTrungChuyen()
        {
            InitializeComponent();
        }

        private void frm_BaoCaoTonTrungChuyen_Load(object sender, EventArgs e)
        {
            grcBCKiemKe.DataSource = BaoCaoTonTrungChuyenDataProvider.Instance.GetListTonTrungChuyen();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            Common.Export2ExcelFromDevGrid<TonTrungChuyenInfo>(grvBCKiemKe, "BCTonTrungChuyen");
        }

    }
}
