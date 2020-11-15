using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class SanXuatCTietLenhInfo
    {
        public string MaLenh { get; set; }
        public string OrgCode { get; set; }
        public int IdLinhKien { get; set; }
        public string MaLinhKien { get; set; }
        public string TenLinhKien { get; set; }
        public int SoLuongCanXuat { get; set; }
        public DateTime NgayCanXuat { get; set; }
        public int SoLuongDaXuat { get; set; }
        public int SoLuongTrenTPham { get; set; }
        public int SoLuongDaQuet { get; set; }
        public string KhoXuat { get; set; }
        public string DonViTinh { get; set; }
        public int TrungMaVach { get; set; }
        public string MaVach { get; set; }
        public int thoiHanBH { get; set; }
    }
}
