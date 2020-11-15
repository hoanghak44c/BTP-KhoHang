using QLBH.Core.Form;

namespace QLBanHang.Forms
{
    partial class frmPhieuXuatHoaDon_ChonChietKhau
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
            if (disposing && (components != null)) {
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
            this.cboChietKhau = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChapNhan = new GtidButton();
            this.txtMaChietKhau = new GtidTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTongTienCK = new GtidTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVAT = new GtidTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTienCK = new GtidTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCacel = new GtidButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboChietKhau
            // 
            this.cboChietKhau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChietKhau.FormattingEnabled = true;
            this.cboChietKhau.Location = new System.Drawing.Point(203, 19);
            this.cboChietKhau.Name = "cboChietKhau";
            this.cboChietKhau.Size = new System.Drawing.Size(311, 21);
            this.cboChietKhau.TabIndex = 2;
            this.cboChietKhau.SelectedIndexChanged += new System.EventHandler(this.cboPhieuXuat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã sản phẩm";
            // 
            // btnChapNhan
            // 
            this.btnChapNhan.Location = new System.Drawing.Point(197, 157);
            this.btnChapNhan.Name = "btnChapNhan";
            this.btnChapNhan.Size = new System.Drawing.Size(75, 23);
            this.btnChapNhan.TabIndex = 6;
            this.btnChapNhan.Text = "Chấp nhận";
            this.btnChapNhan.UseVisualStyleBackColor = true;
            this.btnChapNhan.Click += new System.EventHandler(this.btnChapNhan_Click);
            // 
            // txtMaChietKhau
            // 
            this.txtMaChietKhau.Location = new System.Drawing.Point(90, 20);
            this.txtMaChietKhau.Name = "txtMaChietKhau";
            this.txtMaChietKhau.Size = new System.Drawing.Size(107, 20);
            this.txtMaChietKhau.TabIndex = 1;
            this.txtMaChietKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaChietKhau_KeyDown);
            this.txtMaChietKhau.Leave += new System.EventHandler(this.txtMaChietKhau_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTongTienCK);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtVAT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTienCK);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMaChietKhau);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboChietKhau);
            this.groupBox1.Location = new System.Drawing.Point(6, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 91);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // txtTongTienCK
            // 
            this.txtTongTienCK.Location = new System.Drawing.Point(390, 56);
            this.txtTongTienCK.Name = "txtTongTienCK";
            this.txtTongTienCK.ReadOnly = true;
            this.txtTongTienCK.Size = new System.Drawing.Size(124, 20);
            this.txtTongTienCK.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tổng tiền CK";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(254, 56);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(45, 20);
            this.txtVAT.TabIndex = 4;
            this.txtVAT.TextChanged += new System.EventHandler(this.txtVAT_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "VAT (%)";
            // 
            // txtTienCK
            // 
            this.txtTienCK.Location = new System.Drawing.Point(90, 56);
            this.txtTienCK.Name = "txtTienCK";
            this.txtTienCK.Size = new System.Drawing.Size(107, 20);
            this.txtTienCK.TabIndex = 3;
            this.txtTienCK.TextChanged += new System.EventHandler(this.txtTienCK_TextChanged);
            this.txtTienCK.Leave += new System.EventHandler(this.txtTienCK_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tiền chiết khấu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(169, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "CHIẾT KHẤU HÀNG HÓA";
            // 
            // btnCacel
            // 
            this.btnCacel.Location = new System.Drawing.Point(278, 157);
            this.btnCacel.Name = "btnCacel";
            this.btnCacel.Size = new System.Drawing.Size(75, 23);
            this.btnCacel.TabIndex = 7;
            this.btnCacel.Text = "Hủy bỏ";
            this.btnCacel.UseVisualStyleBackColor = true;
            this.btnCacel.Click += new System.EventHandler(this.btnCacel_Click);
            // 
            // frmPhieuXuatHoaDon_ChonChietKhau
            // 
            this.AcceptButton = this.btnChapNhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 191);
            this.Controls.Add(this.btnCacel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChapNhan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuXuatHoaDon_ChonChietKhau";
            this.Text = "Chọn chiết khấu";
            this.Load += new System.EventHandler(this.frm_HoaDonBan_ChonTyleVAT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboChietKhau;
        private System.Windows.Forms.Label label2;
        private QLBH.Core.Form.GtidButton btnChapNhan;
        private System.Windows.Forms.TextBox txtMaChietKhau;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTongTienCK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTienCK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private QLBH.Core.Form.GtidButton btnCacel;
    }
}