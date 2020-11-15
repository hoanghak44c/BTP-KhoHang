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
using QLBH.Core.Infors;
using QLBH.Core.Providers;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class NhapXuatNoiBoTestUnit
    {
        private static string soPhieu = "PXNB0100070000004";
        private ChungTuNhapNoiBoInfor nhapNBInfo;
        private ChungTuXuatNoiBoInfor xuatNBInfo;
        public NhapXuatNoiBoTestUnit()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.TestLogin("minhpn", "minhpn");
            
            //List<DMChungTuNhapInfo> li1 = tblChungTuDataProvider.Search(soPhieu);
            //if (li1.Count > 0)
            //{
            tblChungTuDataProvider.Delete("PXNB0100070000004");
            //}
            //frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
            //frm.PhieuNhap = "PXNB0100070000004";
            //frm_PhieuXuatNoiBo frmchitiet = new frm_PhieuXuatNoiBo(frm.OID, frm.PhieuNhap, frm.NgayLap.ToString(), frm.PO);
            //frmchitiet.TestLoadData();
            
            //frmchitiet.TestSave();
            //List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(soPhieu);
            //Assert.AreEqual(li.Count, 1);
            //xóa hết các chứng từ nhập xuất nội bộ có số là ABC1, ABC2 đang có trong hệ thống
            //bao gồm các chi tiết của chứng từ đó
            //set lại số lượng tồn trong kho về một số ban đầu cụ thể
            //if (li.Count > 0)
            //{
            //    tblChungTuDataProvider.Delete("PXNB0100070000004");
            //}
        }

        [TestMethod]
        public void TestNhapNoiBo()
        {
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //Ma san pham: 06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 270, 0);
            
            //tạo một chứng từ nhập nội bộ có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            //số phiếu : PNNB0100070000001
            nhapNBInfo = new ChungTuNhapNoiBoInfor
                             {
                                 SoChungTu = soPhieu,
                                 LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_NOIBO),
                                 GhiChu = "Test Nghiệp Vụ",
                                 IdKho = Declare.IdKho
                             };
            NhapNoiBoBussiness nhapBusiness = new NhapNoiBoBussiness(nhapNBInfo);
            nhapBusiness.ListChiTietChungTu.Add(new ChungTu_ChiTietInfo
                                                    {
                                                        IdSanPham = 270,
                                                        SoLuong = 20
                                                    });
            nhapBusiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
                                                    {
                                                        IdSanPham = 270,
                                                        MaVach = "MINHPN005",
                                                        SoLuong = 10
                                                    });
            nhapBusiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
                                                    {
                                                        IdSanPham = 270,
                                                        MaVach = "MINHPN006",
                                                        SoLuong = 10
                                                    });
            nhapBusiness.SaveChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng olà 7)
            HangTonKhoInfo hangTonKhoSauKhiNhap = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 270, 0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong + 20, hangTonKhoSauKhiNhap.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo + 20, hangTonKhoSauKhiNhap.TonAo);
        }

        [TestMethod]
        public void TestXuatNoiBo()
        {
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 7)
            //Mã sản phẩm :06000178 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279,0);
            //tạo một chứng từ xuất nội bộ có số là ABC2, xuất sản phẩm xxx với số lượng xuất là 2
            xuatNBInfo = new ChungTuXuatNoiBoInfor
            {
                SoChungTu = soPhieu,
                LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_NOI_BO),
                GhiChu = "Test Nghiệp Vụ",
                IdKho = Declare.IdKho
            };
            XuatNoiBoBussiness xuatNoiBoBussiness = new XuatNoiBoBussiness(xuatNBInfo);
            xuatNoiBoBussiness.ListChiTietChungTu.Add(new ChungTu_ChiTietInfo
            {
                IdSanPham = 279,
                SoLuong = 2
            });
            xuatNoiBoBussiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "1234TESTNGHIEPVU",
                SoLuong = 1
            });
            xuatNoiBoBussiness.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
            {
                IdSanPham = 279,
                MaVach = "5678TESTNGHIEPVU",
                SoLuong = 1
            });
            xuatNoiBoBussiness.SaveChungTu();
            //Lấp số tồn kho của sản phẩm xxx (kết quả mong đợi là 5)
            HangTonKhoInfo hangTonKhoSauKhiXuat = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279, 0);
            //Kiểm tra có đúng là ban đầu - kết quả mong đợi có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong - 2,hangTonKhoSauKhiXuat.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo - 2 , hangTonKhoSauKhiXuat.TonAo);
        }

        [TestMethod]
        public void TestXoaNhapNoiBo()
        {
            TestNhapNoiBo();

            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 7)
            //Mã sản phẩm :06000184 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279,0);
            //xóa chứng từ nhập nội bộ có số là ABC1, nhập sản phẩm xxx với số lượng nhập là 2
            NhapNoiBoBussiness nhapBusiness = new NhapNoiBoBussiness(nhapNBInfo);
            nhapBusiness.DeleteChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả mong đợi là 5)
            HangTonKhoInfo hangTonKhoSauKhiXoa = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279,0);
            //Kiểm tra có đúng là ban đầu - kết quả mong đợi có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong - 2,hangTonKhoSauKhiXoa.SoLuong);
        }
        [TestMethod]
        public void TestXoaXuatNoiBo()
        {
            TestXuatNoiBo();
            //Lấy số tồn kho của một sản phẩm có mã là xxx (ví dụ ban đầu là 5)
            //mã sản phẩm :06000166 - 279
            HangTonKhoInfo hangTonKhoBanDau = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279,0);
            //xóa chứng từ xuất nội bộ có số là ABC2, xuất sản phẩm xxx với số lượng xuất là 2
            XuatNoiBoBussiness xuatNoiBoBussiness = new XuatNoiBoBussiness(xuatNBInfo);
            xuatNoiBoBussiness.DeleteChungTu();

            //Lấp số tồn kho của sản phẩm xxx (kết quả hy vọng là 7)
            HangTonKhoInfo hangTonKhoSauKhiXoa = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, 279,0);
            //Kiểm tra có đúng là kết quả mong đợi - ban đầu có bằng 2 không?
            Assert.AreEqual(hangTonKhoBanDau.SoLuong + 2 ,hangTonKhoSauKhiXoa.SoLuong);
            Assert.AreEqual(hangTonKhoBanDau.TonAo + 2 , hangTonKhoSauKhiXoa.TonAo );
        }

    }
}
