using QLBH.Core.Form;
namespace QLBanHang.Modules.KhoHang
{
    partial class frmThongKe_TonSanPham
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TonChiTietMaVachTsm = new System.Windows.Forms.ToolStripMenuItem();
            this.ChungTuLienQuanTsm = new System.Windows.Forms.ToolStripMenuItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnViewAll = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.bteSanpham = new DevExpress.XtraEditors.ButtonEdit();
            this.cboKyBaoCao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.deTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bteKho = new DevExpress.XtraEditors.ButtonEdit();
            this.grcHangTon = new QLBH.Core.Form.GtidXtraGridControl();
            this.grvThongKeHangTon = new QLBH.Core.Form.GtidXtraGridView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteSanpham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcHangTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongKeHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TonChiTietMaVachTsm,
            this.ChungTuLienQuanTsm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 48);
            // 
            // TonChiTietMaVachTsm
            // 
            this.TonChiTietMaVachTsm.Name = "TonChiTietMaVachTsm";
            this.TonChiTietMaVachTsm.Size = new System.Drawing.Size(182, 22);
            this.TonChiTietMaVachTsm.Text = "Tồn chi tiết mã vạch";
            this.TonChiTietMaVachTsm.Click += new System.EventHandler(this.TonChiTietMaVachTsm_Click);
            // 
            // ChungTuLienQuanTsm
            // 
            this.ChungTuLienQuanTsm.Name = "ChungTuLienQuanTsm";
            this.ChungTuLienQuanTsm.Size = new System.Drawing.Size(182, 22);
            this.ChungTuLienQuanTsm.Text = "Chứng từ liên quan";
            this.ChungTuLienQuanTsm.Click += new System.EventHandler(this.ChungTuLienQuanTsm_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnViewAll);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.bteSanpham);
            this.groupControl1.Controls.Add(this.cboKyBaoCao);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.btnExport);
            this.groupControl1.Controls.Add(this.btnReload);
            this.groupControl1.Controls.Add(this.deTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.deFrom);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.bteKho);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(953, 112);
            this.groupControl1.TabIndex = 5;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(668, 25);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(99, 26);
            this.btnViewAll.TabIndex = 70;
            this.btnViewAll.Text = "Xem hết";
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 13);
            this.labelControl4.TabIndex = 67;
            this.labelControl4.Text = "Sản phẩm:";
            // 
            // bteSanpham
            // 
            this.bteSanpham.Location = new System.Drawing.Point(73, 53);
            this.bteSanpham.Name = "bteSanpham";
            this.bteSanpham.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteSanpham.Size = new System.Drawing.Size(475, 20);
            this.bteSanpham.TabIndex = 66;
            this.bteSanpham.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteSanpham_ButtonClick);
            this.bteSanpham.TextChanged += new System.EventHandler(this.bteSanpham_TextChanged);
            // 
            // cboKyBaoCao
            // 
            this.cboKyBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKyBaoCao.FormattingEnabled = true;
            this.cboKyBaoCao.Location = new System.Drawing.Point(73, 79);
            this.cboKyBaoCao.Name = "cboKyBaoCao";
            this.cboKyBaoCao.Size = new System.Drawing.Size(105, 21);
            this.cboKyBaoCao.TabIndex = 64;
            this.cboKyBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboKyBaoCao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Kỳ báo cáo";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(554, 57);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(99, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(554, 25);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(99, 26);
            this.btnReload.TabIndex = 13;
            this.btnReload.Text = "Xem";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // deTo
            // 
            this.deTo.EditValue = null;
            this.deTo.Location = new System.Drawing.Point(422, 81);
            this.deTo.Name = "deTo";
            this.deTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deTo.Size = new System.Drawing.Size(126, 20);
            this.deTo.TabIndex = 12;
            this.deTo.EditValueChanged += new System.EventHandler(this.deTo_EditValueChanged);
            this.deTo.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.deTo_EditValueChanging);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(364, 85);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Đến ngày:";
            // 
            // deFrom
            // 
            this.deFrom.EditValue = null;
            this.deFrom.Location = new System.Drawing.Point(234, 80);
            this.deFrom.Name = "deFrom";
            this.deFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFrom.Size = new System.Drawing.Size(126, 20);
            this.deFrom.TabIndex = 10;
            this.deFrom.EditValueChanged += new System.EventHandler(this.deFrom_EditValueChanged);
            this.deFrom.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.deFrom_EditValueChanging);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(184, 84);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Từ ngày:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Kho:";
            // 
            // bteKho
            // 
            this.bteKho.Location = new System.Drawing.Point(73, 27);
            this.bteKho.Name = "bteKho";
            this.bteKho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKho.Size = new System.Drawing.Size(475, 20);
            this.bteKho.TabIndex = 5;
            this.bteKho.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteKho_ButtonClick);
            this.bteKho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteKho_KeyDown);
            this.bteKho.TextChanged += new System.EventHandler(this.bteKho_TextChanged);
            // 
            // grcHangTon
            // 
            this.grcHangTon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcHangTon.ContextMenuStrip = this.contextMenuStrip1;
            this.grcHangTon.Location = new System.Drawing.Point(12, 130);
            this.grcHangTon.MainView = this.grvThongKeHangTon;
            this.grcHangTon.Name = "grcHangTon";
            this.grcHangTon.Size = new System.Drawing.Size(953, 311);
            this.grcHangTon.TabIndex = 0;
            this.grcHangTon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvThongKeHangTon});
            // 
            // grvThongKeHangTon
            // 
            this.grvThongKeHangTon.GridControl = this.grcHangTon;
            this.grvThongKeHangTon.Name = "grvThongKeHangTon";
            this.grvThongKeHangTon.OptionsView.ShowAutoFilterRow = true;
            // 
            // frmThongKe_TonSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 453);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grcHangTon);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKe_TonSanPham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê hàng tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKe_TonSanPham_Load);
            this.Activated += new System.EventHandler(this.frmThongKe_TonSanPham_Activated);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bteSanpham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcHangTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongKeHangTon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GtidXtraGridControl grcHangTon;
        private GtidXtraGridView grvThongKeHangTon;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit bteKho;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TonChiTietMaVachTsm;
        private System.Windows.Forms.ToolStripMenuItem ChungTuLienQuanTsm;
        private DevExpress.XtraEditors.DateEdit deTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deFrom;
        private DevExpress.XtraEditors.SimpleButton btnReload;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private System.Windows.Forms.ComboBox cboKyBaoCao;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit bteSanpham;
        private DevExpress.XtraEditors.SimpleButton btnViewAll;
    }
}