using System;
using System.Collections.Generic;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class BCBangGiaChiTietInfo
    {
        [CaptionColumn("Mã trung tâm")]
        public string MaTrungTam { get; set; }
        [CaptionColumn("Tên trung tâm")]
        public string TenTrungTam { get; set; }
        [CaptionColumn("Mã hàng")]
        public string MaHang { get; set; }
        [CaptionColumn("Tên hàng")]
        public string TenHang { get; set; }
        [CaptionColumn("Đơn vị tính")]
        public string DonViTinh { get; set; }
        [CaptionColumn("Giá nhập HĐ cuối")]
        public float GiaNhapHDCuoi { get; set; }
        [CaptionColumn("Giá nhập Demo cuối")]
        public float GiaNhapDemoCuoi { get; set; }
        [CaptionColumn("Giá tồn kho BQ")]
        public float GiaTonKhoBQ { get; set; }
        [CaptionColumn("Đơn giá chưa VAT")]
        public float DonGiaChuaVAT { get; set; }
        [CaptionColumn("Tỷ lệ VAT")]
        public float TyLeVAT { get; set; }
        [CaptionColumn("Tiền VAT")]
        public float TienVAT { get; set; }
        [CaptionColumn("Đơn giá có VAT")]
        public float DonGiaCoVAT { get; set; }
        [CaptionColumn("Giá Bán Buôn")]
        public float GiaBanBuon { get; set; }
        [CaptionColumn("Giá Bán Demo")]
        public float GiaBanDemo { get; set; }
        [CaptionColumn("Giá niêm yết")]
        public float GiaNiemYet { get; set; }
        [CaptionColumn("Giá website")]
        public float GiaWebSite { get; set; }
    }
}