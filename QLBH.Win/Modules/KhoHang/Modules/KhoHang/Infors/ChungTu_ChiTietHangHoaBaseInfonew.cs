using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    /// <summary>
    /// Dung chung cho form chi tiet ma vachs
    /// </summary>
    [Serializable]
    public class ChungTu_ChiTietHangHoaBaseInfonew : ChungTuChiTietHangHoaBaseInfo
    {
        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public bool TrangThai { get; set; }
    }

    [Serializable]
    public class ChungTu_ChiTietHangHoaTraNCCInfonew : ChungTu_ChiTietHangHoaBaseInfo
    {

        public int SoLuongThucTe { get; set; }

        public int SoLuongNhap { get; set; }
    }
    [Serializable]
    public class ChungTu_ChiTietHangHoaDCDHInfonew : ChungTu_ChiTietHangHoaBaseInfo
    {

        public string SoChungTuDieuChuyen { get; set; }

        public string SoChungTuBan { get; set; }
    }

    [Serializable]
    public class ChungTu_ChiTietHangHoaXTHInfo : ChungTu_ChiTietHangHoaBaseInfo
    {

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

    }
}
