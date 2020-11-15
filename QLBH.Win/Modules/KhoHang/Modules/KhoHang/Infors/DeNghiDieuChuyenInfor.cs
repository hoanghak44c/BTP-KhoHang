using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class DeNghiDieuChuyenInfor : ChungTuChiTietBaseInfo
    {
        public string SoPO { get; set; }

        public string SoPhieuNhap { get; set; }

        public int DonGia { get; set; }

        public int Thanhtien { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public string MaVach { get; set; }

        public int IdKho { get; set; }

        public int IdTrungTam { get; set; }
    }
}
