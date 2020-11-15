using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using QLBanHang.Modules.BanHang.Infors;
using QLBanHang.Modules.BanHang.Providers;
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
    public partial class frmBC_BangGiaChiTiet : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private GridView grvBangGia, grvChinhSach, grvSanPhamKem, grvSieuThi, grvDoiTuong, grvKhuyenMai, grvThanhToan, grvThoiGian; 
        private GridLevelNode chinhSachNode;
        public frmBC_BangGiaChiTiet()
        {
            InitializeComponent();
            grvBangGia = new GtidXtraGridView(grcBangGia);
            grvBangGia.OptionsView.ColumnAutoWidth = false;
            grvBangGia.OptionsView.ShowAutoFilterRow = true;
            grvBangGia.OptionsView.ShowViewCaption = true;
            grvChinhSach = new GtidXtraGridView(grcBangGia); 
            grvChinhSach.OptionsView.ColumnAutoWidth = false;
            grvChinhSach.OptionsView.ShowGroupPanel = false;
            grvSanPhamKem = new GtidXtraGridView(grcBangGia); 
            grvSanPhamKem.OptionsView.ColumnAutoWidth = false;
            grvSanPhamKem.OptionsView.ShowGroupPanel = false;
            grvSieuThi = new GtidXtraGridView(grcBangGia); 
            grvSieuThi.OptionsView.ColumnAutoWidth = false;
            grvSieuThi.OptionsView.ShowGroupPanel = false;
            grvDoiTuong = new GtidXtraGridView(grcBangGia); 
            grvDoiTuong.OptionsView.ColumnAutoWidth = false;
            grvDoiTuong.OptionsView.ShowGroupPanel = false;
            grvKhuyenMai = new GtidXtraGridView(grcBangGia); 
            grvKhuyenMai.OptionsView.ColumnAutoWidth = false;
            grvKhuyenMai.OptionsView.ShowGroupPanel = false;
            grvThanhToan = new GtidXtraGridView(grcBangGia); 
            grvThanhToan.OptionsView.ColumnAutoWidth = false;
            grvThanhToan.OptionsView.ShowGroupPanel = false;
            grvThoiGian = new GtidXtraGridView(grcBangGia);
            grvThoiGian.OptionsView.ColumnAutoWidth = false;
            grvThoiGian.OptionsView.ShowGroupPanel = false;

            grcBangGia.MainView = grvBangGia;

            grcBangGia.LevelTree.RelationName = "BangGia";
            chinhSachNode = grcBangGia.LevelTree.Nodes.Add("ChinhSach", grvChinhSach);
            chinhSachNode.Nodes.Add("SanPhamKem", grvSanPhamKem);
            chinhSachNode.Nodes.Add("SieuThi", grvSieuThi);
            chinhSachNode.Nodes.Add("DoiTuong", grvDoiTuong);
            chinhSachNode.Nodes.Add("KhuyenMai", grvKhuyenMai);
            chinhSachNode.Nodes.Add("ThanhToan", grvThanhToan);
            chinhSachNode.Nodes.Add("ThoiGian", grvThoiGian);

            grvBangGia.MasterRowGetRelationName += grvBangGia_MasterRowGetRelationName;
            grvBangGia.MasterRowGetRelationDisplayCaption += grvBangGia_MasterRowGetRelationDisplayCaption; 
            grvBangGia.MasterRowGetRelationCount += grvBangGia_MasterRowGetRelationCount;
            grvBangGia.MasterRowGetChildList += grvBangGia_MasterRowGetChildList;
            grvBangGia.MasterRowEmpty += grvBangGia_MasterRowEmpty;

            grvChinhSach.MasterRowGetRelationName += grvChinhSach_MasterRowGetRelationName;
            grvChinhSach.MasterRowGetRelationDisplayCaption += grvChinhSach_MasterRowGetRelationDisplayCaption; 
            grvChinhSach.MasterRowGetRelationCount += grvChinhSach_MasterRowGetRelationCount;
            grvChinhSach.MasterRowGetChildList += grvChinhSach_MasterRowGetChildList;
            grvChinhSach.MasterRowEmpty += grvChinhSach_MasterRowEmpty;

        }

        private void frmBC_BangGiaChiTiet_Load(object sender, EventArgs e)
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
            grcBangGia.DataSource =
                BCBanHangDataProvider.Instance.GetBangGiaChiTiet(
                bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam,
                bteSanPham.Tag == null ? 0 : ((DMSanPhamInfo)bteSanPham.Tag).IdSanPham);
            for (int i=5; i<grvBangGia.Columns.Count; i++)
            {
                grvBangGia.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                grvBangGia.Columns[i].DisplayFormat.FormatString = "N0";
            }
        }

        #region GridView Bang Gia
        void grvBangGia_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "ChinhSach";
        }

        void grvBangGia_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Các chính sách liên quan";
        }

        void grvBangGia_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        void grvBangGia_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            e.ChildList = GetChinhSachDetailData((ColumnView)sender, e.RowHandle);
        }

        void grvBangGia_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        #endregion

        #region GridView ChinhSach
        private void grvChinhSach_MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            e.IsEmpty = false;
        }

        private void grvChinhSach_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            switch (grcBangGia.LevelTree.Nodes["ChinhSach"].Nodes[e.RelationIndex].RelationName)
            {
                case "SanPhamKem": e.ChildList = GetListSanPhamKem(Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdDKMua")));
                    break;
                case "SieuThi": e.ChildList = GetListSieuThiApDung(Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdChinhSach")));
                    break;
                case "DoiTuong": e.ChildList = GetListDoiTuongApDung(Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdChinhSach")));
                    break;
                case "KhuyenMai": e.ChildList = GetListKhuyenMai(Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdChinhSach")));
                    break;
                case "ThanhToan": e.ChildList = GetListThanhToan(Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdChinhSach")));
                    break;
                case "ThoiGian": e.ChildList = GetListThoiGian(Convert.ToInt32(((ColumnView)sender).GetRowCellValue(e.RowHandle, "IdChinhSach")));
                    break;
            }
        }

        private void grvChinhSach_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = grcBangGia.LevelTree.Nodes["ChinhSach"].Nodes.Count;
        }

        private void grvChinhSach_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = grcBangGia.LevelTree.Nodes["ChinhSach"].Nodes[e.RelationIndex].RelationName;
        }

        private void grvChinhSach_MasterRowGetRelationDisplayCaption(object sender, MasterRowGetRelationNameEventArgs e)
        {
            switch (grcBangGia.LevelTree.Nodes["ChinhSach"].Nodes[e.RelationIndex].RelationName)
            {
                case "SanPhamKem": e.RelationName = "Sản phẩm mua kèm";
                    break;
                case "SieuThi": e.RelationName = "Các siêu thị áp dụng";
                    break;
                case "DoiTuong": e.RelationName = "Các đối tượng áp dụng";
                    break;
                case "KhuyenMai": e.RelationName = "Khuyến mại";
                    break;
                case "ThanhToan": e.RelationName = "Các điều kiện thanh toán";
                    break;
                case "ThoiGian": e.RelationName = "Thời gian áp dụng";
                    break;
            }
        }
        #endregion


        private object GetRowKey(ColumnView view, int rowHandle)
        {
            return view.GetRowCellValue(rowHandle, "MaHang");
        }

        Hashtable cache = new Hashtable();

        private IList GetChinhSachDetailData(ColumnView view, int rowHandle)
        {
            object key = GetRowKey(view, rowHandle);
            
            if(key == null) return null;

            IList list = cache[key] as IList;
            if (list == null)
            {
                list = GetListChinhSach(
                    bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam,
                    key.ToString());
                cache[key] = list;
            }
            return list;
        }

        List<BCBangGiaChiTietInfo> GetListBangGia()
        {
            return BCBanHangDataProvider.Instance.GetBangGiaChiTiet(
                bteTrungTam.Tag == null ? 0 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam, 
                bteSanPham.Tag == null ? 0 : ((DMSanPhamInfo)bteSanPham.Tag).IdSanPham);
        }

        List<BCChinhSachInfo> GetListChinhSach(int idTrungTam, string maHang)
        {
            return BCBanHangDataProvider.Instance.GetChinhSachApDung(idTrungTam, maHang);
        }

        List<BangGiaADSPKemInfor> GetListSanPhamKem(int idDKMua)
        {
            return KhuyenMaiDataProvider.Instance.GetAllSanPhamKemInfors(idDKMua);
        }

        List<BangGiaADShopInfor> GetListSieuThiApDung(int idChinhSach)
        {
            return ChinhSachDataProvider.Instance.GetBangGiaADShopInfor(idChinhSach);
        }

        List<BangGiaADKhachInfor> GetListDoiTuongApDung(int idChinhSach)
        {
            return ChinhSachDataProvider.Instance.GetBangGiaADKhachInfor(idChinhSach);
        }

        List<BangGiaADKhuyenMaiChiTietInfor> GetListKhuyenMai(int idChinhSach)
        {
            return KhuyenMaiDataProvider.Instance.GetAllKhuyenMaiChiTietInfors(idChinhSach);
        }

        List<BangGiaADBankInfor> GetListThanhToan(int idChinhSach)
        {
            return ChinhSachDataProvider.Instance.GetBangGiaADThanhToanInfor(idChinhSach);
        }

        List<BangGiaADTimeInfor> GetListThoiGian(int idChinhSach)
        {
            return ChinhSachDataProvider.Instance.GetBangGiaADThoiGianInfor(idChinhSach);
        }

        public void DisplayTest()
        {
           grcBangGia.DataSource = GetListBangGia();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //grcBangGia.ShowPrintPreview();
            Common.Export2ExcelFromDevGrid<BCBangGiaChiTietInfo>(grvBangGia, "BCBangGiaChiTiet");
        }

        private void grcBangGia_Click(object sender, EventArgs e)
        {

        }        
    }
}