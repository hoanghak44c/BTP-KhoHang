using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ListThongKeMaVach : DevExpress.XtraEditors.XtraForm
    {
        #region Declare

        private frm_ListChungTuNhap frmNhap;
        private frm_ListChungTuTraNCC frmTra;
        private int chon;
        #endregion
        public frm_ListThongKeMaVach()
        {
            InitializeComponent();
        }
        public frm_ListThongKeMaVach(frm_ListChungTuNhap frm,int chon)
        {
            InitializeComponent();
            this.frmNhap = frm;
            this.chon = chon;
        }
        public frm_ListThongKeMaVach(frm_ListChungTuTraNCC frm,int chon)
        {
            InitializeComponent();
            this.frmTra = frm;
            this.chon = chon;
        }

        private void frm_ListThongKeMaVach_Load(object sender, EventArgs e)
        {
            if (chon == 1)
            {
                txtSoPhieu.Text = frmNhap.PhieuNhap;
                txtPO.Text = frmNhap.PO;
                dgvList.DataSource = KhoNhapNccDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(frmNhap.OID);
            }
            else
            {
                txtSoPhieu.Text = frmTra.PhieuNhap;
                txtPO.Text = frmTra.PO;
                dgvList.DataSource = KhoNhapNccDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(frmTra.OID);
            }
        }
    }
}