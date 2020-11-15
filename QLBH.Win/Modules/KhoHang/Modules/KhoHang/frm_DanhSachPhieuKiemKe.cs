using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;

// <Remarks>
// Tạo DanhSachPhieuKiemKe
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 21/10/2012
// Người sửa cuối:
// </remarks>
namespace QLBanHang.Modules.KhoHang
{
    public interface IUnitTest
    {
        bool IsTestUnit { get; set; }
    }

    public partial class frm_DanhSachPhieuKiemKe : DevExpress.XtraEditors.XtraForm, IUnitTest
    {
        public bool isAdd;
        public int Oid,IdKho, IdNhanVien;
        public string SoPhieu;
        public DateTime NgayLap;
        public string GhiChu;
        public string KhoThucHien;
        public int KhoKhach;
        List<LookUp> lst = new List<LookUp>();
        public KiemKeInfor item = new KiemKeInfor();

        public bool IsTestUnit { get; set; }

        public frm_DanhSachPhieuKiemKe()
        {
            InitializeComponent();
        }
        #region Action
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadTrangThai()
        {
            lst.Add(new LookUp { OID = 0, Name = "Chưa xác nhận" });
            lst.Add(new LookUp { OID = 1, Name = "Xác nhận" });
            repTrangThaiKiemKe.DataSource = null;
            repTrangThaiKiemKe.DataSource = lst;
        }
        private void LoadData()
        {
            IdKho = Declare.IdKho;
            grcDanhSach.DataSource = KiemKeDataProvider.Instance.GetListKiemKe2();
            btnThemMoi.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
        }
        private void Delete()
        {
            KiemKeDataProvider.Instance.DeleteKiemKe2(Oid);
            LoadData();
        }
        public void ReLoad()
        {
            LoadData();
            grcDanhSach.Refresh();
        }
        #endregion

        #region Event
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            isAdd = true;
            
            Oid = 0;
            
            var frm = new frm_ChiTietPhieuKiemKe(this);
            
            frm.ShowDialog();
            
            var idKiemKe = frm.IdKiemKe;
            
            var lst =KiemKeDataProvider.Instance.GetListKiemKe2();
            
            grcDanhSach.DataSource = lst;

            if(idKiemKe > 0)
            {
                var kiemKeInfo = lst.Find(delegate(KiemKeInfor match) { return match.IdKiemKe == idKiemKe; });

                if(kiemKeInfo != null) CommonProvider.Instance.UnLock_KiemKe(kiemKeInfo);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if(IdNhanVien != Declare.IdNhanVien || !Declare.IS_SUPPER_USER)
                    throw new ManagedException("Bạn không có quyền xóa phiếu này");

                if (MessageBox.Show("Bạn có chắc chắn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    Delete();

                    grcDanhSach.DataSource = KiemKeDataProvider.Instance.GetListKiemKe2();
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

        private void frm_DanhSachPhieuKiemKe_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadTrangThai();
        }
        private void dgvKiemKe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && dgvKiemKe.Rows.Count > 0)
            //{
            //    Oid = Convert.ToInt32(dgvKiemKe.Rows[dgvKiemKe.CurrentCell.RowIndex].Cells["clIdKiemKe"].Value);
            //    //Oid = Convert.ToInt32(dgvKiemKe.Rows[e.RowIndex].Cells["clIdKiemKe"].Value.ToString());
            //    NgayLap = Convert.ToDateTime(dgvKiemKe.Rows[e.RowIndex].Cells["clNgayThucHien"].Value);
            //    SoPhieu = dgvKiemKe.Rows[e.RowIndex].Cells["clSoPhieu"].Value.ToString();
            //    GhiChu = Convert.ToString(dgvKiemKe.Rows[e.RowIndex].Cells["clDienGiai"].Value);
            //}
        }
        #endregion

        private void frm_DanhSachPhieuKiemKe_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            item = (KiemKeInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            Oid = item.IdKiemKe;
            NgayLap = item.NgayKiemKe;
            SoPhieu = item.SoPhieu;
            GhiChu = item.GhiChu;
            KhoKhach = item.KhoKhach;
            IdNhanVien = item.IdNhanVien;
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;
                isAdd = false;
                var info = ((KiemKeInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
                info = KiemKeDataProvider.Instance.GetKiemKeInfoById(info.IdKiemKe);
                if (CommonProvider.Instance.Lock_KiemKe(info))
                {
                    var frmChiTietPhieuKiemKe = new frm_ChiTietPhieuKiemKe(this, info.IdKiemKe, info.IdDotKiemKe, info.TrangThai, info.IdNhanVien);
                    frmChiTietPhieuKiemKe.ShowDialog();
                    CommonProvider.Instance.UnLock_KiemKe(info);
                    ReLoad();
                }
            }
            catch (ManagedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DanhSachPhieuKiemKe_Activated(object sender, EventArgs e)
        {
            frm_DanhSachPhieuKiemKe_Load(sender, e);
        }
    }
}