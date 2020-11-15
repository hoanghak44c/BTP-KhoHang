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
    class XuatThanhPhamSXBussiness:ChungTuXuatKhoBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuNhapNccChiTietHangHoaInfo>
    {
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = KhoNhapNccDataProvider.Instance;
        }
        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new XuatTonCalc(tonKhoInfo,ChungTuInfo.SoChungTu,ChungTuInfo.NgayLap);
        }
        public XuatThanhPhamSXBussiness(ChungTuXuatNhapNccInfo chungTuXuatNhapInfo)
            : base(chungTuXuatNhapInfo)
        {
            //if (chungTuXuatNhapInfo.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX))
            //{
            //    throw new ManagedException("Không phải loại chứng từ nhập xuất linh kiện sản xuất");
            //}
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            return true;
        }
    }
}
