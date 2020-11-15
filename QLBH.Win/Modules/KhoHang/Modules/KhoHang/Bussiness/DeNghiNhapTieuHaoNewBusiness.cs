using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class DeNghiNhapTieuHaoBusiness : ChungTuNhapKeToanBusinessBase<ChungTuDeNghiXuatTieuHaoInfornew, DeNghiXuatTieuHaoChiTietInfonew>
    {
         public DeNghiNhapTieuHaoBusiness()
        {
            ChungTu = new ChungTuDeNghiXuatTieuHaoInfornew
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAP_TIEU_HAO),
                //IdNhanVien = Declare.IdNhanVien,
                //IdKho = Declare.IdKho
            };
        }

         public DeNghiNhapTieuHaoBusiness(ChungTuDeNghiXuatTieuHaoInfornew chungTuXuatTieuHaoInfor)
            : base(chungTuXuatTieuHaoInfor)
        {
            //if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO))
            //{
            //    throw new ManagedException("Không phải loại chứng từ đề nghị xuất tiêu hao");
            //}
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiNhapTieuHaoProvider.Instance;
        }
    }
}
