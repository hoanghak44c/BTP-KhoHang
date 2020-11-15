using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class tmp_XuatHang_DAO: BaseDAO
    {
        private static tmp_XuatHang_DAO instance;
        
        private tmp_XuatHang_DAO() {}

        public static tmp_XuatHang_DAO Instance
        {
            get
            {
                if (instance == null) instance = new tmp_XuatHang_DAO();
                return instance;
            }
        }

        public List<ChungTuXuatTieuHaoInfor> GetListXuatByLoaiChungTu()
        {
            return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetByLoaiChungTu, Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN));
        }
        public List<ChungTuXuatTieuHaoInfor> GetListNhanByLoaiChungTu()
        {
            return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetByLoaiChungTu, Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN));
        }
        

    }
}
