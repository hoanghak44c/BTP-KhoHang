namespace QLBanHang.Modules.KhoHang
{
    partial class frm_ChiTietPhieuKiemKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChiTietPhieuKiemKe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label16 = new System.Windows.Forms.Label();
            this.grMaVach = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnInPhieu = new QLBH.Core.Form.GtidSimpleButton();
            this.btnXacNhan = new QLBH.Core.Form.GtidSimpleButton();
            this.btnSave = new QLBH.Core.Form.GtidSimpleButton();
            this.btnThoat = new QLBH.Core.Form.GtidSimpleButton();
            this.grpSanPhamKhong = new System.Windows.Forms.GroupBox();
            this.grcDanhSachKhong = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSachKhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportKhong = new QLBH.Core.Form.GtidButton();
            this.btnXoaKhongCoMaVach = new QLBH.Core.Form.GtidButton();
            this.MaVach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label41 = new System.Windows.Forms.Label();
            this.btnExportCo = new System.Windows.Forms.GroupBox();
            this.grcDanhSachCo = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSachCo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaVach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExport = new QLBH.Core.Form.GtidButton();
            this.btnXoaCoMaVach = new QLBH.Core.Form.GtidButton();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dtNgayKiemKe = new System.Windows.Forms.DateTimePicker();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNgayXuat = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.bteDotKiemKe = new DevExpress.XtraEditors.ButtonEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.chkKhoKhach = new DevExpress.XtraEditors.CheckEdit();
            this.txtNguoiKiem = new QLBH.Core.Form.GtidTextBox();
            this.txtGhiChu = new QLBH.Core.Form.GtidTextBox();
            this.txtSoPhieu = new QLBH.Core.Form.GtidTextBox();
            this.lblSoPhieu = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtMaVach = new QLBH.Core.Form.GtidTextBox();
            this.txtTenSanPham = new QLBH.Core.Form.GtidTextBox();
            this.btnThemHang = new QLBH.Core.Form.GtidButton();
            this.chkAutoRegSub = new DevExpress.XtraEditors.CheckEdit();
            this.grMaVach.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpSanPhamKhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSachKhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachKhong)).BeginInit();
            this.btnExportCo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSachCo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachCo)).BeginInit();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteDotKiemKe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKhoKhach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRegSub.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label16.Location = new System.Drawing.Point(7, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 20);
            this.label16.TabIndex = 125;
            this.label16.Text = "Mã vạch ";
            // 
            // grMaVach
            // 
            this.grMaVach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grMaVach.Controls.Add(this.label27);
            this.grMaVach.Location = new System.Drawing.Point(21, 118);
            this.grMaVach.Name = "grMaVach";
            this.grMaVach.Padding = new System.Windows.Forms.Padding(2);
            this.grMaVach.Size = new System.Drawing.Size(783, 103);
            this.grMaVach.TabIndex = 140;
            this.grMaVach.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label27.Location = new System.Drawing.Point(4, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(72, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "Mã vạch ";
            // 
            // grpAction
            // 
            this.grpAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAction.Controls.Add(this.btnInPhieu);
            this.grpAction.Controls.Add(this.btnXacNhan);
            this.grpAction.Controls.Add(this.btnSave);
            this.grpAction.Controls.Add(this.btnThoat);
            this.grpAction.Location = new System.Drawing.Point(10, 594);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(862, 51);
            this.grpAction.TabIndex = 5;
            this.grpAction.TabStop = false;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInPhieu.Image = ((System.Drawing.Image)(resources.GetObject("btnInPhieu.Image")));
            this.btnInPhieu.Location = new System.Drawing.Point(111, 15);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.ShortCutKey = System.Windows.Forms.Keys.F9;
            this.btnInPhieu.Size = new System.Drawing.Size(95, 25);
            this.btnInPhieu.TabIndex = 3;
            this.btnInPhieu.Text = "In Phiếu (F9)";
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(212, 15);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.ShortCutKey = System.Windows.Forms.Keys.F5;
            this.btnXacNhan.Size = new System.Drawing.Size(95, 25);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "Xác nhận(F5)";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(10, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnSave.Size = new System.Drawing.Size(95, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Cập nhật(F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(761, 15);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ShortCutKey = System.Windows.Forms.Keys.F2;
            this.btnThoat.Size = new System.Drawing.Size(95, 25);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Đóng(ESC)";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // grpSanPhamKhong
            // 
            this.grpSanPhamKhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSanPhamKhong.Controls.Add(this.grcDanhSachKhong);
            this.grpSanPhamKhong.Controls.Add(this.btnExportKhong);
            this.grpSanPhamKhong.Controls.Add(this.btnXoaKhongCoMaVach);
            this.grpSanPhamKhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpSanPhamKhong.ForeColor = System.Drawing.Color.Black;
            this.grpSanPhamKhong.Location = new System.Drawing.Point(11, 422);
            this.grpSanPhamKhong.Name = "grpSanPhamKhong";
            this.grpSanPhamKhong.Size = new System.Drawing.Size(862, 167);
            this.grpSanPhamKhong.TabIndex = 4;
            this.grpSanPhamKhong.TabStop = false;
            this.grpSanPhamKhong.Text = "Danh sách mã vạch không tìm thấy";
            // 
            // grcDanhSachKhong
            // 
            this.grcDanhSachKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDanhSachKhong.Location = new System.Drawing.Point(6, 17);
            this.grcDanhSachKhong.MainView = this.grvDanhSachKhong;
            this.grcDanhSachKhong.Name = "grcDanhSachKhong";
            this.grcDanhSachKhong.Size = new System.Drawing.Size(849, 122);
            this.grcDanhSachKhong.TabIndex = 4;
            this.grcDanhSachKhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSachKhong});
            // 
            // grvDanhSachKhong
            // 
            this.grvDanhSachKhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grvDanhSachKhong.GridControl = this.grcDanhSachKhong;
            this.grvDanhSachKhong.Name = "grvDanhSachKhong";
            this.grvDanhSachKhong.OptionsView.ShowAutoFilterRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Mã vạch";
            this.gridColumn1.FieldName = "MaVach";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 150;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Mã kho";
            this.gridColumn2.FieldName = "MaKho";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "Mã sản phẩm";
            this.gridColumn3.FieldName = "MaSanPham";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn4.Caption = "Tên sản phẩm";
            this.gridColumn4.FieldName = "TenSanPham";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn5.Caption = "Số lượng kiểm kê";
            this.gridColumn5.FieldName = "SoLuong";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "GhiChu";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // btnExportKhong
            // 
            this.btnExportKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportKhong.Image = ((System.Drawing.Image)(resources.GetObject("btnExportKhong.Image")));
            this.btnExportKhong.Location = new System.Drawing.Point(6, 141);
            this.btnExportKhong.Name = "btnExportKhong";
            this.btnExportKhong.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnExportKhong.Size = new System.Drawing.Size(69, 23);
            this.btnExportKhong.TabIndex = 3;
            this.btnExportKhong.Text = "Export";
            this.btnExportKhong.Click += new System.EventHandler(this.btnExportKhong_Click);
            // 
            // btnXoaKhongCoMaVach
            // 
            this.btnXoaKhongCoMaVach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaKhongCoMaVach.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaKhongCoMaVach.Image")));
            this.btnXoaKhongCoMaVach.Location = new System.Drawing.Point(812, 141);
            this.btnXoaKhongCoMaVach.Name = "btnXoaKhongCoMaVach";
            this.btnXoaKhongCoMaVach.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXoaKhongCoMaVach.Size = new System.Drawing.Size(44, 23);
            this.btnXoaKhongCoMaVach.TabIndex = 1;
            this.btnXoaKhongCoMaVach.Click += new System.EventHandler(this.btnXoaKhongCoMaVach_Click);
            // 
            // MaVach
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MaVach.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaVach.HeaderText = "Mã vạch";
            this.MaVach.Name = "MaVach";
            this.MaVach.ReadOnly = true;
            this.MaVach.Width = 150;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label41.Location = new System.Drawing.Point(34, 123);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(72, 20);
            this.label41.TabIndex = 6;
            this.label41.Text = "Mã vạch ";
            // 
            // btnExportCo
            // 
            this.btnExportCo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCo.Controls.Add(this.grcDanhSachCo);
            this.btnExportCo.Controls.Add(this.btnExport);
            this.btnExportCo.Controls.Add(this.btnXoaCoMaVach);
            this.btnExportCo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExportCo.ForeColor = System.Drawing.Color.Black;
            this.btnExportCo.Location = new System.Drawing.Point(11, 213);
            this.btnExportCo.Name = "btnExportCo";
            this.btnExportCo.Size = new System.Drawing.Size(862, 203);
            this.btnExportCo.TabIndex = 3;
            this.btnExportCo.TabStop = false;
            this.btnExportCo.Text = "Danh sách mã vạch trong kho";
            // 
            // grcDanhSachCo
            // 
            this.grcDanhSachCo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDanhSachCo.Location = new System.Drawing.Point(6, 18);
            this.grcDanhSachCo.MainView = this.grvDanhSachCo;
            this.grcDanhSachCo.Name = "grcDanhSachCo";
            this.grcDanhSachCo.Size = new System.Drawing.Size(850, 153);
            this.grcDanhSachCo.TabIndex = 3;
            this.grcDanhSachCo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSachCo});
            // 
            // grvDanhSachCo
            // 
            this.grvDanhSachCo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaVach,
            this.colMaKho,
            this.colMaSanPham,
            this.colTenSanPham,
            this.colSoLuong,
            this.colGhiChu});
            this.grvDanhSachCo.GridControl = this.grcDanhSachCo;
            this.grvDanhSachCo.Name = "grvDanhSachCo";
            this.grvDanhSachCo.OptionsView.ShowAutoFilterRow = true;
            this.grvDanhSachCo.OptionsView.ShowFooter = true;
            this.grvDanhSachCo.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvDanhSachCo_ShowingEditor);
            // 
            // colMaVach
            // 
            this.colMaVach.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaVach.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaVach.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaVach.Caption = "Mã vạch";
            this.colMaVach.FieldName = "MaVach";
            this.colMaVach.Name = "colMaVach";
            this.colMaVach.OptionsColumn.FixedWidth = true;
            this.colMaVach.OptionsColumn.ReadOnly = true;
            this.colMaVach.Visible = true;
            this.colMaVach.VisibleIndex = 0;
            this.colMaVach.Width = 150;
            // 
            // colMaKho
            // 
            this.colMaKho.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaKho.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaKho.Caption = "Mã kho";
            this.colMaKho.FieldName = "MaKho";
            this.colMaKho.Name = "colMaKho";
            this.colMaKho.OptionsColumn.FixedWidth = true;
            this.colMaKho.OptionsColumn.ReadOnly = true;
            this.colMaKho.Visible = true;
            this.colMaKho.VisibleIndex = 1;
            this.colMaKho.Width = 100;
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaSanPham.Caption = "Mã sản phẩm";
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.OptionsColumn.FixedWidth = true;
            this.colMaSanPham.OptionsColumn.ReadOnly = true;
            this.colMaSanPham.Visible = true;
            this.colMaSanPham.VisibleIndex = 2;
            this.colMaSanPham.Width = 100;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTenSanPham.Caption = "Tên sản phẩm";
            this.colTenSanPham.FieldName = "TenSanPham";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.OptionsColumn.FixedWidth = true;
            this.colTenSanPham.OptionsColumn.ReadOnly = true;
            this.colTenSanPham.Visible = true;
            this.colTenSanPham.VisibleIndex = 3;
            this.colTenSanPham.Width = 150;
            // 
            // colSoLuong
            // 
            this.colSoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoLuong.Caption = "Số lượng kiểm kê";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsColumn.FixedWidth = true;
            this.colSoLuong.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 4;
            this.colSoLuong.Width = 100;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(6, 174);
            this.btnExport.Name = "btnExport";
            this.btnExport.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnExport.Size = new System.Drawing.Size(69, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnXoaCoMaVach
            // 
            this.btnXoaCoMaVach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaCoMaVach.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaCoMaVach.Image")));
            this.btnXoaCoMaVach.Location = new System.Drawing.Point(812, 175);
            this.btnXoaCoMaVach.Name = "btnXoaCoMaVach";
            this.btnXoaCoMaVach.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXoaCoMaVach.Size = new System.Drawing.Size(44, 23);
            this.btnXoaCoMaVach.TabIndex = 1;
            this.btnXoaCoMaVach.Click += new System.EventHandler(this.btnXoaCoMaVach_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGhiChu.Location = new System.Drawing.Point(277, 67);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(56, 15);
            this.lblGhiChu.TabIndex = 7;
            this.lblGhiChu.Text = "Diễn giải";
            // 
            // dtNgayKiemKe
            // 
            this.dtNgayKiemKe.CustomFormat = "dd/MM/yyyy";
            this.dtNgayKiemKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtNgayKiemKe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayKiemKe.Location = new System.Drawing.Point(344, 25);
            this.dtNgayKiemKe.Name = "dtNgayKiemKe";
            this.dtNgayKiemKe.Size = new System.Drawing.Size(105, 20);
            this.dtNgayKiemKe.TabIndex = 1;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 300;
            // 
            // lblNgayXuat
            // 
            this.lblNgayXuat.AutoSize = true;
            this.lblNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgayXuat.Location = new System.Drawing.Point(252, 26);
            this.lblNgayXuat.Name = "lblNgayXuat";
            this.lblNgayXuat.Size = new System.Drawing.Size(81, 15);
            this.lblNgayXuat.TabIndex = 5;
            this.lblNgayXuat.Text = "Ngày kiểm kê";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTin.Controls.Add(this.bteDotKiemKe);
            this.grpThongTin.Controls.Add(this.label9);
            this.grpThongTin.Controls.Add(this.chkKhoKhach);
            this.grpThongTin.Controls.Add(this.txtNguoiKiem);
            this.grpThongTin.Controls.Add(this.txtGhiChu);
            this.grpThongTin.Controls.Add(this.lblGhiChu);
            this.grpThongTin.Controls.Add(this.dtNgayKiemKe);
            this.grpThongTin.Controls.Add(this.txtSoPhieu);
            this.grpThongTin.Controls.Add(this.lblSoPhieu);
            this.grpThongTin.Controls.Add(this.lblNgayXuat);
            this.grpThongTin.Controls.Add(this.label42);
            this.grpThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpThongTin.Location = new System.Drawing.Point(10, 3);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(862, 92);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin phiếu kiểm kê";
            // 
            // bteDotKiemKe
            // 
            this.bteDotKiemKe.Location = new System.Drawing.Point(88, 66);
            this.bteDotKiemKe.Name = "bteDotKiemKe";
            this.bteDotKiemKe.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.bteDotKiemKe.Properties.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bteDotKiemKe.Properties.Appearance.Options.UseBackColor = true;
            this.bteDotKiemKe.Properties.Appearance.Options.UseForeColor = true;
            this.bteDotKiemKe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteDotKiemKe.Properties.ReadOnly = true;
            this.bteDotKiemKe.Size = new System.Drawing.Size(158, 20);
            this.bteDotKiemKe.TabIndex = 10;
            this.bteDotKiemKe.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteDotKiemKe_ButtonClick);
            this.bteDotKiemKe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteDotKiemKe_KeyDown);
            this.bteDotKiemKe.TextChanged += new System.EventHandler(this.bteDotKiemKe_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(4, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Đợt kiểm kê";
            // 
            // chkKhoKhach
            // 
            this.chkKhoKhach.Location = new System.Drawing.Point(759, 28);
            this.chkKhoKhach.Name = "chkKhoKhach";
            this.chkKhoKhach.Properties.Caption = "Kho khách";
            this.chkKhoKhach.Size = new System.Drawing.Size(97, 19);
            this.chkKhoKhach.TabIndex = 8;
            this.chkKhoKhach.CheckedChanged += new System.EventHandler(this.chkKhoKhach_CheckedChanged);
            this.chkKhoKhach.Click += new System.EventHandler(this.chkKhoKhach_Click);
            // 
            // txtNguoiKiem
            // 
            this.txtNguoiKiem.BackColor = System.Drawing.Color.White;
            this.txtNguoiKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiKiem.Location = new System.Drawing.Point(531, 25);
            this.txtNguoiKiem.Name = "txtNguoiKiem";
            this.txtNguoiKiem.ReadOnly = true;
            this.txtNguoiKiem.Size = new System.Drawing.Size(222, 20);
            this.txtNguoiKiem.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(344, 56);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(512, 30);
            this.txtGhiChu.TabIndex = 3;
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoPhieu.Location = new System.Drawing.Point(88, 25);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.ReadOnly = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(158, 20);
            this.txtSoPhieu.TabIndex = 0;
            // 
            // lblSoPhieu
            // 
            this.lblSoPhieu.AutoSize = true;
            this.lblSoPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoPhieu.Location = new System.Drawing.Point(20, 26);
            this.lblSoPhieu.Name = "lblSoPhieu";
            this.lblSoPhieu.Size = new System.Drawing.Size(56, 15);
            this.lblSoPhieu.TabIndex = 4;
            this.lblSoPhieu.Text = "Số phiếu";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label42.Location = new System.Drawing.Point(455, 26);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(70, 15);
            this.label42.TabIndex = 6;
            this.label42.Text = "Người kiểm";
            // 
            // txtMaVach
            // 
            this.txtMaVach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaVach.BackColor = System.Drawing.Color.PowderBlue;
            this.txtMaVach.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaVach.Location = new System.Drawing.Point(112, 113);
            this.txtMaVach.Name = "txtMaVach";
            this.txtMaVach.ShortcutsEnabled = false;
            this.txtMaVach.Size = new System.Drawing.Size(614, 38);
            this.txtMaVach.TabIndex = 1;
            this.txtMaVach.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaVach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaVach_KeyDown);
            this.txtMaVach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaVach_KeyPress);
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenSanPham.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTenSanPham.Enabled = false;
            this.txtTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenSanPham.Location = new System.Drawing.Point(27, 173);
            this.txtTenSanPham.Multiline = true;
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(839, 34);
            this.txtTenSanPham.TabIndex = 7;
            // 
            // btnThemHang
            // 
            this.btnThemHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemHang.Image = ((System.Drawing.Image)(resources.GetObject("btnThemHang.Image")));
            this.btnThemHang.Location = new System.Drawing.Point(732, 110);
            this.btnThemHang.Name = "btnThemHang";
            this.btnThemHang.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnThemHang.Size = new System.Drawing.Size(134, 40);
            this.btnThemHang.TabIndex = 2;
            this.btnThemHang.Text = "    &Thêm hàng";
            this.btnThemHang.Click += new System.EventHandler(this.btnThemHang_Click);
            // 
            // chkAutoRegSub
            // 
            this.chkAutoRegSub.EditValue = true;
            this.chkAutoRegSub.Location = new System.Drawing.Point(110, 153);
            this.chkAutoRegSub.Name = "chkAutoRegSub";
            this.chkAutoRegSub.Properties.Caption = "Tự động nhận diện kho kiểm kê (Bỏ chọn khi cần kiểm kê thừa serial)";
            this.chkAutoRegSub.Size = new System.Drawing.Size(455, 19);
            this.chkAutoRegSub.TabIndex = 9;
            this.chkAutoRegSub.ToolTip = "Bỏ chọn khi muốn kiểm kê thừa serial";
            // 
            // frm_ChiTietPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 657);
            this.Controls.Add(this.chkAutoRegSub);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.grpSanPhamKhong);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnExportCo);
            this.Controls.Add(this.txtMaVach);
            this.Controls.Add(this.txtTenSanPham);
            this.Controls.Add(this.btnThemHang);
            this.Controls.Add(this.grpThongTin);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChiTietPhieuKiemKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phiếu kiểm kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ChiTietPhieuKiemKe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_ChiTietPhieuKiemKe_KeyDown);
            this.grMaVach.ResumeLayout(false);
            this.grMaVach.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpSanPhamKhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSachKhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachKhong)).EndInit();
            this.btnExportCo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSachCo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSachCo)).EndInit();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteDotKiemKe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKhoKhach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRegSub.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox grMaVach;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox grpAction;
        private QLBH.Core.Form.GtidSimpleButton btnSave;
        private QLBH.Core.Form.GtidSimpleButton btnThoat;
        private QLBH.Core.Form.GtidButton btnXoaKhongCoMaVach;
        private System.Windows.Forms.GroupBox grpSanPhamKhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVach;
        private System.Windows.Forms.Label label41;
        private QLBH.Core.Form.GtidTextBox txtNguoiKiem;
        private System.Windows.Forms.GroupBox btnExportCo;
        private QLBH.Core.Form.GtidButton btnXoaCoMaVach;
        private QLBH.Core.Form.GtidTextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.DateTimePicker dtNgayKiemKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private QLBH.Core.Form.GtidTextBox txtMaVach;
        private QLBH.Core.Form.GtidTextBox txtTenSanPham;
        internal QLBH.Core.Form.GtidButton btnThemHang;
        private QLBH.Core.Form.GtidTextBox txtSoPhieu;
        private System.Windows.Forms.Label lblNgayXuat;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblSoPhieu;
        private System.Windows.Forms.Label label42;
        private DevExpress.XtraEditors.CheckEdit chkKhoKhach;
        private DevExpress.XtraEditors.ButtonEdit bteDotKiemKe;
        private System.Windows.Forms.Label label9;
        private QLBH.Core.Form.GtidSimpleButton btnXacNhan;
        private QLBH.Core.Form.GtidSimpleButton btnInPhieu;
        private QLBH.Core.Form.GtidButton btnExport;
        private QLBH.Core.Form.GtidButton btnExportKhong;
        private DevExpress.XtraGrid.GridControl grcDanhSachCo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSachCo;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVach;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKho;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.GridControl grcDanhSachKhong;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSachKhong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.CheckEdit chkAutoRegSub;



    }
}