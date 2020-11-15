using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTu_ChiTiet_HangHoaInfo
    {
        public int IdChiTietChungTu { get; set; }

        public int IdChiTietHangHoa { get; set; }

        public int SoLuong { get; set; }
    }
}
