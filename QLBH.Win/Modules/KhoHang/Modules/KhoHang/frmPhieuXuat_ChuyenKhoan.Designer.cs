using QLBH.Core.Form;
namespace QLBanHang.Forms
{
    partial class frmPhieuXuat_ChuyenKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTienThanhToan = new GtidTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTienThucTra = new GtidTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNganHang = new GtidTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoTaiKhoan = new GtidTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new GtidButton();
            this.lblTienTe = new System.Windows.Forms.Label();
            this.cboHinhThucTra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTienConNo = new GtidTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiền phải thanh toán";
            // 
            // txtTienThanhToan
            // 
            this.txtTienThanhToan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTienThanhToan.Location = new System.Drawing.Point(177, 15);
            this.txtTienThanhToan.Name = "txtTienThanhToan";
            this.txtTienThanhToan.ReadOnly = true;
            this.txtTienThanhToan.Size = new System.Drawing.Size(278, 31);
            this.txtTienThanhToan.TabIndex = 2;
            this.txtTienThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(23, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiền chuyển khoản";
            // 
            // txtTienThucTra
            // 
            this.txtTienThucTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTienThucTra.Location = new System.Drawing.Point(177, 55);
            this.txtTienThucTra.Name = "txtTienThucTra";
            this.txtTienThucTra.Size = new System.Drawing.Size(278, 31);
            this.txtTienThucTra.TabIndex = 0;
            this.txtTienThucTra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTienThucTra.TextChanged += new System.EventHandler(this.txtTienThucTra_TextChanged);
            this.txtTienThucTra.GotFocus += new System.EventHandler(this.txtTienThucTra_Enter);
            this.txtTienThucTra.LostFocus += new System.EventHandler(this.txtTienThucTra_LostFocus);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTienConNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboHinhThucTra);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNganHang);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSoTaiKhoan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 174);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtNganHang
            // 
            this.txtNganHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNganHang.Location = new System.Drawing.Point(165, 46);
            this.txtNganHang.Multiline = true;
            this.txtNganHang.Name = "txtNganHang";
            this.txtNganHang.Size = new System.Drawing.Size(278, 51);
            this.txtNganHang.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(11, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngân hàng";
            // 
            // txtSoTaiKhoan
            // 
            this.txtSoTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoTaiKhoan.Location = new System.Drawing.Point(165, 19);
            this.txtSoTaiKhoan.Name = "txtSoTaiKhoan";
            this.txtSoTaiKhoan.Size = new System.Drawing.Size(139, 22);
            this.txtSoTaiKhoan.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số tài khoản";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(349, 281);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng (ESC)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTienTe
            // 
            this.lblTienTe.AutoSize = true;
            this.lblTienTe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTienTe.Location = new System.Drawing.Point(19, 288);
            this.lblTienTe.Name = "lblTienTe";
            this.lblTienTe.Size = new System.Drawing.Size(111, 15);
            this.lblTienTe.TabIndex = 6;
            this.lblTienTe.Text = "Đơn vị tính: VNĐ";
            // 
            // cboHinhThucTra
            // 
            this.cboHinhThucTra.FormattingEnabled = true;
            this.cboHinhThucTra.Location = new System.Drawing.Point(165, 103);
            this.cboHinhThucTra.Name = "cboHinhThucTra";
            this.cboHinhThucTra.Size = new System.Drawing.Size(278, 21);
            this.cboHinhThucTra.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(11, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Hình thức trả";
            // 
            // txtTienConNo
            // 
            this.txtTienConNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTienConNo.Location = new System.Drawing.Point(165, 131);
            this.txtTienConNo.Name = "txtTienConNo";
            this.txtTienConNo.ReadOnly = true;
            this.txtTienConNo.Size = new System.Drawing.Size(278, 29);
            this.txtTienConNo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(11, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Còn nợ";
            // 
            // frmPhieuXuat_ChuyenKhoan
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(487, 322);
            this.Controls.Add(this.lblTienTe);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTienThucTra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTienThanhToan);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuXuat_ChuyenKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển khoản (Esc để thoát)";
            this.Load += new System.EventHandler(this.frmPhieuXuat_TraTienThua_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhieuXuat_TraTienThua_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTienThanhToan;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTienThucTra;
        private System.Windows.Forms.GroupBox groupBox1;
        private QLBH.Core.Form.GtidButton btnClose;
        private System.Windows.Forms.Label lblTienTe;
        public System.Windows.Forms.TextBox txtNganHang;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtSoTaiKhoan;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cboHinhThucTra;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtTienConNo;
        private System.Windows.Forms.Label label7;
    }
}