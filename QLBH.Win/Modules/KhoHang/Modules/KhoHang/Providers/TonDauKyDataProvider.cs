using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class TonDauKyDataProvider
    {

        private static TonDauKyDataProvider instance;

        private TonDauKyDataProvider()
        {
        }

        public static TonDauKyDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new TonDauKyDataProvider();
                return instance;
            }
        }

        internal List<NapSoTonInfo> NapSoTon(int idKho, DateTime ngayDuDau, int idNguoiTao)
        {
            return TonDauKyDAO.Instance.NapSoTon(idKho, ngayDuDau, idNguoiTao);
        }

        public TonDauKyInfo GetTonDauKy(int idSanPham, int idKho, DateTime ngayDuDau, int idNguoiTao)
        {
            return TonDauKyDAO.Instance.GetTonDauKy(idSanPham, idKho, ngayDuDau, idNguoiTao);
        }

        public void Update(TonDauKyInfo tonDauKyInfo)
        {
            TonDauKyDAO.Instance.Update(tonDauKyInfo);
        }

        public int Insert(TonDauKyInfo tonDauKyInfo)
        {
            return TonDauKyDAO.Instance.Insert(tonDauKyInfo);
        }

        public void Update(HangHoaChiTietInfo hangHoaChiTietInfo)
        {
            TonDauKyDAO.Instance.Update(hangHoaChiTietInfo);
        }

        public int Insert(HangHoaChiTietInfo hangHoaChiTietInfo)
        {
            return TonDauKyDAO.Instance.Insert(hangHoaChiTietInfo);
        }

        public void Update (DateTime lanDongBo, int idKho)
        {
            TonDauKyDAO.Instance.Update(lanDongBo, idKho);
        }

        public HangHoaChiTietInfo GetIdHangHoaChiTietMaVachTonDauKy(string maVach, int idDuDauKy)
        {
            return TonDauKyDAO.Instance.GetIdHangHoaChiTietMaVachTonDauKy(maVach, idDuDauKy);
        }
    }
}