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

namespace QLBanHang.Modules.KhoHang.Reports
{
    public partial class frmPhieuXuatKhoReport : DevExpress.XtraEditors.XtraForm
    {
        private PhieuXuatKhoInfo hd = new PhieuXuatKhoInfo();
        List<PhieuXuatKho_ChiTietInfo> liChiTiet = new List<PhieuXuatKho_ChiTietInfo>();
        public frmPhieuXuatKhoReport()
        {
            InitializeComponent();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (txtSoPhieu.Text.Trim() != "")
            {
                LoadSoPhieu(txtSoPhieu.Text.Trim());
                if(hd!=null)
                {
                    rpt_BC_PhieuXuatKho rp = new rpt_BC_PhieuXuatKho(hd);
                    rp.DataSource = liChiTiet;
                    rp.ShowPreview();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Bạn chưa nhập số phiếu!");
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void LoadSoPhieu(string soPhieu)
        {
            hd = PhieuXuatKhoDataProvider.Instance.GetChungTuBySoPhieuXuat(soPhieu);
            if (hd != null)
            {
                liChiTiet = PhieuXuatKhoDataProvider.Instance.GetChungTuChiTietByIDChungTu(hd.IdChungTu);
            }
            else
            {
                clsUtils.MsgCanhBao("Số phiếu không hợp lệ. Xin vui lòng nhập lại!");
                return;
            }
        }
    }
}