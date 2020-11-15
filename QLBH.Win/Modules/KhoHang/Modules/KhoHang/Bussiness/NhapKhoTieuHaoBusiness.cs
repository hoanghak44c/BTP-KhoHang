using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class NhapKhoTieuHaoBusiness : ChungTuNhapKhoBusinessBase<ChungTuXuatTieuHaoInfornew, ChungTu_ChiTietInfonew, ChungTu_ChiTietHangHoaXTHInfo>
    {
        public NhapKhoTieuHaoBusiness()
        {
            ChungTu = new ChungTuXuatTieuHaoInfornew
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_TIEU_HAO),
                //IdNhanVien = Declare.IdNhanVien,
                //IdKho = Declare.IdKho
            };
        }

        public NhapKhoTieuHaoBusiness(ChungTuXuatTieuHaoInfornew chungTuXuatTieuHaoInfor)
            : base(chungTuXuatTieuHaoInfor)
        {
        //    if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO))
        //    {
        //        throw new ManagedException("Không phải loại chứng từ xuất kho tiêu hao");
        //    }
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = NhapTieuHaoProvider.Instance;
        }
        public override bool Conjunction(ChungTu_ChiTietInfonew deNghiXuatTieuHaoChiTietInfonew, ChungTu_ChiTietHangHoaXTHInfo chiTietHangHoaInfo)
        {
            return deNghiXuatTieuHaoChiTietInfonew.IdSanPham == chiTietHangHoaInfo.IdSanPham &&
                   deNghiXuatTieuHaoChiTietInfonew.IdChiPhi == chiTietHangHoaInfo.IdChiPhi
                   && deNghiXuatTieuHaoChiTietInfonew.IdPhongBan == chiTietHangHoaInfo.IdPhongBan;
        }
    }
}
