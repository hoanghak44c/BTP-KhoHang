using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class XacNhanNhapThanhPhanDAO: SystemDAO
    {
        private static XacNhanNhapThanhPhanDAO instance;
        private XacNhanNhapThanhPhanDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static XacNhanNhapThanhPhanDAO Instance
        {
            get
            {
                if (instance == null) instance = new XacNhanNhapThanhPhanDAO();
                return instance;
            }
        }
        public void Insert(SanXuatNhapTachInfo SanXuatNhapTachInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatNhapTachInsert,
                           SanXuatNhapTachInfo.MaLenh,
                           SanXuatNhapTachInfo.OrgCode,
                           SanXuatNhapTachInfo.LoaiGiaoDich,
                           SanXuatNhapTachInfo.MaThanhPham,
                           SanXuatNhapTachInfo.SoLuongYC,
                           SanXuatNhapTachInfo.NguoiLap,
                           SanXuatNhapTachInfo.NgayGiaoDich,
                           SanXuatNhapTachInfo.TransactionID);
        }

        public void Update(SanXuatNhapTachInfo SanXuatNhapTachInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatNhapTachUpdate,
                           SanXuatNhapTachInfo.MaLenh,
                           SanXuatNhapTachInfo.OrgCode,
                           SanXuatNhapTachInfo.LoaiGiaoDich,
                           SanXuatNhapTachInfo.MaThanhPham,
                           SanXuatNhapTachInfo.SoLuongYC,
                           SanXuatNhapTachInfo.NguoiLap,
                           SanXuatNhapTachInfo.NgayGiaoDich,
                           SanXuatNhapTachInfo.TransactionID);
        }
        internal void Delete(string orgcode, int loainhaptach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatNhapTachDelete, orgcode, loainhaptach);
        }
        public DateTime GetMaxDate(string orgcode)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatNhapTachGetMaxDate, orgcode);

            if (Convert.IsDBNull(Parameters["p_NgayLap"].Value)) return DateTime.MinValue;

            DateTime result;

            if (DateTime.TryParse(Parameters["p_NgayLap"].Value.ToString(), out result))
            {
                return result;
            }
            return Convert.ToDateTime(null);
        }
        internal int Exist(string malenh,string mathanhpham,int transactionID)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatNhapTachExist, malenh,mathanhpham,transactionID);
            
            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
        public List<SanXuatNhapTachInfo> SanXuatNhapTachSelectAll(int loaigiadich, int loaichungtu, string orgcode,int trangthai)
        {
            return GetListCommand<SanXuatNhapTachInfo>(Declare.StoreProcedureNamespace.spSanXuatNhapTachSelectall,loaigiadich,loaichungtu, orgcode,trangthai,Declare.IdKho);
        }
        public SanXuatNhapTachInfo SanXuatNhapTachGetByMaVach(string mavach, string malenh)
        {
            return GetObjectCommand<SanXuatNhapTachInfo>(Declare.StoreProcedureNamespace.spSanXuatNhapTachGetByMaVach, mavach, Declare.IdKho, malenh);
        }
        public List<SanXuatNhapTachInfo> TmpSanXuatNhapTachSelectAll(string orgcode, int loaigiaodich)
        {
            return GetListCommand<SanXuatNhapTachInfo>(Declare.StoreProcedureNamespace.sptmpSanXuatNhapTachSelectall, orgcode, loaigiaodich);
        }
        public List<SanXuatNhapTachInfo> SanXuatNhapTachGetByMaLenh(string MaLenh, string MaThanhPham,string OrgCode,int transactionID)
        {
            return GetListCommand<SanXuatNhapTachInfo>(Declare.StoreProcedureNamespace.spSanXuatNhapTachGetByMaLenh, MaLenh, MaThanhPham,OrgCode,transactionID);
        }
        public List<ChungTuXuatNhapNccChiTietInfo> SanXuatNhapTachCTGetBySoChungTu(string sochungtu,int loaichungtu)
        {
            return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spSanXuatNhapTachCTGetBySoChungTu, sochungtu,loaichungtu);
        }
        public ChungTuXuatNhapNccChiTietInfo SanXuatNhapTachCheckMaVach(int loaichungtu, string mavach)
        {
            return GetObjectCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spSanXuatNhapTachCheckMaVach,loaichungtu,mavach);
        }

        public DMChungTuNhapInfo GetChungTuNhapThanhPhamBySoChungTuGoc(string soChungTu, int loaiChungTu)
        {
            return GetObjectCommand<DMChungTuNhapInfo>(Declare.StoreProcedureNamespace.spChungTuXacNhanNhapThanhPhamGetBySoChungTuGoc, soChungTu, loaiChungTu);
        }
    }
}
