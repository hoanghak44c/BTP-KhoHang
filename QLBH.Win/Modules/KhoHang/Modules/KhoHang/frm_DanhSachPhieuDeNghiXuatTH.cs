using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;

// form frmDanhSachPhieuDeNghiXuatTH
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 20/06/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD form_DanhSachPhieuDeNghiXuatTH
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuDeNghiXuatTH : DevExpress.XtraEditors.XtraForm
    {
        public List<tmp_NhapHang_UserChiTietInfo> liChiTietChungTu = new List<tmp_NhapHang_UserChiTietInfo>();

        public frm_DanhSachPhieuDeNghiXuatTH()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        private void LoadTrangThai()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            repTrangThai.DataSource = lst;
        }

        public void Delete()
        {
            DeNghiXuatTieuHaoBusiness DeNghiXuatTieuHaoBusiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle < 0) return;
            DeNghiXuatTieuHaoBusiness = new DeNghiXuatTieuHaoBusiness((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            DeNghiXuatTieuHaoBusiness.DeleteChungTu();
        }
        #region Event

        private void frm_DanhSachPhieuDeNghiXuatTH_Load(object sender, EventArgs e)
        {
            grcDanhSach.DataSource = DeNghiXuatTieuHaoProvider.GetListDeNghiXuatTieuHao();
            btnMoPhieu.Enabled = false;
            btnXoaPhieu.Enabled = IsSupperUser();
            btnMoPhieu.Text = Resources.btnInfor;
            btnThemPhieu.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        }
        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDeNghiXuatTieuHaoInfor info = ((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiXuatTieuHao frm = new frm_PhieuDeNghiXuatTieuHao(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.GhiChu, info.HoTen, info.IdChiPhi, info.IdPhongBan);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiXuatTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        } 
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiXuatTieuHao frm = new frm_PhieuDeNghiXuatTieuHao();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiXuatTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        } 
        //xóa theo id chung tu
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete();
                grcDanhSach.DataSource = DeNghiXuatTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        } 

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
    {
            //if (e.RowIndex < 0) return;
            //ChungTuDeNghiXuatTieuHaoInfor info = ((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            //PhieuXuat = info.SoChungTu;
            //NgayLap = info.NgayLap;
            //DienGiai = info.GhiChu;
            //TrangThai = info.TrangThai;
            //idChungTu = info.IdChungTu;
            //idChiPhi = info.IdChiPhi;
            //idPhongBan = info.IdPhongBan;
            //NguoiXuat = info.HoTen;
            //btnMoPhieu.Enabled = true;
            //btnXoaPhieu.Enabled = info.TrangThai != 1;
        } 

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            //if (dgvChiTiet.RowCount > 0)
            //{
            //    frm_PhieuDeNghiXuatTieuHao frm = new frm_PhieuDeNghiXuatTieuHao(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.GhiChu, info.HoTen, info.IdChiPhi, info.IdPhongBan);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        grcDanhSach.DataSource = DeNghiXuatTieuHaoProvider.GetListDeNghiXuatTieuHao();
            //    }
            //}
        } 
        //chuyển giá trị cột trạng thái từ kiểu bool sang kiểu string 
        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clTrangThai")
            //{
            //    int trangThai = Convert.ToInt32(e.Value);
            //    e.Value = trangThai == 1 ? "Đã xuất" : "Chưa xuất";
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
        #endregion

        private void frm_DanhSachPhieuDeNghiXuatTH_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDeNghiXuatTieuHaoInfor info = ((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiXuatTieuHao frm = new frm_PhieuDeNghiXuatTieuHao(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.GhiChu, info.HoTen, info.IdChiPhi, info.IdPhongBan);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiXuatTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //ChungTuDeNghiXuatTieuHaoInfor info = ((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = IsSupperUser();
            //info.TrangThai != 1;
        }

        private void frm_DanhSachPhieuDeNghiXuatTH_Activated(object sender, EventArgs e)
        {
            frm_DanhSachPhieuDeNghiXuatTH_Load(sender, e);
        }

    }
}