namespace QLBanHang.Modules.KhoHang
{
    partial class frmDanhSachNhapThanhPham
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListNTP = new QLBH.Core.Form.GtidDataGridView();
            this.btnInPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.clSoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListNTP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvListNTP);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 338);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // dgvListNTP
            // 
            this.dgvListNTP.AllowUserToAddRows = false;
            this.dgvListNTP.AllowUserToDeleteRows = false;
            this.dgvListNTP.AllowUserToResizeColumns = false;
            this.dgvListNTP.AllowUserToResizeRows = false;
            this.dgvListNTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListNTP.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListNTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListNTP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSoPhieu,
            this.colSerial,
            this.clNgayXuat,
            this.clTrangThai});
            this.dgvListNTP.Location = new System.Drawing.Point(6, 16);
            this.dgvListNTP.Name = "dgvListNTP";
            this.dgvListNTP.RowHeadersVisible = false;
            this.dgvListNTP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListNTP.Size = new System.Drawing.Size(725, 316);
            this.dgvListNTP.TabIndex = 3;
            this.dgvListNTP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListNTP_CellClick);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(8, 361);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnInPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnInPhieu.TabIndex = 28;
            this.btnInPhieu.Text = "In phiếu";
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // clSoPhieu
            // 
            this.clSoPhieu.DataPropertyName = "SoChungTu";
            this.clSoPhieu.HeaderText = "Số phiếu";
            this.clSoPhieu.MinimumWidth = 200;
            this.clSoPhieu.Name = "clSoPhieu";
            this.clSoPhieu.ReadOnly = true;
            this.clSoPhieu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clSoPhieu.Width = 200;
            // 
            // colSerial
            // 
            this.colSerial.DataPropertyName = "MaVach";
            this.colSerial.HeaderText = "Mã vạch";
            this.colSerial.Name = "colSerial";
            this.colSerial.ReadOnly = true;
            this.colSerial.Width = 250;
            // 
            // clNgayXuat
            // 
            this.clNgayXuat.DataPropertyName = "NgayLap";
            this.clNgayXuat.HeaderText = "Ngày xuất";
            this.clNgayXuat.MinimumWidth = 150;
            this.clNgayXuat.Name = "clNgayXuat";
            this.clNgayXuat.ReadOnly = true;
            this.clNgayXuat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNgayXuat.Width = 150;
            // 
            // clTrangThai
            // 
            this.clTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clTrangThai.DataPropertyName = "TrangThai";
            this.clTrangThai.HeaderText = "Trạng thái";
            this.clTrangThai.Name = "clTrangThai";
            this.clTrangThai.ReadOnly = true;
            this.clTrangThai.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmDanhSachNhapThanhPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 398);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDanhSachNhapThanhPham";
            this.Text = "Danh sách nhập thành phẩm";
            this.Load += new System.EventHandler(this.frmDanhSachNhapThanhPham_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListNTP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private QLBH.Core.Form.GtidDataGridView dgvListNTP;
        private QLBH.Core.Form.GtidSimpleButton btnInPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTrangThai;
    }
}