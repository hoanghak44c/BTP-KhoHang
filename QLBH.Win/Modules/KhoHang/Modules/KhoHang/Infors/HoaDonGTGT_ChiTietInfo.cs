﻿using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class HoaDonGTGT_ChiTietInfo : ChungTuChiTietBaseInfo
    {
        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        public string TenDonViTinh { get; set; }

        public int TyLeVAT { get; set; }

        public int TienVAT { get; set; }
    }
}
