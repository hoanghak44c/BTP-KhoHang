using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Bussiness;
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

// form frm_PhieuXuatNoiBo
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 08/07/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD frm_PhieuXuatNoiBo
namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuXuatNoiBo : frmChiTiet_ChungTuNhapBase
    {
        #region Declare...
        public List<ChungTu_HangHoa_ChiTietInfor> liChungTu = new List<ChungTu_HangHoa_ChiTietInfor>();
        private int IdChiPhi, IdPhongBan, IdNhaCC, IdLyDo;
        private string soPO,soRE, TenDT; 
        List<DMPhongBanInfor> liPhongBan = new List<DMPhongBanInfor>();
        List<DMChiPhiInfo> liChiPhi = new List<DMChiPhiInfo>();
        List<DMLyDoTraHangInfo> liLyDo = new List<DMLyDoTraHangInfo>();
        public int idSanPham = 0;
        private int idChungTuGoc;
        private int trangThai;
        private int DongBo; 
        private frm_DanhSachPhieuXuatNoiBo frm;
        private XuatNoiBoBussiness XuatNoiBoBusiness;
        private CheckBox chkDongBo;
        private Label label5;
        private Label lblKhoHang;
        private DevExpress.XtraEditors.ButtonEdit bteNhaCC;
        private TextBox txtPO;
        private Label label7;
        private Label label6;
        private Label label8;
        private ComboBox cboLyDo;
        private DevExpress.XtraEditors.ButtonEdit btePhongBan;
        private DevExpress.XtraEditors.ButtonEdit bteChiPhi;
        private DataGridViewTextBoxColumn colMaSanPham;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn clSoLuong;
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
        #endregion

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuXuatNoiBo));
            this.chkDongBo = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.bteNhaCC = new DevExpress.XtraEditors.ButtonEdit();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboLyDo = new System.Windows.Forms.ComboBox();
            this.btePhongBan = new DevExpress.XtraEditors.ButtonEdit();
            this.bteChiPhi = new DevExpress.XtraEditors.ButtonEdit();
            this.colMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.btePhongBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteChiPhi.Properties)).BeginInit();
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
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSanPham,
            this.dataGridViewTextBoxColumn2,
            this.clSoLuong,
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
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 107);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 373);
            this.dgvChiTiet.TabIndex = 10;
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNguoiLap.Location = new System.Drawing.Point(517, 21);
            this.txtNguoiLap.Size = new System.Drawing.Size(168, 21);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(380, 79);
            this.txtGhiChu.Size = new System.Drawing.Size(561, 21);
            this.txtGhiChu.TabIndex = 9;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 13;
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 22);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(251, 22);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(449, 21);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(321, 79);
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
            this.txtSoPhieu.Location = new System.Drawing.Point(109, 21);
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(133, 20);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
            this.dtNgayLap.Location = new System.Drawing.Point(307, 21);
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(138, 20);
            this.dtNgayLap.TabIndex = 1;
            // 
            // chkDongBo
            // 
            this.chkDongBo.AutoSize = true;
            this.chkDongBo.Location = new System.Drawing.Point(442, 492);
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
            this.label5.Location = new System.Drawing.Point(694, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Chi phí";
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(694, 22);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(70, 16);
            this.lblKhoHang.TabIndex = 24;
            this.lblKhoHang.Text = "Phòng ban";
            // 
            // bteNhaCC
            // 
            this.bteNhaCC.Location = new System.Drawing.Point(488, 47);
            this.bteNhaCC.Name = "bteNhaCC";
            this.bteNhaCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteNhaCC.Size = new System.Drawing.Size(197, 20);
            this.bteNhaCC.TabIndex = 6;
            this.bteNhaCC.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteNhaCC_ButtonClick);
            this.bteNhaCC.DoubleClick += new System.EventHandler(this.bteNhaCC_DoubleClick);
            this.bteNhaCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteNhaCC_KeyDown);
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(111, 47);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(131, 21);
            this.txtPO.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Số PO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(429, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Nhà CC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 32;
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
            // btePhongBan
            // 
            this.btePhongBan.Location = new System.Drawing.Point(768, 21);
            this.btePhongBan.Name = "btePhongBan";
            this.btePhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btePhongBan.Size = new System.Drawing.Size(173, 20);
            this.btePhongBan.TabIndex = 3;
            this.btePhongBan.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btePhongBan_ButtonClick);
            this.btePhongBan.DoubleClick += new System.EventHandler(this.btePhongBan_DoubleClick);
            this.btePhongBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btePhongBan_KeyDown);
            // 
            // bteChiPhi
            // 
            this.bteChiPhi.Location = new System.Drawing.Point(768, 47);
            this.bteChiPhi.Name = "bteChiPhi";
            this.bteChiPhi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteChiPhi.Size = new System.Drawing.Size(173, 20);
            this.bteChiPhi.TabIndex = 7;
            this.bteChiPhi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteChiPhi_ButtonClick);
            this.bteChiPhi.DoubleClick += new System.EventHandler(this.bteChiPhi_DoubleClick);
            this.bteChiPhi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteChiPhi_KeyDown);
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
            // clSoLuong
            // 
            this.clSoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 50;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Thanhtien";
            this.dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 50;
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
            this.txtSoRE.Location = new System.Drawing.Point(326, 47);
            this.txtSoRE.Name = "txtSoRE";
            this.txtSoRE.Size = new System.Drawing.Size(97, 21);
            this.txtSoRE.TabIndex = 5;
            this.txtSoRE.Leave += new System.EventHandler(this.txtSoRE_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(251, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 34;
            this.label9.Text = "Số RE";
            // 
            // frm_PhieuXuatNoiBo
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
            this.Name = "frm_PhieuXuatNoiBo";
            this.Text = "Phiếu xuất nội bộ";
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
            ((System.ComponentModel.ISupportInitialize)(this.btePhongBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteChiPhi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //public frm_PhieuXuatNoiBo(frm_DanhSachPhieuXuatNoiBo frm)
        //{
        //    this.frm = frm;
        //    XuatNoiBoBusiness = new XuatNoiBoBussiness();
        //}

        public frm_PhieuXuatNoiBo(int oid, string sochungtu, string ngaylap, string sopo)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuXuatNoiBo)
        {
            InitializeComponent();
            XuatNoiBoBusiness = new XuatNoiBoBussiness(new ChungTuXuatNoiBoInfor
            {
                IdChungTu = oid,
                SoChungTu = sochungtu,
                NgayLap = Convert.ToDateTime(ngaylap),
                SoChungTuGoc = sopo
            });
        }

        public frm_PhieuXuatNoiBo(int oid, string sochungtu, string ngaylap, string sopo, int idChungTuGoc, int trangThai, string ghiChu, string nguoiLap, int dongBo, int idphongban, int idchiphi, int idNhaCC, int idLydo, string soPO,string soRE, string tenDT)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuXuatNoiBo)
        {
            InitializeComponent();
            this.idChungTuGoc = idChungTuGoc;
            this.trangThai = trangThai;
            this.GhiChu = ghiChu;
            this.NguoiLap = nguoiLap;
            this.DongBo = dongBo;
            this.IdPhongBan = idphongban;
            this.IdChiPhi = idchiphi;
            this.IdNhaCC = idNhaCC;
            this.IdLyDo = idLydo;
            this.TenDT = tenDT;
            this.soPO = soPO;
            this.soRE = soRE;
            XuatNoiBoBusiness = new XuatNoiBoBussiness(new ChungTuXuatNoiBoInfor
                   {
                       IdChungTu = oid,
                       SoChungTu = sochungtu,
                       NgayLap = Convert.ToDateTime(ngaylap),
                       SoChungTuGoc = sopo,
                       LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_NOI_BO)
                   });
        }

        public frm_PhieuXuatNoiBo()
            : base(Declare.Prefix.PhieuXuatNoiBo)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            XuatNoiBoBusiness = new XuatNoiBoBussiness();
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

        private BindingSource bdSource;

        void bdSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (dgvChiTiet.Rows.Count == bdSource.Count)
            {
                bdSource.RemoveAt(bdSource.Count - 1);
                return;
            }
        }
        protected override void LoadDataInstance()
        {
            LoadLyDo();
            liChiTietChungTu.Clear();
            //load theo id của sản phẩm
            XuatNoiBoBusiness.ListChiTietChungTu = XuatTieuHaoProvider.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
            bdSource = new BindingSource();
            bdSource.DataSource = new BindingList<ChungTu_ChiTietInfo>(XuatNoiBoBusiness.ListChiTietChungTu);
            bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);
            dgvChiTiet.DataSource = bdSource;
            if (IdNhaCC != 0)
            {
                DMDoiTuongInfo dmDoiTuong = DmDoiTuongProvider.GetDmDoiTuongInfoFromOid(IdNhaCC);
                bteNhaCC.Tag = dmDoiTuong;
                bteNhaCC.Text = dmDoiTuong.TenDoiTuong;
            }
            if (OID == 0)
            {
                txtNguoiLap.Text = Declare.UserName;
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
            }
            else
            {
                txtNguoiLap.Text = NguoiLap;
                dtNgayLap.EditValue = Convert.ToDateTime(NgayLap);
            }
            txtGhiChu.Text = GhiChu;
            if(DongBo == 1)
            {chkDongBo.Checked = true;}
            else
            {chkDongBo.Checked = false;}
            if (IdPhongBan != 0)
            {
                DMPhongBanInfor dmPhongBan = DMPhongBanDataProvider.Instance.GetFullInfoByKey(IdPhongBan);
                btePhongBan.Tag = dmPhongBan;
                btePhongBan.Text = dmPhongBan.TenPhongBan;
            }
            if (IdChiPhi!= 0)
            {
                DMChiPhiInfo dmChiPhi = DMChiPhiDataProvider.Instance.GetFullInfoByKey(IdChiPhi);
                bteChiPhi.Tag = dmChiPhi;
                bteChiPhi.Text = dmChiPhi.Ten;
            }
            cboLyDo.SelectedValue = IdLyDo;
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
                clSoLuong.ReadOnly = true;
                chkDongBo.Enabled = false;
            }
            else
            {
                dtNgayLap.Enabled = false;
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = false;
            }
        }

        protected override void GetValuesInstance(int e)
        {
            if (e < 0)
            {
                //HangHoa = null;
                return;
            }
            HangHoa.IdSanPham = XuatNoiBoBusiness.ListChiTietChungTu[e].IdSanPham;
            HangHoa.TenSanPham = XuatNoiBoBusiness.ListChiTietChungTu[e].TenSanPham;
            HangHoa.SoLuong = XuatNoiBoBusiness.ListChiTietChungTu[e].SoLuong;
            HangHoa.TrungMaVach = XuatNoiBoBusiness.ListChiTietChungTu[e].TrungMaVach;
            HangHoa.DonGia = XuatNoiBoBusiness.ListChiTietChungTu[e].DonGia;
            HangHoa.DonViTinh = XuatNoiBoBusiness.ListChiTietChungTu[e].TenDonViTinh;
            InDex = e;
            DonViTinh = XuatNoiBoBusiness.ListChiTietChungTu[e].TenDonViTinh;
            liChiTiet = XuatNoiBoBusiness.GetListChiTietHangHoaByIdSanPham(XuatNoiBoBusiness.ListChiTietChungTu[e].IdSanPham);
            //btnXoaSP.Enabled = HangHoa.IdSanPham > 0;
            btnChiTietMaVach.Enabled = HangHoa.IdSanPham > 0;
            //btnCapNhat.Enabled = HangHoa.IdSanPham > 0;
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            if (chkDongBo.Checked)
            {
                if (btePhongBan.Tag == null || bteChiPhi.Tag == null || cboLyDo.SelectedValue == null)
                { throw new ManagedException("Bạn phải chọn phòng ban, chi phí và lý do mới đồng bộ dữ liệu được!"); }
            }
            ChungTu_ChiTietInfo pt = XuatNoiBoBusiness.ListChiTietChungTu.Find(delegate(ChungTu_ChiTietInfo match)
            {
                return match.IdSanPham == 0;
            });
            if (pt != null)
            {
                XuatNoiBoBusiness.ListChiTietChungTu.Remove(pt);
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
                {
                    throw new InvalidExpressionException("Bạn chưa nhập số lượng!");
                }
            }
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in XuatNoiBoBusiness.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in XuatNoiBoBusiness.ListChiTietChungTu)
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
                if (XuatNoiBoBusiness.ChungTu.IdChungTu == 0)
                {
                    XuatNoiBoBusiness.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                    XuatNoiBoBusiness.ChungTu.IdNhanVien = Declare.IdNhanVien;
                    XuatNoiBoBusiness.ChungTu.IdKho = Declare.IdKho;
                    XuatNoiBoBusiness.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);
                    XuatNoiBoBusiness.ChungTu.NgayNhapXuatKho = Convert.ToDateTime(dtNgayLap.Text);
                    XuatNoiBoBusiness.ChungTu.NguoiTao = txtNguoiLap.Text.Trim();
                    XuatNoiBoBusiness.ChungTu.SoPO = txtPO.Text.Trim();
                    XuatNoiBoBusiness.ChungTu.SoRE = txtSoRE.Text.Trim();
                    XuatNoiBoBusiness.ChungTu.IdLyDo = Convert.ToInt32(cboLyDo.SelectedValue);
                    XuatNoiBoBusiness.ChungTu.IdNhaCC = bteNhaCC.Tag != null ? ((DMDoiTuongInfo)bteNhaCC.Tag).IdDoiTuong : 0;
                    XuatNoiBoBusiness.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_NOI_BO);
                }
                XuatNoiBoBusiness.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                XuatNoiBoBusiness.ChungTu.DongBo = Convert.ToInt32(chkDongBo.Checked);
                XuatNoiBoBusiness.ChungTu.IdPhongBan = btePhongBan.Tag != null ? ((DMPhongBanPairInfor)btePhongBan.Tag).IdPhongBan : 0;
                XuatNoiBoBusiness.ChungTu.IdChiPhi = bteChiPhi.Tag != null ? ((DMChiPhiInfo)bteChiPhi.Tag).IdChiPhi : 0;
                int SumChiTietMaVach = 0;
                int SumChiTietChungTu = 0;
                foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in XuatNoiBoBusiness.ListChiTietHangHoa)
                {
                    SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
                }
                foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in XuatNoiBoBusiness.ListChiTietChungTu)
                {
                    SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
                }
                if (SumChiTietChungTu == SumChiTietMaVach)
                {
                    XuatNoiBoBusiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDuyet.DA_XUAT);
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
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Xuất nội bộ");
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

        protected override ChungTuBusinessBase GetBussiness()
        {
            return XuatNoiBoBusiness;
        }
        protected override void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            foreach (ChungTu_ChiTietInfo pt in XuatNoiBoBusiness.ListChiTietChungTu)
            {
                if (pt.IdSanPham == sanPhamInfo.IdSanPham)
                {
                    MessageBox.Show("Không được nhập 2 mã sản phẩm giống nhau trên cùng 1 phiếu !");
                    return;
                }
            }
            List<TonDauKyInfo> item = DeNghiDieuChuyenDataProvider.Instance.GetListHangTonKhoByIdSanPham(Declare.IdKho, sanPhamInfo.IdSanPham);
            if (item.Count > 0)
            {
                MessageBox.Show("Sản phẩm đã hết tồn kho xin mời bạn chọn hàng khác!");
                return;
            }
            XuatNoiBoBusiness.ListChiTietChungTu[dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow)] = new ChungTu_ChiTietInfo()
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
            //btnCapNhat.Enabled = XuatNoiBoBusiness.ListChiTietChungTu.Count > 0;
        }
        protected override DataGridViewTextBoxColumn ColumnMaSanPham
        {
            get
            {
                return colMaSanPham;
            }
        }

        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                frm_ChiTietXuatNoiBo frm = new frm_ChiTietXuatNoiBo(this, HangHoa, liChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    XuatNoiBoBusiness.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvChiTiet.Rows.Count > 0)
                {
                    dgvChiTiet.Rows.RemoveAt(dgvChiTiet.CurrentRow.Index);
                    btnXoaSP.Enabled = false;
                    btnCapNhat.Enabled = XuatNoiBoBusiness.ListChiTietChungTu.Count > 0;
                }
            }
        }

        private void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
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

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmLookUp_SanPham frm = new frmLookUp_SanPham();
            if (frm.ShowDialog() == DialogResult.OK)//nếu kết quả trả về là form LookUp
            {
                PickUpSanPhamInfo(frm.SelectedItem);
            }
        }

        private void btnChiTietMaVach_Click(object sender, EventArgs e)
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                frm_ChiTietXuatNoiBo frm = new frm_ChiTietXuatNoiBo(this, HangHoa, liChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    XuatNoiBoBusiness.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = XuatNoiBoDataProvider.Instance.GetPhieuXuatNoiBoDetail(OID);
            rpt_BC_PhieuXuatNoiBo rpt = new rpt_BC_PhieuXuatNoiBo();
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

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

        private void txtSoRE_Leave(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPO.Text) && !String.IsNullOrEmpty(txtSoRE.Text))
            {
                DMDoiTuongInfo pt = NhapNoiBoDataProvider.Instance.GetIdDoiTuongByPO(txtPO.Text,txtSoRE.Text);
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
