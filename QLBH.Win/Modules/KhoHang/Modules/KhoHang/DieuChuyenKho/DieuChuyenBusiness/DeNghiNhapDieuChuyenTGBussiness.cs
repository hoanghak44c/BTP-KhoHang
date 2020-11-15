using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class DeNghiNhapDieuChuyenTGBussiness : DeNghiNhapDieuChuyenBussiness
        //ChungTuNhapKeToanBusinessBase<ChungTuNhapDieuChuyenInfo, DeNghiNhapDieuChuyenChiTietInfor>
    {
        public DeNghiNhapDieuChuyenTGBussiness()
        {
            ChungTu = new ChungTuNhapDieuChuyenInfo
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public DeNghiNhapDieuChuyenTGBussiness(ChungTuNhapDieuChuyenInfo chungTuDeNghiNhanDieuChuyenInfor)
            : base(chungTuDeNghiNhanDieuChuyenInfor)
        {
            //if (chungTuDeNghiNhanDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN))
            //{
            //    throw new ManagedException("Không phải loại chứng từ đề nghị nhận điều chuyển");
            //}
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiNhapDieuChuyenTGDataProvider.Instance;
        }
    }
}
