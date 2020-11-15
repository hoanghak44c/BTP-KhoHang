using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChiTietMaVachThanhPham : HangHoa_ChiTietInfo
    {
        public string ChungTuXuatLinhKien { get; set; }
        public string ChungTuNhapThanhPham { get; set; }
        public DateTime NgayXuatLinhKien { get; set; }
        public int TrangThai { get; set; }
        public int IdChungTu { get; set; }
    }
    [Serializable]
    public class ChiTietMaVachLinhKien : HangHoa_ChiTietInfo
    {
        public string TenSanPham { get; set; }
    }


    [Serializable]
    public class MaVachThanhPhamInfo
    {
        public int IdChungTu { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayLap { get; set; }
        public int TrangThai { get; set; }
        public string MaVach { get; set; }
    }

    [Serializable]
    public class ChungTuNhapNoiBoInfor : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

        public int DongBo { get; set; }

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

        public string SoPO { get; set; }

        public int IdNhaCC { get; set; }

        public int IdLyDo { get; set; }

        public string TenDoiTuong { get; set; }

        public string LyDoTraHang { get; set; }

        public string MaKho { get; set; }

        public DateTime NgayNhapXuatKho { get; set; }

        public string SoRE { get; set; }
    }

    [Serializable]
    public class ChungTuXLKInfor : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

        public int DongBo { get; set; }

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

        public string SoPO { get; set; }

        public int IdNhaCC { get; set; }

        public int IdLyDo { get; set; }

        public string TenDoiTuong { get; set; }

        public string LyDoTraHang { get; set; }

        public string MaKho { get; set; }

        public string MaVach { get; set; }

        public DateTime NgayNhapXuatKho { get; set; }
    }
}

