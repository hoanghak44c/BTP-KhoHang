namespace QLBanHang.Modules.KhoHang.Reports
{
    partial class rpt_BC_NoteSanPhamA5Detail
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.txtTenCauHinh = new DevExpress.XtraReports.UI.XRTableCell();
            this.txtGiaTri = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.Detail.Height = 35;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.Location = new System.Drawing.Point(13, 0);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
            this.xrTable3.Size = new System.Drawing.Size(501, 33);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.txtTenCauHinh,
            this.txtGiaTri});
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 1;
            // 
            // txtTenCauHinh
            // 
            this.txtTenCauHinh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtTenCauHinh.Name = "txtTenCauHinh";
            this.txtTenCauHinh.StylePriority.UseFont = false;
            this.txtTenCauHinh.Text = "Cấu hình";
            this.txtTenCauHinh.Weight = 1.1169590643274854;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.StylePriority.UseFont = false;
            this.txtGiaTri.StylePriority.UseTextAlignment = false;
            this.txtGiaTri.Text = "Giá trị";
            this.txtGiaTri.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            this.txtGiaTri.Weight = 1.8128654970760239;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            // 
            // rpt_BC_NoteSanPhamA5Detail
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "9.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell txtTenCauHinh;
        private DevExpress.XtraReports.UI.XRTableCell txtGiaTri;
        public DevExpress.XtraReports.UI.DetailBand Detail;
    }
}
