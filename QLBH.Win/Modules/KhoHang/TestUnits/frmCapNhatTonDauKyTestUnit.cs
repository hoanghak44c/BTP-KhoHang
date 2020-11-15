using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanHang.Forms;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBH.Core.Data;

namespace QLBanHang.TestUnits
{
    [TestClass]
    public class frmCapNhatTonDauKyTestUnit
    {
        private IfrmLoginTestView frmLogin;
        public frmCapNhatTonDauKyTestUnit()
        {
            ConnectionUtil.Instance.IsUAT = 1;
            frmLogin = new frmLogin();
            frmLogin.TestLogin("quantri", "khong biet dau");
        }

        [TestMethod]
        public void TestExportDuLieu()
        {
            frm_BaoCaoChiTietGiaoDichNhapHang frm = new frm_BaoCaoChiTietGiaoDichNhapHang();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestCapNhatTonDauKy()
        {
            frmCapNhatTonDauKy frm = new frmCapNhatTonDauKy();
            frm.ShowDialog();
        }

        [TestMethod]
        public void TestBaoCaoDongBoPO()
        {
            frm_BaoCaoDongBoPO frm = new frm_BaoCaoDongBoPO();
            frm.ShowDialog();
        }

        [TestMethod]
        public void ImportCauHinh()
        {
            frm_CauHinhSanPhamImport frm = new frm_CauHinhSanPhamImport();
            frm.ShowDialog();
        }

    }
}
