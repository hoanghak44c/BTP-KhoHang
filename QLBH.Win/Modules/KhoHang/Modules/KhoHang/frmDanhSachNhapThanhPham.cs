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
using QLBanHang.Modules.KhoHang.Reports;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmDanhSachNhapThanhPham : DevExpress.XtraEditors.XtraForm
    {
        private int OID;
        private int check;
        private string malenh;
        public frmDanhSachNhapThanhPham(int check, string malenh)
        {
            InitializeComponent();
            dgvListNTP.AutoGenerateColumns = false;
            this.check = check;
            this.malenh = malenh;
        }

        //private void LoadTrangThai()
        //{
        //    List<LookUp> lst = new List<LookUp>();
        //    lst.Add(new LookUp{OID = 0,Name = "Chưa hoàn thành"});
        //    lst.Add(new LookUp { OID = 1, Name = "Đã hoàn thành" });
        //}

        private void frmDanhSachNhapThanhPham_Load(object sender, EventArgs e)
        {
            if (check == 1)
            {
                dgvListNTP.DataSource = tblChungTuDataProvider.GetListNTP(malenh);
            }
            if (check == 2)
            {
                dgvListNTP.DataSource = tblChungTuDataProvider.GetListTTP(malenh);
            }
            
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<BaoCao_ChiTietInfor> list = tblChungTuDataProvider.GetPhieuNhapTPDetail(OID);
                if (check == 1)
                {
                    rpt_BC_PhieuNhapHangMuaNCC rpt = new rpt_BC_PhieuNhapHangMuaNCC();
                    List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
                    rpt.DataSource = lst;
                    rpt.ShowPreview();
                }
                else
                {
                    rpt_BC_PhieuTachThanhPhamSX rpt = new rpt_BC_PhieuTachThanhPhamSX();
                    rpt.DataSource = list;
                    rpt.ShowPreview();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void dgvListNTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OID = ((MaVachThanhPhamInfo)dgvListNTP.Rows[e.RowIndex].DataBoundItem).IdChungTu;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}