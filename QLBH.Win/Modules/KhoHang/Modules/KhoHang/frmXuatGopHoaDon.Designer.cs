using QLBH.Core.Form;
namespace QLBanHang.Forms
{
    partial class frmXuatGopHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatGopHoaDon));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoPhieu = new GtidTextBox();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.txtMaVach = new GtidTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new GtidTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoOrderKH = new GtidTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSanPham = new GtidTextBox();
            this.lblThuocXuat = new System.Windows.Forms.Label();
            this.cboKhoXuat = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.mstDenNgay = new System.Windows.Forms.DateTimePicker();
            this.mstTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.grpKetQuaTimKiem = new System.Windows.Forms.GroupBox();
            this.tbllaypalLuoiHienThi = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPhieuXuat = new System.Windows.Forms.DataGridView();
            this.grpThucThi = new System.Windows.Forms.GroupBox();
            this.btnDong = new GtidButton();
            this.btnTim = new GtidButton();
            this.btnCapNhat = new GtidButton();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMaNhanVien = new GtidTextBox();
            this.SoTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPhieuXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoOrderKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieuXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.grpKetQuaTimKiem.SuspendLayout();
            this.tbllaypalLuoiHienThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).BeginInit();
            this.grpThucThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboNhanVien);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtMaNhanVien);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.lblSoPhieu);
            this.groupBox1.Controls.Add(this.txtMaVach);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtTenSanPham);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoOrderKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaSanPham);
            this.groupBox1.Controls.Add(this.lblThuocXuat);
            this.groupBox1.Controls.Add(this.cboKhoXuat);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.mstDenNgay);
            this.groupBox1.Controls.Add(this.mstTuNgay);
            this.groupBox1.Controls.Add(this.lblTuNgay);
            this.groupBox1.Controls.Add(this.lblDenNgay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(10, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(862, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu thức tìm kiếm";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhieu.Location = new System.Drawing.Point(292, 19);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(162, 20);
            this.txtSoPhieu.TabIndex = 5;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoPhieu.Location = new System.Drawing.Point(220, 24);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(72, 13);
            this.lblSoPhieu.TabIndex = 4;
            this.lblSoPhieu.Text = "Số phiếu xuất";
            // 
            // txtMaVach
            // 
            this.txtMaVach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVach.Location = new System.Drawing.Point(292, 77);
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.Size = new System.Drawing.Size(162, 20);
            this.txtMaVach.TabIndex = 106;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(231, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Mã vạch";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanPham.Location = new System.Drawing.Point(93, 105);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(361, 20);
            this.txtTenSanPham.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Tên sản phẩm";
            // 
            // txtSoOrderKH
            // 
            this.txtSoOrderKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoOrderKH.Location = new System.Drawing.Point(93, 19);
            this.txtSoOrderKH.Name = "txtSoOrderKH";
            this.txtSoOrderKH.Size = new System.Drawing.Size(124, 20);
            this.txtSoOrderKH.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Số Order";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSanPham.Location = new System.Drawing.Point(93, 77);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(126, 20);
            this.txtMaSanPham.TabIndex = 7;
            // 
            // lblThuocXuat
            // 
            this.lblThuocXuat.AutoSize = true;
            this.lblThuocXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuocXuat.Location = new System.Drawing.Point(12, 79);
            this.lblThuocXuat.Name = "lblThuocXuat";
            this.lblThuocXuat.Size = new System.Drawing.Size(71, 13);
            this.lblThuocXuat.TabIndex = 0;
            this.lblThuocXuat.Text = "Mã sản phẩm";
            // 
            // cboKhoXuat
            // 
            this.cboKhoXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoXuat.Enabled = false;
            this.cboKhoXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboKhoXuat.FormattingEnabled = true;
            this.cboKhoXuat.Location = new System.Drawing.Point(93, 47);
            this.cboKhoXuat.Name = "cboKhoXuat";
            this.cboKhoXuat.Size = new System.Drawing.Size(361, 21);
            this.cboKhoXuat.TabIndex = 92;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 91;
            this.label17.Text = "Kho xuất";
            // 
            // mstDenNgay
            // 
            this.mstDenNgay.CustomFormat = "dd/MM/yyyy";
            this.mstDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mstDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mstDenNgay.Location = new System.Drawing.Point(741, 19);
            this.mstDenNgay.Name = "mstDenNgay";
            this.mstDenNgay.Size = new System.Drawing.Size(109, 20);
            this.mstDenNgay.TabIndex = 18;
            // 
            // mstTuNgay
            // 
            this.mstTuNgay.CustomFormat = "dd/MM/yyyy";
            this.mstTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mstTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mstTuNgay.Location = new System.Drawing.Point(556, 19);
            this.mstTuNgay.Name = "mstTuNgay";
            this.mstTuNgay.Size = new System.Drawing.Size(106, 20);
            this.mstTuNgay.TabIndex = 17;
            this.mstTuNgay.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(501, 23);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(46, 13);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(680, 23);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(53, 13);
            this.lblDenNgay.TabIndex = 0;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // grpKetQuaTimKiem
            // 
            this.grpKetQuaTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpKetQuaTimKiem.Controls.Add(this.tbllaypalLuoiHienThi);
            this.grpKetQuaTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpKetQuaTimKiem.ForeColor = System.Drawing.Color.Black;
            this.grpKetQuaTimKiem.Location = new System.Drawing.Point(10, 222);
            this.grpKetQuaTimKiem.Name = "grpKetQuaTimKiem";
            this.grpKetQuaTimKiem.Size = new System.Drawing.Size(862, 272);
            this.grpKetQuaTimKiem.TabIndex = 3;
            this.grpKetQuaTimKiem.TabStop = false;
            this.grpKetQuaTimKiem.Text = "Kết quả tìm kiếm";
            // 
            // tbllaypalLuoiHienThi
            // 
            this.tbllaypalLuoiHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbllaypalLuoiHienThi.ColumnCount = 1;
            this.tbllaypalLuoiHienThi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbllaypalLuoiHienThi.Controls.Add(this.dgvPhieuXuat, 0, 0);
            this.tbllaypalLuoiHienThi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbllaypalLuoiHienThi.Location = new System.Drawing.Point(5, 15);
            this.tbllaypalLuoiHienThi.Name = "tbllaypalLuoiHienThi";
            this.tbllaypalLuoiHienThi.RowCount = 1;
            this.tbllaypalLuoiHienThi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbllaypalLuoiHienThi.Size = new System.Drawing.Size(851, 251);
            this.tbllaypalLuoiHienThi.TabIndex = 0;
            // 
            // dgvPhieuXuat
            // 
            this.dgvPhieuXuat.AllowUserToAddRows = false;
            this.dgvPhieuXuat.AllowUserToResizeRows = false;
            this.dgvPhieuXuat.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuXuat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoTT,
            this.IdPhieuXuat,
            this.IdNhanVien,
            this.SoOrderKH,
            this.SoPhieuXuat,
            this.NgayXuat,
            this.TenNhanVien,
            this.GhiChu});
            this.dgvPhieuXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuXuat.Location = new System.Drawing.Point(3, 3);
            this.dgvPhieuXuat.Name = "dgvPhieuXuat";
            this.dgvPhieuXuat.ReadOnly = true;
            this.dgvPhieuXuat.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhieuXuat.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhieuXuat.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPhieuXuat.RowTemplate.Height = 20;
            this.dgvPhieuXuat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuXuat.Size = new System.Drawing.Size(845, 245);
            this.dgvPhieuXuat.TabIndex = 0;
            this.dgvPhieuXuat.Sorted += new System.EventHandler(this.dgvPhieuXuat_Sorted);
            this.dgvPhieuXuat.DoubleClick += new System.EventHandler(this.dgvPhieuXuat_DoubleClick);
            // 
            // grpThucThi
            // 
            this.grpThucThi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThucThi.Controls.Add(this.btnDong);
            this.grpThucThi.Controls.Add(this.btnTim);
            this.grpThucThi.Controls.Add(this.btnCapNhat);
            this.grpThucThi.Location = new System.Drawing.Point(10, 171);
            this.grpThucThi.Name = "grpThucThi";
            this.grpThucThi.Size = new System.Drawing.Size(862, 50);
            this.grpThucThi.TabIndex = 2;
            this.grpThucThi.TabStop = false;
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(495, 16);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(105, 25);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng (F12)";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTim
            // 
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(251, 16);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(116, 25);
            this.btnTim.TabIndex = 0;
            this.btnTim.Text = "Tìm (F3)";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(373, 16);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(115, 25);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Xuất hóa đơn (F6)";
            this.btnCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTieuDe.Location = new System.Drawing.Point(632, 5);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(202, 24);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "XUẤT GỘP HÓA ĐƠN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(556, 76);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(293, 21);
            this.cboNhanVien.TabIndex = 108;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            this.cboNhanVien.Leave += new System.EventHandler(this.cboNhanVien_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(491, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 15);
            this.label13.TabIndex = 109;
            this.label13.Text = "Nhân viên";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhanVien.Location = new System.Drawing.Point(556, 47);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(294, 20);
            this.txtMaNhanVien.TabIndex = 107;
            this.txtMaNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNhanVien_KeyDown);
            this.txtMaNhanVien.Leave += new System.EventHandler(this.txtMaNhanVien_Leave);
            // 
            // SoTT
            // 
            this.SoTT.DataPropertyName = "SoTT";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SoTT.DefaultCellStyle = dataGridViewCellStyle1;
            this.SoTT.HeaderText = "SốTT";
            this.SoTT.Name = "SoTT";
            this.SoTT.ReadOnly = true;
            this.SoTT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SoTT.Width = 50;
            // 
            // IdPhieuXuat
            // 
            this.IdPhieuXuat.DataPropertyName = "IdPhieuXuat";
            this.IdPhieuXuat.HeaderText = "IdPhieuXuat";
            this.IdPhieuXuat.Name = "IdPhieuXuat";
            this.IdPhieuXuat.ReadOnly = true;
            this.IdPhieuXuat.Visible = false;
            // 
            // IdNhanVien
            // 
            this.IdNhanVien.DataPropertyName = "IdNhanVien";
            this.IdNhanVien.HeaderText = "IdNhanVien";
            this.IdNhanVien.Name = "IdNhanVien";
            this.IdNhanVien.ReadOnly = true;
            this.IdNhanVien.Visible = false;
            // 
            // SoOrderKH
            // 
            this.SoOrderKH.DataPropertyName = "SoOrderKH";
            this.SoOrderKH.HeaderText = "Số giao dịch";
            this.SoOrderKH.Name = "SoOrderKH";
            this.SoOrderKH.ReadOnly = true;
            this.SoOrderKH.Width = 120;
            // 
            // SoPhieuXuat
            // 
            this.SoPhieuXuat.DataPropertyName = "SoPhieuXuat";
            this.SoPhieuXuat.HeaderText = "Số phiếu xuất";
            this.SoPhieuXuat.Name = "SoPhieuXuat";
            this.SoPhieuXuat.ReadOnly = true;
            this.SoPhieuXuat.Width = 120;
            // 
            // NgayXuat
            // 
            this.NgayXuat.DataPropertyName = "NgayXuat";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "\"dd/MM/yyyy\"";
            dataGridViewCellStyle2.NullValue = null;
            this.NgayXuat.DefaultCellStyle = dataGridViewCellStyle2;
            this.NgayXuat.HeaderText = "Ngày xuất";
            this.NgayXuat.Name = "NgayXuat";
            this.NgayXuat.ReadOnly = true;
            // 
            // TenNhanVien
            // 
            this.TenNhanVien.DataPropertyName = "TenNhanVien";
            this.TenNhanVien.HeaderText = "Nhân viên";
            this.TenNhanVien.Name = "TenNhanVien";
            this.TenNhanVien.ReadOnly = true;
            this.TenNhanVien.Width = 160;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 250;
            // 
            // frmXuatGopHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 502);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.grpThucThi);
            this.Controls.Add(this.grpKetQuaTimKiem);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmXuatGopHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm phiếu bán hàng";
            this.Load += new System.EventHandler(this.frmTimPhieuXuat_Load);
            this.Activated += new System.EventHandler(this.frmXuatGopHoaDon_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTimPhieuXuat_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpKetQuaTimKiem.ResumeLayout(false);
            this.tbllaypalLuoiHienThi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuXuat)).EndInit();
            this.grpThucThi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpKetQuaTimKiem;
        private System.Windows.Forms.DataGridView dgvPhieuXuat;
        private System.Windows.Forms.Label lblThuocXuat;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.GroupBox grpThucThi;
        internal QLBH.Core.Form.GtidButton btnCapNhat;
        internal QLBH.Core.Form.GtidButton btnDong;
        private System.Windows.Forms.Label lblTieuDe;
        private QLBH.Core.Form.GtidButton btnTim;
        private System.Windows.Forms.TableLayoutPanel tbllaypalLuoiHienThi;
        private System.Windows.Forms.DateTimePicker mstDenNgay;
        private System.Windows.Forms.DateTimePicker mstTuNgay;
        private System.Windows.Forms.ComboBox cboKhoXuat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSoOrderKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaVach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPhieuXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoOrderKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
    }
}