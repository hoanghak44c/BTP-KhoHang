using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoDongBoPO : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        List<TongHopGiaoDichNhapHangReportInfo> lichitiet = new List<TongHopGiaoDichNhapHangReportInfo>();
        List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam;
        private string MaKho;
        private int IdTrungTam;
        #endregion
        public frm_BaoCaoDongBoPO()
        {
            InitializeComponent();
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadLoaiGiaoDich()
        {
            List<LookUp> ligiaodich = new List<LookUp>();
            ligiaodich.Add(new LookUp { OID = 0, Name = "Nhập hàng mua" });
            ligiaodich.Add(new LookUp { OID = 1, Name = "Trả hàng nhà cung cấp" });
            lueLoaiGiaoDich.Properties.DataSource = null;
            lueLoaiGiaoDich.Properties.DataSource = ligiaodich;
            lueLoaiGiaoDich.EditValue = ligiaodich[0].OID;
        }

        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false,String.Format("%{0}%", bteTrungTam.Text),Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
                IdTrungTam = frm.SelectedItem.IdTrungTam;
                bteKho.Text = "";
            }
        }

        private void bteTrungTam_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
                IdTrungTam = frm.SelectedItem.IdTrungTam;
                bteKho.Text = "";
            }
        }

        private void bteTrungTam_TextChanged(object sender, System.EventArgs e)
        {
            if(String.IsNullOrEmpty(bteTrungTam.Text))
            {
                MaTrungTam = String.Empty;
                IdTrungTam = 0;
                bteKho.Text = String.Empty;
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Tag = frm.SelectedItem;
                    bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                    MaTrungTam = frm.SelectedItem.MaTrungTam;
                    IdTrungTam = frm.SelectedItem.IdTrungTam;
                    bteKho.Text = "";
                }
            }
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false,String.Format("%{0}%", bteKho.Text),IdTrungTam,Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.MaKho;
            }
        }

        private void bteKho_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.MaKho;
            }
        }

        private void bteKho_TextChanged(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKho.Text))

                MaKho = String.Empty;
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frm.SelectedItem;
                    bteKho.Text = frm.SelectedItem.TenKho;
                    MaKho = frm.SelectedItem.MaKho;
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (deFrom.EditValue == null || deFrom.DateTime == DateTime.MinValue)
                {
                    deFrom.Focus();
                    throw new ManagedException("Bạn chưa chọn thời gian nhập");
                }

                if(deTo.EditValue == null || deTo.DateTime == DateTime.MinValue)
                {
                    deTo.Focus();
                    throw new ManagedException("Bạn chưa chọn thời gian nhập");
                }

                if(deFrom.DateTime > deTo.DateTime)
                {
                    deTo.Focus();
                    throw new ManagedException("Bạn chọn thời gian không hợp lệ");
                }

                var fromDate = deFrom.DateTime.Date;
                var toDate = deTo.DateTime.Date;
                var runningDate = toDate;
                var loaiGiaoDich = Convert.ToInt32(lueLoaiGiaoDich.EditValue);
                var lstResult = new List<LichSuNhapHangInfo>();
                grcBCHangChuyenKho.DataSource = lstResult;
                grcBCHangChuyenKho.RefreshDataSource();

                frmProgress.Instance.Caption = Text;
                frmProgress.Instance.Description = "Đang nạp dữ liệu...";
                frmProgress.Instance.MaxValue = (int) toDate.Subtract(fromDate).TotalDays + 1;
                frmProgress.Instance.MinValue = 0;
                frmProgress.Instance.DoWork(
                    delegate
                        {
                            while (runningDate >= fromDate)
                            {
                                var lstBuffer = BCDongBoPODataProvider.Instance.

                                    GetLichSuNhapHang(MaTrungTam, MaKho, runningDate, loaiGiaoDich);

                                if(lstBuffer.Count > 0)
                                {
                                    lstResult.AddRange(lstBuffer);
                                    
                                    if(InvokeRequired)
                                        
                                        Invoke((MethodInvoker)delegate { grcBCHangChuyenKho.RefreshDataSource(); });
                                    
                                    else

                                        grcBCHangChuyenKho.RefreshDataSource();

                                    runningDate = runningDate.AddDays(-1);

                                    frmProgress.Instance.Value += 1;
                                }
                                else
                                {
                                    var nextDate = BCDongBoPODataProvider.Instance.

                                        GetNextDateNhapHang(MaTrungTam, MaKho, runningDate, loaiGiaoDich).Date;

                                    var totalDays = (int) runningDate.Subtract(nextDate).TotalDays;

                                    runningDate = runningDate.AddDays(-totalDays);

                                    frmProgress.Instance.Value += totalDays;
                                }
                            }

                            frmProgress.Instance.Description = "Đã xong!";
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                            frmProgress.Instance.IsCompleted = true;
                        });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            Common.Export2ExcelFromDevGrid<LichSuNhapHangInfo>(grvBCHangChuyenKho, "BCDongBoPO");
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
            deFrom.DateTime = DateTime.Now;
            deTo.DateTime = DateTime.Now;
            LoadLoaiGiaoDich();
        }

        private void grcBCHangChuyenKho_Click(object sender, EventArgs e)
        {

        }
    }
}