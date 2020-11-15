namespace QLBanHang.Modules.KhoHang
{
    partial class frm_BaoCaoTonTrungChuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BaoCaoTonTrungChuyen));
            this.grcBCKiemKe = new DevExpress.XtraGrid.GridControl();
            this.grvBCKiemKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKhoXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNganh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThaiXuat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repTrangThaiNhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repLoaiGiaoDich = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repNgayNhan = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayLap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayNhap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdExport = new QLBH.Core.Form.GtidButton();
            ((System.ComponentModel.ISupportInitialize)(this.grcBCKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiGiaoDich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap.VistaTimeProperties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.grcBCKiemKe.Location = new System.Drawing.Point(12, 57);
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
            this.grcBCKiemKe.Size = new System.Drawing.Size(518, 333);
            this.grcBCKiemKe.TabIndex = 8;
            this.grcBCKiemKe.UseEmbeddedNavigator = true;
            this.grcBCKiemKe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBCKiemKe});
            // 
            // grvBCKiemKe
            // 
            this.grvBCKiemKe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKhoXuat,
            this.colMaSanPham,
            this.colTenSanPham,
            this.colNganh,
            this.colSoLuong,
            this.colKhoNhan});
            this.grvBCKiemKe.GridControl = this.grcBCKiemKe;
            this.grvBCKiemKe.Name = "grvBCKiemKe";
            this.grvBCKiemKe.OptionsView.ShowAutoFilterRow = true;
            // 
            // colKhoXuat
            // 
            this.colKhoXuat.Caption = "Kho xuất";
            this.colKhoXuat.FieldName = "KhoXuat";
            this.colKhoXuat.Name = "colKhoXuat";
            this.colKhoXuat.Visible = true;
            this.colKhoXuat.VisibleIndex = 0;
            this.colKhoXuat.Width = 55;
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.Caption = "Mã Sản Phẩm";
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.Visible = true;
            this.colMaSanPham.VisibleIndex = 1;
            this.colMaSanPham.Width = 76;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.Caption = "Tên sản phẩm";
            this.colTenSanPham.FieldName = "TenSanPham";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.Visible = true;
            this.colTenSanPham.VisibleIndex = 2;
            this.colTenSanPham.Width = 79;
            // 
            // colNganh
            // 
            this.colNganh.Caption = "Ngành";
            this.colNganh.FieldName = "Nganh";
            this.colNganh.Name = "colNganh";
            this.colNganh.Visible = true;
            this.colNganh.VisibleIndex = 3;
            this.colNganh.Width = 43;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 4;
            this.colSoLuong.Width = 54;
            // 
            // colKhoNhan
            // 
            this.colKhoNhan.Caption = "Điều chuyển về kho";
            this.colKhoNhan.FieldName = "KhoNhan";
            this.colKhoNhan.Name = "colKhoNhan";
            this.colKhoNhan.Visible = true;
            this.colKhoNhan.VisibleIndex = 5;
            this.colKhoNhan.Width = 107;
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
            // repNgayNhap
            // 
            this.repNgayNhap.AutoHeight = false;
            this.repNgayNhap.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayNhap.Name = "repNgayNhap";
            this.repNgayNhap.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmdExport);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 51);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Image = ((System.Drawing.Image)(resources.GetObject("cmdExport.Image")));
            this.cmdExport.Location = new System.Drawing.Point(407, 12);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.ShortCutKey = System.Windows.Forms.Keys.None;
            this.cmdExport.Size = new System.Drawing.Size(105, 27);
            this.cmdExport.TabIndex = 60;
            this.cmdExport.Text = "Export";
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // frm_BaoCaoTonTrungChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 402);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grcBCKiemKe);
            this.Name = "frm_BaoCaoTonTrungChuyen";
            this.Text = "Báo cáo tồn trung chuyển";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoTonTrungChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcBCKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBCKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTrangThaiNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLoaiGiaoDich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayNhap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcBCKiemKe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBCKiemKe;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repTrangThaiNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLoaiGiaoDich;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayNhan;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private QLBH.Core.Form.GtidButton cmdExport;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colNganh;
    }
}