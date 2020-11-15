using System;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DieuChuyenNotifyProvider
    {

        private static DieuChuyenNotifyProvider instance;

        private DieuChuyenNotifyProvider()
        {
        }

        public static DieuChuyenNotifyProvider Instance
        {
            get
            {
                if (instance == null) instance = new DieuChuyenNotifyProvider();
                return instance;
            }
        }

        public int HasChanged(DateTime checkPoint, ref string maKhos)
        {
            maKhos = String.Empty;

            if (Declare.USER_INFOR != null && Declare.USER_INFOR is NguoiDungInfor)
            {
                //foreach (DMKhoCBOLoadInfo khoCboLoadInfo in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                //{
                //    maKhos += (String.IsNullOrEmpty(maKhos) ? "" : ",") + khoCboLoadInfo.MaKho;
                //}

                return DieuChuyenNotifyDAO.Instance.HasChanged(checkPoint, ref maKhos, ((NguoiDungInfor)Declare.USER_INFOR).IdNhanVien);
                
            }
            return 0;
        }
    }
}