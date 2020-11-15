using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class KiemKeDAO : SystemDAO
    {
        private static KiemKeDAO instance;
        private KiemKeDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static KiemKeDAO Instance
        {
            get
            {
                if (instance == null) instance = new KiemKeDAO();
                return instance;
            }
        }
        public int InsertSoPhieuKiemKe(KiemKeInfor kiemKeInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertSoPhieuKiemKe, kiemKeInfor.IdKiemKe,
                kiemKeInfor.SoPhieu);
            kiemKeInfor.IdKiemKe = Convert.ToInt32(Parameters["p_IdKiemKe"].Value.ToString());
            return Convert.ToInt32(Parameters["p_IdKiemKe"].Value.ToString());
        }
        public int InsertKiemKe(KiemKeInfor kiemKeInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertKiemKe, kiemKeInfor.IdKiemKe,
               kiemKeInfor.IdKho,
               kiemKeInfor.IdNhanVien,
               kiemKeInfor.NgayKiemKe,
               kiemKeInfor.SoPhieu,
               kiemKeInfor.TongTienHang,
               kiemKeInfor.GhiChu,
               kiemKeInfor.KhoKhach,
               kiemKeInfor.IdDotKiemKe,
               kiemKeInfor.TrangThai);
            kiemKeInfor.IdKiemKe = Convert.ToInt32(Parameters["p_IdKiemKe"].Value.ToString());
            return Convert.ToInt32(Parameters["p_IdKiemKe"].Value.ToString());
        }

        public int InsertKiemKeChiTiet(KiemKeChiTietInfor kiemKeChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertKiemKe_ChiTiet, kiemKeChiTietInfor.IdChiTiet,
                kiemKeChiTietInfor.IdKiemKe,
                kiemKeChiTietInfor.IdSanPham,
                kiemKeChiTietInfor.SoLuong,
                kiemKeChiTietInfor.NguoiTao,
                kiemKeChiTietInfor.IdKho);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public int InsertKiemKeChiTietHangHoa(KiemKeChiTietHangHoaInfor kiemKeChiTietHangHoaInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertKiemKe_ChiTietHangHoa, kiemKeChiTietHangHoaInfor.IdChiTietKiemKe,
                kiemKeChiTietHangHoaInfor.IdChiTietHangHoa,
                kiemKeChiTietHangHoaInfor.SoLuong,
                kiemKeChiTietHangHoaInfor.GhiChu,
                kiemKeChiTietHangHoaInfor.SoLuongSs,
                kiemKeChiTietHangHoaInfor.IdKho);
            return Convert.ToInt32(Parameters["p_IdChiTietKiemKe"].Value.ToString());
        }
        public void InsertKiemKeChiTietKhongMaVach(KiemKeChiTietKhongMaVachInfor kiemKeChiTietKhongMaVachInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertKiemKe_ChiTietKhongMaVach, kiemKeChiTietKhongMaVachInfor.IdChiTiet,
                kiemKeChiTietKhongMaVachInfor.IdKiemKe,
                kiemKeChiTietKhongMaVachInfor.IdSanPham,
                kiemKeChiTietKhongMaVachInfor.MaVach,
                kiemKeChiTietKhongMaVachInfor.SoLuong,
                kiemKeChiTietKhongMaVachInfor.NguoiTao,
                kiemKeChiTietKhongMaVachInfor.GhiChu,
                kiemKeChiTietKhongMaVachInfor.IdKho);
            //return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public void UpdateKiemKe(KiemKeInfor kiemKeInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateKiemKe, kiemKeInfor.IdKiemKe,
               kiemKeInfor.IdKho,
               kiemKeInfor.IdNhanVien,
               kiemKeInfor.NgayKiemKe,
               kiemKeInfor.SoPhieu,
               kiemKeInfor.TongTienHang,
               kiemKeInfor.GhiChu,
               kiemKeInfor.KhoKhach,
               kiemKeInfor.IdDotKiemKe,
               kiemKeInfor.TrangThai);
        }
        public void UpdateKiemKeChiTiet(KiemKeChiTietInfor kiemKeChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateKiemKe_ChiTiet, kiemKeChiTietInfor.IdChiTiet,
                              kiemKeChiTietInfor.IdKiemKe,
                              kiemKeChiTietInfor.IdSanPham,
                              kiemKeChiTietInfor.SoLuong,
                              kiemKeChiTietInfor.NguoiTao,
                              kiemKeChiTietInfor.IdKho);
        }
        public void UpdateKiemKeChiTietHangHoa(KiemKeChiTietHangHoaInfor kiemKeChiTietHangHoaInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateKiemKe_ChiTietHangHoa, kiemKeChiTietHangHoaInfor.IdChiTietKiemKe,
                kiemKeChiTietHangHoaInfor.IdChiTietHangHoa,
                kiemKeChiTietHangHoaInfor.SoLuong,
                kiemKeChiTietHangHoaInfor.GhiChu,
                kiemKeChiTietHangHoaInfor.SoLuongSs,
                kiemKeChiTietHangHoaInfor.IdKho);
        }
        public void UpdateKiemKeChiTietKhongMaVach(KiemKeChiTietKhongMaVachInfor kiemKeChiTietKhongMaVachInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateKiemKe_ChiTietKhongMaVach, kiemKeChiTietKhongMaVachInfor.IdChiTiet,
                kiemKeChiTietKhongMaVachInfor.IdKiemKe,
                kiemKeChiTietKhongMaVachInfor.IdSanPham,
                kiemKeChiTietKhongMaVachInfor.MaVach,
                kiemKeChiTietKhongMaVachInfor.SoLuong,
                kiemKeChiTietKhongMaVachInfor.NguoiTao,
                kiemKeChiTietKhongMaVachInfor.GhiChu,
                kiemKeChiTietKhongMaVachInfor.IdKho);
        }
        public List<KiemKeInfor> GetListKiemKe(int idKho)
        {
            return GetListCommand<KiemKeInfor>(Declare.StoreProcedureNamespace.spGetListKiemKe,idKho);
        }
        public List<KiemKeInfor> GetListKiemKe2()
        {
            return GetListCommand<KiemKeInfor>(Declare.StoreProcedureNamespace.spGetListKiemKe2, Declare.IdNhanVien);
        }
        public List<KiemKeChiTietHangHoaInfor> GetListChiTietKiemKeCo(int OidCo)
        {
            return GetListCommand<KiemKeChiTietHangHoaInfor>(Declare.StoreProcedureNamespace.spGetListChiTietKiemKeCo, OidCo);
        }
        public void InsertChiTietKiemKeBoSung(int Oid, int idkho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertChiTietKiemKeBoSung, Oid, idkho);
        }
        public void InsertChiTietHangHoaKiemKeBoSung(int Oid, int idchitietkiemke, int idkho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spInsertChiTietHangHoaKiemKeBoSung, Oid, idchitietkiemke, idkho);
        }
        public List<KiemKeChiTietKhongMaVachInfor> GetListChiTietKiemKeKhong(int OidKhong)
        {
            return GetListCommand<KiemKeChiTietKhongMaVachInfor>(Declare.StoreProcedureNamespace.spGetListChiTietKiemKeKhong, OidKhong);
        }
        public void Delete(int  idKiemKe)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDeleteKiemKe, idKiemKe);
        }
        public void Delete2(int idKiemKe)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDeleteKiemKe2, idKiemKe);
        }
        public List<ChungTu_ChiTietHangHoaKiemKeInfor> GetIdSanPhamByMaVach(string maVach, string maTrungTam, string maKho, string maNganh, int idDotKiemKe)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaKiemKeInfor>(Declare.StoreProcedureNamespace.spGetIdSanPhamByMaVach, maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
        }
        internal List<KiemKeInfor> Search(string sophieu)
        {
            return GetListCommand<KiemKeInfor>(Declare.StoreProcedureNamespace.spKiemKeSearch, sophieu);
        }
        public void UpdateTrangThaiKiemKe(int idKiemKe, int TrangThai)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateTrangThaiKiemKe, idKiemKe,TrangThai);
        }
        public void UpdateGhiChuKiemKe(int idKiemKe, string ghiChu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateGhiChuKiemKe, idKiemKe, ghiChu);
        }
        public bool CheckMaVach(string MaKho, int idSanPham, string MaVach,string maNganh, string maTrungTam, int idDotKiemKe)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spKiemKeChiTietCheckMaVach, MaKho, idSanPham, MaVach, maNganh, maTrungTam, idDotKiemKe);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) > 0 ;
        }
        public List<DMSanPhamInfoEx> GetLookUpSanPhamTrungMV(string maVach, string maTrungTam, string maKho, string maNganh, int idDotKiemKe)
        {
            return GetListCommand<DMSanPhamInfoEx>(Declare.StoreProcedureNamespace.spListSPTrungMV, maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
        }
        public ChungTu_ChiTietHangHoaKiemKeInfor GetSanPhamById_MaVach(int idsanpham,string maVach, string maTrungTam, string maKho, string maNganh, int idDotKiemKe)
        {
            return GetObjectCommand<ChungTu_ChiTietHangHoaKiemKeInfor>(Declare.StoreProcedureNamespace.spSanPhamById_MaVach, idsanpham, maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
        }
        public KiemKeInfor GetMaVachBySoPhieu(string soPhieu)
        {
            return GetObjectCommand<KiemKeInfor>(Declare.StoreProcedureNamespace.spTrangThaiBysoPhieu, soPhieu);
        }
        public List<BCKiemKeChungTuLienQuanTon> GetListKiemKeChungTuLienQuanTon(string maKho, string maSanPham, int idDotKiemKe)
        {
            return GetListCommand<BCKiemKeChungTuLienQuanTon>(Declare.StoreProcedureNamespace.spChungTuKiemKeLienQuanTon, maKho, maSanPham, idDotKiemKe);
        }
        public List<BCKiemKeChungTuLienQuanMaVach> GetListKiemKeChungTuLienQuanMaVach(string maKho, string maVach, int idDotKiemKe)
        {
            return GetListCommand<BCKiemKeChungTuLienQuanMaVach>(Declare.StoreProcedureNamespace.spChungTuKiemKeLienQuanMaVach, maKho, maVach, idDotKiemKe);
        }
        public void UpdateKiemKekhoKhach(int idKiemKe, int khoKhach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateKiemKeKhoKhach, idKiemKe, khoKhach);
        }
        public void DeleteRowKiemKeCoMaVach(int idChiTietKiemKe, int idSanPham,int idChitietHangHoa)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDeleteRowKiemKeCoMaVach, idChiTietKiemKe,idSanPham,idChitietHangHoa);
        }
        public void DeleteRowKiemKeKhongMaVach(int idChiTietKiemKe, int idSanPham, string maVach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDeleteRowKiemKeKhongMaVach, idChiTietKiemKe, idSanPham, maVach);
        }
        public List<InPhieuKiemKeInfor> GetBCPhieuKiemKe(int idKiemKe)
        {
            return GetListCommand<InPhieuKiemKeInfor>(Declare.StoreProcedureNamespace.spInPhieuKiemKe, idKiemKe);
        }

        public KiemKeInfor GetKiemKeInfoById(int idKiemKe)
        {
            return GetObjectCommand<KiemKeInfor>(
                @"select t1.idkiemke,
					 t1.sophieu,
					 t1.ngaykiemke,
					 t1.ghichu,
					 t1.khokhach,
					 t1.iddotkiemke,
					 t1.trangthai,
					 t2.tenkho,
					 t2.makho,
					 t1.idnhanvien,
					 dkk.madotkiemke,
					 t1.lockid,
					 t1.processid,
					 t1.lockmachine,
					 t1.lockaccount,
					 t1.sessionid,
					 t1.last_update_date as lastupdateddate
			        from Tbl_Kiemke t1
		         inner join tbl_dotkiemke dkk
				        on t1.iddotkiemke = dkk.iddotkiemke
			        left join Tbl_Dm_Kho t2
				        on t2.idkho = t1.idkho
		         where t1.idkiemke = :IdKiemKe", idKiemKe);
        }
    }
}
