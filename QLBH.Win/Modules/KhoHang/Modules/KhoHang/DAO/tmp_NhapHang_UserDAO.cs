using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class tmp_NhapHang_UserDAO : BaseDAO
    {
         private static tmp_NhapHang_UserDAO instance;
         private tmp_NhapHang_UserDAO()
        {
            CRUDTableName = Declare.TableNamespace.tmp_NhapHang_User;
            UseCaching = true;
        }
         public static tmp_NhapHang_UserDAO Instance
        {
            get
            {
                if (instance == null) instance = new tmp_NhapHang_UserDAO();
                return instance;
            }
        }
         public List<tmp_NhapHang_UserInfo> GetListNhapHangUserInfo(int idKho)
         {
             return GetListCommand<tmp_NhapHang_UserInfo>(Declare.StoreProcedureNamespace.spNhapHangUserSelectAll, idKho);
         }

         public List<tmp_NhapHang_UserInfo> GetListTraHangUserInfo(int idKho)
         {
             return GetListCommand<tmp_NhapHang_UserInfo>(Declare.StoreProcedureNamespace.spTraHangUserSelectAll, idKho);
         }

         //public List<tmp_NhapHang_UserChiTietInfo> GetNhapHangUserByIdInfo(tmp_NhapHang_UserChiTietInfo id)
         //{
         //    //CreateGetListCommand(Declare.StoreProcedureNamespace.spNhapHangUserGetById);
         //    //Parameters.AddWithValue("@p_MaPO", id.SoPO);
         //    return GetListCommand<tmp_NhapHang_UserChiTietInfo>(Declare.StoreProcedureNamespace.spNhapHangUserGetById, id.SoPO);
         //}

        public List<tmp_NhapHang_UserInfo> Search(string sSoPhieuNhap, string sSoPo, string maNhaCungCap)
        {
            return GetListCommand<tmp_NhapHang_UserInfo>(Declare.StoreProcedureNamespace.spNhapHangSearch, sSoPhieuNhap, sSoPo, maNhaCungCap, Declare.IdKho);
        }
    }
}
