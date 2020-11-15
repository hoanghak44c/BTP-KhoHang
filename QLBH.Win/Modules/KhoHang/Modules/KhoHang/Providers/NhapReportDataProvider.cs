using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhapReportDataProvider
    {
        private static NhapReportDataProvider instance;
        public static NhapReportDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhapReportDataProvider();
                return instance;
            }
        }
        
        //public List<TongHopGiaoDichNhapHangReportInfo> GetTongHopGiaoDichNhapReport(DateTime tungay, DateTime denngay, string trungtam, string kho)
        //{
        //    return NhapReportDAO.Instance.GetTongHopGiaoDichNhapReport(tungay, denngay, trungtam, kho);
        //}

        public List<TongHopGiaoDichNhapHangReportInfo> GetTongHopGiaoDichNhapReport(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, int loaigiaodich)
        {
            return NhapReportDAO.Instance.GetTongHopGiaoDichNhapReport(lapTungay, lapDenngay, nxTungay, nxDenngay, nganh, trungtam, kho, loaigiaodich);
        }
        public List<ChiTietGiaoDichNhapHangReportInfo> GetChiTietGiaoDichNhapReport(DateTime lapTuNgay, DateTime lapDenngay, DateTime nxTuNgay, DateTime nxDenngay, string nganh, string trungtam, string kho, string sLoaiGiaoDich)
        {
            return NhapReportDAO.Instance.GetChiTietGiaoDichNhapReport(lapTuNgay, lapDenngay, nxTuNgay, nxDenngay, nganh, trungtam, kho, sLoaiGiaoDich);
        }

        public List<TongHopGiaoDichNhapHangReportInfo> GetTongHopGiaoDichXuatReport(DateTime tungay, DateTime denngay, string trungtam, string kho)
        {
            return NhapReportDAO.Instance.GetTongHopGiaoDichXuatReport(tungay, denngay, trungtam, kho);
        }
        
        public List<TongHopGiaoDichNhapHangReportInfo> GetDuLieuTongHopNhapXuatReportPNG(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string loaigiaodich, int pageIndex, int pageSize, int userId, string maSanPham)
        {
            return NhapReportDAO.Instance.GetDuLieuTongHopNhapXuatReportPNG(lapTungay, lapDenngay, nxTungay, nxDenngay, nganh, trungtam, kho, loaigiaodich, pageIndex, pageSize, userId, maSanPham);
        }

        public void XoaDuLieuTongHopNhapXuatReport(int userId)
        {
            NhapReportDAO.Instance.XoaDuLieuTongHopNhapXuatReport(userId);
        }

        public void XoaDuLieuTongHopNhapXuatReportPNG(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string loaigiaodich, int pageIndex, int pageSize, int userId, string maSanPham)
        {
            NhapReportDAO.Instance.XoaDuLieuTongHopNhapXuatReportPNG(lapTungay, lapDenngay, nxTungay, nxDenngay, nganh, trungtam, kho, loaigiaodich, pageIndex, pageSize, userId, maSanPham);
        }

        public void TongHopDuLieuNhapXuatReportPNG(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string loaigiaodich, ref int pageIndex, int pageSize, int userId, string maSanPham)
        {
            NhapReportDAO.Instance.TongHopDuLieuNhapXuatReportPNG(lapTungay, lapDenngay, nxTungay, nxDenngay, nganh, trungtam, kho, loaigiaodich, ref pageIndex, pageSize, userId, maSanPham);
        }

        public List<ChiTietGiaoDichNhapHangReportInfo> GetXuatReport(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, string trungtam, string kho)
        {
            return NhapReportDAO.Instance.GetXuatReport(tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<ChiTietGiaoDichNhapHangReportInfo> GetXuatReportPNG(DateTime tungay, DateTime denngay, string trungtam, string kho, int pageIndex, int pageSize)
        {
            return NhapReportDAO.Instance.GetXuatReportPNG(tungay, denngay, trungtam, kho, pageIndex, pageSize);
        }
        public List<MaVachSXReportInfo> GetMaVachSanXuat(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay)
        {
            return NhapReportDAO.Instance.GetMaVachSanXuat(tungay, denngay, trungtam, kho,NXtungay,NXdenngay);
        }
        public List<MaVachSXReportInfo> GetChiTietThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay,int loaichungtu)
        {
            return NhapReportDAO.Instance.GetChiTietThanhPham(tungay, denngay, trungtam, kho,NXtungay,NXdenngay,loaichungtu);
        }
        public List<MaVachSXReportInfo> GetChiTietTachThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay)
        {
            return NhapReportDAO.Instance.GetChiTietTachThanhPham(tungay, denngay, trungtam, kho,NXtungay,NXdenngay);
        }
        public List<MaVachSXReportInfo> GetChiTietLinhKien(DateTime tungay, DateTime denngay, int trungtam, int kho, int loaichungtu, DateTime NXtungay, DateTime NXdenngay)
        {
            return NhapReportDAO.Instance.GetChiTietLinhKien(tungay, denngay, trungtam, kho,loaichungtu,NXtungay,NXdenngay);
        }
        public List<BaoCaoNhapXuatPOChuaXuatInfo> GetNhapXuatPOChuaXuat(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, string trungtam, string kho)
        {
            return NhapReportDAO.Instance.GetNhapXuatPOChuaXuat(tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<BaoCaoNhapTPChuaXacNhanInfo> GetNhapTPChuaNhap(DateTime tungay, DateTime denngay, string trungtam, string kho)
        {
            return NhapReportDAO.Instance.GetNhapTPChuaNhap(tungay, denngay, trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetDanhSachNhapPO(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho, DateTime orctungay, DateTime orcdenngay)
        {
            return NhapReportDAO.Instance.GetDanhSachNhapPO(tungay, denngay, nxtungay, nxdenngay, trungtam, kho,orctungay,orcdenngay);
        }
        public List<NhapXuatNoiBoReportInfo> GetDanhSachNhapNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return NhapReportDAO.Instance.GetDanhSachNhapNoiBo(tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapXuatNoiBoReportInfo> GetDanhSachXuatNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return NhapReportDAO.Instance.GetDanhSachXuatNoiBo(tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetChiTietNhapNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return NhapReportDAO.Instance.GetChiTietNhapNoiBo(tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetChiTietXuatNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return NhapReportDAO.Instance.GetChiTietXuatNoiBo(tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetChiTietNhapPO(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho, DateTime orctungay, DateTime orcdenngay)
        {
            return NhapReportDAO.Instance.GetChiTietNhapPO(tungay, denngay, nxtungay, nxdenngay, trungtam, kho, orctungay, orcdenngay);
        }
        public List<NhapHangMuaReportInfo> GetLookUpXTH()
        {
            return NhapReportDAO.Instance.GetLookUpXTH();
        }
        public List<DeNghiXuatTieuHaoChiTietInfonew> GetLookUpCTXTH(int idchungtu)
        {
            return NhapReportDAO.Instance.GetCTLookUpXTH(idchungtu);
        }
        public List<MaVachSXReportInfo> GetTongHopThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay,int loaichungtu)
        {
            return NhapReportDAO.Instance.GetTongHopThanhPham(tungay, denngay, trungtam, kho,NXtungay,NXdenngay,loaichungtu);
        }
        public List<TongHopNhapXuatLKInfo> GetTongHopNhapXuatLK(DateTime tungay, DateTime denngay, int trungtam, int kho,DateTime XNtu,DateTime XNden)
        {
            return NhapReportDAO.Instance.GetTongHopNhapXuatLK(tungay, denngay, trungtam, kho,XNtu,XNden);
        }
        public List<TongHopNhapXuatLKInfo> GetTongHopNhapXuatDM(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return NhapReportDAO.Instance.GetTongHopNhapXuatDM(tungay, denngay, trungtam, kho, XNtu, XNden);
        }
        public List<TongHopNhapXuatLKInfo> GetTongHopNhapXuatCB(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return NhapReportDAO.Instance.GetTongHopNhapXuatCB(tungay, denngay, trungtam, kho, XNtu, XNden);
        }
        public List<TongHopNhapXuatLKInfo> GetChiTietNhapXuatLK(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return NhapReportDAO.Instance.GetChiTietNhapXuatLK(tungay, denngay, trungtam, kho,XNtu,XNden);
        }
        public List<TongHopNhapXuatLKInfo> GetChiTietNhapXuatDM(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return NhapReportDAO.Instance.GetChiTietNhapXuatDM(tungay, denngay, trungtam, kho, XNtu, XNden);
        }
        public List<TongHopNhapXuatLKInfo> GetChiTietNhapXuatCB(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return NhapReportDAO.Instance.GetChiTietNhapXuatCB(tungay, denngay, trungtam, kho, XNtu, XNden);
        }
        public List<MaVachSXReportInfo> GetTongHopTachThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay)
        {
            return NhapReportDAO.Instance.GetTongHopTachThanhPham(tungay, denngay, trungtam, kho,NXtungay,NXdenngay);
        }
        public List<MaVachSXReportInfo> GetTongHopLinhKien(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay,int loaichungtu)
        {
            return NhapReportDAO.Instance.GetTongHopLinhKien(tungay, denngay, trungtam, kho,NXtungay,NXdenngay,loaichungtu);
        }
        public List<LenhSXChuaNhapLKReportInfo> GetLenhSXChuaNhapLK(DateTime tungay, DateTime denngay, string trungtam)
        {
            return NhapReportDAO.Instance.GetLenhSXChuaNhapLK(tungay, denngay, trungtam);
        }
        public List<NhapXuatThanhPhamReportInfo> GetListChungTuNhapXuatThanhPham(int loaiGiaoDich, DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return NhapReportDAO.Instance.GetListChungTuNhapXuatThanhPham(loaiGiaoDich, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapXuatThanhPhamReportInfo> GetListChungTuNhapXuatThanhPhamChiTiet(int loaiGiaoDich, DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return NhapReportDAO.Instance.GetListChungTuNhapXuatThanhPhamChiTiet(loaiGiaoDich, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
    }
}
