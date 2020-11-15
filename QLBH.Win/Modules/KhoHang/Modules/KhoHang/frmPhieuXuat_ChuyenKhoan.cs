using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
//using QLBanHang.Class.Objects;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuat_ChuyenKhoan : Form
    {
        public frmPhieuXuat_ChuyenKhoan()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        public frmPhieuXuat_ChuyenKhoan(string tienThanhToan, string tienThucTra, string tienNo, string tienTe, string soTaiKhoan, string nganHang, int httra)
        {
            InitializeComponent();
            this.txtTienThanhToan.Text = tienThanhToan;
            this.txtTienThucTra.Text = tienThucTra;
            this.txtTienConNo.Text = tienNo;
            this.lblTienTe.Text = "Đơn vị tính: (" + tienTe + ")";
            this.txtSoTaiKhoan.Text = soTaiKhoan;
            this.txtNganHang.Text = nganHang;
            LoadHinhThucTra();
            this.cboHinhThucTra.SelectedValue = httra;
            Common.LoadStyle(this);
        }
        private void LoadHinhThucTra()
        {
            string str = "Select IdThuChi, KyHieu + ' - ' + Ten ThuChi From tbl_DM_LoaiThuChi " +
                  " Where SuDung=1 and Type=0 order by KyHieu ";

            DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
            if (dt != null)
            {
                this.cboHinhThucTra.DataSource = dt;
                this.cboHinhThucTra.DisplayMember = "ThuChi";
                this.cboHinhThucTra.ValueMember = "IdThuChi";
            }
        }
        private void txtTienThucTra_TextChanged(object sender, EventArgs e)
        {
            double tienThanhToan = Common.DoubleValue(txtTienThanhToan.Text.Trim());
            double tienThucTra = Common.DoubleValue(txtTienThucTra.Text.Trim());
            double tienConNo = tienThanhToan - tienThucTra;
            txtTienConNo.Text = Common.Double2Str(tienConNo);
        }
        private void txtTienThucTra_LostFocus(object sender, EventArgs e)
        {
            try
            {
                this.txtTienThucTra.Text = Common.Double2Str(Common.DoubleValue(this.txtTienThucTra.Text.Trim()));
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTienThucTra_Enter(object sender, EventArgs e)
        {
            this.txtTienThucTra.Focus();
            this.txtTienThucTra.SelectAll();
        }

        private void frmPhieuXuat_TraTienThua_Load(object sender, EventArgs e)
        {
            this.txtTienThucTra.Focus();
            this.txtTienThucTra.SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmPhieuXuat_TraTienThua_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                    this.Close();
        }
    }
}