using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuDeNghiXuatDieuChuyenInfo : ChungTuBaseLockInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdChungTuGoc { get; set; }

        public int IdKhoDieuChuyen { get; set; }

        public string TenKho { get; set; }

        public string NguoiLap { get; set; }

        public DateTime NgayXuat { get; set; }
    }

    [Serializable]
    public class ChungTuXuatDieuChuyenInfo : ChungTuBaseLockInfo
    {
        public string GhiChu { get; set; }

        public int IdKhoDieuChuyen { get; set; }

        public int IdKhoNhanCuoi { get; set; }

        public string TenKho { get; set; }

        public string NguoiLap { get; set; }

        public int IdNguoiVC { get; set; }

        public int IdNguoiUyNhiem { get; set; }

        public int IdNguoiKyDuyet { get; set; }

        public string HoaDonDC { get; set; }

        public string PhuongTien { get; set; }

        public string KhoNhan { get; set; }

        public string KhoNhanCuoi { get; set; }

        public string NguoiUyNhiem { get; set; }

        public string NguoiVanChuyen { get; set; }

        public string NguoiKyDuyet { get; set; }

        public DateTime NgayNhapXuatKho { get; set; }

        public int IdNguoiNhapXuatKho { get; set; }

        public string NguoiNhapXuatKho { get; set; }

        public string SoChungTuGoc { get; set; }

        public string Description { get; set; }

        public double TongTienHang { get; set; }

        public int GiaoNhan { get; set; }
        
    }
}
