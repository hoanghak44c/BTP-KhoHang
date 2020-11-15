using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class BaoCao_ChiTietDCInfor : ChungTuChiTietBaseInfo
    {
        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public string TenDonViTinh { get; set; }

        public string MaVach { get; set; }

        public string GhiChu { get; set; }

        public string KhoDi { get; set; }

        public string NguoiLap { get; set; }

        public DateTime NgayLap { get; set; }

        public string KhoDen { get; set; }

        public string SoChungTu { get; set; }

        public string PhuongTien { get; set; }

        public string NguoiVanChuyen { get; set; }
    }
}
