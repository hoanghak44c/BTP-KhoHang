using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class NoteSanPhamReportInfor
    {
        public int IdSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string Model { get; set; }
        public string TenCauHinh { get; set; }
        public string GiaTri { get; set; }
        public string NhaCC { get; set; }
        public string Loai { get; set; }
        public int STT { get; set; }
        public string TenSanPham { get; set; }
        public float Gia { get; set; }
    }
}
