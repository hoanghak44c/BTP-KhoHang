using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class KhoThongKeHangTonDataProvider
    {

        private static KhoThongKeHangTonDataProvider instance;

        private KhoThongKeHangTonDataProvider()
        {
        }

        public static KhoThongKeHangTonDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new KhoThongKeHangTonDataProvider();
                return instance;
            }
        }

        public List<KhoThongKeHangTonInfo> GetListThongKeHangTonKho(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeHangTonKho(idKho, idTrungTam, fromDate, toDate);
        }

        public List<KhoThongKeHangTonInfo> GetListThongKeHangTonKho2(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate
            , int pageIndex, int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeHangTonKho2(idKho, idTrungTam, fromDate, toDate
                , pageIndex, pageSize, userId);
        }

        public List<KhoThongKeHangTonLichSuInfo> GetListThongKeHangTonLichSu(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate
    , int pageIndex, int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeHangTonLichSu(idKho, idTrungTam, fromDate, toDate
                , pageIndex, pageSize, userId);
        }

        public List<KhoThongKeHangTonLichSuInfo> GetListThongKeHangTonLichSu3(string maKho, string maTrungTam, DateTime fromDate, DateTime toDate
, int pageIndex, int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeHangTonLichSu3(maKho, maTrungTam, fromDate, toDate
                , pageIndex, pageSize, userId);
        }

        public List<KhoThongKeHangTonInfo> GetListThongKeHangTonKho3(string maKho, string maTrungTam, DateTime fromDate, DateTime toDate
    , int pageIndex, int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeHangTonKho3(maKho, maTrungTam, fromDate, toDate
                , pageIndex, pageSize, userId);
        }


        public int LoadDataThongKeHangTonKho(int step, int idSanPham, int idKho, int idTrungTam, DateTime fromDate, DateTime toDate ,int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.LoadDataThongKeHangTonKho(step, idSanPham, idKho, idTrungTam, fromDate, toDate, pageSize, userId);
        }

        public int LoadDataThongKeHangTonKho2(int step, string maSanPham, string maKho, string maTrungTam, DateTime fromDate, DateTime toDate, int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.LoadDataThongKeHangTonKho2(step, maSanPham, maKho, maTrungTam, fromDate, toDate, pageSize, userId);
        }

        public int LoadDataThongKeHangTonLichSu(int step, string maSanPham, string maKho, string maTrungTam, DateTime fromDate, DateTime toDate, int pageSize, int userId)
        {
            return KhoThongKeHangTonDAO.Instance.LoadDataThongKeHangTonLichSu(step, maSanPham, maKho, maTrungTam, fromDate, toDate, pageSize, userId);
        }

        public List<KhoThongKeHangTonInfo> GetListTonKho(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            return KhoThongKeHangTonDAO.Instance.GetListTonKho(idKho, idTrungTam, fromDate, toDate, Declare.UserId);
        }

        public List<KhoThongKeTonMaVachInfo> GetListThongKeTonMaVach(int idTrungTam, int idKho, int idSanPham)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeTonMaVach(idTrungTam, idKho, idSanPham);
        }

        public List<KhoThongKeChungTuInfo> GetListThongKeChungTuLienQuan(int idTrungTam, int idKho, int idSanPham)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeChungTuLienQuan(idTrungTam, idKho, idSanPham);
        }

        public List<KhoThongKeChiTietHangTrungChuyenInfo> GetListChiTietHangTrungChuyen(int idTrungTam, int idKho, int idSanPham)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeChiTietHangTrungChuyen(idTrungTam, idKho, idSanPham);
        }

        public void DeleteData(int idKho, int idTrungTam)
        {
            KhoThongKeHangTonDAO.Instance.DeleteData(idKho, idTrungTam);
        }

        public void TongHopTon(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            KhoThongKeHangTonDAO.Instance.TongHopTon(idKho, idTrungTam, fromDate, toDate, Declare.UserId);
        }

        public void TongHopTonDauKy(int idKho, int idTrungTam, DateTime fromDate)
        {
            KhoThongKeHangTonDAO.Instance.TongHopTonDauKy(idKho, idTrungTam, fromDate, Declare.UserId);
        }

        public void TongHopTonTheoThang(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            KhoThongKeHangTonDAO.Instance.TongHopTonTheoThang(idKho, idTrungTam, fromDate, toDate, Declare.UserId);
        }

        public void TongHopTonTheoNgay(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            KhoThongKeHangTonDAO.Instance.TongHopTonTheoNgay(idKho, idTrungTam, fromDate, toDate, Declare.UserId);
        }

        public void TongHopTonTheoNam(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            KhoThongKeHangTonDAO.Instance.TongHopTonTheoNam(idKho, idTrungTam, fromDate, toDate, Declare.UserId);
        }

        public DateTime GetMinDate(TonInfoBase khoThongKeHangTonInfo)
        {
            return KhoThongKeHangTonDAO.Instance.GetMinDate(khoThongKeHangTonInfo);
        }

        public DateTime GetMaxDate(TonInfoBase khoThongKeHangTonInfo)
        {
            return KhoThongKeHangTonDAO.Instance.GetMaxDate(khoThongKeHangTonInfo);
        }

        public DateTime GetNextDate(TonInfoBase khoThongKeHangTonInfo, DateTime runningDate)
        {
            return KhoThongKeHangTonDAO.Instance.GetNextDate(khoThongKeHangTonInfo, runningDate);
        }

        public int GetTongSoGiaoDich(TonInfoBase khoThongKeHangTonInfo)
        {
            return KhoThongKeHangTonDAO.Instance.GetTongSoGiaoDich(khoThongKeHangTonInfo);
        }

        public List<KhoThongKeChungTuInfo> GetListThongKeChungTuLienQuan(int idTrungTam, int idKho, int idSanPham, DateTime runningDate)
        {
            return KhoThongKeHangTonDAO.Instance.GetListThongKeChungTuLienQuan(idTrungTam, idKho, idSanPham, runningDate);
        }
    }
}