using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class HoaDonGTGTInfo : ChungTuBaseInfo
    {
        public string TenDonVi { get; set; }
        public string DiaChi { get; set; }
        public string HoTen { get; set; }
        public string MaSoThue { get; set; }
        public string KhoXuat { get; set; }
        public string NhanVien { get; set; }
    }
}
