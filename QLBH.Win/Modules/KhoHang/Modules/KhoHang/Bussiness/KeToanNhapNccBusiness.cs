using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang.Bussiness
{
    public class KeToanNhapNccBusiness : ChungTuNhapKeToanBusinessBase<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo>
    {
        public KeToanNhapNccBusiness(ChungTuXuatNhapNccInfo chungTuXuatNhapInfo)
            : base(chungTuXuatNhapInfo)
        {
            if (chungTuXuatNhapInfo.LoaiChungTu != Convert.ToInt32(TransactionType.NHAP_PO))
            {
                throw new ManagedException("Không phải loại chứng từ nhập từ nhà cung cấp");
            }
        }

        protected override void CreateBusinessProvider()
        {
            BusinessKeToanKhoProvider = KeToanNhapNccDataProvider.Instance;
        }
    }
}
