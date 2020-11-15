using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class DeNghiNhapDieuChuyenBussiness : ChungTuNhapKeToanBusinessBase<ChungTuNhapDieuChuyenInfo, DeNghiNhapDieuChuyenChiTietInfor>
    {
        public DeNghiNhapDieuChuyenBussiness()
        {
            ChungTu = new ChungTuNhapDieuChuyenInfo
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public DeNghiNhapDieuChuyenBussiness(ChungTuNhapDieuChuyenInfo chungTuDeNghiNhanDieuChuyenInfor)
            : base(chungTuDeNghiNhanDieuChuyenInfor)
        {
            //if (chungTuDeNghiNhanDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN))
            //{
            //    throw new ManagedException("Không phải loại chứng từ đề nghị nhận điều chuyển");
            //}
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiNhapDieuChuyenDataProvider.Instance;
        }
    }
}
