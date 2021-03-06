namespace QLBanHang.Modules.KhoHang
{
    partial class frm_DanhSachPhieuKiemKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachPhieuKiemKe));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new QLBH.Core.Form.GtidSimpleButton();
            this.btnXoaPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnThemMoi = new QLBH.Core.Form.GtidSimpleButton();
            this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDotKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoThucHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThaiKiemKe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThai = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Controls.Add(this.btnXoaPhieu);
            this.groupBox2.Controls.Add(this.btnThemMoi);
            this.groupBox2.Location = new System.Drawing.Point(2, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 55);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(653, 20);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ShortCutKey = System.Windows.Forms.Keys.F8;
            this.btnThoat.Size = new System.Drawing.Size(95, 25);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát(ESC)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoaPhieu
            // 
            this.btnXoaPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaPhieu.Image")));
            this.btnXoaPhieu.Location = new System.Drawing.Point(111, 24);
            this.btnXoaPhieu.Name = "btnXoaPhieu";
            this.btnXoaPhieu.ShortCutKey = System.Windows.Forms.Keys.F8;
            this.btnXoaPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnXoaPhieu.TabIndex = 0;
            this.btnXoaPhieu.Text = "Xóa(F8)";
            this.btnXoaPhieu.Click += new System.EventHandler(this.btnXoaPhieu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnThemMoi.Image")));
            this.btnThemMoi.Location = new System.Drawing.Point(10, 24);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.ShortCutKey = System.Windows.Forms.Keys.F3;
            this.btnThemMoi.Size = new System.Drawing.Size(95, 25);
            this.btnThemMoi.TabIndex = 1;
            this.btnThemMoi.Text = "Thêm mới(F3)";
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
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
            this.repTrangThai,
            this.repTrangThaiKiemKe});
            this.grcDanhSach.Size = new System.Drawing.Size(738, 313);
            this.grcDanhSach.TabIndex = 4;
            this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDotKiemKe,
            this.colSoPhieu,
            this.colNgayKiemKe,
            this.colKhoThucHien,
            this.colTrangThai,
            this.colGhiChu});
            this.grvDanhSach.GridControl = this.grcDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsView.ShowAutoFilterRow = true;
            this.grvDanhSach.DoubleClick += new System.EventHandler(this.grvDanhSach_DoubleClick);
            this.grvDanhSach.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvDanhSach_RowCellClick);
            // 
            // colDotKiemKe
            // 
            this.colDotKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.colDotKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDotKiemKe.Caption = "Đợt kiểm kê";
            this.colDotKiemKe.FieldName = "MaDotKiemKe";
            this.colDotKiemKe.Name = "colDotKiemKe";
            this.colDotKiemKe.OptionsColumn.AllowEdit = false;
            this.colDotKiemKe.OptionsColumn.FixedWidth = true;
            this.colDotKiemKe.OptionsColumn.ReadOnly = true;
            this.colDotKiemKe.Visible = true;
            this.colDotKiemKe.VisibleIndex = 0;
            this.colDotKiemKe.Width = 100;
            // 
            // colSoPhieu
            // 
            this.colSoPhieu.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPhieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieu.Caption = "Số phiếu";
            this.colSoPhieu.FieldName = "SoPhieu";
            this.colSoPhieu.Name = "colSoPhieu";
            this.colSoPhieu.OptionsColumn.AllowEdit = false;
            this.colSoPhieu.OptionsColumn.FixedWidth = true;
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colSoPhieu.Visible = true;
            this.colSoPhieu.VisibleIndex = 1;
            this.colSoPhieu.Width = 100;
            // 
            // colNgayKiemKe
            // 
            this.colNgayKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayKiemKe.Caption = "Ngày thực hiện";
            this.colNgayKiemKe.FieldName = "NgayKiemKe";
            this.colNgayKiemKe.Name = "colNgayKiemKe";
            this.colNgayKiemKe.OptionsColumn.AllowEdit = false;
            this.colNgayKiemKe.OptionsColumn.FixedWidth = true;
            this.colNgayKiemKe.OptionsColumn.ReadOnly = true;
            this.colNgayKiemKe.Visible = true;
            this.colNgayKiemKe.VisibleIndex = 2;
            this.colNgayKiemKe.Width = 100;
            // 
            // colKhoThucHien
            // 
            this.colKhoThucHien.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoThucHien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoThucHien.Caption = "Kho thực hiện";
            this.colKhoThucHien.FieldName = "TenKho";
            this.colKhoThucHien.Name = "colKhoThucHien";
            this.colKhoThucHien.OptionsColumn.AllowEdit = false;
            this.colKhoThucHien.OptionsColumn.FixedWidth = true;
            this.colKhoThucHien.OptionsColumn.ReadOnly = true;
            this.colKhoThucHien.Visible = true;
            this.colKhoThucHien.VisibleIndex = 3;
            this.colKhoThucHien.Width = 150;
            // 
            // colTrangThai
            // 
            this.colTrangThai.AppearanceHeader.Options.UseTextOptions = true;
            this.colTrangThai.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.ColumnEdit = this.repTrangThaiKiemKe;
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.OptionsColumn.AllowEdit = false;
            this.colTrangThai.OptionsColumn.FixedWidth = true;
            this.colTrangThai.OptionsColumn.ReadOnly = true;
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 4;
            this.colTrangThai.Width = 100;
            // 
            // repTrangThaiKiemKe
            // 
            this.repTrangThaiKiemKe.AutoHeight = false;
            this.repTrangThaiKiemKe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repTrangThaiKiemKe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repTrangThaiKiemKe.DisplayMember = "Name";
            this.repTrangThaiKiemKe.Name = "repTrangThaiKiemKe";
            this.repTrangThaiKiemKe.NullText = "";
            this.repTrangThaiKiemKe.ValueMember = "OID";
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
            this.colGhiChu.VisibleIndex = 5;
            this.colGhiChu.Width = 167;
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
            // frm_DanhSachPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 392);
            this.Controls.Add(this.grcDanhSach);
            this.Controls.Add(this.groupBox2);
            this.KeyPreview = true;
            this.Name = "frm_DanhSachPhieuKiemKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phiếu kiểm kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_DanhSachPhieuKiemKe_Load);
            this.Activated += new System.EventHandler(this.frm_DanhSachPhieuKiemKe_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_DanhSachPhieuKiemKe_KeyDown);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private QLBH.Core.Form.GtidSimpleButton btnXoaPhieu;
        private QLBH.Core.Form.GtidSimpleButton btnThemMoi;
        private DevExpress.XtraGrid.GridControl grcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colDotKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayKiemKe;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoThucHien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThai;
        private QLBH.Core.Form.GtidSimpleButton btnThoat;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiKiemKe;
    }
}