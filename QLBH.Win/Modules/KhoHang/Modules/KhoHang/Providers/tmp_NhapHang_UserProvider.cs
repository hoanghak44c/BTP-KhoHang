using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class tmp_NhapHang_UserProvider
    {
        public static List<tmp_NhapHang_UserInfo> GetNhapHangUserInfor()
        {
            return tmp_NhapHang_UserDAO.Instance.GetListNhapHangUserInfo(Declare.IdKho);
        }

        public static List<tmp_NhapHang_UserInfo> GetNhapHangUserInfor(int idKho)
        {
            return tmp_NhapHang_UserDAO.Instance.GetListNhapHangUserInfo(idKho);
        }

        public static List<tmp_NhapHang_UserInfo> GetTraHangUserInfor(int idKho)
        {
            return tmp_NhapHang_UserDAO.Instance.GetListTraHangUserInfo(idKho);
        }

        public static List<tmp_NhapHang_UserInfo> GetTraHangUserInfor()
        {
            return tmp_NhapHang_UserDAO.Instance.GetListTraHangUserInfo(Declare.IdKho);
        }

        //public static List<tmp_NhapHang_UserChiTietInfo> GetListNhapHangUserInfoFromOid(tmp_NhapHang_UserChiTietInfo id)
        //{
        //    return tmp_NhapHang_UserDAO.Instance.GetNhapHangUserByIdInfo(id);
        //}

        public static List<tmp_NhapHang_UserInfo> Search(string sSoPhieuNhap, string sSoPO, string maNhaCungCap)
        {
            return tmp_NhapHang_UserDAO.Instance.Search(sSoPhieuNhap, sSoPO, maNhaCungCap);
        }
    }
}
