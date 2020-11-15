using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BaoCaoKiemKeDataProvider
    {
        private static BaoCaoKiemKeDataProvider instance;
        public static BaoCaoKiemKeDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BaoCaoKiemKeDataProvider();
                return instance;
            }
        }
        public List<BCChiTietKiemKeInfo> GetBCTongHopKiemKe(string kho, DateTime tuNgay, DateTime denNgay)
        {
            return BaoCaoKiemKeDAO.Instance.GetBCTongHopKiemKe(kho, tuNgay, denNgay);
        }
        public List<BCChiTietKiemKeInfo> GetBCKiemKeTonKho(string kho, int idDotKiemKe)
        {
            return BaoCaoKiemKeDAO.Instance.GetBCKiemKeTonKho(kho, idDotKiemKe);
        }
        public List<BCChiTietKiemKeInfo> GetBCKiemKeTonMaVach(string kho, int idDotKiemKe)
        {
            return BaoCaoKiemKeDAO.Instance.GetBCKiemKeTonMaVach(kho, idDotKiemKe);
        }
        public List<BCChiTietKiemKeInfo> GetBCKiemKeMaVachBanNhieuLan(int idDotKiemKe)
        {
            return BaoCaoKiemKeDAO.Instance.GetBCKiemKeMaVachBanNhieuLan(idDotKiemKe);
        }
        /// <summary>
        /// Báo cáo danh sách phiếu kiểm kê
        /// </summary>
        /// <param name="kho"></param>
        /// <param name="idDotKiemKe"></param>
        /// <returns></returns>
        public List<BCDanhSachPhieuKiemKeInfo> GetBCDanhSachPhieuKiemKe(string kho, int idDotKiemKe)
        {
            return BaoCaoKiemKeDAO.Instance.GetBCDanhSachPhieuKiemKe(kho, idDotKiemKe);
        }
    }
}
