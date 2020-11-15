using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.DongBoERP;
using QLBanHang.Modules.DongBoERP.Providers;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBH.Core.Providers;

// form frmListChungTuNhap
// Người tạo: Trần Tuấn Cường
// Ngày tạo : 25/05/2012
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ListChungTuNhap : DevExpress.XtraEditors.XtraForm
    {
        public int OID = 0;
        private DMTrungTamInfor currentTrungTam;
        private DMKhoInfo currentKho;
        public string PO;
        public string PhieuNhap;
        public DateTime NgayLap;
        List<tmp_NhapHang_UserInfo> lstDataSource;

        public frm_ListChungTuNhap()
        {
            InitializeComponent();

            lstDataSource = new List<tmp_NhapHang_UserInfo>();
            
            dgvList.DataSource = lstDataSource;
        }

        #region CheckUser
        private bool CheckUser(string SoPO)
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;

            List<tmp_NhapHang_LogInfo> litest =
                tmp_NhapHang_LogDataProvider.GetNhapHangLogByUser(
                    new tmp_NhapHang_LogInfo
                        {
                            SoPO = SoPO,
                            SoPhieuNhap = PhieuNhap,
                            LoaiGiaoDich =
                                Convert.ToInt32(
                                    LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP)
                        });

            if (litest.Count > 0)
            {
                if (litest[0].NguoiNhap == null || litest[0].NguoiNhap == Declare.UserName)
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        #endregion

        public void Reload()
        {
            frmProgress.Instance.DoWork(LoadDuLieu);
        }

        private void frm_ListChungTuNhap_Load(object sender, EventArgs e)
        {
            frmProgress.Instance.DoWork(
                delegate
                    {
                        try
                        {
                            //waiting complete
                            //load chung tu
                            currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);

                            currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);

                            if(currentKho.IdTrungTam != currentTrungTam.IdTrungTam)
                            {
                                throw new ManagedException("Thiết lập trung tâm và kho làm việc hiện tại không hợp lệ, đề nghị bạn thiết lập lại.");
                            }

                            Invoke((MethodInvoker)
                                   delegate
                                   {
                                       dteLastSync.EditValue =
                                           NhapHangProvider.NhapHangLastUpdateDate(
                                               currentTrungTam.MaTrungTam, currentKho.MaKho);

                                       clsUtils.NullColumnDateTimeGrid(repdtNgayNhap);
                                       clsUtils.NullColumnDateTimeGrid(repdtThoiGian);
                                       clsUtils.NullColumnDateTimeGrid(repdtNgayNhapMa);
                                   });

                            LoadDuLieu();
                        }
                        catch (ManagedException ex)
                        {
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                            frmProgress.Instance.IsCompleted = true;
                            MessageBox.Show(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                            frmProgress.Instance.IsCompleted = true;
                            EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), Name);
                        }
                    });
        }

        private bool isComplete;

        private void SynsChungTuNhap()
        {
            try
            {
                ConnectionUtil.Instance.BeginTransaction();

                string inventoryOrg = currentTrungTam.MaTrungTam;

                string inventorySub = currentKho.MaKho;

                frmProgress.Instance.Caption = Text;

                frmProgress.Instance.MaxValue = 5;

                frmProgress.Instance.Description = "Đang xóa dữ liệu tạm...";

                PurchaseOrderProvider.Instance.ClearTemporary(inventoryOrg, inventorySub, Declare.UserId);

                frmProgress.Instance.Value += 1;

                frmProgress.Instance.Description = "Đang đồng bộ dữ liệu...";

                bool success = false;

                if (dteLastSync.DateTime.AddDays(15) < CommonProvider.Instance.GetSysDate())

                    dteLastSync.DateTime = CommonProvider.Instance.GetSysDate().AddDays(-15);

                success = BusinessSynchronize.Instance.ChungTuNhapNCCSync(inventoryOrg, inventorySub,
                                                                          dteLastSync.DateTime.ToString(
                                                                              "yyyy/MM/dd hh:mm:ss"));
                if(success)
                {
                    frmProgress.Instance.Value += 1;

                    PurchaseOrderProvider.Instance.TransferToUserData(inventoryOrg, inventorySub, Declare.UserId);

                    frmProgress.Instance.Value += 1;

                    frmProgress.Instance.Description = "Đang cập nhật lại lịch sử...";

                    PurchaseOrderProvider.Instance.ClearNhapHangHistory(inventoryOrg, inventorySub);

                    frmProgress.Instance.Value += 1;

                    PurchaseOrderProvider.Instance.LogHistory(inventoryOrg, inventorySub,
                                                              Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP));

                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                    
                    frmProgress.Instance.Description = "Đã đồng bộ xong.";

                    ConnectionUtil.Instance.CommitTransaction();

                    LockControl.Unlock("SysnChungTuNhap", currentKho.IdKho);

                    LoadDuLieu();

                    Thread.CurrentThread.Join(2500);

                    frmProgress.Instance.IsCompleted = true;

                } 
                else
                {
                    ConnectionUtil.Instance.RollbackTransaction();

                    LockControl.Unlock("SysnChungTuNhap", currentKho.IdKho);

                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                    frmProgress.Instance.Description = "Không đồng bộ được dữ liệu!!!";

                    Thread.CurrentThread.Join(2500);

                    frmProgress.Instance.IsCompleted = true;
                }
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();

                LockControl.Unlock("SysnChungTuNhap", currentKho.IdKho);

                EventLogProvider.Instance.
                    WriteOfflineLog(ex
                                    + "\nUser: " + Declare.UserName
                                    + "\nKho: " + Declare.IdKho,
                                    this.Name);

                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                frmProgress.Instance.Description = "Không hoàn thành!!!";

                Thread.CurrentThread.Join(2500);

                frmProgress.Instance.IsCompleted = true;

            }
        }

        private void GetValue()
        {
            tmp_NhapHang_UserInfo nh = (tmp_NhapHang_UserInfo) grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);
            PO = nh.SoPO;
            PhieuNhap = nh.SoPhieuNhap;
            NgayLap = nh.NgayNhap;
        }

        private void ChiTiet()
        {
            OID = 0;
            GetValue();

            var nhapHangUserInfo = (tmp_NhapHang_UserInfo)grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);

            if (nhapHangUserInfo.IdDoiTuong == 0)
            {
                throw new ManagedException("Không tìm thấy mã nhà cung cấp trong hệ thống! Đề nghị Data kiểm tra lại.");
            }

            if (!String.IsNullOrEmpty(PO)) //&& CheckUser(PO)
            {
                if (PurchaseOrderProvider.Instance.LockSession(
                    currentTrungTam.MaTrungTam, currentKho.MaKho,
                    LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP, PO, PhieuNhap, nhapHangUserInfo.TransactionDate, nhapHangUserInfo.NgayNhap) == 0)
                {
                    throw new ManagedException("Phiếu nhập này đang bị lock bởi người dùng khác, không thể thực hiện được.");
                }

                tmp_NhapHang_LogInfo tmpNhapHangLogInfo =
                    new tmp_NhapHang_LogInfo
                        {
                            SoPO = PO,
                            SoPhieuNhap = PhieuNhap,
                            NguoiNhap = Declare.UserName,
                            LoaiGiaoDich =
                                Convert.ToInt32(
                                    LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP),
                        };

                List<tmp_NhapHang_LogInfo> liNhapHang =
                    tmp_NhapHang_LogDataProvider.GetNhapHangLogBySoPO(tmpNhapHangLogInfo);

                if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser != 1)
                {
                    if (liNhapHang.Count > 0)
                    {
                        tmp_NhapHang_LogDataProvider.Update(Declare.UserName, PO, PhieuNhap,
                                                            Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), Declare.IdKho);
                    }
                    else
                    {
                        tmp_NhapHang_LogDataProvider.Insert(Declare.UserName, PO, PhieuNhap,
                                                            Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), Declare.IdKho);
                    }
                }

                ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                    PO, PhieuNhap, Convert.ToInt32(TransactionType.NHAP_PO), Declare.IdKho, NgayLap, nhapHangUserInfo.IdChungTu);

                ChungTuXuatNhapNccInfo chungtu = tblChungTuDataProvider.GetLichSuChungTuNhapNCCFromSoPO(PO, PhieuNhap,
                                                                                                        Declare.IdKho,
                                                                                                        NgayLap);
                if (chungTuXuatNhapNccInfo == null)
                {
                    chungTuXuatNhapNccInfo = new ChungTuXuatNhapNccInfo
                    {
                        SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapHangMua),
                        NgayLap = NgayLap,
                        SoPO = PO,
                        SoPhieuNhap = PhieuNhap,
                        LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_PO),
                        IdDoiTuong = nhapHangUserInfo.IdDoiTuong,
                        NguoiNhap = nhapHangUserInfo.NguoiNhap,
                        NCC = nhapHangUserInfo.NCC
                    };
                }

                Form frm;

                if(ConnectionUtil.Instance.IsUAT == 1)

                    frm = new frmChiTietChungTuNhapNcc(this, chungTuXuatNhapNccInfo, NgayLap,
                                                       chungtu.FullNameNhap, chungtu.TenCTCK,
                                                       chungtu.TienCTCK);
                else

                    frm = new frmChiTietChungTuNhapNcc2(this, chungTuXuatNhapNccInfo, NgayLap,
                                                       chungtu.FullNameNhap, chungtu.TenCTCK,
                                                       chungtu.TienCTCK);

                if (frm.ShowDialog() == DialogResult.OK)
                    frmProgress.Instance.DoWork(LoadDuLieu);

                PurchaseOrderProvider.Instance.UnLockSession(
                    currentTrungTam.MaTrungTam, currentKho.MaKho,
                    LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP, PO, PhieuNhap, nhapHangUserInfo.TransactionDate, nhapHangUserInfo.NgayNhap);

            }
            else
            {
                throw new ManagedException("Phiếu đã có người truy cập !");
            }
        }

        private void btnNapDuLieu_Click(object sender, EventArgs e)
        {
            string functionName = "SysnChungTuNhap";

            try
            {
                LockControl.Lock(functionName);

                isComplete = true;

                frmProgress.Instance.DoWork(SynsChungTuNhap);

            }
            catch (ManagedException ex)
            {
                LockControl.Unlock(functionName);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteOfflineLog(ex
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    Name);

                LockControl.Unlock(functionName);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ChiTiet();
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (grvChiTiet.FocusedRowHandle != null)
            {
                var nhapHangUserInfo = grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle) as tmp_NhapHang_UserInfo;

                ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                        nhapHangUserInfo.SoPO, nhapHangUserInfo.SoPhieuNhap,
                        Convert.ToInt32(TransactionType.NHAP_PO), Declare.IdKho, nhapHangUserInfo.NgayNhap, nhapHangUserInfo.IdChungTu);
                if (chungTuXuatNhapNccInfo != null)
                {
                    OID = chungTuXuatNhapNccInfo.IdChungTu;
                }
                else
                {
                    OID = 0;
                    MessageBox.Show("PO này chưa được nhập mã vạch chi tiết");
                    return;
                }

                frm_ListThongKeMaVach frm = new frm_ListThongKeMaVach(this,1);
                frm.ShowDialog();
            }
        }

        private void AutoGenChungTu1()
        {
            NhapNccBusiness khoBusiness;
            int code = 0;
            DMKhoInfo dmKhoInfo = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);
            foreach (tmp_NhapHang_UserInfo tmpNhapHangUserInfo in lstDataSource)
            {
                frmProgress.Instance.Value += 1;
                ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                    tmpNhapHangUserInfo.SoPO, tmpNhapHangUserInfo.SoPhieuNhap,
                    Convert.ToInt32(TransactionType.NHAP_PO), Declare.IdKho, NgayLap, tmpNhapHangUserInfo.IdChungTu);

                if (chungTuXuatNhapNccInfo == null)
                {
                    chungTuXuatNhapNccInfo = new ChungTuXuatNhapNccInfo
                    {
                        SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapHangMua),
                        NgayLap = tmpNhapHangUserInfo.NgayNhap,
                        SoPO = tmpNhapHangUserInfo.SoPO,
                        SoPhieuNhap = tmpNhapHangUserInfo.SoPhieuNhap,
                        LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_PO),
                        IdDoiTuong = tmpNhapHangUserInfo.IdDoiTuong,
                        IdKho = Declare.IdKho
                    };
                }

                khoBusiness = new NhapNccBusiness(chungTuXuatNhapNccInfo);

                if(chungTuXuatNhapNccInfo.IdChungTu == 0)
                {
                    khoBusiness.ListChiTietChungTu = KeToanNhapNccDataProvider.Instance.GetListNhapHangUserInfoFromOid(khoBusiness.ChungTu.SoPO, khoBusiness.ChungTu.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP),
                        khoBusiness.ChungTu.NgayLap, chungTuXuatNhapNccInfo.IdChungTu);

                    foreach (ChungTuXuatNhapNccChiTietInfo chungTuXuatNhapNccChiTietInfo in khoBusiness.ListChiTietChungTu)
                    {
                        if (khoBusiness.ListChiTietHangHoa.Exists(delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                        {
                            return match.IdSanPham == chungTuXuatNhapNccChiTietInfo.IdSanPham &&
                              match.TransactionID == chungTuXuatNhapNccChiTietInfo.TransactionID;
                        })) continue;

                        //import ma vach tu file

                        dvFillter.RowFilter = String.Format("SoPO='{0}' and SoPhieuNhap='{1}' and MaSanPham='{2}' and MaKho='{3}'",
                            chungTuXuatNhapNccInfo.SoPO, chungTuXuatNhapNccInfo.SoPhieuNhap, chungTuXuatNhapNccChiTietInfo.MaSanPham, dmKhoInfo.MaKho);

                        DataTable dtTemp = dvFillter.ToTable();
                        foreach (DataRow dataRow in dtTemp.Rows)
                        {
                            ChungTuNhapNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo =
                                new ChungTuNhapNccChiTietHangHoaInfo
                                {
                                    DonGia = 0,
                                    IdChungTuChiTiet = 0,
                                    IdSanPham = chungTuXuatNhapNccChiTietInfo.IdSanPham,
                                    TransactionID =
                                        chungTuXuatNhapNccChiTietInfo.TransactionID
                                };
                            chungTuNhapNccChiTietHangHoaInfo.MaVach = Convert.ToString(dataRow["MaVach"]);
                            chungTuNhapNccChiTietHangHoaInfo.SoLuong = Convert.ToInt32(dataRow["SoLuong"]);
                            khoBusiness.ListChiTietHangHoa.Add(chungTuNhapNccChiTietHangHoaInfo);
                        }
                        #region Auto gen mavach
                        //tu sinh ma vach

                        //for (int i = 0; i < chungTuXuatNhapNccChiTietInfo.SoLuong; i++)
                        //{
                        //    ChungTuNhapNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo =
                        //        new ChungTuNhapNccChiTietHangHoaInfo
                        //            {
                        //                DonGia = 0,
                        //                IdChungTuChiTiet = 0,
                        //                IdSanPham = chungTuXuatNhapNccChiTietInfo.IdSanPham,
                        //                TransactionID =
                        //                    chungTuXuatNhapNccChiTietInfo.TransactionID,
                        //                SoLuong =
                        //                    chungTuXuatNhapNccChiTietInfo.TrungMaVach == 0
                        //                        ? 1
                        //                        : chungTuXuatNhapNccChiTietInfo.SoLuong,
                        //                MaVach =
                        //                    chungTuXuatNhapNccChiTietInfo.MaSanPham + Declare.IdKho + DateTime.Now.Day +
                        //                    code.ToString().PadLeft(5, '0')
                        //            };
                            
                        //    khoBusiness.ListChiTietHangHoa.Add(chungTuNhapNccChiTietHangHoaInfo);
                            
                            //code += 1;

                            //if (chungTuXuatNhapNccChiTietInfo.TrungMaVach == 1)
                            //{
                            //    break;
                            //}
                            //else
                            //{
                            //    HangHoa_ChiTietInfo hangHoaChiTietInfo = TblHangHoaChiTietDataProvider.GetHangHoaChiTietByMaVach(Declare.IdKho,
                            //                                                            chungTuXuatNhapNccChiTietInfo.
                            //                                                                IdSanPham,
                            //                                                            chungTuNhapNccChiTietHangHoaInfo
                            //                                                                .MaVach, 0);
                            //    if (hangHoaChiTietInfo != null)
                            //    {
                            //        chungTuNhapNccChiTietHangHoaInfo.MaVach =
                            //            chungTuXuatNhapNccChiTietInfo.MaSanPham + Declare.IdKho + DateTime.Now.Day +
                            //            code.ToString().PadLeft(5, '0');
                            //        code += 1;
                            //    }
                            //}
                        //}
                        #endregion
                    }
                    try
                    {
                        if (khoBusiness.ListChiTietHangHoa.Count > 0)
                        {
                            khoBusiness.SaveChungTu();
                        }
                        else
                        {
                            File.AppendAllText(Application.StartupPath + "\\ChuaNhapMaVachResult.txt", "\n"
                                + " - SoChungTu: " + chungTuXuatNhapNccInfo.SoChungTu 
                                + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                        }
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(Application.StartupPath + "\\ImportResult.txt", "\n" + ex.Message
                            + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                    }
                }
                else //if (khoBusiness.ListChiTietHangHoa.Count == 0)
                {
                    DataTable dtTemp = null;
                    foreach (ChungTuXuatNhapNccChiTietInfo chungTuXuatNhapNccChiTietInfo in khoBusiness.ListChiTietChungTu)
                    {
                        if (khoBusiness.GetListChiTietHangHoaByIdSanPham(chungTuXuatNhapNccChiTietInfo.IdSanPham).Count < chungTuXuatNhapNccChiTietInfo.SoLuong)
                        {
                            dvFillter.RowFilter = String.Format("SoPO='{0}' and SoPhieuNhap='{1}' and MaSanPham='{2}' and MaKho='{3}'",
                                chungTuXuatNhapNccInfo.SoPO, chungTuXuatNhapNccInfo.SoPhieuNhap, chungTuXuatNhapNccChiTietInfo.MaSanPham, dmKhoInfo.MaKho);
                            
                            dtTemp = dvFillter.ToTable();
                            foreach (DataRow dataRow in dtTemp.Rows)
                            {
                                string maVach = Convert.ToString(dataRow["MaVach"]);
                                if(khoBusiness.ListChiTietHangHoa.Exists(delegate (ChungTuNhapNccChiTietHangHoaInfo match)
                                                                           {
                                                                               return match.MaVach == maVach;
                                                                           }))
                                {
                                    continue;
                                }
                                ChungTuNhapNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo =
                                    new ChungTuNhapNccChiTietHangHoaInfo
                                    {
                                        DonGia = 0,
                                        IdChungTuChiTiet = 0,
                                        IdSanPham = chungTuXuatNhapNccChiTietInfo.IdSanPham,
                                        TransactionID =
                                            chungTuXuatNhapNccChiTietInfo.TransactionID
                                    };
                                chungTuNhapNccChiTietHangHoaInfo.MaVach = maVach;
                                chungTuNhapNccChiTietHangHoaInfo.SoLuong = Convert.ToInt32(dataRow["SoLuong"]);

                                khoBusiness.ListChiTietHangHoa.Add(chungTuNhapNccChiTietHangHoaInfo);
                            }
                        }
                    }
                    try
                    {
                        if (dtTemp != null && dtTemp.Rows.Count > 0 && khoBusiness.ListChiTietHangHoa.Count > 0)
                        {
                            khoBusiness.SaveChungTu();
                        }
                        else
                        {
                            //try
                            //{
                            //    khoBusiness.DeleteChungTu();
                            //    tmp_NhapHang_LogDataProvider.Delete(chungTuXuatNhapNccInfo.SoPO, chungTuXuatNhapNccInfo.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), Declare.IdKho);
                            //}
                            //catch (Exception)
                            //{
                            //    File.AppendAllText(Application.StartupPath + "\\ChuaNhapMaVachResult.txt", "\n"
                            //        + " - SoChungTu: " + chungTuXuatNhapNccInfo.SoChungTu
                            //        + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(Application.StartupPath + "\\ImportResult.txt", "\n" + ex.Message
                            + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                    }
                }
            }
            frmProgress.Instance.Description = "Đã hoàn thành.";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
        }

        private void TryLock()
        {
            const int MAX_INTERVAL = 10;
            int interval = MAX_INTERVAL;
            
            bool isLocked= false;
            
            while (!isLocked)
            {
                try
                {
                    frmProgress.Instance.Description = currentKho.MaKho + ": Đang thử lại...";
                    LockControl.Lock("SysnChungTuNhap");
                    isLocked = true;
                    Thread.SpinWait(5000);
                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                }
                catch (ManagedException ex)
                {
                    frmProgress.Instance.Description = String.Format(ex.Message);
                    Thread.Sleep(2000);
                    frmProgress.Instance.MaxValue = MAX_INTERVAL;
                    frmProgress.Instance.Value = 0;
                    interval = MAX_INTERVAL;
                    while (interval > 0)
                    {
                        frmProgress.Instance.Description = String.Format(currentKho.MaKho + ": Sẽ thử lại trong vòng {0} giây nữa.", interval);
                        frmProgress.Instance.Value += 1;
                        interval -= 1;
                        Thread.Sleep(1000);
                    }
                }                
            }
        }

        private void AutoGenAllChungTu()
        {
            try
            {
                NhapNccBusiness khoBusiness;
                int code = 0;
                List<DMKhoInfo> listKho = DMKhoDataProvider.GetListDMKhoInfor();
                frmProgress.Instance.MaxValue = listKho.Count;
                frmProgress.Instance.Value = 0;
                foreach (DMKhoInfo dmKhoInfo in listKho)
                {
                    currentKho = dmKhoInfo;
                    currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(dmKhoInfo.IdTrungTam);
                    frmProgress.Instance.PushStatus();
                    TryLock();
                    frmProgress.Instance.PopStatus();
                    frmProgress.Instance.PushStatus();
                    frmProgress.Instance.MaxValue = 5;
                    frmProgress.Instance.Value = 0;
                    frmProgress.Instance.Description = currentKho.MaKho + ": Đang đồng bộ số liệu ... ";
                    isComplete = false;
                    SynsChungTuNhap();
                    frmProgress.Instance.PopStatus();
                    frmProgress.Instance.PushStatus();
                    frmProgress.Instance.Description = currentKho.MaKho + ": Đang import số liệu ...";
                    lstDataSource = tmp_NhapHang_UserProvider.GetNhapHangUserInfor(dmKhoInfo.IdKho);
                    frmProgress.Instance.MaxValue = lstDataSource.Count;
                    frmProgress.Instance.Value = 0;
                    foreach (tmp_NhapHang_UserInfo tmpNhapHangUserInfo in lstDataSource)
                    {
                        frmProgress.Instance.Value += 1;
                        ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                            tmpNhapHangUserInfo.SoPO, tmpNhapHangUserInfo.SoPhieuNhap, Convert.ToInt32(TransactionType.NHAP_PO),
                            currentKho.IdKho, NgayLap, tmpNhapHangUserInfo.IdChungTu);

                        if (chungTuXuatNhapNccInfo == null)
                        {
                            chungTuXuatNhapNccInfo = new ChungTuXuatNhapNccInfo
                            {
                                SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapHangMua),
                                NgayLap = tmpNhapHangUserInfo.NgayNhap,
                                SoPO = tmpNhapHangUserInfo.SoPO,
                                SoPhieuNhap = tmpNhapHangUserInfo.SoPhieuNhap,
                                LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_PO),
                                IdDoiTuong = tmpNhapHangUserInfo.IdDoiTuong,
                                IdKho = currentKho.IdKho
                            };
                        }

                        khoBusiness = new NhapNccBusiness(chungTuXuatNhapNccInfo);

                        if (chungTuXuatNhapNccInfo.IdChungTu == 0)
                        {
                            khoBusiness.ListChiTietChungTu = KeToanNhapNccDataProvider.Instance.GetListNhapHangUserInfoFromOid(khoBusiness.ChungTu.SoPO, khoBusiness.ChungTu.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), currentKho.IdKho);

                            foreach (ChungTuXuatNhapNccChiTietInfo chungTuXuatNhapNccChiTietInfo in khoBusiness.ListChiTietChungTu)
                            {
                                if (khoBusiness.ListChiTietHangHoa.Exists(delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                                {
                                    return match.IdSanPham == chungTuXuatNhapNccChiTietInfo.IdSanPham &&
                                      match.TransactionID == chungTuXuatNhapNccChiTietInfo.TransactionID;
                                })) continue;

                                //import ma vach tu file

                                dvFillter.RowFilter = String.Format("SoPO='{0}' and SoPhieuNhap='{1}' and MaSanPham='{2}' and MaKho='{3}'",
                                    chungTuXuatNhapNccInfo.SoPO, chungTuXuatNhapNccInfo.SoPhieuNhap, chungTuXuatNhapNccChiTietInfo.MaSanPham, dmKhoInfo.MaKho);

                                DataTable dtTemp = dvFillter.ToTable();
                                foreach (DataRow dataRow in dtTemp.Rows)
                                {
                                    ChungTuNhapNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo =
                                        new ChungTuNhapNccChiTietHangHoaInfo
                                        {
                                            DonGia = 0,
                                            IdChungTuChiTiet = 0,
                                            IdSanPham = chungTuXuatNhapNccChiTietInfo.IdSanPham,
                                            TransactionID =
                                                chungTuXuatNhapNccChiTietInfo.TransactionID
                                        };
                                    chungTuNhapNccChiTietHangHoaInfo.MaVach = Convert.ToString(dataRow["MaVach"]);
                                    chungTuNhapNccChiTietHangHoaInfo.SoLuong = Convert.ToInt32(dataRow["SoLuong"]);
                                    khoBusiness.ListChiTietHangHoa.Add(chungTuNhapNccChiTietHangHoaInfo);
                                }
                            }
                            try
                            {
                                if (khoBusiness.ListChiTietHangHoa.Count > 0)
                                {
                                    khoBusiness.SaveChungTu();
                                }
                                else
                                {
                                    File.AppendAllText(Application.StartupPath + "\\ChuaNhapMaVachResult.txt", "\n"
                                        + " - SoChungTu: " + chungTuXuatNhapNccInfo.SoChungTu
                                        + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                                }
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(Application.StartupPath + "\\ImportResult.txt", "\n" + ex.Message
                                    + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                            }
                        }
                        else //if (khoBusiness.ListChiTietHangHoa.Count == 0)
                        {
                            DataTable dtTemp = null;
                            foreach (ChungTuXuatNhapNccChiTietInfo chungTuXuatNhapNccChiTietInfo in khoBusiness.ListChiTietChungTu)
                            {
                                if (khoBusiness.GetListChiTietHangHoaByIdSanPham(chungTuXuatNhapNccChiTietInfo.IdSanPham).Count < chungTuXuatNhapNccChiTietInfo.SoLuong)
                                {
                                    dvFillter.RowFilter = String.Format("SoPO='{0}' and SoPhieuNhap='{1}' and MaSanPham='{2}' and MaKho='{3}'",
                                        chungTuXuatNhapNccInfo.SoPO, chungTuXuatNhapNccInfo.SoPhieuNhap, chungTuXuatNhapNccChiTietInfo.MaSanPham, dmKhoInfo.MaKho);

                                    dtTemp = dvFillter.ToTable();
                                    foreach (DataRow dataRow in dtTemp.Rows)
                                    {
                                        string maVach = Convert.ToString(dataRow["MaVach"]);
                                        if (khoBusiness.ListChiTietHangHoa.Exists(delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                                        {
                                            return match.MaVach == maVach;
                                        }))
                                        {
                                            continue;
                                        }
                                        ChungTuNhapNccChiTietHangHoaInfo chungTuNhapNccChiTietHangHoaInfo =
                                            new ChungTuNhapNccChiTietHangHoaInfo
                                            {
                                                DonGia = 0,
                                                IdChungTuChiTiet = 0,
                                                IdSanPham = chungTuXuatNhapNccChiTietInfo.IdSanPham,
                                                TransactionID =
                                                    chungTuXuatNhapNccChiTietInfo.TransactionID
                                            };
                                        chungTuNhapNccChiTietHangHoaInfo.MaVach = maVach;
                                        chungTuNhapNccChiTietHangHoaInfo.SoLuong = Convert.ToInt32(dataRow["SoLuong"]);

                                        khoBusiness.ListChiTietHangHoa.Add(chungTuNhapNccChiTietHangHoaInfo);
                                    }
                                }
                            }
                            try
                            {
                                if (dtTemp != null && dtTemp.Rows.Count > 0 && khoBusiness.ListChiTietHangHoa.Count > 0)
                                {
                                    khoBusiness.SaveChungTu();
                                }
                                else
                                {
                                    //try
                                    //{
                                    //    khoBusiness.DeleteChungTu();
                                    //    tmp_NhapHang_LogDataProvider.Delete(chungTuXuatNhapNccInfo.SoPO, chungTuXuatNhapNccInfo.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), Declare.IdKho);
                                    //}
                                    //catch (Exception)
                                    //{
                                    //    File.AppendAllText(Application.StartupPath + "\\ChuaNhapMaVachResult.txt", "\n"
                                    //        + " - SoChungTu: " + chungTuXuatNhapNccInfo.SoChungTu
                                    //        + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                                    //}
                                }
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(Application.StartupPath + "\\ImportResult.txt", "\n" + ex.Message
                                    + " - PO: " + chungTuXuatNhapNccInfo.SoPO + " - PN: " + chungTuXuatNhapNccInfo.SoPhieuNhap);
                            }
                        }
                    }
                    frmProgress.Instance.PopStatus();
                    frmProgress.Instance.Value += 1;
                }

                frmProgress.Instance.Description = "Đã hoàn thành.";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
            }
            catch (Exception ex)
            {
#if DEBUG
                if (isComplete) MessageBox.Show(ex.ToString());
#else
                if (isComplete) MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        DataSet dsMaVach;
        private DataView dvFillter;
        private void btnGenChungTuNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.FileName = String.Empty;
                //if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                //using (OleDbConnection oConn = new OleDbConnection())
                //{
                //    dsMaVach = new DataSet();
                //    oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", openFileDialog1.FileName);
                //    oConn.Open();

                //    sql = "Select SoPO, SoPhieuNhap, MaSanPham, TenSanPham, MaVach, SoLuong, DonGia, MaKho, MaTrungTam from [Items$]";

                //    using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                //    {
                //        ad.Fill(dsMaVach, "MaVach");
                //    }
                //    dvFillter = new DataView(dsMaVach.Tables["MaVach"]);
                //}

                sql = "select * from tbl_tmp_mavach@qlbh_ta";

                dsMaVach = SqlHelper.ExecuteDataset(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                dvFillter = new DataView(dsMaVach.Tables[0]);

                frmProgress.Instance.Description = "Đang sinh chứng từ nhập...";
                //frmProgress.Instance.DoWork(AutoGenAllChungTu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ChiTiet();
                }
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.DevExport2Excel(grvChiTiet);
        }

        private void bteNhaCungCap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhaCungCap frmLookUpNhaCungCap = new frmLookUp_NhaCungCap(String.Format("%{0}%", bteNhaCungCap.Text));
            if(frmLookUpNhaCungCap.ShowDialog() == DialogResult.OK)
            {
                bteNhaCungCap.Tag = frmLookUpNhaCungCap.SelectedItem;
                bteNhaCungCap.Text = frmLookUpNhaCungCap.SelectedItem.TenDoiTuong;
            }
        }

        private void bteNhaCungCap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhaCungCap frmLookUpNhaCungCap = new frmLookUp_NhaCungCap(String.Format("%{0}%", bteNhaCungCap.Text));
                if (frmLookUpNhaCungCap.ShowDialog() == DialogResult.OK)
                {
                    bteNhaCungCap.Tag = frmLookUpNhaCungCap.SelectedItem;
                    bteNhaCungCap.Text = frmLookUpNhaCungCap.SelectedItem.TenDoiTuong;
                }                
            }
        }

        private void bteNhaCungCap_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(bteNhaCungCap.Text))
            {
                bteNhaCungCap.Tag = null;
            }
        }

        private void LoadDuLieu()
        {
            frmProgress.Instance.Caption = Text;
            frmProgress.Instance.Description = "Đang nạp dữ liệu";
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.MaxValue = 3;
            lstDataSource.Clear();
            frmProgress.Instance.Value += 1;
            lstDataSource.AddRange(tmp_NhapHang_UserProvider.Search(
                txtSoPhieuNhap.Text,
                txtSoPO.Text,
                bteNhaCungCap.Tag == null
                    ? String.Empty
                    : ((DMDoiTuongInfo)bteNhaCungCap.Tag).MaDoiTuong));
            frmProgress.Instance.Value += 1;
            dgvList.RefreshDataSource();
            frmProgress.Instance.Description = "Đã xong";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
        }

        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            frmProgress.Instance.DoWork(LoadDuLieu);
        }
    }
}