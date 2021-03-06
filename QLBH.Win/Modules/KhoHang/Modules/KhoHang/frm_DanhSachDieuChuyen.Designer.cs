namespace QLBanHang.Modules.KhoHang
{
    partial class frm_DanhSachDieuChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachDieuChuyen));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnMoPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayXuatHang = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiSua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiVanChuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiUyNhiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiKyDuyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoaDonDC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhuongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dteNgayThucHien = new System.Windows.Forms.DateTimePicker();
            this.txtSoGiaoDich = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTimKiem = new QLBH.Core.Form.GtidSimpleButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Controls.Add(this.btnMoPhieu);
            this.groupBox2.Location = new System.Drawing.Point(1, 470);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(112, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(767, 20);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnMoPhieu
            // 
            this.btnMoPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnMoPhieu.Image")));
            this.btnMoPhieu.Location = new System.Drawing.Point(11, 20);
            this.btnMoPhieu.Name = "btnMoPhieu";
            this.btnMoPhieu.ShortCutKey = System.Windows.Forms.Keys.F7;
            this.btnMoPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnMoPhieu.TabIndex = 0;
            this.btnMoPhieu.Text = "Mở phiếu(F7)";
            this.btnMoPhieu.Click += new System.EventHandler(this.btnMoPhieu_Click);
            // 
            // grcDanhSach
            // 
            this.grcDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDanhSach.Location = new System.Drawing.Point(1, 61);
            this.grcDanhSach.MainView = this.grvDanhSach;
            this.grcDanhSach.Name = "grcDanhSach";
            this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTrangThai,
            this.repNgayXuatHang,
            this.repNgayXuat});
            this.grcDanhSach.Size = new System.Drawing.Size(875, 411);
            this.grcDanhSach.TabIndex = 7;
            this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            this.grcDanhSach.Enter += new System.EventHandler(this.grcDanhSach_Enter);
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoPhieu,
            this.colNgayLap,
            this.colTrangThai,
            this.colNguoiTao,
            this.colNguoiSua,
            this.colGhiChu,
            this.colKhoXuat,
            this.colKhoNhan,
            this.colNguoiVanChuyen,
            this.colNguoiUyNhiem,
            this.colNguoiKyDuyet,
            this.colHoaDonDC,
            this.colPhuongTien,
            this.colNgayXuat});
            this.grvDanhSach.GridControl = this.grcDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.grvDanhSach.DoubleClick += new System.EventHandler(this.grvDanhSach_DoubleClick);
            this.grvDanhSach.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvDanhSach_RowCellClick);
            // 
            // colSoPhieu
            // 
            this.colSoPhieu.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPhieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoPhieu.Caption = "Số phiếu";
            this.colSoPhieu.FieldName = "SoChungTu";
            this.colSoPhieu.Name = "colSoPhieu";
            this.colSoPhieu.OptionsColumn.AllowEdit = false;
            this.colSoPhieu.OptionsColumn.FixedWidth = true;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 0;
            this.colSoPhieu.Width = 200;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayLap.Caption = "Ngày xuất";
            this.colNgayLap.ColumnEdit = this.repNgayXuatHang;
            this.colNgayLap.FieldName = "NgayNhapXuatKho";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.OptionsColumn.AllowEdit = false;
            this.colNgayLap.OptionsColumn.FixedWidth = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 1;
            this.colNgayLap.Width = 120;
            // 
            // repNgayXuatHang
            // 
            this.repNgayXuatHang.AutoHeight = false;
            this.repNgayXuatHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayXuatHang.Name = "repNgayXuatHang";
            this.repNgayXuatHang.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colTrangThai
            // 
            this.colTrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.colTrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrangThai.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.ColumnEdit = this.repTrangThai;
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowEdit = false;
            this.colTrangThai.OptionsColumn.FixedWidth = true;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 2;
            this.colTrangThai.Width = 100;
            // 
            // repTrangThai
            // 
            this.repTrangThai.AutoHeight = false;
            this.repTrangThai.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThai.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repTrangThai.DisplayMember = "Name";
            this.repTrangThai.Name = "repTrangThai";
            this.repTrangThai.NullText = "";
            this.repTrangThai.ShowFooter = false;
            this.repTrangThai.ShowHeader = false;
            this.repTrangThai.ValueMember = "Id";
            // 
            // colNguoiTao
            // 
            this.colNguoiTao.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiTao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiTao.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiTao.Caption = "Người tạo";
            this.colNguoiTao.FieldName = "NguoiTao";
            this.colNguoiTao.Name = "colNguoiTao";
            this.colNguoiTao.OptionsColumn.AllowEdit = false;
            this.colNguoiTao.OptionsColumn.FixedWidth = true;
            this.colNguoiTao.Visible = true;
            this.colNguoiTao.VisibleIndex = 3;
            this.colNguoiTao.Width = 150;
            // 
            // colNguoiSua
            // 
            this.colNguoiSua.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiSua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiSua.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiSua.Caption = "Người sửa cuối";
            this.colNguoiSua.FieldName = "NguoiSua";
            this.colNguoiSua.Name = "colNguoiSua";
            this.colNguoiSua.OptionsColumn.AllowEdit = false;
            this.colNguoiSua.OptionsColumn.FixedWidth = true;
            this.colNguoiSua.Visible = true;
            this.colNguoiSua.VisibleIndex = 4;
            this.colNguoiSua.Width = 150;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGhiChu.Caption = "Diễn giải";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 5;
            this.colGhiChu.Width = 72;
            // 
            // colKhoXuat
            // 
            this.colKhoXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKhoXuat.Caption = "Kho xuất";
            this.colKhoXuat.FieldName = "TenKho";
            this.colKhoXuat.Name = "colKhoXuat";
            this.colKhoXuat.OptionsColumn.AllowEdit = false;
            this.colKhoXuat.Visible = true;
            this.colKhoXuat.VisibleIndex = 6;
            // 
            // colKhoNhan
            // 
            this.colKhoNhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoNhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoNhan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKhoNhan.Caption = "Kho nhận";
            this.colKhoNhan.FieldName = "KhoNhan";
            this.colKhoNhan.Name = "colKhoNhan";
            this.colKhoNhan.OptionsColumn.AllowEdit = false;
            this.colKhoNhan.Visible = true;
            this.colKhoNhan.VisibleIndex = 7;
            // 
            // colNguoiVanChuyen
            // 
            this.colNguoiVanChuyen.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiVanChuyen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiVanChuyen.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiVanChuyen.Caption = "Người vận chuyển";
            this.colNguoiVanChuyen.FieldName = "NguoiVanChuyen";
            this.colNguoiVanChuyen.Name = "colNguoiVanChuyen";
            this.colNguoiVanChuyen.OptionsColumn.AllowEdit = false;
            this.colNguoiVanChuyen.Visible = true;
            this.colNguoiVanChuyen.VisibleIndex = 8;
            // 
            // colNguoiUyNhiem
            // 
            this.colNguoiUyNhiem.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiUyNhiem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiUyNhiem.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiUyNhiem.Caption = "Người ủy nhiệm";
            this.colNguoiUyNhiem.FieldName = "NguoiUyNhiem";
            this.colNguoiUyNhiem.Name = "colNguoiUyNhiem";
            this.colNguoiUyNhiem.OptionsColumn.AllowEdit = false;
            this.colNguoiUyNhiem.Visible = true;
            this.colNguoiUyNhiem.VisibleIndex = 9;
            // 
            // colNguoiKyDuyet
            // 
            this.colNguoiKyDuyet.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiKyDuyet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiKyDuyet.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiKyDuyet.Caption = "Người ký duyệt";
            this.colNguoiKyDuyet.FieldName = "NguoiKyDuyet";
            this.colNguoiKyDuyet.Name = "colNguoiKyDuyet";
            this.colNguoiKyDuyet.OptionsColumn.FixedWidth = true;
            this.colNguoiKyDuyet.OptionsColumn.ReadOnly = true;
            this.colNguoiKyDuyet.Visible = true;
            this.colNguoiKyDuyet.VisibleIndex = 10;
            this.colNguoiKyDuyet.Width = 100;
            // 
            // colHoaDonDC
            // 
            this.colHoaDonDC.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoaDonDC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoaDonDC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoaDonDC.Caption = "Hóa đơn ĐC";
            this.colHoaDonDC.FieldName = "HoaDonDC";
            this.colHoaDonDC.Name = "colHoaDonDC";
            this.colHoaDonDC.OptionsColumn.AllowEdit = false;
            this.colHoaDonDC.Visible = true;
            this.colHoaDonDC.VisibleIndex = 11;
            // 
            // colPhuongTien
            // 
            this.colPhuongTien.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhuongTien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhuongTien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhuongTien.Caption = "Phương tiện";
            this.colPhuongTien.FieldName = "PhuongTien";
            this.colPhuongTien.Name = "colPhuongTien";
            this.colPhuongTien.OptionsColumn.AllowEdit = false;
            this.colPhuongTien.Visible = true;
            this.colPhuongTien.VisibleIndex = 12;
            // 
            // colNgayXuat
            // 
            this.colNgayXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayXuat.Caption = "Ngày xuất";
            this.colNgayXuat.ColumnEdit = this.repNgayXuat;
            this.colNgayXuat.FieldName = "NgayNhapXuatKho";
            this.colNgayXuat.Name = "colNgayXuat";
            this.colNgayXuat.OptionsColumn.AllowEdit = false;
            this.colNgayXuat.OptionsColumn.ReadOnly = true;
            this.colNgayXuat.Visible = true;
            this.colNgayXuat.VisibleIndex = 13;
            this.colNgayXuat.Width = 20;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboTrangThai);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dteNgayThucHien);
            this.groupBox1.Controls.Add(this.txtSoGiaoDich);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdTimKiem);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 55);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "",
            "Khác",
            "Đã nhận"});
            this.cboTrangThai.Location = new System.Drawing.Point(505, 15);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(121, 21);
            this.cboTrangThai.TabIndex = 9;
            this.cboTrangThai.SelectedIndexChanged += new System.EventHandler(this.cboTrangThai_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Trạng thái:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ngày thực hiện";
            // 
            // dteNgayThucHien
            // 
            this.dteNgayThucHien.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteNgayThucHien.Location = new System.Drawing.Point(324, 15);
            this.dteNgayThucHien.Name = "dteNgayThucHien";
            this.dteNgayThucHien.Size = new System.Drawing.Size(97, 21);
            this.dteNgayThucHien.TabIndex = 6;
            // 
            // txtSoGiaoDich
            // 
            this.txtSoGiaoDich.Location = new System.Drawing.Point(75, 16);
            this.txtSoGiaoDich.Name = "txtSoGiaoDich";
            this.txtSoGiaoDich.Size = new System.Drawing.Size(156, 21);
            this.txtSoGiaoDich.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Số giao dịch";
            // 
            // cmdTimKiem
            // 
            this.cmdTimKiem.Location = new System.Drawing.Point(649, 15);
            this.cmdTimKiem.Name = "cmdTimKiem";
            this.cmdTimKiem.ShortCutKey = System.Windows.Forms.Keys.None;
            this.cmdTimKiem.Size = new System.Drawing.Size(95, 25);
            this.cmdTimKiem.TabIndex = 3;
            this.cmdTimKiem.Text = "Tìm Kiếm";
            this.cmdTimKiem.Click += new System.EventHandler(this.cmdTimKiem_Click);
            // 
            // frm_DanhSachDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(878, 529);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grcDanhSach);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "frm_DanhSachDieuChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phiếu xuất điều chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DanhSachPhieuNhanDieuChuyen_Load);
            this.Activated += new System.EventHandler(this.frm_DanhSachDieuChuyen_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DanhSachDieuChuyen_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private QLBH.Core.Form.GtidSimpleButton btnDong;
        private QLBH.Core.Form.GtidSimpleButton btnMoPhieu;
        private DevExpress.XtraGrid.GridControl grcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiSua;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiVanChuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiUyNhiem;
        private DevExpress.XtraGrid.Columns.GridColumn colHoaDonDC;
        private DevExpress.XtraGrid.Columns.GridColumn colPhuongTien;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuatHang;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiKyDuyet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteNgayThucHien;
        private System.Windows.Forms.TextBox txtSoGiaoDich;
        private System.Windows.Forms.Label label1;
        private QLBH.Core.Form.GtidSimpleButton cmdTimKiem;
    }
}