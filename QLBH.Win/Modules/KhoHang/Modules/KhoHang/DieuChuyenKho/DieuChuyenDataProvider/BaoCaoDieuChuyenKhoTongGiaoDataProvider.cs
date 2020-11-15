using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BaoCaoDieuChuyenKhoTongGiaoDataProvider
    {

        private static BaoCaoDieuChuyenKhoTongGiaoDataProvider instance;

        private BaoCaoDieuChuyenKhoTongGiaoDataProvider()
        {
        }

        public static BaoCaoDieuChuyenKhoTongGiaoDataProvider Instance
        {
            get { return instance ?? (instance = new BaoCaoDieuChuyenKhoTongGiaoDataProvider()); }
        }

        public List<DieuChuyenKhoTongGiaoInfo> GetListSource()
        {
            return BaoCaoDieuChuyenKhoTongGiaoDao.Instance.GetListSource();
        }

        internal List<ChungTuXuatDieuChuyenInfo> GetListSource(string soGiaoDich, System.DateTime ngayGiaoDich, string trangThai)
        {
            return BaoCaoDieuChuyenKhoTongGiaoDao.Instance.GetListSource(soGiaoDich, ngayGiaoDich, trangThai);
        }
    }
}