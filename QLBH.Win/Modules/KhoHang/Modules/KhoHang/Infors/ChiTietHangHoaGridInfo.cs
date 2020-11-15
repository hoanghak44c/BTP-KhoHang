using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChiTietHangHoaGridInfo
    {
        public string MaVach { get; set; }

        public string DonViTinh { get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public int IdSanPham { get; set; }
    }
}
