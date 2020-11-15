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
    public class DeNghiNhapTieuHaoProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuDeNghiXuatTieuHaoInfornew, DeNghiXuatTieuHaoChiTietInfonew>
    {
        private static DeNghiNhapTieuHaoProvider instance;

        public static DeNghiNhapTieuHaoProvider Instance
        {
            get
            {
                if (instance == null) return new DeNghiNhapTieuHaoProvider();
                return instance;
            }
        }

        public static List<ChungTuDeNghiXuatTieuHaoInfornew> GetListDeNghiXuatTieuHao()
        {
            return DeNghiNhapTieuHaoDAO.Instance.GetListDeNghiXuatTieuHao();
        }

        #region Implementation of IBussinessKeToanProvider<ChungTuXuatTieuHaoInfor,DeNghiXuatTieuHaoChiTietInfo>

        public int InsertChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew chiTietChungTu)
        {
            return DeNghiNhapTieuHaoDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
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
            DeNghiNhapTieuHaoDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }

        public List<DeNghiXuatTieuHaoChiTietInfonew> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiNhapTieuHaoDAO.Instance.GetListDeNghiXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew deNghiXuatTieuHaoChiTietInfo)
        {
            DeNghiNhapTieuHaoDAO.Instance.DeleteChiTietChungTu(deNghiXuatTieuHaoChiTietInfo);
        }

        public void UpdateChungTu(ChungTuDeNghiXuatTieuHaoInfornew chungTu)
        {
            DeNghiNhapTieuHaoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuDeNghiXuatTieuHaoInfornew chungTu)
        {
            return DeNghiNhapTieuHaoDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiXuatTieuHaoDAOnew.Instance.Delete(idChungTu);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatTieuHaoDetail(int idChungTu)
        {
            return DeNghiNhapTieuHaoDAO.Instance.GetPhieuDeNghiXuatTieuHaoDetail(idChungTu);
        }
        public List<DeNghiXuatTieuHaoChiTietInfonew> GetCTXTH(string sochungtu)
        {
            return DeNghiNhapTieuHaoDAO.Instance.GetCTXTH(sochungtu);
        }
        #endregion
    }
}
