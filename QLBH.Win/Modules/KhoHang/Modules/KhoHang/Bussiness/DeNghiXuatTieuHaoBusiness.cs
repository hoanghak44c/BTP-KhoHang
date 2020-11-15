using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class DeNghiXuatTieuHaoBusiness : ChungTuXuatKeToanBusinessBase<ChungTuDeNghiXuatTieuHaoInfor, DeNghiXuatTieuHaoChiTietInfo>
    {
        public DeNghiXuatTieuHaoBusiness()
        {
            ChungTu = new ChungTuDeNghiXuatTieuHaoInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public DeNghiXuatTieuHaoBusiness(ChungTuDeNghiXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
            : base(chungTuXuatTieuHaoInfor)
        {
            if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO))
            {
                throw new ManagedException("Không phải loại chứng từ đề nghị xuất tiêu hao");
            }
        }

        #region Overrides of ChungTuKeToanBussinessBase<ChungTuDeNghiXuatTieuHaoInfor,DeNghiXuatTieuHaoChiTietInfo>

        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiXuatTieuHaoProvider.Instance;
        }
        #endregion
    }
}
