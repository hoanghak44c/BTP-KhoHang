using System;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class XuatDoiLinhKienLoiBusiness : ChungTuXuatKhoBusinessBase<ChungTuDoiLinhKienLoiInfo, ChungTuChiTietBaseInfo, ChungTuChiTietHangHoaBaseInfo>
    {

        public XuatDoiLinhKienLoiBusiness(){}

        public XuatDoiLinhKienLoiBusiness(ChungTuDoiLinhKienLoiInfo chungTuDoiLinhKienLoiInfo) : base(chungTuDoiLinhKienLoiInfo) { }

        #region Overrides of ChungTuKeToanBusinessBase<ChungTuDoiLinhKienLoiInfo,ChungTuChiTietBaseInfo>

        protected override void CreateBusinessProvider()
        {
            BusinessProvider = DoiLinhKienLoiDataProvider.Instance;
        }

        #endregion

        protected override void CreateTonKhoCalc(HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new XuatTonKhongCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayXuatHang);
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            hangHoaInfo.IdPhieuXuat = ChungTuInfo.IdChungTu;
            return true;
        }
    }
}