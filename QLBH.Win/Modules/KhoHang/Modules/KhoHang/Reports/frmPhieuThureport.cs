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
    public partial class frmPhieuThureport : DevExpress.XtraEditors.XtraForm
    {
        List<PhieuThu_ChiTietInfo> liChiTiet = new List<PhieuThu_ChiTietInfo>();
        public frmPhieuThureport()
        {
            InitializeComponent();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (txtSoPhieu.Text.Trim() != "")
            {
                LoadSoPhieu(txtSoPhieu.Text.Trim());
                if(liChiTiet.Count!= 0)
                {
                    rpt_BC_PhieuThu rp = new rpt_BC_PhieuThu();
                    rp.DataSource = liChiTiet;
                    rp.ShowPreview();
                }
                else
                {
                    clsUtils.MsgThongBao("Số phiếu bạn nhập không hợp lệ. Xin vui lòng xem lại!");
                    txtSoPhieu.Focus();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Bạn chưa nhập số phiếu thu!");
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSoPhieu(string SoPhieu)
        {
                liChiTiet = PhieuThuDataProvider.Instance.GetChungTuChiTietBySoPhieuThu(SoPhieu);
        }
    }
}