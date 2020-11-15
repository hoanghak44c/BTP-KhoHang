using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Reports;
using QLBanHang.Properties;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Threading;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frm_BaoCaoTonKho : frmBCBase
    {
        Utils ut = new Utils();
        public frm_BaoCaoTonKho()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            //rpt = new rptBCTongHopNew();
            rpt = new rpt_BC_TongHopTonKho();
        }

        private void frm_BaoCaoTonKho_Load(object sender, EventArgs e)
        {
            string sql;
            sql = @"SELECT  IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam where SuDung=1 and (IdTrungTam in
                    (Select IdTrungTam From tbl_DM_Kho Where IdKho in
                    (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in
                    (Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + "))) or ('admin'='" + Declare.UserName.ToLower() + "'))";
            if (Declare.UserName.ToLower().Equals("admin"))
                ut.LoadComboBox(cboTrungTam, sql, 0, "");
            else
                ut.LoadComboBox1(cboTrungTam, sql);
            //----------------
            cboKyBaoCao.Items.Add("Ngày");
            for (int i = 1; i < 13; i++)
                cboKyBaoCao.Items.Add("Tháng " + i.ToString());
            for (int i = 1; i <= 4; i++)
                cboKyBaoCao.Items.Add("Quý " + i.ToString());
            cboKyBaoCao.Items.Add("Năm");
            cboKyBaoCao.Items.Add("Tùy chọn");
            //----------------
            dtTuNgay.Enabled = false;
            dtDenNgay.Enabled = false;

        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Thay doi cboSanPham
            if (cboKho.SelectedIndex > 0) {
                string sql = @"SELECT distinct dbo.tbl_SanPham.IdSanPham, dbo.tbl_SanPham.TenSanPham
                            FROM dbo.tbl_HangHoa_Chitiet INNER JOIN  dbo.tbl_SanPham ON dbo.tbl_HangHoa_Chitiet.IdSanPham = dbo.tbl_SanPham.IdSanPham
                            Where dbo.tbl_SanPham.SuDung=1 and IdKho=" + cboKho.SelectedValue.ToString();
                ut.LoadComboBox(cboSanPham, sql, 0, "");
            }
            else {
                cboSanPham.DataSource = null;
                cboSanPham.Items.Clear();
            }
        }

        private void cboKyBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nam = DateTime.Today.Year;
            dtDenNgay.Enabled = false;
            dtTuNgay.Enabled = false;
            if (cboKyBaoCao.Text == "Ngày") {
                dtTuNgay.Enabled = true;
                dtTuNgay.Value = DateTime.Today;
                dtDenNgay.Value = dtTuNgay.Value;
            }
            else if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0) {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));
                dtTuNgay.Value = new DateTime(nam, thang, 1);
                dtDenNgay.Value = new DateTime(nam, thang, DateTime.DaysInMonth(nam, thang));
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0) {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangdau = (quy - 1) * 3 + 1;
                int thangcuoi = (quy - 1) * 3 + 3;
                dtTuNgay.Value = new DateTime(nam, thangdau, 1);
                dtDenNgay.Value = new DateTime(nam, thangcuoi, DateTime.DaysInMonth(nam, thangcuoi));
            }
            else if (cboKyBaoCao.Text == "Năm") {
                dtTuNgay.Value = new DateTime(nam, 1, 1);
                dtDenNgay.Value = new DateTime(nam, 12, 31);
            }
            else {
                dtTuNgay.Enabled = true;
                dtDenNgay.Enabled = true;
            }

        }

        private void cboTrungTam_Click(object sender, EventArgs e)
        {
            //if (cboTrungTam.SelectedIndex > 0) {
            string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + cboTrungTam.SelectedValue.ToString() +
                          " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                            "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            ut.LoadComboBox(cboKho, sql);//, 0, "");
            //}
            //else {
            //    cboKho.DataSource = null;
            //    cboKho.Items.Clear();
            //}
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            try {
                ShowReport("Báo cáo tồn");
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            myParams.Clear();
            ut.SetParameterReport(myParams, "TenTrungTam", cboTrungTam.Text);
            ut.SetParameterReport(myParams, "TenKho", cboKho.Text);
            ut.SetParameterReport(myParams, "ParaDateFrom", dtTuNgay.Value.Date.ToString("dd/MM/yyyy"));
            ut.SetParameterReport(myParams, "ParaDateTo", dtDenNgay.Value.Date.ToString("dd/MM/yyyy"));
        }
        protected override void OnSetSqlParameters(GtidParameterCollection sqlParams)
        {
            sqlParams.Clear();
            sqlParams.AddWithValue("@FromDate", dtTuNgay.Value.Date);
            sqlParams.AddWithValue("@ToDate", dtDenNgay.Value.Date.AddHours(24));
            sqlParams.AddWithValue("@IdTrungTam", cboTrungTam.SelectedValue);
            sqlParams.AddWithValue("@IdKho", cboKho.SelectedValue);
            sqlParams.AddWithValue("@IdSanPham", cboSanPham.SelectedValue);
            if (ut.isStringNotEmpty(txtTenSanPham.Text))
                sqlParams.AddWithValue("@SanPham", txtTenSanPham.Text);
        }
        protected override void OnLoadReport()
        {
            base.SetSqlParameters("sp_BaoCaoTongHopNew", CommandType.StoredProcedure, "vBCTonKho");
            base.SetParameterFields();
        }
        
        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cboKyBaoCao.Text == "Ngày")
                dtDenNgay.Value = dtTuNgay.Value;
        }

        private void cboTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTrungTam.SelectedIndex > 0) {
            string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + cboTrungTam.SelectedValue.ToString() +
                          " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                            "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            ut.LoadComboBox(cboKho, sql);//, 0, "");
            //}
            //else {
            //    cboKho.DataSource = null;
            //    cboKho.Items.Clear();
            //}
        }

        private void btnViewInBackGround_Click(object sender, EventArgs e)
        {
            try {
                ShowReport("Báo cáo tồn", true);
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}