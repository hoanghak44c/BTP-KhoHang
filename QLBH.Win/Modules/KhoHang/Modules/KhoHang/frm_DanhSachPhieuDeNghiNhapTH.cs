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
    public partial class frm_DanhSachPhieuDeNghiNhapTH : DevExpress.XtraEditors.XtraForm
    {
        public List<tmp_NhapHang_UserChiTietInfo> liChiTietChungTu = new List<tmp_NhapHang_UserChiTietInfo>();

        public frm_DanhSachPhieuDeNghiNhapTH()
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
            lst.Add(new TrangThaiBH { Id = 2, Name = "Chưa nhập" });
            lst.Add(new TrangThaiBH { Id = 3, Name = "Đã nhập" });
            repTrangThai.DataSource = lst;
        }

        public void Delete()
        {
            DeNghiXuatTieuHaoNewBusiness DeNghiXuatTieuHaoBusiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle < 0) return;
            DeNghiXuatTieuHaoBusiness = new DeNghiXuatTieuHaoNewBusiness((ChungTuDeNghiXuatTieuHaoInfornew)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            DeNghiXuatTieuHaoBusiness.DeleteChungTu();
        }
        #region Event

        //nếu click dòng mà có cột trạng thái là đã duyệt thì ẩn các nút trên form Phiếu đề nghị
        //còn nếu click dòng mà có cột trạng thái là chưa duyệt thì để nguyên các nút trên form phiếu đề nghị
        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDeNghiXuatTieuHaoInfornew info = ((ChungTuDeNghiXuatTieuHaoInfornew)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiNhapTieuHao frm = new frm_PhieuDeNghiNhapTieuHao(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.GhiChu, info.HoTen,
                info.TenTrungTam, info.TenKho, info.IdTrungTam, info.IdKho, info.IdNhanVien, info.LoaiChungTu, info.SoChungTuGoc, info.IdNguoiQuanLy, info.NguoiQuanLy);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiNhapTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        } 

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiNhapTieuHao frm = new frm_PhieuDeNghiNhapTieuHao();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiNhapTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        } 
        //xóa theo id chung tu
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            //ActivatedFlag = true;
            //if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    Delete();
            //    grcDanhSach.DataSource = DeNghiXuatTieuHaoProvidernew.GetListDeNghiXuatTieuHao();
            //    grcDanhSach.RefreshDataSource();
            //    ActivatedFlag = false;
            //}
        } 

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDeNghiXuatTieuHaoInfornew info = ((ChungTuDeNghiXuatTieuHaoInfornew)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiNhapTieuHao frm = new frm_PhieuDeNghiNhapTieuHao(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.GhiChu, info.HoTen, info.TenTrungTam,
                info.TenKho, info.IdTrungTam, info.IdKho, info.IdNhanVien, info.LoaiChungTu, info.SoChungTuGoc, info.IdNguoiQuanLy,info.NguoiQuanLy);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiNhapTieuHaoProvider.GetListDeNghiXuatTieuHao();
            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //ChungTuDeNghiXuatTieuHaoInfor info = ((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            btnMoPhieu.Enabled = true;
            //btnXoaPhieu.Enabled = IsSupperUser();
            //info.TrangThai != 1;
        }
        private bool ActivatedFlag = false;
        private void frm_DanhSachPhieuDeNghiXuatTH_Activated(object sender, EventArgs e)
        {
            if (!ActivatedFlag)
                frm_DanhSachPhieuDeNghiNhapTH_Load(sender, e);
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void frm_DanhSachPhieuDeNghiNhapTH_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void frm_DanhSachPhieuDeNghiNhapTH_Load(object sender, EventArgs e)
        {
            grcDanhSach.DataSource = DeNghiNhapTieuHaoProvider.GetListDeNghiXuatTieuHao();
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = IsSupperUser();
            btnMoPhieu.Text = Resources.btnInfor;
            btnThemPhieu.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        }
    }
}