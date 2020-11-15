using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class TonDauKyInfo
    {
        public int IdDuDauKy { get; set; }
        public DateTime ThoiGian { get; set; }
        public int IdKho { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public int NguoiTao { get; set; }
    }

    internal class NapSoTonInfo
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenDonViTinh { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongKhaiBao { get; set; }
        public float GiaNhap { get; set; }
        public float ThanhTien { get; set; }
        public int IdSanPham { get; set; }
        public int IdDuDauKy { get; set; }
    }
}