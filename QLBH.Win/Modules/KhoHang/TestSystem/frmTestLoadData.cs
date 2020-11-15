using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBH.Core.Data;
using QLBH.Core.Form;

namespace QLBanHang.TestSystem
{
    public partial class frmTestLoadData : DevExpress.XtraEditors.XtraForm
    {
        private delegate void VoidDelegate();
        private delegate int GetIntValueDelegate();
        private delegate void SetIntValueDelegate(int value);
        private readonly VoidDelegate gridUpdateDelegate;
        private readonly SetIntValueDelegate setMaxValueDelegate;
        private readonly SetIntValueDelegate setValueDelegate;
        private readonly GetIntValueDelegate getValueDelegate;
        private int rowNums;
        private List<int> listData;
        
        public frmTestLoadData()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmTestLoadData_Load);
            gridView1.TopRowChanged += new EventHandler(gridView1_TopRowChanged);
            gridUpdateDelegate = new VoidDelegate(GridUpdate);
            setMaxValueDelegate = new SetIntValueDelegate(setMaxValue);
            this.setValueDelegate = new SetIntValueDelegate(setValue);
            this.getValueDelegate = new GetIntValueDelegate(getValue);
        }

        void frmTestLoadData_Load(object sender, EventArgs e)
        {
            listData = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                listData.Add(i);
            }

            grcTonKho.DataSource = listData;
            
        }

        void gridView1_TopRowChanged(object sender, EventArgs e)
        {
            GridViewInfo info = gridView1.GetViewInfo() as GridViewInfo;

            rowNums = info.RowsInfo.Count;
            
            Debug.Print(gridView1.TopRowIndex.ToString());

            var workerThread = new Thread(FetchData);
            workerThread.Start(gridView1.TopRowIndex);
        }

        void setValue(int value)
        {
            pbStatus.EditValue = value;
        }

        void setMaxValue(int value)
        {
            pbStatus.Properties.Maximum = value;
        }

        int getValue()
        {
            return Convert.ToInt32(pbStatus.EditValue);
        }

        void GridUpdate()
        {
            grcTonKho.RefreshDataSource();
        }

        void FetchData(object topIndex)
        {
            int max = 0, step = 100;

            if (Convert.ToInt32(topIndex) + rowNums + step/2 > listData.Count)
                max = listData.Count + step;
            else return;
            
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
            for (int i = listData.Count + 1; i <= max; i++)
            {
                listData.Add(i);
                Invoke((MethodInvoker)delegate()
                {
                    pbStatus.EditValue = Convert.ToInt32(pbStatus.EditValue) + 1;
                });                
            }
            Invoke((MethodInvoker)
                   delegate()
                   {
                       grcTonKho.RefreshDataSource();
                   });
            Invoke((MethodInvoker)
                   delegate()
                   {
                       pbStatus.EditValue = 0;
                   });
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //var workerThread = new Thread(FetchData);
            //workerThread.Start();
        }

        private void gridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            //e.
        }

    }

    [TestClass]
    public class frmTestLoadDataUnit
    {
        [TestMethod]
        public void TestLoadData()
        {
            ConnectionUtil.Instance.IsUAT = 1;
            frmTestLoadData frm = new frmTestLoadData();
            frm.ShowDialog();
        }
    }
    
}