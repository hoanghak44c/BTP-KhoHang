using System;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    /// <summary>
    /// note: Dung chung duoc cho ca nhap xuat noi bo nen co the se dat lai ten cho hop ly
    /// </summary>
    [Serializable]
    public class ChungTuXuatTieuHaoInfornew : ChungTuBaseLockInfo
    {
        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

        public string TenTrungTam { get; set; }

        public string TenKho { get; set; }

        public string NguoiXuat { get; set; }

        public DateTime NgayXuatHang { get; set; }

        public int IdNhanVienGiao { get; set; }

        public string MaKho { get; set; }

        public string Nganh { get; set; }
    }
}
