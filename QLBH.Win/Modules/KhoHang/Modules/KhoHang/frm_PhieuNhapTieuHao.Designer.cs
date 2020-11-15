namespace QLBanHang.Modules.KhoHang
{
    partial class frm_PhieuNhapTieuHao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuNhapTieuHao));
            this.bteTVX = new DevExpress.XtraEditors.ButtonEdit();
            this.bteTVDN = new DevExpress.XtraEditors.ButtonEdit();
            this.bteTrungTam = new DevExpress.XtraEditors.ButtonEdit();
            this.bteKho = new DevExpress.XtraEditors.ButtonEdit();
            this.grcList = new DevExpress.XtraGrid.GridControl();
            this.grvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThanhTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPhongBan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colChiPhi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChiPhi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNganh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.dteNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnInPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnCapNhat = new QLBH.Core.Form.GtidSimpleButton();
            this.btnChiTietMaVach = new QLBH.Core.Form.GtidSimpleButton();
            this.txtSoPhieu = new DevExpress.XtraEditors.ButtonEdit();
            this.repNganh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTVX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTVDN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTrungTam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChiPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNganh)).BeginInit();
            this.SuspendLayout();
            // 
            // bteTVX
            // 
            this.bteTVX.Location = new System.Drawing.Point(392, 30);
            this.bteTVX.Name = "bteTVX";
            this.bteTVX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteTVX.Size = new System.Drawing.Size(198, 20);
            this.bteTVX.TabIndex = 24;
            this.bteTVX.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteTVX_ButtonClick);
            this.bteTVX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteTVX_KeyDown);
            this.bteTVX.TextChanged += new System.EventHandler(this.bteTVX_TextChanged);
            // 
            // bteTVDN
            // 
            this.bteTVDN.Location = new System.Drawing.Point(392, 4);
            this.bteTVDN.Name = "bteTVDN";
            this.bteTVDN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteTVDN.Size = new System.Drawing.Size(198, 20);
            this.bteTVDN.TabIndex = 21;
            // 
            // bteTrungTam
            // 
            this.bteTrungTam.Location = new System.Drawing.Point(667, 4);
            this.bteTrungTam.Name = "bteTrungTam";
            this.bteTrungTam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteTrungTam.Size = new System.Drawing.Size(210, 20);
            this.bteTrungTam.TabIndex = 22;
            // 
            // bteKho
            // 
            this.bteKho.Location = new System.Drawing.Point(667, 30);
            this.bteKho.Name = "bteKho";
            this.bteKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKho.Size = new System.Drawing.Size(210, 20);
            this.bteKho.TabIndex = 25;
            // 
            // grcList
            // 
            this.grcList.Location = new System.Drawing.Point(7, 82);
            this.grcList.MainView = this.grvList;
            this.grcList.Name = "grcList";
            this.grcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repChiPhi,
            this.repPhongBan,
            this.repNganh});
            this.grcList.Size = new System.Drawing.Size(870, 312);
            this.grcList.TabIndex = 26;
            this.grcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvList});
            this.grcList.DoubleClick += new System.EventHandler(this.grcList_DoubleClick);
            this.grcList.Enter += new System.EventHandler(this.grcList_Enter);
            // 
            // grvList
            // 
            this.grvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaSanPham,
            this.colTenSanPham,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien,
            this.colPhongBan,
            this.colChiPhi,
            this.colNganh});
            this.grvList.GridControl = this.grcList;
            this.grvList.Name = "grvList";
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaSanPham.Caption = "Mã sản phẩm";
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.OptionsColumn.ReadOnly = true;
            this.colMaSanPham.Visible = true;
            this.colMaSanPham.VisibleIndex = 0;
            this.colMaSanPham.Width = 110;
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
            this.colTenSanPham.OptionsColumn.AllowFocus = false;
            this.colTenSanPham.OptionsColumn.ReadOnly = true;
            this.colTenSanPham.Visible = true;
            this.colTenSanPham.VisibleIndex = 1;
            this.colTenSanPham.Width = 110;
            // 
            // colSoLuong
            // 
            this.colSoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsColumn.AllowEdit = false;
            this.colSoLuong.OptionsColumn.AllowFocus = false;
            this.colSoLuong.OptionsColumn.ReadOnly = true;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 2;
            this.colSoLuong.Width = 110;
            // 
            // colDonGia
            // 
            this.colDonGia.AppearanceHeader.Options.UseTextOptions = true;
            this.colDonGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDonGia.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDonGia.Caption = "Đơn giá";
            this.colDonGia.FieldName = "DonGia";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.OptionsColumn.AllowEdit = false;
            this.colDonGia.OptionsColumn.AllowFocus = false;
            this.colDonGia.OptionsColumn.ReadOnly = true;
            this.colDonGia.Visible = true;
            this.colDonGia.VisibleIndex = 3;
            this.colDonGia.Width = 110;
            // 
            // colThanhTien
            // 
            this.colThanhTien.AppearanceHeader.Options.UseTextOptions = true;
            this.colThanhTien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThanhTien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThanhTien.Caption = "Thành tiền";
            this.colThanhTien.FieldName = "ThanhTien";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.OptionsColumn.AllowEdit = false;
            this.colThanhTien.OptionsColumn.AllowFocus = false;
            this.colThanhTien.OptionsColumn.ReadOnly = true;
            this.colThanhTien.Visible = true;
            this.colThanhTien.VisibleIndex = 4;
            this.colThanhTien.Width = 110;
            // 
            // colPhongBan
            // 
            this.colPhongBan.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhongBan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhongBan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhongBan.Caption = "Phòng ban";
            this.colPhongBan.ColumnEdit = this.repPhongBan;
            this.colPhongBan.FieldName = "IdPhongBan";
            this.colPhongBan.Name = "colPhongBan";
            this.colPhongBan.OptionsColumn.AllowEdit = false;
            this.colPhongBan.OptionsColumn.AllowFocus = false;
            this.colPhongBan.OptionsColumn.ReadOnly = true;
            this.colPhongBan.Visible = true;
            this.colPhongBan.VisibleIndex = 5;
            this.colPhongBan.Width = 110;
            // 
            // repPhongBan
            // 
            this.repPhongBan.AutoHeight = false;
            this.repPhongBan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPhongBan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenPhongBan", "Name")});
            this.repPhongBan.DisplayMember = "TenPhongBan";
            this.repPhongBan.Name = "repPhongBan";
            this.repPhongBan.NullText = "";
            this.repPhongBan.ValueMember = "IdPhongBan";
            // 
            // colChiPhi
            // 
            this.colChiPhi.AppearanceHeader.Options.UseTextOptions = true;
            this.colChiPhi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChiPhi.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colChiPhi.Caption = "Chi phí";
            this.colChiPhi.ColumnEdit = this.repChiPhi;
            this.colChiPhi.FieldName = "IdChiPhi";
            this.colChiPhi.Name = "colChiPhi";
            this.colChiPhi.OptionsColumn.AllowEdit = false;
            this.colChiPhi.OptionsColumn.AllowFocus = false;
            this.colChiPhi.OptionsColumn.ReadOnly = true;
            this.colChiPhi.Visible = true;
            this.colChiPhi.VisibleIndex = 6;
            this.colChiPhi.Width = 114;
            // 
            // repChiPhi
            // 
            this.repChiPhi.AutoHeight = false;
            this.repChiPhi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repChiPhi.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Name")});
            this.repChiPhi.DisplayMember = "Ten";
            this.repChiPhi.Name = "repChiPhi";
            this.repChiPhi.NullText = "";
            this.repChiPhi.ValueMember = "IdChiPhi";
            // 
            // colNganh
            // 
            this.colNganh.AppearanceHeader.Options.UseTextOptions = true;
            this.colNganh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNganh.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNganh.Caption = "Ngành";
            this.colNganh.ColumnEdit = this.repNganh;
            this.colNganh.FieldName = "Nganh";
            this.colNganh.Name = "colNganh";
            this.colNganh.OptionsColumn.FixedWidth = true;
            this.colNganh.OptionsColumn.ReadOnly = true;
            this.colNganh.Visible = true;
            this.colNganh.VisibleIndex = 7;
            this.colNganh.Width = 150;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(596, 7);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 13);
            this.labelControl6.TabIndex = 36;
            this.labelControl6.Text = "Trung tâm HT";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(596, 33);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(45, 13);
            this.labelControl5.TabIndex = 39;
            this.labelControl5.Text = "Kho nhập";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(288, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(98, 13);
            this.labelControl4.TabIndex = 38;
            this.labelControl4.Text = "Thương viên đề nghị";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(288, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Thương viên xuất";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Ghi chú";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Số phiếu";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(54, 56);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(823, 20);
            this.txtGhiChu.TabIndex = 23;
            // 
            // dteNgay
            // 
            this.dteNgay.EditValue = new System.DateTime(2013, 6, 9, 15, 24, 46, 440);
            this.dteNgay.Location = new System.Drawing.Point(54, 30);
            this.dteNgay.Name = "dteNgay";
            this.dteNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dteNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dteNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteNgay.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dteNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteNgay.Size = new System.Drawing.Size(232, 20);
            this.dteNgay.TabIndex = 41;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 32);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(25, 13);
            this.labelControl7.TabIndex = 40;
            this.labelControl7.Text = "Ngày";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieu.Image")));
            this.btnInPhieu.Location = new System.Drawing.Point(108, 400);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.ShortCutKey = System.Windows.Forms.Keys.F11;
            this.btnInPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnInPhieu.TabIndex = 45;
            this.btnInPhieu.Text = "In phiếu(F11)";
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(782, 400);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.Escape;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 47;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(681, 400);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnCapNhat.Size = new System.Drawing.Size(95, 25);
            this.btnCapNhat.TabIndex = 46;
            this.btnCapNhat.Text = "Cập nhật(F2)";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTietMaVach.Image")));
            this.btnChiTietMaVach.Location = new System.Drawing.Point(7, 400);
            this.btnChiTietMaVach.Name = "btnChiTietMaVach";
            this.btnChiTietMaVach.ShortCutKey = System.Windows.Forms.Keys.F7;
            this.btnChiTietMaVach.Size = new System.Drawing.Size(95, 25);
            this.btnChiTietMaVach.TabIndex = 44;
            this.btnChiTietMaVach.Text = "Chi tiết(F7)";
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTiet_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(54, 4);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)});
            this.txtSoPhieu.Properties.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(232, 20);
            this.txtSoPhieu.TabIndex = 48;
            // 
            // repNganh
            // 
            this.repNganh.AutoHeight = false;
            this.repNganh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNganh.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ten", "Ten")});
            this.repNganh.DisplayMember = "Ten";
            this.repNganh.Name = "repNganh";
            this.repNganh.NullText = "";
            this.repNganh.ValueMember = "Ma";
            // 
            // frm_PhieuNhapTieuHao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 430);
            this.Controls.Add(this.txtSoPhieu);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnChiTietMaVach);
            this.Controls.Add(this.dteNgay);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.bteTVX);
            this.Controls.Add(this.bteTVDN);
            this.Controls.Add(this.bteTrungTam);
            this.Controls.Add(this.bteKho);
            this.Controls.Add(this.grcList);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtGhiChu);
            this.KeyPreview = true;
            this.Name = "frm_PhieuNhapTieuHao";
            this.Text = "Phiếu nhập tiêu hao";
            this.Load += new System.EventHandler(this.frm_PhieuNhapTieuHao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PhieuNhapTieuHao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bteTVX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTVDN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteTrungTam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChiPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNganh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit bteTVX;
        private DevExpress.XtraEditors.ButtonEdit bteTVDN;
        private DevExpress.XtraEditors.ButtonEdit bteTrungTam;
        private DevExpress.XtraEditors.ButtonEdit bteKho;
        private DevExpress.XtraGrid.GridControl grcList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvList;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colDonGia;
        private DevExpress.XtraGrid.Columns.GridColumn colThanhTien;
        private DevExpress.XtraGrid.Columns.GridColumn colPhongBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colChiPhi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repChiPhi;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtGhiChu;
        private DevExpress.XtraEditors.DateEdit dteNgay;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public QLBH.Core.Form.GtidSimpleButton btnInPhieu;
        protected QLBH.Core.Form.GtidSimpleButton btnDong;
        protected QLBH.Core.Form.GtidSimpleButton btnCapNhat;
        public QLBH.Core.Form.GtidSimpleButton btnChiTietMaVach;
        protected DevExpress.XtraEditors.ButtonEdit txtSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNganh;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repNganh;
    }
}