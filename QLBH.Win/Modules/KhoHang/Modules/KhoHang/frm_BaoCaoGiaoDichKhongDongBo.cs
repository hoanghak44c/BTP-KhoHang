using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoGiaoDichKhongDongBo : DevExpress.XtraEditors.XtraForm
    {
        public frm_BaoCaoGiaoDichKhongDongBo()
        {
            InitializeComponent();
        }

        private void frm_BaoCaoGiaoDichKhongDongBo_Load(object sender, EventArgs e)
        {
            
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            Common.Export2ExcelFromDevGrid<GiaoDichNhapXuatKhongDongBoInfo>(grvBCKiemKe, "BCGiaoDichKhongDongBo");
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKho.Text));
            if(frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frmLookUp.SelectedItem;
            }

        }

        private void bteSanpham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham frmLookUp = new frmLookUp_SanPham(String.Format("%{0}%", bteSanpham.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteSanpham.Tag = frmLookUp.SelectedItem;
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKho.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frmLookUp.SelectedItem;
                }                
            }
        }

        private void bteSanpham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_SanPham frmLookUp = new frmLookUp_SanPham(String.Format("%{0}%", bteSanpham.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteSanpham.Tag = frmLookUp.SelectedItem;
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            string maKho = bteKho.Tag != null ? ((DMKhoInfo)bteKho.Tag).MaKho : String.Empty;
            string maSanPham = bteSanpham.Tag != null ? ((DMSanPhamInfo)bteSanpham.Tag).MaSanPham : String.Empty;

            grcBCKiemKe.DataSource = BaoCaoGiaoDichKhongDongBoDataProvider.Instance.
                GetListGiaoDichKhongDongBo(maKho, maSanPham, deFrom.DateTime, deTo.DateTime);
        }

    }
}
