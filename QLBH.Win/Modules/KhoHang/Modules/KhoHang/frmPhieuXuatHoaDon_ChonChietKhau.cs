using System;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuatHoaDon_ChonChietKhau : Form
    {
        DataRow[] drMV;
        public int sTTMVChon = 0;
        private DataTable dtSanPham = null;
        public int IdChietKhau = 0;
        public string MaChietKhau = "";
        public string TenChietKhau = "";
        public string DonViTinh = "";
        public double VAT = 0;
        public double TienChietKhau = 0;
        public double TongTienChietKhau = 0;

        public frmPhieuXuatHoaDon_ChonChietKhau()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        private void frm_HoaDonBan_ChonTyleVAT_Load(object sender, EventArgs e)
        {
            string str = "Select sp.IdSanPham,sp.MaSanPham, sp.TenSanPham, dvt.TenDonViTinh " +
                         " From tbl_SanPham sp Inner join tbl_DM_DonViTinh dvt On (sp.IdDonViTinh = dvt.IdDonViTinh) and (sp.ChietKhau = 1)";
            dtSanPham = DBTools.getData("tmp", str).Tables["tmp"];
            if (dtSanPham != null)
            {
                this.cboChietKhau.DataSource = this.dtSanPham;
                this.cboChietKhau.DisplayMember = "TenSanPham";
                this.cboChietKhau.ValueMember = "IdSanPham";
                this.cboChietKhau.SelectedIndex = -1;

                // AutoCompleteStringCollection 
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                for (int i = 0; i < dtSanPham.Rows.Count; i++)
                {
                    data.Add(dtSanPham.Rows[i]["MaSanPham"].ToString());
                }
                txtMaChietKhau.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMaChietKhau.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtMaChietKhau.AutoCompleteCustomSource = data;
            }
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            if (cboChietKhau.SelectedIndex >= 0)
            {
                IdChietKhau = Common.IntValue(dtSanPham.Rows[cboChietKhau.SelectedIndex]["IdSanPham"]);
                MaChietKhau = dtSanPham.Rows[cboChietKhau.SelectedIndex]["MaSanPham"].ToString();
                TenChietKhau = dtSanPham.Rows[cboChietKhau.SelectedIndex]["TenSanPham"].ToString();
                DonViTinh = dtSanPham.Rows[cboChietKhau.SelectedIndex]["TenDonViTinh"].ToString();
                TienChietKhau = Common.DoubleValueInt(txtTienCK.Text);
                VAT = Common.DoubleValue(txtVAT.Text);
                TongTienChietKhau = Common.DoubleValueInt(txtTongTienCK.Text);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Phải chọn mã chiết khấu");
            }
        }

        private void cboPhieuXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaChietKhau.Text = dtSanPham.Rows[cboChietKhau.SelectedIndex]["MaSanPham"].ToString();
            }
            catch
            {
                txtMaChietKhau.Text = "";
            }
        }

        private void btnCacel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtMaChietKhau_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtSanPham.Rows.Count; i++)
            {
                if (txtMaChietKhau.Text.Equals(dtSanPham.Rows[i]["MaSanPham"].ToString()))
                {
                    //cboKhachHang.SelectedIndex = i;
                    cboChietKhau.SelectedValue = dtSanPham.Rows[i]["IdSanPham"];
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                txtMaChietKhau.Text = "";
                cboChietKhau.SelectedIndex = -1;
            }
        }

        private void txtMaChietKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMaChietKhau_Leave(sender, e);
            }
        }
        private void TinhChietKhau()
        {
            double tienCK = Common.DoubleValueInt(txtTienCK.Text.Trim());
            double vat = Common.DoubleValueInt(txtVAT.Text.Trim());
            double tienvat = Common.DoubleValueInt(tienCK * vat / 100);
            txtTongTienCK.Text = Common.Double2Str(tienCK + tienvat);
        }
        private void txtTienCK_TextChanged(object sender, EventArgs e)
        {
            TinhChietKhau();
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            TinhChietKhau();
        }

        private void txtTienCK_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtTienCK.Text = Common.Double2Str(Common.DoubleValue(this.txtTienCK.Text.Trim()));
            }
            catch (System.Exception ex)
            {
#if DEBUG
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                //MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
    }
}