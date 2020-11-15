using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class DeNghiXuatTieuHaoNewBusiness : ChungTuXuatKeToanBusinessBase<ChungTuDeNghiXuatTieuHaoInfornew, DeNghiXuatTieuHaoChiTietInfonew>
    {
         public DeNghiXuatTieuHaoNewBusiness()
        {
            ChungTu = new ChungTuDeNghiXuatTieuHaoInfornew
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO),
                //IdNhanVien = Declare.IdNhanVien,
                //IdKho = Declare.IdKho
            };
        }

         public DeNghiXuatTieuHaoNewBusiness(ChungTuDeNghiXuatTieuHaoInfornew chungTuXuatTieuHaoInfor)
            : base(chungTuXuatTieuHaoInfor)
        {
            //if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO))
            //{
            //    throw new ManagedException("Không phải loại chứng từ đề nghị xuất tiêu hao");
            //}
        }
         protected override int? TrangThaiHuy
         {
             get { return Convert.ToInt32(TrangThaiDuyet.HUY_TIEU_HAO); }
         }
        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiXuatTieuHaoProvidernew.Instance;
        }
    }
}
