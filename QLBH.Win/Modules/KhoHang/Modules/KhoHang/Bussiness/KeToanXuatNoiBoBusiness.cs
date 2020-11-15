using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    //public class KeToanXuatNoiBoBusiness : ChungTuKeToanBusinessBase<ChungTuDeNghiXuatTieuHaoInfor, DeNghiXuatTieuHaoChiTietInfo>
    //{
    //    public KeToanXuatNoiBoBusiness()
    //    {
    //        ChungTu = new ChungTuDeNghiXuatTieuHaoInfor
    //        {
    //            LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_NOI_BO),
    //            IdNhanVien = Declare.IdNhanVien,
    //            IdKho = Declare.IdKho
    //        };
    //public class KeToanXuatNoiBoBusiness : ChungTuKeToanBusinessBase<ChungTuDeNghiXuatTieuHaoInfor, DeNghiXuatTieuHaoChiTietInfo>
    //{
        //public KeToanXuatNoiBoBusiness()
        //{
        //    ChungTu = new ChungTuDeNghiXuatTieuHaoInfor
        //    {
        //        LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_NOI_BO),
        //        IdNhanVien = Declare.IdNhanVien,
        //        IdKho = Declare.IdKho
        //    };

    //    }
    //    public KeToanXuatNoiBoBusiness(ChungTuDeNghiXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
    //        : base(chungTuXuatTieuHaoInfor)
    //    {
    //        if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_NOI_BO))
    //        {
    //            throw new ManagedException("Không phải loại chứng từ xuất kho nội bộ");
    //        }
    //    }
    //    protected override void CreateBusinessProvider()
    //    {
    //        //BusinessProvider = KeToanXuatNoiBoDataProvider.Instance;
    //    }
    //}
        //}
        //public KeToanXuatNoiBoBusiness(ChungTuDeNghiXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
        //    : base(chungTuXuatTieuHaoInfor)
        //{
        //    if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_NOI_BO))
        //    {
        //        throw new Exception("Không phải loại chứng từ xuất kho nội bộ");
        //    }
        //}
        //protected override void CreateBusinessProvider()
        //{
        //    BusinessProvider = XuatNoiBoDataProvider.Instance;
        //}
    //}
        //}
        //public KeToanXuatNoiBoBusiness(ChungTuDeNghiXuatTieuHaoInfor chungTuXuatTieuHaoInfor)
        //    : base(chungTuXuatTieuHaoInfor)
        //{
        //    if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_NOI_BO))
        //    {
        //        throw new Exception("Không phải loại chứng từ xuất kho nội bộ");
        //    }
        //}
        //protected override void CreateBusinessProvider()
        //{
        //    //BusinessProvider = KeToanXuatNoiBoDataProvider.Instance;
        //}
    //}
}
