using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuXuatTraNCC : DevExpress.XtraEditors.XtraForm
    {
        List<ChungTuXuatNoiBoInfor> liDM = new List<ChungTuXuatNoiBoInfor>();

        public frm_DanhSachPhieuXuatTraNCC()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            btnMoPhieu.Enabled = false;
        } 

        #region Event...
        private void LoadTrangThai()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            repTrangThai.DataSource = lst;
        }
        private void frm_DanhSachPhieuXuatTraNCC_Load(object sender, EventArgs e)
        {
            liDM = XuatNoiBoDataProvider.GetListXuatNoiBo();
            grcDanhSach.DataSource = liDM;
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
            btnMoPhieu.Text = Resources.btnInfor;
            btnThemPhieu.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        } 

        public void Delete()
        {
            XuatNoiBoBussiness XuatNoiBoBussiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle <0) return;
            XuatNoiBoBussiness = new XuatNoiBoBussiness((ChungTuXuatNoiBoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            XuatNoiBoBussiness.DeleteChungTu();
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuXuatNoiBoInfor item = (ChungTuXuatNoiBoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            frm_PhieuXuatTraNCC frm = new frm_PhieuXuatTraNCC(item.IdChungTu, item.SoChungTu, item.NgayLap.ToString(), item.SoChungTuGoc,
                                                                item.IdChungTuGoc, item.TrangThai, item.GhiChu, item.HoTen, item.DongBo, item.IdPhongBan, item.IdChiPhi, item.IdNhaCC, item.IdLyDo, item.SoPO,item.SoRE, item.TenDoiTuong);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                liDM = XuatNoiBoDataProvider.GetListXuatNoiBo();
                grcDanhSach.DataSource = liDM;
            }
        } 

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuXuatTraNCC frm = new frm_PhieuXuatTraNCC();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                liDM= XuatNoiBoDataProvider.GetListXuatNoiBo();
                grcDanhSach.DataSource = liDM;
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Delete();
                grcDanhSach.DataSource = XuatNoiBoDataProvider.GetListXuatNoiBo();
            }
        }

        private void frm_DanhSachPhieuXuatTraNCC_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuXuatNoiBoInfor item = (ChungTuXuatNoiBoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            frm_PhieuXuatTraNCC frm = new frm_PhieuXuatTraNCC(item.IdChungTu, item.SoChungTu, item.NgayLap.ToString(), item.SoChungTuGoc,
                                                                item.IdChungTuGoc, item.TrangThai, item.GhiChu, item.HoTen, item.DongBo, item.IdPhongBan, item.IdChiPhi, item.IdNhaCC, item.IdLyDo, item.SoPO, item.SoRE, item.TenDoiTuong);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    liDM = XuatNoiBoDataProvider.GetListXuatNoiBo();
                    grcDanhSach.DataSource = liDM;
                }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = true;
        }

        private void frm_DanhSachPhieuXuatTraNCC_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }
    }
}
