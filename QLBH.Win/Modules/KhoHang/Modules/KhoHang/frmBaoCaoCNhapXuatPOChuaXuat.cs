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
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmBaoCaoCNhapXuatPOChuaXuat : DevExpress.XtraEditors.XtraForm
    {
        List<BaoCaoNhapXuatPOChuaXuatInfo> lichitiet = new List<BaoCaoNhapXuatPOChuaXuatInfo>();
        List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam;
        private string MaKho;
        private int IdTrungTam;
        public frmBaoCaoCNhapXuatPOChuaXuat()
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
            lst.Add(new LookUp { OID = 0, Name = "Nhập hàng mua NCC" });
            lst.Add(new LookUp { OID = 1, Name = "Xuất trả NCC" });
            repLoaiSX.DataSource = null;
            repLoaiSX.DataSource = lst;
        }
        private void LoadTrangThai()
        {
            List<LookUp> lst = new List<LookUp>();
            lst.Add(new LookUp { OID = 0, Name = "Chưa bắn mã vạch" });
            lst.Add(new LookUp { OID = 1, Name = "Phiếu đã hủy" });
            repTrangThai.DataSource = null;
            repTrangThai.DataSource = lst;
        }
        private void LoadLoaiGiaoDich()
        {
            //List<LookUp> ligiaodich = new List<LookUp>();
            //ligiaodich.Add(new LookUp { OID = 0, Name = "Nhập hàng mua NCC" });
            //ligiaodich.Add(new LookUp { OID = 1, Name = "Xuất trả NCC" });
            //lueLoaiGiaoDich.Properties.DataSource = null;
            //lueLoaiGiaoDich.Properties.DataSource = ligiaodich;
            //lueLoaiGiaoDich.EditValue = ligiaodich[0].OID;
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
                MaKho = frm.SelectedItem.MaKho;
            }
        }

        private void bteKho_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.MaKho;
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
                    MaKho = frm.SelectedItem.MaKho;
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            lichitiet = NhapReportDataProvider.Instance.GetNhapXuatPOChuaXuat(
                deFrom.EditValue == null ? new DateTime(2013,5,1) : Convert.ToDateTime(deFrom.EditValue),
                deTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deTo.EditValue),
                dteNXTu.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(dteNXTu.EditValue),
                dteNXDen.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(dteNXDen.EditValue),
                MaTrungTam, MaKho);
            grcBCHangChuyenKho.DataSource = null;
            grcBCHangChuyenKho.DataSource = lichitiet;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            Common.Export2ExcelFromDevGrid<BaoCaoNhapXuatPOChuaXuatInfo>(grvBCHangChuyenKho, "BCNhapXuatPOChuaXuat");
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
            LoadLoaiGiaoDich();
            LoadLoaiSanXuat();
            LoadTrangThai();
        }

        
    }

}