namespace QLBanHang.Modules.KhoHang
{
    partial class frmChiTietXacNhanNhapThanhPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietXacNhanNhapThanhPham));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new QLBH.Core.Form.GtidDataGridView();
            this.clMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clLoaiLinhKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuongYC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaThanhPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaLenh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuongYC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuongDN = new System.Windows.Forms.TextBox();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnNhap = new QLBH.Core.Form.GtidSimpleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.dtNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvChiTiet);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(783, 390);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Các linh kiện";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToResizeColumns = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMa,
            this.clLoaiLinhKien,
            this.clDVT,
            this.clSoLuongYC,
            this.clMaVach});
            this.dgvChiTiet.Location = new System.Drawing.Point(5, 17);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(772, 369);
            this.dgvChiTiet.TabIndex = 4;
            // 
            // clMa
            // 
            this.clMa.DataPropertyName = "MaSanPham";
            this.clMa.HeaderText = "Mã linh kiện";
            this.clMa.MinimumWidth = 150;
            this.clMa.Name = "clMa";
            this.clMa.ReadOnly = true;
            this.clMa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMa.Width = 150;
            // 
            // clLoaiLinhKien
            // 
            this.clLoaiLinhKien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clLoaiLinhKien.DataPropertyName = "TenSanPham";
            this.clLoaiLinhKien.HeaderText = "Tên linh kiện";
            this.clLoaiLinhKien.MinimumWidth = 200;
            this.clLoaiLinhKien.Name = "clLoaiLinhKien";
            this.clLoaiLinhKien.ReadOnly = true;
            this.clLoaiLinhKien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clDVT
            // 
            this.clDVT.DataPropertyName = "TenDonViTinh";
            this.clDVT.HeaderText = "Đơn vị tính";
            this.clDVT.MinimumWidth = 100;
            this.clDVT.Name = "clDVT";
            this.clDVT.ReadOnly = true;
            this.clDVT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clSoLuongYC
            // 
            this.clSoLuongYC.DataPropertyName = "SoLuong";
            this.clSoLuongYC.HeaderText = "Số lượng yêu cầu";
            this.clSoLuongYC.MinimumWidth = 150;
            this.clSoLuongYC.Name = "clSoLuongYC";
            this.clSoLuongYC.ReadOnly = true;
            this.clSoLuongYC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clSoLuongYC.Width = 150;
            // 
            // clMaVach
            // 
            this.clMaVach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.clMaVach.DataPropertyName = "MaVach";
            this.clMaVach.HeaderText = "Mã vạch";
            this.clMaVach.MinimumWidth = 300;
            this.clMaVach.Name = "clMaVach";
            this.clMaVach.ReadOnly = true;
            this.clMaVach.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMaVach.Width = 300;
            // 
            // txtMaThanhPham
            // 
            this.txtMaThanhPham.Location = new System.Drawing.Point(127, 15);
            this.txtMaThanhPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaThanhPham.Name = "txtMaThanhPham";
            this.txtMaThanhPham.Size = new System.Drawing.Size(501, 21);
            this.txtMaThanhPham.TabIndex = 12;
            this.txtMaThanhPham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaThanhPham_KeyDown);
            this.txtMaThanhPham.Leave += new System.EventHandler(this.txtMaThanhPham_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã vạch thành phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã lệnh sản xuất";
            // 
            // txtMaLenh
            // 
            this.txtMaLenh.Enabled = false;
            this.txtMaLenh.Location = new System.Drawing.Point(127, 40);
            this.txtMaLenh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLenh.Name = "txtMaLenh";
            this.txtMaLenh.Size = new System.Drawing.Size(501, 21);
            this.txtMaLenh.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mã Thành phẩm";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Enabled = false;
            this.txtMaSP.Location = new System.Drawing.Point(127, 65);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(245, 21);
            this.txtMaSP.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số lượng sản xuất";
            // 
            // txtSoLuongYC
            // 
            this.txtSoLuongYC.Enabled = false;
            this.txtSoLuongYC.Location = new System.Drawing.Point(127, 90);
            this.txtSoLuongYC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongYC.Name = "txtSoLuongYC";
            this.txtSoLuongYC.Size = new System.Drawing.Size(114, 21);
            this.txtSoLuongYC.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số lượng đã nhập";
            // 
            // txtSoLuongDN
            // 
            this.txtSoLuongDN.Enabled = false;
            this.txtSoLuongDN.Location = new System.Drawing.Point(344, 90);
            this.txtSoLuongDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongDN.Name = "txtSoLuongDN";
            this.txtSoLuongDN.Size = new System.Drawing.Size(114, 21);
            this.txtSoLuongDN.TabIndex = 12;
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(700, 514);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnNhap.Image")));
            this.btnNhap.Location = new System.Drawing.Point(12, 514);
            this.btnNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnNhap.Size = new System.Drawing.Size(152, 25);
            this.btnNhap.TabIndex = 13;
            this.btnNhap.Text = "Xác nhận đã nhập kho";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(378, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tên Thành phẩm";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Enabled = false;
            this.txtTenSP.Location = new System.Drawing.Point(471, 65);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(318, 21);
            this.txtTenSP.TabIndex = 12;
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(((long)(0)));
            this.dtNgayLap.Location = new System.Drawing.Point(526, 91);
            this.dtNgayLap.Name = "dtNgayLap";
            this.dtNgayLap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(263, 20);
            this.dtNgayLap.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(464, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Ngày lập :";
            // 
            // frmChiTietXacNhanNhapThanhPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(807, 550);
            this.Controls.Add(this.dtNgayLap);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.txtSoLuongDN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoLuongYC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaLenh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaThanhPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietXacNhanNhapThanhPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết xác nhận nhập thành phẩm";
            this.Load += new System.EventHandler(this.frmChiTietXacNhanNhapThanhPham_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiTietXacNhanNhapThanhPham_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        protected QLBH.Core.Form.GtidDataGridView dgvChiTiet;
        public System.Windows.Forms.TextBox txtMaThanhPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMaLenh;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSoLuongYC;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtSoLuongDN;
        protected QLBH.Core.Form.GtidSimpleButton btnDong;
        protected QLBH.Core.Form.GtidSimpleButton btnNhap;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLoaiLinhKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoLuongYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaVach;
        private DevExpress.XtraEditors.DateEdit dtNgayLap;
        private System.Windows.Forms.Label label8;
    }
}