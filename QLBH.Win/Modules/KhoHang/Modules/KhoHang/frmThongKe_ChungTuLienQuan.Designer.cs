using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    partial class frmThongKe_ChungTuLienQuan
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
            this.grcHangTon = new QLBH.Core.Form.GtidXtraGridControl();
            this.grvThongKeHangTon = new QLBH.Core.Form.GtidXtraGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcHangTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongKeHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // grcHangTon
            // 
            this.grcHangTon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grcHangTon.Location = new System.Drawing.Point(12, 12);
            this.grcHangTon.MainView = this.grvThongKeHangTon;
            this.grcHangTon.Name = "grcHangTon";
            this.grcHangTon.Size = new System.Drawing.Size(685, 335);
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
            // frmThongKe_ChungTuLienQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 359);
            this.Controls.Add(this.grcHangTon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKe_ChungTuLienQuan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê chứng từ liên quan";
            this.Load += new System.EventHandler(this.frmThongKe_TonChiTietMaVach_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(frmThongKe_ChungTuLienQuan_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongKe_ChungTuLienQuan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grcHangTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongKeHangTon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GtidXtraGridControl grcHangTon;
        private GtidXtraGridView grvThongKeHangTon;
    }
}