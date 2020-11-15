using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmBaoCaoChiTietSanXuat : DevExpress.XtraEditors.XtraForm
    {
        List<MaVachSXReportInfo> lichitiet = new List<MaVachSXReportInfo>();
        List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam;
        private int MaKho;
        private int IdTrungTam;
        public frmBaoCaoChiTietSanXuat()
        {
            InitializeComponent();
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadLoaiSanXuat()
        {
            lst.Add(new LookUp { OID = 7, Name = "Xuất linh kiện sản xuất" });
            lst.Add(new LookUp { OID = 44, Name = "Xuất ComBo" });
            lst.Add(new LookUp { OID = 46, Name = "Xuất đổi mã" });
            lst.Add(new LookUp { OID = 2, Name = "Nhập thành phẩm sản xuất" });
            lst.Add(new LookUp { OID = 43, Name = "Nhập ComBo" });
            lst.Add(new LookUp { OID = 45, Name = "Nhập đổi mã" });
            lst.Add(new LookUp { OID = 30, Name = "Tách thành phẩm sản xuất" });
            lst.Add(new LookUp { OID = 31, Name = "Nhập linh kiện sản xuất" });
            repLoaiSX.DataSource = null;
            repLoaiSX.DataSource = lst;
        }
        private void LoadLoaiGiaoDich()
        {
            List<LookUp> ligiaodich = new List<LookUp>();
            ligiaodich.Add(new LookUp { OID = 7, Name = "Xuất linh kiện sản xuất" });
            ligiaodich.Add(new LookUp { OID = 44, Name = "Xuất ComBo" });
            ligiaodich.Add(new LookUp { OID = 46, Name = "Xuất đổi mã" });
            ligiaodich.Add(new LookUp { OID = 2, Name = "Nhập thành phẩm sản xuất" });
            ligiaodich.Add(new LookUp { OID = 43, Name = "Nhập ComBo" });
            ligiaodich.Add(new LookUp { OID = 45, Name = "Nhập đổi mã" });
            ligiaodich.Add(new LookUp { OID = 30, Name = "Tách thành phẩm sản xuất" });
            ligiaodich.Add(new LookUp { OID = 31, Name = "Nhập linh kiện sản xuất" });
            lueLoaiGiaoDich.Properties.DataSource = null;
            lueLoaiGiaoDich.Properties.DataSource = ligiaodich;
            lueLoaiGiaoDich.EditValue = ligiaodich[0].OID;
        }
        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
                IdTrungTam = frm.SelectedItem.IdTrungTam;
                bteKho.Text = "";
            }
        }

        private void bteTrungTam_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
                IdTrungTam = frm.SelectedItem.IdTrungTam;
                bteKho.Text = "";
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Tag = frm.SelectedItem;
                    bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                    MaTrungTam = frm.SelectedItem.MaTrungTam;
                    IdTrungTam = frm.SelectedItem.IdTrungTam;
                    bteKho.Text = "";
                }
            }
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.IdKho;
            }
        }

        private void bteKho_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.IdKho;
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frm.SelectedItem;
                    bteKho.Text = frm.SelectedItem.TenKho;
                    MaKho = frm.SelectedItem.IdKho;
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 7
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 31
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 44
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 46)
            {
                lichitiet = NhapReportDataProvider.Instance.GetChiTietLinhKien(Convert.ToDateTime(deFrom.EditValue),
                                                                          Convert.ToDateTime(deTo.EditValue), IdTrungTam,
                                                                          MaKho, Convert.ToInt32(lueLoaiGiaoDich.EditValue), 
                                                                          Convert.ToDateTime(NXfrom.EditValue), Convert.ToDateTime(NXto.EditValue));
                grcBCHangChuyenKho.DataSource = null;
                grcBCHangChuyenKho.DataSource = lichitiet;
            }
            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 2
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 30
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 43
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 45)
            {
                lichitiet = NhapReportDataProvider.Instance.GetChiTietThanhPham(Convert.ToDateTime(deFrom.EditValue),
                                                                          Convert.ToDateTime(deTo.EditValue), IdTrungTam,
                                                                          MaKho, Convert.ToDateTime(NXfrom.EditValue), Convert.ToDateTime(NXto.EditValue),
                                                                          Convert.ToInt32(lueLoaiGiaoDich.EditValue));
                grcBCHangChuyenKho.DataSource = null;
                grcBCHangChuyenKho.DataSource = lichitiet;
            }
            //if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 30)
            //{
            //    lichitiet = NhapReportDataProvider.Instance.GetChiTietTachThanhPham(Convert.ToDateTime(deFrom.EditValue),
            //                                                              Convert.ToDateTime(deTo.EditValue), IdTrungTam,
            //                                                              MaKho, Convert.ToDateTime(NXfrom.EditValue), Convert.ToDateTime(NXto.EditValue));
            //    grcBCHangChuyenKho.DataSource = null;
            //    grcBCHangChuyenKho.DataSource = lichitiet;
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            Common.Export2ExcelFromDevGrid<MaVachSXReportInfo>(grvBCHangChuyenKho, "BCChiTietSanXuat");
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
            LoadLoaiGiaoDich();
            LoadLoaiSanXuat();
        }

        
    }

}