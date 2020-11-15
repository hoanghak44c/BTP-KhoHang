using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DeNghiNhanDieuChuyenDataProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuNhapDieuChuyenInfor, DeNghiNhanDieuChuyenInfor>
    {
        private static DeNghiNhanDieuChuyenDataProvider instance;
        public static DeNghiNhanDieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiNhanDieuChuyenDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfor chungTu)
        {
            DeNghiNhanDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfor chungTu)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiNhanDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public List<DeNghiNhanDieuChuyenInfor> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiNhanDieuChuyenDAO.Instance.GetListDeNghiNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public List<ChungTuNhapDieuChuyenInfor> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(DeNghiNhanDieuChuyenDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }
        public int InsertChiTietChungTu(DeNghiNhanDieuChuyenInfor chiTietChungTu)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiNhanDieuChuyenInfor chiTietChungTu)
        {
           DeNghiNhanDieuChuyenDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(DeNghiNhanDieuChuyenInfor chiTietChungTu)
        {
            DeNghiNhanDieuChuyenDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }
        public List<DeNghiNhanDieuChuyenInfor> GetListDNNhanDieuChuyenBySoCT(string SoCT)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.GetListDNNhanDieuChuyenBySoCT(SoCT);
        }
        /// <summary>
        /// Căn cứ vào số phiếu xuất điều chuyển, tìm ra chứng từ nhận điều chuyển tương ứng
        /// </summary>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfor GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.GetChungTuNhanDCBySoCTGoc(soChungTuXuat);
        }

        public ChungTuXuatDieuChuyenInfor GetListDNNDCBySoCT(string SoCT)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.GetListDNNDCBySoCT(SoCT);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiNhanDieuChuyenDetail(int idChungTu)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.GetPhieuDeNghiNhanDieuChuyenDetail(idChungTu);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuNhapDieuChuyenInfor GetInforDNNDCByIdChungTu(int Idchungtu)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.GetInforDNNDCByIdChungTu(Idchungtu);
        }

        public bool ChungTuDaXuatHang(string sochungtugoc)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.ChungTuDaXuatHang(sochungtugoc);
        }

        public string ChungTuDaXacNhanNhapKho(string sochungtugoc)
        {
            return DeNghiNhanDieuChuyenDAO.Instance.ChungTuDaXacNhanNhapKho(sochungtugoc);
        }
    }
}
