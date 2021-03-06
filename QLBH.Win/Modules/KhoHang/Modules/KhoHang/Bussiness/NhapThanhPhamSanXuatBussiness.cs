﻿using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Business;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    class NhapThanhPhamSanXuatBussiness : ChungTuNhapKeToanBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo>
    {
        public NhapThanhPhamSanXuatBussiness(ChungTuXuatNhapNccInfo chungTuXuatNhapInfo)
            : base(chungTuXuatNhapInfo)
        {
            //if (chungTuXuatNhapInfo.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX))
            //{
            //    throw new ManagedException("Không phải loại chứng từ nhập xuất linh kiện sản xuất");
            //}
        }
        //protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        //{
        //    TonKhoCalc = new NhapTonAoCalc(tonKhoInfo);
        //}
        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = NhapThanhPhamSanXuatDataProvider.Instance;
        }
    }
}
