using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class XuatDieuChuyenDAO : SystemDAO
    {
        private static XuatDieuChuyenDAO instance;
        private XuatDieuChuyenDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static XuatDieuChuyenDAO Instance
        {
            get
            {
                if (instance == null) instance = new XuatDieuChuyenDAO();
                return instance;
            }
        }
        public void Update(ChungTuDieuChuyenInfor chungTuXuatDieuChuyenInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuXDCUpdate, chungTuXuatDieuChuyenInfor.IdChungTu,
                              chungTuXuatDieuChuyenInfor.SoChungTu,
                              chungTuXuatDieuChuyenInfor.IdKho,
                              chungTuXuatDieuChuyenInfor.IdNguoiNhapXuatKho,
                              chungTuXuatDieuChuyenInfor.LoaiChungTu,
                              chungTuXuatDieuChuyenInfor.NgayNhapXuatKho,
                              chungTuXuatDieuChuyenInfor.TrangThai,
                              chungTuXuatDieuChuyenInfor.GhiChu);
            //chungTuXuatDieuChuyenInfor.IdKhoDieuChuyen);
        }
        public void UpdateCTCT(ChungTu_ChiTietInfo info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, info.IdChungTuChiTiet,
                info.IdChungTu,
                info.IdSanPham,
                info.SoLuong,
                info.DonGia,
                info.ThanhTien);
        }
        public void UpdateCTHH(ChungTu_ChiTietHangHoaBaseInfo info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHHXNBUpdate, info.IdChungTuChiTiet,
                info.IdChiTietHangHoa,
                info.SoLuong);
        }
        public int Insert(ChungTuDieuChuyenInfor chungTuXuatDieuChuyenInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuXDCInsert, chungTuXuatDieuChuyenInfor.IdChungTu,
                           chungTuXuatDieuChuyenInfor.SoChungTu,
                           chungTuXuatDieuChuyenInfor.IdKho,
                           chungTuXuatDieuChuyenInfor.IdNguoiNhapXuatKho,
                           chungTuXuatDieuChuyenInfor.LoaiChungTu,
                           chungTuXuatDieuChuyenInfor.NgayNhapXuatKho,
                           chungTuXuatDieuChuyenInfor.TrangThai,
                           chungTuXuatDieuChuyenInfor.IdKhoDieuChuyen);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHInsert, chiTietInfo.IdChungTuChiTiet,
                           chiTietInfo.IdChungTu,
                           chiTietInfo.IdSanPham,
                           chiTietInfo.SoLuong,
                           chiTietInfo.DonGia,
                           chiTietInfo.ThanhTien);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public List<ChungTu_ChiTietInfo> GetListXuatDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHDeleteByIdCT, idChungTu);
        }

        internal void Delete(ChungTu_ChiTietInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDeleteByIdChungTu, infor.IdChungTuChiTiet);
        }

        internal void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, infor.IdChungTuChiTiet, infor.IdChiTietHangHoa);
        }

        internal List<ChungTu_ChiTietHangHoaBaseInfo> ChiTietHangHoaGetByIdChungtu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaBaseInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHGetbyIdCT, idChungTu);
        }

        internal void Delete(int idChitietChungTu, int idChiTietHanghoa)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, idChitietChungTu, idChiTietHanghoa);
        }

        internal void Insert(ChungTu_ChiTietHangHoaBaseInfo chungTuHangHoaChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHInsert, chungTuHangHoaChiTietInfor.IdChungTuChiTiet, chungTuHangHoaChiTietInfor.IdChiTietHangHoa, chungTuHangHoaChiTietInfor.SoLuong);
        }

        public ChungTuDieuChuyenInfor GetChungTuDieuChuyenInforBySoChungTu(string soChungTu)
        {
            return GetObjectCommand<ChungTuDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuGetBySoChungTu, soChungTu);
        }

        public List<ChungTuDieuChuyenInfor> GetListXuatDieuChuyen(string idKho)
        {
            return GetListCommand<ChungTuDieuChuyenInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXuatDieuChuyen,
                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN), Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),idKho);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatDieuChuyenDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuXuatNhanDetail, idChungTu);
        }
        public List<BCChiTietHangChuyenKhoInfo> GetBCChiTietChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtungay, DateTime nxdenngay)
        {
            return GetListCommand<BCChiTietHangChuyenKhoInfo>(Declare.StoreProcedureNamespace.sp_BC_ChiTietDieuChuyen,
                                                          trungtam, kho, clsUtils.DateValue(tuNgay), clsUtils.DateValue(denNgay), clsUtils.DateValue(nxtungay), clsUtils.DateValue(nxdenngay));
        }
        public List<BCTongHopHangChuyenKhoInfo> GetBCTongHopChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtungay, DateTime nxdenngay)
        {
            return GetListCommand<BCTongHopHangChuyenKhoInfo>(Declare.StoreProcedureNamespace.sp_BC_TongHopDieuChuyen,
                                                              trungtam, kho, clsUtils.DateValue(tuNgay),
                                                              clsUtils.DateValue(denNgay), clsUtils.DateValue(nxtungay),
                                                              clsUtils.DateValue(nxdenngay),
                                                              Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                                                              Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                                                              Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                                                              Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN));
        }

        public List<ChungTuDieuChuyenInfor> GetFillterDeNghiXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return GetListCommand<ChungTuDieuChuyenInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetFillterXuatDieuChuyen,
                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN), Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN), idKho, soGiaoDich, ngayThucHien, trangThai);
        }

        public List<ChungTuDieuChuyenInfor> GetFillterXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return GetListCommand<ChungTuDieuChuyenInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetFillterXuatDieuChuyen,
                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN), Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN), idKho, soGiaoDich, ngayThucHien, trangThai);
        }
    }
}
