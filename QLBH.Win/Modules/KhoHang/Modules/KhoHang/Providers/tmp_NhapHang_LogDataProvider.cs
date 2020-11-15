using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class tmp_NhapHang_LogDataProvider
    {
        internal static void Insert(string nguoiNhap,string soPo, string soPhieuNhap, int loaiGiaoDich, int idKho)
        {
            tmp_NhapHang_LogDAO.Instance.Insert(nguoiNhap,soPo, soPhieuNhap, loaiGiaoDich, idKho);
        }

        internal static void Update(string nguoiNhap, string soPo, string soPhieuNhap, int loaiGiaoDich, int idKho)
        {
            tmp_NhapHang_LogDAO.Instance.Update(nguoiNhap, soPo, soPhieuNhap, loaiGiaoDich, idKho);
        }

        internal static void Delete(string soPo, string soPhieuNhap, int loaiGiaoDich, int idKho)
        {
            tmp_NhapHang_LogDAO.Instance.Delete(soPo, soPhieuNhap, loaiGiaoDich, idKho);
        }

        public static List<tmp_NhapHang_LogInfo> GetNhapHangLogBySoPO(tmp_NhapHang_LogInfo id)
        {
            return tmp_NhapHang_LogDAO.Instance.GetNhapHangLogBySoPO(id);
        }

        public static List<tmp_NhapHang_LogInfo> GetNhapHangLogByUser(tmp_NhapHang_LogInfo id)
        {
            return tmp_NhapHang_LogDAO.Instance.GetNhapHangLogByUser(id);
        }
    }
}
