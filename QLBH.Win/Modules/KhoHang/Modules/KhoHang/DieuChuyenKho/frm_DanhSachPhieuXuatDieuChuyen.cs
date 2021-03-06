using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuXuatDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        private string idKho, soGiaoDich, trangThai;
        private DateTime ngayGiaoDich;

        List<ChungTuXuatDieuChuyenInfo> liDM;
        public frm_DanhSachPhieuXuatDieuChuyen()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            liDM = new List<ChungTuXuatDieuChuyenInfo>();
            grcDanhSach.DataSource = liDM;
        }

        private void LoadData()
        {
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.Caption = Text;

            liDM.Clear();

            Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });

            idKho = String.Empty;

            var lstKho = DMKhoDataProvider.GetListDMKhoInfor();

            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                idKho += ((NguoiDungInfor)Declare.USER_INFOR).IsOnline ||
                         ((NguoiDungInfor)Declare.USER_INFOR).IsKinhDoanhThiTruong ||
                         ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan == nguoiDungInfor.IdTrungTam
                             ? nguoiDungInfor.IdKho + ","
                             : String.Empty;

                if (!((NguoiDungInfor)Declare.USER_INFOR).IsOnline &&
                    !((NguoiDungInfor)Declare.USER_INFOR).IsKinhDoanhThiTruong &&
                    ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan != nguoiDungInfor.IdTrungTam)
                {
                    var khoInfo = lstKho.Find(delegate(DMKhoInfo match)
                    { return match.IdKho == nguoiDungInfor.IdKho; });
                    if (khoInfo != null)
                    {
                        string otherTrungTam = khoInfo.OtherTrungTam;
                        if (!String.IsNullOrEmpty(otherTrungTam) &&
                            otherTrungTam.Contains(String.Format(",{0},",
                            ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan)))
                        {
                            idKho += nguoiDungInfor.IdKho + ",";
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(soGiaoDich) && !String.IsNullOrEmpty(trangThai) && ngayGiaoDich == DateTime.MinValue)
            {
                frmProgress.Instance.MaxValue = 32;

                ngayGiaoDich = Declare.SYSDATE.AddDays(-31);

                var minDate = DeNghiXuatDieuChuyenDataProvider.Instance.GetMinDate(idKho, trangThai);

                if (minDate > DateTime.MinValue)
                {
                    if (minDate > ngayGiaoDich)
                    {
                        frmProgress.Instance.Value += (int)(minDate.Date - ngayGiaoDich.Date).TotalDays;

                        ngayGiaoDich = minDate;
                    }

                    while (ngayGiaoDich <= Declare.SYSDATE)
                    {
                        liDM.AddRange(XuatDieuChuyenKhoDataProvider.Instance.GetFillterXuatDieuChuyen(idKho, soGiaoDich,
                            ngayGiaoDich, trangThai, Declare.IdTrungTamHachToan));

                        Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });

                        ngayGiaoDich = ngayGiaoDich.AddDays(1);

                        frmProgress.Instance.Value += 1;
                    }                    
                }
            } 
            else
            {
                liDM.AddRange(XuatDieuChuyenKhoDataProvider.Instance.GetFillterXuatDieuChuyen(idKho, soGiaoDich,
                    ngayGiaoDich, trangThai, Declare.IdTrungTamHachToan));

                Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });                
            }

            frmProgress.Instance.Description = "Đã xong!";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;    
        }

        private void frm_DanhSachPhieuNhanDieuChuyen_Load(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            cboTrangThai.SelectedIndex = 1;
            dteNgayThucHien.Checked = false;
            clsUtils.NullColumnDateTimeGrid(repNgayXuatHang);
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);

            soGiaoDich = txtSoGiaoDich.Text;
            trangThai = cboTrangThai.Text;
            ngayGiaoDich = String.IsNullOrEmpty(txtSoGiaoDich.Text)
                                        ? dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                                          !dteNgayThucHien.ShowCheckBox
                                              ? dteNgayThucHien.Value
                                              : DateTime.MinValue
                                        : DateTime.MinValue;

            frmProgress.Instance.DoWork(LoadData);
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            ChungTuXuatDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                if(!CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    return;
                }

                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }
                
                info = DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(info.IdChungTu);

                if (info == null || info.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_HUY_DIEU_CHUYEN) ||
                    info.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN))
                {
                    if (info == null || ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle)).TrangThai != info.TrangThai)
                        frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy, không thể mở được!");
                }

                frm_PhieuXuatDieuChuyen frm = new frm_PhieuXuatDieuChuyen(info);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frmProgress.Instance.DoWork(LoadData);
                }

                CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

            }
            catch (ManagedException ex)
            {
                try
                {
                    CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);
                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                try
                {
                    CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);
                } 
                catch(Exception){}

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DanhSachDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            ChungTuXuatDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                if (!CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    return;
                }

                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(info.IdChungTu);

                if (info == null || info.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_HUY_DIEU_CHUYEN) ||
                    info.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN))
                {
                    if (info == null || ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle)).TrangThai != info.TrangThai)
                        frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy, không thể mở được!");
                }

                frm_PhieuXuatDieuChuyen frm = new frm_PhieuXuatDieuChuyen(info);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frmProgress.Instance.DoWork(LoadData);
                }

                CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

            }
            catch (ManagedException ex)
            {
                try
                {
                    if (info != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                try
                {
                    if (info != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

                }
                catch (Exception) { }

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            grcDanhSach.ShowPrintPreview();
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            soGiaoDich = txtSoGiaoDich.Text;
            trangThai = cboTrangThai.Text;
            ngayGiaoDich = String.IsNullOrEmpty(txtSoGiaoDich.Text)
                                        ? dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                                          !dteNgayThucHien.ShowCheckBox
                                              ? dteNgayThucHien.Value
                                              : DateTime.MinValue
                                        : DateTime.MinValue;

            frmProgress.Instance.DoWork(LoadData);
            
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.Text == "Đã nhận" || String.IsNullOrEmpty(cboTrangThai.Text))
            {
                dteNgayThucHien.ShowCheckBox = false;
            }
            else
            {
                dteNgayThucHien.ShowCheckBox = true;
            }
        }
    }
}