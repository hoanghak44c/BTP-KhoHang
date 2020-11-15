using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class NhapHangMuaReportInfo
    {
        public string SoPhieuNhap { get; set; }
        public string SoPO { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaKho { get; set; }
        public string TenTrungTam { get; set; }
        public string TrangThai { get; set; }
        public string LoaiGiaoDich { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public string MaVach { get; set; }
        public string DongBo { get; set; }
        public string GhiChu { get; set; }

        //thêm
        public int IdChungTu { get; set; }
        public int PhongBan { get; set; }
        public int ChiPhi { get; set; }
        public string Nganh { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
        public DateTime NgayXuatHang { get; set; }
        public string TenNCC { get; set; }
        public string MaNCC { get; set; }
        // thêm 30/08/2013
        public DateTime NgayLapORC { get; set; }
        //thêm 17/09/2013
        public string NguoiLap { get; set; }

    }

    [Serializable]
    public class NhapXuatNoiBoReportInfo
    {
        public string SoChungTu { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaKho { get; set; }
        public string TenTrungTam { get; set; }
        public string TrangThai { get; set; }
        public string LoaiGiaoDich { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public string LyDoTraHang { get; set; }
        public string DongBo { get; set; }
        public string GhiChu { get; set; }
        public string TenNCC { get; set; }
        public string MaNCC { get; set; }
        public string SoPO { get; set; }
        public string SoRE { get; set; }
        //thêm
        public int IdChungTu { get; set; }
        public int PhongBan { get; set; }
        public int ChiPhi { get; set; }
        public string Nganh { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
        public DateTime NgayXuatHang { get; set; }
        public string NguoiLap { get; set; }
    }
}
