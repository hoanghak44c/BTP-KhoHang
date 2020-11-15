using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.BanHang.Infors;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class NoteReportDAO : SystemDAO
    {
        private static NoteReportDAO instance;
        private NoteReportDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static NoteReportDAO Instance
        {
            get
            {
                if (instance == null) instance = new NoteReportDAO();
                return instance;
            }
        }
        public List<NoteSanPhamReportInfor> SanPhamGetHeaderByIdSP(string idSanPham,int idTrungTam)
        {
            return GetListCommand<NoteSanPhamReportInfor>(Declare.StoreProcedureNamespace.spSanPhamGetHeaderByIdSP, idSanPham,idTrungTam);
        }
        public List<NoteSanPhamReportInfor> SanPhamGetCauHinhByIdSP(string idSanPham,string thongTin)
        {
            return GetListCommand<NoteSanPhamReportInfor>(Declare.StoreProcedureNamespace.spSanPhamGetCauHinhByIdSP, idSanPham,thongTin);
        }
        public List<NoteSanPhamReportInfor> SanPhamGetTenByIdSP(string idSanPham)
        {
            return GetListCommand<NoteSanPhamReportInfor>(Declare.StoreProcedureNamespace.spSanPhamGetTenByIdSP, idSanPham);
        }
        public List<TestHoaDonGTGTInfo> SanPhamGetByIdSP(string idSanPham)
        {
            return GetListCommand<TestHoaDonGTGTInfo>(Declare.StoreProcedureNamespace.spSanPhamGetByIdSP, idSanPham);
        }
        public List<NoteSanPhamReportInfor> SanPhamGetCauHinhA7ByIdSP(string idSanPham)
        {
            return GetListCommand<NoteSanPhamReportInfor>(Declare.StoreProcedureNamespace.spSanPhamGetCauHinhA7ByIdSP, idSanPham);
        }
        public void UpdateCauHinhSanPham(string idSanPham, int sTT, string cauHinh)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateCauHinhSanPham,idSanPham,sTT,cauHinh);
        }
        public void DeleteCauHinhSanPham(int idSanPham)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDeleteCauHinhSanPham, idSanPham);
        }
        public void UpdateTenVietTatSanPham(int idSanPham,string tenVietTat)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spUpdateTenVietTatSanPham, idSanPham,tenVietTat);
        }
    }
}
