using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BCDongBoPODAO : BaseDAO
    {

        private static BCDongBoPODAO instance;

        private BCDongBoPODAO()
        {
        }

        public static BCDongBoPODAO Instance
        {
            get
            {
                if (instance == null) instance = new BCDongBoPODAO();
                return instance;
            }
        }

        public List<LichSuNhapHangInfo> GetLichSuTraHang(string sOrg)
        {
            return GetListCommand<LichSuNhapHangInfo>(Declare.StoreProcedureNamespace.sp_BC_LichSuNhapHang, sOrg, 1);
        }

        public List<LichSuNhapHangInfo> GetLichSuNhapHang(string sOrg, string sSub, DateTime runningDate, int loaiGiaoDich)
        {
            var paras = new List<object>();
            var where = " where 1 = 1 ";

            if(!String.IsNullOrEmpty(sOrg))
            {
                where += "and inventoryorg = :inventoryOrg ";
                paras.Add(sOrg);
            }

            if(!String.IsNullOrEmpty(sSub))
            {
                where += "and inventorysub = :inventorySub ";
                paras.Add(sSub);                
            }

            where += "and ngaynhap >= to_date(:fromDate, 'dd/mm/rrrr') ";
            paras.Add(runningDate.ToString("dd/MM/yyyy"));
            
            where += "and ngaynhap < to_date(:toDate, 'dd/mm/rrrr') + 1 ";
            paras.Add(runningDate.ToString("dd/MM/yyyy"));

            where += "and loaigiaodich = :loaiGiaoDich ";
            paras.Add(loaiGiaoDich);

            return GetListCommand<LichSuNhapHangInfo>(
                @"select * from tbl_lichsu_nhaphang" + where, paras.ToArray());
        }

        public DateTime GetNextDateNhapHang(string maTrungTam, string maKho, DateTime runningDate, int loaiGiaoDich)
        {
            var paras = new List<object>();
            var where = " where 1 = 1 ";

            if (!String.IsNullOrEmpty(maTrungTam))
            {
                where += "and inventoryorg = :inventoryOrg ";
                paras.Add(maTrungTam);
            }

            if (!String.IsNullOrEmpty(maKho))
            {
                where += "and inventorysub = :inventorySub ";
                paras.Add(maKho);
            }

            where += "and ngaynhap < to_date(:runningDate, 'dd/mm/rrrr') ";
            paras.Add(runningDate.ToString("dd/MM/yyyy"));

            where += "and loaigiaodich = :loaiGiaoDich ";
            paras.Add(loaiGiaoDich);

            return GetObjectCommand<DateTime>(@"select max(ngaynhap) from tbl_lichsu_nhaphang" + where, paras.ToArray());
        }
    }
}