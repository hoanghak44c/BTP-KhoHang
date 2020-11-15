using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BangGiaReportDAO : SystemDAO
    {
        private static BangGiaReportDAO instance;
        private BangGiaReportDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static BangGiaReportDAO Instance
        {
            get
            {
                if (instance == null) instance = new BangGiaReportDAO();
                return instance;
            }
        }
        public List<BangGiaReportInfo> SanPhamGetCauHinhByMaSP(string masp)
        {
            return GetListCommand<BangGiaReportInfo>(Declare.StoreProcedureNamespace.spSanPhamGetCauHinhByMaSP, masp);
        }
        public BangGiaReportInfo SanPhamGetGiaByMaSP(string masp)
        {
            return GetObjectCommand<BangGiaReportInfo>(Declare.StoreProcedureNamespace.spSanPhamGetGiaByMaSP, masp);
        }
        public BangGiaReportInfo SanPhamGetByMaVach(string maVach)
        {
            return GetObjectCommand<BangGiaReportInfo>(Declare.StoreProcedureNamespace.spSanPhamGetByMaVach, maVach, Declare.IdKho);
        }
    }
}
