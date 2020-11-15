using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;

// form frm_ChiTietXuatNoiBo
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 05/07/2012
// Người sửa cuối:
// Ngày sửa cuối:
//todo: @HanhBD form_ChiTietXuatNoiBo
namespace QLBanHang.Modules.KhoHang
{
    public class frm_ChiTietXuatNoiBo : frmChungTuNhap_ChiTietHangHoaBase
    {
        private ChungTuCTHanghoaBasePairInfo liHangHoa;
        public List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        public frm_ChiTietXuatNoiBo(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet)
            : base(frm,li)
        {
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
        } 
        protected override void AddNewInstance()
        {
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
            if (!KhoXuatNccDataProvider.Instance.CheckSoLuong(Declare.IdKho, liHangHoa.IdSanPham, txtMaVach.Text.Trim()))
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // frm_ChiTietXuatNoiBo
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChiTietXuatNoiBo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

    }
}
