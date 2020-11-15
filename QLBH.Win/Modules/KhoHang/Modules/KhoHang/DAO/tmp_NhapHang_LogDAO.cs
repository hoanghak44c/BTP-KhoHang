using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class tmp_NhapHang_LogDAO : BaseDAO
    {
        private static tmp_NhapHang_LogDAO instance;
        
        private tmp_NhapHang_LogDAO()
        {
            CRUDTableName = Declare.TableNamespace.tmp_NhapHang_Log;
            UseCaching = true;
        }

        public static tmp_NhapHang_LogDAO Instance
        {
            get
            {
                if (instance == null) instance = new tmp_NhapHang_LogDAO();
                return instance;
            }
        }

        internal void Insert(string NguoiNhap, string SoPO, string soPhieuNhap, int loaiGiaoDich, int idKho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spNhapHangLogInsert, NguoiNhap,SoPO, soPhieuNhap, loaiGiaoDich, idKho);
        }

        internal void Update(string NguoiNhap, string SoPO, string soPhieuNhap, int loaiGiaoDich, int idKho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spNhapHangLogUpdate, NguoiNhap, SoPO, soPhieuNhap, loaiGiaoDich, idKho);
        }

        internal void Delete(string SoPO, string soPhieuNhap, int loaiGiaoDich, int idKho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spNhapHangLogDelete, SoPO, soPhieuNhap, loaiGiaoDich, idKho);
        }

        public List<tmp_NhapHang_LogInfo> GetNhapHangLogBySoPO(tmp_NhapHang_LogInfo id)
        {
            return GetListCommand<tmp_NhapHang_LogInfo>(Declare.StoreProcedureNamespace.spNhapHangLogGetBySoPO, id.SoPO, id.SoPhieuNhap,id.NguoiNhap, id.LoaiGiaoDich);
        }

        public List<tmp_NhapHang_LogInfo> GetNhapHangLogByUser(tmp_NhapHang_LogInfo id)
        {
            return GetListCommand<tmp_NhapHang_LogInfo>(Declare.StoreProcedureNamespace.spNhapHangLogGetByUser, id.SoPO, id.SoPhieuNhap, id.LoaiGiaoDich, Declare.IdKho);
        }
    }
}
