using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Objects;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuat_LuaChonIn : frmBCBase
    {
        Utils ut = new Utils();
        public PhieuXuat phieuXuat = null;
        public List<HoaDon> ListChungTu = null;
        public int IdPhieuThu;
        private bool inMaVach = true;
        public frmPhieuXuat_LuaChonIn()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmPhieuXuat_LuaChonIn(PhieuXuat px, List<HoaDon> listCT, int phieuthu)
        {
            InitializeComponent();
            this.phieuXuat = px;
            this.ListChungTu = listCT;
            this.IdPhieuThu = phieuthu;
            Common.LoadStyle(this);
        }
        public frmPhieuXuat_LuaChonIn(PhieuXuat px, List<HoaDon> listCT)
        {
            InitializeComponent();
            this.phieuXuat = px;
            this.ListChungTu = listCT;
            Common.LoadStyle(this);
        }
        public frmPhieuXuat_LuaChonIn(List<HoaDon> listCT, int phieuthu)
        {
            InitializeComponent();
            this.phieuXuat = null;
            this.ListChungTu = listCT;
            this.IdPhieuThu = phieuthu;
            Common.LoadStyle(this);
        }

        private void frmPhieuXuat_LuaChonIn_Load(object sender, EventArgs e)
        {
            if (this.phieuXuat == null || this.phieuXuat.IdPhieuXuat==0)
                chkBill.Enabled = false;
            else
            {
                chkBill.Enabled = true;
                chkBill.Checked = Declare.InBill;
            }
            chkReceipt.Checked = Declare.InHoaDon;
            chkPayment.Checked = Declare.InPhieuThu;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (chkBill.Checked)
                inBill();
            if (chkReceipt.Checked)
                inHoaDon();
            if (chkPayment.Checked)
                inPhieuThu();
            if (!chkBill.Checked && !chkReceipt.Checked && !chkPayment.Checked)
                MessageBox.Show("Bạn chưa chọn loại phiếu để in");
        }

        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            myParams.Clear();
            switch (base.Key) {
                case "In phiếu xuất":
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
                    break;
                case "In phiếu xuất chi tiết theo IMEI":
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
                    break;
                case "In phiếu thu": break;
                default:
                    HoaDon hoadon = ListChungTu[Convert.ToInt32(base.Key.Substring(base.Key.LastIndexOf(" ")))];
                    ut.SetParameterReport(myParams, "SoSeri", hoadon.SoSeri);
                    ut.SetParameterReport(myParams, "SoChungTu", hoadon.SoChungTu);
                    ut.SetParameterReport(myParams, "TenKhachHang", hoadon.TenKhachHang);
                    ut.SetParameterReport(myParams, "DiaChi", hoadon.DiaChiKH);
                    ut.SetParameterReport(myParams, "MaSoThue", hoadon.MaSoThueKH);
                    ut.SetParameterReport(myParams, "HinhThucThanhToan", hoadon.HinhThucTT);                   
                    ut.SetParameterReport(myParams, "NgayLap", String.Format("     {0}                {1}              {2}", hoadon.NgayLap.Day, hoadon.NgayLap.Month, hoadon.NgayLap.Year));
                    //ut.SetParameterReport(myParams, "NgayLap", String.Format("       {0}                {1}                   {2}", hoadon.NgayLap.Day, hoadon.NgayLap.Month, hoadon.NgayLap.Year.ToString().Substring(2)));
                    ut.SetParameterReport(myParams, "TyleVAT", (hoadon.TyLeVAT != -1 ? Convert.ToString(hoadon.TyLeVAT * 100) : "\\"));
                    ut.SetParameterReport(myParams, "TongTienVAT", hoadon.TongTienVAT);
                    ut.SetParameterReport(myParams, "TongTienThanhToan", hoadon.TongTienThanhToan);
                    ut.SetParameterReport(myParams, "SoTienChu", Common.ReadNumner_(Common.Double2Str(hoadon.TongTienThanhToan)));
                    string sql = "select Code from tbl_DM_OrderType where IdOrderType = " + hoadon.OrderType;

                    ut.SetParameterReport(myParams, "OrderType", DBTools.getValue(sql));
                    ut.SetParameterReport(myParams, "SoPhieuXuat", phieuXuat.SoPhieuXuat);
                    string[] kho1 = phieuXuat.KhoXuat.Split("-".ToCharArray());
                    //ut.SetParameterReport(myParams, "KhoXuat", kho1[1]);
                    ut.SetParameterReport(myParams, "MaKho", kho1[0]);
                    ut.SetParameterReport(myParams, "TenKho", kho1[1]);
                    ut.SetParameterReport(myParams, "DiaChiKho", phieuXuat.DiaChiKho);
                    string[] khach1 = phieuXuat.TenKhachHang.Split("-".ToCharArray());
                    ut.SetParameterReport(myParams, "MaKhachHang", khach1[0]);
                    //ut.SetParameterReport(myParams, "SoTaiKhoan", phieuXuat.SoTaiKhoan);
                    //ut.SetParameterReport(myParams, "NganHang", phieuXuat.NganHang);                    
                    //ut.SetParameterReport(myParams, "DiaChiGiaoHang", phieuXuat.DiaChiKH);
                    //ut.SetParameterReport(myParams, "DVT", phieuXuat.TienTe);
                    //ut.SetParameterReport(myParams, "HanThanhToan", phieuXuat.ThoiHanTT);
                    break;
            }
        }
        protected override string OnSetSqlParameters(string cmdTextFormatString)
        {
            switch (base.Key) {
                case "In phiếu xuất":
                case "In phiếu xuất chi tiết theo IMEI":
                    return String.Format(cmdTextFormatString, phieuXuat.IdPhieuXuat);
                case "In phiếu thu":
                    return String.Format(cmdTextFormatString, this.IdPhieuThu);
                default:
                    HoaDon hoadon = ListChungTu[Convert.ToInt32(base.Key.Substring(base.Key.LastIndexOf(" ")))];
                    return String.Format(cmdTextFormatString, hoadon.IdChungTu);
            }
        }
        protected override void OnLoadReport()
        {
            string sql = "";
            switch(base.Key){
                case "In phiếu xuất": 
                    rpt = new rptPhieuXuat();
                    sql = "SELECT MaVach,MaSanPham,TenSanPham,TenDonViTinh,DonGia,TyLeChietKhau,Case When TyleVAT < 0 Then 0 Else TyleVat End As TyleVat,ThanhTien,sum(SoLuong) SoLuong" +
                          " FROM vChiTietPhieuXuat where IdPhieuXuat={0}" +
                          " GROUP BY MaVach,MaSanPham,TenSanPham,TenDonViTinh,DonGia,TyLeChietKhau,TyleVAT,ThanhTien";
                    base.SetSqlParameters(sql, CommandType.Text, "vChiTietPhieuXuat");
                    break;
                case "In phiếu xuất chi tiết theo IMEI": 
                    rpt = new rptPhieuXuat_IEMI();
                    sql = "SELECT MaVach,MaSanPham,TenSanPham,TenDonViTinh,sum(SoLuong) SoLuong" +
                          " FROM vChiTietPhieuXuat where IdPhieuXuat={0}" +
                          " GROUP BY MaVach,MaSanPham,TenSanPham,TenDonViTinh";
                    base.SetSqlParameters(sql, CommandType.Text, "vChiTietPhieuXuat");
                    break;
                case "In phiếu thu":
                    rpt = new rptPhieuThu();
                    sql = " SELECT SoPhieu, NgayLap, HoTen, DiaChi, SoTien, SoTaiKhoan, NoiDungThuChi, TyGia, SoTienChu,  SoChungTuKem, ChungTuGoc, Ngay, Thang, Nam  FROM vThuChi  ";
                    sql = sql + " WHERE IdPhieu ={0}";
                    base.SetSqlParameters(sql, CommandType.Text, "vPhieuThu");
                    break;
                default:
                    rpt = new rptHoaDonBan_1011();
                    //rpt = new rptHoaDonBan_New();
                    //rpt = new rptHoaDonBan();
                    if (inMaVach)
                        base.SetSqlParameters("Select * from vHoaDonBan where IdChungTu={0}", CommandType.Text, "vHoaDonBan");
                    else
                        base.SetSqlParameters("Select * from vHoaDonBanNoImei where IdChungTu={0}", CommandType.Text, "vHoaDonBan");
                    break;
            }
            base.SetParameterFields();
        }

        private void inBill()
        {
            ShowReport("In phiếu xuất");
            ShowReport("In phiếu xuất chi tiết theo IMEI");
            Common.LogAction("In phiếu xuất", "Số phiếu xuất = " + phieuXuat.SoPhieuXuat, Declare.IdKho);
        }
        private void inHoaDon()
        {
            if (MessageBox.Show(this, "Bạn có muốn in kèm mã vạch vào hóa đơn hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                inMaVach = true;
            else
                inMaVach = false;
            if (ListChungTu != null) {
                string soseries = "";
                foreach (HoaDon hd in ListChungTu)
                {
                    if (hd.TyLeVAT == -1 && hd.TongTienThanhToan == 0)
                        soseries += "Hóa đơn khuyến mại: " + hd.SoSeri + ";";
                    else
                        soseries += "Hóa đơn bán hàng: " + hd.SoSeri + ";";
                }
                if (MessageBox.Show(this,"Bạn đang in hóa đơn:\n" + soseries + "\nChú ý in đúng số hóa đơn. Bạn đã chắc chắn in không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    for (int i=ListChungTu.Count-1; i>=0; i--)
                    //foreach (HoaDon hoadon in ListChungTu)
                    {
                        //ShowReport(String.Format("Hóa đơn {0}", ListChungTu.IndexOf(hoadon)));
                        ShowReport(String.Format("Hóa đơn {0}", i));
                        Common.LogAction("In hóa đơn", "Số hóa đơn = " + ListChungTu[i].SoSeri, Declare.IdKho);
                    }
                }
            }
        }
        private void inPhieuThu()
        {
            ShowReport("In phiếu thu");
            Common.LogAction("In phiếu thu", "ID phiếu thu = " + this.IdPhieuThu, Declare.IdKho);
        }


    }
}