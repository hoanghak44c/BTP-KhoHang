using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BaoCaoTonTrungChuyenDAO : BaseDAO
    {

        private static BaoCaoTonTrungChuyenDAO instance;

        private BaoCaoTonTrungChuyenDAO()
        {
        }

        public static BaoCaoTonTrungChuyenDAO Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoTonTrungChuyenDAO();
                return instance;
            }
        }

        public List<TonTrungChuyenInfo> GetListTonTrungChuyen()
        {
            return GetListCommand<TonTrungChuyenInfo>(Declare.StoreProcedureNamespace.spTonTrungChuyenGetList);
        }
    }
}