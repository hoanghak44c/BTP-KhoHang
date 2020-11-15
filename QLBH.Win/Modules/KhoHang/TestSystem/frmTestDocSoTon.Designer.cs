namespace QLBanHang.TestSystem
{
    partial class frmTestDocSoTon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestDocSoTon));
            this.bteBrowse = new DevExpress.XtraEditors.ButtonEdit();
            this.grcTonKho = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcTonMaVach = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExport = new QLBH.Core.Form.GtidButton();
            ((System.ComponentModel.ISupportInitialize)(this.bteBrowse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTonMaVach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // bteBrowse
            // 
            this.bteBrowse.Location = new System.Drawing.Point(12, 12);
            this.bteBrowse.Name = "bteBrowse";
            this.bteBrowse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteBrowse.Size = new System.Drawing.Size(487, 20);
            this.bteBrowse.TabIndex = 0;
            this.bteBrowse.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteBrowse_ButtonClick);
            // 
            // grcTonKho
            // 
            this.grcTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grcTonKho.Location = new System.Drawing.Point(12, 58);
            this.grcTonKho.MainView = this.gridView1;
            this.grcTonKho.Name = "grcTonKho";
            this.grcTonKho.Size = new System.Drawing.Size(526, 200);
            this.grcTonKho.TabIndex = 1;
            this.grcTonKho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grcTonKho;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grcTonKho;
            this.gridView2.Name = "gridView2";
            // 
            // grcTonMaVach
            // 
            this.grcTonMaVach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grcTonMaVach.Location = new System.Drawing.Point(555, 58);
            this.grcTonMaVach.MainView = this.gridView3;
            this.grcTonMaVach.Name = "grcTonMaVach";
            this.grcTonMaVach.Size = new System.Drawing.Size(522, 200);
            this.grcTonMaVach.TabIndex = 2;
            this.grcTonMaVach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView4});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grcTonMaVach;
            this.gridView3.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView3.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuong", null, "{0}")});
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowAutoFilterRow = true;
            this.gridView3.OptionsView.ShowFooter = true;
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grcTonMaVach;
            this.gridView4.Name = "gridView4";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(512, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnExport.Size = new System.Drawing.Size(93, 26);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmTestDocSoTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 279);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grcTonMaVach);
            this.Controls.Add(this.grcTonKho);
            this.Controls.Add(this.bteBrowse);
            this.Name = "frmTestDocSoTon";
            this.Text = "frmTestDocSoTon";
            ((System.ComponentModel.ISupportInitialize)(this.bteBrowse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcTonMaVach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit bteBrowse;
        private DevExpress.XtraGrid.GridControl grcTonKho;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl grcTonMaVach;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        internal QLBH.Core.Form.GtidButton btnExport;
    }
}