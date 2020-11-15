namespace QLBanHang.Modules.KhoHang
{
    partial class frm_DanhSachDotKiemKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DanhSachDotKiemKe));
            this.grcList = new DevExpress.XtraGrid.GridControl();
            this.grvList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKyKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repKyKiemKe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaDotKK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repBatDau = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colThoiGianKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repKetThuc = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTimKiem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSession = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslInfor = new System.Windows.Forms.ToolStripLabel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.txtKyKiemKe = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaDotKiemKe = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKyKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBatDau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBatDau.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKetThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKetThuc.VistaTimeProperties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grcList
            // 
            this.grcList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcList.Location = new System.Drawing.Point(12, 114);
            this.grcList.MainView = this.grvList;
            this.grcList.Name = "grcList";
            this.grcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repBatDau,
            this.repKetThuc,
            this.repKyKiemKe});
            this.grcList.Size = new System.Drawing.Size(911, 339);
            this.grcList.TabIndex = 1;
            this.grcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvList});
            this.grcList.DoubleClick += new System.EventHandler(this.grcList_DoubleClick);
            // 
            // grvList
            // 
            this.grvList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKyKiemKe,
            this.colMaDotKK,
            this.colThoiGianBatDau,
            this.colThoiGianKetThuc,
            this.colGhiChu});
            this.grvList.GridControl = this.grcList;
            this.grvList.Name = "grvList";
            this.grvList.OptionsView.ShowAutoFilterRow = true;
            // 
            // colKyKiemKe
            // 
            this.colKyKiemKe.AppearanceHeader.Options.UseTextOptions = true;
            this.colKyKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKyKiemKe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKyKiemKe.Caption = "Kỳ kiểm kê";
            this.colKyKiemKe.ColumnEdit = this.repKyKiemKe;
            this.colKyKiemKe.FieldName = "KyKiemKe";
            this.colKyKiemKe.Name = "colKyKiemKe";
            this.colKyKiemKe.OptionsColumn.FixedWidth = true;
            this.colKyKiemKe.OptionsColumn.ReadOnly = true;
            this.colKyKiemKe.Visible = true;
            this.colKyKiemKe.VisibleIndex = 0;
            this.colKyKiemKe.Width = 100;
            // 
            // repKyKiemKe
            // 
            this.repKyKiemKe.AutoHeight = false;
            this.repKyKiemKe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repKyKiemKe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repKyKiemKe.DisplayMember = "Name";
            this.repKyKiemKe.Name = "repKyKiemKe";
            this.repKyKiemKe.NullText = "";
            this.repKyKiemKe.ValueMember = "OID";
            // 
            // colMaDotKK
            // 
            this.colMaDotKK.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaDotKK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaDotKK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaDotKK.Caption = "Mã đợt kiểm kê";
            this.colMaDotKK.FieldName = "MaDotKiemKe";
            this.colMaDotKK.Name = "colMaDotKK";
            this.colMaDotKK.OptionsColumn.AllowEdit = false;
            this.colMaDotKK.OptionsColumn.FixedWidth = true;
            this.colMaDotKK.OptionsColumn.ReadOnly = true;
            this.colMaDotKK.Visible = true;
            this.colMaDotKK.VisibleIndex = 1;
            this.colMaDotKK.Width = 150;
            // 
            // colThoiGianBatDau
            // 
            this.colThoiGianBatDau.AppearanceHeader.Options.UseTextOptions = true;
            this.colThoiGianBatDau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThoiGianBatDau.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThoiGianBatDau.Caption = "Thời gian bắt đầu";
            this.colThoiGianBatDau.ColumnEdit = this.repBatDau;
            this.colThoiGianBatDau.FieldName = "NgayBatDau";
            this.colThoiGianBatDau.Name = "colThoiGianBatDau";
            this.colThoiGianBatDau.OptionsColumn.AllowEdit = false;
            this.colThoiGianBatDau.OptionsColumn.FixedWidth = true;
            this.colThoiGianBatDau.OptionsColumn.ReadOnly = true;
            this.colThoiGianBatDau.Visible = true;
            this.colThoiGianBatDau.VisibleIndex = 2;
            this.colThoiGianBatDau.Width = 120;
            // 
            // repBatDau
            // 
            this.repBatDau.AutoHeight = false;
            this.repBatDau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repBatDau.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.repBatDau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repBatDau.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.repBatDau.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repBatDau.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.repBatDau.Name = "repBatDau";
            this.repBatDau.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colThoiGianKetThuc
            // 
            this.colThoiGianKetThuc.AppearanceHeader.Options.UseTextOptions = true;
            this.colThoiGianKetThuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThoiGianKetThuc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThoiGianKetThuc.Caption = "Thời gian kết thúc";
            this.colThoiGianKetThuc.ColumnEdit = this.repKetThuc;
            this.colThoiGianKetThuc.FieldName = "NgayKetThuc";
            this.colThoiGianKetThuc.Name = "colThoiGianKetThuc";
            this.colThoiGianKetThuc.OptionsColumn.AllowEdit = false;
            this.colThoiGianKetThuc.OptionsColumn.FixedWidth = true;
            this.colThoiGianKetThuc.OptionsColumn.ReadOnly = true;
            this.colThoiGianKetThuc.Visible = true;
            this.colThoiGianKetThuc.VisibleIndex = 3;
            this.colThoiGianKetThuc.Width = 120;
            // 
            // repKetThuc
            // 
            this.repKetThuc.AutoHeight = false;
            this.repKetThuc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repKetThuc.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.repKetThuc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repKetThuc.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.repKetThuc.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repKetThuc.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.repKetThuc.Name = "repKetThuc";
            this.repKetThuc.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.OptionsColumn.AllowEdit = false;
            this.colGhiChu.OptionsColumn.FixedWidth = true;
            this.colGhiChu.OptionsColumn.ReadOnly = true;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 4;
            this.colGhiChu.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.toolStripSeparator5,
            this.tsbTimKiem,
            this.toolStripSeparator6,
            this.tsbImport,
            this.toolStripSeparator3,
            this.tsbPrint,
            this.toolStripSeparator4,
            this.tsbSession,
            this.toolStripSeparator2,
            this.tsbClose,
            this.toolStripSeparator1,
            this.tslInfor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(935, 25);
            this.toolStrip1.TabIndex = 88;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(103, 22);
            this.tsbAdd.Text = "Tạo &mới (F5)";
            this.tsbAdd.ToolTipText = "Làm mới (F5)";
            this.tsbAdd.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(79, 22);
            this.tsbEdit.Text = "&Sửa (F6)";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(77, 22);
            this.tsbDelete.Text = "&Hủy (F8)";
            this.tsbDelete.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbTimKiem
            // 
            this.tsbTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("tsbTimKiem.Image")));
            this.tsbTimKiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTimKiem.Name = "tsbTimKiem";
            this.tsbTimKiem.Size = new System.Drawing.Size(109, 22);
            this.tsbTimKiem.Text = "Tìm kiếm (F3)";
            this.tsbTimKiem.Click += new System.EventHandler(this.tsbTimKiem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbImport
            // 
            this.tsbImport.Image = ((System.Drawing.Image)(resources.GetObject("tsbImport.Image")));
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(137, 22);
            this.tsbImport.Text = "Import dữ liệu (F2)";
            this.tsbImport.Click += new System.EventHandler(this.tsbImport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Visible = false;
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(102, 22);
            this.tsbPrint.Text = "&In phiếu (F9)";
            this.tsbPrint.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSession
            // 
            this.tsbSession.Image = ((System.Drawing.Image)(resources.GetObject("tsbSession.Image")));
            this.tsbSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSession.Name = "tsbSession";
            this.tsbSession.Size = new System.Drawing.Size(129, 22);
            this.tsbSession.Text = "Ca làm việc (F11)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(93, 22);
            this.tsbClose.Text = "Đ&óng (F12)";
            this.tsbClose.ToolTipText = "Đóng (F12)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslInfor
            // 
            this.tslInfor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslInfor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslInfor.Name = "tslInfor";
            this.tslInfor.Size = new System.Drawing.Size(138, 22);
            this.tslInfor.Text = "Danh sách đợt kiểm kê";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.txtMaDotKiemKe);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtNam);
            this.groupControl1.Controls.Add(this.txtKyKiemKe);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 33);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(911, 75);
            this.groupControl1.TabIndex = 89;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(145, 33);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(21, 13);
            this.labelControl4.TabIndex = 67;
            this.labelControl4.Text = "Năm";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kỳ kiểm kê";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(172, 30);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(96, 21);
            this.txtNam.TabIndex = 69;
            // 
            // txtKyKiemKe
            // 
            this.txtKyKiemKe.Location = new System.Drawing.Point(72, 30);
            this.txtKyKiemKe.Name = "txtKyKiemKe";
            this.txtKyKiemKe.Size = new System.Drawing.Size(67, 21);
            this.txtKyKiemKe.TabIndex = 68;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(274, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 13);
            this.labelControl2.TabIndex = 70;
            this.labelControl2.Text = "Mã đợt kiểm kê";
            // 
            // txtMaDotKiemKe
            // 
            this.txtMaDotKiemKe.Location = new System.Drawing.Point(351, 30);
            this.txtMaDotKiemKe.Name = "txtMaDotKiemKe";
            this.txtMaDotKiemKe.Size = new System.Drawing.Size(206, 21);
            this.txtMaDotKiemKe.TabIndex = 71;
            // 
            // frm_DanhSachDotKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 465);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grcList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_DanhSachDotKiemKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đợt kiểm kê";
            this.Load += new System.EventHandler(this.frm_DanhSachDotKiemKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKyKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBatDau.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repBatDau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKetThuc.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repKetThuc)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvList;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDotKK;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repBatDau;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repKetThuc;
        private DevExpress.XtraGrid.Columns.GridColumn colKyKiemKe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repKyKiemKe;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsbAdd;
        public System.Windows.Forms.ToolStripButton tsbEdit;
        public System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton tsbSession;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslInfor;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbTimKiem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.TextBox txtKyKiemKe;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtMaDotKiemKe;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}