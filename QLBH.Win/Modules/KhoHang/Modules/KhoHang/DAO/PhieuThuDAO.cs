using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class PhieuThuDAO : BaseDAO
    {
        private static PhieuThuDAO instance;
        private PhieuThuDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu;
            UseCaching = true;
        }
        public static PhieuThuDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhieuThuDAO();
                return instance;
            }
        }
        internal List<PhieuThu_ChiTietInfo> ChungTuChiTietGetBySoPhieuThu(string soPhieuThu)
        {
            return GetListCommand<PhieuThu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetBySoPhieuThu, soPhieuThu);
        }
    }
}
