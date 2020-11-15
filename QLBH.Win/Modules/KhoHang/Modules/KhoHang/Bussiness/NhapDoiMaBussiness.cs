﻿using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    class NhapDoiMaBussiness:ChungTuNhapKhoBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuNhapNccChiTietHangHoaInfo>
    {
        public NhapDoiMaBussiness(ChungTuXuatNhapNccInfo chungTuXuatNhapInfo)
            : base(chungTuXuatNhapInfo)
        {
            //if (chungTuXuatNhapInfo.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX))
            //{
            //    throw new ManagedException("Không phải loại chứng từ nhập xuất linh kiện sản xuất");
            //}
        }
        protected override void CreateTonKhoCalc(HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new NhapTonCalc(tonKhoInfo, ChungTuInfo.SoChungTu, ChungTuInfo.NgayLap);
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = KhoNhapNccDataProvider.Instance;
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            hangHoaInfo.IdPhieuNhap = ChungTuInfo.IdChungTu;
            hangHoaInfo.IdPhieuXuat = 0;
            return true;
        }
    }
}