using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class tmp_XuatKhoNoiBoInfor
    {
        public string MaVach { get; set; }

        public string SoPhieu { get; set; }

        public string DonViTinh { get; set; }

        public int SoLuong { get; set; }

        public string GhiChu { get; set; }

        public DateTime NgayNhap { get; set; }

        public int IdSanPham { get; set; }
    }
}
