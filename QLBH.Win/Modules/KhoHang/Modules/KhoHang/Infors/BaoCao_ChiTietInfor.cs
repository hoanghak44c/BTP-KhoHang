using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class BaoCao_ChiTietInfor : ChungTuChiTietBaseInfo
    {
        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public string TenDonViTinh { get; set; }

        public string MaVach { get; set; }

        public string GhiChu { get; set; }

        public string KhoDi { get; set; }

        public string NguoiVanChuyen { get; set; }

        public DateTime NgayLap { get; set; }

        public string KhoDen { get; set; }

        public string SoChungTu { get; set; }

        public string SoChungTuGoc { get; set; }

        public string Soseri { get; set; }

        public string SoHoaDon { get; set; }

        //Them
        public string NCC { get; set; }
        public string MaSoThue { get; set; }
        public DateTime NgayPO { get; set; }
        public string DVT { get; set; }
        public string TenCTCK { get; set; }
        public string TienCTCK { get; set; }
        public string TenCTCKSP { get; set; }
        public string NguoiLap { get; set; }
    }

    [Serializable]
    public class BaoCao_PhieuNhapMuaNCCInfor : ChungTuChiTietBaseInfo
    {
        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public string TenDonViTinh { get; set; }

        public string MaVach { get; set; }

        public string GhiChu { get; set; }

        public string KhoDi { get; set; }

        public DateTime NgayLap { get; set; }

        public string KhoDen { get; set; }

        public string SoChungTu { get; set; }

        public string SoChungTuGoc { get; set; }

        public string Soseri { get; set; }

        public string SoHoaDon { get; set; }

        //Them
        public string NCC { get; set; }
        public string MaSoThue { get; set; }
        public DateTime NgayPO { get; set; }
        public string DVT { get; set; }
        public string FullNameNhapORC { get; set; }
        public string FullNameBuyer { get; set; }
        public string FullNameNhapPOS { get; set; }
        public string TenCTCK { get; set; }
        public string TienCTCK { get; set; }
        public string TenCTCKSP { get; set; }
    }
}
