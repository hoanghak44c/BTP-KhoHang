using System;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmPhieuNhapTraLaiXuatGop_ChonChungTu : Form
    {
        DataTable dtPX;
        public int IdPhieuXuatChon = 0;
        public frmPhieuNhapTraLaiXuatGop_ChonChungTu(DataTable dtPX)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dtPX = dtPX;
        }

        private void frm_HoaDonBan_ChonTyleVAT_Load(object sender, EventArgs e)
        {
            cboPhieuXuat.DisplayMember = "SoSeri";
            cboPhieuXuat.ValueMember = "IdChungTu";
            cboPhieuXuat.DataSource = this.dtPX;
            cboPhieuXuat.Refresh();
            cboPhieuXuat.Focus();
        }

        private void cboTyle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) {
                    this.IdPhieuXuatChon = Common.IntValue(cboPhieuXuat.SelectedValue);
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
                this.IdPhieuXuatChon = Common.IntValue(cboPhieuXuat.SelectedValue);
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
            double IdPX = Convert.ToDouble(cboPhieuXuat.SelectedValue);
            string str = "select ct.IdChungTu,ct.SoSeri,ct.NgayLap,ct.HoTen " +
                  "from tbl_ChungTu ct " +
                  "where IdChungTu=" + IdPX;
            DataTable dt = DBTools.getData("Tmp", str).Tables["Tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                this.txtKhachHang.Text = dt.Rows[0]["HoTen"].ToString();
                this.dtNgayBan.Value = (DateTime)dt.Rows[0]["NgayLap"];
            }
        }
    }
}