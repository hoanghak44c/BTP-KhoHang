using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class ChungTuNhapNccChiTietHangHoaInfo : ChungTuChiTietHangHoaBaseInfo
    {
        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public bool TrangThai { get; set; }

        //CuongTT 08/01/2013
        public string MaVachThanhPham { get; set; }
        public string SoChungTugoc { get; set; }
        public int TransactionID { get; set; }
        public int ThoiHanBH { get; set; }
        public int IdChungTu { get; set; }
        public string SoChungTu { get; set; }
        public int IdKho { get; set; }
    }
}
