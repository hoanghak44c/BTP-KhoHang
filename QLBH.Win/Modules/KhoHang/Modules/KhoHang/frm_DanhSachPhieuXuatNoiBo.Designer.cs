namespace QLBanHang.Modules.KhoHang
{
    partial class frm_DanhSachPhieuXuatNoiBo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachPhieuXuatNoiBo));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoaPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnThemPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnMoPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLyDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnXoaPhieu);
            this.groupBox2.Controls.Add(this.btnThemPhieu);
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Controls.Add(this.btnMoPhieu);
            this.groupBox2.Location = new System.Drawing.Point(12, 345);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(738, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPhieu.Image")));
            this.btnXoaPhieu.Location = new System.Drawing.Point(213, 20);
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
            this.btnDong.Location = new System.Drawing.Point(630, 20);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnMoPhieu
            // 
            this.btnMoPhieu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.grcDanhSach.Location = new System.Drawing.Point(12, 12);
            this.grcDanhSach.MainView = this.grvDanhSach;
            this.grcDanhSach.Name = "grcDanhSach";
            this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repTrangThai});
            this.grcDanhSach.Size = new System.Drawing.Size(738, 327);
            this.grcDanhSach.TabIndex = 3;
            this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoPhieu,
            this.colNhaCC,
            this.colLyDo,
            this.colSoPO,
            this.colSoRE,
            this.colNgayLap,
            this.colTrangThai,
            this.colKho,
            this.colGhiChu});
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
            this.colSoPhieu.Caption = "Số phiếu";
            this.colSoPhieu.FieldName = "SoChungTu";
            this.colSoPhieu.Name = "colSoPhieu";
            this.colSoPhieu.OptionsColumn.AllowEdit = false;
            this.colSoPhieu.OptionsColumn.FixedWidth = true;
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 0;
            this.colSoPhieu.Width = 200;
            // 
            // colNhaCC
            // 
            this.colNhaCC.AppearanceHeader.Options.UseTextOptions = true;
            this.colNhaCC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhaCC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNhaCC.Caption = "Nhà cung cấp";
            this.colNhaCC.FieldName = "TenDoiTuong";
            this.colNhaCC.Name = "colNhaCC";
            this.colNhaCC.OptionsColumn.AllowEdit = false;
            this.colNhaCC.OptionsColumn.FixedWidth = true;
            this.colNhaCC.OptionsColumn.ReadOnly = true;
            this.colNhaCC.Visible = true;
            this.colNhaCC.VisibleIndex = 1;
            this.colNhaCC.Width = 250;
            // 
            // colLyDo
            // 
            this.colLyDo.AppearanceHeader.Options.UseTextOptions = true;
            this.colLyDo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLyDo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLyDo.Caption = "Lý do giao dịch";
            this.colLyDo.FieldName = "LyDoTraHang";
            this.colLyDo.Name = "colLyDo";
            this.colLyDo.OptionsColumn.AllowEdit = false;
            this.colLyDo.OptionsColumn.FixedWidth = true;
            this.colLyDo.OptionsColumn.ReadOnly = true;
            this.colLyDo.Visible = true;
            this.colLyDo.VisibleIndex = 2;
            this.colLyDo.Width = 150;
            // 
            // colSoPO
            // 
            this.colSoPO.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPO.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoPO.Caption = "Số PO";
            this.colSoPO.FieldName = "SoPO";
            this.colSoPO.Name = "colSoPO";
            this.colSoPO.OptionsColumn.AllowEdit = false;
            this.colSoPO.OptionsColumn.FixedWidth = true;
            this.colSoPO.OptionsColumn.ReadOnly = true;
            this.colSoPO.Visible = true;
            this.colSoPO.VisibleIndex = 3;
            this.colSoPO.Width = 100;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.Caption = "Ngày lập";
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.OptionsColumn.AllowEdit = false;
            this.colNgayLap.OptionsColumn.FixedWidth = true;
            this.colNgayLap.OptionsColumn.ReadOnly = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 5;
            this.colNgayLap.Width = 120;
            // 
            // colTrangThai
            // 
            this.colTrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.colTrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.ColumnEdit = this.repTrangThai;
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowEdit = false;
            this.colTrangThai.OptionsColumn.FixedWidth = true;
            this.colTrangThai.OptionsColumn.ReadOnly = true;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 6;
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
            // colKho
            // 
            this.colKho.AppearanceHeader.Options.UseTextOptions = true;
            this.colKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKho.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKho.Caption = "Kho";
            this.colKho.FieldName = "MaKho";
            this.colKho.Name = "colKho";
            this.colKho.OptionsColumn.FixedWidth = true;
            this.colKho.OptionsColumn.ReadOnly = true;
            this.colKho.Visible = true;
            this.colKho.VisibleIndex = 7;
            this.colKho.Width = 150;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.Caption = "Diễn giải";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 8;
            this.colGhiChu.Width = 20;
            // 
            // colSoRE
            // 
            this.colSoRE.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoRE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoRE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoRE.Caption = "Số RE";
            this.colSoRE.FieldName = "SoRE";
            this.colSoRE.Name = "colSoRE";
            this.colSoRE.OptionsColumn.AllowEdit = false;
            this.colSoRE.OptionsColumn.FixedWidth = true;
            this.colSoRE.OptionsColumn.ReadOnly = true;
            this.colSoRE.Visible = true;
            this.colSoRE.VisibleIndex = 4;
            this.colSoRE.Width = 100;
            // 
            // frm_DanhSachPhieuXuatNoiBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(762, 410);
            this.Controls.Add(this.grcDanhSach);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "frm_DanhSachPhieuXuatNoiBo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Phiếu Xuất Nội Bộ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DanhSachPhieuXuatNoiBo_Load);
            this.Enter += new System.EventHandler(this.frm_DanhSachPhieuXuatNoiBo_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DanhSachPhieuXuatNoiBo_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCC;
        private DevExpress.XtraGrid.Columns.GridColumn colLyDo;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPO;
        private DevExpress.XtraGrid.Columns.GridColumn colKho;
        private DevExpress.XtraGrid.Columns.GridColumn colSoRE;
    }
}