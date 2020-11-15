namespace QLBanHang.Modules.KhoHang
{
    partial class frm_BaoCaoGiaoDichKhongDongBo
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
            this.grcBCKiemKe = new DevExpress.XtraGrid.GridControl();
            this.grvBCKiemKe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhapXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repTrangThaiXuat = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repTrangThaiNhan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repLoaiGiaoDich = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repNgayNhan = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayLap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repNgayNhap = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.bteSanpham = new DevExpress.XtraEditors.ButtonEdit();
            this.cboKyBaoCao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bteKho = new DevExpress.XtraEditors.ButtonEdit();
            this.colLoaiGiaoDich = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteSanpham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).BeginInit();
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
            this.grcBCKiemKe.Location = new System.Drawing.Point(12, 130);
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
            this.grcBCKiemKe.Size = new System.Drawing.Size(742, 340);
            this.grcBCKiemKe.TabIndex = 8;
            this.grcBCKiemKe.UseEmbeddedNavigator = true;
            this.grcBCKiemKe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBCKiemKe});
            // 
            // grvBCKiemKe
            // 
            this.grvBCKiemKe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoChungTu,
            this.colKho,
            this.colNgayNhapXuat,
            this.colMaSanPham,
            this.colTenSanPham,
            this.colSoLuong,
            this.colLoaiGiaoDich});
            this.grvBCKiemKe.GridControl = this.grcBCKiemKe;
            this.grvBCKiemKe.Name = "grvBCKiemKe";
            this.grvBCKiemKe.OptionsView.ShowAutoFilterRow = true;
            // 
            // colSoChungTu
            // 
            this.colSoChungTu.Caption = "Số chứng từ";
            this.colSoChungTu.FieldName = "SoChungTu";
            this.colSoChungTu.Name = "colSoChungTu";
            this.colSoChungTu.Visible = true;
            this.colSoChungTu.VisibleIndex = 1;
            // 
            // colKho
            // 
            this.colKho.Caption = "Kho";
            this.colKho.FieldName = "MaKho";
            this.colKho.Name = "colKho";
            this.colKho.Visible = true;
            this.colKho.VisibleIndex = 0;
            // 
            // colNgayNhapXuat
            // 
            this.colNgayNhapXuat.Caption = "Ngày Nhập Xuất";
            this.colNgayNhapXuat.FieldName = "NgayXuatHang";
            this.colNgayNhapXuat.Name = "colNgayNhapXuat";
            this.colNgayNhapXuat.Visible = true;
            this.colNgayNhapXuat.VisibleIndex = 2;
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.Caption = "Mã sản phẩm";
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.Visible = true;
            this.colMaSanPham.VisibleIndex = 3;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.Caption = "Tên sản phẩm";
            this.colTenSanPham.FieldName = "TenSanPham";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.Visible = true;
            this.colTenSanPham.VisibleIndex = 4;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 5;
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
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.bteSanpham);
            this.groupControl1.Controls.Add(this.cboKyBaoCao);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.btnReload);
            this.groupControl1.Controls.Add(this.deTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.deFrom);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.bteKho);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(742, 112);
            this.groupControl1.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 67;
            this.labelControl4.Text = "Sản phẩm:";
            // 
            // bteSanpham
            // 
            this.bteSanpham.Location = new System.Drawing.Point(73, 53);
            this.bteSanpham.Name = "bteSanpham";
            this.bteSanpham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteSanpham.Size = new System.Drawing.Size(475, 20);
            this.bteSanpham.TabIndex = 66;
            this.bteSanpham.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteSanpham_ButtonClick);
            this.bteSanpham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteSanpham_KeyDown);
            // 
            // cboKyBaoCao
            // 
            this.cboKyBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKyBaoCao.FormattingEnabled = true;
            this.cboKyBaoCao.Location = new System.Drawing.Point(73, 79);
            this.cboKyBaoCao.Name = "cboKyBaoCao";
            this.cboKyBaoCao.Size = new System.Drawing.Size(105, 21);
            this.cboKyBaoCao.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Kỳ báo cáo";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(554, 57);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(554, 25);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(99, 26);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Xem";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(422, 81);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTo.Size = new System.Drawing.Size(126, 20);
            this.deTo.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(364, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Đến ngày:";
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(234, 80);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFrom.Size = new System.Drawing.Size(126, 20);
            this.deFrom.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(184, 84);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Từ ngày:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kho:";
            // 
            // bteKho
            // 
            this.bteKho.Location = new System.Drawing.Point(73, 27);
            this.bteKho.Name = "bteKho";
            this.bteKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKho.Size = new System.Drawing.Size(475, 20);
            this.bteKho.TabIndex = 5;
            this.bteKho.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteKho_ButtonClick);
            this.bteKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteKho_KeyDown);
            // 
            // colLoaiGiaoDich
            // 
            this.colLoaiGiaoDich.Caption = "Loại giao dịch";
            this.colLoaiGiaoDich.FieldName = "LoaiGiaoDich";
            this.colLoaiGiaoDich.Name = "colLoaiGiaoDich";
            this.colLoaiGiaoDich.Visible = true;
            this.colLoaiGiaoDich.VisibleIndex = 6;
            // 
            // frm_BaoCaoGiaoDichKhongDongBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 482);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grcBCKiemKe);
            this.Name = "frm_BaoCaoGiaoDichKhongDongBo";
            this.Text = "Báo cáo các giao dịch nhập xuất không đồng bộ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BaoCaoGiaoDichKhongDongBo_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteSanpham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit bteSanpham;
        private System.Windows.Forms.ComboBox cboKyBaoCao;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit bteKho;
        private DevExpress.XtraGrid.Columns.GridColumn colSoChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn colKho;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhapXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colLoaiGiaoDich;
    }
}