namespace QLBanHang.Modules.KhoHang
{
    partial class frm_InNoteSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_InNoteSanPham));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnInPhieu = new DevExpress.XtraEditors.SimpleButton();
            this.bteSanPham = new DevExpress.XtraEditors.ButtonEdit();
            this.lueKhoIn = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grcSanPham = new DevExpress.XtraGrid.GridControl();
            this.grvSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.chkInGia = new System.Windows.Forms.CheckBox();
            this.rdoA5 = new System.Windows.Forms.RadioButton();
            this.rdoA4 = new System.Windows.Forms.RadioButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoc = new DevExpress.XtraEditors.SimpleButton();
            this.grcNoteSanPham = new DevExpress.XtraGrid.GridControl();
            this.grvNoteSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colThongTin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaTri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bteSanPham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKhoIn.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcNoteSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNoteSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 20);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Khổ in";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieu.Image")));
            this.btnInPhieu.Location = new System.Drawing.Point(418, 15);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(86, 25);
            this.btnInPhieu.TabIndex = 4;
            this.btnInPhieu.Text = "In tờ Note";
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // bteSanPham
            // 
            this.bteSanPham.Location = new System.Drawing.Point(4, 20);
            this.bteSanPham.Name = "bteSanPham";
            this.bteSanPham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteSanPham.Size = new System.Drawing.Size(313, 20);
            this.bteSanPham.TabIndex = 5;
            this.bteSanPham.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteSanPham_ButtonClick);
            this.bteSanPham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteSanPham_KeyDown);
            this.bteSanPham.TextChanged += new System.EventHandler(this.bteSanPham_TextChanged);
            // 
            // lueKhoIn
            // 
            this.lueKhoIn.Location = new System.Drawing.Point(41, 17);
            this.lueKhoIn.Name = "lueKhoIn";
            this.lueKhoIn.Properties.AutoHeight = false;
            this.lueKhoIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKhoIn.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lueKhoIn.Properties.DisplayMember = "Name";
            this.lueKhoIn.Properties.DropDownRows = 3;
            this.lueKhoIn.Properties.NullText = "";
            this.lueKhoIn.Properties.PopupFormMinSize = new System.Drawing.Size(80, 0);
            this.lueKhoIn.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            this.lueKhoIn.Properties.PopupWidth = 70;
            this.lueKhoIn.Properties.ValueMember = "OID";
            this.lueKhoIn.Size = new System.Drawing.Size(83, 20);
            this.lueKhoIn.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.grcSanPham);
            this.groupBox1.Controls.Add(this.bteSanPham);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 461);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Chọn sản phẩm";
            // 
            // grcSanPham
            // 
            this.grcSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grcSanPham.Location = new System.Drawing.Point(4, 50);
            this.grcSanPham.MainView = this.grvSanPham;
            this.grcSanPham.Name = "grcSanPham";
            this.grcSanPham.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit2});
            this.grcSanPham.Size = new System.Drawing.Size(313, 405);
            this.grcSanPham.TabIndex = 22;
            this.grcSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSanPham});
            // 
            // grvSanPham
            // 
            this.grvSanPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.grvSanPham.GridControl = this.grcSanPham;
            this.grvSanPham.Name = "grvSanPham";
            this.grvSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Tên sản phẩm";
            this.gridColumn2.FieldName = "TenSanPham";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 217;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // chkInGia
            // 
            this.chkInGia.AutoSize = true;
            this.chkInGia.Location = new System.Drawing.Point(260, 19);
            this.chkInGia.Name = "chkInGia";
            this.chkInGia.Size = new System.Drawing.Size(53, 17);
            this.chkInGia.TabIndex = 25;
            this.chkInGia.Text = "In giá";
            this.chkInGia.UseVisualStyleBackColor = true;
            // 
            // rdoA5
            // 
            this.rdoA5.AutoSize = true;
            this.rdoA5.Location = new System.Drawing.Point(192, 19);
            this.rdoA5.Name = "rdoA5";
            this.rdoA5.Size = new System.Drawing.Size(62, 17);
            this.rdoA5.TabIndex = 24;
            this.rdoA5.Text = "Giấy A5";
            this.rdoA5.UseVisualStyleBackColor = true;
            // 
            // rdoA4
            // 
            this.rdoA4.AutoSize = true;
            this.rdoA4.Location = new System.Drawing.Point(126, 19);
            this.rdoA4.Name = "rdoA4";
            this.rdoA4.Size = new System.Drawing.Size(62, 17);
            this.rdoA4.TabIndex = 23;
            this.rdoA4.Text = "Giấy A4";
            this.rdoA4.UseVisualStyleBackColor = true;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.Location = new System.Drawing.Point(321, 15);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(91, 25);
            this.btnCapNhat.TabIndex = 21;
            this.btnCapNhat.Text = "Cập nhật STT";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.Location = new System.Drawing.Point(329, 199);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(93, 49);
            this.btnLoc.TabIndex = 21;
            this.btnLoc.Text = "Nạp cấu hình";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // grcNoteSanPham
            // 
            this.grcNoteSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcNoteSanPham.Location = new System.Drawing.Point(6, 46);
            this.grcNoteSanPham.MainView = this.grvNoteSanPham;
            this.grcNoteSanPham.Name = "grcNoteSanPham";
            this.grcNoteSanPham.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheck,
            this.repositoryItemTextEdit1});
            this.grcNoteSanPham.Size = new System.Drawing.Size(500, 409);
            this.grcNoteSanPham.TabIndex = 20;
            this.grcNoteSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNoteSanPham});
            // 
            // grvNoteSanPham
            // 
            this.grvNoteSanPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colThongTin,
            this.colGiaTri});
            this.grvNoteSanPham.GridControl = this.grcNoteSanPham;
            this.grvNoteSanPham.Name = "grvNoteSanPham";
            this.grvNoteSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.ColumnEdit = this.repositoryItemTextEdit1;
            this.colSTT.DisplayFormat.FormatString = "n0";
            this.colSTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.FixedWidth = true;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 100;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colThongTin
            // 
            this.colThongTin.AppearanceHeader.Options.UseTextOptions = true;
            this.colThongTin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThongTin.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThongTin.Caption = "Tên thông số";
            this.colThongTin.FieldName = "TenCauHinh";
            this.colThongTin.Name = "colThongTin";
            this.colThongTin.OptionsColumn.FixedWidth = true;
            this.colThongTin.OptionsColumn.ReadOnly = true;
            this.colThongTin.Visible = true;
            this.colThongTin.VisibleIndex = 1;
            this.colThongTin.Width = 200;
            // 
            // colGiaTri
            // 
            this.colGiaTri.AppearanceHeader.Options.UseTextOptions = true;
            this.colGiaTri.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGiaTri.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGiaTri.Caption = "Giá trị";
            this.colGiaTri.FieldName = "GiaTri";
            this.colGiaTri.Name = "colGiaTri";
            this.colGiaTri.OptionsColumn.ReadOnly = true;
            this.colGiaTri.Visible = true;
            this.colGiaTri.VisibleIndex = 2;
            this.colGiaTri.Width = 289;
            // 
            // repCheck
            // 
            this.repCheck.AutoHeight = false;
            this.repCheck.Name = "repCheck";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkInGia);
            this.groupBox2.Controls.Add(this.btnInPhieu);
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Controls.Add(this.grcNoteSanPham);
            this.groupBox2.Controls.Add(this.lueKhoIn);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.rdoA5);
            this.groupBox2.Controls.Add(this.rdoA4);
            this.groupBox2.Location = new System.Drawing.Point(428, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 461);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. In tờ Note";
            // 
            // frm_InNoteSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 467);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_InNoteSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Note sản phẩm";
            this.Load += new System.EventHandler(this.frm_InNoteSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bteSanPham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKhoIn.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcNoteSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNoteSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnInPhieu;
        private DevExpress.XtraEditors.ButtonEdit bteSanPham;
        private DevExpress.XtraEditors.LookUpEdit lueKhoIn;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl grcNoteSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNoteSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colThongTin;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaTri;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheck;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl grcSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private System.Windows.Forms.RadioButton rdoA5;
        private System.Windows.Forms.RadioButton rdoA4;
        private System.Windows.Forms.CheckBox chkInGia;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}