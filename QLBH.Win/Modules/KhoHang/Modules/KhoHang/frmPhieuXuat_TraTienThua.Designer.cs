using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    partial class frmPhieuXuat_TraTienThua
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
            this.cboHinhThucTra = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTienTraLai_Chu = new GtidTextBox();
            this.txtTienConNo = new GtidTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new GtidButton();
            this.lblTienTe = new System.Windows.Forms.Label();
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
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiền trả";
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
            this.groupBox1.Controls.Add(this.cboHinhThucTra);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTienTraLai_Chu);
            this.groupBox1.Controls.Add(this.txtTienConNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 167);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // cboHinhThucTra
            // 
            this.cboHinhThucTra.FormattingEnabled = true;
            this.cboHinhThucTra.Location = new System.Drawing.Point(164, 129);
            this.cboHinhThucTra.Name = "cboHinhThucTra";
            this.cboHinhThucTra.Size = new System.Drawing.Size(278, 21);
            this.cboHinhThucTra.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(10, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Hình thức trả";
            // 
            // txtTienTraLai_Chu
            // 
            this.txtTienTraLai_Chu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTienTraLai_Chu.Location = new System.Drawing.Point(15, 62);
            this.txtTienTraLai_Chu.Multiline = true;
            this.txtTienTraLai_Chu.Name = "txtTienTraLai_Chu";
            this.txtTienTraLai_Chu.ReadOnly = true;
            this.txtTienTraLai_Chu.Size = new System.Drawing.Size(427, 52);
            this.txtTienTraLai_Chu.TabIndex = 6;
            // 
            // txtTienConNo
            // 
            this.txtTienConNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTienConNo.Location = new System.Drawing.Point(165, 19);
            this.txtTienConNo.Name = "txtTienConNo";
            this.txtTienConNo.ReadOnly = true;
            this.txtTienConNo.Size = new System.Drawing.Size(278, 31);
            this.txtTienConNo.TabIndex = 3;
            this.txtTienConNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(11, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tiền còn lại";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(349, 270);
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
            this.lblTienTe.Location = new System.Drawing.Point(19, 277);
            this.lblTienTe.Name = "lblTienTe";
            this.lblTienTe.Size = new System.Drawing.Size(111, 15);
            this.lblTienTe.TabIndex = 6;
            this.lblTienTe.Text = "Đơn vị tính: VNĐ";
            // 
            // frmPhieuXuat_TraTienThua
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(487, 304);
            this.Controls.Add(this.lblTienTe);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTienThucTra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTienThanhToan);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuXuat_TraTienThua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính tiền trả lại (Esc để thoát)";
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
        public System.Windows.Forms.TextBox txtTienConNo;
        private System.Windows.Forms.Label label3;
        private QLBH.Core.Form.GtidButton btnClose;
        private System.Windows.Forms.Label lblTienTe;
        private System.Windows.Forms.TextBox txtTienTraLai_Chu;
        private System.Windows.Forms.ComboBox cboHinhThucTra;
        private System.Windows.Forms.Label label6;
    }
}