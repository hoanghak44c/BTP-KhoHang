using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class DMChungTuPhieuNhapKhoInfo : DMChungTuXuatInfo
    {
        public string TenKho { get; set; }
        public string NguoiTao { get; set; }
    }
}
