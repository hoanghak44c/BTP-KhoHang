using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.BanHang;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_NoteSanPhamA5 : DevExpress.XtraReports.UI.XtraReport
    {
        private string ThongTin,NhaCC;
        private bool Check;
        public rpt_BC_NoteSanPhamA5()
        {
            InitializeComponent();
        }
        public rpt_BC_NoteSanPhamA5(string CauHinh,string NhaCC,bool check)
        {
            InitializeComponent();
            this.ThongTin = CauHinh;
            this.NhaCC = NhaCC;
            this.Check = check;
            lblTenHang.Font = new Font("Myriad Pro", 16, FontStyle.Bold);
            lblModel.Font = new Font("Myriad Pro", 14, FontStyle.Bold);
            lblMaSP.Font = new Font("Myriad Pro", 12, FontStyle.Regular);
            lblGiaVAT.Font = new Font("Myriad Pro", 11, FontStyle.Regular);
            lblGiaCoVAT.Font = new Font("Myriad Pro", 16, FontStyle.Bold);
            //lblGiaCoVAT.Width = 350;
            //xrSubreport1.Height = 130;
            //xrPictureBox1.Height = 83;
            //xrPictureBox1.Width = 192;
        }
               
        public void BindHeader()
        {
            lblModel.DataBindings.Add("Text", DataSource, "Model");
            lblMaSP.DataBindings.Add("Text", DataSource, "MaSanPham");
            //lblNhaCC.DataBindings.Add("Text", DataSource, "NhaCC");
            xrPictureBox1.DataBindings.Add("Text", DataSource, "NhaCC");
            lblTenHang.DataBindings.Add("Text", DataSource, "Loai");
            if (Check)
                lblGiaCoVAT.DataBindings.Add("Text", DataSource, "Gia", "{0:0,0 VNĐ}");
           // lblGiaCoVAT.Text += " VNĐ";
            //lblGiaCoVAT.Text = String.Format("{0:0,0 VNĐ}", Convert.ToDouble(GetCurrentColumnValue("Gia"))).Replace(',','.');
        }
        public void SetDiemThuong(int idTrungTam)
        {
            try
            {
                string maSanPham = Convert.ToString(GetCurrentColumnValue("MaSanPham"));
                double donGia = Convert.ToDouble(GetCurrentColumnValue("Gia"));

                lblDiemThuong.Text = CommonFuns.Instance.GetDiemThuong(maSanPham, idTrungTam, donGia);
            }
            catch
            {
            }
        }
        public List<NoteSanPhamReportInfor> GetListHeaderInfors(string idSanPham,int idTrungTam)
        {
            return NoteReportDataProvider.Instance.SanPhamGetHeaderByIdSanPham(idSanPham,idTrungTam);
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rpt_BC_NoteSanPhamA5Detail rpt = (rpt_BC_NoteSanPhamA5Detail)xrSubreport1.ReportSource;
            rpt.DataSource = rpt.GetListCauHinhDetail(Convert.ToString(GetCurrentColumnValue("IdSanPham")), ThongTin);
            rpt.BindDetail();
        }
        //public int x { get; set; }
        //public int y { get; set; }
        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string path = String.Format("http://logo.trananh.com.vn/{0}.jpg", xrPictureBox1.Text);

                System.Net.WebRequest req = System.Net.WebRequest.Create(path);
                System.Net.WebResponse response = req.GetResponse();
                System.IO.Stream stream = response.GetResponseStream();
                if (path != null)
                {
                    //Image im = new Bitmap(path, true);
                    Image im = Image.FromStream(stream);

                    
                    
                    ((XRPictureBox)sender).Size = new Size(192, 83); //fix kich thuoc logo truoc khi in

                    ((XRPictureBox)sender).Image = im;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hãng " + xrPictureBox1.Text + " chưa có Logo");
                ((XRPictureBox) sender).Image = null;
            }
        }
        // xin của anh Trình
        public enum AnchorPosition
        {
            Top,Center,Bottom,Left,Right
        }
        public Image Crop(Image imgPhoto, int Width, int Height, AnchorPosition Anchor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentW;
                switch (Anchor)
                {
                    case AnchorPosition.Top:
                        destY = 0;
                        break;
                    case AnchorPosition.Bottom:
                        destY = (int)(Height - (sourceHeight * nPercent));
                        break;
                    default:
                        destY = (int)((Height - (sourceHeight * nPercent)) / 3);
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (Anchor)
                {
                    case AnchorPosition.Left:
                        destX = 0;
                        break;
                    case AnchorPosition.Right:
                        destX = (int)(Width - (sourceWidth * nPercent));
                        break;
                    default:
                        destX = (int)((Width - (sourceWidth * nPercent)) / 2);
                        break;
                }
            }
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format32bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBilinear;
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //grPhoto.SmoothingMode = SmoothingMode.HighSpeed;

            //grPhoto.InterpolationMode = InterpolationMode.Low;

            //grPhoto.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);
            grPhoto.DrawRectangle(new Pen(Color.White, 4), new Rectangle(destX, destY, destWidth, destHeight));
            grPhoto.Dispose();
            //OnSharpen

            //if (Width < 168)
            //{

            //    BitmapFilter.Sharpen(bmPhoto, 14);

            //}
            return bmPhoto;
        }
    }
}
