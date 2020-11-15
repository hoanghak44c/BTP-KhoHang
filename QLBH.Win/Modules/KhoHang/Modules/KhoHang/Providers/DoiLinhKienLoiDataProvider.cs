using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Infors;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DoiLinhKienLoiDataProvider : BusinessProviderBase,
        IBussinessKeToanKhoProvider<ChungTuDoiLinhKienLoiInfo, ChungTuChiTietBaseInfo>,
        IBussinessKhoProvider<ChungTuDoiLinhKienLoiInfo, ChungTuChiTietBaseInfo, ChungTuChiTietHangHoaBaseInfo>
    {

        private static DoiLinhKienLoiDataProvider instance;

        private DoiLinhKienLoiDataProvider()
        {
        }

        public static DoiLinhKienLoiDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DoiLinhKienLoiDataProvider();
                return instance;
            }
        }

        public List<ChungTuChiTietHangHoaBaseInfo> GetListThanhPham(string maVachLinhKienLoi)
        {
            //thanh pham chua duoc tach
            return DoiLinhKienLoiDAO.Instance.GetListThanhPham(maVachLinhKienLoi);
        }

        public ChungTuBaseInfo GetDonHangBan(string maVachThanhPham)
        {
            return DoiLinhKienLoiDAO.Instance.GetDonHangBan(maVachThanhPham);
        }

        public HangHoa_ChiTietInfo GetLinhKienLoi(string maVachLinhKienLoi, string maVachThanhPham)
        {
            return DoiLinhKienLoiDAO.Instance.GetLinhKienLoi(maVachLinhKienLoi, maVachThanhPham);
        }

        public HangHoa_ChiTietInfo GetLinhKienMoi(string maVachLinhKienMoi, int idSanPham, int idKho)
        {
            return DoiLinhKienLoiDAO.Instance.GetLinhKienMoi(maVachLinhKienMoi, idSanPham, idKho);
        }

        public string GetSoPhieuXuatLinhKien(int idCtcTietNhapThanhPham)
        {
            return DoiLinhKienLoiDAO.Instance.GetSoPhieuXuatLinhKien(idCtcTietNhapThanhPham);
        }

        public void UpdatePhieuXuatLinhKien(int idChiTietLinhKienMoi, int idChiTietLinhKienLoi, string soChungTuGoc)
        {
            DoiLinhKienLoiDAO.Instance.UpdatePhieuXuatLinhKien(idChiTietLinhKienMoi, idChiTietLinhKienLoi, soChungTuGoc);
        }

        #region Implementation of IBusinessBaseProvider<ChungTuDoiLinhKienLoiInfo,ChungTuChiTietBaseInfo>

        public void UpdateChungTu(ChungTuDoiLinhKienLoiInfo chungTu)
        {
            DoiLinhKienLoiDAO.Instance.UpdateChungTu(chungTu);
        }

        public int InsertChungTu(ChungTuDoiLinhKienLoiInfo chungTu)
        {
            return DoiLinhKienLoiDAO.Instance.InsertChungTu(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DoiLinhKienLoiDAO.Instance.DeleteChungTu(idChungTu);
        }

        public List<ChungTuChiTietBaseInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return DoiLinhKienLoiDAO.Instance.GetListChiTietChungTuByIdChungTu(idChungTu);
        }

        #endregion

        #region Implementation of IBussinessKeToanKhoProvider<ChungTuDoiLinhKienLoiInfo,ChungTuChiTietBaseInfo>

        public int InsertChiTietChungTu(ChungTuChiTietBaseInfo chiTietChungTu)
        {
            return DoiLinhKienLoiDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTuChiTietBaseInfo chiTietChungTu)
        {
            DoiLinhKienLoiDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTuChiTietBaseInfo chiTietChungTu)
        {
            DoiLinhKienLoiDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }

        #endregion

        #region Implementation of IBussinessKhoProvider<ChungTuDoiLinhKienLoiInfo,ChungTuChiTietBaseInfo,ChungTuChiTietHangHoaBaseInfo>

        public List<ChungTuChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return DoiLinhKienLoiDAO.Instance.GetListChiTietHangHoaByIdChungTu(idChungTu);
        }

        public void DeleteChiTietHangHoa(ChungTuChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            DoiLinhKienLoiDAO.Instance.DeleteChiTietHangHoa(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTuChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            DoiLinhKienLoiDAO.Instance.InsertChiTietHangHoa(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTuChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            DoiLinhKienLoiDAO.Instance.UpdateChiTietHangHoa(chiTietHangHoaInfo);
        }

        #endregion

        public List<XuatDoiLinhKienLoiInfo> GetXuatDoiLinhKienLoi(DateTime tungay, DateTime denngay, string trungtam)
        {
            return DoiLinhKienLoiDAO.Instance.GetXuatDoiLinhKienLoi(tungay, denngay, trungtam);
        }
    }
}