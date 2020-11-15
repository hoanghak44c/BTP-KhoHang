using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class TonDauKyDAO : BaseDAO
    {

        private static TonDauKyDAO instance;

        private TonDauKyDAO()
        {
        }

        public static TonDauKyDAO Instance
        {
            get
            {
                if (instance == null) instance = new TonDauKyDAO();
                return instance;
            }
        }

        internal List<NapSoTonInfo> NapSoTon(int idKho, DateTime ngayDuDau, int idNguoiTao)
        {
            return GetListCommand<NapSoTonInfo>(Declare.StoreProcedureNamespace.spGetTonDauKy, idKho, ngayDuDau, idNguoiTao);
        }

        public TonDauKyInfo GetTonDauKy(int idSanPham, int idKho, DateTime ngayDuDau, int idNguoiTao)
        {
            return GetObjectCommand<TonDauKyInfo>(Declare.StoreProcedureNamespace.spGetTonDauKy, idKho, ngayDuDau, idNguoiTao, idSanPham);
        }

        public HangHoaChiTietInfo GetIdHangHoaChiTietMaVachTonDauKy(string maVach, int idDuDauKy)
        {
            return GetObjectCommand<HangHoaChiTietInfo>(Declare.StoreProcedureNamespace.spGetHangHoaChiTiet, maVach, idDuDauKy);
        }

        public void Update (TonDauKyInfo tonDauKyInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTonDauKyUpdate, tonDauKyInfo.IdDuDauKy,
                           tonDauKyInfo.ThoiGian, tonDauKyInfo.IdKho, tonDauKyInfo.IdSanPham, tonDauKyInfo.SoLuong,
                           tonDauKyInfo.DonGia, tonDauKyInfo.ThanhTien);
        }

        public int Insert(TonDauKyInfo tonDauKyInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTonDauKyInsert, tonDauKyInfo.IdDuDauKy,
                           tonDauKyInfo.ThoiGian, tonDauKyInfo.IdKho, tonDauKyInfo.IdSanPham, tonDauKyInfo.SoLuong,
                           tonDauKyInfo.DonGia, tonDauKyInfo.ThanhTien, tonDauKyInfo.NguoiTao);
            return Convert.ToInt32(Parameters["p_IdDuDauKy"].Value.ToString());
        }

        public void Update(HangHoaChiTietInfo hangHoaChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTonDauKyChiTietUpdate, hangHoaChiTietInfo.IdChiTiet,
                hangHoaChiTietInfo.IdDuDauKy, hangHoaChiTietInfo.IdKho, hangHoaChiTietInfo.IdSanPham,
                hangHoaChiTietInfo.MaVach, hangHoaChiTietInfo.SoLuong);
        }

        public void Update (DateTime lanDongBo, int idKho)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spKhoUpdateLanDongBo, lanDongBo, idKho);
        }

        internal int Insert(HangHoaChiTietInfo hangHoaChiTietInfo)
        {
            ExecuteCommand(Declare.StoreProcedureNamespace.spTonDauKyChiTietInsert, hangHoaChiTietInfo.IdChiTiet,
                hangHoaChiTietInfo.IdDuDauKy, hangHoaChiTietInfo.IdKho, hangHoaChiTietInfo.IdSanPham,
                hangHoaChiTietInfo.MaVach, hangHoaChiTietInfo.SoLuong);
            return Convert.ToInt32(Parameters["p_IdChiTiet"].Value);
        }
    }
}