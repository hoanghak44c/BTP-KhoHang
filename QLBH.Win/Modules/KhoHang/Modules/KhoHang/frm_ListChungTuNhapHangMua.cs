using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.DongBoERP.Providers;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBanHang.Modules.DanhMuc.Infors;

// form frmListChungTuNhap
// Người tạo: Trần Tuấn Cường
// Ngày tạo : 25/05/2012
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ListChungTuNhapHangMua : DevExpress.XtraEditors.XtraForm
    {
        public int OID = 0;
        private DMTrungTamInfor currentTrungTam;
        private DMKhoInfo currentKho;
        public string PO;
        public string PhieuNhap;
        public int IdChungTu;
        private string User;
        public DateTime NgayLap;
        

        public frm_ListChungTuNhapHangMua()
        {
            InitializeComponent();
        }

        #region CheckUser
        private bool CheckUser(string SoPO)
        {
           List<tmp_NhapHang_LogInfo> litest = tmp_NhapHang_LogDataProvider.GetNhapHangLogByUser(new tmp_NhapHang_LogInfo {SoPO = SoPO, SoPhieuNhap = PhieuNhap});
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

        private void frm_ListChungTuNhapHangMua_Load(object sender, EventArgs e)
        {
            //waiting complete
            //load chung tu
        }

        private void SynsChungTuNhap()
        {
            currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
            currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);

            string inventoryOrg = currentTrungTam.MaTrungTam;
            string inventorySub = currentKho.MaKho;

            frmProgress.Instance.Description = "Đang xóa dữ liệu tạm...";

            NhapHangProvider.ClearTemporary(inventoryOrg, inventorySub, Declare.UserId);
            
            frmProgress.Instance.Value += 1;

            frmProgress.Instance.Description = "Đang đồng bộ dữ liệu...";

            bool success = false;

            //success = BusinessSynchronize.Instance.ChungTuNhapNCCSync(inventoryOrg, inventorySub, NhapHangProvider.NhapHangLastUpdateDate(inventoryOrg, inventorySub));
            
            if (!success)
            {
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.Description = "Không hoàn thành.";
                frmProgress.Instance.IsCompleted = true;
                MessageBox.Show("Gọi webservice không thành công!");
                return;
            }

            frmProgress.Instance.Value += 1;

            NhapHangProvider.TransferToUserData(inventoryOrg, inventorySub, Declare.UserId);

            frmProgress.Instance.Value += 1;

            frmProgress.Instance.Description = "Đang cập nhật lại lịch sử...";

            NhapHangProvider.ClearNhapHangHistory(inventoryOrg, inventorySub);

            frmProgress.Instance.Value += 1;

            NhapHangProvider.LogHistory(inventoryOrg, inventorySub, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP));

            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.Description = "Đã hoàn thành.";
            frmProgress.Instance.IsCompleted = true;

            //sql = String.Format("SELECT COUNT(*) FROM tbl_Tmp_NhapHang WHERE MaSanPham NOT IN (SELECT MaSanPham FROM tbl_SanPham WHERE sudung=1) AND InventoryOrg='{0}' AND InventorySub='{1}'", inventoryOrg, inventorySub);
            ////sql += String.Format("AND SoPO=N'{0}' AND SoPhieuNhap=N'{1}'", txtSoPO.Text, txtPhieuNhap.Text);
            //object countNotMa = SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);
            //cmdShowNotMa.Visible = false;
            //if (Convert.ToInt32(countNotMa) > 0)
            //{
            //    cmdShowNotMa.Visible = true;
            //    cmdShowNotMa.Text = String.Format("{0} mặt hàng có mã không hợp lệ", countNotMa);
            //}

            //string sql = String.Format("SELECT t1.SoPhieuNhap, t1.SoPO, ct.IdChungTu, SUM(SoLuong) AS TongSoLuong, N'Hàng bán' AS TrangThai FROM tbl_Tmp_NhapHang t1 "
            //        + "LEFT OUTER JOIN tbl_ChungTu ct ON ct.SoChungTu=t1.SoPhieuNhap AND ct.SoSeri=t1.SoPO AND ct.LoaiChungTu={0} AND ct.IdKho={5} "
            //        + "AND (SELECT TOP (1) soluong FROM tbl_chungtu_chitiet WHERE tbl_chungtu_chitiet.idchungtu = ct.idchungtu)>=0 "
            //        + "WHERE InventoryOrg='{1}' AND InventorySub='{2}' AND ThoiGian < '{3}' AND ThoiGian > '{4}' AND SoLuong >= 0 GROUP BY SoPhieuNhap, SoPO, IdChungTu "
            //        + "UNION ALL "
            //        + "SELECT t1.SoPhieuNhap, t1.SoPO, ct.IdChungTu, SUM(SoLuong) AS TongSoLuong, N'Hàng trả lại' AS TrangThai FROM tbl_Tmp_NhapHang t1 "
            //        + "LEFT OUTER JOIN tbl_ChungTu ct ON ct.SoChungTu=t1.SoPhieuNhap AND ct.SoSeri=t1.SoPO AND ct.LoaiChungTu={0} AND ct.IdKho={5} "
            //        + "AND (SELECT TOP (1) soluong FROM tbl_chungtu_chitiet WHERE tbl_chungtu_chitiet.idchungtu = ct.idchungtu)<0 "
            //        + "WHERE InventoryOrg='{1}' AND InventorySub='{2}' AND ThoiGian < '{3}' AND ThoiGian > '{4}' AND SoLuong < 0 GROUP BY SoPhieuNhap, SoPO, IdChungTu "
            //        + "ORDER BY SoPhieuNhap, SoPO, TongSoLuong DESC",
            //        (int)TransactionType.NHAP,
            //        inventoryOrg,
            //        inventorySub,
            //        dtNgayDongBo.Value.ToString(new CultureInfo("en-US")),
            //        currentKho.LanDongBoTruoc.ToString(new CultureInfo("en-US")),
            //        Declare.IdKho);

            LockControl.Unlock("SysnChungTuNhap");
        }

        private void btnNapDuLieu_Click(object sender, EventArgs e)
        {
            string functionName = "SysnChungTuNhap";
            try
            {
                LockControl.Lock(functionName);
                frmProgress.Instance.Text = "Đồng bộ dữ liệu";
                frmProgress.Instance.MaxValue = 5;
                frmProgress.Instance.DoWork(SynsChungTuNhap);

                dgvList.DataSource = tmp_NhapHang_UserProvider.GetNhapHangUserInfor();
            }
            catch (Exception ex)
            {
                LockControl.Unlock(functionName);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PO = ((tmp_NhapHang_UserInfo)dgvList.Rows[e.RowIndex].DataBoundItem).SoPO;
                PhieuNhap = ((tmp_NhapHang_UserInfo)dgvList.Rows[e.RowIndex].DataBoundItem).SoPhieuNhap;
                User = ((tmp_NhapHang_UserInfo)dgvList.Rows[e.RowIndex].DataBoundItem).NguoiNhap;
                NgayLap = ((tmp_NhapHang_UserInfo)dgvList.Rows[e.RowIndex].DataBoundItem).NgayNhap;
                IdChungTu = ((tmp_NhapHang_UserInfo) dgvList.Rows[e.RowIndex].DataBoundItem).IdChungTu;
            }
        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            OID = 0;
            try
            {
                if (!String.IsNullOrEmpty(PO) && CheckUser(PO))
                {
                    List<tmp_NhapHang_LogInfo> liNhapHang = tmp_NhapHang_LogDataProvider.GetNhapHangLogBySoPO(
                        new tmp_NhapHang_LogInfo
                            {
                                SoPO = PO,
                                SoPhieuNhap = PhieuNhap,
                                NguoiNhap = Declare.UserName,
                                LoaiGiaoDich = Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP)
                            });
                    if (liNhapHang.Count > 0)
                    {
                        tmp_NhapHang_LogDataProvider.Update(Declare.UserName, PO, PhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), Declare.IdKho);
                    }
                    else
                    {
                        tmp_NhapHang_LogDataProvider.Insert(Declare.UserName, PO, PhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), Declare.IdKho);
                    }
                    ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = tblChungTuDataProvider.GetChungTuNhapNCCFromSoPO(
                        PO, PhieuNhap, 0, Declare.IdKho, NgayLap, IdChungTu);
                    
                    if(chungTuXuatNhapNccInfo == null)
                    {
                        chungTuXuatNhapNccInfo = new ChungTuXuatNhapNccInfo
                                                     {
                                                         SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapHangMua),
                                                         NgayLap = NgayLap,
                                                         SoPO = PO,
                                                         SoPhieuNhap = PhieuNhap,
                                                         LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_PO),
                                                         IdDoiTuong = ((tmp_NhapHang_UserInfo)dgvList.CurrentRow.DataBoundItem).IdDoiTuong
                                                     };
                    }

                    //DMChungTuNhapInfo liChungTuNhap = tblChungTuDataProvider.GetIdFromSoPO(PO, PhieuNhap, Convert.ToInt32(TransactionType.NHAP_PO));
                    //if (liChungTuNhap != null)
                    //{
                    //    OID = liChungTuNhap.IdChungTu;
                    //}
                    //frmChiTietChungTuNhapNcc frm = new frmChiTietChungTuNhapNcc(OID, PhieuNhap, NgayLap.ToString(), PO);
                    ///frmChiTietChungTuNhapNcc frm = new frmChiTietChungTuNhapNcc(this,chungTuXuatNhapNccInfo);
                    //if(frm.ShowDialog()== DialogResult.OK)
                    //    dgvList.DataSource = tmp_NhapHang_UserProvider.GetNhapHangUserInfor();

                }
                else
                {
                    throw new ManagedException("Phiếu đã có người truy cập !");
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }
    }
}