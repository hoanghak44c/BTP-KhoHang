using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class NhapNccBusiness: ChungTuNhapKhoBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuNhapNccChiTietHangHoaInfo>
    {
        public NhapNccBusiness(ChungTuXuatNhapNccInfo chungTuXuatNhapInfo)
            : base(chungTuXuatNhapInfo)
        {
            if (chungTuXuatNhapInfo.LoaiChungTu != Convert.ToInt32(TransactionType.NHAP_PO))
            {
                throw new ManagedException("Không phải loại chứng từ nhập từ nhà cung cấp");
            }
        }

        protected override void CreateTonKhoCalc(HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new NhapTonCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayXuatHang);
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = KhoNhapNccDataProvider.Instance;
        }

        public override bool Conjunction(ChungTuXuatNhapNccChiTietInfo chiTietChungTuInfo, ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            return chiTietChungTuInfo.IdSanPham == chiTietHangHoaInfo.IdSanPham &&
                   chiTietChungTuInfo.TransactionID == chiTietHangHoaInfo.TransactionID;
        }

        protected override bool ThietLapBaoHanhHang()
        {
            return true;
        }
        
        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            hangHoaInfo.IdPhieuNhap = ChungTuInfo.IdChungTu;
            hangHoaInfo.IdPhieuXuat = 0;
            return true;
        }
    }
}
