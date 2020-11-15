using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class XuatDieuChuyenKhoTGDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatDieuChuyenInfo, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        private static XuatDieuChuyenKhoTGDataProvider instance;
        public static XuatDieuChuyenKhoTGDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new XuatDieuChuyenKhoTGDataProvider();
                return instance;
            }
        }
        public static List<ChungTuXuatDieuChuyenInfo> GetListDeNghiXuatDieuChuyen(string idKho)
        {
            return XuatDieuChuyenKhoTGDAO.Instance.GetListXuatDieuChuyen(idKho);
        }

        public static List<ChungTuXuatDieuChuyenInfo> GetFillterDeNghiXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return XuatDieuChuyenKhoTGDAO.Instance.GetFillterDeNghiXuatDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        }

        public void UpdateChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            XuatDieuChuyenKhoTGDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            return XuatDieuChuyenKhoTGDAO.Instance.Insert(chungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenKhoTGDAO.Instance.GetListXuatDieuChuyenChiTietByIdChungTu(idChungTu));
        }
        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>

        public void DeleteChungTu(int idChungTu)
        {
            XuatDieuChuyenKhoTGDAO.Instance.Delete(idChungTu);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return XuatDieuChuyenKhoTGDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatDieuChuyenKhoTGDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatDieuChuyenKhoTGDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenKhoTGDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenKhoTGDAO.Instance.DeleteChiTietHangHoa(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenKhoTGDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenKhoTGDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatDieuChuyenDetail(int idChungTu)
        {
            return Origin(XuatDieuChuyenKhoTGDAO.Instance.GetPhieuXuatDieuChuyenDetail(idChungTu));
        }
        //public List<BCChiTietHangChuyenKhoInfo> GetBCChiTietChuyenKho(string trungtam,string kho, DateTime tuNgay, DateTime denNgay)
        //{
        //    return XuatDieuChuyenKhoDAO.Instance.GetBCChiTietChuyenKho(trungtam, kho, tuNgay, denNgay);
        //}
        //public List<BCTongHopHangChuyenKhoInfo> GetBCTongHopChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay)
        //{
        //    return XuatDieuChuyenKhoTGDAO.Instance.GetBCTongHopChuyenKho(trungtam, kho, tuNgay, denNgay);
        //}
    }
}
