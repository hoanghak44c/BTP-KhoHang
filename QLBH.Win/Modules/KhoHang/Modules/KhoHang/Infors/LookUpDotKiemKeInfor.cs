using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class LookUpDotKiemKeInfor
    {
        [DefaultDisplay(false)]
        public int IdDotKiemKe { get; set; }
        [DefaultDisplay(false)]
        public int KyKiemKe { get; set; }
        [CaptionColumn("Mã đợt kiểm kê")]
        public string MaDotKiemKe { get; set; }
        [CaptionColumn("Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }
        [CaptionColumn("Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }
        [CaptionColumn("Ghi chú")]
        public string GhiChu { get; set; }
        [DefaultDisplay(false)]
        public string TrungTam { get; set; }
        [DefaultDisplay(false)]
        public string Kho { get; set; }
        [DefaultDisplay(false)]
        public string Nganh { get; set; }
    }
}
