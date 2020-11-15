using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.DAO;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;
using QLBH.Core.Printers;
using QLBH.Core.Printers.Godex;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class misTestUnit
    {
        public misTestUnit()
        {
            //ConnectionUtil.Instance.IsUAT = 3;
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.TestLogin("quantri", "khong biet dau");

        }

        [TestMethod]
        public void TestNhapDieuChuyen()
        {
            frm_DanhSachPhieuNhapDieuChuyen frm = new frm_DanhSachPhieuNhapDieuChuyen();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestBaoCaoDieuChuyenKhoTongGiao()
        {
            frm_BaoCaoDieuChuyenKhoTongGiao frm = new frm_BaoCaoDieuChuyenKhoTongGiao();
            frm.ShowDialog();
        }

        [TestMethod]
        public void Test1()
        {
            //AppViewManager.Instance.CreateView<FrmTrungTamList>("TrungTamListView").ShowDialog();
        }

        [TestMethod]
        public void Test2()
        {
            //AppViewManager.Instance.CreateView("QLBanHang.Modules.Demo.FrmTrungTamList", "TrungTamListView").ShowDialog();
        }

        [TestMethod]
        public void TestHuyDieuChuyen()
        {
            int idKhoXuat = 7, idKhoNhan = 0, idSanPham = 56586;
            string soChungTuXuat = "PXDC-140314";
            HangTonKhoInfo hangTonKhoXuatInfoBefor = null;
            HangTonKhoInfo hangTonKhoXuatTGInfoBefor = null;
            HangTonKhoInfo hangTonKhoNhanInfoBefor = null;
            HangTonKhoInfo hangTonKhoNhanTGInfoBefor = null;
            HangTonKhoInfo hangTonKhoXuatInfoAfter = null;
            HangTonKhoInfo hangTonKhoXuatTGInfoAfter = null;
            HangTonKhoInfo hangTonKhoNhanInfoAfter = null;
            HangTonKhoInfo hangTonKhoNhanTGInfoAfter = null;

            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo = null;
            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenTGInfo = null;
            ChungTuNhapDieuChuyenInfo chungTuNhanDieuChuyenTGInfo = null;
            ChungTuNhapDieuChuyenInfo chungTuNhanDieuChuyenInfo = null;

            chungTuXuatDieuChuyenInfo =
                DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenBySoChungTu(soChungTuXuat);

            chungTuNhanDieuChuyenTGInfo =
                DeNghiNhapDieuChuyenTGDataProvider.Instance.GetChungTuNhanDCTGBySoCTGoc(soChungTuXuat);

            chungTuNhanDieuChuyenInfo =
                DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(chungTuXuatDieuChuyenInfo.SoChungTu);

            if (chungTuNhanDieuChuyenInfo != null)
                chungTuXuatDieuChuyenTGInfo =
                    DeNghiXuatDieuChuyenTGDataProvider.Instance.GetChungTuXuatDCTGBySoCTGoc(
                        chungTuNhanDieuChuyenInfo.SoChungTu);

            
            frm_DanhSachPhieuDeNghiXuatDieuChuyen frmTest = new frm_DanhSachPhieuDeNghiXuatDieuChuyen();

            hangTonKhoXuatInfoBefor =
                HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuXuatDieuChuyenInfo.IdKho, idSanPham, 0);

            if(chungTuNhanDieuChuyenTGInfo != null)
                hangTonKhoNhanTGInfoBefor = HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuNhanDieuChuyenTGInfo.IdKho,
                                                                                     idSanPham, 0);

            if(chungTuNhanDieuChuyenInfo != null)
                hangTonKhoNhanInfoBefor = HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuNhanDieuChuyenInfo.IdKho, idSanPham, 0);

            if (chungTuXuatDieuChuyenTGInfo != null)
                hangTonKhoXuatTGInfoBefor = HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuXuatDieuChuyenTGInfo.IdKho, idSanPham, 0);


            frmTest.HuyDieuChuyen(chungTuXuatDieuChuyenInfo);

            hangTonKhoXuatInfoAfter =
                HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuXuatDieuChuyenInfo.IdKho, idSanPham, 0);
            

            Assert.AreEqual(hangTonKhoXuatInfoBefor.TonAo - hangTonKhoXuatInfoAfter.TonAo, -1);

            if(chungTuXuatDieuChuyenInfo.LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
            {
                Assert.AreEqual(hangTonKhoXuatInfoBefor.SoLuong - hangTonKhoXuatInfoAfter.SoLuong, -1);
            }

            if (chungTuNhanDieuChuyenTGInfo != null && chungTuNhanDieuChuyenInfo == null)
            {
                hangTonKhoNhanTGInfoAfter = HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuNhanDieuChuyenTGInfo.IdKho,
                                                                                     idSanPham, 0);
                //điều chuyển khác trung tâm, chưa có đề nghị nhận
                Assert.AreEqual(hangTonKhoNhanTGInfoBefor.TonAo - hangTonKhoNhanTGInfoAfter.TonAo, 1);

                if(chungTuNhanDieuChuyenTGInfo.LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN_TRUNG_GIAN))
                {
                    Assert.AreEqual(hangTonKhoNhanTGInfoBefor.SoLuong - hangTonKhoNhanTGInfoAfter.SoLuong, 1);
                }
            }

            if (chungTuNhanDieuChuyenInfo != null)
            {
                hangTonKhoNhanInfoAfter = HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuNhanDieuChuyenInfo.IdKho, idSanPham, 0);
                
                //đã có đề nghị nhận
                Assert.AreEqual(hangTonKhoNhanInfoBefor.TonAo - hangTonKhoNhanInfoAfter.TonAo, 1);
            }

            //if (chungTuXuatDieuChuyenTGInfo != null)
            //{
            //    hangTonKhoXuatTGInfoAfter = HangTonKhoDAO.Instance.GetHangTonKhoById(chungTuXuatDieuChuyenTGInfo.IdKho, idSanPham, 0);
            //}
        }

        [TestMethod]
        public void TestDAO()
        {
            DeNghiNhanDieuChuyenDAO.Instance.GetChungTuNhanDCBySoCTGoc("PXDC-13031000845");
        }

        [TestMethod]
        public void RemoveAllTest()
        {
            List<int> list1 = new List<int> {1, 2, 3, 4, 5};
            List<int> list2 = new List<int> { 1, 3, 5 };
            list1.RemoveAll(
                delegate(int matchRemove)
                    {
                        return !list2.Exists(
                            delegate(int matchExists)
                                {
                                    return matchExists == matchRemove;
                                });
                    });
            Assert.AreEqual(true, !list1.Contains(2) && !list1.Contains(4) &&
                list1.Contains(1) && list1.Contains(3) && list1.Contains(5));
        }

        [TestMethod]
        public void RemoveEffect()
        {
            var lst = new List<int[]>();
            
            for(int i = 3; i < 1003; i++)
            {
                lst.Add(new [] {i, i + 1, i + 2});

                Debug.Print(String.Format("{0},{1},{2}", 
                    lst[lst.Count - 1][0],
                    lst[lst.Count - 1][1],
                    lst[lst.Count - 1][2]));
            }
            
            Test(lst, 3);

            //Assert.AreEqual(item.Count, 10000);
        }

        private void Test(List<int[]>lst, int n)
        {
            var item = new List<int[]>();
            
            for (int i = 0; i < lst.Count; i++)
            {
                if ((lst[i])[0]%n == 0)
                {
                    item.Add(lst[i]);
                    lst.RemoveAt(i);
                    Thread.CurrentThread.Join(500);
                    i--;
                }

                //Thread.Sleep(1000);
            }

            if (item.Count > 0)
                Debug.Print(String.Format("Output {0}:", n));

            for (int i = 0; i < item.Count; i++)
            {
                Debug.Print(String.Format("{0},{1},{2}",
                    item[i][0],
                    item[i][1],
                    item[i][2]));
            }

            if (lst.Count > 0)
                Test(lst, n + 1);
        }

        [TestMethod]
        public void TestMatchRegex()
        {
            Regex reg = new Regex("'.+'");
            MatchCollection matches = reg.Matches(
                @"create or replace procedure sp_GetComputeStorages(p_RunningDate date,
																									p_Cursor      out sys_refcursor) is
begin
	open p_Cursor for
		select ct.idtrungtam
			from tbl_chungtu ct
		 where ((ct.loaichungtu in (8, 9, 10, 35, 36, 50) and
					 ct.ngaylap >= to_date(p_RunningDate, 'dd/mm/rrrr hh24:mi:ss') and
					 ct.ngaylap <
					 to_date(p_RunningDate, 'dd/mm/rrrr hh24:mi:ss') + 1 / 24) or
					 (ct.loaichungtu in (33, 42) and
					 ct.ngayxuathang >=
					 to_date(p_RunningDate, 'dd/mm/rrrr hh24:mi:ss') and
					 ct.ngayxuathang <
					 to_date(p_RunningDate, 'dd/mm/rrrr hh24:mi:ss') + 1 / 24));
end;");

            foreach (Match match in matches)
            {
                Debug.Print(match.Value);                
            }
        }

        [TestMethod]
        public void TestCommandText()
        {
            List<ChungTuNhapDieuChuyenInfo> result = DeNghiNhanDieuChuyenDAO.Instance.GetListChungTuNhapDieuChuyen("PXDC-140211813", 3);

            result = DeNghiNhanDieuChuyenDAO.Instance.GetListChungTuNhapDieuChuyen("PXDC-140211812", 3);
            
            Assert.AreEqual(
                result.TrueForAll(delegate(ChungTuNhapDieuChuyenInfo match)
                                      {
                                          return match.LoaiChungTu == 21 && match.TrangThai == 3;
                                      }), true);
        }

        [TestMethod]
        public void TestGetListString()
        {
            CommonProvider.Instance.LogClientInfo();
        }

        [TestMethod]
        public void TestDeNghiXuatTieuHao()
        {
            frm_DanhSachPhieuDeNghiXuatTHnew frm = new frm_DanhSachPhieuDeNghiXuatTHnew();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestXuatTieuHao()
        {
            var frm = new frm_DanhSachPhieuXuatTieuHaonew();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestGetFiles()
        {
            var result = Directory.GetFiles(@"E:\Projects\QLBanHang\SourceCode\QLBH.Win\bin\Release\SaleTid", "QLBH_Log*.txt");

            foreach (var s in result)
            {
                Debug.Print(s);
            }
        }
    }
}