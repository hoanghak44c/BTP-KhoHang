using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCChiTietHangChuyenKhoInfo
    {
        public int IdPhieuXuat { get; set; }
        public int IdPhieuNhan { get; set; }
        public string SoPhieuXuat { get; set; } //số chứng từ
        public string SoPhieuNhan { get; set;}  //số chứng từ nhận
        public DateTime NgayXuat { get; set; }  // ngày lập
        public DateTime NgayNhan { get; set; }  //ngày lập
        public string KhoXuat { get; set; } //
        public string KhoNhan { get; set; }//
        public string KhoNhanCuoi { get; set; }
        public string KeToanXuat { get; set; } 
        public string ThuKhoXuat { get; set; }//
        public string KeToanNhan { get; set; }//
        public string ThuKhoNhan { get; set; }
        public string MaSanPham { get; set; }//
        public string TenSanPham { get; set; }//
        public string GhiChu { get; set; }//
        public string TrangThai { get; set; }//
        public int SoLuong { get; set; }//
        public string HoaDonDieuChuyen { get; set; }
        public string PhuongTien { get; set; }
        public string NguoiUyNhiem { get; set; }
        public string NguoiVanChuyen { get; set; }
        public string NguoiKyDuyet { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaVach { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
    }

    public class BCTongHopHangChuyenKhoInfo
    {
        public int IdPhieuXuat { get; set; }
        public int IdPhieuNhan { get; set; }
        public string SoPhieuXuat { get; set; } //số chứng từ
        public string SoPhieuNhan { get; set; }  //số chứng từ nhận
        public DateTime NgayXuat { get; set; }  // ngày lập
        public DateTime NgayNhan { get; set; }  //ngày lập
        public string KhoXuat { get; set; } //
        public string KhoNhan { get; set; }//
        public string KhoNhanCuoi { get; set; }
        public string KeToanXuat { get; set; }
        public string ThuKhoXuat { get; set; }//
        public string KeToanNhan { get; set; }
        public string ThuKhoNhan { get; set; }//
        public string MaSanPham { get; set; }//
        public string TenSanPham { get; set; }//
        public string GhiChu { get; set; }//
        public string TrangThai { get; set; }//
        public int SoLuong { get; set; }//
        public string HoaDonDieuChuyen { get; set; }
        public string PhuongTien { get; set; }
        public string NguoiUyNhiem { get; set; }
        public string NguoiVanChuyen { get; set; }
        public string NguoiKyDuyet { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayNhap { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
    }
}
