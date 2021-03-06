﻿using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiNhapTieuHaoDAO : SystemDAO
    {
        private static DeNghiNhapTieuHaoDAO instance;
        private DeNghiNhapTieuHaoDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiNhapTieuHaoDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiNhapTieuHaoDAO();
                return instance;
            }
        }

        public List<DeNghiXuatTieuHaoChiTietInfonew> GetListDeNghiXuatTieuHaoChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiXuatTieuHaoChiTietInfonew>(Declare.StoreProcedureNamespace.spChungTuChiTietNhanTHGetByIdChungTu, idChungTu);
        }

        public int Insert(ChungTuDeNghiXuatTieuHaoInfornew chungTuDeNghiXuatTieuHaoInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNNTHInsert, chungTuDeNghiXuatTieuHaoInfor.IdChungTu,
                           chungTuDeNghiXuatTieuHaoInfor.SoChungTu,
                           chungTuDeNghiXuatTieuHaoInfor.IdKho,
                           chungTuDeNghiXuatTieuHaoInfor.IdNhanVien,
                           chungTuDeNghiXuatTieuHaoInfor.LoaiChungTu,
                           chungTuDeNghiXuatTieuHaoInfor.NgayLap,
                           chungTuDeNghiXuatTieuHaoInfor.TrangThai,
                           chungTuDeNghiXuatTieuHaoInfor.IdTrungTam,
                           chungTuDeNghiXuatTieuHaoInfor.GhiChu,
                           chungTuDeNghiXuatTieuHaoInfor.SoChungTuGoc,
                           chungTuDeNghiXuatTieuHaoInfor.IdNguoiQuanLy);
            chungTuDeNghiXuatTieuHaoInfor.IdChungTu = Convert.ToInt32(Parameters["P_IDCHUNGTU"].Value.ToString());
            //chungTuDeNghiXuatTieuHaoInfor.SoChungTu = Convert.ToString(Parameters["P_SOCHUNGTU"].Value);
            return Convert.ToInt32(Parameters["P_IDCHUNGTU"].Value.ToString());
        }
        public int InsertChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew deNghiXuatTieuHaoChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHNewInsert,
                           deNghiXuatTieuHaoChiTietInfo.IdChungTuChiTiet,
                           deNghiXuatTieuHaoChiTietInfo.IdChungTu,
                           deNghiXuatTieuHaoChiTietInfo.IdSanPham,
                           deNghiXuatTieuHaoChiTietInfo.SoLuong,
                           deNghiXuatTieuHaoChiTietInfo.DonGia,
                           deNghiXuatTieuHaoChiTietInfo.Thanhtien,
                           deNghiXuatTieuHaoChiTietInfo.IdChiPhi,
                           deNghiXuatTieuHaoChiTietInfo.IdPhongBan,
                           deNghiXuatTieuHaoChiTietInfo.Nganh);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public void Update(ChungTuDeNghiXuatTieuHaoInfornew chungTuDeNghiXuatTieuHaoInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNNTHUpdate,
                              chungTuDeNghiXuatTieuHaoInfor.IdChungTu,
                              chungTuDeNghiXuatTieuHaoInfor.SoChungTu,
                              chungTuDeNghiXuatTieuHaoInfor.IdKho,
                              chungTuDeNghiXuatTieuHaoInfor.IdNhanVien,
                              chungTuDeNghiXuatTieuHaoInfor.LoaiChungTu,
                              chungTuDeNghiXuatTieuHaoInfor.NgayLap,
                              chungTuDeNghiXuatTieuHaoInfor.TrangThai,
                              chungTuDeNghiXuatTieuHaoInfor.IdTrungTam,
                              chungTuDeNghiXuatTieuHaoInfor.GhiChu);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew deNghiXuatTieuHaoChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, deNghiXuatTieuHaoChiTietInfo.IdChungTuChiTiet);
        }

        public List<ChungTuDeNghiXuatTieuHaoInfornew> GetListDeNghiXuatTieuHao()
        {
            return GetListCommand<ChungTuDeNghiXuatTieuHaoInfornew>(Declare.StoreProcedureNamespace.spKhoChungTuGetListNhapTieuHao, Convert.ToInt32(TransactionType.DE_NGHI_NHAP_TIEU_HAO), Convert.ToInt32(TransactionType.NHAP_TIEU_HAO), Declare.IdKho);
        }

        public void UpdateChiTietChungTu(DeNghiXuatTieuHaoChiTietInfonew chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, chiTietChungTu.IdChungTuChiTiet,
                           chiTietChungTu.IdChungTu,
                           chiTietChungTu.IdSanPham,
                           chiTietChungTu.SoLuong,
                           chiTietChungTu.DonGia,
                           chiTietChungTu.Thanhtien);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatTieuHaoDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }
        public List<DeNghiXuatTieuHaoChiTietInfonew> GetCTXTH(string sochungtu)
        {
            return GetListCommand<DeNghiXuatTieuHaoChiTietInfonew>(Declare.StoreProcedureNamespace.spctXTHGetAll, sochungtu, Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO));
        }
    }
}
