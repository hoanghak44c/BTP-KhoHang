using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Modules.BaoHanh;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_ChiTietPhieuDieuChuyenCoDH : frmChungTuNhap_ChiTietHangHoaBase
    {
        private string SoChungTu;
        private int IdSanPham;
        private ChungTuCTHanghoaBasePairInfo liHangHoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.GroupBox groupBox4;
        public List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        public List<ChungTu_ChiTietHangHoaDCDHInfo> liChiTiet1;
        private ChungTuCTHanghoaBasePairInfo HangHoa = new ChungTuCTHanghoaBasePairInfo();
        private ComboBox cboDonHang;
        public List<ChiTietDieuChuyenDonHangInfo> litype = new List<ChiTietDieuChuyenDonHangInfo>();
        private int IdKhoNhap;
        public frm_ChiTietPhieuDieuChuyenCoDH(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet, string soChungTu, int idSanPham)
            : base(frm,li)
        {
            InitializeComponent();
            DataGridViewColumn col = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            col.HeaderText = "Đơn hàng";
            col.Name = "colDonHang";
            col.Visible = true;
            col.Width = 200;
            col.CellTemplate = cell;
            col.DataPropertyName = "SoChungTuBan";
            col.ReadOnly = true;
            col.DisplayIndex = cboDonHang.SelectedIndex;
            dgvList.Columns.Add(col);
            
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
            this.SoChungTu = soChungTu;
            this.IdSanPham = idSanPham;
        }

        public frm_ChiTietPhieuDieuChuyenCoDH(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet, string soChungTu, int idSanPham, int idKhoNhap)
            : base(frm, li)
        {
            InitializeComponent();
            DataGridViewColumn col = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            col.HeaderText = "Đơn hàng";
            col.Name = "colDonHang";
            col.Visible = true;
            col.Width = 200;
            col.CellTemplate = cell;
            col.DataPropertyName = "SoChungTuBan";
            col.ReadOnly = true;
            col.DisplayIndex = cboDonHang.SelectedIndex;
            dgvList.Columns.Add(col);

            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
            this.SoChungTu = soChungTu;
            this.IdSanPham = idSanPham;
            this.IdKhoNhap = idKhoNhap;
        }

        private void LoadDonHang()
        {
            litype = tblChungTuDataProvider.CheckSoPhieuByDH(SoChungTu,IdSanPham);
            if (litype.Count > 0)
            {
                cboDonHang.DisplayMember = "SoChungTu";
                cboDonHang.ValueMember = "IdChungTu";
                cboDonHang.DataSource = litype;
            }
            else
            {
                cboDonHang.DataSource = null;
            }
        }
        private string LoadSoCTBan(int idChiTiet)
        {
            ChungTu_ChiTietHangHoaDCDHInfo pt = new ChungTu_ChiTietHangHoaDCDHInfo();
            pt = tblChungTuDataProvider.GetSoChungTuBan(SoChungTu, idChiTiet);
            return pt.SoChungTuBan;
        }
        protected override void LoadDataInstance()
        {
            //thêm 1 list trung gian
            LoadDonHang();
            liChiTiet1 = liChiTiet.ConvertAll(delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                                                  {
                                                      return new ChungTu_ChiTietHangHoaDCDHInfo
                                                                 {
                                                                     DonGia = match.DonGia,
                                                                     IdChiTietHangHoa = match.IdChiTietHangHoa,
                                                                     IdChungTuChiTiet = match.IdChungTuChiTiet,
                                                                     IdSanPham = match.IdSanPham,
                                                                     MaSanPham = match.MaSanPham,
                                                                     MaVach = match.MaVach,
                                                                     SoLuong = match.SoLuong,
                                                                     TenDonViTinh = match.TenDonViTinh,
                                                                     TenSanPham = match.TenSanPham,
                                                                     ThanhTien = match.ThanhTien,
                                                                     TrangThai = match.TrangThai,
                                                                     TrungMaVach = match.TrungMaVach,
                                                                     SoChungTuDieuChuyen = SoChungTu,
                                                                     SoChungTuBan = LoadSoCTBan(match.IdChiTietHangHoa)
                                                                 };
                                                  });
            dgvList.DataSource = new BindingList<ChungTu_ChiTietHangHoaDCDHInfo>(liChiTiet1)
            {
                AllowEdit = true,
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true
            };
            btnXoaDong.Enabled = true;
            foreach (ChungTu_ChiTietHangHoaBaseInfo pt in liChiTiet)
            {
                count = count + pt.SoLuong;
                SoLuongTong = count * pt.DonGia;
            }
        }
        protected void CheckSoLuong()
        {
            int soluong = 0;
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                if (!dgvList.Rows[i].IsNewRow)
                {
                    soluong = soluong + (dgvList.Rows[i].DataBoundItem as ChungTu_ChiTietHangHoaDCDHInfo).SoLuong;
                }
            }
            if (soluong < HangHoa.SoLuong)
            {
                throw new ManagedException("Bạn chưa thêm đủ số mã vạch!");
            }
        }
        protected void CheckTonDH()
        {
            int soluongDH = 0;
            if(liChiTiet.Count!= null)
            {
                for (int i = 0;i< liChiTiet.Count;i++)
                {
                    soluongDH = soluongDH + liChiTiet[i].SoLuong;
                }
            }
            if (soluongDH >= Convert.ToInt32(lblSoLuong.Text))
            {
                throw new InvalidOperationException("Bạn không thể nhập quá số lượng của đơn hàng này!n/ Xin mời bạn chọn đơn hàng khác!");
            }
        }
        protected override void Check()
        {
            int soluong = 0;
            if (liChiTiet.Count != null)
            {
                for (int i = 0; i < liChiTiet.Count; i++)
                {
                    soluong = soluong + liChiTiet[i].SoLuong;
                }
            }
            if (soluong >= Convert.ToInt32(lblSoLuongTon.Text))
            {
                throw new InvalidOperationException("Số lượng mã vạch đã nhập đủ. Không thể xuất thêm !");
            }
            //BaoHanh_KhoHang.Check(txtMaVach.Text.Trim(), Declare.IdKho, IdKhoNhap, liHangHoa.IdSanPham);
        }
        protected override void AddNewInstance()
        {
            if (liChiTiet1.Count > 0)
            {
                foreach (ChungTu_ChiTietHangHoaBaseInfo pt in liChiTiet1)
                {
                    if (pt.MaVach == txtMaVach.Text.Trim())
                    {
                        pt.SoLuong = pt.SoLuong + 1;
                        pt.ThanhTien = pt.ThanhTien + pt.DonGia;
                        lblTongSoLuong.Text = "";
                        lblthanhtien.Text = "";
                        lblTongSoLuong.Text = count.ToString();
                        lblthanhtien.Text = SoLuongTong.ToString();
                        ((BindingList<ChungTu_ChiTietHangHoaDCDHInfo>)dgvList.DataSource).ResetBindings();
                        return;
                    }
                }
            }
            liChiTiet1.Add(new ChungTu_ChiTietHangHoaDCDHInfo { MaVach = txtMaVach.Text.Trim(), DonGia = liHangHoa.DonGia, TenDonViTinh = liHangHoa.DonViTinh,
                SoLuong = 1,ThanhTien = liHangHoa.DonGia, IdSanPham = liHangHoa.IdSanPham,SoChungTuDieuChuyen = SoChungTu,SoChungTuBan = cboDonHang.Text});
            ((BindingList<ChungTu_ChiTietHangHoaDCDHInfo>)dgvList.DataSource).ResetBindings();
            liChiTiet = liChiTiet1.ConvertAll(delegate(ChungTu_ChiTietHangHoaDCDHInfo match)
                                             {
                                                 return match as ChungTu_ChiTietHangHoaBaseInfo;
                                             });
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboDonHang = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(2, 60);
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Location = new System.Drawing.Point(2, 181);
            this.groupBox2.Size = new System.Drawing.Size(654, 309);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(2, 488);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đơn hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Số lượng sản phẩm của đơn hàng";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(618, 22);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(24, 16);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "SL";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboDonHang);
            this.groupBox4.Controls.Add(this.lblSoLuong);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(2, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(653, 55);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // cboDonHang
            // 
            this.cboDonHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonHang.DropDownWidth = 365;
            this.cboDonHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDonHang.FormattingEnabled = true;
            this.cboDonHang.Location = new System.Drawing.Point(85, 19);
            this.cboDonHang.Name = "cboDonHang";
            this.cboDonHang.Size = new System.Drawing.Size(308, 24);
            this.cboDonHang.TabIndex = 15;
            this.cboDonHang.SelectedIndexChanged += new System.EventHandler(this.cboDonHang_SelectedIndexChanged);
            // 
            // frm_ChiTietPhieuDieuChuyenCoDH
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 536);
            this.Controls.Add(this.groupBox4);
            this.Name = "frm_ChiTietPhieuDieuChuyenCoDH";
            this.Text = "Chi tiết hàng hóa ";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        private void cboDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonHang.SelectedIndex == -1)
                return;
            else
            {
                cboDonHang.DisplayMember = "SoChungTu";
                cboDonHang.ValueMember = "IdChungTu";
                cboDonHang.DataSource = litype;
                // chọn số phiếu hiển thị số lượng
                lblSoLuong.Text = litype[cboDonHang.SelectedIndex].SoLuong.ToString();
            }
        }

        protected override void DeleteInstance()
        {
            //if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachByKho(Convert.ToInt32(dgvList.CurrentRow.Cells["clidsanpham"].Value), dgvList.CurrentRow.Cells["clMaVach"].Value.ToString(), Convert.ToInt32(dgvList.CurrentRow.Cells["clSoLuong"].Value)) > 0)
            //{
            dgvList.Rows.Remove(dgvList.CurrentRow);
            count--;
            SoLuongTong = count * liHangHoa.DonGia;
            //btnXoaDong.Enabled = false;
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
            //}
            //else
            //{
            //    clsUtils.MsgCanhBao("Mã vạch đã hết tồn không thể xóa được !");
            //}
        }
    }
}
