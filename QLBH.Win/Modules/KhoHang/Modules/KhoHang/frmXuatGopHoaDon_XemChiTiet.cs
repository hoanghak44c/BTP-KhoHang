using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
//using QLBanHang.Class.Objects;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmXuatGopHoaDon_XemChiTiet : Form
    {
        #region "Khai báo biến"


        public int IdPhieuXuat = 0;
        private bool Updating = false;
        private int TyLe = 100;
        #endregion

        #region "Các phương thức khởi tạo"
        public frmXuatGopHoaDon_XemChiTiet()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmXuatGopHoaDon_XemChiTiet(int idPX)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.IdPhieuXuat = idPX;
            this.Text = "Cập nhật phiếu xuất kho.";
        }
        #endregion

        #region "Các phương thức"

 
        private void LoadKhoXuat()
        {
            try
            {
                string str = "Select DISTINCT kh.IdKho, kh.MaKho, kh.TenKho From tbl_DM_Kho kh " +
                      " Inner Join tbl_Kho_NhanVien knv On kh.IdKho = knv.IdKho " +
                      " Inner Join tbl_DM_NguoiDung nd On nd.IdNhanVien = knv.IdNhanVien " +
                      " Where kh.SuDung =1 and nd.IdNguoiDung = " + Declare.UserId + " order by kh.TenKho ASC";

                DataTable dtKho = DBTools.getData("tbl_DM_Kho", str).Tables["tbl_DM_Kho"];
                if (dtKho != null)
                {
                    //this.dtKho.Constraints.Add("fg_Kho", this.dtKho.Columns["IdKho"], true);
                    this.cboKhoXuat.DataSource = dtKho;
                    this.cboKhoXuat.DisplayMember = "TenKho";
                    this.cboKhoXuat.ValueMember = "IdKho";
                    this.cboKhoXuat.SelectedValue = Declare.IdKho;
                }
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


        private void PhieuXuat_HienThi(DataRow row)
        {
            this.txtSoPhieu.Text = row["SoPhieuXuat"].ToString();
            this.mstNgayXuat.Value = (DateTime)row["NgayXuat"];
            this.cboKhoXuat.SelectedValue = Common.IntValue(row["IdKho"].ToString());
            this.txtTongTienHang.Text = Common.Double2Str((double)row["TongTienHang"]);
            this.txtTongTienCK.Text = Common.Double2Str((double)row["TongTienChietKhau"]);
            this.txtTongTienSauCK.Text = Common.Double2Str((double)row["TongTienSauChietKhau"]);
            this.txtTongTienVAT.Text = Common.Double2Str((double)row["TongTienVAT"]);
            this.txtTongTienThanhToan.Text = Common.Double2Str((double)row["TongTienThanhToan"]);
            this.txtTienThucTra.Text = Common.Double2Str((double)row["TienThanhToanThuc"]);
            this.txtTienConNo.Text = Common.Double2Str((double)row["TienConNo"]);
            this.txtGhiChu.Text = row["GhiChu"].ToString();
            this.txtSoOrderKH.Text = row["SoOrderKH"].ToString();
        }

        private void LoadPhieuXuat(int IdPX)
        {
            string str;
            DataTable dt;

            str = "select px.IdPhieuXuat,px.SoPhieuXuat,px.NgayXuat,px.IdKho," +
                         "px.TongTienHang,px.TongTienChietKhau,px.TongTienSauChietKhau,px.TongTienVAT," +
                         "px.TongTienThanhToan,px.IdTienTe,px.TyGia,px.TienThanhToanThuc,px.TienConNo,px.GhiChu,px.TongTien_Chu,px.SoOrderKH,px.NhapHoaDon " +
                  "from tbl_PhieuXuat px " +
                  "where IdPhieuXuat=" + IdPX + "";
            dt = DBTools.getData("Tmp", str).Tables["Tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                this.PhieuXuat_HienThi(dt.Rows[0]);

                str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "SoLuong,DonGia,TyLeChietKhau,TienChietKhau,TyleVAT,TienVAT,ThanhTien,TyLeThuong,ThuongNong,GhiChu,GiaTheoBangGia " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + IdPX + " and IdSanPhamBan is null ";
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                this.dgvSanPhamBan.Rows.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    double tienSauCK = Common.IntValue(dt.Rows[i]["SoLuong"].ToString()) * Common.DoubleValueInt(dt.Rows[i]["DonGia"].ToString())
                                        - Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"].ToString());
                    object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["DonGia"])),
                            Common.Double2Str((double)dt.Rows[i]["TyLeChietKhau"] * TyLe),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"])),
                            Common.Double2Str(tienSauCK),                            
                            Common.Double2Str((double)dt.Rows[i]["TyLeVAT"] * TyLe),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienVAT"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"])),
                            dt.Rows[i]["GhiChu"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienChietKhau"])),
                            Common.Double2Str(tienSauCK),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["TienVAT"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"])),
                            Common.Double2Str((double)dt.Rows[i]["TyLeThuong"]),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThuongNong"])),
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["GiaTheoBangGia"]))
                        };
                    this.dgvSanPhamBan.Rows.Add(arr);
                }

                str = "SELECT IdPhieuXuat,IdChitiet,MaVach,MaSanPham,IdSanPham,TenSanPham,IdDonViTinh,TenDonViTinh," +
                             "IdSanPhamBan,MaSanPhamBan,TenSanPhamBan,SoLuong,ThanhTien " +
                      "FROM vChiTietPhieuXuat " +
                      "WHERE IdPhieuXuat=" + IdPX + " and IdSanPhamBan is not null ";
                dt = DBTools.getData("Tmp", str).Tables["Tmp"];

                this.dgvHangKhuyenMai.Rows.Clear();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    object[] arr ={ 
                            dt.Rows[i]["MaVach"],
                            dt.Rows[i]["IdSanPham"],
                            dt.Rows[i]["MaSanPham"],
                            dt.Rows[i]["TenSanPham"],
                            dt.Rows[i]["IdSanPhamBan"],
                            dt.Rows[i]["TenSanPhamBan"],
                            dt.Rows[i]["TenDonViTinh"],
                            dt.Rows[i]["SoLuong"],
                            Common.Double2Str(Common.DoubleValueInt(dt.Rows[i]["ThanhTien"]))};
                    this.dgvHangKhuyenMai.Rows.Add(arr);
                }

            }
        }

        #endregion

        #region "Các sự kiên"



        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKhoXuat();
                LoadPhieuXuat(this.IdPhieuXuat);

                //Thiet lap trang thai item
                setEDItems(false);
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

        private void frmPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F12 && tsbClose.Enabled)
                    this.tsbClose_Click(sender, e);
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

        private void txtTienVAT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTongTienThanhToan.Text = Common.Double2Str(Common.DoubleValue(this.txtTongTienSauCK.Text.Trim()) + Common.DoubleValue(this.txtTongTienVAT.Text.Trim()));
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


        private void frmPhieuXuat_Resize(object sender, EventArgs e)
        {

            tabInfors.Location = new Point(grSanPhamBan.Location.X + grSanPhamBan.Width + 10, tabInfors.Location.Y);
            grPayments.Location = new Point(grSanPhamBan.Location.X + grSanPhamBan.Width + 10, grPayments.Location.Y);
        }


        #endregion

 
        private void setEDItems(bool status)
        {
            this.mstNgayXuat.Enabled = status;
            this.txtGhiChu.Enabled = status;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            close();
        }
        private void close()
        {
            try
            {
                this.Close();
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

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

    }
}