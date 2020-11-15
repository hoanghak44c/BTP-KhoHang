using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class tblChungTuDataProvider
    {
        public static List<tmp_XuatKhoNoiBoInfor> GetChungTuById(int id)
        {
            return tbl_ChungTuDAO.Instance.GetChungTuById(id);
        }
        /// <summary>
        /// Dùng để test
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public static T GetChungTuBySoChungTu<T>(string soChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetChungTuBySoChungTu<T>(soChungTu);
        }
        public static List<DMChungTuNhapInfo> GetChungTuByMaVach(string MaVach)
        {
            return tbl_ChungTuDAO.Instance.GetChungTuByMaVach(MaVach);
        }
        public static List<DMChungTuPhieuNhapKhoInfo> GetChungTuByLoaiChungTu(int LoaiChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetChungTuByLoaiChungTu(LoaiChungTu);
        }
        public static List<ChungTuNhapNccChiTietHangHoaInfo> GetMaVachByChungTuGoc(string ChungTuGoc)
        {
            return tbl_ChungTuDAO.Instance.GetMaVachByChungTuGoc(ChungTuGoc);
        }
        internal static int Insert(DMChungTuNhapInfo info)
        {
            return tbl_ChungTuDAO.Instance.Insert(info);
        }
        internal static void Update(DMChungTuNhapInfo info )
        {
             tbl_ChungTuDAO.Instance.Update(info);
        }
        public static void Delete(string info)
        {
            tbl_ChungTuDAO.Instance.Delete(info);
        }
        
        public static DMChungTuNhapInfo GetIdFromSoPO(string PO, string PhieuNhap,int LoaiChungTu)
        {
           return tbl_ChungTuDAO.Instance.GetOidFromSoPo(PO, PhieuNhap ,LoaiChungTu);
        }

        public static ChungTuXuatNhapNccInfo GetChungTuNhapNCCFromSoPO(string PO, string PhieuNhap,int loaichungtu, int idKho, DateTime ngaylap, int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetChungTuNhapXuatNCCFromSoPO(PO, PhieuNhap,loaichungtu, idKho,ngaylap, idChungTu);
        }
        public static ChungTuXuatNhapNccInfo GetLichSuChungTuNhapNCCFromSoPO(string PO, string PhieuNhap, int idKho, DateTime ngaylap)
        {
            return tbl_ChungTuDAO.Instance.GetLichSuChungTuNhapXuatNCCFromSoPO(PO, PhieuNhap, idKho, ngaylap);
        }
        public static List<DMChungTuNhapInfo> Search(string sophieu)
        {
            return tbl_ChungTuDAO.Instance.Search(sophieu);
        }
        internal static void UpdateTrangThai(int idChungTu,TrangThaiDuyet trangThai)
        {
            tbl_ChungTuDAO.Instance.UpdateTrangThai(idChungTu,trangThai);
        }
        public static List<BaoCao_PhieuNhapMuaNCCInfor> GetPhieuNhapPOTongHop(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuNhapPO(idChungTu);
        }
        public static List<BaoCao_PhieuNhapMuaNCCInfor> GetPhieuNhapNCC(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuNhapNCC(idChungTu);
        }
        public static List<BaoCao_ChiTietInfor> GetPhieuTraNCC(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuTraNCC(idChungTu);
        }
        public static List<BaoCao_ChiTietInfor> GetPhieuTraNCC_TH(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuTraNCC_TH(idChungTu);
        }
        public static List<ChungTuXLKInfor> GetListXLK(string malenh)
        {
            return tbl_ChungTuDAO.Instance.GetListXlk(malenh);
        }

        public static List<HangHoa_ChiTietInfo> GetListXLK1(string malenh, TransactionType transactionType)
        {
            return tbl_ChungTuDAO.Instance.GetListXlk1(malenh, transactionType);
        }

        public static List<HangHoa_ChiTietInfo> GetPhieuXuatLKDetail1(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuXuatLKDetail1(idChungTu);
        }

        public static List<MaVachThanhPhamInfo> GetListNTP(string malenh)
        {
            return tbl_ChungTuDAO.Instance.GetListNtp(malenh);
        }
        public static List<MaVachThanhPhamInfo> GetListTTP(string malenh)
        {
            return tbl_ChungTuDAO.Instance.GetListTtp(malenh);
        }
        public static List<BaoCao_ChiTietInfor> GetPhieuXuatLKDetail(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuXuatLKDetail(idChungTu);
        }
        public static List<BaoCao_ChiTietInfor> GetPhieuNhapTPDetail(int idChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetPhieuNhapTPDetail(idChungTu);
        }
        public static List<ChiTietDieuChuyenDonHangInfo> CheckSoPhieuByDH(string soChungTu, int idSanPham)
        {
            return tbl_ChungTuDAO.Instance.CheckSoPhieuByDH(soChungTu,idSanPham);
        }
        public static ChungTu_ChiTietHangHoaDCDHInfo GetSoChungTuBan(string soChungTu, int idChiTiet)
        {
            return tbl_ChungTuDAO.Instance.GetSoChungTuBan(soChungTu, idChiTiet);
        }
        public static ChungTu_ChiTietInfo GetIdChungTuBySoPhieu (string soPhieu, int loaiChungTu)
        {
            return tbl_ChungTuDAO.Instance.GetIdChungTuBySoPhieu(soPhieu, loaiChungTu);
        }
    }
}
