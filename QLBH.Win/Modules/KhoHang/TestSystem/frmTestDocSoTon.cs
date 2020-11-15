using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QLBanHang.TestSystem
{
    public partial class frmTestDocSoTon : DevExpress.XtraEditors.XtraForm
    {
        public frmTestDocSoTon()
        {
            InitializeComponent();
        }

        private void bteBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string sql;
            DataSet ds;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                bteBrowse.Text = openFileDialog.FileName;

                using (OleDbConnection oConn = new OleDbConnection())
                {
                    oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", openFileDialog.FileName);
                    oConn.Open();
                    sql = "Select [Mã hàng] as MaSanPham, [Tên hàng] as TenSanPham, sum([Số lượng]) as SoLuong, [KHO] as Kho from [Items$] where KHO ='LA1.01.KD' group by [Mã hàng], [Tên hàng], [KHO]";
                    //sql = "Select [Mã hàng] as MaSanPham, [Tên hàng] as TenSanPham, [Giá nhập] as DonGia, sum([Số lượng]) as SoLuong from [Items$] group by [Mã hàng], [Tên hàng], [Giá nhập]";
                    using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                    {
                        ds = new DataSet();
                        ad.Fill(ds, "HangHoaDuDauKy");
                        grcTonKho.DataSource = ds.Tables["HangHoaDuDauKy"];

                        ad.SelectCommand.CommandText = "Select [Mã hàng] as MaSanPham, [Tên hàng] as TenSanPham, [Mã vạch] as Mavach, [Số lượng] as SoLuong, [KHO] as Kho from [Items$] where KHO ='LA1.01.KD'";
                        ad.Fill(ds, "ImportTable");
                        grcTonMaVach.DataSource = ds.Tables["ImportTable"];
                    }
                }
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            grcTonKho.ShowPrintPreview();
        }
    }

    [TestClass]
    public class frmTestDocSoTonUnit
    {
        [TestMethod]
        public void TestDocSoTon()
        {
            frmTestDocSoTon frm = new frmTestDocSoTon();
            frm.ShowDialog();
        }
    }
    
}