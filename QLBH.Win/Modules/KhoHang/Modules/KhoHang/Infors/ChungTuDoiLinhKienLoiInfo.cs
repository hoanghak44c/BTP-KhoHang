using System;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class ChungTuDoiLinhKienLoiInfo : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }
        public int LyDoGiaoDich { get; set; }
        /// <summary>
        /// Số phiếu xuất linh kiện.
        /// </summary>
        public string SoChungTuGoc { get; set; }

        public DateTime NgayXuatHang { get; set; }
    }
}