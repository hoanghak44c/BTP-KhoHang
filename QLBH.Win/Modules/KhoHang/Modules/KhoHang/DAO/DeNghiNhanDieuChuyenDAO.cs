using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiNhanDieuChuyenDAO : SystemDAO
    {
        private static DeNghiNhanDieuChuyenDAO instance;
        private DeNghiNhanDieuChuyenDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiNhanDieuChuyenDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiNhanDieuChuyenDAO();
                return instance;
            }
        }
        public List<DeNghiNhanDieuChuyenInfor> GetListDeNghiNhanDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiNhanDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public List<ChungTuNhapDieuChuyenInfor> GetListDieuChuyenChiTietBySoChungTu(string soChungTu)
        {
            return GetListCommand<ChungTuNhapDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuNhapXuatGetBySoChungTu, soChungTu);
        }
        public int Insert(ChungTuNhapDieuChuyenInfor chungTuDeNghiNhanDieuChuyenInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuDNNDCInsert, chungTuDeNghiNhanDieuChuyenInfor.IdChungTu,
                           chungTuDeNghiNhanDieuChuyenInfor.SoChungTu,
                           chungTuDeNghiNhanDieuChuyenInfor.IdKho,
                           chungTuDeNghiNhanDieuChuyenInfor.IdNhanVien,
                           chungTuDeNghiNhanDieuChuyenInfor.LoaiChungTu,
                           chungTuDeNghiNhanDieuChuyenInfor.NgayLap,
                           chungTuDeNghiNhanDieuChuyenInfor.TrangThai,
                           chungTuDeNghiNhanDieuChuyenInfor.SoChungTuGoc,
                           chungTuDeNghiNhanDieuChuyenInfor.GhiChu,
                           chungTuDeNghiNhanDieuChuyenInfor.IdNguoiUyNhiem,
                           chungTuDeNghiNhanDieuChuyenInfor.IdNguoiVC,
                           chungTuDeNghiNhanDieuChuyenInfor.IdNguoiKyDuyet,
                           chungTuDeNghiNhanDieuChuyenInfor.HoaDonDC,
                           chungTuDeNghiNhanDieuChuyenInfor.PhuongTien);
            chungTuDeNghiNhanDieuChuyenInfor.IdChungTu = Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
            //chungTuDeNghiNhanDieuChuyenInfor.SoChungTu = Convert.ToString(Parameters["p_SoChungTu"].Value);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }
        public int InsertChiTietChungTu(DeNghiNhanDieuChuyenInfor deNghiNhanDieuChuyenInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHInsert,
                           deNghiNhanDieuChuyenInfor.IdChungTuChiTiet,
                           deNghiNhanDieuChuyenInfor.IdChungTu,
                           deNghiNhanDieuChuyenInfor.IdSanPham,
                           deNghiNhanDieuChuyenInfor.SoLuong,
                           deNghiNhanDieuChuyenInfor.DonGia,
                           deNghiNhanDieuChuyenInfor.Thanhtien);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public void Update(ChungTuNhapDieuChuyenInfor chungTuDeNghiNhanDieuChuyenInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNNDCUpdate, chungTuDeNghiNhanDieuChuyenInfor.IdChungTu,
                chungTuDeNghiNhanDieuChuyenInfor.SoChungTu,
                chungTuDeNghiNhanDieuChuyenInfor.IdKho,
                chungTuDeNghiNhanDieuChuyenInfor.IdNhanVien,
                chungTuDeNghiNhanDieuChuyenInfor.LoaiChungTu,
                chungTuDeNghiNhanDieuChuyenInfor.NgayLap,
                chungTuDeNghiNhanDieuChuyenInfor.TrangThai);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiNhanDieuChuyenInfor deNghiNhanDieuChuyenInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, deNghiNhanDieuChuyenInfor.IdChungTuChiTiet);
        }

        //public List<ChungTuXuatTieuHaoInfor> GetListDeNghiXuatTieuHao()
        //{
        //    return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetByLoaiChungTu, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO), Declare.IdKho);
        //}

        public void UpdateChiTietChungTu(DeNghiNhanDieuChuyenInfor chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, chiTietChungTu.IdChungTuChiTiet,
                chiTietChungTu.IdChungTu,
                chiTietChungTu.IdSanPham,
                chiTietChungTu.SoLuong,
                chiTietChungTu.DonGia,
                chiTietChungTu.Thanhtien);
        }
        public List<DeNghiNhanDieuChuyenInfor> GetListDNNhanDieuChuyenBySoCT(string SoCT)
        {
            return GetListCommand<DeNghiNhanDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectBySoCT, SoCT);
        }
        public ChungTuXuatDieuChuyenInfor GetListDNNDCBySoCT(string SoCT)
        {
            return GetObjectCommand<ChungTuXuatDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuSelectBySoChungTu, SoCT);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiNhanDieuChuyenDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }

        public ChungTuNhapDieuChuyenInfor GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return
                GetObjectCommand<ChungTuNhapDieuChuyenInfor>(
                    Declare.StoreProcedureNamespace.spChungTuNDCGetBySoChungTuGoc,
                    Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                    Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                    soChungTuXuat);
        }
        //Dùng cho báo cáo điều chuyển
        public ChungTuNhapDieuChuyenInfor GetInforDNNDCByIdChungTu(int idChungTu)
        {
            return GetObjectCommand<ChungTuNhapDieuChuyenInfor>(Declare.StoreProcedureNamespace.sp_GetInfoDNNDCByIdChungtu, idChungTu);
        }

        public bool ChungTuDaXuatHang(string sochungtugoc)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDaXuatHang, 
                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                sochungtugoc);
            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) > 0;
        }

        public string ChungTuDaXacNhanNhapKho(string sochungtugoc)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDaXacNhanNhapKho,
                           Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                           Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                           sochungtugoc);
            if (Parameters["p_SoChungtu"].Value == DBNull.Value || Parameters["p_SoChungtu"].Value.ToString() == "null") return String.Empty;
            return Parameters["p_SoChungtu"].Value.ToString();
        }

        public List<ChungTuNhapDieuChuyenInfo> GetListChungTuNhapDieuChuyen(string soChungTu, int trangThai)
        {
            //return
            //    GetListCommand<ChungTuNhapDieuChuyenInfo>(
            //        "select * from tbl_chungtu where loaichungtu = :loaichungtu and trangthai = :trangthai and ngayxuathang >= :ngayxuathang",
            //        21, 3, DateTime.Now.Date);

            return
                GetListCommand<ChungTuNhapDieuChuyenInfo>(
                    "select * from tbl_chungtu where sochungtu = :sochungtu or sochungtugoc = :sochungtu and trangthai = :trangthai", soChungTu, trangThai);

        }
    }
}
