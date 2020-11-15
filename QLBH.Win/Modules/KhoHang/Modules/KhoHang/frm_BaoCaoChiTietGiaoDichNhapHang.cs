using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Base;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoChiTietGiaoDichNhapHang : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        List<ChiTietGiaoDichNhapHangReportInfo> lichitiet = new List<ChiTietGiaoDichNhapHangReportInfo>();
        List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam, MaKho, Nganh;
        private int IdTrungTam;
        #endregion
        public frm_BaoCaoChiTietGiaoDichNhapHang()
        {
            InitializeComponent();
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }

        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false,String.Format("%{0}%", bteTrungTam.Text),Declare.IdNhanVien);
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
            frmLookUp_Kho frm = new frmLookUp_Kho(false,String.Format("%{0}%", bteKho.Text),IdTrungTam,Declare.IdNhanVien);
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
            string sLoaiGiaoDich = String.Empty;
            if (bteLoaiGiaoDich.Tag != null)
            {
                sLoaiGiaoDich = ",";
                foreach (TransTypeInfo transTypeInfo in ((List<TransTypeInfo>)bteLoaiGiaoDich.Tag))
                {
                    sLoaiGiaoDich += transTypeInfo.OID + ",";
                }                 
            }

            lichitiet = NhapReportDataProvider.Instance.GetChiTietGiaoDichNhapReport(
                    Convert.ToDateTime(deLapFrom.EditValue),
                    deLapTo.EditValue == null
                        ? CommonProvider.Instance.GetSysDate()
                        : Convert.ToDateTime(deLapTo.EditValue),
                    Convert.ToDateTime(deNXFrom.EditValue),
                    deNXTo.EditValue == null
                        ? CommonProvider.Instance.GetSysDate()
                        : Convert.ToDateTime(deNXTo.EditValue),
                    Nganh,
                    MaTrungTam,
                    MaKho,
                    sLoaiGiaoDich);
            grcBCHangChuyenKho.DataSource = null;
            grcBCHangChuyenKho.DataSource = lichitiet;

            //if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 0)
            //{
            //    lichitiet = NhapReportDataProvider.Instance.GetChiTietGiaoDichNhapReport(
            //        Convert.ToDateTime(deLapFrom.EditValue),
            //        deLapTo.EditValue == null
            //            ? CommonProvider.Instance.GetSysDate()
            //            : Convert.ToDateTime(deLapTo.EditValue),
            //        Convert.ToDateTime(deNXFrom.EditValue),
            //        deNXTo.EditValue == null
            //            ? CommonProvider.Instance.GetSysDate()
            //            : Convert.ToDateTime(deNXTo.EditValue),
            //        Nganh,
            //        MaTrungTam,
            //        MaKho);
            //    grcBCHangChuyenKho.DataSource = null;
            //    grcBCHangChuyenKho.DataSource = lichitiet;
            //}
            //else
            //{
            //    lichitiet = NhapReportDataProvider.Instance.GetXuatReport(
            //        Convert.ToDateTime(deLapFrom.EditValue),
            //        deLapTo.EditValue == null
            //            ? CommonProvider.Instance.GetSysDate()
            //            : Convert.ToDateTime(deLapTo.EditValue),
            //        Convert.ToDateTime(deNXFrom.EditValue),
            //        deNXTo.EditValue == null
            //            ? CommonProvider.Instance.GetSysDate()
            //            : Convert.ToDateTime(deNXTo.EditValue),
            //        MaTrungTam,
            //        MaKho);
            //    grcBCHangChuyenKho.DataSource = null;
            //    grcBCHangChuyenKho.DataSource = lichitiet;
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            //Common.Export2ExcelFromDevGrid<ChiTietGiaoDichNhapHangReportInfo>(grvBCHangChuyenKho, "BCChiTietGiaoDichNhapHang");
            Common.Export2ExcelFromDevGridTest<ChiTietGiaoDichNhapHangReportInfo>(grvBCHangChuyenKho, "BCChiTietGiaoDichNhapHang");
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
        }
        
        private void bteNganhHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Nganh frmLookUpNganh = new frmLookUp_Nganh(String.Format("%{0}%", bteNganhHang.Text));
            
            if(frmLookUpNganh.ShowDialog()== DialogResult.OK)
            {
                bteNganhHang.Tag = frmLookUpNganh.SelectedItem;
                bteNganhHang.Text = ((SegmentInfo)bteNganhHang.Tag).Ma;
                Nganh = bteNganhHang.Text;
            }
        }

        private void bteNganhHang_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_Nganh frmLookUpNganh = new frmLookUp_Nganh(String.Format("%{0}%", bteNganhHang.Text));

                if (frmLookUpNganh.ShowDialog() == DialogResult.OK)
                {
                    bteNganhHang.Tag = frmLookUpNganh.SelectedItem;
                    bteNganhHang.Text = ((SegmentInfo) bteNganhHang.Tag).Ma;
                    Nganh = bteNganhHang.Text;
                }                
            }
        }

        private void bteNganhHang_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteNganhHang.Text))
            {
                bteNganhHang.Tag = null;
                Nganh = bteNganhHang.Text;
            }
        }

        private void bteLoaiGiaoDich_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TransType frmLookUpTransType = new frmLookUp_TransType(true, "%%");
            if(frmLookUpTransType.ShowDialog() == DialogResult.OK)
            {
                bteLoaiGiaoDich.Tag = frmLookUpTransType.SelectedItems;
                bteLoaiGiaoDich.Text = String.Empty;
                foreach (TransTypeInfo transTypeInfo in frmLookUpTransType.SelectedItems)
                {
                    bteLoaiGiaoDich.Text += transTypeInfo.Name + ",";
                }
            }
        }
    }
}