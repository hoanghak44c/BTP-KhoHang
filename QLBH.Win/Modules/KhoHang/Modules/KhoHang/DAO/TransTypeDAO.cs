using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class TransTypeDAO : BaseDAO
    {

        private static TransTypeDAO instance;

        private TransTypeDAO()
        {
        }

        public static TransTypeDAO Instance
        {
            get
            {
                if (instance == null) instance = new TransTypeDAO();
                return instance;
            }
        }

        public List<TransTypeInfo> GetListTransType()
        {
            return GetListCommand<TransTypeInfo>(Declare.StoreProcedureNamespace.spTransTypeSelectAll);
        }
    }
}