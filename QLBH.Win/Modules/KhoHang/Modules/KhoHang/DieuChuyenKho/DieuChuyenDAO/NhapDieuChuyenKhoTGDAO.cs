using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class NhapDieuChuyenKhoTGDAO : SystemDAO
    {
        private static NhapDieuChuyenKhoTGDAO instance;
        private NhapDieuChuyenKhoTGDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static NhapDieuChuyenKhoTGDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhapDieuChuyenKhoTGDAO();
                return instance;
            }
        }
        public void Update(ChungTuNhapDieuChuyenInfo chungTuNhanDieuChuyenInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuNDCTGUpdate, chungTuNhanDieuChuyenInfor.IdChungTu,
                chungTuNhanDieuChuyenInfor.SoChungTu,
                chungTuNhanDieuChuyenInfor.IdKho,
                chungTuNhanDieuChuyenInfor.IdNguoiNhapXuatKho,
                chungTuNhanDieuChuyenInfor.LoaiChungTu,
                chungTuNhanDieuChuyenInfor.NgayNhapXuatKho,
                chungTuNhanDieuChuyenInfor.TrangThai);
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
        public int Insert(ChungTuNhapDieuChuyenInfo chungTuNhanDieuChuyenInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuNDCInsert, chungTuNhanDieuChuyenInfor.IdChungTu,
                           chungTuNhanDieuChuyenInfor.SoChungTu,
                           chungTuNhanDieuChuyenInfor.IdKho,
                           chungTuNhanDieuChuyenInfor.IdNguoiNhapXuatKho,
                           chungTuNhanDieuChuyenInfor.LoaiChungTu,
                           chungTuNhanDieuChuyenInfor.NgayNhapXuatKho,
                           chungTuNhanDieuChuyenInfor.TrangThai);
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
        public List<ChungTu_ChiTietInfo> GetListNhanDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public List<ChungTu_ChiTietHangHoaBaseInfo>GetListNhanDieuChuyenBySoPhieu(string soPhieu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaBaseInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHHNDCGetbySoPhieu, soPhieu);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHDeleteByIdCT, idChungTu);
        }

        internal void Delete(ChungTu_ChiTietInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHDelete, infor.IdChungTuChiTiet);
        }

        internal void Delete_ChungTuChiTiet(ChungTu_ChiTietHangHoaBaseInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHDelete, infor.IdChungTuChiTiet, infor.IdChiTietHangHoa);
        }

        internal List<ChungTu_ChiTietHangHoaBaseInfo> ChiTietHangHoaGetByIdChungtu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaBaseInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHGetbyIdCT, idChungTu);
        }
        internal void DeleteChungTuChiTietHangHoa(int idChitietChungTu, int idChiTietHanghoa)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, idChitietChungTu, idChiTietHanghoa);
        }
        internal void Insert(ChungTu_ChiTietHangHoaBaseInfo chungTuHangHoaChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHInsert, chungTuHangHoaChiTietInfor.IdChungTuChiTiet, chungTuHangHoaChiTietInfor.IdChiTietHangHoa, chungTuHangHoaChiTietInfor.SoLuong);
        }
        public List<ChungTuNhapDieuChuyenInfo> GetListNhanDieuChuyen(string IdKho)
        {
            return GetListCommand<ChungTuNhapDieuChuyenInfo>(Declare.StoreProcedureNamespace.spKhoChungTuGetListNhanDieuChuyen,
                Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN), Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),IdKho);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuNhanDieuChuyenDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }
        public void InsertDieuChuyenHangBan(ChungTu_ChiTietHangHoaDCDHInfo chungTuChiTietHangHoaDcdhInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDieuChuyenHangBanInsert,
                              chungTuChiTietHangHoaDcdhInfo.IdChiTietHangHoa,
                              chungTuChiTietHangHoaDcdhInfo.SoChungTuDieuChuyen,
                              chungTuChiTietHangHoaDcdhInfo.SoChungTuBan,
                              chungTuChiTietHangHoaDcdhInfo.SoLuong);
        }
        public void DieuChuyenHangBanDelete (string soChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDieuChuyenHangBanDelete, soChungTu);
        }
        public ChungTuDeNghiNhanDieuChuyenInfor GetChungTuBySoCtg(string soCtg)
        {
            return GetObjectCommand<ChungTuDeNghiNhanDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuSelectBySoCTG, soCtg);
        }

        /// <summary>
        /// Trả về chứng từ nhận điều chuyển dựa trên số chứng từ xuất.
        /// </summary>
        /// <param name="soChungTuXuat"></param>
        /// <returns></returns>
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return
                GetObjectCommand<ChungTuNhapDieuChuyenInfo>(
                    Declare.StoreProcedureNamespace.spChungTuNDCGetBySoChungTuGoc,
                    Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                    Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                    soChungTuXuat);
        }
        /// <summary>
        /// Báo cáo chi tiết nhập chuyển kho
        /// </summary>
        /// <param name="trungtam"></param>
        /// <param name="kho"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<BCChiTietHangChuyenKhoInfo> GetBCChiTietNhanChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay)
        {
            return
                GetListCommand<BCChiTietHangChuyenKhoInfo>(Declare.StoreProcedureNamespace.sp_BC_ChiTietNhapDieuChuyen,
                                                           trungtam, kho, clsUtils.DateValue(tuNgay),
                                                           clsUtils.DateValue(denNgay),
                                                           Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                                                           Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                                                           Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                                                           Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN));
        }
        /// <summary>
        /// Báo cáo tổng hợp nhập chuyển kho
        /// </summary>
        /// <param name="trungtam"></param>
        /// <param name="kho"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<BCTongHopHangChuyenKhoInfo> GetBCTongHopNhanChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay)
        {
            return
                GetListCommand<BCTongHopHangChuyenKhoInfo>(Declare.StoreProcedureNamespace.sp_BC_TongHopNhapDieuChuyen,
                                                           trungtam, kho, clsUtils.DateValue(tuNgay),
                                                           clsUtils.DateValue(denNgay),
                                                           Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                                                           Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                                                           Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                                                           Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN));
        }
        /// <summary>
        /// Hủy nhận ĐC Trung Gian
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuNhapDieuChuyenInfo> GetListDieuChuyenChiTietBySoChungTu(string soChungTu)
        {
            return GetListCommand<ChungTuNhapDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuNhapXuatGetBySoChungTu, soChungTu);
        }
    }
}
