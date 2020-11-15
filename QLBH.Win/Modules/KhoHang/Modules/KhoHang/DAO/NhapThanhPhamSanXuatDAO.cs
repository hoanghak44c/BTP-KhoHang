using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class NhapThanhPhamSanXuatDAO : SystemDAO
    {
        private static NhapThanhPhamSanXuatDAO instance;

        private NhapThanhPhamSanXuatDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu;
            UseCaching = true;
        }

        public static NhapThanhPhamSanXuatDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhapThanhPhamSanXuatDAO();
                return instance;
            }
        }
        internal int InsertChiTietChungTu(ChungTuXuatNhapNccChiTietInfo Info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietNTPInsert, Info.IdChungTuChiTiet,
            Info.IdChungTu,
            Info.IdSanPham,
            Info.SoLuong,
            Info.DonGia,
            Info.Thanhtien,
            Info.DanhSachMaVach);

            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        internal int CheckMaVach(int idsanpham, string mavach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietCheck,idsanpham,mavach);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
        internal int CheckXacNhanNhapMaVachTP(int idChungTu, int idSanPham, string maVach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietCheckMaVachXacNhanNhapTP, idChungTu, idSanPham, maVach);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
        internal int CheckMaVachByKho(int idsanpham, string mavach,int SoLuong)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietCheckByKho, idsanpham, mavach,Declare.IdKho,SoLuong);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
        internal int CheckMaVachTP(int idsanpham, string mavach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietCheck, idsanpham, mavach);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
        internal int CheckMaVachNTP(int idsanpham, string mavach)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spHangHoaChiTietNTPCheck, idsanpham, mavach);

            return Convert.ToInt32(Parameters["p_Count"].Value.ToString());
        }
        public void UpdateChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chungTuXuatNhapNccChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietKhoUpdate,
                           chungTuXuatNhapNccChiTietInfo.IdChungTuChiTiet,
                           chungTuXuatNhapNccChiTietInfo.IdChungTu,
                           chungTuXuatNhapNccChiTietInfo.IdSanPham,
                           chungTuXuatNhapNccChiTietInfo.SoLuong,
                           chungTuXuatNhapNccChiTietInfo.DonGia,
                           chungTuXuatNhapNccChiTietInfo.Thanhtien,
                           chungTuXuatNhapNccChiTietInfo.DanhSachMaVach);
        }
    }
}
