using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

// form frmChungTuNhap_ChiTietHangHoa
// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:


namespace QLBanHang.Modules.KhoHang
{
    public class frmChungTuChiTietHanghoaNhapNcc : frmChungTuNhap_ChiTietHangHoaBase
    {
        private frmChiTiet_ChungTuNhapBase frm;
        private ChungTuCTHanghoaBasePairInfo HangHoa;
        public List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet;
        private int Trangthai;
        List<ChungTuNhapNccChiTietHangHoaInfo> ListAll = new List<ChungTuNhapNccChiTietHangHoaInfo>();

        public frmChungTuChiTietHanghoaNhapNcc(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo HangHoa, List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet,List<ChungTuNhapNccChiTietHangHoaInfo> ListAll,int TrangThai)
            : base(frm, HangHoa)
        {
            this.frm = frm;
            this.HangHoa = HangHoa;
            this.liChiTiet = liChiTiet;
            this.ListAll = ListAll;
            this.Trangthai = TrangThai;
        }
        protected override void AddNewInstance()
        {
            if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(HangHoa.IdSanPham, txtMaVach.Text.Trim()) > 0)
            {
                throw new InvalidOperationException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
            }
            if (ListAll.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
            { return ct.MaVach == txtMaVach.Text.Trim() && HangHoa.IdSanPham != ct.IdSanPham; }).Count > 0)
            {
                throw new InvalidOperationException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
            }
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
            liChiTiet.Add(new ChungTuNhapNccChiTietHangHoaInfo { MaVach = txtMaVach.Text.Trim(), DonGia = HangHoa.DonGia, TenDonViTinh = HangHoa.DonViTinh, SoLuong = 1, ThanhTien = HangHoa.DonGia, IdSanPham = HangHoa.IdSanPham,TransactionID = HangHoa.TransactionID});
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
            ((BindingList<ChungTuNhapNccChiTietHangHoaInfo>)dgvList.DataSource).ResetBindings();
        }
        protected override void Check()
        {
            if (TblHangHoaChiTietDataProvider.IsUsedForAnotherProduct(txtMaVach.Text.Trim(),idSanPham))
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
                throw new ManagedException("Số lượng mã vạch đã đủ. Không thể nhập thêm !");
            }
        }

        protected override void DeleteInstance()
        {
            if(dgvList.CurrentRow==null) return;

            ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo =
                (ChungTuNhapNccChiTietHangHoaInfo) dgvList.CurrentRow.DataBoundItem;

            if(TblHangHoaChiTietDataProvider.DaDungChoGiaoDichKhac(chiTietHangHoaInfo.IdChiTietHangHoa))
            {
                throw new ManagedException("Mã vạch đã được sử dụng. Không thể thay đổi!");
            }

            dgvList.Rows.Remove(dgvList.CurrentRow);
            count--;
            SoLuongTong = count * HangHoa.DonGia;
            //btnXoaDong.Enabled = false;
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
        }
        protected override void LoadDataInstance()
        {
            dgvList.DataSource = new BindingList<ChungTuNhapNccChiTietHangHoaInfo>(liChiTiet)
                                     {
                                         AllowEdit = true,
                                         AllowNew = true,
                                         AllowRemove = true,
                                         RaiseListChangedEvents = true};
            if (Trangthai == 3)
            {
                btnXoaDong.Enabled = false;
            }
            else
            {
                btnXoaDong.Enabled = true;
            }

            btnXoaDong.Enabled = frm.OID == 0;

            foreach (ChungTuNhapNccChiTietHangHoaInfo pt in liChiTiet)
            {
                count = count + pt.SoLuong;
                SoLuongTong = count * pt.DonGia;
            }
        }
    }
}
