using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public class frmMaVachNhapThanhPhan: frmChungTuNhap_ChiTietHangHoaBase
    {
        #region Declare
        private XuatLinhKienSanXuatBussiness business;
        frmChiTietNhapThanhPham frm;
        private ChungTuCTHanghoaBasePairInfo HangHoa;
        public List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet;
        #endregion


        public frmMaVachNhapThanhPhan(frmChiTietNhapThanhPham frm, ChungTuCTHanghoaBasePairInfo HangHoa, List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet):base(frm,HangHoa)
        {
            //InitializeComponent();
            this.frm = frm;
            this.HangHoa = HangHoa;
            this.liChiTiet = liChiTiet;

            business = new XuatLinhKienSanXuatBussiness(new ChungTuXuatNhapNccInfo());
        }

        protected override void AddNewInstance()
        {
            if (liChiTiet.Count > 0)
            {
                foreach (ChungTuNhapNccChiTietHangHoaInfo pt in liChiTiet)
                {
                    if (pt.MaVach == txtMaVach.Text.Trim())
                    {
                        pt.SoLuong = pt.SoLuong + 1;
                        pt.ThanhTien = pt.ThanhTien + pt.DonGia;
                        lblTongSoLuong.Text = "";
                        lblthanhtien.Text = "";
                        lblTongSoLuong.Text = count.ToString();
                        lblthanhtien.Text = SoLuongTong.ToString();
                        ((BindingList<ChungTuNhapNccChiTietHangHoaInfo>)dgvList.DataSource).ResetBindings();
                        return;
                    }
                }
            }
            liChiTiet.Add(new ChungTuNhapNccChiTietHangHoaInfo { MaVach = txtMaVach.Text.Trim(), DonGia = HangHoa.DonGia, TenDonViTinh = HangHoa.DonViTinh, SoLuong = 1, ThanhTien = HangHoa.DonGia, IdSanPham = HangHoa.IdSanPham });
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
            ((BindingList<ChungTuNhapNccChiTietHangHoaInfo>)dgvList.DataSource).ResetBindings();
        }

        protected override void Check()
        {
            if (KhoXuatNccDataProvider.Instance.CheckSoLuong(Declare.IdKho,HangHoa.IdSanPham,txtMaVach.Text.Trim()))
            {
                throw new ManagedException("Mã vạch hiện không có trong kho. Xin hãy kiểm tra lại !");
            }
            if (TblHangHoaChiTietDataProvider.IsUsedForAnotherProduct(txtMaVach.Text.Trim(), idSanPham))
            {
                throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
            }
            int soluong = 0;
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                soluong = soluong + liChiTiet[i].SoLuong;
            }
            if (soluong >= Convert.ToInt32(lblSoLuongTon.Text))
            {
                throw new InvalidOperationException("Số lượng mã vạch đã đủ. Không thể nhập thêm !");
            }
        }
        protected override void LoadDataInstance()
        {
            dgvList.DataSource = new BindingList<ChungTuNhapNccChiTietHangHoaInfo>(liChiTiet)
            {
                AllowEdit = true,
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true
            };
            btnXoaDong.Enabled = true;
            foreach (ChungTuNhapNccChiTietHangHoaInfo pt in liChiTiet)
            {
                count = count + pt.SoLuong;
                SoLuongTong = count * pt.DonGia;
            }
            dgvList.Columns["clDongia"].Visible = false;
            dgvList.Columns["clDongia"].Width = 200;
            dgvList.Columns["clThanhTien"].Visible = false;
            dgvList.Columns["clThanhTien"].Width = 150;
        }
    }
}
