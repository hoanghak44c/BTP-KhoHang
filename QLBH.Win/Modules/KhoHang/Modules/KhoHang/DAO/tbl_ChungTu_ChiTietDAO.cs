using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class tbl_ChungTu_ChiTietDAO:BaseDAO
    {
        private static tbl_ChungTu_ChiTietDAO instance;
        private tbl_ChungTu_ChiTietDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            UseCaching = true;
        }
        public static tbl_ChungTu_ChiTietDAO Instance
        {
            get
            {
                if (instance == null) instance = new tbl_ChungTu_ChiTietDAO();
                return instance;
            }
        }
        internal int Insert(ChungTu_ChiTietInfo Info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietInsert, ParseToParams(Info));

            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        internal List<ChungTu_ChiTietInfo> ChungTuChiTietGetByID(int idChungTu, int idSanPham)
        {
            return GetListCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetById, idChungTu, idSanPham);
        }
        internal List<ChungTu_ChiTietInfo> ChungTuChiTietGetByIdSanPham(string soChungTu, int idSanPham)
        {
            return GetListCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdSanPham, soChungTu, idSanPham);
        }
        internal List<ChungTu_ChiTietHangHoaBaseInfo> ChungTuChiTietGetByIdChungTu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaBaseInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdChungTu, idChungTu);
        }
        internal List<ChungTu_ChiTietHangHoaTraNCCInfo> ChungTuChiTietGetBySoPO(string PO)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaTraNCCInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetBySoPO, PO);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDeleteByIdChungTu, idChungTu);
        }

        public List<tmp_NhapHang_UserChiTietInfo> GetListChungTuChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<tmp_NhapHang_UserChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }

        public List<DeNghiXuatTieuHaoChiTietInfo> GetListDeNghiXuatTieuHaoChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiXuatTieuHaoChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }

    }
}
