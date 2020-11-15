using System;
using System.Collections.Generic;
using System.Text;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChungTuNhap_ChiTietHangHoaBase
    {
        public void SetInput(string MaVach)
        {
#if DEBUG
            txtMaVach.Text = MaVach;
#endif
        }

        public void TestAddNew()
        {
#if DEBUG
            AddNew();
#endif
        }

        public void TestSave()
        {
#if DEBUG
            Save();
#endif
        }
        public void TestLoad()
        {
#if DEBUG
            LoadData();
#endif
        }
    }
}
