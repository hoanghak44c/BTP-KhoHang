using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class BaoCaoDieuChuyenKhoTongGiaoDao : BaseDAO
    {

        private static BaoCaoDieuChuyenKhoTongGiaoDao instance;

        private BaoCaoDieuChuyenKhoTongGiaoDao()
        {
        }

        public static BaoCaoDieuChuyenKhoTongGiaoDao Instance
        {
            get { return instance ?? (instance = new BaoCaoDieuChuyenKhoTongGiaoDao()); }
        }

        public List<DieuChuyenKhoTongGiaoInfo> GetListSource()
        {
            return GetListCommand<DieuChuyenKhoTongGiaoInfo>(
                @"select ct.ngaylap, ct.sochungtu sophieuxuat, khoxuat.makho khoxuat, khonhan.makho khonhan, 
                ct.ngayxuathang ngayxuat, ct.ghichu, dft.description trangthai, ct.diachihoadon sohoadon,
                ct.tongtienhang tongtien
                from tbl_chungtu ct
                inner join tbl_dm_kho khoxuat on ct.idkho = khoxuat.idkho
                inner join tbl_dm_kho khonhan on ct.idkhodieuchuyen = khonhan.idkho
                inner join tbl_defined_transactions dft on ct.loaichungtu = dft.transnum and ct.trangthai = dft.status
                and ct.loaichungtu in (12, 13) 
                and ct.trangthai <> :trangthai and ct.giaonhan = :khoTongGiao",
                Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN),
                Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO));
        }

        public List<ChungTuXuatDieuChuyenInfo> GetListSource(string soGiaoDich, DateTime ngayGiaoDich, string trangThai)
        {
            if(String.IsNullOrEmpty(soGiaoDich))
            {
                if(trangThai == "Đã nhận")
                {
                    return GetListCommand<ChungTuXuatDieuChuyenInfo>(
                        @"Select t1.SoChungTu,
								 t1.NgayLap,
								 t1.ngayxuathang    as NgayNhapXuatKho,
								 t1.GhiChu,
								 t1.idchungtu,
								 t1.loaichungtu,
								 t1.idkho,
								 t1.trangthai,
								 t1.idkhodieuchuyen,
								 t1.idnhanvien,
								 t1.nguoitao,
								 t1.nguoisua,
								 t1.idphieugiaonhan as IdNguoiVC,
								 t1.Idnghenghiep    as IdNguoiUyNhiem,
								 t1.idtiente        as IdNguoiKyDuyet,
								 t1.diachihoadon    as HoaDonDC,
								 t1.diachigiaohang  as PhuongTien,
								 t3.makho           as tenkho,
								 t4.hoten           as NguoiLap,
								 t0.makho           as KhoNhan,
								 t5.hoten           as NguoiUyNhiem,
								 t6.hoten           as NguoiVanChuyen,
								 t7.hoten           as NguoiNhapXuatKho,
								 t8.hoten           as NguoiKyDuyet,
								 t1.tongtienhang,
								 t1.lockid,
								 t1.lockaccount,
								 t1.lockmachine,
								 t1.processid,
								 dft.description
						from Tbl_Chungtu t1
					 inner join tbl_dm_kho t3
							on t3.idkho = t1.idkho
						left join tbl_dm_kho t0
							on t0.idkho = t1.idkhodieuchuyen
						left join tbl_dm_nhanvien t4
							on t4.idnhanvien = t1.idnhanvien
						left join tbl_dm_nhanvien t5
							on t5.idnhanvien = t1.idnghenghiep
						left join tbl_dm_nhanvien t6
							on t6.idnhanvien = t1.idphieugiaonhan
						left join tbl_dm_nhanvien t7
							on t7.idnhanvien = t1.idnhanviengiao
						left join tbl_dm_nhanvien t8
							on t8.idnhanvien = t1.idtiente
						left join tbl_defined_transactions dft
							on dft.transnum = t1.loaichungtu
						 and dft.status = t1.trangthai
					 where t1.loaichungtu in (12, 13)
                        and t1.giaonhan = :khoTongGiao
                        and t1.trangthai = :trangThai
                        and (to_date(t1.ngaylap, 'dd/mm/rrrr') = to_date(:ngayGiaoDich, 'dd/mm/rrrr')
                            or (to_date('01/01/0001', 'dd/mm/rrrr') = to_date(:ngayGiaoDich, 'dd/mm/rrrr')
                                and t1.ngaylap > sysdate - 31))
					 order by ngaylap desc, sochungtu desc",
                        Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO),
                        Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN),
                        ngayGiaoDich.ToString("dd/MM/yyyy"));                    
                }

                if (trangThai == "Khác")
                    return GetListCommand<ChungTuXuatDieuChuyenInfo>(
                        @"Select t1.SoChungTu,
								 t1.NgayLap,
								 t1.ngayxuathang    as NgayNhapXuatKho,
								 t1.GhiChu,
								 t1.idchungtu,
								 t1.loaichungtu,
								 t1.idkho,
								 t1.trangthai,
								 t1.idkhodieuchuyen,
								 t1.idnhanvien,
								 t1.nguoitao,
								 t1.nguoisua,
								 t1.idphieugiaonhan as IdNguoiVC,
								 t1.Idnghenghiep    as IdNguoiUyNhiem,
								 t1.idtiente        as IdNguoiKyDuyet,
								 t1.diachihoadon    as HoaDonDC,
								 t1.diachigiaohang  as PhuongTien,
								 t3.makho           as tenkho,
								 t4.hoten           as NguoiLap,
								 t0.makho           as KhoNhan,
								 t5.hoten           as NguoiUyNhiem,
								 t6.hoten           as NguoiVanChuyen,
								 t7.hoten           as NguoiNhapXuatKho,
								 t8.hoten           as NguoiKyDuyet,
								 t1.tongtienhang,
								 t1.lockid,
								 t1.lockaccount,
								 t1.lockmachine,
								 t1.processid,
								 dft.description
						from Tbl_Chungtu t1
					 inner join tbl_dm_kho t3
							on t3.idkho = t1.idkho
						left join tbl_dm_kho t0
							on t0.idkho = t1.idkhodieuchuyen
						left join tbl_dm_nhanvien t4
							on t4.idnhanvien = t1.idnhanvien
						left join tbl_dm_nhanvien t5
							on t5.idnhanvien = t1.idnghenghiep
						left join tbl_dm_nhanvien t6
							on t6.idnhanvien = t1.idphieugiaonhan
						left join tbl_dm_nhanvien t7
							on t7.idnhanvien = t1.idnhanviengiao
						left join tbl_dm_nhanvien t8
							on t8.idnhanvien = t1.idtiente
						left join tbl_defined_transactions dft
							on dft.transnum = t1.loaichungtu
						 and dft.status = t1.trangthai
					 where t1.loaichungtu in (12, 13)
                        and t1.giaonhan = :khoTongGiao 
                        and t1.trangthai <> :trangThai
                        and (to_date(t1.ngaylap, 'dd/mm/rrrr') = to_date(:ngayGiaoDich, 'dd/mm/rrrr')
                            or (to_date('01/01/0001', 'dd/mm/rrrr') = to_date(:ngayGiaoDich, 'dd/mm/rrrr')
                                and t1.ngaylap > sysdate - 31))
					 order by ngaylap desc, sochungtu desc",
                        Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO),
                        Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN),
                        ngayGiaoDich.ToString("dd/MM/yyyy"));

                return GetListCommand<ChungTuXuatDieuChuyenInfo>(
                    @"Select t1.SoChungTu,
								 t1.NgayLap,
								 t1.ngayxuathang    as NgayNhapXuatKho,
								 t1.GhiChu,
								 t1.idchungtu,
								 t1.loaichungtu,
								 t1.idkho,
								 t1.trangthai,
								 t1.idkhodieuchuyen,
								 t1.idnhanvien,
								 t1.nguoitao,
								 t1.nguoisua,
								 t1.idphieugiaonhan as IdNguoiVC,
								 t1.Idnghenghiep    as IdNguoiUyNhiem,
								 t1.idtiente        as IdNguoiKyDuyet,
								 t1.diachihoadon    as HoaDonDC,
								 t1.diachigiaohang  as PhuongTien,
								 t3.makho           as tenkho,
								 t4.hoten           as NguoiLap,
								 t0.makho           as KhoNhan,
								 t5.hoten           as NguoiUyNhiem,
								 t6.hoten           as NguoiVanChuyen,
								 t7.hoten           as NguoiNhapXuatKho,
								 t8.hoten           as NguoiKyDuyet,
								 t1.tongtienhang,
								 t1.lockid,
								 t1.lockaccount,
								 t1.lockmachine,
								 t1.processid,
								 dft.description
						from Tbl_Chungtu t1
					 inner join tbl_dm_kho t3
							on t3.idkho = t1.idkho
						left join tbl_dm_kho t0
							on t0.idkho = t1.idkhodieuchuyen
						left join tbl_dm_nhanvien t4
							on t4.idnhanvien = t1.idnhanvien
						left join tbl_dm_nhanvien t5
							on t5.idnhanvien = t1.idnghenghiep
						left join tbl_dm_nhanvien t6
							on t6.idnhanvien = t1.idphieugiaonhan
						left join tbl_dm_nhanvien t7
							on t7.idnhanvien = t1.idnhanviengiao
						left join tbl_dm_nhanvien t8
							on t8.idnhanvien = t1.idtiente
						left join tbl_defined_transactions dft
							on dft.transnum = t1.loaichungtu
						 and dft.status = t1.trangthai
					 where t1.loaichungtu in (12, 13)
                        and t1.giaonhan = :khoTongGiao 
                        and (to_date(t1.ngaylap, 'dd/mm/rrrr') = to_date(:ngayGiaoDich, 'dd/mm/rrrr')
                            or (to_date('01/01/0001', 'dd/mm/rrrr') = to_date(:ngayGiaoDich, 'dd/mm/rrrr')
                                and t1.ngaylap > sysdate - 31))
					 order by ngaylap desc, sochungtu desc",
                    Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO),
                    ngayGiaoDich.ToString("dd/MM/yyyy"));
            }

            return GetListCommand<ChungTuXuatDieuChuyenInfo>(
                @"Select t1.SoChungTu,
								 t1.NgayLap,
								 t1.ngayxuathang    as NgayNhapXuatKho,
								 t1.GhiChu,
								 t1.idchungtu,
								 t1.loaichungtu,
								 t1.idkho,
								 t1.trangthai,
								 t1.idkhodieuchuyen,
								 t1.idnhanvien,
								 t1.nguoitao,
								 t1.nguoisua,
								 t1.idphieugiaonhan as IdNguoiVC,
								 t1.Idnghenghiep    as IdNguoiUyNhiem,
								 t1.idtiente        as IdNguoiKyDuyet,
								 t1.diachihoadon    as HoaDonDC,
								 t1.diachigiaohang  as PhuongTien,
								 t3.makho           as tenkho,
								 t4.hoten           as NguoiLap,
								 t0.makho           as KhoNhan,
								 t5.hoten           as NguoiUyNhiem,
								 t6.hoten           as NguoiVanChuyen,
								 t7.hoten           as NguoiNhapXuatKho,
								 t8.hoten           as NguoiKyDuyet,
								 t1.tongtienhang,
								 t1.lockid,
								 t1.lockaccount,
								 t1.lockmachine,
								 t1.processid,
								 dft.description
						from Tbl_Chungtu t1
					 inner join tbl_dm_kho t3
							on t3.idkho = t1.idkho
						left join tbl_dm_kho t0
							on t0.idkho = t1.idkhodieuchuyen
						left join tbl_dm_nhanvien t4
							on t4.idnhanvien = t1.idnhanvien
						left join tbl_dm_nhanvien t5
							on t5.idnhanvien = t1.idnghenghiep
						left join tbl_dm_nhanvien t6
							on t6.idnhanvien = t1.idphieugiaonhan
						left join tbl_dm_nhanvien t7
							on t7.idnhanvien = t1.idnhanviengiao
						left join tbl_dm_nhanvien t8
							on t8.idnhanvien = t1.idtiente
						left join tbl_defined_transactions dft
							on dft.transnum = t1.loaichungtu
						 and dft.status = t1.trangthai
					 where t1.loaichungtu in (12, 13)
                        and t1.giaonhan = :khoTongGiao 
                        and t1.sochungtu = :soChungTu",
                Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO),
                soGiaoDich);
        }
    }
}