using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Core;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Common.Providers;


// form frmDanhSachDeNghiDieuChuyen
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 20/07/2012
// Người sửa cuối:
// Ngày sửa cuối:
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_DanhSachPhieuDeNghiXuatDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        private List<ChungTuXuatDieuChuyenInfo> lstSource;
        private string idKho, soGiaoDich, trangThai;
        private DateTime ngayGiaoDich;
        private readonly bool isEdit;

        public frm_DanhSachPhieuDeNghiXuatDieuChuyen()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            lstSource = new List<ChungTuXuatDieuChuyenInfo>();
            grcDanhSach.DataSource = lstSource;
            isEdit = false;
            btnEdit.Enabled = false;
            btnXoaPhieu.Enabled = false;
        }

        public frm_DanhSachPhieuDeNghiXuatDieuChuyen(bool isEdit)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            lstSource = new List<ChungTuXuatDieuChuyenInfo>();
            grcDanhSach.DataSource = lstSource;
            this.isEdit = isEdit;
            btnEdit.Enabled = isEdit;
            btnXoaPhieu.Enabled = isEdit;
        }

        public void Delete()
        {
            DeNghiXuatDieuChuyenBussiness deNghiXuatDieuChuyenBusiness = 
                new DeNghiXuatDieuChuyenBussiness((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            
            List<ChungTuXuatDieuChuyenInfo> objXuat = DeNghiXuatDieuChuyenDataProvider.Instance.GetListChiTietChungTuBySoChungTu(deNghiXuatDieuChuyenBusiness.ChungTu.SoChungTu);
            
            if (objXuat.FindAll(delegate(ChungTuXuatDieuChuyenInfo math)
            {
                return math.LoaiChungTu == 21;

            }).Count > 0)
            {
                throw new ManagedException("Chứng từ đã nhập kho thành công, không thể hủy được!");
            }

            //Huy De Nghi nhan dieu chuyen
            DeNghiNhapDieuChuyenBussiness deNghiNhapDieuChuyenBusiness = 
                new DeNghiNhapDieuChuyenBussiness((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            
            List<ChungTuNhapDieuChuyenInfo> objNhan = DeNghiNhapDieuChuyenDataProvider.Instance.GetListChiTietChungTuBySoChungTu(deNghiNhapDieuChuyenBusiness.ChungTu.SoChungTu);
            
            for (int i = 0; i < objNhan.Count; i++)
            {
                if (objNhan[i].LoaiChungTu == 14)
                {
                    DeNghiNhapDieuChuyenBussiness deNghiNhanBusiness = new DeNghiNhapDieuChuyenBussiness(objNhan[i]);
                    deNghiNhanBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                    deNghiNhanBusiness.ChungTu.LoaiChungTu =
                        -Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN);
                    deNghiNhanBusiness.CancelChungTu();
                }
            }
            //Huy De Nghi Xuat dieu chuyen trung gian
            DeNghiXuatDieuChuyenTGBussiness deNghiXuatDieuChuyenTgBusiness 
                = new DeNghiXuatDieuChuyenTGBussiness((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

            List<ChungTuXuatDieuChuyenInfo> objDNXuatTG = DeNghiXuatDieuChuyenTGDataProvider.Instance.GetListChiTietChungTuBySoChungTu(deNghiXuatDieuChuyenTgBusiness.ChungTu.SoChungTu);

            for (int i = 0; i < objXuat.Count; i++)
            {
                if (objNhan[i].LoaiChungTu == 55)
                {
                    DeNghiXuatDieuChuyenTGBussiness DeNghiXuatTGBusiness =
                        new DeNghiXuatDieuChuyenTGBussiness(objDNXuatTG[i]);
                    DeNghiXuatTGBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                    DeNghiXuatTGBusiness.ChungTu.LoaiChungTu =
                        -Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN);
                    DeNghiXuatTGBusiness.CancelChungTu();
                }
            }
            
            //Huy nhap dieu chuyen trug gian
            NhapDieuChuyenTGBussiness NhapDieuChuyenTGBusiness;
            
            NhapDieuChuyenTGBusiness = new NhapDieuChuyenTGBussiness((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            List<ChungTuNhapDieuChuyenInfo> objNhapTG = NhapDieuChuyenKhoTGDataProvider.Instance.GetListChiTietChungTuBySoChungTu(NhapDieuChuyenTGBusiness.ChungTu.SoChungTu);
            for (int i = 0; i < objNhan.Count; i++)
            {
                if (objNhan[i].LoaiChungTu == 54)
                {
                    NhapDieuChuyenTGBussiness NhapTGBusiness = new NhapDieuChuyenTGBussiness(objNhapTG[i]);
                    NhapTGBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                    NhapTGBusiness.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN);
                    NhapTGBusiness.CancelChungTu();
                }
            }
            //Huy De Nghi nhan dieu chuyen trung gian
            DeNghiNhapDieuChuyenTGBussiness DeNghiNhapDieuChuyenTGBusiness;
            if (grvDanhSach.FocusedRowHandle < 0) return;
            DeNghiNhapDieuChuyenTGBusiness = new DeNghiNhapDieuChuyenTGBussiness((ChungTuNhapDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));
            List<ChungTuNhapDieuChuyenInfo> objDNNhapTG = DeNghiNhapDieuChuyenTGDataProvider.Instance.GetListChiTietChungTuBySoChungTu(DeNghiNhapDieuChuyenTGBusiness.ChungTu.SoChungTu);
            for (int i = 0; i < objNhan.Count; i++)
            {
                if (objNhan[i].LoaiChungTu == 53)
                {
                    DeNghiNhapDieuChuyenTGBussiness DeNghiNhapTGBusiness = new DeNghiNhapDieuChuyenTGBussiness(objDNNhapTG[i]);
                    DeNghiNhapTGBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                    DeNghiNhapTGBusiness.ChungTu.LoaiChungTu =
                        -Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN);
                    DeNghiNhapTGBusiness.CancelChungTu();
                }
            }
            //Huy Xuat dieu chuyen
            for (int i = 0; i < objXuat.Count; i++)
            {
                if (objXuat[i].LoaiChungTu == 13)
                {
                    XuatDieuChuyenBussiness XuatDieuChuyenBusiness = new XuatDieuChuyenBussiness(objXuat[i]);
                    XuatDieuChuyenBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                    XuatDieuChuyenBusiness.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN);
                    XuatDieuChuyenBusiness.CancelChungTu();
                }
            }
            // Huy de nghi xuat dieu chuyen
            for (int i = 0; i < objXuat.Count; i++)
            {
                if (objXuat[i].LoaiChungTu == 12)
                {
                    DeNghiXuatDieuChuyenBussiness DeNghiDieuChuyenBusiness = new DeNghiXuatDieuChuyenBussiness(objXuat[i]);
                    DeNghiDieuChuyenBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN);
                    DeNghiDieuChuyenBusiness.ChungTu.LoaiChungTu = -Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN);
                    DeNghiDieuChuyenBusiness.CancelChungTu();
                }
            }
        }
        
        private void LoadData()
        {
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.Caption = Text;

            idKho = String.Empty;

            lstSource.Clear();

            Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });

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
                frmProgress.Instance.MaxValue = 31;
                
                ngayGiaoDich = Declare.SYSDATE.AddDays(-31);

                var minDate = DeNghiXuatDieuChuyenDataProvider.Instance.GetMinDate(idKho, trangThai);

                if (minDate > DateTime.MinValue)
                {
                    if (minDate > ngayGiaoDich)
                    {
                        frmProgress.Instance.Value += (int)(minDate.Date - ngayGiaoDich.Date).TotalDays;

                        ngayGiaoDich = minDate;
                    }

                    while (ngayGiaoDich <= Declare.SYSDATE)
                    {
                        lstSource.AddRange(DeNghiXuatDieuChuyenDataProvider.
                                               GetFillterDeNghiXuatDieuChuyen(idKho, soGiaoDich,
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
                lstSource.AddRange(DeNghiXuatDieuChuyenDataProvider.
                                       GetFillterDeNghiXuatDieuChuyen(idKho, soGiaoDich,
                                                                      ngayGiaoDich,
                                                                      trangThai));

                Invoke((MethodInvoker)delegate { grcDanhSach.RefreshDataSource(); });                
            }
            frmProgress.Instance.Description = "Đã xong!";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;
        }

        private void frm_DanhSachPhieuDieuChuyen_Load(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
            btnThemPhieu.Text = Resources.btnAdd;
            btnXoaPhieu.Text = Resources.btnDelete;
            btnMoPhieu.Text = Resources.btnInfor;
            btnDong.Text = Resources.btnClose;
            cboTrangThai.SelectedIndex = 1;
            dteNgayThucHien.Checked = false;
            clsUtils.NullColumnDateTimeGrid(repNgayLap);
            clsUtils.NullColumnDateTimeGrid(repNgayXuat);
            

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

        private void btnMoPhieu_Click(object sender, EventArgs e)
        {
            ChungTuXuatDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;
                
                info = ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu);

                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(info.IdChungTu);

                if(info == null ||
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN) &&
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy, không thể mở được!");               
                }

                frm_PhieuDeNghiXuatDieuChuyen frm = new frm_PhieuDeNghiXuatDieuChuyen(info, true);
                
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
                    CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);
                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                try
                {
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

        private void btnThemPhieu_Click(object sender, EventArgs e)
        {
            frm_PhieuDeNghiXuatDieuChuyen frm = new frm_PhieuDeNghiXuatDieuChuyen();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                frmProgress.Instance.DoWork(LoadData);
            }
        }

        public bool HuyDieuChuyen(ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo)
        {
            //ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo = null;
            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenTgInfo = null;
            ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenInfo = null;
            ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenTgInfo = null;
            DeNghiXuatDieuChuyenTGBussiness deNghiXuatDieuChuyenTgBussiness = null;
            DeNghiNhapDieuChuyenBussiness deNghiNhapDieuChuyenBussiness = null;
            DeNghiNhapDieuChuyenTGBussiness deNghiNhapDieuChuyenTgBussiness = null;
            NhapDieuChuyenTGBussiness nhapDieuChuyenTgBussiness = null;
            DeNghiXuatDieuChuyenBussiness deNghiXuatDieuChuyenBussiness = null;
            XuatDieuChuyenBussiness xuatDieuChuyenBussiness = null;
            ChungTuBusinessBase businessCloned;
            Exception innerException = null;

            try
            {

                frmProgress.Instance.DoWork(
                    delegate
                    {
                        try
                        {
                            frmProgress.Instance.Description = "Đang thực hiện ...";

                            frmProgress.Instance.MaxValue = 30;

                            CommonProvider.Instance.Check_Lock_ChungTu(chungTuXuatDieuChuyenInfo.IdChungTu);

                            frmProgress.Instance.Value += 1;

                            if (!CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 1))
                            {
                                frmProgress.Instance.Description = "Không hoàn thành!";

                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                                throw new ManagedException(
                                    String.Format("Chứng từ {0} đã bị khóa bởi người dùng khác, không thể hủy được!",
                                                  chungTuXuatDieuChuyenInfo.SoChungTu));
                            }

                            frmProgress.Instance.Value += 1;

                            chungTuXuatDieuChuyenInfo =
                                DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(
                                    chungTuXuatDieuChuyenInfo.IdChungTu);

                            frmProgress.Instance.Value += 1;

                            //ngay xuat kho < sysdate, thi khong huy duoc.
                            if ((chungTuXuatDieuChuyenInfo.LoaiChungTu ==
                                 Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN) ||
                                 XuatDieuChuyenDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(
                                     chungTuXuatDieuChuyenInfo.IdChungTu).Count > 0) &&
                                chungTuXuatDieuChuyenInfo.NgayNhapXuatKho.Date !=
                                CommonProvider.Instance.GetSysDate().Date)
                            {
                                frmProgress.Instance.Description = "Không hoàn thành!";

                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                                throw new ManagedException(
                                    String.Format("Chứng từ đã xuất từ ngày {0}, không thể hủy được!",
                                                  chungTuXuatDieuChuyenInfo.NgayNhapXuatKho.Date));
                            }

                            frmProgress.Instance.Value += 1;

                            if (chungTuXuatDieuChuyenInfo == null ||
                                chungTuXuatDieuChuyenInfo.LoaiChungTu !=
                                Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN) &&
                                chungTuXuatDieuChuyenInfo.LoaiChungTu !=
                                Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
                            {
                                frmProgress.Instance.DoWork(LoadData);

                                frmProgress.Instance.Description = "Không hoàn thành!";

                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                                throw new ManagedException("Chứng từ đã bị hủy!");
                            }

                            frmProgress.Instance.Value += 1;

                            chungTuNhapDieuChuyenInfo =
                                DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(
                                    chungTuXuatDieuChuyenInfo.SoChungTu);

                            frmProgress.Instance.Value += 1;

                            if (chungTuNhapDieuChuyenInfo != null)
                            {
                                if (MessageBox.Show("Đã có đề nghị nhận điều chuyển, bạn có muốn tiếp tục không?",
                                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);

                                    frmProgress.Instance.Description = "Không hoàn thành!";

                                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                                    frmProgress.Instance.IsCompleted = true;

                                    return;
                                }

                                CommonProvider.Instance.Check_Lock_ChungTu(chungTuNhapDieuChuyenInfo.IdChungTu);

                                frmProgress.Instance.Value += 1;

                                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 1))
                                {

                                    throw new ManagedException(
                                        String.Format(
                                            "Chứng từ {0} đã bị khóa bởi người dùng khác, không thể hủy được!",
                                            chungTuNhapDieuChuyenInfo.SoChungTu));
                                }

                                frmProgress.Instance.Value += 1;

                                chungTuNhapDieuChuyenInfo =
                                    DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(
                                        chungTuXuatDieuChuyenInfo.SoChungTu);

                                frmProgress.Instance.Value += 1;

                                //neu co chung tu nhan dieu chuyen, thi khong huy duoc.
                                if (chungTuNhapDieuChuyenInfo.LoaiChungTu ==
                                    Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN) ||
                                    NhapDieuChuyenKhoDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(
                                        chungTuNhapDieuChuyenInfo.IdChungTu).Count > 0)

                                    throw new ManagedException("Đã nhận điều chuyển, không thể hủy được!");

                                frmProgress.Instance.Value += 1;

                                chungTuXuatDieuChuyenTgInfo =
                                    DeNghiXuatDieuChuyenTGDataProvider.Instance.GetChungTuXuatDCTGBySoCTGoc(
                                        chungTuNhapDieuChuyenInfo.SoChungTu);

                                frmProgress.Instance.Value += 1;

                                if (chungTuXuatDieuChuyenTgInfo != null)
                                {
                                    deNghiXuatDieuChuyenTgBussiness =
                                        new DeNghiXuatDieuChuyenTGBussiness(chungTuXuatDieuChuyenTgInfo)
                                        {
                                            ChungTu =
                                            {
                                                TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                                LoaiChungTu = -Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN)
                                            }
                                        };
                                }

                                frmProgress.Instance.Value += 1;

                                deNghiNhapDieuChuyenBussiness =
                                    new DeNghiNhapDieuChuyenBussiness(chungTuNhapDieuChuyenInfo)
                                    {
                                        ChungTu =
                                        {
                                            TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                            LoaiChungTu = -Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN)
                                        }
                                    };

                                frmProgress.Instance.Value += 1;

                            }

                            chungTuNhapDieuChuyenTgInfo =
                                DeNghiNhapDieuChuyenTGDataProvider.Instance.GetChungTuNhanDCTGBySoCTGoc(
                                    chungTuXuatDieuChuyenInfo.SoChungTu);

                            frmProgress.Instance.Value += 1;

                            if (XuatDieuChuyenDataProvider.Instance.GetListChiTietHangHoaByIdChungTu(
                                    chungTuXuatDieuChuyenInfo.IdChungTu).Count > 0 &&
                                (chungTuXuatDieuChuyenInfo.LoaiChungTu ==
                                 Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN) ||
                                 chungTuXuatDieuChuyenInfo.LoaiChungTu ==
                                 Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN)))
                            {
                                if (chungTuNhapDieuChuyenTgInfo != null)
                                {
                                    nhapDieuChuyenTgBussiness =
                                        new NhapDieuChuyenTGBussiness(chungTuNhapDieuChuyenTgInfo)
                                        {
                                            ChungTu =
                                            {
                                                TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                                LoaiChungTu = -Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN_TRUNG_GIAN)
                                            }
                                        };

                                    frmProgress.Instance.Value += 1;

                                    deNghiNhapDieuChuyenTgBussiness =
                                        new DeNghiNhapDieuChuyenTGBussiness(chungTuNhapDieuChuyenTgInfo)
                                        {
                                            ChungTu =
                                            {
                                                TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                                LoaiChungTu = -Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN_TRUNG_GIAN)
                                            }
                                        };

                                    frmProgress.Instance.Value += 1;

                                }

                                xuatDieuChuyenBussiness =
                                    new XuatDieuChuyenBussiness(chungTuXuatDieuChuyenInfo)
                                    {
                                        ChungTu =
                                        {
                                            TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                            LoaiChungTu = -Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)
                                        }
                                    };

                                frmProgress.Instance.Value += 1;

                                deNghiXuatDieuChuyenBussiness =
                                    new DeNghiXuatDieuChuyenBussiness(chungTuXuatDieuChuyenInfo)
                                    {
                                        ChungTu =
                                        {
                                            TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                            LoaiChungTu = -Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)
                                        }
                                    };

                                frmProgress.Instance.Value += 1;

                            }
                            else if (chungTuXuatDieuChuyenInfo.LoaiChungTu ==
                                     Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN))
                            {
                                if (chungTuNhapDieuChuyenTgInfo != null)
                                {
                                    deNghiNhapDieuChuyenTgBussiness =
                                        new DeNghiNhapDieuChuyenTGBussiness(chungTuNhapDieuChuyenTgInfo)
                                        {
                                            ChungTu =
                                            {
                                                TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                                LoaiChungTu = -Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN)
                                            }
                                        };

                                    frmProgress.Instance.Value += 1;

                                }

                                deNghiXuatDieuChuyenBussiness =
                                    new DeNghiXuatDieuChuyenBussiness(chungTuXuatDieuChuyenInfo)
                                    {
                                        ChungTu =
                                        {
                                            TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.HUY_DIEU_CHUYEN),
                                            LoaiChungTu = -Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN)
                                        }
                                    };

                                frmProgress.Instance.Value += 1;

                            }
                            try
                            {
                                ConnectionUtil.Instance.BeginTransaction();

                                frmProgress.Instance.MaxValue = 12;

                                //Huy nhan de nghi nhan dieu chuyen

                                if (deNghiNhapDieuChuyenBussiness != null)
                                {
                                    businessCloned = deNghiNhapDieuChuyenBussiness.Clone();

                                    businessCloned.CancelChungTu();

                                }

                                frmProgress.Instance.Value += 1;

                                //Huy nhan de nghi xuat dieu chuyen trung gian

                                if (deNghiXuatDieuChuyenTgBussiness != null)
                                {
                                    businessCloned = deNghiXuatDieuChuyenTgBussiness.Clone();

                                    businessCloned.CancelChungTu();
                                }

                                frmProgress.Instance.Value += 1;

                                //Huy nhan dieu chuyen trung gian

                                if (nhapDieuChuyenTgBussiness != null)
                                {
                                    businessCloned = nhapDieuChuyenTgBussiness.Clone();

                                    businessCloned.CancelChungTu();
                                }

                                frmProgress.Instance.Value += 1;

                                //Huy de nghi nhan dieu chuyen trung gian

                                if (deNghiNhapDieuChuyenTgBussiness != null)
                                {
                                    businessCloned = deNghiNhapDieuChuyenTgBussiness.Clone();

                                    businessCloned.CancelChungTu();
                                }

                                frmProgress.Instance.Value += 1;

                                //Huy dieu chuyen

                                if (xuatDieuChuyenBussiness != null)
                                {
                                    businessCloned = xuatDieuChuyenBussiness.Clone();

                                    businessCloned.CancelChungTu();
                                }

                                frmProgress.Instance.Value += 1;

                                //Huy de nghi dieu chuyen

                                if (deNghiXuatDieuChuyenBussiness != null)
                                {
                                    businessCloned = deNghiXuatDieuChuyenBussiness.Clone();

                                    businessCloned.CancelChungTu();
                                }

                                frmProgress.Instance.Value += 1;

                                ConnectionUtil.Instance.CommitTransaction();
                            }
                            catch (Exception)
                            {
                                ConnectionUtil.Instance.RollbackTransaction();
                                throw;
                            }

                            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
                            //    delegate
                            //    {
                            //        frmProgress.Instance.MaxValue = 12;

                            //        //Huy nhan de nghi nhan dieu chuyen

                            //        if (deNghiNhapDieuChuyenBussiness != null)
                            //        {
                            //            businessCloned = deNghiNhapDieuChuyenBussiness.Clone();

                            //            businessCloned.CancelChungTu();

                            //        }

                            //        frmProgress.Instance.Value += 1;

                            //        //Huy nhan de nghi xuat dieu chuyen trung gian

                            //        if (deNghiXuatDieuChuyenTgBussiness != null)
                            //        {
                            //            businessCloned = deNghiXuatDieuChuyenTgBussiness.Clone();

                            //            businessCloned.CancelChungTu();
                            //        }

                            //        frmProgress.Instance.Value += 1;

                            //        //Huy nhan dieu chuyen trung gian

                            //        if (nhapDieuChuyenTgBussiness != null)
                            //        {
                            //            businessCloned = nhapDieuChuyenTgBussiness.Clone();

                            //            businessCloned.CancelChungTu();
                            //        }

                            //        frmProgress.Instance.Value += 1;

                            //        //Huy de nghi nhan dieu chuyen trung gian

                            //        if (deNghiNhapDieuChuyenTgBussiness != null)
                            //        {
                            //            businessCloned = deNghiNhapDieuChuyenTgBussiness.Clone();

                            //            businessCloned.CancelChungTu();
                            //        }

                            //        frmProgress.Instance.Value += 1;

                            //        //Huy dieu chuyen

                            //        if (xuatDieuChuyenBussiness != null)
                            //        {
                            //            businessCloned = xuatDieuChuyenBussiness.Clone();

                            //            businessCloned.CancelChungTu();
                            //        }

                            //        frmProgress.Instance.Value += 1;

                            //        //Huy de nghi dieu chuyen

                            //        if (deNghiXuatDieuChuyenBussiness != null)
                            //        {
                            //            businessCloned = deNghiXuatDieuChuyenBussiness.Clone();

                            //            businessCloned.CancelChungTu();
                            //        }

                            //        frmProgress.Instance.Value += 1;

                            //    });

                            frmProgress.Instance.Value += 1;

                            if (chungTuNhapDieuChuyenInfo != null)

                                CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 0);

                            frmProgress.Instance.Value += 1;

                            CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);

                            frmProgress.Instance.Value += 1;

                            frmProgress.Instance.Description = "Đã xong!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;
                        }
                        catch (Exception ex)
                        {
                            innerException = ex;

                            frmProgress.Instance.Description = "Không hoàn thành!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;
                        }
                    });

                if (innerException != null)
                {
                    throw innerException;
                }

                return true;

            }
            catch (ManagedException ex)
            {
                try
                {
                    if (chungTuNhapDieuChuyenInfo != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 0);

                    if (chungTuXuatDieuChuyenInfo != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);
                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);

                return false;

            }
            catch (Exception ex)
            {
                try
                {
                    if (chungTuNhapDieuChuyenInfo != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuNhapDieuChuyenInfo, 0);

                    if (chungTuXuatDieuChuyenInfo != null)
                        CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfo, 0);
                }
                catch (Exception) { }

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);


