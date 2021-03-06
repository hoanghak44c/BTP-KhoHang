using System;
using System.Windows.Forms;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    partial class frmChiTiet_ChungTuNhapBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTiet_ChungTuNhapBase));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChiTiet = new QLBH.Core.Form.GtidDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemSP = new QLBH.Core.Form.GtidSimpleButton();
            this.btnXoaSP = new QLBH.Core.Form.GtidSimpleButton();
            this.btnChiTietMaVach = new QLBH.Core.Form.GtidSimpleButton();
            this.btnCapNhat = new QLBH.Core.Form.GtidSimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnInPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnXacNhan = new QLBH.Core.Form.GtidSimpleButton();
            this.txtSoPhieu = new DevExpress.XtraEditors.ButtonEdit();
            this.dtNgayLap = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Phiếu nhập số";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToResizeColumns = false;
            this.dgvChiTiet.AllowUserToResizeRows = false;
            this.dgvChiTiet.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 84);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 396);
            this.dgvChiTiet.TabIndex = 4;
            this.dgvChiTiet.DoubleClick += new System.EventHandler(this.dgvChiTiet_DoubleClick);
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            this.dgvChiTiet.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvChiTiet_EditingControlShowing);
            this.dgvChiTiet.SelectionChanged += new System.EventHandler(this.dgvChiTiet_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ngày lập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(696, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Người lập";
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(768, 20);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.Size = new System.Drawing.Size(173, 21);
            this.txtNguoiLap.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(117, 46);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(824, 21);
            this.txtGhiChu.TabIndex = 3;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.Location = new System.Drawing.Point(12, 486);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.ShortCutKey = System.Windows.Forms.Keys.F3;
            this.btnThemSP.Size = new System.Drawing.Size(95, 25);
            this.btnThemSP.TabIndex = 5;
            this.btnThemSP.Text = "Thêm(F3)";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaSP.Image")));
            this.btnXoaSP.Location = new System.Drawing.Point(113, 486);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.ShortCutKey = System.Windows.Forms.Keys.F8;
            this.btnXoaSP.Size = new System.Drawing.Size(95, 25);
            this.btnXoaSP.TabIndex = 6;
            this.btnXoaSP.Text = "Xóa(F8)";
            //this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTietMaVach.Image")));
            this.btnChiTietMaVach.Location = new System.Drawing.Point(237, 487);
            this.btnChiTietMaVach.Name = "btnChiTietMaVach";
            this.btnChiTietMaVach.ShortCutKey = System.Windows.Forms.Keys.F7;
            this.btnChiTietMaVach.Size = new System.Drawing.Size(95, 25);
            this.btnChiTietMaVach.TabIndex = 7;
            this.btnChiTietMaVach.Text = "Chi tiết(F7)";
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(745, 486);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnCapNhat.Size = new System.Drawing.Size(95, 25);
            this.btnCapNhat.TabIndex = 10;
            this.btnCapNhat.Text = "Cập nhật(F2)";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(846, 486);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.Escape;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieu.Image")));
            this.btnInPhieu.Location = new System.Drawing.Point(338, 487);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.ShortCutKey = System.Windows.Forms.Keys.F11;
            this.btnInPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnInPhieu.TabIndex = 8;
            this.btnInPhieu.Text = "In phiếu(F11)";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(608, 486);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXacNhan.Size = new System.Drawing.Size(101, 25);
            this.btnXacNhan.TabIndex = 9;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Visible = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(117, 21);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)});
            this.txtSoPhieu.Properties.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(336, 20);
            this.txtSoPhieu.TabIndex = 0;
            this.txtSoPhieu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSoPhieu_ButtonClick);
            this.txtSoPhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoPhieu_KeyDown);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
            this.dtNgayLap.Location = new System.Drawing.Point(525, 21);
            this.dtNgayLap.Name = "dtNgayLap";
            this.dtNgayLap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(165, 20);
            this.dtNgayLap.TabIndex = 16;
            // 
            // frmChiTiet_ChungTuNhapBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.dtNgayLap);
            this.Controls.Add(this.txtSoPhieu);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnChiTietMaVach);
            this.Controls.Add(this.btnXoaSP);
            this.Controls.Add(this.btnThemSP);
            this.Controls.Add(this.txtNguoiLap);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTiet_ChungTuNhapBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết chứng từ nhập";
            this.Load += new System.EventHandler(this.frmChiTiet_ChungTuNhap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChiTiet_ChungTuNhapBase_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected GtidSimpleButton btnThemSP;
        protected GtidSimpleButton btnXoaSP;
        protected GtidSimpleButton btnCapNhat;
        protected QLBH.Core.Form.GtidDataGridView dgvChiTiet;
        public System.Windows.Forms.TextBox txtNguoiLap;
        public System.Windows.Forms.TextBox txtGhiChu;
        public GtidSimpleButton btnChiTietMaVach;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label4;
        protected GtidSimpleButton btnDong;
        public GtidSimpleButton btnInPhieu;
        protected GtidSimpleButton btnXacNhan;
        protected DevExpress.XtraEditors.ButtonEdit txtSoPhieu;
        protected DevExpress.XtraEditors.DateEdit dtNgayLap;
    }
}