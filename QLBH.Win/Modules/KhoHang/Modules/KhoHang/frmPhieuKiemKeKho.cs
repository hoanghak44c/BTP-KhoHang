using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
//using QLBanHang.Class.Objects;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Common.Objects;

namespace QLBanHang.Forms
{
    public partial class frmPhieuKiemKeKho : Form
    {
        #region "Khai báo biến"
        DataTable dtPhieuXuat = null;
        DataTable dtPXSearch = null;
        DataTable dtSanPham = null;
        public int IdPhieuXuat = 0;
        public int IndexPX = 0;
        public int IndexPXSearch = -1;
        private bool Updating = false;
        public bool DaLapHoaDon = false;
        #endregion

        #region "Các phương thức khởi tạo"
        public frmPhieuKiemKeKho()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmPhieuKiemKeKho(DataTable dtPX, int IndexPXSearch)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.IndexPXSearch = IndexPXSearch;
            this.dtPXSearch = dtPX;
            this.IdPhieuXuat = int.Parse(this.dtPXSearch.Rows[IndexPXSearch]["IdKiemKe"].ToString());
            this.tsbPrev.Enabled = false;
            this.tsbNext.Enabled = false;
            this.tsbAdd.Enabled = false;
            this.tsbEdit.Enabled = false;
            this.tsbUpdate.Enabled = true;
            this.tsbDelete.Enabled = true;
            this.Text = "Cập nhật phiếu kiểm kê.";
        }

        #endregion

        #region "Các phương thức"

        private void PhieuXuat_KhoiTaoSoPhieu()
        {
            this.txtSoPhieu.Text = Common.TaoSoPhieuTuDong("KK", "tbl_KiemKe", "SoPhieu");
        }
        //private string PhieuXuat_LaySoPhieuThu()
        //{
        //    string rs = txtSoPhieu.Text;
        //    try
        //    {
        //        SqlCommand sqlcmd = new SqlCommand("sp_PhieuXuat_Thu_SoPhieuTuDong");
        //        sqlcmd.Parameters.AddWithValue("@Code", "PXT").Direction = ParameterDirection.Input;
        //        sqlcmd.CommandType = CommandType.StoredProcedure;

        //        string str = DBTools.ExecuteScalar(sqlcmd).ToString();

        //        if (str.Trim().Length != 0 && str != "0")
        //            rs = str;
        //    }
        //    catch (Exception ex) { }
        //    return rs;
        //}
        private bool PhieuXuat_ThemMoi()
        {
            this.IdPhieuXuat = 0;
            this.PhieuXuat_KhoiTaoSoPhieu();
            this.mstNgayXuat.Value = DateTime.Now;//.ResetText();//.Text = DateTime.Today.ToString("dd/MM/yyyy");
            this.txtGhiChu.Text = "";
            this.dgvSanPhamBan.Rows.Clear();
            this.dgvSanPhamKhongCo.Rows.Clear();
            return true;
        }

