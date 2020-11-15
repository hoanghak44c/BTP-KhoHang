using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChiTietDieuChuyenDonHangInfo
    {
        public int IdChungTu { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int DonGia { get; set; }
        public string SoChungTu { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }

        public string TenDonViTinh { get; set; }

        public string MaVach { get; set; }

        public string GhiChu { get; set; }

        public string KhoDi { get; set; }

        public string NguoiVanChuyen { get; set; }

        public DateTime NgayLap { get; set; }

        public string KhoDen { get; set; }

    }
}
