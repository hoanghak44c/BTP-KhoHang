using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DeNghiXuatDieuChuyenTGDataProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuXuatDieuChuyenInfo, DeNghiXuatDieuChuyenInfor>
    {
        private static DeNghiXuatDieuChuyenTGDataProvider instance;
        public static DeNghiXuatDieuChuyenTGDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiXuatDieuChuyenTGDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            DeNghiXuatDieuChuyenTGDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiXuatDieuChuyenTGDAO.Instance.Delete(idChungTu);
        }

        public List<DeNghiXuatDieuChuyenInfor> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiXuatDieuChuyenTGDAO.Instance.GetListDeNghiDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public List<TonDauKyInfo> GetListHangTonKhoByIdSanPham(int idKho, int idSanPham)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.GetListHangTonKhoByIdSanPham(idKho, idSanPham);
        }
        public ChungTuXuatDieuChuyenInfo GetChungTuXuatDCTGBySoCTGoc(string soChungTuNhan)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.GetChungTuXuatDCTGBySoCTGoc(soChungTuNhan);
        }
        //List<DeNghiDieuChuyenInfor> IBusinessBaseProvider<ChungTuDeNghiXuatDieuChuyenInfor, DeNghiDieuChuyenInfor>.GetListChiTietChungTuByIdChungTu(int idChungTu)
        //{
        //    return DeNghiDieuChuyenDAO.Instance.GetListDeNghiDieuChuyenChiTietByIdChungTu(idChungTu);
        //}

        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>

        public int InsertChiTietChungTu(DeNghiXuatDieuChuyenInfor chiTietChungTu)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiXuatDieuChuyenInfor chiTietChungTu)
        {
            DeNghiXuatDieuChuyenTGDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(DeNghiXuatDieuChuyenInfor chiTietChungTu)
        {
            DeNghiXuatDieuChuyenTGDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatDieuChuyenDetail(int idChungTu)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.GetPhieuDeNghiXuatDieuChuyenDetail(idChungTu);
        }
        public List<BaoCao_ChiTietDCInfor> GetPhieuBCDieuChuyen(int idChungTu)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.GetPhieuBCDieuChuyen(idChungTu);
        }
        ///Dùng cho đề nghị điều chuyển cùng trung tâm
        public DMKhoInfo GetIdTrungTamByIdKho (int idKho)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.GetIdTrungTamByIdKho(idKho);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuXuatDieuChuyenInfo GetInforDNDCByIdChungTu(int Idchungtu)
        {
            return DeNghiXuatDieuChuyenTGDAO.Instance.GetInforDNDCByIdChungTu(Idchungtu);
        }
        /// <summary>
        /// Hủy điều chuyển
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuXuatDieuChuyenInfo> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(DeNghiXuatDieuChuyenTGDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }
    }
}
