using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DeNghiXuatDieuChuyenDataProvider : BusinessProviderBase, IBussinessKeToanKhoProvider<ChungTuXuatDieuChuyenInfo, DeNghiXuatDieuChuyenInfor>
    {
        private static DeNghiXuatDieuChuyenDataProvider instance;
        public static DeNghiXuatDieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiXuatDieuChuyenDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            DeNghiXuatDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatDieuChuyenInfo chungTu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            DeNghiXuatDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public List<DeNghiXuatDieuChuyenInfor> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(DeNghiXuatDieuChuyenDAO.Instance.GetListDeNghiDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public List<TonDauKyInfo> GetListHangTonKhoByIdSanPham(int idKho, int idSanPham)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetListHangTonKhoByIdSanPham(idKho, idSanPham);
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
            return DeNghiXuatDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiXuatDieuChuyenInfor chiTietChungTu)
        {
            DeNghiXuatDieuChuyenDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(DeNghiXuatDieuChuyenInfor chiTietChungTu)
        {
            DeNghiXuatDieuChuyenDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatDieuChuyenDetail(int idChungTu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetPhieuDeNghiXuatDieuChuyenDetail(idChungTu);
        }
        public List<BaoCao_ChiTietDCInfor> GetPhieuBCDieuChuyen(int idChungTu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetPhieuBCDieuChuyen(idChungTu);
        }
        ///Dùng cho đề nghị điều chuyển cùng trung tâm
        public DMKhoInfo GetIdTrungTamByIdKho (int idKho)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetIdTrungTamByIdKho(idKho);
        }
        
        public ChungTuXuatDieuChuyenInfo GetChungTuXuatDieuChuyenById(int idChungTu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetChungTuXuatDieuChuyenById(idChungTu);
        }

        public ChungTuXuatDieuChuyenInfo GetChungTuXuatDieuChuyenBySoChungTu(string soChungTu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetChungTuXuatDieuChuyenBySoChungTu(soChungTu);
        }

        public bool DangCoPhieuDieuChuyenChoNhanSerial(int idkho, int idsanpham)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.DangCoPhieuDieuChuyenChoNhanSerial(idkho, idsanpham);
        }

        public static List<ChungTuXuatDieuChuyenInfo> GetFillterDeNghiXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return XuatDieuChuyenKhoDAO.Instance.GetFillterDeNghiXuatDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        }
        public List<NhapHangMuaReportInfo> GetLookUpXDC()
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetLookUpXDC();
        }
        public List<DeNghiNhapDieuChuyenChiTietInfor> GetLookUpCTXDC(int idchungtu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetCTLookUpXDC(idchungtu);
        }
        /// <summary>
        /// Dùng cho xóa phiếu điều chuyển
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuXuatDieuChuyenInfo> GetListDieuChuyenCanXoa(string soChungTu)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetListDieuChuyenCanXoa(soChungTu);
        }
        public void DeleteChungTuDieuChuyen(string soChungTu, int sign, int tinhTon)
        {
            DeNghiXuatDieuChuyenDAO.Instance.DeleteChungTuDieuChuyen(soChungTu,sign,tinhTon);
        }
        /// <summary>
        /// Hủy phiếu ĐC
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuXuatDieuChuyenInfo> GetListChiTietChungTuBySoChungTu(string soChungTu)
        {
            return Origin(DeNghiXuatDieuChuyenDAO.Instance.GetListDieuChuyenChiTietBySoChungTu(soChungTu));
        }

        public int UpdateTrangThaiHuyChungTu(ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.UpdateTrangThaiHuyChungTu(chungTuXuatDieuChuyenInfo);
        }

        public double GetUnitPrice(int idTrungTam, int idSanPham)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetUnitPrice(idTrungTam, idSanPham);
        }

        public DateTime GetMinDate(string idKho, string trangThai)
        {
            return DeNghiXuatDieuChuyenDAO.Instance.GetMinDate(idKho, trangThai);
        }
    }
}
