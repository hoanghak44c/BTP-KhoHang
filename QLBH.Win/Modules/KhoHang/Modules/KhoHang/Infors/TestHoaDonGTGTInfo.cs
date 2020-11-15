using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    /// <summary>
    /// Dung chung cho form chi tiet ma vachs
    /// </summary>
    [Serializable]
    public class TestHoaDonGTGTInfo : ChungTuChiTietHangHoaBaseInfo
    {
        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public bool TrangThai { get; set; }

        public double ThanhTienChuaThue { get; set; }

        public double ThueGTGT { get; set; }

        public double TienThueGTGT { get; set; }

        public double ThanhTienCoThue { get; set; }
    }
}
