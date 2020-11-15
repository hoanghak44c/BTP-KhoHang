namespace QLBanHang.Modules.KhoHang
{
    partial class frmThongKe_TonChiTietMaVachBy
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
            this.grcHangTon = new DevExpress.XtraGrid.GridControl();
            this.grvThongKeHangTon = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaVach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTon = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grcHangTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongKeHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // grcHangTon
            // 
            this.grcHangTon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcHangTon.Location = new System.Drawing.Point(12, 12);
            this.grcHangTon.MainView = this.grvThongKeHangTon;
            this.grcHangTon.Name = "grcHangTon";
            this.grcHangTon.Size = new System.Drawing.Size(417, 327);
            this.grcHangTon.TabIndex = 0;
            this.grcHangTon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvThongKeHangTon});
            // 
            // grvThongKeHangTon
            // 
            this.grvThongKeHangTon.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaVach,
            this.colTon});
            this.grvThongKeHangTon.GridControl = this.grcHangTon;
            this.grvThongKeHangTon.Name = "grvThongKeHangTon";
            this.grvThongKeHangTon.OptionsCustomization.AllowGroup = false;
            this.grvThongKeHangTon.OptionsView.ShowGroupPanel = false;
            // 
            // colMaVach
            // 
            this.colMaVach.Caption = "Mã vạch";
            this.colMaVach.FieldName = "MaVach";
            this.colMaVach.Name = "colMaVach";
            this.colMaVach.OptionsColumn.AllowEdit = false;
            this.colMaVach.Visible = true;
            this.colMaVach.VisibleIndex = 0;
            // 
            // colTon
            // 
            this.colTon.Caption = "Tồn";
            this.colTon.FieldName = "Ton";
            this.colTon.Name = "colTon";
            this.colTon.OptionsColumn.AllowEdit = false;
            this.colTon.Visible = true;
            this.colTon.VisibleIndex = 1;
            // 
            // frmThongKe_TonChiTietMaVach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 351);
            this.Controls.Add(this.grcHangTon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKe_TonChiTietMaVach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê tồn chi tiết mã vạch";
            this.Load += new System.EventHandler(this.frmThongKe_TonChiTietMaVach_Load);
            this.Activated += new System.EventHandler(this.frmThongKe_TonChiTietMaVach_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grcHangTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongKeHangTon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcHangTon;
        private DevExpress.XtraGrid.Views.Grid.GridView grvThongKeHangTon;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVach;
        private DevExpress.XtraGrid.Columns.GridColumn colTon;
    }
}