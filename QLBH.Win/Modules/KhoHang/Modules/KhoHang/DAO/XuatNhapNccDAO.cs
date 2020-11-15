using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class XuatNhapNccDAO : SystemDAO
    {
        private static XuatNhapNccDAO instance;

        private XuatNhapNccDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu;
            UseCaching = true;
        }

        public static XuatNhapNccDAO Instance
        {
            get
            {
                if (instance == null) instance = new XuatNhapNccDAO();
                return instance;
            }
        }

        public List<tmp_XuatKhoNoiBoInfor> GetChungTuById(int id)
        {
            return GetListCommand<tmp_XuatKhoNoiBoInfor>(Declare.StoreProcedureNamespace.spChungTuGetById, id);
        }

        public List<tmp_NhapHang_UserChiTietInfo> GetChungTuBySoCtg(int soCtg)
        {
            return GetListCommand<tmp_NhapHang_UserChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuSelectBySoCTG, soCtg);
        }

        internal int Insert(ChungTuXuatNhapNccInfo dmChungTuInfo)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuInsert,dmChungTuInfo.IdChungTu,
            dmChungTuInfo.SoChungTu,
            dmChungTuInfo.IdKho,
            dmChungTuInfo.IdNhanVien,
            dmChungTuInfo.LoaiChungTu,
            dmChungTuInfo.NgayLap,
            dmChungTuInfo.SoPO,
            dmChungTuInfo.SoPhieuNhap,
            dmChungTuInfo.TrangThai,
            dmChungTuInfo.IdDoiTuong,
            dmChungTuInfo.NgayXuatHang,
            dmChungTuInfo.NgayHenGiaoHang);

            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }

       internal void Update(ChungTuXuatNhapNccInfo chungTuXuatNhapInfo)
       {
           ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuUpdate, chungTuXuatNhapInfo.IdChungTu,
               chungTuXuatNhapInfo.SoChungTu,
               chungTuXuatNhapInfo.IdKho,
               chungTuXuatNhapInfo.IdNhanVien,
               chungTuXuatNhapInfo.LoaiChungTu,
               chungTuXuatNhapInfo.NgayLap,
               chungTuXuatNhapInfo.SoPO,
               chungTuXuatNhapInfo.SoPhieuNhap,
               chungTuXuatNhapInfo.TrangThai,
               chungTuXuatNhapInfo.IdDoiTuong,
               chungTuXuatNhapInfo.NgayXuatHang);

           //return Convert.ToInt32(Parameters["p_IdChungTu"].Value);
       }

       internal void UpdateTrangThai(int IdChungTu,int TrangThai)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuUpdateTrangThai, IdChungTu,
               TrangThai);

           //return Convert.ToInt32(Parameters["p_IdChungTu"].Value);
       }

       internal void Delete(int dmChungTuInfo)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDelete, dmChungTuInfo);

          //Convert.ToInt32(Parameters["p_SoPhieu"].Value);
       }

       internal DMChungTuNhapInfo GetOidFromSoPo(string po,int loaichungtu)
       {
           return GetObjectCommand<DMChungTuNhapInfo>(Declare.StoreProcedureNamespace.spChungTuSelectByPO, po,loaichungtu);
       }

       internal List<DMChungTuNhapInfo> Search(string sophieu)
       {
           return GetListCommand<DMChungTuNhapInfo>(Declare.StoreProcedureNamespace.spChungTuSearch, sophieu);
       }

       internal void UpdateTrangThai(int idChungTu,TrangThaiDuyet trangThai)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuUpdateTrangThai,idChungTu,Convert.ToInt32(trangThai));
       }

       internal int InsertChiTietChungTu(ChungTuXuatNhapNccChiTietInfo Info)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietNTPInsert, Info.IdChungTuChiTiet,
           Info.IdChungTu,
           Info.IdSanPham,
           Info.SoLuong,
           Info.DonGia,
           Info.Thanhtien,
           Info.DanhSachMaVach,
           Info.TransactionID);

           return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
       }

       internal List<ChungTuXuatNhapNccChiTietInfo> ChungTuChiTietGetByID(int idChungTu, int idSanPham)
       {
           return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetById, idChungTu, idSanPham);
       }

       internal List<ChungTuXuatNhapNccChiTietInfo> ChungTuChiTietGetByIdSanPham(string soChungTu, int idSanPham)
       {
           return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdSanPham, soChungTu, idSanPham);
       }

       internal List<ChungTuXuatNhapNccChiTietInfo> ChungTuChiTietGetByIdChungTu(int idChungTu)
       {
           return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdChungTu, idChungTu);
       }

       internal List<ChungTu_ChiTietHangHoaTraNCCInfo> ChungTuChiTietGetBySoPO(string PO)
       {
           return GetListCommand<ChungTu_ChiTietHangHoaTraNCCInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetBySoPO, PO);
       }

       internal List<ChungTuNhapNccChiTietHangHoaInfo> ChiTietHangHoaGetNhapNccByIdChungtu(int idChungTu)
       {
           return GetListCommand<ChungTuNhapNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaGetByIdChungTu, idChungTu);
       }
       internal List<ChungTuXuatNccChiTietHangHoaInfo> ChiTietHangHoaTraNccGetByIdChungtu(int idChungTu)
       {
           return GetListCommand<ChungTuXuatNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaGetByIdChungTu, idChungTu);
       }

       internal void DeleteChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, chiTietChungTu.IdChungTuChiTiet);
       }

       public List<tmp_NhapHang_UserChiTietInfo> GetListChungTuChiTietByIdChungTu(int idChungTu)
       {
           return GetListCommand<tmp_NhapHang_UserChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
       }

       public List<DeNghiXuatTieuHaoChiTietInfo> GetListDeNghiXuatTieuHaoChiTietByIdChungTu(int idChungTu)
       {
           return GetListCommand<DeNghiXuatTieuHaoChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
       }

       internal void InsertChungTuChiTietHangHoaNhapNcc(ChungTuNhapNccChiTietHangHoaInfo Info)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaNhapNCCInsert, Info.IdChungTuChiTiet,
               Info.IdChiTietHangHoa,
               Info.SoLuong);
       }
       internal void InsertChungTuChiTietHangHoaTraNcc(ChungTuXuatNccChiTietHangHoaInfo Info)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaInsert, Info.IdChungTuChiTiet,
               Info.IdChiTietHangHoa,
               Info.SoLuong);
       }

       internal List<ChungTuXuatNhapNccChiTietInfo> ChiTietGetByIdChungtu(int idChungTu)
       {
           return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetByIdChungTu, idChungTu);
       }

       internal void DeleteHangHoaChiTietNhapNcc(ChungTuNhapNccChiTietHangHoaInfo chiTietHanghoa)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, chiTietHanghoa.IdChungTuChiTiet, chiTietHanghoa.IdChiTietHangHoa);
       }
       internal void DeleteHangHoaChiTietTraNcc(ChungTuXuatNccChiTietHangHoaInfo chiTietHanghoa)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, chiTietHanghoa.IdChungTuChiTiet, chiTietHanghoa.IdChiTietHangHoa);
       }

       internal void DeleteHangHoaChiTiet(int idChitietChungTu, int idChiTietHanghoa)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, idChitietChungTu, idChiTietHanghoa);
       }

       public List<ChungTuXuatNhapNccChiTietInfo> GetNhapHangUserByIdInfo(string PO, string PhieuNhap, int LoaiGiaoDich, DateTime NgayNhap, int idChungTu)
       {
           return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spNhapHangUserGetById, PO, PhieuNhap, LoaiGiaoDich, Declare.IdKho, NgayNhap, idChungTu);
       }

       public List<ChungTuXuatNhapNccChiTietInfo> GetNhapHangUserByIdInfo(string PO, string PhieuNhap, int LoaiGiaoDich, int idKho)
       {
           return GetListCommand<ChungTuXuatNhapNccChiTietInfo>(Declare.StoreProcedureNamespace.spNhapHangUserGetById, PO, PhieuNhap, LoaiGiaoDich, idKho);
       }

       internal List<ChungTuXuatNccChiTietHangHoaInfo> ChungTuChiTietHHGetBySoPO(string PO,int loaichungtu)
       {
           return GetListCommand<ChungTuXuatNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietGetBySoPO, PO,loaichungtu);
       }

        public void UpdateChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chungTuXuatNhapNccChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietKhoUpdate,
                           chungTuXuatNhapNccChiTietInfo.IdChungTuChiTiet, 
                           chungTuXuatNhapNccChiTietInfo.IdChungTu,
                           chungTuXuatNhapNccChiTietInfo.IdSanPham,
                           chungTuXuatNhapNccChiTietInfo.SoLuong,
                           chungTuXuatNhapNccChiTietInfo.DonGia,
                           chungTuXuatNhapNccChiTietInfo.TransactionID,
                           chungTuXuatNhapNccChiTietInfo.DanhSachMaVach);
        }

        public void UpdateChiTietHangHoaNhapNcc(ChungTuNhapNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaUpdate,
                           chungTuNhapNccChiTietHangHoaInfo.IdChungTuChiTiet,
                           chungTuNhapNccChiTietHangHoaInfo.IdChiTietHangHoa,
                           chungTuNhapNccChiTietHangHoaInfo.SoLuong);
        }
        public void UpdateChiTietHangHoaTraNcc(ChungTuXuatNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaUpdate,
                           chungTuNhapNccChiTietHangHoaInfo.IdChungTuChiTiet,
                           chungTuNhapNccChiTietHangHoaInfo.IdChiTietHangHoa,
                           chungTuNhapNccChiTietHangHoaInfo.SoLuong);
        }

        public bool MaVachExist(string po, string maVach,int loaichungtu, int idKho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietMaVachExist, po, maVach, loaichungtu, idKho);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) == 1;
        }
        public bool CheckSoLuong(int idKho, int idSanPham,string MaVach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietCheckSoLuong, idKho, idSanPham, MaVach);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) == 1;
        }

    }
}
