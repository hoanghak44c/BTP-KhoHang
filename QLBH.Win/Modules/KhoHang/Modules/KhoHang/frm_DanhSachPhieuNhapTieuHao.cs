using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Providers;

// form frmDanhSachPhieuXuatTieuHao
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 18/06/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD form_DanhSachPhieuXuatTieuHao
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuNhapTieuHao : DevExpress.XtraEditors.XtraForm
    {
        //public DateTime NgayLap;
        //public string PhieuXuat;
        //public int OID, idChungTuGoc;
        //public string PO;
        //public string SoPhieu, SoChungTuGoc;
        //public DateTime NgayXuat;
        //public string DienGiai;
        //public int TrangThaiDuyet;
        List<ChungTuXuatTieuHaoInfornew> liDM = new List<ChungTuXuatTieuHaoInfornew>();

        public frm_DanhSachPhieuNhapTieuHao()
        {
            InitializeComponent();
            Common.LoadStyle(this);
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
            XuatKhoTieuHaoBusinessnew XuatTieuHaoBusiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle < 0) return;
            XuatTieuHaoBusiness = new XuatKhoTieuHaoBusinessnew((ChungTuXuatTieuHaoInfornew)grvDanhSach.GetFocusedRow());
            XuatTieuHaoBusiness.ChungTu.TrangThai = 0;
            XuatTieuHaoBusiness.DeleteChungTu();
        }
        #region Event
        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuXuatTieuHaoInfornew item = (ChungTuXuatTieuHaoInfornew)grvDanhSach.GetFocusedRow();
            frm_PhieuNhapTieuHao frm = new frm_PhieuNhapTieuHao(item.IdChungTu, item.SoChungTu, item.NgayXuatHang.ToString(),
                item.SoChungTuGoc, item.IdChungTuGoc, item.TrangThai, item.HoTen, item.TenTrungTam, item.TenKho, item.NguoiXuat, 
                item.GhiChu,item.IdNhanVienGiao, item.NgayLap.ToString(),item.IdKho);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                liDM = NhapTieuHaoProvider.GetListXuatTieuHao();
                grcDanhSach.DataSource = liDM;
            }
        } 

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        #endregion

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;
                ChungTuXuatTieuHaoInfornew item = (ChungTuXuatTieuHaoInfornew)grvDanhSach.GetFocusedRow();
                if (item == null) return;
                frm_PhieuNhapTieuHao frm = new frm_PhieuNhapTieuHao(item.IdChungTu, item.SoChungTu, item.NgayXuatHang.ToString(),
                    item.SoChungTuGoc, item.IdChungTuGoc, item.TrangThai, item.HoTen, item.TenTrungTam, item.TenKho,item.NguoiXuat,
                    item.GhiChu,item.IdNhanVienGiao, item.NgayLap.ToString(),item.IdKho);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    liDM = NhapTieuHaoProvider.GetListXuatTieuHao();
                    grcDanhSach.DataSource = liDM;
                }
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

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private bool ActivatedFlag = false;
        //Load lại form khi lập đề nghị phiếu
        private void frm_DanhSachPhieuXuatTieuHao_Activated(object sender, EventArgs e)
        {
            if (!ActivatedFlag)
                frm_DanhSachPhieuNhapTieuHao_Load(sender,e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //ActivatedFlag = true;
            //if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    Delete();
            //    grcDanhSach.DataSource = XuatTieuHaoProvidernew.GetListXuatTieuHao();
            //    grcDanhSach.RefreshDataSource();
            //    ActivatedFlag = false;
            //}
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void frm_DanhSachPhieuNhapTieuHao_Load(object sender, EventArgs e)
        {
            liDM = NhapTieuHaoProvider.GetListXuatTieuHao();
            grcDanhSach.DataSource = liDM;
            btnMoPhieu.Enabled = true;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        }

        private void frm_DanhSachPhieuNhapTieuHao_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }
    }
}