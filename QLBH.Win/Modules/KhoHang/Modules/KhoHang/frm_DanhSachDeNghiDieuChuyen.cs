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
using QLBH.Core;
using QLBH.Core.Exceptions;


// form frmDanhSachDeNghiDieuChuyen
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 20/07/2012
// Người sửa cuối:
// Ngày sửa cuối:
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachDeNghiDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        //private int idChungTu = 0;
        //public int idKho;
        //public int SoChungTu;
        //public string TenKho;
        //public string SoPX;
        //public string NguoiXuat;
        //public string PhieuXuat;
        //private string NguoiLap;
        //public string GhiChu;
        //public DateTime NgayLap;
        //public string DienGiai;
        //public DateTime ThoiGian;
        //public int TrangThai;
        //public int idKhoDieuChuyen;
        public frm_DanhSachDeNghiDieuChuyen()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
         
        public void Delete()
        {
            DeNghiDieuChuyenBussiness DeNghiXuatDieuChuyenBusiness;
            if (grvDanhSach.FocusedRowHandle <0) return;
            DeNghiXuatDieuChuyenBusiness = new DeNghiDieuChuyenBussiness((ChungTuDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            List<ChungTuDieuChuyenInfor> objXuat = DeNghiDieuChuyenDataProvider.Instance.GetListChiTietChungTuBySoChungTu(DeNghiXuatDieuChuyenBusiness.ChungTu.SoChungTu);
            if (objXuat.FindAll(delegate(ChungTuDieuChuyenInfor math)
                                   {
                                       return math.LoaiChungTu == 21;
                                   }).Count > 0)
            {
                throw new ManagedException("chứng từ đã nhập kho thành công, không thể hủy được!");
            }
            else
            {
                //Huy De Nghi nhan dieu chuyen
                DeNghiNhanDieuChuyenBussiness DeNghiNhanDieuChuyenBusiness;
                if (grvDanhSach.FocusedRowHandle < 0) return;
                DeNghiNhanDieuChuyenBusiness = new DeNghiNhanDieuChuyenBussiness((ChungTuNhapDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
                List<ChungTuNhapDieuChuyenInfor> objNhan = DeNghiNhanDieuChuyenDataProvider.Instance.GetListChiTietChungTuBySoChungTu(DeNghiNhanDieuChuyenBusiness.ChungTu.SoChungTu);
                for (int i = 0; i < objNhan.Count; i++)
                {
                    if (objNhan[i].LoaiChungTu == 14)
                    {
                        DeNghiNhanDieuChuyenBussiness DeNghiNhanBusiness = new DeNghiNhanDieuChuyenBussiness(objNhan[i]);
                        DeNghiNhanBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                        DeNghiNhanBusiness.ChungTu.LoaiChungTu =
                            - Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN);
                        DeNghiNhanBusiness.CancelChungTu();
                    }
                }
                //Huy De Nghi Xuat dieu chuyen trung gian
                DeNghiXuatDieuChuyenTGBussiness DeNghiXuatDieuChuyenTGBusiness;
                DeNghiXuatDieuChuyenTGBusiness = new DeNghiXuatDieuChuyenTGBussiness((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
                List<ChungTuXuatDieuChuyenInfo> objDNXuatTG = DeNghiXuatDieuChuyenTGDataProvider.Instance.GetListChiTietChungTuBySoChungTu(DeNghiXuatDieuChuyenTGBusiness.ChungTu.SoChungTu);
                for (int i = 0; i < objXuat.Count; i++)
                {
                    if (objNhan[i].LoaiChungTu == 55)
                    {
                        DeNghiXuatDieuChuyenTGBussiness DeNghiXuatTGBusiness =
                            new DeNghiXuatDieuChuyenTGBussiness(objDNXuatTG[i]);
                        DeNghiXuatTGBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                        DeNghiXuatTGBusiness.ChungTu.LoaiChungTu =
                            -Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN);
                        DeNghiXuatTGBusiness.CancelChungTu();
                    }
                }
                //Huy nhap dieu chuyen trug gian
                NhapDieuChuyenTGBussiness NhapDieuChuyenTGBusiness;
                if (grvDanhSach.FocusedRowHandle < 0) return;
                NhapDieuChuyenTGBusiness = new NhapDieuChuyenTGBussiness((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
                List<ChungTuNhapDieuChuyenInfo> objNhapTG = NhapDieuChuyenKhoTGDataProvider.Instance.GetListChiTietChungTuBySoChungTu(NhapDieuChuyenTGBusiness.ChungTu.SoChungTu);
                for (int i = 0; i < objNhan.Count; i++)
                {
                    if (objNhan[i].LoaiChungTu == 54)
                    {
                        NhapDieuChuyenTGBussiness NhapTGBusiness = new NhapDieuChuyenTGBussiness(objNhapTG[i]);
                        NhapTGBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                        NhapTGBusiness.ChungTu.LoaiChungTu =
                            -Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN_TRUNG_GIAN);
                        NhapTGBusiness.CancelChungTu();
                    }
                }
                //Huy De Nghi nhan dieu chuyen trung gian
                DeNghiNhapDieuChuyenTGBussiness DeNghiNhapDieuChuyenTGBusiness;
                if (grvDanhSach.FocusedRowHandle < 0) return;
                DeNghiNhapDieuChuyenTGBusiness = new DeNghiNhapDieuChuyenTGBussiness((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
                List<ChungTuNhapDieuChuyenInfo> objDNNhapTG = DeNghiNhapDieuChuyenTGDataProvider.Instance.GetListChiTietChungTuBySoChungTu(DeNghiNhapDieuChuyenTGBusiness.ChungTu.SoChungTu);
                for (int i = 0; i < objNhan.Count; i++)
                {
                    if (objNhan[i].LoaiChungTu == 53)
                    {
                        DeNghiNhapDieuChuyenTGBussiness DeNghiNhapTGBusiness = new DeNghiNhapDieuChuyenTGBussiness(objDNNhapTG[i]);
                        DeNghiNhapTGBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                        DeNghiNhapTGBusiness.ChungTu.LoaiChungTu =
                            -Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN);
                        DeNghiNhapTGBusiness.CancelChungTu();
                    }
                }
                //Huy Xuat dieu chuyen
                for (int i = 0; i < objXuat.Count; i++)
                {
                    if (objXuat[i].LoaiChungTu == 13)
                    {
                        XuatDieuChuyenBusiness XuatDieuChuyenBusiness = new XuatDieuChuyenBusiness(objXuat[i]);
                        XuatDieuChuyenBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                        XuatDieuChuyenBusiness.ChungTu.LoaiChungTu = - Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN);
                        XuatDieuChuyenBusiness.CancelChungTu();
                    }
                }
                // Huy de nghi xuat dieu chuyen
                for (int i = 0; i < objXuat.Count; i++)
                {
                    if (objXuat[i].LoaiChungTu == 12)
                    {
                        DeNghiDieuChuyenBussiness DeNghiDieuChuyenBusiness = new DeNghiDieuChuyenBussiness(objXuat[i]);
                        DeNghiDieuChuyenBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                        DeNghiDieuChuyenBusiness.ChungTu.LoaiChungTu = -Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN);
                        DeNghiDieuChuyenBusiness.CancelChungTu();
                    }
                }
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
            repTrangThai.DataSource = lst;
        }

        private string IdKho;
        private void frm_DanhSachPhieuDieuChuyen_Load(object sender, EventArgs e)
        {
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetListDeNghiXuatDieuChuyen(IdKho);
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
            btnThemPhieu.Text = Resources.btnAdd;
            //btnXoaPhieu.Text = Resources.btnDelete;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
            clsUtils.NullColumnDateTimeGrid(repNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if(grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = ((ChungTuDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT(info);
            IdKho = String.Empty;
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetListDeNghiXuatDieuChuyen(IdKho);
            }
            //else
            //{
            //    ActivatedFlag = true;
            //}
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT();
            IdKho = String.Empty;
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetListDeNghiXuatDieuChuyen(IdKho);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn hủy bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Delete();
                foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                {
                    IdKho += nguoiDungInfor.IdKho + ",";
                }
                grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetListDeNghiXuatDieuChuyen(IdKho);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;
            //ChungTuDeNghiXuatDieuChuyenInfor info = ((ChungTuDeNghiXuatDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            //PhieuXuat = info.SoChungTu;
            //idKho = info.IdKho;
            //NgayLap = info.NgayLap;
            //DienGiai = info.GhiChu;
            //idChungTu = info.IdChungTu;
            //TrangThai = info.TrangThai;
            //TenKho = info.TenKho;
            //GhiChu = info.GhiChu;
            //NguoiLap = info.NguoiLap;
            //idKhoDieuChuyen = info.IdKhoDieuChuyen;            
            //btnMoPhieu.Enabled = true;
            //btnXoaPhieu.Enabled = false;
            //info.TrangThai != 1;
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            //if(dgvChiTiet.RowCount > 0)
            //{
            //    frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT(idChungTu, PhieuXuat, NgayLap.ToString(), "",TrangThai,idKhoDieuChuyen,TenKho,GhiChu,NguoiLap);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetListDeNghiXuatDieuChuyen();
            //    }
            //}
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clTrangThai")
            //{
            //    int trangThai = Convert.ToInt32(e.Value);
            //    e.Value = trangThai == 1 ? "Đã xuất" : "Chờ xuất";
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

        private void frm_DanhSachDeNghiDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = ((ChungTuDieuChuyenInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT(info);
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                IdKho += nguoiDungInfor.IdKho + ",";
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetListDeNghiXuatDieuChuyen(IdKho);
            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
        }
        private bool ActivatedFlag = false;
        private void frm_DanhSachDeNghiDieuChuyen_Activated(object sender, EventArgs e)
        {
            if (!ActivatedFlag)
            frm_DanhSachPhieuDieuChuyen_Load(sender, e);
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
            grcDanhSach.DataSource = XuatDieuChuyenDataProvider.GetFillterDeNghiXuatDieuChuyen(IdKho, txtSoGiaoDich.Text,
                String.IsNullOrEmpty(txtSoGiaoDich.Text) ?
                dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                !dteNgayThucHien.ShowCheckBox ? dteNgayThucHien.Value : DateTime.MinValue : DateTime.MinValue, cboTrangThai.Text);
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTrangThai.Text == "Đã nhận" || String.IsNullOrEmpty(cboTrangThai.Text))
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