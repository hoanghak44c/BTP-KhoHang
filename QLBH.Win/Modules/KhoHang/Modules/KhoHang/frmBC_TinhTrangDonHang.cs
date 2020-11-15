using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmBC_TinhTrangDonHang : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;

        public frmBC_TinhTrangDonHang()
        {
            InitializeComponent();
        }

        private void frmBC_TinhTrangDonHang_Load(object sender, EventArgs e)
        {
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frmLookUp = new frmLookUp_TrungTam(String.Format("%{0}%", bteTrungTam.Text));
                if (frmLookUp.ShowDialog(this) == DialogResult.OK)
                {
                    bteTrungTam.Text = frmLookUp.SelectedItem.TenTrungTam;
                    bteTrungTam.Tag = frmLookUp.SelectedItem;
                }
            }
        }

        private void bteTrungTam_TextChanged(object sender, System.EventArgs e)
        {
            if (bteTrungTam.Text == String.Empty) bteTrungTam.Tag = null;
        }

        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frmLookUp = new frmLookUp_TrungTam(String.Format("%{0}%", bteTrungTam.Text));
            if (frmLookUp.ShowDialog(this) == DialogResult.OK)
            {
                bteTrungTam.Text = frmLookUp.SelectedItem.TenTrungTam;
                bteTrungTam.Tag = frmLookUp.SelectedItem;
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKho.Text));
                if (frmLookUp.ShowDialog(this) == DialogResult.OK)
                {
                    bteKho.Text = frmLookUp.SelectedItem.TenKho;
                    bteKho.Tag = frmLookUp.SelectedItem;
                }
            }
        }

        private void bteKho_TextChanged(object sender, System.EventArgs e)
        {
            if (bteKho.Text == String.Empty) bteKho.Tag = null;
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKho.Text));
            if (frmLookUp.ShowDialog(this) == DialogResult.OK)
            {
                bteKho.Text = frmLookUp.SelectedItem.TenKho;
                bteKho.Tag = frmLookUp.SelectedItem;
            }
        }

        private void bteNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNhanVien.Text));
                if (frmLookUp.ShowDialog(this) == DialogResult.OK)
                {
                    bteNhanVien.Text = frmLookUp.SelectedItem.HoTen;
                    bteNhanVien.Tag = frmLookUp.SelectedItem;
                }
            }
        }

        private void bteNhanVien_TextChanged(object sender, System.EventArgs e)
        {
            if (bteNhanVien.Text == String.Empty) bteNhanVien.Tag = null;
        }

        private void bteNhanVien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNhanVien.Text));
            if (frmLookUp.ShowDialog(this) == DialogResult.OK)
            {
                bteNhanVien.Text = frmLookUp.SelectedItem.HoTen;
                bteNhanVien.Tag = frmLookUp.SelectedItem;
            }
        }

        private void bteSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_SanPham frmLookUp = new frmLookUp_SanPham(String.Format("%{0}%", bteSanPham.Text));
                if (frmLookUp.ShowDialog(this) == DialogResult.OK)
                {
                    bteSanPham.Text = frmLookUp.SelectedItem.TenSanPham;
                    bteSanPham.Tag = frmLookUp.SelectedItem;
                }
            }
        }

        private void bteSanPham_TextChanged(object sender, System.EventArgs e)
        {
            if (bteSanPham.Text == String.Empty) bteSanPham.Tag = null;
        }

        private void bteSanPham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham frmLookUp = new frmLookUp_SanPham(String.Format("%{0}%", bteSanPham.Text));
            if (frmLookUp.ShowDialog(this) == DialogResult.OK)
            {
                bteSanPham.Text = frmLookUp.SelectedItem.TenSanPham;
                bteSanPham.Tag = frmLookUp.SelectedItem;
            }
        }

        private void bteKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_KhachHang frmLookUp = new frmLookUp_KhachHang(String.Format("%{0}%", bteKhachHang.Text));
                if (frmLookUp.ShowDialog(this) == DialogResult.OK)
                {
                    bteKhachHang.Text = frmLookUp.SelectedItem.TenDoiTuong;
                    bteKhachHang.Tag = frmLookUp.SelectedItem;
                }
            }
        }

        private void bteKhachHang_TextChanged(object sender, EventArgs e)
        {
            if (bteKhachHang.Text == String.Empty) bteKhachHang.Tag = null;
        }

        private void bteKhachHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_KhachHang frmLookUp = new frmLookUp_KhachHang(String.Format("%{0}%", bteKhachHang.Text));
            if (frmLookUp.ShowDialog(this) == DialogResult.OK)
            {
                bteKhachHang.Text = frmLookUp.SelectedItem.TenDoiTuong;
                bteKhachHang.Tag = frmLookUp.SelectedItem;
            }
        }

        void btnReload_Click(object sender, System.EventArgs e)
        {
            grcHangTon.DataSource = BCBanHangDataProvider.Instance.GetTinhTrangDonHang(
                bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam,
                bteKho.Tag == null ? 0 : ((DMKhoInfo)bteKho.Tag).IdKho,
                deFrom.DateTime, deTo.DateTime,
                bteSanPham.Tag == null ? 0 : ((DMSanPhamInfo)bteSanPham.Tag).IdSanPham,
                bteNhanVien.Tag == null ? 0 : ((DMNhanVienInfo)bteNhanVien.Tag).IdNhanVien,
                bteKhachHang.Tag == null ? 0 : ((DMDoiTuongInfo)bteKhachHang.Tag).IdDoiTuong);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //grcHangTon.ShowPrintPreview();
            Common.Export2ExcelFromDevGrid<BCTinhTrangDonHangInfo>(grvThongKeHangTon, "BCTinhTrangDonHang");
        }

    }
}