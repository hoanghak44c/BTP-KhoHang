using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using QLBanHang.Modules.KhoHang.DAO;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class PurchaseOrderProvider
    {

        private static PurchaseOrderProvider instance;

        private PurchaseOrderProvider()
        {
        }

        public static PurchaseOrderProvider Instance
        {
            get { return instance ?? (instance = new PurchaseOrderProvider()); }
        }

        public void ClearTemporary(string inventoryOrg, string inventorySub, int userId)
        {
            PurchaseOrderDao.Instance.DeleteTmpNhapHangTG(inventoryOrg, inventorySub);

            PurchaseOrderDao.Instance.DeleteTmpNhapHangUser(inventoryOrg, inventorySub, userId);
        }

        public void ClearNhapHangHistory(string inventoryOrg, string inventorySub)
        {
            PurchaseOrderDao.Instance.DeleteLichSuNhapHang(inventoryOrg, inventorySub, LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP);
        }

        public void ClearTraHangHistory(string inventoryOrg, string inventorySub)
        {
            PurchaseOrderDao.Instance.DeleteLichSuNhapHang(inventoryOrg, inventorySub, LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP);
        }

        public void TransferToUserData(string inventoryOrg, string inventorySub, int userId)
        {
            PurchaseOrderDao.Instance.InsertTmpNhapHangUser(inventoryOrg, inventorySub, userId);
        }

        public void LogHistory(string inventoryOrg, string inventorySub, int loaiGiaoDich)
        {
            PurchaseOrderDao.Instance.InsertLichSuNhapHang(inventoryOrg, inventorySub, loaiGiaoDich);
        }

        public DateTime NhapHangLastUpdateDate(string inventoryOrg, string inventorySub)
        {
            return PurchaseOrderDao.Instance.GetLastUpdateDate(inventoryOrg, inventorySub,
                                                          LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP);
        }

        public DateTime TraHangLastUpdateDate(string inventoryOrg, string inventorySub)
        {
            return PurchaseOrderDao.Instance.GetLastUpdateDate(inventoryOrg, inventorySub,
                                                          LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP);
        }

        public int LockSession(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo, string soPO, string soPhieuNhap, DateTime transactionDate, DateTime ngayNhap)
        {
            PurchaseOrderDao.Session lockingSession = PurchaseOrderDao.Instance.
                    GetSessionLocking(inventoryOrg,
                                      inventorySub,
                                      loaiGiaoDichPo,
                                      soPO, soPhieuNhap,
                                      transactionDate,
                                      ngayNhap);

            if (lockingSession.LockAt != DateTime.MinValue && lockingSession.LockAt.AddHours(2) < CommonProvider.Instance.GetSysDate())
                return PurchaseOrderDao.Instance.LockSession(inventoryOrg, inventorySub, loaiGiaoDichPo, soPO,
                                                             soPhieuNhap,
                                                             transactionDate, ngayNhap, 1, lockingSession.LockAt);
            
            if (!String.IsNullOrEmpty(lockingSession.Account) && lockingSession.Account.ToLower() != Declare.UserName.ToLower())
            {
                throw new ManagedException(String.Format("Phiếu nhập này đang bị lock bởi người dùng {0} tại máy {1} lúc {2}",
                                                         lockingSession.Account, lockingSession.Machine, lockingSession.LockAt));
            }

            if (!String.IsNullOrEmpty(lockingSession.Machine) && !lockingSession.Machine.EndsWith("\\" + Dns.GetHostName().ToUpper()))
            {
                throw new ManagedException(String.Format("Phiếu nhập này đang bị lock bởi người dùng {0} tại máy {1} lúc {2}",
                                                         lockingSession.Account, lockingSession.Machine, lockingSession.LockAt));
            }

            if(!String.IsNullOrEmpty(lockingSession.Process))
            {
                lockingSession.Process = lockingSession.Process.Split(':')[0];

                if (lockingSession.Process != Process.GetCurrentProcess().Id.ToString())
                {
                    try
                    {
                        Process pr = Process.GetProcessById(Common.IntValue(lockingSession.Process));

                        if (pr.MainModule.ModuleName == Process.GetCurrentProcess().MainModule.ModuleName)
                        {
                            throw new ManagedException(
                                String.Format("Phiếu nhập này đang bị lock bởi người dùng {0} tại máy {1} lúc {2}",
                                              lockingSession.Account, lockingSession.Machine, lockingSession.LockAt));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is ArgumentException || ex is Win32Exception)
                            return PurchaseOrderDao.Instance.
                                LockSession(inventoryOrg, inventorySub, loaiGiaoDichPo,
                                            soPO, soPhieuNhap, transactionDate, ngayNhap, 1, lockingSession.LockAt);
                        
                        throw;
                    }
                }

                return PurchaseOrderDao.Instance.LockSession(inventoryOrg, inventorySub, loaiGiaoDichPo, soPO,
                                             soPhieuNhap,
                                             transactionDate, ngayNhap, 1, lockingSession.LockAt);

            }

            return PurchaseOrderDao.Instance.LockSession(inventoryOrg, inventorySub, loaiGiaoDichPo, soPO, soPhieuNhap,
                                                         transactionDate, ngayNhap, 0, lockingSession.LockAt);
        }

        public int UnLockSession(string inventoryOrg, string inventorySub, LoaiGiaoDichPO loaiGiaoDichPo, string soPO, string soPhieuNhap, DateTime transactionDate, DateTime ngayNhap)
        {
            return PurchaseOrderDao.Instance.UnLockSession(inventoryOrg, inventorySub, loaiGiaoDichPo, soPO, soPhieuNhap,
                                                           transactionDate, ngayNhap);
        }
    }
}