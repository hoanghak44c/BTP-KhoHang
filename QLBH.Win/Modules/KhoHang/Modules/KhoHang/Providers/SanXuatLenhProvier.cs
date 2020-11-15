using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class SanXuatLenhProvier
    {
        public static List<SanXuatLenhInfo> GetSanXuatLenhByMaLenh(string MaLenh,int idchungtu)
        {
            return SanXuatLenhDAO.Instance.GetListSanXuatByMaLenh(MaLenh,idchungtu);
        }

        public static List<SanXuatLenhInfo> GetRecentSanXuatLenh(string maLenh, string makho, string MaTrungTam, string LoaiMaLenh)
        {
            return SanXuatLenhDAO.Instance.GetRecentListSanXuat(maLenh, makho, MaTrungTam, LoaiMaLenh);
        }

        public static List<SanXuatLenhInfo> GetAllSanXuatLenh(string makho, string MaTrungTam,string LoaiMaLenh)
        {
            return SanXuatLenhDAO.Instance.GetAllListSanXuat(makho,MaTrungTam,LoaiMaLenh);
        }
        public static DateTime GetMaxDateSanXuatLenh(string MaTrungTam)
        {
            return SanXuatLenhDAO.Instance.GetMaxDateSanXuatLenh(MaTrungTam);
        }
        public static int GetSoLuongSanXuatLenh(int idKho, int loaichungtu, string sochungtugoc, int trangthai)
        {
            return SanXuatLenhDAO.Instance.GetSoLuongSanXuatLenh(idKho, loaichungtu, sochungtugoc, trangthai);
        }
        public static int GetSoLuongChungTu(int loaichungtu, string sochungtugoc, int trangthai,string soseri)
        {
            return SanXuatLenhDAO.Instance.GetSoLuongChungTu(loaichungtu, sochungtugoc, trangthai,soseri);
        }
        public static int GetSoLuongXacNhanNhap(int loaichungtu, string sochungtugoc, int trangthai, string soseri)
        {
            return SanXuatLenhDAO.Instance.GetSoLuongXacNhanNhap(loaichungtu, sochungtugoc, trangthai, soseri);
        }
        public static int GetSoLuongDNSanXuatLenh(int loaichungtu, string sochungtugoc,string matrungtam)
        {
            return SanXuatLenhDAO.Instance.GetSoLuongDNSanXuatLenh(loaichungtu, sochungtugoc,matrungtam);
        }
        internal static void Insert(SanXuatLenhInfo SanXuatLenhInfo)
        {
            SanXuatLenhDAO.Instance.Insert(SanXuatLenhInfo);
        }
        internal static void InsertHangHoaChiTiet(HangHoaChiTietInfo SanXuatLenhInfo)
        {
            SanXuatLenhDAO.Instance.InsertHangHoaChiTiet(SanXuatLenhInfo);
        }
        /// <summary>
        /// update trạng thái, số lượng hoàn thành.
        /// </summary>
        /// <param name="SanXuatLenhInfo"></param>
        internal static void Update1(SanXuatLenhInfo SanXuatLenhInfo)
        {
            SanXuatLenhDAO.Instance.Update1(SanXuatLenhInfo);
        }

        internal static void Update(SanXuatLenhInfo SanXuatLenhInfo)
        {
            SanXuatLenhDAO.Instance.Update(SanXuatLenhInfo);
        }
        internal static void UpdateTrangThai(SanXuatLenhInfo SanXuatLenhInfo)
        {
            SanXuatLenhDAO.Instance.UpdateTrangThai(SanXuatLenhInfo);
        }
        internal static void UpdateTrangThaiChungTu(int IdChungTu,int TrangThai)
        {
            SanXuatLenhDAO.Instance.UpdateTrangThaiChungTu(IdChungTu,TrangThai);
        }
        public static int CheckMaLenh(string maLenh,string mathanhpham,string matrungtam)
        {
            return SanXuatLenhDAO.Instance.Exist(maLenh,mathanhpham,matrungtam);
        }
        public static int CheckCtietMaLenh(string maLenh, string matrungtam, string malinhkien)
        {
            return SanXuatLenhDAO.Instance.CtietExist(maLenh, matrungtam, malinhkien);
        }
        internal static void tmpSanXuatDelete(string orgCode)
        {
            SanXuatLenhDAO.Instance.tmpSanXuatDelete(orgCode);
        }
        public static List<SanXuatLenhInfo> GetAlltmpSanXuatLenh(string MaTrungTam,string loaimalenh)
        {
            return SanXuatLenhDAO.Instance.GetAllListtmpSanXuat(MaTrungTam,loaimalenh);
        }
        public static ChungTu_ChiTietInfo ChungTuCTGetByMaVach(int LoaiChungTu,string MaVach)
        {
            return SanXuatLenhDAO.Instance.ChungTuCTGetByMaVach(LoaiChungTu,MaVach);
        }
        public static ChungTuNhapNccChiTietHangHoaInfo ChungTuGetSoChungTuGoc(int IdChungTu)
        {
            return SanXuatLenhDAO.Instance.ChungTuGetSoChungTuGoc(IdChungTu);
        }
        public static ChungTuNhapNccChiTietHangHoaInfo CheckMaVach(string MaVach)
        {
            return SanXuatLenhDAO.Instance.CheckMaVach(MaVach);
        }
        internal static void tmpSanXuatCTietDelete(string orgCode)
        {
            SanXuatLenhDAO.Instance.tmpSanXuatCTietDelete(orgCode);
        }
        public static List<SanXuatCTietLenhInfo> GetAlltmpCTSanXuatLenh(string MaTrungTam)
        {
            return SanXuatLenhDAO.Instance.GetAllListtmpCTSanXuat(MaTrungTam);
        }
        public static List<ChungTuNhapNccChiTietHangHoaInfo> GetLinhKiemSXbyIdChungTu(int IdChungTu)
        {
            return SanXuatLenhDAO.Instance.GetLinhKienSXByIDChungTu(IdChungTu);
        }
    }
}
