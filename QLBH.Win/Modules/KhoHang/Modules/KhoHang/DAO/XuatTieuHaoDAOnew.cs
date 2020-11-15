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
    public class XuatTieuHaoDAOnew : SystemDAO
    {
        private static XuatTieuHaoDAOnew instance;
        private XuatTieuHaoDAOnew()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static XuatTieuHaoDAOnew Instance
        {
            get
            {
                if (instance == null) instance = new XuatTieuHaoDAOnew();
                return instance;
            }
        }

        public void Update(ChungTuXuatTieuHaoInfornew chungTuXuatTieuHaoInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuXTHUpdate, chungTuXuatTieuHaoInfor.IdChungTu,
                chungTuXuatTieuHaoInfor.SoChungTu,
                chungTuXuatTieuHaoInfor.IdKho,
                chungTuXuatTieuHaoInfor.IdNhanVienGiao,
                chungTuXuatTieuHaoInfor.LoaiChungTu,
                chungTuXuatTieuHaoInfor.NgayLap,
                chungTuXuatTieuHaoInfor.TrangThai);
        }
        public void UpdateCTCT(ChungTu_ChiTietInfonew info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, info.IdChungTuChiTiet,
                info.IdChungTu,
                info.IdSanPham,
                info.SoLuong,
                info.DonGia,
                info.ThanhTien);
        }
        public void UpdateCTHH(ChungTu_ChiTietHangHoaXTHInfo info)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHHXNBUpdate, info.IdChungTuChiTiet,
                info.IdChiTietHangHoa,
                info.SoLuong);
        }
        public int Insert(ChungTuXuatTieuHaoInfornew chungTuXuatTieuHaoInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNXTHInsert, chungTuXuatTieuHaoInfor.IdChungTu,
                              chungTuXuatTieuHaoInfor.SoChungTu,
                              chungTuXuatTieuHaoInfor.IdKho,
                              chungTuXuatTieuHaoInfor.IdNhanVienGiao,
                              chungTuXuatTieuHaoInfor.LoaiChungTu,
                              chungTuXuatTieuHaoInfor.NgayLap,
                              chungTuXuatTieuHaoInfor.TrangThai,
                              chungTuXuatTieuHaoInfor.IdPhongBan,
                              chungTuXuatTieuHaoInfor.IdChiPhi);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfonew chiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHNewInsert, chiTietInfo.IdChungTuChiTiet,
                           chiTietInfo.IdChungTu,
                           chiTietInfo.IdSanPham,
                           chiTietInfo.SoLuong,
                           chiTietInfo.DonGia,
                           chiTietInfo.ThanhTien,
                           chiTietInfo.IdChiPhi,
                           chiTietInfo.IdPhongBan);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }

        public List<ChungTu_ChiTietInfonew> GetListXuatTieuHaoChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietInfonew>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }

        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHDeleteByIdCT, idChungTu);
        }

        //todo: @HANHBD
        //việc thực hiện xóa trong trong bảng chứng từ chi tiết có thể dùng một store chung
        //vì giống nhau prototype hàm (idChungTuChiTiet, idChiTietHangHoa)
        internal void Delete(ChungTu_ChiTietInfonew infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDeleteByIdChungTu, infor.IdChungTuChiTiet);
        }

        //todo: @HANHBD (DONE) store này không xóa trong chứng từ chi tiết hàng hóa
        //việc thực hiện xóa trong trong bảng chứng từ chi tiết hàng hóa có thể dùng một store chung
        //vì giống nhau prototype hàm (idChungTuChiTiet, idChiTietHangHoa)
        internal void Delete(ChungTu_ChiTietHangHoaXTHInfo infor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, infor.IdChungTuChiTiet, infor.IdChiTietHangHoa);
        }
        //-------------------
        internal List<ChungTu_ChiTietHangHoaXTHInfo> ChiTietHangHoaGetByIdChungtu(int idChungTu)
        {
            return GetListCommand<ChungTu_ChiTietHangHoaXTHInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHGetbyIdCT, idChungTu);
        }

        internal void Delete(int idChitietChungTu,int idChiTietHanghoa)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHangHoaDelete, idChitietChungTu, idChiTietHanghoa);
        }
        internal void Insert(ChungTu_ChiTietHangHoaXTHInfo chungTuHangHoaChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietHHXTHInsert, chungTuHangHoaChiTietInfor.IdChungTuChiTiet, chungTuHangHoaChiTietInfor.IdChiTietHangHoa, chungTuHangHoaChiTietInfor.SoLuong);
        }

        public List<ChungTuXuatTieuHaoInfornew> GetListXuatTieuHao()
        {
            return GetListCommand<ChungTuXuatTieuHaoInfornew>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXuatTieuHao, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO), Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO));
        }

        /// <summary>
        /// Lấy nội dung in phiếu xuất tiêu hao
        /// </summary>
        /// <param name="idChungTu"></param>
        /// <returns></returns>
        public List<BaoCao_ChiTietInfor> GetPhieuXuatTieuHaoDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }
    }
}
