using QLBH.Core.Form;
namespace QLBanHang.Forms
{
    partial class frm_BaoCaoNhapHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BaoCaoNhapHang));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaSanPham = new GtidTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSophieu = new GtidTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTrungTam = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKyBaoCao = new System.Windows.Forms.ComboBox();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdIn = new GtidButton();
            this.cmdThoat = new GtidButton();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaSanPham);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtSophieu);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboSanPham);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboNCC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboKho);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboTrungTam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(92, 100);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(134, 20);
            this.txtMaSanPham.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Mã sản phẩm";
            // 
            // txtSophieu
            // 
            this.txtSophieu.Location = new System.Drawing.Point(92, 154);
            this.txtSophieu.Name = "txtSophieu";
            this.txtSophieu.Size = new System.Drawing.Size(196, 20);
            this.txtSophieu.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Số phiếu";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(92, 127);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(349, 21);
            this.cboSanPham.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Sản phẩm";
            // 
            // cboNCC
            // 
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new System.Drawing.Point(92, 73);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(349, 21);
            this.cboNCC.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Nhà cung cấp";
            // 
            // cboKho
            // 
            this.cboKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(92, 46);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(349, 21);
            this.cboKho.TabIndex = 62;
            this.cboKho.SelectedIndexChanged += new System.EventHandler(this.cboKho_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Kho";
            // 
            // cboTrungTam
            // 
            this.cboTrungTam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrungTam.FormattingEnabled = true;
            this.cboTrungTam.Location = new System.Drawing.Point(92, 19);
            this.cboTrungTam.Name = "cboTrungTam";
            this.cboTrungTam.Size = new System.Drawing.Size(349, 21);
            this.cboTrungTam.TabIndex = 60;
            this.cboTrungTam.SelectedIndexChanged += new System.EventHandler(this.cboTrungTam_SelectedIndexChanged);
            this.cboTrungTam.Click += new System.EventHandler(this.cboTrungTam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Trung tâm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kỳ báo cáo";
            // 
            // cboKyBaoCao
            // 
            this.cboKyBaoCao.FormattingEnabled = true;
            this.cboKyBaoCao.Location = new System.Drawing.Point(89, 42);
            this.cboKyBaoCao.Name = "cboKyBaoCao";
            this.cboKyBaoCao.Size = new System.Drawing.Size(105, 21);
            this.cboKyBaoCao.TabIndex = 54;
            this.cboKyBaoCao.SelectedIndexChanged += new System.EventHandler(this.cboKyBaoCao_SelectedIndexChanged);
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(227, 42);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(98, 20);
            this.dtTuNgay.TabIndex = 56;
            this.dtTuNgay.ValueChanged += new System.EventHandler(this.dtTuNgay_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Từ";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(363, 42);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(98, 20);
            this.dtDenNgay.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "đến";
            // 
            // cmdIn
            // 
            this.cmdIn.Image = ((System.Drawing.Image)(resources.GetObject("cmdIn.Image")));
            this.cmdIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdIn.Location = new System.Drawing.Point(166, 260);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(105, 27);
            this.cmdIn.TabIndex = 59;
            this.cmdIn.Text = "Xem báo cáo";
            this.cmdIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdIn.UseVisualStyleBackColor = true;
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(277, 260);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 27);
            this.cmdThoat.TabIndex = 60;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.UseVisualStyleBackColor = true;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(180, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 19);
            this.label9.TabIndex = 61;
            this.label9.Text = "BÁO CÁO NHẬP HÀNG";
            // 
            // frm_BaoCaoNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 297);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdIn);
            this.Controls.Add(this.dtDenNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtTuNgay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboKyBaoCao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_BaoCaoNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo nhập hàng";
            this.Load += new System.EventHandler(this.frm_BaoCaoNhapHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKyBaoCao;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboKho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTrungTam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSophieu;
        private System.Windows.Forms.Label label8;
        private QLBH.Core.Form.GtidButton cmdIn;
        private QLBH.Core.Form.GtidButton cmdThoat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label10;
    }
}