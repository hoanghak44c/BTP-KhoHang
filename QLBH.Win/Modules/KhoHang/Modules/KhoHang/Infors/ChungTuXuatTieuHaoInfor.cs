using System;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    /// <summary>
    /// note: Dung chung duoc cho ca nhap xuat noi bo nen co the se dat lai ten cho hop ly
    /// </summary>
    [Serializable]
    public class ChungTuXuatTieuHaoInfor : ChungTuBaseInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

    }
}
