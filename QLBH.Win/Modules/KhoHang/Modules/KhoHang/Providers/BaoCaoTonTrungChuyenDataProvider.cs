using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class TonTrungChuyenInfo
    {
        public string KhoXuat { get; set; }
        public string KhoNhan { get; set; }
        public string SoLuong { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string Nganh { get; set; }
    }

    public class BaoCaoTonTrungChuyenDataProvider
    {

        private static BaoCaoTonTrungChuyenDataProvider instance;

        private BaoCaoTonTrungChuyenDataProvider()
        {
        }

        public static BaoCaoTonTrungChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoTonTrungChuyenDataProvider();
                return instance;
            }
        }

        public List<TonTrungChuyenInfo> GetListTonTrungChuyen()
        {
            return BaoCaoTonTrungChuyenDAO.Instance.GetListTonTrungChuyen();
        }
    }
}