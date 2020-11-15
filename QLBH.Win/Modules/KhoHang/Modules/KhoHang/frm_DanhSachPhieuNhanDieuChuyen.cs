using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuNhanDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        //public DateTime NgayLap;
        public string IdKho;
        //public int OID, idChungTuGoc;
        //public string PO;
        //public string SoPhieu, SoChungTuGoc;
        //public DateTime NgayXuat;
        //public string DienGiai;
        //public int TrangThai;
        List<ChungTuNhapDieuChuyenInfor> liDM = new List<ChungTuNhapDieuChuyenInfor>(); 
        public frm_DanhSachPhieuNhanDieuChuyen()
        {
            InitializeComponent();
            Common.LoadStyle(this);
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
        private void frm_DanhSachPhieuNhanDieuChuyen_Load(object sender, EventArgs e)
        {
            //xem lại get list
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            liDM = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
            grcDanhSach.DataSource = liDM;
            btnMoPhieu.Enabled = true;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
            clsUtils.NullColumnDateTimeGrid(repNgayNhap);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if(grvDanhSach.FocusedRowHandle <0) return;
            ChungTuNhapDieuChuyenInfor info =
                (ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            if (info.LoaiChungTu == 14 || info.LoaiChungTu == 21)
            {
                frm_PhieuNhanDieuChuyen frm = new frm_PhieuNhanDieuChuyen(info);
                foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                {
                    IdKho += nguoiDungInfor.IdKho + ",";
                }
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    liDM = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
                    grcDanhSach.DataSource = liDM;
                }
            }
            else
            {
                MessageBox.Show("Số chứng từ yêu cầu chưa được tạo!", "Thông báo");
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex < 0) return;
            //SoPhieu = ((ChungTuDeNghiNhanDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).SoChungTu;
            //NgayXuat = ((ChungTuDeNghiNhanDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).NgayLap;
            //DienGiai = ((ChungTuDeNghiNhanDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).GhiChu;
            //SoChungTuGoc = ((ChungTuDeNghiNhanDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).SoChungTuGoc;
            //idChungTuGoc = ((ChungTuDeNghiNhanDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChungTuGoc;
            //OID = ((ChungTuDeNghiNhanDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChungTu;
            //TrangThai = ((ChungTuDeNghiNhanDieuChuyenInfor) dgvChiTiet.Rows[e.RowIndex].DataBoundItem).TrangThai;
            //btnMoPhieu.Enabled = true;
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            //if (dgvChiTiet.RowCount > 0 && OID > 0)
            //{
            //    frm_PhieuNhanDieuChuyen frm = new frm_PhieuNhanDieuChuyen(OID, SoPhieu, NgayXuat.ToString(), SoChungTuGoc, idChungTuGoc, TrangThai, SoChungTuGoc);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        liDM = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen();
            //        grcDanhSach.DataSource = liDM;
            //    }
            //}
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //ChungTuDeNghiNhanDieuChuyenInfor info =
            //    dgvChiTiet.Rows[e.RowIndex].DataBoundItem as ChungTuDeNghiNhanDieuChuyenInfor;
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
        }

        private void frm_DanhSachPhieuNhanDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuNhapDieuChuyenInfor info =
                (ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            if (info.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN) ||
                info.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
            {
                ChungTuDeNghiNhanDieuChuyenInfor pt = NhanDieuChuyenDataProvider.GetChungTuBySoCtg(info.SoChungTuGoc);
                frm_PhieuNhanDieuChuyen frm = new frm_PhieuNhanDieuChuyen(info);
                foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                {
                    IdKho += nguoiDungInfor.IdKho + ",";
                }
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    liDM = NhanDieuChuyenDataProvider.GetListNhanDieuChuyen(IdKho);
                    grcDanhSach.DataSource = liDM;
                }
            }
            else
            {
                MessageBox.Show("Số chứng từ yêu cầu chưa được tạo!", "Thông báo");
                return;
            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void grvDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "colTrangThai")
            {
                ChungTuNhapDieuChuyenInfor info = ((ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(e.RowHandle));
                if (info == null) return;
                if (info.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN) ||
                    info.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
                {
                    e.DisplayText = Convert.ToInt32(e.Value) == 2 ? "Chờ nhận hàng (chờ thủ kho nhận nhập hàng vào kho)" : Convert.ToInt32(e.Value) == 4 ? "Chờ xuất serial (chờ thủ kho xuất bắn serial xuất)" : "Đã nhận (kết thúc.)";
                }
                else
                {
                    e.DisplayText = Convert.ToInt32(e.Value) == 0 ? "Chờ xác nhận(chờ kế toán kho nhận xác nhận)" : "Đã xuất (thủ kho đã xuất kho, chờ kho nhận làm thủ tục nhận.";
                }
            }
        }

        private bool ActivatedFlag = false;

        private void frm_DanhSachPhieuNhanDieuChuyen_Activated(object sender, EventArgs e)
        {
            if (!ActivatedFlag)
                frm_DanhSachPhieuNhanDieuChuyen_Load(sender, e);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            grcDanhSach.ShowPrintPreview();
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
