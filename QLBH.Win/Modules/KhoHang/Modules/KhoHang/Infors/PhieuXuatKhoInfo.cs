using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class PhieuXuatKhoInfo:ChungTuBaseInfo
    {
        public string NguoiMua { get; set; }

        public string DiaChi { get; set; }
    }
}
