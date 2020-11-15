using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class ChungTu_ChiTietHangHoaKiemKeInfor : ChungTuChiTietHangHoaBaseInfo
    {
        public int IdKiemKe { get; set; }

        public int IdChiTietKiemKe { get; set; }

        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public bool TrangThai { get; set; }

        public int SoLuongSoSach { get; set; }

        public string GhiChu { get; set; }

        public string NguoiKiemKe { get; set; }

        public int IdKho { get; set; }

        public string MaKho { get; set; }
    }
}
