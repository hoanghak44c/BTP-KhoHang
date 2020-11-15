namespace QLBanHang.Modules.KhoHang.Reports
{
    partial class frmChonBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonBaoCao));
            this.btnXacNhan = new QLBH.Core.Form.GtidSimpleButton();
            this.rdoChon = new DevExpress.XtraEditors.RadioGroup();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.rdoChon.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(62, 96);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.ShortCutKey = System.Windows.Forms.Keys.None;
            this.btnXacNhan.Size = new System.Drawing.Size(101, 25);
            this.btnXacNhan.TabIndex = 10;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // rdoChon
            // 
            this.rdoChon.EditValue = 1;
            this.rdoChon.Location = new System.Drawing.Point(3, 7);
            this.rdoChon.Name = "rdoChon";
            this.rdoChon.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Báo cáo chi tiết nhập hàng mua(bao gồm cả mã vạch,số lượng)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Báo cáo tổng hợp nhập hàng mua(bao gồm số lượng tổng)")});
            this.rdoChon.Size = new System.Drawing.Size(331, 83);
            this.rdoChon.TabIndex = 12;
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(169, 96);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.Escape;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmChonBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 128);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.rdoChon);
            this.Controls.Add(this.btnXacNhan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmChonBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn loại báo cáo";
            this.Load += new System.EventHandler(this.frmChonBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rdoChon.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected QLBH.Core.Form.GtidSimpleButton btnXacNhan;
        private DevExpress.XtraEditors.RadioGroup rdoChon;
        protected QLBH.Core.Form.GtidSimpleButton btnDong;
    }
}