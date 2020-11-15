using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_ChiTietNhapNoiBo : frmChungTuNhap_ChiTietHangHoaBase
    {
        private ChungTuCTHanghoaBasePairInfo liHangHoa;
        List<BaoCao_ChiTietInfor> mv = new List<BaoCao_ChiTietInfor>();
        public List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        public frm_ChiTietNhapNoiBo(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet)
            : base(frm,li)
        {
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
        }
        protected override void LoadDataInstance()
        {
            dgvList.DataSource = new BindingList<ChungTu_ChiTietHangHoaBaseInfo>(liChiTiet)
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
        protected override void DeleteInstance()
        {
                dgvList.Rows.Remove(dgvList.CurrentRow);
                count--;
                SoLuongTong = count * liHangHoa.DonGia;
                //btnXoaDong.Enabled = false;
                lblTongSoLuong.Text = "";
                lblthanhtien.Text = "";
                lblTongSoLuong.Text = count.ToString();
                lblthanhtien.Text = SoLuongTong.ToString();
            
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
                throw new ManagedException("Số lượng mã vạch đã nhập đủ. Không thể xuất thêm !");
            }
            mv = NhapNoiBoDataProvider.Instance.GetTrungMaVach(txtMaVach.Text.Trim());
            if (mv.Count != 0)
            {
                throw new InvalidOperationException("Mã vạch đã có trong hệ thống. Xin mời bạn kiểm tra lại!");
            }
        }
        protected override void AddNewInstance()
        {
            if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(liHangHoa.IdSanPham, txtMaVach.Text.Trim()) > 0)
            {
                throw new InvalidOperationException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
            }
            if (liChiTiet.Count > 0)
            {
                foreach (ChungTu_ChiTietHangHoaBaseInfo pt in liChiTiet)
                {
                    if (pt.MaVach == txtMaVach.Text.Trim())
                    {
                        pt.SoLuong = pt.SoLuong + 1;
                        pt.ThanhTien = pt.ThanhTien + pt.DonGia;
                        lblTongSoLuong.Text = "";
                        lblthanhtien.Text = "";
                        lblTongSoLuong.Text = count.ToString();
                        lblthanhtien.Text = SoLuongTong.ToString();
                        ((BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dgvList.DataSource).ResetBindings();
                        return;
                    }
                }
            }
            liChiTiet.Add(new ChungTu_ChiTietHangHoaBaseInfo { MaVach = txtMaVach.Text.Trim(), DonGia = liHangHoa.DonGia, TenDonViTinh = liHangHoa.DonViTinh, SoLuong = 1, ThanhTien = liHangHoa.DonGia, IdSanPham = liHangHoa.IdSanPham });
            ((BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dgvList.DataSource).ResetBindings();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
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
            // frm_ChiTietNhapNoiBo
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.Name = "frm_ChiTietNhapNoiBo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
