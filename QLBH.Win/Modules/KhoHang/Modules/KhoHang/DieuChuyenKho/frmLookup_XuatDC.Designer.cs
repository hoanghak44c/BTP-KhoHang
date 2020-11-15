namespace QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH
{
    //partial class frmLookup_XuatDC
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
    //        this.colSoPhieuXuat = new DevExpress.XtraGrid.Columns.GridColumn();
    //        this.colNgayXuat = new DevExpress.XtraGrid.Columns.GridColumn();
    //        this.repLoaichungtu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
    //        this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
    //        this.txtSoPhieuXuat = new DevExpress.XtraEditors.TextEdit();
    //        ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repLoaichungtu)).BeginInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieuXuat.Properties)).BeginInit();
    //        this.SuspendLayout();
    //        // 
    //        // grcDanhSach
    //        // 
    //        this.grcDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
    //                    | System.Windows.Forms.AnchorStyles.Left)
    //                    | System.Windows.Forms.AnchorStyles.Right)));
    //        this.grcDanhSach.Location = new System.Drawing.Point(-5, 17);
    //        this.grcDanhSach.MainView = this.grvDanhSach;
    //        this.grcDanhSach.Name = "grcDanhSach";
    //        this.grcDanhSach.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
    //        this.repLoaichungtu});
    //        this.grcDanhSach.Size = new System.Drawing.Size(619, 430);
    //        this.grcDanhSach.TabIndex = 3;
    //        this.grcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
    //        this.grvDanhSach});
    //        // 
    //        // grvDanhSach
    //        // 
    //        this.grvDanhSach.ColumnPanelRowHeight = 25;
    //        this.grvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
    //        this.colSoPhieuXuat,
    //        this.colNgayXuat,
    //        this.gridColumn2});
    //        this.grvDanhSach.GridControl = this.grcDanhSach;
    //        this.grvDanhSach.Name = "grvDanhSach";
    //        this.grvDanhSach.OptionsView.ShowAutoFilterRow = true;
    //        this.grvDanhSach.OptionsView.ShowGroupPanel = false;
    //        this.grvDanhSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvDanhSach_KeyDown);
    //        this.grvDanhSach.DoubleClick += new System.EventHandler(this.grvDanhSach_DoubleClick);
    //        // 
    //        // colSoPhieuXuat
    //        // 
    //        this.colSoPhieuXuat.AppearanceHeader.Options.UseTextOptions = true;
    //        this.colSoPhieuXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
    //        this.colSoPhieuXuat.Caption = "Số chứng từ";
    //        this.colSoPhieuXuat.FieldName = "SoChungTu";
    //        this.colSoPhieuXuat.Name = "colSoPhieuXuat";
    //        this.colSoPhieuXuat.OptionsColumn.AllowEdit = false;
    //        this.colSoPhieuXuat.OptionsColumn.ReadOnly = true;
    //        this.colSoPhieuXuat.Visible = true;
    //        this.colSoPhieuXuat.VisibleIndex = 0;
    //        this.colSoPhieuXuat.Width = 278;
    //        // 
    //        // colNgayXuat
    //        // 
    //        this.colNgayXuat.AppearanceHeader.Options.UseTextOptions = true;
    //        this.colNgayXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
    //        this.colNgayXuat.Caption = "Ngày lập";
    //        this.colNgayXuat.DisplayFormat.FormatString = "dd/MM/yyyy";
    //        this.colNgayXuat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
    //        this.colNgayXuat.FieldName = "NgayLap";
    //        this.colNgayXuat.Name = "colNgayXuat";
    //        this.colNgayXuat.OptionsColumn.AllowEdit = false;
    //        this.colNgayXuat.OptionsColumn.FixedWidth = true;
    //        this.colNgayXuat.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
    //        this.colNgayXuat.Visible = true;
    //        this.colNgayXuat.VisibleIndex = 1;
    //        this.colNgayXuat.Width = 100;
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
    //        // gridColumn2
    //        // 
    //        this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
    //        this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
    //        this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
    //        this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
    //        this.gridColumn2.Caption = "Kho nhập";
    //        this.gridColumn2.FieldName = "MaKho";
    //        this.gridColumn2.Name = "gridColumn2";
    //        this.gridColumn2.OptionsColumn.AllowEdit = false;
    //        this.gridColumn2.Visible = true;
    //        this.gridColumn2.VisibleIndex = 2;
    //        // 
    //        // txtSoPhieuXuat
    //        // 
    //        this.txtSoPhieuXuat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
    //                    | System.Windows.Forms.AnchorStyles.Right)));
    //        this.txtSoPhieuXuat.EditValue = "";
    //        this.txtSoPhieuXuat.Location = new System.Drawing.Point(-5, -4);
    //        this.txtSoPhieuXuat.Name = "txtSoPhieuXuat";
    //        this.txtSoPhieuXuat.Size = new System.Drawing.Size(619, 20);
    //        this.txtSoPhieuXuat.TabIndex = 2;
    //        this.txtSoPhieuXuat.EditValueChanged += new System.EventHandler(this.txtSoPhieuXuat_EditValueChanged);
    //        this.txtSoPhieuXuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoPhieuXuat_KeyDown);
    //        // 
    //        // frmLookup_XuatTH
    //        // 
    //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.ClientSize = new System.Drawing.Size(609, 442);
    //        this.Controls.Add(this.grcDanhSach);
    //        this.Controls.Add(this.txtSoPhieuXuat);
    //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
    //        this.Name = "frmLookup_XuatTH";
    //        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    //        this.Load += new System.EventHandler(this.frmLookup_PhieuNhap_Load);
    //        ((System.ComponentModel.ISupportInitialize)(this.grcDanhSach)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.repLoaichungtu)).EndInit();
    //        ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieuXuat.Properties)).EndInit();
    //        this.ResumeLayout(false);

    //    }

    //    #endregion

    //    private DevExpress.XtraGrid.GridControl grcDanhSach;
    //    private DevExpress.XtraGrid.Views.Grid.GridView grvDanhSach;
    //    private DevExpress.XtraGrid.Columns.GridColumn colSoPhieuXuat;
    //    private DevExpress.XtraGrid.Columns.GridColumn colNgayXuat;
    //    private DevExpress.XtraEditors.TextEdit txtSoPhieuXuat;
    //    private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    //    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLoaichungtu;
    //}
}