using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCLichSuThayDoiGiaInfo
    {
        public int IdTrungTam { get; set; }
        public string MaTrungTam { get; set; }
        public string TenTrungTam { get; set; }
        public string IdSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string DonViTinh { get; set; }
        public double DonGiaChuaVAT { get; set; }
        public double TyLeVAT { get; set; }
        public double DonGiaCoVAT { get; set; }
        public double GiaBanBuon { get; set; }
        public double GiaBanDemo { get; set; }
        public double GiaNiemYet { get; set; }
        public double GiaWebSite { get; set; }
    }
}