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
    public class ChungTu_ChiTietHangHoaDCInfo : ChungTuChiTietHangHoaBaseInfo
    {
        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public string TenSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public bool TrangThai { get; set; }

        public string SoChungTuDieuChuyen { get; set; }

        public int IdChiTiet { get; set; }

        public string SoChungTuBan { get; set; }
    }

    //[Serializable]
    //public class ChungTu_ChiTietHangHoaTraNCCInfo : ChungTu_ChiTietHangHoaBaseInfo
    //{

    //    public int SoLuongThucTe { get; set; }

    //    public int SoLuongNhap { get; set; }
    //}
}
