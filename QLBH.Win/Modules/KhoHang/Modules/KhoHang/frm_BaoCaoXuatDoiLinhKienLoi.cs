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
    public partial class frm_BaoCaoXuatDoiLinhKienLoi : DevExpress.XtraEditors.XtraForm
    {
        List<XuatDoiLinhKienLoiInfo> lichitiet = new List<XuatDoiLinhKienLoiInfo>();
        List<LookUp> lst = new List<LookUp>();
        //List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam;
        private int MaKho;
        public frm_BaoCaoXuatDoiLinhKienLoi()
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
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
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
            }
        }

        private void  LoadTrangThai()
        {
            List<LookUp> lst = new List<LookUp>();
            lst.Add(new LookUp { OID = 1, Name = "Chờ xuất" });
            lst.Add(new LookUp { OID = 2, Name = "Đang xuất" });
            lst.Add(new LookUp { OID = 3, Name = "Đã xuất đủ" });
            lst.Add(new LookUp { OID = 4, Name = "Ngừng sản xuất" });
            lst.Add(new LookUp { OID = 5, Name = "Phiếu đã hủy" });
            repTrangThai.DataSource = lst;
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
                }
            }
        }

        

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvChiTiet);
            Common.Export2ExcelFromDevGrid<XuatDoiLinhKienLoiInfo>(grvChiTiet, "BCXuatDoiLinhKenLoi");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            lichitiet = DoiLinhKienLoiDataProvider.Instance.GetXuatDoiLinhKienLoi(Convert.ToDateTime(deFrom.EditValue),
                                                                          Convert.ToDateTime(deTo.EditValue), MaTrungTam);
            grcChiTiet.DataSource = null;
            grcChiTiet.DataSource = lichitiet;
        }

        private void frm_BaoCaoLenhSXChuaXuatLK_Load(object sender, EventArgs e)
        {
            LoadTrangThai();
        }
    }
}