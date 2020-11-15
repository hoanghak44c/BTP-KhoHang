using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Business.Calculations;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class XuatNoiBoBussiness : ChungTuXuatKhoBusinessBase<ChungTuXuatNoiBoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        public XuatNoiBoBussiness()
        {
            ChungTu = new ChungTuXuatNoiBoInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_NOI_BO),
                IdNhanVien = Declare.IdNhanVien,
                IdKho = Declare.IdKho
            };
        }

        public XuatNoiBoBussiness(ChungTuXuatNoiBoInfor chungTuXuatNoiBoInfor)
            : base(chungTuXuatNoiBoInfor)
        {
            if (chungTuXuatNoiBoInfor.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_NOI_BO))
            {
                throw new ManagedException("Không phải loại chứng từ xuất kho nội bộ");
            }
        }
        /// <summary>
        /// note: Truong hop khong tach quy trinh ke toan va kho rieng thi viet lai ham sau
        /// </summary>
        /// <param name="tonKhoInfo"></param>
        protected override void CreateTonKhoCalc(HangTonKhoInfo tonKhoInfo)
        {
            TonKhoCalc = new XuatTonCalc(tonKhoInfo, ChungTuInfo.SoChungTu, ChungTuInfo.NgayLap);
        }

        protected override bool IsOnTheSameAccountBook
        {
            get
            {
                return XuatNoiBoDataProvider.Instance.
                    CheckSameAccountBookByIdNhanVienAndIdKho(ChungTu.IdNhanVien, ChungTu.IdKho);
            }
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKhoProvider = XuatNoiBoDataProvider.Instance;
        }

        protected override bool ThietLapTuoiTon(HangHoa_ChiTietInfo hangHoaInfo)
        {
            hangHoaInfo.IdPhieuXuat = ChungTuInfo.IdChungTu;
            return true;
        }
    }
}
