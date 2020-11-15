using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class TongHopNhapXuatLKInfo
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaLenh { get; set; }
        public string SoPhieu { get; set; }
        public string DVT { get; set; }
        public string MaKho { get; set; }
        public string MaTrungTam { get; set; }
        public string MaVach { get; set; }
        public int SoLuong { get; set; }
        public string LoaiGiaoDich { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayNhapXuat { get; set; }
    }
}
