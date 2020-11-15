using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuXuatDieuChuyenInfor : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }

        public int IdKhoDieuChuyen { get; set; }
    }
}
