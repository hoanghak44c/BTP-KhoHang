using System;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class NhapNoiBoBussiness : ChungTuNhapKhoBusinessBase<ChungTuNhapNoiBoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        public NhapNoiBoBussiness()
        {
            ChungTu = new ChungTuNhapNoiBoInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_NOIBO),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }
        public NhapNoiBoBussiness(ChungTuNhapNoiBoInfor chungTuXuatTieuHaoInfor)
            : base(chungTuXuatTieuHaoInfor)
        {
            if (chungTuXuatTieuHaoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.NHAP_NOIBO))
            {
                throw new ManagedException("Không phải loại chứng từ nhập nội bộ");
            }
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = NhapNoiBoDataProvider.Instance;
        }

        protected override void CreateTonKhoCalc(QLBH.Core.Infors.HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new NhapTonCalc(tonKhoInfo, ChungTuInfo.SoChungTu, ChungTuInfo.NgayLap);
        }

        protected override bool IsOnTheSameAccountBook
        {
            get
            {
                //return true;
                return NhapNoiBoDataProvider.Instance.
                    CheckSameAccountBookByIdNhanVienAndIdKho(ChungTu.IdNhanVien, ChungTu.IdKho);
            }
        }

        protected override bool ThietLapBaoHanhHang()
        {
            return true;
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            int idPhieuNhap = NhapNoiBoDataProvider.Instance.GetIdPhieuNhapMuaLanCuoi(ChungTu.SoPO, ChungTu.SoRE, ChungTu.IdKho,
                                                           hangHoaInfo.IdSanPham);

            hangHoaInfo.IdPhieuNhap = idPhieuNhap == 0 ? ChungTuInfo.IdChungTu : idPhieuNhap;
            hangHoaInfo.IdPhieuXuat = 0;
            return true;
        }
    }
}
