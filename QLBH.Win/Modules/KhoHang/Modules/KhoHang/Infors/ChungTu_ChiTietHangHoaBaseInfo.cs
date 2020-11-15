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
    public class ChungTu_ChiTietHangHoaBaseInfo : ChungTuChiTietHangHoaBaseInfo
    {
        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public bool TrangThai { get; set; }

        public DateTime BaoHanhHangTu { get; set; }

        public DateTime BaoHanhHangDen { get; set; }
    }

    [Serializable]
    public class ChungTu_ChiTietHangHoaTraNCCInfo : ChungTu_ChiTietHangHoaBaseInfo
    {

        public int SoLuongThucTe { get; set; }

        public int SoLuongNhap { get; set; }
    }

    [Serializable]
    public class ChungTu_ChiTietHangHoaDCDHInfo : ChungTu_ChiTietHangHoaBaseInfo
    {

        public string SoChungTuDieuChuyen { get; set; }

        public string SoChungTuBan { get; set; }
    }
}
