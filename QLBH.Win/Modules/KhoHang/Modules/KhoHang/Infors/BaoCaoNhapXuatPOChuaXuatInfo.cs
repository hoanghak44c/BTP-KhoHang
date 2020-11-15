using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class BaoCaoNhapXuatPOChuaXuatInfo
    {
        public string SoPO { get; set; }
        public string SoPhieuNhap { get; set; }
        public string MaDoiTuong { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime NgayXuatHang { get; set; }
        public int LoaiGiaoDich { get; set; }
        public string TrungTam { get; set; }
        public string MaKho { get; set; }
        public string ThuongVienMua { get; set; }
        public string NguoiNhapORC { get; set; }
        public int TrangThai { get; set; }

        //them
        public string DVT { get; set; }
        public string MaLenh { get; set; }
        public string TenSanPham { get; set; }

    }

    [Serializable]
    public class BaoCaoNhapTPChuaXacNhanInfo
    {
        public string MaLenh { get; set; }
        public string SoPhieuNhap { get; set; }
        public string TenDoiTuong { get; set; }
        public string MaThanhPham { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public string OrgCode { get; set; }
        public string MaKho { get; set; }
    }
}
