using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Modules.BaoHanh;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;

//HanhBD 07/01/2013
namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuXuatDieuChuyen : frm_DieuChuyenKhoBase
    {
        private int idChungTuGoc;
        private int trangThai;
        private int idKhoDieuChuyen;
        private string TenKho;
        private DateTime NgayLap;
       // private string NguoiLap;
        private frm_DanhSachPhieuXuatDieuChuyen frm;
        private XuatDieuChuyenBussiness business;
        private NhapDieuChuyenBussiness NhapDieuChuyenBussiness;
        private List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        private List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet1;
        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn clTenSanPham;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn clDonGia;
        private DataGridViewTextBoxColumn clThanhTien;
        List<ChiTietDieuChuyenDonHangInfo> SCT = new List<ChiTietDieuChuyenDonHangInfo>();
        private bool CheckDH = false;
        List<DMKhoInfo> litype = new List<DMKhoInfo>();
        private GtidButton cmdTmpSave;
        private bool isDaXacNhanNhapKho;
        public frm_PhieuXuatDieuChuyen(frm_DanhSachPhieuXuatDieuChuyen frm)
            : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.frm = frm;
            dgvChiTiet.AutoGenerateColumns = false;
            business = new XuatDieuChuyenBussiness();
        }

        public frm_PhieuXuatDieuChuyen(ChungTuXuatDieuChuyenInfo info)
            : base(info, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new XuatDieuChuyenBussiness(info);
            idChungTuGoc = info.IdChungTu;
            SoChungTu = info.SoChungTu;
            NgayLap = info.NgayLap;
            if (business.ListChiTietHangHoa.Count == 0)
            {
                btnXacNhan.Text = "Import Mã";
                btnXacNhan.Visible = true;
            }
            isDaXacNhanNhapKho = !String.IsNullOrEmpty(DeNghiNhapDieuChuyenDataProvider.Instance.ChungTuDaXacNhanNhapKho(chungTuInfo.SoChungTu));
        }

        public frm_PhieuXuatDieuChuyen()
            : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            btnXacNhan.Text = "Import Mã";
            btnXacNhan.Visible = true;
        }

        protected override void LoadDataInstance()
        {
            base.LoadDataInstance();
            business.ListChiTietChungTu = XuatDieuChuyenKhoDataProvider.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
            dgvChiTiet.DataSource = business.ListChiTietChungTu;
            //btnXoaSP.Enabled = IsSupperUser();
            btnChiTietMaVach.Enabled = IsSupperUser();
            btnThemSP.Enabled = false;
            btnCapNhat.Enabled = IsSupperUser();
            btnInPhieu.Enabled = false;
            if (chungTuInfo.NguoiNhapXuatKho == null)
            {
                txtNguoiLap.Text = Declare.UserName;
            }
            else
            {
                txtNguoiLap.Text = chungTuInfo.NguoiNhapXuatKho;
            }
            if (chungTuInfo.NgayNhapXuatKho == DateTime.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            }
            else
            {
                dtNgayLap.EditValue = chungTuInfo.NgayNhapXuatKho;
            }
            if (chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_KETOAN_NHAN) || 
                chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN)||
                chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN))
            {
                btnThemSP.Enabled = false;
                btnCapNhat.Enabled = false;
                btnThemSP.Enabled = false;
                cmdTmpSave.Enabled = false;
                btnInPhieu.Enabled = true;
                txtNguoiLap.Enabled = false;
                dtNgayLap.Enabled = false;
                txtGhiChu.Enabled = false;
                dtNgayLap.Enabled = false;
                clSoLuong.ReadOnly = false;
            }
            else
            {
                dtNgayLap.Enabled = false; 
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = true;
            }

            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
            {
                //btnXoaSP.Enabled = true;
            }
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
                {
                    throw new ManagedException("Bạn chưa nhập số lượng!");
                }
            }
            foreach (ChungTu_ChiTietInfo pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == 0)
                {
                    throw new ManagedException("Trong danh sách có sản phẩm bạn chưa thêm vào!");
                }
            }

            if(bteKhoDi.Text.StartsWith("BH1") && !bteKhoDen.Text.StartsWith("BH1"))
            {
                foreach (var chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
                {
                    if(XuatDieuChuyenKhoDataProvider.Instance.DangBaoHanh(chungTuChiTietHangHoaBaseInfo.MaVach, 
                        chungTuChiTietHangHoaBaseInfo.IdSanPham))

                        throw new ManagedException(String.Format("Mã vạch '{0}' đang được bảo hành, không thể chuyển được!",
                            chungTuChiTietHangHoaBaseInfo.MaVach));
                }
            }

            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu > SumChiTietMaVach)
            {
                throw new ManagedException("Bạn chưa nhập đủ số mã vạch!");
            }

            return true;
        }

        private bool CheckCungTrungTam()
        {
            DMKhoInfo pt = DeNghiXuatDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKho);
            DMKhoInfo gt = DeNghiXuatDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKhoDieuChuyen);
            if (pt.IdTrungTam == gt.IdTrungTam)
            {
                return true;
            }
            return false;
        }

        protected override void AfterSaveChungTuInstance()
        {
            if (CheckDH)
            {
                NhapDieuChuyenKhoDataProvider.Instance.DieuChuyenHangBanDelete(chungTuInfo.SoChungTu);
                foreach (ChungTu_ChiTietHangHoaBaseInfo info in business.ListChiTietHangHoa)
                {
                    if(info is ChungTu_ChiTietHangHoaDCDHInfo && !String.IsNullOrEmpty(((ChungTu_ChiTietHangHoaDCDHInfo)info).SoChungTuBan))
                        NhapDieuChuyenKhoDataProvider.Instance.InsertDieuChuyenHangBan((ChungTu_ChiTietHangHoaDCDHInfo)info);
                }
            }

            XuatDieuChuyenKhoDAO.Instance.DeleteTmp(business.ChungTu.SoChungTu);
        }

        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                base.SaveChungTuInstance();
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN);
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                //chungTuInfo.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
                if (business.ListChiTietHangHoa.Exists(delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                {
                    return !match.IsOrigin;
                }))
                {
                    //neu co thay doi ve ma vach thi lay theo ngay nhap xuat moi

                    business.ChungTu.NgayNhapXuatKho =
                        // neu duoc phep back date thi lay theo ngay back date
                        dtNgayLap.Enabled ? Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"))
                        // neu khong duoc back date thi lay lai theo ngay he thong
                        : CommonProvider.Instance.GetSysDate();
                }
                else
                {
                    if (dtNgayLap.DateTime == DateTime.MinValue)
                        business.ChungTu.NgayNhapXuatKho = CommonProvider.Instance.GetSysDate();
                    else
                        //neu khong thay doi ma vach thi lay theo ngay da duoc thiet lap
                        business.ChungTu.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.EditValue,
                                                                              new CultureInfo("vi-VN"));
                }
            }
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu == SumChiTietMaVach)
            {
                if(CheckCungTrungTam())
                {
                    business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN);
                }
                else
                {
                    if (business.ChungTu.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT))
                        
                        if (!DeNghiNhapDieuChuyenDataProvider.Instance.ChungTuDaCoPhieuNhan(business.ChungTu.SoChungTu))
                        {
                            if (business.ListChiTietHangHoa.Count > 0)
                                business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_KETOAN_NHAN);
                        }
                        else
                        {
                            if (business.ListChiTietHangHoa.Count > 0)
                                business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN);
                        }
                }
            }
        }

        protected override void SaveChungTu()
        {
            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());
            if (li.Count > 0 && OID == 0)
            {
                txtSoPhieu.Focus();
                throw new ManagedException("Số phiếu đã tồn tại trong hệ thống. Xin hãy kiểm tra lại!");
            }
            if (this.Business == null) this.Business = GetBussiness();

            bool ngayChungTuEnabled = business.ChungTu.NgayNhapXuatKho != (DateTime)dtNgayLap.EditValue && !dtNgayLap.Enabled;

            SaveChungTuInstance();
            
            if (CheckCungTrungTam())
            {
                SaveBusinessNhanDieuChuyen();
            }
            else
            {
                SaveBusinessNhanDieuChuyenTG();
            }

            frmProgress.Instance.Caption = Text;
            frmProgress.Instance.Description = "Đang thực hiện ...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;

            frmProgress.Instance.DoWork(
                delegate
                    {
                        try
                        {
                            frmProgress.Instance.MaxValue = 15;

                            ConnectionUtil.Instance.BeginTransaction();

                            ChungTuBusinessBase clonedBusiness = business.Clone();

                            frmProgress.Instance.Value += 1;

                            if (ngayChungTuEnabled)
                            {
                                ((XuatDieuChuyenBussiness)clonedBusiness).ChungTu.NgayNhapXuatKho = CommonProvider.Instance.GetSysDate();
                            }

                            frmProgress.Instance.Value += 1;

                            clonedBusiness.SaveChungTu();

                            frmProgress.Instance.Value += 1;

                            clonedBusiness = NhapDieuChuyenBussiness.Clone();

                            frmProgress.Instance.Value += 1;

                            if (ngayChungTuEnabled)
                            {
                                ((NhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayNhapXuatKho = CommonProvider.Instance.GetSysDate();

                                frmProgress.Instance.Value += 1;

                            }

                            clonedBusiness.SaveChungTu();

                            frmProgress.Instance.Value += 1;

                            AfterSaveChungTuInstance();

                            frmProgress.Instance.Value += 1;

                            ConnectionUtil.Instance.CommitTransaction();

                            frmProgress.Instance.Description = "Đã xong!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;

                        }
                        catch (Exception ex)
                        {
                            //if(!(ex is ManagedException))
                            {
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Xuất điều chuyển");
                            }

                            ConnectionUtil.Instance.RollbackTransaction();

                            //if(!(ex is ManagedException))
                            {
                                EventLogProvider.Instance.WriteOfflineLog("rollback completed.", "Xuất điều chuyển");
                            }

                            MessageBox.Show(ex.Message);

                            frmProgress.Instance.Description = "Giao dịch không thành công!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;
                        }
                    });

            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //        {
            //            try
            //            {
            //                frmProgress.Instance.MaxValue = 15;

            //                ChungTuBusinessBase clonedBusiness = business.Clone();

            //                frmProgress.Instance.Value += 1;

            //                if (ngayChungTuEnabled)
            //                {
            //                    ((XuatDieuChuyenBussiness)clonedBusiness).ChungTu.NgayNhapXuatKho =
            //                        CommonProvider.Instance.GetSysDate();
            //                }

            //                frmProgress.Instance.Value += 1;

            //                clonedBusiness.SaveChungTu();

            //                frmProgress.Instance.Value += 1;

            //                clonedBusiness = NhapDieuChuyenBussiness.Clone();

            //                frmProgress.Instance.Value += 1;

            //                if (ngayChungTuEnabled)
            //                {
            //                    ((NhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayNhapXuatKho =
            //                        CommonProvider.Instance.GetSysDate();

            //                    frmProgress.Instance.Value += 1;

            //                }
                            
            //                clonedBusiness.SaveChungTu();

            //                frmProgress.Instance.Value += 1;

            //                AfterSaveChungTuInstance();

            //                frmProgress.Instance.Value += 1;

            //            }
            //            catch (Exception ex)
            //            {
            //                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Do Serializable Work In Transaction");
            //                throw;
            //            }
            //        });
            Reload();
        }

        private void SaveBusinessNhanDieuChuyen()
        {
            ChungTu_ChiTietInfo obj = tbl_ChungTuDAO.Instance.GetIdChungTuBySoPhieu(chungTuInfo.SoChungTu, Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN));
            int idChungTu = 0;
            if(obj != null) idChungTu = obj.IdChungTu;

            ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenInfor =
                NhapDieuChuyenKhoDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(chungTuInfo.SoChungTu);

            //NhapDieuChuyenBussiness NhapDieuChuyenBussiness = null;

            if(chungTuNhapDieuChuyenInfor != null)
            {
                if (chungTuNhapDieuChuyenInfor.IdNguoiNhapXuatKho == 0)
                {
                    chungTuNhapDieuChuyenInfor.IdNguoiNhapXuatKho = Declare.IdNhanVien;
                }
                chungTuNhapDieuChuyenInfor.LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN);
                chungTuNhapDieuChuyenInfor.NgayNhapXuatKho = CommonProvider.Instance.GetSysDate(); //Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
                chungTuNhapDieuChuyenInfor.IdKho = chungTuInfo.IdKhoDieuChuyen;
                NhapDieuChuyenBussiness = new NhapDieuChuyenBussiness(chungTuNhapDieuChuyenInfor);
            }
            else
            {
                throw new ManagedException("Không tìm thấy chứng từ nhận điều chuyển!");
            }
                //NhapDieuChuyenBussiness = new NhapDieuChuyenBussiness(new ChungTuNhapDieuChuyenInfo
                //        {
                //            //detail của phiếu nhận điều chuyển
                //            LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                //            IdChungTu = idChungTu,
                //            SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyen),
                //            SoChungTuGoc = txtSoPhieu.Text.Trim(),
                //            NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")), //CommonProvider.Instance.GetSysDate(),
                //            IdKho = chungTuInfo.IdKhoDieuChuyen,
                //            IdNguoiNhapXuatKho = Declare.IdNhanVien,
                //        });

            //chi tiết phiếu nhận điều chuyển
            NhapDieuChuyenBussiness.ListChiTietChungTu.RemoveAll(
                delegate(ChungTu_ChiTietInfo matchRemove)
                {
                    return !business.ListChiTietChungTu.Exists(
                        delegate(ChungTu_ChiTietInfo matchExists)
                        {
                            return matchExists.IdSanPham == matchRemove.IdSanPham;
                        });
                });

            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                ChungTu_ChiTietInfo chiTietHangHoaNhanDieuChuyen =
                    NhapDieuChuyenBussiness.ListChiTietChungTu.Find(
                        delegate(ChungTu_ChiTietInfo match)
                        {
                            return match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                        });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    NhapDieuChuyenBussiness.ListChiTietChungTu.Add(
                        new ChungTu_ChiTietInfo
                            {
                                IdChungTu = idChungTu,
                                IdSanPham = chungTuChiTietInfo.IdSanPham,
                                SoLuong = chungTuChiTietInfo.SoLuong
                            });
                else
                    chiTietHangHoaNhanDieuChuyen.SoLuong = chungTuChiTietInfo.SoLuong;
            }

            NhapDieuChuyenBussiness.ListChiTietHangHoa.RemoveAll(
                delegate(ChungTu_ChiTietHangHoaBaseInfo matchRemove)
                {
                    return !business.ListChiTietHangHoa.Exists(
                        delegate(ChungTu_ChiTietHangHoaBaseInfo matchExists)
                        {
                            return matchExists.IdSanPham == matchRemove.IdSanPham &&
                                   matchExists.MaVach == matchRemove.MaVach;
                        });
                });

            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietInfo in business.ListChiTietHangHoa)
            {
                ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaNhanDieuChuyen =
                    NhapDieuChuyenBussiness.ListChiTietHangHoa.Find(
                        delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                            {
                                return match.MaVach == chungTuChiTietInfo.MaVach &&
                                       match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                            });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    NhapDieuChuyenBussiness.ListChiTietHangHoa.Add(
                        new ChungTu_ChiTietHangHoaBaseInfo
                            {
                                MaVach = chungTuChiTietInfo.MaVach,
                                IdSanPham = chungTuChiTietInfo.IdSanPham,
                                SoLuong = chungTuChiTietInfo.SoLuong,
                                //IdChungTuChiTiet = chungTuChiTietInfo.IdChungTuChiTiet
                            });
                else
                    chiTietHangHoaNhanDieuChuyen.SoLuong = chungTuChiTietInfo.SoLuong;
            }
            //xét trạng thái cho phiếu nhận điều chuyển
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in NhapDieuChuyenBussiness.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in NhapDieuChuyenBussiness.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }

            if (SumChiTietChungTu == SumChiTietMaVach)
            {
                NhapDieuChuyenBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN);
            }
            //hah: khong save o day
            //NhapDieuChuyenBussiness.SaveChungTu();

        }

        private void SaveBusinessNhanDieuChuyenTG()
        {
            ChungTu_ChiTietInfo obj = tbl_ChungTuDAO.Instance.GetIdChungTuBySoPhieu(chungTuInfo.SoChungTu, Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN));
            
            if (obj == null) return;

            int idChungTu = 0;
            if (obj != null) idChungTu = obj.IdChungTu;

            ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenInfor = 
                DeNghiNhapDieuChuyenTGDataProvider.Instance.GetChungTuNhanDCTGBySoCTGoc(chungTuInfo.SoChungTu);
                //NhapDieuChuyenKhoDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(chungTuInfo.SoChungTu);

            //NhapDieuChuyenTGBussiness NhapDieuChuyenTGBussiness = null;

            if (chungTuNhapDieuChuyenInfor != null)
            {
                if (chungTuNhapDieuChuyenInfor.IdNguoiNhapXuatKho == 0)
                {
                    chungTuNhapDieuChuyenInfor.IdNguoiNhapXuatKho = Declare.IdNhanVien;
                }
                chungTuNhapDieuChuyenInfor.LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN_TRUNG_GIAN);
                chungTuNhapDieuChuyenInfor.NgayNhapXuatKho = CommonProvider.Instance.GetSysDate(); //Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
                chungTuNhapDieuChuyenInfor.IdKho = -chungTuInfo.IdKho;
                NhapDieuChuyenBussiness = new NhapDieuChuyenTGBussiness(chungTuNhapDieuChuyenInfor);
            }
            else
            {
                throw new ManagedException("Không tìm thấy chứng từ!");
            }
                //NhapDieuChuyenTGBussiness = new NhapDieuChuyenTGBussiness(new ChungTuNhapDieuChuyenInfo
                //{
                //    //detail của phiếu nhận điều chuyển
                //    LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN_TRUNG_GIAN),
                //    IdChungTu = idChungTu,
                //    SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyenTrungGian),
                //    SoChungTuGoc = txtSoPhieu.Text.Trim(),
                //    NgayNhapXuatKho = CommonProvider.Instance.GetSysDate(), //Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")),
                //    IdKho = -chungTuInfo.IdKho,
                //    IdNguoiNhapXuatKho = Declare.IdNhanVien,
                //});

            //chi tiết phiếu nhận điều chuyển
            NhapDieuChuyenBussiness.ListChiTietChungTu.RemoveAll(
                delegate(ChungTu_ChiTietInfo matchRemove)
                {
                    return !business.ListChiTietChungTu.Exists(
                        delegate(ChungTu_ChiTietInfo matchExists)
                        {
                            return matchExists.IdSanPham == matchRemove.IdSanPham;
                        });
                });

            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                ChungTu_ChiTietInfo chiTietHangHoaNhanDieuChuyen =
                    NhapDieuChuyenBussiness.ListChiTietChungTu.Find(
                        delegate(ChungTu_ChiTietInfo match)
                        {
                            return match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                        });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    NhapDieuChuyenBussiness.ListChiTietChungTu.Add(
                        new ChungTu_ChiTietInfo
                        {
                            IdChungTu = idChungTu,
                            IdSanPham = chungTuChiTietInfo.IdSanPham,
                            SoLuong = chungTuChiTietInfo.SoLuong
                        });
                else
                    chiTietHangHoaNhanDieuChuyen.SoLuong = chungTuChiTietInfo.SoLuong;
            }

            NhapDieuChuyenBussiness.ListChiTietHangHoa.RemoveAll(
                delegate(ChungTu_ChiTietHangHoaBaseInfo matchRemove)
                {
                    return !business.ListChiTietHangHoa.Exists(
                        delegate(ChungTu_ChiTietHangHoaBaseInfo matchExists)
                        {
                            return matchExists.IdSanPham == matchRemove.IdSanPham &&
                                   matchExists.MaVach == matchRemove.MaVach;
                        });
                });

            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietInfo in business.ListChiTietHangHoa)
            {
                ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaNhanDieuChuyen =
                    NhapDieuChuyenBussiness.ListChiTietHangHoa.Find(
                        delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                        {
                            return match.MaVach == chungTuChiTietInfo.MaVach &&
                                   match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                        });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    NhapDieuChuyenBussiness.ListChiTietHangHoa.Add(
                        new ChungTu_ChiTietHangHoaBaseInfo
                        {
                            MaVach = chungTuChiTietInfo.MaVach,
                            IdSanPham = chungTuChiTietInfo.IdSanPham,
                            SoLuong = chungTuChiTietInfo.SoLuong,
                            //IdChungTuChiTiet = chungTuChiTietInfo.IdChungTuChiTiet
                        });
                else
                    chiTietHangHoaNhanDieuChuyen.SoLuong = chungTuChiTietInfo.SoLuong;
            }
            //xét trạng thái cho phiếu nhận điều chuyển
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in NhapDieuChuyenBussiness.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in NhapDieuChuyenBussiness.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }

            if (SumChiTietChungTu == SumChiTietMaVach)
            {
                NhapDieuChuyenBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN);
            }
            
            //hah: khong save o day
            //NhapDieuChuyenTGBussiness.SaveChungTu();

        }

        protected override void GetValuesInstance(int e)
        {
            if (e < 0)
            {
                HangHoa = null;
                return;
            }
            HangHoa.IdSanPham = business.ListChiTietChungTu[e].IdSanPham;
            HangHoa.TenSanPham = business.ListChiTietChungTu[e].TenSanPham;
            HangHoa.SoLuong = business.ListChiTietChungTu[e].SoLuong;
            HangHoa.TrungMaVach = business.ListChiTietChungTu[e].TrungMaVach;
            HangHoa.DonGia = business.ListChiTietChungTu[e].DonGia;
            HangHoa.DonViTinh = business.ListChiTietChungTu[e].TenDonViTinh;
            InDex = e;
            DonViTinh = business.ListChiTietChungTu[e].TenDonViTinh;
            liChiTiet = business.GetListChiTietHangHoaByIdSanPham(business.ListChiTietChungTu[e].IdSanPham);
            if(liChiTiet.Count == 0)
            {
                liChiTiet = XuatDieuChuyenKhoDataProvider.Instance.
                    GetListChiTietHangHoaByIdSanPham(business.ListChiTietChungTu[e].IdSanPham, business.ChungTu.SoChungTu);
            }
            btnXoaSP.Enabled = false;
            btnThemSP.Enabled = false;
            btnChiTietMaVach.Enabled = true;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }

        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                //if (!isDaXacNhanNhapKho)
                //{
                //    throw new Exception("Chứng từ này chưa được xác nhận nhập kho, không thể xuất được.");
                //}

                if (business.ListChiTietHangHoa.Count == 0)
                    chungTuInfo.IdNguoiNhapXuatKho = Declare.IdNhanVien;

                frm_ChiTietPhieuXuatDieuChuyen frm = new frm_ChiTietPhieuXuatDieuChuyen(this, HangHoa, liChiTiet, chungTuInfo.IdKho);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                }

                //SCT = tblChungTuDataProvider.CheckSoPhieuByDH(txtSoPhieu.Text, HangHoa.IdSanPham);
                //if (SCT.Count == 0)
                //{
                //    frm_ChiTietPhieuXuatDieuChuyen frm = new frm_ChiTietPhieuXuatDieuChuyen(this, HangHoa, liChiTiet, chungTuInfo.IdKho);
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        business.MergeChiTietHangHoa(frm.liChiTiet);
                //    }
                //}
                //else
                //{
                //    CheckDH = true;
                //    frm_ChiTietPhieuDieuChuyenCoDH frm = new frm_ChiTietPhieuDieuChuyenCoDH(this, HangHoa, liChiTiet, SoChungTu, HangHoa.IdSanPham, chungTuInfo.IdKhoDieuChuyen);
                //    if (frm.ShowDialog() == DialogResult.OK)
                //    {
                //        business.MergeChiTietHangHoa(frm.liChiTiet);
                //    }
                //}
            }
        }

        protected override void OnDeleteChungTu()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 0)
            {
                throw new Exception("Bạn không có quyền xóa");
            }
            business.ChungTu.TrangThai = 0;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuXuatDieuChuyen));
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdTmpSave = new QLBH.Core.Form.GtidButton();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoNhanCuoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bteKhoDen
            // 
            this.bteKhoDen.TabIndex = 4;
            // 
            // bteKhoDi
            // 
            this.bteKhoDi.TabIndex = 3;
            // 
            // bteNguoiVanChuyen
            // 
            this.bteNguoiVanChuyen.TabIndex = 8;
            // 
            // bteNguoiUyNhiem
            // 
            this.bteNguoiUyNhiem.TabIndex = 10;
            // 
            // bteNguoiKyDuyet
            // 
            this.bteNguoiKyDuyet.TabIndex = 9;
            // 
            // txtHoaDonDC
            // 
            this.txtHoaDonDC.Size = new System.Drawing.Size(308, 21);
            this.txtHoaDonDC.TabIndex = 7;
            // 
            // txtPhuongtien
            // 
            this.txtPhuongtien.TabIndex = 5;
            // 
            // bteKhoNhanCuoi
            // 
            this.bteKhoNhanCuoi.TabIndex = 6;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 19;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSanPham,
            this.clTenSanPham,
            this.clSoLuong,
            this.clDonGia,
            this.clThanhTien});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 177);
            this.dgvChiTiet.RowHeadersWidth = 25;
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 303);
            this.dgvChiTiet.Enter += new System.EventHandler(this.dgvChiTiet_Enter);
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(125, 151);
            this.txtGhiChu.Size = new System.Drawing.Size(816, 21);
            this.txtGhiChu.TabIndex = 11;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(460, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 151);
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 20;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.TabIndex = 18;
            this.btnXacNhan.Text = "Import Mã";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(124, 20);
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
            this.dtNgayLap.Location = new System.Drawing.Point(582, 20);
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(147, 20);
            this.dtNgayLap.TabIndex = 1;
            // 
            // clMaSanPham
            // 
            this.clMaSanPham.DataPropertyName = "MaSanPham";
            this.clMaSanPham.HeaderText = "Mã sản phẩm";
            this.clMaSanPham.MinimumWidth = 150;
            this.clMaSanPham.Name = "clMaSanPham";
            this.clMaSanPham.ReadOnly = true;
            this.clMaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMaSanPham.Width = 150;
            // 
            // clTenSanPham
            // 
            this.clTenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clTenSanPham.DataPropertyName = "TenSanPham";
            this.clTenSanPham.HeaderText = "Tên sản phẩm";
            this.clTenSanPham.MinimumWidth = 200;
            this.clTenSanPham.Name = "clTenSanPham";
            this.clTenSanPham.ReadOnly = true;
            this.clTenSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 50;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clDonGia
            // 
            this.clDonGia.DataPropertyName = "DonGia";
            this.clDonGia.HeaderText = "Đơn giá";
            this.clDonGia.MinimumWidth = 50;
            this.clDonGia.Name = "clDonGia";
            this.clDonGia.ReadOnly = true;
            this.clDonGia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clThanhTien
            // 
            this.clThanhTien.DataPropertyName = "ThanhTien";
            this.clThanhTien.HeaderText = "Thành tiền";
            this.clThanhTien.MinimumWidth = 50;
            this.clThanhTien.Name = "clThanhTien";
            this.clThanhTien.ReadOnly = true;
            this.clThanhTien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmdTmpSave
            // 
            this.cmdTmpSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdTmpSave.Image")));
            this.cmdTmpSave.Location = new System.Drawing.Point(439, 486);
            this.cmdTmpSave.Name = "cmdTmpSave";
            this.cmdTmpSave.ShortCutKey = System.Windows.Forms.Keys.None;
            this.cmdTmpSave.Size = new System.Drawing.Size(101, 25);
            this.cmdTmpSave.TabIndex = 17;
            this.cmdTmpSave.Text = "Lưu nháp";
            this.cmdTmpSave.Click += new System.EventHandler(this.cmdTmpSave_Click);
            // 
            // frm_PhieuXuatDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.cmdTmpSave);
            this.Name = "frm_PhieuXuatDieuChuyen";
            this.Text = "Phiếu xuất điều chuyển";
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.bteKhoNhanCuoi, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.bteKhoDen, 0);
            this.Controls.SetChildIndex(this.txtHoaDonDC, 0);
            this.Controls.SetChildIndex(this.txtPhuongtien, 0);
            this.Controls.SetChildIndex(this.bteNguoiVanChuyen, 0);
            this.Controls.SetChildIndex(this.bteNguoiUyNhiem, 0);
            this.Controls.SetChildIndex(this.bteKhoDi, 0);
            this.Controls.SetChildIndex(this.bteNguoiKyDuyet, 0);
            this.Controls.SetChildIndex(this.cmdTmpSave, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoNhanCuoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
            //    if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
            //        btnXoaSP.Enabled = false;
            //        btnCapNhat.Enabled = dgvChiTiet.Rows.Count > 0;
            //    }
            //}
        }

        private void btnChiTietMaVach_Click(object sender, EventArgs e)
        {
            if (HangHoa != null)
            {
                frm_ChiTietPhieuXuatDieuChuyen frm = new frm_ChiTietPhieuXuatDieuChuyen(this, HangHoa, liChiTiet, chungTuInfo.IdKho);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                business.MergeChiTietHangHoa(frm.liChiTiet);
                //}
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = XuatDieuChuyenDataProvider.Instance.GetPhieuXuatDieuChuyenDetail(OID);
            rpt_BC_PhieuXuatDieuChuyen rpt = new rpt_BC_PhieuXuatDieuChuyen(chungTuInfo);
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    DataSet ds;
                    string sql = String.Empty;

                    using (OleDbConnection oConn = new OleDbConnection())
                    {
                        ds = new DataSet();
                        oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", opf.FileName);
                        oConn.Open();

                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, [SO_LUONG] as SoLuong from [Items$]";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "HangHoaChiTiet");
                        }

                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, SUM([SO_LUONG]) as SoLuong from [Items$] group by [MA_HANG_HOA], [SERIAL]";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "TblCheck");
                        }
                    }

                    foreach (ChungTu_ChiTietInfo chungTuChiTietInfor in business.ListChiTietChungTu)
                    {
                        ////if(san pham khong duoc phep trung ma)
                        ////{
                        ////    ds.Tables["TblCheck"].DefaultView.RowFilter = String.Format("MaSanPham='{0}' and SoLuong > 1", chungTuChiTietInfor.MaSanPham);
                        ////    DataTable tableCheck = ds.Tables["TblCheck"].DefaultView.ToTable("Temp");
                        ////    tableCheck.Rows.Count > 0 throw exception
                        ////}

                        ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        DataTable tableTemp = ds.Tables[0].DefaultView.ToTable("Temp");
                        int slMaVach = 0;
                        foreach (DataRow dataRow in tableTemp.Rows)
                        {
                            slMaVach += Convert.ToInt32(dataRow["SoLuong"]);
                        }
                        if(slMaVach != chungTuChiTietInfor.SoLuong)
                        {
                            throw new Exception("Số lượng mã vạch của mã " + chungTuChiTietInfor.MaSanPham +
                                                " không khớp với số lượng trên phiếu.");
                        }
                    }
                    if (business.ListChiTietHangHoa.Count > 0)
                    {
                        if(MessageBox.Show("Các mã vạch đang tồn tại trên phiếu sẽ bị xóa đi, bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo)==DialogResult.Yes)
                        {
                            business.ListChiTietHangHoa.Clear();
                        }
                    }

                    foreach (ChungTu_ChiTietInfo chungTuChiTietInfor in business.ListChiTietChungTu)
                    {
                        ds.Tables[0].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        DataTable tableTemp = ds.Tables[0].DefaultView.ToTable("Temp");
                        foreach (DataRow dataRow in tableTemp.Rows)
                        {
                            if (dataRow["MaVach"] == DBNull.Value || String.IsNullOrEmpty(Convert.ToString(dataRow["MaVach"])))
                            {
                                throw new ManagedException("Đang có dòng không được nhập mã vạch.");
                            }

                            ChungTu_ChiTietHangHoaBaseInfo chiTietMaVach = business.ListChiTietHangHoa.Find(
                                delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                                {
                                    return
                                        match.MaVach == Convert.ToString(dataRow["MaVach"]);
                                });
                            if (chiTietMaVach == null)
                            {
                                business.ListChiTietHangHoa.Add(
                                    new ChungTu_ChiTietHangHoaBaseInfo
                                    {
                                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                                        MaVach = Convert.ToString(dataRow["MaVach"]),
                                        SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                                        TrungMaVach = chungTuChiTietInfor.TrungMaVach
                                    });
                            }
                            else
                            {
                                chiTietMaVach.SoLuong += Convert.ToInt32(dataRow["SoLuong"]);
                            }
                        }
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
                throw;
            }
        }

        private void dgvChiTiet_Enter(object sender, EventArgs e)
        {
            btnChiTietMaVach.Enabled = true;
        }

        private void cmdTmpSave_Click(object sender, EventArgs e)
        {
            if (business.ListChiTietHangHoa.Count > 0)
            {
                XuatDieuChuyenKhoDataProvider.Instance.DeleteTmpChiTietHangHoa(business.ChungTu.SoChungTu);

                foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
                {
                    XuatDieuChuyenKhoDataProvider.Instance.InsertTmpChiTietHangHoa(chungTuChiTietHangHoaBaseInfo, business.ChungTu.SoChungTu);
                }                
            }
        }
    }
}
