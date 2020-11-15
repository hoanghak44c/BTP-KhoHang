using System;
using System.Data;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmCapNhatTonDauKy_SanPhamChuaMaVach : Form
    {

        public frmCapNhatTonDauKy_SanPhamChuaMaVach()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }


        private void frmCapNhatTonDauKy_ChiTietHangHoa_Load(object sender, EventArgs e)
        {
            string sql = @"
                        select kh.MaKho,sp.MaSanPham, sp.TenSanPham,dvt.TenDonViTinh DVT,dk.Soluong,nd.TenDangNhap NguoiNhap
                        from tbl_sanpham sp inner join
                        (select * from tbl_hanghoa_dudauky where idsanpham not in
                        (select idsanpham from tbl_hanghoa_chitiet) )dk on sp.idsanpham=dk.idsanpham
                        inner join tbl_dm_nguoidung nd on dk.nguoitao = nd.idnguoidung 
                        inner join tbl_dm_donvitinh dvt on dvt.iddonvitinh = sp.iddonvitinh
                        inner join tbl_dm_kho kh on dk.idkho = kh.idkho where dk.idkho = " + Declare.IdKho;

            DataTable dt = DBTools.getData("Temp", sql).Tables["Temp"];
            dgvList.DataSource = dt;

        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string sql = @"select kh.MaKho,sp.MaSanPham, sp.TenSanPham,dvt.TenDonViTinh DVT,dk.Soluong,nd.TenDangNhap NguoiNhap
                        from tbl_sanpham sp inner join
                        (select * from tbl_hanghoa_dudauky where idsanpham not in
                        (select idsanpham from tbl_hanghoa_chitiet) )dk on sp.idsanpham=dk.idsanpham
                        inner join tbl_dm_nguoidung nd on dk.nguoitao = nd.idnguoidung 
                        inner join tbl_dm_donvitinh dvt on dvt.iddonvitinh = sp.iddonvitinh
                        inner join tbl_dm_kho kh on dk.idkho = kh.idkho where dk.idkho = " + Declare.IdKho;
            if (txtSanPham.Text != "")
                sql += String.Format(" and (sp.MaSanPham like '%{0}%' or sp.TenSanPham like '%{0}%')",txtSanPham.Text);

            if (txtUser.Text != "")
                sql += String.Format(" and nd.TenDangNhap = '{0}'", txtUser.Text);

            DataTable dt = DBTools.getData("Temp", sql).Tables["Temp"];
            dgvList.DataSource = dt;
        }

    }
}