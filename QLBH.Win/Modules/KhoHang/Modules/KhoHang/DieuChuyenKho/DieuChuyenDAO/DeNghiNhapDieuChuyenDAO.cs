using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiNhapDieuChuyenDAO : SystemDAO
    {
        private static DeNghiNhapDieuChuyenDAO instance;
        private DeNghiNhapDieuChuyenDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiNhapDieuChuyenDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiNhapDieuChuyenDAO();
                return instance;
            }
        }
        public List<DeNghiNhapDieuChuyenChiTietInfor> GetListDeNghiNhanDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiNhapDieuChuyenChiTietInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public int Insert(ChungTuNhapDieuChuyenInfo chungTuDeNghiNhanDieuChuyenInfor)
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
                           chungTuDeNghiNhanDieuChuyenInfor.PhuongTien,
                           chungTuDeNghiNhanDieuChuyenInfor.IdKhoNhanCuoi);
            chungTuDeNghiNhanDieuChuyenInfor.IdChungTu = Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
            //chungTuDeNghiNhanDieuChuyenInfor.SoChungTu = Convert.ToString(Parameters["p_SoChungTu"].Value);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }
        public int InsertChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor deNghiNhanDieuChuyenChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietDNXTHInsert,
                           deNghiNhanDieuChuyenChiTietInfor.IdChungTuChiTiet,
                           deNghiNhanDieuChuyenChiTietInfor.IdChungTu,
                           deNghiNhanDieuChuyenChiTietInfor.IdSanPham,
                           deNghiNhanDieuChuyenChiTietInfor.SoLuong,
                           deNghiNhanDieuChuyenChiTietInfor.DonGia,
                           deNghiNhanDieuChuyenChiTietInfor.Thanhtien);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value.ToString());
        }
        public void Update(ChungTuNhapDieuChuyenInfo chungTuDeNghiNhanDieuChuyenInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNNDCUpdate, chungTuDeNghiNhanDieuChuyenInfor.IdChungTu,
                chungTuDeNghiNhanDieuChuyenInfor.SoChungTu,
                chungTuDeNghiNhanDieuChuyenInfor.IdKho,
                chungTuDeNghiNhanDieuChuyenInfor.IdNhanVien,
                chungTuDeNghiNhanDieuChuyenInfor.LoaiChungTu,
                chungTuDeNghiNhanDieuChuyenInfor.NgayLap,
                chungTuDeNghiNhanDieuChuyenInfor.TrangThai,
                chungTuDeNghiNhanDieuChuyenInfor.GhiChu,
                chungTuDeNghiNhanDieuChuyenInfor.HoaDonDC,
                chungTuDeNghiNhanDieuChuyenInfor.PhuongTien,
                chungTuDeNghiNhanDieuChuyenInfor.IdKhoNhanCuoi);
        }
        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }

        public void DeleteChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor deNghiNhanDieuChuyenChiTietInfor)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, deNghiNhanDieuChuyenChiTietInfor.IdChungTuChiTiet);
        }

        //public List<ChungTuXuatTieuHaoInfor> GetListDeNghiXuatTieuHao()
        //{
        //    return GetListCommand<ChungTuXuatTieuHaoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetByLoaiChungTu, Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO), Declare.IdKho);
        //}

        public void UpdateChiTietChungTu(DeNghiNhapDieuChuyenChiTietInfor chiTietChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuChiTietXTHUpdate, chiTietChungTu.IdChungTuChiTiet,
                chiTietChungTu.IdChungTu,
                chiTietChungTu.IdSanPham,
                chiTietChungTu.SoLuong,
                chiTietChungTu.DonGia,
                chiTietChungTu.Thanhtien);
        }
        public List<DeNghiNhapDieuChuyenChiTietInfor> GetListDNNhanDieuChuyenBySoCT(string SoCT)
        {
            return GetListCommand<DeNghiNhapDieuChuyenChiTietInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectBySoCT, SoCT);
        }
        public ChungTuNhapDieuChuyenInfo GetListDNNDCBySoCT(string SoCT)
        {
            return GetObjectCommand<ChungTuNhapDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuSelectBySoChungTu, SoCT);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuDeNghiNhanDieuChuyenDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuDeNghiDeTail, idChungTu);
        }

        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCBySoCTGoc(string soChungTuXuat)
        {
            return
                GetObjectCommand<ChungTuNhapDieuChuyenInfo>(
                    Declare.StoreProcedureNamespace.spChungTuNDCGetBySoChungTuGoc,
                    Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                    Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                    soChungTuXuat);
        }
        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDCTGBySoCTGoc(string soChungTuXuat)
        {
            return
                GetObjectCommand<ChungTuNhapDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuNDCTGGetBySoChungTuGoc,
                                                            soChungTuXuat);
        }

        public ChungTuNhapDieuChuyenInfo GetChungTuNhanDieuChuyenById(int idChungTu)
        {
            return GetObjectCommand<ChungTuNhapDieuChuyenInfo>(Declare.StoreProcedureNamespace.sp_GetInfoDNNDCByIdChungtu, idChungTu);
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
        /// <summary>
        /// Hủy ĐC
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuNhapDieuChuyenInfo> GetListDieuChuyenChiTietBySoChungTu(string soChungTu)
        {
            return GetListCommand<ChungTuNhapDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuNhapXuatGetBySoChungTu, soChungTu);
        }

        public bool ChungTuDaCoPhieuNhan(string soChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spPhieuNhanDieuChuyenExisted, 
                Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                soChungTu);
            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) > 0;
        }
    }
}
