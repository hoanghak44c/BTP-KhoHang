using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachDeNghiNhanDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        private int idChungTu = 0;
        public int SoChungTu;
        public string SoPX;
        public string NguoiXuat;
        public string PhieuXuat;
        private string User;
        public DateTime NgayLap;
        public string DienGiai;
        public DateTime ThoiGian;
        public int TrangThai;
        public string SoCTG;
        private string IdKho;
        public frm_DanhSachDeNghiNhanDieuChuyen()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        public void Delete()
        {
            DeNghiNhanDieuChuyenBussiness DeNghiNhanDieuChuyenBusiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle < 0) return;
            DeNghiNhanDieuChuyenBusiness = new DeNghiNhanDieuChuyenBussiness((ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            DeNghiNhanDieuChuyenBusiness.DeleteChungTu();
        }
        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if(grvDanhSach.FocusedRowHandle <0) return;
            ChungTuDeNghiNhanDieuChuyenInfor info = ((ChungTuDeNghiNhanDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiNhanDieuChuyen frm = new frm_PhieuDeNghiNhanDieuChuyen(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.SoChungTuGoc);
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            }
        }
        private void LoadTrangThai()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            lst.Add(new TrangThaiBH { Id = 2, Name = "Chưa nhận" });
            lst.Add(new TrangThaiBH { Id = 3, Name = "Đã nhận" });
            repTrangThai.DataSource = lst;
        }
        private void frm_DanhSachDeNghiNhanDieuChuyen_Load(object sender, EventArgs e)
        {
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            btnMoPhieu.Enabled = false;
            btnXoaPhieu.Enabled = false;
            btnThemPhieu.Text = Resources.btnAdd;
            btnMoPhieu.Text = Resources.btnInfor;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiNhanDieuChuyen frm = new frm_PhieuDeNghiNhanDieuChuyen();
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Delete();
                foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                {
                    IdKho += nguoiDungInfor.IdKho + ",";
                }
                grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //ChungTuDeNghiNhanDieuChuyenInfor info = ((ChungTuDeNghiNhanDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            //PhieuXuat = info.SoChungTu;
            //NgayLap = info.NgayLap;
            //DienGiai = info.GhiChu;
            //idChungTu = info.IdChungTu;
            //SoCTG = info.SoChungTuGoc;
            //TrangThai = info.TrangThai;
            //btnMoPhieu.Enabled = true;
            //btnXoaPhieu.Enabled = false;
            //info.TrangThai != 1;
        }
        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            //if (dgvChiTiet.RowCount > 0)
            //{
            //    frm_PhieuDeNghiNhanDieuChuyen frm = new frm_PhieuDeNghiNhanDieuChuyen(idChungTu, PhieuXuat,
            //                                                                          NgayLap.ToString(), "", TrangThai,SoCTG);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen();
            //    }
            //}
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clTrangThai")
            //{
            //    int trangThai = Convert.ToInt32(e.Value);
            //    e.Value = trangThai == 3 ? "Đã nhận" : "Chờ nhận";
            //    e.FormattingApplied = true;
            //}
            //if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clNgayXuat")
            //{
            //    // Use the default row value when Value property is null.
            //    if ((DateTime)e.Value == DateTime.MinValue)
            //    {
            //        e.Value = "";
            //        e.FormattingApplied = true;
            //    }
            //}
        }

        private void frm_DanhSachDeNghiNhanDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if(grvDanhSach.FocusedRowHandle <0) return;
            ChungTuDeNghiNhanDieuChuyenInfor info = ((ChungTuDeNghiNhanDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiNhanDieuChuyen frm = new frm_PhieuDeNghiNhanDieuChuyen(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.SoChungTuGoc);
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }
    }
}