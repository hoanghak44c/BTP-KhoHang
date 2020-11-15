using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using CrystalDecisions.Shared;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frmBC_HangNhapChuaCoTrongOracle : frmBCBase
    {
        Utils ut = new Utils();
        public frmBC_HangNhapChuaCoTrongOracle()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rptBC_HangNhapChuaCoTrongOracle();
        }

        private void frmBC_KiemKeKho_Load(object sender, EventArgs e)
        {
            LoadTrungTamCommbo();            
        }

        private void LoadTrungTamCommbo()
        {
            string sql;// = "select IdTrungTam, TenTrungTam from tbl_DM_TrungTam where SuDung=1";
            sql = @"SELECT  IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam where SuDung=1 and (IdTrungTam in
                    (Select IdTrungTam From tbl_DM_Kho Where IdKho in
                    (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in
                    (Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + "))) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            DataTable dt = DBTools.getData("tbl_DM_TrungTam", sql).Tables["tbl_DM_TrungTam"];
            //dt.Rows.InsertAt(dt.NewRow(), 0);
            cboTrungtam.DisplayMember = "TenTrungTam";
            cboTrungtam.ValueMember = "IdTrungTam";
            cboTrungtam.DataSource = dt;
            cboTrungtam.Refresh();
            if (dt != null && dt.Rows.Count > 0)
                cboTrungtam.SelectedIndex = 0;
        }

        private void cboTrungtam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + cboTrungtam.SelectedValue.ToString() +
                          " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                            "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            ut.LoadComboBox(cboKho, sql);//, 0, "");
        }

        private void btnXemBC_Click(object sender, EventArgs e)
        {
            if (cboKho.SelectedValue == DBNull.Value)
            {
                MessageBox.Show("Bạn phải chọn kho để xem báo cáo");
                return;
            }
            
            try {
                ShowReport("Báo cáo mặt hàng chưa có mã trong oracle");
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
            ut.SetParameterReport(myParams, "TenTrungTam", cboTrungtam.Text);
            ut.SetParameterReport(myParams, "TenKho", cboKho.Text);
            ut.SetParameterReport(myParams, "NgayFrom", dtNgayFrom.Value.ToString("dd/MM/yyyy"));
            ut.SetParameterReport(myParams, "NgayTo", dtNgayTo.Value.ToString("dd/MM/yyyy"));
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            IFormatProvider IProvider = new CultureInfo("en-US");
            cmdTextFormatString += string.Format(@" WHERE (dbo.tbl_LichSu_NhapHang.MaSanPham NOT IN
                          (SELECT MaSanPham FROM dbo.tbl_SanPham)) And NgayNhap >='{0}' 
                            and NgayNhap<='{1} 23:59'", ut.DateToString(dtNgayFrom.Value), ut.DateToString(dtNgayTo.Value));
            
            //if (cboTrungtam.SelectedValue != DBNull.Value)
            //    cmdTextFormatString += String.Format(" and tbl_DM_Kho.IdTrungTam={0}", Convert.ToInt32(cboTrungtam.SelectedValue));
            if (cboKho.SelectedValue != DBNull.Value)
                cmdTextFormatString += String.Format(" and tbl_DM_Kho.IdKho={0}", Convert.ToInt32(cboKho.SelectedValue));
            if (!String.IsNullOrEmpty(txtSoPhieu.Text))
                cmdTextFormatString += String.Format(" and dbo.tbl_LichSu_NhapHang.SoPhieuNhap Like '%{0}%'", txtSoPhieu.Text);
            if (!String.IsNullOrEmpty(txtMaSanPham.Text))
                cmdTextFormatString += String.Format(" and dbo.tbl_LichSu_NhapHang.MaSanPham like '%{0}%'", txtMaSanPham.Text);
            if (!String.IsNullOrEmpty(txtSoPO.Text))
                cmdTextFormatString += String.Format(" and dbo.tbl_LichSu_NhapHang.SoPO Like '%{0}%'", txtSoPO.Text);
            return cmdTextFormatString;

        }

        protected override void OnLoadReport()
        {
            string sql = @"SELECT     dbo.tbl_LichSu_NhapHang.IdPhieuNhap, dbo.tbl_LichSu_NhapHang.InventoryOrg, dbo.tbl_LichSu_NhapHang.InventorySub, 
                      dbo.tbl_LichSu_NhapHang.SoPO, dbo.tbl_LichSu_NhapHang.SoPhieuNhap, dbo.tbl_LichSu_NhapHang.NgayNhap, dbo.tbl_LichSu_NhapHang.GhiChu, 
                      dbo.tbl_LichSu_NhapHang.TongTienHang, dbo.tbl_LichSu_NhapHang.ThoiGian, dbo.tbl_LichSu_NhapHang.MaSanPham, 
                      dbo.tbl_LichSu_NhapHang.SoLuong, dbo.tbl_LichSu_NhapHang.DonGia, dbo.tbl_LichSu_NhapHang.ThanhTien
FROM         dbo.tbl_LichSu_NhapHang INNER JOIN
                      dbo.tbl_DM_Kho ON dbo.tbl_LichSu_NhapHang.InventorySub = dbo.tbl_DM_Kho.MaKho";
            base.SetParameterFields();
            base.SetSqlParameters(sql, CommandType.Text, "vBCHangNhapChuaCoTrongOracle");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}