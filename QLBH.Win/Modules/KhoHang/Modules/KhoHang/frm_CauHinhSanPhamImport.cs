using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_CauHinhSanPhamImport : DevExpress.XtraEditors.XtraForm
    {
        public frm_CauHinhSanPhamImport()
        {
            InitializeComponent();
        }

        private void Import(object selectedPath)
        {
            string[] files = Directory.GetFiles(selectedPath.ToString());

            DataSet ds = new DataSet();

            string sql = String.Empty;
            
            frmProgress.Instance.MaxValue = files.Length;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.Description = "Đang load dữ liệu ...";

            foreach (string file in files)
            {
                frmProgress.Instance.Value += 1;

                FileInfo fileInfo = new FileInfo(file);
                using (OleDbConnection oConn = new OleDbConnection())
                {
                    oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;READONLY=TRUE;IMEX=1;HDR=No\"", file);
                    try
                    {
                        oConn.Open();
                    }
                    catch (Exception exception)
                    {
                        Invoke((MethodInvoker)
                               delegate
                               {
                                   txtLog.Text +=
                                       String.Format("File {0} không map được cấu hình sản phẩm\r\n",
                                                     fileInfo.Name);
                                   txtLog.Text += exception.Message;
                                   txtLog.SelectionStart = txtLog.Text.Length;
                                   txtLog.ScrollToCaret();
                               });
                        continue;
                    }
                    sql = "Select * from [Sheet1$]";
                    using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                    {
                        //if(fileInfo.Name == "AMSTBLU0002")
                        //{
                        //    MessageBox.Show("AMSTBLU0002");
                        //}

                        DataTable dataTable = new DataTable(fileInfo.Name.Replace(".xls", ""));
                        ad.Fill(dataTable);

                        sql = String.Format("select sp.idsanpham  from tbl_map_sanpham map, tbl_sanpham sp where map.mamoi = sp.masanpham and mavip = '{0}'", dataTable.TableName);
                        int idSanPham = Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql));

                        if(idSanPham == 0)
                        {
                            Invoke((MethodInvoker)
                                   delegate
                                       {
                                           txtLog.Text +=
                                               String.Format("Mã {0} không map được cấu hình sản phẩm\r\n",
                                                             dataTable.TableName);
                                           txtLog.SelectionStart = txtLog.Text.Length;
                                           txtLog.ScrollToCaret();
                                       });
                            //EventLogProvider.Instance.WriteLog(String.Format("Mã {0} không map được cấu hình sản phẩm", dataTable.TableName), "Import cấu hình sản phẩm");
                            continue;
                        }


                        try
                        {
                            ConnectionUtil.Instance.BeginTransaction();
                            
                            sql = "delete tbl_cauhinh_sanpham where idsanpham={0}";
                            sql = String.Format(sql, idSanPham);
                            SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                if (dataRow[0] == DBNull.Value) continue;

                                sql = "insert into tbl_cauhinh_sanpham (idsanpham, tencauhinh, giatri, sudung) values({0},'{1}','{2}',1)";
                                sql = String.Format(sql, idSanPham, dataRow[0], dataRow[1]);
                                SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);
                            }
                            ConnectionUtil.Instance.CommitTransaction();
                        }
                        catch (Exception exception)
                        {
                            ConnectionUtil.Instance.RollbackTransaction();
                            Invoke((MethodInvoker)
                                   delegate
                                   {
                                       txtLog.Text +=
                                           String.Format("Mã {0} không map được cấu hình sản phẩm\r\n",
                                                         dataTable.TableName);
                                       txtLog.Text += exception.Message;
                                       txtLog.SelectionStart = txtLog.Text.Length;
                                       txtLog.ScrollToCaret();
                                   });
                            //EventLogProvider.Instance.WriteLog(String.Format("Mã {0} không map được cấu hình sản phẩm", dataTable.TableName), "Import cấu hình sản phẩm");
                        }
                    
                    }
                }
            }

            frmProgress.Instance.Description = "Đã hoàn thành.";
            frmProgress.Instance.IsCompleted = true;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtDir.Text))
            {
                frmProgress.Instance.Text = "Import cấu hình sản phẩm";
                frmProgress.Instance.DoWork(Import, txtDir.Text);
            }
        }
    }
}