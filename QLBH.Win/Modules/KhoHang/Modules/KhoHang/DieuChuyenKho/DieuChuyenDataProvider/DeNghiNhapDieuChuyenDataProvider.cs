using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DeNghiNhapDieuChuyenDataProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuNhapDieuChuyenInfo, DeNghiNhapDieuChuyenChiTietInfor>
    {
        private static DeNghiNhapDieuChuyenDataProvider instance;
        public static DeNghiNhapDieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiNhapDieuChuyenDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            DeNghiNhapDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiNhapDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public List<DeNghiNhapDieuChuyenChiTietInfor> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiNhapDieuChuyenDAO.Instance.GetListDeNghiNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public int InsertChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            DeNghiNhapDieuChuyenDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            DeNghiNhapDieuChuyenDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }

        public List<DeNghiNhapDieuChuyenChiTietInfor> GetListDNNhanDieuChuyenBySoCT(string SoCT)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.GetListDNNhanDieuChuyenBySoCT(SoCT);
        }

        /// <summary>
        /// Căn cứ vào số phiếu xuất điều chuyển, tìm ra chứng từ nhận điều chuyển tương ứng
        /// </summary>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.GetChungTuNhanDCBySoCTGoc(soChungTuXuat);
        }

        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCTGBySoCTGoc(string soChungTuXuat)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.GetChungTuNhanDCTGBySoCTGoc(soChungTuXuat);
        }

        public ChungTuNhapDieuChuyenInfo GetListDNNDCBySoCT(string SoCT)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.GetListDNNDCBySoCT(SoCT);
        }

        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiNhanDieuChuyenDetail(int idChungTu)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.GetPhieuDeNghiNhanDieuChuyenDetail(idChungTu);
        }

        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDieuChuyenById(int idChungTu)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.GetChungTuNhanDieuChuyenById(idChungTu);
        }

        public bool ChungTuDaXuatHang(string sochungtugoc)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.ChungTuDaXuatHang(sochungtugoc);
        }

        public string ChungTuDaXacNhanNhapKho(string sochungtugoc)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.ChungTuDaXacNhanNhapKho(sochungtugoc);
        }
        /// <summary>
        /// Hủy ĐC
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuNhapDieuChuyenInfo> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(DeNghiNhapDieuChuyenDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }

        public bool ChungTuDaCoPhieuNhan(string soChungTu)
        {
            return DeNghiNhapDieuChuyenDAO.Instance.ChungTuDaCoPhieuNhan(soChungTu);
        }
    }
}
