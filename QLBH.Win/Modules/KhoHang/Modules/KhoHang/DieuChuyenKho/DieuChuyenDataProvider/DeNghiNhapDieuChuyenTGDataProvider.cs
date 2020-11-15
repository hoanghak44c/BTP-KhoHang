using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DeNghiNhapDieuChuyenTGDataProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuNhapDieuChuyenInfo, DeNghiNhapDieuChuyenChiTietInfor>
    {
        private static DeNghiNhapDieuChuyenTGDataProvider instance;
        public static DeNghiNhapDieuChuyenTGDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiNhapDieuChuyenTGDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            DeNghiNhapDieuChuyenTGDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfo chungTu)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiNhapDieuChuyenTGDAO.Instance.Delete(idChungTu);
        }

        public List<DeNghiNhapDieuChuyenChiTietInfor> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiNhapDieuChuyenTGDAO.Instance.GetListDeNghiNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public int InsertChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            DeNghiNhapDieuChuyenTGDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            DeNghiNhapDieuChuyenTGDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }
        public List<DeNghiNhapDieuChuyenChiTietInfor> GetListDNNhanDieuChuyenBySoCT(string SoCT)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.GetListDNNhanDieuChuyenBySoCT(SoCT);
        }
        /// <summary>
        /// Căn cứ vào số phiếu xuất điều chuyển, tìm ra chứng từ nhận điều chuyển tương ứng
        /// </summary>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.GetChungTuNhanDCBySoCTGoc(soChungTuXuat);
        }
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCTGBySoCTGoc(string soChungTuXuat)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.GetChungTuNhanDCTGBySoCTGoc(soChungTuXuat);
        }
        public ChungTuNhapDieuChuyenInfo GetListDNNDCBySoCT(string SoCT)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.GetListDNNDCBySoCT(SoCT);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiNhanDieuChuyenDetail(int idChungTu)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.GetPhieuDeNghiNhanDieuChuyenDetail(idChungTu);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuNhapDieuChuyenInfo GetInforDNNDCByIdChungTu(int idchungtu)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.GetInforDNNDCByIdChungTu(idchungtu);
        }

        public bool ChungTuDaXuatHang(string sochungtugoc)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.ChungTuDaXuatHang(sochungtugoc);
        }

        public string ChungTuDaXacNhanNhapKho(string sochungtugoc)
        {
            return DeNghiNhapDieuChuyenTGDAO.Instance.ChungTuDaXacNhanNhapKho(sochungtugoc);
        }

        /// <summary>
        /// Hủy điều chuyển
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuNhapDieuChuyenInfo> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(DeNghiNhapDieuChuyenTGDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }
    }
}
