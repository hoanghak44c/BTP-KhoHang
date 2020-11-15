using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CrystalDecisions.Shared;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frm_XuatHuyTieuHao : frmBCBase
    {
        int IdChungTu;
        int CurrentIndex = 0;
        DataTable dtChungTu;
        bool Updating = false;
        Utils ut = new Utils();

        public frm_XuatHuyTieuHao()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frm_XuatHuyTieuHao(int IdChungTu)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.IdChungTu = IdChungTu;
        }

        private void GetChungTuData()
        {
            string sql = "Select IdChungTu, SoChungTu, NgayLap, IdNhanVien, IdKho, GhiChu from tbl_ChungTu where LoaiChungTu=" + Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO);
            //sql += " and NgayLap > '" + Declare.NgayKhoaSo.ToString(new CultureInfo("en-US")) + "'";
            //sql += " and NgayLap >= '" + Declare.NgayLamViec.ToString(new CultureInfo("en-US")) + "'";
            sql += string.Format(" and ThoigianSua >=  convert(datetime,'{0}',103) ", Common.Date2String(Declare.NgayLamViec));
            sql += " and IdKho = " + Declare.IdKho;
            sql += " order by NgayLap desc";
            dtChungTu = DBTools.getData("Temp", sql).Tables["Temp"];
        }

        private void EnableForm(Control parent, bool enabled)
        {
            foreach (Control ctl in parent.Controls) {
                if (ctl.GetType() == typeof(TextBox) ||// ctl.GetType() == typeof(ComboBox) ||
                    ctl.GetType() == typeof(Button) || ctl.GetType() == typeof(DateTimePicker)) {
                    ctl.Enabled = enabled;
                }
                if (ctl.HasChildren) {
                    EnableForm(ctl, enabled);
                }
            }
        }

        private void EnableMenuFunc()
        {
            tsbUpdate.Enabled = Updating;
            tsbAdd.Enabled = !Updating;
            tsbEdit.Enabled = !Updating & IdChungTu != 0;
            tsbDelete.Enabled = IdChungTu != 0;
            tsbPrev.Enabled = CurrentIndex > 0;
            tsbNext.Enabled = dtChungTu != null && CurrentIndex < dtChungTu.Rows.Count - 1;
        }

        private void LoadFormIndex()
        {
            if (dtChungTu == null || CurrentIndex >= dtChungTu.Rows.Count || CurrentIndex < 0) return;
            txtSoPhieu.Text = dtChungTu.Rows[CurrentIndex]["SoChungTu"].ToString();
            txtGhiChu.Text = dtChungTu.Rows[CurrentIndex]["GhiChu"].ToString();
            cboNhanVien.SelectedValue = dtChungTu.Rows[CurrentIndex]["IdNhanVien"];
            cboKho.SelectedValue = dtChungTu.Rows[CurrentIndex]["IdKho"];
            dtNgayHuy.Value = (DateTime)dtChungTu.Rows[CurrentIndex]["NgayLap"];
            string sql = "select hh.MaVach, sp.MaSanPham, sp.TenSanPham, dvt.TenDonViTinh, kho.TenKho, cthh.SoLuong, ctct.DonGia,";
            sql += " cthh.SoLuong * ctct.DonGia ThanhTien, sp.IdSanPham, hh.IdChiTiet from dbo.tbl_ChungTu_ChiTiet_HangHoa cthh";
            sql += " inner join tbl_ChungTu_Chitiet ctct on cthh.IdChiTietChungTu = ctct.IdChiTiet";
            sql += " inner join tbl_ChungTu ct on ctct.IdChungTu = ct.IdChungTu";
            sql += " inner join tbl_SanPham sp on ctct.IdSanPham = sp.IdSanPham";
            sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh = sp.IdDonViTinh";
            sql += " inner join tbl_DM_Kho kho on kho.IdKho = ct.IdKho";
            sql += " inner join tbl_HangHoa_ChiTiet hh on hh.IdChiTiet = cthh.IdChiTietHangHoa";
            sql += " where ct.IdChungTu=" + dtChungTu.Rows[CurrentIndex]["IdChungTu"].ToString();
            IdChungTu = Convert.ToInt32(dtChungTu.Rows[CurrentIndex]["IdChungTu"]);
            dgvList.Rows.Clear();
            DataTable dtChiTiet = DBTools.getData("Tmp", sql).Tables["Tmp"];
            if (dtChiTiet != null) {
                foreach (DataRow dr in dtChiTiet.Rows) {
                    object[] field ={
                            dr["MaVach"],
                            dr["MaSanPham"],
                            dr["TenSanPham"],
                            dr["TenDonViTinh"],
                            dr["SoLuong"],
                            dr["DonGia"],
                            dr["ThanhTien"],
                            dr["IdSanPham"],
                            dr["IdChiTiet"],
                            dr["SoLuong"]
                        };
                    dgvList.Rows.Add(field);
                }
            }
            txtTongTien.Text = Common.Double2Str(TongThanhTien());
        }

        private void Form_Refresh() {
            //cboKho.SelectedIndex = -1;
            //cboKho.Enabled = true;
            cboNhanVien.SelectedIndex = -1;
            cboNhanVien.Enabled = true;
            txtSoPhieu.Text = Common.TaoSoPhieuTuDong("XH", "tbl_ChungTu", "SoChungTu");
            txtSoPhieu.Enabled = true;
            txtSoSeri.Text = String.Empty;
            txtSoSeri.Enabled = true;
            txtGhiChu.Text = String.Empty;
            txtGhiChu.Enabled = true;
            dtNgayHuy.Enabled = true;
            dgvList.Rows.Clear();
            IdChungTu = 0;
        }

        private void frm_XuatHuyTieuHao_Load(object sender, EventArgs e)
        {
            LoadCommboKho();
            LoadCommboNhanVien();
            LayMaVach();
            GetChungTuData();
            LoadFormIndex();
            EnableMenuFunc();
            EnableForm(this, false);
        }

        private void UpdateChiTiet(int IdChungTu, int IdSanPham, int SoLuong, double DonGia ) {
            GtidCommand sqlcmd = new GtidCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.CommandText = "sp_tbl_ChungTu_XuatHuyTieuHao_ChiTiet_Insert";
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@IdChiTiet", 0).Direction = ParameterDirection.Output;
            sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu);
            sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSanPham);
            sqlcmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            sqlcmd.Parameters.AddWithValue("@DonGia", DonGia);
            sqlcmd.Parameters.AddWithValue("@ThanhTien", SoLuong * DonGia);
            if (!DBTools.InsertRecord(sqlcmd)) {
                throw DBTools._LastError;
            }
            int IdChungTuChiTiet = int.Parse(sqlcmd.Parameters["@IdChiTiet"].Value.ToString());

            sqlcmd.CommandText = "sp_tbl_ChungTu_ChiTiet_HangHoa_Insert";
            for (int i = 0; i < dgvList.Rows.Count; i++) {
                if (IdSanPham == int.Parse(dgvList.Rows[i].Cells["IdSanPham"].Value.ToString())) {
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@IdChiTietChungTu", IdChungTuChiTiet);
                    sqlcmd.Parameters.AddWithValue("@IdChiTietHangHoa", dgvList.Rows[i].Cells["IdChiTietHangHoa"].Value);
                    sqlcmd.Parameters.AddWithValue("@SoLuong", dgvList.Rows[i].Cells["SoLuong"].Value);
                    if (!DBTools.InsertRecord(sqlcmd)) {
                        throw DBTools._LastError;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try {
                txtMaVach.Text = txtMaVach.Text.Replace("'", "");
                if (!Valid()) return;
                string tmp = DBTools.getValue(String.Format("Select SoLuong from tbl_HangHoa_ChiTiet where MaVach=N'{0}' and IdKho={1} and SoLuong > 0", txtMaVach.Text, cboKho.SelectedValue));
                if (String.IsNullOrEmpty(tmp)) {
                    MessageBox.Show("Mã vạch này không còn trong kho, không thể hủy được!");
                    txtMaVach.Focus();
                    return;
                }
                int soluong = int.Parse(tmp);

                if (soluong == 0) {
                    MessageBox.Show("Hàng trong kho này đã hết, không thể hủy được");
                    txtMaVach.Focus();
                    return;
                }

                foreach (DataGridViewRow dgr in dgvList.Rows) {
                    if (dgr.Cells["MaVach"].Value.ToString() == txtMaVach.Text) {
                        if (int.Parse(dgr.Cells["SoLuong"].Value.ToString()) < soluong) {
                            tmp = DBTools.getValue(String.Format(@"select sp.TrungMaVach from tbl_HangHoa_ChiTiet hhct 
                                inner join tbl_SanPham sp on sp.IdSanPham = hhct.IdSanPham
                                where hhct.MaVach=N'{0}' and hhct.IdKho={1} and hhct.SoLuong > 0", txtMaVach.Text, Common.IntValue(cboKho.SelectedValue)));
                            bool TrungMaVach = String.IsNullOrEmpty(tmp) ? false : Convert.ToBoolean(tmp);
                            if (!TrungMaVach) {
                                MessageBox.Show("Loại sản phẩm này không được phép trùng mã vạch");
                                txtMaVach.Focus();
                                return;
                            }
                            dgr.Cells["SoLuong"].Value = int.Parse(dgr.Cells["SoLuong"].Value.ToString()) + 1;
                            txtMaVach.Focus();
                            return;
                        }
                        else {
                            MessageBox.Show("Đã đủ số lượng hàng trong kho, không thể nhập thêm nữa");
                            txtMaVach.Focus();
                            return;
                        }
                    }
                }
                DataTable dt = DBTools.getData("Tmp", String.Format("select * from vChiTietChungTu where MaVach=N'{0}' and IdKho={1} and SoLuong > 0", txtMaVach.Text, Declare.IdKho)).Tables["Tmp"];
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
                        dt.Rows[0]["IdChiTiet"],
                        0
                    };
                    dgvList.Rows.Add(field);
                    DataGridViewRow newRow = dgvList.Rows[dgvList.Rows.Count - 1];
                    tmp = DBTools.getValue(String.Format(@"select TrungMaVach from tbl_SanPham where IdSanPham = {0}", Common.IntValue(dt.Rows[0]["IdSanPham"])));
                    bool TrungMaVach = String.IsNullOrEmpty(tmp) ? false : Convert.ToBoolean(tmp);
                    newRow.Cells["SoLuong"].ReadOnly = !TrungMaVach;                    
                }

                txtTongTien.Text = Common.Double2Str(TongThanhTien());
                SelectText();
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
        
        private void SelectText() {
            txtMaVach.SelectionStart = 0;
            txtMaVach.SelectionLength = txtMaVach.Text.Length;
        }

        private double TongThanhTien()
        {
            double value = 0;
            foreach (DataGridViewRow dgr in dgvList.Rows) {
                value += Convert.ToDouble(dgr.Cells["ThanhTien"].Value);
            }
            return value;
        }

        private void LoadCommboNhanVien()
        {
            string str = "Select DISTINCT nv.IdNhanVien, nv.maNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                 " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien " +
                 " Where knv.IdKho = " + Declare.IdKho + " and nv.SuDung = 1  order by nv.HoTen ASC";

            DataTable dtNhanVien = DBTools.getData("tbl_DM_NhanVien", str).Tables["tbl_DM_NhanVien"];
            if (dtNhanVien != null) {
                this.cboNhanVien.DisplayMember = "HoTen";
                this.cboNhanVien.ValueMember = "IdNhanVien";
                this.cboNhanVien.DataSource = dtNhanVien;
                //this.cboNhanVien.SelectedIndex = -1;
            }
        }

        private void LoadCommboKho()
        {
            string str = "Select DISTINCT kh.IdKho, kh.MaKho + ' - ' + kh.TenKho AS KhoBan From tbl_DM_Kho kh " +
                  " Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                  " Inner Join tbl_DM_NhanVien nv On knv.IdNhanVien = nv.IdNhanVien " +
                  " Inner Join tbl_DM_NguoiDung nd On nv.IdNhanVien = nd.IdNhanVien " +
                  " where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + " order by KhoBan ASC";
            DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
            if (dtKho != null) {
                this.cboKho.DisplayMember = "KhoBan";
                this.cboKho.ValueMember = "IdKho";
                this.cboKho.DataSource = dtKho;
                if (Declare.IdKho>0)
                    this.cboKho.SelectedValue = Declare.IdKho;
            }
        }

        private bool LayMaVach()
        {
            string str;
            //str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
            //      " Where hh.IdKho in (Select DISTINCT kh.IdKho From tbl_DM_Kho kh " +
            //      " inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
            //      " inner Join tbl_DM_NhanVien nv On knv.IdNhanVien = nv.IdNhanVien " +
            //      " Inner Join tbl_DM_NguoiDung nd On nv.IdNhanVien = nd.IdNhanVien " +
            //      " where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + ") and hh.SoLuong > 0 order by hh.MaVach ASC";
            str = "Select DISTINCT hh.MaVach From tbl_HangHoa_Chitiet hh " +
                  " Where hh.IdKho = " + Declare.IdKho + " and hh.SoLuong > 0  order by hh.MaVach ASC";
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

        private bool Valid() {
            if (cboKho.SelectedValue == null) {
                MessageBox.Show("Bạn chưa chọn kho");
                cboKho.Focus();
                return false;
            }
            if (cboNhanVien.SelectedValue == null) {
                MessageBox.Show("Bạn chưa chọn nhân viên");
                cboNhanVien.Focus();
                return false;
            }
            return true;
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) {
                btnThem_Click(this, null);
            }
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46) {
                dgvList.Rows.Remove(dgvList.CurrentRow);
                txtTongTien.Text = Common.Double2Str(TongThanhTien());
            }
        }

        private void txtMaVach_Enter(object sender, EventArgs e)
        {
            txtMaVach.SelectionStart = 0;
            txtMaVach.SelectionLength = txtMaVach.Text.Length;
            this.txtMaVach.Focus();
            this.txtMaVach.SelectAll();
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.CurrentRow != null) {
                if (dgvList.CurrentRow.Cells[e.ColumnIndex] == dgvList.CurrentRow.Cells["SoLuong"]) {
                    dgvList.CurrentRow.Cells["ThanhTien"].Value = int.Parse(dgvList.CurrentRow.Cells["SoLuong"].Value.ToString()) * int.Parse(dgvList.CurrentRow.Cells["DonGia"].Value.ToString());
                }
                txtTongTien.Text = Common.Double2Str(TongThanhTien());
            }            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null) return;
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                dgvList.Rows.Remove(dgvList.CurrentRow);
                txtTongTien.Text = Common.Double2Str(TongThanhTien());
            }
        }

        private void txtMaVach_DoubleClick(object sender, EventArgs e)
        {
            txtMaVach.SelectionStart = 0;
            txtMaVach.SelectionLength = txtMaVach.Text.Length;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            try {
                if (dgvList.Rows.Count == 0) {
                    MessageBox.Show("Phải có ít nhất một mặt hàng");
                    return;
                }
                if (!Valid()) return;
                GtidCommand sqlcmd = new GtidCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                ConnectionUtil.Instance.BeginTransaction();
                if (IdChungTu == 0) {
                    if (txtSoPhieu.Text == "")
                    {
                        txtSoPhieu.Text = Common.TaoSoPhieuTuDong("XH", "tbl_ChungTu", "SoChungTu"); 
                    }                   

                    sqlcmd.Parameters.Clear();
                    sqlcmd.CommandText = "sp_tbl_ChungTu_XuatHuyTieuHao_Insert";
                    sqlcmd.Parameters.AddWithValue("@IdChungTu", 0).Direction = ParameterDirection.Output;
                    sqlcmd.Parameters.AddWithValue("@LoaiChungTu", TransactionType.XUAT_HUY_TIEU_HAO);
                    sqlcmd.Parameters.AddWithValue("@SoSeri", txtSoSeri.Text);
                    sqlcmd.Parameters.AddWithValue("@SoChungTu", txtSoPhieu.Text);
                    sqlcmd.Parameters.AddWithValue("@NgayLap", dtNgayHuy.Value);
                    sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@IdNhanVien", cboNhanVien.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(txtTongTien.Text));
                    sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName);
                    DateTime date = DateTime.Now;
                    sqlcmd.Parameters.AddWithValue("@ThoigianTao", date);
                    sqlcmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay);
                    sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName);
                    sqlcmd.Parameters.AddWithValue("@ThoigianSua", date);
                    sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay);
                    if (!DBTools.InsertRecord(sqlcmd)) {
                        throw DBTools._LastError;
                    }

                    IdChungTu = int.Parse(sqlcmd.Parameters["@IdChungTu"].Value.ToString());

                    dgvList.Sort(dgvList.Columns["IdSanPham"], ListSortDirection.Ascending);
                    int IdSanPham = 0;
                    int SoLuong = 0;
                    double DonGia = 0;

                    foreach (DataGridViewRow dgr in dgvList.Rows) {
                        if (IdSanPham == 0) {
                            IdSanPham = int.Parse(dgr.Cells["IdSanPham"].Value.ToString());
                            SoLuong = int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                            DonGia = double.Parse(dgr.Cells["DonGia"].Value.ToString());
                        }
                        else if (IdSanPham == int.Parse(dgr.Cells["IdSanPham"].Value.ToString())) {
                            SoLuong += int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                        else {
                            UpdateChiTiet(IdChungTu, IdSanPham, SoLuong, DonGia);
                            IdSanPham = int.Parse(dgr.Cells["IdSanPham"].Value.ToString());
                            SoLuong = int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                            DonGia = double.Parse(dgr.Cells["DonGia"].Value.ToString());
                        }
                        
                    }
                    UpdateChiTiet(IdChungTu, IdSanPham, SoLuong, DonGia);

                    CurrentIndex = dtChungTu == null ? 0 : dtChungTu.Rows.Count;
                    //sqlcmd.CommandText = "sp_tbl_ChungTu_ChiTiet_HangHoa_Insert";

                    //int IdKho = int.Parse(DBTools.getValue(String.Format("Select IdKho from tbl_DM_Kho where MaKho='{0}'", dgr.Cells["MaKho"].Value)));
                    //QLBanHang.Class.Common.LogAction("Tạo mới xuất hủy", "IdChungTu " + IdChungTu, IdKho);

                }
                else {
                    sqlcmd.CommandText = "sp_tbl_ChungTu_XuatHuyTieuHao_Update";
                    sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu);
                    sqlcmd.Parameters.AddWithValue("@LoaiChungTu", TransactionType.XUAT_HUY_TIEU_HAO);
                    sqlcmd.Parameters.AddWithValue("@SoSeri", txtSoSeri.Text);
                    sqlcmd.Parameters.AddWithValue("@SoChungTu", txtSoPhieu.Text);
                    sqlcmd.Parameters.AddWithValue("@NgayLap", dtNgayHuy.Value);
                    sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@IdNhanVien", cboNhanVien.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(txtTongTien.Text));
                    DateTime date = DateTime.Now;
                    sqlcmd.Parameters.AddWithValue("@NguoiSua", Declare.UserName);
                    sqlcmd.Parameters.AddWithValue("@ThoigianSua", date);
                    sqlcmd.Parameters.AddWithValue("@TenMaySua", Declare.TenMay);
                    if (!DBTools.UpdateRecord(sqlcmd)) {
                        throw DBTools._LastError;
                    }

                    sqlcmd.CommandText = "sp_tbl_ChungTu_XuatHuyTieuHao_ChiTiet_Delete";
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu);
                    if (!DBTools.DeleteRecord(sqlcmd)) {
                        throw DBTools._LastError;
                    }

                    dgvList.Sort(dgvList.Columns["IdSanPham"], ListSortDirection.Ascending);
                    int IdSanPham = 0;
                    int SoLuong = 0;
                    double DonGia = 0;

                    foreach (DataGridViewRow dgr in dgvList.Rows) {
                        if (IdSanPham == int.Parse(dgr.Cells["IdSanPham"].Value.ToString())) {
                            SoLuong += int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                        }
                        else {
                            if (IdSanPham != 0) UpdateChiTiet(IdChungTu, IdSanPham, SoLuong, DonGia);
                            IdSanPham = int.Parse(dgr.Cells["IdSanPham"].Value.ToString());
                            SoLuong = int.Parse(dgr.Cells["SoLuong"].Value.ToString());
                            DonGia = double.Parse(dgr.Cells["DonGia"].Value.ToString());
                        }
                    }
                    UpdateChiTiet(IdChungTu, IdSanPham, SoLuong, DonGia);

                    //int IdKho = int.Parse(DBTools.getValue(String.Format("Select IdKho from tbl_DM_Kho where MaKho='{0}'", dgr.Cells["MaKho"].Value)));
                    //QLBanHang.Class.Common.LogAction("Cập nhật xuất hủy", "IdChungTu " + IdChungTu, IdKho);
                }
                ConnectionUtil.Instance.CommitTransaction();
                MessageBox.Show("Đã cập nhật thành công");
                Updating = false;
                GetChungTuData();
                EnableForm(this, false);
                EnableMenuFunc();
                foreach (DataGridViewRow dgr in dgvList.Rows)
                {
                    dgr.Cells["SoLuongDau"].Value = Common.IntValue(dgr.Cells["SoLuong"].Value);
                }
            }
            catch (System.Exception ex) {
                ConnectionUtil.Instance.RollbackTransaction();
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif

            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try {
                if (IdChungTu > 0) {
                    if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        GtidCommand sqlcmd = new GtidCommand();
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "sp_tbl_ChungTu_XuatHuyTieuHao_Delete";
                        sqlcmd.Parameters.AddWithValue("@IdChungTu", IdChungTu);
                        DBTools.ExecuteScalar(sqlcmd);
                        dgvList.Rows.Clear();
                        MessageBox.Show("Đã xóa thành công");
                        //int IdKho = int.Parse(DBTools.getValue(String.Format("Select IdKho from tbl_DM_Kho where MaKho='{0}'", dgr.Cells["MaKho"].Value)));
                        //QLBanHang.Class.Common.LogAction("Xóa xuất hủy", "IdChungTu " + IdChungTu, IdKho);
                        GetChungTuData();
                        if (CurrentIndex >= dtChungTu.Rows.Count) CurrentIndex--;
                        LoadFormIndex();
                        EnableForm(this, false);
                        EnableMenuFunc();
                    }
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

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Form_Refresh();
            EnableForm(this, true);
            Updating = true;
            EnableMenuFunc();
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            if (CurrentIndex > 0) {
                if (Updating) {
                    if (MessageBox.Show("Dữ liệu đang cập nhật, bạn có muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                CurrentIndex--;
                EnableForm(this, false);
                Updating = false;
                LoadFormIndex();
                EnableMenuFunc();
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (CurrentIndex < dtChungTu.Rows.Count) {
                if (Updating) {
                    if (MessageBox.Show("Dữ liệu đang cập nhật, bạn có muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                CurrentIndex++;
                EnableForm(this, false);
                Updating = false;
                LoadFormIndex();
                EnableMenuFunc();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            EnableForm(this, true);
            Updating = true;
            EnableMenuFunc();
        }

        private void frm_XuatHuyTieuHao_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (!this.dgvList.Focused && !this.txtMaVach.Focused && !this.txtGhiChu.Focused)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                        return;
                    }
                    else if (e.KeyCode == Keys.F2)
                    {
                        if (this.WindowState == FormWindowState.Maximized)
                            this.WindowState = FormWindowState.Normal;
                        else
                            this.WindowState = FormWindowState.Maximized;
                        e.Handled = true;
                        return;
                    }
                }

                if (e.KeyCode == Keys.F3 && tsbPrev.Enabled)
                    this.tsbPrev_Click(sender, e);
                else if (e.KeyCode == Keys.F4 && tsbNext.Enabled)
                    this.tsbNext_Click(sender, e);
                else if (e.KeyCode == Keys.F5 && tsbAdd.Enabled)
                    this.tsbAdd_Click(sender, e);
                else if (e.KeyCode == Keys.F6 && tsbEdit.Enabled)
                    this.tsbEdit_Click(sender, e);
                else if (e.KeyCode == Keys.F7 && tsbUpdate.Enabled)
                    this.tsbUpdate_Click(sender, e);
                else if (e.KeyCode == Keys.F8 && tsbDelete.Enabled)
                    this.tsbDelete_Click(sender, e);
                else if (e.KeyCode == Keys.F12 && tsbClose.Enabled)
                    this.tsbClose_Click(sender, e);
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
//            try {
//                if (cboKho.SelectedValue == null) return;
//                string sql = "select SUM(SoLuong) from tbl_HangHoa_Chitiet where IdKho=" + cboKho.SelectedValue;
//                object result = DBTools.ExecuteScalar(sql);
//                if (Common.IntValue(result) <= 0)
//                    MessageBox.Show("Không còn mặt hàng nào trong kho");
//                dgvList.Rows.Clear();
//            }
//            catch (System.Exception ex) {
//#if DEBUG
//                MessageBox.Show(ex.ToString());
//#else
//                MessageBox.Show(ex.Message);
//#endif
//            }
        }
        protected override object OnSetDataSource()
        {
            string sql = string.Format(@"SELECT     dbo.tbl_HangHoa_Chitiet.IdChiTiet, dbo.tbl_SanPham.IdSanPham, dbo.tbl_HangHoa_Chitiet.MaVach, dbo.tbl_SanPham.MaSanPham, 
                      dbo.tbl_SanPham.TenSanPham, dbo.tbl_DM_DonViTinh.TenDonViTinh, dbo.tbl_ChungTu_ChiTiet_HangHoa.SoLuong, 
                      dbo.tbl_DM_Kho.TenKho AS KhoDi, dbo.tbl_ChungTu.NgayLap, dbo.tbl_ChungTu.SoChungTu, dbo.tbl_DM_NhanVien.HoTen AS NguoiVanChuyen, 
                      dbo.tbl_ChungTu.IdChungTu
FROM         dbo.tbl_ChungTu_ChiTiet_HangHoa INNER JOIN
                      dbo.tbl_ChungTu_Chitiet ON dbo.tbl_ChungTu_ChiTiet_HangHoa.IdChiTietChungTu = dbo.tbl_ChungTu_Chitiet.IdChitiet INNER JOIN
                      dbo.tbl_HangHoa_Chitiet INNER JOIN
                      dbo.tbl_SanPham ON dbo.tbl_HangHoa_Chitiet.IdSanPham = dbo.tbl_SanPham.IdSanPham ON 
                      dbo.tbl_ChungTu_ChiTiet_HangHoa.IdChiTietHangHoa = dbo.tbl_HangHoa_Chitiet.IdChiTiet INNER JOIN
                      dbo.tbl_DM_DonViTinh ON dbo.tbl_SanPham.IdDonViTinh = dbo.tbl_DM_DonViTinh.IdDonViTinh INNER JOIN
                      dbo.tbl_ChungTu ON dbo.tbl_ChungTu_Chitiet.IdChungTu = dbo.tbl_ChungTu.IdChungTu INNER JOIN
                      dbo.tbl_DM_Kho ON dbo.tbl_ChungTu.IdKho = dbo.tbl_DM_Kho.IdKho INNER JOIN
                      dbo.tbl_DM_NhanVien ON dbo.tbl_ChungTu.IdNhanVien = dbo.tbl_DM_NhanVien.IdNhanVien
WHERE     (dbo.tbl_ChungTu.IdChungTu = {0})", IdChungTu);
            DataSet ds = ut.getDataSet(sql, "vBCXuatHuyTieuHao");
            return ds;
        }

        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            myParams.Clear();
            ut.SetParameterReport(myParams, "pTrungTam", Declare.TenTrungTam);
            ut.SetParameterReport(myParams, "pKho", cboKho.Text);
            ut.SetParameterReport(myParams, "pSoSeri", String.Empty);
            ut.SetParameterReport(myParams, "pNhanVien", cboNhanVien.Text);
            ut.SetParameterReport(myParams, "pSoPhieu", txtSoPhieu.Text);
        }

        protected override void OnLoadReport()
        {
            rpt = new rpt_BC_XuatHuyTieuHao();
            base.SetParameterFields();
            base.SetDataSource();
        }

        private void tsbIn_Click(object sender, EventArgs e)
        {
            ShowReport("Xuất hủy tiêu hao");
        }

        private void dgvList_Validating(object sender, CancelEventArgs e)
        {
         
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                if (dgvList.CurrentRow.Cells[e.ColumnIndex] == dgvList.CurrentRow.Cells["SoLuong"])
                {
                    bool loi = false;
                    if (ut.getInt(dgvList.CurrentRow.Cells["SoLuong"].Value) == 0)
                    {
                        MessageBox.Show("Số lượng phải >0");
                        loi = true;
                    }
                    int tondb = Common.IntValue(DBTools.getValue(String.Format("Select SoLuong From tbl_hanghoa_chitiet where IdKho={0} and IdSanPham={1} and MaVach=N'{2}'", Common.IntValue(cboKho.SelectedValue), Common.IntValue(dgvList.CurrentRow.Cells["IdSanPham"].Value), dgvList.CurrentRow.Cells["MaVach"].Value.ToString())));
                    int ton = tondb + int.Parse(dgvList.CurrentRow.Cells["SoLuongDau"].Value.ToString());
                    if (int.Parse(dgvList.CurrentRow.Cells["SoLuong"].Value.ToString()) > ton)
                    {
                        MessageBox.Show("Số lượng không vượt quá số lượng tồn là: " + ton);
                        loi = true;
                    }
                    if (loi)
                        e.Cancel = true;

                }
            }   
        }  
      
    }
}