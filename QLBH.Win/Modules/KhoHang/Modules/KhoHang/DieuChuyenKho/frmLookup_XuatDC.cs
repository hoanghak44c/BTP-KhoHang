using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using QLBanHang.Modules.KhoHang.Base;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH
{
    public partial class frmLookup_XuatDC : frm_LookUpXuatDieuChuyenBase
    {
        //public NhapHangMuaReportInfo item = new NhapHangMuaReportInfo();
        //private int IdDoiTuong;
        //private int idkho;
        //private DateTime tungay, denngay;
        //objGridMarkSelection opt = new objGridMarkSelection();
        private GridColumn ColSoPhieuXuat;
        private GridColumn ColNgayLap;

        public frmLookup_XuatDC(string searchInput)
            : base(searchInput)
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.ColSoPhieuXuat = new GridColumn();
            this.ColNgayLap = new GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvLookUp)).BeginInit();
            this.SuspendLayout();
            // 
            // grvLookUp
            // 
            this.grvLookUp.Columns.AddRange(new[] {
            this.ColSoPhieuXuat,
            this.ColNgayLap
            });
            // 
            // ColSoChungTu
            // 
            this.ColSoPhieuXuat.FieldName = "SoChungTu";
            this.ColSoPhieuXuat.Caption = "Số phiếu xuất";
            this.ColSoPhieuXuat.Name = "ColSoPhieuXuat";
            this.ColSoPhieuXuat.OptionsColumn.AllowEdit = false;
            this.ColSoPhieuXuat.OptionsColumn.ReadOnly = true;
            this.ColSoPhieuXuat.Visible = true;
            //this.ColMaSanPham.Width = 120;
            // 
            // ColNgayLap
            // 
            this.ColNgayLap.FieldName = "NgayLap";
            this.ColNgayLap.Caption = "Ngày lập";
            this.ColNgayLap.Name = "ColNgayLap";
            this.ColNgayLap.OptionsColumn.AllowEdit = false;
            this.ColNgayLap.OptionsColumn.ReadOnly = true;
            this.ColNgayLap.Visible = true;
            // 
            // frmLookUp_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(690, 457);
            this.Name = "frmLookUp_XuatDC";
            this.Text = "Tìm kiếm nhanh số phiếu xuất điều chuyển";
            ((System.ComponentModel.ISupportInitialize)(this.grvLookUp)).EndInit();
            this.ResumeLayout(false);

        }
        //private void LoadLoaiChungTu()
        //{
        //    repLoaichungtu.DataSource = StringEnum.GetStringValue(TransactionType.NHAP_PO,
        //                                                          TransactionType.NHAPHANGLOIBHNCC);
        //}

        //private void LoadDataSource()
        //{
        //    List<NhapHangMuaReportInfo> lst = new List<NhapHangMuaReportInfo>();
        //    lst = DeNghiXuatDieuChuyenDataProvider.Instance.GetLookUpXDC();
        //    grcDanhSach.DataSource = null;
        //    grcDanhSach.DataSource = lst;
        //    //opt.View = grvDanhSach;
        //}
        //private void Save()
        //{
        //    item = (NhapHangMuaReportInfo) grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
        //    //for (int i = 0; i < opt.selection.Count; i++)
        //    //{
        //    //    item.Add((BhPhieuXuatNhaCCLookUpInfor)opt[i]);
        //    //}
        //    //item = (BhPhieuXuatNhaCCLookUpInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
        //}

        //private void frmLookup_PhieuNhap_Load(object sender, EventArgs e)
        //{
        //    LoadLoaiChungTu();
        //    LoadDataSource();
        //}

        //private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Save();
        //        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        //        this.Close();
        //    }
        //    catch { }
        //}

        //private void txtSoPhieuXuat_EditValueChanged(object sender, EventArgs e)
        //{
        //    LoadDataSource();
        //}

        //private void grvDanhSach_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        try
        //        {
        //            Save();
        //            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        //            this.Close();
        //        }
        //        catch { }
        //    }
        //}

        //private void txtSoPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Down)
        //        grcDanhSach.Focus();
        //}
    }
}