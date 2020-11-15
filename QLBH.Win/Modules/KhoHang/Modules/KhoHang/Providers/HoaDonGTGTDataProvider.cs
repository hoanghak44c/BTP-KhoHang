using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class HoaDonGTGTDataProvider
    {
        private static HoaDonGTGTDataProvider instance;
        public static HoaDonGTGTDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonGTGTDataProvider();
                return instance;
            }
        }
        internal HoaDonGTGTInfo GetChungTuBySoChungTu(string sochungtu)
        {
            return HoaDonGTGTDAO.Instance.GetChungTuBySoChungTu(sochungtu);
        }
        internal List<HoaDonGTGT_ChiTietInfo> GetChungTuChiTietByIDChungTu(int IdChungTu)
        {
            return HoaDonGTGTDAO.Instance.ChungTuChiTietGetByIdChungTu(IdChungTu);
        }
    }
}
