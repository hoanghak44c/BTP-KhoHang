using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class SanXuatNhapTachInfo
    {
        public string MaLenh { get; set; }
        public string OrgCode { get; set; }
        public int LoaiGiaoDich { get; set; }
        public string MaThanhPham { get; set; }
        public int SoLuongHT { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public int TrangThai { get; set; }

        public string SoChungTu { get; set; }
        public string TenThanhPham { get; set; }
        public string TenLoaiSP { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuongYC { get; set; }
        public int IdChungTu { get; set; }
        public int TrangThaiChungTu { get; set; }
        public string TenTrangThai { get; set; }
        public int idKho { get; set; }
        public int idNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public int idthanhpham { get; set; }
        public int TransactionID { get; set; }
    }
}
