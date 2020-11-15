using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
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
using QLBH.Core.Form;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuNhapDieuChuyen : frm_DieuChuyenKhoBase
    {
        private frm_DanhSachPhieuNhapDieuChuyen frm;
        public int idSanPham = 0;
        private int idChungTuGoc,idChungTuChiTiet;
        private int trangThai;
        public string soCTG;
        private DateTime NgayLap;
        private string TenKho;
        private int IdKhoDieuChuyen;
        private List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn clTenSanPham;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn clDonGia;
        private DataGridViewTextBoxColumn clThanhTien;
        private QLBH.Core.Form.GtidTextBox txtSoCTG;
        private Label lblChungTuGoc;
        private NhapDieuChuyenBussiness business;
        XuatDieuChuyenTGBussiness XuatDieuChuyenTGBussiness;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuNhapDieuChuyen));
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoCTG = new QLBH.Core.Form.GtidTextBox();
            this.lblChungTuGoc = new System.Windows.Forms.Label();
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
            this.bteNguoiVanChuyen.TabIndex = 9;
            // 
            // bteNguoiUyNhiem
            // 
            // 
            // bteNguoiKyDuyet
            // 
            this.bteNguoiKyDuyet.TabIndex = 10;
            // 
            // txtHoaDonDC
            // 
            this.txtHoaDonDC.Location = new System.Drawing.Point(125, 98);
            this.txtHoaDonDC.Size = new System.Drawing.Size(99, 21);
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
            this.btnThemSP.TabIndex = 14;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 15;
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
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 180);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 300);
            this.dgvChiTiet.TabIndex = 13;
            this.dgvChiTiet.Enter += new System.EventHandler(this.dgvChiTiet_Enter);
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(125, 153);
            this.txtGhiChu.Size = new System.Drawing.Size(816, 21);
            this.txtGhiChu.TabIndex = 12;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 16;
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 153);
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 20;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.TabIndex = 17;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.TabIndex = 18;
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
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
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.TabIndex = 1;
            // 
            // clMaSanPham
            // 
            this.clMaSanPham.DataPropertyName = "MaSanPham";
            this.clMaSanPham.HeaderText = "Mã sản phẩm";
            this.clMaSanPham.MinimumWidth = 150;
            this.clMaSanPham.Name = "clMaSanPham";
            this.clMaSanPham.ReadOnly = true;
            this.clMaSanPham.Width = 200;
            // 
            // clTenSanPham
            // 
            this.clTenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clTenSanPham.DataPropertyName = "TenSanPham";
            this.clTenSanPham.HeaderText = "Tên sản phẩm";
            this.clTenSanPham.MinimumWidth = 200;
            this.clTenSanPham.Name = "clTenSanPham";
            this.clTenSanPham.ReadOnly = true;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 100;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
            // 
            // clDonGia
            // 
            this.clDonGia.DataPropertyName = "DonGia";
            this.clDonGia.HeaderText = "Đơn giá";
            this.clDonGia.MinimumWidth = 50;
            this.clDonGia.Name = "clDonGia";
            this.clDonGia.ReadOnly = true;
            // 
            // clThanhTien
            // 
            this.clThanhTien.DataPropertyName = "ThanhTien";
            this.clThanhTien.HeaderText = "Thành tiền";
            this.clThanhTien.MinimumWidth = 50;
            this.clThanhTien.Name = "clThanhTien";
            this.clThanhTien.ReadOnly = true;
            // 
            // txtSoCTG
            // 
            this.txtSoCTG.Location = new System.Drawing.Point(290, 98);
            this.txtSoCTG.Name = "txtSoCTG";
            this.txtSoCTG.Size = new System.Drawing.Size(143, 21);
            this.txtSoCTG.TabIndex = 8;
            // 
            // lblChungTuGoc
            // 
            this.lblChungTuGoc.AutoSize = true;
            this.lblChungTuGoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChungTuGoc.Location = new System.Drawing.Point(230, 100);
            this.lblChungTuGoc.Name = "lblChungTuGoc";
            this.lblChungTuGoc.Size = new System.Drawing.Size(54, 16);
            this.lblChungTuGoc.TabIndex = 51;
            this.lblChungTuGoc.Text = "Số CTG";
            // 
            // frm_PhieuNhapDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.txtSoCTG);
            this.Controls.Add(this.lblChungTuGoc);
            this.Name = "frm_PhieuNhapDieuChuyen";
            this.Text = "Phiếu nhận điều chuyển";
            this.Controls.SetChildIndex(this.txtHoaDonDC, 0);
            this.Controls.SetChildIndex(this.txtPhuongtien, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.bteNguoiKyDuyet, 0);
            this.Controls.SetChildIndex(this.bteKhoNhanCuoi, 0);
            this.Controls.SetChildIndex(this.bteNguoiVanChuyen, 0);
            this.Controls.SetChildIndex(this.bteNguoiUyNhiem, 0);
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
            this.Controls.SetChildIndex(this.bteKhoDi, 0);
            this.Controls.SetChildIndex(this.lblChungTuGoc, 0);
            this.Controls.SetChildIndex(this.txtSoCTG, 0);
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

        public frm_PhieuNhapDieuChuyen(frm_DanhSachPhieuNhapDieuChuyen frm)
            : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            this.frm = frm;
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new NhapDieuChuyenBussiness();
        }

        public frm_PhieuNhapDieuChuyen(int oid, string sochungtu, string ngaylap, string sopo)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            business = new NhapDieuChuyenBussiness(new ChungTuNhapDieuChuyenInfo
            {IdChungTu = oid,
                SoChungTu = sochungtu,
                NgayLap = Convert.ToDateTime(ngaylap),
                SoChungTuGoc = sopo});
        }

        public frm_PhieuNhapDieuChuyen(ChungTuNhapDieuChuyenInfo info)
            : base(info, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.soCTG = info.SoChungTuGoc;
            this.NguoiLap = info.NguoiLap;
            this.TenKho = info.TenKho;
            this.IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            this.SoPO = info.SoChungTuGoc;
            this.trangThai = info.TrangThai;
            this.NgayLap = info.NgayLap;
            dgvChiTiet.AutoGenerateColumns = false;
            business = new NhapDieuChuyenBussiness(info);
        }
        //public frm_PhieuNhanDieuChuyen(int oid, string sochungtu, string ngaylap, string sopo, int idChungTuGoc, int TrangThai,string soCTG,string nguoiLap,string tenKho,int idKhoDieuChuyen)
        //    : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuNhanDieuChuyen)
        //{
        //    InitializeComponent();
        //    this.idChungTuGoc = idChungTuGoc;
        //    this.trangThai = TrangThai;
        //    this.soCTG = soCTG;
        //    this.NguoiLap = nguoiLap;
        //    this.TenKho = tenKho;
        //    this.IdKhoDieuChuyen = idKhoDieuChuyen;
        //    business = new NhapDieuChuyenBussiness(new ChungTuNhanDieuChuyenInfor 
        //    { IdChungTu = oid,
        //        SoChungTu = sochungtu, 
        //        NgayLap = Convert.ToDateTime(ngaylap),
        //        SoChungTuGoc = sopo ,
        //        LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN)});
        //}

        public frm_PhieuNhapDieuChuyen()
            : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        
        protected override void LoadDataInstance()
        {
            base.LoadDataInstance();
            business.ListChiTietChungTu = NhapDieuChuyenKhoDataProvider.Instance.GetListChiTietNhanDieuChuyen(OID != 0 ? OID : idChungTuGoc);

            if (!String.IsNullOrEmpty(business.ChungTu.SoChungTuGoc) &&
                business.ListChiTietHangHoa.Count == 0)
            {
                var chungTuXuatDieuChuyenInfo = XuatDieuChuyenKhoDataProvider.Instance.GetChungTuBySoChungTu<ChungTuXuatDieuChuyenInfo>(
                    business.ChungTu.SoChungTuGoc);

                if(DMKhoDataProvider.GetKhoByIdInfo(chungTuXuatDieuChuyenInfo.IdKho).MaKho.StartsWith("TK2"))
                {
                    List<ChungTu_ChiTietHangHoaBaseInfo> lstMaVach =
                        NhapDieuChuyenKhoDataProvider.Instance.
                            GetListNhanDieuChuyenBySoPhieu(business.ChungTu.SoChungTuGoc);

                    foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in lstMaVach)
                    {
                        business.ListChiTietHangHoa.Add(new ChungTu_ChiTietHangHoaBaseInfo
                        {
                            MaVach = chungTuChiTietHangHoaBaseInfo.MaVach,
                            IdSanPham = chungTuChiTietHangHoaBaseInfo.IdSanPham,
                            SoLuong = chungTuChiTietHangHoaBaseInfo.SoLuong
                        });
                    }   
                }
            }

            dgvChiTiet.DataSource = business.ListChiTietChungTu;
            txtNguoiLap.Text = Declare.UserName;
            txtNguoiLap.Text = chungTuInfo.NguoiNhapXuatKho;
            txtSoCTG.Text = ((ChungTuNhapDieuChuyenInfo) chungTuInfo).SoChungTuGoc;
            if (chungTuInfo.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN))
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                dtNgayLap.Enabled = false;
            }
            else
            {
                dtNgayLap.EditValue = Convert.ToString(chungTuInfo.NgayLap);
                dtNgayLap.Enabled = false;
            }
            btnXoaSP.Enabled = false;
            btnThemSP.Enabled = false;
            btnCapNhat.Enabled = true;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN))
            {
                //btnXoaSP.Enabled = IsSupperUser();
                btnCapNhat.Enabled = IsSupperUser();
                btnThemSP.Enabled = false;
                txtNguoiLap.Enabled = IsSupperUser();
                txtGhiChu.Enabled = IsSupperUser();
                dtNgayLap.Enabled = IsSupperUser();
                clSoLuong.ReadOnly = IsSupperUser();
            }
            else
            {
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
            int User = 0;
            if (dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            foreach (ChungTu_ChiTietInfo pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == 0)
                {
                    throw new ManagedException("Trong danh sách có sản phẩm bạn chưa thêm vào!");
                }
            }
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                if (bteKhoDen.Text == nguoiDungInfor.TenKho)
                {
                    User = 1;
                }
            }

            var dmKhoInfo = DMKhoDataProvider.GetKhoByIdInfo(business.ChungTu.IdKho);

            if (dmKhoInfo.IdTrungTam == 5 && //nếu là trung tâm trung chuyển
                
                dmKhoInfo.OtherTrungTam.Contains(((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan.ToString()))
            {
                User = 1;
            }
            else if (dmKhoInfo.IdTrungTam != ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan)
            {
                User = 0;
            }

                

            if (User != 1)
            {
                throw new ManagedException("Bạn không có quyền nhận chứng từ này!");
            }
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in
                    business.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu > SumChiTietMaVach)
            {
                throw new ManagedException("Bạn chưa nhập mã vạch!");
            }
            return true;
        }
        protected override void SaveChungTuInstance()
        {
            Check();
            //if(!IsSupperUser())
            //{
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.IdNguoiNhapXuatKho = Declare.IdNhanVien;
                business.ChungTu.IdKho = chungTuInfo.IdKho;
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN);                
            //}
            business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
            if (Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")) >= Convert.ToDateTime(NgayLap, new CultureInfo("vi-VN")))
            {
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

                    dtNgayLap.EditValue = business.ChungTu.NgayNhapXuatKho;
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
            else
            {
                throw new InvalidOperationException("Ngày nhập kho phải lớn hơn ngày đề nghị nhập!");
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
                business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN);
            }
        }
        private void SaveBusinessXuatDieuChuyenTG()
        {
            ChungTu_ChiTietInfo obj = tbl_ChungTuDAO.Instance.GetIdChungTuBySoPhieu(chungTuInfo.SoChungTu, Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN));
            
            if (obj == null) return;
            
            int idChungTu = 0;
            if (obj != null) idChungTu = obj.IdChungTu;

            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenTGInfor =
                DeNghiXuatDieuChuyenTGDataProvider.Instance.GetChungTuXuatDCTGBySoCTGoc(chungTuInfo.SoChungTu);

            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyen =
                    DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(soCTG);

            if (chungTuXuatDieuChuyenTGInfor != null)
            {
                if (chungTuXuatDieuChuyenTGInfor.IdNguoiNhapXuatKho == 0)
                {
                    chungTuXuatDieuChuyenTGInfor.IdNguoiNhapXuatKho = Declare.IdNhanVien;
                }
                chungTuXuatDieuChuyenTGInfor.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN_TRUNG_GIAN);

                if (dtNgayLap.DateTime == DateTime.MinValue)
                    chungTuXuatDieuChuyenTGInfor.NgayNhapXuatKho = CommonProvider.Instance.GetSysDate();
                else
                    chungTuXuatDieuChuyenTGInfor.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.EditValue,
                                                                                      new CultureInfo("vi-VN"));

                XuatDieuChuyenTGBussiness = new XuatDieuChuyenTGBussiness(chungTuXuatDieuChuyenTGInfor);
            }
            else
            {
                XuatDieuChuyenTGBussiness = new XuatDieuChuyenTGBussiness(new ChungTuXuatDieuChuyenInfo
                {
                    //detail của phiếu xuất điều chuyển
                    LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN_TRUNG_GIAN),
                    IdChungTu = idChungTu,
                    SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDieuChuyenTrungGian),
                    SoChungTuGoc = txtSoPhieu.Text.Trim(),
                    NgayNhapXuatKho = CommonProvider.Instance.GetSysDate(), //Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")),
                    IdKho = -chungTuXuatDieuChuyen.IdKho,
                    IdNguoiNhapXuatKho = Declare.IdNhanVien,
                });

                
            }
            //chi tiết phiếu nhận điều chuyển
            XuatDieuChuyenTGBussiness.ListChiTietChungTu.RemoveAll(
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
                    XuatDieuChuyenTGBussiness.ListChiTietChungTu.Find(
                        delegate(ChungTu_ChiTietInfo match)
                        {
                            return match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                        });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    XuatDieuChuyenTGBussiness.ListChiTietChungTu.Add(
                        new ChungTu_ChiTietInfo
                        {
                            IdChungTu = idChungTu,
                            IdSanPham = chungTuChiTietInfo.IdSanPham,
                            SoLuong = chungTuChiTietInfo.SoLuong
                        });
                else
                    chiTietHangHoaNhanDieuChuyen.SoLuong = chungTuChiTietInfo.SoLuong;
            }

            XuatDieuChuyenTGBussiness.ListChiTietHangHoa.RemoveAll(
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
                    XuatDieuChuyenTGBussiness.ListChiTietHangHoa.Find(
                        delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                        {
                            return match.MaVach == chungTuChiTietInfo.MaVach &&
                                   match.IdSanPham == chungTuChiTietInfo.IdSanPham;
                        });
                if (chiTietHangHoaNhanDieuChuyen == null)
                    XuatDieuChuyenTGBussiness.ListChiTietHangHoa.Add(
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
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in XuatDieuChuyenTGBussiness.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in XuatDieuChuyenTGBussiness.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }

            if (SumChiTietChungTu == SumChiTietMaVach)
            {
                XuatDieuChuyenTGBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_XUAT);
            }            
            //hah: khong thuc hien save chung tu tai day
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
            SaveBusinessXuatDieuChuyenTG();

            frmProgress.Instance.Caption = Text;
            frmProgress.Instance.Description = "Đang thực hiện ...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;

            frmProgress.Instance.DoWork(
                delegate
                    {
                        try
                        {
                            ConnectionUtil.Instance.BeginTransaction();

                            ChungTuBusinessBase clonedBusiness;

                            frmProgress.Instance.MaxValue = 15;

                            if (XuatDieuChuyenTGBussiness != null)
                            {
                                clonedBusiness = XuatDieuChuyenTGBussiness.Clone();

                                frmProgress.Instance.Value += 1;

                                if (ngayChungTuEnabled)
                                {
                                    ((XuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.NgayNhapXuatKho =
                                        CommonProvider.Instance.GetSysDate();
                                }

                                frmProgress.Instance.Value += 1;

                                clonedBusiness.SaveChungTu();

                                frmProgress.Instance.Value += 1;
                            }

                            frmProgress.Instance.Value += 1;

                            clonedBusiness = business.Clone();

                            if (ngayChungTuEnabled)
                            {
                                ((NhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayNhapXuatKho =
                                    CommonProvider.Instance.GetSysDate();
                            }

                            frmProgress.Instance.Value += 1;

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
                            ConnectionUtil.Instance.RollbackTransaction();

                            MessageBox.Show(ex.Message);

                            frmProgress.Instance.Description = "Giao dịch không thành công!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;

                            if (!(ex is ManagedException))
                            {
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Nhan dieu chuyen");
                            }
                        }
                    });

            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //        {
            //            ChungTuBusinessBase clonedBusiness;

            //            frmProgress.Instance.MaxValue = 15;

            //            if (XuatDieuChuyenTGBussiness != null)
            //            {
            //                clonedBusiness = XuatDieuChuyenTGBussiness.Clone();
                            
            //                frmProgress.Instance.Value += 1;

            //                if (ngayChungTuEnabled)
            //                {
            //                    ((XuatDieuChuyenTGBussiness) clonedBusiness).ChungTu.NgayNhapXuatKho =
            //                        CommonProvider.Instance.GetSysDate();
            //                }

            //                frmProgress.Instance.Value += 1;

            //                clonedBusiness.SaveChungTu();

            //                frmProgress.Instance.Value += 1;
            //            }

            //            frmProgress.Instance.Value += 1;

            //            clonedBusiness = business.Clone();
                        
            //            if (ngayChungTuEnabled)
            //            {
            //                ((NhapDieuChuyenBussiness) clonedBusiness).ChungTu.NgayNhapXuatKho =
            //                    CommonProvider.Instance.GetSysDate();
            //            }

            //            frmProgress.Instance.Value += 1;

            //            clonedBusiness.SaveChungTu();

            //            frmProgress.Instance.Value += 1;

            //            AfterSaveChungTuInstance();

            //            frmProgress.Instance.Value += 1;
            //        });
            Reload();
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
            idChungTuChiTiet = business.ListChiTietChungTu[e].IdChungTuChiTiet;
            liChiTiet = business.GetListChiTietHangHoaByIdSanPham(business.ListChiTietChungTu[e].IdSanPham);
            //btnThemSP.Enabled = HangHoa.IdSanPham < 0;
            //btnXoaSP.Enabled = HangHoa.IdSanPham < 0;
            btnChiTietMaVach.Enabled = HangHoa.IdSanPham > 0;
            //btnCapNhat.Enabled = HangHoa.IdSanPham > 0;
        }
        protected override QLBH.Core.Business.ChungTuBusinessBase GetBussiness()
        {
            return business;
        }

        private void btnChiTietMaVach_Click(object sender, EventArgs e)
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                frm_ChiTietPhieuNhapDieuChuyen frm = new frm_ChiTietPhieuNhapDieuChuyen(this, HangHoa, liChiTiet,idChungTuChiTiet);
                //if (frm.ShowDialog()== DialogResult.OK)
                //{
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                //}
            }
        }

        protected override void OnDeleteChungTu()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 0)
            {
                throw new Exception("Bạn không có quyền xóa");
            }
            business.ChungTu.TrangThai = 2;
        }

        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                frm_ChiTietPhieuNhapDieuChuyen frm = new frm_ChiTietPhieuNhapDieuChuyen(this, HangHoa, liChiTiet,idChungTuChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = NhanDieuChuyenDataProvider.Instance.GetPhieuNhanDieuChuyenDetail(OID);
            ChungTuXuatDieuChuyenInfor chungTuXuatDieuChuyenInfor =
            DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
            rpt_BC_PhieuNhanDieuChuyen rpt = new rpt_BC_PhieuNhanDieuChuyen(chungTuXuatDieuChuyenInfor.IdKho, txtSoCTG.Text);
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void dgvChiTiet_Enter(object sender, EventArgs e)
        {
            btnChiTietMaVach.Enabled = true;
        }
    }
}
