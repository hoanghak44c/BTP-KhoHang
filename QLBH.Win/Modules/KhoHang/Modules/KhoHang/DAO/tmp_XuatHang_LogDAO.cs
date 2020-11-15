using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class tmp_XuatHang_LogDAO :BaseDAO
    {
        private static tmp_XuatHang_LogDAO instance;
        private tmp_XuatHang_LogDAO()
        {
            CRUDTableName = Declare.TableNamespace.tmp_NhapHang_Log;
            UseCaching = true;
        }
        public static tmp_XuatHang_LogDAO Instance
        {
            get
            {
                if (instance == null) instance = new tmp_XuatHang_LogDAO();
                return instance;
            }
        }
        internal void Insert(string NguoiNhap,string SoPO)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spNhapHangLogInsert,NguoiNhap,SoPO);
        }
        internal void Update(string NguoiNhap, string SoPO)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spNhapHangLogUpdate,NguoiNhap,SoPO);
        }
        public List<tmp_XuatHang_Log_Info> GetNhapHangLogBySoPO(tmp_XuatHang_Log_Info id)
        {
            return GetListCommand<tmp_XuatHang_Log_Info>(Declare.StoreProcedureNamespace.spNhapHangLogGetBySoPO, id.SoPO, id.NguoiXuat);
        }
        //public List<tmp_XuatHang_Log_Info> GetNhapHangLogByUser(tmp_XuatHang_Log_Info id)
        //{
        //    return GetListCommand<tmp_XuatHang_Log_Info>(Declare.StoreProcedureNamespace.spNhapHangLogGetByUser, id.SoPO);
        //}

    }
}
