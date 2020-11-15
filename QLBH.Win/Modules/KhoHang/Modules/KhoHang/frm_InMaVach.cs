using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    public partial class frm_InMaVach : frmBCBase
    {
        Utils ut = new Utils();
        public frm_InMaVach()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            rpt = new rpt_InMaVachSP();
        }

        private void frm_BangGiaHienTai_Load(object sender, EventArgs e)
        {
            string sql = String.Format("Select IdSanPham, 0 ChonIn, MaSanPham, TenSanPham, TenVietTat, DonGiaCoVAT, 0 SoLuong, TrungMaVach from vSanPham where IdTrungTam={0}", Declare.IdTrungTam);
            DataTable dt = DBTools.getData("BangGiaHienTai", sql).Tables["BangGiaHienTai"];
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        object[] arr = { dt.Rows[i]["IdSanPham"], 0, dt.Rows[i]["MaSanPham"], 
            //                            dt.Rows[i]["TenSanPham"], dt.Rows[i]["DonGiaCoVAT"],
            //                            0, dt.Rows[i]["TrungMaVach"]};
            //        this.gv.Rows.Add(arr);
            //    }
            //}
            gv.DataSource = dt;
            LoadComboLoaiSanPham();
        }

        private void LoadComboLoaiSanPham() {
            string sql = "SELECT IdSanPham, TenSanPham FROM tbl_SanPham WHERE IdCha is null and SuDung=1 ORDER BY TenSanPham";
            DataTable dt = DBTools.getData("Temp", sql).Tables["Temp"];
            DataRow dr = dt.NewRow();
            dr["IdSanPham"] = 0;
            dr["TenSanPham"] = String.Empty;
            dt.Rows.InsertAt(dr, 0);
            cboLoaiSP.DisplayMember = "TenSanPham";
            cboLoaiSP.ValueMember = "IdSanPham";
            cboLoaiSP.DataSource = dt;
            cboLoaiSP.Refresh();
        }

        private void sLocSanPham()
        {
            string dk = "and 1=1 ";
            if (!String.IsNullOrEmpty(txtMaSP.Text))
                dk += String.Format("and MaSanPham like '{0}' ", txtMaSP.Text);
            if (!String.IsNullOrEmpty(txtTenSP.Text))
                dk += String.Format("and TenSanPham like N'{0}' ", txtTenSP.Text);
            if (Convert.ToInt32(cboLoaiSP.SelectedValue) != 0)
                dk += String.Format("and IdCha = {0} ", cboLoaiSP.SelectedValue);

            string sql = String.Format("Select IdSanPham, 0 ChonIn, MaSanPham, TenSanPham, TenVietTat, DonGiaCoVAT, 0 SoLuong, TrungMaVach from vSanPham where IdTrungTam={0} ", Declare.IdTrungTam) + dk;

            DataTable dt = DBTools.getData("BangGiaHienTai", sql).Tables["BangGiaHienTai"];
            //gv.Rows.Clear();
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        object[] arr = { dt.Rows[i]["IdSanPham"], 0, dt.Rows[i]["MaSanPham"], 
            //                            dt.Rows[i]["TenSanPham"],dt.Rows[i]["TenVietTat"], 
            //                            dt.Rows[i]["DonGiaCoVAT"], 0, dt.Rows[i]["TrungMaVach"]};
            //        this.gv.Rows.Add(arr);
            //    }
            //}
            gv.DataSource = dt;
            gv.Refresh();
            lbTongSo.Text = String.Format("Tổng số {0} sản phẩm", gv.RowCount);
        }

        private void gv_SelectionChanged(object sender, EventArgs e)
        {
            if (gv.CurrentRow != null)
                lblTenSanPham.Text = gv.CurrentRow.Cells["TenSanPham"].Value.ToString();
        }

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter){
                sLocSanPham();
            }
        }

        private void cmdLoc_Click(object sender, EventArgs e)
        {
            sLocSanPham();
        }

        private void tlsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlsPrint_Click(object sender, EventArgs e)
        {
            //printMaVach();
            try
            {
                ShowReport("Mã vạch sản phẩm");
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void frm_InMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F9 && tlsPrint.Enabled)
                    this.tlsPrint_Click(sender, e);
                else if (e.KeyCode == Keys.F12 && tlsClose.Enabled)
                    this.tlsClose_Click(sender, e);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        protected override object OnSetDataSource()
        {
            //Ghi du lieu can ghi vao bang tbl_Tmp_MaVach
            //this.Cursor = Cursors.WaitCursor;
            //string where = "";
            //bool isPrint = false;
            string sql = "";


            //in bao cao
            sql = "Select * from tbl_Tmp_MaVach";
            DataSet ds = ut.getDataSet(sql, "tbl_Tmp_MaVach");

            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            if (Declare.CHUAN_MAVACH.Equals("Code 128"))
                type = BarcodeLib.TYPE.CODE128;
            else if (Declare.CHUAN_MAVACH.Equals("Code 13"))
                type = BarcodeLib.TYPE.EAN13;

            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            barcode.IncludeLabel = true;
            gv.Sort(gv.Columns["ChonIn"], ListSortDirection.Descending);
            gv.EndEdit();
            foreach (DataGridViewRow row in gv.Rows) {
                int chonIn = Convert.ToInt32(row.Cells["ChonIn"].Value);
                int soluong = Common.IntValue(row.Cells["SoLuong"].Value);
                if (chonIn <= 0) break;
                if (soluong > 0) {
                    int id = Common.IntValue(row.Cells["IdSanPham"].Value);
                    string maSanPham = row.Cells["MaSanPham"].Value.ToString();
                    string tenSanPham = row.Cells["TenSanPham"].Value.ToString();
                    string tenRutGon = row.Cells["TenVietTat"].Value.ToString();
                    double giaban = Common.DoubleValue(row.Cells["GiaBan"].Value);
                    bool trungMaVach = Common.BoolValue(row.Cells["TrungMaVach"].Value);
                    string mavach = "";
                    int nRow = soluong / 5;
                    int nAdd = soluong % 5;
                    int count = 0;
                    for (int i = 1; i <= nRow; i++) {
                        DataRow dr = ds.Tables[0].NewRow();
                        dr["IdSanPham"] = id;
                        dr["MaSanPham"] = maSanPham;
                        dr["TenSanPham"] = tenSanPham;
                        dr["TenVietTat"] = tenRutGon;
                        dr["GiaBan"] = giaban;

                        for (int j = 1; j <= 5; j++) {
                            mavach = trungMaVach ? TaoMaVach(maSanPham, 0) : TaoMaVach(maSanPham, ++count);
                            dr["MaVach" + j] = mavach;
                            Image img = barcode.Encode(type, mavach);
                            dr["Barcode" + j] = Common.imageToByteArray(img);
                        }
                        ds.Tables[0].Rows.Add(dr);
                    }

                    if (nAdd > 0) {
                        DataRow dr = ds.Tables[0].NewRow();
                        dr["IdSanPham"] = id;
                        dr["MaSanPham"] = maSanPham;
                        dr["TenSanPham"] = tenSanPham;
                        dr["TenVietTat"] = tenRutGon;
                        dr["GiaBan"] = giaban;

                        for (int j = 1; j <= nAdd; j++) {
                            mavach = trungMaVach ? TaoMaVach(maSanPham, 0) : TaoMaVach(maSanPham, ++count);

                            dr["MaVach" + j] = mavach;
                            Image img = barcode.Encode(type, mavach);
                            dr["Barcode" + j] = Common.imageToByteArray(img);
                        }
                        ds.Tables[0].Rows.Add(dr);
                    }
                }
            }

            return ds;
        }
        //private void printMaVach()
        protected override void OnLoadReport()
        {
            try {
                base.SetDataSource();
                //Create a report object
                //and set its data source with the DataSet
                //rpt_InMaVachSanPham rpt = new rpt_InMaVachSanPham();
                //rpt.SetDataSource(ds);
                //frm_rpt frm = new frm_rpt(rpt);
                //frm.Show();

                //xoa du lieu
                //sql = "Delete From tbl_Tmp_MaVach";
                //DBTools.ExecuteQuery(sql, CommandType.Text);
                //this.Cursor = Cursors.Default;
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private string TaoMaVach(string strCode, int stt)
        {
            DateTime d = DateTime.Now;
            string sday = "";
            //sday += (d.Day < 10) ? ("0" + d.Day) : (d.Day + "");
            //sday += (d.Month < 10) ? ("0" + d.Month) : (d.Month + "");
            //sday += d.Year.ToString().Substring(2);

            string rs = strCode + sday;

            if (stt != 0)
            {
                string serie = stt + "";
                string tmp = serie;
                for (int i = 0; i < (Declare.MAXMAVACH_SANPHAM - tmp.Length); i++)
                    serie = "0" + serie;
                rs += serie;
            }
            return rs;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gv.Rows)
            {
                row.Cells["ChonIn"].Value = chkAll.Checked;
            }
            gv.Refresh();
        }

    }
}