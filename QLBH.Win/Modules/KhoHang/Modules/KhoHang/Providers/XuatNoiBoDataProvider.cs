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
    public class XuatNoiBoDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatNoiBoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
        , IBussinessKeToanKhoProvider<ChungTuXuatNoiBoInfor, ChungTu_ChiTietInfo>
    {
        private static XuatNoiBoDataProvider instance;
        public static XuatNoiBoDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new XuatNoiBoDataProvider();
                return instance;
            }
        }

        public static List<ChungTuXuatNoiBoInfor>GetListXuatNoiBo()
        {
            return XuatNoiBoDAO.Instance.GetListXuatNoiBo();
        }

        public void  DeleteChungTu(int idChungTu)
        {
            XuatNoiBoDAO.Instance.Delete(idChungTu);
        }

        public void UpdateChungTu(ChungTuXuatNoiBoInfor chungTu)
        {
            XuatNoiBoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatNoiBoInfor chungTu)
        {
            return XuatNoiBoDAO.Instance.Insert(chungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAO.Instance.GetListXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAO.Instance.Delete(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return XuatTieuHaoDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatTieuHaoDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatTieuHaoDAO.Instance.UpdateCTCT(chiTietChungTu);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatNoiBoDetail(int idChungTu)
        {
            return Origin(XuatNoiBoDAO.Instance.GetPhieuXuatNoiBoDetail(idChungTu));
        }
    }
}
