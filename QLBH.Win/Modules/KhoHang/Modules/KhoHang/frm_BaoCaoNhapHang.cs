using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CrystalDecisions.Shared;
using System.Threading;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frm_BaoCaoNhapHang : frmBCBase
    {
        Utils ut = new Utils();

        public frm_BaoCaoNhapHang()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rpt_BC_NhapHang();
        }

        
        private void frm_BaoCaoNhapHang_Load(object sender, EventArgs e)
        {
            string sql;
            //sql = @"SELECT     IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam";
            sql = @"SELECT  IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam where SuDung=1 and (IdTrungTam in
                    (Select IdTrungTam From tbl_DM_Kho Where IdKho in
                    (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in
                    (Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + "))) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            if (Declare.UserName.ToLower().Equals("admin"))
                ut.LoadComboBox(cboTrungTam, sql, 0, "");
            else
                ut.LoadComboBox1(cboTrungTam, sql);
            sql = string.Format(@"SELECT IdDoiTuong, TenDoiTuong  FROM tbl_DM_DoiTuong
                  WHERE Type IN ({0},{1})", (int)CustomerType.NHA_CUNG_CAP, (int)CustomerType.DAI_LY);
            ut.LoadComboBox(cboNCC, sql, 0, "");
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
            dtTuNgay.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtDenNgay.Enabled = false;
        }
                    
        private void cboKyBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nam = DateTime.Today.Year;
            dtDenNgay.Enabled = false;
            dtTuNgay.Enabled = false;
            if (cboKyBaoCao.Text == "Ngày")
            {
                dtTuNgay.Enabled = true;
                dtTuNgay.Value = DateTime.Today;
                dtDenNgay.Value = dtTuNgay.Value;
            }
            else if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));
                dtTuNgay.Value = new DateTime(nam, thang, 1);
                dtDenNgay.Value = new DateTime(nam, thang, DateTime.DaysInMonth(nam, thang));
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangdau = (quy - 1) * 3 + 1;
                int thangcuoi = (quy - 1) * 3 + 3;
                dtTuNgay.Value = new DateTime(nam, thangdau, 1);
                dtDenNgay.Value = new DateTime(nam, thangcuoi, DateTime.DaysInMonth(nam, thangcuoi));
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                dtTuNgay.Value = new DateTime(nam, 1, 1);
                dtDenNgay.Value = new DateTime(nam, 12, 31);
            }
            else
            {
                dtTuNgay.Enabled = true;
                dtDenNgay.Enabled = true;
            }

        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Thay doi cboSanPham
            if (cboKho.SelectedIndex >= 0)
            {
                string sql = @"SELECT distinct dbo.tbl_SanPham.IdSanPham, dbo.tbl_SanPham.TenSanPham
                            FROM dbo.tbl_HangHoa_Chitiet INNER JOIN  dbo.tbl_SanPham ON dbo.tbl_HangHoa_Chitiet.IdSanPham = dbo.tbl_SanPham.IdSanPham
                            Where IdKho=" + cboKho.SelectedValue.ToString();
                ut.LoadComboBox(cboSanPham, sql, 0, "");
            }
            else
                cboSanPham.DataSource = null;
        }

        private void cboTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboTrungTam.SelectedIndex > 0)
            //{
            string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + cboTrungTam.SelectedValue.ToString() +
                          " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                            "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            ut.LoadComboBox(cboKho, sql);//, 0, "");
            //}
            //else
            //    cboKho.Items.Clear();           
        }

        private void cboTrungTam_Click(object sender, EventArgs e)
        {
            //if (cboTrungTam.SelectedIndex > 0)
            //{
            string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + cboTrungTam.SelectedValue.ToString() +
                          " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                            "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            ut.LoadComboBox(cboKho, sql);//, 0, "");
            //}
            //else
            //    cboKho.Items.Clear();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            try {
                ShowReport("Báo cáo nhập hàng");
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
            ut.SetParameterReport(myParams, "pTrungTam", cboTrungTam.Text);
            ut.SetParameterReport(myParams, "pKho", cboKho.Text);
            ut.SetParameterReport(myParams, "pTuNgay", dtTuNgay.Value.ToString("dd/MM/yyyy"));
            ut.SetParameterReport(myParams, "pDenNgay", dtDenNgay.Value.ToString("dd/MM/yyyy"));
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            cmdTextFormatString = String.Format(cmdTextFormatString, (int)TransactionType.NHAP_PO);
            if (cboTrungTam.SelectedIndex >= 0)
                cmdTextFormatString += String.Format(" and kho.IdTrungTam={0}", cboTrungTam.SelectedValue.ToString());
            if (cboKho.SelectedIndex >= 0)
                cmdTextFormatString += String.Format(" and kho.IdKho={0}", cboKho.SelectedValue.ToString());
            if (cboNCC.SelectedIndex > 0)
                cmdTextFormatString += String.Format(" and dt.IdDoiTuong={0}", cboNCC.SelectedValue.ToString());
            if (cboSanPham.SelectedIndex > 0)
                cmdTextFormatString += String.Format(" and ctct.IdSanPham={0}", cboSanPham.SelectedValue.ToString());
            if (ut.isStringNotEmpty(txtSophieu.Text))
                cmdTextFormatString += string.Format(" and ct.SoChungTu='{0}'", txtSophieu.Text.Trim());
            if (!String.IsNullOrEmpty(txtMaSanPham.Text))
                cmdTextFormatString += String.Format(" and sp.MaSanPham like N'%{0}%'", txtMaSanPham.Text);
            cmdTextFormatString += string.Format(" and ct.NgayLap>='{0}' and ct.NgayLap<='{1}'", ut.DateToString(dtTuNgay.Value), ut.DateToString(dtDenNgay.Value));
            return cmdTextFormatString;
        }

        protected override void OnLoadReport()
        {
            string sql= @"select sp.MaSanPham, sp.TenSanPham, dvt.TenDonViTinh, ctct.SoLuong, ctct.DonGia, 
                ctct.ThanhTien, dt.TenDoiTuong as NhaCungCap, ct.NgayLap
                from tbl_ChungTu_ChiTiet ctct
                inner join tbl_SanPham sp on sp.IdSanPham = ctct.IdSanPham
                inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh = sp.IdDonViTinh
                inner join tbl_ChungTu ct on ct.IdChungTu = ctct.IdChungTu
                left outer join tbl_DM_DoiTuong dt on ct.IdDoiTuong = dt.IdDoiTuong
                inner join tbl_DM_Kho kho on ct.IdKho = kho.IdKho
                where LoaiChungTu={0}";
            base.SetSqlParameters(sql, CommandType.Text, "vBaoCaoNhapHang");
            base.SetParameterFields();
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (cboKyBaoCao.Text == "Ngày")
                dtDenNgay.Value = dtTuNgay.Value;
        }
    }
}