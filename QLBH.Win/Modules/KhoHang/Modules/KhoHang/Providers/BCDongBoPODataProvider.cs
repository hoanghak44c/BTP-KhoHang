using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class BCDongBoPODataProvider
    {

        private static BCDongBoPODataProvider instance;

        private BCDongBoPODataProvider()
        {
        }

        public static BCDongBoPODataProvider Instance
        {
            get
            {
                if (instance == null) instance = new BCDongBoPODataProvider();
                return instance;
            }
        }

        public List<LichSuNhapHangInfo> GetLichSuTraHang(string sOrg)
        {
            return BCDongBoPODAO.Instance.GetLichSuTraHang(sOrg);
        }

        public List<LichSuNhapHangInfo> GetLichSuNhapHang(string sOrg, string sSub, DateTime runningDate, int loaiGiaoDich)
        {
            return BCDongBoPODAO.Instance.GetLichSuNhapHang(sOrg, sSub, runningDate, loaiGiaoDich);
        }


        public DateTime GetNextDateNhapHang(string maTrungTam, string maKho, DateTime runningDate, int loaiGiaoDich)
        {
            return BCDongBoPODAO.Instance.GetNextDateNhapHang(maTrungTam, maKho, runningDate, loaiGiaoDich);
        }
    }
}