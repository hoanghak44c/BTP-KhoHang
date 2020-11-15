namespace QLBanHang.Modules.KhoHang.DieuChuyenKho
{
    partial class frm_BaoCaoDieuChuyenHangDemo
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
            this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhieuXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayXuatHang = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colMaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaVach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPhieuNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNgayXuat = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colNgayNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPhieuXK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoNhapMua = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKhoTonHienTai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // grcDanhSach
            // 
            this.grcDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcDanhSach.Location = new System.Drawing.Point(12, 12);
            this.grcDanhSach.MainView = this.grvDanhSach;
            this.grcDanhSach.Name = "grcDanhSach";
            this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repNgayXuatHang,
            this.repNgayXuat});
            this.grcDanhSach.Size = new System.Drawing.Size(616, 316);
            this.grcDanhSach.TabIndex = 8;
            this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDanhSach});
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgayLap,
            this.colSoPhieuXuat,
            this.colKhoXuat,
            this.colNgayXuat,
            this.colMaSanPham,
            this.colTenSanPham,
            this.colMaVach,
            this.colSoLuong,
            this.colKhoNhan,
            this.colSoPhieuNhan,
            this.colNgayNhan,
            this.colNgayNhap,
            this.colTrangThai,
            this.colGhiChu,
            this.colSoHD,
            this.colSoPhieuXK,
            this.colKhoNhapMua,
            this.colKhoTonHienTai,
            this.colGhiChu1});
            this.grvDanhSach.GridControl = this.grcDanhSach;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.OptionsView.ShowAutoFilterRow = true;
            // 
            // colSoPhieuXuat
            // 
            this.colSoPhieuXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPhieuXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieuXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoPhieuXuat.Caption = "Số phiếu xuất";
            this.colSoPhieuXuat.FieldName = "SoPhieuXuat";
            this.colSoPhieuXuat.Name = "colSoPhieuXuat";
            this.colSoPhieuXuat.OptionsColumn.AllowEdit = false;
            this.colSoPhieuXuat.OptionsColumn.FixedWidth = true;
            this.colSoPhieuXuat.Visible = true;
            this.colSoPhieuXuat.VisibleIndex = 0;
            this.colSoPhieuXuat.Width = 200;
            // 
            // colNgayLap
            // 
            this.colNgayLap.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayLap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayLap.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayLap.Caption = "Ngày lập";
            this.colNgayLap.ColumnEdit = this.repNgayXuatHang;
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.OptionsColumn.AllowEdit = false;
            this.colNgayLap.OptionsColumn.FixedWidth = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 1;
            this.colNgayLap.Width = 120;
            // 
            // repNgayXuatHang
            // 
            this.repNgayXuatHang.AutoHeight = false;
            this.repNgayXuatHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayXuatHang.Name = "repNgayXuatHang";
            this.repNgayXuatHang.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaSanPham.Caption = "Mã sản phẩm";
            this.colMaSanPham.FieldName = "MaSanPham";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.OptionsColumn.AllowEdit = false;
            this.colMaSanPham.OptionsColumn.FixedWidth = true;
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
            this.colTenSanPham.OptionsColumn.AllowEdit = false;
            this.colTenSanPham.OptionsColumn.FixedWidth = true;
            this.colTenSanPham.Visible = true;
            this.colTenSanPham.VisibleIndex = 3;
            this.colTenSanPham.Width = 150;
            // 
            // colMaVach
            // 
            this.colMaVach.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaVach.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaVach.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaVach.Caption = "Mã vạch";
            this.colMaVach.FieldName = "MaVach";
            this.colMaVach.Name = "colMaVach";
            this.colMaVach.OptionsColumn.AllowEdit = false;
            this.colMaVach.OptionsColumn.FixedWidth = true;
            this.colMaVach.Visible = true;
            this.colMaVach.VisibleIndex = 4;
            this.colMaVach.Width = 150;
            // 
            // colSoLuong
            // 
            this.colSoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsColumn.AllowEdit = false;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 5;
            this.colSoLuong.Width = 72;
            // 
            // colKhoXuat
            // 
            this.colKhoXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKhoXuat.Caption = "Kho xuất";
            this.colKhoXuat.FieldName = "KhoXuat";
            this.colKhoXuat.Name = "colKhoXuat";
            this.colKhoXuat.OptionsColumn.AllowEdit = false;
            this.colKhoXuat.Visible = true;
            this.colKhoXuat.VisibleIndex = 6;
            // 
            // colKhoNhan
            // 
            this.colKhoNhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colKhoNhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKhoNhan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKhoNhan.Caption = "Kho nhận";
            this.colKhoNhan.FieldName = "KhoNhan";
            this.colKhoNhan.Name = "colKhoNhan";
            this.colKhoNhan.OptionsColumn.AllowEdit = false;
            this.colKhoNhan.Visible = true;
            this.colKhoNhan.VisibleIndex = 7;
            // 
            // colSoPhieuNhan
            // 
            this.colSoPhieuNhan.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoPhieuNhan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoPhieuNhan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoPhieuNhan.Caption = "Số phiếu nhận";
            this.colSoPhieuNhan.FieldName = "SoPhieuNhan";
            this.colSoPhieuNhan.Name = "colSoPhieuNhan";
            this.colSoPhieuNhan.OptionsColumn.AllowEdit = false;
            this.colSoPhieuNhan.Visible = true;
            this.colSoPhieuNhan.VisibleIndex = 8;
            // 
            // colNgayXuat
            // 
            this.colNgayXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayXuat.Caption = "Ngày xuất";
            this.colNgayXuat.ColumnEdit = this.repNgayXuat;
            this.colNgayXuat.FieldName = "NgayNhapXuatKho";
            this.colNgayXuat.Name = "colNgayXuat";
            this.colNgayXuat.OptionsColumn.AllowEdit = false;
            this.colNgayXuat.OptionsColumn.ReadOnly = true;
            this.colNgayXuat.Visible = true;
            this.colNgayXuat.VisibleIndex = 9;
            this.colNgayXuat.Width = 20;
            // 
            // repNgayXuat
            // 
            this.repNgayXuat.AutoHeight = false;
            this.repNgayXuat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repNgayXuat.Name = "repNgayXuat";
            this.repNgayXuat.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colNgayNhan
            // 
            this.colNgayNhan.Caption = "Ngày nhận";
            this.colNgayNhan.FieldName = "NgayNhan";
            this.colNgayNhan.Name = "colNgayNhan";
            this.colNgayNhan.Visible = true;
            this.colNgayNhan.VisibleIndex = 10;
            // 
            // colNgayNhap
            // 
            this.colNgayNhap.Caption = "Ngày nhập";
            this.colNgayNhap.FieldName = "NgayNhap";
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.Visible = true;
            this.colNgayNhap.VisibleIndex = 11;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Caption = "Trạng thái";
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 12;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 13;
            // 
            // colSoHD
            // 
            this.colSoHD.Caption = "Hóa đơn điều chuyển";
            this.colSoHD.FieldName = "HoaDonDC";
            this.colSoHD.Name = "colSoHD";
            this.colSoHD.Visible = true;
            this.colSoHD.VisibleIndex = 14;
            // 
            // colSoPhieuXK
            // 
            this.colSoPhieuXK.Caption = "Số phiếu xuất bán";
            this.colSoPhieuXK.Name = "colSoPhieuXK";
            this.colSoPhieuXK.Visible = true;
            this.colSoPhieuXK.VisibleIndex = 15;
            // 
            // colKhoNhapMua
            // 
            this.colKhoNhapMua.Caption = "Kho mua";
            this.colKhoNhapMua.FieldName = "KhoMua";
            this.colKhoNhapMua.Name = "colKhoNhapMua";
            this.colKhoNhapMua.Visible = true;
            this.colKhoNhapMua.VisibleIndex = 16;
            // 
            // colKhoTonHienTai
            // 
            this.colKhoTonHienTai.Caption = "Kho tồn hiện tại";
            this.colKhoTonHienTai.FieldName = "KhoTonHienTai";
            this.colKhoTonHienTai.Name = "colKhoTonHienTai";
            this.colKhoTonHienTai.Visible = true;
            this.colKhoTonHienTai.VisibleIndex = 17;
            // 
            // colGhiChu1
            // 
            this.colGhiChu1.Caption = "Ghi chú";
            this.colGhiChu1.FieldName = "GhiChu1";
            this.colGhiChu1.Name = "colGhiChu1";
            this.colGhiChu1.Visible = true;
            this.colGhiChu1.VisibleIndex = 18;
            // 
            // frm_BaoCaoDieuChuyenHangDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 340);
            this.Controls.Add(this.grcDanhSach);
            this.Name = "frm_BaoCaoDieuChuyenHangDemo";
            this.Text = "Báo cáo điều chuyển hàng demo";
            ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNgayXuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieuXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuatHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVach;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieuNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayXuat;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repNgayXuat;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colSoHD;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhieuXK;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoNhapMua;
        private DevExpress.XtraGrid.Columns.GridColumn colKhoTonHienTai;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu1;
    }
}