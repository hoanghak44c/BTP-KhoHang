using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

// form frm_PhieuDeNghiXuatTieuHao
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 17/06/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD form_PhieuDeNghiXuatTieuHao
namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDeNghiXuatTieuHao : frmChiTiet_ChungTuNhapBase
    {
        private DeNghiXuatTieuHaoBusiness business;
        //private List<DeNghiXuatTieuHaoChiTietInfo> liChiTiet;
        private int trangThai;
        //private string GhiChu;
        //private string NguoiLap;
        private int IdChiPhi, IdPhongBan;
        List<DMPhongBanInfor> liPhongBan = new List<DMPhongBanInfor>();
        List<DMChiPhiInfo> liChiPhi = new List<DMChiPhiInfo>();
        private DataGridViewTextBoxColumn MaSanPham;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn ThanhTien;
        public int SLCu;
        private string maSanPham;
        private int idSanPham = 0;
        private ComboBox cboPhongBan;
        private Label lblKhoHang;
        private ComboBox cboChiPhi;
        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Label label5;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiXuatTieuHao));
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboPhongBan = new System.Windows.Forms.ComboBox();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.cboChiPhi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.TabIndex = 7;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 8;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 10;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSanPham,
            this.dataGridViewTextBoxColumn2,
            this.clSoLuong,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvChiTiet.TabIndex = 6;
            this.dgvChiTiet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellValueChanged);
            this.dgvChiTiet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvChiTiet_UserDeletingRow);
            this.dgvChiTiet.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvChiTiet_CellValidating);
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Size = new System.Drawing.Size(337, 21);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTietMaVach.Image")));
            this.btnChiTietMaVach.TabIndex = 9;
            this.btnChiTietMaVach.Text = "Chi tiết";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            // 
            // MaSanPham
            // 
            this.MaSanPham.Name = "MaSanPham";
            // 
            // TenSanPham
            // 
            this.TenSanPham.Name = "TenSanPham";
            // 
            // SoLuong
            // 
            this.SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            this.DonGia.Name = "DonGia";
            // 
            // ThanhTien
            // 
            this.ThanhTien.Name = "ThanhTien";
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.FormattingEnabled = true;
            this.cboPhongBan.Location = new System.Drawing.Point(525, 46);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Size = new System.Drawing.Size(165, 21);
            this.cboPhongBan.TabIndex = 4;
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(457, 51);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(70, 16);
            this.lblKhoHang.TabIndex = 13;
            this.lblKhoHang.Text = "Phòng ban";
            // 
            // cboChiPhi
            // 
            this.cboChiPhi.FormattingEnabled = true;
            this.cboChiPhi.Location = new System.Drawing.Point(768, 46);
            this.cboChiPhi.Name = "cboChiPhi";
            this.cboChiPhi.Size = new System.Drawing.Size(173, 21);
            this.cboChiPhi.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(705, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Chi phí";
            // 
            // clMaSanPham
            // 
            this.clMaSanPham.DataPropertyName = "MaSanPham";
            this.clMaSanPham.HeaderText = "Mã sản phẩm";
            this.clMaSanPham.MinimumWidth = 150;
            this.clMaSanPham.Name = "clMaSanPham";
            this.clMaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMaSanPham.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenSanPham";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên sản phẩm";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 50;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Thanhtien";
            this.dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TrangThai";
            this.dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 170;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MaVach";
            this.dataGridViewTextBoxColumn7.HeaderText = "mavach";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "IdSanPham";
            this.dataGridViewTextBoxColumn8.HeaderText = "clidsanpham";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SoPhieuNhap";
            this.dataGridViewTextBoxColumn9.HeaderText = "sophieu";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TrungMaVach";
            this.dataGridViewTextBoxColumn10.HeaderText = "trungmavach";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TenDonViTinh";
            this.dataGridViewTextBoxColumn11.HeaderText = "donvitinh";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "SoPO";
            this.dataGridViewTextBoxColumn12.HeaderText = "soPO";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // frm_PhieuDeNghiXuatTieuHao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.cboChiPhi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.lblKhoHang);
            this.Name = "frm_PhieuDeNghiXuatTieuHao";
            this.Text = "Phiếu đề nghị xuất tiêu hao";
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.lblKhoHang, 0);
            this.Controls.SetChildIndex(this.cboPhongBan, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cboChiPhi, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frm_PhieuDeNghiXuatTieuHao(int OID, string PhieuNhap, string NgayLap, string PO, int TrangThai,string DienGiai, string NguoiXuat,int IdChiPhi,int IdPhongBan)
            : base(OID, PhieuNhap, NgayLap, PO, Declare.Prefix.PhieuXuatTieuHao)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            this.trangThai = TrangThai;
            this.GhiChu = DienGiai;
            this.NguoiLap = NguoiXuat;
            this.IdChiPhi = IdChiPhi;
            this.IdPhongBan = IdPhongBan;
            business = new DeNghiXuatTieuHaoBusiness(new ChungTuDeNghiXuatTieuHaoInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO),
                IdChungTu = OID,
                SoChungTu = PhieuNhap,
                NgayLap = Convert.ToDateTime(NgayLap),
                //SoChungTuGoc = PO
            });
        }

        public frm_PhieuDeNghiXuatTieuHao(ChungTuDeNghiXuatTieuHaoInfor xuatTieuHaoInfor)
            : base(xuatTieuHaoInfor.IdChungTu, xuatTieuHaoInfor.SoChungTu, xuatTieuHaoInfor.NgayLap.ToString(), string.Empty, Declare.Prefix.PhieuXuatTieuHao)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiXuatTieuHaoBusiness(xuatTieuHaoInfor);

        }

        public frm_PhieuDeNghiXuatTieuHao() : base(Declare.Prefix.PhieuXuatTieuHao)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiXuatTieuHaoBusiness();
        }

        private void LoadPhongBan()
        {
            liPhongBan = DMPhongBanDataProvider.Instance.GetListPhongBanInfor();
            if (liPhongBan.Count > 0)
            {
                cboPhongBan.DataSource = liPhongBan;
                cboPhongBan.DisplayMember = "TenPhongBan";
                cboPhongBan.ValueMember = "IdPhongBan";
            }
            else
            {
                cboPhongBan.DataSource = null;
            }
        }
        private void LoadChiPhi()
        {
            liChiPhi = DMChiPhiDataProvider.Instance.GetListChiPhiInfo();
            if (liChiPhi.Count > 0)
            {
                cboChiPhi.DataSource = liChiPhi;
                cboChiPhi.DisplayMember = "Ten";
                cboChiPhi.ValueMember = "IdChiPhi";
            }
            else
            {
                cboChiPhi.DataSource = null;
            }
        }

        private BindingSource bdSource;

        void bdSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (dgvChiTiet.Rows.Count == bdSource.Count)
            {
                bdSource.RemoveAt(bdSource.Count - 1);
                return;
            }
        }
        protected override void LoadDataInstance()
        {
            LoadChiPhi();
            LoadPhongBan();
            DateTime Ngaylap = business.ChungTu.NgayLap;
            if (Ngaylap <= dtNgayLap.Properties.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                txtNguoiLap.Text = Declare.UserName;
            }
            else
            {
                dtNgayLap.Text = Ngaylap.ToString();
                txtNguoiLap.Text = business.ChungTu.NguoiTao;
            }
            txtGhiChu.Text = GhiChu;
            bdSource = new BindingSource();
            if (business.ListChiTietChungTu != null)
            {
                bdSource.DataSource = new BindingList<DeNghiXuatTieuHaoChiTietInfo>(business.ListChiTietChungTu);
                bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);
                dgvChiTiet.DataSource = bdSource;
                cboPhongBan.SelectedValue = IdPhongBan;
                cboChiPhi.SelectedValue = IdChiPhi;
            }
            btnXoaSP.Enabled = false;
            btnCapNhat.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT))
            {
                btnXoaSP.Enabled = IsSupperUser();
                //btnInPhieu.Enabled = false;
                btnThemSP.Enabled = IsSupperUser();
                btnCapNhat.Enabled = IsSupperUser();
                txtNguoiLap.Enabled = IsSupperUser();
                txtGhiChu.Enabled = IsSupperUser();
                dtNgayLap.Enabled = IsSupperUser();
                cboPhongBan.Enabled = false;
                cboChiPhi.Enabled = false;
                clSoLuong.ReadOnly = IsSupperUser();
            }
            else
            {
                btnXoaSP.Enabled = true;
                btnThemSP.Enabled = true;
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = false;
            }
        }
        protected override void GetValuesInstance(int e)
        {
            btnChiTietMaVach.Enabled = false;
            btnXoaSP.Enabled = IsSupperUser();
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount <= 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++ )
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
               {
                   throw new ManagedException("Bạn chưa nhập số lượng!");
               }
            }
                return true;
        }
        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }
        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                business.ChungTu.IdNhanVien = Declare.IdNhanVien;
                business.ChungTu.IdKho = Declare.IdKho;
                business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                business.ChungTu.IdPhongBan = Convert.ToInt32(cboPhongBan.SelectedValue);
                business.ChungTu.IdChiPhi = Convert.ToInt32(cboChiPhi.SelectedValue);
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null) return;
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvChiTiet.Rows.Count > 0)
                {
                    dgvChiTiet.Rows.RemoveAt(dgvChiTiet.CurrentRow.Index);
                    btnXoaSP.Enabled = false;
                }
            }
        }
        //Ghi kèm trạng thái duyệt và thoát
        //private void btnInPhieu_Click(object sender, EventArgs e)
        //{
            //tblChungTuDataProvider.UpdateTrangThai(OID, TrangThaiDuyet.DA_XUAT);
            //DialogResult = DialogResult.OK;//tự hiểu và load lại datagridview
        //}

        protected override void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            foreach (DeNghiXuatTieuHaoChiTietInfo pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == sanPhamInfo.IdSanPham)
                {
                    MessageBox.Show("Không được nhập 2 mã sản phẩm giống nhau trên cùng 1 phiếu !");
                    return;
                }
            }
            business.ListChiTietChungTu[dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow)] = new DeNghiXuatTieuHaoChiTietInfo()
            {
                MaSanPham = sanPhamInfo.MaSanPham,
                IdSanPham = sanPhamInfo.IdSanPham,
                TenSanPham = sanPhamInfo.TenSanPham,
                DonGia = sanPhamInfo.GiaNhap,
                TrungMaVach = sanPhamInfo.TrungMaVach,
                SoLuong = 1
            };
            ((BindingSource)dgvChiTiet.DataSource).ResetBindings(false);
            btnCapNhat.Enabled = business.ListChiTietChungTu.Count > 0;
        }
        protected override DataGridViewTextBoxColumn ColumnMaSanPham
        {
            get
            {
                return clMaSanPham;
            }
        }
        private void dgvChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgvChiTiet.Columns["clMaSanPham"].Index)
            //{
            //    frmLookUp_SanPham frm = new frmLookUp_SanPham();
            //    if (frm.ShowDialog() == DialogResult.OK)//nếu kết quả trả về là form LookUp
            //    {
            //        business.ListChiTietChungTu.Add(new DeNghiXuatTieuHaoChiTietInfo()
            //        {
            //            MaSanPham = frm.SelectedItem.MaSanPham,
            //            IdSanPham = frm.SelectedItem.IdSanPham,
            //            TenSanPham = frm.SelectedItem.TenSanPham,
            //            DonGia = frm.SelectedItem.GiaNhap
            //        });

            //        ((BindingList<DeNghiXuatTieuHaoChiTietInfo>)dgvChiTiet.DataSource).ResetBindings();
            //    }
            //}

        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //btnXoaSP.Enabled = true;
            //btnCapNhat.Enabled = true;
            btnChiTietMaVach.Enabled = false;
        }
        //su ly nut del(click 1 dong an del thi hoi co xoa hay khong?)

        private void dgvChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void dgvChiTiet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
