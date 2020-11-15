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
    public partial class frmBangGiaReport : DevExpress.XtraEditors.XtraForm
    {
        private BangGiaReportInfo bg;
        private List<BangGiaReportInfo> liChiTiet = new List<BangGiaReportInfo>();
        public frmBangGiaReport()
        {
            InitializeComponent();
        }

        private void LoadSanPham(string MaSanPham)
        {
            if (MaSanPham != "")
            {
                bg = BangGiaReportDataProvider.Instance.SanPhamGetGiaByMaSanPham(MaSanPham);
                liChiTiet = BangGiaReportDataProvider.Instance.SanPhamGetCauHinhByMaSanPham(MaSanPham);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (txtSoPhieu.Text.Trim() != "")
            {
                LoadSanPham(txtSoPhieu.Text.Trim());
                if (bg != null)
                {
                    rpt_BangGia rpt = new rpt_BangGia(bg);
                    rpt.DataSource = liChiTiet;
                    rpt.ShowPreview();
                }
            }
            else
            {
                txtSoPhieu.Focus();
                clsUtils.MsgCanhBao("Bạn chưa nhập mã sản phẩm !");
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}