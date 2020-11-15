using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.BanHang.Infors;
using QLBanHang.Modules.BanHang.Reports;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class TestPhieuBH : Form
    {
        public TestPhieuBH()
        {
            InitializeComponent();
        }

        #region Event bteSanPham
        private void bteSanPham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham frmLookUp = new frmLookUp_SanPham(true, String.Format("%{0}%", bteSanPham.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteSanPham.EditValue = String.Empty;
                bteSanPham.Tag = frmLookUp.SelectedItems;
                foreach (DMSanPhamInfo selectedItem in frmLookUp.SelectedItems)
                {
                    bteSanPham.EditValue += selectedItem.MaSanPham + ",";
                }
            }
        }
        private void bteSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_SanPham frmLookUp = new frmLookUp_SanPham(true, String.Format("%{0}%", bteSanPham.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteSanPham.Tag = frmLookUp.SelectedItems;
                    foreach (DMSanPhamInfo selectedItem in frmLookUp.SelectedItems)
                    {
                        bteSanPham.EditValue += selectedItem.MaSanPham + ",";
                    }
                }
            }
        }
        private void bteSanPham_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteSanPham.Text)) bteSanPham.Tag = null;
        }
        #endregion 

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>)bteSanPham.Tag;
            string Id = String.Empty;
            foreach (DMSanPhamInfo dmSanPhamInfo in listSP)
            {
                Id += dmSanPhamInfo.IdSanPham + ",";
            }
            List<TestHoaDonGTGTInfo> list =
                    NoteReportDataProvider.Instance.SanPhamGetByIdSanPham(Id);

            //int i = list.Count / 6 + (list.Count % 6 > 0 ? 1 : 0);
            //for (int j = 0; j < i; j++)
            //{
            //    QLBanHang.Modules.KhoHang.Reports.rpt_HoaDonGiaTriGiaTang rpt = new QLBanHang.Modules.KhoHang.Reports.rpt_HoaDonGiaTriGiaTang(Convert.ToDateTime(dtNgay.Value),
            //                                        txtTenDonVi.Text, txtDiaChi.Text, txtTenNguoiMua.Text,
            //                                        txtMaSoThue.Text,
            //                                        txtBoPhan.Text, txtNhanVienBH.Text, txtSoPhieu.Text,
            //                                        txtDienThoai.Text,
            //                                        txtDiaChiGiaoHang.Text, txtKhoXuat.Text, txtThoiGianGiaoHang.Text, txtTienChu.Text);

            //    List<TestHoaDonGTGTInfo> tmp = list.FindAll(delegate(TestHoaDonGTGTInfo math)
            //                     {
            //                         return list.IndexOf(math) >= j * 6 && list.IndexOf(math) <= (j + 1) * 6 - 1;
            //                     });
            //    rpt.DataSource = tmp;
            //    //rpt.Print();
            //    rpt.ShowPreview();
            //}
            //if (i == 1)
            //{
                QLBanHang.Modules.KhoHang.Reports.rpt_HoaDonGiaTriGiaTangNew rpt =
                    new QLBanHang.Modules.KhoHang.Reports.rpt_HoaDonGiaTriGiaTangNew(Convert.ToDateTime(dtNgay.Value),
                                                                         txtTenDonVi.Text, txtDiaChi.Text,
                                                                         txtTenNguoiMua.Text,
                                                                         txtMaSoThue.Text,
                                                                         txtBoPhan.Text, txtNhanVienBH.Text,
                                                                         txtSoPhieu.Text,
                                                                         txtDienThoai.Text,
                                                                         txtDiaChiGiaoHang.Text, txtKhoXuat.Text,
                                                                         txtThoiGianGiaoHang.Text, txtTienChu.Text);
                List<TestHoaDonGTGTInfo> lst = new List<TestHoaDonGTGTInfo>(list);
                rpt.DataSource = lst;
                rpt.ShowPreview();
            //}
            //else
            //{
            //    string soBK = CommonProvider.Instance.GetSoPhieu("BK");
            //    QLBanHang.Modules.KhoHang.Reports.rpt_HoaDonGTGT rpt =
            //        new QLBanHang.Modules.KhoHang.Reports.rpt_HoaDonGTGT(Convert.ToDateTime(dtNgay.Value),
            //                                                             txtTenDonVi.Text, txtDiaChi.Text,
            //                                                             txtTenNguoiMua.Text,
            //                                                             txtMaSoThue.Text,
            //                                                             txtBoPhan.Text, txtNhanVienBH.Text,
            //                                                             txtSoPhieu.Text,
            //                                                             txtDienThoai.Text,
            //                                                             txtDiaChiGiaoHang.Text, txtKhoXuat.Text,
            //                                                             txtThoiGianGiaoHang.Text, txtTienChu.Text,soBK);
            //    List<TestHoaDonGTGTInfo> lst = new List<TestHoaDonGTGTInfo>(list);
            //    rpt.DataSource = lst;
            //    rpt.ShowPreview();
            //    QLBanHang.Modules.KhoHang.Reports.rpt_BangKeHoaDonGTGT rpt1 =
            //        new QLBanHang.Modules.KhoHang.Reports.rpt_BangKeHoaDonGTGT(Convert.ToDateTime(dtNgay.Value),
            //                                                             txtTenDonVi.Text, txtDiaChi.Text,
            //                                                             txtTenNguoiMua.Text,
            //                                                             txtMaSoThue.Text,
            //                                                             txtBoPhan.Text, txtNhanVienBH.Text,
            //                                                             txtSoPhieu.Text,
            //                                                             txtDienThoai.Text,
            //                                                             txtDiaChiGiaoHang.Text, txtKhoXuat.Text,
            //                                                             txtThoiGianGiaoHang.Text, txtTienChu.Text, soBK);
            //    List<TestHoaDonGTGTInfo> lst1 = new List<TestHoaDonGTGTInfo>(list);
            //    rpt1.DataSource = lst1;
            //    rpt1.ShowPreview();
            //}
        }

        private void TestPhieuBH_Load(object sender, EventArgs e)
        {
            txtMaSoThue.Text = "12345678";
            txtNhanVienBH.Text = "Trần Tuấn Cường";
            txtSoPhieu.Text = "OD-1305113434";
            txtTenDonVi.Text = "Công ty cổ phần thế giới số Trần Anh";
            txtTenNguoiMua.Text = "Bùi Đức Hạnh";
            txtThoiGianGiaoHang.Text = "1 ngày";
            txtTienChu.Text = "Mười Một triệu năm trăm ngàn đồng chẵn";
            txtKhoXuat.Text = "LA1.01.KD";
            txtDiaChi.Text = "1174 đường láng - Đống Đa - Hà Nội";
            txtDienThoai.Text = "01664.262.004";
            txtBoPhan.Text = "Phòng kinh doanh thị trường";
            txtDiaChiGiaoHang.Text = "1174 đường láng - Đống Đa - Hà Nội";
        }
    }
}
