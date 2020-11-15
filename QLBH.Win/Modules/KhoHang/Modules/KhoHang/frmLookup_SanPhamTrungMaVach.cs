using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH
{
    public partial class frmLookup_SanPhamTrungMaVach : DevExpress.XtraEditors.XtraForm
    {
        public DMSanPhamInfoEx item = new DMSanPhamInfoEx();
        private int IdDoiTuong,IdKho, idDotKiemKe;
        private string maVach, maTrungTam, maKho, maNganh;
        private DateTime tungay, denngay;
        objGridMarkSelection opt = new objGridMarkSelection();
        public frmLookup_SanPhamTrungMaVach(string maVach, string maKho, string maTrungTam, string maNganh, int idDotKiemKe)
        {
            InitializeComponent();
            this.maVach = maVach;
            this.maKho = maKho;
            this.maTrungTam = maTrungTam;
            this.maNganh = maNganh;
            this.idDotKiemKe = idDotKiemKe;
        }

        private void LoadDataSource()
        {
            List<DMSanPhamInfoEx> lst = new List<DMSanPhamInfoEx>();
            lst = KiemKeDataProvider.Instance.GetLookUpSanPhamTrungMV(maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
            grcDanhSach.DataSource = null;
            grcDanhSach.DataSource = lst;
            //opt.View = grvDanhSach;
        }
        private void Save()
        {
            item = (DMSanPhamInfoEx)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
        }

        private void frmLookup_PhieuNhap_Load(object sender, EventArgs e)
        {
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