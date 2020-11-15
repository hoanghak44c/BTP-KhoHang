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
    public class DeNghiXuatTieuHaoProvider :BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuDeNghiXuatTieuHaoInfor, DeNghiXuatTieuHaoChiTietInfo>
    {
        private static readonly DeNghiXuatTieuHaoProvider instance;
        
        public static DeNghiXuatTieuHaoProvider Instance
        {
            get
            {
                if(instance == null) return new DeNghiXuatTieuHaoProvider();
                return instance;
            }
        }

        public static List<ChungTuDeNghiXuatTieuHaoInfor> GetListDeNghiXuatTieuHao()
        {
            return DeNghiXuatTieuHaoDAO.Instance.GetListDeNghiXuatTieuHao();
        }

        #region Implementation of IBussinessKeToanProvider<ChungTuXuatTieuHaoInfor,DeNghiXuatTieuHaoChiTietInfo>

        public int InsertChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo chiTietChungTu)
        {
            return DeNghiXuatTieuHaoDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>
        //public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo deNghiXuatTieuHaoChiTietInfo)
        //{
        //    DeNghiXuatTieuHaoDAO.Instance.DeleteChiTietChungTu(deNghiXuatTieuHaoChiTietInfo);
        //}

        public void UpdateChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo chiTietChungTu)
        {
            DeNghiXuatTieuHaoDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }

        public List<DeNghiXuatTieuHaoChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiXuatTieuHaoDAO.Instance.GetListDeNghiXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo deNghiXuatTieuHaoChiTietInfo)
        {
            DeNghiXuatTieuHaoDAO.Instance.DeleteChiTietChungTu(deNghiXuatTieuHaoChiTietInfo);
        }

        public void UpdateChungTu(ChungTuDeNghiXuatTieuHaoInfor chungTu)
        {
            DeNghiXuatTieuHaoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuDeNghiXuatTieuHaoInfor chungTu)
        {
            return DeNghiXuatTieuHaoDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiXuatTieuHaoDAO.Instance.Delete(idChungTu);
        }
        public List<BaoCao_ChiTietXTHInfor> GetInPhieuDeNghiXuatTieuHao(int idChungTu)
        {
            return DeNghiXuatTieuHaoDAO.Instance.GetInPhieuDeNghiXuatTieuHao(idChungTu);
        }
        #endregion
    }
}
