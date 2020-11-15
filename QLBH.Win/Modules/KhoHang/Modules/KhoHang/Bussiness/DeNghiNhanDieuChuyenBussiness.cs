using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class DeNghiNhanDieuChuyenBussiness : ChungTuNhapKeToanBusinessBase<ChungTuNhapDieuChuyenInfor, DeNghiNhanDieuChuyenInfor>
    {
        public DeNghiNhanDieuChuyenBussiness()
        {
            ChungTu = new ChungTuNhapDieuChuyenInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public DeNghiNhanDieuChuyenBussiness(ChungTuNhapDieuChuyenInfor chungTuDeNghiNhanDieuChuyenInfor)
            : base(chungTuDeNghiNhanDieuChuyenInfor)
        {
            //if (chungTuDeNghiNhanDieuChuyenInfor.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN))
            //{
            //    throw new ManagedException("Không phải loại chứng từ đề nghị nhận điều chuyển");
            //}
        }
        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = DeNghiNhanDieuChuyenDataProvider.Instance;
        }
    }
}
