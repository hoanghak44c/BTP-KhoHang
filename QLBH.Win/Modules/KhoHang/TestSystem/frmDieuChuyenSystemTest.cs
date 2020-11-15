using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.BanHang;
using QLBH.Common;
using QLBH.Core.Data;

namespace QLBanHang.TestSystem
{
    public partial class frmDieuChuyenSystemTest : DevExpress.XtraEditors.XtraForm
    {
        public frmDieuChuyenSystemTest()
        {
            InitializeComponent();
        }

        private void btnDeNghiDieuChuyen_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiXuatDieuChuyen frm = new frm_DanhSachPhieuDeNghiXuatDieuChuyen();
            frm.ShowDialog();
        }

        private void btnDieuChuyen_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuXuatDieuChuyen frm = new frm_DanhSachPhieuXuatDieuChuyen();
            frm.ShowDialog();
        }

        private void frmDieuChuyenKhoSystemTest_Load(object sender, EventArgs e)
        {
            lblYouAre.Text = String.Format("User: {0}", Declare.UserName);
            lblKho.Text = String.Format("Kho: {0}", Declare.IdKho);
        }

        private void btnChangeLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            lblYouAre.Text = String.Format("User: {0}", Declare.UserName);
            lblKho.Text = String.Format("Kho: {0}", Declare.IdKho);
        }

        private void btnThietLapKhoHienTai_Click(object sender, EventArgs e)
        {
            frmThietLapCaLamViec frm = new frmThietLapCaLamViec(2);
            frm.ShowDialog();
            lblKho.Text = String.Format("Kho: {0}", Declare.IdKho);
        }

        private void btnBaoCaoTon_Click(object sender, EventArgs e)
        {
            frmThongKe_TonSanPham_v01 frm = new frmThongKe_TonSanPham_v01();
            frm.ShowDialog();
        }

        private void btnDeNghiNhanDieuChuyen_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiNhapDieuChuyen frm = new frm_DanhSachPhieuDeNghiNhapDieuChuyen();
            frm.ShowDialog();
        }

        private void btnNhapKhoDieuChuyen_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuNhanDieuChuyen frm = new frm_DanhSachPhieuNhanDieuChuyen();
            frm.ShowDialog();
        }

        private void btnNhapNoiBo_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuNhapNoiBo frm = new frm_DanhSachPhieuNhapNoiBo();
            frm.ShowDialog();
        }

        private void btnKiemKe_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuKiemKe frm = new frm_DanhSachPhieuKiemKe();
            frm.IsTestUnit = true;
            frm.ShowDialog();
        }

        private void btnDeNghiXTH_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiXuatTHnew frm = new frm_DanhSachPhieuDeNghiXuatTHnew();
            frm.ShowDialog();
        }

        private void btnXTH_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuXuatTieuHaonew frm = new frm_DanhSachPhieuXuatTieuHaonew();
            frm.ShowDialog();

        }

        private void btnXuatNoiBo_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuXuatNoiBo frm = new frm_DanhSachPhieuXuatNoiBo();
            frm.ShowDialog();
        }

        private void btnBCDCK_Click(object sender, EventArgs e)
        {
            frm_BaoCaoChiTietHangChuyenKho frm = new frm_BaoCaoChiTietHangChuyenKho();
            frm.ShowDialog();
        }

        private void btnTieuHao_Click(object sender, EventArgs e)
        {
            frm_BaoCaoTongHopXuatTieuHao frm = new frm_BaoCaoTongHopXuatTieuHao();
            frm.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frmBC_LichSuMaVach frm = new frmBC_LichSuMaVach();
            //frm.ShowDialog();
        }

        private void btnBCTon_Click(object sender, EventArgs e)
        {
            frm_BaoCaoDanhMuc frm = new frm_BaoCaoDanhMuc();
            frm.ShowDialog();
        }

        private void btnInNote_Click(object sender, EventArgs e)
        {
            frm_InNoteSanPham frm = new frm_InNoteSanPham();
            frm.ShowDialog();
        }

        private void btnInBH_Click(object sender, EventArgs e)
        {
            TestPhieuBH frm = new TestPhieuBH();
            frm.ShowDialog();
        }

        private void btnDNNhapTieuHao_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiNhapTH frm = new frm_DanhSachPhieuDeNghiNhapTH();
            frm.ShowDialog();
        }

        private void btnNhapTieuHao_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuNhapTieuHao frm = new frm_DanhSachPhieuNhapTieuHao();
            frm.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmBaoCaoDanhSachNhapNoiBo frm = new frmBaoCaoDanhSachNhapNoiBo();
            frm.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmBaoCaoChiTietNhapNoiBo frm = new frmBaoCaoChiTietNhapNoiBo();
            frm.ShowDialog();
        }

        private void btnDanhSachXuatNB_Click(object sender, EventArgs e)
        {
            frmBaoCaoDanhSachXuatNoiBo frm = new frmBaoCaoDanhSachXuatNoiBo();
            frm.ShowDialog();
        }

        private void btnChiTietXuatNB_Click(object sender, EventArgs e)
        {
            frmBaoCaoChiTietXuatNoiBo frm = new frmBaoCaoChiTietXuatNoiBo();
            frm.ShowDialog();
        }

        private void btnDeNghiDieuChuyenTG_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiXuatDieuChuyen frm = new frm_DanhSachPhieuDeNghiXuatDieuChuyen();
            frm.ShowDialog();
        }

        private void btnDieuChuyenTG_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuXuatDieuChuyen frm = new frm_DanhSachPhieuXuatDieuChuyen();
            frm.ShowDialog();
        }

        private void btnDeNghiNhanDCTG_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiNhapDieuChuyen frm = new frm_DanhSachPhieuDeNghiNhapDieuChuyen();
            frm.ShowDialog();
        }

        private void btnNhapKhoDieuChuyenTG_Click(object sender, EventArgs e)
        {
            frm_DanhSachPhieuNhapDieuChuyen frm = new frm_DanhSachPhieuNhapDieuChuyen();
            frm.ShowDialog();
        }

        private void btnDotKiemKe_Click(object sender, EventArgs e)
        {
            frm_DanhSachDotKiemKe frm = new frm_DanhSachDotKiemKe();
            frm.ShowDialog();
        }

        private void btnTestSth_Click(object sender, EventArgs e)
        {
            Process[] currentProcesses = Process.GetProcessesByName("QLBanHang.exe", "thomnt");
            foreach (Process currentProcess in currentProcesses)
            {
                MessageBox.Show(currentProcess.ProcessName);
                MessageBox.Show(currentProcess.MachineName);                
            }
        }
    }
}