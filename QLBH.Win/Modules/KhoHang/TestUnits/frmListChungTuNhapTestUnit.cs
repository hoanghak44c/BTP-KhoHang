using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Forms;
using QLBanHang.Modules;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Core.Data;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class frmListChungTuNhapTestUnit
    {
        private IfrmLoginTestView frmLogin;
        public frmListChungTuNhapTestUnit()
        {
            ConnectionUtil.Instance.IsUAT = 1;
            frmLogin = new frmLogin();
            //frmLogin.TestLogin("Hangltt6", "100891");
            frmLogin.TestLogin("quangpv79", "141174");
        }

        [TestMethod]
        public void TestDeNghiNhanDieuChuyen()
        {
            frm_DanhSachPhieuDeNghiNhapDieuChuyen frm = new frm_DanhSachPhieuDeNghiNhapDieuChuyen();
            frm.ShowDialog();

        }
        [TestMethod]
        public void TestMainSystem()
        {
            //ConnectionUtil.Instance.IsUAT = true;
            //frmMain frmMain = new frmMain();
            //frmMain.ShowDialog();
        }
        [TestMethod]
        public void TestBCNhapTPChuaNhap()
        {
            frmBaoCaoThanhPhamSanXuatChuaXacNhan frm = new frmBaoCaoThanhPhamSanXuatChuaXacNhan();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBCTongHopLK()
        {
            frmBaoCaoTongHopGiaoDichNhapXuatLK frm = new frmBaoCaoTongHopGiaoDichNhapXuatLK();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBCNhapXuatPO()
        {
            frmBaoCaoCNhapXuatPOChuaXuat frm = new frmBaoCaoCNhapXuatPOChuaXuat();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBCChiTietLK()
        {
            frmBaoCaoChiTietGiaoDichNhapXuatLK frm = new frmBaoCaoChiTietGiaoDichNhapXuatLK();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBCChiTietPO()
        {
            frmBaoCaoChiTietNhapHangMua frm = new frmBaoCaoChiTietNhapHangMua();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestDanhSachnhapComBo()
        {
            frmDanhSachNhapComBo frm = new frmDanhSachNhapComBo();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestBCNhapHangMua()
        {
            frmBaoCaoDanhSachNhapHangMua frm = new frmBaoCaoDanhSachNhapHangMua();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestDanhSachnhapDoiMa()
        {
            frmDanhSachNhapDoiMa frm = new frmDanhSachNhapDoiMa();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestNhapReport()
        {
            frm_BaoCaoChiTietGiaoDichNhapHang frm = new frm_BaoCaoChiTietGiaoDichNhapHang();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestChitietSXReport()
        {
            frmBaoCaoChiTietSanXuat frm = new frmBaoCaoChiTietSanXuat();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestTongHopSXReport()
        {
            frmBaoCaoTongHopSanXuat frm = new frmBaoCaoTongHopSanXuat();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestMaVachSXReport()
        {
            frm_BaoCaoChiTietMaVachSanXuat frm = new frm_BaoCaoChiTietMaVachSanXuat();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestLenhSXchuanhapLKReport()
        {
            frm_BaoCaoLenhSXChuaXuatLK frm = new frm_BaoCaoLenhSXChuaXuatLK();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestSystem()
        {
            frm_ListChungTuNhap frmListChungTuNhap = new frm_ListChungTuNhap();
            frmListChungTuNhap.ShowDialog();
        }
        [TestMethod]
        public void TestTraPO()
        {
            frm_ListChungTuTraNCC frmListChungTuNhap = new frm_ListChungTuTraNCC();
            frmListChungTuNhap.ShowDialog();
        }
        [TestMethod]
        public void ChonHoaDon()
        {
            frmHoaDonGTGTreport frmListChungTuNhap = new frmHoaDonGTGTreport();
            frmListChungTuNhap.ShowDialog();
        }
        [TestMethod]
        public void BangGia()
        {
            //frmBangGiaReport frmListChungTuNhap = new frmBangGiaReport();
            //frmListChungTuNhap.ShowDialog();
        }
        [TestMethod]
        public void TestNhapTP()
        {
            frmDanhSachXuatLKSX frmListChungTuNhap = new frmDanhSachXuatLKSX();
            frmListChungTuNhap.ShowDialog();
        }
        [TestMethod]
        public void TestTachSX()
        {
            frmDanhSachTachThanhPhamSX frmListChungTuNhap = new frmDanhSachTachThanhPhamSX();
            frmListChungTuNhap.ShowDialog();
        }
        [TestMethod]
        public void TestXacNhan()
        {
            frmDanhSachXacNhanNhapThanhPham frmListChungTuNhap = new frmDanhSachXacNhanNhapThanhPham();
            frmListChungTuNhap.ShowDialog();
        }
        ~ frmListChungTuNhapTestUnit()
        {
            //frmLogin.TestLogin();
        }
        [TestMethod]
        public void Xuathuytieuhao()
        {
            frm_XuatHuyTieuHao frmxuatnoibo = new frm_XuatHuyTieuHao();
            frmxuatnoibo.ShowDialog();
        }
        [TestMethod]
        public void DSDNXuattieuhao()
        {
            frm_DanhSachPhieuDeNghiXuatTH frmDSDNxuattieuhao = new frm_DanhSachPhieuDeNghiXuatTH();
            frmDSDNxuattieuhao.ShowDialog();
        }
        [TestMethod]
        public void DSxuattieuhao()
        {
            frm_DanhSachPhieuXuatTieuHao frmxuattieuhao = new frm_DanhSachPhieuXuatTieuHao();
            frmxuattieuhao.ShowDialog();
        }
        [TestMethod]
        public void DSXuatNoiBo()
        {
            frm_DanhSachPhieuXuatNoiBo frmxuatNB = new frm_DanhSachPhieuXuatNoiBo();
            frmxuatNB.ShowDialog();
        }
        [TestMethod]
        public void DanhSachNhapNB()
        {
            frm_DanhSachPhieuNhapNoiBoTest frmDSNhapNB = new frm_DanhSachPhieuNhapNoiBoTest();
            frmDSNhapNB.ShowDialog();
        }
        [TestMethod]
        public void DanhSachPhieuDNXuatDieuChuyen()
        {
            frm_DanhSachDeNghiDieuChuyen frm = new frm_DanhSachDeNghiDieuChuyen();
            frm.ShowDialog();
        }
        [TestMethod]
        public void DanhSachXuatDieuChuyen()
        {
            frm_DanhSachDieuChuyen frm = new frm_DanhSachDieuChuyen();
            frm.ShowDialog();
        }
        [TestMethod]
        public void DanhSachDNNhanDieuChuyen()
        {
            frm_DanhSachDeNghiNhanDieuChuyen frm = new frm_DanhSachDeNghiNhanDieuChuyen();
            frm.ShowDialog();
        }
        [TestMethod]
        public void DanhSachPhieuNhanDieuChuyen()
        {
            frm_DanhSachPhieuNhanDieuChuyen frm = new frm_DanhSachPhieuNhanDieuChuyen();
            frm.ShowDialog();
        }
        [TestMethod]
        public void KiemKe()
        {
            frm_DanhSachPhieuKiemKe frm = new frm_DanhSachPhieuKiemKe();
            //frm.IsTestUnit = true;
            frm.ShowDialog();
        }

        [TestMethod]
        public void DotKiemKe()
        {
            frm_DanhSachDotKiemKe frm = new frm_DanhSachDotKiemKe();
            frm.ShowDialog();
        }

        [TestMethod]
        public void PhieuXuatKho()
        {
            frmPhieuXuatKhoReport frm = new frmPhieuXuatKhoReport();
            frm.ShowDialog();
        }
        [TestMethod]
        public void PhieuThu()
        {
            frmPhieuThureport frm = new frmPhieuThureport();
            frm.ShowDialog();
        }
    }
}
