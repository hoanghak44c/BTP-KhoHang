using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class SanXuatCTietLenhProvider
    {
        public static List<SanXuatCTietLenhInfo> GetSanXuatLenhByMaLenh(string MaLenh,string orgcode)
        {
            return SanXuatCTietLenhDAO.Instance.GetListSanXuatByMaLenh(MaLenh,orgcode);
        }
        internal static void Insert(SanXuatCTietLenhInfo SanXuatCTietLenhInfo)
        {
            SanXuatCTietLenhDAO.Instance.Insert(SanXuatCTietLenhInfo);
        }
        internal static void Update(SanXuatCTietLenhInfo SanXuatCTietLenhInfo)
        {
            SanXuatCTietLenhDAO.Instance.Update(SanXuatCTietLenhInfo);
        }
        internal static void Delete(string MaLenh,string trungtam)
        {
            SanXuatCTietLenhDAO.Instance.Delete(MaLenh,trungtam);
        }
        internal static void UpdateSL(SanXuatCTietLenhInfo SanXuatCTietLenhInfo)
        {
            SanXuatCTietLenhDAO.Instance.UpdateSL(SanXuatCTietLenhInfo);
        }
    }
}
