using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCChiTietXuatTieuHaoInfo    
    {
        public int IdPhieuXuat { get; set; }
        public string SoPhieuXuat { get; set; } 
        public DateTime NgayXuat { get; set; }  
        public string KhoXuat { get; set; } 
        public string NguoiDeNghi { get; set; }
        public string NguoiQuanLy { get; set; } 
        public string NguoiDeNghiXuat { get; set; }
        public string NguoiXuat { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string GhiChu { get; set; }
        public int TrangThai { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaVach { get; set; }
        public string TenPhongBan { get; set; }
        public string TenChiPhi { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
        public string MaPhongBan { get; set; }
    }
}
