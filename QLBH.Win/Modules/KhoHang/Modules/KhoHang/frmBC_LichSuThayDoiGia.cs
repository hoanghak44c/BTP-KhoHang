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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmBC_LichSuThayDoiGia : DevExpress.XtraEditors.XtraForm
    {
        GtidXtraGridView grvLichSu;
        GtidXtraGridView grvLichSuDetail;
        public frmBC_LichSuThayDoiGia()
        {
            InitializeComponent();
            GtidXtraGridView grvLichSu = new GtidXtraGridView(grcLichSu);
            GtidXtraGridView grvLichSuDetail = new GtidXtraGridView(grcLichSu);
            
            grcLichSu.MainView = grvLichSu;

            grcLichSu.LevelTree.RelationName = "LichSu";
            grcLichSu.LevelTree.Nodes.Add("LichSuDetail", grvLichSuDetail);
            grvLichSu.MasterRowEmpty += new MasterRowEmptyEventHandler(grvLichSu_MasterRowEmpty);
            grvLichSu.MasterRowGetRelationCount += new MasterRowGetRelationCountEventHandler(grvLichSu_MasterRowGetRelationCount);
            grvLichSu.MasterRowGetRelationName += new MasterRowGetRelationNameEventHandler(grvLichSu_MasterRowGetRelationName);
            grvLichSu.MasterRowGetRelationDisplayCaption += new MasterRowGetRelationNameEventHandler(grvLichSu_MasterRowGetRelationDisplayCaption);
            grvLichSu.MasterRowGetChildList += new MasterRowGetChildListEventHandler(grvLichSu_MasterRowGetChildList);
        }

        void grvLichSu_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Chi tiết lịch sử thay đổi giá";
        }

        void grvLichSu_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "LichSu";
        }

        void grvLichSu_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            e.ChildList = BCBanHangDataProvider.Instance.GetLichSuThayDoiGiaDetail(
                bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam,
                Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdSanPham")),
                Convert.ToDateTime(dteStart.EditValue),
                Convert.ToDateTime(dteEnd.EditValue)); 
        }

        void grvLichSu_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        void grvLichSu_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void frmBC_LichSuThayDoiGia_Load(object sender, EventArgs e)
        {
            DMTrungTamInfor tt = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
            if (tt!=null)
            {
                bteTrungTam.Tag = tt;
                bteTrungTam.Text = tt.TenTrungTam;
            }
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
            grcLichSu.DataSource = BCBanHangDataProvider.Instance.GetLichSuThayDoiGia(
                bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam,
                bteSanPham.Tag == null ? 0 : ((DMSanPhamInfo)bteSanPham.Tag).IdSanPham);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.Export2ExcelFromDevGrid<BCLichSuThayDoiGiaInfo>(grvLichSuDetail, "BCLichSuThayDoiGia");
        }

    }
}