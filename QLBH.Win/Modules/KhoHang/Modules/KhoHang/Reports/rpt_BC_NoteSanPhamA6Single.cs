using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class rpt_BC_NoteSanPhamA6Single : DevExpress.XtraReports.UI.XtraReport
    {
        private string ThongTin,NhaCC;
        public rpt_BC_NoteSanPhamA6Single()
        {
            InitializeComponent();
        }
        public rpt_BC_NoteSanPhamA6Single(string CauHinh, string NhaCC)
        {
            InitializeComponent();
            this.ThongTin = CauHinh;
            this.NhaCC = NhaCC;
            lblTenHang.Font = new Font("Myriad Pro", 12, FontStyle.Bold);
            lblModel.Font = new Font("Myriad Pro", 11, FontStyle.Bold);
            lblMaSP.Font = new Font("Myriad Pro", 10, FontStyle.Regular);
            lblGiaVAT.Font = new Font("Myriad Pro", 9, FontStyle.Regular);
        }
        public void BindHeader()
        {
            lblModel.DataBindings.Add("Text", DataSource, "Model");
            lblMaSP.DataBindings.Add("Text", DataSource, "MaSanPham");
            //lblNhaCC.DataBindings.Add("Text", DataSource, "NhaCC");
            lblTenHang.DataBindings.Add("Text", DataSource, "Loai");
            xrPictureBox1.DataBindings.Add("Text", DataSource, "NhaCC");
        }

        public List<NoteSanPhamReportInfor> GetListHeaderInfors(string idSanPham,int idTrungTam)
        {
            return NoteReportDataProvider.Instance.SanPhamGetHeaderByIdSanPham(idSanPham,idTrungTam);
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rpt_BC_NoteSanPhamA6Detailnew rpt = (rpt_BC_NoteSanPhamA6Detailnew)xrSubreport1.ReportSource;
            rpt.DataSource = rpt.GetListCauHinhDetail(Convert.ToString(GetCurrentColumnValue("IdSanPham")), ThongTin);
            rpt.BindDetail();
        }

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
                    ((XRPictureBox)sender).Image = im;//Crop(im, 192, 83, AnchorPosition.Center);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hãng " + xrPictureBox1.Text + " chưa có Logo");
            }
        }
    }
}