//            try
//            {
//                ChungTuXuatNccChiTietHangHoaInfo info =
//                ((ChungTuXuatNccChiTietHangHoaInfo)dgvChiTiet.CurrentRow.DataBoundItem);
//                if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clSoLuongXuat")
//                {
//                    int SLMoi = Convert.ToInt32(e.FormattedValue);
//                    if (SLMoi > SLCu)
//                    {
//                        if (info.SoLuongTT < SLMoi)
//                        {
//                            e.Cancel = true;
//                            throw new InvalidOperationException("Số lượng tồn không đủ để xuất !");
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
        }

        private void dgvChiTiet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex == dgvChiTiet.Columns["clMaSanPham"].Index)
            //{
            //    frmLookUp_SanPham frm = new frmLookUp_SanPham();
            //    if (frm.ShowDialog() == DialogResult.OK)//nếu kết quả trả về là form LookUp
            //    {
            //        ((DeNghiXuatTieuHaoBusiness)Business).ListChiTietChungTu.Add(new DeNghiXuatTieuHaoChiTietInfo()
            //        {
            //            MaSanPham = frm.SelectedItem.MaSanPham,
            //            IdSanPham = frm.SelectedItem.IdSanPham,
            //            TenSanPham = frm.SelectedItem.TenSanPham,
            //            DonGia = frm.SelectedItem.GiaNhap
            //        });

            //        ((BindingList<DeNghiXuatTieuHaoChiTietInfo>)dgvChiTiet.DataSource).ResetBindings();
            //    } 
            //}

        }

        private void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
                    if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
                        btnXoaSP.Enabled = false;
                        btnCapNhat.Enabled = dgvChiTiet.Rows.Count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmLookUp_SanPham frm = new frmLookUp_SanPham();
            if (frm.ShowDialog() == DialogResult.OK)//nếu kết quả trả về là form LookUp
            {
                PickUpSanPhamInfo(frm.SelectedItem);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<BaoCao_ChiTietXTHInfor> list = DeNghiXuatTieuHaoProvider.Instance.GetInPhieuDeNghiXuatTieuHao(OID);
                rpt_BC_PhieuDeNghiXuatTieuHao rpt = new rpt_BC_PhieuDeNghiXuatTieuHao();
                List<BaoCao_ChiTietXTHInfor> lst = new List<BaoCao_ChiTietXTHInfor>(list);
                rpt.DataSource = lst;
                rpt.ShowPreview();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }
    }
}
