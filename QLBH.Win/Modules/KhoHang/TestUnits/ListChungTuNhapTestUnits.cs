using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class ListChungTuNhapTestUnits
    {
        private IfrmLoginTestView frmLogin;
        private static string sophieu = "PN010007000000004";
        public ListChungTuNhapTestUnits()
        {
            frmLogin = new frmLogin();
            frmLogin.TestLogin("quantri", "quantri");

            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(sophieu);
            if (li.Count > 0)
            {
                tblChungTuDataProvider.Delete("PN010007000000004"); 
            }
        }
        
        [TestMethod]
        public void TestDelete()
        {
            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(sophieu);
            if (li.Count > 0)
            {
                tblChungTuDataProvider.Delete("PN010007000000008");
            }
        }
        [TestMethod]
        public void TestChungTu_InsertSuccess()
        {
            List<DMChungTuNhapInfo> li1 = tblChungTuDataProvider.Search(sophieu);
            if (li1.Count > 0)
            {
                tblChungTuDataProvider.Delete("PN010007000000004");
            }
            frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
            frm.PO = "PO010007000000004";
            frm.PhieuNhap = "PN010007000000004";
            frmChiTietChungTuNhapNcc frmchitiet = new frmChiTietChungTuNhapNcc(frm.OID,frm.PhieuNhap,frm.NgayLap.ToString(),frm.PO);
            frmchitiet.TestLoadData();
            //for (int i = 0; i < frmchitiet.liSanPhamOld.Count; i++)
            //{
            //    frmchitiet.TestClick(i);
            //    frmChungTuNhap_ChiTietHangHoaBase frmchitiethh = new frmChungTuNhap_ChiTietHangHoaBase(frmchitiet,frmchitiet.LiHangHoa);
            //    frmchitiethh.TestLoad();
            //    for (int j = 0; j < frmchitiet.LiHangHoa[0].SoLuong; j++)
            //    {
            //        if (frmchitiet.LiHangHoa[0].TrungMaVach == 0)
            //        {
            //            frmchitiethh.SetInput("1234567890");
            //            frmchitiethh.TestAddNew();
            //        }
            //        else
            //        {
            //            for (int k = 0; k < frmchitiet.LiHangHoa[0].SoLuong; k++)
            //            {
            //                frmchitiethh.SetInput("123456789" + k);
            //                frmchitiethh.TestAddNew();
            //            }
            //        }
            //    }
            //    frmchitiethh.TestSave();
            //}
            frmchitiet.TestSave();
            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(sophieu);
            Assert.AreEqual(li.Count, 1);
        }
        [TestMethod]
        public void TestChungTu_MaVachIsNotEmpTy()
        {
            try
            {
                frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
                frm.PO = "PO010007000000004";
                frm.PhieuNhap = "PN010007000000004";
                frmChiTietChungTuNhapNcc frmchitiet = new frmChiTietChungTuNhapNcc(frm.OID, frm.PhieuNhap, frm.NgayLap.ToString(), frm.PO);
                frmchitiet.TestLoadData();
                //for (int i = 0; i < frmchitiet.liSanPhamOld.Count; i++)
                //{
                //    frmchitiet.TestClick(i);
                //    frmChungTuNhap_ChiTietHangHoaBase frmchitiethh = new frmChungTuNhap_ChiTietHangHoaBase(frmchitiet, frmchitiet.LiHangHoa);
                //    frmchitiethh.TestLoad();
                //    for (int j = 0; j < frmchitiet.LiHangHoa[0].SoLuong; j++)
                //    {
                //        frmchitiethh.SetInput("");
                //        frmchitiethh.TestAddNew();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Mã vạch không được để trống !");
            }
        }
        [TestMethod]
        public void TestChungTu_VuotQuaSoLuongMaVach()
        {
            try
            {
                frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
                frm.PO = "PO010007000000004";
                frm.PhieuNhap = "PN010007000000004";
                frmChiTietChungTuNhapNcc frmchitiet = new frmChiTietChungTuNhapNcc(frm.OID, frm.PhieuNhap, frm.NgayLap.ToString(), frm.PO);
                frmchitiet.TestLoadData();
                //for (int i = 0; i < frmchitiet.liSanPhamOld.Count; i++)
                //{
                //    frmchitiet.TestClick(i);
                //    frmChungTuNhap_ChiTietHangHoaBase frmchitiethh = new frmChungTuNhap_ChiTietHangHoaBase(frmchitiet, frmchitiet.LiHangHoa);
                //    frmchitiethh.TestLoad();
                //    for (int j = 0; j < frmchitiet.LiHangHoa[0].SoLuong+1; j++)
                //    {
                //        frmchitiethh.SetInput("0123456789");
                //        frmchitiethh.TestAddNew();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Số lượng mã vạch đã đủ. Không thể nhập thêm !");
            }
        }
        [TestMethod]
        public void TestChungTu_TrungMaVach()
        {
            try
            {
                frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
                frm.PO = "PO010007000000004";
                frm.PhieuNhap = "PN010007000000004";
                frmChiTietChungTuNhapNcc frmchitiet = new frmChiTietChungTuNhapNcc(frm.OID, frm.PhieuNhap, frm.NgayLap.ToString(), frm.PO);
                frmchitiet.TestLoadData();
                //for (int i = 0; i < frmchitiet.liSanPhamOld.Count; i++)
                //{
                //    frmchitiet.TestClick(i);
                //    frmChungTuNhap_ChiTietHangHoaBase frmchitiethh = new frmChungTuNhap_ChiTietHangHoaBase(frmchitiet, frmchitiet.LiHangHoa);
                //    frmchitiethh.TestLoad();
                //    frmchitiet.LiHangHoa[0].TrungMaVach = 1;
                //    for (int j = 0; j < frmchitiet.LiHangHoa[0].SoLuong + 1; j++)
                //    {
                //        frmchitiethh.SetInput("0123456789");
                //        frmchitiethh.TestAddNew();
                //    }
                //}
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Mã vạch không được phép trùng nhau !");
            }
        }
        [TestMethod]
        public void TestChungTu_SoLuongMaVachChuaDu()
        {
            try
            {
                frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
                frm.PO = "PO010007000000004";
                frm.PhieuNhap = "PN010007000000004";
                frmChiTietChungTuNhapNcc frmchitiet = new frmChiTietChungTuNhapNcc(frm.OID, frm.PhieuNhap, frm.NgayLap.ToString(), frm.PO);
                frmchitiet.TestLoadData();
                //for (int i = 0; i < frmchitiet.liSanPhamOld.Count; i++)
                //{
                //    frmchitiet.TestClick(i);
                //    frmChungTuNhap_ChiTietHangHoaBase frmchitiethh = new frmChungTuNhap_ChiTietHangHoaBase(frmchitiet, frmchitiet.LiHangHoa);
                //    frmchitiethh.TestLoad();
                //    for (int j = 0; j < frmchitiet.LiHangHoa[0].SoLuong -1; j++)
                //    {
                //        if (frmchitiet.LiHangHoa[0].TrungMaVach == 0)
                //        {
                //            frmchitiethh.SetInput("1234567890");
                //            frmchitiethh.TestAddNew();
                //        }
                //        else
                //        {
                //            for (int k = 0; k < frmchitiet.LiHangHoa[0].SoLuong; k++)
                //            {
                //                frmchitiethh.SetInput("123456789" + k);
                //                frmchitiethh.TestAddNew();
                //            }
                //        }
                //    }
                //    frmchitiethh.TestSave();
                //}
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Bạn chưa thêm đủ số mã vạch !");
            }
        }
        [TestMethod]
        public void TestChungTu_SanPhamChuaDuMaVach()
        {
            try
            {
                frm_ListChungTuNhap frm = new frm_ListChungTuNhap();
                frm.PO = "PO010007000000004";
                frm.PhieuNhap = "PN010007000000004";
                frmChiTietChungTuNhapNcc frmchitiet = new frmChiTietChungTuNhapNcc(frm.OID, frm.PhieuNhap, frm.NgayLap.ToString(), frm.PO);
                frmchitiet.TestLoadData();
                //for (int i = 0; i < frmchitiet.liSanPhamOld.Count-1; i++)
                //{
                //    frmchitiet.TestClick(i);
                //    frmChungTuNhap_ChiTietHangHoaBase frmchitiethh = new frmChungTuNhap_ChiTietHangHoaBase(frmchitiet, frmchitiet.LiHangHoa);
                //    frmchitiethh.TestLoad();
                //    for (int j = 0; j < frmchitiet.LiHangHoa[0].SoLuong; j++)
                //    {
                //        if (frmchitiet.LiHangHoa[0].TrungMaVach == 0)
                //        {
                //            frmchitiethh.SetInput("1234567890");
                //            frmchitiethh.TestAddNew();
                //        }
                //        else
                //        {
                //            for (int k = 0; k < frmchitiet.LiHangHoa[0].SoLuong; k++)
                //            {
                //                frmchitiethh.SetInput("123456789" + k);
                //                frmchitiethh.TestAddNew();
                //            }
                //        }
                //    }
                //    frmchitiethh.TestSave();
                //}
                //frmchitiet.TestSave();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Bạn chưa nhập đủ mã vạch cho các sản phẩm !");
            }
        }
    }
}
