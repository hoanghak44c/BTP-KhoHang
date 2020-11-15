using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmXuatGopHoaDon : Form
    {
#region "Khai báo biến"
        DataTable dtPX;
        DataTable dtNhanVien = null;
#endregion

#region "Các phương thức khởi tạo"
        public frmXuatGopHoaDon()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.dgvPhieuXuat.Columns["NgayXuat"].DefaultCellStyle.Format = new System.Globalization.CultureInfo("vi-VN").DateTimeFormat.ShortDatePattern;
        }

#endregion

#region "Các phương thức"
        private void LoadComboBoxData()
        {
            LoadKhoXuat();
            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            try
            {
                string str = "Select DISTINCT nv.IdNhanVien, nv.MaNhanVien, nv.HoTen From tbl_DM_NhanVien nv " +
                      " Inner Join tbl_Kho_NhanVien knv On knv.IdNhanVien = nv.IdNhanVien " +
                      " Where knv.IdKho in ( Select knv1.idKho From tbl_Kho_NhanVien knv1 " +
                      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv1.IdNhanVien " +
                      " Where nd.IdNguoiDung = " + Declare.UserId + ") and (nv.SuDung = 1)  order by nv.HoTen ASC";

                this.dtNhanVien = DBTools.getData("tbl_DM_NhanVien", str).Tables["tbl_DM_NhanVien"];
                if (this.dtNhanVien != null)
                {
                    //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                    this.cboNhanVien.DataSource = this.dtNhanVien;
                    this.cboNhanVien.DisplayMember = "HoTen";
                    this.cboNhanVien.ValueMember = "IdNhanVien";
                    this.cboNhanVien.SelectedIndex = -1;
                    //this.cboNhanVien.SelectedValue = Declare.IdNhanVien;

                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                    {
                        data.Add(dtNhanVien.Rows[i]["HoTen"].ToString());
                        data1.Add(dtNhanVien.Rows[i]["MaNhanVien"].ToString());
                    }

                    cboNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cboNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cboNhanVien.AutoCompleteCustomSource = data;

                    txtMaNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtMaNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtMaNhanVien.AutoCompleteCustomSource = data1;
                }
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void LoadKhoXuat()
        {
            string str = "Select DISTINCT kh.IdKho, kh.MaKho, kh.TenKho From tbl_DM_Kho kh " +
                  " Inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                  " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv.IdNhanVien " +
                  " Where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + " order by kh.TenKho ASC";

            DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
            if (dtKho != null)
            {
                //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                this.cboKhoXuat.DataSource = dtKho;
                this.cboKhoXuat.DisplayMember = "TenKho";
                this.cboKhoXuat.ValueMember = "IdKho";
                if (Declare.IdKho != 0)
                    this.cboKhoXuat.SelectedValue = Declare.IdKho;
            }
        }

        private string TimPhieuXuat_ChuoiLoc()
        {
            string str = "select px.IdPhieuXuat,px.IdNhanVien,px.SoOrderKH,px.SoPhieuXuat,px.NgayXuat,nv.HoTen TenNhanVien,px.GhiChu ";
            str += " from tbl_PhieuXuat px";
            str += " left join tbl_DM_NhanVien nv on nv.IdNhanVien = px.IdNhanVien ";

            if (this.txtMaSanPham.Text.Trim().Length > 0 || this.txtTenSanPham.Text.Trim().Length > 0)
            {
                str += " inner join tbl_PhieuXuat_ChiTiet pxct on px.IdPhieuXuat = pxct.IdPhieuXuat ";
                str += " inner join tbl_SanPham sp on pxct.IdSanPham = sp.IdSanPham ";
            }

            if (this.txtMaVach.Text.Trim().Length > 0)
            {
                if (this.txtMaSanPham.Text.Trim().Length > 0 || this.txtTenSanPham.Text.Trim().Length > 0)
                {
                    str += " inner join tbl_PhieuXuat_ChiTiet_hanghoa pxcthh on pxct.IdChiTiet = pxcthh.IdChiTietPhieuXuat ";
                    str += " inner join tbl_hanghoa_chitiet hhct on pxcthh.IdChiTietHangHoa = hhct.IdChiTiet ";

                }
                else
                {
                    str += " inner join tbl_PhieuXuat_ChiTiet pxct on px.IdPhieuXuat = pxct.IdPhieuXuat ";
                    str += " inner join tbl_PhieuXuat_ChiTiet_hanghoa pxcthh on pxct.IdChiTiet = pxcthh.IdChiTietPhieuXuat ";
                    str += " inner join tbl_hanghoa_chitiet hhct on pxcthh.IdChiTietHangHoa = hhct.IdChiTiet ";
                }
            }

            str += " Where (px.NhapHoaDon IS NULL or px.NhapHoaDon=0) ";
            str += " and LoaiXuatNhap = " + (int)TransactionType.XUAT_BAN;
            //str += //" and px.ThoigianSua > convert(datetime,'" + Common.Date2LongString(Declare.NgayKhoaSo) + "',121) " +
            //       " and px.ThoigianSua >=  convert(datetime,'" + Common.Date2String(Declare.NgayLamViec) + "',103)";

            if (txtSoOrderKH.Text.Trim().Length > 0)
                str += " and px.SoOrderKH = N'" + this.txtSoOrderKH.Text.Trim() + "'";

            if (txtSoPhieu.Text.Trim().Length > 0)
                str += " and px.SoPhieuXuat like N'%" + this.txtSoPhieu.Text.Trim() + "%'";

            if (mstTuNgay.Text.Trim().Length > 0)
                str += string.Format(" and px.NgayXuat >= convert(datetime,'{0}',103) ", Common.Date2String(mstTuNgay.Value));

            if (mstDenNgay.Text.Trim().Length > 0)
                str += string.Format(" and convert(varchar,px.NgayXuat,101) <= convert(datetime,'{0}',103) ", Common.Date2String(mstDenNgay.Value));

            if (Common.IntValue(this.cboKhoXuat.SelectedValue) > 0)
                str += " and px.IdKho=" + this.cboKhoXuat.SelectedValue.ToString();

            if (Common.IntValue(this.cboNhanVien.SelectedValue) > 0)
                str += " and px.IdNhanVien=" + this.cboNhanVien.SelectedValue.ToString();

            if (this.txtMaSanPham.Text.Trim().Length > 0)
                str += " and sp.MaSanPham = N'" + this.txtMaSanPham.Text.Trim() + "'";

            if (this.txtTenSanPham.Text.Trim().Length > 0)
                str += " and sp.TenSanPham like N'%" + this.txtTenSanPham.Text.Trim() + "%'";

            if (this.txtMaVach.Text.Trim().Length > 0)
                str += " and hhct.MaVach like N'%" + this.txtMaVach.Text.Trim() + "%'";

            return str;
        }

        private bool TimPhieuXuat_NgayXuatHopLe()
        {
            if (this.mstTuNgay.Text.Trim().Length >4 && this.mstTuNgay.Text.Trim().Length < 10)
            {
                MessageBox.Show("Mục 'Từ ngày' nhập chưa đúng!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mstTuNgay.Focus();
                return false;
            }
            if (this.mstTuNgay.Text.Trim().Length ==10)
            {
                if (!Common.IsValidDate(this.mstTuNgay.Text.Trim()))
                {
                    MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.mstTuNgay.Focus();
                    return false;
                }
            }

            if (  this.mstDenNgay.Text.Trim().Length >4 && this.mstDenNgay.Text.Trim().Length < 10)
            {
                MessageBox.Show("Mục 'Đến ngày' nhập chưa đúng!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.mstDenNgay.Focus();
                return false;
            }
            if (this.mstDenNgay.Text.Trim().Length ==10)
            {
                if (!Common.IsValidDate(this.mstDenNgay.Text.Trim()))
                {
                    MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.mstDenNgay.Focus();
                    return false;
                }
            }

            if (mstTuNgay.Text.Trim().Length == 10 && mstDenNgay.Text.Trim().Length == 10)
            {
                if (DateTime.Compare(Common.ParseDate(this.mstDenNgay.Text.Trim()), Common.ParseDate(this.mstTuNgay.Text.Trim())) < 0)
                {
                    MessageBox.Show("Mục 'Từ ngày' phải nhỏ hơn Mục 'Đến ngày'.", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    mstTuNgay.Focus();
                    return false;
                }
            }
           return true;
        }

        private void TimPhieuXuat_CapNhatSoTT(DataTable dt, int VitriRong)
        {
            for (int i = VitriRong; i <= dt.Rows.Count - 1; i++)
            {
                dt.Rows[i]["SoTT"] = i + 1;
            }
        }

        private void LuoiHienThi_AnCot()
        {
            for (int i = 0; i <= this.dtPX.Columns.Count - 1; i++)
            {
                if (this.dtPX.Columns[i].ColumnName != "IdPhieuXuat" && this.dtPX.Columns[i].ColumnName != "IdNhanVien")
                    this.dgvPhieuXuat.Columns[i].Visible=true;
                else
                    this.dgvPhieuXuat.Columns[i].Visible = false;
            }
        }

        //private void PhieuXuat_Sua()
        //{
        //    if (this.dgvPhieuXuat.RowCount == 0) {
        //        MessageBox.Show("Không có phiếu xuất nào để sửa.", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (this.dgvPhieuXuat.CurrentRow == null) {
        //        MessageBox.Show("Bạn chưa chọn phiếu để sửa.", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    _IdPhieu[0] = Convert.ToInt32(this.dgvPhieuXuat.CurrentRow.Cells["IdPhieuXuat"].Value);
        //    this.DialogResult = DialogResult.OK;

        //    //int IndexPX=-1;
        //    //for (int i = 0; i <= this.dtPX.Rows.Count - 1; i++)
        //    //{
        //    //    if ((int)this.dgvPhieuXuat.CurrentRow.Cells["IdPhieuXuat"].Value == (int)this.dtPX.Rows[i]["IdPhieuXuat"])
        //    //    {
        //    //        IndexPX = i;
        //    //        break;
        //    //    }
        //    //}
        //    //frmPhieuXuat frm = new frmPhieuXuat(this.dtPX, IndexPX);
        //    //frm.MdiParent = this.ParentForm;
        //    //frm.Show();
        //    //if (this.dtPX.Rows.Count > 0)
        //    //    this.dgvPhieuXuat.CurrentRow.Selected = true;
        //}

#endregion 

#region "Các sự kiên"
        private void frmTimPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                btnTim_Click(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (!this.TimPhieuXuat_NgayXuatHopLe()) return;

            string sqlSearch = this.TimPhieuXuat_ChuoiLoc();

            SearchPhieuXuat(sqlSearch);
        }

        private void SearchPhieuXuat(string sqlSearch)
        {
            try
            {
                if (sqlSearch.Trim().Length == 0) return;

                if (this.dtPX != null)
                    this.dtPX = null;
                this.dtPX = DBTools.getData("tbl_PhieuXuat", sqlSearch).Tables["tbl_PhieuXuat"];
                if (this.dtPX == null)
                {
                    MessageBox.Show("Lỗi tìm phiếu xuất: " + DBTools._LastError.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.dtPX.Columns.Add("SoTT", typeof(int));
                this.dgvPhieuXuat.DataSource = dtPX;
                this.TimPhieuXuat_CapNhatSoTT(this.dtPX, 0);
                this.LuoiHienThi_AnCot();
                this.grpKetQuaTimKiem.Text = "Kết quả tìm kiếm (" + dgvPhieuXuat.RowCount + " phiếu)";
                if (this.dtPX.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu xuất nào thỏa mãn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.dtPX != null)
                    this.dtPX.Dispose();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lstIdPX = new List<int>();
                int idNhanVien = -1;
                bool sameNV = true;
                foreach (DataGridViewRow row in dgvPhieuXuat.SelectedRows)
                {
                    int idPX = (int)row.Cells["IdPhieuXuat"].Value;
                    lstIdPX.Add(idPX);

                    try
                    {
                        int idnv = (int)row.Cells["IdNhanVien"].Value;
                        if (idNhanVien == -1)
                            idNhanVien = idnv;

                        if (idNhanVien != -1 && idNhanVien != idnv)
                            sameNV = false;
                    }
                    catch { sameNV = false; }
                }

                if (lstIdPX.Count > 0)
                {
                    frmXuatGopHoaDon_ChiTiet frm;
                    if (sameNV)
                        frm = new frmXuatGopHoaDon_ChiTiet(lstIdPX, idNhanVien);                    
                    else
                        frm = new frmXuatGopHoaDon_ChiTiet(lstIdPX);

                    frm.MdiParent = this.ParentForm;
                    frm.Show();
                    frm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    MessageBox.Show("Không chọn phiếu xuất!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }


        //private void dgvPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyData == Keys.Enter)
        //        {
        //            if (this.dgvPhieuXuat.RowCount > 0)
        //            {
        //                this.PhieuXuat_Sua();
        //                e.Handled = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    } 
        //}

        //private void dgvPhieuXuat_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this.dgvPhieuXuat.RowCount > 0)
        //        {
        //            this.PhieuXuat_Sua();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //   } 
        //}
#endregion


        private void frmTimPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)   
                {
                    if (!this.dgvPhieuXuat.Focused)
                    {
                        SendKeys.Send("{TAB}");
                        e.Handled = true;
                        return;
                    }
                }
                if (e.KeyCode == Keys.F3)
                    this.btnTim_Click(sender, e);
                else if (e.KeyCode == Keys.F6)
                    this.btnCapNhat_Click(sender, e);
                else if (e.KeyCode == Keys.F12)
                    this.btnDong_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void dgvPhieuXuat_Sorted(object sender, EventArgs e)
        {
            this.dtPX.DefaultView.AllowEdit = true;
            for (int i = 0; i <= this.dtPX.DefaultView.Count - 1; i++)
            {
                this.dtPX.DefaultView[i]["SoTT"] = i + 1;
            }
            this.dtPX.DefaultView.AllowEdit = false;
        }

        private void dgvPhieuXuat_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int idPX = 0;
                foreach (DataGridViewRow row in dgvPhieuXuat.SelectedRows)
                {
                    idPX = int.Parse(row.Cells["IdPhieuXuat"].Value.ToString());
                }

                if (idPX > 0)
                {
                    frmXuatGopHoaDon_XemChiTiet frm = new frmXuatGopHoaDon_XemChiTiet(idPX);
                    frm.ShowDialog();
                    //frm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    MessageBox.Show("Không chọn phiếu xuất!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  

        }

        private void frmXuatGopHoaDon_Activated(object sender, EventArgs e)
        {
            btnTim_Click(sender, e);
        }

        private void txtMaNhanVien_Leave(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < dtNhanVien.Rows.Count; i++)
            {
                if (txtMaNhanVien.Text.Equals(dtNhanVien.Rows[i]["MaNhanVien"].ToString()))
                {
                    //cboNhanVien.SelectedIndex = i;
                    cboNhanVien.SelectedValue = dtNhanVien.Rows[i]["IdNhanVien"];
                    found = true;
                    break;
                }
            }
            if (!found)
                cboNhanVien.Text = "";
        }

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtMaNhanVien_Leave(sender, e);
            }
        }

        private void cboNhanVien_Leave(object sender, EventArgs e)
        {
            bool found = false;
            if (cboNhanVien.Text.Trim().Length > 0)
            {
                for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                {
                    if (dtNhanVien.Rows[i]["HoTen"].ToString().ToLower().Equals(cboNhanVien.Text.Trim().ToLower()))
                    {
                        //cboNhanVien.SelectedIndex = i;
                        cboNhanVien.SelectedValue = dtNhanVien.Rows[i]["IdNhanVien"];
                        found = true;
                        break;
                    }
                }
            }
            if (!found || cboNhanVien.Text.Length == 0)
            {
                // MessageBox.Show("Nhân viên này không có trong danh sách, chọn nhân viên khác");
                cboNhanVien.Text = "";
            }
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaNhanVien.Text = dtNhanVien.Rows[cboNhanVien.SelectedIndex]["MaNhanVien"].ToString();
            }
            catch { txtMaNhanVien.Text = ""; }
        }


    }
}