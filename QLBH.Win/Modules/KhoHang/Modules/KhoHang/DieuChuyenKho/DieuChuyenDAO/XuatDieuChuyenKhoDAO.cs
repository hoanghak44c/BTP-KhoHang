using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class XuatDieuChuyenKhoDAO : SystemDAO
    {
        private static XuatDieuChuyenKhoDAO instance;
        private XuatDieuChuyenKhoDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static XuatDieuChuyenKhoDAO Instance
        {
            get
            {
                if (instance == null) instance = new XuatDieuChuyenKhoDAO();
                return instance;
            }
        }
        public void Update(ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor)
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
        public int Insert(ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor)
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

        public List<ChungTuXuatDieuChuyenInfo> GetListXuatDieuChuyen(string idKho)
        {
            return GetListCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXuatDieuChuyen,
                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN), Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),idKho);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatDieuChuyenDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
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

        public List<ChungTuXuatDieuChuyenInfo> GetFillterDeNghiXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return
                GetListCommand<ChungTuXuatDieuChuyenInfo>(
                    Declare.StoreProcedureNamespace.spKhoChungTuGetFillterXuatDieuChuyen,
                    Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                    Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN), idKho, soGiaoDich, ngayThucHien, trangThai,
                    Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN), -1);
        }

        public List<ChungTuXuatDieuChuyenInfo> GetFillterXuatDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai, int idTrungTamHachToan)
        {
            return
                GetListCommand<ChungTuXuatDieuChuyenInfo>(
                    Declare.StoreProcedureNamespace.spKhoChungTuGetFillterXuatDieuChuyen,
                    Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                    Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN), idKho, soGiaoDich, ngayThucHien, trangThai,
                    Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN), idTrungTamHachToan);
        }

        public void InsertTmp(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo, string soChungTu)
        {
            ExecuteCommand(@"insert into TBL_TMP_MAVACH_DIEUCHUYEN(dongia, idchitiethanghoa, idchungtuchitiet, idsanpham,
                masanpham, mavach, soluong, tendonvitinh, tensanpham, thanhtien, trangthai, trungmavach, sochungtu) 
                values(:dongia, :idchitiethanghoa, :idchungtuchitiet, :idsanpham, :masanpham, :mavach, :soluong, 
                :tendonvitinh, :tensanpham, :thanhtien, :trangthai, :trungmavach, :sochungtu)",
                chiTietHangHoaInfo.DonGia,
                chiTietHangHoaInfo.IdChiTietHangHoa, 
                chiTietHangHoaInfo.IdChungTuChiTiet,
                chiTietHangHoaInfo.IdSanPham,
                String.IsNullOrEmpty(chiTietHangHoaInfo.MaSanPham) ? String.Empty : chiTietHangHoaInfo.MaSanPham,
                chiTietHangHoaInfo.MaVach,
                chiTietHangHoaInfo.SoLuong,
                String.IsNullOrEmpty(chiTietHangHoaInfo.TenDonViTinh) ? String.Empty : chiTietHangHoaInfo.TenDonViTinh,
                String.IsNullOrEmpty(chiTietHangHoaInfo.TenSanPham) ? String.Empty : chiTietHangHoaInfo.TenSanPham,
                chiTietHangHoaInfo.ThanhTien,
                chiTietHangHoaInfo.TrangThai,
                chiTietHangHoaInfo.TrungMaVach,
                soChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdSanPham(int idSanPham, string soChungTu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaBaseInfo>(@"select dongia, idchitiethanghoa, 
                idchungtuchitiet, idsanpham, masanpham, mavach, soluong, tendonvitinh, tensanpham, 
                thanhtien, trangthai, trungmavach, sochungtu from TBL_TMP_MAVACH_DIEUCHUYEN
                where idsanpham = :idsanpham and sochungtu = :sochungtu", idSanPham, soChungTu);
        }

        public void DeleteTmp(string soChungTu)
        {
            ExecuteCommand(@"delete TBL_TMP_MAVACH_DIEUCHUYEN where sochungtu = :sochungtu", soChungTu);
        }

        public bool DangBaoHanh(string maVach, int idSanPham)
        {
            return GetObjectCommand<int>(@"select count(*) from tbl_bh_item it, tbl_bh_phieunhan pn
                where it.idphieunhan = pn.idphieunhan
                    and it.serial = :maVach
                    and it.idsanpham = :idSanPham
                    and pn.trangthaiphieu not in (4,8)", maVach, idSanPham) > 0;
        }
    }
}
