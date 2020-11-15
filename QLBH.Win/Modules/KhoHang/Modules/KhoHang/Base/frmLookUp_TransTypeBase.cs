using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang.Base
{
    public class frmLookUp_TransTypeBase : frmLookUp_BaseNew_1<TransTypeInfo>
    {
        protected frmLookUp_TransTypeBase(bool isMultiSelect, string searchInput)
            : base(isMultiSelect, searchInput)
        {
        }
        protected frmLookUp_TransTypeBase(string searchInput)
            : base(searchInput)
        {
        }

        protected override void OnLoad()
        {
            ListInitInfo = TransTypeDataProvider.Instance.GetListTransType();
        }
    }
}