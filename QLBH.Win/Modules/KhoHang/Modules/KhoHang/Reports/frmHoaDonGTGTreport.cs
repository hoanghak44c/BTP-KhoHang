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
    public partial class frmHoaDonGTGTreport : DevExpress.XtraEditors.XtraForm
    {
        private HoaDonGTGTInfo hd = new HoaDonGTGTInfo();
        List<HoaDonGTGT_ChiTietInfo> liChiTiet = new List<HoaDonGTGT_ChiTietInfo>();
        public string TienBangChu;
        public frmHoaDonGTGTreport()
        {
            InitializeComponent();
        }

        private void LoadSoPhieu(string SoPhieu)
        {
            hd = HoaDonGTGTDataProvider.Instance.GetChungTuBySoChungTu(SoPhieu);
            if (hd != null)
            {
                liChiTiet = HoaDonGTGTDataProvider.Instance.GetChungTuChiTietByIDChungTu(hd.IdChungTu);
            }
            else
            {
                clsUtils.MsgCanhBao("Số phiếu không tồn tại trong hệ thống. Xin hãy kiểm tra lại !");
                return;
            }
        }
        private string GetTien()
        {
            double tongtien =0;
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                tongtien = tongtien + Convert.ToDouble(liChiTiet[i].ThanhTien);
            }
            return Common.ReadNumner_(Common.Double2Str(tongtien));
        }
        private void txtSoPhieu_TextChanged(object sender, EventArgs e)
        {
//            try
//            {
//                if (txtSoPhieu.Text.Trim() != "")
//                {
//                    LoadSoPhieu(txtSoPhieu.Text.Trim());
//                }
//                else
//                {
//                    txtSoPhieu.Focus();
            //                    throw new ManagedException("Bạn chưa nhập số hóa đơn !");
//                }
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
        }



        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (txtSoPhieu.Text.Trim() != "")
            {
                LoadSoPhieu(txtSoPhieu.Text.Trim());
                if (hd != null)
                {
                    TienBangChu = GetTien();
                    //rpt_HoaDonGTGT1 rp = new rpt_HoaDonGTGT1(hd, this);
                    //rp.DataSource = liChiTiet;
                    //rp.ShowPreview();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Bạn chưa nhập số hóa đơn !");
                return;
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}