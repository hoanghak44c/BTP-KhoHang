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
    public partial class frmBC_TinhTrangBangGia : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;

        public frmBC_TinhTrangBangGia()
        {
            InitializeComponent();
        }

        private void frmBC_TinhTrangBangGia_Load(object sender, EventArgs e)
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

        void btnReload_Click(object sender, System.EventArgs e)
        {
            grcHangTon.DataSource = BCBanHangDataProvider.Instance.GetTinhTrangBangGia(
                bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam,
                txtSoBangGia.Text,
                deFrom.DateTime,
                cboTrangThaiDuyet.SelectedIndex,
                txtNguoiLap.Text,
                bteSanPham.Tag == null ? 0 : ((DMSanPhamInfo)bteSanPham.Tag).IdSanPham);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.Export2ExcelFromDevGrid<BCTinhTrangBangGiaInfo>(grvThongKeHangTon, "BCTinhTrangBangGia");
        }

    }
}