using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CrystalDecisions.Shared;
using QLBanHang.Modules.KhoHang.Reports;
using QLBanHang.Properties;
using System.Threading;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frmBC_PhieuNhapChuaDuChiTiet : frmBCBase
    {
        Utils ut = new Utils();
        public frmBC_PhieuNhapChuaDuChiTiet()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rpt_BC_PhieuNhapChuaDuChiTiet();
        }

        private void frmBC_KiemKeKho_Load(object sender, EventArgs e)
        {
            try {
                LoadTrungTamCommbo();
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void LoadTrungTamCommbo()
        {
            string sql;// = "select IdTrungTam, TenTrungTam from tbl_DM_TrungTam where SuDung=1";
            sql = @"SELECT  IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam where SuDung=1 and (IdTrungTam in
                    (Select IdTrungTam From tbl_DM_Kho Where IdKho in
                    (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in
                    (Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + "))) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            DataTable dt = DBTools.getData("tbl_DM_TrungTam", sql).Tables["tbl_DM_TrungTam"];
            if (dt == null) throw DBTools._LastError;
            cboTrungtam.DisplayMember = "TenTrungTam";
            cboTrungtam.ValueMember = "IdTrungTam";
            cboTrungtam.DataSource = dt;
            cboTrungtam.Refresh();
        }


        private void cboTrungtam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + Common.IntValue(cboTrungtam.SelectedValue) +
                              " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                                "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

                ut.LoadComboBox(cboKho, sql);//, 0, "");
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnXemBC_Click(object sender, EventArgs e)
        {
            try {
                //if (cboKho.SelectedValue == DBNull.Value) {
                //    MessageBox.Show("Bạn phải chọn kho để xem báo cáo");
                //    return;
                //}

                ShowReport("Báo cáo các phiếu chưa nhập đủ chi tiết");
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
            ut.SetParameterReport(myParams, "TrungTam", cboTrungtam.Text);
            ut.SetParameterReport(myParams, "Kho", cboKho.Text);
            ut.SetParameterReport(myParams, "TuNgay", dtNgayFrom.Value.ToString("dd/MM/yyyy"));
            ut.SetParameterReport(myParams, "DenNgay", dtNgayTo.Value.ToString("dd/MM/yyyy"));
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            cmdTextFormatString += " WHERE 1=1";
            cmdTextFormatString += string.Format(@" And NgayNhap >='{0}' 
                            and NgayNhap<='{1} 23:59'", ut.DateToString(dtNgayFrom.Value), ut.DateToString(dtNgayTo.Value));
            
            //if (cboTrungtam.SelectedValue != DBNull.Value)
            //    cmdTextFormatString += String.Format(" and tbl_DM_Kho.IdTrungTam={0}", Convert.ToInt32(cboTrungtam.SelectedValue));
            if (cboKho.SelectedValue != DBNull.Value)
                cmdTextFormatString += String.Format(" and IdKho={0}", Convert.ToInt32(cboKho.SelectedValue));
            if (!String.IsNullOrEmpty(txtSoPhieu.Text))
                cmdTextFormatString += String.Format(" and SoPhieuNhap Like '%{0}%'", txtSoPhieu.Text);
            if (!String.IsNullOrEmpty(txtMaSanPham.Text))
                cmdTextFormatString += String.Format(" and MaSanPham like '%{0}%'", txtMaSanPham.Text);
            if (!String.IsNullOrEmpty(txtSoPO.Text))
                cmdTextFormatString += String.Format(" and SoPO Like '%{0}%'", txtSoPO.Text);

            cmdTextFormatString += " Order by NgayNhap, SoPO, SoPhieuNhap";
            return cmdTextFormatString;

        }

        protected override void OnLoadReport()
        {
            string sql = @"select * from vPhieuNhapChuaDuChiTiet";
            base.SetParameterFields();
            base.SetSqlParameters(sql, CommandType.Text, "vPhieuNhapChuaDuChiTiet");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}