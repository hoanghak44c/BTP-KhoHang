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
using QLBH.Common.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachDeNghiNhanDieuChuyenNew : DevExpress.XtraEditors.XtraForm
    {
        private string IdKho;
        private int idChungTu = 0;
        public int SoChungTu;
        public string SoPX;
        public string NguoiLap;
        public string PhieuXuat;
        public DateTime NgayLap;
        public string DienGiai;
        public DateTime ThoiGian;
        public int TrangThai;
        public string SoCTG;
        public string TenKho;
        public int IdKhoDieuChuyen;
        //Downline
        //danh sách hiện ra cả 3 loại chứng từ : Đề nghị nhận điều chuyển, nhận điều chuyển, đề nghị xuất điều chuyển tương ứng với trạng thái chờ nhân, đã nhận
        //khi click vào phiếu đề nghị xuất điều chuyển sẽ hiển thị ra form phiếu đề nghị nhận điều chuyển , load ra luôn số chứng từ gốc 
        //khi click vào phiếu đề nghị nhân điều chuyển sẽ hiển thị ra form phiếu đề nghị nhận điều chuyển như bình thường
        //khi click vào phiếu nhận điều chuyển sẽ hiển thị ra form phiếu đề nghị nhận điều chuyển
        public frm_DanhSachDeNghiNhanDieuChuyenNew()
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
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuNhapDieuChuyenInfor info = ((ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            if (info.LoaiChungTu == 14 || info.LoaiChungTu == 21)
            {
                PhieuXuat = info.SoChungTu;
                NgayLap = info.NgayLap;
                DienGiai = info.GhiChu;
                idChungTu = info.IdChungTu;
                SoCTG = info.SoChungTuGoc;
                TrangThai = info.TrangThai;
                NguoiLap = info.NguoiLap;
                TenKho = info.TenKho;
                //IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            }
            else
            {
                idChungTu = 0;
                NgayLap = CommonProvider.Instance.GetSysDate();
                DienGiai = info.GhiChu;
                SoCTG = info.SoChungTu;
                TrangThai = 0;
                NguoiLap = Declare.TenNhanVien;
                TenKho = info.TenKho;
                IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            }

            frm_PhieuDeNghiNhanDieuChuyenNew frm = new frm_PhieuDeNghiNhanDieuChuyenNew(info);
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
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chờ xác nhận(chờ kế toán kho nhận xác nhận)" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất (thủ kho đã xuất kho, chờ kho nhận làm thủ tục nhận.)" });
            lst.Add(new TrangThaiBH { Id = 2, Name = "Chờ nhận hàng (chờ thủ kho nhận nhập hàng vào kho)" });
            lst.Add(new TrangThaiBH { Id = 3, Name = "Đã nhận (kết thúc.)" });
            lst.Add(new TrangThaiBH { Id = 4, Name = "Chờ xuất serial (chờ thủ kho xuất bắn serial xuất)" });
            repTT.DataSource = lst;

        }
        private void frm_DanhSachDeNghiNhanDieuChuyen_Load(object sender, EventArgs e)
        {
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
            btnThemPhieu.Enabled = false;
            btnThemPhieu.Text = Resources.btnAdd;
            btnMoPhieu.Text = Resources.btnInfor;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
            clsUtils.NullColumnDateTimeGrid(repNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            //frm_PhieuDeNghiNhanDieuChuyenNew frm = new frm_PhieuDeNghiNhanDieuChuyenNew();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen();
            //}
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
            //nếu loại chứng từ là đề nghị nhận thì ...
            //nếu loại chứng từ là đề nghị xuất thì...
            //if (e.RowIndex < 0) return;
            //ChungTuDeNghiNhanDieuChuyenInfor info = ((ChungTuDeNghiNhanDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            //if(info.LoaiChungTu == 14 || info.LoaiChungTu == 21)
            //{
            //    PhieuXuat = info.SoChungTu;
            //    NgayLap = info.NgayLap;
            //    DienGiai = info.GhiChu;
            //    idChungTu = info.IdChungTu;
            //    SoCTG = info.SoChungTuGoc;
            //    TrangThai = info.TrangThai;
            //    btnMoPhieu.Enabled = true;
            //    btnXoaPhieu.Enabled = false;
            //    //info.TrangThai != 1;
            //}
            //else
            //{
            //    //PhieuXuat = CommonProvider.Instance.GetSoPhieu()
            //    //NgayLap = info.NgayLap;
            //    DienGiai = info.GhiChu;
            //    //idChungTu = info.IdChungTu;
            //    SoCTG = info.SoChungTu;
            //    TrangThai = info.TrangThai;
            //    btnMoPhieu.Enabled = true;
            //    btnXoaPhieu.Enabled = false;
            //}
        }
        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            //if (dgvChiTiet.RowCount > 0)
            //{
            //    frm_PhieuDeNghiNhanDieuChuyenNew frm = new frm_PhieuDeNghiNhanDieuChuyenNew(idChungTu, PhieuXuat,
            //                                                                          NgayLap.ToString(), "", TrangThai,SoCTG);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        dgvChiTiet.DataSource = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen();
            //    }
            //}
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if(e.RowIndex < 0)return;
            //ChungTuDeNghiNhanDieuChuyenInfor info = grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle) as ChungTuDeNghiNhanDieuChuyenInfor;
            //if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clTrangThai")
            //{
            //    int trangThai = Convert.ToInt32(e.Value);
            //    if (info.LoaiChungTu == 14 || info.LoaiChungTu == 21)
            //    {
            //        e.Value = trangThai == 3 ? "Đã nhận" : "Chờ nhận";
            //        e.FormattingApplied = true;
            //    }
            //    else
            //    {
            //        e.Value = trangThai == 1 ? "Đã xuất" : "Chưa xuất";
            //        e.FormattingApplied = true;
            //    }
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
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuNhapDieuChuyenInfor info = ((ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            if (info.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN) 
                || info.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
            {
                PhieuXuat = info.SoChungTu;
                NgayLap = info.NgayLap;
                DienGiai = info.GhiChu;
                idChungTu = info.IdChungTu;
                SoCTG = info.SoChungTuGoc;
                TrangThai = info.TrangThai;
                NguoiLap = info.NguoiLap;
                TenKho = info.TenKho;
                IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            }
            else
            {
                idChungTu = 0;
                NgayLap = DateTime.Now;
                DienGiai = info.GhiChu;
                SoCTG = info.SoChungTuGoc;
                TrangThai = 0;
                NguoiLap = Declare.TenNhanVien;
                TenKho = info.TenKho;
                IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            }

            frm_PhieuDeNghiNhanDieuChuyenNew frm = new frm_PhieuDeNghiNhanDieuChuyenNew(info);
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

        private void grvDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if(e.Column.Name=="colTrangThai")
            //{
            //    ChungTuNhapDieuChuyenInfor info = ((ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(e.RowHandle));
            //    if (info== null) return;
            //    if (info.LoaiChungTu == 14 || info.LoaiChungTu == 21)
            //    {
            //        e.DisplayText = Convert.ToInt32(e.Value) == 2 ? "Chờ nhận" : Convert.ToInt32(e.Value) == 4 ? "Chờ nhận (chưa xuất)" : "Đã nhận";
            //    }
            //    else
            //    {
            //        e.DisplayText = Convert.ToInt32(e.Value) == 0 ? "Chờ xuất" : "Đã xuất";
            //    }
            //}
        }
        private bool ActivatedFlag = false;
        private void frm_DanhSachDeNghiNhanDieuChuyenNew_Activated(object sender, EventArgs e)
        {
            if (!ActivatedFlag)
            frm_DanhSachDeNghiNhanDieuChuyen_Load(sender, e);
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            IdKho = String.Empty;
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            grcDanhSach.DataSource = NhanDieuChuyenDataProvider.GetFillterDeNghiNhanDieuChuyen(IdKho, txtSoGiaoDich.Text,
                String.IsNullOrEmpty(txtSoGiaoDich.Text) ?
                dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                !dteNgayThucHien.ShowCheckBox ? dteNgayThucHien.Value : DateTime.MinValue : DateTime.MinValue, cboTrangThai.Text);
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.Text == "Đã nhận" || String.IsNullOrEmpty(cboTrangThai.Text))
            {
                dteNgayThucHien.ShowCheckBox = false;
            }
            else
            {
                dteNgayThucHien.ShowCheckBox = true;
            }
        }
    }
}