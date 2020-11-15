using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChiTietKiemKeInfor: ChungTuChiTietBaseInfo
    {
        public int IdKiemKe { get; set; }
        public int IdChiTiet { get; set; }
        public int IdKho { get; set; }
        public int IdNhanVien { get; set; }
        public DateTime NgayKiemKe { get; set; }
        public string SoPhieu { get; set; }
        public int SoLuongSoSach { get; set; }
        public int NguoiTao { get; set; }
        public string MaVach { get; set; }
        public string GhiChu { get; set; }
        public string DonViTinh { get; set; }
        public int TrungMaVach { get; set; }
    }
}
