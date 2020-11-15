using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class tmp_NhapHang_UserInfo
    {
        public string SoPhieuNhap { get; set; }

        public string SoPO { get; set; }

        public DateTime NgayNhap { get; set; }

        public DateTime ThoiGian { get; set; }

        public string Trangthai { get; set; }

        public string GhiChu { get; set; }

        public string NguoiNhap { get; set; }

        public int IdDoiTuong { get; set; }

        public int TransactionID { get; set; }

        public DateTime NgayNhapMa { get; set; }

        public DateTime TransactionDate { get; set; }

        public string MaKho { get; set; }

        public string NCC { get; set; }

        public int IdChungTu { get; set; }

    }
}
