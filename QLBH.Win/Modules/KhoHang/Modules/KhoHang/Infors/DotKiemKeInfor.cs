using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class DotKiemKeInfor
    {
        public string MaDotKiemKe { get; set; }
        [DefaultDisplay(false)]
        public int IdDotKiemKe { get; set; }
        public DateTime NgayBatDau{ get; set; }
        public DateTime NgayKetThuc{ get; set; }
        public string GhiChu { get; set; }
        public string TrungTam { get; set; }
        public string Kho { get; set; }
        public string Nganh { get; set; }
        public string TenNganh { get; set; }
        public int KyKiemKe { get; set; }
        public string NguoiTao { get; set; }
        public string TenMayTao { get; set; }
    }
}
