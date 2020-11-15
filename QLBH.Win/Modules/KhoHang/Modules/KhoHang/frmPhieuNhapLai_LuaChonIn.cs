using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using System.Data.SqlTypes;
using CrystalDecisions.Shared;
using System.Threading;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Objects;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frmPhieuNhapLai_LuaChonIn : frmBCBase
    {
        Utils ut = new Utils();
        public PhieuXuat phieuXuat = null;
        public string soPhieuNhap = "";
        public frmPhieuNhapLai_LuaChonIn()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmPhieuNhapLai_LuaChonIn(PhieuXuat px, string phieunhap)
        {
            InitializeComponent();
            this.phieuXuat = px;
            this.soPhieuNhap = phieunhap;
            Common.LoadStyle(this);
        }
        private void frmPhieuXuat_LuaChonIn_Load(object sender, EventArgs e)
        {
            chkBill.Checked = Declare.InBill;
            chkBillImei.Checked = Declare.InBill;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (chkBill.Checked)
                inBill();
            if (chkBillImei.Checked)
                inBillImei();
            if (!chkBill.Checked && !chkBillImei.Checked)
                MessageBox.Show("Bạn chưa chọn loại phiếu để in");
        }

        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            myParams.Clear();
            switch (base.Key) {
                case "In phiếu nhập chi tiết theo IMEI":
                    string[] kho = phieuXuat.KhoXuat.Split(" - ".ToCharArray());
                    ut.SetParameterReport(myParams, "TrungTam", phieuXuat.TrungTam);
                    ut.SetParameterReport(myParams, "Kho", phieuXuat.KhoXuat);
                    ut.SetParameterReport(myParams, "DiaChiKho", phieuXuat.DiaChiKho);
                    ut.SetParameterReport(myParams, "DienThoai", phieuXuat.DienThoaiKho);
                    ut.SetParameterReport(myParams, "TenNhanVien", phieuXuat.NhanVien);
                    ut.SetParameterReport(myParams, "TenKhachHang", phieuXuat.TenKhachHang);
                    ut.SetParameterReport(myParams, "DiaChiKH", phieuXuat.DiaChiKH);
                    ut.SetParameterReport(myParams, "DienThoaiKH", phieuXuat.DienThoaiKH);
                    ut.SetParameterReport(myParams, "MaSoThueKH", phieuXuat.MaSoThueKH);
                    ut.SetParameterReport(myParams, "NoiDungXuat", phieuXuat.GhiChu);
                    ut.SetParameterReport(myParams, "NgayXuat", String.Format("Ngày {0} tháng {1} năm {2}", phieuXuat.NgayXuat.Day, phieuXuat.NgayXuat.Month, phieuXuat.NgayXuat.Year));
                    ut.SetParameterReport(myParams, "SoPhieuXuat", phieuXuat.SoPhieuXuat);
                    ut.SetParameterReport(myParams, "MaKho", kho[0]);
                    ut.SetParameterReport(myParams, "SoPhieuNhap", soPhieuNhap);
                    break;
                default:
                    ut.SetParameterReport(myParams, "TrungTam", phieuXuat.TrungTam);
                    ut.SetParameterReport(myParams, "Kho", phieuXuat.KhoXuat);
                    ut.SetParameterReport(myParams, "DiaChiKho", phieuXuat.DiaChiKho);
                    ut.SetParameterReport(myParams, "DienThoai", phieuXuat.DienThoaiKho);
                    ut.SetParameterReport(myParams, "TenNhanVien", phieuXuat.NhanVien);
                    ut.SetParameterReport(myParams, "TenKhachHang", phieuXuat.TenKhachHang);
                    ut.SetParameterReport(myParams, "DiaChiKH", phieuXuat.DiaChiKH);
                    ut.SetParameterReport(myParams, "DienThoaiKH", phieuXuat.DienThoaiKH);
                    ut.SetParameterReport(myParams, "MaSoThueKH", phieuXuat.MaSoThueKH);
                    ut.SetParameterReport(myParams, "NoiDungXuat", phieuXuat.GhiChu);
                    ut.SetParameterReport(myParams, "NgayXuat", String.Format("Ngày {0} tháng {1} năm {2}", phieuXuat.NgayXuat.Day, phieuXuat.NgayXuat.Month, phieuXuat.NgayXuat.Year));
                    ut.SetParameterReport(myParams, "SoPhieuXuat", phieuXuat.SoPhieuXuat);
                    ut.SetParameterReport(myParams, "TongTienHang", phieuXuat.TongTienHang);
                    ut.SetParameterReport(myParams, "TongTienChietKhau", phieuXuat.TongTienCK);
                    ut.SetParameterReport(myParams, "TongTienVAT", phieuXuat.TongTienVAT);
                    ut.SetParameterReport(myParams, "TongTienThanhToan", phieuXuat.TongTienThanhToan);
                    ut.SetParameterReport(myParams, "TongTienChu", Common.ReadNumner_(Common.Double2Str(phieuXuat.TongTienThanhToan)));
                    ut.SetParameterReport(myParams, "HinhThucThanhToan", phieuXuat.HinhThucTT);
                    ut.SetParameterReport(myParams, "TongTienThanhToan", phieuXuat.TongTienThanhToan);
                    ut.SetParameterReport(myParams, "TienThucTra", phieuXuat.TienThucTra);
                    ut.SetParameterReport(myParams, "TienConNo", phieuXuat.TienConNo);
                    ut.SetParameterReport(myParams, "TienTe", phieuXuat.TienTe);
                    ut.SetParameterReport(myParams, "SoPhieuNhap", soPhieuNhap);
                    break;
            }
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            switch (base.Key) {
                case "In phiếu nhập hàng trả lại":
                case "In phiếu nhập chi tiết theo IMEI":
                    return String.Format(cmdTextFormatString, phieuXuat.IdPhieuXuat);
                default:
                    return String.Format(cmdTextFormatString, phieuXuat.IdPhieuXuat);
            }
        }
        protected override void OnLoadReport()
        {
            string sql = "";
            switch(base.Key){
                case "In phiếu nhập chi tiết theo IMEI": 
                    rpt = new rptPhieuNhapLai_IEMI();
                    sql = "SELECT MaVach,MaSanPham,TenSanPham,TenDonViTinh,sum(SoLuong) SoLuong" +
                          " FROM vChiTietPhieuXuat where IdPhieuXuat={0}" +
                          " GROUP BY MaVach,MaSanPham,TenSanPham,TenDonViTinh";
                    base.SetSqlParameters(sql, CommandType.Text, "vChiTietPhieuXuat");
                    break;
                default:
                    rpt = new rptPhieuNhapLai();
                    sql = "SELECT MaVach,MaSanPham,TenSanPham,TenDonViTinh,DonGia,TyLeChietKhau,Case When TyleVAT < 0 Then 0 Else TyleVat End As TyleVat,ThanhTien,sum(SoLuong) SoLuong" +
                          " FROM vChiTietPhieuXuat where IdPhieuXuat={0}" +
                          " GROUP BY MaVach,MaSanPham,TenSanPham,TenDonViTinh,DonGia,TyLeChietKhau,TyleVAT,ThanhTien";
                    base.SetSqlParameters(sql, CommandType.Text, "vChiTietPhieuXuat");
                    break;
            }
            base.SetParameterFields();
        }

        private void inBill()
        {
            ShowReport("In phiếu nhập hàng trả lại");
            Common.LogAction("In phiếu nhập trả lại", "Số phiếu nhập = " + phieuXuat.SoPhieuXuat, Declare.IdKho);
        }
        private void inBillImei()
        {
            ShowReport("In phiếu nhập chi tiết theo IMEI");
            Common.LogAction("In phiếu nhập trả lại IMEI", "Số phiếu nhập = " + phieuXuat.SoPhieuXuat, Declare.IdKho);
        }
    }
}