using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoTongHopHangChuyenKho : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int idChungTu = 0;
        private string MaTrungTam;
        private string MaKho;
        public int SoChungTu;
        public string SoPX;
        public string NguoiLap;
        public string PhieuXuat;
        public DateTime NgayLap;
        public string DienGiai;
        public DateTime ThoiGian;
        public int TrangThai;
        public string SoCTG;
        public string TenKho;
        public int IdKhoDieuChuyen;
        private List<BCTongHopHangChuyenKhoInfo> lstBC;
        //private ChungTuDieuChuyenInfor lstDNDC;
        List<LookUp> lst = new List<LookUp>();
        [Serializable]
        public class LookUp
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        public frm_BaoCaoTongHopHangChuyenKho()
        {
            InitializeComponent();
            //if (IsSupperUser())
            //{grcBCHangChuyenKho.ContextMenuStrip = new ContextMenuStrip();}
        }
        private void LoadLoaiChungTu()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            lst.Add(new TrangThaiBH { Id = 2, Name = "Chờ nhận" });
            lst.Add(new TrangThaiBH { Id = 3, Name = "Đã nhận" });
            lst.Add(new TrangThaiBH { Id = 4, Name = "Chờ nhận (Chưa xuất)" });
            repTrangThaiNhan.DataSource = lst;
        }

        private void frm_BaoCaoChiTietHangChuyenKho_Load(object sender, EventArgs e)
        {
            //fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
            //toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);
            //lstBC = XuatDieuChuyenDataProvider.Instance.GetBCTongHopChuyenKho(MaTrungTam,MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
            //grcBCHangChuyenKho.DataSource = null;
            //grcBCHangChuyenKho.DataSource = lstBC;
            //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu đề nghị xuất điều chuyển", null, PhieuDNXuat_Click);
            //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu xuất điều chuyển", null, PhieuXuat_Click);
            //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu đề nghị nhận điều chuyển", null, PhieuDNNhan_Click);
            //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu nhận điều chuyển", null, PhieuNhan_Click);
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);
            clsUtils.NullColumnDateTimeGrid(repNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayNhap);
            LoadLoaiChungTu();
        }
        private void PhieuDNXuat_Click(object sender, EventArgs e)
        {
            if (grvBCHangChuyenKho.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = DeNghiDieuChuyenDataProvider.Instance.GetInforDNDCByIdChungTu(
                    ((BCTongHopHangChuyenKhoInfo) grvBCHangChuyenKho.GetRow(grvBCHangChuyenKho.FocusedRowHandle)).
                        IdPhieuXuat);
            frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT(info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //grcBCHangChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCTongHopChuyenKho(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
            }
        }
        private void PhieuXuat_Click(object sender, EventArgs e)
        {
            if (grvBCHangChuyenKho.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = DeNghiDieuChuyenDataProvider.Instance.GetInforDNDCByIdChungTu(
                    ((BCTongHopHangChuyenKhoInfo)grvBCHangChuyenKho.GetRow(grvBCHangChuyenKho.FocusedRowHandle)).
                        IdPhieuXuat);
            frm_PhieuDieuChuyenCungTT frm = new frm_PhieuDieuChuyenCungTT(info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //grcBCHangChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCTongHopChuyenKho(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
            }
        }
        private void PhieuDNNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBCHangChuyenKho.FocusedRowHandle < 0) return;
                if(((BCTongHopHangChuyenKhoInfo)grvBCHangChuyenKho.GetRow(grvBCHangChuyenKho.FocusedRowHandle)).IdPhieuNhan == 0)
                {
                    MessageBox.Show("Chưa có phiếu nhận!");
                    return;
                }
                ChungTuNhapDieuChuyenInfor info = DeNghiNhanDieuChuyenDataProvider.Instance.GetInforDNNDCByIdChungTu(
                    ((BCTongHopHangChuyenKhoInfo)grvBCHangChuyenKho.GetRow(grvBCHangChuyenKho.FocusedRowHandle)).IdPhieuNhan);
                frm_PhieuDeNghiNhanDieuChuyenNew frm = new frm_PhieuDeNghiNhanDieuChuyenNew(info);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //grcBCHangChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCTongHopChuyenKho(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PhieuNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBCHangChuyenKho.FocusedRowHandle < 0) return;
                if (((BCTongHopHangChuyenKhoInfo)grvBCHangChuyenKho.GetRow(grvBCHangChuyenKho.FocusedRowHandle)).IdPhieuNhan == 0)
                {
                    MessageBox.Show("Chưa có phiếu nhận!");
                    return;
                }
                ChungTuNhapDieuChuyenInfor info = DeNghiNhanDieuChuyenDataProvider.Instance.GetInforDNNDCByIdChungTu(
                    ((BCTongHopHangChuyenKhoInfo)grvBCHangChuyenKho.GetRow(grvBCHangChuyenKho.FocusedRowHandle)).IdPhieuNhan);
                frm_PhieuNhanDieuChuyen frm = new frm_PhieuNhanDieuChuyen(info);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //grcBCHangChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCTongHopChuyenKho(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue), Convert.ToDateTime(deNXFrom.EditValue), Convert.ToDateTime(deNXTo.EditValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                //fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
                //toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);
                if (bteTrungTam.Text == null) throw new ManagedException("Bạn chưa chọn trung tâm!");
                //if (bteKho.Tag == null) throw new ManagedException("Bạn chưa chọn kho!");
                lstBC = XuatDieuChuyenDataProvider.Instance.GetBCTongHopChuyenKho(bteTrungTam.Text, bteKho.Text, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue), Convert.ToDateTime(deNXFrom.EditValue), Convert.ToDateTime(deNXTo.EditValue));
                grcBCHangChuyenKho.DataSource = null;
                grcBCHangChuyenKho.DataSource = lstBC;
                LoadLoaiChungTu();
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //grcBCHangChuyenKho.ShowPrintPreview();
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            Common.Export2ExcelFromDevGrid<BCTongHopHangChuyenKhoInfo>(grvBCHangChuyenKho, "BCTongHopHangChuyenKho");
        }
        #region bteKho
        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);
            if(frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.EditValue = String.Empty;
                bteKho.Tag = frmLookUpKho.SelectedItem;
                //bteKho.Text = frmLookUpKho.SelectedItem.TenKho;
                //MaKho = frmLookUpKho.SelectedItem.MaKho;
                foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                {
                    bteKho.EditValue += selectedItem.MaKho + ", ";
                }
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);
                if (frmLookUpKho.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frmLookUpKho.SelectedItem;
                    //bteKho.Text = frmLookUpKho.SelectedItem.TenKho;
                    //MaKho = frmLookUpKho.SelectedItem.MaKho;
                    foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                    {
                        bteKho.EditValue += selectedItem.MaKho + ", ";
                    }
                }                
            }
        }

        private void bteKho_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKho.Text)) bteKho.Tag = null;
        }
        #endregion

        #region bteTrungTam
        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.EditValue = String.Empty;
                bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                //bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
                bteKho.Text = "";
                foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
                {
                    bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
                }
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true, String.Format("%{0}%", bteTrungTam.Text),Declare.IdNhanVien);
                if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                    //bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                    //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
                    bteKho.Text = "";
                    foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
                    {
                        bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
                    }
                }
            }
        }

        private void bteTrungTam_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteTrungTam.Text)) bteTrungTam.Tag = null;
        }

        private void chkAllTrungTam_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAllTrungTam.Checked)
            //{
            //    bteTrungTam.Text = "Xem toàn bộ các kho";
            //    bteTrungTam.Tag = DMTrungTamDataProvider.GetListTrungTamInfo();
            //}
            //else
            //{
            //    bteTrungTam.Text = String.Empty;
            //    bteTrungTam.Tag = null;
            //}
        }

        private void checkAllKho_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAllKho.Checked)
            //{
            //    bteKho.Text = "Xem toàn bộ các kho";
            //    bteKho.Tag = DMKhoDataProvider.GetListDMKhoInfor();
            //}
            //else
            //{
            //    bteKho.Text = String.Empty;
            //    bteKho.Tag = null;
            //}
        }
        #endregion
    }
}