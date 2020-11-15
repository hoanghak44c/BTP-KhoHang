using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class KhoThongKeHangTonDAO : BaseDAO
    {

        private static KhoThongKeHangTonDAO instance;

        private KhoThongKeHangTonDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_HangTonKho;
            UseCaching = true;
        }

        public static KhoThongKeHangTonDAO Instance
        {
            get
            {
                if (instance == null) instance = new KhoThongKeHangTonDAO();
                return instance;
            }
        }

        public List<KhoThongKeHangTonInfo> GetListThongKeHangTonKho(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            return GetListCommand<KhoThongKeHangTonInfo>(Declare.StoreProcedureNamespace.spThongKeXuatNhapTon, idKho,
                                                         idTrungTam, fromDate, toDate);
        }

        public List<KhoThongKeHangTonInfo> GetListThongKeHangTonKho2(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate
            , int pageIndex, int pageSize, int userId)
        {
            return GetListCommand<KhoThongKeHangTonInfo>(Declare.StoreProcedureNamespace.spThongKeXuatNhapTon2, idKho,
                                                         idTrungTam, fromDate, toDate, pageIndex, pageSize, userId);
        }

        public List<KhoThongKeHangTonLichSuInfo> GetListThongKeHangTonLichSu(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate
    , int pageIndex, int pageSize, int userId)
        {
            return GetListCommand<KhoThongKeHangTonLichSuInfo>(Declare.StoreProcedureNamespace.spThongKeXuatNhapTonLichSu2, idKho,
                                                         idTrungTam, fromDate, toDate, pageIndex, pageSize, userId);
        }

        public List<KhoThongKeHangTonInfo> GetListThongKeHangTonKho3(string maKho, string maTrungTam, DateTime fromDate, DateTime toDate
    , int pageIndex, int pageSize, int userId)
        {
            return GetListCommand<KhoThongKeHangTonInfo>(Declare.StoreProcedureNamespace.spThongKeXuatNhapTon5, maKho,
                                                         maTrungTam, fromDate, toDate, pageIndex, pageSize, userId);
        }

        public List<KhoThongKeHangTonLichSuInfo> GetListThongKeHangTonLichSu3(string maKho, string maTrungTam, DateTime fromDate, DateTime toDate
, int pageIndex, int pageSize, int userId)
        {
            return GetListCommand<KhoThongKeHangTonLichSuInfo>(Declare.StoreProcedureNamespace.spThongKeXuatNhapTonLichSu5, maKho,
                                                         maTrungTam, fromDate, toDate, pageIndex, pageSize, userId);
        }

        public int LoadDataThongKeHangTonKho(int step, int idSanPham, int idKho, int idTrungTam, DateTime fromDate, DateTime toDate, int pageSize, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spThongKeXuatNhapTon3, step, idSanPham, idKho, idTrungTam, fromDate, toDate, pageSize, userId);
            if (Parameters["p_PageTotal"].Value == DBNull.Value) return 0;
            return Convert.ToInt32(Parameters["p_PageTotal"].Value.ToString());
        }

        public int LoadDataThongKeHangTonKho2(int step, string maSanPham, string maKho, string maTrungTam, DateTime fromDate, DateTime toDate, int pageSize, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spThongKeXuatNhapTon4, step, maSanPham, maKho, maTrungTam, fromDate, toDate, pageSize, userId);
            if (Parameters["p_PageTotal"].Value == DBNull.Value) return 0;
            return Convert.ToInt32(Parameters["p_PageTotal"].Value.ToString());
        }

        public int LoadDataThongKeHangTonLichSu(int step, string maSanPham, string maKho, string maTrungTam, DateTime fromDate, DateTime toDate, int pageSize, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spThongKeXuatNhapTonLichSu, step, maSanPham, maKho, maTrungTam, fromDate, toDate, pageSize, userId);
            if (Parameters["p_PageTotal"].Value == DBNull.Value) return 0;
            return Convert.ToInt32(Parameters["p_PageTotal"].Value.ToString());
        }

        public List<KhoThongKeHangTonInfo> GetListTonKho(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate, int userId)
        {
            return GetListCommand<KhoThongKeHangTonInfo>(Declare.StoreProcedureNamespace.spGetListTonKho, idKho,
                                                         idTrungTam, fromDate, toDate, userId);
        }

        public List<KhoThongKeTonMaVachInfo> GetListThongKeTonMaVach(int idTrungTam, int idKho, int idSanPham)
        {
            return GetListCommand<KhoThongKeTonMaVachInfo>(Declare.StoreProcedureNamespace.spThongKeTonMaVach, idTrungTam, idKho,
                                                         idSanPham);
        }

        public List<KhoThongKeChungTuInfo> GetListThongKeChungTuLienQuan(int idTrungTam, int idKho, int idSanPham)
        {
            return GetListCommand<KhoThongKeChungTuInfo>(Declare.StoreProcedureNamespace.spThongKeChungTuLienQuan, idTrungTam, idKho,
                                                         idSanPham);
        }

        public List<KhoThongKeChiTietHangTrungChuyenInfo> GetListThongKeChiTietHangTrungChuyen(int idTrungTam, int idKho, int idSanPham)
        {
            return GetListCommand<KhoThongKeChiTietHangTrungChuyenInfo>(Declare.StoreProcedureNamespace.spThongKeChiTietHangTrungChuyen, idTrungTam, idKho,
                                                         idSanPham);
        }

        public void DeleteData(int idKho, int idTrungTam)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDeleteCompleteData, idKho, idTrungTam);
        }

        public void TongHopTonDauKy(int idKho, int idTrungTam, DateTime fromDate, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTongHopTonDauKy, idKho, idTrungTam, fromDate, userId);
        }

        public void TongHopTonTheoThang(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTongHopTonTheoThang, idKho, idTrungTam, fromDate, toDate, userId);
        }

        public void TongHopTonTheoNgay(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTongHopTonTheoNgay, idKho, idTrungTam, fromDate, toDate, userId);
        }

        public void TongHopTonTheoNam(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTongHopTonTheoNam, idKho, idTrungTam, fromDate, toDate, userId);
        }

        public void TongHopTon(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate, int userId)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTongHopTon, idKho, idTrungTam, fromDate, toDate, userId);
        }

        public DateTime GetMinDate(TonInfoBase khoThongKeHangTonInfo)
        {
            return
                GetObjectCommand<DateTime>(
                    @"SELECT min(ct.ngaylap)
			    FROM tbl_chungtu ct
		     inner join tbl_chungtu_chitiet ctct
				    on ct.idchungtu = ctct.idchungtu
		     where ctct.idsanpham = :IdSanPham
			     and ct.idkho = :IdKho", khoThongKeHangTonInfo.IdSanPham, khoThongKeHangTonInfo.IdKho);
        }

        public DateTime GetMaxDate(TonInfoBase khoThongKeHangTonInfo)
        {
            return
                GetObjectCommand<DateTime>(
                    @"SELECT max(ct.ngaylap)
			    FROM tbl_chungtu ct
		     inner join tbl_chungtu_chitiet ctct
				    on ct.idchungtu = ctct.idchungtu
		     where ctct.idsanpham = :IdSanPham
			     and ct.idkho = :IdKho", khoThongKeHangTonInfo.IdSanPham, khoThongKeHangTonInfo.IdKho);
        }

        public DateTime GetNextDate(TonInfoBase khoThongKeHangTonInfo, DateTime runningDate)
        {
            return
                GetObjectCommand<DateTime>(
                    @"SELECT max(ct.ngaylap)
			    FROM tbl_chungtu ct
		     inner join tbl_chungtu_chitiet ctct
				    on ct.idchungtu = ctct.idchungtu
		     where ctct.idsanpham = :IdSanPham
			     and ct.idkho = :IdKho
                and ct.ngaylap < to_date(:runningDate, 'dd/mm/rrrr')", khoThongKeHangTonInfo.IdSanPham, khoThongKeHangTonInfo.IdKho, runningDate.ToString("dd/MM/yyyy"));
        }

        public int GetTongSoGiaoDich(TonInfoBase khoThongKeHangTonInfo)
        {
            return
                GetObjectCommand<int>(
                    @"SELECT count(*)
			    FROM tbl_chungtu ct
		     inner join tbl_chungtu_chitiet ctct
				    on ct.idchungtu = ctct.idchungtu
		     where ctct.idsanpham = :IdSanPham
			     and ct.idkho = :IdKho", khoThongKeHangTonInfo.IdSanPham, khoThongKeHangTonInfo.IdKho);
        }

        public List<KhoThongKeChungTuInfo> GetListThongKeChungTuLienQuan(int idTrungTam, int idKho, int idSanPham, DateTime runningDate)
        {
            return
                GetListCommand<KhoThongKeChungTuInfo>(
                    @"select ct.sochungtu,
			                 ct.idtrungtam,
			                 ct.idkho,
			                 ct.ngaylap,
			                 ct.ngayxuathang,
			                 ctct.idsanpham,
			                 ct.thoigiantao thoidiemgiaodich,
			                 ct.dongbo_orc,
			                 ct.sochungtugoc,
			                 sum(ctct.soluong) soluong, 
			                 tt.tentrungtam,
			                 kho.tenkho,
			                 dft.transname as loaichungtu,
			                 dft.description as trangthai,
			                 sp.masanpham,
			                 sp.tensanpham,
			                 tk.ton
	                from tbl_chungtu ct
                 inner join tbl_chungtu_chitiet ctct
		                on ctct.idchungtu = ct.idchungtu
                 inner join tbl_defined_transactions dft
		                on ct.loaichungtu = dft.transnum
	                    and ct.trangthai = dft.status
	                left join tbl_dm_kho kho
		                on ct.idkho = kho.idkho
	                left join tbl_dm_trungtam tt
		                on tt.idtrungtam = kho.idtrungtam
	                left join tbl_sanpham sp
		                on sp.idsanpham = ctct.idsanpham
	                left join tbl_the_kho tk
		                on tk.idsanpham = ctct.idsanpham
	                     and tk.sochungtu = ct.sochungtu
	                     and tk.idkho = ct.idkho
                 where ctct.idsanpham = :IdSanPham
	                 and ct.idkho = :IdKho
	                 and ct.ngaylap >= to_date(:fromDate, 'dd/mm/rrrr')
	                 and ct.ngaylap < to_date(:toDate, 'dd/mm/rrrr') + 1
                 group by ct.sochungtu,
			                 ct.idtrungtam,
			                 ct.idkho,
			                 ct.ngaylap,
			                 ct.ngayxuathang,
			                 ctct.idsanpham,
			                 ct.thoigiantao,
			                 ct.dongbo_orc,
			                 ct.sochungtugoc,
			                 tt.tentrungtam,
			                 kho.tenkho,
			                 dft.transname,
			                 dft.description,
			                 sp.masanpham,
			                 sp.tensanpham,
			                 tk.ton
                 order by ct.ngaylap desc",
                    idSanPham, idKho, runningDate.ToString("dd/MM/yyyy"), runningDate.ToString("dd/MM/yyyy"));
        }
    }
}