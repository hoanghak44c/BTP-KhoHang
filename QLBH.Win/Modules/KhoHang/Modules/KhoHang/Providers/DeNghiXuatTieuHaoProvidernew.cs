using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DeNghiXuatTieuHaoProvidernew :BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuDeNghiXuatTieuHaoInfornew, DeNghiXuatTieuHaoChiTietInfonew>
    {
        private static DeNghiXuatTieuHaoProvidernew instance;
        
        public static DeNghiXuatTieuHaoProvidernew Instance
        {
            get
            {
                if(instance == null) return new DeNghiXuatTieuHaoProvidernew();
                return instance;
            }
        }

        public List<ChungTuDeNghiXuatTieuHaoInfornew> GetListDeNghiXuatTieuHao()
        {
            return DeNghiXuatTieuHaoDAOnew.Instance.GetListDeNghiXuatTieuHao();
        }

        #region Implementation of IBussinessKeToanProvider<ChungTuXuatTieuHaoInfor,DeNghiXuatTieuHaoChiTietInfo>

        public int InsertChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew chiTietChungTu)
        {
            return DeNghiXuatTieuHaoDAOnew.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>
        //public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo deNghiXuatTieuHaoChiTietInfo)
        //{
        //    DeNghiXuatTieuHaoDAO.Instance.DeleteChiTietChungTu(deNghiXuatTieuHaoChiTietInfo);
        //}

        public void UpdateChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew chiTietChungTu)
        {
            DeNghiXuatTieuHaoDAOnew.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }

        public List<DeNghiXuatTieuHaoChiTietInfonew> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiXuatTieuHaoDAOnew.Instance.GetListDeNghiXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew deNghiXuatTieuHaoChiTietInfo)
        {
            DeNghiXuatTieuHaoDAOnew.Instance.DeleteChiTietChungTu(deNghiXuatTieuHaoChiTietInfo);
        }

        public void UpdateChungTu(ChungTuDeNghiXuatTieuHaoInfornew chungTu)
        {
            DeNghiXuatTieuHaoDAOnew.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuDeNghiXuatTieuHaoInfornew chungTu)
        {
            return DeNghiXuatTieuHaoDAOnew.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiXuatTieuHaoDAOnew.Instance.Delete(idChungTu);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatTieuHaoDetail(int idChungTu)
        {
            return DeNghiXuatTieuHaoDAOnew.Instance.GetPhieuDeNghiXuatTieuHaoDetail(idChungTu);
        }
        public ChungTuDeNghiXuatTieuHaoInfornew GetPhieuDeNghiXuatTieuHao(int idChungTu)
        {
            return DeNghiXuatTieuHaoDAOnew.Instance.GetPhieuDeNghiXuatTieuHao(idChungTu);
        }
        #endregion
    }
}
