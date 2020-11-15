using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoChiTietNhapXuatThanhPham : DevExpress.XtraEditors.XtraForm
    {
        private int idTrungTam, idKho;
        public frm_BaoCaoChiTietNhapXuatThanhPham()
        {
            InitializeComponent();
            lueLoaiGiaoDich.Properties.DisplayMember = "Name";
            lueLoaiGiaoDich.Properties.ValueMember = "OID";
            lueLoaiGiaoDich.Properties.DataSource = new List<LookUp>
                                                        {
                                                            new LookUp {Name = "Tất cả", OID = 0},
                                                            new LookUp {Name = "Nhập thành phẩm", OID = 2},
                                                            new LookUp {Name = "Xuất thành phẩm", OID = 30}
                                                        };

            rleLoaiChungTu.DisplayMember = "Name";
            rleLoaiChungTu.ValueMember = "OID";
            rleLoaiChungTu.DataSource = new List<LookUp>
                                                        {
                                                            new LookUp {Name = "Nhập thành phẩm", OID = 2},
                                                            new LookUp {Name = "Xuất thành phẩm", OID = 30}
                                                        };

        }

        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam();
            if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.MaTrungTam;
                idTrungTam = frmLookUpTrungTam.SelectedItem.IdTrungTam;
            }
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho();
            if(frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.Text = frmLookUpKho.SelectedItem.MaKho;
                idKho = frmLookUpKho.SelectedItem.IdKho;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            grcBCTHNhapTP.DataSource = NhapReportDataProvider.Instance.GetListChungTuNhapXuatThanhPhamChiTiet(
                Convert.ToInt32(lueLoaiGiaoDich.EditValue),
                Convert.ToDateTime(deFrom.EditValue),
                deTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deTo.EditValue),
                Convert.ToDateTime(deNXFrom.EditValue),
                deNXTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deNXTo.EditValue),
                idTrungTam, idKho);            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCTHNhapTP);
            Common.Export2ExcelFromDevGrid<NhapXuatThanhPhamReportInfo>(grvBCTHNhapTP, "BCChiTietXuatThanhPham");
        }
    }
}