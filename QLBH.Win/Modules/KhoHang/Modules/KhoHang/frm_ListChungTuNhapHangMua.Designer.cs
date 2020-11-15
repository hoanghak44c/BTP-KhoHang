namespace QLBanHang.Modules.KhoHang
{
    partial class frm_ListChungTuNhapHangMua
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.clsophieunhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clsopo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clngaynhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clthoigian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cltrangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cluser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtLanDongBoTruoc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtNgayDongBo = new System.Windows.Forms.DateTimePicker();
            this.btnNapDuLieu = new QLBH.Core.Form.GtidButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clsophieunhap,
            this.clsopo,
            this.clngaynhap,
            this.clthoigian,
            this.cltrangthai,
            this.clghichu,
            this.cluser});
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 50;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(534, 177);
            this.dgvList.TabIndex = 0;
            this.dgvList.DoubleClick += new System.EventHandler(this.dgvList_DoubleClick);
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // clsophieunhap
            // 
            this.clsophieunhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clsophieunhap.DataPropertyName = "SoPhieuNhap";
            this.clsophieunhap.HeaderText = "Số phiếu nhập";
            this.clsophieunhap.MinimumWidth = 200;
            this.clsophieunhap.Name = "clsophieunhap";
            this.clsophieunhap.ReadOnly = true;
            this.clsophieunhap.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clsopo
            // 
            this.clsopo.DataPropertyName = "SoPO";
            this.clsopo.HeaderText = "Số PO";
            this.clsopo.MinimumWidth = 150;
            this.clsopo.Name = "clsopo";
            this.clsopo.ReadOnly = true;
            this.clsopo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clsopo.Width = 150;
            // 
            // clngaynhap
            // 
            this.clngaynhap.DataPropertyName = "NgayNhap";
            this.clngaynhap.HeaderText = "Ngày nhập";
            this.clngaynhap.MinimumWidth = 150;
            this.clngaynhap.Name = "clngaynhap";
            this.clngaynhap.ReadOnly = true;
            this.clngaynhap.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clngaynhap.Width = 150;
            // 
            // clthoigian
            // 
            this.clthoigian.DataPropertyName = "ThoiGian";
            this.clthoigian.HeaderText = "Thời gian";
            this.clthoigian.MinimumWidth = 150;
            this.clthoigian.Name = "clthoigian";
            this.clthoigian.ReadOnly = true;
            this.clthoigian.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clthoigian.Width = 150;
            // 
            // cltrangthai
            // 
            this.cltrangthai.DataPropertyName = "Trangthai";
            this.cltrangthai.HeaderText = "Trạng thái";
            this.cltrangthai.MinimumWidth = 100;
            this.cltrangthai.Name = "cltrangthai";
            this.cltrangthai.ReadOnly = true;
            this.cltrangthai.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clghichu
            // 
            this.clghichu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clghichu.DataPropertyName = "GhiChu";
            this.clghichu.HeaderText = "Ghi chú";
            this.clghichu.MinimumWidth = 200;
            this.clghichu.Name = "clghichu";
            this.clghichu.ReadOnly = true;
            this.clghichu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cluser
            // 
            this.cluser.DataPropertyName = "NguoiNhap";
            this.cluser.HeaderText = "Người nhập";
            this.cluser.MinimumWidth = 100;
            this.cluser.Name = "cluser";
            this.cluser.ReadOnly = true;
            this.cluser.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 65);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtLanDongBoTruoc);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtNgayDongBo);
            this.panel3.Controls.Add(this.btnNapDuLieu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(540, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 65);
            this.panel3.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Lần đồng bộ trước";
            // 
            // dtLanDongBoTruoc
            // 
            this.dtLanDongBoTruoc.CustomFormat = "dd/MM/yyyy - hh:mm:ss";
            this.dtLanDongBoTruoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLanDongBoTruoc.Location = new System.Drawing.Point(131, 9);
            this.dtLanDongBoTruoc.Name = "dtLanDongBoTruoc";
            this.dtLanDongBoTruoc.Size = new System.Drawing.Size(134, 21);
            this.dtLanDongBoTruoc.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian đồng bộ";
            // 
            // dtNgayDongBo
            // 
            this.dtNgayDongBo.CustomFormat = "dd/MM/yyyy - hh:mm:ss";
            this.dtNgayDongBo.Enabled = false;
            this.dtNgayDongBo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayDongBo.Location = new System.Drawing.Point(131, 36);
            this.dtNgayDongBo.Name = "dtNgayDongBo";
            this.dtNgayDongBo.Size = new System.Drawing.Size(134, 21);
            this.dtNgayDongBo.TabIndex = 2;
            // 
            // btnNapDuLieu
            // 
            this.btnNapDuLieu.Location = new System.Drawing.Point(271, 9);
            this.btnNapDuLieu.Name = "btnNapDuLieu";
            this.btnNapDuLieu.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnNapDuLieu.Size = new System.Drawing.Size(132, 48);
            this.btnNapDuLieu.TabIndex = 3;
            this.btnNapDuLieu.Text = "Nạp dữ liệu mua hàng";
            this.btnNapDuLieu.Click += new System.EventHandler(this.btnNapDuLieu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chứng từ nhập";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 459);
            this.panel2.TabIndex = 2;
            // 
            // frm_ListChungTuNhapHangMua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm_ListChungTuNhapHangMua";
            this.Text = "Nhập hàng mua";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtNgayDongBo;
        private System.Windows.Forms.Label label2;
        private QLBH.Core.Form.GtidButton btnNapDuLieu;
        private System.Windows.Forms.DateTimePicker dtLanDongBoTruoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clsophieunhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn clsopo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clngaynhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn clthoigian;
        private System.Windows.Forms.DataGridViewTextBoxColumn cltrangthai;
        private System.Windows.Forms.DataGridViewTextBoxColumn clghichu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cluser;
    }
}