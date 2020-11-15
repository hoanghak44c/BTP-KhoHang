namespace QLBanHang.Modules.KhoHang
{
    partial class frm_DanhSachPhieuNhanDieuChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachPhieuNhanDieuChuyen));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnMoPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoChungTuGoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayNhap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNguoiTao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiSuaCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayNhan = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
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
            this.groupBox2.Location = new System.Drawing.Point(4, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(835, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(112, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(727, 20);
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
            this.grcDanhSach.Location = new System.Drawing.Point(4, 62);
            this.grcDanhSach.MainView = this.grvDanhSach;
            this.grcDanhSach.Name = "grcDanhSach";
            this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTrangThai,
            this.repNgayNhan,
            this.repNgayNhap,
            this.repTT});
            this.grcDanhSach.Size = new System.Drawing.Size(835, 301);
            this.grcDanhSach.TabIndex = 8;
            this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            this.grcDanhSach.Enter += new System.EventHandler(this.grcDanhSach_Enter);
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoPhieu,
            this.colSoChungTuGoc,
            this.colNgayLap,
            this.colTrangThai,
            this.colNguoiTao,
            this.colNguoiSuaCuoi,
            this.colGhiChu,
            this.colNgayNhan});
            this.grvDanhSach.GridControl = this.grcDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.grvDanhSach.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvDanhSach_CustomColumnDisplayText);
            this.grvDanhSach.DoubleClick += new System.EventHandler(this.grvDanhSach_DoubleClick);
            this.grvDanhSach.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvDanhSach_RowCellClick);
            // 
            // colSoPhieu
            // 
            this.colSoPhieu.AppearanceCell.Options.UseTextOptions = true;
            this.colSoPhieu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieu.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPhieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieu.Caption = "Số phiếu";
            this.colSoPhieu.FieldName = "SoChungTu";
            this.colSoPhieu.Name = "colSoPhieu";
            this.colSoPhieu.OptionsColumn.AllowEdit = false;
            this.colSoPhieu.OptionsColumn.FixedWidth = true;
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 0;
            this.colSoPhieu.Width = 250;
            // 
            // colSoChungTuGoc
            // 
            this.colSoChungTuGoc.AppearanceCell.Options.UseTextOptions = true;
            this.colSoChungTuGoc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoChungTuGoc.Caption = "Số chứng từ gốc";
            this.colSoChungTuGoc.FieldName = "SoChungTuGoc";
            this.colSoChungTuGoc.Name = "colSoChungTuGoc";
            this.colSoChungTuGoc.OptionsColumn.AllowEdit = false;
            this.colSoChungTuGoc.OptionsColumn.FixedWidth = true;
            this.colSoChungTuGoc.OptionsColumn.ReadOnly = true;
            this.colSoChungTuGoc.Visible = true;
            this.colSoChungTuGoc.VisibleIndex = 1;
            this.colSoChungTuGoc.Width = 250;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.Caption = "Ngày nhập";
            this.colNgayLap.ColumnEdit = this.repNgayNhap;
            this.colNgayLap.FieldName = "NgayNhapXuatKho";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.OptionsColumn.AllowEdit = false;
            this.colNgayLap.OptionsColumn.FixedWidth = true;
            this.colNgayLap.OptionsColumn.ReadOnly = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 2;
            this.colNgayLap.Width = 120;
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
            // colTrangThai
            // 
            this.colTrangThai.AppearanceCell.Options.UseTextOptions = true;
            this.colTrangThai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.colTrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.ColumnEdit = this.repTT;
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowEdit = false;
            this.colTrangThai.OptionsColumn.FixedWidth = true;
            this.colTrangThai.OptionsColumn.ReadOnly = true;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 3;
            this.colTrangThai.Width = 100;
            // 
            // repTT
            // 
            this.repTT.AutoHeight = false;
            this.repTT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repTT.DisplayMember = "Name";
            this.repTT.Name = "repTT";
            this.repTT.NullText = "";
            this.repTT.ValueMember = "Id";
            // 
            // colNguoiTao
            // 
            this.colNguoiTao.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiTao.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiTao.Caption = "Người tạo";
            this.colNguoiTao.FieldName = "NguoiTao";
            this.colNguoiTao.Name = "colNguoiTao";
            this.colNguoiTao.OptionsColumn.AllowEdit = false;
            this.colNguoiTao.OptionsColumn.FixedWidth = true;
            this.colNguoiTao.OptionsColumn.ReadOnly = true;
            this.colNguoiTao.Visible = true;
            this.colNguoiTao.VisibleIndex = 4;
            this.colNguoiTao.Width = 150;
            // 
            // colNguoiSuaCuoi
            // 
            this.colNguoiSuaCuoi.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiSuaCuoi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiSuaCuoi.Caption = "Người sửa cuối";
            this.colNguoiSuaCuoi.FieldName = "NguoiSua";
            this.colNguoiSuaCuoi.Name = "colNguoiSuaCuoi";
            this.colNguoiSuaCuoi.OptionsColumn.AllowEdit = false;
            this.colNguoiSuaCuoi.OptionsColumn.FixedWidth = true;
            this.colNguoiSuaCuoi.OptionsColumn.ReadOnly = true;
            this.colNguoiSuaCuoi.Visible = true;
            this.colNguoiSuaCuoi.VisibleIndex = 5;
            this.colNguoiSuaCuoi.Width = 150;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceCell.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.Caption = "Diễn giải";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 6;
            this.colGhiChu.Width = 20;
            // 
            // colNgayNhan
            // 
            this.colNgayNhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayNhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayNhan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayNhan.Caption = "Ngày nhận";
            this.colNgayNhan.ColumnEdit = this.repNgayNhan;
            this.colNgayNhan.FieldName = "NgayNhan";
            this.colNgayNhan.Name = "colNgayNhan";
            this.colNgayNhan.OptionsColumn.AllowEdit = false;
            this.colNgayNhan.OptionsColumn.ReadOnly = true;
            this.colNgayNhan.Visible = true;
            this.colNgayNhan.VisibleIndex = 7;
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
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(835, 51);
            this.groupBox1.TabIndex = 9;
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
            // frm_DanhSachPhieuNhanDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(844, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grcDanhSach);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "frm_DanhSachPhieuNhanDieuChuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phiếu nhận điều chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DanhSachPhieuNhanDieuChuyen_Load);
            this.Activated += new System.EventHandler(this.frm_DanhSachPhieuNhanDieuChuyen_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DanhSachPhieuNhanDieuChuyen_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colSoChungTuGoc;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiTao;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiSuaCuoi;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayNhap;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTT;
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