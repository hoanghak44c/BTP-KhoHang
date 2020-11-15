using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiXuatTieuHaoDAO : SystemDAO
    {
        private static DeNghiXuatTieuHaoDAO instance;
        private DeNghiXuatTieuHaoDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiXuatTieuHaoDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiXuatTieuHaoDAO();
                return instance;
            }
        }

        public List<DeNghiXuatTieuHaoChiTietInfo> GetListDeNghiXuatTieuHaoChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiXuatTieuHaoChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public int Insert(ChungTuDeNghiXuatTieuHaoInfor chungTuDeNghiXuatTieuHaoInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNXTHInsert, chungTuDeNghiXuatTieuHaoInfor.IdChungTu,
                           chungTuDeNghiXuatTieuHaoInfor.SoChungTu,
                           chungTuDeNghiXuatTieuHaoInfor.IdKho,
                           chungTuDeNghiXuatTieuHaoInfor.IdNhanVien,
                           chungTuDeNghiXuatTieuHaoInfor.LoaiChungTu,
                           chungTuDeNghiXuatTieuHaoInfor.NgayLap,
                           chungTuDeNghiXuatTieuHaoInfor.TrangThai,
                           chungTuDeNghiXuatTieuHaoInfor.IdPhongBan,
                           chungTuDeNghiXuatTieuHaoInfor.IdChiPhi,
                           chungTuDeNghiXuatTieuHaoInfor.GhiChu);
            chungTuDeNghiXuatTieuHaoInfor.IdChungTu = Convert.ToInt32(Parameters["P_IDCHUNGTU"].Value.ToString());
            //chungTuDeNghiXuatTieuHaoInfor.SoChungTu = Convert.ToString(Parameters["P_SOCHUNGTU"].Value);
            return Convert.ToInt32(Parameters["P_IDCHUNGTU"].Value.ToString());
        }
        public int InsertChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo deNghiXuatTieuHaoChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHInsert,
                           deNghiXuatTieuHaoChiTietInfo.IdChungTuChiTiet,
                           deNghiXuatTieuHaoChiTietInfo.IdChungTu,
                           deNghiXuatTieuHaoChiTietInfo.IdSanPham,
                           deNghiXuatTieuHaoChiTietInfo.SoLuong,
                           deNghiXuatTieuHaoChiTietInfo.DonGia,
                           deNghiXuatTieuHaoChiTietInfo.Thanhtien);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public void Update(ChungTuDeNghiXuatTieuHaoInfor chungTuDeNghiXuatTieuHaoInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNXTHUpdate, chungTuDeNghiXuatTieuHaoInfor.IdChungTu,
                chungTuDeNghiXuatTieuHaoInfor.SoChungTu,
                chungTuDeNghiXuatTieuHaoInfor.IdKho,
                chungTuDeNghiXuatTieuHaoInfor.IdNhanVien,
                chungTuDeNghiXuatTieuHaoInfor.LoaiChungTu,
                chungTuDeNghiXuatTieuHaoInfor.NgayLap,
                chungTuDeNghiXuatTieuHaoInfor.TrangThai,
                chungTuDeNghiXuatTieuHaoInfor.IdPhongBan,
                chungTuDeNghiXuatTieuHaoInfor.IdChiPhi);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo deNghiXuatTieuHaoChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, deNghiXuatTieuHaoChiTietInfo.IdChungTuChiTiet);
        }

        public List<ChungTuDeNghiXuatTieuHaoInfor> GetListDeNghiXuatTieuHao()
        {
            return GetListCommand<ChungTuDeNghiXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXuatTieuHao, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO),Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO),Declare.IdKho);
        }

        public void UpdateChiTietChungTu(DeNghiXuatTieuHaoChiTietInfo chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, chiTietChungTu.IdChungTuChiTiet,
                           chiTietChungTu.IdChungTu,
                           chiTietChungTu.IdSanPham,
                           chiTietChungTu.SoLuong,
                           chiTietChungTu.DonGia,
                           chiTietChungTu.Thanhtien);
        }
        public List<BaoCao_ChiTietXTHInfor> GetInPhieuDeNghiXuatTieuHao(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietXTHInfor>(Declare.StoreProcedureNamespace.spInPhieuDNXuatTieuHao, idChungTu);
        }
    }
}
