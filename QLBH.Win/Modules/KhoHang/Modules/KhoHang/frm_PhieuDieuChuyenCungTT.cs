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
using QLBH.Core.Exceptions;

//HanhBD 07/01/2013
namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDieuChuyenCungTT : frm_DieuChuyenBase
    {
        private int idChungTuGoc;
        private int trangThai;
        private int idKhoDieuChuyen;
        private string TenKho;
        private DateTime NgayLap;
       // private string NguoiLap;
        private frm_DanhSachDieuChuyen frm;
        private XuatDieuChuyenBusiness business;
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
        private bool isDaXacNhanNhapKho;
        public frm_PhieuDieuChuyenCungTT(frm_DanhSachDieuChuyen frm) : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.frm = frm;
            dgvChiTiet.AutoGenerateColumns = false;
            business = new XuatDieuChuyenBusiness();
        } 

        public frm_PhieuDieuChuyenCungTT(ChungTuDieuChuyenInfor info)
            : base(info, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new XuatDieuChuyenBusiness(info);
            idChungTuGoc = info.IdChungTu;
            SoChungTu = info.SoChungTu;
            NgayLap = info.NgayLap;
            if (business.ListChiTietHangHoa.Count == 0)
            {
                btnXacNhan.Text = "Import Mã";
                btnXacNhan.Visible = true;
            }
            isDaXacNhanNhapKho = !String.IsNullOrEmpty(DeNghiNhanDieuChuyenDataProvider.Instance.ChungTuDaXacNhanNhapKho(chungTuInfo.SoChungTu));
        }

        public frm_PhieuDieuChuyenCungTT()
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
            business.ListChiTietChungTu = XuatDieuChuyenDataProvider.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
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
            if (chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_XUAT) || chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN)||
                chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN))
            {
                btnThemSP.Enabled = IsSupperUser();
                btnCapNhat.Enabled = IsSupperUser();
                btnThemSP.Enabled = false;
                btnInPhieu.Enabled = true;
                txtNguoiLap.Enabled = IsSupperUser();
                dtNgayLap.Enabled = IsSupperUser();
                txtGhiChu.Enabled = IsSupperUser();
                dtNgayLap.Enabled = IsSupperUser();
                clSoLuong.ReadOnly = IsSupperUser();
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
            DMKhoInfo pt = DeNghiDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKho);
            DMKhoInfo gt = DeNghiDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKhoDieuChuyen);
            if (pt.IdTrungTam == gt.IdTrungTam)
            {
                return true;
            }
            return false;
        }

        protected override void AfterSaveChungTuInstance()
        {
            if (CheckCungTrungTam())
            {
                SaveBusinessNhanDieuChuyen();
            }

            if (CheckDH)
            {
                NhanDieuChuyenDataProvider.Instance.DieuChuyenHangBanDelete(txtSoPhieu.Text);
                foreach (ChungTu_ChiTietHangHoaDCDHInfo info in business.ListChiTietHangHoa)
                {
                    if(!String.IsNullOrEmpty(info.SoChungTuBan))
                    NhanDieuChuyenDataProvider.Instance.InsertDieuChuyenHangBan(info);
                }
            }
        }

        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                base.SaveChungTuInstance();
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN);
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                if(business.ListChiTietHangHoa.Exists(delegate (ChungTu_ChiTietHangHoaBaseInfo match)
                                                          {
                                                              return !match.IsOrigin;
                                                          }))
                {
                    //neu co thay doi ve ma vach thi lay theo ngay nhap xuat moi

                    chungTuInfo.NgayNhapXuatKho = 
                        // neu duoc phep back date thi lay theo ngay back date
                        dtNgayLap.Enabled ? Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"))
                        // neu khong duoc back date thi lay lai theo ngay he thong
                        : CommonProvider.Instance.GetSysDate();
                } 
                else
                {
                    //neu khong thay doi ma vach thi lay theo ngay da duoc thiet lap
                    chungTuInfo.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
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
                    if(chungTuInfo.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_KETOAN_NHAN))
                    business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_XUAT);
                    else
                    {
                        business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN);
                    }
                }
            }
        }

        private void SaveBusinessNhanDieuChuyen()
        {
            ChungTu_ChiTietInfo obj = tbl_ChungTuDAO.Instance.GetIdChungTuBySoPhieu(txtSoPhieu.Text.Trim(), Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN));
            int idChungTu = 0;
            if(obj != null) idChungTu = obj.IdChungTu;

            ChungTuNhapDieuChuyenInfor chungTuNhapDieuChuyenInfor =
                NhanDieuChuyenCungTTDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(chungTuInfo.SoChungTu);
            
            NhanDieuChuyenCungTTBussiness NhanDieuChuyenBussiness = null;

            if(chungTuNhapDieuChuyenInfor != null)
            {
                if (chungTuNhapDieuChuyenInfor.IdNguoiNhapXuatKho == 0)
                {
                    chungTuNhapDieuChuyenInfor.IdNguoiNhapXuatKho = Declare.IdNhanVien;
                }
                chungTuNhapDieuChuyenInfor.LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN);
                chungTuNhapDieuChuyenInfor.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.Text);

                NhanDieuChuyenBussiness = new NhanDieuChuyenCungTTBussiness(chungTuNhapDieuChuyenInfor);
            }
            else
                NhanDieuChuyenBussiness = new NhanDieuChuyenCungTTBussiness(new ChungTuNhapDieuChuyenInfor
                        {
                            //detail của phiếu nhận điều chuyển
                            LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN),
                            IdChungTu = idChungTu,
                            SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyen),
                            SoChungTuGoc = txtSoPhieu.Text.Trim(),
                            NgayNhapXuatKho = CommonProvider.Instance.GetSysDate(), //Convert.ToDateTime(dtNgayLap.Text),
                            IdKho = chungTuInfo.IdKhoDieuChuyen,
                            IdNguoiNhapXuatKho = Declare.IdNhanVien,
                        });

            //chi tiết phiếu nhận điều chuyển
            NhanDieuChuyenBussiness.ListChiTietChungTu.RemoveAll(
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
                    NhanDieuChuyenBussiness.ListChiTietChungTu.Find(
                        delegate(ChungTu_ChiTietInfo match)
                        {
                            return match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                        });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    NhanDieuChuyenBussiness.ListChiTietChungTu.Add(
                        new ChungTu_ChiTietInfo
                            {
                                IdChungTu = idChungTu,
                                IdSanPham = chungTuChiTietInfo.IdSanPham,
                                SoLuong = chungTuChiTietInfo.SoLuong
                            });
                else
                    chiTietHangHoaNhanDieuChuyen.SoLuong = chungTuChiTietInfo.SoLuong;
            }

            NhanDieuChuyenBussiness.ListChiTietHangHoa.RemoveAll(
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
                    NhanDieuChuyenBussiness.ListChiTietHangHoa.Find(
                        delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                            {
                                return match.MaVach == chungTuChiTietInfo.MaVach &&
                                       match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                            });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    NhanDieuChuyenBussiness.ListChiTietHangHoa.Add(
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
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in NhanDieuChuyenBussiness.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in NhanDieuChuyenBussiness.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }

            if (SumChiTietChungTu == SumChiTietMaVach)
            {
                NhanDieuChuyenBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN);
            }
            NhanDieuChuyenBussiness.SaveChungTu();

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
            //btnThemSP.Enabled = HangHoa.IdSanPham < 0;
            //btnXoaSP.Enabled = HangHoa.IdSanPham < 0;
            btnChiTietMaVach.Enabled = HangHoa.IdSanPham > 0;
            //btnCapNhat.Enabled = HangHoa.IdSanPham > 0;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }

        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                if (!isDaXacNhanNhapKho)
                {
                    throw new Exception("Chứng từ này chưa được xác nhận nhập kho, không thể xuất được.");
                }

                if (business.ListChiTietHangHoa.Count == 0)
                    chungTuInfo.IdNguoiNhapXuatKho = Declare.IdNhanVien;
                SCT = tblChungTuDataProvider.CheckSoPhieuByDH(txtSoPhieu.Text, HangHoa.IdSanPham);
                if (SCT.Count == 0)
                {
                    frm_ChiTietPhieuDieuChuyenCungTT frm = new frm_ChiTietPhieuDieuChuyenCungTT(this, HangHoa, liChiTiet, chungTuInfo.IdKho);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        business.MergeChiTietHangHoa(frm.liChiTiet);
                    }
                }
                else
                {
                    CheckDH = true;
                    frm_ChiTietPhieuDieuChuyenCoDH frm = new frm_ChiTietPhieuDieuChuyenCoDH(this, HangHoa, liChiTiet, SoChungTu, HangHoa.IdSanPham, chungTuInfo.IdKhoDieuChuyen);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        business.MergeChiTietHangHoa(frm.liChiTiet);
                    }
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDieuChuyenCungTT));
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bteKhoDen
            // 
            // 
            // bteKhoDi
            // 
            // 
            // bteNguoiVanChuyen
            // 
            // 
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSanPham,
            this.clTenSanPham,
            this.clSoLuong,
            this.clDonGia,
            this.clThanhTien});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 155);
            this.dgvChiTiet.RowHeadersWidth = 25;
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 325);
            this.dgvChiTiet.Enter += new System.EventHandler(this.dgvChiTiet_Enter);
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.Location = new System.Drawing.Point(525, 20);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(117, 127);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(460, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(696, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 128);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Text = "Import Mã";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(117, 20);
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
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
            // frm_PhieuDieuChuyenCungTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Name = "frm_PhieuDieuChuyenCungTT";
            this.Text = "Phiếu xuất điều chuyển";
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
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
                frm_ChiTietPhieuDieuChuyenCungTT frm = new frm_ChiTietPhieuDieuChuyenCungTT(this, HangHoa, liChiTiet, chungTuInfo.IdKho);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                business.MergeChiTietHangHoa(frm.liChiTiet);
                //}
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = XuatDieuChuyenDataProvider.Instance.GetPhieuXuatDieuChuyenDetail(OID);
            rpt_BC_PhieuXuatDieuChuyen rpt = new rpt_BC_PhieuXuatDieuChuyen(chungTuInfo.IdKhoDieuChuyen);
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
    }
}
