using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BaoCaoGiaoDichKhongDongBoDataProvider
    {

        private static BaoCaoGiaoDichKhongDongBoDataProvider instance;

        private BaoCaoGiaoDichKhongDongBoDataProvider()
        {
        }

        public static BaoCaoGiaoDichKhongDongBoDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoGiaoDichKhongDongBoDataProvider();
                return instance;
            }
        }

        public List<GiaoDichNhapXuatKhongDongBoInfo> GetListGiaoDichKhongDongBo(string maKho, string maSanPham, DateTime fromDate, DateTime toDate)
        {
            return BaoCaoGiaoDichKhongDongBoDAO.Instance.GetListGiaoDichKhongDongBo(maKho, maSanPham, fromDate, toDate);
        }
    }
}