using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class frmChonBaoCao : DevExpress.XtraEditors.XtraForm
    {
        public int Value = 0;
        private bool check = false;
        public frmChonBaoCao()
        {
            InitializeComponent();
        }
        public frmChonBaoCao(bool check)
        {
            this.check = check;
            InitializeComponent();
        }

        private void frmChonBaoCao_Load(object sender, EventArgs e)
        {
            if (check)
            {
                rdoChon.Properties.Items[0].Description = "Thời hạn bảo hành theo thành phẩm (TGPC)";
                rdoChon.Properties.Items[1].Description = "Thời hạn bảo hành theo linh kiện (PCTA)";
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Value = Convert.ToInt32(rdoChon.EditValue);
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}