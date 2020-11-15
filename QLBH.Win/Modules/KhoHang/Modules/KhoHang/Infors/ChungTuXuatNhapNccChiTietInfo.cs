using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class ChungTuXuatNhapNccChiTietInfo : ChungTuChiTietBaseInfo
    {
        public string SoPO { get; set; }

        public string SoPhieuNhap { get; set; }

        public double DonGia
        {
            get { return donGia; }
            set
            {
                if (donGia != value)
                {
                    NotifyChange();
                }
                donGia = value;
            }
        }

        public double Thanhtien
        {
            get { return thanhTien; }
            set
            {
                if (thanhTien != value)
                {
                    NotifyChange();
                }
                thanhTien = value;
            }
        }

        //public string TenSanPham { get; set; }

        //public string MaSanPham { get; set; }

        public string TenDonViTinh { get; set; }

        public int TrungMaVach { get; set; }

        public string MaVach { get; set; }

        private double donGia;
        private double thanhTien;
        public bool check { get; set; }
        public string DanhSachMaVach { get; set; }
        public int TransactionID { get; set; }
        public string TenNganhHang { get; set; }
        public string TenCTCK{ get; set; }
    }
}
