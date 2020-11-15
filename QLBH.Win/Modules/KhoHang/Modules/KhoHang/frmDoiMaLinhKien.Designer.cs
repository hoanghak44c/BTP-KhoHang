namespace QLBanHang.Modules.KhoHang
{
    partial class frmDoiMaLinhKien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMaLinhKien));
            this.txtSerialCu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialMoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDong = new QLBH.Core.Form.GtidSimpleButton();
            this.btnXacNhan = new QLBH.Core.Form.GtidSimpleButton();
            this.txtSerialThanhPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bteKhoThucHien = new DevExpress.XtraEditors.ButtonEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.ucCodeGenerate = new QLBH.Common.UserControls.UCCodeGenerate();
            this.label6 = new System.Windows.Forms.Label();
            this.bteLyDoTraHang = new DevExpress.XtraEditors.ButtonEdit();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoThucHien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteLyDoTraHang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSerialCu
            // 
            this.txtSerialCu.BackColor = System.Drawing.Color.White;
            this.txtSerialCu.Location = new System.Drawing.Point(135, 121);
            this.txtSerialCu.Name = "txtSerialCu";
            this.txtSerialCu.Size = new System.Drawing.Size(265, 21);
            this.txtSerialCu.TabIndex = 4;
            this.txtSerialCu.Leave += new System.EventHandler(this.txtSerialCu_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Serial lỗi:";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(135, 94);
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(265, 21);
            this.txtDienGiai.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Diễn giải:";
            // 
            // txtSerialMoi
            // 
            this.txtSerialMoi.Location = new System.Drawing.Point(135, 175);
            this.txtSerialMoi.Name = "txtSerialMoi";
            this.txtSerialMoi.Size = new System.Drawing.Size(265, 21);
            this.txtSerialMoi.TabIndex = 6;
            this.txtSerialMoi.Leave += new System.EventHandler(this.txtSerialMoi_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Serial mới:";
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(305, 202);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShortCutKey = System.Windows.Forms.Keys.Escape;
            this.btnDong.Size = new System.Drawing.Size(95, 25);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Thoát(ESC)";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(198, 202);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.ShortCutKey = System.Windows.Forms.Keys.F5;
            this.btnXacNhan.Size = new System.Drawing.Size(101, 25);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "Xác nhận(F5)";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSerialThanhPham
            // 
            this.txtSerialThanhPham.BackColor = System.Drawing.Color.White;
            this.txtSerialThanhPham.Location = new System.Drawing.Point(135, 148);
            this.txtSerialThanhPham.Name = "txtSerialThanhPham";
            this.txtSerialThanhPham.ReadOnly = true;
            this.txtSerialThanhPham.Size = new System.Drawing.Size(265, 21);
            this.txtSerialThanhPham.TabIndex = 5;
            this.txtSerialThanhPham.Leave += new System.EventHandler(this.txtSerialThanhPham_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Serial thành phẩm:";
            // 
            // bteKhoThucHien
            // 
            this.bteKhoThucHien.Location = new System.Drawing.Point(135, 42);
            this.bteKhoThucHien.Name = "bteKhoThucHien";
            this.bteKhoThucHien.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.bteKhoThucHien.Properties.Appearance.Options.UseBackColor = true;
            this.bteKhoThucHien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteKhoThucHien.Properties.ReadOnly = true;
            this.bteKhoThucHien.Size = new System.Drawing.Size(265, 20);
            this.bteKhoThucHien.TabIndex = 1;
            this.bteKhoThucHien.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteKhoThucHien_ButtonClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Kho thực hiện:";
            // 
            // ucCodeGenerate
            // 
            this.ucCodeGenerate.FieldName = "SoChungTu";
            this.ucCodeGenerate.Location = new System.Drawing.Point(135, 12);
            this.ucCodeGenerate.Name = "ucCodeGenerate";
            this.ucCodeGenerate.Prefix = "PXDLK";
            this.ucCodeGenerate.Size = new System.Drawing.Size(267, 26);
            this.ucCodeGenerate.TabIndex = 0;
            this.ucCodeGenerate.TableName = "Tbl_ChungTu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 29;
            this.label6.Text = "Số phiếu xuất:";
            // 
            // bteLyDoTraHang
            // 
            this.bteLyDoTraHang.Location = new System.Drawing.Point(135, 68);
            this.bteLyDoTraHang.Name = "bteLyDoTraHang";
            this.bteLyDoTraHang.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.bteLyDoTraHang.Properties.Appearance.Options.UseBackColor = true;
            this.bteLyDoTraHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteLyDoTraHang.Properties.ReadOnly = true;
            this.bteLyDoTraHang.Size = new System.Drawing.Size(265, 20);
            this.bteLyDoTraHang.TabIndex = 2;
            this.bteLyDoTraHang.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteLyDoTraHang_ButtonClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Lý do trả hàng:";
            // 
            // frmDoiMaLinhKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 250);
            this.Controls.Add(this.bteLyDoTraHang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ucCodeGenerate);
            this.Controls.Add(this.bteKhoThucHien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSerialThanhPham);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtSerialMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDienGiai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerialCu);
            this.Controls.Add(this.label4);
            this.Name = "frmDoiMaLinhKien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi linh kiện lỗi";
            this.Load += new System.EventHandler(this.frmDoiMaLinhKien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoThucHien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteLyDoTraHang.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtSerialCu;
        protected System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtDienGiai;
        protected System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtSerialMoi;
        protected System.Windows.Forms.Label label3;
        protected QLBH.Core.Form.GtidSimpleButton btnXacNhan;
        protected QLBH.Core.Form.GtidSimpleButton btnDong;
        public System.Windows.Forms.TextBox txtSerialThanhPham;
        protected System.Windows.Forms.Label label1;
        protected DevExpress.XtraEditors.ButtonEdit bteKhoThucHien;
        private System.Windows.Forms.Label label5;
        private QLBH.Common.UserControls.UCCodeGenerate ucCodeGenerate;
        private System.Windows.Forms.Label label6;
        protected DevExpress.XtraEditors.ButtonEdit bteLyDoTraHang;
        private System.Windows.Forms.Label label7;
    }
}