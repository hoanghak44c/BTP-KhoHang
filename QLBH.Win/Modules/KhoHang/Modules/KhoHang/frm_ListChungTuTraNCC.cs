using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.DongBoERP;
using QLBanHang.Modules.DongBoERP.Providers;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

// form frmListChungTuNhap
// Người tạo: Trần Tuấn Cường
// Ngày tạo : 25/05/2012
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ListChungTuTraNCC : DevExpress.XtraEditors.XtraForm
    {
        private DMTrungTamInfor currentTrungTam;
        private DMKhoInfo currentKho;
        public string PO;
        public string PhieuNhap;
        private string User;
        public DateTime NgayLap;
        List<tmp_NhapHang_UserInfo> lichitiet = new List<tmp_NhapHang_UserInfo>();
        public int OID = 0;
        private string NCC;
        public frm_ListChungTuTraNCC()
        {
            InitializeComponent();
        }

        #region CheckUser
        private bool CheckUser(string SoPO)
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            
           List<tmp_NhapHang_LogInfo> litest = tmp_NhapHang_LogDataProvider.GetNhapHangLogByUser(new tmp_NhapHang_LogInfo {SoPO = SoPO, SoPhieuNhap = PhieuNhap, LoaiGiaoDich = Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP)});
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
            lichitiet = tmp_NhapHang_UserProvider.GetTraHangUserInfor();
            dgvList.DataSource = null;
            dgvList.DataSource = lichitiet;
        }

        private void frm_ListChungTuNhap_Load(object sender, EventArgs e)
        {
            try
            {
                currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
                currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);
                //waiting complete
                //load chung tu
                clsUtils.NullColumnDateTimeGrid(repdtThoiGian);
                clsUtils.NullColumnDateTimeGrid(repdtNgayNhap);
                dteLastSync.DateTime = NhapHangProvider.TraHangLastUpdateDate(currentTrungTam.MaTrungTam, currentKho.MaKho);
                lichitiet = tmp_NhapHang_UserProvider.GetTraHangUserInfor();
                //for (int i = 0; i < lichitiet.Count; i++)
                //{
                //    ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(lichitiet[i].SoPO, lichitiet[i].SoPhieuNhap, Convert.ToInt32(TransactionType.TRA_LAI_PO), Declare.IdKho, lichitiet[i].NgayNhap);
                //    if (chungTuXuatNhapNccInfo != null)
                //    {
                //        if (chungTuXuatNhapNccInfo.TrangThai == 1)
                //        {
                //            lichitiet[i].Trangthai = "Chưa nhập đủ";
                //        }
                //        else
                //        {
                //            lichitiet[i].Trangthai = "Đã nhập đủ";
                //        }
                //    }
                //    else
                //    {
                //        lichitiet[i].Trangthai = "Chưa nhập";
                //    }
                //}
                dgvList.DataSource = lichitiet;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void SynsChungTuNhap()
        {
            try
            {
                ConnectionUtil.Instance.BeginTransaction();

                string inventoryOrg = currentTrungTam.MaTrungTam;
                string inventorySub = currentKho.MaKho;

                frmProgress.Instance.Description = "Đang xóa dữ liệu tạm...";

                NhapHangProvider.ClearTemporary(inventoryOrg, inventorySub, Declare.UserId);

                frmProgress.Instance.Value += 1;

                frmProgress.Instance.Description = "Đang đồng bộ dữ liệu...";

                bool success = false;

                if (dteLastSync.DateTime.AddDays(15) < CommonProvider.Instance.GetSysDate())
                    dteLastSync.DateTime = CommonProvider.Instance.GetSysDate().AddDays(-15);

                success =
                    BusinessSynchronize.Instance.ChungTuNhapNCCSync(inventoryOrg, inventorySub,
                                                                    dteLastSync.DateTime.ToString("yyyy/MM/dd HH:mm:ss"));

                if (success)
                {
                    frmProgress.Instance.Value += 1;

                    NhapHangProvider.TransferToUserData(inventoryOrg, inventorySub, Declare.UserId);

                    frmProgress.Instance.Value += 1;

                    frmProgress.Instance.Description = "Đang cập nhật lại lịch sử...";

                    NhapHangProvider.ClearTraHangHistory(inventoryOrg, inventorySub);

                    frmProgress.Instance.Value += 1;

                    NhapHangProvider.LogHistory(inventoryOrg, inventorySub,
                                                Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP));

                    ConnectionUtil.Instance.CommitTransaction();

                    LockControl.Unlock("SysnChungTuTraNCC");

                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                    frmProgress.Instance.Description = "Đã hoàn thành.";

                    Thread.CurrentThread.Join(2500);

                    frmProgress.Instance.IsCompleted = true;
                }
                else
                {
                    ConnectionUtil.Instance.RollbackTransaction();

                    LockControl.Unlock("SysnChungTuTraNCC");

                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                    frmProgress.Instance.Description = "Không đồng bộ được dữ liệu.";

                    Thread.CurrentThread.Join(2500);

                    frmProgress.Instance.IsCompleted = true;
                }
            }
            catch(Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();

                LockControl.Unlock("SysnChungTuTraNCC");

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
            PO = lichitiet[lichitiet.IndexOf(nh)].SoPO;
            PhieuNhap = lichitiet[lichitiet.IndexOf(nh)].SoPhieuNhap;
            User = lichitiet[lichitiet.IndexOf(nh)].NguoiNhap;
            NgayLap = lichitiet[lichitiet.IndexOf(nh)].NgayNhap;
            NCC = lichitiet[lichitiet.IndexOf(nh)].NCC;
        }

        private void btnNapDuLieu_Click(object sender, EventArgs e)
        {
            string functionName = "SysnChungTuTraNCC";
            try
            {
                LockControl.Lock(functionName);
                frmProgress.Instance.Text = "Đồng bộ dữ liệu";
                frmProgress.Instance.MaxValue = 5;
                frmProgress.Instance.DoWork(SynsChungTuNhap);
                lichitiet = tmp_NhapHang_UserProvider.GetTraHangUserInfor();
                //for (int i = 0; i < lichitiet.Count; i++)
                //{
                //    ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(lichitiet[i].SoPO, lichitiet[i].SoPhieuNhap, Convert.ToInt32(TransactionType.TRA_LAI_PO), Declare.IdKho, lichitiet[i].NgayNhap);
                //    if (chungTuXuatNhapNccInfo != null)
                //    {
                //        if (chungTuXuatNhapNccInfo.TrangThai == 1)
                //        {
                //            lichitiet[i].Trangthai = "Chưa nhập đủ";
                //        }
                //        else
                //        {
                //            lichitiet[i].Trangthai = "Đã nhập đủ";
                //        }
                //    }
                //    else
                //    {
                //        lichitiet[i].Trangthai = "Chưa nhập";
                //    }
                //}
                dgvList.DataSource = lichitiet;
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
                LockControl.Unlock(functionName);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif

                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GetValue();

                var nhapHangUserInfo = grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle) as tmp_NhapHang_UserInfo;

                if (nhapHangUserInfo != null && !String.IsNullOrEmpty(nhapHangUserInfo.SoPO) && CheckUser(nhapHangUserInfo.SoPO))
                {
                    tmp_NhapHang_LogInfo tmpNhapHangLogInfo =
                        new tmp_NhapHang_LogInfo
                            {
                                SoPO = nhapHangUserInfo.SoPO,
                                SoPhieuNhap = nhapHangUserInfo.SoPhieuNhap,
                                NguoiNhap = Declare.UserName,
                                LoaiGiaoDich =
                                    Convert.ToInt32(
                                        LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP)
                            };
                    
                    List<tmp_NhapHang_LogInfo> liNhapHang =
                        tmp_NhapHang_LogDataProvider.GetNhapHangLogBySoPO(tmpNhapHangLogInfo);
                    
                    if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser != 1)
                    {
                        if (liNhapHang.Count > 0)
                        {
                            tmp_NhapHang_LogDataProvider.Update(Declare.UserName, PO, PhieuNhap,
                                                                Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP), Declare.IdKho);
                        }
                        else
                        {
                            tmp_NhapHang_LogDataProvider.Insert(Declare.UserName, PO, PhieuNhap,
                                                                Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP), Declare.IdKho);
                        }
                    }
                    
                    ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                        PO, PhieuNhap, Convert.ToInt32(TransactionType.TRA_LAI_PO), Declare.IdKho, NgayLap, nhapHangUserInfo.IdChungTu);

                    if (chungTuXuatNhapNccInfo == null)
                    {
                        chungTuXuatNhapNccInfo = new ChungTuXuatNhapNccInfo
                        {
                            SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuTraHangMua),
                            NgayLap = NgayLap,
                            SoPO = PO,
                            SoPhieuNhap = PhieuNhap,
                            LoaiChungTu = Convert.ToInt32(TransactionType.TRA_LAI_PO),
                            IdDoiTuong = nhapHangUserInfo.IdDoiTuong,
                            NCC = nhapHangUserInfo.NCC
                        };
                    }

                    var frm = new frmChiTiet_ChungTuTraNCC(this, chungTuXuatNhapNccInfo, NgayLap);

                    frm.ShowDialog();

                    dgvList.Refresh();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvChiTiet.FocusedRowHandle != null)
                {
                    var nhapHangUserInfo = grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle) as tmp_NhapHang_UserInfo;
                    
                    ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                        nhapHangUserInfo.SoPO, nhapHangUserInfo.SoPhieuNhap,
                        Convert.ToInt32(TransactionType.TRA_LAI_PO), Declare.IdKho, 
                        nhapHangUserInfo.NgayNhap, nhapHangUserInfo.IdChungTu);

                    if (chungTuXuatNhapNccInfo != null)
                    {
                        OID = chungTuXuatNhapNccInfo.IdChungTu;
                    }
                    else
                    {
                        OID = 0;
                    }

                    frm_ListThongKeMaVach frm = new frm_ListThongKeMaVach(this, 2);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }
    }
}