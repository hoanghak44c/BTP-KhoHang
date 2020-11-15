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
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmLookup_DotKiemKeKetThuc : frm_LookUpDotKiemKeEndBase
    {
        private GridColumn ColMaDotKiemKe;
        //public DotKiemKeInfor item = new DotKiemKeInfor();
        //private int IdDoiTuong;
        //private int idkho;
        //private DateTime tungay, denngay;
        //objGridMarkSelection opt = new objGridMarkSelection();
        public frmLookup_DotKiemKeKetThuc(string searchInput):base(searchInput)
        {
            InitializeComponent();
        }

        public frmLookup_DotKiemKeKetThuc(bool isMultiSelect)
            : base(isMultiSelect)
        {
            InitializeComponent();
        }

        public frmLookup_DotKiemKeKetThuc(bool isMultiSelect, string searchInput)
            : base(isMultiSelect, searchInput)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.ColMaDotKiemKe = new GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvLookUp)).BeginInit();
            this.SuspendLayout();
            // 
            // grvLookUp
            // 
            this.grvLookUp.Columns.AddRange(new[] {
            this.ColMaDotKiemKe
            });
            // 
            // ColMaSanPham
            // 
            this.ColMaDotKiemKe.FieldName = "MaDotKiemKe";
            this.ColMaDotKiemKe.Caption = "Mã đợt kiểm kê";
            this.ColMaDotKiemKe.Name = "ColMaDotKiemKe";
            this.ColMaDotKiemKe.OptionsColumn.AllowEdit = false;
            this.ColMaDotKiemKe.OptionsColumn.ReadOnly = true;
            this.ColMaDotKiemKe.Visible = true;
            // 
            // frmLookUp_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(690, 457);
            this.Name = "frmLookUp_DotKiemKe";
            this.Text = "Tìm kiếm nhanh đợt kiểm kê";
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
        //    List<DotKiemKeInfor> lst = new List<DotKiemKeInfor>();
        //    lst = DotKiemKeDataProvider.Instance.GetLookUpDKKEnd();
        //    grcDanhSach.DataSource = null;
        //    grcDanhSach.DataSource = lst;
        //    //opt.View = grvDanhSach;
        //}
        //private void Save()
        //{
        //    item = (DotKiemKeInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
        //    //for (int i = 0; i < opt.selection.Count; i++)
        //    //{
        //    //    item.Add((BhPhieuXuatNhaCCLookUpInfor)opt[i]);
        //    //}
        //    //item = (BhPhieuXuatNhaCCLookUpInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
        //}

        //private void frmLookup_PhieuNhap_Load(object sender, EventArgs e)
        //{
        //    //LoadLoaiChungTu();
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