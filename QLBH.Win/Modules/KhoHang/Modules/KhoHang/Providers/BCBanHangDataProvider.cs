using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BCBanHangDataProvider
    {

        private static BCBanHangDataProvider instance;

        private BCBanHangDataProvider()
        {
        }

        public static BCBanHangDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BCBanHangDataProvider();
                return instance;
            }
        }

        public List<BCTinhTrangDonHangInfo> GetTinhTrangDonHang(int idTrungTam, int idKho, DateTime tuNgay, DateTime denNgay, int idSanPham, int idNhanVien, int idKhachHang)
        {
            return BCBanHangDAO.Instance.GetTinhTrangDonHang(idTrungTam, idKho, tuNgay, denNgay, idSanPham, idNhanVien,
                                                      idKhachHang);
        }

        public List<BCTinhTrangBangGiaInfo> GetTinhTrangBangGia(int idTrungTam, string soBangGia, DateTime ngayLap, int trangThaiDuyet, string nguoiLap, int idSanPham)
        {
            return BCBanHangDAO.Instance.GetTinhTrangBangGia(idTrungTam, soBangGia, ngayLap, trangThaiDuyet, nguoiLap, idSanPham);
        }

        public List<BCBangGiaChiTietInfo> GetBangGiaChiTiet(int idTrungTam, int idSanPham)
        {
            return BCBanHangDAO.Instance.GetBangGiaChiTiet(idTrungTam, idSanPham);
        }

        public List<BCChinhSachInfo> GetChinhSachApDung(int idTrungTam, string maSanPham)
        {
            return BCBanHangDAO.Instance.GetChinhSachApDung(idTrungTam, maSanPham);
        }

        public List<BCLichSuThayDoiGiaInfo> GetLichSuThayDoiGia(int idTrungTam, int idSanPham)
        {
            return BCBanHangDAO.Instance.GetLichSuThayDoiGia(idTrungTam, idSanPham);
        }

        public List<BCLichSuThayDoiGiaDetailInfo> GetLichSuThayDoiGiaDetail(int idTrungTam, int idSanPham, DateTime tuNgay, DateTime denNgay)
        {
            return BCBanHangDAO.Instance.GetLichSuThayDoiGiaDetail(idTrungTam, idSanPham, tuNgay, denNgay);
        }
    }
}