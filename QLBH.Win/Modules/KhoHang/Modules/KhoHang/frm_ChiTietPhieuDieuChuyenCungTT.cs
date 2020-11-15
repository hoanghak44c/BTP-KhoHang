using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
//using QLBanHang.Modules.BaoHanh;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_ChiTietPhieuDieuChuyenCungTT : frmChungTuNhap_ChiTietHangHoaBase
    {
        public int IdChungTuChiTiet;
        private frmChiTiet_ChungTuNhapBase frm;
        private ChungTuCTHanghoaBasePairInfo liHangHoa;
        public List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        private int IdKhoDi;

        public frm_ChiTietPhieuDieuChuyenCungTT(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet)
            : base(frm,li)
        {
            this.frm = frm;
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
        }

        public frm_ChiTietPhieuDieuChuyenCungTT(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet, int IdKhoDi)
            : base(frm, li)
        {
            this.frm = frm;
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
            this.IdKhoDi = IdKhoDi;
        } 

        protected override void AddNewInstance()
        {
            txtMaVach.Text = txtMaVach.Text.Trim();
            if (liChiTiet.Count > 0)
            {
                foreach (ChungTu_ChiTietHangHoaBaseInfo pt in liChiTiet)
                {
                    if (pt.MaVach == txtMaVach.Text)
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
            liChiTiet.Add(new ChungTu_ChiTietHangHoaBaseInfo { MaVach = txtMaVach.Text, DonGia = liHangHoa.DonGia, TenDonViTinh = liHangHoa.DonViTinh, SoLuong = 1, ThanhTien = liHangHoa.DonGia, IdSanPham = liHangHoa.IdSanPham });
            ((BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dgvList.DataSource).ResetBindings();
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
        }
        protected override void DeleteInstance()
        {
            if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachByKho(Convert.ToInt32(dgvList.CurrentRow.Cells["clidsanpham"].Value), dgvList.CurrentRow.Cells["clMaVach"].Value.ToString(), Convert.ToInt32(dgvList.CurrentRow.Cells["clSoLuong"].Value)) > 0)
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
            else
            {
                clsUtils.MsgCanhBao("Mã vạch đã hết tồn không thể xóa được !");
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
                throw new ManagedException("Số lượng mã vạch đã nhập đủ. Không thể xuất thêm !");
            }
            if (!KhoXuatNccDataProvider.Instance.CheckSoLuong(IdKhoDi, liHangHoa.IdSanPham, txtMaVach.Text))
            {
                throw new ManagedException("Mã vạch hiện không có trong kho. Xin hãy kiểm tra lại !");
            }
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
            // frm_ChiTietPhieuDieuChuyenCungTT
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.Name = "frm_ChiTietPhieuDieuChuyenCungTT";
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
