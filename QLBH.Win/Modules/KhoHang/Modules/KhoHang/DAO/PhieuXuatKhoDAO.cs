using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class PhieuXuatKhoDAO:BaseDAO
    {
        private static PhieuXuatKhoDAO instance;
        private PhieuXuatKhoDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu;
            UseCaching = true;
        }
        public static PhieuXuatKhoDAO Instance
        {
            get
            {
                if (instance == null) instance = new PhieuXuatKhoDAO();
                return instance;
            }
        }

        public PhieuXuatKhoInfo GetChungTuBySoPhieuXuat(string soPhieuXuat)
        {
            return GetObjectCommand<PhieuXuatKhoInfo>(Declare.StoreProcedureNamespace.spChungTuGetBySoPhieuXuat, soPhieuXuat);
        }
        internal List<PhieuXuatKho_ChiTietInfo> ChungTuChiTietGetByIdChungTu(int idChungTu)
        {
            return GetListCommand<PhieuXuatKho_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdChungTu, idChungTu);
        }
    }
}
