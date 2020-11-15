using QLBH.Core.Form;
namespace QLBanHang.Forms
{
    partial class frmBC_PhieuNhapChuaDuChiTiet
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoPO = new GtidTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtNgayTo = new System.Windows.Forms.DateTimePicker();
            this.txtMaSanPham = new GtidTextBox();
            this.dtNgayFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoPhieu = new GtidTextBox();
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTrungtam = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXemBC = new GtidButton();
            this.btnThoat = new GtidButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTieuDe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTieuDe.Location = new System.Drawing.Point(17, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(424, 19);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "BÁO CÁO CÁC PHIẾU CHƯA NHẬP ĐỦ CHI TIẾT";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoPO);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtNgayTo);
            this.groupBox1.Controls.Add(this.txtMaSanPham);
            this.groupBox1.Controls.Add(this.dtNgayFrom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSoPhieu);
            this.groupBox1.Controls.Add(this.cboKho);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboTrungtam);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 181);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtSoPO
            // 
            this.txtSoPO.Location = new System.Drawing.Point(107, 122);
            this.txtSoPO.Name = "txtSoPO";
            this.txtSoPO.Size = new System.Drawing.Size(306, 20);
            this.txtSoPO.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Số PO";
            // 
            // dtNgayTo
            // 
            this.dtNgayTo.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayTo.Location = new System.Drawing.Point(293, 148);
            this.dtNgayTo.Name = "dtNgayTo";
            this.dtNgayTo.Size = new System.Drawing.Size(119, 20);
            this.dtNgayTo.TabIndex = 43;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(107, 94);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(305, 20);
            this.txtMaSanPham.TabIndex = 84;
            // 
            // dtNgayFrom
            // 
            this.dtNgayFrom.CustomFormat = "dd/MM/yyyy";
            this.dtNgayFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayFrom.Location = new System.Drawing.Point(107, 148);
            this.dtNgayFrom.Name = "dtNgayFrom";
            this.dtNgayFrom.Size = new System.Drawing.Size(119, 20);
            this.dtNgayFrom.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 82;
            this.label7.Text = "Mã sản phẩm";
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(107, 67);
            this.txtSoPhieu.Name = "txtSoPhieu";
            this.txtSoPhieu.Size = new System.Drawing.Size(306, 20);
            this.txtSoPhieu.TabIndex = 2;
            // 
            // cboKho
            // 
            this.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(107, 41);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(306, 21);
            this.cboKho.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "đến";
            // 
            // cboTrungtam
            // 
            this.cboTrungtam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrungtam.FormattingEnabled = true;
            this.cboTrungtam.Location = new System.Drawing.Point(107, 16);
            this.cboTrungtam.Name = "cboTrungtam";
            this.cboTrungtam.Size = new System.Drawing.Size(306, 21);
            this.cboTrungtam.TabIndex = 1;
            this.cboTrungtam.SelectedIndexChanged += new System.EventHandler(this.cboTrungtam_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thời gian từ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số phiếu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kho";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trung tâm";
            // 
            // btnXemBC
            // 
            this.btnXemBC.Location = new System.Drawing.Point(143, 233);
            this.btnXemBC.Name = "btnXemBC";
            this.btnXemBC.Size = new System.Drawing.Size(87, 25);
            this.btnXemBC.TabIndex = 3;
            this.btnXemBC.Text = "Xem";
            this.btnXemBC.UseVisualStyleBackColor = true;
            this.btnXemBC.Click += new System.EventHandler(this.btnXemBC_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(236, 233);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(82, 25);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmBC_PhieuNhapChuaDuChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 269);
            this.ControlBox = false;
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXemBC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmBC_PhieuNhapChuaDuChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo các phiếu chưa nhập đủ chi tiết";
            this.Load += new System.EventHandler(this.frmBC_KiemKeKho_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.ComboBox cboKho;
        private System.Windows.Forms.ComboBox cboTrungtam;
        private System.Windows.Forms.DateTimePicker dtNgayFrom;
        private QLBH.Core.Form.GtidButton btnXemBC;
        private QLBH.Core.Form.GtidButton btnThoat;
        private System.Windows.Forms.DateTimePicker dtNgayTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoPO;
        private System.Windows.Forms.Label label6;
    }
}