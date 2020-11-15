namespace QLBanHang.Modules.KhoHang
{
    partial class frm_BaoCaoTongHopKiemKe
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
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bteKho = new DevExpress.XtraEditors.ButtonEdit();
            this.grcBCKiemKe = new DevExpress.XtraGrid.GridControl();
            this.grvBCKiemKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayLap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colNguoiKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaVachKhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaVachCo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNganh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThaiXuat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repTrangThaiNhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repLoaiGiaoDich = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repNgayNhan = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayNhap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
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
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.btnReload);
            this.groupControl1.Controls.Add(this.deTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.deFrom);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.bteKho);
            this.groupControl1.Location = new System.Drawing.Point(1, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1071, 91);
            this.groupControl1.TabIndex = 6;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(522, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(417, 44);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(99, 26);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Xem báo cáo";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(266, 62);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTo.Size = new System.Drawing.Size(121, 20);
            this.deTo.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(208, 66);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Đến ngày:";
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(70, 62);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFrom.Size = new System.Drawing.Size(121, 20);
            this.deFrom.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 66);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Từ ngày:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kho:";
            // 
            // bteKho
            // 
            this.bteKho.Location = new System.Drawing.Point(70, 28);
            this.bteKho.Name = "bteKho";
            this.bteKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKho.Size = new System.Drawing.Size(317, 20);
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
            this.colNgayLap,
            this.colNguoiKiemKe,
            this.colSoPhieu,
            this.colKho,
            this.colMaSanPham,
            this.colTenSanPham,
            this.colSoLuong,
            this.colMaVachKhong,
            this.colMaVachCo,
            this.colGhiChu,
            this.colLoai,
            this.colNganh});
            this.grvBCKiemKe.GridControl = this.grcBCKiemKe;
            this.grvBCKiemKe.Name = "grvBCKiemKe";
            this.grvBCKiemKe.OptionsView.ColumnAutoWidth = false;
            this.grvBCKiemKe.OptionsView.ShowAutoFilterRow = true;
            // 
            // colNgayLap
            // 
            this.colNgayLap.Caption = "Ngày lập";
            this.colNgayLap.ColumnEdit = this.repNgayLap;
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 0;
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
            // colNguoiKiemKe
            // 
            this.colNguoiKiemKe.Caption = "Người kiểm kê";
            this.colNguoiKiemKe.FieldName = "TenNhanVien";
            this.colNguoiKiemKe.Name = "colNguoiKiemKe";
            this.colNguoiKiemKe.Visible = true;
            this.colNguoiKiemKe.VisibleIndex = 1;
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
            this.colSoPhieu.VisibleIndex = 2;
            this.colSoPhieu.Width = 150;
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
            this.colKho.VisibleIndex = 3;
            this.colKho.Width = 120;
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaSanPham.Caption = "Mã sản phẩm";
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.OptionsColumn.FixedWidth = true;
            this.colMaSanPham.OptionsColumn.ReadOnly = true;
            this.colMaSanPham.Visible = true;
            this.colMaSanPham.VisibleIndex = 4;
            this.colMaSanPham.Width = 100;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTenSanPham.Caption = "Tên sản phẩm";
            this.colTenSanPham.FieldName = "TenSanPham";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.OptionsColumn.AllowEdit = false;
            this.colTenSanPham.OptionsColumn.FixedWidth = true;
            this.colTenSanPham.OptionsColumn.ReadOnly = true;
            this.colTenSanPham.Visible = true;
            this.colTenSanPham.VisibleIndex = 5;
            this.colTenSanPham.Width = 300;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng ";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 6;
            // 
            // colMaVachKhong
            // 
            this.colMaVachKhong.Caption = "Mã vạch không";
            this.colMaVachKhong.FieldName = "MaVachKhong";
            this.colMaVachKhong.Name = "colMaVachKhong";
            this.colMaVachKhong.Visible = true;
            this.colMaVachKhong.VisibleIndex = 7;
            // 
            // colMaVachCo
            // 
            this.colMaVachCo.Caption = "Mã vạch có";
            this.colMaVachCo.FieldName = "MaVachCo";
            this.colMaVachCo.Name = "colMaVachCo";
            this.colMaVachCo.Visible = true;
            this.colMaVachCo.VisibleIndex = 8;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 6;
            this.colGhiChu.Width = 259;
            // 
            // colLoai
            // 
            this.colLoai.AppearanceHeader.Options.UseTextOptions = true;
            this.colLoai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLoai.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLoai.Caption = "Loại";
            this.colLoai.FieldName = "Loai";
            this.colLoai.Name = "colLoai";
            this.colLoai.OptionsColumn.FixedWidth = true;
            this.colLoai.OptionsColumn.ReadOnly = true;
            this.colLoai.Visible = true;
            this.colLoai.VisibleIndex = 8;
            this.colLoai.Width = 150;
            // 
            // colNganh
            // 
            this.colNganh.AppearanceHeader.Options.UseTextOptions = true;
            this.colNganh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNganh.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNganh.Caption = "Ngành";
            this.colNganh.FieldName = "Nganh";
            this.colNganh.Name = "colNganh";
            this.colNganh.OptionsColumn.FixedWidth = true;
            this.colNganh.OptionsColumn.ReadOnly = true;
            this.colNganh.Visible = true;
            this.colNganh.VisibleIndex = 10;
            this.colNganh.Width = 150;
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
            // frm_BaoCaoTongHopKiemKe
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
            this.Name = "frm_BaoCaoTongHopKiemKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng hợp kiểm kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoChiTietHangChuyenKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit bteKho;
        private DevExpress.XtraGrid.GridControl grcBCKiemKe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBCKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
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
        private DevExpress.XtraGrid.Columns.GridColumn colLoai;
        private DevExpress.XtraGrid.Columns.GridColumn colNganh;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVachKhong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVachCo;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiKiemKe;
    }
}