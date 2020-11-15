using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class tblChungTu_ChiTietDataProvider
    {
        internal static int Insert(ChungTu_ChiTietInfo info)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.Insert(info);
        }
        public static List<ChungTu_ChiTietInfo> ChungTuChiTietGetByID(int IdChungTu, int IdSanPham)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.ChungTuChiTietGetByID(IdChungTu, IdSanPham);
        }

        public static List<DeNghiXuatTieuHaoChiTietInfo> DeNghiXuatTieuHaoChiTietSelectByIDChungTu(int idChungTu)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.GetListDeNghiXuatTieuHaoChiTietByIdChungTu(idChungTu);
        }

        public static List<tmp_NhapHang_UserChiTietInfo> ChungTuChiTietSelectByIDChungTu(int idChungTu)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.GetListChungTuChiTietByIdChungTu(idChungTu);
        }
        public static List<ChungTu_ChiTietInfo> ChungTuChiTietGetByIdSanPham(string SoChungTu, int IdSanPham)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.ChungTuChiTietGetByIdSanPham(SoChungTu, IdSanPham);
        }
        public static List<ChungTu_ChiTietHangHoaBaseInfo> ChungTuChiTietHangHoaGetByIdChungTu(int IdChungTu)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.ChungTuChiTietGetByIdChungTu(IdChungTu);
        }
        public static List<ChungTu_ChiTietHangHoaTraNCCInfo> ChungTuChiTietHangHoaGetBySoPO(string PO)
        {
            return tbl_ChungTu_ChiTietDAO.Instance.ChungTuChiTietGetBySoPO(PO);
        }
        internal static void Delete(int IdChungTu)
        {
            tbl_ChungTu_ChiTietDAO.Instance.Delete(IdChungTu);
        }
    }
}
