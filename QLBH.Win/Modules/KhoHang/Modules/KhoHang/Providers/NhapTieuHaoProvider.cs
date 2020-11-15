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
    public class NhapTieuHaoProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatTieuHaoInfornew, ChungTu_ChiTietInfonew, ChungTu_ChiTietHangHoaXTHInfo>
    {
        private static NhapTieuHaoProvider instance;

        private NhapTieuHaoProvider() { }

        public static NhapTieuHaoProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhapTieuHaoProvider();
                return instance;
            }
        }

        #region Implementation of IBussinessKeToanProvider<ChungTuXuatTieuHaoInfor,ChungTu_ChiTietInfo>

        public void UpdateChungTu(ChungTuXuatTieuHaoInfornew chungTu)
        {
            NhapTieuHaoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatTieuHaoInfornew chungTu)
        {
            return NhapTieuHaoDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            NhapTieuHaoDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfonew> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(NhapTieuHaoDAO.Instance.GetListXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        #endregion

        #region Implementation of IBussinessKhoProvider<ChungTuXuatTieuHaoInfor,ChungTu_ChiTietInfo,ChungTu_ChiTietHangHoaBaseInfo>

        public List<ChungTu_ChiTietHangHoaXTHInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(NhapTieuHaoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            NhapTieuHaoDAO.Instance.Delete(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            NhapTieuHaoDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            NhapTieuHaoDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }

        public List<BaoCao_ChiTietInfor> GetPhieuXuatTieuHaoDetail(int idChungTu)
        {
            return NhapTieuHaoDAO.Instance.GetPhieuXuatTieuHaoDetail(idChungTu);
        }

        #endregion

        public static List<ChungTuXuatTieuHaoInfornew> GetListXuatTieuHao()
        {
            return NhapTieuHaoDAO.Instance.GetListXuatTieuHao();
        }
        public List<ChungTu_ChiTietHangHoaXTHInfo> GetListNhanTieuHaoBySoPhieu(string soPhieu)
        {
            return NhapTieuHaoDAO.Instance.GetListNhanTieuHaoBySoPhieu(soPhieu);
        }
        /// <summary>
        /// Báo cáo tiêu hao
        /// </summary>
        /// <param name="trungtam"></param>
        /// <param name="kho"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<BCChiTietXuatTieuHaoInfo> GetBCChiTietNhapTieuHao(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxTuNgay, DateTime nxDenNgay)
        {
            return NhapTieuHaoDAO.Instance.GetBCChiTietNhapTieuHao(trungtam, kho, tuNgay, denNgay, nxTuNgay, nxDenNgay);
        }
        public List<BCChiTietXuatTieuHaoInfo> GetBCTongHopNhapTieuHao(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtuNgay, DateTime nxdenNgay)
        {
            return NhapTieuHaoDAO.Instance.GetBCTongHopNhapTieuHao(trungtam, kho, tuNgay, denNgay, nxtuNgay, nxdenNgay);
        }
    }
}
