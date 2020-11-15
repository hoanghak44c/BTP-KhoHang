namespace QLBanHang.Modules.KhoHang.Reports
{
    partial class rpt_BC_NoteSanPhamA65
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable7 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblTenHang = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblModel = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.rpt_BC_NoteSanPhamA6Detailnew1 = new QLBanHang.Modules.KhoHang.Reports.rpt_BC_NoteSanPhamA6Detailnew();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblMaSP = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblGiaVAT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lblDonGia = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblGiaCoVAT = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblDiemThuong = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_BC_NoteSanPhamA6Detailnew1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable7,
            this.xrSubreport1,
            this.xrTable1,
            this.xrTable2,
            this.xrPictureBox1,
            this.lblDonGia,
            this.xrTable3});
            this.Detail.Height = 592;
            this.Detail.MultiColumn.ColumnCount = 2;
            this.Detail.MultiColumn.Direction = DevExpress.XtraReports.UI.ColumnDirection.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable7
            // 
            this.xrTable7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTable7.Location = new System.Drawing.Point(167, 125);
            this.xrTable7.Name = "xrTable7";
            this.xrTable7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow9,
            this.xrTableRow10});
            this.xrTable7.Size = new System.Drawing.Size(242, 50);
            this.xrTable7.StylePriority.UseFont = false;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblTenHang});
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Weight = 1;
            // 
            // lblTenHang
            // 
            this.lblTenHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.StylePriority.UseFont = false;
            this.lblTenHang.Text = "lblTenHang";
            this.lblTenHang.Weight = 3.58;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblModel});
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Weight = 1;
            // 
            // lblModel
            // 
            this.lblModel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblModel.Multiline = true;
            this.lblModel.Name = "lblModel";
            this.lblModel.StylePriority.UseFont = false;
            this.lblModel.Text = "lblModel";
            this.lblModel.Weight = 3.58;
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.Location = new System.Drawing.Point(17, 200);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.ReportSource = this.rpt_BC_NoteSanPhamA6Detailnew1;
            this.xrSubreport1.Size = new System.Drawing.Size(390, 280);
            this.xrSubreport1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrSubreport1_BeforePrint);
            // 
            // rpt_BC_NoteSanPhamA6Detailnew1
            // 
            this.rpt_BC_NoteSanPhamA6Detailnew1.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.rpt_BC_NoteSanPhamA6Detailnew1.Name = "rpt_BC_NoteSanPhamA6Detailnew1";
            this.rpt_BC_NoteSanPhamA6Detailnew1.PageColor = System.Drawing.Color.White;
            this.rpt_BC_NoteSanPhamA6Detailnew1.PageHeight = 1100;
            this.rpt_BC_NoteSanPhamA6Detailnew1.PageWidth = 850;
            this.rpt_BC_NoteSanPhamA6Detailnew1.Version = "9.2";
            // 
            // xrTable1
            // 
            this.xrTable1.Location = new System.Drawing.Point(20, 533);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(192, 25);
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblMaSP});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1;
            // 
            // lblMaSP
            // 
            this.lblMaSP.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.StylePriority.UseFont = false;
            this.lblMaSP.StylePriority.UseTextAlignment = false;
            this.lblMaSP.Text = "lblMaSP";
            this.lblMaSP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.lblMaSP.Weight = 3.58;
            // 
            // xrTable2
            // 
            this.xrTable2.Location = new System.Drawing.Point(224, 533);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(150, 17);
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblGiaVAT});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1;
            // 
            // lblGiaVAT
            // 
            this.lblGiaVAT.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblGiaVAT.Name = "lblGiaVAT";
            this.lblGiaVAT.StylePriority.UseFont = false;
            this.lblGiaVAT.StylePriority.UseTextAlignment = false;
            this.lblGiaVAT.Text = "Giá đã bao gồm VAT";
            this.lblGiaVAT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblGiaVAT.Weight = 3.58;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Location = new System.Drawing.Point(17, 117);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(142, 58);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrPictureBox1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPictureBox1_BeforePrint);
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(225, 508);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow6});
            this.lblDonGia.Size = new System.Drawing.Size(150, 17);
            this.lblDonGia.StylePriority.UseTextAlignment = false;
            this.lblDonGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblGiaCoVAT});
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Weight = 1;
            // 
            // lblGiaCoVAT
            // 
            this.lblGiaCoVAT.Name = "lblGiaCoVAT";
            xrSummary1.FormatString = "{0:n0}";
            this.lblGiaCoVAT.Summary = xrSummary1;
            this.lblGiaCoVAT.Weight = 3;
            // 
            // xrTable3
            // 
            this.xrTable3.Location = new System.Drawing.Point(17, 508);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.Size = new System.Drawing.Size(192, 17);
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblDiemThuong});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1;
            // 
            // lblDiemThuong
            // 
            this.lblDiemThuong.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.lblDiemThuong.Name = "lblDiemThuong";
            this.lblDiemThuong.StylePriority.UseFont = false;
            this.lblDiemThuong.StylePriority.UseTextAlignment = false;
            this.lblDiemThuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.lblDiemThuong.Weight = 3.58;
            // 
            // rpt_BC_NoteSanPhamA65
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(10, 0, 0, 0);
            this.PageHeight = 583;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A5;
            this.PaperName = "A6 (105 x 148mm)";
            this.Version = "9.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt_BC_NoteSanPhamA6Detailnew1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable7;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow9;
        private DevExpress.XtraReports.UI.XRTableCell lblTenHang;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell lblModel;
        private DevExpress.XtraReports.UI.XRSubreport xrSubreport1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell lblMaSP;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell lblGiaVAT;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private rpt_BC_NoteSanPhamA6Detailnew rpt_BC_NoteSanPhamA6Detailnew1;
        private DevExpress.XtraReports.UI.XRTable lblDonGia;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell lblGiaCoVAT;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell lblDiemThuong;
    }
}
