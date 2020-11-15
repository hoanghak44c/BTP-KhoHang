using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH
{
    public partial class frmLookup_XuatTH : DevExpress.XtraEditors.XtraForm
    {
        public NhapHangMuaReportInfo item = new NhapHangMuaReportInfo();
        private int IdDoiTuong;
        private int idkho;
        private DateTime tungay, denngay;
        objGridMarkSelection opt = new objGridMarkSelection();
        public frmLookup_XuatTH()
        {
            InitializeComponent();
        }

        private void LoadLoaiChungTu()
        {
            repLoaichungtu.DataSource = StringEnum.GetStringValue(TransactionType.NHAP_PO,
                                                                  TransactionType.NHAPHANGLOIBHNCC);
        }

        private void LoadDataSource()
        {
            List<NhapHangMuaReportInfo> lst = new List<NhapHangMuaReportInfo>();
            lst = NhapReportDataProvider.Instance.GetLookUpXTH();
            grcDanhSach.DataSource = null;
            grcDanhSach.DataSource = lst;
            //opt.View = grvDanhSach;
        }
        private void Save()
        {
            item = (NhapHangMuaReportInfo) grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            //for (int i = 0; i < opt.selection.Count; i++)
            //{
            //    item.Add((BhPhieuXuatNhaCCLookUpInfor)opt[i]);
            //}
            //item = (BhPhieuXuatNhaCCLookUpInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
        }

        private void frmLookup_PhieuNhap_Load(object sender, EventArgs e)
        {
            LoadLoaiChungTu();
            LoadDataSource();
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Save();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch { }
        }

        private void txtSoPhieuXuat_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataSource();
        }

        private void grvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Save();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                catch { }
            }
        }

        private void txtSoPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                grcDanhSach.Focus();
        }
    }
}