using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class DieuChuyenKhoTongGiaoInfo
    {
        public DateTime NgayLap { get; set; }
        public String SoPhieuXuat { get; set; }
        public String KhoXuat { get; set; }
        public DateTime NgayXuat { get; set; }
        public String MaSanPham { get; set; }
        public String TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public String KhoNhan { get; set; }
        public String TrangThai { get; set; }
        public String GhiChu { get; set; }
        public String HoaDon { get; set; }
        public Double TongTien { get; set; }
    }
}