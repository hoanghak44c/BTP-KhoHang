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
    public class TestDieuChuyen
    {
        public TestDieuChuyen()
        {
            ConnectionUtil.Instance.IsUAT = 1;// 1: golive 2: test1  3 : test 
            frmLogin frmLogin = new frmLogin();
            frmLogin.TestLogin("quantri", "khong biet dau");
        }
        
        [TestMethod]
        public void TestMainSystem()
        {
            Form frm = new frmMain(); //new frmDieuChuyenSystemTest();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestTonLichSu()
        {
            frmThongKe_XuatNhapTonLichSu frm = new frmThongKe_XuatNhapTonLichSu();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestBaoCaoKKTon()
        {
            frm_BaoCaoKiemKeTonKho frm = new frm_BaoCaoKiemKeTonKho();
            frm.ShowDialog();
        }
        
        [TestMethod]
        public void TestBaoCaoKKMaVach()
        {
            frm_BaoCaoKiemKeTonMaVach frm = new frm_BaoCaoKiemKeTonMaVach();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBv()
        {
            frm_BaoCaoChiTietGiaoDichNhapHang frm = new frm_BaoCaoChiTietGiaoDichNhapHang();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBaoCaoTongHopGiaoDichNhapHang()
        {
            frm_BaoCaoTongHopGiaoDichNhapHang frm = new frm_BaoCaoTongHopGiaoDichNhapHang();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBaoCaoDieuChuyenChoNhan()
        {
            frm_BaoCaoPhieuDieuChuyenChoNhan frm = new frm_BaoCaoPhieuDieuChuyenChoNhan();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBaoCaoKiemKe()
        {
            frm_BaoCaoTongHopKiemKe frm = new frm_BaoCaoTongHopKiemKe();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestDotKiemKe()
        {
            frm_DanhSachDotKiemKe frm = new frm_DanhSachDotKiemKe();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestBaoCaoDSKiemKe()
        {
            frm_BaoCaoDanhSachPhieuKiemKe frm = new frm_BaoCaoDanhSachPhieuKiemKe();
            frm.ShowDialog();
        }
        [TestMethod]
        public void frmBaoCaoXuatDoiLinhKienLoi()
        {
            frm_BaoCaoXuatDoiLinhKienLoi frm = new frm_BaoCaoXuatDoiLinhKienLoi();
            frm.ShowDialog();
        }
    }
}
