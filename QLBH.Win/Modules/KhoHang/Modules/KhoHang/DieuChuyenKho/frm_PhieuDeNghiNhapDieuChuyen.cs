using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDeNghiNhapDieuChuyen : frm_DieuChuyenKhoBase
    {
        private objGridMarkSelection opt = new objGridMarkSelection();
        private List<DeNghiNhapDieuChuyenChiTietInfor> lst = new List<DeNghiNhapDieuChuyenChiTietInfor>();
        private DeNghiXuatDieuChuyenTGBussiness deNghiXuatDieuChuyenTGBussiness;
        private DeNghiNhapDieuChuyenBussiness business;
        private int idChungTuGoc;
        private int trangThai;
        private string TenKho;
        private int IdKho, IdKhoDieuChuyen,idChungTu;

        private string soPhieuXuatDieuChuyenTG =
            CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDieuChuyenTrungGian, true);

        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn clTenSanPham;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn clDonGia;
        private DataGridViewTextBoxColumn clThanhTien;
        private Label lblKhoHang;
        private TextBox txtSoCTG;
        private Label lblChungTuGoc;

        public frm_PhieuDeNghiNhapDieuChuyen()
            : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiNhapDieuChuyenBussiness();
        }

        public frm_PhieuDeNghiNhapDieuChuyen(ChungTuNhapDieuChuyenInfo info)
            : base(info, Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.SoCTG = info.SoChungTuGoc;
            this.NguoiLap = info.NguoiLap;
            this.TenKho = info.TenKho;
            this.IdKho = info.IdKho;
            this.IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            this.trangThai = info.TrangThai;
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiNhapDieuChuyenBussiness(info);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiNhapDieuChuyen));
            this.lblChungTuGoc = new System.Windows.Forms.Label();
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.txtSoCTG = new System.Windows.Forms.TextBox();
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
            this.bteKhoDi.Size = new System.Drawing.Size(311, 20);
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
            this.bteNguoiKyDuyet.Location = new System.Drawing.Point(125, 125);
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
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(20, 128);
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
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSanPham,
            this.clTenSanPham,
            this.clSoLuong,
            this.clDonGia,
            this.clThanhTien});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 178);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 302);
            this.dgvChiTiet.TabIndex = 13;
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(125, 151);
            this.txtGhiChu.Size = new System.Drawing.Size(816, 21);
            this.txtGhiChu.TabIndex = 12;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(457, 21);
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.TabIndex = 14;
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
            this.txtSoPhieu.Size = new System.Drawing.Size(311, 20);
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
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.TabIndex = 1;
            // 
            // lblChungTuGoc
            // 
            this.lblChungTuGoc.AutoSize = true;
            this.lblChungTuGoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChungTuGoc.Location = new System.Drawing.Point(234, 102);
            this.lblChungTuGoc.Name = "lblChungTuGoc";
            this.lblChungTuGoc.Size = new System.Drawing.Size(54, 16);
            this.lblChungTuGoc.TabIndex = 15;
            this.lblChungTuGoc.Text = "Số CTG";
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
            this.clSoLuong.MinimumWidth = 100;
            this.clSoLuong.Name = "clSoLuong";
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
            this.clDonGia.Width = 150;
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
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(460, 47);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(56, 16);
            this.lblKhoHang.TabIndex = 41;
            this.lblKhoHang.Text = "Kho đến";
            // 
            // txtSoCTG
            // 
            this.txtSoCTG.Location = new System.Drawing.Point(293, 98);
            this.txtSoCTG.Name = "txtSoCTG";
            this.txtSoCTG.Size = new System.Drawing.Size(140, 21);
            this.txtSoCTG.TabIndex = 8;
            this.txtSoCTG.TabStop = false;
            this.txtSoCTG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoCTG_KeyDown);
            this.txtSoCTG.Leave += new System.EventHandler(this.txtSoCTG_Leave);
            // 
            // frm_PhieuDeNghiNhapDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.txtSoCTG);
            this.Controls.Add(this.lblKhoHang);
            this.Controls.Add(this.lblChungTuGoc);
            this.Name = "frm_PhieuDeNghiNhapDieuChuyen";
            this.Text = "Phiếu đề nghị nhận điều chuyển";
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.bteKhoNhanCuoi, 0);
            this.Controls.SetChildIndex(this.txtHoaDonDC, 0);
            this.Controls.SetChildIndex(this.txtPhuongtien, 0);
            this.Controls.SetChildIndex(this.bteNguoiVanChuyen, 0);
            this.Controls.SetChildIndex(this.bteNguoiUyNhiem, 0);
            this.Controls.SetChildIndex(this.bteNguoiKyDuyet, 0);
            this.Controls.SetChildIndex(this.bteKhoDen, 0);
            this.Controls.SetChildIndex(this.bteKhoDi, 0);
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.lblChungTuGoc, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.lblKhoHang, 0);
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
        #region btePhieuXuatDC
        private void btePhieuXuatDC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //frmLookup_XuatDC frm = new frmLookup_XuatDC(String.Format("%{0}%", btePhieuXuatDC.Text));
            //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    //idChungTu = frm.item.IdChungTu;
            //    btePhieuXuatDC.Text = frm.SelectedItem.SoChungTu;
            //    LoadSoCTG();
            //    LoadHeader();
            //    //lst = DeNghiXuatDieuChuyenDataProvider.Instance.GetLookUpCTXDC(idChungTu);
            //    //business.ListChiTietChungTu = lst;
            //    //opt.View = business.ListChiTietChungTu;
            //}
        }

        private void btePhieuXuatDC_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    frmLookup_XuatDC frm = new frmLookup_XuatDC(String.Format("%{0}%", btePhieuXuatDC.Text));
            //    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        //idChungTu = frm.item.IdChungTu;
            //        btePhieuXuatDC.Text = frm.SelectedItem.SoChungTu;
            //        LoadSoCTG();
            //        LoadHeader();
            //        //lst = DeNghiXuatDieuChuyenDataProvider.Instance.GetLookUpCTXDC(idChungTu);
            //        //business.ListChiTietChungTu = lst;
            //        //opt.View = business.ListChiTietChungTu;
            //    }
            //}
        }

        private void btePhieuXuatDC_TextChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(btePhieuXuatDC.Text)) btePhieuXuatDC.Tag = null;
        }
        #endregion
        protected override void LoadDataInstance()
        {
            if (chungTuInfo != null)
            {
                base.LoadDataInstance();

                if (chungTuInfo.IdChungTu == 0)
                {
                    dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                    dtNgayLap.Enabled = false;
                }
                else
                {
                    dtNgayLap.Text = Convert.ToString(chungTuInfo.NgayLap);
                    dtNgayLap.Enabled = false;
                }
                txtSoCTG.Text = ((ChungTuNhapDieuChuyenInfo)chungTuInfo).SoChungTuGoc;
                txtSoCTG.Enabled = false;
                txtHoaDonDC.Enabled = false;
            }
            else
            {
                txtNguoiLap.Text = Declare.TenNhanVien;
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                bteKhoDen.Enabled = false;
                bteKhoDi.Enabled = false;
            } 
            //txtNguoiLap.Text = NguoiLap;

            if (business.ListChiTietChungTu != null)
                dgvChiTiet.DataSource =
                    new BindingList<DeNghiNhapDieuChuyenChiTietInfor>(business.ListChiTietChungTu)
                    {
                        AllowEdit = true,
                        AllowNew = true,
                        AllowRemove = true,
                        RaiseListChangedEvents = true
                    };
            LoadSoCTG();
            btnXoaSP.Enabled = false;
            btnThemSP.Enabled = false;
            btnInPhieu.Enabled = chungTuInfo != null && chungTuInfo.IdChungTu > 0;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN) ||
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT) || 
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN))
            {  
                //btnXoaSP.Enabled = IsSupperUser();
                btnChiTietMaVach.Enabled = IsSupperUser();
                btnThemSP.Enabled = false;
                txtNguoiLap.Enabled = false;
                btnCapNhat.Enabled = IsSupperUser();
                txtGhiChu.Enabled = IsSupperUser();
                //dtNgayLap.Enabled = IsSupperUser();
                //txtSoCTG.Enabled = IsSupperUser();
                clSoLuong.ReadOnly = true;
            }
            else
            {
                //btnXoaSP.Enabled = IsSupperUser();
                btnChiTietMaVach.Enabled = false;
                btnThemSP.Enabled = false; 
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = true;
            }
        }

        protected override void GetValuesInstance(int e)
        {
            btnChiTietMaVach.Enabled = false;
            btnXoaSP.Enabled = false;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }

        private bool Check()
        {
            int User = 0;

            if(dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Chưa có sản phẩm nào cả!");
            }
            
            //foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            //{
            //    if (((DMKhoInfo)bteKhoDen.Tag).IdKho == nguoiDungInfor.IdKho)
            //    {
            //        User = 1;
            //    }
            //}
            //if(User!=1)
            //{
            //    throw new Exception("Bạn không có quyền nhận chứng từ này!");
            //}

            //@HanhBD: khong cho phep tao nhieu phieu nhan cho cung 1 phieu xuat
            string sSoChungTuNhap =
                DeNghiNhanDieuChuyenDataProvider.Instance.ChungTuDaXacNhanNhapKho(txtSoCTG.Text);
            if (!String.IsNullOrEmpty(sSoChungTuNhap) && sSoChungTuNhap != txtSoPhieu.Text)
            {
                throw new Exception("Chứng từ này đã được xác nhận nhập kho bởi chứng từ số " + sSoChungTuNhap);
            }

            foreach (DeNghiNhapDieuChuyenChiTietInfor pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == 0)
                {
                    throw new InvalidOperationException("Trong danh sách có sản phẩm bạn chưa thêm vào!");
                }
            }
            return true;
        }
        
        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                //if(Convert.ToDateTime(dtNgayLap.Text) < chungTuInfo.NgayLap)
                //{
                //    throw new InvalidOperationException("Ngày đề nghị nhập phải lớn hơn hoặc bằng ngày đề nghị xuất!");
                //}
                business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                if (business.ChungTu.IdChungTu == 0)
                {
                    business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                    business.ChungTu.SoChungTuGoc = txtSoCTG.Text.Trim();
                    business.ChungTu.IdNhanVien = Declare.IdNhanVien;
                    business.ChungTu.IdKho = ((DMKhoInfo)bteKhoDen.Tag).IdKho;
                    business.ChungTu.HoaDonDC = txtHoaDonDC.Text;
                    business.ChungTu.PhuongTien = txtPhuongtien.Text;
                    business.ChungTu.IdNguoiVC = ((DMNhanVienInfo)bteNguoiVanChuyen.Tag).IdNhanVien;
                    business.ChungTu.IdNguoiUyNhiem = ((DMNhanVienInfo)bteNguoiUyNhiem.Tag).IdNhanVien;
                    business.ChungTu.IdNguoiKyDuyet = ((DMNhanVienInfo)bteNguoiKyDuyet.Tag).IdNhanVien;
                    business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN);

                    business.ChungTu.IdKhoNhanCuoi = bteKhoNhanCuoi.Tag != null ? ((DMKhoInfo) bteKhoNhanCuoi.Tag).IdKho : ((DMKhoInfo)bteKhoDen.Tag).IdKho;

                    if (business.ChungTu.IdChungTu == 0)
                    {
                        business.ChungTu.TrangThai =
                            Convert.ToInt32(
                                DeNghiNhapDieuChuyenDataProvider.Instance.ChungTuDaXuatHang(
                                    business.ChungTu.SoChungTuGoc)
                                    ? TrangThaiDieuChuyen.CHO_THUKHO_NHAN
                                    : TrangThaiDieuChuyen.CHO_THUKHO_XUAT);
                    }
                }
            }
        }

        private void SaveBusinessXuatDieuChuyenTG()
        {
            //ChungTuXuatDieuChuyenInfo chungTuNhapDieuChuyenTrungGian = DeNghiXuatDieuChuyenTGDataProvider.Instance.GetChungTuXuatDCTGBySoCTGoc(chungTuInfo.SoChungTu);
            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyen = DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
            if(chungTuXuatDieuChuyen == null)
            {
                throw new ManagedException("Số chứng từ gốc không hợp lệ");
            }

            if(chungTuXuatDieuChuyen.NgayLap < new DateTime(2013,8,19))
            {
                //truoc thoi diem nay khong xu ly kho trung gian.
                return;
            }

            //if (chungTuNhapDieuChuyenTrungGian == null)
                deNghiXuatDieuChuyenTGBussiness = new DeNghiXuatDieuChuyenTGBussiness(new ChungTuNhapDieuChuyenInfo
                {
                    LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN),
                    IdChungTu = 0,//hanhbd: neu sua chung tu thi chua dat yc
                    IdNhanVien = Declare.IdNhanVien,
                    SoChungTu = soPhieuXuatDieuChuyenTG,
                    GhiChu = txtGhiChu.Text.Trim(),
                    NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")),
                    IdKho = -chungTuXuatDieuChuyen.IdKho,
                    HoaDonDC = chungTuXuatDieuChuyen.HoaDonDC,
                    PhuongTien = chungTuXuatDieuChuyen.PhuongTien,
                    IdNguoiUyNhiem = chungTuXuatDieuChuyen.IdNguoiUyNhiem,
                    IdNguoiVC = chungTuXuatDieuChuyen.IdNguoiVC,
                    IdKhoNhanCuoi = chungTuXuatDieuChuyen.IdKhoNhanCuoi
                });
            //else
                //deNghiXuatDieuChuyenTGBussiness = new DeNghiXuatDieuChuyenTGBussiness(chungTuNhapDieuChuyenTrungGian);

            deNghiXuatDieuChuyenTGBussiness.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);

            foreach (DeNghiNhapDieuChuyenChiTietInfor deNghiDieuChuyenInfor in business.ListChiTietChungTu)
            {
                DeNghiXuatDieuChuyenInfor deNghiNhanDieuChuyenTGInfor =
                    deNghiXuatDieuChuyenTGBussiness.ListChiTietChungTu.Find(
                        delegate(DeNghiXuatDieuChuyenInfor match)
                        {
                            return match.IdSanPham == deNghiDieuChuyenInfor.IdSanPham;
                        });

                if (deNghiNhanDieuChuyenTGInfor != null)
                {
                    deNghiNhanDieuChuyenTGInfor.SoLuong = deNghiDieuChuyenInfor.SoLuong;
                    deNghiNhanDieuChuyenTGInfor.DonGia = deNghiDieuChuyenInfor.DonGia;
                    deNghiNhanDieuChuyenTGInfor.Thanhtien = deNghiDieuChuyenInfor.Thanhtien;
                }
                else
                    deNghiXuatDieuChuyenTGBussiness.ListChiTietChungTu.Add(
                        new DeNghiXuatDieuChuyenInfor
                        {
                            IdSanPham = deNghiDieuChuyenInfor.IdSanPham,
                            SoLuong = deNghiDieuChuyenInfor.SoLuong,
                            MaSanPham = deNghiDieuChuyenInfor.MaSanPham,
                            TenSanPham = deNghiDieuChuyenInfor.TenSanPham,
                            DonGia = deNghiDieuChuyenInfor.DonGia,
                            Thanhtien = deNghiDieuChuyenInfor.Thanhtien,
                        });
            }

            if (deNghiXuatDieuChuyenTGBussiness.ChungTu.IdChungTu == 0)
                deNghiXuatDieuChuyenTGBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_KETOAN_NHAN);
                deNghiXuatDieuChuyenTGBussiness.ChungTu.SoChungTuGoc = txtSoPhieu.Text.Trim();
                //hah:khong thuc hien save tai day
                //deNghiXuatDieuChuyenTGBussiness.SaveChungTu();

            //if (business.ChungTu.IdChungTu == 0)
            //    business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN);
        }

        //protected override void AfterSaveChungTuInstance()
        //{
        //    SaveBusinessXuatDieuChuyenTG();
        //}

        protected override void SaveChungTu()
        {
            try
            {
                List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());

                if (li.Count > 0 && OID == 0)
                {
                    txtSoPhieu.Focus();

                    throw new ManagedException("Số phiếu đã tồn tại trong hệ thống. Xin hãy kiểm tra lại!");
                }

                if (this.Business == null) this.Business = GetBussiness();

                SaveChungTuInstance();

                SaveBusinessXuatDieuChuyenTG();

                bool ngayChungTuEnabled = dtNgayLap.Enabled;

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

                                frmProgress.Instance.MaxValue = 15;

                                ChungTuBusinessBase clonedBusiness = deNghiXuatDieuChuyenTGBussiness.Clone();

                                frmProgress.Instance.Value += 1;

                                ((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDieuChuyenTrungGian);

                                frmProgress.Instance.Value += 1;

                                ((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.SoChungTuGoc = business.ChungTu.SoChungTu;

                                frmProgress.Instance.Value += 1;

                                if (((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
                                {
                                    ((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.NgayLap =
                                        CommonProvider.Instance.GetSysDate();
                                }
                                frmProgress.Instance.Value += 1;

                                clonedBusiness.SaveChungTu();

                                frmProgress.Instance.Value += 1;

                                clonedBusiness = business.Clone();

                                frmProgress.Instance.Value += 1;

                                if (((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
                                {
                                    ((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayLap =
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
                                    EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "De nghi nhan dieu chuyen");
                                }
                            }
                        });
                //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
                //    delegate
                //    {
                //        try
                //        {
                //            frmProgress.Instance.MaxValue = 15;

                //            ChungTuBusinessBase clonedBusiness = deNghiXuatDieuChuyenTGBussiness.Clone();

                //            frmProgress.Instance.Value += 1;

                //            ((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.SoChungTu = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDieuChuyenTrungGian);

                //            frmProgress.Instance.Value += 1;

                //            ((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.SoChungTuGoc = business.ChungTu.SoChungTu;

                //            frmProgress.Instance.Value += 1;

                //            if (((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
                //            {
                //                ((DeNghiXuatDieuChuyenTGBussiness)clonedBusiness).ChungTu.NgayLap =
                //                    CommonProvider.Instance.GetSysDate();
                //            }
                //            frmProgress.Instance.Value += 1;

                //            clonedBusiness.SaveChungTu();

                //            frmProgress.Instance.Value += 1;

                //            clonedBusiness = business.Clone();

                //            frmProgress.Instance.Value += 1;

                //            if (((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
                //            {
                //                ((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayLap =
                //                    CommonProvider.Instance.GetSysDate();
                //            }

                //            frmProgress.Instance.Value += 1;

                //            clonedBusiness.SaveChungTu();

                //            frmProgress.Instance.Value += 1;

                //            AfterSaveChungTuInstance();

                //            frmProgress.Instance.Value += 1;
                //        }
                //        catch (Exception ex)
                //        {
                //            EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "De nghi nhan dieu chuyen");
                //            throw;
                //        }
                //    });

                if (chungTuXuatDieuChuyenInfor != null)
                {
                    CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfor.IdChungTu, 0);
                }

                Reload();
            }
            catch (Exception)
            {
                try
                {
                    if (chungTuXuatDieuChuyenInfor != null)
                    {
                        CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfor.IdChungTu, 0);
                    }
                }
                catch (Exception){}

                throw;
            }
        }

        protected override void OnDeleteChungTu()
        {
            if (!IsSupperUser())
            {
                throw new Exception("Bạn không có quyền xóa");
            }
        }

        private void dgvChiTiet_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            btnChiTietMaVach.Enabled = false;
        }

        private void LoadSoCTG()
        {
            business.ListChiTietChungTu.Clear();
            if(!string.IsNullOrEmpty(txtSoCTG.Text))
            {
                ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor = DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);

                if (chungTuXuatDieuChuyenInfor == null)
                    throw new ManagedException("Không tồn tại số chứng từ này");

                List<DeNghiNhapDieuChuyenChiTietInfor> frm =
                    DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNhanDieuChuyenBySoCT(txtSoCTG.Text);
                if ((chungTuXuatDieuChuyenInfor.LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)
                    || chungTuXuatDieuChuyenInfor.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN))
                    && (chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDuyet.CHUA_XUAT)
                    || chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT)
                    ||chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN)
                    || chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT)
                    ||chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN)))
                    //&& (chungTuXuatDieuChuyenInfor.IdKhoDieuChuyen == Declare.IdKho))
                {
                    var trungTamNhanDieuChuyen = DMTrungTamDataProvider.GetTrungTamByIdKho(chungTuXuatDieuChuyenInfor.IdKhoDieuChuyen);

                    if (DMKhoDataProvider.Instance.IsCrossedOU(Declare.IdTrungTamHachToan, trungTamNhanDieuChuyen.IdTrungTam)
                        && trungTamNhanDieuChuyen.MaTrungTam != "TK2")
                        
                        throw new ManagedException("Chứng từ này điều chuyển cho chi nhánh khác!");

                    for (int i = 0; i < frm.Count; i++)
                    {
                        business.ListChiTietChungTu.Add(new DeNghiNhapDieuChuyenChiTietInfor
                        {
                            IdSanPham = frm[i].IdSanPham,
                            MaSanPham = frm[i].MaSanPham,
                            TenSanPham = frm[i].TenSanPham,
                            SoLuong = frm[i].SoLuong,
                            DonGia = frm[i].DonGia,
                            Thanhtien = frm[i].Thanhtien
                        });
                    }
                    ((BindingList<DeNghiNhapDieuChuyenChiTietInfor>)dgvChiTiet.DataSource).ResetBindings();
                    btnChiTietMaVach.Enabled = false;
                    btnXoaSP.Enabled = false;
                }
                else
                {
                    throw new ManagedException("Không đúng kho nhập!");
                }
            }
        }

        private void LoadHeader()
        {
            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyen = DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
            idChungTu = 0;
            //dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            txtGhiChu.Text = chungTuXuatDieuChuyen.GhiChu;
            txtHoaDonDC.Text = chungTuXuatDieuChuyen.HoaDonDC;
            txtPhuongtien.Text = chungTuXuatDieuChuyen.PhuongTien;
            txtHoaDonDC.Enabled = false;
            txtPhuongtien.Enabled = false;
            txtNguoiLap.Enabled = false;
            bteNguoiVanChuyen.Enabled = false;
            bteNguoiUyNhiem.Enabled = false;
            bteNguoiKyDuyet.Enabled = false;
            bteKhoDi.Enabled = false;
            bteKhoDen.Enabled = false;
            bteKhoNhanCuoi.Enabled = false;
            if (chungTuXuatDieuChuyen.IdKhoNhanCuoi != 0)
            {
                DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(chungTuXuatDieuChuyen.IdKhoNhanCuoi);
                bteKhoNhanCuoi.Tag = dmKho;
                bteKhoNhanCuoi.Text = dmKho.TenKho;
                bteKhoNhanCuoi.Enabled = false;                
            }
            if (chungTuXuatDieuChuyen.IdKhoDieuChuyen != 0)
            {
                DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(chungTuXuatDieuChuyen.IdKhoDieuChuyen);
                bteKhoDen.Tag = dmKho;
                bteKhoDen.Text = dmKho.TenKho;
                bteKhoDen.Enabled = false;
            }
            if (chungTuXuatDieuChuyen.IdKho != 0)
            {
                DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(chungTuXuatDieuChuyen.IdKho);
                bteKhoDi.Text = dmKho.TenKho;
                bteKhoDi.Enabled = false;
            }
            if (chungTuXuatDieuChuyen.IdNguoiVC != 0)
            {
                DMNhanVienInfo dmNv = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(chungTuXuatDieuChuyen.IdNguoiVC);
                bteNguoiVanChuyen.Tag = dmNv;
                bteNguoiVanChuyen.Text = dmNv.HoTen;
                bteNguoiVanChuyen.Enabled = false;
            }

            if (chungTuXuatDieuChuyen.IdNguoiUyNhiem != 0)
            {
                DMNhanVienInfo dmNv = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(chungTuXuatDieuChuyen.IdNguoiUyNhiem);
                bteNguoiUyNhiem.Tag = dmNv;
                bteNguoiUyNhiem.Text = dmNv.HoTen;
                bteNguoiUyNhiem.Enabled = false;
            }
            if (chungTuXuatDieuChuyen.IdNguoiKyDuyet != 0)
            {
                DMNhanVienInfo dmNv = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(chungTuXuatDieuChuyen.IdNguoiKyDuyet);
                bteNguoiKyDuyet.Tag = dmNv;
                bteNguoiKyDuyet.Text = dmNv.HoTen;
                bteNguoiKyDuyet.Enabled = false;
            }
        }
        
        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = DeNghiNhapDieuChuyenDataProvider.Instance.GetPhieuDeNghiNhanDieuChuyenDetail(OID);
            ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor =
                DeNghiNhapDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
            rpt_BC_PhieuDeNghiNhanDieuChuyen rpt = new rpt_BC_PhieuDeNghiNhanDieuChuyen(chungTuXuatDieuChuyenInfor.IdKho);
            //List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = list;
            rpt.ShowPreview();
        }

        private void txtSoCTG_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(txtHoaDonDC.Text))
                {
                    CheckSoCTGHopLe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtSoCTG_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtHoaDonDC.Text))

                    CheckSoCTGHopLe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfor;

        private bool CheckSoCTGHopLe()
        {
            int User = 0;

            if (String.IsNullOrEmpty(txtSoCTG.Text))
            {
                throw new ManagedException("Bạn chưa nhập số chứng từ!");
            }

            chungTuXuatDieuChuyenInfor =
                DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenBySoChungTu(txtSoCTG.Text);

            if(chungTuXuatDieuChuyenInfor == null)
            {
                throw new ManagedException("Không tìm thấy chứng từ nào!");
            }
            DMKhoInfo dmKhoInfo = DMKhoDataProvider.GetKhoByIdInfo(chungTuXuatDieuChuyenInfor.IdKhoDieuChuyen);
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1 ||
                ((NguoiDungInfor)Declare.USER_INFOR).IsOnline ||
                ((NguoiDungInfor)Declare.USER_INFOR).IsKinhDoanhThiTruong ||
                ((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan == dmKhoInfo.IdTrungTam ||
                (dmKhoInfo.IdTrungTam == 5 && //tổng kho trung chuyển
                !String.IsNullOrEmpty(dmKhoInfo.OtherTrungTam) && 
                dmKhoInfo.OtherTrungTam.Contains(((NguoiDungInfor)Declare.USER_INFOR).IdTrungTamHachToan.ToString()))
                )
            {
                User = 1;
            }

            if (User == 1)
            {
                if ((chungTuXuatDieuChuyenInfor.LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)
                || chungTuXuatDieuChuyenInfor.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN))
                && (chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_KETOAN_NHAN)
                || chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT)))
                {
                    if (chungTuXuatDieuChuyenInfor.HoaDonDC == txtHoaDonDC.Text || String.IsNullOrEmpty(chungTuXuatDieuChuyenInfor.HoaDonDC))
                    {
                        try
                        {
                            CommonProvider.Instance.Check_Lock_ChungTu(chungTuXuatDieuChuyenInfor.IdChungTu);

                            if(!CommonProvider.Instance.Lock_Unlock_ChungTu(chungTuXuatDieuChuyenInfor.IdChungTu, 1))
                            {
                                throw new ManagedException(String.Format("Chứng từ {0} đang bị lock bởi người dùng khác, không thể mở được!", chungTuXuatDieuChuyenInfor.SoChungTu));
                            }

                            LoadSoCTG();

                            LoadHeader();

                        }
                        catch (ManagedException ex)
                        {
                            MessageBox.Show(ex.Message);

                            txtSoCTG.Focus();
                        }
                    }
                    else
                    {
                        clsUtils.MsgThongBao("Bạn chưa nhập số Hóa Đơn điều chuyển! Hoặc số hóa đơn điều chuyển chưa đúng với phiếu xuất ĐC");
                        
                        txtHoaDonDC.Focus();
                    }
                }
                else if (chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_HUY_DIEU_CHUYEN))
                {
                    MessageBox.Show(String.Format("Chứng từ {0} đang chờ hủy, không làm thủ tục nhận được!", chungTuXuatDieuChuyenInfor.SoChungTu));

                    txtSoCTG.Focus();
                }
                else
                {
                    clsUtils.MsgCanhBao("Chứng từ đã được nhận!");

                    txtSoCTG.Focus();
                }
            }
            else
            {
                throw new ManagedException("Bạn không có quyền nhận chứng từ này!");
            }

            return true;
        }
    }
}
