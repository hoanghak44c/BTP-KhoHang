using System;
using System.Data;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Forms
{
    public partial class frmBC_InHDPhieu : Form
    {
        string SoHD_Phieu = "";
        string ReportType = "";
        string QuyenSo = "";
        GtidConnection cnn;
        GtidDataAdapter da;
        DataSet ds = new DataSet();

        public frmBC_InHDPhieu()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmBC_InHDPhieu( string strReportType, string strSoPhieu)
        {
            InitializeComponent();
            ReportType = strReportType;
            SoHD_Phieu = strSoPhieu;
            Common.LoadStyle(this);
        }
        public frmBC_InHDPhieu(string strReportType, string strSoPhieu,string IdQuyen)
        {
            InitializeComponent();
            ReportType = strReportType;
            SoHD_Phieu = strSoPhieu;
            this.QuyenSo = IdQuyen;
            Common.LoadStyle(this);
        }
        private void frmBC_InHDPhieu_Load(object sender, EventArgs e)
        {
            string strCaption = "";
            string ReportFile = Declare.AppPath;
            string sql = "";
            cnn = ConnectionUtil.Instance.GetConnection();
            switch (ReportType)
            {
                case "PN":
                    {
                        this.Text= "In phiếu nhập kho";
                        sql = " select * from vThongTinNhaThuoc;select * from vPhieuNhap where SoPhieuNhap=N'" + SoHD_Phieu + "';select * from vChiTiet_PhieuNhap where SoPhieuNhap=N'" + SoHD_Phieu + "'";
                        ReportFile = ReportFile + "Reports\\rptPhieuNhapKho.rpt";
                        da = new GtidDataAdapter(sql,cnn);
                        da.Fill(ds);
                        ds.Tables[0].TableName = "vThongTinNhaThuoc";
                        ds.Tables[1].TableName = "vPhieuNhap";
                        ds.Tables[2].TableName = "vChiTiet_PhieuNhap";
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            rptPhieuNhapKho rpt = new rptPhieuNhapKho();
                            rpt.SetDataSource(ds);
                            rptViewer.ReportSource = rpt;
                            rptViewer.RefreshReport();
                           
                            return;
                        }
                        break;
                    }
                case "PX":
                    {
                        this.Text = "In phiếu xuất kho";
                        sql = " select * from vThongTinNhaThuoc;select * from vPhieuXuat where SoPhieuXuat=N'" + SoHD_Phieu + "';select * from vChiTiet_PhieuXuat where SoPhieuXuat=N'" + SoHD_Phieu + "'";
                        ReportFile = ReportFile + "Reports\\rptPhieuXuatKho.rpt";
                        da = new GtidDataAdapter(sql, cnn);
                        da.Fill(ds);
                        ds.Tables[0].TableName = "vThongTinNhaThuoc";
                        ds.Tables[1].TableName = "vPhieuXuat";
                        ds.Tables[2].TableName = "vChiTiet_PhieuXuat";
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            rptPhieuXuatKho rpt = new rptPhieuXuatKho();
                            rpt.SetDataSource(ds);
                            rptViewer.ReportSource = rpt;
                            rptViewer.RefreshReport();
                            return;
                        }
                        break;
                    }
                case "PDC":
                    {
                        strCaption = "In phiếu điều chuyển hàng";
                        sql = " SELECT     SoLuong, GhiChu, NVNhap, TenThuoc, TenNhaSanXuat, KhoXuat, SoPhieuDC, NgayLap, TenDonViTinh, IdKho, IdThuoc, KhoNhap, NVXuat, HanDung FROM  vPhieuDieuChuyen";
                        sql = sql + " WHERE SoPhieuDC = '" + SoHD_Phieu.Trim() + "'";
                        ReportFile = ReportFile + "Reports\\rptPhieuDieuChuyen.rpt";

                        break;
                    }
            }
            this.Text = strCaption;

            if (!DBTools.ExistData(sql))
            {
                MessageBox.Show("Không có dữ liệu. Chọn số phiếu khác để in!", Declare.titleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DBTools.LoadReportFile(ReportFile, sql, rptViewer);
                this.rptViewer.RefreshReport();
            }

        }
    }
}