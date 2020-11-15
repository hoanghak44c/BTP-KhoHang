using QLBH.Core.Form;

namespace QLBanHang.Modules.DongBoERP
{
    partial class frm_ChungTuNhap
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
            if (disposing && (components != null)) {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChungTuNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.btnNapDuLieu = new QLBH.Core.Form.GtidButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnPhieuTruocDo = new QLBH.Core.Form.GtidButton();
            this.btnPhieuTiepTheo = new QLBH.Core.Form.GtidButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTongTienHang = new QLBH.Core.Form.GtidTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGhiChu = new QLBH.Core.Form.GtidTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTrungTam = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtThoiGianTaoGD = new QLBH.Core.Form.GtidTextBox();
            this.txtNgayNhap = new QLBH.Core.Form.GtidTextBox();
            this.txtPhieuNhap = new QLBH.Core.Form.GtidTextBox();
            this.txtSoPO = new QLBH.Core.Form.GtidTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNhapChiTietHangHoa = new QLBH.Core.Form.GtidButton();
            this.btnImportNoiDungChiTiet = new QLBH.Core.Form.GtidButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.IdPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdChungTuChiTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventorySub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDong = new QLBH.Core.Form.GtidButton();
            this.dtNgayDongBo = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGoTo = new QLBH.Core.Form.GtidButton();
            this.txtFilterSoHD = new QLBH.Core.Form.GtidTextBox();
            this.cboConditionName = new System.Windows.Forms.ComboBox();
            this.btnPrint = new QLBH.Core.Form.GtidButton();
            this.dtLanDongBoTruoc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdShowNotMa = new QLBH.Core.Form.GtidButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian đồng bộ";
            // 
            // btnNapDuLieu
            // 
            this.btnNapDuLieu.Location = new System.Drawing.Point(345, 16);
            this.btnNapDuLieu.Name = "btnNapDuLieu";
            this.btnNapDuLieu.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnNapDuLieu.Size = new System.Drawing.Size(157, 30);
            this.btnNapDuLieu.TabIndex = 2;
            this.btnNapDuLieu.Text = "Nạp dữ liệu mua hàng";
            this.btnNapDuLieu.Click += new System.EventHandler(this.btnNapDuLieu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblContent);
            this.groupBox1.Location = new System.Drawing.Point(15, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblContent.Location = new System.Drawing.Point(31, 29);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(180, 13);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "Không có phiếu mua hàng nào";
            // 
            // btnPhieuTruocDo
            // 
            this.btnPhieuTruocDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhieuTruocDo.Enabled = false;
            this.btnPhieuTruocDo.Location = new System.Drawing.Point(610, 489);
            this.btnPhieuTruocDo.Name = "btnPhieuTruocDo";
            this.btnPhieuTruocDo.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnPhieuTruocDo.Size = new System.Drawing.Size(83, 25);
            this.btnPhieuTruocDo.TabIndex = 2;
            this.btnPhieuTruocDo.Text = "Phiếu trước đó";
            this.btnPhieuTruocDo.Click += new System.EventHandler(this.btnPhieuTruocDo_Click);
            // 
            // btnPhieuTiepTheo
            // 
            this.btnPhieuTiepTheo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhieuTiepTheo.Enabled = false;
            this.btnPhieuTiepTheo.Location = new System.Drawing.Point(697, 489);
            this.btnPhieuTiepTheo.Name = "btnPhieuTiepTheo";
            this.btnPhieuTiepTheo.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnPhieuTiepTheo.Size = new System.Drawing.Size(87, 25);
            this.btnPhieuTiepTheo.TabIndex = 1;
            this.btnPhieuTiepTheo.Text = "Phiếu tiếp theo";
            this.btnPhieuTiepTheo.Click += new System.EventHandler(this.btnPhieuTiepTheo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTongTienHang);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cboKho);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboTrungTam);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtThoiGianTaoGD);
            this.groupBox2.Controls.Add(this.txtNgayNhap);
            this.groupBox2.Controls.Add(this.txtPhieuNhap);
            this.groupBox2.Controls.Add(this.txtSoPO);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(15, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(861, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // txtTongTienHang
            // 
            this.txtTongTienHang.Enabled = false;
            this.txtTongTienHang.Location = new System.Drawing.Point(105, 117);
            this.txtTongTienHang.Name = "txtTongTienHang";
            this.txtTongTienHang.Size = new System.Drawing.Size(187, 21);
            this.txtTongTienHang.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Tổng tiền hàng";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Enabled = false;
            this.txtGhiChu.Location = new System.Drawing.Point(105, 67);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(267, 44);
            this.txtGhiChu.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Ghi chú";
            // 
            // cboKho
            // 
            this.cboKho.Enabled = false;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(105, 40);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(267, 21);
            this.cboKho.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Kho hàng";
            // 
            // cboTrungTam
            // 
            this.cboTrungTam.Enabled = false;
            this.cboTrungTam.FormattingEnabled = true;
            this.cboTrungTam.Location = new System.Drawing.Point(105, 13);
            this.cboTrungTam.Name = "cboTrungTam";
            this.cboTrungTam.Size = new System.Drawing.Size(267, 21);
            this.cboTrungTam.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Trung tâm";
            // 
            // txtThoiGianTaoGD
            // 
            this.txtThoiGianTaoGD.Enabled = false;
            this.txtThoiGianTaoGD.Location = new System.Drawing.Point(590, 91);
            this.txtThoiGianTaoGD.Name = "txtThoiGianTaoGD";
            this.txtThoiGianTaoGD.Size = new System.Drawing.Size(251, 21);
            this.txtThoiGianTaoGD.TabIndex = 7;
            // 
            // txtNgayNhap
            // 
            this.txtNgayNhap.Enabled = false;
            this.txtNgayNhap.Location = new System.Drawing.Point(590, 65);
            this.txtNgayNhap.Name = "txtNgayNhap";
            this.txtNgayNhap.Size = new System.Drawing.Size(251, 21);
            this.txtNgayNhap.TabIndex = 6;
            // 
            // txtPhieuNhap
            // 
            this.txtPhieuNhap.Enabled = false;
            this.txtPhieuNhap.Location = new System.Drawing.Point(590, 39);
            this.txtPhieuNhap.Name = "txtPhieuNhap";
            this.txtPhieuNhap.Size = new System.Drawing.Size(251, 21);
            this.txtPhieuNhap.TabIndex = 5;
            // 
            // txtSoPO
            // 
            this.txtSoPO.Enabled = false;
            this.txtSoPO.Location = new System.Drawing.Point(590, 13);
            this.txtSoPO.Name = "txtSoPO";
            this.txtSoPO.Size = new System.Drawing.Size(251, 21);
            this.txtSoPO.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(491, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Thời gian tạo GD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ngày nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số phiếu nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số PO";
            // 
            // btnNhapChiTietHangHoa
            // 
            this.btnNhapChiTietHangHoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhapChiTietHangHoa.Location = new System.Drawing.Point(689, 282);
            this.btnNhapChiTietHangHoa.Name = "btnNhapChiTietHangHoa";
            this.btnNhapChiTietHangHoa.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnNhapChiTietHangHoa.Size = new System.Drawing.Size(171, 23);
            this.btnNhapChiTietHangHoa.TabIndex = 5;
            this.btnNhapChiTietHangHoa.Text = "Nhập chi tiết hàng hóa";
            this.btnNhapChiTietHangHoa.Click += new System.EventHandler(this.btnNhapChiTietHangHoa_Click);
            // 
            // btnImportNoiDungChiTiet
            // 
            this.btnImportNoiDungChiTiet.Location = new System.Drawing.Point(24, 282);
            this.btnImportNoiDungChiTiet.Name = "btnImportNoiDungChiTiet";
            this.btnImportNoiDungChiTiet.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnImportNoiDungChiTiet.Size = new System.Drawing.Size(153, 23);
            this.btnImportNoiDungChiTiet.TabIndex = 6;
            this.btnImportNoiDungChiTiet.Text = "Import nội dung chi tiết";
            this.btnImportNoiDungChiTiet.Click += new System.EventHandler(this.btnImportNoiDungChiTiet_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPhieuNhap,
            this.IdChungTuChiTiet,
            this.InventoryOrg,
            this.InventorySub,
            this.SoPO,
            this.SoPhieuNhap,
            this.NgayNhap,
            this.GhiChu,
            this.TongTienHang,
            this.ThoiGian,
            this.MaSanPham,
            this.IdSanPham,
            this.TenSanPham,
            this.TenDonViTinh,
            this.SoLuong,
            this.DonGia,
            this.ThanhTien,
            this.TrangThai,
            this.colGhiChu});
            this.dgvList.Location = new System.Drawing.Point(15, 311);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidth = 25;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(861, 150);
            this.dgvList.TabIndex = 7;
            // 
            // IdPhieuNhap
            // 
            this.IdPhieuNhap.DataPropertyName = "IdPhieuNhap";
            this.IdPhieuNhap.HeaderText = "IdPhieuNhap";
            this.IdPhieuNhap.Name = "IdPhieuNhap";
            this.IdPhieuNhap.ReadOnly = true;
            this.IdPhieuNhap.Visible = false;
            // 
            // IdChungTuChiTiet
            // 
            this.IdChungTuChiTiet.DataPropertyName = "IdChiTiet";
            this.IdChungTuChiTiet.HeaderText = "IdChungTuChiTiet";
            this.IdChungTuChiTiet.Name = "IdChungTuChiTiet";
            this.IdChungTuChiTiet.ReadOnly = true;
            this.IdChungTuChiTiet.Visible = false;
            // 
            // InventoryOrg
            // 
            this.InventoryOrg.DataPropertyName = "InventoryOrg";
            this.InventoryOrg.HeaderText = "InventoryOrg";
            this.InventoryOrg.Name = "InventoryOrg";
            this.InventoryOrg.ReadOnly = true;
            this.InventoryOrg.Visible = false;
            // 
            // InventorySub
            // 
            this.InventorySub.DataPropertyName = "InventorySub";
            this.InventorySub.HeaderText = "InventorySub";
            this.InventorySub.Name = "InventorySub";
            this.InventorySub.ReadOnly = true;
            this.InventorySub.Visible = false;
            // 
            // SoPO
            // 
            this.SoPO.DataPropertyName = "SoPO";
            this.SoPO.HeaderText = "Số PO";
            this.SoPO.Name = "SoPO";
            this.SoPO.ReadOnly = true;
            this.SoPO.Visible = false;
            // 
            // SoPhieuNhap
            // 
            this.SoPhieuNhap.DataPropertyName = "SoPhieuNhap";
            this.SoPhieuNhap.HeaderText = "Số phiếu nhập";
            this.SoPhieuNhap.Name = "SoPhieuNhap";
            this.SoPhieuNhap.ReadOnly = true;
            this.SoPhieuNhap.Visible = false;
            // 
            // NgayNhap
            // 
            this.NgayNhap.DataPropertyName = "NgayNhap";
            this.NgayNhap.HeaderText = "Ngày nhập";
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.ReadOnly = true;
            this.NgayNhap.Visible = false;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Visible = false;
            // 
            // TongTienHang
            // 
            this.TongTienHang.DataPropertyName = "TongTienHang";
            this.TongTienHang.HeaderText = "Tổng tiền hàng";
            this.TongTienHang.Name = "TongTienHang";
            this.TongTienHang.ReadOnly = true;
            this.TongTienHang.Visible = false;
            // 
            // ThoiGian
            // 
            this.ThoiGian.DataPropertyName = "ThoiGian";
            dataGridViewCellStyle1.NullValue = null;
            this.ThoiGian.DefaultCellStyle = dataGridViewCellStyle1;
            this.ThoiGian.HeaderText = "Thời gian";
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.ReadOnly = true;
            this.ThoiGian.Visible = false;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã sản phẩm";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.ReadOnly = true;
            // 
            // IdSanPham
            // 
            this.IdSanPham.DataPropertyName = "IdSanPham";
            this.IdSanPham.HeaderText = "IdSanPham";
            this.IdSanPham.Name = "IdSanPham";
            this.IdSanPham.ReadOnly = true;
            this.IdSanPham.Visible = false;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.ReadOnly = true;
            this.TenSanPham.Width = 150;
            // 
            // TenDonViTinh
            // 
            this.TenDonViTinh.DataPropertyName = "TenDonViTinh";
            this.TenDonViTinh.HeaderText = "ĐVT";
            this.TenDonViTinh.Name = "TenDonViTinh";
            this.TenDonViTinh.ReadOnly = true;
            this.TenDonViTinh.Width = 70;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.SoLuong.DefaultCellStyle = dataGridViewCellStyle2;
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 80;
            // 
            // DonGia
            // 
            this.DonGia.DataPropertyName = "DonGia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.DonGia.DefaultCellStyle = dataGridViewCellStyle3;
            this.DonGia.HeaderText = "Đơn giá";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ThanhTien.DefaultCellStyle = dataGridViewCellStyle4;
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 80;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "colGhiChu";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            this.colGhiChu.Width = 130;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(789, 489);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(87, 25);
            this.btnDong.TabIndex = 24;
            this.btnDong.Text = "Kết thúc";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dtNgayDongBo
            // 
            this.dtNgayDongBo.CustomFormat = "dd/MM/yyyy - hh:mm:ss";
            this.dtNgayDongBo.Enabled = false;
            this.dtNgayDongBo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayDongBo.Location = new System.Drawing.Point(144, 36);
            this.dtNgayDongBo.Name = "dtNgayDongBo";
            this.dtNgayDongBo.Size = new System.Drawing.Size(170, 21);
            this.dtNgayDongBo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Location = new System.Drawing.Point(15, 473);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(861, 8);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // btnGoTo
            // 
            this.btnGoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGoTo.Location = new System.Drawing.Point(234, 489);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnGoTo.Size = new System.Drawing.Size(80, 25);
            this.btnGoTo.TabIndex = 2;
            this.btnGoTo.Text = "Chuyển đến";
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // txtFilterSoHD
            // 
            this.txtFilterSoHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilterSoHD.Location = new System.Drawing.Point(135, 493);
            this.txtFilterSoHD.Name = "txtFilterSoHD";
            this.txtFilterSoHD.Size = new System.Drawing.Size(93, 21);
            this.txtFilterSoHD.TabIndex = 5;
            // 
            // cboConditionName
            // 
            this.cboConditionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboConditionName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConditionName.FormattingEnabled = true;
            this.cboConditionName.Items.AddRange(new object[] {
            "Số phiếu nhập",
            "Số PO"});
            this.cboConditionName.Location = new System.Drawing.Point(15, 493);
            this.cboConditionName.Name = "cboConditionName";
            this.cboConditionName.Size = new System.Drawing.Size(114, 21);
            this.cboConditionName.TabIndex = 9;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(320, 489);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnPrint.Size = new System.Drawing.Size(83, 25);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "In Phiếu";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dtLanDongBoTruoc
            // 
            this.dtLanDongBoTruoc.CustomFormat = "dd/MM/yyyy - hh:mm:ss";
            this.dtLanDongBoTruoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLanDongBoTruoc.Location = new System.Drawing.Point(144, 9);
            this.dtLanDongBoTruoc.Name = "dtLanDongBoTruoc";
            this.dtLanDongBoTruoc.Size = new System.Drawing.Size(170, 21);
            this.dtLanDongBoTruoc.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Lần đồng bộ trước";
            // 
            // cmdShowNotMa
            // 
            this.cmdShowNotMa.Location = new System.Drawing.Point(622, 16);
            this.cmdShowNotMa.Name = "cmdShowNotMa";
            this.cmdShowNotMa.ShortCutKey = System.Windows.Forms.Keys.None;
            this.cmdShowNotMa.Size = new System.Drawing.Size(234, 30);
            this.cmdShowNotMa.TabIndex = 28;
            this.cmdShowNotMa.Text = "Các mặt hàng chưa có mã";
            this.cmdShowNotMa.Visible = false;
            this.cmdShowNotMa.Click += new System.EventHandler(this.cmdShowNotMa_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frm_ChungTuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 528);
            this.Controls.Add(this.cmdShowNotMa);
            this.Controls.Add(this.dtLanDongBoTruoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGoTo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPhieuTruocDo);
            this.Controls.Add(this.btnPhieuTiepTheo);
            this.Controls.Add(this.dtNgayDongBo);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.cboConditionName);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnImportNoiDungChiTiet);
            this.Controls.Add(this.btnNhapChiTietHangHoa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtFilterSoHD);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNapDuLieu);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frm_ChungTuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đồng bộ chứng từ mua hàng";
            this.Load += new System.EventHandler(this.frm_ChungTuNhap_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_ChungTuNhap_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboKho;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTrungTam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DateTimePicker dtNgayDongBo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboConditionName;
        private System.Windows.Forms.DateTimePicker dtLanDongBoTruoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdChungTuChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventorySub;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private GtidButton btnNapDuLieu;
        private GtidButton btnPhieuTruocDo;
        private GtidButton btnPhieuTiepTheo;
        private GtidTextBox txtTongTienHang;
        private GtidTextBox txtGhiChu;
        private GtidTextBox txtThoiGianTaoGD;
        private GtidTextBox txtNgayNhap;
        private GtidTextBox txtPhieuNhap;
        private GtidTextBox txtSoPO;
        private GtidButton btnNhapChiTietHangHoa;
        private GtidButton btnImportNoiDungChiTiet;
        internal GtidButton btnDong;
        private GtidButton btnGoTo;
        private GtidTextBox txtFilterSoHD;
        private GtidButton btnPrint;
        private GtidButton cmdShowNotMa;

    }
}
