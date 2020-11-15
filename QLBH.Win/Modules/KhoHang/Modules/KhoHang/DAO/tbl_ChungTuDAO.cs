using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.DAO
{
   public class tbl_ChungTuDAO : BaseDAO
    {
       private static tbl_ChungTuDAO instance;
       private tbl_ChungTuDAO()
        {
            CRUDTableName = Declare.TableNamespace.tbl_ChungTu;
            UseCaching = true;
        }
       public static tbl_ChungTuDAO Instance
        {
            get
            {
                if (instance == null) instance = new tbl_ChungTuDAO();
                return instance;
            }
        }
       public List<tmp_XuatKhoNoiBoInfor> GetChungTuById(int id)
       {
           return GetListCommand<tmp_XuatKhoNoiBoInfor>(Declare.StoreProcedureNamespace.spChungTuGetById, id);
       }
       public List<DMChungTuPhieuNhapKhoInfo> GetChungTuByLoaiChungTu(int LoaiChungTu)
       {
           return GetListCommand<DMChungTuPhieuNhapKhoInfo>(Declare.StoreProcedureNamespace.spChungTuGetByLoaiChungTu, LoaiChungTu);
       }

       public List<DMChungTuNhapInfo> GetChungTuByMaVach(string mavach)
       {
           return GetListCommand<DMChungTuNhapInfo>(Declare.StoreProcedureNamespace.spChungTuGetByMaVach, mavach);
       }
       public List<ChungTuNhapNccChiTietHangHoaInfo> GetMaVachByChungTuGoc(string chungtugoc)
       {
           return GetListCommand<ChungTuNhapNccChiTietHangHoaInfo>(Declare.StoreProcedureNamespace.spMaVachGetByChungTuGoc, chungtugoc);
       }

       internal int Insert(DMChungTuNhapInfo dmChungTuInfo)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuInsert,ParseToParams(dmChungTuInfo));

           return Convert.ToInt32(Parameters["p_IdChungTu"].Value.ToString());
       }

       internal void Update(DMChungTuNhapInfo dmChungTuInfo)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuUpdate, ParseToParams(dmChungTuInfo));
       }
       internal void Delete(string dmChungTuInfo)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuDeleteBySoPhieu, dmChungTuInfo);

          //Convert.ToInt32(Parameters["p_SoPhieu"].Value);
       }
       
       internal DMChungTuNhapInfo GetOidFromSoPo(string po, string phieuNhap,int loaichungtu)
       {
           return GetObjectCommand<DMChungTuNhapInfo>(Declare.StoreProcedureNamespace.spChungTuSelectByPO, po, phieuNhap, loaichungtu);
       }

       internal ChungTuXuatNhapNccInfo GetChungTuNhapXuatNCCFromSoPO(string po, string phieuNhap, int loaichungtu, int idKho, DateTime ngaylap, int idChungTu)
       {
           return GetObjectCommand<ChungTuXuatNhapNccInfo>(Declare.StoreProcedureNamespace.spChungTuSelectByPO, po, phieuNhap, loaichungtu, idKho, ngaylap, idChungTu);
       }
       internal ChungTuXuatNhapNccInfo GetLichSuChungTuNhapXuatNCCFromSoPO(string po, string phieuNhap, int idKho, DateTime ngaylap)
       {
           return GetObjectCommand<ChungTuXuatNhapNccInfo>(Declare.StoreProcedureNamespace.spLichSuChungTuSelectByPO, po, phieuNhap, idKho, ngaylap);
       }
       internal List<DMChungTuNhapInfo> Search(string sophieu)
       {
           return GetListCommand<DMChungTuNhapInfo>(Declare.StoreProcedureNamespace.spChungTuSearch, sophieu);
       }
       internal void UpdateTrangThai(int idChungTu,TrangThaiDuyet trangThai)
       {
           ExecuteCommand(Declare.StoreProcedureNamespace.spChungTuUpdateTrangThai,idChungTu,Convert.ToInt32(trangThai));
       }

       public T GetChungTuBySoChungTu<T>(string soChungTu)
       {
           return GetObjectCommand<T>(Declare.StoreProcedureNamespace.spChungTuGetBySoChungTu, soChungTu);
       }
       public List<BaoCao_PhieuNhapMuaNCCInfor> GetPhieuNhapNCC(int idChungTu)
       {
           return GetListCommand<BaoCao_PhieuNhapMuaNCCInfor>(Declare.StoreProcedureNamespace.spPhieuNhapNCC, idChungTu);
       }
       public List<BaoCao_ChiTietInfor> GetPhieuTraNCC(int idChungTu)
       {
           return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuTraNCC, idChungTu);
       }
       public List<BaoCao_ChiTietInfor> GetPhieuTraNCC_TH(int idChungTu)
       {
           return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuTraNCC_TH, idChungTu);
       }
       public List<BaoCao_PhieuNhapMuaNCCInfor> GetPhieuNhapPO(int idChungTu)
       {
           return GetListCommand<BaoCao_PhieuNhapMuaNCCInfor>(Declare.StoreProcedureNamespace.spPhieuNhapPOTongHop, idChungTu);
       }
       public List<ChungTuXLKInfor> GetListXlk(string malenh)
       {
           return GetListCommand<ChungTuXLKInfor>(Declare.StoreProcedureNamespace.spKhoChungTuGetListXLK,
                                                        Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX), Declare.IdKho, malenh);
       }

       public List<HangHoa_ChiTietInfo> GetListXlk1(string malenh, TransactionType transactionType)
       {
           return GetListCommand<ChiTietMaVachThanhPham>(
               @"select t1.idchungtu,
					    t1.sochungtu chungtuxuatlinhkien,
                        tp.sochungtu chungtunhapthanhpham,
					    t1.ngaylap ngayxuatlinhkien,
					    tp.trangthai,
					    nvl(hhct.mavach, ctct.danhsachmavach) mavach,
                        cthh.soluong
			    from tbl_chungtu t1
		     inner join tbl_chungtu tp
				    on t1.sochungtugoc = tp.sochungtu
		     inner join tbl_chungtu_chitiet ctct
				    on tp.idchungtu = ctct.idchungtu
			    left join tbl_chungtu_chitiet_hanghoa cthh
				    on ctct.idchitiet = cthh.idchitietchungtu
			    left join tbl_hanghoa_chitiet hhct
				    on hhct.idchitiet = cthh.idchitiethanghoa
		     where t1.sochungtugoc = tp.sochungtu
			     and t1.loaichungtu = :loaichungtu
			     and (t1.idkho = :idkho or :idkho = 0)
			     and tp.sochungtugoc = :sochungtugoc
		     order by t1.ngaylap desc, t1.sochungtu desc",
               Convert.ToInt32(transactionType),
               Declare.IdKho, malenh).ConvertAll(
                   delegate(ChiTietMaVachThanhPham item)
                       {
                           return (HangHoa_ChiTietInfo) item;
                       });
       }

       public List<HangHoa_ChiTietInfo> GetPhieuXuatLKDetail1(int idChungTu)
       {
           return GetListCommand<ChiTietMaVachLinhKien>(
               @"SELECT hhct.MaVach, sp.MaSanPham, sp.TenSanPham, cthh.SoLuong
	                FROM tbl_ChungTu_ChiTiet_HangHoa cthh
                 INNER JOIN tbl_ChungTu_Chitiet ctct
		                ON cthh.IdChiTietChungTu = ctct.IdChitiet
                 INNER JOIN tbl_HangHoa_Chitiet hhct
		                ON cthh.IdChiTietHangHoa = hhct.IdChiTiet
                 INNER JOIN tbl_SanPham sp
		                ON hhct.IdSanPham = sp.IdSanPham
                 WHERE ctct.idchungtu = :idchungtu",
               idChungTu).ConvertAll(delegate(ChiTietMaVachLinhKien item)
                                         {
                                             return (HangHoa_ChiTietInfo) item;
                                         });
       }


       public List<MaVachThanhPhamInfo> GetListNtp(string malenh)
       {
           return GetListCommand<MaVachThanhPhamInfo>(Declare.StoreProcedureNamespace.spKhoChungTuGetListNTP,
                                                        Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX), Declare.IdKho, malenh);
       }
       public List<MaVachThanhPhamInfo> GetListTtp(string malenh)
       {
           return GetListCommand<MaVachThanhPhamInfo>(Declare.StoreProcedureNamespace.spKhoChungTuGetListNTP,
                                                        Convert.ToInt32(TransactionType.XUAT_THANH_PHAM), Declare.IdKho, malenh);
       }
       public List<BaoCao_ChiTietInfor> GetPhieuXuatLKDetail(int idChungTu)
       {
           return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuXuatTieuHao, idChungTu);
       }
       public List<BaoCao_ChiTietInfor> GetPhieuNhapTPDetail(int idChungTu)
       {
           return GetListCommand<BaoCao_ChiTietInfor>(Declare.StoreProcedureNamespace.spPhieuXuatTieuHao, idChungTu);
       }
       public List<ChiTietDieuChuyenDonHangInfo> CheckSoPhieuByDH(string soChungtu, int idSanPham)
       {
           return GetListCommand<ChiTietDieuChuyenDonHangInfo>(Declare.StoreProcedureNamespace.spChungTuCheckSoPhieuByDH,
                                                      soChungtu,idSanPham);
       }
       public ChungTu_ChiTietHangHoaDCDHInfo GetSoChungTuBan(string soChungTu, int idChiTiet)
       {
           return GetObjectCommand<ChungTu_ChiTietHangHoaDCDHInfo>(Declare.StoreProcedureNamespace.spChungTuSelectSoChungTuBan,idChiTiet, soChungTu );
       }
       public ChungTu_ChiTietInfo GetIdChungTuBySoPhieu (string soPhieu, int loaiChungTu)
       {
           return GetObjectCommand<ChungTu_ChiTietInfo>(Declare.StoreProcedureNamespace.spChungTuGetIdChungTuBySoPhieu,
                                                        soPhieu, loaiChungTu);
       }
    }
}
