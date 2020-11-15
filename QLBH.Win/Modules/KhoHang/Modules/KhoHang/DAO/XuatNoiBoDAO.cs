using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.HeThong.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class XuatNoiBoDAO : SystemDAO
    {
        private static XuatNoiBoDAO instance;
        private XuatNoiBoDAO()
        {
            //CRUDTableName = Declare.TableNamespace.tbl_ChungTu_ChiTiet;
            //UseCaching = true;
        }

        public static XuatNoiBoDAO Instance
        {
            get
            {
                if (instance == null) instance = new XuatNoiBoDAO();
                return instance;
            }
        }

        public void Update(ChungTuXuatNoiBoInfor chungTuXuatNoiBoInfor)
        {
            ExecUpdateCommand(Declare.StoreProcedureNamespace.spChungTuXNBUpdate, chungTuXuatNoiBoInfor.IdChungTu,
                              chungTuXuatNoiBoInfor.SoChungTu,
                              chungTuXuatNoiBoInfor.IdKho,
                              chungTuXuatNoiBoInfor.IdNhanVien,
                              chungTuXuatNoiBoInfor.LoaiChungTu,
                              chungTuXuatNoiBoInfor.NgayLap,
                              chungTuXuatNoiBoInfor.TrangThai,
                              chungTuXuatNoiBoInfor.GhiChu,
                              chungTuXuatNoiBoInfor.DongBo,
                              chungTuXuatNoiBoInfor.IdPhongBan,
                              chungTuXuatNoiBoInfor.IdChiPhi,
                              chungTuXuatNoiBoInfor.IdNhaCC,
                              chungTuXuatNoiBoInfor.IdLyDo,
                              chungTuXuatNoiBoInfor.SoPO,
                              chungTuXuatNoiBoInfor.NgayNhapXuatKho,
                              chungTuXuatNoiBoInfor.SoRE);
        }
        public int Insert(ChungTuXuatNoiBoInfor chungTuXuatNoiBoInfor)
        {
            ExecInsertCommand(Declare.StoreProcedureNamespace.spChungTuXNBInsert, chungTuXuatNoiBoInfor.IdChungTu,
                           chungTuXuatNoiBoInfor.SoChungTu,
                           chungTuXuatNoiBoInfor.IdKho,
                           chungTuXuatNoiBoInfor.IdNhanVien,
                           chungTuXuatNoiBoInfor.LoaiChungTu,
                           chungTuXuatNoiBoInfor.NgayLap,
                           chungTuXuatNoiBoInfor.TrangThai,
                           chungTuXuatNoiBoInfor.GhiChu,
                           chungTuXuatNoiBoInfor.DongBo,
                           chungTuXuatNoiBoInfor.IdPhongBan,
                           chungTuXuatNoiBoInfor.IdChiPhi,
                           chungTuXuatNoiBoInfor.IdNhaCC,
                           chungTuXuatNoiBoInfor.IdLyDo,
                           chungTuXuatNoiBoInfor.SoPO,
                           chungTuXuatNoiBoInfor.NgayNhapXuatKho,
                           chungTuXuatNoiBoInfor.SoRE);
            return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
        }

        internal void Delete(int idChungTu)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteById, idChungTu);
        }
        public List<ChungTuXuatNoiBoInfor> GetListXuatNoiBo()
        {
            return GetListCommand<ChungTuXuatNoiBoInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXuatNoiBo,
                                                         Convert.ToInt32(TransactionType.XUAT_NOI_BO),Declare.IdKho);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuXuatNoiBoDetail(int idChungTu)
        {
            return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuXuatTieuHao, idChungTu);
        }
    }
}
