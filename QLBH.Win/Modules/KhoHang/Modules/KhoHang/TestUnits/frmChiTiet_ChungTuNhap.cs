using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTiet_ChungTuNhapBase
    {
        public void TestSave()
        {
#if DEBUG
            SaveChungTu();
#endif
        }

        public void TestLoadData()
        {
#if DEBUG
            LoadData();
#endif
        }
        public void TestClick(int e)
        {
#if DEBUG
            GetValues(e);
#endif
        }
    }
}
