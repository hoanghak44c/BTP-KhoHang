using QLBH.Core.Form;
namespace QLBanHang.Forms
{
    partial class frmPhieuXuat_ChonKhuyenMai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new GtidButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lstKhuyenMai = new System.Windows.Forms.ListBox();
            this.gvKM = new System.Windows.Forms.DataGridView();
            this.IdSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DVT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new GtidButton();
            ((System.ComponentModel.ISupportInitialize)(this.gvKM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(83, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sản phẩm này có các hình thức khuyến mại sau:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(24, 213);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Cập nhật";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Danh sách khuyến mại";
            // 
            // lstKhuyenMai
            // 
            this.lstKhuyenMai.FormattingEnabled = true;
            this.lstKhuyenMai.Location = new System.Drawing.Point(12, 81);
            this.lstKhuyenMai.Name = "lstKhuyenMai";
            this.lstKhuyenMai.Size = new System.Drawing.Size(183, 108);
            this.lstKhuyenMai.TabIndex = 2;
            this.lstKhuyenMai.SelectedIndexChanged += new System.EventHandler(this.lstKhuyenMai_SelectedIndexChanged);
            // 
            // gvKM
            // 
            this.gvKM.AllowUserToAddRows = false;
            this.gvKM.AllowUserToDeleteRows = false;
            this.gvKM.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gvKM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvKM.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvKM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvKM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdSanPham,
            this.MaVach,
            this.MaSanPham,
            this.TenSanPham,
            this.DVT,
            this.colSoLuong,
            this.colTienKM});
            this.gvKM.Location = new System.Drawing.Point(6, 19);
            this.gvKM.Name = "gvKM";
            this.gvKM.RowHeadersVisible = false;
            this.gvKM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvKM.Size = new System.Drawing.Size(547, 179);
            this.gvKM.TabIndex = 1;
            this.gvKM.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_CellEndEdit);
            // 
            // IdSanPham
            // 
            this.IdSanPham.DataPropertyName = "IdSanPham";
            dataGridViewCellStyle3.NullValue = "0";
            this.IdSanPham.DefaultCellStyle = dataGridViewCellStyle3;
            this.IdSanPham.HeaderText = "ID";
            this.IdSanPham.Name = "IdSanPham";
            this.IdSanPham.Visible = false;
            this.IdSanPham.Width = 80;
            // 
            // MaVach
            // 
            this.MaVach.DataPropertyName = "MaVach";
            this.MaVach.HeaderText = "Mã vạch";
            this.MaVach.Name = "MaVach";
            this.MaVach.Width = 80;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã SP";
            this.MaSanPham.Name = "MaSanPham";
            this.MaSanPham.ReadOnly = true;
            this.MaSanPham.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaSanPham.Width = 80;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.ReadOnly = true;
            this.TenSanPham.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenSanPham.Width = 160;
            // 
            // DVT
            // 
            this.DVT.DataPropertyName = "TenDonViTinh";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.DVT.DefaultCellStyle = dataGridViewCellStyle4;
            this.DVT.HeaderText = "ĐVT";
            this.DVT.Name = "DVT";
            this.DVT.ReadOnly = true;
            this.DVT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DVT.Width = 70;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#";
            dataGridViewCellStyle5.NullValue = null;
            this.colSoLuong.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSoLuong.Width = 50;
            // 
            // colTienKM
            // 
            this.colTienKM.DataPropertyName = "SoTien";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.colTienKM.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTienKM.HeaderText = "Tiền KM";
            this.colTienKM.Name = "colTienKM";
            this.colTienKM.ReadOnly = true;
            this.colTienKM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gvKM);
            this.groupBox1.Location = new System.Drawing.Point(201, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết khuyến mại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(340, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hãy chọn một hình thức khuyến mại phù hợp!";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(106, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmPhieuXuat_ChonKhuyenMai
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 280);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstKhuyenMai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuXuat_ChonKhuyenMai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn khuyến mại";
            this.Load += new System.EventHandler(this.frmPhieuXuat_LuaChonIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvKM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private QLBH.Core.Form.GtidButton btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstKhuyenMai;
        private System.Windows.Forms.DataGridView gvKM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVach;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn DVT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienKM;
        private QLBH.Core.Form.GtidButton btnCancel;
    }
}