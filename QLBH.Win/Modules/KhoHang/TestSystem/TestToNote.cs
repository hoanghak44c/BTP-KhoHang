using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBH.Core.Data;

namespace QLBanHang.TestSystem
{
    [TestClass]
    public class TestToNote
    {
        public TestToNote()
        {
            ConnectionUtil.Instance.IsUAT = 3;// 1: golive 2: test1  3 : test 
            frmLogin frmLogin = new frmLogin();
            frmLogin.TestLogin("quantri", "quantri");
        }
        
        [TestMethod]
        public void TestNoteSanPham()
        {
            frm_InNoteSanPham frm = new frm_InNoteSanPham();
            frm.ShowDialog();
        }
    }
}
