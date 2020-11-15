using System;
using System.Collections.Generic;
using System.Text;
using QLBH.Core.Infors;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Infors
{
    public class ChungTuXuatNhapNccInfo : ChungTuBaseInfo
    {
        private string soPhieuNhap;
        private string _SoPO;
        public string SoPO
        {
            get { return _SoPO; }
            set {
                if (_SoPO !=value)
                {
                    NotifyChange();
                }
                _SoPO = value;
            }
        }

        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set
            {
                if (_GhiChu != value)
                {
                    NotifyChange();
                }
                _GhiChu = value;
            }
        }
        public string NguoiNhap { get; set; }

        private int _idDoiTuong;

        public int IdDoiTuong
        {
            get { return _idDoiTuong; }
            set
            {
                if (_idDoiTuong != value) NotifyChange();
                _idDoiTuong = value;
            }
        }

        public string SoPhieuNhap
        {
            get { return soPhieuNhap; }
            set
            {
                if (soPhieuNhap != value) NotifyChange();
                soPhieuNhap = value;
            }
        }

        public int TransactionID { get; set; }

        public DateTime NgayXuatHang { get; set; }
        public string NCC { get; set; }
        public DateTime NgayHenGiaoHang { get; set; }
        public string FullNameNhap { get; set; }
        public string TenCTCK { get; set; }
        public string TienCTCK { get; set; }
    }
}
