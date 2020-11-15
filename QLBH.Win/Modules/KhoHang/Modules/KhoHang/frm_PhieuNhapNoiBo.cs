using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

// form frm_PhieuNhapNoiBo
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 23/07/2012
// Người sửa cuối:
// Ngày sửa cuối:
//@HanhBD frm_PhieuNhapNoiBo
namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuNhapNoiBo : frmChiTiet_ChungTuNhapBase
    {
        public List<ChungTu_HangHoa_ChiTietInfor> liChungTu = new List<ChungTu_HangHoa_ChiTietInfor>();
        private int IdChiPhi, IdPhongBan,IdNhaCC,IdLyDo;
        private string soPO, soRE,TenDT;
        List<DMPhongBanInfor> liPhongBan = new List<DMPhongBanInfor>();
        List<DMChiPhiInfo> liChiPhi = new List<DMChiPhiInfo>();
        List<DMLyDoTraHangInfo> liLyDo = new List<DMLyDoTraHangInfo>();
        public int idSanPham = 0;
        private int idChungTuGoc;
        private int trangThai;
        private int DongBo;
        private frm_DanhSachPhieuNhapNoiBo frm;
        private NhapNoiBoBussiness NhapNoiBoBussiness;
        private CheckBox chkDongBo;
        private Label label5;
        private Label lblKhoHang;
        private Label label6;
        private Label label7;
        private TextBox txtPO;
        private DevExpress.XtraEditors.ButtonEdit bteNhaCC;
        private Label label8;
        private ComboBox cboLyDo;
        private DevExpress.XtraEditors.ButtonEdit bteChiPhi;
        private DevExpress.XtraEditors.ButtonEdit btePhongBan;
        private DataGridViewTextBoxColumn colMaSanPham;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn colNganh;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private TextBox txtSoRE;
        private Label label9;
        private List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuNhapNoiBo));
            this.chkDongBo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.bteNhaCC = new DevExpress.XtraEditors.ButtonEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.cboLyDo = new System.Windows.Forms.ComboBox();
            this.bteChiPhi = new DevExpress.XtraEditors.ButtonEdit();
            this.btePhongBan = new DevExpress.XtraEditors.ButtonEdit();
            this.colMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoRE = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNhaCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteChiPhi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btePhongBan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.TabIndex = 11;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 12;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 17;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSanPham,
            this.dataGridViewTextBoxColumn2,
            this.SoLuong,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.colNganh,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 105);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 375);
            this.dgvChiTiet.TabIndex = 10;
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(554, 20);
            this.txtNguoiLap.Size = new System.Drawing.Size(140, 21);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(380, 78);
            this.txtGhiChu.Size = new System.Drawing.Size(561, 21);
            this.txtGhiChu.TabIndex = 9;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Image = ((System.Drawing.Image)(resources.GetObject("btnChiTietMaVach.Image")));
            this.btnChiTietMaVach.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(271, 21);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(482, 21);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(321, 80);
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 18;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.TabIndex = 14;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.TabIndex = 16;
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(109, 20);
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(156, 20);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
            this.dtNgayLap.Location = new System.Drawing.Point(333, 21);
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(144, 20);
            this.dtNgayLap.TabIndex = 1;
            // 
            // chkDongBo
            // 
            this.chkDongBo.AutoSize = true;
            this.chkDongBo.Location = new System.Drawing.Point(443, 491);
            this.chkDongBo.Name = "chkDongBo";
            this.chkDongBo.Size = new System.Drawing.Size(67, 17);
            this.chkDongBo.TabIndex = 15;
            this.chkDongBo.Text = "Đồng bộ";
            this.chkDongBo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(714, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Chi phí";
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(700, 22);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(70, 16);
            this.lblKhoHang.TabIndex = 20;
            this.lblKhoHang.Text = "Phòng ban";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(455, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Nhà CC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Số PO";
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(109, 51);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(156, 21);
            this.txtPO.TabIndex = 4;
            // 
            // bteNhaCC
            // 
            this.bteNhaCC.Location = new System.Drawing.Point(514, 49);
            this.bteNhaCC.Name = "bteNhaCC";
            this.bteNhaCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteNhaCC.Size = new System.Drawing.Size(180, 20);
            this.bteNhaCC.TabIndex = 6;
            this.bteNhaCC.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteNhaCC_ButtonClick);
            this.bteNhaCC.DoubleClick += new System.EventHandler(this.bteNhaCC_DoubleClick);
            this.bteNhaCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteNhaCC_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Lý do GD";
            // 
            // cboLyDo
            // 
            this.cboLyDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLyDo.FormattingEnabled = true;
            this.cboLyDo.Location = new System.Drawing.Point(109, 79);
            this.cboLyDo.Name = "cboLyDo";
            this.cboLyDo.Size = new System.Drawing.Size(206, 21);
            this.cboLyDo.TabIndex = 8;
            // 
            // bteChiPhi
            // 
            this.bteChiPhi.Location = new System.Drawing.Point(776, 50);
            this.bteChiPhi.Name = "bteChiPhi";
            this.bteChiPhi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteChiPhi.Size = new System.Drawing.Size(165, 20);
            this.bteChiPhi.TabIndex = 7;
            this.bteChiPhi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteChiPhi_ButtonClick);
            this.bteChiPhi.DoubleClick += new System.EventHandler(this.bteChiPhi_DoubleClick);
            this.bteChiPhi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteChiPhi_KeyDown);
            // 
            // btePhongBan
            // 
            this.btePhongBan.Location = new System.Drawing.Point(776, 18);
            this.btePhongBan.Name = "btePhongBan";
            this.btePhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btePhongBan.Size = new System.Drawing.Size(165, 20);
            this.btePhongBan.TabIndex = 3;
            this.btePhongBan.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btePhongBan_ButtonClick);
            this.btePhongBan.DoubleClick += new System.EventHandler(this.btePhongBan_DoubleClick);
            this.btePhongBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btePhongBan_KeyDown);
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.DataPropertyName = "MaSanPham";
            this.colMaSanPham.HeaderText = "Mã sản phẩm";
            this.colMaSanPham.MinimumWidth = 150;
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMaSanPham.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenSanPham";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên sản phẩm";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 50;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Thanhtien";
            this.dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TrangThai";
            this.dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 170;
            // 
            // colNganh
            // 
            this.colNganh.DataPropertyName = "Nganh";
            this.colNganh.HeaderText = "Ngành";
            this.colNganh.MinimumWidth = 100;
            this.colNganh.Name = "colNganh";
            this.colNganh.ReadOnly = true;
            this.colNganh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MaVach";
            this.dataGridViewTextBoxColumn7.HeaderText = "mavach";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "IdSanPham";
            this.dataGridViewTextBoxColumn8.HeaderText = "clidsanpham";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SoPhieuNhap";
            this.dataGridViewTextBoxColumn9.HeaderText = "sophieu";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TrungMaVach";
            this.dataGridViewTextBoxColumn10.HeaderText = "trungmavach";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TenDonViTinh";
            this.dataGridViewTextBoxColumn11.HeaderText = "donvitinh";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "SoPO";
            this.dataGridViewTextBoxColumn12.HeaderText = "soPO";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // txtSoRE
            // 
            this.txtSoRE.Location = new System.Drawing.Point(333, 48);
            this.txtSoRE.Name = "txtSoRE";
            this.txtSoRE.Size = new System.Drawing.Size(116, 21);
            this.txtSoRE.TabIndex = 5;
            this.txtSoRE.Leave += new System.EventHandler(this.txtSoRE_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(271, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Số RE";
            // 
            // frm_PhieuNhapNoiBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.txtSoRE);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bteChiPhi);
            this.Controls.Add(this.btePhongBan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboLyDo);
            this.Controls.Add(this.bteNhaCC);
            this.Controls.Add(this.txtPO);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblKhoHang);
            this.Controls.Add(this.chkDongBo);
            this.Name = "frm_PhieuNhapNoiBo";
            this.Text = "Phiếu nhập nội bộ";
            this.Controls.SetChildIndex(this.chkDongBo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
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
            this.Controls.SetChildIndex(this.lblKhoHang, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtPO, 0);
            this.Controls.SetChildIndex(this.bteNhaCC, 0);
            this.Controls.SetChildIndex(this.cboLyDo, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.btePhongBan, 0);
            this.Controls.SetChildIndex(this.bteChiPhi, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtSoRE, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNhaCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteChiPhi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btePhongBan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frm_PhieuNhapNoiBo(int oid, string sochungtu, string ngaylap, string sopo)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuNhapNoiBo)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            NhapNoiBoBussiness = new NhapNoiBoBussiness(new ChungTuNhapNoiBoInfor
            {
                IdChungTu = oid,
                SoChungTu = sochungtu,
                NgayLap = Convert.ToDateTime(ngaylap),
                SoChungTuGoc = sopo
            });
        }

        public frm_PhieuNhapNoiBo(int oid, string sochungtu, string ngaylap, string sopo, int idChungTuGoc, int trangThai, string ghiChu, string nguoiLap, int dongBo, int idPhongBan, int idChiPhi,int idNhaCC,int idLydo,string soPO,string soRE,string tenDT)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuNhapNoiBo)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.idChungTuGoc = idChungTuGoc;
            this.trangThai = trangThai;
            this.GhiChu = ghiChu;
            this.NguoiLap = nguoiLap;
            this.DongBo = dongBo;
            this.IdChiPhi = idChiPhi;
            this.IdPhongBan = idPhongBan;
            this.IdNhaCC = idNhaCC;
            this.IdLyDo = idLydo;
            this.TenDT = tenDT;
            this.soPO = soPO;
            this.soRE = soRE;
            dgvChiTiet.AutoGenerateColumns = false;
            NhapNoiBoBussiness = new NhapNoiBoBussiness(new ChungTuNhapNoiBoInfor
            {
                IdChungTu = oid,
                SoChungTu = sochungtu,
                NgayLap = Convert.ToDateTime(ngaylap),
                SoChungTuGoc = sopo,
                LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_NOIBO)
            });
        }

        public frm_PhieuNhapNoiBo() : base(Declare.Prefix.PhieuNhapNoiBo)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            NhapNoiBoBussiness = new NhapNoiBoBussiness();
        }
        private void LoadLyDo()
        {
            liLyDo = DMLyDoTraHangDataProvider.Instance.GetListLyDoTraHangInfo();
            if (liLyDo.Count > 0)
            {
                cboLyDo.DataSource = liLyDo;
                cboLyDo.DisplayMember = "Ten";
                cboLyDo.ValueMember = "IdLyDoTH";
            }
            else
            {
                cboLyDo.DataSource = null;
            }
        }

        #region Event btePhongBan
        private void btePhongBan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_PhongBan frmLookUp = new frmLookUp_PhongBan(String.Format("%{0}%", btePhongBan.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                btePhongBan.Tag = frmLookUp.SelectedItem;
                btePhongBan.Text = frmLookUp.SelectedItem.TenPhongBan;
            }
        }

        private void btePhongBan_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_PhongBan frmLookUp = new frmLookUp_PhongBan(String.Format("%{0}%", btePhongBan.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                btePhongBan.Tag = frmLookUp.SelectedItem;
                btePhongBan.Text = frmLookUp.SelectedItem.TenPhongBan;
            }
        }

        private void btePhongBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_PhongBan frmLookUp = new frmLookUp_PhongBan(String.Format("%{0}%", btePhongBan.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    btePhongBan.Tag = frmLookUp.SelectedItem;
                    btePhongBan.Text = frmLookUp.SelectedItem.TenPhongBan;
                }
            }
        }
        #endregion

        #region Event bteChiPhi
        private void bteChiPhi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_ChiPhi frmLookUp = new frmLookUp_ChiPhi(String.Format("%{0}%", bteChiPhi.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteChiPhi.Tag = frmLookUp.SelectedItem;
                bteChiPhi.Text = frmLookUp.SelectedItem.Ten;
            }
        }

        private void bteChiPhi_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_ChiPhi frmLookUp = new frmLookUp_ChiPhi(String.Format("%{0}%", bteChiPhi.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteChiPhi.Tag = frmLookUp.SelectedItem;
                bteChiPhi.Text = frmLookUp.SelectedItem.Ten;
            }
        }

        private void bteChiPhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_ChiPhi frmLookUp = new frmLookUp_ChiPhi(String.Format("%{0}%", bteChiPhi.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteChiPhi.Tag = frmLookUp.SelectedItem;
                    bteChiPhi.Text = frmLookUp.SelectedItem.Ten;
                }
            }
        }
        #endregion 

        #region Event bteNhaCC

        private void bteNhaCC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhaCungCap frmLookUp = new frmLookUp_NhaCungCap(String.Format("%{0}%", bteNhaCC.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNhaCC.Tag = frmLookUp.SelectedItem;
                bteNhaCC.Text = frmLookUp.SelectedItem.TenDoiTuong;
            }
        }

        private void bteNhaCC_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_NhaCungCap frmLookUp = new frmLookUp_NhaCungCap(String.Format("%{0}%", bteNhaCC.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteNhaCC.Tag = frmLookUp.SelectedItem;
                bteNhaCC.Text = frmLookUp.SelectedItem.TenDoiTuong;
            }
        }

        private void bteNhaCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhaCungCap frmLookUp = new frmLookUp_NhaCungCap(String.Format("%{0}%", bteNhaCC.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteNhaCC.Tag = frmLookUp.SelectedItem;
                    bteNhaCC.Text = frmLookUp.SelectedItem.TenDoiTuong;
                }
            }
        }
        #endregion
        private bool Check()
        {
            if(dgvChiTiet.RowCount <= 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            if(chkDongBo.Checked)
            {
                if (btePhongBan.Tag == null || bteChiPhi.Tag == null || cboLyDo.SelectedValue == null)
                { throw new ManagedException("Bạn phải chọn phòng ban, chi phí và lý do mới đồng bộ dữ liệu được!"); }
            }
            //if(bteNhaCC.Tag == null)
            //{
            //    throw new InvalidOperationException("Bạn chưa chọn nhà cung cấp!");
            //}
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
                {
                    throw new InvalidExpressionException("Bạn chưa nhập số lượng!");
                }
            }
            //foreach (ChungTu_ChiTietInfo pt in NhapNoiBoBussiness.ListChiTietChungTu)
            //{
            //    if (pt.IdSanPham == 0)
            //    {
            //        throw new InvalidOperationException("Trong danh sách có sản phẩm bạn chưa thêm vào!");
            //    }
            //}
            ChungTu_ChiTietInfo pt = NhapNoiBoBussiness.ListChiTietChungTu.Find(delegate(ChungTu_ChiTietInfo match)
            {
                return match.IdSanPham == 0;
            });
            if (pt != null)
            {
                NhapNoiBoBussiness.ListChiTietChungTu.Remove(pt);
            }
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in NhapNoiBoBussiness.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in NhapNoiBoBussiness.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu > SumChiTietMaVach)
            {
                throw new InvalidExpressionException("Bạn chưa nhập đủ số mã vạch!");
            }
            return true;
        }

        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                if (NhapNoiBoBussiness.ChungTu.IdChungTu == 0)
                {
                    NhapNoiBoBussiness.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                    NhapNoiBoBussiness.ChungTu.IdNhanVien = Declare.IdNhanVien;
                    NhapNoiBoBussiness.ChungTu.IdKho = Declare.IdKho;
                    NhapNoiBoBussiness.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);
                    NhapNoiBoBussiness.ChungTu.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.Text);
                    NhapNoiBoBussiness.ChungTu.NguoiTao = txtNguoiLap.Text.Trim();
                    NhapNoiBoBussiness.ChungTu.SoPO = txtPO.Text.Trim();
                    NhapNoiBoBussiness.ChungTu.SoRE = txtSoRE.Text.Trim();
                    NhapNoiBoBussiness.ChungTu.IdLyDo = Convert.ToInt32(cboLyDo.SelectedValue);
                    NhapNoiBoBussiness.ChungTu.IdNhaCC = bteNhaCC.Tag != null ? ((DMDoiTuongInfo)bteNhaCC.Tag).IdDoiTuong : 0;
                    NhapNoiBoBussiness.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_NOIBO);                    
                }
                NhapNoiBoBussiness.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                NhapNoiBoBussiness.ChungTu.DongBo = Convert.ToInt32(chkDongBo.Checked);
                NhapNoiBoBussiness.ChungTu.IdPhongBan = btePhongBan.Tag != null ? ((DMPhongBanPairInfor)btePhongBan.Tag).IdPhongBan : 0;
                NhapNoiBoBussiness.ChungTu.IdChiPhi = bteChiPhi.Tag != null ? ((DMChiPhiInfo)bteChiPhi.Tag).IdChiPhi : 0;
                int SumChiTietMaVach = 0;
                int SumChiTietChungTu = 0;
                foreach (
                    ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in
                        NhapNoiBoBussiness.ListChiTietHangHoa)
                {
                    SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
                }
                foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in NhapNoiBoBussiness.ListChiTietChungTu)
                {
                    SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
                }
                if (SumChiTietChungTu == SumChiTietMaVach)
                {
                    NhapNoiBoBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDuyet.DA_XUAT);
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

            SaveChungTuInstance();

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

                            frmProgress.Instance.MaxValue = 10;
                            ChungTuBusinessBase clonedBusiness = Business.Clone();
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
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Nhập nội bộ");
                            }
                        }
                    });

            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //        {
            //            frmProgress.Instance.MaxValue = 10;
            //            ChungTuBusinessBase clonedBusiness = Business.Clone();
            //            frmProgress.Instance.Value += 1;
            //            clonedBusiness.SaveChungTu();
            //            frmProgress.Instance.Value += 1;
            //            AfterSaveChungTuInstance();
            //            frmProgress.Instance.Value += 1;
            //        });
            Reload();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmLookUp_SanPham frm = new frmLookUp_SanPham(0, 0, false, false);
            if (frm.ShowDialog()== DialogResult.OK)//nếu kết quả trả về là form LookUp
            {
                PickUpSanPhamInfo(frm.SelectedItem);
            }
        }

        private BindingSource bdSource;
        protected override void LoadDataInstance()
        {
            LoadLyDo();
            liChiTietChungTu.Clear();
            //load theo id của sản phẩm
            NhapNoiBoBussiness.ListChiTietChungTu = NhapNoiBoDataProvider.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
            bdSource = new BindingSource();
            bdSource.DataSource = new BindingList<ChungTu_ChiTietInfo>(NhapNoiBoBussiness.ListChiTietChungTu);
            bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);
            dgvChiTiet.DataSource = bdSource;
            if (IdNhaCC != 0)
            {
                DMDoiTuongInfo dmDoiTuong = DmDoiTuongProvider.GetDmDoiTuongInfoFromOid(IdNhaCC);
                bteNhaCC.Tag = dmDoiTuong;
                bteNhaCC.Text = dmDoiTuong.TenDoiTuong;
            }
            if(OID == 0)
            {
                txtNguoiLap.Text = Declare.UserName;
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            }
            else
            {
                txtNguoiLap.Text = NguoiLap;
                dtNgayLap.EditValue = Convert.ToDateTime(NgayLap);
            }
            if (DongBo == 1)
            { chkDongBo.Checked = true; }
            else
            {chkDongBo.Checked = false;}
            if (IdPhongBan != 0)
            {
                DMPhongBanInfor dmPhongBan = DMPhongBanDataProvider.Instance.GetFullInfoByKey(IdPhongBan);
                btePhongBan.Tag = dmPhongBan;
                btePhongBan.Text = dmPhongBan.TenPhongBan;
            }
            if (IdChiPhi != 0)
            {
                DMChiPhiInfo dmChiPhi = DMChiPhiDataProvider.Instance.GetFullInfoByKey(IdChiPhi);
                bteChiPhi.Tag = dmChiPhi;
                bteChiPhi.Text = dmChiPhi.Ten;
            }
            cboLyDo.SelectedValue = IdLyDo;
            txtGhiChu.Text = GhiChu;
            txtPO.Text = soPO;
            txtSoRE.Text = soRE;
            bteNhaCC.Text = TenDT;
            bteNhaCC.Tag = DmDoiTuongProvider.GetDmDoiTuongInfoFromOid(IdNhaCC);
            btnChiTietMaVach.Enabled = false;
            btnXoaSP.Enabled = false;
            btnCapNhat.Enabled = false;
            dtNgayLap.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT))
            {
                btnXoaSP.Enabled = false;
                btnThemSP.Enabled = false;
                btnCapNhat.Enabled = false;
                btnThemSP.Enabled = false;
                txtNguoiLap.Enabled = false;
                txtGhiChu.Enabled = false;
                txtPO.Enabled = false;
                bteNhaCC.Enabled = false;
                cboLyDo.Enabled = false;
                btePhongBan.Enabled = false;
                bteChiPhi.Enabled = false;
                dtNgayLap.Enabled = false;
                SoLuong.ReadOnly = true;
                chkDongBo.Enabled = false;
            }
            else
            {
                dtNgayLap.Enabled = false;
                btnCapNhat.Enabled = true;
                SoLuong.ReadOnly = false;
            }
        }

        void bdSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (dgvChiTiet.Rows.Count == bdSource.Count)
            {
                bdSource.RemoveAt(bdSource.Count - 1);
                return;
            }
        }

        protected override void GetValuesInstance(int e)
        {
            if(e < 0)
            {
                HangHoa = new ChungTuCTHanghoaBasePairInfo();
                return;
            }
            HangHoa.IdSanPham = NhapNoiBoBussiness.ListChiTietChungTu[e].IdSanPham;
            HangHoa.TenSanPham = NhapNoiBoBussiness.ListChiTietChungTu[e].TenSanPham;
            HangHoa.SoLuong = NhapNoiBoBussiness.ListChiTietChungTu[e].SoLuong;
            HangHoa.TrungMaVach = NhapNoiBoBussiness.ListChiTietChungTu[e].TrungMaVach;
            HangHoa.DonGia = NhapNoiBoBussiness.ListChiTietChungTu[e].DonGia;
            HangHoa.DonViTinh = NhapNoiBoBussiness.ListChiTietChungTu[e].TenDonViTinh;
            InDex = e;
            DonViTinh = NhapNoiBoBussiness.ListChiTietChungTu[e].TenDonViTinh;
            liChiTiet = NhapNoiBoBussiness.GetListChiTietHangHoaByIdSanPham(NhapNoiBoBussiness.ListChiTietChungTu[e].IdSanPham);
            //btnXoaSP.Enabled = HangHoa.IdSanPham > 0;
            btnChiTietMaVach.Enabled = HangHoa.IdSanPham > 0;
            //btnCapNhat.Enabled = HangHoa.IdSanPham > 0;
        }

        protected override DataGridViewTextBoxColumn ColumnMaSanPham
        {
            get { return colMaSanPham; }
        }

        protected override void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            foreach (ChungTu_ChiTietInfo pt in NhapNoiBoBussiness.ListChiTietChungTu)
            {
                if (pt.IdSanPham == sanPhamInfo.IdSanPham)
                {
                    MessageBox.Show("Không được nhập 2 mã sản phẩm giống nhau trên cùng 1 phiếu !");
                    return;
                }
            }
            NhapNoiBoBussiness.ListChiTietChungTu[dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow)] = new ChungTu_ChiTietInfo()
            {
                MaSanPham = sanPhamInfo.MaSanPham,
                IdSanPham = sanPhamInfo.IdSanPham,
                TenSanPham = sanPhamInfo.TenSanPham,
                DonGia = sanPhamInfo.GiaNhap,
                TrungMaVach = sanPhamInfo.TrungMaVach,
                Nganh = sanPhamInfo.Nganh,
                SoLuong = 1
            };
            ((BindingSource)dgvChiTiet.DataSource).ResetBindings(false);
            //btnCapNhat.Enabled = NhapNoiBoBussiness.ListChiTietChungTu.Count > 0;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return NhapNoiBoBussiness;
        }

        //HANHBD: hàm này dùng ở chỗ nào?
        //public void Delete()
        //{
        //    NhapNoiBoBussiness NhapNoiBoBussiness;
        //    //- lay infor nhap noi bo tren danh sach grid
        //    if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
        //    NhapNoiBoBussiness = new NhapNoiBoBussiness((ChungTuNhapNoiBoInfor)dgvChiTiet.CurrentRow.DataBoundItem);
        //    NhapNoiBoBussiness.DeleteChungTu();
        //}

        void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
                    btnXoaSP.Enabled = false;
                    btnCapNhat.Enabled = dgvChiTiet.Rows.Count > 0;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
                btnXoaSP.Enabled = false;
                btnCapNhat.Enabled = NhapNoiBoBussiness.ListChiTietChungTu.Count > 0;
            }
        }

        //private void dgvChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //}

        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                frm_ChiTietNhapNoiBo frm = new frm_ChiTietNhapNoiBo(this, HangHoa, liChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    NhapNoiBoBussiness.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = NhapNoiBoDataProvider.Instance.GetPhieuNhapNoiBoDetail(OID);
            rpt_BC_PhieuNhapNoiBo rpt =new rpt_BC_PhieuNhapNoiBo();
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void txtSoRE_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPO.Text) && !String.IsNullOrEmpty(txtSoRE.Text))
            {
                DMDoiTuongInfo pt = NhapNoiBoDataProvider.Instance.GetIdDoiTuongByPO(txtPO.Text, txtSoRE.Text);
                if (pt != null)
                {
                    DMDoiTuongInfo dmPhongBan = DmDoiTuongProvider.GetDmDoiTuongInfoFromOid(pt.IdDoiTuong);
                    bteNhaCC.Tag = dmPhongBan;
                    bteNhaCC.Text = dmPhongBan.TenDoiTuong;
                }
            }
        }
    }
}
