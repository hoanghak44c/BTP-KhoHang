using System;
using System.Collections.Generic;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCChinhSachInfo
    {
        public int IdChinhSach { get; set; }
        public string SoChinhSach { get; set; }
        public string TinhTrangApDung { get; set; }
        public DateTime HieuLucTuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public int IdDKMua { get; set; }
    }
}