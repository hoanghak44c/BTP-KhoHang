namespace QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH
{
    //partial class frmLookup_DotKiemKeTest
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.grcDanhSach = new DevExpress.XtraGrid.GridControl();
    //        this.grvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
    //        this.colMaDotKiemKe = new DevExpress.XtraGrid.Columns.GridColumn();
    //        this.colNgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
    //        this.colNgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
    //        this.repLoaichungtu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
    //        this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
    //        this.txtSoPhieuXuat = new DevExpress.XtraEditors.TextEdit();
    //        ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repLoaichungtu)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieuXuat.Properties)).BeginInit();
    //        this.SuspendLayout();
    //        // 
    //        // grcDanhSach
    //        // 
    //        this.grcDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
    //                    | System.Windows.Forms.AnchorStyles.Left)
    //                    | System.Windows.Forms.AnchorStyles.Right)));
    //        this.grcDanhSach.Location = new System.Drawing.Point(-5, 23);
    //        this.grcDanhSach.MainView = this.grvDanhSach;
    //        this.grcDanhSach.Name = "grcDanhSach";
    //        this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
    //        this.repLoaichungtu,
    //        this.repositoryItemDateEdit1});
    //        this.grcDanhSach.Size = new System.Drawing.Size(605, 422);
    //        this.grcDanhSach.TabIndex = 3;
    //        this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
    //        this.grvDanhSach});
    //        // 
    //        // grvDanhSach
    //        // 
    //        this.grvDanhSach.ColumnPanelRowHeight = 25;
    //        this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
    //        this.colMaDotKiemKe,
    //        this.colNgayBatDau,
    //        this.colNgayKetThuc});
    //        this.grvDanhSach.GridControl = this.grcDanhSach;
    //        this.grvDanhSach.Name = "grvDanhSach";
    //        this.grvDanhSach.OptionsView.ShowAutoFilterRow = true;
    //        this.grvDanhSach.OptionsView.ShowGroupPanel = false;
    //        //this.grvDanhSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvDanhSach_KeyDown);
    //        //this.grvDanhSach.DoubleClick += new System.EventHandler(this.grvDanhSach_DoubleClick);
    //        // 
    //        // colMaDotKiemKe
    //        // 
    //        this.colMaDotKiemKe.AppearanceHeader.Options.UseTextOptions = true;
    //        this.colMaDotKiemKe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
    //        this.colMaDotKiemKe.Caption = "Mã đợt kiểm kê";
    //        this.colMaDotKiemKe.FieldName = "MaDotKiemKe";
    //        this.colMaDotKiemKe.Name = "colMaDotKiemKe";
    //        this.colMaDotKiemKe.OptionsColumn.AllowEdit = false;
    //        this.colMaDotKiemKe.OptionsColumn.ReadOnly = true;
    //        this.colMaDotKiemKe.Visible = true;
    //        this.colMaDotKiemKe.VisibleIndex = 0;
    //        this.colMaDotKiemKe.Width = 278;
    //        // 
    //        // colNgayBatDau
    //        // 
    //        this.colNgayBatDau.AppearanceHeader.Options.UseTextOptions = true;
    //        this.colNgayBatDau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
    //        this.colNgayBatDau.Caption = "Ngày bắt đầu";
    //        this.colNgayBatDau.DisplayFormat.FormatString = "dd/MM/yyyy";
    //        this.colNgayBatDau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
    //        this.colNgayBatDau.FieldName = "NgayBatDau";
    //        this.colNgayBatDau.Name = "colNgayBatDau";
    //        this.colNgayBatDau.OptionsColumn.AllowEdit = false;
    //        this.colNgayBatDau.OptionsColumn.FixedWidth = true;
    //        this.colNgayBatDau.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
    //        this.colNgayBatDau.Visible = true;
    //        this.colNgayBatDau.VisibleIndex = 1;
    //        this.colNgayBatDau.Width = 100;
    //        // 
    //        // colNgayKetThuc
    //        // 
    //        this.colNgayKetThuc.AppearanceHeader.Options.UseTextOptions = true;
    //        this.colNgayKetThuc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
    //        this.colNgayKetThuc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
    //        this.colNgayKetThuc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
    //        this.colNgayKetThuc.Caption = "Ngày kết thúc";
    //        this.colNgayKetThuc.DisplayFormat.FormatString = "dd/MM/yyyy";
    //        this.colNgayKetThuc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
    //        this.colNgayKetThuc.FieldName = "NgayKetThuc";
    //        this.colNgayKetThuc.Name = "colNgayKetThuc";
    //        this.colNgayKetThuc.OptionsColumn.AllowEdit = false;
    //        this.colNgayKetThuc.Visible = true;
    //        this.colNgayKetThuc.VisibleIndex = 2;
    //        // 
    //        // repLoaichungtu
    //        // 
    //        this.repLoaichungtu.AutoHeight = false;
    //        this.repLoaichungtu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
    //        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
    //        this.repLoaichungtu.DisplayMember = "Name";
    //        this.repLoaichungtu.Name = "repLoaichungtu";
    //        this.repLoaichungtu.NullText = "";
    //        this.repLoaichungtu.ValueMember = "Id";
    //        // 
    //        // repositoryItemDateEdit1
    //        // 
    //        this.repositoryItemDateEdit1.AutoHeight = false;
    //        this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
    //        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
    //        this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
    //        this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
    //        new DevExpress.XtraEditors.Controls.EditorButton()});
    //        // 
    //        // txtSoPhieuXuat
    //        // 
    //        this.txtSoPhieuXuat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
    //                    | System.Windows.Forms.AnchorStyles.Right)));
    //        this.txtSoPhieuXuat.EditValue = "";
    //        this.txtSoPhieuXuat.Location = new System.Drawing.Point(0, 1);
    //        this.txtSoPhieuXuat.Name = "txtSoPhieuXuat";
    //        this.txtSoPhieuXuat.Size = new System.Drawing.Size(595, 20);
    //        this.txtSoPhieuXuat.TabIndex = 2;
    //        //this.txtSoPhieuXuat.EditValueChanged += new System.EventHandler(this.txtSoPhieuXuat_EditValueChanged);
    //        //this.txtSoPhieuXuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoPhieuXuat_KeyDown);
    //        // 
    //        // frmLookup_DotKiemKe
    //        // 
    //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.ClientSize = new System.Drawing.Size(595, 442);
    //        this.Controls.Add(this.grcDanhSach);
    //        this.Controls.Add(this.txtSoPhieuXuat);
    //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
    //        this.Name = "frmLookup_DotKiemKe";
    //        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    //        //this.Load += new System.EventHandler(this.frmLookup_PhieuNhap_Load);
    //        ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repLoaichungtu)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieuXuat.Properties)).EndInit();
    //        this.ResumeLayout(false);

    //    }

    //    #endregion

    //    private DevExpress.XtraGrid.GridControl grcDanhSach;
    //    private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
    //    private DevExpress.XtraGrid.Columns.GridColumn colMaDotKiemKe;
    //    private DevExpress.XtraGrid.Columns.GridColumn colNgayBatDau;
    //    private DevExpress.XtraEditors.TextEdit txtSoPhieuXuat;
    //    private DevExpress.XtraGrid.Columns.GridColumn colNgayKetThuc;
    //    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLoaichungtu;
    //    private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    //}
}