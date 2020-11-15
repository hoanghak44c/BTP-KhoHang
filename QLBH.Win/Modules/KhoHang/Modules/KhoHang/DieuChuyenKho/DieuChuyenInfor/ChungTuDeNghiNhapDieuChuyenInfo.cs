using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuDeNghiNhapDieuChuyenInfor : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdChungTuGoc { get; set; }

        public int IdKhoDieuChuyen { get; set; }

        public string TenKho { get; set; }

        public string NguoiLap { get; set; }

        //public DateTime NgayNhan { get; set; }
    }

    [Serializable]
    public class ChungTuNhapDieuChuyenInfo : ChungTuXuatDieuChuyenInfo
    {
        public int IdChungTuGoc { get; set; }

        public string KhoDi { get; set; }

        public string KhoDen { get; set; }
    }
}
