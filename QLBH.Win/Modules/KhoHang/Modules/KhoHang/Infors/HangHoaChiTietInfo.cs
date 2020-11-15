using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class HangHoaChiTietInfo
    {
        public int IdChiTiet { get; set; }
        public int IdDuDauKy { get; set; }
        public int IdKho { get; set; }
        public int IdSanPham { get; set; }
        public string MaVach { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        public int IdTrungTam { get; set; }
        public DateTime BaoHanhHangTu { get; set; }
        public DateTime BaoHanhHangDen { get; set; }
        public string TenSanPham { get; set; }
        public string MaSanPham { get; set; }
    }
}