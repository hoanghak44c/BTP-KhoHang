using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class BangGiaReportInfo
    {
        public int IdSanPham { get; set; }
        public int IdLoaiSanPham { get; set; }
        public int IdCauHinh { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MaCauHinh { get; set; }
        public string TenCauHinh { get; set; }
        public double DonGia { get; set; }
        public string GiaTri { get; set; }

        //CuongTT 20.02.2013
        public int TrungMaVach { get; set; }
        //HanhBD 16.04.2013
        public string NhaCC { get; set; }
    }
}
