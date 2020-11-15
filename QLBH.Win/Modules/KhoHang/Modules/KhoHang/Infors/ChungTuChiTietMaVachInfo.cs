using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuChiTietMaVachInfo
    {
        public int IdChiTietChungTu { get; set; }

        public int IdChiTietHangHoa { get; set; }

        public int SoLuong { get; set; }

        public string MaVach { get; set; }
    }
}
