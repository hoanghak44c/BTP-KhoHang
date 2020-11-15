using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmThongKe_TonSanPham : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int idKho, idTrungTam;
        private List<KhoThongKeHangTonInfo> list;

        public frmThongKe_TonSanPham()
        {
            InitializeComponent();
        }

        private void frmThongKe_TonSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                //----------------
                cboKyBaoCao.Items.Add("Ngày");
                for (int i = 1; i < 13; i++)
                    cboKyBaoCao.Items.Add("Tháng " + i.ToString());
                for (int i = 1; i <= 4; i++)
                    cboKyBaoCao.Items.Add("Quý " + i.ToString());
                cboKyBaoCao.Items.Add("Năm");
                cboKyBaoCao.Items.Add("Tùy chọn");
                //----------------
                deTo.EditValue = DateTime.Now;
                deFrom.EditValue = deTo.EditValue;

                //bteKho.Tag = DMKhoDataProvider.GetListDMKhoInfor().Find(
                //    delegate(DMKhoInfo match) { return match.IdKho == Declare.IdKho; });
                //if (bteKho.Tag != null)
                //    bteKho.EditValue = ((DMKhoInfo)bteKho.Tag).TenKho;
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

        private void LoadTon()
        {
            int pageSize = 500;
            int pageTotal;
            if (bteKho.Tag != null)
            {
                int step = 0;
                List<DMKhoInfo> listKho = (List<DMKhoInfo>)bteKho.Tag;
                int max = listKho.Count;
                List<DMSanPhamInfo> listSanPham;

                listSanPham = (List<DMSanPhamInfo>)bteSanpham.Tag;

                if(bteSanpham.Tag != null)
                    max = listKho.Count*listSanPham.Count;

                step += 1;

                frmProgress.Instance.MaxValue = max;
                frmProgress.Instance.Value = 0;

                foreach (DMKhoInfo dmKhoInfo in listKho)
                {
                    if (listSanPham!= null)
                    {
                        foreach (DMSanPhamInfo dmSanPhamInfo in listSanPham)
                        {
                            frmProgress.Instance.PushStatus();
                            frmProgress.Instance.Description = dmKhoInfo.MaKho + ": Đang load dữ liệu ...";
                            pageTotal = KhoThongKeHangTonDataProvider.Instance.LoadDataThongKeHangTonKho(step, dmSanPhamInfo.IdSanPham, dmKhoInfo.IdKho, 0, fromDate, toDate, pageSize, Declare.UserId);

                            frmProgress.Instance.MaxValue = pageTotal;
                            frmProgress.Instance.Value = 0;
                            while (frmProgress.Instance.Value < frmProgress.Instance.MaxValue)
                            {
                                List<KhoThongKeHangTonInfo> listTmp = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonKho2(
                                        dmKhoInfo.IdKho, 0, fromDate, toDate, frmProgress.Instance.Value, pageSize, Declare.UserId);

                                list.AddRange(listTmp);

                                Invoke((MethodInvoker)
                                       delegate()
                                       {
                                           grcHangTon.RefreshDataSource();
                                           grvThongKeHangTon.ExpandAllGroups();
                                       });
                                frmProgress.Instance.Value += 1;
                            }
                            frmProgress.Instance.PopStatus();
                            step += 1;
                            frmProgress.Instance.Value = step;
                        }                        
                    } 
                    else
                    {
                        frmProgress.Instance.PushStatus();
                        frmProgress.Instance.Description = dmKhoInfo.MaKho + ": Đang load dữ liệu ...";
                        pageTotal = KhoThongKeHangTonDataProvider.Instance.LoadDataThongKeHangTonKho(step, 0, dmKhoInfo.IdKho, 0, fromDate, toDate, pageSize, Declare.UserId);

                        frmProgress.Instance.MaxValue = pageTotal;
                        frmProgress.Instance.Value = 0;
                        while (frmProgress.Instance.Value < frmProgress.Instance.MaxValue)
                        {
                            List<KhoThongKeHangTonInfo> listTmp = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonKho2(
                                    dmKhoInfo.IdKho, 0, fromDate, toDate, frmProgress.Instance.Value, pageSize, Declare.UserId);

                            list.AddRange(listTmp);

                            Invoke((MethodInvoker)
                                   delegate()
                                   {
                                       grcHangTon.RefreshDataSource();
                                       grvThongKeHangTon.ExpandAllGroups();
                                   });
                            frmProgress.Instance.Value += 1;
                        }
                        step += 1;
                        frmProgress.Instance.PopStatus();
                        step += 1;
                        frmProgress.Instance.Value = step;
                    }
                }
            }
            else
                throw new ManagedException("Bạn chưa chọn kho");

            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
            frmProgress.Instance.Description = "Đã xong";
        }

        private void LoadForm()
        {
            fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
            toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);

            if (grcHangTon.ContextMenuStrip.Items.ContainsKey("ChonCotHienThi"))
            {
                //frmProgress.Instance.Description = "Đang lấy dữ liệu...";
                //frmProgress.Instance.MaxValue = 100;
                //frmProgress.Instance.Value = 0;
                //frmProgress.Instance.DoWork(this, LoadTon);
                //grcHangTon.DataSource = list;
            }
            else
            {
                grcHangTon.ContextMenuStrip.Items.Add("Xóa dữ liệu", null, btnDeleteData_Click);
                grcHangTon.ContextMenuStrip.Items.Add("Export dữ liệu", null, btnExport_Click);
                ToolStripItem[] tmp = new ToolStripItem[grcHangTon.ContextMenuStrip.Items.Count];
                grcHangTon.ContextMenuStrip.Items.CopyTo(tmp, 0);

                ToolStripMenuItem menuItem = new ToolStripMenuItem("Chọn cột hiển thị");
                menuItem.Name = "ChonCotHienThi";

                //frmProgress.Instance.Description = "Đang lấy dữ liệu...";
                //frmProgress.Instance.MaxValue = 100;
                //frmProgress.Instance.Value = 0;
                //frmProgress.Instance.DoWork(this, LoadTon);
                //grcHangTon.DataSource = list;

                ToolStripItem[] tmp1 = new ToolStripItem[grcHangTon.ContextMenuStrip.Items.Count];
                grcHangTon.ContextMenuStrip.Items.CopyTo(tmp1, 0);
                menuItem.DropDownItems.AddRange(tmp1);

                grcHangTon.ContextMenuStrip.Items.Clear();

                grcHangTon.ContextMenuStrip.Items.AddRange(tmp);
                grcHangTon.ContextMenuStrip.Items.Add(menuItem);
            }
            if (this.grvThongKeHangTon.SortInfo.Count == 0)
            {
                this.grvThongKeHangTon.GroupCount = 5;
                this.grvThongKeHangTon.SortInfo
                    .AddRange(new[]
                                  {
                                      new GridColumnSortInfo(
                                          this.grvThongKeHangTon.Columns["TenTrungTam"],
                                          ColumnSortOrder.Ascending),
                                      new GridColumnSortInfo(
                                          this.grvThongKeHangTon.Columns["TenKho"],
                                          ColumnSortOrder.Ascending),
                                      new GridColumnSortInfo(
                                          this.grvThongKeHangTon.Columns["Nganh"],
                                          ColumnSortOrder.Ascending),
                                      new GridColumnSortInfo(
                                          this.grvThongKeHangTon.Columns["Loai"],
                                          ColumnSortOrder.Ascending),
                                      new GridColumnSortInfo(
                                          this.grvThongKeHangTon.Columns["Hang"],
                                          ColumnSortOrder.Ascending),
                                  });
            }

            foreach (GridColumn column in this.grvThongKeHangTon.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
                column.OptionsColumn.ReadOnly = true;
            }
        }

        private bool isActivating;

        private void frmThongKe_TonSanPham_Activated(object sender, EventArgs e)
        {
//            try
//            {
//                if (!isActivating)
//                {
//                    isActivating = true;
//                    LoadForm();
//                }
//                isActivating = false;
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.ToString());
//#else
//                MessageBox.Show(ex.Message);
//#endif
//            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            return;
        }

        private void TonChiTietMaVachTsm_Click(object sender, EventArgs e)
        {
            KhoThongKeHangTonInfo khoThongKeHangTonInfo = (KhoThongKeHangTonInfo) grvThongKeHangTon.GetFocusedRow();
            if(khoThongKeHangTonInfo != null)
            {
                Form frm = new frmThongKe_TonChiTietMaVach(khoThongKeHangTonInfo);
                frm.ShowDialog();
            }
        }

        private void ChungTuLienQuanTsm_Click(object sender, EventArgs e)
        {
            KhoThongKeHangTonInfo khoThongKeHangTonInfo = (KhoThongKeHangTonInfo)grvThongKeHangTon.GetFocusedRow();
            if (khoThongKeHangTonInfo != null)
            {
                Form frm = new frmThongKe_ChungTuLienQuan(khoThongKeHangTonInfo);
                frm.ShowDialog();
            }
        }
        
        private void TongHop(int idKho, int idTrungTam, DateTime fromDate, DateTime toDate)
        {
            if (fromDate.Day == 1 && fromDate.Month == 1 && toDate.Day == 31 && toDate.Month == 12)
            {
                //tong hop du lieu monthly
                //KhoThongKeHangTonDataProvider.
                //        Instance.TongHopTonTheoNam(idKho, idTrungTam, fromDate, toDate);

                Debug.Print(String.Format("sp_TongHopTonTheoNam({0},{1},{2},{3});", idKho, idTrungTam, fromDate, toDate));

            }
            else if (fromDate.Day == 1 && toDate.Day == DateTime.DaysInMonth(toDate.Year, toDate.Month))
            {
                //tong hop du lieu monthly
                //KhoThongKeHangTonDataProvider.
                //        Instance.TongHopTonTheoThang(idKho, idTrungTam, fromDate, toDate);

                Debug.Print(String.Format("sp_TongHopTonTheoThang({0},{1},{2},{3});", idKho, idTrungTam, fromDate, toDate));

            }
            else
            {
                //tong hop du lieu daily
                //KhoThongKeHangTonDataProvider.
                //        Instance.TongHopTonTheoNgay(idKho, idTrungTam, fromDate, toDate);

                Debug.Print(String.Format("sp_TongHopTonTheoNgay({0},{1},{2},{3});", idKho, idTrungTam, fromDate, toDate));

            }
        }

        private void TongHopDuLieu()
        {
            KhoThongKeHangTonDataProvider.Instance.TongHopTon(idKho, idTrungTam, fromDate, toDate);

            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                        
            frmProgress.Instance.Description = "Đã hoàn thành.";

            frmProgress.Instance.IsCompleted = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
                toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);
                if(bteKho.Tag == null) throw new Exception("Bạn chưa chọn kho");

                //idKho = bteKho.Tag == null ? 0 : ((DMKhoInfo)bteKho.Tag).IdKho;
                //idTrungTam = bteKho.Tag == null || ((DMKhoInfo)bteKho.Tag).IdKho != 0 ? 0 : ((DMKhoInfo)bteKho.Tag).IdTrungTam;

                //frmProgress.Instance.Text = "Tổng hợp số tồn";
                //frmProgress.Instance.Description = "Đang tổng hợp số tồn ...";
                //frmProgress.Instance.MaxValue = 9;
                //frmProgress.Instance.Value = 0;
                //frmProgress.Instance.DoWork(TongHopDuLieu);

                //grcHangTon.DataSource = KhoThongKeHangTonDataProvider.Instance.GetListTonKho(idKho, idTrungTam, fromDate, toDate);

                list = new List<KhoThongKeHangTonInfo>();
                grcHangTon.DataSource = list;
                LoadForm();

                isActivating = true;
                frmProgress.Instance.Description = "Đang lấy dữ liệu...";
                frmProgress.Instance.MaxValue = 100;
                frmProgress.Instance.Value = 0;
                frmProgress.Instance.DoWork(LoadTon);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            grcHangTon.ShowPrintPreview();
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);

            if(frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.EditValue = String.Empty;
                bteKho.Tag = frmLookUpKho.SelectedItems;
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
                    bteKho.Tag = frmLookUpKho.SelectedItems;
                    foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                    {
                        bteKho.EditValue += selectedItem.MaKho + ", ";
                    }
                }
            }
        }

        private void bteKho_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(bteKho.Text))
            {
                bteKho.Tag = null;
            }
        }

        private void cboKyBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nam = DateTime.Today.Year;
            if (cboKyBaoCao.Text == "Ngày")
            {
                deTo.EditValue = DateTime.Today;
                deFrom.EditValue = deTo.EditValue;
            }
            else if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));
                if (thang > Convert.ToDateTime(deFrom.EditValue).Month)
                {
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thang,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deTo.EditValue).Year, thang));
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thang, 1);
                }
                else
                {
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thang, 1);
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thang,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deFrom.EditValue).Year, thang));
                }
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangdau = (quy - 1) * 3 + 1;
                int thangcuoi = (quy - 1) * 3 + 3;
                if (thangcuoi > Convert.ToDateTime(deTo.EditValue).Month)
                {
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thangcuoi,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deTo.EditValue).Year,
                                                                       thangcuoi));
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, thangdau, 1);                    
                } 
                else
                {
                    deFrom.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thangdau, 1);
                    deTo.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year, thangcuoi,
                                                  DateTime.DaysInMonth(Convert.ToDateTime(deFrom.EditValue).Year,
                                                                       thangcuoi));
                }
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                deTo.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, 12, 31);
                deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year, 1, 1);
            }
            else
            {
                deFrom.Enabled = true;
                deTo.Enabled = true;
            }
        }

        private void deTo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (deFrom.EditValue!= null && Convert.ToDateTime(e.NewValue) < Convert.ToDateTime(deFrom.EditValue))
            {
                e.Cancel = true;
                return;
            }

            if (cboKyBaoCao.Text == "Ngày") return;

            if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));

                if (Convert.ToDateTime(e.NewValue).Day != DateTime.DaysInMonth(Convert.ToDateTime(e.NewValue).Year, thang))
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thang)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangcuoi = (quy - 1) * 3 + 3;
                if (Convert.ToDateTime(e.NewValue).Day != DateTime.DaysInMonth(Convert.ToDateTime(e.NewValue).Year, thangcuoi))
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thangcuoi)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                if (Convert.ToDateTime(e.NewValue).Day != 31)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != 12)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void deFrom_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (deTo.EditValue != null && Convert.ToDateTime(e.NewValue) > Convert.ToDateTime(deTo.EditValue))
            {
                e.Cancel = true;
                return;
            }

            if (cboKyBaoCao.Text == "Ngày") return;

            if (cboKyBaoCao.Text.IndexOf("Tháng") >= 0)
            {
                int thang = int.Parse(cboKyBaoCao.Text.Substring(6));
                if (Convert.ToDateTime(e.NewValue).Day != 1)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thang)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text.IndexOf("Quý") >= 0)
            {
                int quy = int.Parse(cboKyBaoCao.Text.Substring(4));
                int thangdau = (quy - 1) * 3 + 1;
                if (Convert.ToDateTime(e.NewValue).Day != 1)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != thangdau)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if (cboKyBaoCao.Text == "Năm")
            {
                if (Convert.ToDateTime(e.NewValue).Day != 1)
                {
                    e.Cancel = true;
                    return;
                }
                if (Convert.ToDateTime(e.NewValue).Month != 1)
                {
                    e.Cancel = true;
                    return;
                }
            }
       }

        private void deFrom_EditValueChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(cboKyBaoCao.Text) || cboKyBaoCao.Text == "Tùy chọn" || cboKyBaoCao.Text == "Ngày")
                return;
            
            if (Convert.ToDateTime(deTo.EditValue).Year != Convert.ToDateTime(deFrom.EditValue).Year)
            {
                deTo.EditValue = new DateTime(Convert.ToDateTime(deFrom.EditValue).Year,
                                              Convert.ToDateTime(deTo.EditValue).Month,
                                              DateTime.DaysInMonth(Convert.ToDateTime(deFrom.EditValue).Year,
                                                                   Convert.ToDateTime(deTo.EditValue).Month));
            }
        }

        private void deTo_EditValueChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cboKyBaoCao.Text) || cboKyBaoCao.Text == "Tùy chọn" || cboKyBaoCao.Text == "Ngày")
                return;

            if (Convert.ToDateTime(deFrom.EditValue).Year != Convert.ToDateTime(deTo.EditValue).Year)
            {
                deFrom.EditValue = new DateTime(Convert.ToDateTime(deTo.EditValue).Year,
                                              Convert.ToDateTime(deFrom.EditValue).Month,
                                              Convert.ToDateTime(deFrom.EditValue).Day);
            }
        }

        private void bteSanpham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham frmLookUpSanPham = new frmLookUp_SanPham(true);
            if(frmLookUpSanPham.ShowDialog() == DialogResult.OK)
            {
                bteSanpham.EditValue = String.Empty;
                bteSanpham.Tag = frmLookUpSanPham.SelectedItems;
                foreach (DMSanPhamInfo selectedItem in frmLookUpSanPham.SelectedItems)
                {
                    bteSanpham.EditValue += selectedItem.MaSanPham + ", ";
                }
            }
        }

        private void bteSanpham_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteSanpham.Text))
            {
                bteSanpham.Tag = null;
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {

        }
    }
}