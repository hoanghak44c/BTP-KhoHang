using System;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuatHoaDon_ChonKyHieu : Form
    {
        DataTable dtHD;
        public int iChonKH = 0;
        public frmPhieuXuatHoaDon_ChonKyHieu(DataTable dtHD)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dtHD = dtHD;
        }

        private void frm_HoaDonBan_ChonTyleVAT_Load(object sender, EventArgs e)
        {
            cboMaVach.Items.Clear();
            for (int i = 0; i < dtHD.Rows.Count; i++)
            {
                cboMaVach.Items.Add(dtHD.Rows[i]["KyHieu"]);
            }
            cboMaVach.SelectedIndex = 0;
            cboMaVach.Refresh();
            cboMaVach.Focus();

        }

        private void cboTyle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) {
                    this.iChonKH = cboMaVach.SelectedIndex;
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
                this.iChonKH = cboMaVach.SelectedIndex;
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

        private void cboMaVach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaSanPham.Text = dtHD.Rows[cboMaVach.SelectedIndex]["KyHieuDau"].ToString();
            txtTenSanPham.Text = dtHD.Rows[cboMaVach.SelectedIndex]["SoHienTai"].ToString();
        }

    }
}