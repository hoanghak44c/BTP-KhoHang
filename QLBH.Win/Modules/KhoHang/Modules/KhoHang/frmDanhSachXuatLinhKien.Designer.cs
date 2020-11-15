namespace QLBanHang.Modules.KhoHang
{
    partial class frmDanhSachXuatLinhKien
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
            this.dgvListXLK = new QLBH.Core.Form.GtidDataGridView();
            this.clSoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMavach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayXuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInphieu = new QLBH.Core.Form.GtidSimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListXLK)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvListXLK);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 346);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // dgvListXLK
            // 
            this.dgvListXLK.AllowUserToAddRows = false;
            this.dgvListXLK.AllowUserToDeleteRows = false;
            this.dgvListXLK.AllowUserToResizeColumns = false;
            this.dgvListXLK.AllowUserToResizeRows = false;
            this.dgvListXLK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListXLK.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvListXLK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListXLK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSoPhieu,
            this.colMavach,
            this.clNgayXuat,
            this.clTrangThai});
            this.dgvListXLK.Location = new System.Drawing.Point(6, 16);
            this.dgvListXLK.Name = "dgvListXLK";
            this.dgvListXLK.RowHeadersVisible = false;
            this.dgvListXLK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListXLK.Size = new System.Drawing.Size(725, 324);
            this.dgvListXLK.TabIndex = 3;
            this.dgvListXLK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvListXLK_MouseDown);
            this.dgvListXLK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListXLK_CellClick);
            // 
            // clSoPhieu
            // 
            this.clSoPhieu.DataPropertyName = "SoChungTu";
            this.clSoPhieu.HeaderText = "Số phiếu";
            this.clSoPhieu.MinimumWidth = 150;
            this.clSoPhieu.Name = "clSoPhieu";
            this.clSoPhieu.ReadOnly = true;
            this.clSoPhieu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clSoPhieu.Width = 150;
            // 
            // colMavach
            // 
            this.colMavach.DataPropertyName = "MaVach";
            this.colMavach.HeaderText = "Mã vạch thành phẩm";
            this.colMavach.Name = "colMavach";
            this.colMavach.Width = 200;
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
            // btnInphieu
            // 
            this.btnInphieu.Location = new System.Drawing.Point(7, 361);
            this.btnInphieu.Name = "btnInphieu";
            this.btnInphieu.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnInphieu.Size = new System.Drawing.Size(95, 25);
            this.btnInphieu.TabIndex = 26;
            this.btnInphieu.Text = "In phiếu";
            this.btnInphieu.Click += new System.EventHandler(this.btnInphieu_Click);
            // 
            // frmDanhSachXuatLinhKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 398);
            this.Controls.Add(this.btnInphieu);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDanhSachXuatLinhKien";
            this.Text = "Danh sách chứng từ xuất LK";
            this.Load += new System.EventHandler(this.frmDanhSachXuatLinhKien_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListXLK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private QLBH.Core.Form.GtidDataGridView dgvListXLK;
        private QLBH.Core.Form.GtidSimpleButton btnInphieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMavach;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayXuat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTrangThai;
    }
}