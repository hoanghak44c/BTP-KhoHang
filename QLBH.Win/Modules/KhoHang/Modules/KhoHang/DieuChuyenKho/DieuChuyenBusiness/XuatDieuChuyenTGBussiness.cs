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
    public class XuatDieuChuyenTGBussiness : ChungTuXuatKhoBusinessBase<ChungTuXuatDieuChuyenInfo, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        public XuatDieuChuyenTGBussiness()
        {
            ChungTu = new ChungTuXuatDieuChuyenInfo
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public XuatDieuChuyenTGBussiness(ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor)
            : base(chungTuXuatDieuChuyenInfor)
        {
            //if (chungTuXuatDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
            //{
            //    throw new ManagedException("Không phải loại chứng từ xuất diều chuyển");
            //}
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = XuatDieuChuyenKhoTGDataProvider.Instance;
        }

        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new XuatTonThatCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayLap);
        }
    }
}
