using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
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
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDeNghiDieuChuyen : frmChiTiet_ChungTuNhapBase
    {
        private DeNghiDieuChuyenBussiness business;
        //private List<DeNghiDieuChuyenInfor> liChiTiet;
        private int IdKho;
        private int IdKhoDieuChuyen;
        private int trangThai;
        private ComboBox cboKho;
        private Label lblKhoHang;
        private DataGridViewTextBoxColumn colMaSanPham;
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
        List<DMKhoInfo> litype = new List<DMKhoInfo>();
        public frm_PhieuDeNghiDieuChuyen(int OID, string PhieuNhap, string NgayLap, string PO, int TrangThai,int idKhoDieuChuyen)
            : base(OID, PhieuNhap, NgayLap, PO, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            LoadKho();
            cboKho.Enabled = true;
            dgvChiTiet.AutoGenerateColumns = false;
            this.trangThai = TrangThai;
            this.IdKhoDieuChuyen = idKhoDieuChuyen;
            business = new DeNghiDieuChuyenBussiness(new ChungTuDieuChuyenInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                IdChungTu = OID,
                SoChungTu = PhieuNhap,
                NgayLap = Convert.ToDateTime(NgayLap),
                IdKho = Declare.IdKho
                //SoChungTuGoc = PO
            });
        }

        public frm_PhieuDeNghiDieuChuyen(ChungTuDieuChuyenInfor chungTuDeNghiXuatDieuChuyenInfor)
            : base(chungTuDeNghiXuatDieuChuyenInfor.IdChungTu, chungTuDeNghiXuatDieuChuyenInfor.SoChungTu, chungTuDeNghiXuatDieuChuyenInfor.NgayLap.ToString(), string.Empty, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            LoadKho();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            cboKho.Enabled = true;
            business = new DeNghiDieuChuyenBussiness(chungTuDeNghiXuatDieuChuyenInfor);

        }

        public frm_PhieuDeNghiDieuChuyen() : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            LoadKho();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiDieuChuyenBussiness();
            cboKho.Enabled = true;
        }
        private void LoadKho()
        {
            litype = DMKhoDataProvider.GetListDMKhoInfor();
            if (litype.Count > 0)
            {
                cboKho.DataSource = litype;
                cboKho.DisplayMember = "TenKho";
                cboKho.ValueMember = "IdKho";
                cboKho.SelectedValue = IdKhoDieuChuyen;
            }
            else
            {
                cboKho.DataSource = null;
            }
        }

        protected override void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            business.ListChiTietChungTu[dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow)] = new DeNghiDieuChuyenInfor()
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
                return colMaSanPham;
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
            DateTime Ngaylap = business.ChungTu.NgayLap;
         
            if (Ngaylap <= dtNgayLap.Properties.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            }
            else
            {
                dtNgayLap.Text = Ngaylap.ToString();
            }
            bdSource = new BindingSource();
            if (business.ListChiTietChungTu != null)
                bdSource.DataSource = new BindingList<DeNghiDieuChuyenInfor>(business.ListChiTietChungTu);
            bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);
            dgvChiTiet.DataSource = bdSource;
            btnXoaSP.Enabled = false;
            btnCapNhat.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT))
            {
                btnXoaSP.Enabled = false;
                btnChiTietMaVach.Enabled = false;
                btnThemSP.Enabled = false;
                btnCapNhat.Enabled = false;
                txtNguoiLap.Enabled = false;
                txtGhiChu.Enabled = false;
                cboKho.Enabled = false;
                dtNgayLap.Enabled = false;
                cboKho.Enabled = false;
                clSoLuong.ReadOnly = true;
            }
            else
            {
                btnChiTietMaVach.Enabled = false;
                btnXoaSP.Enabled = true;
                btnThemSP.Enabled = true;
                btnCapNhat.Enabled = true; 
                clSoLuong.ReadOnly = false;
            }
            cboKho.SelectedValue = IdKhoDieuChuyen;
        }

        protected override void GetValuesInstance(int e)
        {
            btnChiTietMaVach.Enabled = false;
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount <= 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            if (Equals(cboKho.SelectedValue, null))
            {
                cboKho.Focus();
                throw new ManagedException("Bạn chưa chọn kho hàng chuyển đến!");
            }
            if(Equals(cboKho.SelectedValue,Declare.IdKho))
            {
                cboKho.Focus();
                throw new ManagedException("Bạn phải chọn kho khác với kho hiện tại!");
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
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
                //business.ChungTu.NgayLap = DateTime.Now;
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                business.ChungTu.IdKhoDieuChuyen = Convert.ToInt32(cboKho.SelectedValue.ToString());
                business.ChungTu.IdNhanVien = Declare.IdNhanVien;
                business.ChungTu.IdKho = Declare.IdKho;
                business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN);

            }
        }

        private void dgvChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiDieuChuyen));
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.colMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnThemSP.TabIndex = 6;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 7;
            this.btnXoaSP.Text = "Xóa ";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 9;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSanPham,
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
            this.dgvChiTiet.TabIndex = 5;
            this.dgvChiTiet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvChiTiet_UserDeletingRow);
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Size = new System.Drawing.Size(337, 21);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.TabIndex = 14;
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 10;
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
            // cboKho
            // 
            this.cboKho.Enabled = false;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(529, 46);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(412, 21);
            this.cboKho.TabIndex = 4;
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(460, 50);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(63, 16);
            this.lblKhoHang.TabIndex = 15;
            this.lblKhoHang.Text = "Kho hàng";
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.DataPropertyName = "MaSanPham";
            this.colMaSanPham.HeaderText = "Mã sản phẩm";
            this.colMaSanPham.MinimumWidth = 150;
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMaSanPham.Width = 150;
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
            // frm_PhieuDeNghiDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.cboKho);
            this.Controls.Add(this.lblKhoHang);
            this.Name = "frm_PhieuDeNghiDieuChuyen";
            this.Text = "Phiếu đề nghị xuất điều chuyển";
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
            this.Controls.SetChildIndex(this.cboKho, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
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
            List<BaoCao_ChiTietInfor> list = DeNghiDieuChuyenDataProvider.Instance.GetPhieuDeNghiXuatDieuChuyenDetail(OID);
            rpt_BC_PhieuDeNghiXuatDieuChuyen rpt = new rpt_BC_PhieuDeNghiXuatDieuChuyen();
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }
    }
}
