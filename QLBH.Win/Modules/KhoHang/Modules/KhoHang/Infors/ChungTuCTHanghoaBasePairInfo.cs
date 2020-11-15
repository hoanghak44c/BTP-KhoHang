using System;
using System.Collections.Generic;
using System.Text;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class ChungTuCTHanghoaBasePairInfo
    {
        public int IdSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public int TrungMaVach { get; set; }
        public string DonViTinh { get; set; }
        public int TransactionID { get; set; }
        public int IdPhongBan { get; set; }
        public int IdChiPhi { get; set; }
    }
}
