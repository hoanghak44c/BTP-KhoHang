using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.DAO;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BangGiaReportDataProvider
    {
        private static BangGiaReportDataProvider instance;
        public static BangGiaReportDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BangGiaReportDataProvider();
                return instance;
            }
        }
        public List<BangGiaReportInfo> SanPhamGetCauHinhByMaSanPham(string maSp)
        {
            return BangGiaReportDAO.Instance.SanPhamGetCauHinhByMaSP(maSp);
        }
        public BangGiaReportInfo SanPhamGetGiaByMaSanPham(string maSp)
        {
            return BangGiaReportDAO.Instance.SanPhamGetGiaByMaSP(maSp);
        }
        public BangGiaReportInfo SanPhamGetByMaVach(string maVach)
        {
            return BangGiaReportDAO.Instance.SanPhamGetByMaVach(maVach);
        }
    }
}
