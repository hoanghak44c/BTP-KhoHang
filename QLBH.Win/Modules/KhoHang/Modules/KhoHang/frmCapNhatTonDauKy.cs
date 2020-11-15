using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;
using System.Collections;
using QLBanHang.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmCapNhatTonDauKy : DevExpress.XtraEditors.XtraForm
    {
        int _IdDuDauKy = 0;
        ArrayList arrTemp;
        List<int> deletedTemp;
        List<int> deletedTempDetail;

        public frmCapNhatTonDauKy()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        private void frmCapNhatTonDauKy_Load(object sender, EventArgs e)
        {
            LoadCommboKho();
            EnableFunctions();
        }

        private void EnableFunctions()
        {
            bool status = Common.IsEnableNhapDauKy(Common.IntValue(cboKho.SelectedValue));
            btnCapNhat.Enabled = status;
            btnXoa.Enabled = status;
            btnXoaChiTiet.Enabled = status;
        }

        private void LoadCommboKho()
        {
            this.cboKho.DisplayMember = "TenKho";
            this.cboKho.ValueMember = "IdKho";
            this.cboKho.DataSource = DMKhoDataProvider.Instance.GetListKhoByUser(Declare.UserId);
            if (Declare.IdKho > 0)
                this.cboKho.SelectedValue = Declare.IdKho;
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableFunctions();
            ValidNgayDuDau();
            //dtNgayDuDau.Value = Common.LayNgayDuDau(int.Parse(cboKho.SelectedValue.ToString()));
            dgvList.DataSource = null;
            dgvList.Refresh();
        }

        private bool ValidNgayDuDau()
        {
            if (cboKho.SelectedIndex == -1)
            {
                MessageBox.Show("Ngày dư đầu chưa được thiết lập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            DMKhoCBOLoadInfo khoInfo = (DMKhoCBOLoadInfo)cboKho.SelectedItem;
            dtNgayDuDau.Value = khoInfo.NgayDuDau < dtNgayDuDau.MinDate ? DateTime.Now.Date : khoInfo.NgayDuDau;
            return true;
        }

        private void btnNapSoTon_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show(Declare.msgNapSoDuDau, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                if (cboKho.SelectedValue == null) {
                    MessageBox.Show(Resources.KhoChuaNhap, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cboKho.Focus();
                    return;
                }else{
                    if (!ValidNgayDuDau()) return;
                }
                this.arrTemp = null;
                this.deletedTemp = null; 
                dgvList.DataSource = TonDauKyDataProvider.Instance.NapSoTon(Convert.ToInt32(cboKho.SelectedValue),
                                                                            dtNgayDuDau.Value.Date, Declare.UserId);
                dgvList.Refresh();
            }
            catch (Exception ex) { 
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.xls)|*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                txtFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnNapSoTonTuFile_Click(object sender, EventArgs e)
        {
            try {
                if (cboKho.SelectedValue == null) {
                    MessageBox.Show(Resources.KhoChuaNhap, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cboKho.Focus();
                    return;
                }
                else {
                    if (!ValidNgayDuDau()) return;
                }

                if (String.IsNullOrEmpty(txtFile.Text)) {
                    MessageBox.Show("Bạn chưa chọn file", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnChonFile.Focus();
                    return;
                }
                if (MessageBox.Show(Declare.msgNapSoDuDau, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    this.arrTemp = null;
                    this.deletedTemp = null;
                    OleDbConnection oConn = new OleDbConnection();
                    oConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtFile.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes\"";
                    oConn.Open();
                    string sql = "Select distinct [Mã hàng] as MaSanPham, [Tên hàng] as TenSanPham, [Đơn vị tính] as TenDonViTinh, [Số lượng] as SoLuongKhaiBao, 0 as SoLuong, [Giá nhập] as GiaNhap, [Số lượng] * [Giá nhập] as ThanhTien";
                    sql += " from [ITEM_TRANANH$] where [Mã hàng] is not null";
                    OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "Temp");
                    oConn.Close();
                    //ds.Tables["Temp"].Columns.Add(new DataColumn("ThanhTien", typeof(Double)));
                    ds.Tables["Temp"].Columns.Add(new DataColumn("IdSanPham", typeof(int)));
                    ds.Tables["Temp"].Columns.Add(new DataColumn("IdDuDauKy", typeof(int)));
                    dgvList.DataSource = ds.Tables["Temp"];
                    dgvList.Refresh();
                }
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif

            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "MaSanPham")
            {
                string sql = "select sp.IdSanPham, sp.TenSanPham, dvt.TenDonViTinh from tbl_SanPham sp";
                sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh= sp.IdDonViTinh";
                sql += " where sp.MaSanPham='" + dgvList.CurrentCell.Value.ToString() + "'";
                DataTable dt = DBTools.getData("tmp", sql).Tables["tmp"];
                //object result = DBTools.ExecuteScalar(sql);
                if (dt != null && dt.Rows.Count>0) {
                    dgvList.CurrentRow.Cells["IdSanPham"].Value = Common.IntValue(dt.Rows[0]["IdSanPham"]);
                    dgvList.CurrentRow.Cells["TenSanPham"].Value = dt.Rows[0]["TenSanPham"];
                    dgvList.CurrentRow.Cells["TenDonViTinh"].Value = dt.Rows[0]["TenDonViTinh"];
                    dgvList.CurrentRow.Cells["GiaNhap"].ReadOnly = false;// dt.Rows[0]["TenDonViTinh"];
                    dgvList.CurrentRow.Cells["SoLuong"].Value = 0;
                }
            }
        }

        private void btnNhapChiTiet_Click(object sender, EventArgs e)
        {
            try {
                string sql;
                if (dgvList.CurrentRow == null) return;
                if (!dgvList.CurrentCell.Selected) return;
                if (dgvList.CurrentRow.Cells["MaSanPham"].Value == null) {
                    MessageBox.Show("Bạn chưa nhập mã sản phẩm");
                    return;
                }
                sql = "select sp.IdSanPham from tbl_SanPham sp";
                sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh= sp.IdDonViTinh";
                sql += " where sp.MaSanPham='" + dgvList.CurrentRow.Cells["MaSanPham"].Value.ToString() + "'";
                object result = DBTools.ExecuteScalar(sql);
                if (result == null) {
                    MessageBox.Show("Mã sản phẩm này không có trong danh mục");
                    return;
                }
                dgvList.CurrentRow.Cells["IdSanPham"].Value = result;
                int IdSanPham = Convert.ToInt32(result);

                if (this.arrTemp == null) this.arrTemp = new ArrayList();
                bool found = false;
                foreach (DataTable dt in this.arrTemp) {
                    if (dt.TableName == IdSanPham.ToString()) {
                        found = true;
                        break;
                    }
                }
                if(!found){
                    sql = "select hhct.MaVach, dvt.TenDonViTinh, hhct.SoLuong, ddk.DonGia, hhct.SoLuong * ddk.DonGia as ThanhTien, hhct.IdChiTiet as IdChiTietHangHoa from tbl_HangHoa_Chitiet hhct";
                    sql += " inner join tbl_HangHoa_DuDauKy ddk on ddk.IdDuDauKy = hhct.IdDuDauKy";
                    sql += " inner join tbl_SanPham sp on sp.IdSanPham = hhct.IdSanPham";
                    sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh = sp.IdDonViTinh";
                    sql += " where ddk.ThoiGian='" + dtNgayDuDau.Value.Date.ToString(new CultureInfo("en-US")) + "'" ;
                    sql += " and ddk.IdKho= " + cboKho.SelectedValue;
                    sql += " and hhct.IdSanPham =" + IdSanPham;
                    DataTable dt = DBTools.getData(IdSanPham.ToString(), sql).Tables[IdSanPham.ToString()];
                    this.arrTemp.Add(dt);
                }

                if (deletedTempDetail == null)
                    deletedTempDetail = new List<int>();

                Form frm = new frmCapNhatTonDauKy_ChiTietHangHoa(IdSanPham, _IdDuDauKy, dgvList.CurrentRow.Cells["SoLuong"]
                    , dgvList.CurrentRow.Cells["ThanhTien"], dgvList.CurrentRow.Cells["TenDonViTinh"]
                    , this.arrTemp, deletedTempDetail
                    , dgvList.CurrentRow.Cells["GiaNhap"].Value == DBNull.Value ? 0 : Convert.ToDouble(dgvList.CurrentRow.Cells["GiaNhap"].Value)
                    , dgvList.CurrentRow.Cells["SoLuongKhaiBao"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvList.CurrentRow.Cells["SoLuongKhaiBao"].Value)
                    , Common.IntValue(cboKho.SelectedValue));
                frm.ShowDialog();
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try {
                if (cboKho.SelectedValue == null) {
                    MessageBox.Show(Resources.KhoChuaNhap, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cboKho.Focus();
                    return;
                }
                else {
                    if (!ValidNgayDuDau()) return;
                }
                string sql = String.Empty;
                GtidCommand sqlcmd = new GtidCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                ConnectionUtil.Instance.BeginTransaction();

                //xoa nhung mat hang da bi xoa khoi grid
                if (deletedTemp != null)
                {
                    sqlcmd.CommandText = "sp_CapNhatTonDauKy_Delete";
                    foreach (int i in deletedTemp)
                    {
                        sqlcmd.Parameters.Clear();
                        sqlcmd.Parameters.AddWithValue("@ThoiGian", dtNgayDuDau.Value.Date);
                        sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                        sqlcmd.Parameters.AddWithValue("@IdSanPham", i);
                        sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId);
                        if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;
                    }
                    deletedTemp = null;
                }
                if (deletedTempDetail != null)
                {
                    sqlcmd.CommandType = CommandType.Text;
                    foreach (int i in deletedTempDetail)
                    {
                        sqlcmd.CommandText = "Delete tbl_HangHoa_Chitiet where IdChiTiet=" + i;
                        if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;
                    }
                    deletedTempDetail = null;
                }
                sqlcmd.CommandText = "sp_tbl_HH_DuDauKy_Temp_Delete";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId);
                if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;

                //them cac mat hang co trong grid
                foreach (DataGridViewRow dgr in dgvList.Rows) {
                    if (dgr.IsNewRow) continue;

                    if (dgr.Cells["MaSanPham"].Value == null) {
                        throw new Exception("Bạn chưa nhập mã sản phẩm");
                    }
                    sql = "select sp.IdSanPham from tbl_SanPham sp";
                    sql += " where sp.MaSanPham='" + dgr.Cells["MaSanPham"].Value.ToString() + "'";
                    object result = DBTools.ExecuteScalar(sql);
                    if (result == null) {
                        throw new ManagedException(String.Format("Mã sản phẩm '{0}'này không có trong danh mục", dgr.Cells["MaSanPham"].Value));
                    }else{
                        dgr.Cells["IdSanPham"].Value = result;
                    }
                    sqlcmd.CommandText = "sp_tbl_HH_DuDauKy_Temp_Insert";
                    sqlcmd.Parameters.Clear();
                    sqlcmd.Parameters.AddWithValue("@ThoiGian", dtNgayDuDau.Value.Date);
                    sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                    sqlcmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                    int slNhap = Common.IntValue(dgr.Cells["SoLuong"].Value);
                    int slKBao = Common.IntValue(dgr.Cells["SoLuongKhaiBao"].Value);
                    if (slNhap != 0 && slNhap != slKBao)
                        slKBao = slKBao - slNhap;
                    sqlcmd.Parameters.AddWithValue("@SoLuongKhaiBao", slKBao);
                    sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId);
                    sqlcmd.Parameters.AddWithValue("@DonGia", dgr.Cells["GiaNhap"].Value);
                    sqlcmd.Parameters.AddWithValue("@ThanhTien", dgr.Cells["ThanhTien"].Value);
                    if (!DBTools.InsertRecord(sqlcmd)) throw DBTools._LastError;

                    if (dgr.Cells["IdSanPham"].Value != DBNull.Value && dgr.Cells["IdSanPham"].Value != null && dgr.Cells["SoLuong"].Value != DBNull.Value) {                        
                        if (this.arrTemp != null) {
                            foreach (DataTable dt in this.arrTemp) {
                                if (dt.TableName == dgr.Cells["IdSanPham"].Value.ToString()) {
                                    sql = String.Format("select IdDuDauKy from tbl_HangHoa_DuDauKy where IdSanPham={0}", dgr.Cells["IdSanPham"].Value.ToString());
                                    sql += String.Format(" and IdKho={0}", cboKho.SelectedValue);
                                    sql += String.Format(" and ThoiGian='{0}'", dtNgayDuDau.Value.Date.ToString(new CultureInfo("en-US")));
                                    sql += String.Format(" and NguoiTao={0}", Declare.UserId);
                                    result = DBTools.ExecuteScalar(sql);
                                    if (result != null) {
                                        dgr.Cells["IdDuDauKy"].Value = result;
                                        sqlcmd.CommandText = "sp_CapNhatTonDauKy_Update";
                                        sqlcmd.Parameters.Clear();
                                        sqlcmd.Parameters.AddWithValue("@IdDuDauKy", result);
                                        sqlcmd.Parameters.AddWithValue("@ThoiGian", dtNgayDuDau.Value.Date);
                                        sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                                        sqlcmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                                        sqlcmd.Parameters.AddWithValue("@SoLuong", dgr.Cells["SoLuong"].Value);
                                        sqlcmd.Parameters.AddWithValue("@DonGia", dgr.Cells["GiaNhap"].Value);
                                        sqlcmd.Parameters.AddWithValue("@ThanhTien", dgr.Cells["ThanhTien"].Value);
                                        if (!DBTools.UpdateRecord(sqlcmd)) throw DBTools._LastError;
                                    }
                                    else {
                                        sqlcmd.CommandText = "sp_CapNhatTonDauKy_Insert";
                                        sqlcmd.Parameters.Clear();
                                        sqlcmd.Parameters.AddWithValue("@IdDuDauKy", 0).Direction = ParameterDirection.Output;
                                        sqlcmd.Parameters.AddWithValue("@ThoiGian", dtNgayDuDau.Value.Date);
                                        sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                                        sqlcmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                                        sqlcmd.Parameters.AddWithValue("@SoLuong", dgr.Cells["SoLuong"].Value);
                                        sqlcmd.Parameters.AddWithValue("@DonGia", dgr.Cells["GiaNhap"].Value);
                                        sqlcmd.Parameters.AddWithValue("@ThanhTien", dgr.Cells["ThanhTien"].Value);
                                        sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId);
                                        if (!DBTools.InsertRecord(sqlcmd)) throw DBTools._LastError;
                                        dgr.Cells["IdDuDauKy"].Value = sqlcmd.Parameters["@IdDuDauKy"].Value;
                                    }
                                    _IdDuDauKy = int.Parse(dgr.Cells["IdDuDauKy"].Value.ToString()); 
                                    foreach (DataRow dr in dt.Rows) {
                                        sql = "select IdChiTiet from tbl_HangHoa_Chitiet where MaVach=N'" + dr["MaVach"].ToString() + "'";
                                        sql += " and IdDuDauKy=" + _IdDuDauKy;
                                        result = DBTools.ExecuteScalar(sql);
                                        if (result != null) {
                                            dr["IdChiTiethangHoa"] = result;
                                            sqlcmd.CommandText = "sp_CapNhatTonDauKy_CT_Update";
                                            sqlcmd.Parameters.Clear();
                                            sqlcmd.Parameters.AddWithValue("@IdChiTiet", result);
                                            sqlcmd.Parameters.AddWithValue("@IdDuDauKy", _IdDuDauKy);
                                            sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                                            sqlcmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                                            sqlcmd.Parameters.AddWithValue("@MaVach", dr["MaVach"]);
                                            sqlcmd.Parameters.AddWithValue("@SoLuong", dr["SoLuong"]);
                                            if (!DBTools.UpdateRecord(sqlcmd)) throw DBTools._LastError;
                                        }
                                        else {
                                            sqlcmd.CommandText = "sp_CapNhatTonDauKy_CT_Insert";
                                            sqlcmd.Parameters.Clear();
                                            sqlcmd.Parameters.AddWithValue("@IdChiTiet", 0).Direction= ParameterDirection.Output;
                                            sqlcmd.Parameters.AddWithValue("@IdDuDauKy", _IdDuDauKy);
                                            sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                                            sqlcmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                                            sqlcmd.Parameters.AddWithValue("@MaVach", dr["MaVach"]);
                                            sqlcmd.Parameters.AddWithValue("@SoLuong", dr["SoLuong"]);
                                            if (!DBTools.InsertRecord(sqlcmd)) throw DBTools._LastError;
                                            dr["IdChiTiethangHoa"] = sqlcmd.Parameters["@IdChiTiet"].Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }//for


                sql = String.Format("Update tbl_DM_Kho set LanDongBoTruoc=to_date('{0}', 'MM/dd/yyyy HH:MI:SS PM') where IdKho={1}", DateTime.Now.ToString(new CultureInfo("en-US")), cboKho.SelectedValue);
                if(DBTools.ExecuteQuery(sql, CommandType.Text) == null){
                    throw DBTools._LastError;
                }
                ConnectionUtil.Instance.CommitTransaction();
                MessageBox.Show("Cập nhật thành công");
            }
            catch (System.Exception ex) {
                ConnectionUtil.Instance.RollbackTransaction();
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            try {
                if (dgvList.CurrentRow == null) return;
                if (!dgvList.CurrentCell.Selected) return;
                if (dgvList.CurrentRow.Cells["MaSanPham"].Value == null) {
                    MessageBox.Show("Hiện không có sản phẩm cần xóa");
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    if (dgvList.CurrentRow.Cells["IdSanPham"].Value != System.DBNull.Value) {
                        string sql = "select sp.IdSanPham from tbl_SanPham sp";
                        sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh= sp.IdDonViTinh";
                        sql += " where sp.MaSanPham='" + dgvList.CurrentRow.Cells["MaSanPham"].Value.ToString() + "'";
                        object result = DBTools.ExecuteScalar(sql);
                        if (result != null) {
                            if (deletedTemp == null) {
                                deletedTemp = new List<int>();
                            }
                            deletedTemp.Add(int.Parse(dgvList.CurrentRow.Cells["IdSanPham"].Value.ToString()));
                        }
                    }
                    dgvList.Rows.Remove(dgvList.CurrentRow);
                }
                
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try {
                if (MessageBox.Show("Bạn có chắc chắn xóa toàn bộ dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    GtidCommand sqlcmd = new GtidCommand();
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "sp_CapNhatTonDauKy_Delete";
                    ConnectionUtil.Instance.BeginTransaction();
                    foreach (DataGridViewRow dgr in dgvList.Rows) {
                        sqlcmd.Parameters.Clear();
                        sqlcmd.Parameters.AddWithValue("@ThoiGian", dtNgayDuDau.Value.Date);
                        sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                        sqlcmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value == null ? DBNull.Value : dgr.Cells["IdSanPham"].Value);
                        sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId);
                        if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;
                    }
                    dgvList.DataSource = null;
                    dgvList.Rows.Clear();
                    if (deletedTemp != null) {
                        foreach (int i in deletedTemp) {
                            sqlcmd.Parameters.Clear();
                            sqlcmd.Parameters.AddWithValue("@ThoiGian", dtNgayDuDau.Value.Date);
                            sqlcmd.Parameters.AddWithValue("@IdKho", cboKho.SelectedValue);
                            sqlcmd.Parameters.AddWithValue("@IdSanPham", i);
                            sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId);
                            if (!DBTools.DeleteRecord(sqlcmd)) throw DBTools._LastError;
                        }
                        deletedTemp = null;
                    }
                    if(arrTemp != null) arrTemp = null;
                    ConnectionUtil.Instance.CommitTransaction();
                }
            }
            catch (System.Exception ex) {
                ConnectionUtil.Instance.RollbackTransaction();
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif

            }

        }

        private void dgvList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                if (e.Row.Cells["IdSanPham"].Value != System.DBNull.Value) {
                    string sql = "select sp.IdSanPham from tbl_SanPham sp";
                    sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh= sp.IdDonViTinh";
                    sql += " where sp.MaSanPham='" + e.Row.Cells["MaSanPham"].Value.ToString() + "'";
                    object result = DBTools.ExecuteScalar(sql);
                    if (result != null) {
                        if (deletedTemp == null) {
                            deletedTemp = new List<int>();
                        }
                        deletedTemp.Add(int.Parse(e.Row.Cells["IdSanPham"].Value.ToString()));
                    }
                }
                dgvList.Rows.Remove(dgvList.CurrentRow);
                return;
            }
            e.Cancel = true;
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "MaSanPham") {
                if (dgvList.CurrentCell.Value == null) return;
                if (String.IsNullOrEmpty(dgvList.CurrentCell.Value.ToString().Trim())) return;
                string sql = "select sp.IdSanPham from tbl_SanPham sp";
                sql += " where sp.MaSanPham='" + dgvList.CurrentCell.Value.ToString() + "'";
                object result = DBTools.ExecuteScalar(sql);
                if (result == null) {
                    Form frm = new frm_Chon_SanPham(dgvList.CurrentRow.Cells["IdSanPham"], dgvList.CurrentCell, dgvList.CurrentRow.Cells["TenSanPham"], dgvList.CurrentRow.Cells["GiaNhap"], dgvList.CurrentRow.Cells["TenDonViTinh"]);
                    frm.ShowDialog();
                }
            }            
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "SoLuong") {
                if (e.FormattedValue.ToString() != String.Empty) {
                    if (!Common.IsInteger32(e.FormattedValue.ToString())) {
                        e.Cancel = true;
                        MessageBox.Show("Chưa nhập đúng định dạng kiểu số nguyên");
                    }
                }
            }
        }

        private void btnChuaNhapMV_Click(object sender, EventArgs e)
        {
            Form frm = new frmCapNhatTonDauKy_SanPhamChuaMaVach();
            frm.ShowDialog();
        }

        private void GenMaVachTuDong()
        {
            string sql = String.Empty;
            DataSet dsKho = null;
            DataSet dsTonDauKy = null;
            DataSet dsHangHoaChiTiet = null;
            DMKhoInfo dmKho;
            try
            {
                ConnectionUtil.Instance.BeginTransaction();

                sql = "Select distinct MaKho from tbl_tmp_mavach_chuan_t3 order by MaKho";
                dsKho = SqlHelper.ExecuteDataset(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);


                sql = "Select MaKho, MaSanPham, SUM(SoLuong) as SoLuong from tbl_tmp_mavach_chuan_t3 group by MaKho, MaSanPham order by MaKho";
                dsTonDauKy = SqlHelper.ExecuteDataset(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                //frmProgress.Instance.Description = "Đang xóa dữ liệu kho...";
                //frmProgress.Instance.MaxValue = dsKho.Tables[0].Rows.Count;
                //frmProgress.Instance.Value = 0;
                //foreach (DataRow dataRow in dsKho.Tables[0].Rows)
                //{
                //    dmKho = DMKhoDataProvider.Instance.GetKhoInfoByCode(Convert.ToString(dataRow["MaKho"]), 0);
                //    frmProgress.Instance.Description =dmKho.MaKho+ ":Đang xóa dữ liệu kho...";
                //    frmProgress.Instance.Value += 1;
                //    if (dmKho != null)
                //    {
                //        sql = "select * from tbl_hanghoa_dudauky_t2 where idkho=" + dmKho.IdKho;
                //        object dado = SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);
                //        //if(dado != null) throw new Exception("Kho này đã đổ tồn.");
                //        //KhoThongKeHangTonDataProvider.Instance.DeleteData(dmKho.IdKho, 0);
                //    }

                //}

                frmProgress.Instance.MaxValue = dsTonDauKy.Tables[0].Rows.Count;
                frmProgress.Instance.Value = 0;
                foreach (DataRow dataRow in dsTonDauKy.Tables[0].Rows)
                {
                    dmKho = DMKhoDataProvider.Instance.GetKhoInfoByCode(Convert.ToString(dataRow["MaKho"]), 0);
                    if(dmKho == null) continue;
                    frmProgress.Instance.Description = dmKho.MaKho+ ":Đang cập nhật tồn đầu kỳ ...";
                    //int soluong = (Convert.ToInt32(dataRow["SoLuong"]) < 100 ? 100 : Convert.ToInt32(dataRow["SoLuong"]));
                    int soluong = Convert.ToInt32(dataRow["SoLuong"]);
                    int idKho = dmKho.IdKho;
                    int idSanPham =
                        DmSanPhamProvider.GetSanPhamBriefByMa(Convert.ToString(dataRow["MaSanPham"])).IdSanPham;
                    frmProgress.Instance.Value += 1;

                    //sql = "delete tbl_hanghoa_dudauky_t2 where idkho=" +
                    //    idKho + " and idsanpham=" +
                    //    idSanPham;

                    //SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                    //sql = "insert into tbl_hanghoa_dudauky_t2 (idkho, idsanpham, soluong, thoigian) values(" +
                    //    idKho + "," +
                    //    idSanPham + "," +
                    //    soluong + ", "+
                    //    "to_date('28/02/2013','dd/mm/yyyy')"+                   
                    //")";
                    
                    SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                    //sql = "delete tbl_hangtonkho_t2 where idkho=" +
                    //    idKho + " and idsanpham=" +
                    //    idSanPham;

                    //SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                    //sql = "insert into tbl_hangtonkho_t2 (idkho, idsanpham, soluong, tonao) values(" +
                    //      idKho + "," +
                    //      idSanPham + "," +
                    //      soluong + "," +
                    //      soluong +
                    //      ")";

                    SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                    sql = "select iddudauky from tbl_hanghoa_dudauky_t2 where idsanpham= "+idSanPham+"and idkho="+idKho;
                    
                    int idDuDauKy = Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(), CommandType.Text,
                                                            sql));

                    //sql = "delete tbl_hanghoa_chitiet_t2 where idkho=" +
                    //      idKho + " and idsanpham=" +
                    //      idSanPham;

                    //SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                    sql =
                        String.Format(
                            "Select MaKho, MaSanPham, Serial, SoLuong from tbl_tmp_mavach_chuan_t2 where MaKho='{0}' and MaSanPham='{1}'",
                            dataRow["MaKho"], dataRow["MaSanPham"]);

                    dsHangHoaChiTiet = SqlHelper.ExecuteDataset(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);
                    frmProgress.Instance.PushStatus();
                    frmProgress.Instance.MaxValue = dsHangHoaChiTiet.Tables[0].Rows.Count;
                    frmProgress.Instance.Value = 0;

                    foreach (DataRow drHangHoaChiTiet in dsHangHoaChiTiet.Tables[0].Rows)
                    {
                        frmProgress.Instance.Description = dmKho.MaKho + ":Đang cập nhật tồn mã vạch ...";

                        sql = "select sp.trungmavach from tbl_sanpham sp where sp.idsanpham =" + idSanPham;
                        int trungMaVach =
                            Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(),
                                                                    CommandType.Text, sql));
                        if(trungMaVach == 0)
                        {
                            sql = "select 1 from tbl_hanghoa_chitiet_t2 hhct ";
                            sql += "where hhct.mavach='" + drHangHoaChiTiet["Serial"] + "'";
                            object exists = SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                            if (exists != null) 
                                throw new Exception("Trùng mã vạch");                            
                        }

                        sql = "insert into tbl_hanghoa_chitiet_t2 (iddudauky, idkho, idsanpham, mavach, soluong) values(" +
                              idDuDauKy + "," +
                              idKho + "," +
                              idSanPham + ",'" +
                              drHangHoaChiTiet["Serial"] + "'," +
                              //"to_date('" + BaoHanhHangTu.ToString("dd/MM/yyyy") + "','dd/mm/yyyy')," +
                              //"to_date('" + BaoHanhHangTu.AddMonths(ThoiHanBaoHanh).ToString("dd/MM/yyyy") + "','dd/mm/yyyy')," +
                              drHangHoaChiTiet["SoLuong"] +
                              ")";

                        SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);
                        frmProgress.Instance.Value += 1;
                    }
                    frmProgress.Instance.PopStatus();
                }
                ConnectionUtil.Instance.CommitTransaction();
                frmProgress.Instance.Description = "Đã hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
            }
            catch (Exception exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                Debug.Print(exception.ToString());
                Debug.Print(sql);
                frmProgress.Instance.Description = "Không hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
#if DEBUG
                MessageBox.Show(exception.ToString());
#else
                MessageBox.Show(exception.Message);
#endif

                return;
            }

        }

        private void DoVaoBangTam(object sFileName)
        {
            DataSet ds;
            string sql= String.Empty;

            using (OleDbConnection oConn = new OleDbConnection())
            {
                ds = new DataSet();
                oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", sFileName);
                oConn.Open();

                sql = "Select [MA_KHO] as MaKho, [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, [SO_LUONG] as SoLuong from [Items$]";
                using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                {
                    ad.Fill(ds, "HangHoaChiTiet");
                }
            }
            frmProgress.Instance.MaxValue = ds.Tables["HangHoaChiTiet"].Rows.Count;

            try
            {
                ConnectionUtil.Instance.BeginTransaction();
                foreach (DataRow drHangHoaChiTiet in ds.Tables["HangHoaChiTiet"].Rows)
                {
                    sql = "insert into TBL_TMP_MAVACH_T5 values('" + drHangHoaChiTiet["MaSanPham"] + "','" +
                          drHangHoaChiTiet["MaVach"] + "'," + drHangHoaChiTiet["SoLuong"] + ",'" + drHangHoaChiTiet["MaKho"] + "')";

                    SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                    frmProgress.Instance.Value += 1;
                }
                ConnectionUtil.Instance.CommitTransaction();
                frmProgress.Instance.IsCompleted = true;

            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                frmProgress.Instance.IsCompleted = true;
                Debug.Print(ex.ToString());
                Debug.Print(sql);
            }
        }

        private void btnImportNoiDungChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds;
                string sql;
                openFileDialog1.FileName = String.Empty;
                //openFileDialog1.Filter = "*.xls|*.xlsx";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                
                frmProgress.Instance.DoWork(DoVaoBangTam, openFileDialog1.FileName);
                //frmProgress.Instance.DoWork(GenMaVachTuDong);
                
                return;

                int idSanPham, idDuDauKy;
                openFileDialog1.FileName = String.Empty;
                //openFileDialog1.Filter = "*.xls|*.xlsx";
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                try
                {
                    using (OleDbConnection oConn = new OleDbConnection())
                    {
                        oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", openFileDialog1.FileName);
                        oConn.Open();
                        sql = "Select [ma fpt] as MaSanPham, [Ten] as TenSanPham, sum([số lượng]) as SoLuong from [Items$] group by [ma fpt], [Ten]";
                        //sql = "Select [Mã hàng] as MaSanPham, [Tên hàng] as TenSanPham, [Giá nhập] as DonGia, sum([Số lượng]) as SoLuong from [Items$] group by [Mã hàng], [Tên hàng], [Giá nhập]";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ds = new DataSet();
                            ad.Fill(ds, "HangHoaDuDauKy");

                            ad.SelectCommand.CommandText = "Select [ma fpt] as MaSanPham, [Ten] as TenSanPham, [Serial] as Mavach, [số lượng] as SoLuong from [Items$]";
                            ad.Fill(ds, "ImportTable");
                        }
                    }
                }
                catch (Exception exception)
                {
#if DEBUG
                    MessageBox.Show(exception.ToString());
#else
                MessageBox.Show(exception.Message);
#endif
                    
                    return;
                }

                ConnectionUtil.Instance.BeginTransaction();
                
                foreach (DataRow dr in ds.Tables["HangHoaDuDauKy"].Rows)
                {
                    if (dr["MaSanPham"] == DBNull.Value)
                    {
                        continue;
                    }

                    DMSanPhamInfo sanPhamInfo = DmSanPhamProvider.Instance.GetSanPhamByMa(dr["MaSanPham"].ToString());
                    if (sanPhamInfo == null)
                    {
                        continue;
                        //throw new Exception(String.Format("Mã sản phẩm '{0}' này không có trong danh mục", dr["MaSanPham"]));
                    }
                    idSanPham = sanPhamInfo.IdSanPham;

                    DataRow[] foundRows = ds.Tables["ImportTable"].Select(String.Format("MaSanPham='{0}'", dr["MaSanPham"]));
                    if (foundRows.Length > 0)
                    {
                        TonDauKyInfo tonDauKyInfo =
                            TonDauKyDataProvider.Instance.GetTonDauKy(idSanPham, Convert.ToInt32(cboKho.SelectedValue),
                                                                      dtNgayDuDau.Value, Declare.UserId) ??
                            new TonDauKyInfo();

                        tonDauKyInfo.ThoiGian = dtNgayDuDau.Value.Date;
                        tonDauKyInfo.IdKho = Convert.ToInt32(cboKho.SelectedValue);
                        tonDauKyInfo.IdSanPham = idSanPham;
                        tonDauKyInfo.SoLuong = Convert.ToInt32(dr["SoLuong"]);
                        tonDauKyInfo.DonGia = 0;//dr["DonGia"]);
                        tonDauKyInfo.ThanhTien = 0;// Common.IntValue(dr["SoLuong"]) * Common.DoubleValue(dr["DonGia"]));

                        if (tonDauKyInfo.IdDuDauKy != 0)
                        {
                            TonDauKyDataProvider.Instance.Update(tonDauKyInfo);
                        }
                        else
                        {
                            tonDauKyInfo.NguoiTao = Declare.UserId;
                            _IdDuDauKy = TonDauKyDataProvider.Instance.Insert(tonDauKyInfo);
                        }
                        foreach (DataRow dr1 in foundRows)
                        {
                            HangHoaChiTietInfo hangHoaChiTietInfo = TonDauKyDataProvider.Instance.
                                                                        GetIdHangHoaChiTietMaVachTonDauKy(
                                                                            dr1["MaVach"].ToString(),
                                                                            _IdDuDauKy) ??
                                                                    new HangHoaChiTietInfo();

                            hangHoaChiTietInfo.IdDuDauKy = _IdDuDauKy;
                            hangHoaChiTietInfo.IdKho = Convert.ToInt32(cboKho.SelectedValue);
                            hangHoaChiTietInfo.IdSanPham = idSanPham;
                            hangHoaChiTietInfo.MaVach = Convert.ToString(dr1["MaVach"]);
                            hangHoaChiTietInfo.SoLuong = Convert.ToInt32(dr1["SoLuong"]);

                            if (hangHoaChiTietInfo.IdChiTiet != 0)
                            {
                                TonDauKyDataProvider.Instance.Update(hangHoaChiTietInfo);
                            }
                            else
                            {
                                TonDauKyDataProvider.Instance.Insert(hangHoaChiTietInfo);
                            }
                        }
                    }
                }// end for each row in the grid
                TonDauKyDataProvider.Instance.Update(DateTime.Now, Convert.ToInt32(cboKho.SelectedValue));

                ConnectionUtil.Instance.CommitTransaction();

                MessageBox.Show("Cập nhật thành công");

            }
            catch (Exception exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
#if DEBUG
                MessageBox.Show(exception.ToString());
#else
                MessageBox.Show(exception.Message);
#endif
            }
        }
    }
}