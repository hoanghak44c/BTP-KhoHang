using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

// form frmChiTiet_ChungTuNhap
// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:


namespace QLBanHang.Modules.KhoHang
{
    public class frmChiTietChungTuNhapNcc : frmChiTiet_ChungTuNhapBase
    {
        private NhapNccBusiness khoBusiness;
        private NhapNccBusiness clonedBusiness;
        List<ChungTuXuatNhapNccChiTietInfo> listCTChungTu;
        private frm_ListChungTuNhap frm;
        //private KeToanNhapNccBusiness keToanBusiness;

        private List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet;
        private DateTime ngayLap;
        private string fullNameNhap, TenCTCK,TienCTCK;
        ArrayList arTran = new ArrayList();
        public int TrangThai;
        private List<ChungTuNhapNccChiTietHangHoaInfo> ListAll;
        private TextBox txtNCC;
        private Label label5;
        private TextBox txtFullNameNhap;
        private Label label6;
        private TextBox txtTenCTCK;
        private Label label7;
        private TextBox txtTienCTCK;
        private Label label8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colTenCTCK;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn clNganh;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        public QLBH.Core.Form.GtidSimpleButton gtidSimpleButton1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietChungTuNhapNcc));
            this.gtidSimpleButton1 = new QLBH.Core.Form.GtidSimpleButton();
            this.txtNCC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullNameNhap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenCTCK = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTienCTCK = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenCTCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemSP
            // 
            this.btnThemSP.TabIndex = 7;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 8;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 13;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colTenCTCK,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.clNganh,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 158);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 322);
            this.dgvChiTiet.TabIndex = 6;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Size = new System.Drawing.Size(573, 21);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(693, 21);
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 14;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.TabIndex = 10;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(638, 486);
            this.btnXacNhan.TabIndex = 12;
            this.btnXacNhan.Text = "Import mã";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
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
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.TabIndex = 1;
            // 
            // gtidSimpleButton1
            // 
            this.gtidSimpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("gtidSimpleButton1.Image")));
            this.gtidSimpleButton1.Location = new System.Drawing.Point(439, 487);
            this.gtidSimpleButton1.Name = "gtidSimpleButton1";
            this.gtidSimpleButton1.ShortCutKey = System.Windows.Forms.Keys.F11;
            this.gtidSimpleButton1.Size = new System.Drawing.Size(95, 25);
            this.gtidSimpleButton1.TabIndex = 11;
            this.gtidSimpleButton1.Text = "In mã vạch";
            // 
            // txtNCC
            // 
            this.txtNCC.Enabled = false;
            this.txtNCC.Location = new System.Drawing.Point(117, 77);
            this.txtNCC.Name = "txtNCC";
            this.txtNCC.Size = new System.Drawing.Size(824, 21);
            this.txtNCC.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Nhà cung cấp";
            // 
            // txtFullNameNhap
            // 
            this.txtFullNameNhap.Enabled = false;
            this.txtFullNameNhap.Location = new System.Drawing.Point(768, 46);
            this.txtFullNameNhap.Name = "txtFullNameNhap";
            this.txtFullNameNhap.Size = new System.Drawing.Size(173, 21);
            this.txtFullNameNhap.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(693, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Người nhập";
            // 
            // txtTenCTCK
            // 
            this.txtTenCTCK.Enabled = false;
            this.txtTenCTCK.Location = new System.Drawing.Point(117, 104);
            this.txtTenCTCK.Name = "txtTenCTCK";
            this.txtTenCTCK.Size = new System.Drawing.Size(824, 21);
            this.txtTenCTCK.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Tên CTCK";
            // 
            // txtTienCTCK
            // 
            this.txtTienCTCK.Enabled = false;
            this.txtTienCTCK.Location = new System.Drawing.Point(117, 131);
            this.txtTienCTCK.Name = "txtTienCTCK";
            this.txtTienCTCK.Size = new System.Drawing.Size(824, 21);
            this.txtTienCTCK.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tiền CTCK";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaSanPham";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã sản phẩm";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // colTenCTCK
            // 
            this.colTenCTCK.DataPropertyName = "TenCTCK";
            this.colTenCTCK.HeaderText = "Tên CTCK";
            this.colTenCTCK.MinimumWidth = 200;
            this.colTenCTCK.Name = "colTenCTCK";
            this.colTenCTCK.Width = 200;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clNganh
            // 
            this.clNganh.DataPropertyName = "TenNganhHang";
            this.clNganh.HeaderText = "Ngành hàng";
            this.clNganh.MinimumWidth = 200;
            this.clNganh.Name = "clNganh";
            this.clNganh.ReadOnly = true;
            this.clNganh.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TrangThai";
            this.dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 170;
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
            // frmChiTietChungTuNhapNcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.txtTienCTCK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTenCTCK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFullNameNhap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gtidSimpleButton1);
            this.Controls.Add(this.txtNCC);
            this.Controls.Add(this.label5);
            this.Name = "frmChiTietChungTuNhapNcc";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNCC, 0);
            this.Controls.SetChildIndex(this.gtidSimpleButton1, 0);
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
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtFullNameNhap, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtTenCTCK, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtTienCTCK, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frmChiTietChungTuNhapNcc(frm_ListChungTuNhap frm, ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo,
            DateTime ngaylap,string fullname,string tenCTCK,string tienCTCK) : base(chungTuXuatNhapNccInfo.IdChungTu, chungTuXuatNhapNccInfo.SoChungTu, chungTuXuatNhapNccInfo.NgayLap.ToString(), chungTuXuatNhapNccInfo.SoPO, Declare.Prefix.PhieuNhapHangMua)
        {
            InitializeComponent();
            this.frm = frm;
            khoBusiness = new NhapNccBusiness(chungTuXuatNhapNccInfo);
            ngayLap = ngaylap;
            fullNameNhap = fullname;
            TenCTCK = tenCTCK;
            TienCTCK = tienCTCK;
        }

        public frmChiTietChungTuNhapNcc(int oid, string sochungtu, string ngaylap, string sopo) : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuNhapHangMua)
        {
            InitializeComponent();
            khoBusiness = new NhapNccBusiness(new ChungTuXuatNhapNccInfo{IdChungTu = oid,SoChungTu = sochungtu,NgayLap = Convert.ToDateTime(ngaylap),SoPO = sopo, LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_PO)});
            ngayLap = Convert.ToDateTime(ngaylap);
        }

        

        protected override void LoadDataInstance()
        {
            btnXacNhan.Visible = true;
            if (OID == 0)
            {
                listCTChungTu = KeToanNhapNccDataProvider.Instance.GetListNhapHangUserInfoFromOid(SoPO, khoBusiness.ChungTu.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), ngayLap, OID);
            }
            else
            {
                khoBusiness.ListChiTietChungTu = KhoNhapNccDataProvider.Instance.GetListChiTietChungTuByIdChungTu(OID);
                listCTChungTu = KeToanNhapNccDataProvider.Instance.GetListNhapHangUserInfoFromOid(SoPO, khoBusiness.ChungTu.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP), ngayLap, OID);
                for (int i = 0; i < khoBusiness.ListChiTietChungTu.Count; i++)
                {
                    arTran.Add(khoBusiness.ListChiTietChungTu[i].TransactionID);
                }
                TrangThai = khoBusiness.ChungTu.TrangThai;
            }
            for (int i = 0; i < listCTChungTu.Count; i++)
            {
                if (listCTChungTu.Count > 0 && OID > 0)
                {
                    foreach (ChungTuXuatNhapNccChiTietInfo pt in khoBusiness.ListChiTietChungTu)
                    {
                        if (pt.IdSanPham == listCTChungTu[i].IdSanPham && 
                            pt.TransactionID == listCTChungTu[i].TransactionID)
                        {
                            listCTChungTu[i].TrangThai = pt.SoLuong == listCTChungTu[i].SoLuong ? "Đã nhập đủ" : "Chưa nhập đủ";
                        }
                    }
                    if (listCTChungTu[i].TrangThai == null)
                    {
                        listCTChungTu[i].TrangThai = "Chưa nhập";
                    }
                }
                else
                {
                    listCTChungTu[i].TrangThai = "Chưa nhập";
                }
            }
            txtSoPhieu.Text = khoBusiness.ChungTu.SoChungTu;
            txtNguoiLap.Text = khoBusiness.ChungTu.NguoiNhap;
            txtNCC.Text = khoBusiness.ChungTu.NCC;
            txtFullNameNhap.Text = fullNameNhap;
            txtTenCTCK.Text = TenCTCK;
            txtTienCTCK.Text = TienCTCK;
            if (khoBusiness.ChungTu.IdChungTu != 0)
            {
                dtNgayLap.Text = khoBusiness.ChungTu.NgayLap.ToString();
                btnCapNhat.Enabled = false;
            }
            else
            {
                dtNgayLap.Text = CommonProvider.Instance.GetSysDate().ToString();
                btnCapNhat.Enabled = true;
            }
            btnXoaSP.Visible = false;
            btnChiTietMaVach.Visible = false;
            btnThemSP.Visible = false;
            txtNguoiLap.Enabled = false;
            dtNgayLap.Enabled = false;
            dgvChiTiet.DataSource = listCTChungTu;
            if (IsSupperUser())
            {
                //btnXoaSP.Visible = true;
            }
            if (CheckIn())
            {
                btnInPhieu.Enabled = true;
            }
            else
            {
                btnInPhieu.Enabled = false;
            }
            if (CheckImport())
            {
                btnXacNhan.Enabled = false;
            }
            else
            {
                btnXacNhan.Enabled = true;
            }
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return khoBusiness;
        }

        private bool CheckIn()
        {
            int count =0;
            for (int i = 0; i <listCTChungTu.Count; i++)
            {
                if (listCTChungTu[i].TrangThai == "Đã nhập đủ")
                {
                    count++;
                }
            }
            if (count == listCTChungTu.Count)
            {
                return true;
            }
            
            return false;
        }

        private bool CheckImport()
        {
            int count = 0;

            for (int i = 0; i < listCTChungTu.Count; i++)
            {
                if (listCTChungTu[i].TrangThai == "Đã nhập đủ")
                {
                    count++;
                }
            }
            if (count == listCTChungTu.Count)
            {
                return true;
            }

            return false;
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

                        frmProgress.Instance.MaxValue = 15;
                        clonedBusiness = (NhapNccBusiness)Business.Clone();
                        frmProgress.Instance.Value += 1;
                        clonedBusiness.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();
                        frmProgress.Instance.Value += 1;
                        clonedBusiness.ChungTu.NgayXuatHang = CommonProvider.Instance.GetSysDate();
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
                            EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Chứng từ nhập NCC");
                        }
                    }
                });
            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //    {
            //        frmProgress.Instance.MaxValue = 15;
            //        clonedBusiness = (NhapNccBusiness)Business.Clone();
            //        frmProgress.Instance.Value += 1;
            //        clonedBusiness.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();
            //        frmProgress.Instance.Value += 1;
            //        clonedBusiness.ChungTu.NgayXuatHang = CommonProvider.Instance.GetSysDate();
            //        frmProgress.Instance.Value += 1;
            //        clonedBusiness.SaveChungTu();
            //        frmProgress.Instance.Value += 1;
            //        AfterSaveChungTuInstance();
            //        frmProgress.Instance.Value += 1;
            //    });
            Reload();

        }

        protected override void SaveChungTuInstance()
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = khoBusiness.ChungTu;
            if (chungTuXuatNhapNccInfo.IdChungTu ==0)
            {
                chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
                chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_PO);
                chungTuXuatNhapNccInfo.SoChungTu = txtSoPhieu.Text.Trim();
                chungTuXuatNhapNccInfo.GhiChu = txtGhiChu.Text.Trim();
                chungTuXuatNhapNccInfo.TrangThai = 1;
                chungTuXuatNhapNccInfo.NgayLap = CommonProvider.Instance.GetSysDate();
                chungTuXuatNhapNccInfo.NgayXuatHang = CommonProvider.Instance.GetSysDate();
                chungTuXuatNhapNccInfo.NgayHenGiaoHang = ngayLap;
            }
            foreach (ChungTuNhapNccChiTietHangHoaInfo pt in khoBusiness.ListChiTietHangHoa)
            {
                if (String.IsNullOrEmpty(pt.MaVach))
                    throw new ManagedException("Mã vạch không được để trống.");

                if (pt.TrungMaVach == 0)
                {
                    if (ListAll.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
                    {
                        return ct.MaVach == pt.MaVach;
                    }).Count > 1)
                    {
                        throw new ManagedException("Mã vạch " + pt.MaVach + " bị trùng . Xin hãy kiểm tra lại !");
                    }

                    if (ListAll.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
                    {
                        return ct.MaVach == pt.MaVach && ct.IdSanPham != pt.IdSanPham;
                    }).Count > 0)
                    {
                        throw new ManagedException("Mã vạch " + pt.MaVach + " bị trùng . Xin hãy kiểm tra lại !");
                    }
                }
                else
                {
                    if (ListAll.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
                    {
                        return ct.MaVach == pt.MaVach && ct.IdSanPham != pt.IdSanPham;
                    }).Count > 1)
                    {
                        throw new ManagedException("Mã vạch " + pt.MaVach + " bị trùng . Xin hãy kiểm tra lại !");
                    }
                }
            }
            for (int i = 0; i < listCTChungTu.Count; i++)
            {
                if (listCTChungTu[i].TrangThai != "Đã nhập đủ")
                {
                    throw new ManagedException("Bạn chưa nhập đủ số lượng trong phiếu nhập !");
                }
            }
            if (chungTuXuatNhapNccInfo.IdDoiTuong==0)
            {
                throw new ManagedException("Không tìm thấy mã nhà cung cấp trong hệ thống! Đề nghị Data kiểm tra lại.");
            }
        }

        protected override void Reload()
        {
            frm.Reload();
        }

        protected override void AfterSaveChungTuInstance()
        {
            if (khoBusiness.ListChiTietChungTu.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < listCTChungTu.Count; i++)
                {
                    if (listCTChungTu[i].TrangThai == "Đã nhập đủ")
                    {
                        count++;
                    }
                }
                if (listCTChungTu.Count == count)
                {
                    KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(
                        new ChungTuXuatNhapNccInfo { IdChungTu = clonedBusiness.ChungTu.IdChungTu, TrangThai = 2 });
                }
                else
                {
                    KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(
                        new ChungTuXuatNhapNccInfo { IdChungTu = clonedBusiness.ChungTu.IdChungTu, TrangThai = 1 });
                }
            }
        }
        
        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && HangHoa.IdSanPham != 0)
            {
                frmChungTuChiTietHanghoaNhapNcc frm = new frmChungTuChiTietHanghoaNhapNcc(this, HangHoa,liChiTiet,ListAll,TrangThai);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ChungTuXuatNhapNccChiTietInfo ct = listCTChungTu[InDex];
                    if (!arTran.Contains(ct.TransactionID))
                    {
                        khoBusiness.ListChiTietChungTu.Add(ct);
                        arTran.Add(ct.TransactionID);
                        khoBusiness.MergeChiTietHangHoa(frm.liChiTiet,
                                                    delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                                                    {
                                                        return khoBusiness.Conjunction(
                                                            khoBusiness.ListChiTietChungTu[khoBusiness.ListChiTietChungTu.IndexOf(ct)],
                                                            match);
                                                    });
                        khoBusiness.ListChiTietChungTu[khoBusiness.ListChiTietChungTu.IndexOf(ct)].TrangThai = "Đã nhập đủ";
                    }
                    else
                    {
                        ChungTuXuatNhapNccChiTietInfo chiTietMaVach = khoBusiness.ListChiTietChungTu.Find(
                                delegate(ChungTuXuatNhapNccChiTietInfo match)
                                    {
                                        return match.TransactionID == ct.TransactionID;
                                    });
                        khoBusiness.MergeChiTietHangHoa(frm.liChiTiet,
                                                    delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                                                    {
                                                        return khoBusiness.Conjunction(
                                                            khoBusiness.ListChiTietChungTu[khoBusiness.ListChiTietChungTu.IndexOf(chiTietMaVach)],
                                                            match);
                                                    });
                        khoBusiness.ListChiTietChungTu[khoBusiness.ListChiTietChungTu.IndexOf(chiTietMaVach)].TrangThai = "Đã nhập đủ";
                    }
                    listCTChungTu[listCTChungTu.IndexOf(ct)].TrangThai = "Đã nhập đủ";
                    dgvChiTiet.DataSource = null;
                    dgvChiTiet.DataSource = listCTChungTu;
                }
            }
        }

        protected override void GetValuesInstance(int e)
        {
            HangHoa.IdSanPham = listCTChungTu[e].IdSanPham;
            HangHoa.TenSanPham = listCTChungTu[e].TenSanPham;
            HangHoa.SoLuong = listCTChungTu[e].SoLuong;
            HangHoa.TrungMaVach = listCTChungTu[e].TrungMaVach;
            HangHoa.DonGia = listCTChungTu[e].DonGia;
            HangHoa.DonViTinh = listCTChungTu[e].TenDonViTinh;
            HangHoa.TransactionID = listCTChungTu[e].TransactionID;
            InDex = e;
            DonViTinh = listCTChungTu[e].TenDonViTinh;
            liChiTiet = khoBusiness.GetListChiTietHangHoaByConjunction(
                delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                    {
                        return khoBusiness.Conjunction(
                            listCTChungTu[e],
                            match);
                    });
            ListAll = khoBusiness.ListChiTietHangHoa;
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if (khoBusiness.ChungTu.TrangThai != 1)
            {
                if (khoBusiness.ChungTu.TrangThai != 3)
                {
                    if (clsUtils.MsgXoa("Sau khi in phiếu bạn không thể sửa lại phiếu nhập này nữa . Bạn có chắc chắn muốn in không ?") == DialogResult.Yes)
                    {
                        frmChonBaoCao frm = new frmChonBaoCao();
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                        {
                            if (frm.Value == 1)
                            {
                                List<BaoCao_PhieuNhapMuaNCCInfor> list = tblChungTuDataProvider.GetPhieuNhapNCC(OID);
                                rpt_BC_PhieuNhapHangMuaTongHop rpt = new rpt_BC_PhieuNhapHangMuaTongHop();
                                List<BaoCao_PhieuNhapMuaNCCInfor> lst = new List<BaoCao_PhieuNhapMuaNCCInfor>(list);
                                rpt.DataSource = lst;
                                rpt.ShowPreview();
                                KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(
                                        new ChungTuXuatNhapNccInfo { IdChungTu = khoBusiness.ChungTu.IdChungTu, TrangThai = 3 });
                            }
                            else
                            {
                                List<BaoCao_PhieuNhapMuaNCCInfor> list = tblChungTuDataProvider.GetPhieuNhapPOTongHop(OID);
                                rpt_BC_PhieuNhapHangMuaNCC rpt = new rpt_BC_PhieuNhapHangMuaNCC();
                                List<BaoCao_PhieuNhapMuaNCCInfor> lst = new List<BaoCao_PhieuNhapMuaNCCInfor>(list);
                                rpt.DataSource = lst;
                                rpt.ShowPreview();
                                KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(
                                        new ChungTuXuatNhapNccInfo { IdChungTu = khoBusiness.ChungTu.IdChungTu, TrangThai = 3 });
                            }
                        }
                    }
                }
                else
                {
                    frmChonBaoCao frm = new frmChonBaoCao();
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        if (frm.Value == 1)
                        {
                            List<BaoCao_PhieuNhapMuaNCCInfor> list = tblChungTuDataProvider.GetPhieuNhapNCC(OID);
                            rpt_BC_PhieuNhapHangMuaTongHop rpt = new rpt_BC_PhieuNhapHangMuaTongHop();
                            List<BaoCao_PhieuNhapMuaNCCInfor> lst = new List<BaoCao_PhieuNhapMuaNCCInfor>(list);
                            rpt.DataSource = lst;
                            rpt.ShowPreview();
                            KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(
                                    new ChungTuXuatNhapNccInfo { IdChungTu = khoBusiness.ChungTu.IdChungTu, TrangThai = 3 });
                        }
                        else
                        {
                            List<BaoCao_PhieuNhapMuaNCCInfor> list = tblChungTuDataProvider.GetPhieuNhapPOTongHop(OID);
                            rpt_BC_PhieuNhapHangMuaNCC rpt = new rpt_BC_PhieuNhapHangMuaNCC();
                            List<BaoCao_PhieuNhapMuaNCCInfor> lst = new List<BaoCao_PhieuNhapMuaNCCInfor>(list);
                            rpt.DataSource = lst;
                            rpt.ShowPreview();
                            KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(
                                    new ChungTuXuatNhapNccInfo { IdChungTu = khoBusiness.ChungTu.IdChungTu, TrangThai = 3 });
                        }
                    }
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Phiếu chưa xuất đủ . Không thể in !");
                return;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if(khoBusiness.ListChiTietHangHoa.Count == 0)
                {
                    tmp_NhapHang_LogDataProvider.Delete(khoBusiness.ChungTu.SoPO, khoBusiness.ChungTu.SoPhieuNhap,
                                                        Convert.ToInt32(LoaiGiaoDichPO.NHAP_HANG_NHA_CUNG_CAP),
                                                        Declare.IdKho);
                }
                base.OnClosing(e);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif

            }
        }

        private List<ChungTuXuatNhapNccChiTietInfo> check(List<ChungTuXuatNhapNccChiTietInfo> lst,DataSet ds)
        {
            List<ChungTuXuatNhapNccChiTietInfo> lichitiet = new List<ChungTuXuatNhapNccChiTietInfo>();
            if (lst.Count > 0)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    ChungTuNhapNccChiTietHangHoaInfo chiTietMaVach = khoBusiness.ListChiTietHangHoa.Find(
                                    delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                                    {
                                        return
                                            match.TransactionID == lst[i].TransactionID;
                                    });
                    if (chiTietMaVach == null)
                    {
                        lichitiet.Add(lst[i]);
                    }
                }
            }
            else
            {
                lichitiet.AddRange(lst);
            }
            for (int i = 0; i < lichitiet.Count; i++)
            {
                CheckTrungMaVach(lichitiet[i],ds);
            }
            lichitiet.Sort(delegate(ChungTuXuatNhapNccChiTietInfo item1, ChungTuXuatNhapNccChiTietInfo item2)
                               {
                                   return item1.MaSanPham.CompareTo(item2.MaSanPham);

                               });
            return lichitiet;
        }

        private int GetIdSP(string MaSP)
        {
            DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(MaSP);
            if (sp != null)
            {
                return sp.IdSanPham;
            }
            else
            {
                return 0;
            }
        }

        private void CheckTrungMaVach(ChungTuXuatNhapNccChiTietInfo chungTuChiTietInfor,DataSet ds)
        {
            int TrungMaVach = 0;
            int SoLuongMaVach = 0;
            ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
            DataTable tableTemp = ds.Tables["HangHoaChiTiet"].DefaultView.ToTable("Temp");
            ds.Tables["CheckTrungMaVach"].DefaultView.RowFilter = String.Format("MaSanPham='{0}' and SoLuong > 1", chungTuChiTietInfor.MaSanPham);
            DataTable tblCheck = ds.Tables["CheckTrungMaVach"].DefaultView.ToTable("Temp");
            DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(chungTuChiTietInfor.MaSanPham);
            if (sp != null)
            {
                TrungMaVach = sp.TrungMaVach;
            }
            for (int i = 0; i < tableTemp.Rows.Count; i++)
            {
                SoLuongMaVach += Convert.ToInt32(tableTemp.Rows[i]["SoLuong"]);
            }
            if (SoLuongMaVach < chungTuChiTietInfor.SoLuong && SoLuongMaVach > 0)
            {
                throw new ManagedException("số lượng mã vạch của mã hàng :" + chungTuChiTietInfor.MaSanPham + " không khớp trong file import . Xin hãy kiểm tra lại!");
            }
            for (int i = 0; i < tableTemp.Rows.Count; i++)
            {
                if (ListAll.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
                { return ct.MaVach == tableTemp.Rows[i]["MaVach"].ToString().Trim() 
                    && GetIdSP(tableTemp.Rows[i]["MaSanPham"].ToString().Trim()) != ct.IdSanPham; }).Count > 0)
                {
                    throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[i]["MaVach"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                }
            }
            if (TrungMaVach == 0)
            {
                
                for (int i = 0; i < tableTemp.Rows.Count; i++)
                {
                    ChungTuNhapNccChiTietHangHoaInfo chiTietMaVach = khoBusiness.ListChiTietHangHoa.Find(
                    delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                    {
                        return match.MaVach == tableTemp.Rows[i]["MaVach"].ToString();
                    });
                    if (string.IsNullOrEmpty(tableTemp.Rows[i]["MaVach"].ToString().Trim()))
                    {
                        throw new InvalidOperationException("Mã vạch của mã sản phẩm " + tableTemp.Rows[i]["MaSanPham"] + " đang để trống !");
                    }
                    if (chiTietMaVach != null)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[i]["MaVach"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachTP(sp.IdSanPham, tableTemp.Rows[i]["MaVach"].ToString()) > 0)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[i]["MaVach"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(sp.IdSanPham, tableTemp.Rows[i]["MaVach"].ToString()) > 0)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[i]["MaVach"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                }
                if (tblCheck.Rows.Count > 0)
                {
                    throw new InvalidOperationException("Mã sản phẩm : " + sp.MaSanPham + " có mã vạch " + tblCheck.Rows[0]["MaVach"] + " bị trùng. Xin hãy kiểm tra lại !");
                }
            }
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

                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, [SO_LUONG] as SoLuong from [Items$] where [SERIAL] is not null and [MA_HANG_HOA] is not null";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "HangHoaChiTiet");
                        }
                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, sum([SO_LUONG]) as SoLuong from [Items$] group by [MA_HANG_HOA],[SERIAL]";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "CheckTrungMaVach");
                        }
                    }

                    int x = 0;
                    string MaSP = "";
                    foreach (ChungTuXuatNhapNccChiTietInfo chungTuChiTietInfor in check(listCTChungTu,ds))
                    {
                        //int TrungMaVach = 0;
                        //DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(chungTuChiTietInfor.MaSanPham);
                        //if (sp != null)
                        //{
                        //    TrungMaVach = sp.TrungMaVach;
                        //}
                        int count = 0;
                        //ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        //DataTable tableTemp = ds.Tables["HangHoaChiTiet"].DefaultView.ToTable("Temp");
                        ds.Tables["CheckTrungMaVach"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        DataTable tblCheck = ds.Tables["CheckTrungMaVach"].DefaultView.ToTable("Temp");
                        #region
                        //foreach (DataRow dataRow in tblCheck.Rows)
                        //{
                        //    if (dataRow["MaVach"] == DBNull.Value || String.IsNullOrEmpty(Convert.ToString(dataRow["MaVach"])))
                        //    {
                        //        throw new ManagedException("Đang có dòng không được nhập mã vạch.");
                        //    }

                        //    ChungTuNhapNccChiTietHangHoaInfo chiTietMaVach = khoBusiness.ListChiTietHangHoa.Find(
                        //        delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                        //            {
                        //                return match.MaVach == Convert.ToString(dataRow["MaVach"]);
                        //            });
                        //    ChungTuNhapNccChiTietHangHoaInfo chiTietTransactionID = khoBusiness.ListChiTietHangHoa.Find(
                        //        delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                        //        {
                        //            return match.MaVach == Convert.ToString(dataRow["MaVach"]) 
                        //                && match.TransactionID == chungTuChiTietInfor.TransactionID;
                        //        });
                        //    if (count < chungTuChiTietInfor.SoLuong)
                        //    {
                        //        if (TrungMaVach == 0)
                        //        {
                        //            // không cho trùng mã vạch
                        //            if (chiTietTransactionID == null && chiTietMaVach == null)
                        //            {
                        //                khoBusiness.ListChiTietHangHoa.Add(
                        //                new ChungTuNhapNccChiTietHangHoaInfo
                        //                {
                        //                    IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //                    IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //                    MaVach = Convert.ToString(dataRow["MaVach"]),
                        //                    SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                        //                    TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //                    TransactionID = chungTuChiTietInfor.TransactionID
                        //                });
                        //                count += Convert.ToInt32(dataRow["SoLuong"]);
                        //            }
                        //            //if (chiTietTransactionID != null && chiTietMaVach != null)
                        //            //{
                        //            //    khoBusiness.ListChiTietHangHoa.Add(
                        //            //    new ChungTuNhapNccChiTietHangHoaInfo
                        //            //    {
                        //            //        IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //            //        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //            //        MaVach = Convert.ToString(dataRow["MaVach"]),
                        //            //        SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                        //            //        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //            //        TransactionID = chungTuChiTietInfor.TransactionID
                        //            //    });
                        //            //    count += Convert.ToInt32(dataRow["SoLuong"]);
                        //            //}
                        //        }
                        //        else
                        //        {
                        //            //cho trùng mã vạch
                        //            if (chiTietTransactionID == null)
                        //            {
                        //                if (Convert.ToInt32(dataRow["SoLuong"]) > chungTuChiTietInfor.SoLuong)
                        //                {
                        //                    khoBusiness.ListChiTietHangHoa.Add(
                        //                    new ChungTuNhapNccChiTietHangHoaInfo
                        //                    {
                        //                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //                        MaVach = Convert.ToString(dataRow["MaVach"]),
                        //                        SoLuong = chungTuChiTietInfor.SoLuong,
                        //                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //                        TransactionID = chungTuChiTietInfor.TransactionID
                        //                    });
                        //                    count += chungTuChiTietInfor.SoLuong;
                        //                }
                        //                else
                        //                {
                        //                    khoBusiness.ListChiTietHangHoa.Add(
                        //                    new ChungTuNhapNccChiTietHangHoaInfo
                        //                    {
                        //                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //                        MaVach = Convert.ToString(dataRow["MaVach"]),
                        //                        SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                        //                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //                        TransactionID = chungTuChiTietInfor.TransactionID
                        //                    });
                        //                    count += Convert.ToInt32(dataRow["SoLuong"]);
                        //                }
                        //            }
                        //            else
                        //            {
                        //                if (Convert.ToInt32(dataRow["SoLuong"]) > chungTuChiTietInfor.SoLuong)
                        //                {
                        //                    chiTietTransactionID.SoLuong = chungTuChiTietInfor.SoLuong;
                        //                }
                        //                else
                        //                {
                        //                    chiTietTransactionID.SoLuong += Convert.ToInt32(dataRow["SoLuong"]);
                        //                    count += Convert.ToInt32(dataRow["SoLuong"]);
                        //                }
                        //            }
                        //        }
                        //        if (count == chungTuChiTietInfor.SoLuong)
                        //        {
                        //            khoBusiness.ListChiTietChungTu.Add(chungTuChiTietInfor);
                        //            listCTChungTu[listCTChungTu.IndexOf(chungTuChiTietInfor)].TrangThai = "Đã nhập đủ";
                        //            dgvChiTiet.DataSource = null;
                        //            dgvChiTiet.DataSource = listCTChungTu;
                        //        }
                        //    }
                        //}
                        #endregion

                        if (!string.IsNullOrEmpty(MaSP))
                        {
                            if (!MaSP.Equals(chungTuChiTietInfor.MaSanPham))
                            {
                                x = 0;
                            }
                        }
                        else
                        {
                            x = 0;
                        }

                        MaSP = chungTuChiTietInfor.MaSanPham;
                        
                        for (int i = x; i < tblCheck.Rows.Count; i++)
                        {
                            
                            if (count < chungTuChiTietInfor.SoLuong)
                            {
                                if (Convert.ToInt32(tblCheck.Rows[i]["SoLuong"]) > chungTuChiTietInfor.SoLuong)
                                {
                                    khoBusiness.ListChiTietHangHoa.Add(
                                    new ChungTuNhapNccChiTietHangHoaInfo
                                    {
                                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                                        MaVach = Convert.ToString(tblCheck.Rows[i]["MaVach"]).Trim(),
                                        SoLuong = chungTuChiTietInfor.SoLuong,
                                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                                        TransactionID = chungTuChiTietInfor.TransactionID
                                    });
                                    count += chungTuChiTietInfor.SoLuong;
                                    x = i;
                                }
                                else
                                {
                                    khoBusiness.ListChiTietHangHoa.Add(
                                    new ChungTuNhapNccChiTietHangHoaInfo
                                    {
                                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                                        MaVach = Convert.ToString(tblCheck.Rows[i]["MaVach"]).Trim(),
                                        SoLuong = Convert.ToInt32(tblCheck.Rows[i]["SoLuong"]),
                                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                                        TransactionID = chungTuChiTietInfor.TransactionID
                                    });
                                    count += Convert.ToInt32(tblCheck.Rows[i]["SoLuong"]);
                                    x = i + 1;
                                }
                                if (count == chungTuChiTietInfor.SoLuong)
                                {
                                    khoBusiness.ListChiTietChungTu.Add(chungTuChiTietInfor);
                                    listCTChungTu[listCTChungTu.IndexOf(chungTuChiTietInfor)].TrangThai = "Đã nhập đủ";
                                    dgvChiTiet.DataSource = null;
                                    dgvChiTiet.DataSource = listCTChungTu;
                                    arTran.Add(chungTuChiTietInfor.TransactionID);
                                }
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
                //throw;
            }
        }
    }
}
