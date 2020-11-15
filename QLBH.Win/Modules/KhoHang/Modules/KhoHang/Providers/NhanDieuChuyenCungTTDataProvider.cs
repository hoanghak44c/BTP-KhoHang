using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhanDieuChuyenCungTTDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuNhapDieuChuyenInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
       , IBussinessKeToanKhoProvider<ChungTuNhapDieuChuyenInfor, ChungTu_ChiTietInfo>
    {
        private static NhanDieuChuyenCungTTDataProvider instance;
        public static NhanDieuChuyenCungTTDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhanDieuChuyenCungTTDataProvider();
                return instance;
            }
        }
        public static List<ChungTuNhapDieuChuyenInfor> GetListNhanDieuChuyen(string idKho)
        {
            return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyen(idKho);
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfor chungTu)
        {
            NhanDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfor chungTu)
        {
            return NhanDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            NhanDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        //public List<ChungTu_ChiTietHangHoaBaseInfo> GetListNhanDieuChuyenBySoPhieu(string soPhieu)
        //{
        //    return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenBySoPhieu(soPhieu);
        //}

        //public List<ChungTu_ChiTietInfo> GetListChiTietNhanDieuChuyen(int idChungTu)
        //{
        //    return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu);
        //}

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return NhanDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhanDieuChuyenDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhanDieuChuyenDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(NhanDieuChuyenDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhanDieuChuyenDAO.Instance.DeleteChungTuChiTietHangHoa(chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhanDieuChuyenDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhanDieuChuyenDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuNhanDieuChuyenDetail(int idChungTu)
        {
            return Origin(NhanDieuChuyenDAO.Instance.GetPhieuNhanDieuChuyenDetail(idChungTu));
        }
        public void InsertDieuChuyenHangBan(ChungTu_ChiTietHangHoaDCDHInfo chungTu)
        {
            NhanDieuChuyenDAO.Instance.InsertDieuChuyenHangBan(chungTu);
        }
        public void DieuChuyenHangBanDelete(string soChungTu)
        {
            NhanDieuChuyenDAO.Instance.DieuChuyenHangBanDelete(soChungTu);
        }
        public static ChungTuDeNghiNhanDieuChuyenInfor GetChungTuBySoCtg(string soCtg)
        {
            return NhanDieuChuyenDAO.Instance.GetChungTuBySoCtg(soCtg);
        }

        /// <summary>
        /// Căn cứ vào số phiếu xuất điều chuyển, tìm ra chứng từ nhận điều chuyển tương ứng
        /// </summary>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfor GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return NhanDieuChuyenDAO.Instance.GetChungTuNhanDCBySoCTGoc(soChungTuXuat);
        }
        public ChungTu_ChiTietHangHoaBaseInfo GetBaoHanhByIdSanPhamIdKhoMaVach(int idKho, int idSanPham, string maVach)
        {
            return NhanDieuChuyenDAO.Instance.GetBaoHanhByIdSanPhamIdKhoMaVach(idKho,idSanPham,maVach);
        }
    }
}
