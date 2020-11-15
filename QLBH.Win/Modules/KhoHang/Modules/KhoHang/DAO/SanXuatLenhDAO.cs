using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Common;
using QLBH.Core.Data;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class SanXuatLenhDAO : BaseDAO
    {
        private static SanXuatLenhDAO instance;
        private SanXuatLenhDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static SanXuatLenhDAO Instance
        {
            get
            {
                if (instance == null) instance = new SanXuatLenhDAO();
                return instance;
            }
        }
        public List<SanXuatLenhInfo> GetListSanXuatByMaLenh(string MaLenh,int  idchungtu)
        {
            return GetListCommand<SanXuatLenhInfo>(Declare.StoreProcedureNamespace.spSanXuatLenhGetMaLenh, MaLenh,idchungtu);
        }
        public DateTime GetMaxDateSanXuatLenh(string matrungtam)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhGetMaxDate, matrungtam);
            if (Convert.IsDBNull(Parameters["p_NgayLap"].Value)) return DateTime.MinValue;
            
            DateTime result;
            if (DateTime.TryParse(Parameters["p_NgayLap"].Value.ToString(), out result))
            {
                return result;
            }
            return Convert.ToDateTime(null);
        }
        public int GetSoLuongSanXuatLenh(int idKho, int loaichungtu,string sochungtugoc,int trangthai)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhGetSoLuong, idKho, loaichungtu, sochungtugoc, trangthai);

            return Convert.ToInt32(Parameters["p_count"].Value.ToString());
        }
        public int GetSoLuongChungTu(int loaichungtu, string sochungtugoc, int trangthai,string soseri)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuGetSoLuong, loaichungtu, sochungtugoc, trangthai, soseri);

            return Convert.ToInt32(Parameters["p_count"].Value.ToString());
        }
        public int GetSoLuongXacNhanNhap(int loaichungtu, string sochungtugoc, int trangthai, string soseri)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spXacNhanXuatGetSoLuong, loaichungtu, sochungtugoc, trangthai, soseri);

            return Convert.ToInt32(Parameters["p_count"].Value.ToString());
        }
        public int GetSoLuongDNSanXuatLenh(int loaichungtu, string sochungtugoc,string matrungtam)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhGetSoLuongDN, loaichungtu, sochungtugoc,matrungtam);

            return Convert.ToInt32(Parameters["p_count"].Value.ToString());
        }
        public List<SanXuatLenhInfo> GetAllListSanXuat(string makho,string MaTrungTam,string LoaiMaLenh)
        {
            return GetListCommand<SanXuatLenhInfo>(Declare.StoreProcedureNamespace.spSanXuatLenhSelectAll, makho, MaTrungTam,LoaiMaLenh);
        }

        public List<SanXuatLenhInfo> GetRecentListSanXuat(string maLenh, string makho, string MaTrungTam, string LoaiMaLenh)
        {
            return GetListCommand<SanXuatLenhInfo>(Declare.StoreProcedureNamespace.spSanXuatLenhRecent, maLenh, makho, MaTrungTam, LoaiMaLenh);
        }

        public void Insert(SanXuatLenhInfo SanXuatLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhInsert, SanXuatLenhInfo.MaLenh,
                           SanXuatLenhInfo.MaThanhPham,
                           SanXuatLenhInfo.NgayLap,
                           SanXuatLenhInfo.NguoiLap,
                           SanXuatLenhInfo.OrgCode,
                           SanXuatLenhInfo.SoLuongTP,
                           SanXuatLenhInfo.Status,
                           SanXuatLenhInfo.TrangThai,
                           SanXuatLenhInfo.Loai_Ma_Lenh,
                           SanXuatLenhInfo.Description,
                           SanXuatLenhInfo.Last_update_date);
        }
        public void InsertHangHoaChiTiet(HangHoaChiTietInfo SanXuatLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietInsert, SanXuatLenhInfo.IdSanPham,
                           SanXuatLenhInfo.MaVach,
                           SanXuatLenhInfo.SoLuong,
                           SanXuatLenhInfo.IdKho);
        }

        public void Update1(SanXuatLenhInfo SanXuatLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhUpdate1, SanXuatLenhInfo.MaLenh,
                           SanXuatLenhInfo.MaThanhPham,
                           SanXuatLenhInfo.NgayLap,
                           SanXuatLenhInfo.NguoiLap,
                           SanXuatLenhInfo.OrgCode,
                           SanXuatLenhInfo.SoLuongTP,
                           SanXuatLenhInfo.SoLuongHT,
                           SanXuatLenhInfo.Status,
                           SanXuatLenhInfo.TrangThai,
                           SanXuatLenhInfo.Description,
                           SanXuatLenhInfo.Last_update_date);
        }

        public void Update(SanXuatLenhInfo SanXuatLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhUpdate, SanXuatLenhInfo.MaLenh,
                           SanXuatLenhInfo.MaThanhPham,
                           SanXuatLenhInfo.NgayLap,
                           SanXuatLenhInfo.NguoiLap,
                           SanXuatLenhInfo.OrgCode,
                           SanXuatLenhInfo.SoLuongTP,
                           SanXuatLenhInfo.Status,
                           SanXuatLenhInfo.TrangThai,
                           SanXuatLenhInfo.Description,
                           SanXuatLenhInfo.Last_update_date);
        }
        public void UpdateTrangThai(SanXuatLenhInfo SanXuatLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhUpdateTrangThai, SanXuatLenhInfo.MaLenh,
                           SanXuatLenhInfo.MaThanhPham,
                           SanXuatLenhInfo.TrangThai);
        }
        public void UpdateTrangThaiChungTu(int IdChungTu,int TrangThai)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhUpdateTrangThai,IdChungTu,TrangThai);
        }
        public int Exist(string MaLenh,string mathanhpham,string matrungtam)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatLenhExist,
                                                    MaLenh,mathanhpham,matrungtam);
            return Convert.ToInt32(Parameters["p_count"].Value.ToString());
        }
        public int CtietExist(string MaLenh, string matrungtam,string malinhkien)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatCtietLenhExist,
                                                    MaLenh, matrungtam,malinhkien);
            return Convert.ToInt32(Parameters["p_count"].Value.ToString());
        }
        internal void tmpSanXuatDelete(string OrgCode)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.sptmpSanXuatLenhDelete, OrgCode);
        }
        public List<SanXuatLenhInfo> GetAllListtmpSanXuat(string MaTrungTam,string loaimalenh)
        {
            return GetListCommand<SanXuatLenhInfo>(Declare.StoreProcedureNamespace.sptmpSanXuatLenhSelectall, MaTrungTam,loaimalenh);
        }
        public ChungTu_ChiTietInfo ChungTuCTGetByMaVach(int LoaiChungTu,string MaVach)
        {
            return GetObjectCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuCTGetByMaVach, LoaiChungTu, MaVach,Declare.IdKho);
        }
        public ChungTuNhapNccChiTietHangHoaInfo ChungTuGetSoChungTuGoc(int IdChungTu)
        {
            return GetObjectCommand<ChungTuNhapNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spChungTuGetSoChungTuGoc, IdChungTu);
        }
        public ChungTuNhapNccChiTietHangHoaInfo CheckMaVach(string MaVach)
        {
            return GetObjectCommand<ChungTuNhapNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spHangHoaChiTietCheckMaVach, MaVach);
        }
        internal void tmpSanXuatCTietDelete(string orgCode)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.sptmpSanXuatCTLenhDelete, orgCode);
        }
        public List<SanXuatCTietLenhInfo> GetAllListtmpCTSanXuat(string MaTrungTam)
        {
            return GetListCommand<SanXuatCTietLenhInfo>(Declare.StoreProcedureNamespace.sptmpSanXuatCTLenhSelectAll,MaTrungTam);
        }
        public List<ChungTuNhapNccChiTietHangHoaInfo> GetLinhKienSXByIDChungTu(int IdChungTu)
        {
            return GetListCommand<ChungTuNhapNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spLinhKienSXGetByIdChungTu, IdChungTu);
        }
    }
}
