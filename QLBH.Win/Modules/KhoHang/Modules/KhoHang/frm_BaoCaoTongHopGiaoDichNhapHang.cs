using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoTongHopGiaoDichNhapHang : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        private List<TongHopGiaoDichNhapHangReportInfo> lichitiet;
        private KeyValuePair<DateTime, int> param;
        private string MaTrungTam, MaKho, Nganh;
        private int IdTrungTam;
        private bool isAborted;
        private Thread tongHopDuLieuThread, loadDuLieuThread1, loadDuLieuThread2, loadDuLieuThread3;
        private bool loading;
        private bool isComputing;
        private DateTime dComputing;
        private bool isPreparing;
        private DateTime sysDate;

        #endregion
        public frm_BaoCaoTongHopGiaoDichNhapHang()
        {
            InitializeComponent();
            
            this.FormClosing += frm_BaoCaoTongHopGiaoDichNhapHang_FormClosing;

            lichitiet = new List<TongHopGiaoDichNhapHangReportInfo>();
            grcBCHangChuyenKho.DataSource = lichitiet;
            sysDate = CommonProvider.Instance.GetSysDate().Date;
            deLapFrom.DateTime = sysDate;
            deLapTo.DateTime = sysDate;
            deNXFrom.DateTime = sysDate;
            deNXTo.DateTime = sysDate;

        }

        void frm_BaoCaoTongHopGiaoDichNhapHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tongHopDuLieuThread != null && tongHopDuLieuThread.IsAlive)
            {
                if(MessageBox.Show(this, "Đang tổng hợp dữ liệu của báo cáo tổng hợp giao dịch nhập xuất, bạn có muốn dừng lại không?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                isAborted = true;
            }
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
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
                //LoadTrangThai();
                lichitiet.Clear();
                grcBCHangChuyenKho.RefreshDataSource();

                NhapReportDataProvider.Instance.XoaDuLieuTongHopNhapXuatReport(Declare.UserId);
                isPreparing = true;

                param = new KeyValuePair<DateTime, int>(DateTime.MinValue, -1);
                tongHopDuLieuThread = new Thread(TongHopDuLieu);
                tongHopDuLieuThread.Start();
                loadDuLieuThread1 = new Thread(LoadDuLieu);
                loadDuLieuThread1.Start();
                loadDuLieuThread2 = new Thread(LoadDuLieu);
                loadDuLieuThread2.Start();
                loadDuLieuThread3 = new Thread(LoadDuLieu);
                loadDuLieuThread3.Start();
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

        private void TongHopDuLieu()
        {
            if (loading) return;

            Invoke((MethodInvoker)
                   delegate
                       {
                           btnReload.Enabled = false;
                       });

            loading = true;
            int pageIndex = -1;
            int pageSize = 100;            

            DateTime nxTo = deNXTo.EditValue == null
                                ? sysDate
                                : Convert.ToDateTime(deNXTo.EditValue);

            dComputing = nxTo;
            isComputing = true;

            DateTime nxFrom = deNXFrom.EditValue == null
                                  ? deLapFrom.EditValue == null
                                        ? new DateTime(2013, 5, 1)
                                        : deLapFrom.DateTime
                                  : deLapFrom.EditValue == null
                                        ? deNXFrom.DateTime
                                        : deNXFrom.DateTime < deLapFrom.DateTime
                                              ? deLapFrom.DateTime
                                              : deNXFrom.DateTime;

            string sLoaiGiaoDich = String.Empty;
            if (bteLoaiGiaoDich.Tag != null)
            {
                sLoaiGiaoDich = ",";
                foreach (TransTypeInfo transTypeInfo in ((List<TransTypeInfo>)bteLoaiGiaoDich.Tag))
                {
                    sLoaiGiaoDich += transTypeInfo.OID + ",";
                }                
            }

            isPreparing = false;

            do
            {
                if(isAborted) return;
                dComputing = nxTo;
                Debug.Print("{0}: ThreadId {3} TongHopDuLieu Ngay Nhap {2} Page Index {1}", DateTime.Now, pageIndex, nxTo, Thread.CurrentThread.ManagedThreadId);
                Exception exception;

                do
                {
                    if (isAborted) return;

                    try
                    {
                        exception = null;
                        NhapReportDataProvider.Instance.TongHopDuLieuNhapXuatReportPNG(
                            Convert.ToDateTime(deLapFrom.EditValue),
                            Convert.ToDateTime(deLapTo.EditValue),
                            nxTo,
                            nxTo.AddDays(1),
                            Nganh, MaTrungTam, MaKho,
                            sLoaiGiaoDich,
                            ref pageIndex, pageSize, Declare.UserId, bteSanPham.Text);
                    }
                    catch (Exception ex)
                    {
                        exception = ex;
                        Debug.Print("{0}: ThreadId {1} {2}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, ex.ToString());
                        Debug.Print("{0}: ThreadId {3} Retry TongHopDuLieu Ngay Nhap {2} Page Index {1}", DateTime.Now, pageIndex, nxTo, Thread.CurrentThread.ManagedThreadId);
                    }
                    
                } while (exception != null);

                nxTo = nxTo.AddDays(-1);

            } while (nxTo >= nxFrom);
            
            dComputing = dComputing.AddDays(-1);
            isComputing = false;
            
            loading = false;

            LoadDuLieu();

            while(true)
            {
                if (isAborted) return;

                if (loadDuLieuThread1.IsAlive || loadDuLieuThread2.IsAlive || loadDuLieuThread3.IsAlive)
                {
                    Thread.CurrentThread.Join(100);
                }
                else
                {
                    break;
                }
            }

            Invoke((MethodInvoker)
                   delegate
                   {
                       btnReload.Enabled = true;
                   });

            MessageBox.Show("Đã tổng hợp xong.");
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool SetParamValue(ref DateTime nxTo, ref int pageIndex)
        {
            if (param.Key == DateTime.MinValue || param.Key > nxTo)
            {
                param = new KeyValuePair<DateTime, int>(nxTo, pageIndex);
                return true;                
            }

            if (param.Key == nxTo && param.Value < pageIndex)
            {
                param = new KeyValuePair<DateTime, int>(nxTo, pageIndex);
                return true;
            }

            if(param.Key < nxTo)
            {
                pageIndex = param.Value;
                nxTo = param.Key;
            }
            return false;
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void FetchData(List<TongHopGiaoDichNhapHangReportInfo> liTmp)
        {
            lichitiet.AddRange(liTmp);
        }

        private void LoadDuLieu()
        {
            try
            {
                //if (loading) return;
                //loading = true;
                int pageIndex = 0;
                int pageSize = 100;
                bool reTry;
                string sLoaiGiaoDich = String.Empty;
                Exception exception;

                List<TongHopGiaoDichNhapHangReportInfo> liTmp = new List<TongHopGiaoDichNhapHangReportInfo>();

                DateTime nxTo = deNXTo.EditValue == null
                               ? sysDate
                               : Convert.ToDateTime(deNXTo.EditValue);

                DateTime nxFrom = deNXFrom.EditValue == null
                                      ? deLapFrom.EditValue == null
                                            ? new DateTime(2013, 5, 1)
                                            : deLapFrom.DateTime
                                      : deLapFrom.EditValue == null
                                            ? deNXFrom.DateTime
                                            : deNXFrom.DateTime < deLapFrom.DateTime
                                                  ? deLapFrom.DateTime
                                                  : deNXFrom.DateTime;

                if (bteLoaiGiaoDich.Tag != null)
                {
                    sLoaiGiaoDich = ",";
                    foreach (TransTypeInfo transTypeInfo in ((List<TransTypeInfo>)bteLoaiGiaoDich.Tag))
                    {
                        sLoaiGiaoDich += transTypeInfo.OID + ",";
                    }
                }

                do
                {
                    if (isAborted) return;

                    do
                    {
                        if (isAborted) return;

                        while (isPreparing || dComputing == DateTime.MinValue || (dComputing >= nxTo && isComputing))
                        {
                            if (isAborted) return;
                            //pending here
                            Thread.Sleep(500);
                        }

                        reTry = false;

                        //Debug.Print("{0}: ThreadId {4} LoadDuLieu Ngay Nhap {3} Page Index {1} ", DateTime.Now, pageIndex, liTmp.Count, nxTo, Thread.CurrentThread.ManagedThreadId);

                        if (!SetParamValue(ref nxTo, ref pageIndex))
                        {
                            pageIndex += 1;
                            reTry = true;
                            continue;
                        }

                        do
                        {
                            if (isAborted) return;

                            try
                            {
                                exception = null;
                                liTmp =
                                    NhapReportDataProvider.Instance.GetDuLieuTongHopNhapXuatReportPNG(
                                        Convert.ToDateTime(deLapFrom.EditValue),
                                        Convert.ToDateTime(deLapTo.EditValue),
                                        nxTo,
                                        nxTo.AddDays(1),
                                        Nganh, MaTrungTam, MaKho,
                                        sLoaiGiaoDich,
                                        pageIndex, pageSize, Declare.UserId, bteSanPham.Text);
                            }
                            catch (Exception ex)
                            {
                                Debug.Print("{0}: ThreadId {4} Retry LoadDuLieu Ngay Nhap {3} Page Index {1} ", DateTime.Now, pageIndex, liTmp.Count, nxTo, Thread.CurrentThread.ManagedThreadId);
                                exception = ex;
                            }
                        } while (exception != null);

                        FetchData(liTmp);

                        Debug.Print("{0}: ThreadId {4} LoadDuLieu Ngay Nhap {3} Page Index {1} Count {2}", DateTime.Now, pageIndex, liTmp.Count, nxTo, Thread.CurrentThread.ManagedThreadId);

                        if (liTmp.Count > 0)
                        {
                            Debug.Print("{0}: ThreadId {4} XoaDuLieu Ngay Nhap {3} Page Index {1} Count {2}", DateTime.Now, pageIndex, liTmp.Count, nxTo, Thread.CurrentThread.ManagedThreadId);
                            
                            NhapReportDataProvider.Instance.XoaDuLieuTongHopNhapXuatReportPNG(
                                Convert.ToDateTime(deLapFrom.EditValue),
                                Convert.ToDateTime(deLapTo.EditValue),
                                nxTo,
                                nxTo.AddDays(1),
                                Nganh, MaTrungTam, MaKho,
                                sLoaiGiaoDich,
                                pageIndex, pageSize, Declare.UserId, bteSanPham.Text);
                        }

                        if (liTmp.Count > 0) pageIndex += 1;

                        Invoke((MethodInvoker)
                               delegate
                               {
                                   grcBCHangChuyenKho.RefreshDataSource();
                               });

                    } while (liTmp.Count >= pageSize || reTry);

                    pageIndex = 0;

                    nxTo = nxTo.AddDays(-1);

                } while (nxTo >= nxFrom);

                //loading = false;
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(),"Load Du Lieu");
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
                                     {
                                         FileName = "BCTongHopGiaoDichNhapHang",
                                         Filter =
                                             "CSV Files (*.csv)|*.csv|XML Files (*.xml)|*.xml|Excell Files (*.xlsb)|*.xlsb",
                                         InitialDirectory = Application.StartupPath,
                                         RestoreDirectory = true
                                     };
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = saveFileDialog.FileName;

                if(fileName.EndsWith("csv"))
                {
                    Common.Export2CsvFromDevGrid<TongHopGiaoDichNhapHangReportInfo>(grvBCHangChuyenKho, fileName);
                }
                else if (fileName.EndsWith("xml"))
                {
                    Common.Export2XmlFromDevGrid<TongHopGiaoDichNhapHangReportInfo>(grvBCHangChuyenKho, fileName);
                }
                else if(fileName.EndsWith("xlsb"))
                {
                    Common.Export2ExcelFromDevGridTest<TongHopGiaoDichNhapHangReportInfo>(grvBCHangChuyenKho, fileName);
                }
            }
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
           
        }
        
        private void bteNganhHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Nganh frmLookUpNganh = new frmLookUp_Nganh(String.Format("%{0}%", bteNganhHang.Text));

            if (frmLookUpNganh.ShowDialog() == DialogResult.OK)
            {
                bteNganhHang.Tag = frmLookUpNganh.SelectedItem;
                bteNganhHang.Text = ((SegmentInfo)bteNganhHang.Tag).Ma;
                Nganh = bteNganhHang.Text;
            }
        }

        private void bteNganhHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Nganh frmLookUpNganh = new frmLookUp_Nganh(String.Format("%{0}%", bteNganhHang.Text));

                if (frmLookUpNganh.ShowDialog() == DialogResult.OK)
                {
                    bteNganhHang.Tag = frmLookUpNganh.SelectedItem;
                    bteNganhHang.Text = ((SegmentInfo)bteNganhHang.Tag).Ma;
                    Nganh = bteNganhHang.Text;
                }
            }
        }

        private void bteNganhHang_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteNganhHang.Text))
            {
                bteNganhHang.Tag = null;
                Nganh = bteNganhHang.Text;
            }
        }

        private void bteLoaiGiaoDich_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TransType frmLookUpTransType = new frmLookUp_TransType(true, "%%");
            if (frmLookUpTransType.ShowDialog() == DialogResult.OK)
            {
                bteLoaiGiaoDich.Tag = frmLookUpTransType.SelectedItems;
                bteLoaiGiaoDich.Text = String.Empty;
                foreach (TransTypeInfo transTypeInfo in frmLookUpTransType.SelectedItems)
                {
                    bteLoaiGiaoDich.Text += transTypeInfo.Name + ",";
                }
            }
        }

        private void bteSanPham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham frmLookUpSanPham = new frmLookUp_SanPham(String.Format("%{0}%", bteSanPham.Text));
            if(frmLookUpSanPham.ShowDialog() == DialogResult.OK)
            {
                bteSanPham.Tag = frmLookUpSanPham.SelectedItem;
                bteSanPham.Text = frmLookUpSanPham.SelectedItem.MaSanPham;
            }
        }

        private void bteSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_SanPham frmLookUpSanPham = new frmLookUp_SanPham(String.Format("%{0}%", bteSanPham.Text));
                if (frmLookUpSanPham.ShowDialog() == DialogResult.OK)
                {
                    bteSanPham.Tag = frmLookUpSanPham.SelectedItem;
                    bteSanPham.Text = frmLookUpSanPham.SelectedItem.MaSanPham;
                }                
            }
        }

        private void deLapFrom_DateTimeChanged(object sender, EventArgs e)
        {
            if (deLapFrom.DateTime < Declare.GoliveDate) deLapFrom.DateTime = Declare.GoliveDate;
        }

        private void deNXFrom_DateTimeChanged(object sender, EventArgs e)
        {
            if (deNXFrom.DateTime < Declare.GoliveDate) deNXFrom.DateTime = Declare.GoliveDate;
        }
    }
}