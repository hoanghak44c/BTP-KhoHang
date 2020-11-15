using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ListPhieuBase : DevExpress.XtraEditors.XtraForm
    {
        public frm_ListPhieuBase()
        {
            InitializeComponent();
            dgvChiTiet.AutoGenerateColumns = false;
        }

        protected virtual void MoPhieuInstance(){}
        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            MoPhieuInstance();
        }
        protected virtual void ThemPhieuInstance(){}
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            ThemPhieuInstance();
        }
        protected virtual void XoaPhieuInstance(){}
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            XoaPhieuInstance();
        }
        protected virtual bool HasChanged()
        {
            return false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (HasChanged())
            {
                if (MessageBox.Show("Dữ liệu chưa được lưu có thể sẽ bị mất. Bạn có chắc chắn muốn thoát ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                }
                return;
            }
            DialogResult = DialogResult.Cancel;
        }
        protected virtual void LoadDataInstance() { }
        private void frm_ListPhieuBase_Load(object sender, EventArgs e)
        {
            LoadDataInstance();
        }
    }
}