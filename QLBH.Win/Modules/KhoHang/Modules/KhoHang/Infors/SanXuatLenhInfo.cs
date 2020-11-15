using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class SanXuatLenhInfo 
    {
        public string MaLenh { get; set; }
        public int idThanhPham { get; set; }
        public string MaThanhPham { get; set; }
        public int SoLuongTP { get; set; }
        public string OrgCode { get; set; }
        public string NguoiLap { get; set; }
        public DateTime NgayLap { get; set; }
        public int Status { get; set; }
        public string TenThanhPham { get; set; }
        public string DonViTinh { get; set; }
        public int TrangThai { get; set; }
        public string TenTrangthai { get; set; }

        public string MaVachThanhPham { get; set; }

        //19/01/2013
        public int SoLuongHT { get; set; }
        //public string TransactionID { get; set; }

        //CuongTT 30/3/2013
        public string Loai_Ma_Lenh { get; set; }
        public string Description { get; set; }
        public DateTime Last_update_date { get; set; }
    }
}