#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        private void btnXoaPhieu_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn sẽ hủy giao dịch điều chuyển này không?", "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            if (grvDanhSach.FocusedRowHandle < 0) return;

            if((grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle) as ChungTuXuatDieuChuyenInfo) == null) return;

            if(HuyDieuChuyen(grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle) as ChungTuXuatDieuChuyenInfo))
            {
                frmProgress.Instance.DoWork(LoadData);
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_DanhSachDeNghiDieuChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            ChungTuXuatDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu);
                
                if(!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(info.IdChungTu);

                if (info == null ||
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN) &&
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy, không thể mở được!");
                }

                frm_PhieuDeNghiXuatDieuChuyen frm = new frm_PhieuDeNghiXuatDieuChuyen(info, true);
                
                //foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
                //{
                //    idKho += nguoiDungInfor.IdKho + ",";
                //}
                
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
            btnXoaPhieu.Enabled = isEdit;
        }

        private void grcDanhSach_Enter(object sender, EventArgs e)
        {
            btnMoPhieu.Enabled = true;
        }

        private void cmdTimKiem_Click(object sender, EventArgs e)
        {
            soGiaoDich = txtSoGiaoDich.Text;
            ngayGiaoDich = String.IsNullOrEmpty(txtSoGiaoDich.Text)
                                        ? dteNgayThucHien.ShowCheckBox && dteNgayThucHien.Checked ||
                                          !dteNgayThucHien.ShowCheckBox
                                              ? dteNgayThucHien.Value
                                              : DateTime.MinValue
                                        : DateTime.MinValue;
            trangThai = cboTrangThai.Text;

            frmProgress.Instance.DoWork(LoadData);

        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTrangThai.Text == "Đã nhận" || String.IsNullOrEmpty(cboTrangThai.Text))
            {
                dteNgayThucHien.ShowCheckBox = false;
            }
            else
            {
                dteNgayThucHien.ShowCheckBox = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ChungTuXuatDieuChuyenInfo info = null;

            try
            {
                if (grvDanhSach.FocusedRowHandle < 0) return;

                info = ((ChungTuXuatDieuChuyenInfo)grvDanhSach.GetRow(grvDanhSach.FocusedRowHandle));

                CommonProvider.Instance.Check_Lock_ChungTu(info.IdChungTu);

                if (!CommonProvider.Instance.Lock_Unlock_ChungTu(info, 1))
                {
                    throw new ManagedException("Chứng từ đã bị khóa bởi người dùng khác, không thể mở được!");
                }

                info = DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(info.IdChungTu);

                if (info == null ||
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN) &&
                    info.LoaiChungTu != Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
                {
                    frmProgress.Instance.DoWork(LoadData);

                    throw new ManagedException("Chứng từ đã bị hủy, không thể mở được!");
                }

                var frm = new frm_PhieuDeNghiXuatDieuChuyen(info, isEdit);

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
                    CommonProvider.Instance.Lock_Unlock_ChungTu(info, 0);
                }
                catch (Exception) { }

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                try
                {
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.FileName = "DanhSachDeNghiDieuChuyen";

            saveFileDialog.Filter = "Excell 2003 (*.xls)|(*.xls)";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                grvDanhSach.ExportToXls(saveFileDialog.FileName);
            }
        }
    }
}