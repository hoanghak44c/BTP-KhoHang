using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Forms;
using QLBanHang.Modules;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBH.Core.Data;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class frmThongKeTonSanPham
    {
        private IfrmLoginTestView frmLogin;
        public frmThongKeTonSanPham()
        {
            ConnectionUtil.Instance.IsUAT = 1;
            frmLogin = new frmLogin();
            frmLogin.TestLogin("quantri", "khong biet dau");
        }

        [TestMethod]
        public void View()
        {
            frmThongKe_TonSanPham frm = new frmThongKe_TonSanPham();
            frm.ShowDialog();
        }
        [TestMethod]
        public void View1()
        {
            frmThongKe_TonSanPham_v01 frm = new frmThongKe_TonSanPham_v01();
            frm.ShowDialog();
        }
        [TestMethod]
        public void View3()
        {
            frm_BaoCaoXuatNhapTonLichSu frm = new frm_BaoCaoXuatNhapTonLichSu();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestBaoCaoTongHopNhapThanhPham()
        {
            frm_BaoCaoTongHopNhapXuatThanhPham frm = new frm_BaoCaoTongHopNhapXuatThanhPham();
            frm.ShowDialog();
        }
    }
}
