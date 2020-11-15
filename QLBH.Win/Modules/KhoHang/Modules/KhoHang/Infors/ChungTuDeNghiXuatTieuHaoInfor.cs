using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class ChungTuDeNghiXuatTieuHaoInfor : ChungTuBaseInfo
    {
        //todo: @HANHBD chưa có IdPhongBan, IdChiPhi

        public string GhiChu { get; set; }

        public string SoChungTuGoc { get; set; }

        public int IdPhongBan { get; set; }

        public int IdChiPhi { get; set; }

        public int IdChungTuGoc { get; set; }

        public string HoTen { get; set; }

    }
}
