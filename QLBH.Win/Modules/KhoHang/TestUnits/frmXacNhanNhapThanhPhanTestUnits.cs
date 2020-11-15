using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class frmXacNhanNhapThanhPhanTestUnits
    {
        private IfrmLoginTestView frmLogin;
        public frmXacNhanNhapThanhPhanTestUnits()
        {
            frmLogin = new frmLogin();
            frmLogin.TestLogin("cuongtran", "cuongtt");            
        }

        [TestMethod]
        public void NhapThanhPhamSanXuat()
        {
            frmDanhSachXacNhanNhapThanhPham frm = new frmDanhSachXacNhanNhapThanhPham();
            frm.ShowDialog();
        }
    }
}
