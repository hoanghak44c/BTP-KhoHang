using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class XacNhanNhapThanhPhanSanXuatBussiness : ChungTuNhapKhoBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuNhapNccChiTietHangHoaInfo>
    {
        public XacNhanNhapThanhPhanSanXuatBussiness(ChungTuXuatNhapNccInfo ChungTuXuatNhapNccInfo)
            : base(ChungTuXuatNhapNccInfo)
        {
            //if (ChungTuXuatNhapNccInfo.LoaiChungTu != Convert.ToInt32(TransactionType.NHAP_NOIBO))
            //{
            //    throw new ManagedException("Không phải loại chứng từ nhập nội bộ");
            //}
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = XacNhanNhapThanhPhamSXDataProvider.Instance;
        }

        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new NhapTonThatCalc(tonKhoInfo,ChungTuInfo.SoChungTu,ChungTuInfo.NgayLap);
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            hangHoaInfo.IdPhieuNhap = ChungTuInfo.IdChungTu;
            hangHoaInfo.IdPhieuXuat = 0;
            return true;
        }
    }
}
