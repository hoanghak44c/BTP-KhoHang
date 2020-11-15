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
    public class XuatDieuChuyenDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuDieuChuyenInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        private static XuatDieuChuyenDataProvider instance;
        public static XuatDieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new XuatDieuChuyenDataProvider();
                return instance;
            }
        }
        public static List<ChungTuDieuChuyenInfor> GetListDeNghiXuatDieuChuyen(string idKho)
        {
            return XuatDieuChuyenDAO.Instance.GetListXuatDieuChuyen(idKho);
        }

        public static List<ChungTuDieuChuyenInfor> GetFillterDeNghiXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return XuatDieuChuyenDAO.Instance.GetFillterDeNghiXuatDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        }

        public void UpdateChungTu(ChungTuDieuChuyenInfor chungTu)
        {
            XuatDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuDieuChuyenInfor chungTu)
        {
            return XuatDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenDAO.Instance.GetListXuatDieuChuyenChiTietByIdChungTu(idChungTu));
        }
        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>

        public void DeleteChungTu(int idChungTu)
        {
            XuatDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return XuatDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatDieuChuyenDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatDieuChuyenDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenDAO.Instance.DeleteChiTietHangHoa(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatDieuChuyenDetail(int idChungTu)
        {
            return Origin(XuatDieuChuyenDAO.Instance.GetPhieuXuatDieuChuyenDetail(idChungTu));
        }
        public List<BCChiTietHangChuyenKhoInfo> GetBCChiTietChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtungay, DateTime nxdenngay)
        {
            return XuatDieuChuyenDAO.Instance.GetBCChiTietChuyenKho(trungtam,kho, tuNgay, denNgay,nxtungay,nxdenngay);
        }
        public List<BCTongHopHangChuyenKhoInfo> GetBCTongHopChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtungay, DateTime nxdenngay)
        {
            return XuatDieuChuyenDAO.Instance.GetBCTongHopChuyenKho(trungtam, kho, tuNgay, denNgay, nxtungay, nxdenngay);
        }
    }
}
