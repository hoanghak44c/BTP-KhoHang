using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoDieuChuyenKhoTongGiao : DevExpress.XtraEditors.XtraForm
    {
        private string soGiaoDich;
        private DateTime ngayGiaoDich;
        private string trangThai;

        public frm_BaoCaoDieuChuyenKhoTongGiao()
        {
            InitializeComponent();
        }

        private void frm_BaoCaoDieuChuyenKhoTongGiao_Load(object sender, EventArgs e)
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

        private void LoadData()
        {
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;

            Invoke((MethodInvoker)
                   delegate
                   {
                       grcDanhSach.DataSource =
                           BaoCaoDieuChuyenKhoTongGiaoDataProvider.Instance.GetListSource(soGiaoDich, ngayGiaoDich, trangThai);

                       grcDanhSach.RefreshDataSource();
                   });

            frmProgress.Instance.Description = "Đã xong!";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = 100;

            soGiaoDich = txtSoGiaoDich.Text;
            ngayGiaoDich = String.IsNullOrEmpty(txtSoGiaoDich.Text)
                                        ? dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                                          !dteNgayThucHien.ShowCheckBox
                                              ? dteNgayThucHien.Value
                                              : DateTime.MinValue
                                        : DateTime.MinValue;
            trangThai = cboTrangThai.Text;

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

        private void grcDanhSach_DoubleClick(object sender, EventArgs e)
        {
            ChungTuXuatDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu);

                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(info.IdChungTu);

                if (info == null ||
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN) &&
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy, không thể mở được!");
                }

                frm_PhieuDeNghiXuatDieuChuyen frm = new frm_PhieuDeNghiXuatDieuChuyen(info, true);

                //foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                //{
                //    idKho += nguoiDungInfor.IdKho + ",";
                //}

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

        private void cmdExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
                                     {
                                         FileName = "DieuChuyenKhoTongGiao",
                                         Filter = "Excel 2003(*.xls)|*.xls"
                                     };

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            
                grvDanhSach.ExportToXls(saveFileDialog.FileName);
            
        }
    }
}