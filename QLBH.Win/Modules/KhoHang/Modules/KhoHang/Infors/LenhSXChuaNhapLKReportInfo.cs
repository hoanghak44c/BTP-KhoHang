using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors.Repository;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class LenhSXChuaNhapLKReportInfo
    {
        public string MaLenh { get; set; }
        public string MaThanhPham { get; set; }
        public string TenThanhPham { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string OrgCode { get; set; }
        public DateTime NgayLap { get; set; }
        public string KhoXuat { get; set; }
        public int TrangThai { get; set; }
    }

    [Serializable]
    public class NhapXuatThanhPhamReportInfo
    {
        [CaptionColumn("Mã trung tâm")]
        public string MaTrungTam { get; set; }
        [CaptionColumn("Mã kho")]
        public string MaKho { get; set; }
        [CaptionColumn("Lệnh sản xuất")]
        public string LenhSanXuat { get; set; }
        [CaptionColumn("Số chứng từ")]
        public string SoChungTu { get; set; }
        [CaptionColumn("Mã thành phẩm")]
        public string MaThanhPham { get; set; }
        [CaptionColumn("Tên thành phẩm")]
        public string TenThanhPham { get; set; }
        [CaptionColumn("Đơn vị tính")]
        public string DonViTinh { get; set; }
        [CaptionColumn("Số lượng")]
        public int SoLuong { get; set; }
        [CaptionColumn("Ngày lập")]
        public DateTime NgayLap { get; set; }
        [CaptionColumn("Ngày xuất")]
        public DateTime NgayNhapXuat { get; set; }
        [CaptionColumn("Loại giao dịch"), XtraGridEditor(typeof(RepositoryItemLookUpEdit), "LoaiChungTu")]
        public int LoaiChungTu { get; set; }
        public string MaVach { get; set; }
    }
    [Serializable]
    public class XuatDoiLinhKienLoiInfo
    {
        public string MaLenh { get; set; }
        public int TrangThai { get; set; }
        [CaptionColumn("Mã trung tâm")]
        public string MaTrungTam { get; set; }
        [CaptionColumn("Mã kho")]
        public string MaKho { get; set; }
        [CaptionColumn("Số chứng từ")]
        public string SoChungTu { get; set; }
        [CaptionColumn("Mã linh kiện")]
        public string MaLinhKien { get; set; }
        [CaptionColumn("Mã thành phẩm")]
        public string MaThanhPham { get; set; }
        [CaptionColumn("Tên linh kiện")]
        public string TenLinhKien { get; set; }
        [CaptionColumn("Tên thành phẩm")]
        public string TenThanhPham { get; set; }
        [CaptionColumn("Mã vạch nhập")]
        public string SerialNhap { get; set; }
        [CaptionColumn("Mã vạch xuất")]
        public string SerialXuat { get; set; }
        [CaptionColumn("Mã vạch thành phẩm")]
        public string SerialTP { get; set; }
        [CaptionColumn("Đơn vị tính")]
        public string DonViTinh { get; set; }
        [CaptionColumn("Số lượng")]
        public int SoLuong { get; set; }
        [CaptionColumn("Ngày lập")]
        public DateTime NgayLap { get; set; }
        [CaptionColumn("Ngày xuất")]
        public DateTime NgayNhapXuat { get; set; }
        [CaptionColumn("Loại giao dịch")] 
        public int LoaiChungTu { get; set; }
    }
}
