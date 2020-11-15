using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class KiemKeChiTietKhongMaVachInfor
    {
        public int IdChiTiet { get; set; }
        public int IdKiemKe { get; set; }
        public int IdSanPham { get; set; }
        public string MaVach { get; set; }
        public int SoLuong { get; set; }
        public int NguoiTao { get; set; }
        public string GhiChu { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int TrungMaVach { get; set; }
        public string DonViTinh { get; set; }
        public string HoTen { get; set; }
        public int IdKho { get; set; }
        public string MaKho { get; set; }
    }

    [Serializable]
    public class KiemKeChiTietHangHoaInfor
    {
        public int IdChiTietKiemKe { get; set; }
        public int IdChiTietHangHoa { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        public int SoLuongSs { get; set; }
        public string MaVach { get; set; }
        public int TrungMaVach { get; set; }
        public string TenDonViTinh{ get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int IdSanPham { get; set; }
        public string HoTen { get; set; }
        public int IdKho { get; set; }
        public string MaKho { get; set; }
    }

    [Serializable]
    public class KiemKeChiTietInfor
    {
        public int IdChiTiet { get; set; }
        public int IdKiemKe { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public int NguoiTao { get; set; }
        public int IdKho { get; set; }
        public int IdTrungTam { get; set; }
    }

    [Serializable]
    public class KiemKeInfor : ILockInfo
    {
        public int IdKiemKe { get; set; }
        public int IdKho { get; set; }
        public DateTime NgayKiemKe { get; set; }
        public string SoPhieu { get; set; }
        public int IdNhanVien { get; set; }
        public double TongTienHang { get; set; }
        public string GhiChu { get; set; }
        public int NguoiTao { get; set; }
        public string TenKho { get; set; }
        public int KhoKhach { get; set; }
        public int IdDotKiemKe { get; set; }
        public int TrangThai { get; set; }
        public string MaDotKiemKe { get; set; }

        #region Implementation of ILockInfo

        public string ProcessId { get; set; }
        public string LockAccount { get; set; }
        public string LockMachine { get; set; }
        public int LockId { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        #endregion
    }
    [Serializable]
    public class InPhieuKiemKeInfor
    {
        public int IdChiTietKiemKe { get; set; }
        public int IdChiTietHangHoa { get; set; }
        public int SoLuong { get; set; }
        public string GhiChu { get; set; }
        public int SoLuongSs { get; set; }
        public string MaVach { get; set; }
        public int TrungMaVach { get; set; }
        public string TenDonViTinh { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int IdSanPham { get; set; }
        public string HoTen { get; set; }
        public int IdKho { get; set; }
        public string MaKho { get; set; }
        public DateTime NgayKiemKe { get; set; }
        public string DotKiemKe { get; set; }
        public string SoPhieu { get; set; }
    }
}
