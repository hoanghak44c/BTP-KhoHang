namespace QLBanHang.Modules.KhoHang
{
    partial class frm_DanhSachPhieuDeNghiXuatDieuChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachPhieuDeNghiXuatDieuChuyen));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new QLBH.Core.Form.GtidSimpleButton();
            this.btnXoaPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnThemPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnMoPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayLap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiSuaCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoDi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoNhanCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiVanChuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiUyNhiem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiKyDuyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoaDonDC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhuongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTongTienHang = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap.VistaTimeProperties)).BeginInit();
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
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnXoaPhieu);
            this.groupBox2.Controls.Add(this.btnThemPhieu);
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Controls.Add(this.btnMoPhieu);
            this.groupBox2.Location = new System.Drawing.Point(1, 483);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(885, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(415, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(213, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ShortCutKey = System.Windows.Forms.Keys.F6;
            this.btnEdit.Size = new System.Drawing.Size(95, 25);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Sửa(F6)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPhieu.Image")));
            this.btnXoaPhieu.Location = new System.Drawing.Point(314, 20);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.ShortCutKey = System.Windows.Forms.Keys.F8;
            this.btnXoaPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnXoaPhieu.TabIndex = 2;
            this.btnXoaPhieu.Text = "Xóa phiếu(F8)";
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // btnThemPhieu
            // 
            this.btnThemPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnThemPhieu.Image")));
            this.btnThemPhieu.Location = new System.Drawing.Point(112, 20);
            this.btnThemPhieu.Name = "btnThemPhieu";
            this.btnThemPhieu.ShortCutKey = System.Windows.Forms.Keys.F3;
            this.btnThemPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnThemPhieu.TabIndex = 1;
            this.btnThemPhieu.Text = "Thêm phiếu(F3)";
            this.btnThemPhieu.Click += new System.EventHandler(this.btnThemPhieu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(777, 20);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 3;
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
            this.grcDanhSach.Location = new System.Drawing.Point(1, 63);
            this.grcDanhSach.MainView = this.grvDanhSach;
            this.grcDanhSach.Name = "grcDanhSach";
            this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repNgayLap,
            this.repNgayXuat});
            this.grcDanhSach.Size = new System.Drawing.Size(885, 420);
            this.grcDanhSach.TabIndex = 4;
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
            this.colNguoiSuaCuoi,
            this.colKhoDi,
            this.colKhoNhan,
            this.colKhoNhanCuoi,
            this.colNguoiVanChuyen,
            this.colNguoiUyNhiem,
            this.colNguoiKyDuyet,
            this.colHoaDonDC,
            this.colPhuongTien,
            this.colGhiChu,
            this.colNgayXuat,
            this.colTongTienHang});
            this.grvDanhSach.GridControl = this.grcDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsView.ColumnAutoWidth = false;
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
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 0;
            this.colSoPhieu.Width = 108;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayLap.Caption = "Ngày lập";
            this.colNgayLap.ColumnEdit = this.repNgayLap;
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.OptionsColumn.AllowEdit = false;
            this.colNgayLap.OptionsColumn.FixedWidth = true;
            this.colNgayLap.OptionsColumn.ReadOnly = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 1;
            this.colNgayLap.Width = 120;
            // 
            // repNgayLap
            // 
            this.repNgayLap.AutoHeight = false;
            this.repNgayLap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayLap.Name = "repNgayLap";
            this.repNgayLap.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colTrangThai
            // 
            this.colTrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.colTrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrangThai.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.FieldName = "Description";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowEdit = false;
            this.colTrangThai.OptionsColumn.FixedWidth = true;
            this.colTrangThai.OptionsColumn.ReadOnly = true;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 2;
            this.colTrangThai.Width = 100;
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
            this.colNguoiTao.OptionsColumn.ReadOnly = true;
            this.colNguoiTao.Visible = true;
            this.colNguoiTao.VisibleIndex = 3;
            this.colNguoiTao.Width = 93;
            // 
            // colNguoiSuaCuoi
            // 
            this.colNguoiSuaCuoi.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiSuaCuoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiSuaCuoi.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiSuaCuoi.Caption = "Người sửa cuối";
            this.colNguoiSuaCuoi.FieldName = "NguoiSua";
            this.colNguoiSuaCuoi.Name = "colNguoiSuaCuoi";
            this.colNguoiSuaCuoi.OptionsColumn.AllowEdit = false;
            this.colNguoiSuaCuoi.OptionsColumn.FixedWidth = true;
            this.colNguoiSuaCuoi.OptionsColumn.ReadOnly = true;
            this.colNguoiSuaCuoi.Visible = true;
            this.colNguoiSuaCuoi.VisibleIndex = 4;
            this.colNguoiSuaCuoi.Width = 97;
            // 
            // colKhoDi
            // 
            this.colKhoDi.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoDi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoDi.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKhoDi.Caption = "Kho xuất";
            this.colKhoDi.FieldName = "TenKho";
            this.colKhoDi.Name = "colKhoDi";
            this.colKhoDi.Visible = true;
            this.colKhoDi.VisibleIndex = 6;
            this.colKhoDi.Width = 72;
            // 
            // colKhoNhan
            // 
            this.colKhoNhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoNhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoNhan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKhoNhan.Caption = "Kho Nhận";
            this.colKhoNhan.FieldName = "KhoNhan";
            this.colKhoNhan.Name = "colKhoNhan";
            this.colKhoNhan.Visible = true;
            this.colKhoNhan.VisibleIndex = 7;
            this.colKhoNhan.Width = 74;
            // 
            // colKhoNhanCuoi
            // 
            this.colKhoNhanCuoi.Caption = "Kho nhận cuối";
            this.colKhoNhanCuoi.FieldName = "KhoNhanCuoi";
            this.colKhoNhanCuoi.Name = "colKhoNhanCuoi";
            this.colKhoNhanCuoi.Visible = true;
            this.colKhoNhanCuoi.VisibleIndex = 8;
            // 
            // colNguoiVanChuyen
            // 
            this.colNguoiVanChuyen.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiVanChuyen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiVanChuyen.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiVanChuyen.Caption = "Người Vận Chuyển";
            this.colNguoiVanChuyen.FieldName = "NguoiVanChuyen";
            this.colNguoiVanChuyen.Name = "colNguoiVanChuyen";
            this.colNguoiVanChuyen.Visible = true;
            this.colNguoiVanChuyen.VisibleIndex = 9;
            this.colNguoiVanChuyen.Width = 81;
            // 
            // colNguoiUyNhiem
            // 
            this.colNguoiUyNhiem.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiUyNhiem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiUyNhiem.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiUyNhiem.Caption = "Người Ủy Nhiệm";
            this.colNguoiUyNhiem.FieldName = "NguoiUyNhiem";
            this.colNguoiUyNhiem.Name = "colNguoiUyNhiem";
            this.colNguoiUyNhiem.Visible = true;
            this.colNguoiUyNhiem.VisibleIndex = 10;
            this.colNguoiUyNhiem.Width = 63;
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
            this.colNguoiKyDuyet.VisibleIndex = 11;
            this.colNguoiKyDuyet.Width = 65;
            // 
            // colHoaDonDC
            // 
            this.colHoaDonDC.AppearanceHeader.Options.UseTextOptions = true;
            this.colHoaDonDC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHoaDonDC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHoaDonDC.Caption = "Hóa đơn ĐC";
            this.colHoaDonDC.FieldName = "HoaDonDC";
            this.colHoaDonDC.Name = "colHoaDonDC";
            this.colHoaDonDC.Visible = true;
            this.colHoaDonDC.VisibleIndex = 12;
            this.colHoaDonDC.Width = 51;
            // 
            // colPhuongTien
            // 
            this.colPhuongTien.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhuongTien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhuongTien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhuongTien.Caption = "Phương tiện";
            this.colPhuongTien.FieldName = "PhuongTien";
            this.colPhuongTien.Name = "colPhuongTien";
            this.colPhuongTien.Visible = true;
            this.colPhuongTien.VisibleIndex = 13;
            this.colPhuongTien.Width = 57;
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
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 5;
            this.colGhiChu.Width = 89;
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
            this.colNgayXuat.VisibleIndex = 14;
            this.colNgayXuat.Width = 77;
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
            // colTongTienHang
            // 
            this.colTongTienHang.Caption = "Tổng tiền hàng";
            this.colTongTienHang.FieldName = "TongTienHang";
            this.colTongTienHang.Name = "colTongTienHang";
            this.colTongTienHang.Visible = true;
            this.colTongTienHang.VisibleIndex = 15;
            this.colTongTienHang.Width = 85;
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
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 55);
            this.groupBox1.TabIndex = 5;
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
            // frm_DanhSachPhieuDeNghiXuatDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(888, 542);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grcDanhSach);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "frm_DanhSachPhieuDeNghiXuatDieuChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phiếu đề nghị điều chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DanhSachPhieuDieuChuyen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DanhSachDeNghiDieuChuyen_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap)).EndInit();
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
        private QLBH.Core.Form.GtidSimpleButton btnXoaPhieu;
        private QLBH.Core.Form.GtidSimpleButton btnThemPhieu;
        private DevExpress.XtraGrid.GridControl grcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiSuaCuoi;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoDi;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiVanChuyen;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiUyNhiem;
        private DevExpress.XtraGrid.Columns.GridColumn colHoaDonDC;
        private DevExpress.XtraGrid.Columns.GridColumn colPhuongTien;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiKyDuyet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private QLBH.Core.Form.GtidSimpleButton cmdTimKiem;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dteNgayThucHien;
        private System.Windows.Forms.TextBox txtSoGiaoDich;
        private QLBH.Core.Form.GtidSimpleButton btnEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTienHang;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoNhanCuoi;
    }
}