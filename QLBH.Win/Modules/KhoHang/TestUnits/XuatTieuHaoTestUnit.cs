using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Infors;
using QLBH.Core.Providers;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class XuatTieuHaoTestUnit
    {
        private static string soPhieu = "PXTH0100070000004";
        private ChungTuDeNghiXuatTieuHaoInfor deNghiXuatTieuHaoInfo;
        private ChungTuXuatTieuHaoInfor xuatTieuHaoInfo;
        public XuatTieuHaoTestUnit()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.TestLogin("hanhbd", "hanhbd");
            tblChungTuDataProvider.Delete("PXTH0100070000004");
        }
        [TestMethod]
        public void TestDeNghiXuatTieuHao()
        {
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);

            //tạo một chứng từ đề nghị xuất tiêu hao có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            deNghiXuatTieuHaoInfo = new ChungTuDeNghiXuatTieuHaoInfor()
            {
                SoChungTu = soPhieu,
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO),
                GhiChu = "Test Nghiệp Vụ",
                IdKho = Declare.IdKho
            };
            DeNghiXuatTieuHaoBusiness deNghiXuatTieuHaoBusiness = new DeNghiXuatTieuHaoBusiness(deNghiXuatTieuHaoInfo);
            deNghiXuatTieuHaoBusiness.ListChiTietChungTu.Add(new DeNghiXuatTieuHaoChiTietInfo()
            {
                IdSanPham = 279,
                SoLuong = 2
            });
            //deNghiXuatTieuHaoBusiness.ListChiTietChungTu.Add(new DeNghiXuatTieuHaoChiTietInfo
            //{
            //    IdSanPham = 279,
            //    MaVach = "1234TESTNGHIEPVU",
            //    SoLuong = 1
            //});
            //deNghiXuatTieuHaoBusiness.ListChiTietChungTu.Add(new DeNghiXuatTieuHaoChiTietInfo
            //{
            //    IdSanPham = 279,
            //    MaVach = "5678TESTNGHIEPVU",
            //    SoLuong = 1
            //});
            deNghiXuatTieuHaoBusiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong, hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo - 2, hangTonKhoSauKhiXuat.TonAo);
        }

        [TestMethod]
        public void TestXuatTieuHao()
        {
            TestDeNghiXuatTieuHao();
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);

            //tạo một chứng từ xuất tiêu hao có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            xuatTieuHaoInfo = new ChungTuXuatTieuHaoInfor
                  {
                      IdChungTu = deNghiXuatTieuHaoInfo.IdChungTu,
                      SoChungTu = soPhieu,
                      LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO),
                      GhiChu = "Test Nghiệp Vụ",
                      IdKho = Declare.IdKho
                  };
            XuatKhoTieuHaoBusiness xuatKhoTieuHaoBusiness = new XuatKhoTieuHaoBusiness(xuatTieuHaoInfo);
            xuatKhoTieuHaoBusiness.ListChiTietChungTu.Add(new ChungTu_ChiTietInfo
            {
                IdSanPham = 279,
                SoLuong = 2,
            });
            xuatKhoTieuHaoBusiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "3456TESTNGHIEPVU",
                SoLuong = 1
            });
            xuatKhoTieuHaoBusiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "5678TESTNGHIEPVU",
                SoLuong = 1
            });
            xuatKhoTieuHaoBusiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong - 2, hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo, hangTonKhoSauKhiXuat.TonAo);
        }
    }
}
