using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DotKiemKeDAO : BaseDAO
    {

        private static DotKiemKeDAO instance;

        private DotKiemKeDAO()
        {
            CRUDTableName = Declare.TableNamespace.DotKiemKe;
            UseCaching = true;
        }

        public static DotKiemKeDAO Instance
        {
            get
            {
                if (instance == null) instance = new DotKiemKeDAO();
                return instance;
            }
        }

        public List<DotKiemKeInfor> GetListAll(int kyKiemKe, int namKiemKe, string maDotKiemKe)
        {
            return GetListCommand<DotKiemKeInfor>(Declare.StoreProcedureNamespace.spDotKiemKeGetAll, Declare.IdTrungTam, kyKiemKe, namKiemKe, maDotKiemKe);
        }

        public List<DotKiemKeInfor> GetListByDate(DateTime ngayThucHien)
        {
            return GetListCommand<DotKiemKeInfor>(Declare.StoreProcedureNamespace.spDotKiemKeGetByDate, ngayThucHien);
        }

        public int Insert(DotKiemKeInfor info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeInsert, info.MaDotKiemKe, info.GhiChu, info.TrungTam, info.Kho, info.Nganh, Declare.UserName, info.TenMayTao, info.KyKiemKe);
            return Convert.ToInt32(Parameters["p_IdDotKiemKe"].Value.ToString());
        }
        /// <summary>
        /// Kết thúc đợt kiểm kê
        /// </summary>
        /// <param name="info"></param>
        public void Update(DotKiemKeInfor info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeUpdate2, info.IdDotKiemKe, info.NgayKetThuc, Declare.UserName, 0);
        }
        public List<DotKiemKeInfor> GetLookUpDKK()
        {
            return GetListCommand<DotKiemKeInfor>(Declare.StoreProcedureNamespace.spDKKGetAll, Declare.IdTrungTam);
        }
        public List<DotKiemKeInfor> GetLookUpDKKEnd()
        {
            return GetListCommand<DotKiemKeInfor>(Declare.StoreProcedureNamespace.spDKKGetEnd);
        }
        public DotKiemKeInfor GetListDotKiemKeById(int idDotKiemke)
        {
            return GetObjectCommand<DotKiemKeInfor>(Declare.StoreProcedureNamespace.spDKKGetById, idDotKiemke);
        }

        public bool CanBeFinished(int idDotKiemKe)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeCanBeFinished, idDotKiemKe);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) == 0;
        }
        /// <summary>
        /// Tổng hợp dữ liệu kiểm kê
        /// </summary>
        /// <param name="info"></param>
        public void Update2(DotKiemKeInfor info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeUpdate2, info.IdDotKiemKe, info.NgayKetThuc, Declare.UserName, 1);
        }

        public bool MaDotKiemKeUnique(string maDotKiemKe)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeMaUnique, maDotKiemKe);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) == 0;
        }

        public void ChotSoTon(DotKiemKeInfor info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeChotSoTon, info.TrungTam, info.Kho, info.Nganh, info.IdDotKiemKe, info.NgayBatDau, Declare.UserName);
        }

        public int UpdateThoiGianChotTon(DotKiemKeInfor info)
        {
            return ExecuteCommand(
                @"update tbl_dotkiemke t
		             set t.thoigianbatdau = :thoiGianBatDau, t.nguoisua = :nguoiSua
	             where t.iddotkiemke = :idDotKiemKe
                    and t.thoigianbatdau is null", info.NgayBatDau, Declare.UserName, info.IdDotKiemKe);
        }

        public bool DaChotSoTon(DotKiemKeInfor info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDotKiemKeDaChotSoTon, info.IdDotKiemKe);
            return Convert.ToInt32(Parameters["p_DaChotTon"].Value.ToString()) == 1;
        }
    }
}