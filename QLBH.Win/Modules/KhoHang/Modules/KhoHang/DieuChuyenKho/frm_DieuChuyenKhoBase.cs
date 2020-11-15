using System;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DieuChuyenKhoBase : frmChiTiet_ChungTuNhapBase
    {
        protected ChungTuXuatDieuChuyenInfo chungTuInfo;
        protected string SoCTG;
        public frm_DieuChuyenKhoBase()
        {
            InitializeComponent();
        }

        public frm_DieuChuyenKhoBase(ChungTuXuatDieuChuyenInfo info, string soPhieuPrefix):base(soPhieuPrefix)
        {
            InitializeComponent();
            chungTuInfo = info;
            OID = chungTuInfo.IdChungTu;
            SoChungTu = chungTuInfo.SoChungTu;
            SoPO = String.Empty;
            NgayLap = chungTuInfo.NgayLap.ToString();
        }

        public frm_DieuChuyenKhoBase(ChungTuNhapDieuChuyenInfo info, string soPhieuPrefix): base(soPhieuPrefix)
        {
            InitializeComponent();
            chungTuInfo = info;
            OID = chungTuInfo.IdChungTu;
            SoChungTu = chungTuInfo.SoChungTu;
            SoPO = String.Empty;
            NgayLap = chungTuInfo.NgayLap.ToString();
            SoCTG = info.SoChungTuGoc;
        }

        public frm_DieuChuyenKhoBase(string soPhieuPrefix):base(soPhieuPrefix)
        {
            InitializeComponent();
        }

        public frm_DieuChuyenKhoBase(int oid,string sochungtu,string ngaylap,string SoPO): base(oid,sochungtu,ngaylap,SoPO)
        {
            InitializeComponent();
        }

        public frm_DieuChuyenKhoBase(int oid, string sochungtu, string ngaylap, string SoPO, string soPhieuPrefix)
            : base(oid, sochungtu, ngaylap, SoPO, soPhieuPrefix)
        {
            InitializeComponent();
        }

        protected virtual void ChonKhoDen()
        {
            var frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoDen.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                if (DMTrungTamDataProvider.Instance.IsCrossedOU(Declare.IdTrungTamHachToan, frmLookUp.SelectedItem.IdTrungTam))
                {
                    if (MessageBox.Show(String.Format("Kho này thuộc chi nhánh {0}, bạn có chắc chắn không?",
                        frmLookUp.SelectedItem.Tinh), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        bteKhoDen.Tag = frmLookUp.SelectedItem;
                        bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
                        bteKhoNhanCuoi.Tag = frmLookUp.SelectedItem;
                        bteKhoNhanCuoi.Text = frmLookUp.SelectedItem.TenKho;
                    }
                }
                else
                {
                    bteKhoDen.Tag = frmLookUp.SelectedItem;
                    bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
                    bteKhoNhanCuoi.Tag = frmLookUp.SelectedItem;
                    bteKhoNhanCuoi.Text = frmLookUp.SelectedItem.TenKho;
                }
            }            
        }
        
        #region Event bteKhoDen
        private void bteKhoDen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                ChonKhoDen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bteKhoDen_DoubleClick(object sender, EventArgs e)
        {
            ChonKhoDen();
        }

        private void bteKhoDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChonKhoDen();
            }
        }

        private void bteKhoDen_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKhoDen.Text))
            {
                bteKhoDen.Tag = null;
            }
        }
        #endregion 

        protected override void LoadDataInstance()
        {
            //bteKhodi.Enabled = false;
            if (chungTuInfo.IdKhoDieuChuyen != 0)
            {
                DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(chungTuInfo.IdKhoDieuChuyen);
                bteKhoDen.Tag = dmKho;
                bteKhoDen.Text = dmKho.TenKho;
                bteKhoDen.Enabled = false;
            }
            else if (chungTuInfo.TenKho != null && chungTuInfo.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN) ||
                chungTuInfo.TenKho != null && chungTuInfo.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
            {
                bteKhoDen.Text = chungTuInfo.TenKho;
                bteKhoDen.Enabled = false;
            }

            if (chungTuInfo.IdKhoNhanCuoi != 0)
            {
                DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(chungTuInfo.IdKhoNhanCuoi);
                bteKhoNhanCuoi.Tag = dmKho;
                bteKhoNhanCuoi.Text = dmKho.TenKho;
                bteKhoNhanCuoi.Enabled = false;
            }

            if (SoCTG != null)
            {
                ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor =
                    DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(SoCTG);
                if (chungTuXuatDieuChuyenInfor.IdKho != 0)
                {
                    DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(chungTuXuatDieuChuyenInfor.IdKho);
                    bteKhoDi.Text = dmKho.TenKho;
                    bteKhoDi.Enabled = false;
                }
            }
            else if (chungTuInfo.TenKho != null && chungTuInfo.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN) ||
                chungTuInfo.TenKho != null && chungTuInfo.LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
            {
                bteKhoDi.Text = chungTuInfo.TenKho;
                bteKhoDi.Enabled = false;
            }
            else if(chungTuInfo.IdChungTu == 0)
            {
                bteKhoDi.Text = "";
            }

            if(chungTuInfo.GhiChu != null)
            {txtGhiChu.Text = chungTuInfo.GhiChu;}
            else
            {
                txtGhiChu.Text = "";
            }
            if(chungTuInfo.NguoiLap !=null)
            {txtNguoiLap.Text = chungTuInfo.NguoiLap;}
            else
            {
                txtNguoiLap.Text = Declare.UserName;
            }
            txtHoaDonDC.Text = chungTuInfo.HoaDonDC;
            txtPhuongtien.Text = chungTuInfo.PhuongTien;
            if (chungTuInfo.IdNguoiVC != 0)
            {
                DMNhanVienInfo dmNv = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(chungTuInfo.IdNguoiVC);
                bteNguoiVanChuyen.Tag = dmNv;
                bteNguoiVanChuyen.Text = dmNv.HoTen;
            }

            if (chungTuInfo.IdNguoiUyNhiem != 0)
            {
                DMNhanVienInfo dmNv = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(chungTuInfo.IdNguoiUyNhiem);
                bteNguoiUyNhiem.Tag = dmNv;
                bteNguoiUyNhiem.Text = dmNv.HoTen;
            }
            if (chungTuInfo.IdNguoiKyDuyet != 0)
            {
                DMNhanVienInfo dmNv = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(chungTuInfo.IdNguoiKyDuyet);
                bteNguoiKyDuyet.Tag = dmNv;
                bteNguoiKyDuyet.Text = dmNv.HoTen;
            }

            btnXoaSP.Enabled = chungTuInfo.IdChungTu == 0;
            btnThemSP.Enabled = chungTuInfo.IdChungTu == 0;
        }

        protected override void SaveChungTuInstance()
        {
            //chỉ trong trường hợp thêm mới thì mới được ghi những thông tin này
            if(chungTuInfo.IdChungTu == 0)
            {
                chungTuInfo.IdNhanVien = Declare.IdNhanVien;
                chungTuInfo.SoChungTu = txtSoPhieu.Text.Trim();
                chungTuInfo.IdKho = ((DMKhoInfo)bteKhoDi.Tag).IdKho;
                chungTuInfo.IdKhoDieuChuyen = ((DMKhoInfo) bteKhoDen.Tag).IdKho;
            }
            else if (chungTuInfo.IdNguoiNhapXuatKho == 0)
            {
                chungTuInfo.IdNguoiNhapXuatKho = Declare.IdNhanVien;
            }

            chungTuInfo.GhiChu = txtGhiChu.Text.Trim();
            chungTuInfo.IdKhoNhanCuoi = bteKhoNhanCuoi.Tag != null ? ((DMKhoInfo)bteKhoNhanCuoi.Tag).IdKho : ((DMKhoInfo)bteKhoDen.Tag).IdKho;
            chungTuInfo.IdNguoiUyNhiem = bteNguoiUyNhiem.Tag != null ? ((DMNhanVienInfo) bteNguoiUyNhiem.Tag).IdNhanVien : 0;
            chungTuInfo.IdNguoiVC = bteNguoiVanChuyen.Tag != null ? ((DMNhanVienInfo)bteNguoiVanChuyen.Tag).IdNhanVien : 0;
            chungTuInfo.IdNguoiKyDuyet = bteNguoiKyDuyet.Tag != null ? ((DMNhanVienInfo)bteNguoiKyDuyet.Tag).IdNhanVien : 0;
            chungTuInfo.HoaDonDC = txtHoaDonDC.Text;
            chungTuInfo.PhuongTien = txtPhuongtien.Text;
        }

        #region Event bteNguoiVanChuyen
        private void bteNguoiVanChuyen_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiVanChuyen.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNguoiVanChuyen.Tag = frmLookUp.SelectedItem;
                bteNguoiVanChuyen.Text = frmLookUp.SelectedItem.HoTen;
            }
        }

        private void bteNguoiVanChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiVanChuyen.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteNguoiVanChuyen.Tag = frmLookUp.SelectedItem;
                    bteNguoiVanChuyen.Text = frmLookUp.SelectedItem.HoTen;
                }
            }
        }

        private void bteNguoiVanChuyen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiVanChuyen.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNguoiVanChuyen.Tag = frmLookUp.SelectedItem;
                bteNguoiVanChuyen.Text = frmLookUp.SelectedItem.HoTen;
            }

        }
        #endregion

        #region Event bteNguoiUyNhiem
        private void bteNguoiUyNhiem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiUyNhiem.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNguoiUyNhiem.Tag = frmLookUp.SelectedItem;
                bteNguoiUyNhiem.Text = frmLookUp.SelectedItem.HoTen;
            }
        }

        private void bteNguoiUyNhiem_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiUyNhiem.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNguoiUyNhiem.Tag = frmLookUp.SelectedItem;
                bteNguoiUyNhiem.Text = frmLookUp.SelectedItem.HoTen;
            }
        }

        private void bteNguoiUyNhiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiUyNhiem.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteNguoiUyNhiem.Tag = frmLookUp.SelectedItem;
                    bteNguoiUyNhiem.Text = frmLookUp.SelectedItem.HoTen;
                }
            }
        }
        #endregion

        #region Event Nguoikyduyet
        private void bteNguoiKyDuyet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiKyDuyet.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNguoiKyDuyet.Tag = frmLookUp.SelectedItem;
                bteNguoiKyDuyet.Text = frmLookUp.SelectedItem.HoTen;
            }
        }

        private void bteNguoiKyDuyet_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiKyDuyet.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNguoiKyDuyet.Tag = frmLookUp.SelectedItem;
                bteNguoiKyDuyet.Text = frmLookUp.SelectedItem.HoTen;
            }
        }

        private void bteNguoiKyDuyet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhanVien frmLookUp = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiKyDuyet.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteNguoiKyDuyet.Tag = frmLookUp.SelectedItem;
                    bteNguoiKyDuyet.Text = frmLookUp.SelectedItem.HoTen;
                }
            }
        }
        #endregion

        private void bteKhoNhanCuoi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoNhanCuoi.Text));

                if (bteKhoDi.Tag == null)
                {
                    bteKhoDi.Focus();
                    throw new ManagedException("Bạn chưa chọn kho đi");
                }

                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    if (DMKhoDataProvider.Instance.IsCrossedOU(((DMKhoInfo)bteKhoDi.Tag).IdKho, frmLookUp.SelectedItem.IdKho))
                    {
                        bteKhoNhanCuoi.Tag = frmLookUp.SelectedItem;
                        bteKhoNhanCuoi.Text = frmLookUp.SelectedItem.TenKho;
                    }
                    else

                        throw new ManagedException("Kho nhận hàng cuối phải khác chi nhánh với kho xuất");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bteKhoNhanCuoi_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoNhanCuoi.Text));
                
                if (bteKhoDi.Tag == null)
                {
                    bteKhoDi.Focus();
                    throw new ManagedException("Bạn chưa chọn kho đi");
                }

                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    if (DMKhoDataProvider.Instance.IsCrossedOU(((DMKhoInfo)bteKhoDi.Tag).IdKho, frmLookUp.SelectedItem.IdKho))
                    {
                        bteKhoNhanCuoi.Tag = frmLookUp.SelectedItem;
                        bteKhoNhanCuoi.Text = frmLookUp.SelectedItem.TenKho;
                    }
                    else

                        throw new ManagedException("Kho nhận hàng cuối phải khác chi nhánh với kho xuất");
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bteKhoNhanCuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    var frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoNhanCuoi.Text));

                    if (bteKhoDi.Tag == null)
                    {
                        bteKhoDi.Focus();
                        throw new ManagedException("Bạn chưa chọn kho đi");
                    }

                    if (frmLookUp.ShowDialog() == DialogResult.OK)
                    {
                        if (DMKhoDataProvider.Instance.IsCrossedOU(((DMKhoInfo)bteKhoDi.Tag).IdKho, frmLookUp.SelectedItem.IdKho))
                        {
                            bteKhoNhanCuoi.Tag = frmLookUp.SelectedItem;
                            bteKhoNhanCuoi.Text = frmLookUp.SelectedItem.TenKho;
                        }
                        else

                            throw new ManagedException("Kho nhận hàng cuối phải khác chi nhánh với kho xuất");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bteKhoNhanCuoi_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKhoNhanCuoi.Text))

                bteKhoNhanCuoi.Tag = null;
        }
    }
}