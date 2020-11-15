using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class tmp_XuatKho_UserInfor
    {
        public string SoPO { get; set; }

        public string SoPhieuXuat { get; set; }

        public DateTime NgayNhap { get; set; }

        public DateTime ThoiGian { get; set; }

        public string Trangthai { get; set; }

        public string GhiChu { get; set; }

        public string NguoiXuat { get; set; }
    }
}
