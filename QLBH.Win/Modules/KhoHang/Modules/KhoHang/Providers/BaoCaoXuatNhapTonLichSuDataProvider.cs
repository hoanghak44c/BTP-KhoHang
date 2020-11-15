using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BaoCaoXuatNhapTonLichSuDataProvider
    {

        private static BaoCaoXuatNhapTonLichSuDataProvider instance;

        private BaoCaoXuatNhapTonLichSuDataProvider()
        {
        }

        public static BaoCaoXuatNhapTonLichSuDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoXuatNhapTonLichSuDataProvider();
                return instance;
            }
        }

        public void LoadBaoCaoXuatNhapTonLichSuInfo(string maKho, string maSanPham, DateTime fromDate, DateTime toDate)
        {
            BaoCaoXuatNhapTonLichSuDAO.Instance.LoadBaoCaoXuatNhapTonLichSuInfo(maKho, maSanPham, fromDate, toDate);
        }

        public List<BaoCaoXuatNhapTonLichSuInfo> GetListBaoCaoXuatNhapTonLichSuInfo(string maKho, string maSanPham, DateTime fromDate, DateTime toDate, int batDau, int ketThuc)
        {
            return BaoCaoXuatNhapTonLichSuDAO.Instance.GetListBaoCaoXuatNhapTonLichSuInfo(maKho, maSanPham, fromDate, toDate, batDau, ketThuc);
        }

    }
}