using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class SanXuatCTietLenhDAO : BaseDAO
    {
        private static SanXuatCTietLenhDAO instance;
        private SanXuatCTietLenhDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static SanXuatCTietLenhDAO Instance
        {
            get
            {
                if (instance == null) instance = new SanXuatCTietLenhDAO();
                return instance;
            }
        }
        public List<SanXuatCTietLenhInfo> GetListSanXuatByMaLenh(string MaLenh,string orgcode)
        {
            return GetListCommand<SanXuatCTietLenhInfo>(Declare.StoreProcedureNamespace.spSanXuatCTietLenhGetMaLenh, MaLenh,orgcode);
        }
        public void Insert(SanXuatCTietLenhInfo SanXuatCTietLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatCTietLenhInsert, SanXuatCTietLenhInfo.MaLenh,
                           SanXuatCTietLenhInfo.MaLinhKien,
                           SanXuatCTietLenhInfo.NgayCanXuat,
                           SanXuatCTietLenhInfo.OrgCode,
                           SanXuatCTietLenhInfo.SoLuongCanXuat,
                           SanXuatCTietLenhInfo.SoLuongDaXuat,
                           SanXuatCTietLenhInfo.SoLuongTrenTPham,
                           SanXuatCTietLenhInfo.KhoXuat);
        }
        public void Update(SanXuatCTietLenhInfo SanXuatCTietLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatCTietLenhUpdate, SanXuatCTietLenhInfo.MaLenh,
                           SanXuatCTietLenhInfo.MaLinhKien,
                           SanXuatCTietLenhInfo.NgayCanXuat,
                           SanXuatCTietLenhInfo.OrgCode,
                           SanXuatCTietLenhInfo.SoLuongCanXuat,
                           SanXuatCTietLenhInfo.SoLuongDaXuat,
                           SanXuatCTietLenhInfo.SoLuongTrenTPham,
                           SanXuatCTietLenhInfo.KhoXuat);
        }
        public void UpdateSL(SanXuatCTietLenhInfo SanXuatCTietLenhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatCTietLenhUpdateSL, SanXuatCTietLenhInfo.MaLenh, SanXuatCTietLenhInfo.MaLinhKien,
                           SanXuatCTietLenhInfo.SoLuongDaXuat);
        }
        public void Delete(string MaLenh,string trungtam)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spSanXuatCTietLenhDelete, MaLenh, trungtam);
        }
    }
}
