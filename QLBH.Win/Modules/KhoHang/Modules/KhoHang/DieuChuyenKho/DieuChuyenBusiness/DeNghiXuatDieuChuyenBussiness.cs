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
    public class DeNghiXuatDieuChuyenBussiness : ChungTuXuatKeToanBusinessBase<ChungTuXuatDieuChuyenInfo, DeNghiXuatDieuChuyenInfor>
    {
        public DeNghiXuatDieuChuyenBussiness()
        {
            ChungTu = new ChungTuXuatDieuChuyenInfo
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public DeNghiXuatDieuChuyenBussiness(ChungTuXuatDieuChuyenInfo chungTuDeNghiXuatDieuChuyenInfor)
            : base(chungTuDeNghiXuatDieuChuyenInfor)
        {
            //if (chungTuDeNghiXuatDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN))
            //{
            //    throw new Exception("Không phải loại chứng từ đề nghị xuất điều chuyển!");
            //}
        }

        #region Overrides of ChungTuKeToanKhoBusinessBase<ChungTuXuatDieuChuyenInfor,DeNghiXuatTieuHaoChiTietInfo>

        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiXuatDieuChuyenDataProvider.Instance;
        }

        #endregion
    }
}
