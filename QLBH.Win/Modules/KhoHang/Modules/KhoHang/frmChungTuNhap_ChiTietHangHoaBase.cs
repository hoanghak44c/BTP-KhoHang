using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

// form frmChungTuNhap_ChiTietHangHoaBase
// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:


namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChungTuNhap_ChiTietHangHoaBase : DevExpress.XtraEditors.XtraForm
    {
        private frmChiTiet_ChungTuNhapBase frm;
        private frmChiTietNhapThanhPham frmNhapThanhPhan;
        public int SLCu;
        protected int count=0;
        protected double SoLuongTong=0;
        private ChungTuCTHanghoaBasePairInfo HangHoa = new ChungTuCTHanghoaBasePairInfo();
        //protected BindingList<ChungTuChiTietHangHoaBaseInfo> liChiTiet = new BindingList<ChungTuChiTietHangHoaBaseInfo>();
        List<BaoCao_ChiTietInfor> mv = new List<BaoCao_ChiTietInfor>();
        List<ChungTuChiTietHangHoaBaseInfo> vv = new List<ChungTuChiTietHangHoaBaseInfo>();
        public int idSanPham;
        public frmChungTuNhap_ChiTietHangHoaBase()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        public frmChungTuNhap_ChiTietHangHoaBase(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo HangHoa)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.frm = frm;
            this.HangHoa = HangHoa;
        }

        public frmChungTuNhap_ChiTietHangHoaBase(frmChiTietNhapThanhPham frmNhapThanhPham, ChungTuCTHanghoaBasePairInfo HangHoa)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.frmNhapThanhPhan = frmNhapThanhPham;
            this.HangHoa = HangHoa;
        }

        public frmChungTuNhap_ChiTietHangHoaBase(ChungTuCTHanghoaBasePairInfo HangHoa)
        {
            InitializeComponent();
            this.HangHoa = HangHoa;
        }
        #region Action
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        #region LoadData
        protected virtual void LoadDataInstance(){}
        private void LoadData()
        {
            txtMaVach.Focus();
            lblMa.Text = HangHoa.TenSanPham;
            lblSoLuongTon.Text = HangHoa.SoLuong.ToString();
            idSanPham = HangHoa.IdSanPham;
            if (HangHoa.TrungMaVach == 0)
            {
                clSoLuong.ReadOnly = true;
            }
            else
            {
                clSoLuong.ReadOnly = false;
            }
            if (IsSupperUser())
            {
                btnXoaDong.Enabled = true;
            }
            else
            {
                btnXoaDong.Enabled = false;
            }
            //if (frm.dcMaVach.Count > 0 && frm.dcMaVach.ContainsKey(idSanPham))
            //{
            //    liChiTiet = (BindingList<ChungTu_ChiTietHangHoaBaseInfo>)frm.dcMaVach[idSanPham];
            //}
            LoadDataInstance();
            //dgvList.DataSource = liChiTiet;
            //foreach (DataGridCell pt in dgvList)
            //{
            //    count = count + pt.SoLuong;
            //    SoLuongTong = count * pt.DonGia;
            //}
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
            btnDong.Text = Resources.btnClose;
            btnGhi.Text = Resources.btnSave;
        }
        #endregion

        protected virtual void Check() { }

        #region AddNew
        protected virtual void AddNewInstance(){}
        private void AddNew()
        {
            if (String.IsNullOrEmpty(txtMaVach.Text.Trim()))
            {
                throw new ManagedException("Mã vạch không được để trống !");
            }
            txtMaVach.Text = txtMaVach.Text.Trim();
            Check();
            if (HangHoa.TrungMaVach == 0)
            {
                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    if (row.DataBoundItem as ChungTuChiTietHangHoaBaseInfo != null)
                    {
                        if ((row.DataBoundItem as ChungTuChiTietHangHoaBaseInfo).MaVach == txtMaVach.Text.Trim())
                        {
                            throw new InvalidOperationException("Mã vạch không được phép trùng nhau !");
                        }
                    }
                    //HanhBD check mã vạch đã có trong tbl_HangHoa_ChiTiet hay chưa!
                    //mv = NhapNoiBoDataProvider.Instance.GetTrungMaVach(txtMaVach.Text.Trim());
                    //(row.DataBoundItem as ChungTuChiTietHangHoaBaseInfo).IdChungTuChiTiet = vv.Find(delegate(ChungTuChiTietHangHoaBaseInfo match)
                    //{
                    //    return match.IdChungTuChiTiet == (row.DataBoundItem as ChungTuChiTietHangHoaBaseInfo).IdChungTuChiTiet;
                    //}).IdChungTuChiTiet;
                    //if (mv.Count != 0)
                    //{
                    //    throw new InvalidOperationException("Mã vạch đã có trong hệ thống. Xin mời bạn kiểm tra lại!");
                    //}
                }
                //for (int i = 0; i < liChiTiet.Count; i++)
                //{
                //    if (txtMaVach.Text.Trim() == liChiTiet[i].MaVach)
                //    {
                //        throw new InvalidOperationException("Mã vạch không được phép trùng nhau !");
                //    }
                //}
            }
            count++;
            SoLuongTong = count * HangHoa.DonGia;
            AddNewInstance();
            txtMaVach.Text = "";
            txtMaVach.Focus();

        }
        #endregion

        #region Save
        //protected virtual void SaveInstance(){}
        private void Save()
        {
            int soluong = 0;
            bool check = false;
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                if (!dgvList.Rows[i].IsNewRow)
                {
                    soluong = soluong + (dgvList.Rows[i].DataBoundItem as ChungTuChiTietHangHoaBaseInfo).SoLuong;
                }
            }
            if (soluong < HangHoa.SoLuong)
            {
                throw new InvalidOperationException("Bạn chưa thêm đủ số mã vạch !");
            }
            if (soluong > HangHoa.SoLuong)
            {
                throw new InvalidOperationException("Số lượng bạn nhập vào vượt quá số lượng xuất !");
            }
            //if (frm.dcMaVach.ContainsKey(idSanPham))
            //    frm.dcMaVach[idSanPham] = liChiTiet;
            //else
            //{
            //    frm.dcMaVach.Add(idSanPham, liChiTiet);
            //    //frm.liSanPhamNew.Add(idSanPham);
            //}
            //this.Close();
            //SaveInstance();
            DialogResult = DialogResult.OK;
        }
        #endregion

        private void frmChungTuNhap_ChiTietHangHoa_Load(object sender, EventArgs e)
        {
            if(!DesignMode) LoadData();
        }

        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNew();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected virtual void DeleteInstance(){}

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                //count = count - (dgvList.CurrentRow.DataBoundItem as ChungTuChiTietHangHoaBaseInfo).SoLuong;
                //SoLuongTong = count*liChiTiet[index].DonGia;
                DeleteInstance();
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Rows.Count > 0 && e.RowIndex >=0)
            {
               // btnXoaDong.Enabled = true;
                //index = e.RowIndex;
                SLCu = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells["clSoLuong"].Value);
            }
        }

        private void dgvList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void frmChungTuNhap_ChiTietHangHoaBase_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void Add_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    AddNew();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                    MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }
        }

        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            count = 0;
            SoLuongTong = 0;
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                count += Convert.ToInt32(dgvList.Rows[i].Cells["clSoLuong"].Value);
            }
            SoLuongTong = count * HangHoa.DonGia;
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
        }

        protected virtual bool CellValidating(object objValidating, int colIndex, int rowIndex)
        {
            return true;
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (!CellValidating(e.FormattedValue, e.ColumnIndex, e.RowIndex)) e.Cancel = true;
            }
            catch (Exception ex)
            {
                e.Cancel = true;
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                    MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
           
        }
    }
}