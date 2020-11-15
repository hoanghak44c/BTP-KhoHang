using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.BanHang;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoXuatNhapTonLichSu : DevExpress.XtraEditors.XtraForm
    {
        private int SoLuongTimKiem = Declare.SOLUONG_TIMKIEM;
        private int SoLuongHienTai = 0;
        private List<BaoCaoXuatNhapTonLichSuInfo> listResult = new List<BaoCaoXuatNhapTonLichSuInfo>();
        private List<BaoCaoXuatNhapTonLichSuInfo> listSearch = new List<BaoCaoXuatNhapTonLichSuInfo>();

        public frm_BaoCaoXuatNhapTonLichSu()
        {
            InitializeComponent();
        }

        private void frm_BaoCaoXuatNhapTonLichSu_Load(object sender, EventArgs e)
        {
            CommonFuns.Instance.LoadComboBoxPages(cboPage);
        }

        private void btnFillter_Click(object sender, EventArgs e)
        {
            SoLuongHienTai = 0;
            SoLuongTimKiem = Declare.SOLUONG_TIMKIEM;
            listResult = new List<BaoCaoXuatNhapTonLichSuInfo>();
            gListXuatNhapTon.DataSource = new BindingList<BaoCaoXuatNhapTonLichSuInfo>(listResult);

            TimKiemChungTu();
        }

        private void LoadDuLieu()
        {
            int batDau = SoLuongHienTai;
            int ketThuc = SoLuongTimKiem != -1 ? SoLuongHienTai + SoLuongTimKiem : -1;
            string maKho = bteKho.Text;
            string maSanPham = bteSanpham.Text;
            DateTime fromDate = deFrom.DateTime;
            DateTime toDate = deTo.DateTime;
            if (listResult.Count == 0)
            {
                frmProgress.Instance.Description = "Đang load dữ liệu...";
                BaoCaoXuatNhapTonLichSuDataProvider.Instance.LoadBaoCaoXuatNhapTonLichSuInfo(maKho, maSanPham, fromDate, toDate);                
            }
            frmProgress.Instance.Description = Common.MsgProgress(SoLuongTimKiem);
            listSearch = BaoCaoXuatNhapTonLichSuDataProvider.Instance.GetListBaoCaoXuatNhapTonLichSuInfo(maKho, maSanPham, fromDate, toDate, batDau, ketThuc);

            listResult.AddRange(listSearch);

            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
            frmProgress.Instance.Description = "Đã xong";
        }

        private void TimKiemChungTu()
        {
            try
            {
                frmProgress.Instance.Description = Common.MsgProgress(SoLuongTimKiem);
                frmProgress.Instance.MaxValue = SoLuongTimKiem;
                frmProgress.Instance.Value = 0;
                frmProgress.Instance.DoWork(LoadDuLieu);
                gvListXuatNhapTon.ExpandAllGroups();
                ((BindingList<BaoCaoXuatNhapTonLichSuInfo>)gListXuatNhapTon.DataSource).ResetBindings();
                SoLuongHienTai = listResult.Count;

                this.grpKetQuaTimKiem.Text = "Kết quả tìm kiếm (" + listResult.Count + " phiếu)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);

            if (frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.EditValue = String.Empty;
                bteKho.Tag = frmLookUpKho.SelectedItems;
                foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                {
                    bteKho.EditValue += selectedItem.MaKho + ", ";
                }
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);

                if (frmLookUpKho.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frmLookUpKho.SelectedItems;
                    foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                    {
                        bteKho.EditValue += selectedItem.MaKho + ", ";
                    }
                }
            }
        }

        private void bteKho_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKho.Text))
            {
                bteKho.Tag = null;
            }
        }

        private void bteSanpham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham frmLookUpSanPham = new frmLookUp_SanPham(true);
            if (frmLookUpSanPham.ShowDialog() == DialogResult.OK)
            {
                bteSanpham.EditValue = String.Empty;
                bteSanpham.Tag = frmLookUpSanPham.SelectedItems;
                foreach (DMSanPhamInfo selectedItem in frmLookUpSanPham.SelectedItems)
                {
                    bteSanpham.EditValue += selectedItem.MaSanPham + ", ";
                }
            }
        }

        private void bteSanpham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_SanPham frmLookUpSanPham = new frmLookUp_SanPham(true);
                if (frmLookUpSanPham.ShowDialog() == DialogResult.OK)
                {
                    bteSanpham.EditValue = String.Empty;
                    bteSanpham.Tag = frmLookUpSanPham.SelectedItems;
                    foreach (DMSanPhamInfo selectedItem in frmLookUpSanPham.SelectedItems)
                    {
                        bteSanpham.EditValue += selectedItem.MaSanPham + ", ";
                    }
                }
            }
        }

        private void bteSanpham_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteSanpham.Text))
            {
                bteSanpham.Tag = null;
            }
        }

        private void cboKyBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nam = DateTime.Today.Year;
            if (cboKyBaoCao.Text == "Ngày")
            {
                deTo.EditValue = DateTime.Today;
                deFrom.EditValue = deTo.EditValue;
            }
            else if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));
                if (thang > Convert.ToDateTime(deFrom.EditValue).Month)
                {
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thang,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deTo.EditValue).Year, thang));
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thang, 1);
                }
                else
                {
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thang, 1);
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thang,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deFrom.EditValue).Year, thang));
                }
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangdau = (quy - 1) * 3 + 1;
                int thangcuoi = (quy - 1) * 3 + 3;
                if (thangcuoi > Convert.ToDateTime(deTo.EditValue).Month)
                {
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thangcuoi,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deTo.EditValue).Year,
                                                                       thangcuoi));
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thangdau, 1);
                }
                else
                {
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thangdau, 1);
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thangcuoi,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deFrom.EditValue).Year,
                                                                       thangcuoi));
                }
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                deTo.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, 12, 31);
                deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, 1, 1);
            }
            else
            {
                deFrom.Enabled = true;
                deTo.Enabled = true;
            }
        }

        private void deFrom_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (deTo.EditValue != null && Convert.ToDateTime(e.NewValue) > Convert.ToDateTime(deTo.EditValue))
            {
                e.Cancel = true;
                return;
            }

            if (cboKyBaoCao.Text == "Ngày") return;

            if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));
                if (Convert.ToDateTime(e.NewValue).Day != 1)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thang)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangdau = (quy - 1) * 3 + 1;
                if (Convert.ToDateTime(e.NewValue).Day != 1)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thangdau)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                if (Convert.ToDateTime(e.NewValue).Day != 1)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != 1)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void deTo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (deFrom.EditValue != null && Convert.ToDateTime(e.NewValue) < Convert.ToDateTime(deFrom.EditValue))
            {
                e.Cancel = true;
                return;
            }

            if (cboKyBaoCao.Text == "Ngày") return;

            if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));

                if (Convert.ToDateTime(e.NewValue).Day != DateTime.DaysInMonth(Convert.ToDateTime(e.NewValue).Year, thang))
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thang)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangcuoi = (quy - 1) * 3 + 3;
                if (Convert.ToDateTime(e.NewValue).Day != DateTime.DaysInMonth(Convert.ToDateTime(e.NewValue).Year, thangcuoi))
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thangcuoi)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                if (Convert.ToDateTime(e.NewValue).Day != 31)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != 12)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void deFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboKyBaoCao.Text) || cboKyBaoCao.Text == "Tùy chọn" || cboKyBaoCao.Text == "Ngày")
                return;

            if (Convert.ToDateTime(deTo.EditValue).Year != Convert.ToDateTime(deFrom.EditValue).Year)
            {
                deTo.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year,
                                              Convert.ToDateTime(deTo.EditValue).Month,
                                              DateTime.DaysInMonth(Convert.ToDateTime(deFrom.EditValue).Year,
                                                                   Convert.ToDateTime(deTo.EditValue).Month));
            }
        }

        private void deTo_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboKyBaoCao.Text) || cboKyBaoCao.Text == "Tùy chọn" || cboKyBaoCao.Text == "Ngày")
                return;

            if (Convert.ToDateTime(deFrom.EditValue).Year != Convert.ToDateTime(deTo.EditValue).Year)
            {
                deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year,
                                              Convert.ToDateTime(deFrom.EditValue).Month,
                                              Convert.ToDateTime(deFrom.EditValue).Day);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SoLuongTimKiem = Common.IntValue(cboPage.SelectedItem);
            if (SoLuongTimKiem == 0)
                SoLuongTimKiem = Declare.SOLUONG_TIMKIEM;
            if (cboPage.SelectedItem.Equals("Tất cả"))
            {
                if (MessageBox.Show(Declare.msgLoadDataWrn, "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SoLuongTimKiem = -1;
                }
                else
                {
                    return;
                }
            }

            TimKiemChungTu();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(gvListXuatNhapTon);
            Common.Export2ExcelFromDevGrid<BaoCaoXuatNhapTonLichSuInfo>(gvListXuatNhapTon, "BCXuatNhapTonLichSu");
        }

        private void ChungTuLienQuanTsm_Click(object sender, EventArgs e)
        {
            BaoCaoXuatNhapTonLichSuInfo khoThongKeHangTonInfo = (BaoCaoXuatNhapTonLichSuInfo)gvListXuatNhapTon.GetFocusedRow();
            if (khoThongKeHangTonInfo != null)
            {
                Form frm = new frmThongKe_ChungTuLienQuan(khoThongKeHangTonInfo);
                frm.ShowDialog();
            }
        }

        private void TonChiTietMaVachTsm_Click(object sender, EventArgs e)
        {
            BaoCaoXuatNhapTonLichSuInfo khoThongKeHangTonInfo = (BaoCaoXuatNhapTonLichSuInfo)gvListXuatNhapTon.GetFocusedRow();
            if (khoThongKeHangTonInfo != null)
            {
                Form frm = new frmThongKe_TonChiTietMaVach(khoThongKeHangTonInfo);
                frm.ShowDialog();
            }
        }
    }
}