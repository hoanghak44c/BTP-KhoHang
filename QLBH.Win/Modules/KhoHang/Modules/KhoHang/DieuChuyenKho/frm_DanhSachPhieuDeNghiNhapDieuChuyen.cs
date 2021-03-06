using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuDeNghiNhapDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        public int SoChungTu;
        public string SoPX;
        public string NguoiLap;
        public string PhieuXuat;
        public string DienGiai;
        public DateTime ThoiGian;
        public int TrangThai;
        public string SoCTG;
        public string TenKho;
        public int IdKhoDieuChuyen;

        private string idKho, soGiaoDich, trangThai;
        private DateTime ngayGiaoDich;

        private List<ChungTuNhapDieuChuyenInfo> lstSource;
        //Downline
        //danh sách hiện ra cả 3 loại chứng từ : Đề nghị nhận điều chuyển, nhận điều chuyển, đề nghị xuất điều chuyển tương ứng với trạng thái chờ nhân, đã nhận
        //khi click vào phiếu đề nghị xuất điều chuyển sẽ hiển thị ra form phiếu đề nghị nhận điều chuyển , load ra luôn số chứng từ gốc 
        //khi click vào phiếu đề nghị nhân điều chuyển sẽ hiển thị ra form phiếu đề nghị nhận điều chuyển như bình thường
        //khi click vào phiếu nhận điều chuyển sẽ hiển thị ra form phiếu đề nghị nhận điều chuyển
        public frm_DanhSachPhieuDeNghiNhapDieuChuyen()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            lstSource = new List<ChungTuNhapDieuChuyenInfo>();
            grcDanhSach.DataSource = lstSource;
        }

        public void Delete()
        {
            DeNghiNhapDieuChuyenBussiness DeNghiNhanDieuChuyenBusiness;
            //- lay infor nhap noi bo tren danh sach grid
            if (grvDanhSach.FocusedRowHandle < 0) return;
            DeNghiNhanDieuChuyenBusiness = new DeNghiNhapDieuChuyenBussiness((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            DeNghiNhanDieuChuyenBusiness.DeleteChungTu();
        }

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            ChungTuNhapDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                if (!CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    return;
                }
                
                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = NhapDieuChuyenKhoDataProvider.Instance.GetChungTuNhanDieuChuyenById(info.IdChungTu);

                if (info.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN)
                    || info.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
                {
                    PhieuXuat = info.SoChungTu;
                    DienGiai = info.GhiChu;
                    SoCTG = info.SoChungTuGoc;
                    TrangThai = info.TrangThai;
                    NguoiLap = info.NguoiLap;
                    TenKho = info.TenKho;
                }
                else
                {
                    frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy!");
                }

                frm_PhieuDeNghiNhapDieuChuyen frm = new frm_PhieuDeNghiNhapDieuChuyen(info);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frmProgress.Instance.DoWork(LoadData);
                }

                CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);
            }
            catch (ManagedException ex)
            {
                try
                {
                    if (info != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                try
                {
                    if (info != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

                }
                catch (Exception) { }

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }

        }

        private void LoadData()
        {
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.Caption = Text;

            lstSource.Clear();

            Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });

            idKho = String.Empty;

            var lstKho = DMKhoDataProvider.GetListDMKhoInfor();

            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                idKho += ((NguoiDungInfor)Declare.USER_INFOR).IsOnline ||
                         ((NguoiDungInfor)Declare.USER_INFOR).IsKinhDoanhThiTruong ||
                         ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan == nguoiDungInfor.IdTrungTam
                             ? nguoiDungInfor.IdKho + ","
                             : String.Empty;

                if (!((NguoiDungInfor)Declare.USER_INFOR).IsOnline &&
                    !((NguoiDungInfor)Declare.USER_INFOR).IsKinhDoanhThiTruong &&
                    ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan != nguoiDungInfor.IdTrungTam)
                {
                    var khoInfo = lstKho.Find(delegate(DMKhoInfo match)
                    { return match.IdKho == nguoiDungInfor.IdKho; });
                    if (khoInfo != null)
                    {
                        string otherTrungTam = khoInfo.OtherTrungTam;
                        if (!String.IsNullOrEmpty(otherTrungTam) &&
                            otherTrungTam.Contains(String.Format(",{0},",
                            ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan)))
                        {
                            idKho += nguoiDungInfor.IdKho + ",";
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(soGiaoDich) && !String.IsNullOrEmpty(trangThai) && ngayGiaoDich == DateTime.MinValue)
            {
                frmProgress.Instance.MaxValue = 32;

                ngayGiaoDich = Declare.SYSDATE.AddDays(-31);

                var minDate = NhapDieuChuyenKhoDataProvider.Instance.GetMinDate(idKho, trangThai);

                if (minDate > DateTime.MinValue)
                {
                    if (minDate > ngayGiaoDich)
                    {
                        frmProgress.Instance.Value += (int)(minDate.Date - ngayGiaoDich.Date).TotalDays;

                        ngayGiaoDich = minDate;
                    }

                    while (ngayGiaoDich <= Declare.SYSDATE)
                    {
                        lstSource.AddRange(NhapDieuChuyenKhoDataProvider.
                            GetFillterDeNghiNhanDieuChuyen(idKho, soGiaoDich,
                                                             ngayGiaoDich,
                                                             trangThai));

                        Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });

                        ngayGiaoDich = ngayGiaoDich.AddDays(1);

                        frmProgress.Instance.Value += 1;
                    }                    
                }
            }
            else
            {
                lstSource.AddRange(NhapDieuChuyenKhoDataProvider.
                    GetFillterDeNghiNhanDieuChuyen(idKho, soGiaoDich,
                                                     ngayGiaoDich,
                                                     trangThai));

                Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });                
            }
            frmProgress.Instance.Description = "Đã xong!";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;    
        }

        private void frm_DanhSachDeNghiNhanDieuChuyen_Load(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = false;
            //btnThemPhieu.Enabled = false;
            btnThemPhieu.Text = Resources.btnAdd;
            btnMoPhieu.Text = Resources.btnInfor;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnDong.Text = Resources.btnClose;
            cboTrangThai.SelectedIndex = 1;
            dteNgayThucHien.Checked = false;
            clsUtils.NullColumnDateTimeGrid(repNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayNhan);

            soGiaoDich = txtSoGiaoDich.Text;
            trangThai = cboTrangThai.Text;
            ngayGiaoDich = String.IsNullOrEmpty(txtSoGiaoDich.Text)
                                        ? dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                                          !dteNgayThucHien.ShowCheckBox
                                              ? dteNgayThucHien.Value
                                              : DateTime.MinValue
                                        : DateTime.MinValue;

            frmProgress.Instance.DoWork(LoadData); 
        }

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiNhapDieuChuyen frm = new frm_PhieuDeNghiNhapDieuChuyen();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frmProgress.Instance.DoWork(LoadData);
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {
            return;
//            ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenInfo = null;
//            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo = null;

//            if (MessageBox.Show("Bạn có chắc chắn sẽ hủy giao dịch điều chuyển này không?", "Xác nhận",
//                                    MessageBoxButtons.YesNo,
//                                    MessageBoxIcon.Question,
//                                    MessageBoxDefaultButton.Button2) == DialogResult.No) return;

//            try
//            {
//                if (grvDanhSach.FocusedRowHandle < 0) return;

//                chungTuNhapDieuChuyenInfo = ((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

//                CommonProvider.Instance.Check_Lock_ChungTu(chungTuNhapDieuChuyenInfo.IdChungTu);

//                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 1))
//                {
//                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể hủy được!");
//                }

//                chungTuXuatDieuChuyenInfo =
//                    DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenBySoChungTu(
//                        chungTuNhapDieuChuyenInfo.SoChungTuGoc);

//                if(chungTuXuatDieuChuyenInfo == null) 
//                    throw new ManagedException(String.Format("Chứng từ gốc {0} không tồn tại!", chungTuNhapDieuChuyenInfo.SoChungTuGoc));

//                CommonProvider.Instance.Check_Lock_ChungTu(chungTuXuatDieuChuyenInfo.IdChungTu);

//                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 1))
//                {
//                    throw new ManagedException(
//                        String.Format("Chứng từ gốc {0} đã bị khóa bởi người dùng khác, không thể hủy được!",
//                                      chungTuNhapDieuChuyenInfo.SoChungTuGoc));
//                }

//                chungTuNhapDieuChuyenInfo =
//                    DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDieuChuyenById(
//                        chungTuNhapDieuChuyenInfo.IdChungTu);

//                if (chungTuNhapDieuChuyenInfo == null ||
//                    chungTuNhapDieuChuyenInfo.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN) &&
//                    chungTuNhapDieuChuyenInfo.LoaiChungTu != Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
//                {
//                    frmProgress.Instance.DoWork(LoadData);

//                    throw new ManagedException("Chứng từ đã bị hủy!");
//                }

//                //neu co chung tu nhan dieu chuyen, thi khong huy duoc.
//                if (chungTuNhapDieuChuyenInfo.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN) ||
//                    NhapDieuChuyenKhoDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(chungTuNhapDieuChuyenInfo.IdChungTu).Count > 0)

//                    throw new ManagedException("Đã nhận điều chuyển, không thể hủy được!");

//                ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenTgInfo =
//                    DeNghiXuatDieuChuyenTGDataProvider.Instance.GetChungTuXuatDCTGBySoCTGoc(
//                        chungTuNhapDieuChuyenInfo.SoChungTu);

//                DeNghiXuatDieuChuyenTGBussiness deNghiXuatDieuChuyenTgBussiness = null;

//                DeNghiNhapDieuChuyenBussiness deNghiNhapDieuChuyenBussiness = null;

//                ChungTuBusinessBase businessCloned;

//                if (chungTuNhapDieuChuyenInfo.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN) &&
//                    NhapDieuChuyenKhoDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(chungTuNhapDieuChuyenInfo.IdChungTu).Count == 0)
//                {
//                    if (chungTuXuatDieuChuyenTgInfo != null)
//                    {
//                        deNghiXuatDieuChuyenTgBussiness =
//                            new DeNghiXuatDieuChuyenTGBussiness(chungTuXuatDieuChuyenTgInfo)
//                            {
//                                ChungTu =
//                                {
//                                    TrangThai =
//                                        Convert.ToInt32(
//                                            TrangThaiDieuChuyen.
//                                                HUY_DIEU_CHUYEN),
//                                    LoaiChungTu =
//                                        -Convert.ToInt32(
//                                            TransactionType.
//                                                DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN)
//                                }
//                            };
//                    }

//                    deNghiNhapDieuChuyenBussiness =
//                        new DeNghiNhapDieuChuyenBussiness(chungTuNhapDieuChuyenInfo)
//                        {
//                            ChungTu =
//                            {
//                                TrangThai =
//                                    Convert.ToInt32(
//                                        TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
//                                LoaiChungTu =
//                                    -Convert.ToInt32(
//                                        TransactionType.
//                                            DE_NGHI_XUAT_DIEU_CHUYEN)
//                            }
//                        };

//                }

//                chungTuXuatDieuChuyenInfo.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_HUY_DIEU_CHUYEN);

//                ConnectionUtil.Instance.DoSerializableWorkInTransaction(
//                    delegate
//                        {
//                            //Set trang thai cho huy cho phieu xuat

//                            if(DeNghiXuatDieuChuyenDataProvider.Instance.
//                                UpdateTrangThaiHuyChungTu(chungTuXuatDieuChuyenInfo)== 0)
//                            {
//                                throw new ManagedException("Chứng từ gốc đã bị lock bởi ứng dụng khác, không thể thực hiện được.");
//                            }

//                            //Huy de nghi xuat dieu chuyen trung gian);

//                            if (deNghiXuatDieuChuyenTgBussiness != null)
//                            {
//                                businessCloned = deNghiXuatDieuChuyenTgBussiness.Clone();

//                                businessCloned.CancelChungTu();
//                            }

//                            //Huy de nghi nhan dieu chuyen

//                            if (deNghiNhapDieuChuyenBussiness != null)
//                            {
//                                businessCloned = deNghiNhapDieuChuyenBussiness.Clone();

//                                businessCloned.CancelChungTu();
//                            }
//                        }
//                    );

//                frmProgress.Instance.DoWork(LoadData);

//                CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);
//                CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 0);

//            }
//            catch (ManagedException ex)
//            {
//                try
//                {
//                    CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);
//                    CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 0);
//                }
//                catch (Exception) { }

//                MessageBox.Show(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                try
//                {
//                    CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);
//                    CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 0);
//                }
//                catch (Exception) { }

//                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);

//#if DEBUG
//                MessageBox.Show(ex.ToString());
//#else
//                MessageBox.Show(ex.Message);
//#endif
//            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frm_DanhSachDeNghiNhanDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            ChungTuNhapDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                if (!CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    return;
                }

                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = NhapDieuChuyenKhoDataProvider.Instance.GetChungTuNhanDieuChuyenById(info.IdChungTu);

                if (info.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN)
                    || info.LoaiChungTu == Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN))
                {
                    PhieuXuat = info.SoChungTu;
                    DienGiai = info.GhiChu;
                    SoCTG = info.SoChungTuGoc;
                    TrangThai = info.TrangThai;
                    NguoiLap = info.NguoiLap;
                    TenKho = info.TenKho;
                    IdKhoDieuChuyen = info.IdKhoDieuChuyen;
                }
                else
                {
                    frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy!");
                }

                frm_PhieuDeNghiNhapDieuChuyen frm = new frm_PhieuDeNghiNhapDieuChuyen(info);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frmProgress.Instance.DoWork(LoadData);
                }

                CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

            }
            catch (ManagedException ex)
            {
                try
                {
                    if (info != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                try
                {
                    if (info != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);

                }
                catch (Exception) { }

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            
        }

        private void grvDanhSach_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnXoaPhieu.Enabled = ConnectionUtil.Instance.IsUAT == 3;
        }
       
        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            soGiaoDich = txtSoGiaoDich.Text;
            trangThai = cboTrangThai.Text;
            ngayGiaoDich = String.IsNullOrEmpty(txtSoGiaoDich.Text)
                                        ? dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                                          !dteNgayThucHien.ShowCheckBox
                                              ? dteNgayThucHien.Value
                                              : DateTime.MinValue
                                        : DateTime.MinValue;

            frmProgress.Instance.DoWork(LoadData);
        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrangThai.Text == "Đã nhận" || String.IsNullOrEmpty(cboTrangThai.Text))
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