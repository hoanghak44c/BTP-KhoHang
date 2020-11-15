using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class TransTypeDataProvider
    {

        private static TransTypeDataProvider instance;

        private TransTypeDataProvider()
        {
        }

        public static TransTypeDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new TransTypeDataProvider();
                return instance;
            }
        }

        public List<TransTypeInfo> GetListTransType()
        {
            return TransTypeDAO.Instance.GetListTransType();
        }
    }
}