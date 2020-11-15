using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.BanHang.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NoteReportDataProvider
    {
        private static NoteReportDataProvider instance;
        public static NoteReportDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NoteReportDataProvider();
                return instance;
            }
        }
        public List<NoteSanPhamReportInfor> SanPhamGetHeaderByIdSanPham(string idSanPham,int idTrungTam)
        {
            return NoteReportDAO.Instance.SanPhamGetHeaderByIdSP(idSanPham,idTrungTam);
        }
        public List<NoteSanPhamReportInfor> SanPhamGetCauHinhByIdSanPham(string idSanPham,string thongTin)
        {
            return NoteReportDAO.Instance.SanPhamGetCauHinhByIdSP(idSanPham,thongTin);
        }
        public List<NoteSanPhamReportInfor> SanPhamGetTenByIdSanPham(string idSanPham)
        {
            return NoteReportDAO.Instance.SanPhamGetTenByIdSP(idSanPham);
        }
        public List<NoteSanPhamReportInfor> SanPhamGetCauHinhA7ByIdSanPham(string idSanPham)
        {
            return NoteReportDAO.Instance.SanPhamGetCauHinhA7ByIdSP(idSanPham);
        }
        public List<TestHoaDonGTGTInfo> SanPhamGetByIdSanPham(string idSanPham)
        {
            return NoteReportDAO.Instance.SanPhamGetByIdSP(idSanPham);
        }
        public void UpdateCauHinhSanPham(string idSanPham,int sTT, string cauHinh)
        {
            NoteReportDAO.Instance.UpdateCauHinhSanPham(idSanPham,sTT,cauHinh);
        }
        public void DeleteCauHinhSanPham(int idSanPham)
        {
            NoteReportDAO.Instance.DeleteCauHinhSanPham(idSanPham);
        }
        public void UpdateTenVietTatSanPham(int idSanPham,string tenVietTat)
        {
            NoteReportDAO.Instance.UpdateTenVietTatSanPham(idSanPham,tenVietTat);
        }
    }
}
