using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

// form frmChiTiet_ChungTunNhap
// Người tạo: Trần Tuấn Cường
// Ngày tạo : 25/05/2012
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTiet_ChungTuNhapBase : frmBCBase
    {
        public string DonViTinh;
        public int OID;
        protected string SoChungTu;
        protected string NgayLap;
        protected string NguoiLap;
        protected string GhiChu;
        protected string ReportTitle;
        public string SoPO;
        public int IdSanPham;
        public int InDex;
        private bool IsAdd = false;

        public ChungTuBusinessBase Business;
        /// <summary>
        /// lấy các thông tin từ form ChiTiet_ChungTuNhapBase sang form ChungTuNhap_ChiTietHangHoaBase
        /// </summary>
        public ChungTuCTHanghoaBasePairInfo HangHoa = new ChungTuCTHanghoaBasePairInfo();
        /// <summary>
        /// list ra danh sách tất cả các bản ghi trong bang tbl_ChungTu_Chitiet qua IdChungTu
        /// </summary>
        public List<tmp_NhapHang_UserChiTietInfo> liChiTietChungTu = new List<tmp_NhapHang_UserChiTietInfo>();
        /// <summary>
        /// dùng add vào dcMaVach theo IdSanPham 
        /// </summary>
        public List<ChiTietHangHoaGridInfo> LiMaVach = new List<ChiTietHangHoaGridInfo>();
        /// <summary>
        /// list ra danh sách tất mã vạch có qua IdChungTu hoặc SoPO
        /// </summary>
        protected BindingList<ChungTu_ChiTietHangHoaBaseInfo> listChungTuChiTietHangHoa = new BindingList<ChungTu_ChiTietHangHoaBaseInfo>();

        protected readonly string SoPhieuPrefix;

        public frmChiTiet_ChungTuNhapBase()
        {
            InitializeComponent();
            dgvChiTiet.AutoGenerateColumns = false;
            //dgvChiTiet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvChiTiet_CellValidating);
        }

        public frmChiTiet_ChungTuNhapBase(string soPhieuPrefix)
        {
            InitializeComponent();
            dgvChiTiet.AutoGenerateColumns = false;
            SoPhieuPrefix = soPhieuPrefix;
            //dgvChiTiet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvChiTiet_CellValidating);
        }

        public frmChiTiet_ChungTuNhapBase(int oid,string sochungtu,string ngaylap,string SoPO)
        {
            InitializeComponent();
            this.OID = oid;
            this.SoChungTu = sochungtu;
            this.NgayLap = ngaylap;
            this.SoPO = SoPO;
            btnThemSP.ShortCutKey = Keys.F3;
            dgvChiTiet.AutoGenerateColumns = false;
            //dgvChiTiet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvChiTiet_CellValidating);
        }

        public frmChiTiet_ChungTuNhapBase(int oid, string sochungtu, string ngaylap, string SoPO, string soPhieuPrefix)
        {
            InitializeComponent();
            this.OID = oid;
            this.SoChungTu = sochungtu;
            this.NgayLap = ngaylap;
            this.SoPO = SoPO;
            btnThemSP.ShortCutKey = Keys.F3;
            dgvChiTiet.AutoGenerateColumns = false;
            SoPhieuPrefix = soPhieuPrefix;
            //dgvChiTiet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvChiTiet_CellValidating);
        }
        protected bool IsSupperUser()
        {
            //if (((NguoiDungInfor)Declare.USER_INFOR).TenDangNhap == "tufpt") return true;

            return false;
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        protected virtual ChungTuBusinessBase GetBussiness()
        {
            return null;
        }

        protected virtual void LoadDataInstance(){}

        protected virtual DataGridViewTextBoxColumn ColumnMaSanPham
        {
            get { return null; }
        }

        private void LoadData()
        {
            btnCapNhat.Text = Resources.btnSave;
            btnThemSP.Text = Resources.btnAdd;
            btnXoaSP.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            btnChiTietMaVach.Text = Resources.btnInfor;
            btnInPhieu.Text = Resources.btnPrint;
            //btnXacNhan.Text = Resources.btnDraft;
            LoadDataInstance();
            dtNgayLap.BackColor = Color.White;
            dtNgayLap.ForeColor = Color.Black;
            if (OID == 0)
            {
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(SoPhieuPrefix);
                IsAdd = true;
            }
            else
            {
                txtSoPhieu.Text = SoChungTu;
            }

            if (liChiTietChungTu.Count > 0)
            {
                btnThemSP.Enabled = true;
            }

            if (IsSupperUser())
            {
                //btnXoaSP.Enabled = true;
                //dtNgayLap.Enabled = true;
            }
        }
        
        protected virtual void SaveChungTuInstance(){}
        protected virtual void AfterSaveChungTuInstance(){}
        protected virtual void Reload(){}
       
        protected virtual void OnDeleteChungTu()
        {
            throw new Exception("Chức năng này chưa được thực hiện");
        }

        private void DeleteChungTu()
        {
            try
            {
                if (this.Business == null) this.Business = GetBussiness();
                ConnectionUtil.Instance.BeginTransaction();
                //OnDeleteChungTu();
                Business.DeleteChungTu();
                ConnectionUtil.Instance.CommitTransaction();
                MessageBox.Show("Đã xóa thành công.");
                this.Close();
                Reload();
            }
            catch (Exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw;
            }
        }

        protected virtual void SaveChungTu()
        {
            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());
            if (li.Count > 0 && OID == 0)
            {
                txtSoPhieu.Focus();
                throw new ManagedException("Số phiếu đã tồn tại trong hệ thống. Xin hãy kiểm tra lại!");
            }
            if (this.Business == null) this.Business = GetBussiness();

            try
            {
                ConnectionUtil.Instance.BeginTransaction();
                SaveChungTuInstance();
                Business.SaveChungTu();
                AfterSaveChungTuInstance();
                ConnectionUtil.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw;
            }
            Reload();
            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //    {
            //        SaveChungTuInstance();
            //        Business.SaveChungTu();
            //        AfterSaveChungTuInstance();
            //    });
        }

        /// <summary>
        /// hàm này chỉ sử dụng khi cần thao tác với form ChungTuNhap_ChiTietHangHoaBase
        /// </summary>
        /// <param name="e"></param>
        protected virtual void ClickInstance(int e){}

        private void GetValues(int e)
        {
            GetValuesInstance(e);
        }
        /// <summary>
        /// khi click vào cell, lấy ra các thông tin cần có của databounditem
        /// </summary>
        /// <param name="e"></param>
        protected virtual void GetValuesInstance(int e)
        {
            //chỗ này không throw exception vì có một số nghiệp vụ không cần đến chi tiết hàng hóa
            
            //throw new NotImplementedException();
        }

        protected virtual void DoubleClickInstance(){}

        private void frmChiTiet_ChungTuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.DesignMode) LoadData();
                if (OID == 0)
                {
                    btnInPhieu.Enabled = false;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString(), this.Name);
            }
        }
        
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoaSP.Enabled = true;
            btnChiTietMaVach.Enabled = true;
            if (dgvChiTiet.CurrentRow == null || 
                dgvChiTiet.CurrentRow.DataBoundItem == null ||
                dgvChiTiet.CurrentRow.IsNewRow)
            {
                btnXoaSP.Enabled = false;
                btnChiTietMaVach.Enabled = false;
            }
            InDex = e.RowIndex;
            if (e.RowIndex >= 0 && dgvChiTiet.CurrentRow != null && dgvChiTiet.CurrentRow.DataBoundItem != null)
            {
                GetValues(e.RowIndex);
            }
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            if (InDex >= 0 && dgvChiTiet.CurrentRow != null && !dgvChiTiet.CurrentRow.IsNewRow)
            {
                DoubleClickInstance();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SaveChungTu();
                //if (IsAdd)
                //{
                //    MessageBox.Show("Thêm mới thành công!");
                //}
                //else
                //{
                //    MessageBox.Show("Cập nhật thành công!");
                //}
                
                DialogResult = DialogResult.OK;
            }
            catch(ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif                
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        /// <summary>
        /// Hàm này để kiểm tra xem thông tin trên form có bị thay đổi hay không
        /// </summary>
        /// <returns>Mặc định là không có sự thay đổi gì, thoát khỏi form sẽ không hỏi</returns>
        protected virtual bool HasChanged()
        {
            return false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if(HasChanged())
            {
                if (MessageBox.Show("Dữ liệu chưa được lưu có thể sẽ bị mất. Bạn có chắc chắn muốn thoát ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Cancel;
                }
                return;
            }
            DialogResult = DialogResult.Cancel;
        }

        private void btnChiTietMaVach_Click(object sender, EventArgs e)
        {
            if (InDex >= 0)
            {
                DoubleClickInstance();
            }
        }

        //private void btnInPhieu_Click(object sender, EventArgs e)
        //{
        //    ShowReport(ReportTitle);
        //}

        void dgvChiTiet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ColumnMaSanPham == null) return;
            if (dgvChiTiet.CurrentCell != null && dgvChiTiet.CurrentCell.ColumnIndex == dgvChiTiet.Columns.IndexOf(ColumnMaSanPham))
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                e.Control.TextChanged += new EventHandler(Control_TextChanged);
            }
        }

        //void dgvChiTiet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (ColumnMaSanPham != null && e.ColumnIndex == ColumnMaSanPham.Index)
        //    {
        //        if (e.FormattedValue == null || String.IsNullOrEmpty(e.FormattedValue.ToString()))
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //}

        private bool isKeyPressed;
        void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
           // if(e.KeyChar)
            isKeyPressed = true;
        }
        protected virtual int GetIdKho()
        {
            return Declare.IdKho;
        }
        void Control_TextChanged(object sender, EventArgs e)
        {
            try
            {
                frmLookUp_SanPham frm;

                if (ColumnMaSanPham == null) return;
                if (!isKeyPressed || dgvChiTiet.CurrentCell.ColumnIndex != dgvChiTiet.Columns.IndexOf(ColumnMaSanPham) ||
                    ((TextBox)sender).Text == String.Empty || ((TextBox)sender).Text == (string)dgvChiTiet.CurrentCell.Value) return;

                if (this.Business == null) this.Business = GetBussiness();

                if (Business.BusinessType == BusinessType.VIRTUAL_OUT || Business.BusinessType == BusinessType.REAL_OUT)
                    frm = new frmLookUp_SanPham(GetIdKho(), 0, true, Business.BusinessType == BusinessType.VIRTUAL_OUT, String.Format("%{0}%", ((TextBox)sender).Text));
                else
                    frm = new frmLookUp_SanPham(String.Format("%{0}%", ((TextBox)sender).Text));

                dgvChiTiet.CurrentCell.Value = null;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    isKeyPressed = false;
                    PickUpSanPhamInfo(frm.SelectedItem);
                }
                else
                {
                    ((TextBox)sender).Text = String.Empty;
                }
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }            
        }

        protected virtual void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            
        }

        void dgvChiTiet_SelectionChanged(object sender, EventArgs e)
        {
            //btnXoaSP.Enabled = (dgvChiTiet.CurrentRow != null && dgvChiTiet.CurrentRow.DataBoundItem != null);
            btnChiTietMaVach.Enabled = (dgvChiTiet.CurrentRow != null && dgvChiTiet.CurrentRow.DataBoundItem != null);
            GetValuesInstance(dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow));
        }

        void btnThemSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null && dgvChiTiet.CurrentRow.IsNewRow) return;
            if(dgvChiTiet.Rows.Count > 0)
            {
                if (dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 1].IsNewRow)
                {
                    dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 1].Selected = true;
                    dgvChiTiet.CurrentCell = dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 1].Cells[0];
                    return;
                }
            }
            dgvChiTiet.Rows.Add();
            dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 1].Selected = true;
            dgvChiTiet.CurrentCell = dgvChiTiet.Rows[dgvChiTiet.Rows.Count - 1].Cells[0];
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //if(MessageBox.Show("Bạn sẽ không thể sửa lại chứng từ này được nữa. Bạn có chắc chắn không?", Resources.Confirm, MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                
            //}
        }

        private void txtSoPhieu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(OID == 0)
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(SoPhieuPrefix);
        }

        private void txtSoPhieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && OID == 0)
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(SoPhieuPrefix);
        }

        void frmChiTiet_ChungTuNhapBase_KeyDown(object sender, KeyEventArgs e)
        {
            QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        //private void btnXoaSP_Click(object sender, EventArgs e)
        //{
        //    if(MessageBox.Show("Bạn có chắc chắn xóa chứng từ này không?","Xác nhận xóa", MessageBoxButtons.YesNo) ==DialogResult.Yes)
        //    {
        //        DeleteChungTu();
        //    }
        //}
    }
}