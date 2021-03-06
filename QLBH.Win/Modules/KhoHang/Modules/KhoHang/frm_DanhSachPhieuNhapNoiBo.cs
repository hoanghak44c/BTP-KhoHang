using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuNhapNoiBo : DevExpress.XtraEditors.XtraForm
    {
        List<ChungTuNhapNoiBoInfor> liDM = new List<ChungTuNhapNoiBoInfor>(); 

        public frm_DanhSachPhieuNhapNoiBo()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        private void LoadTrangThai()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa nhập" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã nhập" });
            repTrangThai.DataSource = lst;
        }
        public void Delete()
        {
            NhapNoiBoBussiness NhapNoiBoBussiness;
            if (grvDanhSach.FocusedRowHandle <0) return;
            NhapNoiBoBussiness = new NhapNoiBoBussiness((ChungTuNhapNoiBoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            NhapNoiBoBussiness.DeleteChungTu();
        }

        private void frm_DanhSachPhieuNhapNoiBo_Load(object sender, EventArgs e)
        {
            liDM =  NhapNoiBoDataProvider.GetListNhapNoiBo();
            grcDanhSach.DataSource = liDM;
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
            btnMoPhieu.Text = Resources.btnInfor;
            btnThemPhieu.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;

            ChungTuNhapNoiBoInfor item = (ChungTuNhapNoiBoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo(item.IdChungTu, item.SoChungTu, item.NgayLap.ToString(), item.SoChungTuGoc,
                                                                item.IdChungTuGoc, item.TrangThai, item.GhiChu, item.HoTen, item.DongBo, item.IdPhongBan, item.IdChiPhi, item.IdNhaCC, item.IdLyDo, item.SoPO,item.SoRE, item.TenDoiTuong);
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = NhapNoiBoDataProvider.GetListNhapNoiBo();
            }
        }

        private bool Check()
        {
            return true;
        }
        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        liDM = NhapNoiBoDataProvider.GetListNhapNoiBo();
                        grcDanhSach.DataSource = liDM;
                    }
                }
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Delete();
                    grcDanhSach.DataSource = NhapNoiBoDataProvider.GetListNhapNoiBo();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_DanhSachPhieuNhapNoiBo_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = true;
        }

        private void grvDanhSach_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if(e.Column==colTrangThai)
            //{
            //    int trangThai = Convert.ToInt32(e.Value);
            //    e.DisplayText = trangThai == 1 ? "Đã Nhập" : "Chưa Nhập";
            //}
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle<0)return;
                ChungTuNhapNoiBoInfor item = (ChungTuNhapNoiBoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
                frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo(item.IdChungTu, item.SoChungTu, item.NgayLap.ToString(), item.SoChungTuGoc,
                                                                item.IdChungTuGoc, item.TrangThai, item.GhiChu, item.HoTen, item.DongBo, item.IdPhongBan, item.IdChiPhi, item.IdNhaCC, item.IdLyDo, item.SoPO, item.SoRE, item.TenDoiTuong);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    liDM = NhapNoiBoDataProvider.GetListNhapNoiBo();
                    grcDanhSach.DataSource = liDM;
                }
        }

        private void frm_DanhSachPhieuNhapNoiBo_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }
    }
}