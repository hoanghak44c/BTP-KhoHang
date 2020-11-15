using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class MaVachSXReportInfo
    {
        public string SoPhieu { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public string MaVachLinhKien { get; set; }
        public string MaVachThanhPham { get; set; }
        public string MaThanhPham { get; set; }
        public string TenThanhPham { get; set; }
        public int SoLuongLenh { get; set; }
        public int SoLuongHT { get; set; }
        public string MaKho { get; set; }
        public DateTime NgayXuatLK { get; set; }
        public DateTime NgayNhapTP { get; set; }
        public DateTime NgayPhatHanh { get; set; }
        public int SoLuongTP { get; set; }
        public int SoLuongLK { get; set; }
        public int LoaiChungTu { get; set; }
        public string NguoiTao { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayXuatHang { get; set; }
    }
}
