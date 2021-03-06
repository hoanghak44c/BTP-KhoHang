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
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        //public DateTime NgayLap;
        public string IdKho;
        //public int OID, idChungTuGoc,idKhoDieuChuyen;
        //public string PO;
        //public string SoPhieu, SoChungTuGoc;
        //public DateTime NgayXuat;
        //public string GhiChu;
        //public string TenKho;
        //public string NguoiLap;
        //public int TrangThaiDuyet;
        List<ChungTuDieuChuyenInfor> liDM = new List<ChungTuDieuChuyenInfor>(); 
        public frm_DanhSachDieuChuyen()
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
            repTrangThai.DataSource = lst;
        }
        private void frm_DanhSachPhieuNhanDieuChuyen_Load(object sender, EventArgs e)
        {
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            liDM = DieuChuyenDataProvider.Instance.GetListXuatDieuChuyen(IdKho);
            grcDanhSach.DataSource = liDM;
            btnMoPhieu.Enabled = true;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
            clsUtils.NullColumnDateTimeGrid(repNgayXuatHang);
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = ((ChungTuDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDieuChuyenCungTT frm = new frm_PhieuDieuChuyenCungTT(info);
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                liDM = DieuChuyenDataProvider.Instance.GetListXuatDieuChuyen(IdKho);
                grcDanhSach.DataSource = liDM;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //SoPhieu = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).SoChungTu;
            //NgayXuat = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).NgayLap;
            //GhiChu = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).GhiChu;
            //NguoiLap = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).NguoiLap;
            //TenKho = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).TenKho;
            ////SoChungTuGoc = ((ChungTuXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).SoChungTuGoc;
            ////idChungTuGoc = ((ChungTuXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChungTuGoc;
            //OID = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChungTu;
            //TrangThaiDuyet = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).TrangThai;
            //idKhoDieuChuyen = ((ChungTuDeNghiXuatDieuChuyenInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdKhoDieuChuyen;
            //btnMoPhieu.Enabled = true;
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            //if (dgvChiTiet.RowCount > 0 && OID > 0)
            //{
            //    frm_PhieuDieuChuyenCungTT frm = new frm_PhieuDieuChuyenCungTT(OID, SoPhieu, NgayXuat.ToString(), SoChungTuGoc,
            //                                                      idChungTuGoc,TrangThaiDuyet,idKhoDieuChuyen,TenKho,GhiChu,NguoiLap);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        liDM = DieuChuyenDataProvider.GetListXuatDieuChuyen();
            //        grcDanhSach.DataSource = liDM;
            //    }
            //}
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clTrangThai")
            //{
            //    int trangThai = Convert.ToInt32(e.Value);
            //    e.Value = trangThai == 1 ? "Đã xuất " : "Chờ xuất";
            //    e.Value = trangThai == 3 ? "Đã nhận" : "Chờ nhận";
            //    e.FormattingApplied = true;
            //}
        }

        private void frm_DanhSachDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if(grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = ((ChungTuDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDieuChuyenCungTT frm = new frm_PhieuDieuChuyenCungTT(info);
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                liDM = DieuChuyenDataProvider.Instance.GetListXuatDieuChuyen(IdKho);
                grcDanhSach.DataSource = liDM;
            }

        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }
        private bool ActivatedFlag = false;
        private void frm_DanhSachDieuChuyen_Activated(object sender, EventArgs e)
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
            grcDanhSach.DataSource = DieuChuyenDataProvider.Instance.GetFillterXuatDieuChuyen(IdKho, txtSoGiaoDich.Text,
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