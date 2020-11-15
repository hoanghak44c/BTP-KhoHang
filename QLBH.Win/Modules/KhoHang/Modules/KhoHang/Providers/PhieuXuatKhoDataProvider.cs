using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class PhieuXuatKhoDataProvider
    {
        private static PhieuXuatKhoDataProvider instance;
        public static PhieuXuatKhoDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new PhieuXuatKhoDataProvider();
                return instance;
            }
        }
        internal PhieuXuatKhoInfo GetChungTuBySoPhieuXuat(string soPhieuXuat)
        {
            return PhieuXuatKhoDAO.Instance.GetChungTuBySoPhieuXuat(soPhieuXuat);
        }
        internal List<PhieuXuatKho_ChiTietInfo> GetChungTuChiTietByIDChungTu(int IdChungTu)
        {
            return PhieuXuatKhoDAO.Instance.ChungTuChiTietGetByIdChungTu(IdChungTu);
        }
    }
}
