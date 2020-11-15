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
    public class XuatDieuChuyenBusiness : ChungTuXuatKhoBusinessBase<ChungTuDieuChuyenInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        public XuatDieuChuyenBusiness()
        {
            ChungTu = new ChungTuDieuChuyenInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public XuatDieuChuyenBusiness(ChungTuDieuChuyenInfor chungTuXuatDieuChuyenInfor)
            : base(chungTuXuatDieuChuyenInfor)
        {
            //if (chungTuXuatDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
            //{
            //    throw new ManagedException("Không phải loại chứng từ xuất diều chuyển");
            //}
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = XuatDieuChuyenDataProvider.Instance;
        }

        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new XuatTonThatCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayLap);
        }
    }
}
