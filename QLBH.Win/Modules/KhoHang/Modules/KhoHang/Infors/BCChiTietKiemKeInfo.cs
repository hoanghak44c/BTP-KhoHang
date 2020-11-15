using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCKiemKeInfoBase
    {
        [DefaultDisplay(false)]
        public int IdPhieuKiemKe { get; set; }
        [DefaultDisplay(false)]
        public int IdKho { get; set; }
        [DefaultDisplay(false)]
        public int IdTrungTam { get; set; }
        [DefaultDisplay(false)]
        public int IdSanPham { get; set; }
    }
   public class BCChiTietKiemKeInfo :BCKiemKeInfoBase
    {
        public string SoPhieu { get; set; }
        public string MaKho { get; set; }
        public string MaDotKiemKe { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenNhanVien { get; set; }
        public string GhiChu { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MaVach { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
        public int SauKiemKe { get; set; }
        public int ThucTe { get; set; }
        public int ChenhLech { get; set; }
        public int ChenhLechOrc { get; set; }
        public int ChenhLechThatAo { get; set; }
        public int IdDotKiemKe { get; set; }
        public int TonOrc { get; set; }
        public int TonAo { get; set; }
        public int TrungChuyen { get; set; }

    }
   public class BCKiemKeChungTuLienQuanTon : BCKiemKeInfoBase
   {
       public string SoPhieu { get; set; }
       public string MaKho { get; set; }
       public string MaSanPham { get; set; }
       public string TenSanPham { get; set; }
       public string TenNhanVien { get; set; }
       //public string GhiChu { get; set; }
       public int SoLuong { get; set; }
       public int SoLuongSS { get; set; }
       public DateTime NgayLap { get; set; }
   }
   public class BCKiemKeChungTuLienQuanMaVach : BCKiemKeInfoBase
   {
       public string SoPhieu { get; set; }
       public string MaKho { get; set; }
       public string MaSanPham { get; set; }
       public string TenSanPham { get; set; }
       public string TenNhanVien { get; set; }
       public string GhiChu { get; set; }
       public int SoLuong { get; set; }
       //public int SoLuongSS { get; set; }
       public string MaVach { get; set; }
       public DateTime NgayLap { get; set; }
   }
   public class BCDanhSachPhieuKiemKeInfo : BCKiemKeInfoBase
   {
       public string SoPhieu { get; set; }
       public string MaKho { get; set; }
       public string TenNhanVien { get; set; }
       public string GhiChu { get; set; }
       public DateTime ThoiGianBatDau { get; set; }
       public DateTime ThoiGianKetThuc { get; set; }
       public DateTime NgayKiemKe { get; set; }
       public int IdDotKiemKe { get; set; }
       public int IdKiemKe { get; set; }
       public string MaDotKiemKe { get; set; }
   }
}
