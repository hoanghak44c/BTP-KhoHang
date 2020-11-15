using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class tbl_ChungTu_ChiTiet_HanghoaDAO:BaseDAO
    {
        private static tbl_ChungTu_ChiTiet_HanghoaDAO instance;
        private tbl_ChungTu_ChiTiet_HanghoaDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            UseCaching = true;
        }
        public static tbl_ChungTu_ChiTiet_HanghoaDAO Instance
        {
            get
            {
                if (instance == null) instance = new tbl_ChungTu_ChiTiet_HanghoaDAO();
                return instance;
            }
        }
        //internal void Insert(ChungTu_ChiTiet_HangHoaInfo Info)
        //{
        //    ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaInsert, ParseToParams(Info));
        //}
        internal List<ChungTuChiTietMaVachInfo> ChiTietHangHoaGetByIdChungtu(int idChungTu)
        {
            return GetListCommand<ChungTuChiTietMaVachInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaGetByIdChungTu, idChungTu);
        }
        internal void Delete(int idChitietChungTu,int idChiTietHanghoa)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, idChitietChungTu, idChiTietHanghoa);
        }
    }
}
