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
    public class DeNghiDieuChuyenDataProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuDieuChuyenInfor, DeNghiDieuChuyenInfor>
    {
        private static DeNghiDieuChuyenDataProvider instance;
        public static DeNghiDieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiDieuChuyenDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuDieuChuyenInfor chungTu)
        {
            DeNghiDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuDieuChuyenInfor chungTu)
        {
            return DeNghiDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public List<DeNghiDieuChuyenInfor> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiDieuChuyenDAO.Instance.GetListDeNghiDieuChuyenChiTietByIdChungTu(idChungTu));
        }
        public List<ChungTuDieuChuyenInfor> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(DeNghiDieuChuyenDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }
        public List<TonDauKyInfo> GetListHangTonKhoByIdSanPham(int idKho, int idSanPham)
        {
            return DeNghiDieuChuyenDAO.Instance.GetListHangTonKhoByIdSanPham(idKho, idSanPham);
        }

        //List<DeNghiDieuChuyenInfor> IBusinessBaseProvider<ChungTuDeNghiXuatDieuChuyenInfor, DeNghiDieuChuyenInfor>.GetListChiTietChungTuByIdChungTu(int idChungTu)
        //{
        //    return DeNghiDieuChuyenDAO.Instance.GetListDeNghiDieuChuyenChiTietByIdChungTu(idChungTu);
        //}

        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>
        
        public int InsertChiTietChungTu(DeNghiDieuChuyenInfor chiTietChungTu)
        {
            return DeNghiDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiDieuChuyenInfor chiTietChungTu)
        {
            DeNghiDieuChuyenDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(DeNghiDieuChuyenInfor chiTietChungTu)
        {
            DeNghiDieuChuyenDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatDieuChuyenDetail(int idChungTu)
        {
            return DeNghiDieuChuyenDAO.Instance.GetPhieuDeNghiXuatDieuChuyenDetail(idChungTu);
        }
        public List<BaoCao_ChiTietDCInfor> GetPhieuBCDieuChuyen(int idChungTu)
        {
            return DeNghiDieuChuyenDAO.Instance.GetPhieuBCDieuChuyen(idChungTu);
        }
        ///Dùng cho đề nghị điều chuyển cùng trung tâm
        public DMKhoInfo GetIdTrungTamByIdKho (int idKho)
        {
            return DeNghiDieuChuyenDAO.Instance.GetIdTrungTamByIdKho(idKho);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuDieuChuyenInfor GetInforDNDCByIdChungTu(int Idchungtu)
        {
            return DeNghiDieuChuyenDAO.Instance.GetInforDNDCByIdChungTu(Idchungtu);
        }
    }
}
