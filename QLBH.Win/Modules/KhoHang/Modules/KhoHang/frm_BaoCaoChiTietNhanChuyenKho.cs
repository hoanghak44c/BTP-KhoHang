using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoChiTietNhanChuyenKho : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private int idChungTu = 0;
        private int IdTrungTam ;
        private string MaTrungTam;
        private string MaKho;
        public int SoChungTu;
        public string SoPX;
        public string NguoiLap;
        public string PhieuXuat;
        public DateTime NgayLap;
        public string DienGiai;
        public DateTime ThoiGian;
        public int TrangThai;
        public string SoCTG;
        public string TenKho;
        public int IdKhoDieuChuyen;
        private List<BCChiTietHangChuyenKhoInfo> lstBC;
        //private ChungTuDieuChuyenInfor lstDNDC;
        List<LookUp> lst = new List<LookUp>();
        [Serializable]
        public class LookUp
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        public frm_BaoCaoChiTietNhanChuyenKho()
        {
            InitializeComponent();
            //if (IsSupperUser())
            //{grcBCHangChuyenKho.ContextMenuStrip = new ContextMenuStrip();}
        }
        private void LoadLoaiChungTu()
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            lst.Add(new TrangThaiBH { Id = 0, Name = "Chưa xuất" });
            lst.Add(new TrangThaiBH { Id = 1, Name = "Đã xuất" });
            lst.Add(new TrangThaiBH { Id = 2, Name = "Chờ nhận" });
            lst.Add(new TrangThaiBH { Id = 3, Name = "Đã nhận" });
            lst.Add(new TrangThaiBH { Id = 4, Name = "Chờ nhận (Chưa xuất)" });
            repTrangThaiNhan.DataSource = lst;
        }

        private void frm_BaoCaoChiTietHangChuyenKho_Load(object sender, EventArgs e)
        {
            //fromDate = deFrom.EditValue == null ? DateTime.MinValue : Convert.ToDateTime(deFrom.EditValue);
            //toDate = deTo.EditValue == null ? DateTime.MaxValue : Convert.ToDateTime(deTo.EditValue);
            //lstBC = XuatDieuChuyenDataProvider.Instance.GetBCChiTietChuyenKho(MaTrungTam,MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
            //grcBCHangChuyenKho.DataSource = null;
            //grcBCHangChuyenKho.DataSource = lstBC;
            //if (grcBCHangChuyenKho.ContextMenuStrip != null)
            //{
                //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu đề nghị xuất điều chuyển", null, PhieuDNXuat_Click);
                //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu xuất điều chuyển", null, PhieuXuat_Click);
                //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu đề nghị nhận điều chuyển", null, PhieuDNNhan_Click);
                //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Phiếu nhận điều chuyển", null, PhieuNhan_Click);
                //grcBCHangChuyenKho.ContextMenuStrip.Items.Add("Xóa line mã vạch chứng từ", null, XoaLine_Click);
            //}
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);
            clsUtils.NullColumnDateTimeGrid(repNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayNhap);
            LoadLoaiChungTu();
        }

        private void XoaLine_Click(object sender, EventArgs e)
        {
            try
            {
                string soChungTuXuat =
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).
                        SoPhieuXuat;

                string soChungTuNhan =
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).
                        SoPhieuNhan;

                string maVach =
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).
                        MaVach;

                string maSanPham =
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).
                        MaSanPham;

                int idSanPham =
                    QLBanHang.Modules.DanhMuc.Providers.DmSanPhamProvider.Instance.GetSanPhamByMa(maSanPham).IdSanPham;

                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận xóa mã vạch", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                ConnectionUtil.Instance.BeginTransaction();

                ChungTuDieuChuyenInfor infoXuat =
                    tblChungTuDataProvider.GetChungTuBySoChungTu<ChungTuDieuChuyenInfor>(soChungTuXuat);

                if (!String.IsNullOrEmpty(soChungTuNhan))
                {
                    ChungTuNhapDieuChuyenInfor infoNhap =
                        tblChungTuDataProvider.GetChungTuBySoChungTu<ChungTuNhapDieuChuyenInfor>(soChungTuNhan);

                    NhanDieuChuyenBussiness nhanDieuChuyenBussiness = new NhanDieuChuyenBussiness(infoNhap);
                    DeNghiNhanDieuChuyenBussiness deNghiNhanDieuChuyenBussiness;
                    if (nhanDieuChuyenBussiness.ListChiTietHangHoa.Count > 0)
                    {
                        ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaBaseInfo =
                            nhanDieuChuyenBussiness.ListChiTietHangHoa.Find(delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                            {
                                return match.MaVach == maVach &&
                                       match.IdSanPham == idSanPham;
                            });
                        
                        ChungTu_ChiTietInfo chungTuChiTietInfo =
                            nhanDieuChuyenBussiness.ListChiTietChungTu.Find(delegate(ChungTu_ChiTietInfo match)
                            {
                                return match.IdSanPham == idSanPham;
                            });

                        nhanDieuChuyenBussiness.ListChiTietHangHoa.Remove(chiTietHangHoaBaseInfo);

                        if (chiTietHangHoaBaseInfo.SoLuong == chungTuChiTietInfo.SoLuong)
                        {
                            nhanDieuChuyenBussiness.ListChiTietChungTu.Remove(chungTuChiTietInfo);
                        }
                        else
                        {
                            chungTuChiTietInfo.SoLuong -= chiTietHangHoaBaseInfo.SoLuong;
                        }

                        nhanDieuChuyenBussiness.SaveChungTu();

                        deNghiNhanDieuChuyenBussiness = new DeNghiNhanDieuChuyenBussiness(infoNhap);

                        DeNghiNhanDieuChuyenInfor deNghiNhanDieuChuyenInfor = deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Find(
                            delegate(DeNghiNhanDieuChuyenInfor match)
                            {
                                return match.IdSanPham == idSanPham;
                            });

                        if (chiTietHangHoaBaseInfo.SoLuong == deNghiNhanDieuChuyenInfor.SoLuong)
                        {
                            deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Remove(deNghiNhanDieuChuyenInfor);
                        }
                        else
                        {
                            deNghiNhanDieuChuyenInfor.SoLuong -= chiTietHangHoaBaseInfo.SoLuong;
                        }

                        deNghiNhanDieuChuyenBussiness.SaveChungTu();
                    }
                    else
                    {
                        deNghiNhanDieuChuyenBussiness = new DeNghiNhanDieuChuyenBussiness(infoNhap);

                        DeNghiNhanDieuChuyenInfor deNghiNhanDieuChuyenInfor = deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Find(
                            delegate(DeNghiNhanDieuChuyenInfor match)
                            {
                                return match.IdSanPham == idSanPham;
                            });

                        deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Remove(deNghiNhanDieuChuyenInfor);

                        deNghiNhanDieuChuyenBussiness.SaveChungTu();
                    }
                }

                XuatDieuChuyenBusiness xuatDieuChuyenBusiness = new XuatDieuChuyenBusiness(infoXuat);
                DeNghiDieuChuyenBussiness deNghiDieuChuyenBussiness;

                if (xuatDieuChuyenBusiness.ListChiTietHangHoa.Count > 0)
                {
                    ChungTu_ChiTietInfo chungTuChiTietInfo =
                        xuatDieuChuyenBusiness.ListChiTietChungTu.Find(delegate(ChungTu_ChiTietInfo match)
                        {
                            return match.IdSanPham == idSanPham;
                        });

                    ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaBaseInfo =
                        xuatDieuChuyenBusiness.ListChiTietHangHoa.Find(delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                        {
                            return match.MaVach == maVach &&
                                   match.IdSanPham == idSanPham;
                        });

                    xuatDieuChuyenBusiness.ListChiTietHangHoa.Remove(chiTietHangHoaBaseInfo);

                    if (chiTietHangHoaBaseInfo.SoLuong == chungTuChiTietInfo.SoLuong)
                    {
                        xuatDieuChuyenBusiness.ListChiTietChungTu.Remove(chungTuChiTietInfo);
                    }
                    else
                    {
                        chungTuChiTietInfo.SoLuong -= chiTietHangHoaBaseInfo.SoLuong;
                    }

                    xuatDieuChuyenBusiness.SaveChungTu();

                    deNghiDieuChuyenBussiness = new DeNghiDieuChuyenBussiness(infoXuat);

                    DeNghiDieuChuyenInfor deNghiDieuChuyenInfor = deNghiDieuChuyenBussiness.ListChiTietChungTu.Find(
                        delegate(DeNghiDieuChuyenInfor match)
                        {
                            return match.IdSanPham == idSanPham;
                        });

                    if (chiTietHangHoaBaseInfo.SoLuong == deNghiDieuChuyenInfor.SoLuong)
                    {
                        deNghiDieuChuyenBussiness.ListChiTietChungTu.Remove(deNghiDieuChuyenInfor);
                    }
                    else
                    {
                        deNghiDieuChuyenInfor.SoLuong -= chiTietHangHoaBaseInfo.SoLuong;
                    }

                    deNghiDieuChuyenBussiness.SaveChungTu();
                }

                ConnectionUtil.Instance.CommitTransaction();

                //grcBCNhanChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCChiTietChuyenKho(MaTrungTam, MaKho, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));

            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
        private void PhieuDNXuat_Click(object sender, EventArgs e)
        {
            if (grvBCNhanChuyenKho.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = DeNghiDieuChuyenDataProvider.Instance.GetInforDNDCByIdChungTu(
                    ((BCChiTietHangChuyenKhoInfo) grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).
                        IdPhieuXuat);
            frm_PhieuDeNghiDieuChuyenCungTT frm = new frm_PhieuDeNghiDieuChuyenCungTT(info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //grcBCNhanChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCChiTietChuyenKho(bteTrungTam.Text, bteKho.Text, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
            }
        }
        private void PhieuXuat_Click(object sender, EventArgs e)
        {
            if (grvBCNhanChuyenKho.FocusedRowHandle < 0) return;
            ChungTuDieuChuyenInfor info = DeNghiDieuChuyenDataProvider.Instance.GetInforDNDCByIdChungTu(
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).
                        IdPhieuXuat);
            frm_PhieuDieuChuyenCungTT frm = new frm_PhieuDieuChuyenCungTT(info);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //grcBCNhanChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCChiTietChuyenKho(bteTrungTam.Text, bteKho.Text, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
            }
        }
        private void PhieuDNNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBCNhanChuyenKho.FocusedRowHandle < 0) return;
                if(((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).IdPhieuNhan == 0)
                {
                    MessageBox.Show("Chưa có phiếu nhận!");
                    return;
                }
                ChungTuNhapDieuChuyenInfor info = DeNghiNhanDieuChuyenDataProvider.Instance.GetInforDNNDCByIdChungTu(
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).IdPhieuNhan);
                frm_PhieuDeNghiNhanDieuChuyenNew frm = new frm_PhieuDeNghiNhanDieuChuyenNew(info);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //grcBCNhanChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCChiTietChuyenKho(bteTrungTam.Text, bteKho.Text, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PhieuNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvBCNhanChuyenKho.FocusedRowHandle < 0) return;
                if (((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).IdPhieuNhan == 0)
                {
                    MessageBox.Show("Chưa có phiếu nhận!");
                    return;
                }
                ChungTuNhapDieuChuyenInfor info = DeNghiNhanDieuChuyenDataProvider.Instance.GetInforDNNDCByIdChungTu(
                    ((BCChiTietHangChuyenKhoInfo)grvBCNhanChuyenKho.GetRow(grvBCNhanChuyenKho.FocusedRowHandle)).IdPhieuNhan);
                frm_PhieuNhanDieuChuyen frm = new frm_PhieuNhanDieuChuyen(info);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //grcBCNhanChuyenKho.DataSource = XuatDieuChuyenDataProvider.Instance.GetBCChiTietChuyenKho(bteTrungTam.Text, bteKho.Text, Convert.ToDateTime(deFrom.EditValue), Convert.ToDateTime(deTo.EditValue));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDuLieu()
        {
            frmProgress.Instance.Description = "Đang load dữ liệu";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.DoWork(LoadDataSource);
            grcBCNhanChuyenKho.DataSource = null;
            grcBCNhanChuyenKho.DataSource = lstBC;
        }

        private void LoadDataSource()
        {
            try
            {
                if (bteTrungTam.Text == null) throw new ManagedException("Bạn chưa chọn trung tâm!");
                //if (bteKho.Tag == null) throw new ManagedException("Bạn chưa chọn kho!");
                lstBC = NhanDieuChuyenDataProvider.Instance.GetBCChiTietNhanChuyenKho(bteTrungTam.Text, bteKho.Text,
                    deFrom.EditValue == null ? new DateTime(2013, 5, 1) : Convert.ToDateTime(deFrom.EditValue),
                    deTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deTo.EditValue),
                    deNXFrom.EditValue == null ? new DateTime(2013, 5, 1) : Convert.ToDateTime(deNXFrom.EditValue),
                    deNXTo.EditValue == null ? CommonProvider.Instance.GetSysDate() : Convert.ToDateTime(deNXTo.EditValue));
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            frmProgress.Instance.Description = "Đã xong";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadDuLieu();
            LoadLoaiChungTu();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //grcBCHangChuyenKho.ShowPrintPreview();
            //Common.DevExport2Excel(grvBCNhanChuyenKho);
            Common.Export2ExcelFromDevGrid<BCChiTietHangChuyenKhoInfo>(grvBCNhanChuyenKho, "BCChiTietNhanChuyenKho");
        }
        #region bteKho
        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);
            if(frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.EditValue = String.Empty;
                bteKho.Tag = frmLookUpKho.SelectedItem;
                //bteKho.Text = frmLookUpKho.SelectedItem.TenKho;
                //MaKho = frmLookUpKho.SelectedItem.MaKho;
                foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                {
                    bteKho.EditValue += selectedItem.MaKho + ", ";
                }
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);
                if (frmLookUpKho.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frmLookUpKho.SelectedItem;
                    //bteKho.Text = frmLookUpKho.SelectedItem.TenKho;
                    //MaKho = frmLookUpKho.SelectedItem.MaKho;
                    foreach (DMKhoInfo selectedItem in frmLookUpKho.SelectedItems)
                    {
                        bteKho.EditValue += selectedItem.MaKho + ", ";
                    }
                }                
            }
        }

        private void bteKho_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKho.Text)) bteKho.Tag = null;
        }
        #endregion

        #region bteTrungTam
        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.EditValue = String.Empty;
                bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                //bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
                //IdTrungTam = frmLookUpTrungTam.SelectedItem.IdTrungTam;
                bteKho.Text = "";
                foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
                {
                    bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
                }
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true, String.Format("%{0}%", bteTrungTam.Text),Declare.IdNhanVien);
                if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                    bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                    //MaTrungTam = frmLookUpTrungTam.SelectedItem.MaTrungTam;
                    //IdTrungTam = frmLookUpTrungTam.SelectedItem.IdTrungTam;
                    bteKho.Text = "";
                    foreach (DMTrungTamInfor selectedItem in frmLookUpTrungTam.SelectedItems)
                    {
                        bteTrungTam.EditValue += selectedItem.MaTrungTam + ", ";
                    }
                }
            }
        }

        private void bteTrungTam_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteTrungTam.Text)) bteTrungTam.Tag = null;
        }
        #endregion 

       
    }
}