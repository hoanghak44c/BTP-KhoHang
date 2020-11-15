using System;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.Modules.KhoHang.DAO
{
    public class PurchaseOrderDao : BaseDAO
    {

        private static PurchaseOrderDao instance;

        private PurchaseOrderDao()
        {
        }

        public static PurchaseOrderDao Instance
        {
            get { return instance ?? (instance = new PurchaseOrderDao()); }
        }

        public class Session
        {
            public int SID { get; set; }
            public string Process { get; set; }
            public string Machine { get; set; }
            public string Account { get; set; }
            public DateTime LockAt { get; set; }
        }

        private Session GetCurrentSession()
        {
            var currentSession = GetObjectCommand<Session>(
                @"select b.sid, b.process, b.machine
                        from v$process a, v$session b
                     where a.addr = b.paddr
                         and b.audsid = userenv('sessionid')");

            if (currentSession != null)
            {
                if (String.IsNullOrEmpty(currentSession.Machine))
                    currentSession.Machine = Declare.TenMay;

                currentSession.Account = Declare.UserName;
            }

            return currentSession;
        }

        public int LockSession(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo, 
            string soPO, string soPhieuNhap, DateTime transactionDate, DateTime ngayNhap, int lockForced, DateTime lockAt)
        {
            Session currentSession = GetCurrentSession();

            if(lockAt == DateTime.MinValue)

                return ExecuteCommand(
                    @"Update tbl_lichsu_nhaphang
                     set sessionid   = :sessionid,
                         processid   = :processid,
                         lockaccount = :lockaccount,
                         lockmachine = :lockmachine,
                         lockat = sysdate
                 where inventoryorg = :inventoryorg
                     and inventorysub = :inventorysub
                     and sopo = :sopo
                     and sophieunhap = :sophieunhap
                     and transaction_date = :transactiondate
                     and ngaynhap = :ngaynhap
                     and loaigiaodich = :loaigiaodich
                     and (sessionid is null or sessionid = :sessionid or :lockForced = 1)
                     and (processid is null or processid = :processid or :lockForced = 1)
                     and (lockaccount is null or lockaccount = :lockaccount or :lockForced = 1)
                     and (lockmachine is null or lockmachine = :lockmachine or :lockForced = 1)",
                    currentSession.SID, currentSession.Process, currentSession.Account, currentSession.Machine,
                    inventoryOrg,
                    inventorySub, soPO, soPhieuNhap, transactionDate, ngayNhap, Convert.ToInt32(loaiGiaoDichPo),
                    lockForced);

            return ExecuteCommand(
                @"Update tbl_lichsu_nhaphang
                     set sessionid   = :sessionid,
                         processid   = :processid,
                         lockaccount = :lockaccount,
                         lockmachine = :lockmachine,
                         lockat = localtimestamp
                 where inventoryorg = :inventoryorg
                     and inventorysub = :inventorysub
                     and sopo = :sopo
                     and sophieunhap = :sophieunhap
                     and transaction_date = :transactiondate
                     and ngaynhap = :ngaynhap
                     and loaigiaodich = :loaigiaodich
                     and lockat = :lockat
                     and (sessionid is null or sessionid = :sessionid or :lockForced = 1)
                     and (processid is null or processid = :processid or :lockForced = 1)
                     and (lockaccount is null or lockaccount = :lockaccount or :lockForced = 1)
                     and (lockmachine is null or lockmachine = :lockmachine or :lockForced = 1)",
                currentSession.SID, currentSession.Process, currentSession.Account, currentSession.Machine,
                inventoryOrg,
                inventorySub, soPO, soPhieuNhap, transactionDate, ngayNhap, Convert.ToInt32(loaiGiaoDichPo), lockAt,
                lockForced);

        }

        public Session GetSessionLocking(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo, string soPO, string soPhieuNhap, DateTime transactionDate, DateTime ngayNhap)
        {
            return
                GetObjectCommand<Session>(
                    @"select sessionid   sid,
			                 processid   process,
			                 lockmachine machine,
			                 lockaccount account,
			                 lockat
	                from tbl_lichsu_nhaphang
                 where inventoryorg = :inventoryorg
	                 and inventorysub = :inventorysub
	                 and sopo = :sopo
	                 and sophieunhap = :sophieunhap
	                 and transaction_date = :transactiondate
	                 and ngaynhap = :ngaynhap
	                 and loaigiaodich = :loaigiaodich
                     and rownum = 1",
                    inventoryOrg, inventorySub, soPO, soPhieuNhap, transactionDate, ngayNhap,
                    Convert.ToInt32(loaiGiaoDichPo));
        }

        public int UnLockSession(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo, string soPO, string soPhieuNhap, DateTime transactionDate, DateTime ngayNhap)
        {
            Session currentSession = GetCurrentSession();

            return ExecuteCommand(
                @"Update tbl_lichsu_nhaphang
                     set sessionid   = null,
                         processid   = null,
                         lockaccount = null,
                         lockmachine = null,
                         lockat      = null
                 where inventoryorg = :inventoryorg
                     and inventorysub = :inventorysub
                     and sopo = :sopo
                     and sophieunhap = :sophieunhap
                     and transaction_date = :transactiondate
                     and ngaynhap = :ngaynhap
                     and loaigiaodich = :loaigiaodich
                     and sessionid   = :sessionid
                     and processid   = :processid
                     and lockaccount = :lockaccount
                     and lockmachine = :lockmachine",
                inventoryOrg, inventorySub, soPO, soPhieuNhap, transactionDate, ngayNhap, Convert.ToInt32(loaiGiaoDichPo),
                currentSession.SID, currentSession.Process, currentSession.Account, currentSession.Machine);
        }

        public void DeleteTmpNhapHangTG(string inventoryOrg, string inventorySub)
        {
            ExecuteCommand(
                @"DELETE FROM tbl_Tmp_NhapHang@qlbh_ta
                     WHERE InventoryOrg = :InventoryOrg
	                     AND InventorySub = :InventorySub",
                inventoryOrg, inventorySub);
        }

        public void DeleteTmpNhapHangUser(string inventoryOrg, string inventorySub, int userId)
        {
            ExecuteCommand(
                @"DELETE FROM tbl_Tmp_NhapHang_User
                     WHERE InventoryOrg = :InventoryOrg
	                     AND InventorySub = :InventorySub
	                     AND UserId = :UserId",
                inventoryOrg, inventorySub, userId);
        }

        public void DeleteLichSuNhapHang(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo)
        {
            ExecuteCommand(
                @"DELETE FROM tbl_Tmp_NhapHang@qlbh_ta t
                     WHERE exists
	                     (SELECT TransactionID
			                    FROM tbl_LichSu_NhapHang
		                     WHERE InventoryOrg = :InventoryOrg
                                AND InventorySub = :InventorySub
                                AND LoaiGiaoDich = :LoaiGiaoDich
                                AND TransactionID = t.TransactionID)",
                inventoryOrg, inventorySub, Convert.ToInt32(loaiGiaoDichPo));
        }

        public DateTime GetLastUpdateDate(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo)
        {
            return
                GetObjectCommand<DateTime>(
                    @"SELECT MAX(Last_Update_Date)
	                    FROM tbl_LichSu_NhapHang
                     WHERE InventoryOrg = :InventoryOrg
	                     AND InventorySub = :InventorySub
	                     AND LoaiGiaoDich = :LoaiGiaoDich",
                    inventoryOrg, inventorySub, Convert.ToInt32(loaiGiaoDichPo));
        }

        public void InsertTmpNhapHangUser(string inventoryOrg, string inventorySub, int userId)
        {
            ExecuteCommand(
                    @"INSERT INTO tbl_Tmp_NhapHang_User
	                    (INVENTORYORG,
	                     INVENTORYSUB,
	                     SOPO,
	                     SOPHIEUNHAP,
	                     NGAYNHAP,
	                     GHICHU,
	                     THOIGIAN,
	                     MASANPHAM,
	                     SOLUONG,
	                     DONGIA,
	                     THANHTIEN,
	                     MADOITUONG,
	                     TENDOITUONG,
	                     LOAIGIAODICH,
	                     LAST_UPDATE_DATE,
	                     BONUSBAOHANH,
	                     TRANSACTIONID,
	                     TRANSACTION_DATE,
	                     FLAG,
	                     USERID,
	                     CTCKLIENQUAN,
	                     CTCKLIENQUAN_TEN,
	                     CTCKLIENQUAN_TIEN,
	                     USERNAME_NHAPORC,
	                     FULLNAME_NHAPORC,
	                     CTCKLIENQUAN_SP,
	                     FULLNAME_BUYER)
	                    SELECT INVENTORYORG,
		                     INVENTORYSUB,
		                     SOPO,
		                     SOPHIEUNHAP,
		                     NGAYNHAP,
		                     GHICHU,
		                     THOIGIAN,
		                     MASANPHAM,
		                     SOLUONG,
		                     DONGIA,
		                     THANHTIEN,
		                     MADOITUONG,
		                     TENDOITUONG,
		                     LOAIGIAODICH,
		                     LAST_UPDATE_DATE,
		                     BONUSBAOHANH,
		                     TRANSACTIONID,
		                     TRANSACTION_DATE,
		                     FLAG,
		                     :UserId AS UserId,
		                     CTCKLIENQUAN,
		                     CTCKLIENQUAN_TEN,
		                     CTCKLIENQUAN_TIEN,
		                     USERNAME_NHAPORC,
		                     FULLNAME_NHAPORC,
		                     CTCKLIENQUAN_SP,
		                     FULLNAME_BUYER
		                    FROM tbl_Tmp_NhapHang@qlbh_ta TEMP
	                     WHERE InventoryOrg = :InventoryOrg
		                     AND InventorySub = :InventorySub",
                    userId, inventoryOrg, inventorySub);
        }

        public void InsertLichSuNhapHang(string inventoryOrg, string inventorySub, int loaiGiaoDich)
        {
            ExecuteCommand(
                @"insert into tbl_lichsu_nhaphang
	                (inventoryorg,
	                 inventorysub,
	                 sopo,
	                 sophieunhap,
	                 ngaynhap,
	                 ghichu,
	                 thoigian,
	                 masanpham,
	                 soluong,
	                 dongia,
	                 thanhtien,
	                 madoituong,
	                 tendoituong,
	                 loaigiaodich,
	                 last_update_date,
	                 bonusbaohanh,
	                 transactionid,
	                 transaction_date,
	                 ctcklienquan,
	                 ctcklienquan_ten,
	                 ctcklienquan_tien,
	                 username_nhaporc,
	                 fullname_nhaporc,
	                 ctcklienquan_sp,
	                 fullname_buyer)
	                select inventoryorg,
		                 inventorysub,
		                 sopo,
		                 sophieunhap,
		                 transaction_date ngaynhap,
		                 ghichu,
		                 thoigian,
		                 masanpham,
		                 soluong,
		                 dongia,
		                 thanhtien,
		                 madoituong,
		                 tendoituong,
		                 loaigiaodich,
		                 last_update_date,
		                 bonusbaohanh,
		                 transactionid,
		                 transaction_date,
		                 ctcklienquan,
		                 ctcklienquan_ten,
		                 ctcklienquan_tien,
		                 username_nhaporc,
		                 fullname_nhaporc,
		                 ctcklienquan_sp,
		                 fullname_buyer
		                from tbl_Tmp_NhapHang@qlbh_ta
	                 WHERE InventoryOrg = :InventoryOrg
		                 AND InventorySub = :InventorySub
		                 AND LoaiGiaoDich = :LoaiGiaoDich",
                inventoryOrg, inventorySub, loaiGiaoDich);
        }
    }
}