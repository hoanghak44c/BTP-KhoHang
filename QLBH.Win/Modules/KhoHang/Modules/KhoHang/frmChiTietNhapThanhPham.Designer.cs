namespace QLBanHang.Modules.KhoHang
{
    partial class frmChiTietNhapThanhPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietNhapThanhPham));
            this.txtMaLenh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaThanhPham = new System.Windows.Forms.TextBox();
            this.txtTenThanhPham = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoLuongYC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuongCT = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new QLBH.Core.Form.GtidDataGridView();
            this.colMaLinhKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLinhKien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongYC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSLCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNhap = new QLBH.Core.Form.GtidSimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaVachTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.dgvMaVach = new QLBH.Core.Form.GtidDataGridView();
            this.colMaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new QLBH.Core.Form.GtidSimpleButton();
            this.txtMaVach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.btnInPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaVach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaLenh
            // 
            this.txtMaLenh.Enabled = false;
            this.txtMaLenh.Location = new System.Drawing.Point(115, 5);
            this.txtMaLenh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLenh.Name = "txtMaLenh";
            this.txtMaLenh.Size = new System.Drawing.Size(289, 21);
            this.txtMaLenh.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã lệnh sản xuất :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(409, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã thành phẩm :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên thành phẩm :";
            // 
            // txtMaThanhPham
            // 
            this.txtMaThanhPham.Enabled = false;
            this.txtMaThanhPham.Location = new System.Drawing.Point(514, 6);
            this.txtMaThanhPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaThanhPham.Name = "txtMaThanhPham";
            this.txtMaThanhPham.Size = new System.Drawing.Size(289, 21);
            this.txtMaThanhPham.TabIndex = 8;
            // 
            // txtTenThanhPham
            // 
            this.txtTenThanhPham.Enabled = false;
            this.txtTenThanhPham.Location = new System.Drawing.Point(115, 30);
            this.txtTenThanhPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenThanhPham.Name = "txtTenThanhPham";
            this.txtTenThanhPham.Size = new System.Drawing.Size(688, 21);
            this.txtTenThanhPham.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số lượng yêu cầu :";
            // 
            // txtSoLuongYC
            // 
            this.txtSoLuongYC.Enabled = false;
            this.txtSoLuongYC.Location = new System.Drawing.Point(115, 55);
            this.txtSoLuongYC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongYC.Name = "txtSoLuongYC";
            this.txtSoLuongYC.Size = new System.Drawing.Size(114, 21);
            this.txtSoLuongYC.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số lượng đã chi tiết :";
            // 
            // txtSoLuongCT
            // 
            this.txtSoLuongCT.Enabled = false;
            this.txtSoLuongCT.Location = new System.Drawing.Point(347, 55);
            this.txtSoLuongCT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoLuongCT.Name = "txtSoLuongCT";
            this.txtSoLuongCT.Size = new System.Drawing.Size(88, 21);
            this.txtSoLuongCT.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvChiTiet);
            this.groupBox1.Location = new System.Drawing.Point(10, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(796, 188);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linh kiện sản xuất";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToResizeColumns = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLinhKien,
            this.colTenLinhKien,
            this.colDVT,
            this.colSoLuongYC,
            this.colSLCT});
            this.dgvChiTiet.Location = new System.Drawing.Point(5, 17);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(786, 162);
            this.dgvChiTiet.TabIndex = 4;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // colMaLinhKien
            // 
            this.colMaLinhKien.DataPropertyName = "MaLinhKien";
            this.colMaLinhKien.HeaderText = "Mã linh kiện";
            this.colMaLinhKien.MinimumWidth = 200;
            this.colMaLinhKien.Name = "colMaLinhKien";
            this.colMaLinhKien.ReadOnly = true;
            this.colMaLinhKien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMaLinhKien.Width = 200;
            // 
            // colTenLinhKien
            // 
            this.colTenLinhKien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenLinhKien.DataPropertyName = "TenLinhKien";
            this.colTenLinhKien.HeaderText = "Tên linh kiện";
            this.colTenLinhKien.MinimumWidth = 350;
            this.colTenLinhKien.Name = "colTenLinhKien";
            this.colTenLinhKien.ReadOnly = true;
            this.colTenLinhKien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colDVT
            // 
            this.colDVT.DataPropertyName = "DonViTinh";
            this.colDVT.HeaderText = "Đơn vị tính";
            this.colDVT.MinimumWidth = 150;
            this.colDVT.Name = "colDVT";
            this.colDVT.ReadOnly = true;
            this.colDVT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDVT.Width = 150;
            // 
            // colSoLuongYC
            // 
            this.colSoLuongYC.DataPropertyName = "SoLuongTrenTPham";
            this.colSoLuongYC.HeaderText = "SL Yêu cầu";
            this.colSoLuongYC.MinimumWidth = 80;
            this.colSoLuongYC.Name = "colSoLuongYC";
            this.colSoLuongYC.ReadOnly = true;
            this.colSoLuongYC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colSLCT
            // 
            this.colSLCT.DataPropertyName = "SoLuongDaQuet";
            this.colSLCT.HeaderText = "SL Đã quét";
            this.colSLCT.MinimumWidth = 80;
            this.colSLCT.Name = "colSLCT";
            this.colSLCT.ReadOnly = true;
            this.colSLCT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnNhap
            // 
            this.btnNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnNhap.Image")));
            this.btnNhap.Location = new System.Drawing.Point(13, 528);
            this.btnNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnNhap.Size = new System.Drawing.Size(95, 25);
            this.btnNhap.TabIndex = 10;
            this.btnNhap.Text = "Nhập tiếp";
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            this.btnNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnNhap_KeyDown);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(716, 528);
            this.btnDong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(15, 287);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(796, 237);
            this.groupBox2.TabIndex = 11;
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
            // dgvMaVach
            // 
            this.dgvMaVach.AllowUserToResizeColumns = false;
            this.dgvMaVach.AllowUserToResizeRows = false;
            this.dgvMaVach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMaVach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaVach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaVach,
            this.colMaLK,
            this.colTenLK,
            this.colDonViTinh,
            this.colSoLuong});
            this.dgvMaVach.Location = new System.Drawing.Point(5, 45);
            this.dgvMaVach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMaVach.Name = "dgvMaVach";
            this.dgvMaVach.RowHeadersVisible = false;
            this.dgvMaVach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaVach.Size = new System.Drawing.Size(786, 158);
            this.dgvMaVach.TabIndex = 4;
            // 
            // colMaVach
            // 
            this.colMaVach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaVach.DataPropertyName = "MaVach";
            this.colMaVach.HeaderText = "Mã vạch";
            this.colMaVach.MinimumWidth = 250;
            this.colMaVach.Name = "colMaVach";
            this.colMaVach.ReadOnly = true;
            this.colMaVach.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMaLK
            // 
            this.colMaLK.DataPropertyName = "MaSanPham";
            this.colMaLK.HeaderText = "Mã linh kiện";
            this.colMaLK.MinimumWidth = 150;
            this.colMaLK.Name = "colMaLK";
            this.colMaLK.ReadOnly = true;
            this.colMaLK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMaLK.Width = 150;
            // 
            // colTenLK
            // 
            this.colTenLK.DataPropertyName = "TenSanPham";
            this.colTenLK.HeaderText = "Tên linh kiện";
            this.colTenLK.MinimumWidth = 250;
            this.colTenLK.Name = "colTenLK";
            this.colTenLK.ReadOnly = true;
            this.colTenLK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTenLK.Width = 250;
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.DataPropertyName = "TenDonViTinh";
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.MinimumWidth = 150;
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            this.colDonViTinh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDonViTinh.Width = 150;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            this.colSoLuong.HeaderText = "Số lượng";
            this.colSoLuong.MinimumWidth = 100;
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(((long)(0)));
            this.dtNgayLap.Location = new System.Drawing.Point(514, 56);
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
            this.dtNgayLap.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(441, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày lập :";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieu.Image")));
            this.btnInPhieu.Location = new System.Drawing.Point(114, 528);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.ShortCutKey = System.Windows.Forms.Keys.F11;
            this.btnInPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnInPhieu.TabIndex = 13;
            this.btnInPhieu.Text = "In phiếu(F11)";
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // frmChiTietNhapThanhPham
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(817, 564);
            this.Controls.Add(this.btnInPhieu);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietNhapThanhPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất linh kiện sản xuất";
            this.Load += new System.EventHandler(this.frmChiTietNhapThanhPham_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiTietNhapThanhPham_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaVach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtMaLenh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtMaThanhPham;
        public System.Windows.Forms.TextBox txtTenThanhPham;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSoLuongYC;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtSoLuongCT;
        private System.Windows.Forms.GroupBox groupBox1;
        protected QLBH.Core.Form.GtidDataGridView dgvChiTiet;
        protected QLBH.Core.Form.GtidSimpleButton btnNhap;
        protected QLBH.Core.Form.GtidSimpleButton btnDong;
        private System.Windows.Forms.GroupBox groupBox2;
        protected QLBH.Core.Form.GtidDataGridView dgvMaVach;
        protected QLBH.Core.Form.GtidSimpleButton btnThem;
        public System.Windows.Forms.TextBox txtMaVach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaVach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        public System.Windows.Forms.TextBox txtMaVachTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLinhKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLinhKien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSLCT;
        private DevExpress.XtraEditors.DateEdit dtNgayLap;
        private System.Windows.Forms.Label label8;
        public QLBH.Core.Form.GtidSimpleButton btnInPhieu;
    }
}