namespace QLBanHang.Modules.KhoHang
{
    partial class frm_BaoCaoXuatDoiLinhKienLoi
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.bteTrungTam = new DevExpress.XtraEditors.ButtonEdit();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.grcChiTiet = new DevExpress.XtraGrid.GridControl();
            this.grvChiTiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaLinhKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenThanhPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerrialNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSerialXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerialTP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaThanhPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLinhKien = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTrungTam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Trung tâm :";
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(268, 39);
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
            this.deTo.Size = new System.Drawing.Size(126, 20);
            this.deTo.TabIndex = 34;
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(80, 39);
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
            this.deFrom.Size = new System.Drawing.Size(126, 20);
            this.deFrom.TabIndex = 33;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(212, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "Đến ngày:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 32;
            this.labelControl2.Text = "Ngày lập:";
            // 
            // bteTrungTam
            // 
            this.bteTrungTam.Location = new System.Drawing.Point(80, 13);
            this.bteTrungTam.Name = "bteTrungTam";
            this.bteTrungTam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteTrungTam.Size = new System.Drawing.Size(314, 20);
            this.bteTrungTam.TabIndex = 29;
            this.bteTrungTam.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteTrungTam_ButtonClick);
            this.bteTrungTam.DoubleClick += new System.EventHandler(this.bteTrungTam_DoubleClick);
            this.bteTrungTam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteTrungTam_KeyDown);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(418, 42);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(99, 26);
            this.btnReload.TabIndex = 28;
            this.btnReload.Text = "Xem báo cáo";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(418, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 27;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grcChiTiet
            // 
            this.grcChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcChiTiet.Location = new System.Drawing.Point(2, 98);
            this.grcChiTiet.MainView = this.grvChiTiet;
            this.grcChiTiet.Name = "grcChiTiet";
            this.grcChiTiet.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTrangThai});
            this.grcChiTiet.Size = new System.Drawing.Size(867, 375);
            this.grcChiTiet.TabIndex = 26;
            this.grcChiTiet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChiTiet});
            // 
            // grvChiTiet
            // 
            this.grvChiTiet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaLinhKien,
            this.colMaThanhPham,
            this.colTenLinhKien,
            this.colTenThanhPham,
            this.colSerrialNhap,
            this.colSerialXuat,
            this.colSerialTP,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn5});
            this.grvChiTiet.GridControl = this.grcChiTiet;
            this.grvChiTiet.Name = "grvChiTiet";
            this.grvChiTiet.OptionsView.ShowAutoFilterRow = true;
            // 
            // colMaLinhKien
            // 
            this.colMaLinhKien.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaLinhKien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaLinhKien.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaLinhKien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaLinhKien.Caption = "Mã linh kiện";
            this.colMaLinhKien.FieldName = "MaLinhKien";
            this.colMaLinhKien.Name = "colMaLinhKien";
            this.colMaLinhKien.OptionsColumn.FixedWidth = true;
            this.colMaLinhKien.OptionsColumn.ReadOnly = true;
            this.colMaLinhKien.Visible = true;
            this.colMaLinhKien.VisibleIndex = 0;
            this.colMaLinhKien.Width = 100;
            // 
            // colTenThanhPham
            // 
            this.colTenThanhPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenThanhPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenThanhPham.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenThanhPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTenThanhPham.Caption = "Tên thành phẩm";
            this.colTenThanhPham.FieldName = "TenThanhPham";
            this.colTenThanhPham.Name = "colTenThanhPham";
            this.colTenThanhPham.OptionsColumn.FixedWidth = true;
            this.colTenThanhPham.OptionsColumn.ReadOnly = true;
            this.colTenThanhPham.Visible = true;
            this.colTenThanhPham.VisibleIndex = 3;
            this.colTenThanhPham.Width = 150;
            // 
            // colSerrialNhap
            // 
            this.colSerrialNhap.AppearanceHeader.Options.UseTextOptions = true;
            this.colSerrialNhap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSerrialNhap.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSerrialNhap.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSerrialNhap.Caption = "Mã vạch nhập";
            this.colSerrialNhap.FieldName = "SerialNhap";
            this.colSerrialNhap.Name = "colSerrialNhap";
            this.colSerrialNhap.OptionsColumn.FixedWidth = true;
            this.colSerrialNhap.OptionsColumn.ReadOnly = true;
            this.colSerrialNhap.Visible = true;
            this.colSerrialNhap.VisibleIndex = 4;
            this.colSerrialNhap.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn7.Caption = "Số lượng";
            this.gridColumn7.DisplayFormat.FormatString = "n0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "SoLuong";
            this.gridColumn7.GroupFormat.FormatString = "n0";
            this.gridColumn7.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn8.Caption = "Tên kho";
            this.gridColumn8.FieldName = "KhoXuat";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn9.Caption = "Ngày nhập";
            this.gridColumn9.FieldName = "NgayLap";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "Đơn vị tính";
            this.gridColumn4.FieldName = "DonViTinh";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 10;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Trạng thái";
            this.gridColumn5.ColumnEdit = this.repTrangThai;
            this.gridColumn5.FieldName = "TrangThai";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 11;
            // 
            // repTrangThai
            // 
            this.repTrangThai.AutoHeight = false;
            this.repTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThai.DisplayMember = "Name";
            this.repTrangThai.Name = "repTrangThai";
            this.repTrangThai.NullText = "";
            this.repTrangThai.ValueMember = "OID";
            // 
            // colSerialXuat
            // 
            this.colSerialXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colSerialXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSerialXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSerialXuat.Caption = "Mã vạch xuất";
            this.colSerialXuat.FieldName = "SerialXuat";
            this.colSerialXuat.Name = "colSerialXuat";
            this.colSerialXuat.OptionsColumn.FixedWidth = true;
            this.colSerialXuat.OptionsColumn.ReadOnly = true;
            this.colSerialXuat.Visible = true;
            this.colSerialXuat.VisibleIndex = 5;
            this.colSerialXuat.Width = 100;
            // 
            // colSerialTP
            // 
            this.colSerialTP.AppearanceHeader.Options.UseTextOptions = true;
            this.colSerialTP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSerialTP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSerialTP.Caption = "Mã vạch thành phẩm";
            this.colSerialTP.FieldName = "SerialTP";
            this.colSerialTP.Name = "colSerialTP";
            this.colSerialTP.OptionsColumn.FixedWidth = true;
            this.colSerialTP.OptionsColumn.ReadOnly = true;
            this.colSerialTP.Visible = true;
            this.colSerialTP.VisibleIndex = 6;
            this.colSerialTP.Width = 100;
            // 
            // colMaThanhPham
            // 
            this.colMaThanhPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaThanhPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaThanhPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaThanhPham.Caption = "Mã thành phẩm";
            this.colMaThanhPham.FieldName = "MaThanhPham";
            this.colMaThanhPham.Name = "colMaThanhPham";
            this.colMaThanhPham.OptionsColumn.FixedWidth = true;
            this.colMaThanhPham.OptionsColumn.ReadOnly = true;
            this.colMaThanhPham.Visible = true;
            this.colMaThanhPham.VisibleIndex = 1;
            this.colMaThanhPham.Width = 100;
            // 
            // colTenLinhKien
            // 
            this.colTenLinhKien.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenLinhKien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenLinhKien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTenLinhKien.Caption = "Tên linh kiện";
            this.colTenLinhKien.FieldName = "TenLinhKien";
            this.colTenLinhKien.Name = "colTenLinhKien";
            this.colTenLinhKien.OptionsColumn.FixedWidth = true;
            this.colTenLinhKien.OptionsColumn.ReadOnly = true;
            this.colTenLinhKien.Visible = true;
            this.colTenLinhKien.VisibleIndex = 2;
            this.colTenLinhKien.Width = 150;
            // 
            // frm_BaoCaoXuatDoiLinhKienLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 481);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deTo);
            this.Controls.Add(this.deFrom);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.bteTrungTam);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grcChiTiet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_BaoCaoXuatDoiLinhKienLoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách linh kiện đổi lỗi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoLenhSXChuaXuatLK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTrungTam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit bteTrungTam;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.GridControl grcChiTiet;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChiTiet;
        private DevExpress.XtraGrid.Columns.GridColumn colMaLinhKien;
        private DevExpress.XtraGrid.Columns.GridColumn colTenThanhPham;
        private DevExpress.XtraGrid.Columns.GridColumn colSerrialNhap;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colSerialTP;
        private DevExpress.XtraGrid.Columns.GridColumn colMaThanhPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLinhKien;

    }
}