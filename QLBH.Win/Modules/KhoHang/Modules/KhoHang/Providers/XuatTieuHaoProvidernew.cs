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
    public class XuatTieuHaoProvidernew : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatTieuHaoInfornew, ChungTu_ChiTietInfonew, ChungTu_ChiTietHangHoaXTHInfo>
    {
        private static XuatTieuHaoProvidernew instance;
        
        private XuatTieuHaoProvidernew(){}

        public static XuatTieuHaoProvidernew Instance
        {
            get
            {
                if (instance == null) instance = new XuatTieuHaoProvidernew();
                return instance;
            }
        }

        #region Implementation of IBussinessKeToanProvider<ChungTuXuatTieuHaoInfor,ChungTu_ChiTietInfo>

        public void UpdateChungTu(ChungTuXuatTieuHaoInfornew chungTu)
        {
            XuatTieuHaoDAOnew.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatTieuHaoInfornew chungTu)
        {
            return XuatTieuHaoDAOnew.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            XuatTieuHaoDAOnew.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfonew> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAOnew.Instance.GetListXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        #endregion

        #region Implementation of IBussinessKhoProvider<ChungTuXuatTieuHaoInfor,ChungTu_ChiTietInfo,ChungTu_ChiTietHangHoaBaseInfo>

        public List<ChungTu_ChiTietHangHoaXTHInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAOnew.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAOnew.Instance.Delete(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAOnew.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAOnew.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }

        public List<BaoCao_ChiTietInfor> GetPhieuXuatTieuHaoDetail(int idChungTu)
        {
            return XuatTieuHaoDAOnew.Instance.GetPhieuXuatTieuHaoDetail(idChungTu);
        }

        #endregion

        public static List<ChungTuXuatTieuHaoInfornew> GetListXuatTieuHao()
        {
            return XuatTieuHaoDAOnew.Instance.GetListXuatTieuHao();
        }
    }
}
