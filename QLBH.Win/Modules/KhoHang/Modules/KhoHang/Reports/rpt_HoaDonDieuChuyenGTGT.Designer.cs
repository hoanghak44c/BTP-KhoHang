namespace QLBanHang.Modules.BanHang.Reports
{
    partial class rpt_HoaDonDieuChuyenGTGT
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTongTien = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTongSL = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblNguoiLap = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lblNgay = new DevExpress.XtraReports.UI.XRLabel();
            this.lblThang = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNam = new DevExpress.XtraReports.UI.XRLabel();
            this.lblHDSo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNguoiVC = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKhonhap = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKhoXuat = new DevExpress.XtraReports.UI.XRLabel();
            this.lblngay1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblthang1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblnam1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSoChungTu = new DevExpress.XtraReports.UI.XRLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblGhiChu = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9});
            this.Detail.Height = 19;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TenSanPham", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(100, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.Size = new System.Drawing.Size(234, 15);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MaSanPham", "")});
            this.xrLabel2.Location = new System.Drawing.Point(367, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(100, 15);
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TenDonViTinh", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(467, 0);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.Size = new System.Drawing.Size(50, 15);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoLuong", "{0:#,#}")});
            this.xrLabel4.Location = new System.Drawing.Point(525, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(65, 15);
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DonGia", "{0:#,#}")});
            this.xrLabel7.Location = new System.Drawing.Point(633, 0);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.Size = new System.Drawing.Size(70, 15);
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ThanhTien", "{0:#,#}")});
            this.xrLabel8.Location = new System.Drawing.Point(708, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.Size = new System.Drawing.Size(80, 15);
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "IdChungTu", "")});
            this.xrLabel9.Location = new System.Drawing.Point(58, 0);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.Size = new System.Drawing.Size(33, 15);
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:n0}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel9.Summary = xrSummary1;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(692, 125);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTongTien.Size = new System.Drawing.Size(67, 17);
            this.lblTongTien.StylePriority.UseFont = false;
            this.lblTongTien.StylePriority.UseTextAlignment = false;
            this.lblTongTien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblTongSL
            // 
            this.lblTongSL.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SoLuong", "")});
            this.lblTongSL.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSL.Location = new System.Drawing.Point(525, 133);
            this.lblTongSL.Name = "lblTongSL";
            this.lblTongSL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTongSL.Size = new System.Drawing.Size(67, 17);
            this.lblTongSL.StylePriority.UseFont = false;
            this.lblTongSL.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:n0}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.lblTongSL.Summary = xrSummary2;
            this.lblTongSL.Text = "lblTongSL";
            this.lblTongSL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblNguoiLap,
            this.lblTongSL,
            this.lblTongTien});
            this.PageFooter.Height = 274;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblNguoiLap.Location = new System.Drawing.Point(50, 250);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNguoiLap.Size = new System.Drawing.Size(175, 17);
            this.lblNguoiLap.StylePriority.UseFont = false;
            this.lblNguoiLap.StylePriority.UseTextAlignment = false;
            this.lblNguoiLap.Text = "123";
            this.lblNguoiLap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblNgay,
            this.lblThang,
            this.lblNam,
            this.lblHDSo,
            this.lblNguoiVC,
            this.lblKhonhap,
            this.lblKhoXuat,
            this.lblngay1,
            this.lblthang1,
            this.lblnam1,
            this.lblSoChungTu,
            this.lblGhiChu});
            this.GroupHeader1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.GroupHeader1.Height = 356;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StylePriority.UseFont = false;
            // 
            // lblNgay
            // 
            this.lblNgay.Location = new System.Drawing.Point(333, 158);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNgay.Size = new System.Drawing.Size(33, 17);
            this.lblNgay.Text = "ngay";
            // 
            // lblThang
            // 
            this.lblThang.Location = new System.Drawing.Point(408, 158);
            this.lblThang.Name = "lblThang";
            this.lblThang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblThang.Size = new System.Drawing.Size(50, 17);
            this.lblThang.Text = "thang";
            // 
            // lblNam
            // 
            this.lblNam.Location = new System.Drawing.Point(492, 158);
            this.lblNam.Name = "lblNam";
            this.lblNam.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNam.Size = new System.Drawing.Size(42, 17);
            this.lblNam.Text = "nam";
            // 
            // lblHDSo
            // 
            this.lblHDSo.Location = new System.Drawing.Point(608, 158);
            this.lblHDSo.Name = "lblHDSo";
            this.lblHDSo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblHDSo.Size = new System.Drawing.Size(167, 25);
            // 
            // lblNguoiVC
            // 
            this.lblNguoiVC.Location = new System.Drawing.Point(217, 225);
            this.lblNguoiVC.Name = "lblNguoiVC";
            this.lblNguoiVC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNguoiVC.Size = new System.Drawing.Size(225, 17);
            this.lblNguoiVC.Text = "ho ten nguoi vc";
            // 
            // lblKhonhap
            // 
            this.lblKhonhap.Location = new System.Drawing.Point(125, 265);
            this.lblKhonhap.Name = "lblKhonhap";
            this.lblKhonhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblKhonhap.Size = new System.Drawing.Size(292, 17);
            this.lblKhonhap.Text = "kho nhap";
            // 
            // lblKhoXuat
            // 
            this.lblKhoXuat.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoXuat.Location = new System.Drawing.Point(500, 265);
            this.lblKhoXuat.Name = "lblKhoXuat";
            this.lblKhoXuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblKhoXuat.Size = new System.Drawing.Size(292, 17);
            this.lblKhoXuat.StylePriority.UseFont = false;
            this.lblKhoXuat.Text = "Kho xuat";
            // 
            // lblngay1
            // 
            this.lblngay1.Location = new System.Drawing.Point(608, 242);
            this.lblngay1.Name = "lblngay1";
            this.lblngay1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblngay1.Size = new System.Drawing.Size(33, 17);
            this.lblngay1.Text = "ngay";
            // 
            // lblthang1
            // 
            this.lblthang1.Location = new System.Drawing.Point(667, 242);
            this.lblthang1.Name = "lblthang1";
            this.lblthang1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblthang1.Size = new System.Drawing.Size(42, 17);
            this.lblthang1.Text = "thang";
            // 
            // lblnam1
            // 
            this.lblnam1.Location = new System.Drawing.Point(725, 242);
            this.lblnam1.Name = "lblnam1";
            this.lblnam1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblnam1.Size = new System.Drawing.Size(42, 17);
            this.lblnam1.Text = "nam";
            // 
            // lblSoChungTu
            // 
            this.lblSoChungTu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoChungTu.Location = new System.Drawing.Point(417, 242);
            this.lblSoChungTu.Name = "lblSoChungTu";
            this.lblSoChungTu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSoChungTu.Size = new System.Drawing.Size(114, 17);
            this.lblSoChungTu.StylePriority.UseFont = false;
            this.lblSoChungTu.Text = "so  noi bo";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(QLBanHang.Modules.KhoHang.Infors.BaoCao_ChiTietDCInfor);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(127, 291);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGhiChu.Size = new System.Drawing.Size(664, 17);
            this.lblGhiChu.Text = "Ghi chú";
            // 
            // rpt_HoaDonDieuChuyenGTGT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.GroupHeader1});
            this.DataSource = this.bindingSource1;
            this.Margins = new System.Drawing.Printing.Margins(7, 8, 12, 100);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "9.2";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel lblNgay;
        private DevExpress.XtraReports.UI.XRLabel lblThang;
        private DevExpress.XtraReports.UI.XRLabel lblNam;
        private DevExpress.XtraReports.UI.XRLabel lblHDSo;
        private DevExpress.XtraReports.UI.XRLabel lblNguoiVC;
        private DevExpress.XtraReports.UI.XRLabel lblKhonhap;
        private DevExpress.XtraReports.UI.XRLabel lblKhoXuat;
        private DevExpress.XtraReports.UI.XRLabel lblngay1;
        private DevExpress.XtraReports.UI.XRLabel lblthang1;
        private DevExpress.XtraReports.UI.XRLabel lblnam1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel lblTongTien;
        private DevExpress.XtraReports.UI.XRLabel lblTongSL;
        private DevExpress.XtraReports.UI.XRLabel lblSoChungTu;
        private DevExpress.XtraReports.UI.XRLabel lblNguoiLap;
        private DevExpress.XtraReports.UI.XRLabel lblGhiChu;
    }
}
