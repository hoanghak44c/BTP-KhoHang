using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using System.Data.SqlTypes;
using CrystalDecisions.Shared;
//using QLBanHang.Class.Objects;
using QLBanHang.Modules.DanhMuc;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmPhieuXuat_ChonKhuyenMai : Form
    {
        private int IdSanPhamBan = 0;
        public int IdKhuyenMai = 0;
        public DataRow[] rowKM;
        private DataTable dtKM;
        public frmPhieuXuat_ChonKhuyenMai()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmPhieuXuat_ChonKhuyenMai(int sanphamban)
        {
            InitializeComponent();
            this.IdSanPhamBan = sanphamban;
            Common.LoadStyle(this);
        }

        public frmPhieuXuat_ChonKhuyenMai(DataRow[] rowKM)
        {
            InitializeComponent();
            this.rowKM = rowKM;
            Common.LoadStyle(this);
        }
        public frmPhieuXuat_ChonKhuyenMai(DataTable dt)
        {
            InitializeComponent();
            this.dtKM = dt;
            Common.LoadStyle(this);
        }
        private void frmPhieuXuat_LuaChonIn_Load(object sender, EventArgs e)
        {
            LoadKhuyenMai();
            LoadChiTietKhuyenMai();
            gvKM.Focus();
            gvKM.Rows[0].Selected = true;
            gvKM.Rows[0].Cells["MaVach"].Selected = true;
            gvKM.CurrentCell = gvKM.Rows[0].Cells["MaVach"];
            //gvKM.BeginEdit(true);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadKhuyenMai()
        {
            //string str = "Select tkm.IdKhuyenMai, tkm.SoKhuyenMai + '[' + case when tkm.GhiChu is null then '' else tkm.GhiChu end + ']' KhuyenMai " +
            //      "From tbl_KhuyenMai tkm Where tkm.IdKhuyenMai in (select IdKhuyenMai from vKhuyenMai vkm " +
            //      " Where vkm.IdSanPhamBan=" + IdSanPhamBan + " and vkm.IdTrungTam = " + Declare.IdTrungTam +
            //            " and IdSanPhamBan not in (select IdSanPhamBan from vBangGia_KhuyenMai where IdKho=" + Declare.IdKho + ") " +
            //      " Union all " +
            //      " select IdKhuyenMai from vBangGia_KhuyenMai where IdSanPhamBan =  " + IdSanPhamBan + " and IdKho = " + Declare.IdKho + ")";
            //DataTable dt = DBTools.getData("KM", str).Tables["KM"];
            //if (dt != null)
            //{
            //    lstKhuyenMai.DataSource = dt;
            //    lstKhuyenMai.DisplayMember = "KhuyenMai";
            //    lstKhuyenMai.ValueMember = "IdKhuyenMai";
            //    lstKhuyenMai.SelectedIndex = 0;
            //    IdKhuyenMai = (int)lstKhuyenMai.SelectedValue;
            //}
            //SqlCommand sqlcmd = new SqlCommand();
            //sqlcmd.CommandType = CommandType.StoredProcedure;
            //sqlcmd.CommandText = "sp_Nap_KhuyenMai_Header";
            //sqlcmd.Parameters.Clear();
            //sqlcmd.Parameters.AddWithValue("@IdTrungTam", Declare.IdTrungTam);
            //sqlcmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
            //sqlcmd.Parameters.AddWithValue("@IdSanPhamBan", IdSanPhamBan);
            //DataTable dt = DBTools.getData(sqlcmd, "tmp").Tables["tmp"];
            if (dtKM != null)
            {
                lstKhuyenMai.DataSource = dtKM;
                lstKhuyenMai.DisplayMember = "KhuyenMai";
                lstKhuyenMai.ValueMember = "IdKhuyenMai";
                lstKhuyenMai.SelectedIndex = 0;
                IdKhuyenMai = int.Parse(lstKhuyenMai.SelectedValue.ToString());
            }
        }

        private void LoadChiTietKhuyenMai()
        {
            try
            {


                //string str = "Select IdSanPham,'' MaVach, MaSanPham, TenSanPham, TenDonViTinh, SoLuong, SoTien " +
                //      " From vKhuyenMai " +
                //      " Where IdSanPhamBan = " + IdSanPhamBan + " and IdKhuyenMai=" + IdKhuyenMai +
                //      " and IdTrungTam = " + Declare.IdTrungTam + " and IdSanPhamBan not in (select IdSanPhamBan from vBangGia_KhuyenMai where IdKho=" + Declare.IdKho + ") " +
                //      " Union all " +
                //      " Select IdSanPham,'' MaVach, MaSanPham, TenSanPham, TenDonViTinh, SoLuong, SoTien " +
                //      " From vBangGia_KhuyenMai " +
                //      " Where IdSanPhamBan = " + IdSanPhamBan + " and IdKhuyenMai=" + IdKhuyenMai +
                //      " and IdKho = " + Declare.IdKho;
                //DataTable dt = DBTools.getData("KM", str).Tables["KM"];
                //if (dt != null)
                //{
                //    gvKM.DataSource = dt;
                //    gvKM.Refresh();
                //}
                IdKhuyenMai = int.Parse(this.lstKhuyenMai.SelectedValue.ToString());
                string str = String.Format(@"Select sp.IdSanPham,'' MaVach, sp.MaSanPham, sp.TenSanPham, TenDonViTinh, kmct.SoLuong, kmct.SoTien 
                                From tbl_SanPham sp Inner Join tbl_KhuyenMai_ChiTiet kmct On sp.IdSanPham = kmct.IdSanPham
	                                Inner Join tbl_KhuyenMai km On km.IdKhuyenMai = kmct.IdKhuyenMai and km.IdKhuyenMai={0}
	                                Inner Join tbl_DM_DonViTinh dvt On dvt.IdDonViTinh = sp.IdDonViTinh", IdKhuyenMai);
                DataTable dt = DBTools.getData("KM", str).Tables["KM"];
                if (dt != null)
                {
                    gvKM.DataSource = dt;
                    gvKM.Refresh();
                }
            }
            catch (Exception ex) { };
        }

        private void lstKhuyenMai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChiTietKhuyenMai();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in gvKM.Rows)
            //{
            //    if (row.Cells["MaVach"].Value == null || row.Cells["MaVach"].Value.ToString().Trim().Length == 0)
            //    {
            //        MessageBox.Show("Phải nhập mã vạch cho sản phẩm khuyến mại!");
            //        row.Cells["MaVach"].Selected = true;
            //        return;
            //    }
            //}
            this.IdKhuyenMai = int.Parse(lstKhuyenMai.SelectedValue.ToString());
            this.Close();
        }
        private void gv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Utils ut = new Utils();
            DataGridViewRow r = gvKM.Rows[e.RowIndex];

            if (e.ColumnIndex == 1 && r.Cells["MaVach"].Value != null)//cot ma vach
            {
                string code = r.Cells["MaVach"].Value.ToString();
                string maSP = r.Cells["MaSanPham"].Value.ToString();
                if (!ut.isStringNotEmpty(code)) return;

                string sql = string.Format(@"SELECT IdChiTiet FROM tbl_HangHoa_Chitiet   
                            WHERE tbl_HangHoa_Chitiet.MaVach=N'{0}'", code);
                if (ut.fGetID_sql(sql) == 0)
                {
                    frm_Chon_SanPham_MaVach frm = new frm_Chon_SanPham_MaVach(r.Cells["IdSanPham"], r.Cells["MaVach"], r.Cells["TenSanPham"], Declare.IdKho, true, false);
                    frm.ShowDialog();
                    //return;
                }
                code = r.Cells["MaVach"].Value.ToString();
                //Kiem tra trang thai san pham
                string str = String.Format("Select IdSanPham From tbl_HangHoa_ChiTiet Where MaVach = '{0}' and IdKho = {1} and SoLuong > 0 and IdSanPham = (Select IdSanPham From tbl_SanPham Where MaSanPham = '{2}')",
                                            code, Declare.IdKho, maSP);

                if (DBTools.getValue(str).Equals(""))
                {
                    MessageBox.Show("Mã vạch không đúng hoặc sản phẩm khuyến mại này đã hết, chọn sản phẩm khác");
                    r.Cells["MaVach"].Value = "";
                    r.Selected = true;
                    r.Cells["MaVach"].Selected = true;
                    gvKM.CurrentCell = r.Cells["MaVach"];
                    return;
                }
                if (gvKM.RowCount > e.RowIndex + 1)
                {
                    try
                    {
                        gvKM.Rows[e.RowIndex + 1].Selected = true;
                        gvKM.Rows[e.RowIndex + 1].Cells["MaVach"].Selected = true;
                        gvKM.CurrentCell = gvKM.Rows[e.RowIndex + 1].Cells["MaVach"];
                    }
                    catch (Exception ex) { }
                }
            }
        }
        public List<STKhuyenMai> getMaVachKM()
        {
            List<STKhuyenMai> lst = new List<STKhuyenMai>();
            foreach (DataGridViewRow row in gvKM.Rows)
            {
                STKhuyenMai km;
                string mavach = "";
                int idSanPham;
                string maSanPham;
                string tenSanPham;
                string donViTinh;
                int soLuong;
                double soTien;
                if (row.Cells["MaVach"].Value != null)
                {
                    mavach = row.Cells["MaVach"].Value.ToString();
                    if (mavach != "")
                    {
                        idSanPham = Common.IntValue(row.Cells["IdSanPham"].Value);
                        maSanPham = row.Cells["MaSanPham"].Value.ToString();
                        tenSanPham = row.Cells["TenSanPham"].Value.ToString();
                        donViTinh = row.Cells["DVT"].Value.ToString();
                        soLuong = Common.IntValue(row.Cells["colSoLuong"].Value);
                        soTien = Common.DoubleValueInt(row.Cells["colTienKM"].Value);
                        lst.Add(new STKhuyenMai(mavach,idSanPham,maSanPham,tenSanPham,donViTinh,soLuong,soTien));
                    }
                }
            }
            return lst;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.IdKhuyenMai = 0;
            this.Close();
        }
    }
}