using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhapDieuChuyenKhoTGDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuNhapDieuChuyenInfo, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
       , IBussinessKeToanKhoProvider<ChungTuNhapDieuChuyenInfo, ChungTu_ChiTietInfo>
    {
        private static NhapDieuChuyenKhoTGDataProvider instance;
        public static NhapDieuChuyenKhoTGDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhapDieuChuyenKhoTGDataProvider();
                return instance;
            }
        }
        public static List<ChungTuNhapDieuChuyenInfo> GetListNhanDieuChuyen(string idKho)
        {
            return NhapDieuChuyenKhoTGDAO.Instance.GetListNhanDieuChuyen(idKho);
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            NhapDieuChuyenKhoTGDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            return NhapDieuChuyenKhoTGDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            NhapDieuChuyenKhoTGDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(NhapDieuChuyenKhoTGDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        //public List<ChungTu_ChiTietHangHoaBaseInfo> GetListNhanDieuChuyenBySoPhieu(string soPhieu)
        //{
        //    return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenBySoPhieu(soPhieu);
        //}

        public List<ChungTu_ChiTietInfo> GetListChiTietNhanDieuChuyen(int idChungTu)
        {
            return NhapDieuChuyenKhoTGDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return NhapDieuChuyenKhoTGDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhapDieuChuyenKhoTGDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhapDieuChuyenKhoTGDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(NhapDieuChuyenKhoTGDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhapDieuChuyenKhoTGDAO.Instance.DeleteChungTuChiTietHangHoa(chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhapDieuChuyenKhoTGDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhapDieuChuyenKhoTGDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuNhanDieuChuyenDetail(int idChungTu)
        {
            return Origin(NhapDieuChuyenKhoTGDAO.Instance.GetPhieuNhanDieuChuyenDetail(idChungTu));
        }
        public void InsertDieuChuyenHangBan(ChungTu_ChiTietHangHoaDCDHInfo chungTu)
        {
            NhapDieuChuyenKhoTGDAO.Instance.InsertDieuChuyenHangBan(chungTu);
        }
        public void DieuChuyenHangBanDelete(string soChungTu)
        {
            NhapDieuChuyenKhoTGDAO.Instance.DieuChuyenHangBanDelete(soChungTu);
        }
        public static ChungTuDeNghiNhanDieuChuyenInfor GetChungTuBySoCtg(string soCtg)
        {
            return NhapDieuChuyenKhoTGDAO.Instance.GetChungTuBySoCtg(soCtg);
        }

        /// <summary>
        /// Căn cứ vào số phiếu xuất điều chuyển, tìm ra chứng từ nhận điều chuyển tương ứng
        /// </summary>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return NhapDieuChuyenKhoTGDAO.Instance.GetChungTuNhanDCBySoCTGoc(soChungTuXuat);
        }
        /// <summary>
        /// Hủy Nhận ĐC trung gian
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuNhapDieuChuyenInfo> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(NhapDieuChuyenKhoTGDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }
    }
}
