using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;
using QLBH.Core.Version;

// form frmDanhSachPhieuXuatTieuHao
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 18/06/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD form_DanhSachPhieuXuatTieuHao
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuXuatTieuHao : DevExpress.XtraEditors.XtraForm
    {
        //public DateTime NgayLap;
        //public string PhieuXuat;
        //public int OID, idChungTuGoc;
        //public string PO;
        //public string SoPhieu, SoChungTuGoc;
        //public DateTime NgayXuat;
        //public string DienGiai;
        //public int TrangThaiDuyet;
        List<ChungTuXuatTieuHaoInfor> liDM = new List<ChungTuXuatTieuHaoInfor>(); 

        public frm_DanhSachPhieuXuatTieuHao()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        private void LoadTrangThai()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            repTrangThai.DataSource = lst;
        }

        #region Event

        private void frm_DanhSachPhieuXuatTieuHao_Load(object sender, EventArgs e)
        {
            liDM = XuatTieuHaoProvider.GetListXuatTieuHao();
            grcDanhSach.DataSource = liDM;
            btnMoPhieu.Enabled = true;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
            this.Text = this.Text + " - " + VerBase.CurrentVersion;
        } 

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            if (grvDanhSach.FocusedRowHandle < 0) return;
            ChungTuXuatTieuHaoInfor item = (ChungTuXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
            frm_PhieuXuatTieuHao frm = new frm_PhieuXuatTieuHao(item.IdChungTu, item.SoChungTu, item.NgayLap.ToString(), item.SoChungTuGoc, item.IdChungTuGoc, item.TrangThai,item.HoTen);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                liDM = XuatTieuHaoProvider.GetListXuatTieuHao();
                grcDanhSach.DataSource = liDM;
            }
        } 

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        #endregion

        private void frm_DanhSachPhieuXuatTieuHao_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;
                ChungTuXuatTieuHaoInfor item = (ChungTuXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle);
                if (item == null) return;
                frm_PhieuXuatTieuHao frm = new frm_PhieuXuatTieuHao(item.IdChungTu, item.SoChungTu, item.NgayLap.ToString(), item.SoChungTuGoc, item.IdChungTuGoc, item.TrangThai, item.HoTen);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    liDM = XuatTieuHaoProvider.GetListXuatTieuHao();
                    grcDanhSach.DataSource = liDM;
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

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }
        //Load lại form khi lập đề nghị phiếu
        private void frm_DanhSachPhieuXuatTieuHao_Activated(object sender, EventArgs e)
        {
            frm_DanhSachPhieuXuatTieuHao_Load(sender,e);
        }
    }
}