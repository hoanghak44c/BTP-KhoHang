using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class BaoCaoXuatNhapTonLichSuInfo : TonInfoBase
    {
        public string MaTrungTam { get; set; }
        public string MaKho { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int TonDau { get; set; }
        public int Xuat { get; set; }
        public int Nhap { get; set; }
        public int TonCuoi { get; set; }
        public int TonTC { get; set; }
        public string Hang { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
    }
}
