using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiDieuChuyenDAO : SystemDAO
    {
        private static DeNghiDieuChuyenDAO instance;
        private DeNghiDieuChuyenDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiDieuChuyenDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiDieuChuyenDAO();
                return instance;
            }
        }
        public List<DeNghiDieuChuyenInfor> GetListDeNghiDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public List<ChungTuDieuChuyenInfor> GetListDieuChuyenChiTietBySoChungTu(string soChungTu)
        {
            return GetListCommand<ChungTuDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuNhapXuatGetBySoChungTu, soChungTu);
        }

        [Obsolete("Hàm này không được dùng nữa.")]
        public int Insert(ChungTuDieuChuyenInfor chungTuDeNghiXuatDieuChuyenInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNDCInsert,
                           chungTuDeNghiXuatDieuChuyenInfor.SoChungTu,
                           chungTuDeNghiXuatDieuChuyenInfor.IdKho,
                           chungTuDeNghiXuatDieuChuyenInfor.IdNhanVien,
                           chungTuDeNghiXuatDieuChuyenInfor.LoaiChungTu,
                           chungTuDeNghiXuatDieuChuyenInfor.NgayLap,
                           chungTuDeNghiXuatDieuChuyenInfor.TrangThai,
                           chungTuDeNghiXuatDieuChuyenInfor.IdKhoDieuChuyen,
                           chungTuDeNghiXuatDieuChuyenInfor.GhiChu,
                           chungTuDeNghiXuatDieuChuyenInfor.IdNguoiUyNhiem,
                           chungTuDeNghiXuatDieuChuyenInfor.IdNguoiVC,
                           chungTuDeNghiXuatDieuChuyenInfor.IdNguoiKyDuyet,
                           chungTuDeNghiXuatDieuChuyenInfor.HoaDonDC,
                           chungTuDeNghiXuatDieuChuyenInfor.PhuongTien,
                           chungTuDeNghiXuatDieuChuyenInfor.TongTienHang);
            chungTuDeNghiXuatDieuChuyenInfor.IdChungTu = Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
            //chungTuDeNghiXuatDieuChuyenInfor.SoChungTu = Convert.ToString(Parameters["p_SoChungTu"].Value);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }
        public int InsertChiTietChungTu(DeNghiDieuChuyenInfor deNghiDieuChuyenInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHInsert,
                           deNghiDieuChuyenInfor.IdChungTuChiTiet,
                           deNghiDieuChuyenInfor.IdChungTu,
                           deNghiDieuChuyenInfor.IdSanPham,
                           deNghiDieuChuyenInfor.SoLuong,
                           deNghiDieuChuyenInfor.DonGia,
                           deNghiDieuChuyenInfor.Thanhtien);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public void Update(ChungTuDieuChuyenInfor chungTuDeNghiXuatDieuChuyenInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNDCUpdate,
                              chungTuDeNghiXuatDieuChuyenInfor.IdChungTu,
                              chungTuDeNghiXuatDieuChuyenInfor.SoChungTu,
                              chungTuDeNghiXuatDieuChuyenInfor.IdKho,
                              chungTuDeNghiXuatDieuChuyenInfor.IdNhanVien,
                              chungTuDeNghiXuatDieuChuyenInfor.LoaiChungTu,
                              chungTuDeNghiXuatDieuChuyenInfor.NgayLap,
                              chungTuDeNghiXuatDieuChuyenInfor.TrangThai,
                              chungTuDeNghiXuatDieuChuyenInfor.IdKhoDieuChuyen,
                              chungTuDeNghiXuatDieuChuyenInfor.GhiChu,
                              chungTuDeNghiXuatDieuChuyenInfor.HoaDonDC,
                              chungTuDeNghiXuatDieuChuyenInfor.PhuongTien,
                              chungTuDeNghiXuatDieuChuyenInfor.IdNguoiUyNhiem,
                              chungTuDeNghiXuatDieuChuyenInfor.IdNguoiVC,
                              chungTuDeNghiXuatDieuChuyenInfor.IdNguoiUyNhiem);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiDieuChuyenInfor deNghiDieuChuyenInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, deNghiDieuChuyenInfor.IdChungTuChiTiet);
        }

        //public List<ChungTuXuatTieuHaoInfor> GetListDeNghiXuatTieuHao()
        //{
        //    return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetByLoaiChungTu, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO), Declare.IdKho);
        //}

        public void UpdateChiTietChungTu(DeNghiDieuChuyenInfor deNghiDieuChuyenInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, deNghiDieuChuyenInfor.IdChungTuChiTiet,
                deNghiDieuChuyenInfor.IdChungTu,
                deNghiDieuChuyenInfor.IdSanPham,
                deNghiDieuChuyenInfor.SoLuong,
                deNghiDieuChuyenInfor.DonGia,
                deNghiDieuChuyenInfor.Thanhtien);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiXuatDieuChuyenDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }
        public List<BaoCao_ChiTietDCInfor> GetPhieuBCDieuChuyen(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietDCInfor>(Declare.StoreProcedureNamespace.spPhieuBaoCaoDieuChuyen, idChungTu);
        }
        public List<TonDauKyInfo> GetListHangTonKhoByIdSanPham(int idKho, int idSanPham)
        {
            return GetListCommand<TonDauKyInfo>(Declare.StoreProcedureNamespace.spHangTonKhoGetbyIdSP, idKho, idSanPham);
        }
        //Hạnh dùng cho phiếu đề nghị điều chuyển cùng trung tâm
        public DMKhoInfo GetIdTrungTamByIdKho(int idKho)
        {
            return GetObjectCommand<DMKhoInfo>(Declare.StoreProcedureNamespace.spGetIdTrungTamByIdKho, idKho);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuDieuChuyenInfor GetInforDNDCByIdChungTu(int idChungTu)
        {
            return GetObjectCommand<ChungTuDieuChuyenInfor>(Declare.StoreProcedureNamespace.sp_GetChungTuXuatDieuChuyenById, idChungTu);
        }
    }
}
