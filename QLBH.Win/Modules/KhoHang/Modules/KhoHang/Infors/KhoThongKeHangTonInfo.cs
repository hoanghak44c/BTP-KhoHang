using System;
using DevExpress.XtraEditors.Repository;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class TonInfoBase
    {
        [DefaultDisplay(false)]
        public int IdTrungTam { get; set; }
        [DefaultDisplay(false)]
        public int IdKho { get; set; }
        [DefaultDisplay(false)]
        public int IdSanPham { get; set; }
    }

    [Serializable]
    public class KhoThongKeHangTonInfo : TonInfoBase
    {
        public string MaTrungTam { get; set; }
        public string MaKho { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        [DefaultDisplay(false)]
        public int DauKy { get; set; }
        [DefaultDisplay(false)]
        public int Xuat { get; set; }
        [DefaultDisplay(false)]
        public int Nhap { get; set; }
        public int Ton { get; set; }
        public int TonAo { get; set; }
        public string Hang { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
        public int TonTrungChuyen { get; set; }
    }

    [Serializable]
    public class KhoThongKeHangTonLichSuInfo : TonInfoBase
    {
        public string MaTrungTam { get; set; }
        public string MaKho { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int DauKy { get; set; }
        public int Xuat { get; set; }
        public int Nhap { get; set; }
        public int Ton { get; set; }
        public string Hang { get; set; }
        public string Loai { get; set; }
        public string Nganh { get; set; }
    }

    [Serializable]
    public class KhoThongKeChiTietHangTrungChuyenInfo
    {
        [DefaultDisplay(false), CaptionColumn("ID Trung tâm nhận")]
        public int IdTrungTam { get; set; }
        [DefaultDisplay(false), CaptionColumn("Trung Tâm Nhận")]
        public string TenTrungTam { get; set; }
        [DefaultDisplay(false)]
        public int IdKho { get; set; }
        [CaptionColumn("Kho Nhận")]
        public string TenKho { get; set; }
        [DefaultDisplay(false), CaptionColumn("ID Sản Phẩm")]
        public int IdSanPham { get; set; }
        [DefaultDisplay(false), CaptionColumn("Mã Sản Phẩm")]
        public string MaSanPham { get; set; }
        [DefaultDisplay(false), CaptionColumn("Tên Sản Phẩm")]
        public string TenSanPham { get; set; }
        [CaptionColumn("Số Chứng Từ")]
        public string SoChungTu { get; set; }
        [DefaultDisplay(false), CaptionColumn("Số Chứng Từ Gốc")]
        public string SoChungTuGoc { get; set; }
        [CaptionColumn("Ngày Chứng Từ"), DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime NgayLap { get; set; }
        [CaptionColumn("Ngày nhập xuất"), DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime NgayXuatHang { get; set; }
        [CaptionColumn("Số Lượng")]
        public int SoLuong { get; set; }
        [CaptionColumn("Loại Chứng Từ")]
        public string LoaiChungTu { get; set; }
        [CaptionColumn("Trạng Thái")]
        public string TrangThai { get; set; }
        [CaptionColumn("Tồn Lịch Sử")]
        public int Ton { get; set; }
        [CaptionColumn("Thời điểm phát sinh giao dịch"), DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime ThoiDiemGiaoDich { get; set; }
        [DefaultDisplay(false), CaptionColumn("Đồng Bộ"), XtraGridEditor(typeof(RepositoryItemCheckEdit))]
        public int DongBo_ORC { get; set; }
    }

    [Serializable]
    public class KhoThongKeChungTuInfo
    {
        [DefaultDisplay(false), CaptionColumn("ID Trung tâm")]
        public int IdTrungTam { get; set; }
        [DefaultDisplay(false), CaptionColumn("Trung Tâm")]
        public string TenTrungTam { get; set; }
        [DefaultDisplay(false)]
        public int IdKho { get; set; }
        [DefaultDisplay(false), CaptionColumn("Kho")]
        public string TenKho { get; set; }
        [DefaultDisplay(false), CaptionColumn("ID Sản Phẩm")]
        public int IdSanPham { get; set; }
        [DefaultDisplay(false), CaptionColumn("Mã Sản Phẩm")]
        public string MaSanPham { get; set; }
        [DefaultDisplay(false), CaptionColumn("Tên Sản Phẩm")]
        public string TenSanPham { get; set; }
        [CaptionColumn("Số Chứng Từ")]
        public string SoChungTu { get; set; }
        [DefaultDisplay(false), CaptionColumn("Số Chứng Từ Gốc")]
        public string SoChungTuGoc { get; set; }
        [CaptionColumn("Ngày Chứng Từ"), DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime NgayLap { get; set; }
        [CaptionColumn("Ngày nhập xuất"), DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime NgayXuatHang { get; set; }
        [CaptionColumn("Số Lượng")]
        public int SoLuong { get; set; }
        [CaptionColumn("Loại Chứng Từ")]
        public string LoaiChungTu { get; set; }
        [CaptionColumn("Trạng Thái")]
        public string TrangThai { get; set; }
        [CaptionColumn("Tồn Lịch Sử")]
        public int Ton { get; set; }
        [CaptionColumn("Thời điểm phát sinh giao dịch"),DisplayFormat("dd/MM/yyyy HH:mm:ss")]
        public DateTime ThoiDiemGiaoDich { get; set; }
        [DefaultDisplay(false), CaptionColumn("Đồng Bộ"), XtraGridEditor(typeof(RepositoryItemCheckEdit))]
        public int DongBo_ORC { get; set; }
    }

}