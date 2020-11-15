using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class PhieuThu_ChiTietInfo
    {
        public string SoPhieu { get; set; }
        public DateTime NgayLap { get; set; }
        public string NguoiNop { get; set; }
        public string DiaChi { get; set; }
        public int TongSoTien { get; set; }
        public string LyDoNop { get; set; }
        public string KemTheo { get; set; }
        public string SoTienChu { get; set; }
    }
}
