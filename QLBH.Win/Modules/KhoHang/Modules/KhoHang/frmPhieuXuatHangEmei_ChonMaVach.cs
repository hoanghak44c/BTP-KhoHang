using System;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuatHangEmei_ChonMaVach : Form
    {
        DataRow[] drMV;
        public int sTTMVChon = 0;
        public frmPhieuXuatHangEmei_ChonMaVach(DataRow[] drMV)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.drMV = drMV;
        }

        private void frm_HoaDonBan_ChonTyleVAT_Load(object sender, EventArgs e)
        {
            for (int i=0; i< drMV.Length; i++)
            {
                cboMaVach.Items.Add(drMV[i]["MaSanPham"]);
            }
            cboMaVach.SelectedIndex = 0;
            cboMaVach.Refresh();
            cboMaVach.Focus();

            txtMaSanPham.Text = drMV[sTTMVChon]["MaVach"].ToString();
        }

        private void cboTyle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) {
                    this.sTTMVChon = Common.IntValue(cboMaVach.SelectedIndex);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif            	
            }
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            try
            {
                this.sTTMVChon = Common.IntValue(cboMaVach.SelectedIndex);
                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void cboPhieuXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sTTMVChon = Common.IntValue(cboMaVach.SelectedIndex);
            //txtMaSanPham.Text = drMV[sTTMVChon]["MaSanPham"].ToString();
            txtTenSanPham.Text = drMV[sTTMVChon]["TenSanPham"].ToString();
        }
    }
}