using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class XuatKhoTieuHaoBusiness : ChungTuXuatKhoBusinessBase<ChungTuXuatTieuHaoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        public XuatKhoTieuHaoBusiness()
        {
            ChungTu = new ChungTuXuatTieuHaoInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public XuatKhoTieuHaoBusiness(ChungTuXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
            : base(chungTuXuatTieuHaoInfor)
        {
            if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO))
            {
                throw new ManagedException("Không phải loại chứng từ xuất kho tiêu hao");
            }
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = XuatTieuHaoProvider.Instance;
        }
    }
}
