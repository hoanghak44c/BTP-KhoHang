using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BaoCaoXuatNhapTonLichSuDAO : BaseDAO
    {

        private static BaoCaoXuatNhapTonLichSuDAO instance;

        private BaoCaoXuatNhapTonLichSuDAO()
        {
        }

        public static BaoCaoXuatNhapTonLichSuDAO Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoXuatNhapTonLichSuDAO();
                return instance;
            }
        }

        public List<BaoCaoXuatNhapTonLichSuInfo> GetListBaoCaoXuatNhapTonLichSuInfo(string maKho, string maSanPham, DateTime fromDate, DateTime toDate, int batDau, int ketThuc)
        {
            return GetListCommand<BaoCaoXuatNhapTonLichSuInfo>("sp_baocao_xuatnhaptonls5", fromDate, batDau, ketThuc, Declare.UserId);
        }

        public void LoadBaoCaoXuatNhapTonLichSuInfo(string maKho, string maSanPham, DateTime fromDate, DateTime toDate)
        {
            ExecuteCommand("sp_baocao_xuatnhaptonLS", maKho, maSanPham, fromDate, toDate, Declare.UserId);
        }

    }
}