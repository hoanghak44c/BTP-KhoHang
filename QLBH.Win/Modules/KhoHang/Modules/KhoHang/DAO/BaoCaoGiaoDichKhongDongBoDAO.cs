using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BaoCaoGiaoDichKhongDongBoDAO : BaseDAO
    {

        private static BaoCaoGiaoDichKhongDongBoDAO instance;

        private BaoCaoGiaoDichKhongDongBoDAO()
        {
        }

        public static BaoCaoGiaoDichKhongDongBoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoGiaoDichKhongDongBoDAO();
                return instance;
            }
        }

        public List<GiaoDichNhapXuatKhongDongBoInfo> GetListGiaoDichKhongDongBo(string maKho, string maSanPham, DateTime fromDate, DateTime toDate)
        {
            return
                GetListCommand<GiaoDichNhapXuatKhongDongBoInfo>(
                    Declare.StoreProcedureNamespace.spGetListGiaoDichKhongDongBo, maKho, maSanPham, fromDate, toDate);
        }
    }
}