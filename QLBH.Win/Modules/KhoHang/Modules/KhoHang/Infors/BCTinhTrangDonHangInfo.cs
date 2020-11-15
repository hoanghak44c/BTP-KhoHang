using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCTinhTrangDonHangInfo
    {
        public string MaTrungTam { get; set; }
        public string TenTrungTam { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string LoaiGiaoDich { get; set; }
        public string TrangThaiGiaoDich { get; set; }
        public string SoGiaoDich { get; set; }
        public DateTime NgayLapDon { get; set; }
        public string SoHoaDon { get; set; }
        public string KyHieu { get; set; }
        public string KhachHang { get; set; }
        public string BillTo { get; set; }
        public string ShipTo { get; set; }
        public string MaKhachLe { get; set; }
        public string TenKhachLe { get; set; }
        public string DiaChiHoaDon { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string SoPhieuXuat { get; set; }
        public DateTime NgayXuatKho { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public int CoGiaoHang { get; set; }
        public int HenGiaoHang { get; set; }
        public string NhanVienGiao { get; set; }
        public string GhiChu { get; set; }
    }
}