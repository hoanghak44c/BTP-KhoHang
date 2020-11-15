using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class HoaDonGTGTDAO : BaseDAO
    {
        private static HoaDonGTGTDAO instance;
        private HoaDonGTGTDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu;
            UseCaching = true;
        }
       public static HoaDonGTGTDAO Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonGTGTDAO();
                return instance;
            }
        }
       public HoaDonGTGTInfo GetChungTuBySoChungTu(string soChungTu)
       {
           return GetObjectCommand<HoaDonGTGTInfo>(Declare.StoreProcedureNamespace.spChungTuGetBySoChungTu, soChungTu);
       }
       internal List<HoaDonGTGT_ChiTietInfo> ChungTuChiTietGetByIdChungTu(int idChungTu)
       {
           return GetListCommand<HoaDonGTGT_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdChungTu, idChungTu);
       }
    }
}
