using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    class KhoXuatNccDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuXuatNccChiTietHangHoaInfo>
        , IBussinessKeToanKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo>
    {
        private static KhoXuatNccDataProvider instance;
        public static KhoXuatNccDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new KhoXuatNccDataProvider();
                return instance;
            }
        }
        public void UpdateChungTu(ChungTuXuatNhapNccInfo chungTu)
        {
            XuatNhapNccDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatNhapNccInfo chungTu)
        {
            return XuatNhapNccDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            throw new NotImplementedException();
        }

        public List<ChungTuXuatNhapNccChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatNhapNccDAO.Instance.ChungTuChiTietGetByIdChungTu(idChungTu));
        }

        public List<ChungTuXuatNccChiTietHangHoaInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatNhapNccDAO.Instance.ChiTietHangHoaTraNccGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTuXuatNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.DeleteHangHoaChiTietTraNcc(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTuXuatNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.InsertChungTuChiTietHangHoaTraNcc(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTuXuatNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.UpdateChiTietHangHoaTraNcc(chiTietHangHoaInfo);
        }

        public int InsertChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
            return XuatNhapNccDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
            XuatNhapNccDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
            XuatNhapNccDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }

        public bool CheckMaVach(string po, string maVach,int loaichungtu, int idKho)
        {
            return XuatNhapNccDAO.Instance.MaVachExist(po, maVach, loaichungtu, idKho);
        }
        public bool CheckSoLuong(int IdKho,int IdSanPham, string maVach)
        {
            return XuatNhapNccDAO.Instance.CheckSoLuong(IdKho, IdSanPham, maVach);
        }
    }
}
