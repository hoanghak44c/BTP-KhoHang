using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class tmp_NhapHang_LogInfo
    {
        public string NguoiNhap { get; set; }

        public string SoPO { get; set; }
        
        public string SoPhieuNhap { get; set; }

        public DateTime ThoiGian { get; set; }

        public int LoaiGiaoDich { get; set; }
    }
}
