using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class DMChungTuNhapInfo
    {
        public int IdChungTu { get; set; }

        public string SoChungTu { get; set; }

        public int IdKho { get; set; }

        public int IdNhanVien { get; set; }

        public int LoaiChungTu { get; set; }

        public DateTime NgayLap { get; set; }

        public string SoChungTuGoc { get; set; }

        //public string GhiChu { get; set; }
    }
}
