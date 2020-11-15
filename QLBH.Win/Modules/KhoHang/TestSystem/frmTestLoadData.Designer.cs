namespace QLBanHang.TestSystem
{
    partial class frmTestLoadData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestLoadData));
            this.grcTonKho = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExport = new QLBH.Core.Form.GtidButton();
            this.pbStatus = new DevExpress.XtraEditors.ProgressBarControl();
            this.ucCodeGenerate1 = new QLBH.Common.UserControls.UCCodeGenerate();
            ((System.ComponentModel.ISupportInitialize)(this.grcTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcTonKho
            // 
            this.grcTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcTonKho.Location = new System.Drawing.Point(0, 12);
            this.grcTonKho.MainView = this.gridView1;
            this.grcTonKho.Name = "grcTonKho";
            this.grcTonKho.Size = new System.Drawing.Size(1089, 432);
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
            this.gridView1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseWheel);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grcTonKho;
            this.gridView2.Name = "gridView2";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(984, 450);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnExport.Size = new System.Drawing.Size(93, 26);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(12, 450);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(268, 26);
            this.pbStatus.TabIndex = 5;
            this.pbStatus.UseWaitCursor = true;
            // 
            // ucCodeGenerate1
            // 
            this.ucCodeGenerate1.FieldName = null;
            this.ucCodeGenerate1.Location = new System.Drawing.Point(354, 449);
            this.ucCodeGenerate1.Name = "ucCodeGenerate1";
            this.ucCodeGenerate1.Prefix = "PNDC";
            this.ucCodeGenerate1.Size = new System.Drawing.Size(245, 26);
            this.ucCodeGenerate1.TabIndex = 6;
            this.ucCodeGenerate1.TableName = null;
            // 
            // frmTestLoadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 488);
            this.Controls.Add(this.ucCodeGenerate1);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grcTonKho);
            this.Name = "frmTestLoadData";
            this.Text = "frmTestLoadData";
            ((System.ComponentModel.ISupportInitialize)(this.grcTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcTonKho;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        internal QLBH.Core.Form.GtidButton btnExport;
        private DevExpress.XtraEditors.ProgressBarControl pbStatus;
        private QLBH.Common.UserControls.UCCodeGenerate ucCodeGenerate1;
    }
}