using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiXuatDieuChuyenTGDAO : SystemDAO
    {
        private static DeNghiXuatDieuChuyenTGDAO instance;
        private DeNghiXuatDieuChuyenTGDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiXuatDieuChuyenTGDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiXuatDieuChuyenTGDAO();
                return instance;
            }
        }
        public List<DeNghiXuatDieuChuyenInfor> GetListDeNghiDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiXuatDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public int Insert(ChungTuXuatDieuChuyenInfo chungTuDeNghiXuatDieuChuyenInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNDCTGInsert, chungTuDeNghiXuatDieuChuyenInfor.IdChungTu,
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
                           chungTuDeNghiXuatDieuChuyenInfor.SoChungTuGoc,
                           chungTuDeNghiXuatDieuChuyenInfor.IdKhoNhanCuoi);
            chungTuDeNghiXuatDieuChuyenInfor.IdChungTu = Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
            //chungTuDeNghiXuatDieuChuyenInfor.SoChungTu = Convert.ToString(Parameters["p_SoChungTu"].Value);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }
        public int InsertChiTietChungTu(DeNghiXuatDieuChuyenInfor deNghiDieuChuyenInfor)
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
        public void Update(ChungTuXuatDieuChuyenInfo chungTuDeNghiXuatDieuChuyenInfor)
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
                              chungTuDeNghiXuatDieuChuyenInfor.IdNguoiKyDuyet, 
                              chungTuDeNghiXuatDieuChuyenInfor.GiaoNhan,
                              chungTuDeNghiXuatDieuChuyenInfor.IdKhoNhanCuoi);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiXuatDieuChuyenInfor deNghiDieuChuyenInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, deNghiDieuChuyenInfor.IdChungTuChiTiet);
        }

        //public List<ChungTuXuatTieuHaoInfor> GetListDeNghiXuatTieuHao()
        //{
        //    return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetByLoaiChungTu, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO), Declare.IdKho);
        //}

        public void UpdateChiTietChungTu(DeNghiXuatDieuChuyenInfor deNghiDieuChuyenInfor)
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
        public ChungTuXuatDieuChuyenInfo GetChungTuXuatDCTGBySoCTGoc(string soChungTuNhan)
        {
            return
                GetObjectCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuXDCTGGetBySoChungTuGoc,
                                                            soChungTuNhan);
        }
        //Hạnh dùng cho phiếu đề nghị điều chuyển cùng trung tâm
        public DMKhoInfo GetIdTrungTamByIdKho(int idKho)
        {
            return GetObjectCommand<DMKhoInfo>(Declare.StoreProcedureNamespace.spGetIdTrungTamByIdKho, idKho);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuXuatDieuChuyenInfo GetInforDNDCByIdChungTu(int idChungTu)
        {
            return GetObjectCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.sp_GetChungTuXuatDieuChuyenById, idChungTu);
        }
        /// <summary>
        /// Hủy điều chuyển
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuXuatDieuChuyenInfo> GetListDieuChuyenChiTietBySoChungTu(string soChungTu)
        {
            return GetListCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuNhapXuatGetBySoChungTu, soChungTu);
        }
    }
}
