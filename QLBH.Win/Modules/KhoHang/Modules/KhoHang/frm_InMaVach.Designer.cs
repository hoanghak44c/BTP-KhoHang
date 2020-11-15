using QLBH.Core.Form;
namespace QLBanHang.Forms
{
    partial class frm_InMaVach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_InMaVach));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTongSo = new System.Windows.Forms.Label();
            this.cmdLoc = new GtidButton();
            this.cboLoaiSP = new System.Windows.Forms.ComboBox();
            this.txtTenSP = new GtidTextBox();
            this.txtMaSP = new GtidTextBox();
            this.gv = new System.Windows.Forms.DataGridView();
            this.IdSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChonIn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenVietTat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrungMaVach = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 95);
            this.panel1.TabIndex = 61;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsPrint,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tlsClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(836, 25);
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsPrint
            // 
            this.tlsPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsPrint.Image")));
            this.tlsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPrint.Name = "tlsPrint";
            this.tlsPrint.Size = new System.Drawing.Size(108, 22);
            this.tlsPrint.Text = "In mã vạch (F9)";
            this.tlsPrint.Click += new System.EventHandler(this.tlsPrint_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(203, 22);
            this.toolStripLabel1.Text = "IN MÃ VẠCH SẢN PHẨM";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsClose
            // 
            this.tlsClose.Image = ((System.Drawing.Image)(resources.GetObject("tlsClose.Image")));
            this.tlsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsClose.Name = "tlsClose";
            this.tlsClose.Size = new System.Drawing.Size(87, 22);
            this.tlsClose.Text = "Thoát (F12)";
            this.tlsClose.Click += new System.EventHandler(this.tlsClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbTongSo);
            this.groupBox1.Controls.Add(this.cmdLoc);
            this.groupBox1.Controls.Add(this.cboLoaiSP);
            this.groupBox1.Controls.Add(this.txtTenSP);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 66);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Chọn toàn bộ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(47, 36);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 61;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(405, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Loại sản phẩm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(203, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(111, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Mã";
            // 
            // lbTongSo
            // 
            this.lbTongSo.AutoSize = true;
            this.lbTongSo.Location = new System.Drawing.Point(802, 36);
            this.lbTongSo.Name = "lbTongSo";
            this.lbTongSo.Size = new System.Drawing.Size(0, 13);
            this.lbTongSo.TabIndex = 55;
            // 
            // cmdLoc
            // 
            this.cmdLoc.Location = new System.Drawing.Point(723, 30);
            this.cmdLoc.Name = "cmdLoc";
            this.cmdLoc.Size = new System.Drawing.Size(69, 23);
            this.cmdLoc.TabIndex = 54;
            this.cmdLoc.Text = "Lọc";
            this.cmdLoc.UseVisualStyleBackColor = true;
            this.cmdLoc.Click += new System.EventHandler(this.cmdLoc_Click);
            this.cmdLoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSP_KeyDown);
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.FormattingEnabled = true;
            this.cboLoaiSP.Location = new System.Drawing.Point(404, 32);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Size = new System.Drawing.Size(313, 21);
            this.cboLoaiSP.TabIndex = 53;
            this.cboLoaiSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSP_KeyDown);
            // 
            // txtTenSP
            // 
            this.txtTenSP.AcceptsReturn = true;
            this.txtTenSP.Location = new System.Drawing.Point(205, 32);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(193, 20);
            this.txtTenSP.TabIndex = 50;
            this.txtTenSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSP_KeyDown);
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(111, 32);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(88, 20);
            this.txtMaSP.TabIndex = 48;
            this.txtMaSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSP_KeyDown);
            // 
            // gv
            // 
            this.gv.AllowUserToAddRows = false;
            this.gv.AllowUserToDeleteRows = false;
            this.gv.AllowUserToOrderColumns = true;
            this.gv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSanPham,
            this.ChonIn,
            this.MaSanPham,
            this.TenSanPham,
            this.TenVietTat,
            this.GiaBan,
            this.SoLuong,
            this.TrungMaVach});
            //this.gv.DataBindings.Add(new System.Windows.Forms.Binding("AutoGenerateColumns", global::QLBanHang.Properties.Settings.Default, "F", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gv.Location = new System.Drawing.Point(3, 3);
            this.gv.Name = "gv";
            this.gv.RowHeadersVisible = false;
            this.gv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gv.Size = new System.Drawing.Size(830, 436);
            this.gv.TabIndex = 7;
            this.gv.SelectionChanged += new System.EventHandler(this.gv_SelectionChanged);
            // 
            // IdSanPham
            // 
            this.IdSanPham.DataPropertyName = "IdSanPham";
            dataGridViewCellStyle3.NullValue = "0";
            this.IdSanPham.DefaultCellStyle = dataGridViewCellStyle3;
            this.IdSanPham.HeaderText = "ID";
            this.IdSanPham.Name = "IdSanPham";
            this.IdSanPham.ReadOnly = true;
            this.IdSanPham.Visible = false;
            // 
            // ChonIn
            // 
            this.ChonIn.DataPropertyName = "ChonIn";
            this.ChonIn.FalseValue = "0";
            this.ChonIn.HeaderText = "Chọn in";
            this.ChonIn.IndeterminateValue = "-1";
            this.ChonIn.Name = "ChonIn";
            this.ChonIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChonIn.TrueValue = "1";
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.ReadOnly = true;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.ReadOnly = true;
            this.TenSanPham.Width = 300;
            // 
            // TenVietTat
            // 
            this.TenVietTat.DataPropertyName = "TenVietTat";
            this.TenVietTat.HeaderText = "Tên rút gọn";
            this.TenVietTat.Name = "TenVietTat";
            this.TenVietTat.Width = 150;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "DonGiaCoVAT";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0.##";
            this.GiaBan.DefaultCellStyle = dataGridViewCellStyle4;
            this.GiaBan.HeaderText = "Giá bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GiaBan.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 150;
            // 
            // TrungMaVach
            // 
            this.TrungMaVach.DataPropertyName = "TrungMaVach";
            this.TrungMaVach.HeaderText = "Cho phép trùng mã vạch";
            this.TrungMaVach.Name = "TrungMaVach";
            this.TrungMaVach.ReadOnly = true;
            this.TrungMaVach.Width = 150;
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTenSanPham.Location = new System.Drawing.Point(3, 442);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(830, 40);
            this.lblTenSanPham.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTenSanPham, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 95);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 482);
            this.tableLayoutPanel1.TabIndex = 62;
            // 
            // frm_InMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frm_InMaVach";
            this.Text = "In mã vạch sản phẩm";
            this.Load += new System.EventHandler(this.frm_BangGiaHienTai_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_InMaVach_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTongSo;
        private QLBH.Core.Form.GtidButton cmdLoc;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.DataGridView gv;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tlsPrint;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlsClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSanPham;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChonIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenVietTat;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TrungMaVach;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label1;
    }
}