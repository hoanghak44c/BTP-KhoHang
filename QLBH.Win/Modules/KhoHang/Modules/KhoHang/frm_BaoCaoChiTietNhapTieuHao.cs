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
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoChiTietNhapTieuHao : DevExpress.XtraEditors.XtraForm
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
        public frm_BaoCaoChiTietNhapTieuHao()
        {
            InitializeComponent();
            if (IsSupperUser())
            {grcBCNhapTieuHao.ContextMenuStrip = new ContextMenuStrip();}
        }
        private void LoadLoaiChungTu()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 2, Name = "Chưa nhập" });
            lst.Add(new TrangThaiBH { Id = 3, Name = "Đã nhập" });
            repTrangThaiNhan.DataSource = lst;
        }

        private void frm_BaoCaoChiTietHangChuyenKho_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repNgayNhap);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);
            LoadLoaiChungTu();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (bteTrungTam.Text == null) throw new ManagedException("Bạn chưa chọn trung tâm!");
                lstBC = NhapTieuHaoProvider.Instance.GetBCChiTietNhapTieuHao(MaTrungTam, MaKho, 
                    Convert.ToDateTime(deFrom.EditValue), 
                    Convert.ToDateTime(deTo.EditValue),
                    Convert.ToDateTime(dteNXTu.EditValue), 
                    Convert.ToDateTime(dteNXDen.EditValue));
                grcBCNhapTieuHao.DataSource = null;
                grcBCNhapTieuHao.DataSource = lstBC;
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
            //Common.DevExport2Excel(grvBCNhapTieuHao);
            Common.Export2ExcelFromDevGrid<BCChiTietXuatTieuHaoInfo>(grvBCNhapTieuHao, "BCChiTietNhapTieuHao");
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