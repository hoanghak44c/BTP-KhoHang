using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class NhapReportDAO : SystemDAO
    {
        private static NhapReportDAO instance;
        private NhapReportDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static NhapReportDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhapReportDAO();
                return instance;
            }
        }
        
        public List<ChiTietGiaoDichNhapHangReportInfo> GetChiTietGiaoDichNhapReport(DateTime lapTungay,DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string sLoaiGiaoDich)
        {
            return
                GetListCommand<ChiTietGiaoDichNhapHangReportInfo>(
                    Declare.StoreProcedureNamespace.spChiTietGiaoDichNhapHangReport, lapTungay,
                    lapDenngay, nxTungay, nxDenngay, nganh,
                    trungtam, kho, sLoaiGiaoDich);
        }

        public List<ChiTietGiaoDichNhapHangReportInfo> GetXuatReport(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, string trungtam, string kho)
        {
            return GetListCommand<ChiTietGiaoDichNhapHangReportInfo>(Declare.StoreProcedureNamespace.spChiTietGiaoDichXuatHangReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<ChiTietGiaoDichNhapHangReportInfo> GetXuatReportPNG(DateTime tungay, DateTime denngay, string trungtam, string kho, int pageIndex, int pageSize)
        {
            return GetListCommand<ChiTietGiaoDichNhapHangReportInfo>(Declare.StoreProcedureNamespace.spChiTietGiaoDichXuatHangReportPNG, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, pageIndex, pageSize);
        }
        public List<MaVachSXReportInfo> GetMaVachSanXuat(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spMaVachSXReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay));
        }
        public List<MaVachSXReportInfo> GetChiTietThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay,int loaichungtu)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spChiTietThanhPhamReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay),loaichungtu);
        }
        public List<MaVachSXReportInfo> GetChiTietTachThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spChiTietTachThanhPhamReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay));
        }
        public List<MaVachSXReportInfo> GetChiTietLinhKien(DateTime tungay, DateTime denngay, int trungtam, int kho, int loaichugtu, DateTime NXtungay, DateTime NXdenngay)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spChiTietLinhKienReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, loaichugtu, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay));
        }
        public List<BaoCaoNhapXuatPOChuaXuatInfo> GetNhapXuatPOChuaXuat(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, string trungtam, string kho)
        {
            return GetListCommand<BaoCaoNhapXuatPOChuaXuatInfo>(Declare.StoreProcedureNamespace.spBaoCaoNhapXuatPOChuaXuat, Declare.UserId, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<BaoCaoNhapTPChuaXacNhanInfo> GetNhapTPChuaNhap(DateTime tungay, DateTime denngay, string trungtam, string kho)
        {
            return GetListCommand<BaoCaoNhapTPChuaXacNhanInfo>(Declare.StoreProcedureNamespace.spBaoCaoNhapTPChuaNhap, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetDanhSachNhapPO(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho, DateTime orctungay, DateTime orcdenngay)
        {
            return GetListCommand<NhapHangMuaReportInfo>(Declare.StoreProcedureNamespace.spDanhSachNhapPOReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho,orctungay,orcdenngay);
        }
        public List<NhapHangMuaReportInfo> GetChiTietNhapNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return GetListCommand<NhapHangMuaReportInfo>(Declare.StoreProcedureNamespace.spChiTietNhapNoiBoReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapXuatNoiBoReportInfo> GetDanhSachNhapNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return GetListCommand<NhapXuatNoiBoReportInfo>(Declare.StoreProcedureNamespace.spDanhSachNhapNoiBoReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapXuatNoiBoReportInfo> GetDanhSachXuatNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return GetListCommand<NhapXuatNoiBoReportInfo>(Declare.StoreProcedureNamespace.spDanhSachXuatNoiBoReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetChiTietXuatNoiBo(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return GetListCommand<NhapHangMuaReportInfo>(Declare.StoreProcedureNamespace.spChiTietXuatNoiBoReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapHangMuaReportInfo> GetChiTietNhapPO(DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho, DateTime orctungay, DateTime orcdenngay)
        {
            return GetListCommand<NhapHangMuaReportInfo>(Declare.StoreProcedureNamespace.spChiTietNhapPOReport, tungay, denngay, nxtungay, nxdenngay, trungtam, kho,orctungay,orcdenngay);
        }
        public List<NhapHangMuaReportInfo> GetLookUpXTH()
        {
            return GetListCommand<NhapHangMuaReportInfo>(Declare.StoreProcedureNamespace.spPXTHGetAll);
        }
        public List<DeNghiXuatTieuHaoChiTietInfonew> GetCTLookUpXTH(int idchungtu)
        {
            return GetListCommand<DeNghiXuatTieuHaoChiTietInfonew>(Declare.StoreProcedureNamespace.spPXTHctGetAll, idchungtu);
        }
        public List<MaVachSXReportInfo> GetTongHopThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay,int loaichungtu)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spTongHopThanhPhamReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay),loaichungtu);
        }
        public List<TongHopNhapXuatLKInfo> GetTongHopNhapXuatLK(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return GetListCommand<TongHopNhapXuatLKInfo>(Declare.StoreProcedureNamespace.spTongHopNhapXuatLK, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(XNtu), clsUtils.DateValue(XNden));
        }
        public List<TongHopNhapXuatLKInfo> GetTongHopNhapXuatDM(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return GetListCommand<TongHopNhapXuatLKInfo>(Declare.StoreProcedureNamespace.spTongHopNhapXuatDM, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(XNtu), clsUtils.DateValue(XNden));
        }
        public List<TongHopNhapXuatLKInfo> GetTongHopNhapXuatCB(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return GetListCommand<TongHopNhapXuatLKInfo>(Declare.StoreProcedureNamespace.spTongHopNhapXuatCB, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(XNtu), clsUtils.DateValue(XNden));
        }
        public List<TongHopNhapXuatLKInfo> GetChiTietNhapXuatLK(DateTime tungay, DateTime denngay, int trungtam, int kho,DateTime XNtu,DateTime XNden)
        {
            return GetListCommand<TongHopNhapXuatLKInfo>(Declare.StoreProcedureNamespace.spChiTietNhapXuatLK, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(XNtu), clsUtils.DateValue(XNden));
        }
        public List<TongHopNhapXuatLKInfo> GetChiTietNhapXuatDM(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return GetListCommand<TongHopNhapXuatLKInfo>(Declare.StoreProcedureNamespace.spChiTietNhapXuatDM, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(XNtu), clsUtils.DateValue(XNden));
        }
        public List<TongHopNhapXuatLKInfo> GetChiTietNhapXuatCB(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime XNtu, DateTime XNden)
        {
            return GetListCommand<TongHopNhapXuatLKInfo>(Declare.StoreProcedureNamespace.spChiTietNhapXuatCB, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(XNtu), clsUtils.DateValue(XNden));
        }
        public List<MaVachSXReportInfo> GetTongHopTachThanhPham(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spTongHopTachThanhPhamReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay));
        }
        public List<MaVachSXReportInfo> GetTongHopLinhKien(DateTime tungay, DateTime denngay, int trungtam, int kho, DateTime NXtungay, DateTime NXdenngay,int loaichungtu)
        {
            return GetListCommand<MaVachSXReportInfo>(Declare.StoreProcedureNamespace.spTongHopLinhKienReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho, clsUtils.DateValue(NXtungay), clsUtils.DateValue(NXdenngay),loaichungtu);
        }

        public List<LenhSXChuaNhapLKReportInfo> GetLenhSXChuaNhapLK(DateTime tungay, DateTime denngay, string trungtam)
        {
            return GetListCommand<LenhSXChuaNhapLKReportInfo>(Declare.StoreProcedureNamespace.spLenhSXChuaNhapLK, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam);
        }

        public List<TongHopGiaoDichNhapHangReportInfo> GetTongHopGiaoDichNhapReport(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, int loaigiaodich)
        {
            return
                GetListCommand<TongHopGiaoDichNhapHangReportInfo>(
                    Declare.StoreProcedureNamespace.spTongHopGiaoDichNhapHangReport, clsUtils.DateValue(lapTungay),
                    clsUtils.DateValue(lapDenngay), clsUtils.DateValue(nxTungay), clsUtils.DateValue(nxDenngay), nganh,
                    trungtam, kho, loaigiaodich);
        }

        public List<TongHopGiaoDichNhapHangReportInfo> GetTongHopGiaoDichXuatReport(DateTime tungay, DateTime denngay, string trungtam, string kho)
        {
            return GetListCommand<TongHopGiaoDichNhapHangReportInfo>(Declare.StoreProcedureNamespace.spTongHopGiaoDichXuatHangReport, clsUtils.DateValue(tungay), clsUtils.DateValue(denngay), trungtam, kho);
        }

        public List<TongHopGiaoDichNhapHangReportInfo> GetDuLieuTongHopNhapXuatReportPNG(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string loaigiaodich, int pageIndex, int pageSize, int userId, string maSanPham)
        {
            List<TongHopGiaoDichNhapHangReportInfo> result = GetListCommand<TongHopGiaoDichNhapHangReportInfo>(Declare.StoreProcedureNamespace.spGetDuLieuTongHopNhapXuatReportPNG, clsUtils.DateValue(lapTungay), clsUtils.DateValue(lapDenngay), clsUtils.DateValue(nxTungay), clsUtils.DateValue(nxDenngay), nganh, trungtam, kho, loaigiaodich, pageIndex, pageSize, userId, maSanPham);
            
            return result;
        }

        public void XoaDuLieuTongHopNhapXuatReport(int userId)
        {
            ExecuteCommand(@"DELETE tbl_tonghop_nhapxuat where userid = :userId", userId);
        }

        public void XoaDuLieuTongHopNhapXuatReportPNG(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string loaigiaodich, int pageIndex, int pageSize, int userId, string maSanPham)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spXoaDuLieuTongHopNhapXuatReportPNG, clsUtils.DateValue(lapTungay), clsUtils.DateValue(lapDenngay), clsUtils.DateValue(nxTungay), clsUtils.DateValue(nxDenngay), nganh, trungtam, kho, loaigiaodich, pageIndex, pageSize, userId, maSanPham);
        }

        public void TongHopDuLieuNhapXuatReportPNG(DateTime lapTungay, DateTime lapDenngay, DateTime nxTungay, DateTime nxDenngay, string nganh, string trungtam, string kho, string loaigiaodich, ref int pageIndex, int pageSize, int userId, string maSanPham)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTongHopDuLieuNhapXuatReportPNG, clsUtils.DateValue(lapTungay), clsUtils.DateValue(lapDenngay), clsUtils.DateValue(nxTungay), clsUtils.DateValue(nxDenngay), nganh, trungtam, kho, loaigiaodich, pageIndex, pageSize, userId, maSanPham);
            
            pageIndex = Convert.ToInt32(Parameters["p_PageIndex"].Value.ToString());
        }

        public List<NhapXuatThanhPhamReportInfo> GetListChungTuNhapXuatThanhPham(int loaiGiaoDich, DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return
                GetListCommand<NhapXuatThanhPhamReportInfo>(
                    Declare.StoreProcedureNamespace.spTongHopNhapXuatThanhPhamReport, loaiGiaoDich, tungay, denngay,
                    nxtungay, nxdenngay, trungtam, kho);
        }
        public List<NhapXuatThanhPhamReportInfo> GetListChungTuNhapXuatThanhPhamChiTiet(int loaiGiaoDich, DateTime tungay, DateTime denngay, DateTime nxtungay, DateTime nxdenngay, int trungtam, int kho)
        {
            return
                GetListCommand<NhapXuatThanhPhamReportInfo>(
                    Declare.StoreProcedureNamespace.spChiTietNhapXuatThanhPhamReport, loaiGiaoDich, tungay, denngay,
                    nxtungay, nxdenngay, trungtam, kho);
        }
    }
}
