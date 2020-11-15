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
    public partial class frmBC_KiemKeKho : frmBCBase
    {
        Utils ut = new Utils();
        public frmBC_KiemKeKho()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rptBCKiemKeKho();
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
                MessageBox.Show("Bạn phải chọn kho để kiểm kê!");
                return;
            }
            try {
                ShowReport("Báo cáo kiểm kê kho");
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
            cmdTextFormatString += string.Format(" where NgayKiemKe >='{0}' and NgayKiemKe<='{1} 23:59'", ut.DateToString(dtNgayFrom.Value), ut.DateToString(dtNgayTo.Value));
            
            if (cboKho.SelectedValue != DBNull.Value)
                cmdTextFormatString += String.Format(" and IdKho={0}", Convert.ToInt32(cboKho.SelectedValue));
            if (!String.IsNullOrEmpty(txtSoPhieu.Text)) 
                cmdTextFormatString += String.Format(" and SoPhieu Like '%{0}%'", txtSoPhieu.Text);
            if (!String.IsNullOrEmpty(txtMaSanPham.Text))
                cmdTextFormatString += String.Format(" and MaSanPham like '%{0}%'", txtMaSanPham.Text);
            if (!String.IsNullOrEmpty(txtTenSanPham.Text))
                cmdTextFormatString += String.Format(" and TenSanPham like N'%{0}%'", txtTenSanPham.Text);

            return cmdTextFormatString;

        }

        protected override void OnLoadReport()
        {
            string sql = "Select * from vBCKiemKeKho";
            base.SetParameterFields();
            base.SetSqlParameters(sql, CommandType.Text, "vBCKiemKeKho");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}