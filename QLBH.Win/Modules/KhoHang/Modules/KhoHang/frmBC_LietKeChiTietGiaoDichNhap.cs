using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Threading;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frmBC_LietKeChiTietGiaoDichNhap : frmBCBase
    {
        Utils ut = new Utils();
        public frmBC_LietKeChiTietGiaoDichNhap()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rptBC_LietKeChiTietNhapHang();
        }

        private void frmBC_LietKeChiTietGiaoDichNhap_Load(object sender, EventArgs e)
        {
            LoadComboTrungTam();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try {
                ShowReport("Báo cáo liệt kê chi tiết giao dịch nhập");
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
            ut.SetParameterReport(myParams, "TrungTam", cboTrungTam.Text);
            ut.SetParameterReport(myParams, "Date", String.Format("Từ ngày {0} đến ngày {1}", dtFromDate.Value, dtToDate.Value));
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            IFormatProvider IProvider = new CultureInfo("en-US");
            cmdTextFormatString += String.Format(" and ct.NgayLap >='{0}' and ct.NgayLap <= '{1}'", dtFromDate.Value.ToString(IProvider), dtToDate.Value.ToString(IProvider));
            if (cboTrungTam.SelectedIndex >= 0) {
                cmdTextFormatString += String.Format(" and tt.IdTrungTam = {0} ", cboTrungTam.SelectedValue);
            }
            if (!String.IsNullOrEmpty(txtMaSanPham.Text))
                cmdTextFormatString += String.Format(" and sp.MaSanPham like '%{0}%'", txtMaSanPham.Text);
            if (!String.IsNullOrEmpty(txtTenSanPham.Text))
                cmdTextFormatString += String.Format(" and sp.TenSanPham like N'%{0}%'", txtTenSanPham.Text);

            return cmdTextFormatString;
            
        }
        protected override void OnLoadReport()
        {
            string sql = String.Format(@"select ct.SoChungTu, ct.SoSeri, ct.NgayLap, tt.TenTrungTam, sp.MaSanPham, sp.TenSanPham,
	                     ctct.SoLuong, ctct.DonGia, ctct.ThanhTien, ct.GhiChu, kho.MaKho, dvt.TenDonViTinh from tbl_ChungTu ct
                    inner join tbl_ChungTu_ChiTiet ctct on ct.IdChungTu = ctct.IdChungTu
                    inner join tbl_DM_Kho kho on ct.IdKho = kho.IdKho
                    inner join tbl_DM_TrungTam tt on kho.IdTrungTam = tt.IdTrungTam
                    inner join tbl_SanPham sp on ctct.IdSanPham = sp.IdSanPham
                    inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh = sp.IdDonViTinh
                    where ct.LoaiChungTu = {0}", (int)TransactionType.NHAP_PO);
            base.SetParameterFields();
            base.SetSqlParameters(sql, CommandType.Text, "vBaoCaoLietKeChiTietGiaoDichNhap");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboTrungTam()
        {
            string sql;// = "select IdTrungTam, TenTrungTam from tbl_DM_TrungTam";
            sql = @"SELECT  IdTrungTam, TenTrungTam FROM tbl_DM_TrungTam where SuDung=1 and (IdTrungTam in
                    (Select IdTrungTam From tbl_DM_Kho Where IdKho in
                    (Select IdKho From tbl_Kho_NhanVien Where IdNhanVien in
                    (Select IdNhanVien From tbl_DM_NguoiDung Where IdNguoiDung=" + Declare.UserId + "))) or ('admin'='" + Declare.UserName.ToLower() + "'))";

            DataTable dt = DBTools.getData("Temp", sql).Tables["Temp"];
            //dt.Rows.InsertAt(dt.NewRow(), 0);
            cboTrungTam.DisplayMember = "TenTrungTam";
            cboTrungTam.ValueMember = "IdTrungTam";
            cboTrungTam.DataSource = dt;
            cboTrungTam.Refresh();
            if (dt != null && dt.Rows.Count > 0)
                cboTrungTam.SelectedIndex = 0;
        }

    }
}