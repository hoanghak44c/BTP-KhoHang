namespace QLBanHang.Modules.KhoHang
{
    partial class frmChungTuNhap_ChiTietHangHoaBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChungTuNhap_ChiTietHangHoaBase));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.lblSL = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaVach = new QLBH.Core.Form.GtidTextBox();
            this.btnThem = new QLBH.Core.Form.GtidButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoaDong = new QLBH.Core.Form.GtidSimpleButton();
            this.dgvList = new QLBH.Core.Form.GtidDataGridView();
            this.clMaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clidsanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltensanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmasanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblthanhtien = new DevExpress.XtraEditors.LabelControl();
            this.lblTongSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnGhi = new QLBH.Core.Form.GtidSimpleButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSoLuongTon);
            this.groupBox1.Controls.Add(this.lblSL);
            this.groupBox1.Controls.Add(this.lblMa);
            this.groupBox1.Controls.Add(this.lblTieuDe);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMaVach);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.Location = new System.Drawing.Point(516, 13);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(80, 14);
            this.lblSoLuongTon.TabIndex = 5;
            this.lblSoLuongTon.Text = "Số lượng tồn";
            this.lblSoLuongTon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(425, 13);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(85, 16);
            this.lblSL.TabIndex = 4;
            this.lblSL.Text = "Số lượng tồn";
            // 
            // lblMa
            // 
            this.lblMa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblMa.Location = new System.Drawing.Point(79, 13);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(328, 28);
            this.lblMa.TabIndex = 3;
            this.lblMa.Text = "Sản phẩm";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTieuDe.Location = new System.Drawing.Point(10, 14);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(63, 13);
            this.lblTieuDe.TabIndex = 2;
            this.lblTieuDe.Text = "Sản phẩm";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mã vạch";
            // 
            // txtMaVach
            // 
            this.txtMaVach.BackColor = System.Drawing.Color.PowderBlue;
            this.txtMaVach.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaVach.Location = new System.Drawing.Point(72, 44);
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.Size = new System.Drawing.Size(456, 44);
            this.txtMaVach.TabIndex = 0;
            this.txtMaVach.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaVach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Add_KeyDown);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(553, 48);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnThem.Size = new System.Drawing.Size(95, 25);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaDong);
            this.groupBox2.Controls.Add(this.dgvList);
            this.groupBox2.Controls.Add(this.lblthanhtien);
            this.groupBox2.Controls.Add(this.lblTongSoLuong);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Location = new System.Drawing.Point(2, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 312);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDong.Image")));
            this.btnXoaDong.Location = new System.Drawing.Point(624, 282);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXoaDong.Size = new System.Drawing.Size(24, 24);
            this.btnXoaDong.TabIndex = 5;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaVach,
            this.clDonViTinh,
            this.clSoLuong,
            this.clDonGia,
            this.clThanhTien,
            this.clidsanpham,
            this.cltensanpham,
            this.clmasanpham});
            this.dgvList.Location = new System.Drawing.Point(6, 12);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(642, 268);
            this.dgvList.TabIndex = 0;
            this.dgvList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvList_UserDeletingRow);
            this.dgvList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvList_CellValidating);
            this.dgvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellEndEdit);
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // clMaVach
            // 
            this.clMaVach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clMaVach.DataPropertyName = "MaVach";
            this.clMaVach.HeaderText = "Mã vạch";
            this.clMaVach.MinimumWidth = 150;
            this.clMaVach.Name = "clMaVach";
            this.clMaVach.ReadOnly = true;
            // 
            // clDonViTinh
            // 
            this.clDonViTinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clDonViTinh.DataPropertyName = "TenDonViTinh";
            this.clDonViTinh.HeaderText = "Đơn vị tính";
            this.clDonViTinh.MinimumWidth = 100;
            this.clDonViTinh.Name = "clDonViTinh";
            this.clDonViTinh.ReadOnly = true;
            this.clDonViTinh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clSoLuong
            // 
            this.clSoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 100;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clDonGia
            // 
            this.clDonGia.DataPropertyName = "DonGia";
            this.clDonGia.HeaderText = "Đơn giá";
            this.clDonGia.MinimumWidth = 100;
            this.clDonGia.Name = "clDonGia";
            this.clDonGia.ReadOnly = true;
            this.clDonGia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clThanhTien
            // 
            this.clThanhTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clThanhTien.DataPropertyName = "ThanhTien";
            this.clThanhTien.HeaderText = "Thành tiền";
            this.clThanhTien.MinimumWidth = 100;
            this.clThanhTien.Name = "clThanhTien";
            this.clThanhTien.ReadOnly = true;
            this.clThanhTien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clidsanpham
            // 
            this.clidsanpham.DataPropertyName = "IdSanPham";
            this.clidsanpham.HeaderText = "idsanpham";
            this.clidsanpham.Name = "clidsanpham";
            this.clidsanpham.ReadOnly = true;
            this.clidsanpham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clidsanpham.Visible = false;
            // 
            // cltensanpham
            // 
            this.cltensanpham.DataPropertyName = "TenSanPham";
            this.cltensanpham.HeaderText = "tensanpham";
            this.cltensanpham.Name = "cltensanpham";
            this.cltensanpham.ReadOnly = true;
            this.cltensanpham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cltensanpham.Visible = false;
            // 
            // clmasanpham
            // 
            this.clmasanpham.DataPropertyName = "MaSanPham";
            this.clmasanpham.HeaderText = "masanpham";
            this.clmasanpham.Name = "clmasanpham";
            this.clmasanpham.ReadOnly = true;
            this.clmasanpham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmasanpham.Visible = false;
            // 
            // lblthanhtien
            // 
            this.lblthanhtien.Location = new System.Drawing.Point(252, 286);
            this.lblthanhtien.Name = "lblthanhtien";
            this.lblthanhtien.Size = new System.Drawing.Size(6, 13);
            this.lblthanhtien.TabIndex = 4;
            this.lblthanhtien.Text = "0";
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.Location = new System.Drawing.Point(85, 286);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(6, 13);
            this.lblTongSoLuong.TabIndex = 2;
            this.lblTongSoLuong.Text = "0";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(163, 286);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(83, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tổng thành tiền :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 286);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tổng số lượng :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDong);
            this.groupBox3.Controls.Add(this.btnGhi);
            this.groupBox3.Location = new System.Drawing.Point(2, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(654, 46);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(329, 14);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.Escape;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.Image")));
            this.btnGhi.Location = new System.Drawing.Point(228, 14);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnGhi.Size = new System.Drawing.Size(95, 25);
            this.btnGhi.TabIndex = 0;
            this.btnGhi.Text = "Cập nhật(F2)";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // frmChungTuNhap_ChiTietHangHoaBase
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChungTuNhap_ChiTietHangHoaBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hàng hóa";
            this.Load += new System.EventHandler(this.frmChungTuNhap_ChiTietHangHoa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChungTuNhap_ChiTietHangHoaBase_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMa;
        protected System.Windows.Forms.Label lblSoLuongTon;
        protected System.Windows.Forms.Label lblSL;
        protected DevExpress.XtraEditors.LabelControl lblthanhtien;
        protected DevExpress.XtraEditors.LabelControl lblTongSoLuong;
        public QLBH.Core.Form.GtidButton btnThem;
        public QLBH.Core.Form.GtidTextBox txtMaVach;
        protected System.Windows.Forms.Label lblTieuDe;
        protected System.Windows.Forms.Label label7;
        protected DevExpress.XtraEditors.LabelControl labelControl2;
        protected DevExpress.XtraEditors.LabelControl labelControl1;
        private QLBH.Core.Form.GtidSimpleButton btnDong;
        protected QLBH.Core.Form.GtidSimpleButton btnXoaDong;
        public QLBH.Core.Form.GtidSimpleButton btnGhi;
        public System.Windows.Forms.GroupBox groupBox1;
        public QLBH.Core.Form.GtidDataGridView dgvList;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaVach;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn clThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clidsanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltensanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmasanpham;
    }
}