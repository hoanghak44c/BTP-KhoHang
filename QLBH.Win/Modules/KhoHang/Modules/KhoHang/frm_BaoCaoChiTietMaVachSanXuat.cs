using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoChiTietMaVachSanXuat : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        List<MaVachSXReportInfo> lichitiet = new List<MaVachSXReportInfo>();
        List<LookUp> lst = new List<LookUp>();
        private int MaTrungTam;
        private int MaKho;
        #endregion
        public frm_BaoCaoChiTietMaVachSanXuat()
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
            lst.Add(new LookUp{OID = 7,Name = "Sản xuất lắp ráp"});
            lst.Add(new LookUp { OID = 44, Name = "Sản xuất ComBo" });
            lst.Add(new LookUp { OID = 46, Name = "Sản xuất đổi mã" });
            repLoaiSanXuat.DataSource = null;
            repLoaiSanXuat.DataSource = lst;
        }

        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false,String.Format("%{0}%", bteTrungTam.Text),Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.IdTrungTam;
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
                MaTrungTam = frm.SelectedItem.IdTrungTam;
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
                    MaTrungTam = frm.SelectedItem.IdTrungTam;
                    bteKho.Text = "";
                }
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), MaTrungTam, Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frm.SelectedItem;
                    bteKho.Text = frm.SelectedItem.TenKho;
                    MaKho = frm.SelectedItem.IdKho;
                }
            }
        }

        private void bteKho_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false,String.Format("%{0}%", bteKho.Text),MaTrungTam,Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.IdKho;
            }
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), MaTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.IdKho;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            lichitiet = NhapReportDataProvider.Instance.GetMaVachSanXuat(Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue), MaTrungTam, MaKho, Convert.ToDateTime(NXfrom.EditValue), Convert.ToDateTime(NXto.EditValue));
            grcChiTiet.DataSource = null;
            grcChiTiet.DataSource = lichitiet;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvChiTiet);
            Common.Export2ExcelFromDevGrid<MaVachSXReportInfo>(grvChiTiet, "BCChiTietMaVachSX");
        }

        private void frm_BaoCaoChiTietMaVachSanXuat_Load(object sender, EventArgs e)
        {
            LoadLoaiSanXuat();
        }
    }
}