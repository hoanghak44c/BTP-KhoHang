using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachDotKiemKe : DevExpress.XtraEditors.XtraForm
    {
        private List<DotKiemKeInfor> lstSource;

        public frm_DanhSachDotKiemKe()
        {
            InitializeComponent();
            
            if (!Declare.IS_SUPPER_USER && Declare.UserName != "anhdtn1174" && Declare.UserName != "superuser" &&

                ((NguoiDungInfor)Declare.USER_INFOR).NhomNguoiDung != "KTK")

                tsbImport.Visible = false;

            lstSource = new List<DotKiemKeInfor>();
            grcList.DataSource = lstSource;
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadKyKiemKe()
        {
            List<LookUp> lst = new List<LookUp>();

            lst.Add(new LookUp { OID = 1, Name = "Tháng 1" });
            lst.Add(new LookUp { OID = 2, Name = "Tháng 2" });
            lst.Add(new LookUp { OID = 3, Name = "Tháng 3" });
            lst.Add(new LookUp { OID = 4, Name = "Tháng 4" });
            lst.Add(new LookUp { OID = 5, Name = "Tháng 5" });
            lst.Add(new LookUp { OID = 6, Name = "Tháng 6" });
            lst.Add(new LookUp { OID = 7, Name = "Tháng 7" });
            lst.Add(new LookUp { OID = 8, Name = "Tháng 8" });
            lst.Add(new LookUp { OID = 9, Name = "Tháng 9" });
            lst.Add(new LookUp { OID = 10, Name = "Tháng 10" });
            lst.Add(new LookUp { OID = 11, Name = "Tháng 11" });
            lst.Add(new LookUp { OID = 12, Name = "Tháng 12" });
            repKyKiemKe.DataSource = lst;
        }

        private void LoadDuLieu()
        {
            try
            {
                frmProgress.Instance.Caption = this.Text;
                frmProgress.Instance.Description = "Đang nạp dữ liệu ...";
                frmProgress.Instance.MaxValue = 100;
                
                Thread.CurrentThread.Join(500);

                DateTime sysDate = CommonProvider.Instance.GetSysDate();

                var kyKiemKe = txtKyKiemKe.Text;
                var nam = txtNam.Text;
                var maDotKiemKe = txtMaDotKiemKe.Text;


                if(InvokeRequired)
                {
                    Invoke((MethodInvoker)
                           delegate
                               {
                                   if (String.IsNullOrEmpty(txtKyKiemKe.Text))
                                       txtKyKiemKe.Text = sysDate.Month.ToString();
                                   if (String.IsNullOrEmpty(txtNam.Text))
                                       txtNam.Text = sysDate.Year.ToString();
                                   if (String.IsNullOrEmpty(txtMaDotKiemKe.Text))
                                       txtMaDotKiemKe.Text = "%%";

                                   kyKiemKe = txtKyKiemKe.Text;
                                   nam = txtNam.Text;
                                   maDotKiemKe = txtMaDotKiemKe.Text;

                               });
                } 
                else
                {
                    if (String.IsNullOrEmpty(txtKyKiemKe.Text))
                        txtKyKiemKe.Text = sysDate.Month.ToString();
                    if (String.IsNullOrEmpty(txtNam.Text))
                        txtNam.Text = sysDate.Year.ToString();
                    if (String.IsNullOrEmpty(txtMaDotKiemKe.Text))
                        txtMaDotKiemKe.Text = "%%";

                    kyKiemKe = txtKyKiemKe.Text;
                    nam = txtNam.Text;
                    maDotKiemKe = txtMaDotKiemKe.Text;

                }
                
                frmProgress.Instance.Value = 50;
                Thread.CurrentThread.Join(500);

                lstSource.Clear();
                lstSource.AddRange(DotKiemKeDataProvider.Instance.GetListAll(
                    Convert.ToInt32(kyKiemKe),
                    Convert.ToInt32(nam),
                    maDotKiemKe));

                grcList.RefreshDataSource();

                frmProgress.Instance.Description = "Đã xong!";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
            }
            catch (Exception ex)
            {
                frmProgress.Instance.Description = "Không thành công!";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                if (ex is ArgumentException || ex is FormatException || ex is OverflowException)
                    MessageBox.Show("Tham số nhập không đúng định dạng");
                else
                    MessageBox.Show(ex.Message);
                frmProgress.Instance.IsCompleted = true;
            }
        }

        private void frm_DanhSachDotKiemKe_Load(object sender, EventArgs e)
        {
            LoadKyKiemKe();

            frmProgress.Instance.DoWork(LoadDuLieu);
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!Declare.IS_SUPPER_USER && Declare.UserName != "anhdtn1174" && Declare.UserName != "superuser" &&

                ((NguoiDungInfor)Declare.USER_INFOR).NhomNguoiDung != "KTK") return;

            var frm = new frm_ChiTietTongHopKiemKe(null);

            if (frm.ShowDialog() == DialogResult.OK) frmProgress.Instance.DoWork(LoadDuLieu); 
        }

        private void grcList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var info = (DotKiemKeInfor)grvList.GetFocusedRow();

                var frm = new frm_ChiTietTongHopKiemKe(info);

                if (frm.ShowDialog() == DialogResult.OK) frmProgress.Instance.DoWork(LoadDuLieu); 

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

        private void tsbImport_Click(object sender, EventArgs e)
        {
            if (!Declare.IS_SUPPER_USER && Declare.UserName != "anhdtn1174" && Declare.UserName != "superuser" &&

                ((NguoiDungInfor)Declare.USER_INFOR).NhomNguoiDung != "KTK")
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!");

                return;
            }
            openFileDialog1.FileName = String.Empty;

            openFileDialog1.Filter = "Excell Files(*.xls, *.xlsx)|*.xls;*.xlsx";

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            frmProgress.Instance.DoWork(
                delegate
                    {
                        try
                        {
                            frmProgress.Instance.Text = this.Text;
                            frmProgress.Instance.Description = "Đang nạp dữ liệu ....";
                            frmProgress.Instance.MaxValue = 100;

                            using (var oConn = new OleDbConnection())
                            {
                                var dsDotKiemKe = new DataSet();
                                oConn.ConnectionString =
                                    String.Format(
                                        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"",
                                        openFileDialog1.FileName);
                                oConn.Open();

                                string sql =
                                    "Select [Đợt kiểm kê] as MaDotKiemKe, [Trung tâm] as MaTrungTam, [Ngành] as MaNganh from [Import$]";

                                using (var ad = new OleDbDataAdapter(sql, oConn))
                                {
                                    ad.Fill(dsDotKiemKe, "DsDotKiemKe");
                                    
                                    frmProgress.Instance.Description = "Đang kiểm tra dữ liệu ....";
                                    frmProgress.Instance.MaxValue = dsDotKiemKe.Tables["DsDotKiemKe"].Rows.Count;

                                    foreach (
                                        DataRow dataRow in
                                            dsDotKiemKe.Tables["DsDotKiemKe"].Rows)
                                    {
                                        string sTmp = Convert.ToString(dataRow["MaDotKiemKe"]);
                                        if (sTmp.Length > 100)
                                            throw new ManagedException(
                                                String.Format(
                                                    "Mã đợt kiểm kê {0} vượt quá 100 ký tự!",
                                                    sTmp));
                                        
                                        if (sTmp.Contains("'"))
                                            throw new ManagedException(
                                                String.Format(
                                                    "Mã đợt kiểm kê {0} chứa ký tự đặc biệt",
                                                    sTmp));
                                        
                                        if(!DotKiemKeDataProvider.Instance.MaDotKiemKeUnique(sTmp))
                                            throw new ManagedException(
                                                String.Format(
                                                    "Mã đợt kiểm kê {0} không duy nhất",
                                                    sTmp));

                                        sTmp = Convert.ToString(dataRow["MaTrungTam"]);
                                        if (DMTrungTamDataProvider.GetTrungTamByMa(sTmp) == null)
                                            throw new ManagedException(
                                                String.Format("Mã trung tâm {0} không tồn tại",
                                                              sTmp));

                                        sTmp = Convert.ToString(dataRow["MaNganh"]);
                                        if (
                                            DmNganhDataProvider.Instance.GetFullInfoByKey(sTmp) ==
                                            null)
                                            throw new ManagedException(
                                                String.Format("Mã ngành {0} không tồn tại", sTmp));

                                        frmProgress.Instance.Value += 1;
                                    }

                                    frmProgress.Instance.Description = "Đang cập nhật dữ liệu ....";
                                    frmProgress.Instance.Value = 0;
                                    frmProgress.Instance.MaxValue = dsDotKiemKe.Tables["DsDotKiemKe"].Rows.Count;

                                    foreach (
                                        DataRow dataRow in
                                            dsDotKiemKe.Tables["DsDotKiemKe"].Rows)
                                    {
                                        DotKiemKeDataProvider.Instance.Insert(
                                            new DotKiemKeInfor
                                                {
                                                    MaDotKiemKe =
                                                        Convert.ToString(dataRow["MaDotKiemKe"]),
                                                    NguoiTao = Declare.UserName,
                                                    TrungTam =
                                                        Convert.ToString(dataRow["MaTrungTam"]),
                                                    Nganh = Convert.ToString(dataRow["MaNganh"]),
                                                    TenMayTao = Dns.GetHostName()
                                                });

                                        frmProgress.Instance.Value += 1;
                                    }

                                    frmProgress.Instance.Description = "Đã cập nhật thành công";
                                    Thread.CurrentThread.Join(2000);

                                    frmProgress.Instance.Value = 0;
                                    LoadDuLieu();

                                }
                            }
                        }
                        catch (ManagedException ex)
                        {
                            frmProgress.Instance.Description = "Không thành công!";
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                            MessageBox.Show(ex.Message);
                            frmProgress.Instance.IsCompleted = true;
                        }
                        catch(Exception ex)
                        {
                            frmProgress.Instance.Description = "Không thành công!";
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
#if DEBUG
                            MessageBox.Show(ex.ToString());
#else
                            MessageBox.Show(ex.Message);
#endif
                            frmProgress.Instance.IsCompleted = true;
                        }
                    });
        }

        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            frmProgress.Instance.DoWork(LoadDuLieu);
        }
    }
}