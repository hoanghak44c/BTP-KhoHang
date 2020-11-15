using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DoiLinhKienLoiDAO : BaseDAO
    {

        private static DoiLinhKienLoiDAO instance;

        private DoiLinhKienLoiDAO()
        {
        }

        public static DoiLinhKienLoiDAO Instance
        {
            get
            {
                if (instance == null) instance = new DoiLinhKienLoiDAO();
                return instance;
            }
        }

        public List<ChungTuChiTietHangHoaBaseInfo> GetListThanhPham(string maVachLinhKienLoi)
        {
            //thanh pham chua duoc tach, serial hong khong trung ma vach thi so luong = 0
            return
                GetListCommand<ChungTuChiTietHangHoaBaseInfo>(
                    Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetListThanhPham, maVachLinhKienLoi);
        }

        public ChungTuBaseInfo GetDonHangBan(string maVachThanhPham)
        {
            return GetObjectCommand<ChungTuBaseInfo>(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetDonHangBan,
                                                     maVachThanhPham);
        }

        public HangHoa_ChiTietInfo GetLinhKienLoi(string maVachLinhKienLoi, string maVachThanhPham)
        {
            return GetObjectCommand<HangHoa_ChiTietInfo>(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetLinhKienLoi,
                                                     maVachLinhKienLoi, maVachThanhPham);
        }

        public HangHoa_ChiTietInfo GetLinhKienMoi(string maVachLinhKienMoi, int idSanPham, int idKho)
        {
            return GetObjectCommand<HangHoa_ChiTietInfo>(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetLinhKienMoi,
                                                     maVachLinhKienMoi, idSanPham, idKho);
        }

        public void UpdateChungTu(ChungTuDoiLinhKienLoiInfo chungTu)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_UpdateChungTu,
                chungTu.IdChungTu, chungTu.LyDoGiaoDich, chungTu.GhiChu);
        }

        public int InsertChungTu(ChungTuDoiLinhKienLoiInfo chungTu)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_InsertChungTu,
                              chungTu.IdKho, chungTu.LoaiChungTu, chungTu.SoChungTu, chungTu.SoChungTuGoc,
                              chungTu.NgayLap, chungTu.NgayXuatHang, chungTu.LyDoGiaoDich, chungTu.GhiChu, chungTu.TrangThai);

            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }

        public void DeleteChungTu(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_DeleteChungTu, idChungTu);
        }

        public List<ChungTuChiTietBaseInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return
                GetListCommand<ChungTuChiTietBaseInfo>(
                    Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetListChiTietChungTu, idChungTu);
        }

        public int InsertChiTietChungTu(ChungTuChiTietBaseInfo chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_InsertChiTietChungTu,
                chiTietChungTu.IdChungTu, chiTietChungTu.IdSanPham, chiTietChungTu.SoLuong);

            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }

        public void DeleteChiTietChungTu(ChungTuChiTietBaseInfo chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_DeleteChiTietChungTu,
                chiTietChungTu.IdChungTuChiTiet);
        }

        public void UpdateChiTietChungTu(ChungTuChiTietBaseInfo chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_UpdateChiTietChungTu,
                chiTietChungTu.IdChungTuChiTiet, chiTietChungTu.IdSanPham, chiTietChungTu.SoLuong);
        }

        public List<ChungTuChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return
                GetListCommand<ChungTuChiTietHangHoaBaseInfo>(
                    Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetListChiTietHangHoa, idChungTu);
        }

        public void DeleteChiTietHangHoa(ChungTuChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_DeleteChiTietHangHoa,
                chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa);
        }

        public void InsertChiTietHangHoa(ChungTuChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_InsertChiTietHangHoa,
                chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa, chiTietHangHoaInfo.SoLuong);
        }

        public void UpdateChiTietHangHoa(ChungTuChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_UpdateChiTietHangHoa,
                chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa, chiTietHangHoaInfo.SoLuong);
        }

        public string GetSoPhieuXuatLinhKien(int idCtcTietNhapThanhPham)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_GetSoPhieuXLK, idCtcTietNhapThanhPham);
            return Parameters["p_SoPhieuXuatLinhKien"].Value.ToString();
        }

        public void UpdatePhieuXuatLinhKien(int idChiTietLinhKienMoi, int idChiTietLinhKienLoi, string soChungTuGoc)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDoiLinhKienLoi_UpdatePhieuXLK, idChiTietLinhKienMoi, idChiTietLinhKienLoi, soChungTuGoc);
        }

        public List<XuatDoiLinhKienLoiInfo> GetXuatDoiLinhKienLoi(DateTime tungay, DateTime denngay, string trungtam)
        {
            return GetListCommand<XuatDoiLinhKienLoiInfo>(Declare.StoreProcedureNamespace.spXuatDoiLKLoi, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam);
        }
    }
}