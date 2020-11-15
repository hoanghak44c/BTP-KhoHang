using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    //public class NhanDieuChuyenBussiness : ChungTuNhapKhoBusinessBase<ChungTuNhapDieuChuyenInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    //{
    //    public NhanDieuChuyenBussiness()
    //    {
    //        ChungTu = new ChungTuNhapDieuChuyenInfor
    //        {
    //            LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
    //            IdNhanVien = Declare.IdNhanVien,
    //            IdKho = Declare.IdKho
    //        };
    //    }

    //    public NhanDieuChuyenBussiness(ChungTuNhapDieuChuyenInfor chungTuNhanDieuChuyenInfor)
    //        : base(chungTuNhanDieuChuyenInfor)
    //    {
    //        //if (chungTuNhanDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
    //        //{
    //        //    throw new ManagedException("Không phải loại chứng từ nhận điều chuyển ");
    //        //}
    //    }
    //    protected override void CreateBusinessProvider()
    //    {
    //        BusinessKhoProvider = NhanDieuChuyenDataProvider.Instance;
    //    }
    //}

    public class NhapDieuChuyenTGBussiness : NhapDieuChuyenBussiness
        //ChungTuNhapKhoBusinessBase<ChungTuNhapDieuChuyenInfo, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        public NhapDieuChuyenTGBussiness()
        {
            ChungTu = new ChungTuNhapDieuChuyenInfo
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public NhapDieuChuyenTGBussiness(ChungTuNhapDieuChuyenInfo chungTuNhanDieuChuyenInfor)
            : base(chungTuNhanDieuChuyenInfor)
        {
            //if (chungTuNhanDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
            //{
            //    throw new ManagedException("Không phải loại chứng từ nhận điều chuyển ");
            //}
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = NhapDieuChuyenKhoTGDataProvider.Instance;
        }

        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new NhapTonThatCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayLap);
        }
    }
}
