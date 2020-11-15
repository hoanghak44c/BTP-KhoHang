using System.Windows.Forms;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    partial class frmCapNhatTonDauKy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatTonDauKy));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonFile = new QLBH.Core.Form.GtidButton();
            this.btnNapSoTonTuFile = new QLBH.Core.Form.GtidButton();
            this.btnNapSoTon = new QLBH.Core.Form.GtidButton();
            this.txtFile = new QLBH.Core.Form.GtidTextBox();
            this.dtNgayDuDau = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImportNoiDungChiTiet = new QLBH.Core.Form.GtidButton();
            this.btnXoaChiTiet = new QLBH.Core.Form.GtidButton();
            this.btnNhapChiTiet = new QLBH.Core.Form.GtidButton();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongKhaiBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdDuDauKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new QLBH.Core.Form.GtidButton();
            this.btnCapNhat = new QLBH.Core.Form.GtidButton();
            this.btnThoat = new QLBH.Core.Form.GtidButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnChuaNhapMV = new QLBH.Core.Form.GtidButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kho";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnChonFile);
            this.groupBox1.Controls.Add(this.btnNapSoTonTuFile);
            this.groupBox1.Controls.Add(this.btnNapSoTon);
            this.groupBox1.Controls.Add(this.txtFile);
            this.groupBox1.Controls.Add(this.dtNgayDuDau);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboKho);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonFile.Location = new System.Drawing.Point(553, 50);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnChonFile.Size = new System.Drawing.Size(116, 23);
            this.btnChonFile.TabIndex = 4;
            this.btnChonFile.Text = "Chọn file";
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // btnNapSoTonTuFile
            // 
            this.btnNapSoTonTuFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNapSoTonTuFile.Location = new System.Drawing.Point(675, 50);
            this.btnNapSoTonTuFile.Name = "btnNapSoTonTuFile";
            this.btnNapSoTonTuFile.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnNapSoTonTuFile.Size = new System.Drawing.Size(132, 23);
            this.btnNapSoTonTuFile.TabIndex = 5;
            this.btnNapSoTonTuFile.Text = "Nạp số tồn từ file";
            this.btnNapSoTonTuFile.Click += new System.EventHandler(this.btnNapSoTonTuFile_Click);
            // 
            // btnNapSoTon
            // 
            this.btnNapSoTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNapSoTon.Location = new System.Drawing.Point(732, 23);
            this.btnNapSoTon.Name = "btnNapSoTon";
            this.btnNapSoTon.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnNapSoTon.Size = new System.Drawing.Size(75, 23);
            this.btnNapSoTon.TabIndex = 2;
            this.btnNapSoTon.Text = "Nạp số tồn";
            this.btnNapSoTon.Click += new System.EventHandler(this.btnNapSoTon_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.BackColor = System.Drawing.Color.White;
            this.txtFile.Enabled = false;
            this.txtFile.Location = new System.Drawing.Point(87, 52);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(460, 20);
            this.txtFile.TabIndex = 3;
            // 
            // dtNgayDuDau
            // 
            this.dtNgayDuDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgayDuDau.CustomFormat = "dd/MM/yyyy";
            this.dtNgayDuDau.Enabled = false;
            this.dtNgayDuDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayDuDau.Location = new System.Drawing.Point(622, 24);
            this.dtNgayDuDau.Name = "dtNgayDuDau";
            this.dtNgayDuDau.Size = new System.Drawing.Size(104, 20);
            this.dtNgayDuDau.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày dư đầu";
            // 
            // cboKho
            // 
            this.cboKho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKho.Enabled = false;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(87, 25);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(460, 21);
            this.cboKho.TabIndex = 0;
            this.cboKho.SelectedIndexChanged += new System.EventHandler(this.cboKho_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "File số dư đầu";
            // 
            // btnImportNoiDungChiTiet
            // 
            this.btnImportNoiDungChiTiet.Location = new System.Drawing.Point(7, 95);
            this.btnImportNoiDungChiTiet.Name = "btnImportNoiDungChiTiet";
            this.btnImportNoiDungChiTiet.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnImportNoiDungChiTiet.Size = new System.Drawing.Size(140, 23);
            this.btnImportNoiDungChiTiet.TabIndex = 6;
            this.btnImportNoiDungChiTiet.Text = "Import nội dung chi tiết";
            this.btnImportNoiDungChiTiet.Click += new System.EventHandler(this.btnImportNoiDungChiTiet_Click);
            // 
            // btnXoaChiTiet
            // 
            this.btnXoaChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaChiTiet.Location = new System.Drawing.Point(647, 95);
            this.btnXoaChiTiet.Name = "btnXoaChiTiet";
            this.btnXoaChiTiet.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXoaChiTiet.Size = new System.Drawing.Size(75, 23);
            this.btnXoaChiTiet.TabIndex = 7;
            this.btnXoaChiTiet.Text = "Xóa chi tiết";
            this.btnXoaChiTiet.Click += new System.EventHandler(this.btnXoaChiTiet_Click);
            // 
            // btnNhapChiTiet
            // 
            this.btnNhapChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhapChiTiet.Location = new System.Drawing.Point(728, 95);
            this.btnNhapChiTiet.Name = "btnNhapChiTiet";
            this.btnNhapChiTiet.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnNhapChiTiet.Size = new System.Drawing.Size(90, 23);
            this.btnNhapChiTiet.TabIndex = 8;
            this.btnNhapChiTiet.Text = "Nhập chi tiết";
            this.btnNhapChiTiet.Click += new System.EventHandler(this.btnNhapChiTiet_Click);
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPham,
            this.TenDonViTinh,
            this.SoLuongKhaiBao,
            this.SoLuong,
            this.GiaNhap,
            this.ThanhTien,
            this.IdSanPham,
            this.IdDuDauKy});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.Location = new System.Drawing.Point(7, 124);
            this.dgvList.Name = "dgvList";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvList.RowHeadersWidth = 25;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.Size = new System.Drawing.Size(815, 245);
            this.dgvList.TabIndex = 9;
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            this.dgvList.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvList_UserDeletingRow);
            this.dgvList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvList_CellValidating);
            this.dgvList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellEndEdit);
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã sản phẩm";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TenSanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TenSanPham.Width = 185;
            // 
            // TenDonViTinh
            // 
            this.TenDonViTinh.DataPropertyName = "TenDonViTinh";
            this.TenDonViTinh.HeaderText = "Đơn vị tính";
            this.TenDonViTinh.Name = "TenDonViTinh";
            this.TenDonViTinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenDonViTinh.Width = 80;
            // 
            // SoLuongKhaiBao
            // 
            this.SoLuongKhaiBao.DataPropertyName = "SoLuongKhaiBao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SoLuongKhaiBao.DefaultCellStyle = dataGridViewCellStyle3;
            this.SoLuongKhaiBao.HeaderText = "SL tồn khai báo";
            this.SoLuongKhaiBao.Name = "SoLuongKhaiBao";
            this.SoLuongKhaiBao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SoLuongKhaiBao.Width = 90;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "SL đã nhập";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // GiaNhap
            // 
            this.GiaNhap.DataPropertyName = "GiaNhap";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.GiaNhap.DefaultCellStyle = dataGridViewCellStyle4;
            this.GiaNhap.HeaderText = "Giá nhập";
            this.GiaNhap.Name = "GiaNhap";
            this.GiaNhap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.ThanhTien.DefaultCellStyle = dataGridViewCellStyle5;
            this.ThanhTien.HeaderText = "Thành tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            this.ThanhTien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IdSanPham
            // 
            this.IdSanPham.DataPropertyName = "IdSanPham";
            this.IdSanPham.HeaderText = "IdSanPham";
            this.IdSanPham.Name = "IdSanPham";
            this.IdSanPham.Visible = false;
            // 
            // IdDuDauKy
            // 
            this.IdDuDauKy.DataPropertyName = "IdDuDauKy";
            this.IdDuDauKy.HeaderText = "IdDuDauKy";
            this.IdDuDauKy.Name = "IdDuDauKy";
            this.IdDuDauKy.Visible = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(646, 375);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXoa.Size = new System.Drawing.Size(79, 26);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "&Xóa ";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(555, 375);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnCapNhat.Size = new System.Drawing.Size(85, 26);
            this.btnCapNhat.TabIndex = 10;
            this.btnCapNhat.Text = "    &Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(731, 375);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnThoat.Size = new System.Drawing.Size(91, 26);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Th&oát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChuaNhapMV
            // 
            this.btnChuaNhapMV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChuaNhapMV.Location = new System.Drawing.Point(12, 375);
            this.btnChuaNhapMV.Name = "btnChuaNhapMV";
            this.btnChuaNhapMV.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnChuaNhapMV.Size = new System.Drawing.Size(180, 23);
            this.btnChuaNhapMV.TabIndex = 34;
            this.btnChuaNhapMV.Text = "Sản phẩm chưa nhập mã vạch";
            this.btnChuaNhapMV.Click += new System.EventHandler(this.btnChuaNhapMV_Click);
            // 
            // frmCapNhatTonDauKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 413);
            this.Controls.Add(this.btnChuaNhapMV);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnNhapChiTiet);
            this.Controls.Add(this.btnXoaChiTiet);
            this.Controls.Add(this.btnImportNoiDungChiTiet);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCapNhatTonDauKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật tồn đầu kỳ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCapNhatTonDauKy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboKho;
        private QLBH.Core.Form.GtidButton btnChonFile;
        private QLBH.Core.Form.GtidButton btnNapSoTonTuFile;
        private QLBH.Core.Form.GtidButton btnNapSoTon;
        private System.Windows.Forms.DateTimePicker dtNgayDuDau;
        private System.Windows.Forms.Label label4;
        private QLBH.Core.Form.GtidButton btnImportNoiDungChiTiet;
        private QLBH.Core.Form.GtidButton btnXoaChiTiet;
        private QLBH.Core.Form.GtidButton btnNhapChiTiet;
        private System.Windows.Forms.DataGridView dgvList;
        internal QLBH.Core.Form.GtidButton btnXoa;
        internal QLBH.Core.Form.GtidButton btnCapNhat;
        internal QLBH.Core.Form.GtidButton btnThoat;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongKhaiBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDuDauKy;
        private QLBH.Core.Form.GtidButton btnChuaNhapMV;
        private GtidTextBox txtFile;
    }
}