using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang.Base
{
    public partial class frm_LookUpDotKiemKeEndBase : frmLookUp_BaseNew_1<DotKiemKeInfor>
    {
        public frm_LookUpDotKiemKeEndBase(){}
        public frm_LookUpDotKiemKeEndBase(string searchInput) : base(searchInput) { }
        public frm_LookUpDotKiemKeEndBase(bool isMultiSelect) : base(isMultiSelect) { }
        public frm_LookUpDotKiemKeEndBase(bool isMultiSelect, string searchInput) : base(isMultiSelect, searchInput) { }
        
        protected override void OnLoad()
        {
            ListInitInfo = DotKiemKeDataProvider.Instance.GetLookUpDKKEnd();
        }

        protected override string[] LookUpPropertyNames()
        {
            return new []{"NguoiTao"};
        }
    }
}