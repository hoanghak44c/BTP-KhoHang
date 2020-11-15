using System;
using System.Data;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frmBC_TonDauKy : frmBCBase
    {
        Utils ut = new Utils();
        public frmBC_TonDauKy()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rptBC_TonDauKy();
        }

        private void frmBC_TonDauKy_Load(object sender, EventArgs e)
        {
            string sql;// = "select IdTrungTam, TenTrungTam from tbl_DM_TrungTam where SuDung=1";
            sql = @"SELECT  IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam where SuDung=1 and (IdTrungTam in
                    (Select IdTrungTam From tbl_DM_Kho Where IdKho in
                    (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in
                    (Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + "))) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            if (Declare.UserName.ToLower().Equals("admin"))
                ut.LoadComboBox(cboTrungTam, sql, 0, "");
            else
                ut.LoadComboBox1(cboTrungTam, sql);
            //ut.LoadComboBox(cboTrungTam, sql, 0, "");
        }

        private void cboTrungTam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cboTrungTam.SelectedIndex > 0){
            string sql = "SELECT IdKho,TenKho FROM tbl_DM_Kho WHERE sudung=1 and IdTrungTam=" + cboTrungTam.SelectedValue.ToString() +
                          " and (IdKho in (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in " +
                            "(Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + ")) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            ut.LoadComboBox(cboKho, sql);//, 0, "");
            //}
        }

        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKho.SelectedIndex >= 0) {
                string sql = string.Format("select distinct ThoiGian from tbl_HangHoa_DuDauKy where IdKho={0} order by ThoiGian desc", cboKho.SelectedValue);
                cboNgayDuDau.DisplayMember = "ThoiGian";
                cboNgayDuDau.ValueMember = "ThoiGian";
                cboNgayDuDau.DataSource = DBTools.getData("Temp", sql).Tables["Temp"];
            }
        }

        private void cmdIn_Click(object sender, EventArgs e)
        {
            try {
                ShowReport("Báo cáo tồn đầu kỳ");
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnSetSqlParameters(GtidParameterCollection sqlParams)
        {
            if (cboNgayDuDau.SelectedValue != null)
                sqlParams.AddWithValue("@ThoiGian", cboNgayDuDau.SelectedValue).Direction = ParameterDirection.Input;
            if (cboTrungTam.SelectedValue != null && int.Parse(cboTrungTam.SelectedValue.ToString()) != 0)
                sqlParams.AddWithValue("@IdTrungTam", cboTrungTam.SelectedValue).Direction = ParameterDirection.Input;
            if (cboKho.SelectedValue != null && int.Parse(cboKho.SelectedValue.ToString()) != 0)
                sqlParams.AddWithValue("@IdKho", cboKho.SelectedValue).Direction = ParameterDirection.Input;
            if (ut.isStringNotEmpty(txtTenSanPham.Text))
                sqlParams.AddWithValue("@SanPham", txtTenSanPham.Text).Direction = ParameterDirection.Input;

        }
        protected override void OnLoadReport()
        {
            base.SetSqlParameters("sp_BaoCaoTonDauKy", CommandType.StoredProcedure, "vBCTonDauKy");
        }
    }
}