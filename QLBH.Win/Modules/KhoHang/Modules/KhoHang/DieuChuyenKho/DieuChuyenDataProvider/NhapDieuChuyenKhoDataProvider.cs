using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhapDieuChuyenKhoDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuNhapDieuChuyenInfo, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
       , IBussinessKeToanKhoProvider<ChungTuNhapDieuChuyenInfo, ChungTu_ChiTietInfo>
    {
        private static NhapDieuChuyenKhoDataProvider instance;
        public static NhapDieuChuyenKhoDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhapDieuChuyenKhoDataProvider();
                return instance;
            }
        }
        public static List<ChungTuNhapDieuChuyenInfo> GetListNhanDieuChuyen(string idKho)
        {
            return NhapDieuChuyenKhoDAO.Instance.GetListNhanDieuChuyen(idKho);
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            NhapDieuChuyenKhoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            return NhapDieuChuyenKhoDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            NhapDieuChuyenKhoDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(NhapDieuChuyenKhoDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListNhanDieuChuyenBySoPhieu(string soPhieu)
        {
            return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenBySoPhieu(soPhieu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietNhanDieuChuyen(int idChungTu)
        {
            return NhapDieuChuyenKhoDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return NhapDieuChuyenKhoDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhapDieuChuyenKhoDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhapDieuChuyenKhoDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(NhapDieuChuyenKhoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhapDieuChuyenKhoDAO.Instance.DeleteChungTuChiTietHangHoa(chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhapDieuChuyenKhoDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhapDieuChuyenKhoDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuNhanDieuChuyenDetail(int idChungTu)
        {
            return Origin(NhapDieuChuyenKhoDAO.Instance.GetPhieuNhanDieuChuyenDetail(idChungTu));
        }
        public void InsertDieuChuyenHangBan(ChungTu_ChiTietHangHoaDCDHInfo chungTu)
        {
            NhapDieuChuyenKhoDAO.Instance.InsertDieuChuyenHangBan(chungTu);
        }
        public void DieuChuyenHangBanDelete(string soChungTu)
        {
            NhapDieuChuyenKhoDAO.Instance.DieuChuyenHangBanDelete(soChungTu);
        }

        /// <summary>
        /// Căn cứ vào số phiếu xuất điều chuyển, tìm ra chứng từ nhận điều chuyển tương ứng
        /// </summary>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return NhapDieuChuyenKhoDAO.Instance.GetChungTuNhanDCBySoCTGoc(soChungTuXuat);
        }

        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDieuChuyenById(int idChungTu)
        {
            return NhapDieuChuyenKhoDAO.Instance.GetChungTuNhanDieuChuyenById(idChungTu);
        }

        public static List<ChungTuNhapDieuChuyenInfo> GetFillterDeNghiNhanDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return NhapDieuChuyenKhoDAO.Instance.GetFillterDeNghiNhanDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        }

        public DateTime GetMinDate(string idKho, string trangThai)
        {
            return NhapDieuChuyenKhoDAO.Instance.GetMinDate(idKho, trangThai);
        }
    }
}
