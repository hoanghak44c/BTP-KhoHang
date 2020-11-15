using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Infors;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class KhoXuatNccBusiness :ChungTuXuatKhoBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuXuatNccChiTietHangHoaInfo>
    {
        public KhoXuatNccBusiness(ChungTuXuatNhapNccInfo chungTuChungTuXuatNhapInfo)
            : base(chungTuChungTuXuatNhapInfo)
        {
            //if (ChungTuNhapInfo.LoaiChungTu != Convert.ToInt32(TransactionType.TRA_LAI_PO))
            //{
            //    throw new ManagedException("Không phải loại chứng từ trả");
            //}
        }

        public KhoXuatNccBusiness() { }

        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new XuatTonCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayXuatHang);
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = KhoXuatNccDataProvider.Instance;
        }

        public override bool Conjunction(ChungTuXuatNhapNccChiTietInfo chiTietChungTuInfo, ChungTuXuatNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            return chiTietChungTuInfo.IdSanPham == chiTietHangHoaInfo.IdSanPham &&
                   chiTietChungTuInfo.TransactionID == chiTietHangHoaInfo.TransactionID;
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            hangHoaInfo.IdPhieuXuat = ChungTuInfo.IdChungTu;
            return true;
        }
    }
}
