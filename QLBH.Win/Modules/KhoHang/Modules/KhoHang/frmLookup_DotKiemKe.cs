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

namespace QLBanHang.Modules.KhoHang
{
    public class frmLookup_DotKiemKe : frm_LookUpDotKiemKeBase
    {
        private GridColumn ColMaDotKiemKe;

        public frmLookup_DotKiemKe(string searchInput)
            : base(searchInput)
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
            //this.ColMaSanPham.Width = 120;
            // 
            // ColTenSanPham
            // 
            //this.ColIdDotKiemKe.FieldName = "TenSanPham";
            //this.ColIdDotKiemKe.Caption = "Tên Sản Phẩm";
            //this.ColIdDotKiemKe.Name = "ColTenSanPham";
            //this.ColIdDotKiemKe.OptionsColumn.AllowEdit = false;
            //this.ColIdDotKiemKe.OptionsColumn.ReadOnly = true;
            //this.ColIdDotKiemKe.Visible = true;
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
    
    }
}