using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmTimKiemMaVach : DevExpress.XtraEditors.XtraForm
    {
        public string MaLenh;
        public string MaThanhPham;
        public string TenThanhPham;
        public string MaVachThanhPham;
        public string MaTrungTam;
        public int SoLuongYC;
        public int SoLuongDN;
        List<DMChungTuNhapInfo> liTim = new List<DMChungTuNhapInfo>();
        List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach = new List<ChungTuNhapNccChiTietHangHoaInfo>();
        List<SanXuatLenhInfo> liSX = new List<SanXuatLenhInfo>();
        DMChungTuNhapInfo liChungTu = new DMChungTuNhapInfo();
        private ChungTuXuatNhapNccInfo ct;
        public frmTimKiemMaVach(string MaTrungTam)
        {
            this.MaTrungTam = MaTrungTam;
            InitializeComponent();
        }
        public frmTimKiemMaVach()
        {
            InitializeComponent();
        }

        private void Tim(string MaVach)
        {
            liTim = tblChungTuDataProvider.GetChungTuByMaVach(MaVach);
            
            if (liTim.Count >0)
            {
                ct = new ChungTuXuatNhapNccInfo
                {
                    IdChungTu = liTim[0].IdChungTu,
                    LoaiChungTu = liTim[0].LoaiChungTu,
                    IdKho = liTim[0].IdKho,
                    IdNhanVien = liTim[0].IdNhanVien,
                    NgayLap = liTim[0].NgayLap,
                    SoChungTu = liTim[0].SoChungTu,
                    SoPO = liTim[0].SoChungTuGoc
                };
                if (liTim[0].LoaiChungTu == Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX))
                {
                    liSX = SanXuatLenhProvier.GetSanXuatLenhByMaLenh(liTim[0].SoChungTuGoc, liTim[0].IdChungTu);
                    MaVachThanhPham = liSX[0].MaVachThanhPham;
                    MaThanhPham = liSX[0].MaThanhPham;
                    TenThanhPham = liSX[0].TenThanhPham;
                    SoLuongYC = liSX[0].SoLuongTP;
                    MaLenh = liTim[0].SoChungTuGoc;
                    SoLuongDN = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                        Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX), liTim[0].SoChungTuGoc,MaTrungTam);
                    liMaVach = tblChungTuDataProvider.GetMaVachByChungTuGoc(liTim[0].SoChungTu);
                }
                //else if (liTim[0].LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX))
                //{
                //    liChungTu = tblChungTuDataProvider.GetChungTuBySoChungTu<DMChungTuNhapInfo>(liTim[0].SoChungTuGoc);
                //    liSX = SanXuatLenhProvier.GetSanXuatLenhByMaLenh(liChungTu.SoChungTuGoc);
                //    if (liSX.Count > 0)
                //    {
                //        MaVachThanhPham = liSX[0].MaVachThanhPham;
                //        MaThanhPham = liSX[0].MaThanhPham;
                //        TenThanhPham = liSX[0].TenThanhPham;
                //        SoLuongYC = liSX[0].SoLuongTP;
                //        MaLenh = liSX[0].MaLenh;
                //        SoLuongDN = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                //        Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX), liChungTu.SoChungTuGoc,MaTrungTam);
                //        liMaVach = tblChungTuDataProvider.GetMaVachByChungTuGoc(liTim[0].SoChungTu);
                //    }
                //    liMaVach = tblChungTuDataProvider.GetMaVachByChungTuGoc(liTim[0].SoChungTuGoc);
                //}
                else
                {
                    throw new ManagedException("Không tìm thấy dữ liệu phù hợp !");
                }
                frmChiTietNhapThanhPham frm = new frmChiTietNhapThanhPham(this,MaLenh,liMaVach,ct,2);
                frm.ShowDialog();
                this.Close();
            }
            //else if (liTim.Count > 1)
            //{
            //    if (clsUtils.MsgXoa("Mã vạch tồn tại trong nhiều thành phẩm khác nhau.Xin hãy chọn thành phẩm ?") == System.Windows.Forms.DialogResult.Yes)
            //    {
                    
            //    }
            //}
            else
            {
                throw new ManagedException("Không tìm thấy dữ liệu phù hợp !");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                Tim(txtTim.Text.Trim());
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Tim(txtTim.Text.Trim());
            }
        }
    }
}