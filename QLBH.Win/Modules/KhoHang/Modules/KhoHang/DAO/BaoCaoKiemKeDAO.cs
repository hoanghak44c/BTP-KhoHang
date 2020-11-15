using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BaoCaoKiemKeDAO : SystemDAO
    {
        private static BaoCaoKiemKeDAO instance;
        private BaoCaoKiemKeDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static BaoCaoKiemKeDAO Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoKiemKeDAO();
                return instance;
            }
        }
        public List<BCChiTietKiemKeInfo> GetBCTongHopKiemKe(string kho, DateTime tuNgay, DateTime denNgay)
        {
            return GetListCommand<BCChiTietKiemKeInfo>(Declare.StoreProcedureNamespace.sp_BC_TongHopKiemKe,kho, clsUtils.DateValue(tuNgay), clsUtils.DateValue(denNgay));
        }
        public List<BCChiTietKiemKeInfo> GetBCKiemKeTonKho(string kho, int idDotKiemKe)
        {
            return GetListCommand<BCChiTietKiemKeInfo>(Declare.StoreProcedureNamespace.sp_BC_KiemKeTonKho, kho,idDotKiemKe);
        }
        public List<BCChiTietKiemKeInfo> GetBCKiemKeTonMaVach(string kho, int idDotKiemKe)
        {
            return GetListCommand<BCChiTietKiemKeInfo>(Declare.StoreProcedureNamespace.sp_BC_KiemKeTonMaVach, kho, idDotKiemKe);
        }
        public List<BCChiTietKiemKeInfo> GetBCKiemKeMaVachBanNhieuLan(int idDotKiemKe)
        {
            return GetListCommand<BCChiTietKiemKeInfo>(Declare.StoreProcedureNamespace.sp_BC_KiemKeMaVachBanNhieuLan, idDotKiemKe);
        }
        /// <summary>
        /// Báo cáo danh sách phiếu kiểm kê
        /// </summary>
        /// <param name="kho"></param>
        /// <param name="idDotKiemKe"></param>
        /// <returns></returns>
        public List<BCDanhSachPhieuKiemKeInfo> GetBCDanhSachPhieuKiemKe(string kho, int idDotKiemKe)
        {
            return GetListCommand<BCDanhSachPhieuKiemKeInfo>(Declare.StoreProcedureNamespace.sp_BC_DanhSachPhieuKiemKe, kho, idDotKiemKe);
        }
    }
}
