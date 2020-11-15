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
    public class XuatDieuChuyenKhoDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatDieuChuyenInfo, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        private static XuatDieuChuyenKhoDataProvider instance;
        public static XuatDieuChuyenKhoDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new XuatDieuChuyenKhoDataProvider();
                return instance;
            }
        }
        public static List<ChungTuXuatDieuChuyenInfo> GetListDeNghiXuatDieuChuyen(string idKho)
        {
            return XuatDieuChuyenKhoDAO.Instance.GetListXuatDieuChuyen(idKho);
        }

        //public static List<ChungTuXuatDieuChuyenInfo> GetFillterDeNghiXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        //{
        //    return XuatDieuChuyenKhoDAO.Instance.GetFillterDeNghiXuatDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        //}

        public void UpdateChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            XuatDieuChuyenKhoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            return XuatDieuChuyenKhoDAO.Instance.Insert(chungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenKhoDAO.Instance.GetListXuatDieuChuyenChiTietByIdChungTu(idChungTu));
        }
        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>

        public void DeleteChungTu(int idChungTu)
        {
            XuatDieuChuyenKhoDAO.Instance.Delete(idChungTu);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return XuatDieuChuyenKhoDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatDieuChuyenKhoDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatDieuChuyenKhoDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenKhoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenKhoDAO.Instance.DeleteChiTietHangHoa(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenKhoDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatDieuChuyenKhoDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatDieuChuyenDetail(int idChungTu)
        {
            return Origin(XuatDieuChuyenKhoDAO.Instance.GetPhieuXuatDieuChuyenDetail(idChungTu));
        }
        //public List<BCChiTietHangChuyenKhoInfo> GetBCChiTietChuyenKho(string trungtam,string kho, DateTime tuNgay, DateTime denNgay)
        //{
        //    return XuatDieuChuyenKhoDAO.Instance.GetBCChiTietChuyenKho(trungtam, kho, tuNgay, denNgay);
        //}
        //public List<BCTongHopHangChuyenKhoInfo> GetBCTongHopChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay)
        //{
        //    return XuatDieuChuyenKhoDAO.Instance.GetBCTongHopChuyenKho(trungtam, kho, tuNgay, denNgay);
        //}
        public List<ChungTuXuatDieuChuyenInfo> GetFillterXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai, int idTrungTamHachToan)
        {
            return XuatDieuChuyenKhoDAO.Instance.GetFillterXuatDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai, idTrungTamHachToan);
        }

        public void InsertTmpChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo, string soChungTu)
        {
            XuatDieuChuyenKhoDAO.Instance.InsertTmp(chiTietHangHoaInfo, soChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdSanPham(int idSanPham, string soChungTu)
        {
            return XuatDieuChuyenKhoDAO.Instance.GetListChiTietHangHoaByIdSanPham(idSanPham, soChungTu);
        }

        public void DeleteTmpChiTietHangHoa(string soChungTu)
        {
            XuatDieuChuyenKhoDAO.Instance.DeleteTmp(soChungTu);
        }

        public bool DangBaoHanh(string maVach, int idSanPham)
        {
            return XuatDieuChuyenKhoDAO.Instance.DangBaoHanh(maVach, idSanPham);
        }
    }
}
