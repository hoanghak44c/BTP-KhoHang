using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class XuatTieuHaoProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatTieuHaoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        private static XuatTieuHaoProvider instance;
        
        private XuatTieuHaoProvider(){}

        public static XuatTieuHaoProvider Instance
        {
            get
            {
                if (instance == null) instance = new XuatTieuHaoProvider();
                return instance;
            }
        }

        #region Implementation of IBussinessKeToanProvider<ChungTuXuatTieuHaoInfor,ChungTu_ChiTietInfo>

        public void UpdateChungTu(ChungTuXuatTieuHaoInfor chungTu)
        {
            XuatTieuHaoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatTieuHaoInfor chungTu)
        {
            return XuatTieuHaoDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            XuatTieuHaoDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAO.Instance.GetListXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        #endregion

        #region Implementation of IBussinessKhoProvider<ChungTuXuatTieuHaoInfor,ChungTu_ChiTietInfo,ChungTu_ChiTietHangHoaBaseInfo>

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

        public List<BaoCao_ChiTietXTHInfor> GetDeNghiTieuHaoDetail(int idChungTu)
        {
            return XuatTieuHaoDAO.Instance.GetDeNghiTieuHaoDetail(idChungTu);
        }

        public List<BaoCao_ChiTietXTHInfor> GetTieuHaoDetail(int idChungTu)
        {
            return XuatTieuHaoDAO.Instance.GetTieuHaoDetail(idChungTu);
        }

        #endregion

        public static List<ChungTuXuatTieuHaoInfor> GetListXuatTieuHao()
        {
            return XuatTieuHaoDAO.Instance.GetListXuatTieuHao();
        }
        /// <summary>
        /// Dùng Cho báo cáo xuất tiêu hao
        /// </summary>
        /// <returns></returns>
        public List<BCChiTietXuatTieuHaoInfo> GetBCChiTietXuatTieuHao(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtuNgay, DateTime nxdenNgay)
        {
            return XuatTieuHaoDAO.Instance.GetBCChiTietXuatTieuHao(trungtam, kho, tuNgay, denNgay, nxtuNgay, nxdenNgay);
        }
        public List<BCChiTietXuatTieuHaoInfo> GetBCTongHopXuatTieuHao(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtuNgay, DateTime nxdenNgay)
        {
            return XuatTieuHaoDAO.Instance.GetBCTongHopXuatTieuHao(trungtam, kho, tuNgay, denNgay, nxtuNgay, nxdenNgay);
        }
    }
}
