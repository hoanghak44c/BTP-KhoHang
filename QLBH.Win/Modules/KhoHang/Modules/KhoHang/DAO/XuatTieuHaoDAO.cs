using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class XuatTieuHaoDAO : SystemDAO
    {
        private static XuatTieuHaoDAO instance;
        private XuatTieuHaoDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static XuatTieuHaoDAO Instance
        {
            get
            {
                if (instance == null) instance = new XuatTieuHaoDAO();
                return instance;
            }
        }

        public void Update(ChungTuXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNXTHUpdate, chungTuXuatTieuHaoInfor.IdChungTu,
                chungTuXuatTieuHaoInfor.SoChungTu,
                chungTuXuatTieuHaoInfor.IdKho,
                chungTuXuatTieuHaoInfor.IdNhanVien,
                chungTuXuatTieuHaoInfor.LoaiChungTu,
                chungTuXuatTieuHaoInfor.NgayLap,
                chungTuXuatTieuHaoInfor.TrangThai,
                chungTuXuatTieuHaoInfor.IdPhongBan,
                chungTuXuatTieuHaoInfor.IdChiPhi);
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
        public int Insert(ChungTuXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNXTHInsert, chungTuXuatTieuHaoInfor.IdChungTu,
                              chungTuXuatTieuHaoInfor.SoChungTu,
                              chungTuXuatTieuHaoInfor.IdKho,
                              chungTuXuatTieuHaoInfor.IdNhanVien,
                              chungTuXuatTieuHaoInfor.LoaiChungTu,
                              chungTuXuatTieuHaoInfor.NgayLap,
                              chungTuXuatTieuHaoInfor.TrangThai,
                              chungTuXuatTieuHaoInfor.IdPhongBan,
                              chungTuXuatTieuHaoInfor.IdChiPhi);
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

        public List<ChungTu_ChiTietInfo> GetListXuatTieuHaoChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }

        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHDeleteByIdCT, idChungTu);
        }

        //todo: @HANHBD
        //việc thực hiện xóa trong trong bảng chứng từ chi tiết có thể dùng một store chung
        //vì giống nhau prototype hàm (idChungTuChiTiet, idChiTietHangHoa)
        internal void Delete(ChungTu_ChiTietInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDeleteByIdChungTu, infor.IdChungTuChiTiet);
        }

        //todo: @HANHBD (DONE) store này không xóa trong chứng từ chi tiết hàng hóa
        //việc thực hiện xóa trong trong bảng chứng từ chi tiết hàng hóa có thể dùng một store chung
        //vì giống nhau prototype hàm (idChungTuChiTiet, idChiTietHangHoa)
        internal void Delete(ChungTu_ChiTietHangHoaBaseInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, infor.IdChungTuChiTiet, infor.IdChiTietHangHoa);
        }

        internal List<ChungTu_ChiTietHangHoaBaseInfo> ChiTietHangHoaGetByIdChungtu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaBaseInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHGetbyIdCT, idChungTu);
        }

        internal void Delete(int idChitietChungTu,int idChiTietHanghoa)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, idChitietChungTu, idChiTietHanghoa);
        }
        internal void Insert(ChungTu_ChiTietHangHoaBaseInfo chungTuHangHoaChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHInsert, chungTuHangHoaChiTietInfor.IdChungTuChiTiet, chungTuHangHoaChiTietInfor.IdChiTietHangHoa, chungTuHangHoaChiTietInfor.SoLuong);
        }

        public List<ChungTuXuatTieuHaoInfor> GetListXuatTieuHao()
        {
            return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXuatTieuHao, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO), Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO), Declare.IdKho);
        }

        /// <summary>
        /// Lấy nội dung in phiếu xuất tiêu hao
        /// </summary>
        /// <param name="idChungTu"></param>
        /// <returns></returns>
        public List<BaoCao_ChiTietXTHInfor> GetDeNghiTieuHaoDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietXTHInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }
        /// <summary>
        /// Lấy nội dung in phiếu xuất tiêu hao
        /// </summary>
        /// <param name="idChungTu"></param>
        /// <returns></returns>
        public List<BaoCao_ChiTietXTHInfor> GetTieuHaoDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietXTHInfor>(Declare.StoreProcedureNamespace.spPhieuTieuHaoDeTail, idChungTu);
        }
        /// <summary>
        /// Báo cáo xuất tiêu hao
        /// </summary>
        /// <returns></returns>
        public List<BCChiTietXuatTieuHaoInfo> GetBCChiTietXuatTieuHao(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtuNgay, DateTime nxdenNgay)
        {
            return GetListCommand<BCChiTietXuatTieuHaoInfo>(Declare.StoreProcedureNamespace.sp_BC_ChiTietXuatTieuHao,
                                                          trungtam, kho, tuNgay, denNgay, nxtuNgay, nxdenNgay);
        }
        public List<BCChiTietXuatTieuHaoInfo> GetBCTongHopXuatTieuHao(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtuNgay, DateTime nxdenNgay)
        {
            return GetListCommand<BCChiTietXuatTieuHaoInfo>(Declare.StoreProcedureNamespace.sp_BC_TongHopXuatTieuHao,
                                                          trungtam, kho, tuNgay, denNgay, nxtuNgay, nxdenNgay);
        }
    }
}
