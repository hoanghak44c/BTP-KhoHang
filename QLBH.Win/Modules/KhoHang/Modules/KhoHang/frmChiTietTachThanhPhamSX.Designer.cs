namespace QLBanHang.Modules.KhoHang
{
    partial class frmChiTietTachThanhPhamSX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietTachThanhPhamSX));
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnNhap = new QLBH.Core.Form.GtidSimpleButton();
            this.txtSoLuongDN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuongYC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaLenh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaThanhPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new QLBH.Core.Form.GtidDataGridView();
            this.clCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaVachLK = new System.Windows.Forms.TextBox();
            this.btnThem = new QLBH.Core.Form.GtidSimpleButton();
            this.dtNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(695, 507);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 29;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnNhap.Image")));
            this.btnNhap.Location = new System.Drawing.Point(7, 507);
            this.btnNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnNhap.Size = new System.Drawing.Size(159, 25);
            this.btnNhap.TabIndex = 28;
            this.btnNhap.Text = "Xác nhận đã nhập kho(F2)";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // txtSoLuongDN
            // 
            this.txtSoLuongDN.Enabled = false;
            this.txtSoLuongDN.Location = new System.Drawing.Point(339, 83);
            this.txtSoLuongDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongDN.Name = "txtSoLuongDN";
            this.txtSoLuongDN.Size = new System.Drawing.Size(114, 21);
            this.txtSoLuongDN.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Số lượng đã tách";
            // 
            // txtSoLuongYC
            // 
            this.txtSoLuongYC.Enabled = false;
            this.txtSoLuongYC.Location = new System.Drawing.Point(122, 83);
            this.txtSoLuongYC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongYC.Name = "txtSoLuongYC";
            this.txtSoLuongYC.Size = new System.Drawing.Size(114, 21);
            this.txtSoLuongYC.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Số lượng cần tách";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Enabled = false;
            this.txtTenSP.Location = new System.Drawing.Point(466, 58);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(318, 21);
            this.txtTenSP.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(373, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tên Thành phẩm";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Enabled = false;
            this.txtMaSP.Location = new System.Drawing.Point(122, 58);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(245, 21);
            this.txtMaSP.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mã Thành phẩm";
            // 
            // txtMaLenh
            // 
            this.txtMaLenh.Enabled = false;
            this.txtMaLenh.Location = new System.Drawing.Point(122, 33);
            this.txtMaLenh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLenh.Name = "txtMaLenh";
            this.txtMaLenh.Size = new System.Drawing.Size(501, 21);
            this.txtMaLenh.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mã lệnh sản xuất";
            // 
            // txtMaThanhPham
            // 
            this.txtMaThanhPham.Location = new System.Drawing.Point(122, 8);
            this.txtMaThanhPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaThanhPham.Name = "txtMaThanhPham";
            this.txtMaThanhPham.Size = new System.Drawing.Size(501, 21);
            this.txtMaThanhPham.TabIndex = 22;
            this.txtMaThanhPham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaThanhPham_KeyDown);
            this.txtMaThanhPham.Leave += new System.EventHandler(this.txtMaThanhPham_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã vạch thành phẩm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvChiTiet);
            this.groupBox1.Location = new System.Drawing.Point(7, 177);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(783, 321);
            this.groupBox1.TabIndex = 15;
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
            this.clCheck,
            this.clMa,
            this.clTen,
            this.clDVT,
            this.clSoLuong,
            this.clMaVach});
            this.dgvChiTiet.Location = new System.Drawing.Point(5, 17);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(772, 300);
            this.dgvChiTiet.TabIndex = 4;
            // 
            // clCheck
            // 
            this.clCheck.DataPropertyName = "Check";
            this.clCheck.HeaderText = "";
            this.clCheck.MinimumWidth = 100;
            this.clCheck.Name = "clCheck";
            this.clCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clMa
            // 
            this.clMa.DataPropertyName = "MaSanPham";
            this.clMa.HeaderText = "Mã linh kiện";
            this.clMa.MinimumWidth = 200;
            this.clMa.Name = "clMa";
            this.clMa.ReadOnly = true;
            this.clMa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMa.Width = 200;
            // 
            // clTen
            // 
            this.clTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clTen.DataPropertyName = "TenSanPham";
            this.clTen.HeaderText = "Tên linh kiện";
            this.clTen.MinimumWidth = 300;
            this.clTen.Name = "clTen";
            this.clTen.ReadOnly = true;
            this.clTen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clDVT
            // 
            this.clDVT.DataPropertyName = "DonViTinh";
            this.clDVT.HeaderText = "Đơn vị tính";
            this.clDVT.MinimumWidth = 120;
            this.clDVT.Name = "clDVT";
            this.clDVT.ReadOnly = true;
            this.clDVT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDVT.Width = 120;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 120;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clSoLuong.Width = 120;
            // 
            // clMaVach
            // 
            this.clMaVach.DataPropertyName = "MaVach";
            this.clMaVach.HeaderText = "Mã vạch";
            this.clMaVach.MinimumWidth = 250;
            this.clMaVach.Name = "clMaVach";
            this.clMaVach.ReadOnly = true;
            this.clMaVach.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMaVach.Width = 300;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Mã linh kiện";
            // 
            // txtMaVachLK
            // 
            this.txtMaVachLK.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVachLK.Location = new System.Drawing.Point(138, 118);
            this.txtMaVachLK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaVachLK.Name = "txtMaVachLK";
            this.txtMaVachLK.Size = new System.Drawing.Size(485, 46);
            this.txtMaVachLK.TabIndex = 26;
            this.txtMaVachLK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaVachLK_KeyDown);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(651, 132);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnThem.Size = new System.Drawing.Size(95, 25);
            this.btnThem.TabIndex = 29;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = null;
            this.dtNgayLap.Location = new System.Drawing.Point(521, 84);
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
            this.dtNgayLap.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(459, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Ngày lập :";
            // 
            // frmChiTietTachThanhPhamSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(797, 540);
            this.Controls.Add(this.dtNgayLap);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.txtSoLuongDN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaVachLK);
            this.Controls.Add(this.label7);
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
            this.Name = "frmChiTietTachThanhPhamSX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết tách thành phẩm sản xuất";
            this.Load += new System.EventHandler(this.frmChiTietTachThanhPhamSX_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiTietTachThanhPhamSX_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected QLBH.Core.Form.GtidSimpleButton btnDong;
        protected QLBH.Core.Form.GtidSimpleButton btnNhap;
        public System.Windows.Forms.TextBox txtSoLuongDN;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtSoLuongYC;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtMaLenh;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMaThanhPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        protected QLBH.Core.Form.GtidDataGridView dgvChiTiet;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtMaVachLK;
        protected QLBH.Core.Form.GtidSimpleButton btnThem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaVach;
        private DevExpress.XtraEditors.DateEdit dtNgayLap;
        private System.Windows.Forms.Label label8;
    }
}