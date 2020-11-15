using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTu_ChiTietInfo :ChungTuChiTietBaseInfo
    {

        public double DonGia { get; set; }

        public double ThanhTien { get; set; }

        public int TrungMaVach { get; set; }

        public string TenDonViTinh { get; set; }

        public string Nganh { get; set; }
    }
}
