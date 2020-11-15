using System;

namespace QLBanHang.Modules.KhoHang.Infors
{
    [Serializable]
    public class LichSuNhapHangInfo
    {
        public string INVENTORYORG { get; set; }
        public string INVENTORYSUB { get; set; }
        public string SOPO { get; set; }
        public string SOPHIEUNHAP { get; set; }
        public DateTime NGAYNHAP { get; set; }
        public string GHICHU { get; set; }
        public DateTime THOIGIAN { get; set; }
        public string MASANPHAM { get; set; }
        public int SOLUONG { get; set; }
        public double DONGIA { get; set; }
        public double THANHTIEN { get; set; }
        public string MADOITUONG { get; set; }
        public string TENDOITUONG { get; set; }
        public int LOAIGIAODICH { get; set; }
        public DateTime LAST_UPDATE_DATE { get; set; }
        public string BONUSBAOHANH { get; set; }
        public string TRANSACTIONID { get; set; }
        public DateTime TRANSACTION_DATE { get; set; }
        public string SoChungTu { get; set; }
    }
}