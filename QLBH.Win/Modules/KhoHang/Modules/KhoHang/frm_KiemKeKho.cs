using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
using System.Data.SqlClient;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Forms
{
    public partial class frm_KiemKeKho : Form
    {
        int IdKiemKe = 0;

        public frm_KiemKeKho()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        private void frm_KiemKeKho_Load(object sender, EventArgs e)
        {
            LoadCommboKho();
            LoadCommboNhanVien();
            LayMaVach();
            LaySoPhieu();
        }

        private void LoadCommboKho()
        {
            string str = "Select DISTINCT kh.IdKho, kh.MaKho, kh.TenKho From tbl_DM_Kho kh " +
                  " Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                  " Inner Join tbl_DM_NhanVien nv On knv.IdNhanVien = nv.IdNhanVien " +
                  " Inner Join tbl_DM_NguoiDung nd On nv.IdNhanVien = nd.IdNhanVien " +
                  " where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + " order by kh.TenKho ASC";
            DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
            if (dtKho != null) {
                this.cboKho.DataSource = dtKho;
                this.cboKho.DisplayMember = "TenKho";
                this.cboKho.ValueMember = "IdKho";
                this.cboKho.SelectedValue = Declare.IdKho;
                this.cboKho.Enabled = false;
            }
        }

        private void LoadCommboNhanVien()
        {
            string str = "Select DISTINCT nv.IdNhanVien, nv.maNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                 " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien " +
                 " Where knv.IdKho in ( Select knv1.idKho From tbl_Kho_NhanVien knv1 " +
                 " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv1.IdNhanVien " +
                 " Where nd.IdNguoiDung = " + Declare.UserId + ") and (nv.SuDung = 1)  order by nv.HoTen ASC";

            DataTable dtNhanVien = DBTools.getData("tbl_DM_NhanVien", str).Tables["tbl_DM_NhanVien"];
            if (dtNhanVien != null) {
                this.cboNhanVien.DataSource = dtNhanVien;
                this.cboNhanVien.DisplayMember = "HoTen";
                this.cboNhanVien.ValueMember = "IdNhanVien";
                this.cboNhanVien.SelectedIndex = -1;
            }
        }

        private bool LayMaVach()
        {
            string str;
            str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
                  " Where hh.IdKho in (Select DISTINCT kh.IdKho From tbl_DM_Kho kh " +
                  " inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                  " inner Join tbl_DM_NhanVien nv On knv.IdNhanVien = nv.IdNhanVien " +
                  " Inner Join tbl_DM_NguoiDung nd On nv.IdNhanVien = nd.IdNhanVien " +
                  " where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + ") and hh.TrangThai in (1,2,3,5)  order by hh.MaVach ASC";
            //str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
            //      " Where hh.IdKho = " + Declare.IdKho + " in and hh.TrangThai in (1,2,3,5)  order by hh.MaVach ASC";
            DataTable dtMaVach = DBTools.getData("tbl_HangHoa_Chitiet", str).Tables["tbl_HangHoa_Chitiet"];
            if (dtMaVach == null)
                return false;
            else {
                // AutoCompleteStringCollection 
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                for (int i = 0; i < dtMaVach.Rows.Count; i++)
                    data.Add(dtMaVach.Rows[i]["MaVach"].ToString());

                txtMaVach.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMaVach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtMaVach.AutoCompleteCustomSource = data;

                return true;
            }
        }

        private void LaySoPhieu() {
            GtidCommand sqlcmd = new GtidCommand();
            sqlcmd.CommandText = "sp_KiemKe_SoHoaDonTuDong";
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@Code", "KK");
            txtSoPhieu.Text = (string)DBTools.ExecuteScalar(sqlcmd);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try {
                txtMaVach.Text = txtMaVach.Text.Replace("'", "");
                DataTable dt = DBTools.getData("Tmp", String.Format("select * from vChiTietChungTu where MaVach=N'{0}'", txtMaVach.Text)).Tables["Tmp"];
                //ItemStatus status = (ItemStatus)int.Parse(DBTools.getValue(String.Format("Select TrangThai from tbl_HangHoa_ChiTiet where MaVach='{0}'", txtMaVach.Text)));

                int IdKho = 0;
                int.TryParse(DBTools.getValue(String.Format("Select IdKho from tbl_HangHoa_ChiTiet where MaVach='{0}'", txtMaVach.Text)), out IdKho);

                if (cboKho.SelectedValue == null) {
                    MessageBox.Show("Hãy chọn kho");
                    return;
                }

                if (IdKho != int.Parse(cboKho.SelectedValue.ToString())) {
                    MessageBox.Show("Hàng này không thuộc kho đã chọn");
                    return;
                }

                string sql = String.Format("select TrungMaVach from tbl_HangHoa_ChiTiet hhct "
                    + "inner join tbl_SanPham sp on sp.IdSanPham=hhct.IdSanPham "
                    + "where hhct.MaVach=N'{0}'", txtMaVach.Text.Replace("'",""));
                bool TrungMaVach = false;
                bool.TryParse(DBTools.getValue(sql), out TrungMaVach);

                foreach (DataGridViewRow dgr in dgvList.Rows) {
                    if (dgr.Cells["MaVach"].Value.ToString().Equals(txtMaVach.Text)) {
                        if (!TrungMaVach) {
                            MessageBox.Show("Loại sản phẩm này không được phép nhập trùng mã vạch");
                            return;
                        }
                        dgvList.CurrentCell = dgr.Cells["SoLuong"];
                        dgvList.CurrentCell.Value = Common.IntValue(dgvList.CurrentCell.Value.ToString()) + 1;
                        return;
                    }
                }

                if (dt != null) {
                    object[] field ={
                        dt.Rows[0]["MaVach"],
                        dt.Rows[0]["MaSanPham"],
                        dt.Rows[0]["TenSanPham"],
                        dt.Rows[0]["TenDonViTinh"],
                        1,
                        dt.Rows[0]["GiaNhap"],
                        dt.Rows[0]["GiaNhap"],
                        dt.Rows[0]["IdSanPham"],
                        dt.Rows[0]["IdChiTiet"]
                    };
                    dgvList.Rows.Add(field);
                }
                txtTongTien.Text = Common.Double2Str(TongThanhTien());
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif

            }
        }

        private double TongThanhTien()
        {
            double value = 0;
            foreach (DataGridViewRow dgr in dgvList.Rows) {
                value += Convert.ToDouble(dgr.Cells["ThanhTien"].Value);
            }
            return value;
        }

        private void UpdateChiTiet(int IdKiemKe, int IdSanPham, int SoLuong)
        {
            GtidCommand sqlcmd = new GtidCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.CommandText = "sp_KiemKe_ChiTiet_Insert";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdChiTiet", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@IdKiemKe", IdKiemKe);
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSanPham);
            sqlcmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            if (!DBTools.InsertRecord(sqlcmd)) {
                throw DBTools._LastError;
            }
            int IdChiTietKiemKe = int.Parse(sqlcmd.Parameters["@IdChiTiet"].Value.ToString());

            sqlcmd.CommandText = "sp_KiemKe_ChiTiet_HangHoa_Insert";
            for (int i = 0; i < dgvList.Rows.Count; i++) {
                if (IdSanPham == int.Parse(dgvList.Rows[i].Cells["IdSanPham"].Value.ToString())) {
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@IdChiTietKiemKe", IdChiTietKiemKe);
                    sqlcmd.Parameters.AddWithValue("@IdChiTietHangHoa", dgvList.Rows[i].Cells["IdChiTietHangHoa"].Value);
                    sqlcmd.Parameters.AddWithValue("@SoLuong", dgvList.Rows[i].Cells["SoLuong"].Value);
                    if (!DBTools.InsertRecord(sqlcmd)) {
                        throw DBTools._LastError;
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try {
                GtidCommand sqlcmd = new GtidCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                if (IdKiemKe == 0) {
                    string sql = String.Format("select SoPhieu from tbl_KiemKe where SoPhieu ='{0}'", txtSoPhieu.Text);
                    if (DBTools.ExecuteScalar(sql) != null) {
                        MessageBox.Show("Số phiếu này đã được sử dụng, hãy dùng số khác");
                        return;
                    }
                    sqlcmd.CommandText = "sp_KiemKe_Insert";
                    sqlcmd.Parameters.AddWithValue("@IdKiemKe", 0).Direction = ParameterDirection.Output;
                    sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@NgayKiemKe", dtNgayKiemKe.Value);
                    sqlcmd.Parameters.AddWithValue("@SoPhieu", txtSoPhieu.Text);
                    sqlcmd.Parameters.AddWithValue("@IdNhanVien", cboNhanVien.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(txtTongTien.Text));
                    sqlcmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    if (!DBTools.InsertRecord(sqlcmd)) throw DBTools._LastError;
                    IdKiemKe = Convert.ToInt32(sqlcmd.Parameters["@IdKiemKe"].Value);

                    dgvList.Sort(dgvList.Columns["IdSanPham"], ListSortDirection.Ascending);
                    int IdSanPham = 0;
                    int SoLuong = 0;

                    foreach (DataGridViewRow dgr in dgvList.Rows) {
                        if (IdSanPham == 0) {
                            IdSanPham = int.Parse(dgr.Cells["IdSanPham"].Value.ToString());
                            SoLuong = int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                        else if (IdSanPham == int.Parse(dgr.Cells["IdSanPham"].Value.ToString())) {
                            SoLuong += int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                        else {
                            UpdateChiTiet(IdKiemKe, IdSanPham, SoLuong);
                            IdSanPham = int.Parse(dgr.Cells["IdSanPham"].Value.ToString());
                            SoLuong = int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                    }
                    UpdateChiTiet(IdKiemKe, IdSanPham, SoLuong);
                }
                else {
                    sqlcmd.CommandText = "sp_KiemKe_Update";
                    sqlcmd.Parameters.AddWithValue("@IdKiemKe", IdKiemKe);
                    sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@NgayKiemKe", dtNgayKiemKe.Value);
                    sqlcmd.Parameters.AddWithValue("@IdNhanVien", cboNhanVien.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(txtTongTien.Text));
                    sqlcmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    if (!DBTools.UpdateRecord(sqlcmd)) throw DBTools._LastError;

                    sqlcmd.CommandText = "sp_KiemKe_ChiTiet_Delete";
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@IdKiemKe", IdKiemKe);
                    if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;

                    dgvList.Sort(dgvList.Columns["IdSanPham"], ListSortDirection.Ascending);
                    int IdSanPham = 0;
                    int SoLuong = 0;

                    foreach (DataGridViewRow dgr in dgvList.Rows) {
                        if (IdSanPham == int.Parse(dgr.Cells["IdSanPham"].Value.ToString())) {
                            SoLuong += int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                        else {
                            if (IdSanPham != 0) UpdateChiTiet(IdKiemKe, IdSanPham, SoLuong);
                            IdSanPham = int.Parse(dgr.Cells["IdSanPham"].Value.ToString());
                            SoLuong = int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                    }
                    UpdateChiTiet(IdKiemKe, IdSanPham, SoLuong);
                }

            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (IdKiemKe != 0)
            {
                GtidCommand sqlcmd = new GtidCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_KiemKe_Delete";
                sqlcmd.Parameters.AddWithValue("@IdKiemKe", IdKiemKe);
                if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Remove(dgvList.CurrentRow);
            txtTongTien.Text = Common.Double2Str(TongThanhTien());
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                dgvList.Rows.Remove(dgvList.CurrentRow);
                txtTongTien.Text = Common.Double2Str(TongThanhTien());
            }
        }

        private void txtMaVach_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMaVach.Text)) {
                txtMaVach.SelectionStart = 0;
                txtMaVach.SelectionLength = txtMaVach.Text.Length;
            }

        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "SoLuong") {
                txtTongTien.Text = Common.Double2Str(TongThanhTien());
            }
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvList.Rows[e.RowIndex].IsNewRow) return;
            if (dgvList.Columns[e.ColumnIndex].Name == "SoLuong") {
                if (!Common.IsInteger32(e.FormattedValue.ToString())) {
                    e.Cancel = true;
                    MessageBox.Show("Chưa nhập đúng định dạng kiểu số nguyên");
                    return;
                }
                bool TrungMaVach = false;
                bool.TryParse(DBTools.getValue(String.Format("select TrungMaVach from tbl_HangHoa_ChiTiet hhct "
                    + "inner join tbl_SanPham sp on sp.IdSanPham=hhct.IdSanPham "
                    + "where hhct.MaVach=N'{0}'", dgvList.CurrentRow.Cells["MaVach"].Value)), out TrungMaVach);
                if (!TrungMaVach && int.Parse(e.FormattedValue.ToString()) > 1) {
                    e.Cancel = true;
                    MessageBox.Show("Loại sản phẩm này không được phép trùng mã vạch");
                    return;
                }
            }
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtMaVach.Text.Trim() != "")
                    btnThem_Click(sender, e);
            }
        }
    }
}