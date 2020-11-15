using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules
{
    public class frm_PhieuDeNghiNhanDieuChuyen : frmChiTiet_ChungTuNhapBase
    {
        //private DeNghiNhanDieuChuyenBussiness business;
        //private List<DeNghiNhanDieuChuyenInfor> liChiTiet; 
        private DeNghiNhanDieuChuyenBussiness business;
        private int idChungTuGoc;
        private int trangThai;
        private string SoCTG;
        private QLBH.Core.Form.GtidTextBox txtSoCTG;
        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn clTenSanPham;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn clDonGia;
        private DataGridViewTextBoxColumn clThanhTien;
        private DevExpress.XtraEditors.ButtonEdit bteKhoDen;
        private TextBox txtKhoDi;
        private Label label5;
        private Label lblKhoHang;
        private Label lblChungTuGoc;

        public frm_PhieuDeNghiNhanDieuChuyen(int OID, string PhieuNhap, string NgayLap, string PO, int TrangThai, string soCTG)
            : base(OID, PhieuNhap, NgayLap, PO, Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.SoCTG = soCTG;
            this.trangThai = TrangThai;
            dgvChiTiet.AutoGenerateColumns = false;

            business = new DeNghiNhanDieuChuyenBussiness(new ChungTuNhapDieuChuyenInfor
            {
                LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                IdChungTu = OID,
                SoChungTu = PhieuNhap,
                IdKho = Declare.IdKho,
                NgayLap = Convert.ToDateTime(NgayLap),
                TrangThai = trangThai
            });

        }

        public frm_PhieuDeNghiNhanDieuChuyen(ChungTuNhapDieuChuyenInfor chungTuDeNghiNhanDieuChuyenInfor)
            : base(chungTuDeNghiNhanDieuChuyenInfor.IdChungTu, chungTuDeNghiNhanDieuChuyenInfor.SoChungTu, chungTuDeNghiNhanDieuChuyenInfor.NgayLap.ToString(), string.Empty, Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiNhanDieuChuyenBussiness(chungTuDeNghiNhanDieuChuyenInfor);

        }

        public frm_PhieuDeNghiNhanDieuChuyen() : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiNhanDieuChuyenBussiness();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiNhanDieuChuyen));
            this.lblChungTuGoc = new System.Windows.Forms.Label();
            this.txtSoCTG = new QLBH.Core.Form.GtidTextBox();
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bteKhoDen = new DevExpress.XtraEditors.ButtonEdit();
            this.txtKhoDi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKhoHang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.TabIndex = 6;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 7;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 9;
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
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 98);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 382);
            this.dgvChiTiet.TabIndex = 5;
            this.dgvChiTiet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvChiTiet_UserDeletingRow);
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(117, 71);
            this.txtGhiChu.Size = new System.Drawing.Size(433, 21);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(46, 71);
            this.label4.TabIndex = 14;
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 10;
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
            // lblChungTuGoc
            // 
            this.lblChungTuGoc.AutoSize = true;
            this.lblChungTuGoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChungTuGoc.Location = new System.Drawing.Point(556, 71);
            this.lblChungTuGoc.Name = "lblChungTuGoc";
            this.lblChungTuGoc.Size = new System.Drawing.Size(107, 16);
            this.lblChungTuGoc.TabIndex = 15;
            this.lblChungTuGoc.Text = "Số chứng từ gốc";
            // 
            // txtSoCTG
            // 
            this.txtSoCTG.Location = new System.Drawing.Point(669, 71);
            this.txtSoCTG.Name = "txtSoCTG";
            this.txtSoCTG.Size = new System.Drawing.Size(272, 21);
            this.txtSoCTG.TabIndex = 4;
            this.txtSoCTG.Leave += new System.EventHandler(this.txtSoCTG_Leave);
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
            // bteKhoDen
            // 
            this.bteKhoDen.Location = new System.Drawing.Point(525, 44);
            this.bteKhoDen.Name = "bteKhoDen";
            this.bteKhoDen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKhoDen.Size = new System.Drawing.Size(415, 20);
            this.bteKhoDen.TabIndex = 40;
            // 
            // txtKhoDi
            // 
            this.txtKhoDi.Location = new System.Drawing.Point(117, 44);
            this.txtKhoDi.Name = "txtKhoDi";
            this.txtKhoDi.Size = new System.Drawing.Size(336, 21);
            this.txtKhoDi.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "Kho đi";
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(459, 44);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(56, 16);
            this.lblKhoHang.TabIndex = 37;
            this.lblKhoHang.Text = "Kho đến";
            // 
            // frm_PhieuDeNghiNhanDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.bteKhoDen);
            this.Controls.Add(this.txtKhoDi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblKhoHang);
            this.Controls.Add(this.txtSoCTG);
            this.Controls.Add(this.lblChungTuGoc);
            this.Name = "frm_PhieuDeNghiNhanDieuChuyen";
            this.Text = "Phiếu đề nghị nhận điều chuyển";
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
            this.Controls.SetChildIndex(this.txtSoCTG, 0);
            this.Controls.SetChildIndex(this.lblKhoHang, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtKhoDi, 0);
            this.Controls.SetChildIndex(this.bteKhoDen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        protected override void LoadDataInstance()
        {
            DateTime Ngaylap = business.ChungTu.NgayLap;

            if (Ngaylap <= dtNgayLap.Properties.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            }
            else
            {
                dtNgayLap.Text = Ngaylap.ToString();
            }
            if (business.ListChiTietChungTu != null)
                dgvChiTiet.DataSource =
                    new BindingList<DeNghiNhanDieuChuyenInfor>(business.ListChiTietChungTu)
                    {
                        AllowEdit = true,
                        AllowNew = true,
                        AllowRemove = true,
                        RaiseListChangedEvents = true
                    };
            txtSoCTG.Text = SoCTG;
            btnXoaSP.Enabled = false;
            //btnCapNhat.Enabled = false;
            btnThemSP.Enabled = false;
            dtNgayLap.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT))
            {  
                btnXoaSP.Enabled = false;
                btnChiTietMaVach.Enabled = false;
                btnThemSP.Enabled = false;
                txtNguoiLap.Enabled = false;
                txtGhiChu.Enabled = false;
                //dtNgayLap.Enabled = false;
                txtSoCTG.Enabled = false;
                clSoLuong.ReadOnly = true;
            }
            else
            {
                btnXoaSP.Enabled = false;
                btnChiTietMaVach.Enabled = false;
                btnThemSP.Enabled = false; 
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = false;
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
            if(dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Chưa có sản phẩm nào cả!");
            }
            return true;
        }
        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.SoChungTuGoc = txtSoCTG.Text.Trim();
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                business.ChungTu.IdNhanVien = Declare.IdNhanVien;
                business.ChungTu.IdKho = Declare.IdKho;
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN);
            }
        }

        private void dgvChiTiet_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            btnChiTietMaVach.Enabled = false;
        }

        private void dgvChiTiet_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void txtSoCTG_Leave(object sender, EventArgs e)
        {
            business.ListChiTietChungTu.Clear();
            //List<ChungTuXuatDieuChuyenInfor> chungTuXuatDieuChuyenInfor = 
            //    DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
            List<DeNghiNhanDieuChuyenInfor> frm =
                DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNhanDieuChuyenBySoCT(txtSoCTG.Text);
            //Lay ve chung tu xuat dieu chuyen info theo so chung tu nhap vao
            //kiem tra chung tu info theo cac dk sau:
            //- Loaichungtu la loai xuatdieuchuyen
            //- Trangthai la da xuat
            //- Khodieuchuyen == Declare.IdKho
            //Cac truong hop khac throw exception
            //Chi nhap mot lan luc them moi, sau do disable
            //for(int n=0; n< chungTuXuatDieuChuyenInfor.Count;n ++)
            //{
            //    if (chungTuXuatDieuChuyenInfor[n].LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)
            //        && chungTuXuatDieuChuyenInfor[n].TrangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT)
            //        && chungTuXuatDieuChuyenInfor[n].IdKhoDieuChuyen == Declare.IdKho)
            //    {
            //        for (int i = 0; i < frm.Count; i++)
            //        {
            //            business.ListChiTietChungTu.Add(new DeNghiNhanDieuChuyenInfor
            //                {
            //                    IdSanPham = frm[i].IdSanPham,
            //                    MaSanPham = frm[i].MaSanPham,
            //                    TenSanPham = frm[i].TenSanPham,
            //                    SoLuong = frm[i].SoLuong,
            //                    DonGia = frm[i].DonGia,
            //                    Thanhtien = frm[i].Thanhtien
            //                });
            //        }
            //        ((BindingList<DeNghiNhanDieuChuyenInfor>) dgvChiTiet.DataSource).ResetBindings();
            //        btnChiTietMaVach.Enabled = false;
            //        btnXoaSP.Enabled = false;
            //    }
            //    else
            //    {
            //        throw new InvalidExpressionException("Số chứng từ nhập không thỏa mãn!");
            //    }
            //}
            txtSoCTG.Enabled = false;
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            //List<BaoCao_ChiTietInfor> list = DeNghiNhanDieuChuyenDataProvider.Instance.GetPhieuDeNghiNhanDieuChuyenDetail(OID);
            //rpt_BC_PhieuDeNghiNhanDieuChuyen rpt = new rpt_BC_PhieuDeNghiNhanDieuChuyen();
            //List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            //rpt.DataSource = lst;
            //rpt.ShowPreview();
        }
    }
}
