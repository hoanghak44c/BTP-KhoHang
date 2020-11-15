using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Form;
using ThreadState = System.Threading.ThreadState;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmThongKe_XuatNhapTonLichSu : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int idKho, idTrungTam;
        private List<KhoThongKeHangTonLichSuInfo> list;

        public frmThongKe_XuatNhapTonLichSu()
        {
            InitializeComponent();
            grvThongKeHangTon.ColumnFilterChanged += new EventHandler(grvThongKeHangTon_ColumnFilterChanged);
        }

        private void frmThongKe_XuatNhapTonLichSu_Load(object sender, EventArgs e)
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

        int pageSize = 50;
        int pageIndex = 0;
        int pageTotal = -1;

        private void LoadTon()
        {
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

                            frmProgress.Instance.MaxValue = pageTotal;
                            frmProgress.Instance.Value = 0;
                            while (frmProgress.Instance.Value < frmProgress.Instance.MaxValue)
                            {
                                List<KhoThongKeHangTonLichSuInfo> listTmp = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu(
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
                            List<KhoThongKeHangTonLichSuInfo> listTmp = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu(
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

            foreach (GridColumn column in this.grvThongKeHangTon.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
                column.OptionsColumn.ReadOnly = true;
            }
        }

        private bool isActivating;

        private void frmThongKe_XuatNhapTonLichSu_Activated(object sender, EventArgs e)
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

        private void TonChiTietMaVachTsm_Click(object sender, EventArgs e)
        {
            TonInfoBase khoThongKeHangTonInfo = (TonInfoBase)grvThongKeHangTon.GetFocusedRow();
            if(khoThongKeHangTonInfo != null)
            {
                Form frm = new frmThongKe_TonChiTietMaVach(khoThongKeHangTonInfo);
                frm.ShowDialog();
            }
        }

        private void ChungTuLienQuanTsm_Click(object sender, EventArgs e)
        {
            TonInfoBase khoThongKeHangTonInfo = (TonInfoBase)grvThongKeHangTon.GetFocusedRow();
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
                pageIndex = 0;
                pageTotal = KhoThongKeHangTonDataProvider.Instance.LoadDataThongKeHangTonLichSu(0, bteSanpham.Text, bteKho.Text, String.Empty, fromDate, toDate, pageSize, Declare.UserId);
                list = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu3(
                                        bteKho.Text, String.Empty, fromDate, toDate, pageIndex, pageSize, Declare.UserId);
                grcHangTon.DataSource = list;
                LoadForm();

                isActivating = true;
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
            Common.DevExport2Excel(grvThongKeHangTon);
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
            //else
            //{
            //    bteSanpham.Tag = DmSanPhamProvider.Instance.GetSanPhamByMa(bteSanpham.Text);
            //}
        }

        private int rowNums;

        private bool loading = false;

        private void grvThongKeHangTon_TopRowChanged(object sender, EventArgs e)
        {
            if (loading) return;

            GridViewInfo info = grvThongKeHangTon.GetViewInfo() as GridViewInfo;

            rowNums = info.RowsInfo.Count;

            Debug.Print(grvThongKeHangTon.TopRowIndex.ToString());

            var workerThread = new Thread(FetchTopIndexData);

            workerThread.Start(grvThongKeHangTon.TopRowIndex);

        }

        void grvThongKeHangTon_ColumnFilterChanged(object sender, EventArgs e)
        {
            if(grvThongKeHangTon.Columns["MaSanPham"].FilterInfo.Value!= null)
            {
                pageIndex = 0;
                pageTotal = KhoThongKeHangTonDataProvider.Instance.LoadDataThongKeHangTonLichSu(0, grvThongKeHangTon.Columns["MaSanPham"].FilterInfo.Value.ToString(), bteKho.Text, String.Empty, fromDate, toDate, pageSize, Declare.UserId);
                list = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu3(
                                        bteKho.Text, String.Empty, fromDate, toDate, pageIndex, pageSize, Declare.UserId);
                grcHangTon.DataSource = list;
            }
            else
            {
                pageIndex = 0;
                pageTotal = KhoThongKeHangTonDataProvider.Instance.LoadDataThongKeHangTonLichSu(0, bteSanpham.Text, bteKho.Text, String.Empty, fromDate, toDate, pageSize, Declare.UserId);
                list = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu3(
                                        bteKho.Text, String.Empty, fromDate, toDate, pageIndex, pageSize, Declare.UserId);
                grcHangTon.DataSource = list;                
            }
        }

        void FetchTopIndexData(object topIndex)
        {
            int step = pageSize;

            if (loading || pageIndex >= pageTotal) return;

            if (Convert.ToInt32(topIndex) + rowNums + step  < (list.Count/(pageIndex + 1))) return;

            pageIndex += 1;

            loading = true;

            Invoke((MethodInvoker)
                   delegate()
                   {
                       pbStatus.Properties.Maximum = step;
                   });

            Invoke((MethodInvoker)
                   delegate()
                   {
                       pbStatus.EditValue = 0;
                   });

            List<KhoThongKeHangTonLichSuInfo> listTmp =
                KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu3(
                    bteKho.Text, String.Empty, fromDate, toDate, pageIndex, pageSize, Declare.UserId);

            for (int i = 0; i < listTmp.Count; i++)
            {
                list.Add(listTmp[i]);

                Invoke((MethodInvoker)
                   delegate()
                   {
                       pbStatus.EditValue = Convert.ToInt32(pbStatus.EditValue) + 1;
                   });
            }

            Invoke((MethodInvoker)
                   delegate()
                   {
                       grcHangTon.RefreshDataSource();
                   });

            loading = false;
        }

        void FetchPageIndexData(object pageIndex)
        {
            try
            {
                if (Convert.ToInt32(pageIndex) > pageTotal) return;
                List<KhoThongKeHangTonLichSuInfo> listTmp =
                    KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu3(
                        bteKho.Text, String.Empty, fromDate, toDate, Convert.ToInt32(pageIndex), pageSize, Declare.UserId);
                if (listTmp.Count > 0 && listTmp[0] != null && !String.IsNullOrEmpty(listTmp[0].MaSanPham))
                {
                    list.AddRange(listTmp);
                } 
                else
                {
                    throw new Exception("Khong co du lieu");
                }
            }
            catch (Exception)
            {
                listPageErr.Add(Convert.ToInt32(pageIndex));
            }
        }

        void LoadAllData()
        {
            if (pageTotal == -1)
            {
                pageTotal = KhoThongKeHangTonDataProvider.Instance.LoadDataThongKeHangTonLichSu(0, sSanPham, sKho, String.Empty, fromDate, toDate, pageSize, Declare.UserId);
                pageIndex = 0;

                list = KhoThongKeHangTonDataProvider.Instance.GetListThongKeHangTonLichSu3(
                                        bteKho.Text, String.Empty, fromDate, toDate, pageIndex, pageSize, Declare.UserId);

            }

            Invoke((MethodInvoker)
                   delegate()
                       {
                           grcHangTon.DataSource = list;
                           pbStatus.Properties.Maximum = pageTotal - 1;
                           pbStatus.EditValue = 0;
                       });

            while (pageIndex < pageTotal || listPageErr.Count > 0)
            {
                if (pageIndex < pageTotal)
                {
                    for (int i = 0; i < listLoadWorker.Capacity; i++)
                    {
                        if (i == listLoadWorker.Count)
                        {
                            pageIndex += 1;
                            listLoadWorker.Add(new Thread(FetchPageIndexData));
                            listLoadWorker[i].Start(pageIndex);
                        }
                        if (listLoadWorker[i] == null || listLoadWorker[i].ThreadState != ThreadState.Running)
                        {
                            pageIndex += 1;
                            listLoadWorker[i] = new Thread(FetchPageIndexData);
                            listLoadWorker[i].Start(pageIndex);
                        }
                    }                    
                }
                else 
                {
                    for (int i = 0; i < listLoadWorker.Capacity; i++)
                    {
                        if (listPageErr.Count > 0)
                        {
                            if (i == listLoadWorker.Count)
                            {
                                listLoadWorker.Add(new Thread(FetchPageIndexData));
                                listLoadWorker[i].Start(listPageErr[0]);
                                listPageErr.RemoveAt(0);
                            }
                            if (listLoadWorker[i] == null || listLoadWorker[i].ThreadState != ThreadState.Running)
                            {
                                listLoadWorker[i] = new Thread(FetchPageIndexData);
                                listLoadWorker[i].Start(listPageErr[0]);
                                listPageErr.RemoveAt(0);
                            }
                            Thread.Sleep(500);
                        }
                    }
                }
                Invoke((MethodInvoker)
                       delegate()
                       {
                           pbStatus.EditValue = pageIndex - listPageErr.Count;
                           grcHangTon.RefreshDataSource();
                       });
            }
            Invoke((MethodInvoker)
                   delegate()
                   {
                       pbStatus.EditValue = pageIndex;
                       grcHangTon.RefreshDataSource();
                       btnViewAll.Enabled = true;
                       btnReload.Enabled = true;
                       btnExport.Enabled = true;
                   });
            loading = false;
        }

        private List<Thread> listLoadWorker;
        private List<int> listPageErr;
        private string sSanPham, sKho;
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                loading = true;
                btnViewAll.Enabled = false;
                btnReload.Enabled = false;
                btnExport.Enabled = false;
                if (pageIndex >= pageTotal)
                {
                    pageTotal = -1;
                    pageIndex = 0;
                    if (list== null) list = new List<KhoThongKeHangTonLichSuInfo>();
                    list.Clear();
                    grcHangTon.RefreshDataSource();
                }

                fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
                toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);
                sSanPham = bteSanpham.Text;
                sKho = bteKho.Text;
                listPageErr = new List<int>();

                if (listLoadWorker == null) listLoadWorker = new List<Thread>(20);

                Thread mainWorker = new Thread(LoadAllData);
                mainWorker.Start();

                isActivating = true;
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