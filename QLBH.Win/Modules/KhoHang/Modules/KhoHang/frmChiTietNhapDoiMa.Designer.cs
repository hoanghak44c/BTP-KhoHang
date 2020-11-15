namespace QLBanHang.Modules.KhoHang
{
    partial class frmChiTietNhapDoiMa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietNhapDoiMa));
            this.dtNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaVachTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.txtMaVach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenThanhPham = new System.Windows.Forms.TextBox();
            this.txtSoLuongCT = new System.Windows.Forms.TextBox();
            this.txtSoLuongYC = new System.Windows.Forms.TextBox();
            this.txtMaThanhPham = new System.Windows.Forms.TextBox();
            this.txtMaLenh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXacNhan = new QLBH.Core.Form.GtidSimpleButton();
            this.dgvMaVach = new QLBH.Core.Form.GtidDataGridView();
            this.clMaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new QLBH.Core.Form.GtidSimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnNhap = new QLBH.Core.Form.GtidSimpleButton();
            this.dgvChiTiet = new QLBH.Core.Form.GtidDataGridView();
            this.clMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSLYC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSLDQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaVach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(((long)(0)));
            this.dtNgayLap.Location = new System.Drawing.Point(510, 59);
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
            this.dtNgayLap.Size = new System.Drawing.Size(289, 20);
            this.dtNgayLap.TabIndex = 28;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMaVachTP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.dgvMaVach);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.txtMaVach);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(13, 290);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(796, 237);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mã vạch linh kiện";
            // 
            // txtMaVachTP
            // 
            this.txtMaVachTP.Location = new System.Drawing.Point(126, 212);
            this.txtMaVachTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaVachTP.Name = "txtMaVachTP";
            this.txtMaVachTP.Size = new System.Drawing.Size(399, 21);
            this.txtMaVachTP.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Mã vạch thành phẩm :";
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(766, 208);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(25, 25);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtMaVach
            // 
            this.txtMaVach.Location = new System.Drawing.Point(64, 22);
            this.txtMaVach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.Size = new System.Drawing.Size(624, 21);
            this.txtMaVach.TabIndex = 8;
            this.txtMaVach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaVach_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Mã vạch ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvChiTiet);
            this.groupBox1.Location = new System.Drawing.Point(8, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(796, 188);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linh kiện sản xuất";
            // 
            // txtTenThanhPham
            // 
            this.txtTenThanhPham.Enabled = false;
            this.txtTenThanhPham.Location = new System.Drawing.Point(510, 33);
            this.txtTenThanhPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenThanhPham.Name = "txtTenThanhPham";
            this.txtTenThanhPham.Size = new System.Drawing.Size(289, 21);
            this.txtTenThanhPham.TabIndex = 21;
            // 
            // txtSoLuongCT
            // 
            this.txtSoLuongCT.Enabled = false;
            this.txtSoLuongCT.Location = new System.Drawing.Point(345, 58);
            this.txtSoLuongCT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongCT.Name = "txtSoLuongCT";
            this.txtSoLuongCT.Size = new System.Drawing.Size(88, 21);
            this.txtSoLuongCT.TabIndex = 22;
            // 
            // txtSoLuongYC
            // 
            this.txtSoLuongYC.Enabled = false;
            this.txtSoLuongYC.Location = new System.Drawing.Point(139, 58);
            this.txtSoLuongYC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongYC.Name = "txtSoLuongYC";
            this.txtSoLuongYC.Size = new System.Drawing.Size(88, 21);
            this.txtSoLuongYC.TabIndex = 23;
            // 
            // txtMaThanhPham
            // 
            this.txtMaThanhPham.Enabled = false;
            this.txtMaThanhPham.Location = new System.Drawing.Point(113, 33);
            this.txtMaThanhPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaThanhPham.Name = "txtMaThanhPham";
            this.txtMaThanhPham.Size = new System.Drawing.Size(289, 21);
            this.txtMaThanhPham.TabIndex = 19;
            // 
            // txtMaLenh
            // 
            this.txtMaLenh.Enabled = false;
            this.txtMaLenh.Location = new System.Drawing.Point(113, 8);
            this.txtMaLenh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLenh.Name = "txtMaLenh";
            this.txtMaLenh.Size = new System.Drawing.Size(289, 21);
            this.txtMaLenh.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(439, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Ngày lập :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Số lượng đã chi tiết :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên thành phẩm :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Tổng số lượng yêu cầu :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mã thành phẩm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mã lệnh sản xuất :";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(113, 531);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXacNhan.Size = new System.Drawing.Size(101, 25);
            this.btnXacNhan.TabIndex = 29;
            this.btnXacNhan.Text = "Import Mã";
            this.btnXacNhan.Visible = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // dgvMaVach
            // 
            this.dgvMaVach.AllowUserToResizeColumns = false;
            this.dgvMaVach.AllowUserToResizeRows = false;
            this.dgvMaVach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMaVach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaVach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaVach,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.clSoLuong});
            this.dgvMaVach.Location = new System.Drawing.Point(5, 45);
            this.dgvMaVach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMaVach.Name = "dgvMaVach";
            this.dgvMaVach.RowHeadersVisible = false;
            this.dgvMaVach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaVach.Size = new System.Drawing.Size(786, 158);
            this.dgvMaVach.TabIndex = 4;
            // 
            // clMaVach
            // 
            this.clMaVach.DataPropertyName = "MaVach";
            this.clMaVach.HeaderText = "Mã vạch";
            this.clMaVach.MinimumWidth = 200;
            this.clMaVach.Name = "clMaVach";
            this.clMaVach.ReadOnly = true;
            this.clMaVach.Width = 200;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaSanPham";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã linh kiện";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenSanPham";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên linh kiện";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 350;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 350;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TenDonViTinh";
            this.dataGridViewTextBoxColumn3.HeaderText = "Đơn vị tính";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 80;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(693, 19);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnThem.Size = new System.Drawing.Size(95, 25);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(714, 531);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 25;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnNhap.Image")));
            this.btnNhap.Location = new System.Drawing.Point(11, 531);
            this.btnNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnNhap.Size = new System.Drawing.Size(95, 25);
            this.btnNhap.TabIndex = 26;
            this.btnNhap.Text = "Nhập tiếp";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            this.btnNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNhap_KeyDown);
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToResizeColumns = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMa,
            this.clTen,
            this.clDVT,
            this.clSLYC,
            this.clSLDQ});
            this.dgvChiTiet.Location = new System.Drawing.Point(5, 13);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(786, 162);
            this.dgvChiTiet.TabIndex = 5;
            // 
            // clMa
            // 
            this.clMa.DataPropertyName = "MaLinhKien";
            this.clMa.HeaderText = "Mã linh kiện";
            this.clMa.MinimumWidth = 200;
            this.clMa.Name = "clMa";
            this.clMa.Width = 200;
            // 
            // clTen
            // 
            this.clTen.DataPropertyName = "TenLinhKien";
            this.clTen.HeaderText = "Tên linh kiện";
            this.clTen.MinimumWidth = 350;
            this.clTen.Name = "clTen";
            this.clTen.Width = 350;
            // 
            // clDVT
            // 
            this.clDVT.DataPropertyName = "DonViTinh";
            this.clDVT.HeaderText = "Đơn vị tính";
            this.clDVT.MinimumWidth = 150;
            this.clDVT.Name = "clDVT";
            this.clDVT.Width = 150;
            // 
            // clSLYC
            // 
            this.clSLYC.DataPropertyName = "SoLuongTrenTPham";
            this.clSLYC.HeaderText = "SL yêu cầu";
            this.clSLYC.MinimumWidth = 80;
            this.clSLYC.Name = "clSLYC";
            this.clSLYC.ReadOnly = true;
            // 
            // clSLDQ
            // 
            this.clSLDQ.DataPropertyName = "SoLuongDaQuet";
            this.clSLDQ.HeaderText = "SL đã quét";
            this.clSLDQ.MinimumWidth = 80;
            this.clSLDQ.Name = "clSLDQ";
            this.clSLDQ.ReadOnly = true;
            // 
            // frmChiTietNhapDoiMa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 564);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.dtNgayLap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTenThanhPham);
            this.Controls.Add(this.txtSoLuongCT);
            this.Controls.Add(this.txtSoLuongYC);
            this.Controls.Add(this.txtMaThanhPham);
            this.Controls.Add(this.txtMaLenh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmChiTietNhapDoiMa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmChiTietNhapDoiMa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiTietNhapDoiMa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaVach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtNgayLap;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtMaVachTP;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        protected QLBH.Core.Form.GtidDataGridView dgvMaVach;
        protected QLBH.Core.Form.GtidSimpleButton btnThem;
        public System.Windows.Forms.TextBox txtMaVach;
        private System.Windows.Forms.Label label7;
        protected QLBH.Core.Form.GtidSimpleButton btnDong;
        protected QLBH.Core.Form.GtidSimpleButton btnNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtTenThanhPham;
        public System.Windows.Forms.TextBox txtSoLuongCT;
        public System.Windows.Forms.TextBox txtSoLuongYC;
        public System.Windows.Forms.TextBox txtMaThanhPham;
        public System.Windows.Forms.TextBox txtMaLenh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        protected QLBH.Core.Form.GtidDataGridView dgvChiTiet;
        protected QLBH.Core.Form.GtidSimpleButton btnXacNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSLYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSLDQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaVach;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoLuong;
    }
}