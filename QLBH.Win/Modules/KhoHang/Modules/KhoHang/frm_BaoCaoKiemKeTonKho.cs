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
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoKiemKeTonKho : DevExpress.XtraEditors.XtraForm
    {
        private List<BCChiTietKiemKeInfo> lstBC;
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
        public frm_BaoCaoKiemKeTonKho()
        {
            InitializeComponent();
        }
        #region bteDotKiemKe
        private void bteDotKiemKe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookup_DotKiemKeKetThuc frm = new frmLookup_DotKiemKeKetThuc(true);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bteDotKiemKe.Text = String.Empty;
                bteDotKiemKe.Tag = frm.SelectedItems;
                foreach (DotKiemKeInfor dotKiemKeInfor in frm.SelectedItems)
                {
                    bteDotKiemKe.Text += (String.IsNullOrEmpty(bteDotKiemKe.Text) ? String.Empty : ", ") + dotKiemKeInfor.MaDotKiemKe;
                }
            }
        }

        private void bteDotKiemKe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookup_DotKiemKeKetThuc frm = new frmLookup_DotKiemKeKetThuc(true);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    bteDotKiemKe.Tag = frm.SelectedItems;
                    foreach (DotKiemKeInfor dotKiemKeInfor in frm.SelectedItems)
                    {
                        bteDotKiemKe.Text += (String.IsNullOrEmpty(bteDotKiemKe.Text) ? String.Empty : ", ") + dotKiemKeInfor.MaDotKiemKe;
                    }
                }
            }
        }
        private void bteDotKiemKe_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteDotKiemKe.Text)) bteDotKiemKe.Tag = null;
        }
        #endregion

        private void frm_BaoCaoChiTietHangChuyenKho_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
            if (lstBC == null) lstBC = new List<BCChiTietKiemKeInfo>();
            grcBCKiemKe.DataSource = new BindingList<BCChiTietKiemKeInfo>(lstBC);
        }
        private bool Check()
        {
            if (bteDotKiemKe.Tag == null && deNgayThucHien.EditValue == null)
            {
                throw new ManagedException("Bạn chưa chọn đợt kiểm kê hoặc ngày thực hiện!");
            }
            return true;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            string maKho = bteKho.Text;
            int idDotKiemKe = 0;
            List<DotKiemKeInfor> lstDotKiemKeInfo = bteDotKiemKe.Tag == null ? null : (List<DotKiemKeInfor>)bteDotKiemKe.Tag; ;

            lstBC.Clear();
            ((BindingList<BCChiTietKiemKeInfo>)grcBCKiemKe.DataSource).ResetBindings();

            try
            {
                if (Check())
                {
                    frmProgress.Instance.Caption = Text;
                    frmProgress.Instance.Text = "Tổng hợp số liệu báo cáo kiểm kê";
                    frmProgress.Instance.Value = 0;
                    frmProgress.Instance.DoWork(
                        delegate
                            {
                                frmProgress.Instance.Description = "Đang chuẩn bị số liệu kiểm kê";
                                if (lstDotKiemKeInfo == null)
                                {
                                    lstDotKiemKeInfo = DotKiemKeDataProvider.Instance.GetListByDate(deNgayThucHien.DateTime);
                                }

                                frmProgress.Instance.MaxValue = lstDotKiemKeInfo.Count;

                                while (frmProgress.Instance.Value < frmProgress.Instance.MaxValue)
                                {
                                    if (lstDotKiemKeInfo!= null)
                                    {
                                        idDotKiemKe = lstDotKiemKeInfo[frmProgress.Instance.Value].IdDotKiemKe;
                                        frmProgress.Instance.Description = "Đang chuẩn bị số liệu đợt kiểm kê " +
                                            lstDotKiemKeInfo[frmProgress.Instance.Value].MaDotKiemKe;
                                    } else
                                    {
                                        frmProgress.Instance.Description = "Đang chuẩn bị số liệu đợt kiểm kê ";
                                    }
                                    lstBC.AddRange(BaoCaoKiemKeDataProvider.Instance.
                                        GetBCKiemKeTonKho(maKho, idDotKiemKe));

                                    this.Invoke((MethodInvoker)
                                                delegate
                                                    {
                                                        ((BindingList<BCChiTietKiemKeInfo>)
                                                         grcBCKiemKe.DataSource).ResetBindings();
                                                    });

                                    frmProgress.Instance.Value += 1;
                                }
                                frmProgress.Instance.Description = "Đã hoàn thành";
                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                                frmProgress.Instance.IsCompleted = true;
                            });

                    
                }
            }
            catch (ManagedException ex)
            {
                frmProgress.Instance.Description = "Không hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            catch (Exception ex)
            {
                frmProgress.Instance.Description = "Không hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
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
            Common.Export2ExcelFromDevGrid<BCChiTietKiemKeInfo>(grvBCKiemKe, "BCKiemKeTonKho");
        }
        #region bteKho
        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho2 frmLookUpKho = new frmLookUp_Kho2(Declare.IdNhanVien,true);
            if(frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.EditValue = String.Empty;
                bteKho.Tag = frmLookUpKho.SelectedItems;
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
                frmLookUp_Kho2 frmLookUpKho2 = new frmLookUp_Kho2(Declare.IdNhanVien, true);
                if (frmLookUpKho2.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frmLookUpKho2.SelectedItems;
                    //bteKho.Text = frmLookUpKho2.SelectedItems.TenKho;
                    //MaKho = frmLookUpKho.SelectedItem.MaKho;
                    foreach (DMKhoInfo selectedItem in frmLookUpKho2.SelectedItems)
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

        //#region bteTrungTam
        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            //if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            //{
            //    bteTrungTam.EditValue = String.Empty;
            //    bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
            //    //bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
            //    //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
            //    bteKho.Text = "";
            //    foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
            //    {
            //        bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
            //    }
            //}
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true, String.Format("%{0}%", bteTrungTam.Text),Declare.IdNhanVien);
            //    if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            //    {
            //        bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
            //        //bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
            //        //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
            //        bteKho.Text = "";
            //        foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
            //        {
            //            bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
            //        }
            //    }
            //}
        }

        private void bteTrungTam_TextChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(bteTrungTam.Text)) bteTrungTam.Tag = null;
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

        private void ChungTuLienQuanTsm_Click(object sender, EventArgs e)
        {
            BCChiTietKiemKeInfo kiemKeChiTietInfor = (BCChiTietKiemKeInfo)grvBCKiemKe.GetFocusedRow();
            if (kiemKeChiTietInfor != null)
            {
                Form frm = new frmThongKe_ChungTuKiemKeLienQuanTon(kiemKeChiTietInfor);
                frm.ShowDialog();
            }
        }
        //#endregion
    }
}