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

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuNhapNoiBoTest : frm_ListPhieuBase
    {
        public DateTime NgayLap;
        public string PhieuNhap;
        public int OID, idChungTuGoc;
        public string PO;
        public string SoPhieu;
        public string SoChungTuGoc;
        public DateTime NgayXuat;
        public string DienGiai;
        public int TrangThaiDuyet;
        public string GhiChu;
        public string NguoiLap;
        private int DongBoERP;
        private int IdChiPhi, IdPhongBan;
        List<ChungTuNhapNoiBoInfor> liDM = new List<ChungTuNhapNoiBoInfor>(); 

        //public frm_DanhSachPhieuNhapNoiBoTest()
        //{
        //    //InitializeComponent();
        //    dgvChiTiet.AutoGenerateColumns = false;
        //    Common.LoadStyle(this);
        //} 
        private  void Delete()
        {
            NhapNoiBoBussiness NhapNoiBoBussiness;
            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
            NhapNoiBoBussiness = new NhapNoiBoBussiness((ChungTuNhapNoiBoInfor)dgvChiTiet.CurrentRow.DataBoundItem);
            NhapNoiBoBussiness.DeleteChungTu();
        }
        protected override void XoaPhieuInstance()
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Delete();
                    dgvChiTiet.DataSource = NhapNoiBoDataProvider.GetListNhapNoiBo();
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
        protected override void LoadDataInstance()
        {
            liDM = NhapNoiBoDataProvider.GetListNhapNoiBo();
            dgvChiTiet.DataSource = liDM;
            btnMoPhieu.Enabled = false;
            btnXoaPhieu.Enabled = false;
            dgvChiTiet.AutoGenerateColumns = false;
            btnMoPhieu.Text = Resources.btnInfor;
            btnThemPhieu.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
        }
        //private void frm_DanhSachPhieuNhapNoiBo_Load(object sender, EventArgs e)
        //{
        //    liDM =  NhapNoiBoDataProvider.GetListNhapNoiBo();
        //    dgvChiTiet.DataSource = liDM;
        //    btnMoPhieu.Enabled = false;
        //    btnXoaPhieu.Enabled = false;
        //    dgvChiTiet.AutoGenerateColumns = false;
        //    btnMoPhieu.Text = Resources.btnInfor;
        //    btnThemPhieu.Text = Resources.btnAdd;
        //    btnXoaPhieu.Text = Resources.btnDelete;
        //    btnDong.Text = Resources.btnClose;
        //}
        protected override void MoPhieuInstance()
        {
            //frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo(OID, SoPhieu, NgayXuat.ToString(), SoChungTuGoc, idChungTuGoc, TrangThaiDuyet, GhiChu, NguoiLap, DongBoERP,IdPhongBan,IdChiPhi);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    dgvChiTiet.DataSource = NhapNoiBoDataProvider.GetListNhapNoiBo();
            //}
        }
        //private void btnMoPhieu_Click(object sender, EventArgs e)
        //{
        //    frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo(OID, SoPhieu, NgayXuat.ToString(), SoChungTuGoc, idChungTuGoc,TrangThaiDuyet,GhiChu,NguoiLap);
        //    if (frm.ShowDialog() == DialogResult.OK)
        //    {
        //        dgvChiTiet.DataSource = NhapNoiBoDataProvider.GetListNhapNoiBo();
        //    }
        //}

        private bool Check()
        {
            return true;
        }
        protected override void ThemPhieuInstance()
        {
            try
            {
                if (Check())
                {
                    frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        liDM = NhapNoiBoDataProvider.GetListNhapNoiBo();
                        dgvChiTiet.DataSource = liDM;
                    }
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
//        private void btnThemPhieu_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (Check())
//                {
//                    frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo();
//                    if (frm.ShowDialog() == DialogResult.OK)
//                    {
//                        liDM = NhapNoiBoDataProvider.GetListNhapNoiBo();
//                        dgvChiTiet.DataSource = liDM;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.ToString());
//#else
//                MessageBox.Show(ex.Message);
//#endif
//            }
//        }

//        private void btnXoaPhieu_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
//                {
//                    Delete();
//                    dgvChiTiet.DataSource = NhapNoiBoDataProvider.GetListNhapNoiBo();
//                }
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                MessageBox.Show(ex.ToString());
//#else
//                MessageBox.Show(ex.Message);
//#endif
//            }
//        }

        //private void btnDong_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            SoPhieu = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).SoChungTu;
            NgayXuat = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).NgayLap;
            DienGiai = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).GhiChu;
            SoChungTuGoc = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).SoChungTuGoc;
            idChungTuGoc = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChungTuGoc;
            OID = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChungTu;
            GhiChu = ((ChungTuNhapNoiBoInfor) dgvChiTiet.Rows[e.RowIndex].DataBoundItem).GhiChu;
            NguoiLap = ((ChungTuNhapNoiBoInfor) dgvChiTiet.Rows[e.RowIndex].DataBoundItem).HoTen;
            TrangThaiDuyet = ((ChungTuNhapNoiBoInfor)dgvChiTiet.Rows[e.RowIndex].DataBoundItem).TrangThai;
            IdPhongBan = ((ChungTuNhapNoiBoInfor) dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdPhongBan;
            IdChiPhi = ((ChungTuNhapNoiBoInfor) dgvChiTiet.Rows[e.RowIndex].DataBoundItem).IdChiPhi;
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = true;
        }
        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            if (dgvChiTiet.RowCount > 0 && OID > 0)
            {
                //frm_PhieuNhapNoiBo frm = new frm_PhieuNhapNoiBo(OID, SoPhieu, NgayXuat.ToString(), SoChungTuGoc,
                //                                                idChungTuGoc, TrangThaiDuyet, GhiChu, NguoiLap, DongBoERP,IdPhongBan,IdChiPhi);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    liDM = NhapNoiBoDataProvider.GetListNhapNoiBo();
                //    dgvChiTiet.DataSource = liDM;
                //}
            }
        }

        private void dgvChiTiet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChiTiet.Columns[e.ColumnIndex].Name == "clTrangThai")
            {
                int trangThai = Convert.ToInt32(e.Value);
                e.Value = trangThai == 1 ? "Đã Nhập" : "Chưa Nhập";
                e.FormattingApplied = true;
            }
        }

        private void frm_DanhSachPhieuNhapNoiBo_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }
    }
}