        private bool PhieuXuat_SuHopLeCuaThongTin()
        {
            //
            //Sự hợp lệ của thông tin số phiếu kiểm kê
            //
            if (this.txtSoPhieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Số phiếu chưa nhập." + "\n" + "-Hãy nhập số phiếu", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.txtSoPhieu.Focus();
                return false;
            }
            //Kiem tra trung so phieu
            string sqlstr = "select * from tbl_KiemKe where SoPhieu=N'" + this.txtSoPhieu.Text.Trim() + "' and IdKiemKe!=" + this.IdPhieuXuat;
            if (DBTools.ExistData(sqlstr))
            {
                MessageBox.Show("Số phiếu này đã có." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSoPhieu.Focus();
                return false;
            }

            //Sự hợp lệ của thông tin ngày xuất
            //
            if (this.mstNgayXuat.Text.Trim().Length == 4)
            {
                MessageBox.Show("Ngày xuất chưa nhập." + "\n" + "-Hãy nhập ngày xuất", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.mstNgayXuat.Focus();
                return false;
            }
            if (this.mstNgayXuat.Text.Trim().Length > 4 && this.mstNgayXuat.Text.Trim().Length < 10)
            {
                MessageBox.Show("Ngày xuất nhập chưa đúng." + "\n" + "-Hãy nhập lại", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }
            if (!Common.IsValidDate(mstNgayXuat.Text.Trim()))
            {
                MessageBox.Show(Declare.msgDateTimeValid, Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //tabInfors.SelectedTab = tabInfors.TabPages[0];
                this.mstNgayXuat.Focus();
                return false;
            }

            //
            //Sự hợp lệ của thông tin chi tiết phiếu kiểm kê
            //
            if (this.dgvSanPhamBan.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết phiếu kiểm kê.", Declare.titleNotice, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgvSanPhamBan.Focus();
                return false;
            }

            return true;
        }


        private void PhieuXuat_InsertCommand(GtidCommand sqlcmd)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_Insert";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdKiemKe", 0).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.AddWithValue("@SoPhieu", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@NgayKiemKe", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@IdNhanVien", Declare.UserId).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());

                DBTools.InsertRecord(sqlcmd);

                this.IdPhieuXuat = int.Parse(sqlcmd.Parameters["@IdKiemKe"].Value.ToString());
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


        private void PhieuXuat_UpdateCommand(GtidCommand sqlcmd)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_Update";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdKiemKe", this.IdPhieuXuat).Direction = ParameterDirection.Input;

                sqlcmd.Parameters.AddWithValue("@IdKiemKe", 0).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@SoPhieu", this.txtSoPhieu.Text.Trim()).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@NgayKiemKe", this.mstNgayXuat.Value).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@IdKho", this.cboKhoXuat.SelectedValue).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@IdNhanVien", Declare.UserId).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@GhiChu", this.txtGhiChu.Text.Trim());

                DBTools.UpdateRecord(sqlcmd);
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

        private void PhieuXuat_DeleteCommand(GtidCommand sqlcmd)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_Delete";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdKiemKe", IdPhieuXuat).Direction = ParameterDirection.Input;
                DBTools.DeleteRecord(sqlcmd);
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


        private void PhieuXuat_AllDetails_DeleteCommand(GtidCommand sqlcmd)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_ChiTiet_Delete";
                sqlcmd.Parameters.Clear();
                sqlcmd.Parameters.AddWithValue("@IdKiemKe", IdPhieuXuat).Direction = ParameterDirection.Input;
                DBTools.DeleteRecord(sqlcmd);
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



        private int ChiTietPX_InsertCommand(GtidCommand sqlcmd, int IdSP, int sLuong)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_ChiTiet_Insert";
                sqlcmd.Parameters.Clear();

                sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
                sqlcmd.Parameters.AddWithValue("@IdKiemKe", this.IdPhieuXuat).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@IdSanPham", IdSP).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@SoLuong", sLuong).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId).Direction = ParameterDirection.Input;

                DBTools.InsertRecord(sqlcmd);

                int idChitiet = Common.IntValue(sqlcmd.Parameters["@IdChitiet"].Value.ToString());

                return idChitiet;
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            return -1;
        }


        private int ChiTietPX_KhongMaVach_InsertCommand(GtidCommand sqlcmd)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_ChiTiet_KhongMaVach_Insert";

                foreach (DataGridViewRow dgr in dgvSanPhamKhongCo.Rows)
                {
                    if (dgr.Cells["MaVachKC"].Value != null && dgr.Cells["MaVachKC"].Value.ToString() != "" && Common.IntValue(dgr.Cells["IdSanPhamKC"].Value) != 0)
                    {
                        int idSanPham = Common.IntValue(dgr.Cells["IdSanPhamKC"].Value);
                        int soluong = Common.IntValue(dgr.Cells["SoLuongKC"].Value.ToString());
                        string mavach = dgr.Cells["MaVachKC"].Value.ToString();
                        string ghichu = dgr.Cells["GhiChuKC"].Value != null ? dgr.Cells["GhiChuKC"].Value.ToString() : "";

                        sqlcmd.Parameters.Clear();
                        sqlcmd.Parameters.AddWithValue("@IdChitiet", 0).Direction = ParameterDirection.Output;
                        sqlcmd.Parameters.AddWithValue("@IdKiemKe", this.IdPhieuXuat).Direction = ParameterDirection.Input;
                        sqlcmd.Parameters.AddWithValue("@IdSanPham", idSanPham).Direction = ParameterDirection.Input;
                        sqlcmd.Parameters.AddWithValue("@MaVach", mavach).Direction = ParameterDirection.Input;
                        sqlcmd.Parameters.AddWithValue("@SoLuong", soluong).Direction = ParameterDirection.Input;
                        sqlcmd.Parameters.AddWithValue("@NguoiTao", Declare.UserId).Direction = ParameterDirection.Input;
                        sqlcmd.Parameters.AddWithValue("@GhiChu", ghichu).Direction = ParameterDirection.Input;

                        DBTools.InsertRecord(sqlcmd);
                    }
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
            return -1;
        }


        private void ChiTietPX_HangHoa_InsertCommand(GtidCommand sqlcmd, int IdChitiet, int IdHanghoa, int Soluong, int SoluongSS, string ghichu)
        {
            try
            {
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_PhieuKiemKe_ChiTiet_HangHoa_Insert";
                sqlcmd.Parameters.Clear();

                sqlcmd.Parameters.AddWithValue("@IdChiTietKiemKe", IdChitiet).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@IdChitietHangHoa", IdHanghoa).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@SoLuong", Soluong).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@SoLuongSoSach", SoluongSS).Direction = ParameterDirection.Input;
                sqlcmd.Parameters.AddWithValue("@GhiChu", ghichu).Direction = ParameterDirection.Input;

                DBTools.InsertRecord(sqlcmd);
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
 
        private void LoadMaVach()
        {
            try
            {
                if (dtSanPham != null)
                {
                    // AutoCompleteStringCollection 
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtSanPham.Rows.Count; i++)
                        data.Add(dtSanPham.Rows[i]["MaVach"].ToString());

                    txtMaVach.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtMaVach.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtMaVach.AutoCompleteCustomSource = data;
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
            try
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
                    this.cboKhoXuat.SelectedValue = Declare.IdKho;
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


        private void LoadComboBoxData()
        {
            LoadKhoXuat();
            LoadOfflineData();
        }

        private void PhieuXuat_HienThi(DataRow row)
        {
            this.txtSoPhieu.Text = row["SoPhieu"].ToString();
            this.mstNgayXuat.Value = (DateTime)row["NgayKiemKe"];
            this.cboKhoXuat.SelectedValue = Common.IntValue(row["IdKho"].ToString());
            this.txtGhiChu.Text = row["GhiChu"].ToString();
        }

        private void LoadAllPhieuXuat()
        {
            string str = "select * from tbl_KiemKe  ";
            str += string.Format(" where NgayKiemKe >=  convert(datetime,'{0}',103)", Common.Date2String(Declare.NgayLamViec));
            str += " order by NgayKiemKe desc ";
            dtPhieuXuat = DBTools.getData("Tmp", str).Tables["Tmp"];
            showInfors();
        }
        private void LoadPhieuXuat(int IdPX)
        {
            string str;
            DataTable dt;

            str = "select * from tbl_KiemKe where IdKiemKe=" + IdPX + "";
            dt = DBTools.getData("Tmp", str).Tables["Tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                this.PhieuXuat_HienThi(dt.Rows[0]);

                str = "SELECT * FROM vChiTietKiemKe " +
                      "WHERE IdKiemKe=" + IdPX;
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                this.dgvSanPhamBan.Rows.Clear();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            dt.Rows[i]["SoLuongSS"],
                            dt.Rows[i]["GhiChu"]
                        };
                        this.dgvSanPhamBan.Rows.Add(arr);
                        DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                        newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(DBTools.getValue("Select TrungMaVach From tbl_SanPham Where IdSanPham = " + Common.IntValue(dt.Rows[i]["IdSanPham"])));
                    }
                }

                //hien thi danh sach ma vach khong co trong kho
                str = "SELECT * FROM vChiTietKiemKeKhongMaVach " +
                      "WHERE IdKiemKe=" + IdPX;
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dgvSanPhamKhongCo.Rows.Clear();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            dt.Rows[i]["GhiChu"]
                        };
                        this.dgvSanPhamKhongCo.Rows.Add(arr);
                    }
                }
            }
        }

        #endregion

        #region "Các sự kiên"
        private void dgvChiTietPhieuXuat_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                    e.Handled = true;

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

        private void dgvChiTietPhieuXuat_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {

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

        private void dgvChiTietPhieuXuat_Resize_1(object sender, EventArgs e)
        {
            try
            {
                //this.ResizeLuoiHienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showInfors()
        {
            this.Text = "Cập nhật phiếu kiểm kê.";
            if (dtPhieuXuat != null)
            {
                this.Text += " - Tổng số phiếu [" + dtPhieuXuat.Rows.Count + "]";
                if (dtPhieuXuat.Rows.Count > 0)
                {
                    this.Text += " - Phiếu số [" + (this.IndexPX + 1) + "]";
                }

            }
        }
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                txtSoPhieu.ReadOnly=!Common.IsEnableCommand("12");//sửa giá bán
                //Neu la sua tu danh sach tim kiem
                if (this.IndexPXSearch >= 0)
                {
                    this.LoadPhieuXuat(this.IdPhieuXuat);
                    return;
                }
                LoadAllPhieuXuat();
               
                if (this.IdPhieuXuat == 0)
                {
                    if (dtPhieuXuat != null && dtPhieuXuat.Rows.Count > 0)
                    {
                        this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdKiemKe"].ToString());
                    }
                }
                if (this.IdPhieuXuat > 0)
                {
                    this.LoadPhieuXuat(this.IdPhieuXuat);
                    showInfors();
                }
                else
                {
                    this.PhieuXuat_ThemMoi();
                }
                //Thiet lap trang thai item
                setEDItems(false);
                setEDUpdate();
                setEDFunctions();
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            } 
            txtMaVach.Focus();
            
        }

        private void frmPhieuXuat_Dispose(object sender, EventArgs e)
        {
            //try
            //{
            //    Declare.HienThiPhieuXuat = chkDefault.Checked;
            //    Common.SetValue("HIENTHI_PHIEUXUAT", (chkDefault.Checked ? "1" : "0"));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            
        }

        private List<ChiTietKiemKe> GetChiTietPhieuXuat(GtidCommand sqlcmd)
        {
            DataGridView data = dgvSanPhamBan;
            data.Sort(data.Columns["IdSanPham"], ListSortDirection.Ascending);
            int IdSanPham = 0;
            List<ChiTietKiemKe> listPX = new List<ChiTietKiemKe>();
            ChiTietKiemKe detailPX = null;

            foreach (DataGridViewRow dgr in data.Rows)
            {

                int idSP = Common.IntValue(dgr.Cells["IdSanPham"].Value.ToString());
                if (idSP == IdSanPham)
                {
                    int sl = Common.IntValue(dgr.Cells["SoLuong"].Value.ToString());
                    int sltt = Common.IntValue(dgr.Cells["SoLuongThucTe"].Value);
                    string ghichu = dgr.Cells["GhiChu"].Value == null ? "" : dgr.Cells["GhiChu"].Value.ToString();
                    detailPX.SoLuong += sl;
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVach"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlcmd.Connection));
                    ChiTietKKHangHoa hanghoa = new ChiTietKKHangHoa(IdHangHoa, sl, sltt, ghichu);
                    detailPX.DsHangHoa.Add(hanghoa);
                }
                else
                {
                    if (detailPX != null)
                        listPX.Add(detailPX);
                    IdSanPham = idSP;
                    detailPX = new ChiTietKiemKe();
                    detailPX.IdSanPham = idSP;
                    detailPX.SoLuong = Common.IntValue(dgr.Cells["SoLuong"].Value.ToString());
                    detailPX.NguoiTao = Declare.UserId;
                    //Luu lai Id Hang hoa
                    string str = "Select IdChiTiet From tbl_HangHoa_Chitiet Where MaVach=N'" + dgr.Cells["MaVach"].Value.ToString() + "' and IdKho = " + Declare.IdKho + " and IdSanPham = " + idSP;
                    int IdHangHoa = Common.IntValue(DBTools.getValue(str, sqlcmd, sqlcmd.Connection));
                    int sltt = Common.IntValue(dgr.Cells["SoLuongThucTe"].Value);
                    string ghichu = dgr.Cells["GhiChu"].Value == null ? "" : dgr.Cells["GhiChu"].Value.ToString();
                    ChiTietKKHangHoa hanghoa = new ChiTietKKHangHoa(IdHangHoa, detailPX.SoLuong, sltt, ghichu);
                    detailPX.DsHangHoa.Add(hanghoa);
                }

            }
            if (detailPX != null)
                listPX.Add(detailPX);

            return listPX;

        }

 

        private void dtChiTietPhieuXuat_Rowchanged(object sender, DataRowChangeEventArgs e)
        {
            //Double TongTien = 0;
            //if (this.dtChiTietPX.Rows.Count > 0)
            //{

            //    for (int i = 0; i <= this.dtChiTietPX.Rows.Count - 2; i++)
            //    {
            //        TongTien += (Double)this.dtChiTietPX.Rows[i]["ThanhTien"];
            //    }
            //}

            //this.txtTongTienSauCK.Text = Common.Double2Str(TongTien);
        }

        private void frmPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!this.txtGhiChu.Focused && !this.dgvSanPhamBan.Focused && !this.txtMaVach.Focused)
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
                //else if (e.KeyCode == Keys.F9 && tsbPrint.Enabled)
                //    this.tsbPrint_Click(sender, e);
                else if (e.KeyCode == Keys.F10 && tsbSearch.Enabled)
                    this.tsbSearch_Click(sender, e);
                //else if (e.KeyCode == Keys.F11 && tsbPayment.Enabled)
                //    this.tsbPayment_Click(sender, e);
                else if (e.KeyCode == Keys.F12 && tsbClose.Enabled)
                    this.tsbClose_Click(sender, e);
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


 
        private void frmPhieuXuat_Resize(object sender, EventArgs e)
        {

        }

        private void txtSoPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (this.IdPhieuXuat == 0)
                {
                    PhieuXuat_KhoiTaoSoPhieu();
                    this.txtSoPhieu.SelectionStart = this.txtSoPhieu.Text.Trim().Length;
                }
            }
        }

        #endregion

        private void txtMaVach_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] row = dtSanPham.Select("MaVach='" + txtMaVach.Text.Trim() + "'");
                if (row.Length > 0)
                {
                    txtTenSanPham.Text = row[0]["TenSanPham"].ToString();
                }
            }
            catch { }
        }
        private void txtMaVach_TextEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txtMaVach.Text.Trim() != "")
                    InputDataFromCode(txtMaVach.Text.Trim(), true);
            }
        }

        private void InputDataFromCode(string code, bool isEnter)
        {
            try
            {
                Utils ut = new Utils();
                int idSPBan = -1;
                DataTable dt;
                string sTrungMV = "";
                if (!ut.isStringNotEmpty(code)) return;
                //            string sql = string.Format(@"SELECT IdChiTiet FROM tbl_HangHoa_Chitiet   
                //                            WHERE tbl_HangHoa_Chitiet.MaVach=N'{0}'", code);
                DataRow[] rowSP = dtSanPham.Select("MaVach='" + code + "'");
                if (rowSP.Length == 0)
                {
                    if (MessageBox.Show("Mã vạch này không tồn tại trong kho.\nBạn có muốn thêm mã vạch này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //lay thong tin san pham
                        object[] arr ={ code, 0, "", "", "", 1 };
                        this.dgvSanPhamKhongCo.Rows.Add(arr);
                        return;
                    }
                    else
                        return;

                }
                else
                {
                    sTrungMV = rowSP[0]["TrungMaVach"].ToString();
                }

                //Kiem tra san pham da nhap chua, neu nhap roi thi tang so luong
                bool foundSP = false;
                foreach (DataGridViewRow row in dgvSanPhamBan.Rows)
                {
                    if (row.Cells["MaVach"].Value.ToString().ToLower().Equals(code.ToLower()))
                    {
                        //trung voi san pham ban roi va cung co gia roi
                        //idSPBan = Common.IntValue(row.Cells["IdSanPham"].Value.ToString());
                        //str = String.Format("Select case when TrungMaVach is null then 0 else TrungMaVach end TrungMaVach From tbl_SanPham Where IdSanPham = {0}", idSPBan);
                        //if (DBTools.getValue(str).Equals("1"))
                        if (sTrungMV.Equals("1"))
                        {
                            row.Cells["SoLuong"].Value = Common.IntValue(row.Cells["SoLuong"].Value.ToString()) + 1;
                            foundSP = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm có mã vạch này đã nhập rồi, bạn không thể nhập lại nữa!");
                            return;
                        }
                    }
                }
                if (!foundSP)//khong thi them moi
                {
                    //lay thong tin san pham
                    idSPBan = Common.IntValue(rowSP[0]["IdSanPham"].ToString());
                    int soLuong = 1;
                    object[] arr ={rowSP[0]["MaVach"], rowSP[0]["IdSanPham"], rowSP[0]["MaSanPham"],
                            rowSP[0]["TenSanPham"], rowSP[0]["TenDonViTinh"], 
                            soLuong,Common.IntValue(rowSP[0]["SoLuong"]),""};
                    this.dgvSanPhamBan.Rows.Add(arr);

                    DataGridViewRow newRow = this.dgvSanPhamBan.Rows[this.dgvSanPhamBan.RowCount - 1];
                    newRow.Cells["SoLuong"].ReadOnly = !Common.BoolValue(sTrungMV);
                }
            }
            catch { }

        }


        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (txtMaVach.Text.Trim() != "")
                InputDataFromCode(txtMaVach.Text.Trim(), true);
        }

        private void tsbPrev_Click(object sender, EventArgs e)
        {
            prev();
            showInfors();
        }
        private void prev()
        {
            if (IndexPX > 0)
            {
                if (Updating)
                {
                    if (MessageBox.Show("Dữ liệu đang cập nhật, bạn có muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                IndexPX--;
                this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdKiemKe"].ToString());
                this.LoadPhieuXuat(this.IdPhieuXuat);
                Updating = false;
                setEDFunctions();
                setEDUpdate();
            }
        }
        private void tsbNext_Click(object sender, EventArgs e)
        {
            next();
            showInfors();
        }
        private void next()
        {
            if (IndexPX < dtPhieuXuat.Rows.Count - 1)
            {
                if (Updating)
                {
                    if (MessageBox.Show("Dữ liệu đang cập nhật, bạn có muốn hủy bỏ không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
                IndexPX++;
                this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdKiemKe"].ToString());
                this.LoadPhieuXuat(this.IdPhieuXuat);
                Updating = false;
                setEDFunctions();
                setEDUpdate();
            }
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            add();
            this.Text = "Cập nhật phiếu kiểm kê. Đang tạo phiếu kiểm kê mới ...";
        }
        private void LoadOfflineData()
        {
            try
            {
                string str = "Select hh.MaVach,sp.IdSanPham,sp.MaSanPham, sp.TenSanPham,dvt.TenDonViTinh,hh.SoLuong," +
                          "case when sp.TrungMaVach is null then 0 else sp.TrungMaVach end TrungMaVach " +
                      " From tbl_HangHoa_Chitiet hh " +
                      " inner join tbl_SanPham sp on hh.IdSanPham = sp.IdSanPham " +
                      " inner join tbl_DM_DonViTinh dvt on sp.IdDonViTinh = dvt.IdDonViTinh " +
                      " Where hh.IdKho=" + this.cboKhoXuat.SelectedValue;
 
                dtSanPham = DBTools.getData("tmp", str).Tables["tmp"];
                LoadMaVach();

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

        private void add()
        {
            try
            {
                //this.LoadOfflineData();
                this.Updating = true;
                this.setEDItems(true);
                this.setEDUpdate();
                this.PhieuXuat_ThemMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            edit();
            this.Text = "Cập nhật phiếu kiểm kê.";
            if (dtPhieuXuat != null)
            {
                this.Text += " - Tổng số phiếu [" + dtPhieuXuat.Rows.Count + "]";
                if (dtPhieuXuat.Rows.Count > 0)
                    this.Text += " - Đang sửa phiếu số [" + (this.IndexPX + 1) + "] ...";
            }
        }
        private void edit()
        {
            Updating = true;
            setEDItems(true);
            setEDUpdate();
        }
        private void setEDItems(bool status)
        {
            this.mstNgayXuat.Enabled = status;
            this.txtGhiChu.Enabled = status;
            this.txtMaVach.Enabled=status;
            this.btnThemHang.Enabled = status;
            this.btnXoaSanPham.Enabled = status;
        }
        private void setEDFunctions()
        {
            if (IdPhieuXuat == 0)
            {
                this.tsbPrev.Enabled = false;
                this.tsbNext.Enabled = false;
                this.tsbEdit.Enabled = false;
                this.tsbDelete.Enabled = false;
                //this.tsbPrint.Enabled = false;
            }
            else
            {
                this.tsbPrev.Enabled = IndexPX > 0 ? true : false;
                this.tsbNext.Enabled = IndexPX < (dtPhieuXuat.Rows.Count - 1) ? true : false;
                this.tsbEdit.Enabled = true;
                this.tsbDelete.Enabled = true;
                this.tsbUpdate.Enabled = true;
                //this.tsbPrint.Enabled = true;
            }
            this.tsbAdd.Enabled = true;// Common.IsEnableCommandPX(-1);
            this.tsbDelete.Enabled = this.tsbDelete.Enabled & !DaLapHoaDon;
        }

        private void setEDUpdate()
        {
            this.tsbAdd.Enabled = !Updating;
            this.tsbEdit.Enabled = !Updating;
            this.tsbUpdate.Enabled = Updating;// &ChuaDayOracle;
            //this.tsbPrint.Enabled = Updating;
            //this.tsbPayment.Enabled = Updating;
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            RecalculateInfors();
            update(false);
            showInfors();
        }
        private bool update(bool print)
        {
            GtidCommand sqlCmd = null;
            string strMsg = "Tạo mới phiếu kiểm kê thành công!";
            bool isAdded = false;
            try
            {
                if (!this.PhieuXuat_SuHopLeCuaThongTin()) return false;

                sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                ConnectionUtil.Instance.BeginTransaction();
                //Cap nhat thong tin chung
                if (this.IdPhieuXuat == 0)
                {
                    //Them header
                    this.PhieuXuat_InsertCommand(sqlCmd);
                    isAdded = true;
                }
                else
                {
                    //sua header
                    this.PhieuXuat_UpdateCommand(sqlCmd);
                    //xoa het chi tiet cu
                    this.PhieuXuat_AllDetails_DeleteCommand(sqlCmd);
                    strMsg = "Cập nhật phiếu kiểm kê thành công!";
                }

                //Them chi tiet san pham ban
                List<ChiTietKiemKe> listPX = GetChiTietPhieuXuat(sqlCmd);
                foreach (ChiTietKiemKe px in listPX)
                {
                    //them bang chi tiet phieu xuat
                    int idChitietPX = this.ChiTietPX_InsertCommand(sqlCmd, px.IdSanPham, px.SoLuong);
                    //them bang chi tiet hang hoa
                    foreach (ChiTietKKHangHoa hh in px.DsHangHoa)
                        this.ChiTietPX_HangHoa_InsertCommand(sqlCmd, idChitietPX, hh.IdHangHoa, hh.SoLuong, hh.SoLuongSoSach, hh.GhiChu);
                }

                //Them cac san pham ma vach khong co trong kho
                ChiTietPX_KhongMaVach_InsertCommand(sqlCmd);
                ConnectionUtil.Instance.CommitTransaction();

                Common.LogAction(strMsg, "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu kiểm kê = " + txtSoPhieu.Text, Declare.IdKho);
                MessageBox.Show(strMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Dong trong truong hop sua tu danh sach tim kiem
                if (this.IndexPXSearch >= 0)
                {
                    this.Close();
                    return true;
                }
                //Thiet lap trang thai item, load lai danh sach phieu xuat
                if (isAdded)
                {
                    LoadAllPhieuXuat();
                    IndexPX = dtPhieuXuat.Rows.Count - 1;
                }
                Updating = false;
                setEDFunctions();
                setEDUpdate();
                setEDItems(false);
                LoadOfflineData();
                
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Common.LogAction("Lỗi cập nhật phiếu kiểm kê" , "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu kiểm kê = " + txtSoPhieu.Text, Declare.IdKho);
                //if (sqlTran != null)
                //    sqlTran.Rollback();
                return false;
            }
            return true;
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            delete();
            showInfors();
        }
        private void delete()
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc chắn hủy dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNoCancel);
            if (rs == DialogResult.Cancel)
            {
                return;
            }
            else if (rs == DialogResult.Yes)
            {

                //if (MessageBox.Show("Bạn có chắc chắn hủy dữ liệu này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                //    return;

                //Xoa du lieu hien tai
                if (this.IdPhieuXuat != 0)
                {

                    GtidCommand sqlCmd = null;
                    try
                    {
                        sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                        ConnectionUtil.Instance.BeginTransaction();
                        //xoa chi tiet phieu xuat
                        this.PhieuXuat_DeleteCommand(sqlCmd);
                        ConnectionUtil.Instance.CommitTransaction();
                        Common.LogAction("Xóa phiếu kiểm kê thành công", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu kiểm kê = " + txtSoPhieu.Text, Declare.IdKho);
                        MessageBox.Show("Hủy phiếu kiểm kê thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Dong trong truong hop sua tu danh sach tim kiem
                        if (this.IndexPXSearch >= 0)
                        {
                            this.dtPXSearch.Rows.RemoveAt(this.IndexPXSearch);
                            this.Close();
                            return;
                        }
                        dtPhieuXuat.Rows.RemoveAt(IndexPX);

                    }
                    catch (Exception ex)
                    {
                        ConnectionUtil.Instance.RollbackTransaction();
                        Common.LogAction("Xóa phiếu kiểm kê thất bại", "Id phiếu = " + this.IdPhieuXuat + "; Số phiếu kiểm kê = " + txtSoPhieu.Text, Declare.IdKho);
                        MessageBox.Show("Lỗi ngoại lệ:" + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //if (sqlTran != null)
                        //    sqlTran.Rollback();
                    }
                }
            }

            //Hien thi du lieu tiep theo
            if (IndexPX == dtPhieuXuat.Rows.Count)
            {
                IndexPX--;
            }
            if (dtPhieuXuat.Rows.Count > 0)
            {
                this.IdPhieuXuat = Common.IntValue(dtPhieuXuat.Rows[IndexPX]["IdKiemKe"].ToString());
                this.LoadPhieuXuat(this.IdPhieuXuat);
            }
            else
                this.PhieuXuat_ThemMoi();
            //Thiet lap trang thai item
            Updating = false;
            setEDUpdate();
            setEDItems(false);
            setEDFunctions();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            //int[] IdPhieu = new int[] { 0 };
            //frmTimPhieuXuat frm = new frmTimPhieuXuat((int)TransactionType.XUAT_BAN, IdPhieu);
            //if (frm.ShowDialog() == DialogResult.OK) {
            //    if (IdPhieu[0] > 0) {
            //        this.IdPhieuXuat = IdPhieu[0];
            //        if (dtPhieuXuat.PrimaryKey.Length == 0)
            //            dtPhieuXuat.PrimaryKey = new DataColumn[] { dtPhieuXuat.Columns["IdKiemKe"] };
            //        IndexPX = dtPhieuXuat.Rows.IndexOf(dtPhieuXuat.Rows.Find(this.IdPhieuXuat));
            //        this.LoadPhieuXuat(this.IdPhieuXuat);
            //        setEDFunctions();
            //        if (ChuaDayOracle)
            //            tsbEdit_Click(this, null);
            //    }
            //}
            //frm.MdiParent = this.ParentForm;
            //this.Close();            
        }

 
        private void tsbClose_Click(object sender, EventArgs e)
        {
            close();
        }
        private void close()
        {
            try
            {
                this.Close();
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

        private void RecalculateInfors()
        {
            try
            {
                dgvSanPhamBan.EndEdit();
                dgvSanPhamKhongCo.EndEdit();
            }
            catch (Exception ex) { }   
        }


        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSanPhamBan.SelectedRows)
            {
                dgvSanPhamBan.Rows.Remove(row);
            }
        }




        private void txtMaVach_Leave(object sender, EventArgs e)
        {
            //if (txtMaVach.Text.Trim() != "")
            //    InputDataFromCode(txtMaVach.Text.Trim(), false);
        }

 
        private void txtMaVach_Enter(object sender, EventArgs e)
        {
            this.txtMaVach.Focus();
            this.txtMaVach.SelectAll();
        }

 
        private void dgvSanPhamBan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSanPhamBan.CurrentRow != null)
            {
                if (dgvSanPhamBan.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamBan.CurrentRow.Cells["SoLuong"])
                {
                    Utils ut = new Utils();
                    if (ut.getInt(e.FormattedValue) <= 0)
                    {
                        MessageBox.Show("Số lượng phải >0");
                        e.Cancel = true;
                    }
                }
            }
        }


        private void dgvSanPhamBan_Leave(object sender, EventArgs e)
        {
            dgvSanPhamBan.EndEdit();
        }

        private void btnXoaSanPhamKoCo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSanPhamKhongCo.SelectedRows)
            {
                dgvSanPhamKhongCo.Rows.Remove(row);
            }
        }

        private void dgvSanPhamKhongCo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvSanPhamKhongCo.EndEdit();
            if (dgvSanPhamKhongCo.CurrentRow != null)
            {
                if (dgvSanPhamKhongCo.CurrentRow.Cells[e.ColumnIndex] == dgvSanPhamKhongCo.CurrentRow.Cells["MaSanPhamKC"])
                {
                    string masp = dgvSanPhamKhongCo.CurrentRow.Cells["MaSanPhamKC"].Value.ToString();
                    string str = "Select sp.IdSanPham, sp.TenSanPham, dvt.TenDonViTinh " +
                          " From tbl_SanPham sp inner join tbl_dm_DonViTinh dvt on sp.IdDonViTinh = dvt.IdDonViTinh " +
                          " Where sp.MaSanPham='" + masp + "'";
                    DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];
                    if (dt!=null && dt.Rows.Count>0)
                    {
                        dgvSanPhamKhongCo.CurrentRow.Cells["IdSanPhamKC"].Value = dt.Rows[0]["IdSanPham"];
                        dgvSanPhamKhongCo.CurrentRow.Cells["TenSanPhamKC"].Value = dt.Rows[0]["TenSanPham"];
                        dgvSanPhamKhongCo.CurrentRow.Cells["DVTKC"].Value = dt.Rows[0]["TenDonViTinh"];
                    }

                }
            }
        }


    }
}