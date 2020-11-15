using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class PhieuThuDataProvider
    {
        private static PhieuThuDataProvider instance;
        public static PhieuThuDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new PhieuThuDataProvider();
                return instance;
            }
        }

        internal List<PhieuThu_ChiTietInfo> GetChungTuChiTietBySoPhieuThu(string soPhieuThu)
        {
            return PhieuThuDAO.Instance.ChungTuChiTietGetBySoPhieuThu(soPhieuThu);
        }
    }
}
