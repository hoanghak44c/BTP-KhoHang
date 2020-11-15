using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBH.Core.Data;

namespace QLBanHang.TestSystem
{
    [TestClass]
    public class BCBanHangTestSystem
    {
        public BCBanHangTestSystem()
        {
            ConnectionUtil.Instance.IsUAT = 1;
            frmLogin frmLogin = new frmLogin();
            frmLogin.TestLogin("quantri", "khong biet dau");
        }
        [TestMethod]
        public void TestMain()
        {
            Form frm = new frmMain();
            frm.ShowDialog();
        }
        
        [TestMethod]
        public void TestTinhTrangDonHang()
        {
            frmBC_TinhTrangDonHang frm = new frmBC_TinhTrangDonHang();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestTinhTrangBangGia()
        {
            frmBC_TinhTrangBangGia frm = new frmBC_TinhTrangBangGia();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBangGiaChiTiet()
        {
            frmBC_BangGiaChiTiet frm = new frmBC_BangGiaChiTiet();
            frm.DisplayTest();
            frm.ShowDialog();
        }
        [TestMethod]
        public void LichSuThayDoiBangGia()
        {
            frmBC_LichSuThayDoiGia frm = new frmBC_LichSuThayDoiGia();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestNoiBo()
        {
            frm_DanhSachPhieuNhapNoiBo frm = new frm_DanhSachPhieuNhapNoiBo();
            frm.ShowDialog();
        }
    }
}
