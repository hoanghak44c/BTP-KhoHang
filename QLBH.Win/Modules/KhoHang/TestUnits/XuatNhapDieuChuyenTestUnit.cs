using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Infors;
using QLBH.Core.Providers;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class XuatNhapDieuChuyenTestUnit
    {
        private static string soPhieu = "PXTH0100070000004";
        private ChungTuDieuChuyenInfor deNghiXuatDieuChuyenInfor;
        private ChungTuDieuChuyenInfor xuatDieuChuyenInfor;
        private ChungTuNhapDieuChuyenInfor deNghiNhanDieuChuyenInfor;
        private ChungTuNhapDieuChuyenInfor nhanDieuChuyenInfor;
        public XuatNhapDieuChuyenTestUnit()
        {
            ConnectionUtil.Instance.IsUAT = 1;
            frmLogin frmLogin = new frmLogin();
            //frmLogin.TestLogin("Hangltt6", "100891");
            frmLogin.TestLogin("quangnd3940", "khong biet dau");

            Declare.SYSDATE = CommonProvider.Instance.GetSysDate();
        }
        [TestMethod]
        public void TestDeNghiXuatDieuChuyen()
        {
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);

            //tạo một chứng từ đề nghị xuất tiêu hao có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            deNghiXuatDieuChuyenInfor = new ChungTuDieuChuyenInfor()
            {
                SoChungTu = soPhieu,
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN),
                GhiChu = "Test Nghiệp Vụ",
                IdKho = Declare.IdKho
            };
            DeNghiDieuChuyenBussiness deNghiDieuChuyenBussiness = new DeNghiDieuChuyenBussiness(deNghiXuatDieuChuyenInfor);
            deNghiDieuChuyenBussiness.ListChiTietChungTu.Add(new DeNghiDieuChuyenInfor
            {
                IdSanPham = 279,
                SoLuong = 2
            });
            deNghiDieuChuyenBussiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong, hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo - 2, hangTonKhoSauKhiXuat.TonAo);
        }
        [TestMethod]
        public void TestXuatDieuChuyen()
        {
            TestDeNghiXuatDieuChuyen();
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);

            //tạo một chứng từ xuất tiêu hao có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            xuatDieuChuyenInfor = new ChungTuDieuChuyenInfor()
            {
                IdChungTu = deNghiXuatDieuChuyenInfor.IdChungTu,
                SoChungTu = soPhieu,
                LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN),
                GhiChu = "Test Nghiệp Vụ",
                IdKho = Declare.IdKho
            };
            XuatDieuChuyenBusiness xuatDieuChuyenBusiness = new XuatDieuChuyenBusiness(xuatDieuChuyenInfor);
            xuatDieuChuyenBusiness.ListChiTietChungTu.Add(new ChungTu_ChiTietInfo
            {
                IdSanPham = 279,
                SoLuong = 2
            });
            xuatDieuChuyenBusiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "1234TESTNGHIEPVU",
                SoLuong = 1
            });
            xuatDieuChuyenBusiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "5678TESTNGHIEPVU",
                SoLuong = 1
            });
            xuatDieuChuyenBusiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong - 4 , hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo, hangTonKhoSauKhiXuat.TonAo);
        }

        [TestMethod]
        public void TestDeNghiNhanDieuChuyen()
        {
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);

            //tạo một chứng từ đề nghị xuất tiêu hao có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            deNghiNhanDieuChuyenInfor = new ChungTuNhapDieuChuyenInfor()
            {
                SoChungTu = soPhieu,
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                GhiChu = "Test Nghiệp Vụ",
                IdKho = Declare.IdKho
            };
            DeNghiNhanDieuChuyenBussiness deNghiNhanDieuChuyenBussiness = new DeNghiNhanDieuChuyenBussiness(deNghiNhanDieuChuyenInfor);
            deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Add(new DeNghiNhanDieuChuyenInfor
            {
                IdSanPham = 279,
                SoLuong = 2
            });
            deNghiNhanDieuChuyenBussiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong, hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo - 2, hangTonKhoSauKhiXuat.TonAo);
        }
        [TestMethod]
        public void TestNhanDieuChuyen()
        {
            TestDeNghiNhanDieuChuyen();
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);

            //tạo một chứng từ xuất tiêu hao có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            nhanDieuChuyenInfor = new ChungTuNhapDieuChuyenInfor()
            {
                IdChungTu = deNghiNhanDieuChuyenInfor.IdChungTu,
                SoChungTu = soPhieu,
                LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                GhiChu = "Test Nghiệp Vụ",
                IdKho = Declare.IdKho
            };
            NhanDieuChuyenBussiness nhanDieuChuyenBussiness = new NhanDieuChuyenBussiness(nhanDieuChuyenInfor);
            nhanDieuChuyenBussiness.ListChiTietChungTu.Add(new ChungTu_ChiTietInfo
            {
                IdSanPham = 279,
                SoLuong = 2
            });
            nhanDieuChuyenBussiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "1234TESTNGHIEPVU",
                SoLuong = 1
            });
            nhanDieuChuyenBussiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "5678TESTNGHIEPVU",
                SoLuong = 1
            });
            nhanDieuChuyenBussiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong - 4, hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo, hangTonKhoSauKhiXuat.TonAo);
        }
        [TestMethod]
        public void TestDeNghiNhanDieuChuyenSys()
        {
            frm_DanhSachPhieuDeNghiNhapDieuChuyen frm = new frm_DanhSachPhieuDeNghiNhapDieuChuyen();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestDeNghiXuatDieuChuyenSys()
        {
            frm_DanhSachPhieuDeNghiXuatDieuChuyen frm = new frm_DanhSachPhieuDeNghiXuatDieuChuyen();
            frm.ShowDialog();
            
        }
        [TestMethod]
        public void TestXuatDieuChuyenSys()
        {
            frm_DanhSachPhieuXuatDieuChuyen frm = new frm_DanhSachPhieuXuatDieuChuyen();
            frm.ShowDialog();
        }
        [TestMethod]
        public void TestNhapDieuChuyenSys()
        {
            frm_DanhSachPhieuNhapDieuChuyen frm = new frm_DanhSachPhieuNhapDieuChuyen();
            frm.ShowDialog();
        }
    }
}