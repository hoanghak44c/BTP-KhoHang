using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuXuatNoiBoInfor : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

        public int DongBo { get; set; }

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

        public string SoPO { get; set; }

        public int IdNhaCC { get; set; }

        public int IdLyDo { get; set; }

        public string TenDoiTuong { get; set; }

        public string LyDoTraHang { get; set; }

        public DateTime NgayNhapXuatKho { get; set; }

        public string SoRE { get; set; }
    }
}
