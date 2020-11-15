using System;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class NhapDoiLinhKienLoiBusiness : ChungTuNhapKhoBusinessBase<ChungTuDoiLinhKienLoiInfo, ChungTuChiTietBaseInfo, ChungTuChiTietHangHoaBaseInfo>
    {

        public NhapDoiLinhKienLoiBusiness(){ }

        public NhapDoiLinhKienLoiBusiness(ChungTuDoiLinhKienLoiInfo chungTuDoiLinhKienLoiInfo) : base(chungTuDoiLinhKienLoiInfo) { }

        #region Overrides of ChungTuKeToanBusinessBase<ChungTuDoiLinhKienLoiInfo, ChungTuChiTietBaseInfo>

        protected override void CreateBusinessProvider()
        {
            BusinessProvider = DoiLinhKienLoiDataProvider.Instance;
        }

        #endregion

        protected override void CreateTonKhoCalc(HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new NhapTonKhongCalc(tonKhoInfo, ChungTu.SoChungTu, ChungTu.NgayXuatHang);
        }
    }
}