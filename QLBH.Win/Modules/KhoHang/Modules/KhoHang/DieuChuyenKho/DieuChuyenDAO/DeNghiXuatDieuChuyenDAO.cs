using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class DeNghiXuatDieuChuyenDAO : SystemDAO
    {
        private static DeNghiXuatDieuChuyenDAO instance;
        private DeNghiXuatDieuChuyenDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static DeNghiXuatDieuChuyenDAO Instance
        {
            get
            {
                if (instance == null) instance = new DeNghiXuatDieuChuyenDAO();
                return instance;
            }
        }
        public List<DeNghiXuatDieuChuyenInfor> GetListDeNghiDieuChuyenChiTietByIdChungTu(int idChungTu)
        {
            return GetListCommand<DeNghiXuatDieuChuyenInfor>(Declare.StoreProcedureNamespace.spChungTuChiTietSelectByIdChungTu, idChungTu);
        }
        public int Insert(ChungTuXuatDieuChuyenInfo chungTuDeNghiXuatDieuChuyenInfor)
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
                           chungTuDeNghiXuatDieuChuyenInfor.TongTienHang,
                           chungTuDeNghiXuatDieuChuyenInfor.GiaoNhan,
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
        //Hạnh dùng cho phiếu đề nghị điều chuyển cùng trung tâm
        public DMKhoInfo GetIdTrungTamByIdKho(int idKho)
        {
            return GetObjectCommand<DMKhoInfo>(Declare.StoreProcedureNamespace.spGetIdTrungTamByIdKho, idKho);
        }
        
        public ChungTuXuatDieuChuyenInfo GetChungTuXuatDieuChuyenById(int idChungTu)
        {
            return GetObjectCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.sp_GetChungTuXuatDieuChuyenById, idChungTu);
        }

        public List<NhapHangMuaReportInfo> GetLookUpXDC()
        {
            return GetListCommand<NhapHangMuaReportInfo>(Declare.StoreProcedureNamespace.spPXDCGetAll);
        }
        public List<DeNghiNhapDieuChuyenChiTietInfor> GetCTLookUpXDC(int idchungtu)
        {
            return GetListCommand<DeNghiNhapDieuChuyenChiTietInfor>(Declare.StoreProcedureNamespace.spPXDCctGetAll, idchungtu);
        }
        /// <summary>
        /// Dùng cho xóa phiếu điều chuyển
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuXuatDieuChuyenInfo> GetListDieuChuyenCanXoa(string soChungTu)
        {
            return GetListCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuDieuChuyenCanXoa, soChungTu);
        }
        public void DeleteChungTuDieuChuyen(string soChungTu, int sign, int tinhTon)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spCtCtDelByIdCtCt, soChungTu,sign,tinhTon);
        }
        /// <summary>
        /// Hủy ĐC
        /// </summary>
        /// <param name="soChungTu"></param>
        /// <returns></returns>
        public List<ChungTuXuatDieuChuyenInfo> GetListDieuChuyenChiTietBySoChungTu(string soChungTu)
        {
            return GetListCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.spChungTuNhapXuatGetBySoChungTu, soChungTu);
        }

        public bool DangCoPhieuDieuChuyenChoNhanSerial(int idkho, int idsanpham)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spDangCoPhieuDieuChuyenChoNhanSerial, idkho, idsanpham);
            return Convert.ToInt32(Parameters["p_Count"].Value.ToString()) > 0;
        }

        public ChungTuXuatDieuChuyenInfo GetChungTuXuatDieuChuyenBySoChungTu(string soChungTu)
        {
            return GetObjectCommand<ChungTuXuatDieuChuyenInfo>(Declare.StoreProcedureNamespace.sp_GetChungTuXuatDieuChuyenBySoChungTu, soChungTu);
        }

        public int UpdateTrangThaiHuyChungTu(ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo)
        {
            return ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuDNDCUpdateTrangThaiHuy,
                  chungTuXuatDieuChuyenInfo.IdChungTu,
                  chungTuXuatDieuChuyenInfo.TrangThai,
                  chungTuXuatDieuChuyenInfo.ProcessId,
                  chungTuXuatDieuChuyenInfo.LockId,
                  chungTuXuatDieuChuyenInfo.LockAccount,
                  chungTuXuatDieuChuyenInfo.LockMachine);
        }

        public double GetUnitPrice(int idTrungTam, int idSanPham)
        {
            return
                GetObjectCommand<double>(
                    @"select dongiacovat
	                    from tbl_banggia_banhang bg
                     where bg.idsanpham = :idSanPham
	                     and bg.idtrungtam = :idTrungTam",
                    idSanPham, idTrungTam);
        }

        public DateTime GetMinDate(string idKho, string trangThai)
        {
            var lstParas = new List<object>();
            var sql =
                @"select min(ngaylap) from tbl_chungtu 
                        where loaichungtu in (12, 13) and ngaylap > sysdate - 31";

            if (!String.IsNullOrEmpty(idKho))
            {
                sql += " and instr(:idkho, ',' || idkho || ',') > 0";
                lstParas.Add(String.Format(",{0},", idKho));
            }

            if (trangThai == "Đã nhận")
            {
                sql += " and trangthai = 3";
            }
            else sql += " and trangthai <> 3";

            return
                GetObjectCommand<DateTime>(sql, lstParas.ToArray());
        }
    }
}
