using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCLichSuThayDoiGiaDetailInfo
    {
        public DateTime NgayCapNhat { get; set; }
        public float GiaNhapHDCuoi { get; set; }
        public float GiaTonKhoBQ { get; set; }
        public float DonGiaChuaVAT { get; set; }
        public int TyLeVAT { get; set; }
        public float TienVAT { get; set; }
        public float DonGiaCoVAT { get; set; }
        public float GiaBanBuon { get; set; }
        public float GiaNiemYet { get; set; }
        public float GiaWebSite { get; set; }
        public string NguoiDuyet { get; set; }
    }
}