namespace QLBanHang.Modules.KhoHang
{
    partial class frmBaoCaoThanhPhamSanXuatChuaXacNhan
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bteKho = new DevExpress.XtraEditors.ButtonEdit();
            this.bteTrungTam = new DevExpress.XtraEditors.ButtonEdit();
            this.grcBCHangChuyenKho = new DevExpress.XtraGrid.GridControl();
            this.grvBCHangChuyenKho = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThaiXuat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repTrangThaiNhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.replueLoaiGD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repdtNgayLap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repLoaiSX = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTrungTam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBCHangChuyenKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCHangChuyenKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.replueLoaiGD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repdtNgayLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repdtNgayLap.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiSX)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnReload);
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.deTo);
            this.groupControl1.Controls.Add(this.deFrom);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.bteKho);
            this.groupControl1.Controls.Add(this.bteTrungTam);
            this.groupControl1.Location = new System.Drawing.Point(-5, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(671, 114);
            this.groupControl1.TabIndex = 13;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(515, 61);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(99, 26);
            this.btnReload.TabIndex = 15;
            this.btnReload.Text = "Xem báo cáo";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(515, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(320, 82);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTo.Size = new System.Drawing.Size(172, 20);
            this.deTo.TabIndex = 12;
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(89, 82);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFrom.Size = new System.Drawing.Size(168, 20);
            this.deFrom.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(263, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Đến ngày:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 85);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Từ ngày:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(61, 59);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Kho:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Trung tâm :";
            // 
            // bteKho
            // 
            this.bteKho.Location = new System.Drawing.Point(89, 56);
            this.bteKho.Name = "bteKho";
            this.bteKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKho.Size = new System.Drawing.Size(403, 20);
            this.bteKho.TabIndex = 5;
            this.bteKho.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteKho_ButtonClick);
            this.bteKho.DoubleClick += new System.EventHandler(this.bteKho_DoubleClick);
            this.bteKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteKho_KeyDown);
            // 
            // bteTrungTam
            // 
            this.bteTrungTam.Location = new System.Drawing.Point(89, 30);
            this.bteTrungTam.Name = "bteTrungTam";
            this.bteTrungTam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteTrungTam.Size = new System.Drawing.Size(403, 20);
            this.bteTrungTam.TabIndex = 5;
            this.bteTrungTam.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteTrungTam_ButtonClick);
            this.bteTrungTam.DoubleClick += new System.EventHandler(this.bteTrungTam_DoubleClick);
            this.bteTrungTam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteTrungTam_KeyDown);
            // 
            // grcBCHangChuyenKho
            // 
            this.grcBCHangChuyenKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcBCHangChuyenKho.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcBCHangChuyenKho.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcBCHangChuyenKho.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcBCHangChuyenKho.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcBCHangChuyenKho.EmbeddedNavigator.Buttons.First.Visible = false;
            this.grcBCHangChuyenKho.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcBCHangChuyenKho.Location = new System.Drawing.Point(-5, 123);
            this.grcBCHangChuyenKho.MainView = this.grvBCHangChuyenKho;
            this.grcBCHangChuyenKho.Name = "grcBCHangChuyenKho";
            this.grcBCHangChuyenKho.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTrangThaiXuat,
            this.repTrangThaiNhan,
            this.replueLoaiGD,
            this.repdtNgayLap,
            this.repTrangThai,
            this.repLoaiSX});
            this.grcBCHangChuyenKho.Size = new System.Drawing.Size(671, 442);
            this.grcBCHangChuyenKho.TabIndex = 12;
            this.grcBCHangChuyenKho.UseEmbeddedNavigator = true;
            this.grcBCHangChuyenKho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBCHangChuyenKho});
            // 
            // grvBCHangChuyenKho
            // 
            this.grvBCHangChuyenKho.ColumnPanelRowHeight = 25;
            this.grvBCHangChuyenKho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.colSoLuong,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.grvBCHangChuyenKho.GridControl = this.grcBCHangChuyenKho;
            this.grvBCHangChuyenKho.Name = "grvBCHangChuyenKho";
            this.grvBCHangChuyenKho.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Mã lệnh";
            this.gridColumn1.FieldName = "MaLenh";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Mã thành phẩm";
            this.gridColumn2.FieldName = "MaThanhPham";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn6.Caption = "Trung tâm";
            this.gridColumn6.FieldName = "OrgCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "Kho";
            this.gridColumn7.FieldName = "MaKho";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ngày nhập ORC";
            this.gridColumn8.FieldName = "NgayNhap";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // repTrangThaiXuat
            // 
            this.repTrangThaiXuat.AutoHeight = false;
            this.repTrangThaiXuat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThaiXuat.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repTrangThaiXuat.DisplayMember = "Name";
            this.repTrangThaiXuat.Name = "repTrangThaiXuat";
            this.repTrangThaiXuat.NullText = "";
            this.repTrangThaiXuat.ValueMember = "Id";
            // 
            // repTrangThaiNhan
            // 
            this.repTrangThaiNhan.AutoHeight = false;
            this.repTrangThaiNhan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThaiNhan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repTrangThaiNhan.DisplayMember = "Name";
            this.repTrangThaiNhan.Name = "repTrangThaiNhan";
            this.repTrangThaiNhan.NullText = "";
            this.repTrangThaiNhan.ValueMember = "Id";
            // 
            // replueLoaiGD
            // 
            this.replueLoaiGD.AutoHeight = false;
            this.replueLoaiGD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.replueLoaiGD.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.replueLoaiGD.DisplayMember = "Name";
            this.replueLoaiGD.Name = "replueLoaiGD";
            this.replueLoaiGD.NullText = "";
            this.replueLoaiGD.ShowFooter = false;
            this.replueLoaiGD.ShowHeader = false;
            this.replueLoaiGD.Tag = "";
            this.replueLoaiGD.ValueMember = "OID";
            // 
            // repdtNgayLap
            // 
            this.repdtNgayLap.AutoHeight = false;
            this.repdtNgayLap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repdtNgayLap.Name = "repdtNgayLap";
            this.repdtNgayLap.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repTrangThai
            // 
            this.repTrangThai.AutoHeight = false;
            this.repTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThai.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.repTrangThai.DisplayMember = "Name";
            this.repTrangThai.Name = "repTrangThai";
            this.repTrangThai.NullText = "";
            this.repTrangThai.ValueMember = "OID";
            // 
            // repLoaiSX
            // 
            this.repLoaiSX.AutoHeight = false;
            this.repLoaiSX.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLoaiSX.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name1")});
            this.repLoaiSX.DisplayMember = "Name";
            this.repLoaiSX.Name = "repLoaiSX";
            this.repLoaiSX.NullText = "";
            this.repLoaiSX.ShowFooter = false;
            this.repLoaiSX.ShowHeader = false;
            this.repLoaiSX.ValueMember = "OID";
            // 
            // frmBaoCaoThanhPhamSanXuatChuaXacNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 568);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grcBCHangChuyenKho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCaoThanhPhamSanXuatChuaXacNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo thành phẩm chưa xác nhận nhập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoChiTietGiaoDichNhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTrungTam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBCHangChuyenKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCHangChuyenKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.replueLoaiGD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repdtNgayLap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repdtNgayLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiSX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit bteKho;
        private DevExpress.XtraEditors.ButtonEdit bteTrungTam;
        private DevExpress.XtraGrid.GridControl grcBCHangChuyenKho;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBCHangChuyenKho;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit replueLoaiGD;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repdtNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLoaiSX;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
    }
}