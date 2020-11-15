using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuDeNghiNhanDieuChuyenInfor :ChungTuBaseInfo
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
    public class ChungTuNhapDieuChuyenInfor : ChungTuDieuChuyenInfor
    {
        public string SoChungTuGoc { get; set; }

        public int IdChungTuGoc { get; set; }

        //public DateTime NgayNhan { get; set; }
    }
}
