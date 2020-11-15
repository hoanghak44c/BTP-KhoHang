using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuDeNghiXuatTieuHaoInfornew : ChungTuBaseLockInfo
    {
        //todo: @HANHBD chưa có IdPhongBan, IdChiPhi

        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        //public int IdPhongBan { get; set; }

        //public int IdChiPhi { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

        public string TenTrungTam { get; set; }

        public string TenKho { get; set; }

        public string MaKho { get; set; }

        public string Nganh { get; set; }

        public int IdNguoiQuanLy { get; set; }

        public string NguoiQuanLy { get; set; }

        public string NguoiXuat { get; set; }
    }
}
