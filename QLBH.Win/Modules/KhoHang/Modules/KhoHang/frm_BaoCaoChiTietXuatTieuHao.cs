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
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoDeNghiXuatTieuHao : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private string MaTrungTam;
        private string MaKho;
        private List<BCChiTietXuatTieuHaoInfo> lstBC;
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
        public frm_BaoCaoDeNghiXuatTieuHao()
        {
            InitializeComponent();
            if (IsSupperUser())
            {grcBCXuatTieuHao.ContextMenuStrip = new ContextMenuStrip();}
        }
        private void LoadLoaiChungTu()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            repTrangThaiNhan.DataSource = lst;
        }

        private void frm_BaoCaoChiTietHangChuyenKho_Load(object sender, EventArgs e)
        {
            //grcBCXuatTieuHao.ContextMenuStrip.Items.Add("Phiếu đề nghị xuất tiêu hao", null, PhieuDNXuat_Click);
            //grcBCXuatTieuHao.ContextMenuStrip.Items.Add("Phiếu xuất tiêu hao", null, PhieuXuat_Click);
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);
            LoadLoaiChungTu();
        }
        //private void PhieuDNXuat_Click(object sender, EventArgs e)
        //{
        //    if (grvBCXuatTieuHao.FocusedRowHandle < 0) return;
        //    ChungTuDieuChuyenInfor info = DeNghiDieuChuyenDataProvider.Instance.GetInforDNDCByIdChungTu(
        //            ((BCChiTietHangChuyenKhoInfo) grvBCXuatTieuHao.GetRow(grvBCXuatTieuHao.FocusedRowHandle)).
        //                IdPhieuXuat);
        //    frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT(info);
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        grcBCXuatTieuHao.DataSource = XuatTieuHaoProvider.Instance.GetBCChiTietXuatTieuHao(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
        //    }
        //}
        //private void PhieuXuat_Click(object sender, EventArgs e)
        //{
        //    if (grvBCXuatTieuHao.FocusedRowHandle < 0) return;
        //    ChungTuDieuChuyenInfor info = DeNghiDieuChuyenDataProvider.Instance.GetInforDNDCByIdChungTu(
        //            ((BCChiTietHangChuyenKhoInfo)grvBCXuatTieuHao.GetRow(grvBCXuatTieuHao.FocusedRowHandle)).
        //                IdPhieuXuat);
        //    frm_PhieuDieuChuyenCungTT frm = new frm_PhieuDieuChuyenCungTT(info);
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        grcBCXuatTieuHao.DataSource = XuatTieuHaoProvider.Instance.GetBCChiTietXuatTieuHao(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
        //    }
        //}

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                //fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
                //toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);
                if (bteTrungTam.Text == null) throw new ManagedException("Bạn chưa chọn trung tâm!");
                lstBC = XuatTieuHaoProvider.Instance.GetBCChiTietXuatTieuHao(
                    MaTrungTam,MaKho, 
                    Convert.ToDateTime(deFrom.EditValue),
                    deTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deTo.EditValue),
                    Convert.ToDateTime(deNXFrom.EditValue),
                    deNXTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deNXTo.EditValue));
                grcBCXuatTieuHao.DataSource = null;
                grcBCXuatTieuHao.DataSource = lstBC;
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
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCXuatTieuHao);
            Common.Export2ExcelFromDevGrid<BCChiTietXuatTieuHaoInfo>(grvBCXuatTieuHao, "BCChiTietXuatTieuHao");
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
                //IdTrungTam = frmLookUpTrungTam.SelectedItem.IdTrungTam;
                MaTrungTam = "";
                foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
                {
                    bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
                    MaTrungTam += selectedItem.MaTrungTam + ", ";
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
                    //bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                    //bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                    //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
                    //IdTrungTam = frmLookUpTrungTam.SelectedItem.IdTrungTam;
                    //bteKho.Text = "";
                    MaTrungTam = "";
                    foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
                    {
                        bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
                        MaTrungTam += selectedItem.MaTrungTam + ", ";
                    }
                }
            }
        }

        private void bteTrungTam_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteTrungTam.Text)) bteTrungTam.Tag = null;
        }
        #endregion 

       
    }
}