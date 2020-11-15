using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTu_ChiTietInfonew :ChungTuChiTietBaseInfo
    {

        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public int TrungMaVach { get; set; }

        public string TenDonViTinh { get; set; }

        public int IdChiPhi { get; set; }

        public int IdPhongBan { get; set; }

        public string Nganh { get; set; }
    }
}
