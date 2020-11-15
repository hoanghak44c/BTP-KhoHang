using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class tblChungTu_ChiTiet_HangHoaDataProvider
    {
        //internal static void Insert(ChungTu_ChiTiet_HangHoaInfo info)
        //{
        //    tbl_ChungTu_ChiTiet_HanghoaDAO.Instance.Insert(info);
        //}
        public static List<ChungTuChiTietMaVachInfo> ChungTuChiTietGetByIdSanPham(int IdChungTu)
        {
            return tbl_ChungTu_ChiTiet_HanghoaDAO.Instance.ChiTietHangHoaGetByIdChungtu(IdChungTu);
        }
        internal static void Delete(int idChiTietChungTu,int idChiTietHangHoa)
        {
            tbl_ChungTu_ChiTiet_HanghoaDAO.Instance.Delete(idChiTietChungTu, idChiTietHangHoa);
        }
    }
}
