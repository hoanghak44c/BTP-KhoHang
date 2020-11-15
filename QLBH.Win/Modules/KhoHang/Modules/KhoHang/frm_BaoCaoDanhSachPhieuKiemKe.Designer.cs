namespace QLBanHang.Modules.KhoHang
{
    partial class frm_BaoCaoDanhSachPhieuKiemKe
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bteDotKiemKe = new DevExpress.XtraEditors.ButtonEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bteKho = new DevExpress.XtraEditors.ButtonEdit();
            this.grcBCKiemKe = new DevExpress.XtraGrid.GridControl();
            this.grvBCKiemKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDotKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayLap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colNgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThaiXuat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repTrangThaiNhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repLoaiGiaoDich = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repNgayNhan = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayNhap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteDotKiemKe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBCKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiGiaoDich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.bteDotKiemKe);
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.btnReload);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.bteKho);
            this.groupControl1.Location = new System.Drawing.Point(1, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1071, 91);
            this.groupControl1.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Đợt kiểm kê :";
            // 
            // bteDotKiemKe
            // 
            this.bteDotKiemKe.Location = new System.Drawing.Point(83, 33);
            this.bteDotKiemKe.Name = "bteDotKiemKe";
            this.bteDotKiemKe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteDotKiemKe.Size = new System.Drawing.Size(174, 20);
            this.bteDotKiemKe.TabIndex = 17;
            this.bteDotKiemKe.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteDotKiemKe_ButtonClick);
            this.bteDotKiemKe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteDotKiemKe_KeyDown);
            this.bteDotKiemKe.TextChanged += new System.EventHandler(this.bteDotKiemKe_TextChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(402, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(297, 44);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(99, 26);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Xem báo cáo";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(55, 62);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kho:";
            // 
            // bteKho
            // 
            this.bteKho.Location = new System.Drawing.Point(83, 59);
            this.bteKho.Name = "bteKho";
            this.bteKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKho.Size = new System.Drawing.Size(174, 20);
            this.bteKho.TabIndex = 5;
            this.bteKho.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteKho_ButtonClick);
            this.bteKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteKho_KeyDown);
            this.bteKho.TextChanged += new System.EventHandler(this.bteKho_TextChanged);
            // 
            // grcBCKiemKe
            // 
            this.grcBCKiemKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.First.Visible = false;
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.Last.Visible = false;
            this.grcBCKiemKe.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grcBCKiemKe.Location = new System.Drawing.Point(1, 100);
            this.grcBCKiemKe.MainView = this.grvBCKiemKe;
            this.grcBCKiemKe.Name = "grcBCKiemKe";
            this.grcBCKiemKe.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTrangThaiXuat,
            this.repTrangThaiNhan,
            this.repLoaiGiaoDich,
            this.repNgayNhan,
            this.repNgayXuat,
            this.repNgayLap,
            this.repNgayNhap});
            this.grcBCKiemKe.Size = new System.Drawing.Size(1071, 312);
            this.grcBCKiemKe.TabIndex = 7;
            this.grcBCKiemKe.UseEmbeddedNavigator = true;
            this.grcBCKiemKe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBCKiemKe});
            // 
            // grvBCKiemKe
            // 
            this.grvBCKiemKe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDotKiemKe,
            this.colSoPhieu,
            this.colNgayLap,
            this.colNgayKetThuc,
            this.colNguoiKiemKe,
            this.colKho,
            this.colNgayKiemKe,
            this.colGhiChu});
            this.grvBCKiemKe.GridControl = this.grcBCKiemKe;
            this.grvBCKiemKe.Name = "grvBCKiemKe";
            this.grvBCKiemKe.OptionsView.ColumnAutoWidth = false;
            this.grvBCKiemKe.OptionsView.ShowAutoFilterRow = true;
            // 
            // colDotKiemKe
            // 
            this.colDotKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDotKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDotKiemKe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDotKiemKe.Caption = "Đợt kiểm kê";
            this.colDotKiemKe.FieldName = "MaDotKiemKe";
            this.colDotKiemKe.Name = "colDotKiemKe";
            this.colDotKiemKe.OptionsColumn.FixedWidth = true;
            this.colDotKiemKe.OptionsColumn.ReadOnly = true;
            this.colDotKiemKe.Visible = true;
            this.colDotKiemKe.VisibleIndex = 0;
            this.colDotKiemKe.Width = 150;
            // 
            // colSoPhieu
            // 
            this.colSoPhieu.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPhieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoPhieu.Caption = "Số phiếu";
            this.colSoPhieu.FieldName = "SoPhieu";
            this.colSoPhieu.Name = "colSoPhieu";
            this.colSoPhieu.OptionsColumn.FixedWidth = true;
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 1;
            this.colSoPhieu.Width = 150;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayLap.Caption = "Ngày bắt đầu";
            this.colNgayLap.ColumnEdit = this.repNgayLap;
            this.colNgayLap.OptionsColumn.FixedWidth = true;
            this.colNgayLap.OptionsColumn.ReadOnly = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 2;
            this.colNgayLap.Width = 100;
            // 
            // repNgayLap
            // 
            this.repNgayLap.AutoHeight = false;
            this.repNgayLap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayLap.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.repNgayLap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repNgayLap.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.repNgayLap.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repNgayLap.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.repNgayLap.Name = "repNgayLap";
            this.repNgayLap.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colNgayKetThuc
            // 
            this.colNgayKetThuc.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayKetThuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayKetThuc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayKetThuc.Caption = "Ngày kết thúc";
            this.colNgayKetThuc.FieldName = "ThoiGianKetThuc";
            this.colNgayKetThuc.Name = "colNgayKetThuc";
            this.colNgayKetThuc.OptionsColumn.FixedWidth = true;
            this.colNgayKetThuc.OptionsColumn.ReadOnly = true;
            this.colNgayKetThuc.Visible = true;
            this.colNgayKetThuc.VisibleIndex = 3;
            this.colNgayKetThuc.Width = 100;
            // 
            // colNguoiKiemKe
            // 
            this.colNguoiKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiKiemKe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiKiemKe.Caption = "Người kiểm kê";
            this.colNguoiKiemKe.FieldName = "TenNhanVien";
            this.colNguoiKiemKe.Name = "colNguoiKiemKe";
            this.colNguoiKiemKe.OptionsColumn.FixedWidth = true;
            this.colNguoiKiemKe.OptionsColumn.ReadOnly = true;
            this.colNguoiKiemKe.Visible = true;
            this.colNguoiKiemKe.VisibleIndex = 4;
            this.colNguoiKiemKe.Width = 150;
            // 
            // colKho
            // 
            this.colKho.AppearanceHeader.Options.UseTextOptions = true;
            this.colKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKho.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKho.Caption = "Kho kiểm kê";
            this.colKho.FieldName = "MaKho";
            this.colKho.Name = "colKho";
            this.colKho.OptionsColumn.FixedWidth = true;
            this.colKho.OptionsColumn.ReadOnly = true;
            this.colKho.Visible = true;
            this.colKho.VisibleIndex = 5;
            this.colKho.Width = 120;
            // 
            // colNgayKiemKe
            // 
            this.colNgayKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayKiemKe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayKiemKe.Caption = "Ngày kiểm kê";
            this.colNgayKiemKe.FieldName = "NgayKiemKe";
            this.colNgayKiemKe.Name = "colNgayKiemKe";
            this.colNgayKiemKe.OptionsColumn.FixedWidth = true;
            this.colNgayKiemKe.OptionsColumn.ReadOnly = true;
            this.colNgayKiemKe.Visible = true;
            this.colNgayKiemKe.VisibleIndex = 6;
            this.colNgayKiemKe.Width = 100;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 7;
            this.colGhiChu.Width = 500;
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
            // repLoaiGiaoDich
            // 
            this.repLoaiGiaoDich.AutoHeight = false;
            this.repLoaiGiaoDich.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLoaiGiaoDich.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repLoaiGiaoDich.DisplayMember = "Name";
            this.repLoaiGiaoDich.Name = "repLoaiGiaoDich";
            this.repLoaiGiaoDich.NullText = "";
            this.repLoaiGiaoDich.ValueMember = "Id";
            // 
            // repNgayNhan
            // 
            this.repNgayNhan.AutoHeight = false;
            this.repNgayNhan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayNhan.Name = "repNgayNhan";
            this.repNgayNhan.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repNgayXuat
            // 
            this.repNgayXuat.AutoHeight = false;
            this.repNgayXuat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayXuat.Name = "repNgayXuat";
            this.repNgayXuat.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repNgayNhap
            // 
            this.repNgayNhap.AutoHeight = false;
            this.repNgayNhap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayNhap.Name = "repNgayNhap";
            this.repNgayNhap.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // frm_BaoCaoDanhSachPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 413);
            this.Controls.Add(this.grcBCKiemKe);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_BaoCaoDanhSachPhieuKiemKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phiếu kiểm kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoChiTietHangChuyenKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteDotKiemKe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcBCKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiGiaoDich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit bteKho;
        private DevExpress.XtraGrid.GridControl grcBCKiemKe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBCKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colKho;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLoaiGiaoDich;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiKiemKe;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit bteDotKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn colDotKiemKe;
    }
}