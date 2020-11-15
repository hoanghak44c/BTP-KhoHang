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
    public partial class frmBaoCaoDanhSachNhapHangMua : DevExpress.XtraEditors.XtraForm
    {
        List<NhapHangMuaReportInfo> lichitiet = new List<NhapHangMuaReportInfo>();
        List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam;
        private int MaKho;
        private int IdTrungTam;
        public frmBaoCaoDanhSachNhapHangMua()
        {
            InitializeComponent();
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadTrangThai()
        {
            lst.Add(new LookUp { OID = 1, Name = "Đang xuất" });
            lst.Add(new LookUp { OID = 2, Name = "Đã xuất đủ(chưa in phiếu)" });
            lst.Add(new LookUp { OID = 3, Name = "Đã xuất đủ(đã in phiếu)" });
            
            repTrangThai.DataSource = null;
            repTrangThai.DataSource = lst;
        }
        //private void LoadLoaiGiaoDich()
        //{
        //    List<LookUp> ligiaodich = new List<LookUp>();
        //    ligiaodich.Add(new LookUp { OID = 0, Name = "Xuất linh kiện sản xuất" });
        //    ligiaodich.Add(new LookUp { OID = 1, Name = "Nhập thành phẩm sản xuất" });
        //    lueLoaiGiaoDich.Properties.DataSource = null;
        //    lueLoaiGiaoDich.Properties.DataSource = ligiaodich;
        //    lueLoaiGiaoDich.EditValue = ligiaodich[0].OID;
        //}
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
            lichitiet = NhapReportDataProvider.Instance.GetDanhSachNhapPO(Convert.ToDateTime(deFrom.EditValue),
                                                                          deTo.EditValue == null
                                                                              ? CommonProvider.Instance.GetSysDate()
                                                                              : Convert.ToDateTime(deTo.EditValue),
                                                                          Convert.ToDateTime(deNXFrom.EditValue),
                                                                          deNXTo.EditValue == null
                                                                              ? CommonProvider.Instance.GetSysDate()
                                                                              : Convert.ToDateTime(deNXTo.EditValue),
                                                                          IdTrungTam,
                                                                          MaKho,
                                                                          Convert.ToDateTime(dtORCtu.EditValue),
                                                                          dtORCden.EditValue == null
                                                                              ? CommonProvider.Instance.GetSysDate()
                                                                              : Convert.ToDateTime(dtORCden.EditValue));
            grcBCHangChuyenKho.DataSource = null;
            grcBCHangChuyenKho.DataSource = lichitiet;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            Common.Export2ExcelFromDevGrid<NhapHangMuaReportInfo>(grvBCHangChuyenKho, "BCDSNhapHangMua");
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayLapORC);
            LoadTrangThai();
            //LoadLoaiSanXuat();
        }

        
    }

}