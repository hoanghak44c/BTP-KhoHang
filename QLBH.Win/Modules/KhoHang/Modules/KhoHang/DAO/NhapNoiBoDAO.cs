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
    public class NhapNoiBoDAO : SystemDAO
    {
        private static NhapNoiBoDAO instance;
        private NhapNoiBoDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static NhapNoiBoDAO Instance
        {
            get
            {
                if (instance == null) instance = new NhapNoiBoDAO();
                return instance;
            }
        }
        public void Update(ChungTuNhapNoiBoInfor chungTuNhapNoiBoInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuNNBUpdate, chungTuNhapNoiBoInfor.IdChungTu,
                              chungTuNhapNoiBoInfor.SoChungTu,
                              chungTuNhapNoiBoInfor.IdKho,
                              chungTuNhapNoiBoInfor.IdNhanVien,
                              chungTuNhapNoiBoInfor.LoaiChungTu,
                              chungTuNhapNoiBoInfor.NgayLap,
                              chungTuNhapNoiBoInfor.TrangThai,
                              chungTuNhapNoiBoInfor.GhiChu,
                              chungTuNhapNoiBoInfor.DongBo,
                              chungTuNhapNoiBoInfor.IdPhongBan,
                              chungTuNhapNoiBoInfor.IdChiPhi,
                              chungTuNhapNoiBoInfor.IdNhaCC,
                              chungTuNhapNoiBoInfor.IdLyDo,
                              chungTuNhapNoiBoInfor.SoPO,
                              chungTuNhapNoiBoInfor.NgayNhapXuatKho,
                              chungTuNhapNoiBoInfor.SoRE); 
        }
        public int Insert(ChungTuNhapNoiBoInfor chungTuNhapNoiBoInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuNNBInsert, chungTuNhapNoiBoInfor.IdChungTu,
                              chungTuNhapNoiBoInfor.SoChungTu,
                              chungTuNhapNoiBoInfor.IdKho,
                              chungTuNhapNoiBoInfor.IdNhanVien,
                              chungTuNhapNoiBoInfor.LoaiChungTu,
                              chungTuNhapNoiBoInfor.NgayLap,
                              chungTuNhapNoiBoInfor.TrangThai,
                              chungTuNhapNoiBoInfor.GhiChu,
                              chungTuNhapNoiBoInfor.DongBo,
                              chungTuNhapNoiBoInfor.IdPhongBan,
                              chungTuNhapNoiBoInfor.IdChiPhi,
                              chungTuNhapNoiBoInfor.IdNhaCC,
                              chungTuNhapNoiBoInfor.IdLyDo,
                              chungTuNhapNoiBoInfor.SoPO,
                              chungTuNhapNoiBoInfor.NgayNhapXuatKho,
                              chungTuNhapNoiBoInfor.SoRE);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }
        
        public void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDelete, idChungTu);
        }
        public List<ChungTuNhapNoiBoInfor> GetListNhapNoiBo()
        {
            return GetListCommand<ChungTuNhapNoiBoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetListNhapNoiBo,
                                                         Convert.ToInt32(TransactionType.NHAP_NOIBO),Declare.IdKho);
        }
        //public ChungTu_ChiTietInfo GetSanPhamTrungMaVach(int idSanPham)
        //{
            //return GetObjectCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spSanPhamSelectTrungMaVach,idSanPham);
        //}
        public List<BaoCao_ChiTietInfor> GetPhieuNhapNoiBoDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuXuatTieuHao, idChungTu);
        }
        /// <summary>
        /// Hàm này dùng trong form ChungTu_ChiTietHangHoaBase ,check mã vạch đã có trong bảng tbl_HangHoa_ChiTiet chưa
        /// </summary>
        /// <param name="maVach"></param>
        /// <returns></returns>
        public List<BaoCao_ChiTietInfor> GetTrungMaVach(string maVach)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetTrungMaVach,
                                                       maVach);
        }
        public DMDoiTuongInfo GetIdDoiTuongByPO(string pO,string rE)
        {
            return GetObjectCommand<DMDoiTuongInfo>(Declare.StoreProcedureNamespace.spGetIdDoiTuongByPO, pO,rE);
        }

        public int GetIdPhieuNhapMuaLanCuoi(string soPo, string soRe, int idKho, int idSanPham)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spKhoIdPhieuNhapMuaCuoi, soPo, soRe, idKho, idSanPham);

            return Convert.ToInt32(Parameters["p_IdPhieuNhap"].Value.ToString());
        }
    }
}
