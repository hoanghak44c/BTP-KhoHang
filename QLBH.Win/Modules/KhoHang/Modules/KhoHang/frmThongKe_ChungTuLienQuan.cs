using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmThongKe_ChungTuLienQuan : DevExpress.XtraEditors.XtraForm
    {
        private TonInfoBase khoThongKeHangTonInfo;
        
        private List<KhoThongKeChungTuInfo> lstChungTuLienQuan;

        private bool onStop, isRunning;

        public frmThongKe_ChungTuLienQuan(TonInfoBase khoThongKeHangTonInfo)
        {
            InitializeComponent();
            grcHangTon.ContextMenuStrip = new ContextMenuStrip();
            this.khoThongKeHangTonInfo = khoThongKeHangTonInfo;
            lstChungTuLienQuan = new List<KhoThongKeChungTuInfo>();
            grcHangTon.DataSource = lstChungTuLienQuan;
        }

        private void frmThongKe_TonChiTietMaVach_Load(object sender, EventArgs e)
        {
            grcHangTon.ContextMenuStrip.Items.Add("Export", null, btnExportData_Click);
            grcHangTon.RefreshDataSource();
            grvThongKeHangTon.OptionsView.ShowFooter = true;
            grvThongKeHangTon.Columns["SoLuong"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            foreach (GridColumn column in this.grvThongKeHangTon.Columns)
            {
                column.OptionsColumn.AllowEdit = true;
                column.OptionsColumn.ReadOnly = true;
            }
            var t = new Thread(delegate()
                                      {
                                          frmProgress.Instance.Caption = "Thống kê chứng từ liên quan";
                                          frmProgress.Instance.DoWork(LoadDuLieu);
                                      });
            t.Start();
        }

        void frmThongKe_ChungTuLienQuan_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isRunning)
            {
                if (MessageBox.Show("Chứng từ liên quan vẫn chưa nạp hết, bạn có muốn dừng lại không?", "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                onStop = true;                
            }
        }

        private void LoadDuLieu()
        {
            isRunning = true;
            frmProgress.Instance.MaxValue = 1;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.Caption = Text;
            var minDate = KhoThongKeHangTonDataProvider.Instance.GetMinDate(khoThongKeHangTonInfo).Date;
            var maxDate = KhoThongKeHangTonDataProvider.Instance.GetMaxDate(khoThongKeHangTonInfo).Date;
            var runningDate = maxDate;
            var totalDay = Convert.ToInt32(maxDate.Subtract(minDate).TotalDays);
            frmProgress.Instance.MaxValue = totalDay + 1;
            Thread.CurrentThread.Join(500);
            while (runningDate >= minDate && !onStop)
            {
                var tmpResult = KhoThongKeHangTonDataProvider.Instance.GetListThongKeChungTuLienQuan(
                    
                    khoThongKeHangTonInfo.IdTrungTam, khoThongKeHangTonInfo.IdKho, 
                    
                    khoThongKeHangTonInfo.IdSanPham, runningDate);

                if (tmpResult.Count > 0)
                {
                    lstChungTuLienQuan.AddRange(tmpResult);

                    grcHangTon.RefreshDataSource();

                    frmProgress.Instance.Value += 1;

                    runningDate = runningDate.AddDays(-1);    
                } 
                else
                {
                    var nextDate = KhoThongKeHangTonDataProvider.Instance.GetNextDate(khoThongKeHangTonInfo, runningDate).Date;

                    frmProgress.Instance.Value += Convert.ToInt32(runningDate.Subtract(nextDate).TotalDays);

                    runningDate = nextDate;
                }
            }
            frmProgress.Instance.Description = "Đã xong!";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
            isRunning = false;
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            Common.DevExport2Excel(grvThongKeHangTon);
        }

        private void frmThongKe_ChungTuLienQuan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}