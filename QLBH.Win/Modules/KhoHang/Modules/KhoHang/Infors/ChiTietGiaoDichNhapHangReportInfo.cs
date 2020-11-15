using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChiTietGiaoDichNhapHangReportInfo
    {
        public int IdSanPham { get; set; }
        public string Nganh { get; set; }
        public string Chung { get; set; }
        public string Loai { get; set; }
        public string Nhom { get; set; }
        public string NhaSanXuat { get; set; }
        public string Model { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenTrungTam { get; set; }
        public string TenKho { get; set; }
        public string LoaiChungTu { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayXuatHang { get; set; }
        public string SoChungTuORC { get; set; }
        public string SoChungTuPOS { get; set; }
        public string GhiChu { get; set; }
        public string TenDonViTinh { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public string ThuongVien { get; set; }
        public string SoSeri { get; set; }
        public string DienGiai { get; set; }
        public string MaVach { get; set; }
    }

    [Serializable]
    public class TongHopGiaoDichNhapHangReportInfo
    {
        public int IdSanPham { get; set; }
        public string Nganh { get; set; }
        public string Chung { get; set; }
        public string Loai { get; set; }
        public string Nhom { get; set; }
        public string NhaSanXuat { get; set; }
        public string Model { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaTrungTam { get; set; }
        public string MaKho { get; set; }
        public string LoaiChungTu { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayNhapXuat { get; set; }
        public string SoChungTu { get; set; }
        public string SoChungTuGoc { get; set; }
        public string GhiChu { get; set; }
        public string TenDonViTinh { get; set; }
        public int SoLuong { get; set; }
        public float DonGia { get; set; }
        public float ThanhTien { get; set; }
        public string ThuongVien { get; set; }
        public string SoSeri { get; set; }
        public string DienGiai { get; set; }
        public string TrangThai { get; set; }
        public int DongBo_ORC { get; set; }
    }
}
