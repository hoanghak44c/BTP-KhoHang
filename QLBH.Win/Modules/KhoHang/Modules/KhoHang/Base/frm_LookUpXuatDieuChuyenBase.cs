using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang.Base
{
    public partial class frm_LookUpXuatDieuChuyenBase : frmLookUp_BaseNew_1<NhapHangMuaReportInfo>
    {
        public frm_LookUpXuatDieuChuyenBase(){}
        public frm_LookUpXuatDieuChuyenBase(string searchInput) : base(searchInput) { }
        protected override void OnLoad()
        {
            ListInitInfo = DeNghiXuatDieuChuyenDataProvider.Instance.GetLookUpXDC();
        }
    }
}