using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DieuChuyenDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuDieuChuyenInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        private static DieuChuyenDataProvider instance;

        private DieuChuyenDataProvider() { }

        public static DieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DieuChuyenDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuDieuChuyenInfor chungTu)
        {
            XuatDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuDieuChuyenInfor chungTu)
        {
            return XuatDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            throw new NotImplementedException();
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatDieuChuyenDAO.Instance.GetListXuatDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
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
        public List<ChungTuDieuChuyenInfor> GetListXuatDieuChuyen(string idKho)
        {
            return XuatDieuChuyenDAO.Instance.GetListXuatDieuChuyen(idKho);
        }
        public List<ChungTuDieuChuyenInfor> GetFillterXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return XuatDieuChuyenDAO.Instance.GetFillterXuatDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        }
    }
}
