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
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuNhanDieuChuyen : frm_DieuChuyenBase
    {
        private frm_DanhSachPhieuNhanDieuChuyen frm;
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
        private NhanDieuChuyenBussiness business;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuNhanDieuChuyen));
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
            // bteNguoiUyNhiem
            // 
            // 
            // btnThemSP
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
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 180);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 300);
            this.dgvChiTiet.Enter += new System.EventHandler(this.dgvChiTiet_Enter);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(117, 153);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 20);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 153);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // txtSoPhieu
            // 
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
            this.txtSoCTG.Location = new System.Drawing.Point(118, 128);
            this.txtSoCTG.Name = "txtSoCTG";
            this.txtSoCTG.Size = new System.Drawing.Size(336, 21);
            this.txtSoCTG.TabIndex = 50;
            // 
            // lblChungTuGoc
            // 
            this.lblChungTuGoc.AutoSize = true;
            this.lblChungTuGoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChungTuGoc.Location = new System.Drawing.Point(21, 133);
            this.lblChungTuGoc.Name = "lblChungTuGoc";
            this.lblChungTuGoc.Size = new System.Drawing.Size(54, 16);
            this.lblChungTuGoc.TabIndex = 51;
            this.lblChungTuGoc.Text = "Số CTG";
            // 
            // frm_PhieuNhanDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.txtSoCTG);
            this.Controls.Add(this.lblChungTuGoc);
            this.Name = "frm_PhieuNhanDieuChuyen";
            this.Text = "Phiếu nhận điều chuyển";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frm_PhieuNhanDieuChuyen(frm_DanhSachPhieuNhanDieuChuyen frm)
            : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            this.frm = frm;
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new NhanDieuChuyenBussiness();
        }

        public frm_PhieuNhanDieuChuyen(int oid, string sochungtu, string ngaylap, string sopo)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            business = new NhanDieuChuyenBussiness(new ChungTuNhapDieuChuyenInfor
            {IdChungTu = oid,
                SoChungTu = sochungtu,
                NgayLap = Convert.ToDateTime(ngaylap),
                SoChungTuGoc = sopo});
        }

        public frm_PhieuNhanDieuChuyen(ChungTuNhapDieuChuyenInfor info)
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
            business = new NhanDieuChuyenBussiness(info);
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
        //    business = new NhanDieuChuyenBussiness(new ChungTuNhanDieuChuyenInfor 
        //    { IdChungTu = oid,
        //        SoChungTu = sochungtu, 
        //        NgayLap = Convert.ToDateTime(ngaylap),
        //        SoChungTuGoc = sopo ,
        //        LoaiChungTu = Convert.ToInt32(TransactionType.NHAN_DIEU_CHUYEN)});
        //}

        public frm_PhieuNhanDieuChuyen()
            : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        protected override void LoadDataInstance()
        {
            base.LoadDataInstance();
            business.ListChiTietChungTu = NhanDieuChuyenDataProvider.Instance.GetListChiTietNhanDieuChuyen(OID != 0 ? OID : idChungTuGoc);
            dgvChiTiet.DataSource = business.ListChiTietChungTu;
            txtNguoiLap.Text = Declare.UserName;
            txtNguoiLap.Text = chungTuInfo.NguoiNhapXuatKho;
            txtSoCTG.Text = ((ChungTuNhapDieuChuyenInfor) chungTuInfo).SoChungTuGoc;
            txtSoCTG.Enabled = false;
            if (chungTuInfo.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN))
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                dtNgayLap.Enabled = false;
            }
            else
            {
                dtNgayLap.Text = Convert.ToString(chungTuInfo.NgayLap);
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
                }
                else
                {
                    //neu khong thay doi ma vach thi lay theo ngay da duoc thiet lap
                    business.ChungTu.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
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
                frm_ChiTietPhieuNhanDieuChuyen frm = new frm_ChiTietPhieuNhanDieuChuyen(this, HangHoa, liChiTiet, idChungTuChiTiet);
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
                frm_ChiTietPhieuNhanDieuChuyen frm = new frm_ChiTietPhieuNhanDieuChuyen(this, HangHoa, liChiTiet, idChungTuChiTiet);
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
