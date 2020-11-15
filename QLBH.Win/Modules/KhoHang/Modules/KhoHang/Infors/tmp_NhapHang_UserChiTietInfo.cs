using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    /// <summary>
    /// hah: info này có thể hiểu là chứng từ chi tiết info
    /// </summary>
    [Serializable]
    public class tmp_NhapHang_UserChiTietInfo
    {
        public string SoPO { get; set; }

        public string SoPhieuNhap { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        public int Thanhtien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public string MaVach { get; set; }

        public int IdSanPham { get; set; }

        public string TrangThai { get; set; }
    }
}
