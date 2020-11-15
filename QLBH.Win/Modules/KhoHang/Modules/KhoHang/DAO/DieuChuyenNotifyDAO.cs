using System;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DieuChuyenNotifyDAO : BaseDAO
    {

        private static DieuChuyenNotifyDAO instance;

        private DieuChuyenNotifyDAO()
        {
        }

        public static DieuChuyenNotifyDAO Instance
        {
            get
            {
                if (instance == null) instance = new DieuChuyenNotifyDAO();
                return instance;
            }
        }

        public int HasChanged(DateTime checkPoint, ref string maKhos, int idNhanVien)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDieuChuyenCheckChanged, checkPoint, idNhanVien, maKhos);
            maKhos = Convert.ToString(Parameters["p_Kho"].Value);
            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
    }
}