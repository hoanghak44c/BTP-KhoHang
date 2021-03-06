using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

// form frmDanhSachPhieuDeNghiXuatTH
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 20/06/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD form_DanhSachPhieuDeNghiXuatTH
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuDeNghiXuatTHnew : DevExpress.XtraEditors.XtraForm
    {
        public List<tmp_NhapHang_UserChiTietInfo> liChiTietChungTu = new List<tmp_NhapHang_UserChiTietInfo>();
        //public string PO;
        //private int idChungTu = 0;
        //private int idChiPhi;
        //private int idPhongBan;
        //public int SoChungTu;
        //public string SoPX ;
        //public string NguoiXuat;
        //public string PhieuXuat;
        //public DateTime NgayLap;
        //public string DienGiai;
        //public DateTime ThoiGian;
        //public int TrangThai;

        public frm_DanhSachPhieuDeNghiXuatTHnew()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        private void LoadTrangThai()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            repTrangThai.DataSource = lst;
        }

        public void Delete()
        {
            DeNghiXuatTieuHaoNewBusiness DeNghiXuatTieuHaoBusiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle < 0) return;
            DeNghiXuatTieuHaoBusiness = new DeNghiXuatTieuHaoNewBusiness((ChungTuDeNghiXuatTieuHaoInfornew)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            if(DeNghiXuatTieuHaoBusiness.ChungTu.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO))
            {
                DeNghiXuatTieuHaoBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDuyet.HUY_TIEU_HAO);
                DeNghiXuatTieuHaoBusiness.CancelChungTu();
            }
            else
            {
                clsUtils.MsgThongBao("Chứng từ đã xuất kho, không thể hủy !");
            }
        }
        #region Event

        private void frm_DanhSachPhieuDeNghiXuatTH_Load(object sender, EventArgs e)
        {
            grcDanhSach.DataSource = DeNghiXuatTieuHaoProvidernew.Instance.GetListDeNghiXuatTieuHao();
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = IsSupperUser();
            btnMoPhieu.Text = Resources.btnInfor;
            btnThemPhieu.Text = Resources.btnAdd;
            //btnXoaPhieu.Text = Resources.btnDraft;
            btnDong.Text = Resources.btnClose;
            LoadTrangThai();
        }

        //nếu click dòng mà có cột trạng thái là đã duyệt thì ẩn các nút trên form Phiếu đề nghị
        //còn nếu click dòng mà có cột trạng thái là chưa duyệt thì để nguyên các nút trên form phiếu đề nghị
        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;
                
                var info = ((ChungTuDeNghiXuatTieuHaoInfornew)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
                
                if(CommonProvider.Instance.Lock_ChungTu(info))
                {
                    //var frm = new frm_PhieuDeNghiXuatTieuHaoNew(info.IdChungTu, info.SoChungTu, info.NgayLap.ToString(), "", info.TrangThai, info.GhiChu, info.HoTen,
                    //    info.TenTrungTam, info.TenKho, info.IdTrungTam, info.IdKho, info.IdNhanVien, info.LoaiChungTu, info.IdNguoiQuanLy, info.NguoiQuanLy);
                    
                    var frm = new frm_PhieuDeNghiXuatTieuHaoNew(info);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        grcDanhSach.DataSource = DeNghiXuatTieuHaoProvidernew.Instance.GetListDeNghiXuatTieuHao();
                    }

                    CommonProvider.Instance.UnLock_ChungTu(info);
                } 
                else
                {
                    throw new ManagedException("Chứng từ đã bị lock bởi người dùng khác!");
                }
            }
            catch (ManagedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(new ManagedException(ex.Message, false).Message);
            }
        } 

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiXuatTieuHaoNew frm = new frm_PhieuDeNghiXuatTieuHaoNew();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grcDanhSach.DataSource = DeNghiXuatTieuHaoProvidernew.Instance.GetListDeNghiXuatTieuHao();
            }
        } 
        //xóa theo id chung tu
        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            ActivatedFlag = true;
            if (MessageBox.Show("Bạn có chắc chắn hủy bản ghi này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Delete();
                grcDanhSach.DataSource = DeNghiXuatTieuHaoProvidernew.Instance.GetListDeNghiXuatTieuHao();
                grcDanhSach.RefreshDataSource();
                ActivatedFlag = false;
            }
        } 

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        private void frm_DanhSachPhieuDeNghiXuatTH_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                var info = ((ChungTuDeNghiXuatTieuHaoInfornew)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                info = DeNghiXuatTieuHaoProvidernew.Instance.GetPhieuDeNghiXuatTieuHao(info.IdChungTu);

                if (CommonProvider.Instance.Lock_ChungTu(info))
                {
                    //var frm = new frm_PhieuDeNghiXuatTieuHaoNew(
                    //    info.IdChungTu, info.SoChungTu,
                    //    info.NgayLap.ToString(), "",
                    //    info.TrangThai, info.GhiChu,
                    //    info.HoTen, info.TenTrungTam,
                    //    info.TenKho, info.IdTrungTam,
                    //    info.IdKho, info.IdNhanVien,
                    //    info.LoaiChungTu,
                    //    info.IdNguoiQuanLy,
                    //    info.NguoiQuanLy);

                    var frm = new frm_PhieuDeNghiXuatTieuHaoNew(info);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        grcDanhSach.DataSource = DeNghiXuatTieuHaoProvidernew.Instance.GetListDeNghiXuatTieuHao();
                    }
                    CommonProvider.Instance.UnLock_ChungTu(info);
                }
                else
                {
                    throw new ManagedException("Chứng từ đã bị lock bởi người dùng khác!");
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

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Danh sách đề nghị xuất tiêu hao");
#endif

            }
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //ChungTuDeNghiXuatTieuHaoInfor info = ((ChungTuDeNghiXuatTieuHaoInfor)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            btnMoPhieu.Enabled = true;
            //btnXoaPhieu.Enabled = IsSupperUser();
            //info.TrangThai != 1;
        }
        private bool ActivatedFlag = false;
        private void frm_DanhSachPhieuDeNghiXuatTH_Activated(object sender, EventArgs e)
        {
            if (!ActivatedFlag)
                frm_DanhSachPhieuDeNghiXuatTH_Load(sender, e);
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

    }
}