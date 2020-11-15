using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BCBanHangDAO : BaseDAO
    {

        private static BCBanHangDAO instance;

        private BCBanHangDAO()
        {
        }

        public static BCBanHangDAO Instance
        {
            get
            {
                if (instance == null) instance = new BCBanHangDAO();
                return instance;
            }
        }

        public List<BCTinhTrangDonHangInfo> GetTinhTrangDonHang(int idTrungTam, int idKho, DateTime tuNgay, DateTime denNgay, int idSanPham, int idNhanVien, int idKhachHang)
        {
            return GetListCommand<BCTinhTrangDonHangInfo>(Declare.StoreProcedureNamespace.spCSBCTinhTrangDonHang,
                                                          idTrungTam, idKho,
                                                          tuNgay == DateTime.MinValue ? DBNull.Value : (object)tuNgay,
                                                          denNgay == DateTime.MinValue ? DBNull.Value : (object)denNgay, 
                                                          idSanPham, idNhanVien, idKhachHang);
        }

        public List<BCTinhTrangBangGiaInfo> GetTinhTrangBangGia(int idTrungTam, string soBangGia, DateTime ngayLap, int trangThaiDuyet, string nguoiLap, int idSanPham)
        {
            return GetListCommand<BCTinhTrangBangGiaInfo>(Declare.StoreProcedureNamespace.spCSBCTinhTrangBangGia,
                                                          idTrungTam, soBangGia, 
                                                          ngayLap == DateTime.MinValue ? DBNull.Value : (object)ngayLap, 
                                                          trangThaiDuyet, nguoiLap, idSanPham);
        }

        public List<BCBangGiaChiTietInfo> GetBangGiaChiTiet(int idTrungTam, int idSanPham)
        {
            return GetListCommand<BCBangGiaChiTietInfo>(Declare.StoreProcedureNamespace.spCSBCBangGiaChiTiet,
                                                        idTrungTam, idSanPham);
        }

        public List<BCChinhSachInfo> GetChinhSachApDung(int idTrungTam, string maSanPham)
        {
            return GetListCommand<BCChinhSachInfo>(Declare.StoreProcedureNamespace.spCSBCChinhSachApDung,
                                                        idTrungTam, maSanPham);
        }

        public List<BCLichSuThayDoiGiaInfo> GetLichSuThayDoiGia(int idTrungTam, int idSanPham)
        {
            return GetListCommand<BCLichSuThayDoiGiaInfo>(Declare.StoreProcedureNamespace.spCSBCLichSuThayDoiGia, idTrungTam, idSanPham);
        }

        public List<BCLichSuThayDoiGiaDetailInfo> GetLichSuThayDoiGiaDetail(int idTrungTam, int idSanPham, DateTime tuNgay, DateTime denNgay)
        {
            return GetListCommand<BCLichSuThayDoiGiaDetailInfo>(Declare.StoreProcedureNamespace.spCSBCLichSuThayDoiGiaDetail,
                                                            idTrungTam, idSanPham, tuNgay, denNgay);
        }
    }
}