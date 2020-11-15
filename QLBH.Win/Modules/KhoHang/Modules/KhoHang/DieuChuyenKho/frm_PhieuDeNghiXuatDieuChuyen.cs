using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using QLBanHang.Modules.BanHang.Reports;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Base;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Infors;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDeNghiXuatDieuChuyen : frm_DieuChuyenKhoBase
    {
        private DeNghiXuatDieuChuyenBussiness business;
        DeNghiNhapDieuChuyenBussiness deNghiNhapDieuChuyenBussiness;
        DeNghiNhapDieuChuyenTGBussiness deNghiNhapDieuChuyenTGBussiness;
        private int IdKho;
        private string PhieuNhap;
        private string TenKho;
        private int IdKhoDieuChuyen;
        private int trangThai;
        private readonly bool isEdit;

        private string soPhieuNhanDieuChuyen = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyen,
                                                                                  true);
        private string soPhieuNhanDieuChuyenTG = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyenTrungGian,
                                                                                  true);
        private DataGridViewTextBoxColumn colMaSanPham;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private CheckBox chkKhoTong;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

        public frm_PhieuDeNghiXuatDieuChuyen()
            : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.CellEndEdit += new DataGridViewCellEventHandler(dgvChiTiet_CellEndEdit);
            business = new DeNghiXuatDieuChuyenBussiness();
            chungTuInfo = business.ChungTu;
            isEdit = false;
        }

        public frm_PhieuDeNghiXuatDieuChuyen(ChungTuXuatDieuChuyenInfo info)
            : base(info, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.CellEndEdit += new DataGridViewCellEventHandler(dgvChiTiet_CellEndEdit);
            business = new DeNghiXuatDieuChuyenBussiness(info);
            trangThai = business.ChungTu.TrangThai;
            isEdit = false;
        }

        public frm_PhieuDeNghiXuatDieuChuyen(ChungTuXuatDieuChuyenInfo info, bool isEdit)
            : base(info, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.CellEndEdit += new DataGridViewCellEventHandler(dgvChiTiet_CellEndEdit);
            business = new DeNghiXuatDieuChuyenBussiness(info);
            trangThai = business.ChungTu.TrangThai;
            this.isEdit = isEdit;
        }

        void dgvChiTiet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == clSoLuong.Index)
            {
                business.ListChiTietChungTu[e.RowIndex].Thanhtien =
                    business.ListChiTietChungTu[e.RowIndex].DonGia*
                    business.ListChiTietChungTu[e.RowIndex].SoLuong;
            }
        }

        protected override void ChonKhoDen()
        {
            //base.ChonKhoDen();

            //-giam doc sieu thi, admin nganh hang thuc hien all
            //-xuat di tu kho tong
            //-- neu trung tam hach toan la kho tong, thi kho den la all
            //-- nguoc lai, kho den thuoc trung tam hach toan


            if(ConnectionUtil.Instance.IsUAT == 1)
            {
                base.ChonKhoDen();

                return;
            }

            if (bteKhoDi.Tag == null)
            {
                throw new ManagedException("Bạn chưa chọn kho đi!");
            }
            
            if ((Declare.USER_INFOR as NguoiDungInfor).DieuChuyen == 1)

                base.ChonKhoDen();

            else if (!String.IsNullOrEmpty(((DMKhoInfo)bteKhoDi.Tag).OtherTrungTam) &&

                ((DMKhoInfo)bteKhoDi.Tag).OtherTrungTam.Contains(String.Format(",{0},", Declare.IdTrungTamHachToan)))
            {
                var frmLookUp = new frmLookUp_Kho(false, String.Format("%{0}%", bteKhoDen.Text), Declare.IdTrungTamHachToan, -1, -1);

                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteKhoDen.Tag = frmLookUp.SelectedItem;
                    bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
                }                
            }
            else
            {
                var frmLookUp = new frmLookUp_Kho(false, String.Format("%{0}%", bteKhoDen.Text), ((DMKhoInfo)bteKhoDi.Tag).IdTrungTam, -1, -1);

                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteKhoDen.Tag = frmLookUp.SelectedItem;
                    bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
                }
            }
        }

        #region Event bteKhoDi
        private void bteKhoDi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (business.ChungTu.IdChungTu != 0) return;

            frmLookUpBaseKho frmLookUp;

            if ((Declare.USER_INFOR as NguoiDungInfor).IdNhomNguoiDung == Declare.NHOM_GIAM_DOC_SIEU_THI)
            {
                frmLookUp = new frmLookUp_Kho();
            } 
            else
            {
                frmLookUp = new frmLookUp_KhoDieuChuyen(Declare.IdNhanVien);
            }

            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                if (bteKhoDi.Tag != frmLookUp.SelectedItem)
                {
                    bteKhoDi.Tag = frmLookUp.SelectedItem;
                    bteKhoDi.Text = frmLookUp.SelectedItem.TenKho;
                    business.ChungTu.IdKho = frmLookUp.SelectedItem.IdKho;

                    if (business != null && business.ListChiTietChungTu.Count > 0)
                    {
                        if (MessageBox.Show(@"Bạn thay đổi kho xuất dữ liệu sẽ bị mất đi.\r\nBạn có muốn thay đổi không?",
                                                            "Thông báo",
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            dgvChiTiet.Rows.Clear();
                        }
                    }
                }
            }
        }
        
        private void bteKhoDi_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKhoDi.Text)) bteKhoDi.Tag = null;
        }

        private void bteKhoDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (business.ChungTu.IdChungTu != 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_KhoDieuChuyen frmLookUp = new frmLookUp_KhoDieuChuyen(Declare.IdNhanVien);
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    if (bteKhoDi.Tag != frmLookUp.SelectedItem)
                    {
                        bteKhoDi.Tag = frmLookUp.SelectedItem;
                        bteKhoDi.Text = frmLookUp.SelectedItem.TenKho;
                        business.ChungTu.IdKho = frmLookUp.SelectedItem.IdKho;
                        if (business != null && business.ListChiTietChungTu.Count > 0)
                        {
                            if (MessageBox.Show("Bạn thay đổi kho xuất dữ liệu sẽ bị mất đi.\nBạn có muốn thay đổi không?",
                                                                "Thông báo",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                dgvChiTiet.Rows.Clear();
                            }
                        }
                    }
                }
            }
        }
        #endregion 
        private bool CheckCungTrungTam()
        {
            DMKhoInfo pt = DeNghiXuatDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKho);
            DMKhoInfo gt = DeNghiXuatDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKhoDieuChuyen);
            return pt.IdTrungTam == gt.IdTrungTam;
        }

        protected override int GetIdKho()
        {
            int ex = -1;
            if (bteKhoDi.Tag != null)
            {
                ex = ((DMKhoInfo) bteKhoDi.Tag).IdKho;
            }
            else
            {
                clsUtils.MsgCanhBao("Bạn chưa chọn kho đi!");
            }
            return ex ;
        }

        protected override void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            foreach (DeNghiXuatDieuChuyenInfor pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == sanPhamInfo.IdSanPham)
                {
                    MessageBox.Show("Không được nhập 2 mã sản phẩm giống nhau trên cùng 1 phiếu !");
                    return;
                }
            }
            if(business.ListChiTietChungTu.Count >=12)
            {
                MessageBox.Show("Số lượng sản phẩm nhiều quá! In hóa đơn sẽ bị tràn trang!");
                business.ListChiTietChungTu.RemoveAt(11);
                ((BindingSource)dgvChiTiet.DataSource).ResetBindings(true);
                return;
            }
            if(bteKhoDi.Tag == null)
            {
                clsUtils.MsgThongBao("Bạn chưa chọn kho đi nên chưa thể chọn sản phẩm được!");
                return;
            }

            List<TonDauKyInfo> item = DeNghiXuatDieuChuyenDataProvider.Instance.GetListHangTonKhoByIdSanPham(((DMKhoInfo)bteKhoDi.Tag).IdKho, sanPhamInfo.IdSanPham);
            if (item.Count > 0)
            {
                MessageBox.Show("Sản phẩm đã hết tồn kho xin mời bạn chọn hàng khác!");
                return;
            }
            var unitPrice = DeNghiXuatDieuChuyenDataProvider.Instance.
                GetUnitPrice(((DMKhoInfo) bteKhoDi.Tag).IdTrungTam,
                             sanPhamInfo.IdSanPham);
            
            business.ListChiTietChungTu[dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow)] =
                new DeNghiXuatDieuChuyenInfor()
                    {
                        MaSanPham = sanPhamInfo.MaSanPham,
                        IdSanPham = sanPhamInfo.IdSanPham,
                        TenSanPham = sanPhamInfo.TenSanPham,
                        DonGia = unitPrice,
                        Thanhtien = unitPrice,
                        TrungMaVach = sanPhamInfo.TrungMaVach,
                        SoLuong = 1,
                        IdKho = business.ChungTu.IdKho
                    };

            ((BindingSource)dgvChiTiet.DataSource).ResetBindings(false);
            btnCapNhat.Enabled = business.ListChiTietChungTu.Count > 0;
        }

        protected override DataGridViewTextBoxColumn ColumnMaSanPham
        {
            get
            {
                return colMaSanPham;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow == null) return;
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvChiTiet.Rows.Count > 0)
                {
                    dgvChiTiet.Rows.RemoveAt(dgvChiTiet.CurrentRow.Index);
                    btnXoaSP.Enabled = false;
                }
            }
        }

        private BindingSource bdSource;

        void bdSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (dgvChiTiet.Rows.Count == bdSource.Count)
            {
                bdSource.RemoveAt(bdSource.Count - 1);
                return;
            }
        }

        protected override void LoadDataInstance()
        {
            base.LoadDataInstance();
            DateTime Ngaylap = chungTuInfo.NgayLap;
            if (Ngaylap <= dtNgayLap.Properties.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                dtNgayLap.Enabled = false;
            }
            else
            {
                dtNgayLap.EditValue = Convert.ToString(chungTuInfo.NgayLap);
                dtNgayLap.Enabled = false;
            }
            bdSource = new BindingSource();
            
            if (business.ListChiTietChungTu != null)
            {
                bdSource.DataSource = new BindingList<DeNghiXuatDieuChuyenInfor>(business.ListChiTietChungTu);

                if (business.ListChiTietChungTu.Count > 0)
                    dgvChiTiet.Enabled = false;
            }

            chkKhoTong.Checked = chungTuInfo.GiaoNhan == Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO);

            bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);


            dgvChiTiet.DataSource = bdSource;
            btnCapNhat.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if (
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_XUAT) || 
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN)  ||
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN) || 
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT)
                )
            {
                btnCapNhat.Enabled = false;
                txtPhuongtien.Enabled = false;
                txtHoaDonDC.Enabled = false;
                txtGhiChu.Enabled = false;
                bteNguoiVanChuyen.Enabled = false;
                bteNguoiUyNhiem.Enabled = false;
                bteNguoiKyDuyet.Enabled = false;
                clSoLuong.ReadOnly = false;
            }
            else
            {
                dtNgayLap.Enabled = false;
                btnThemSP.Enabled = true;
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = false;
            }

            if (isEdit && trangThai != Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN))
            {
                btnCapNhat.Enabled = true;
                txtPhuongtien.Enabled = true;
                txtHoaDonDC.Enabled = true;
                txtGhiChu.Enabled = true;
                bteNguoiVanChuyen.Enabled = true;
                bteNguoiUyNhiem.Enabled = true;
                bteNguoiKyDuyet.Enabled = true;
            }
        }

        protected override void GetValuesInstance(int e)
        {
            btnChiTietMaVach.Enabled = false;
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount <= 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            if (String.IsNullOrEmpty(bteKhoDi.Text) || bteKhoDi.Tag == null)
            {
                throw new ManagedException("Bạn chưa chọn kho hàng xuất đi !");
            }
            if (String.IsNullOrEmpty(bteKhoDen.Text) || bteKhoDen.Tag == null)
            {
                throw new ManagedException("Bạn chưa chọn kho hàng chuyển đến !");
            }
            if (bteKhoDen.Text == bteKhoDi.Text)
            {
                throw new ManagedException("Bạn phải chọn kho khác với kho hiện tại!");
            }
            if (Equals(bteNguoiUyNhiem.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn người ủy nhiệm !");
            }
            if (Equals(bteNguoiVanChuyen.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn người vận chuyển !");
            }
            if (Equals(bteNguoiKyDuyet.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn người ký duyệt!");
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
                {
                    throw new ManagedException("Bạn chưa nhập số lượng!");
                }
            }
            DeNghiXuatDieuChuyenInfor pt = business.ListChiTietChungTu.Find(delegate(DeNghiXuatDieuChuyenInfor match)
                                                                            {
                                                                                return match.IdSanPham == 0;
                                                                            });
            if (pt !=null)
            {
                business.ListChiTietChungTu.Remove(pt);
            }

            business.ListChiTietChungTu.ForEach(
                delegate(DeNghiXuatDieuChuyenInfor action)
                    {
                        if (DeNghiXuatDieuChuyenDataProvider.Instance.
                            DangCoPhieuDieuChuyenChoNhanSerial(action.IdKho,
                                                               action.IdSanPham))
                            throw new ManagedException("Sản phẩm " + action.MaSanPham +
                                                       " đang nhận điều chuyển chờ thủ kho nhập serial, không thể làm thêm xuất điều chuyển mới.");
                    });

            return true;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }

        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                base.SaveChungTuInstance();

                chungTuInfo.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));

                business.ChungTu = chungTuInfo;

                //nếu thêm mới
                if (chungTuInfo.IdChungTu == 0)
                {
                    business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN);
                }

                if (CheckCungTrungTam()) //cùng trung tâm
                {
                    ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenInfor = DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(chungTuInfo.SoChungTu);

                    if (chungTuNhapDieuChuyenInfor == null)
                        deNghiNhapDieuChuyenBussiness = new DeNghiNhapDieuChuyenBussiness(new ChungTuNhapDieuChuyenInfo
                        {
                            //detail của phiếu đề nghị nhận điều chuyển
                            LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                            //IdChungTu = OID,
                            IdNhanVien = Declare.IdNhanVien,
                            SoChungTu = soPhieuNhanDieuChuyen,
                            SoChungTuGoc = txtSoPhieu.Text.Trim(),
                            GhiChu = txtGhiChu.Text.Trim(),
                            NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")),
                            IdKho = chungTuInfo.IdKhoDieuChuyen,
                            HoaDonDC = chungTuInfo.HoaDonDC,
                            PhuongTien = chungTuInfo.PhuongTien,
                            IdNguoiUyNhiem = chungTuInfo.IdNguoiUyNhiem,
                            IdNguoiVC = chungTuInfo.IdNguoiVC,
                            IdNguoiKyDuyet = chungTuInfo.IdNguoiKyDuyet,
                            IdKhoNhanCuoi = chungTuInfo.IdKhoNhanCuoi
                        });
                    else
                        deNghiNhapDieuChuyenBussiness = new DeNghiNhapDieuChuyenBussiness(chungTuNhapDieuChuyenInfor);

                    deNghiNhapDieuChuyenBussiness.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));

                    foreach (DeNghiXuatDieuChuyenInfor deNghiDieuChuyenInfor in business.ListChiTietChungTu)
                    {
                        DeNghiNhapDieuChuyenChiTietInfor deNghiNhanDieuChuyenChiTietInfor =
                            deNghiNhapDieuChuyenBussiness.ListChiTietChungTu.Find(
                                delegate(DeNghiNhapDieuChuyenChiTietInfor match)
                                    {
                                        return match.IdSanPham == deNghiDieuChuyenInfor.IdSanPham;
                                    });

                        if(deNghiNhanDieuChuyenChiTietInfor != null)
                        {
                            deNghiNhanDieuChuyenChiTietInfor.SoLuong = deNghiDieuChuyenInfor.SoLuong;
                            deNghiNhanDieuChuyenChiTietInfor.DonGia = deNghiDieuChuyenInfor.DonGia;
                            deNghiNhanDieuChuyenChiTietInfor.Thanhtien = deNghiDieuChuyenInfor.Thanhtien;
                        } 
                        else
                            deNghiNhapDieuChuyenBussiness.ListChiTietChungTu.Add(
                                new DeNghiNhapDieuChuyenChiTietInfor
                                    {
                                        IdSanPham = deNghiDieuChuyenInfor.IdSanPham,
                                        SoLuong = deNghiDieuChuyenInfor.SoLuong,
                                        MaSanPham = deNghiDieuChuyenInfor.MaSanPham,
                                        TenSanPham = deNghiDieuChuyenInfor.TenSanPham,
                                        DonGia = deNghiDieuChuyenInfor.DonGia,
                                        Thanhtien = deNghiDieuChuyenInfor.Thanhtien,
                                    });
                    }

                    if (deNghiNhapDieuChuyenBussiness.ChungTu.IdChungTu == 0)
                        deNghiNhapDieuChuyenBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);

                    //hah: khong goi ham save tai day
                    //deNghiNhapDieuChuyenBussiness.SaveChungTu();

                    if (business.ChungTu.IdChungTu == 0)
                        business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);
                }
                else // khác trung tâm
                {
                    ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenTrungGian = DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDCTGBySoCTGoc(chungTuInfo.SoChungTu);
                    
                    if (chungTuNhapDieuChuyenTrungGian == null)
                        deNghiNhapDieuChuyenBussiness = new DeNghiNhapDieuChuyenTGBussiness(new ChungTuNhapDieuChuyenInfo
                        {
                            //detail của phiếu đề nghị nhận điều chuyển trung gian
                            LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN),
                            //IdChungTu = OID,
                            IdNhanVien = Declare.IdNhanVien,
                            SoChungTu = soPhieuNhanDieuChuyenTG,
                            SoChungTuGoc = txtSoPhieu.Text.Trim(),
                            GhiChu = txtGhiChu.Text.Trim(),
                            NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN")),
                            IdKho = -chungTuInfo.IdKho,
                            IdKhoDieuChuyen = chungTuInfo.IdKhoDieuChuyen,
                            HoaDonDC = chungTuInfo.HoaDonDC,
                            PhuongTien = chungTuInfo.PhuongTien,
                            IdNguoiUyNhiem = chungTuInfo.IdNguoiUyNhiem,
                            IdNguoiVC = chungTuInfo.IdNguoiVC,
                            IdNguoiKyDuyet = chungTuInfo.IdNguoiKyDuyet,
                            IdKhoNhanCuoi = chungTuInfo.IdKhoNhanCuoi
                        });
                    else
                        deNghiNhapDieuChuyenBussiness = new DeNghiNhapDieuChuyenTGBussiness(chungTuNhapDieuChuyenTrungGian);

                    deNghiNhapDieuChuyenBussiness.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));

                    foreach (DeNghiXuatDieuChuyenInfor deNghiDieuChuyenInfor in business.ListChiTietChungTu)
                    {
                        DeNghiNhapDieuChuyenChiTietInfor deNghiNhanDieuChuyenChiTietTgInfor =
                            deNghiNhapDieuChuyenBussiness.ListChiTietChungTu.Find(
                                delegate(DeNghiNhapDieuChuyenChiTietInfor match)
                                {
                                    return match.IdSanPham == deNghiDieuChuyenInfor.IdSanPham;
                                });

                        if (deNghiNhanDieuChuyenChiTietTgInfor != null)
                        {
                            deNghiNhanDieuChuyenChiTietTgInfor.SoLuong = deNghiDieuChuyenInfor.SoLuong;
                            deNghiNhanDieuChuyenChiTietTgInfor.DonGia = deNghiDieuChuyenInfor.DonGia;
                            deNghiNhanDieuChuyenChiTietTgInfor.Thanhtien = deNghiDieuChuyenInfor.Thanhtien;
                        }
                        else
                            deNghiNhapDieuChuyenBussiness.ListChiTietChungTu.Add(
                                new DeNghiNhapDieuChuyenChiTietInfor
                                {
                                    IdSanPham = deNghiDieuChuyenInfor.IdSanPham,
                                    SoLuong = deNghiDieuChuyenInfor.SoLuong,
                                    MaSanPham = deNghiDieuChuyenInfor.MaSanPham,
                                    TenSanPham = deNghiDieuChuyenInfor.TenSanPham,
                                    DonGia = deNghiDieuChuyenInfor.DonGia,
                                    Thanhtien = deNghiDieuChuyenInfor.Thanhtien,
                                });
                    }
                    //Hah: tai sao tao phieu moi dieu chuyen khac trung tam trang thai lai la cho nhan chua xuat ???
                    if (deNghiNhapDieuChuyenBussiness.ChungTu.IdChungTu == 0)
                        deNghiNhapDieuChuyenBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);

                    //hah: khong goi ham save tai day
                    //deNghiNhapDieuChuyenBussiness.SaveChungTu();

                    if (business.ChungTu.IdChungTu == 0)
                    {
                        business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);

                        business.ChungTu.GiaoNhan = chkKhoTong.Checked
                                                        ? Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO)
                                                        : Convert.ToInt32(LoaiGiaoNhan.KHONG_GIAO);
                    }
                }
            }
        }

        protected override void SaveChungTu()
        {
            if(isEdit)
            {
                ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenInfo =
                    DeNghiXuatDieuChuyenDataProvider.Instance.GetChungTuXuatDieuChuyenById(OID);

                ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenTgInfo =
                    DeNghiNhapDieuChuyenTGDataProvider.Instance.GetChungTuNhanDCTGBySoCTGoc(
                        chungTuXuatDieuChuyenInfo.SoChungTu);

                ChungTuNhapDieuChuyenInfo chungTuNhapDieuChuyenInfo =
                    DeNghiNhapDieuChuyenDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(
                        chungTuXuatDieuChuyenInfo.SoChungTu);

                ChungTuXuatDieuChuyenInfo chungTuXuatDieuChuyenTgInfo =
                    chungTuNhapDieuChuyenInfo == null
                        ? null
                        : DeNghiXuatDieuChuyenTGDataProvider.Instance.GetChungTuXuatDCTGBySoCTGoc(
                            chungTuNhapDieuChuyenInfo.SoChungTu);

                if (bteNguoiKyDuyet.Tag == null)
                {
                    if(MessageBox.Show("Bạn chưa chọn người ký duyệt, có tiếp tục thực hiện không?", "Xác nhận", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        bteNguoiKyDuyet.Focus();
                        return;
                    }
                }

                if (bteNguoiUyNhiem.Tag == null)
                {
                    if (MessageBox.Show("Bạn chưa chọn người ủy nhiệm, có tiếp tục thực hiện không?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        bteNguoiUyNhiem.Focus();
                        return;
                    }
                }

                if (bteNguoiVanChuyen.Tag == null)
                {
                    if (MessageBox.Show("Bạn chưa chọn người vận chuyển, có tiếp tục thực hiện không?", "Xác nhận",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        bteNguoiVanChuyen.Focus();
                        return;
                }

                if(String.IsNullOrEmpty(txtHoaDonDC.Text))
                {
                    if (MessageBox.Show("Bạn chưa nhập số hóa đơn, có tiếp tục thực hiện không?", "Xác nhận", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        txtHoaDonDC.Focus();
                        return;
                    }                    
                }

                if (chungTuNhapDieuChuyenTgInfo != null)
                {
                    if (bteNguoiKyDuyet.Tag != null)
                        chungTuNhapDieuChuyenTgInfo.IdNguoiKyDuyet = ((DMNhanVienInfo)bteNguoiKyDuyet.Tag).IdNhanVien;
                    if (bteNguoiUyNhiem.Tag != null)
                        chungTuNhapDieuChuyenTgInfo.IdNguoiUyNhiem = ((DMNhanVienInfo)bteNguoiUyNhiem.Tag).IdNhanVien;
                    if (bteNguoiVanChuyen.Tag != null)
                        chungTuNhapDieuChuyenTgInfo.IdNguoiVC = ((DMNhanVienInfo)bteNguoiVanChuyen.Tag).IdNhanVien;
                    
                    chungTuNhapDieuChuyenTgInfo.IdKhoNhanCuoi = bteKhoNhanCuoi.Tag != null ? ((DMKhoInfo) bteKhoNhanCuoi.Tag).IdKho : ((DMKhoInfo)bteKhoDen.Tag).IdKho;

                    chungTuNhapDieuChuyenTgInfo.GhiChu = txtGhiChu.Text;
                    chungTuNhapDieuChuyenTgInfo.HoaDonDC = txtHoaDonDC.Text;
                    chungTuNhapDieuChuyenTgInfo.PhuongTien = txtPhuongtien.Text;
                }

                if (chungTuXuatDieuChuyenTgInfo != null)
                {
                    if (bteNguoiKyDuyet.Tag != null)
                        chungTuXuatDieuChuyenTgInfo.IdNguoiKyDuyet = ((DMNhanVienInfo)bteNguoiKyDuyet.Tag).IdNhanVien;
                    if (bteNguoiUyNhiem.Tag != null)
                        chungTuXuatDieuChuyenTgInfo.IdNguoiUyNhiem = ((DMNhanVienInfo)bteNguoiUyNhiem.Tag).IdNhanVien;
                    if (bteNguoiVanChuyen.Tag != null)
                        chungTuXuatDieuChuyenTgInfo.IdNguoiVC = ((DMNhanVienInfo)bteNguoiVanChuyen.Tag).IdNhanVien;
                    
                    chungTuXuatDieuChuyenTgInfo.IdKhoNhanCuoi = bteKhoNhanCuoi.Tag != null ? ((DMKhoInfo)bteKhoNhanCuoi.Tag).IdKho : ((DMKhoInfo)bteKhoDen.Tag).IdKho;
                    
                    chungTuXuatDieuChuyenTgInfo.GhiChu = txtGhiChu.Text;
                    chungTuXuatDieuChuyenTgInfo.HoaDonDC = txtHoaDonDC.Text;
                    chungTuXuatDieuChuyenTgInfo.PhuongTien = txtPhuongtien.Text;
                    chungTuXuatDieuChuyenTgInfo.GiaoNhan = chkKhoTong.Checked ? Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO) : Convert.ToInt32(LoaiGiaoNhan.KHONG_GIAO);
                }

                if (chungTuNhapDieuChuyenInfo!= null)
                {
                    if (bteNguoiKyDuyet.Tag != null)
                        chungTuNhapDieuChuyenInfo.IdNguoiKyDuyet = ((DMNhanVienInfo) bteNguoiKyDuyet.Tag).IdNhanVien;
                    if (bteNguoiUyNhiem.Tag != null)
                        chungTuNhapDieuChuyenInfo.IdNguoiUyNhiem = ((DMNhanVienInfo) bteNguoiUyNhiem.Tag).IdNhanVien;
                    if (bteNguoiVanChuyen.Tag != null)
                        chungTuNhapDieuChuyenInfo.IdNguoiVC = ((DMNhanVienInfo) bteNguoiVanChuyen.Tag).IdNhanVien;
                    
                    chungTuNhapDieuChuyenInfo.IdKhoNhanCuoi = bteKhoNhanCuoi.Tag != null ? ((DMKhoInfo)bteKhoNhanCuoi.Tag).IdKho : ((DMKhoInfo)bteKhoDen.Tag).IdKho;
                    
                    chungTuNhapDieuChuyenInfo.GhiChu = txtGhiChu.Text;
                    chungTuNhapDieuChuyenInfo.HoaDonDC = txtHoaDonDC.Text;
                    chungTuNhapDieuChuyenInfo.PhuongTien = txtPhuongtien.Text;
                }

                if (bteNguoiKyDuyet.Tag != null)
                    chungTuXuatDieuChuyenInfo.IdNguoiKyDuyet = ((DMNhanVienInfo) bteNguoiKyDuyet.Tag).IdNhanVien;
                if (bteNguoiUyNhiem.Tag != null)
                    chungTuXuatDieuChuyenInfo.IdNguoiUyNhiem = ((DMNhanVienInfo) bteNguoiUyNhiem.Tag).IdNhanVien;
                if (bteNguoiVanChuyen.Tag != null)
                    chungTuXuatDieuChuyenInfo.IdNguoiVC = ((DMNhanVienInfo) bteNguoiVanChuyen.Tag).IdNhanVien;
                
                chungTuXuatDieuChuyenInfo.IdKhoNhanCuoi = bteKhoNhanCuoi.Tag != null ? ((DMKhoInfo)bteKhoNhanCuoi.Tag).IdKho : ((DMKhoInfo)bteKhoDen.Tag).IdKho;
                
                chungTuXuatDieuChuyenInfo.GhiChu = txtGhiChu.Text;
                chungTuXuatDieuChuyenInfo.HoaDonDC = txtHoaDonDC.Text;
                chungTuXuatDieuChuyenInfo.PhuongTien = txtPhuongtien.Text;
                chungTuXuatDieuChuyenInfo.GiaoNhan = chkKhoTong.Checked ? Convert.ToInt32(LoaiGiaoNhan.KHO_TONG_GIAO) : Convert.ToInt32(LoaiGiaoNhan.KHONG_GIAO);

                try
                {
                    ConnectionUtil.Instance.BeginTransaction();

                    if (chungTuNhapDieuChuyenTgInfo != null)
                        DeNghiNhapDieuChuyenTGDataProvider.Instance.UpdateChungTu(chungTuNhapDieuChuyenTgInfo);

                    if (chungTuXuatDieuChuyenTgInfo != null)
                        DeNghiXuatDieuChuyenTGDataProvider.Instance.UpdateChungTu(chungTuXuatDieuChuyenTgInfo);

                    if (chungTuNhapDieuChuyenInfo != null)
                        DeNghiNhapDieuChuyenDataProvider.Instance.UpdateChungTu(chungTuNhapDieuChuyenInfo);

                    DeNghiXuatDieuChuyenDataProvider.Instance.UpdateChungTu(chungTuXuatDieuChuyenInfo);

                    ConnectionUtil.Instance.CommitTransaction();

                    return;
                }
                catch (Exception)
                {
                    ConnectionUtil.Instance.RollbackTransaction();
                    throw;
                }
            }

            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());

            if (li.Count > 0 && OID == 0)
            {
                txtSoPhieu.Focus();
                throw new ManagedException("Số phiếu đã tồn tại trong hệ thống. Xin hãy kiểm tra lại!");
            }
            if (this.Business == null) this.Business = GetBussiness();

            business.ChungTu.TongTienHang = 0;

            foreach (DeNghiXuatDieuChuyenInfor deNghiXuatDieuChuyenInfor in business.ListChiTietChungTu)
            {
                business.ChungTu.TongTienHang += deNghiXuatDieuChuyenInfor.Thanhtien;
            }

            SaveChungTuInstance();

            bool ngayChungTuEnabled = dtNgayLap.Enabled;

            frmProgress.Instance.Caption = Text;
            frmProgress.Instance.Description = "Đang thực hiện ...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.DoWork(
                delegate()
                    {
                        try
                        {
                            frmProgress.Instance.MaxValue = 15;

                            ConnectionUtil.Instance.BeginTransaction();

                            ChungTuBusinessBase clonedBusiness = business.Clone();

                            frmProgress.Instance.Value += 1;

                            if (((DeNghiXuatDieuChuyenBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
                            {
                                ((DeNghiXuatDieuChuyenBussiness)clonedBusiness).ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();

                                frmProgress.Instance.Value += 1;
                            }

                            clonedBusiness.SaveChungTu();

                            frmProgress.Instance.Value += 1;

                            clonedBusiness = deNghiNhapDieuChuyenBussiness.Clone();

                            frmProgress.Instance.Value += 1;

                            ((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.SoChungTuGoc = business.ChungTu.SoChungTu;

                            frmProgress.Instance.Value += 1;

                            if (((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
                            {
                                ((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();

                                frmProgress.Instance.Value += 1;
                            }

                            clonedBusiness.SaveChungTu();

                            frmProgress.Instance.Value += 1;

                            AfterSaveChungTuInstance();

                            ConnectionUtil.Instance.CommitTransaction();

                            frmProgress.Instance.Description = "Đã xong!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;
                        }
                        catch (Exception ex)
                        {
                            //if(!(ex is ManagedException))
                            {
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Đề nghị Xuất điều chuyển");
                            }

                            ConnectionUtil.Instance.RollbackTransaction();

                            //if(!(ex is ManagedException))
                            {
                                EventLogProvider.Instance.WriteOfflineLog("rollback completed.", "Đề nghị Xuất điều chuyển");
                            }
                            MessageBox.Show(ex.Message);

                            frmProgress.Instance.Description = "Giao dịch không thành công!";

                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                            frmProgress.Instance.IsCompleted = true;
                        }
                    });

            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //        {
            //            frmProgress.Instance.MaxValue = 15;

            //            ChungTuBusinessBase clonedBusiness = business.Clone();

            //            frmProgress.Instance.Value += 1;

            //            if (((DeNghiXuatDieuChuyenBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
            //            {
            //                ((DeNghiXuatDieuChuyenBussiness)clonedBusiness).ChungTu.NgayLap =
            //                    CommonProvider.Instance.GetSysDate();
                            
            //                frmProgress.Instance.Value += 1;
            //            }
                        
            //            clonedBusiness.SaveChungTu();

            //            frmProgress.Instance.Value += 1;

            //            clonedBusiness = deNghiNhapDieuChuyenBussiness.Clone();

            //            frmProgress.Instance.Value += 1;

            //            //((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.SoChungTu =
            //            //    (clonedBusiness is DeNghiNhapDieuChuyenTGBussiness)
            //            //        ? CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyenTrungGian)
            //            //        : CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyen);

            //            ((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.SoChungTuGoc = business.ChungTu.SoChungTu;

            //            frmProgress.Instance.Value += 1;

            //            if (((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.IdChungTu == 0 && !ngayChungTuEnabled)
            //            {
            //                ((DeNghiNhapDieuChuyenBussiness)clonedBusiness).ChungTu.NgayLap =
            //                    CommonProvider.Instance.GetSysDate();

            //                frmProgress.Instance.Value += 1;
            //            }

            //            clonedBusiness.SaveChungTu();

            //            frmProgress.Instance.Value += 1;

            //            AfterSaveChungTuInstance();

            //            frmProgress.Instance.Value += 1;
            //        });
            Reload();
        }

        protected override void OnDeleteChungTu()
        {
            if(((NguoiDungInfor)Declare.USER_INFOR).SupperUser== 0)
            {
                throw new Exception("Bạn không có quyền xóa");
            }
        }

        private void dgvChiTiet_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiXuatDieuChuyen));
            this.colMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkKhoTong = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoNhanCuoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bteKhoDen
            // 
            this.bteKhoDen.TabIndex = 4;
            // 
            // bteKhoDi
            // 
            this.bteKhoDi.TabIndex = 3;
            this.bteKhoDi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bteKhoDi_ButtonClick);
            this.bteKhoDi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bteKhoDi_KeyDown);
            this.bteKhoDi.TextChanged += new System.EventHandler(this.bteKhoDi_TextChanged);
            // 
            // bteNguoiVanChuyen
            // 
            this.bteNguoiVanChuyen.Size = new System.Drawing.Size(284, 20);
            this.bteNguoiVanChuyen.TabIndex = 8;
            // 
            // bteNguoiUyNhiem
            // 
            // 
            // bteNguoiKyDuyet
            // 
            this.bteNguoiKyDuyet.Location = new System.Drawing.Point(124, 126);
            this.bteNguoiKyDuyet.TabIndex = 10;
            // 
            // txtHoaDonDC
            // 
            this.txtHoaDonDC.Location = new System.Drawing.Point(124, 99);
            this.txtHoaDonDC.MaxLength = 125;
            this.txtHoaDonDC.TabIndex = 7;
            // 
            // txtPhuongtien
            // 
            this.txtPhuongtien.MaxLength = 125;
            this.txtPhuongtien.TabIndex = 5;
            // 
            // bteKhoNhanCuoi
            // 
            this.bteKhoNhanCuoi.TabIndex = 6;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.TabIndex = 14;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 15;
            this.btnXoaSP.Text = "Xóa ";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 19;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSanPham,
            this.dataGridViewTextBoxColumn2,
            this.clSoLuong,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 174);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 306);
            this.dgvChiTiet.TabIndex = 13;
            this.dgvChiTiet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvChiTiet_UserDeletingRow);
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(123, 151);
            this.txtGhiChu.TabIndex = 12;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(460, 20);
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(741, 20);
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 151);
            this.label4.TabIndex = 14;
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 20;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.TabIndex = 17;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.TabIndex = 18;
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(124, 20);
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
            this.dtNgayLap.Location = new System.Drawing.Point(582, 20);
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(153, 20);
            this.dtNgayLap.TabIndex = 1;
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.DataPropertyName = "MaSanPham";
            this.colMaSanPham.HeaderText = "Mã sản phẩm";
            this.colMaSanPham.MinimumWidth = 150;
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMaSanPham.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenSanPham";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên sản phẩm";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 50;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Thanhtien";
            this.dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TrangThai";
            this.dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 170;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MaVach";
            this.dataGridViewTextBoxColumn7.HeaderText = "mavach";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "IdSanPham";
            this.dataGridViewTextBoxColumn8.HeaderText = "clidsanpham";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "SoPhieuNhap";
            this.dataGridViewTextBoxColumn9.HeaderText = "sophieu";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TrungMaVach";
            this.dataGridViewTextBoxColumn10.HeaderText = "trungmavach";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TenDonViTinh";
            this.dataGridViewTextBoxColumn11.HeaderText = "donvitinh";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "SoPO";
            this.dataGridViewTextBoxColumn12.HeaderText = "soPO";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // chkKhoTong
            // 
            this.chkKhoTong.AutoSize = true;
            this.chkKhoTong.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkKhoTong.Location = new System.Drawing.Point(872, 101);
            this.chkKhoTong.Name = "chkKhoTong";
            this.chkKhoTong.Size = new System.Drawing.Size(69, 17);
            this.chkKhoTong.TabIndex = 9;
            this.chkKhoTong.Text = "Kho tổng";
            this.chkKhoTong.UseVisualStyleBackColor = true;
            // 
            // frm_PhieuDeNghiXuatDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.chkKhoTong);
            this.Name = "frm_PhieuDeNghiXuatDieuChuyen";
            this.Text = "Phiếu đề nghị xuất điều chuyển";
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.bteKhoNhanCuoi, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.bteKhoDen, 0);
            this.Controls.SetChildIndex(this.txtHoaDonDC, 0);
            this.Controls.SetChildIndex(this.txtPhuongtien, 0);
            this.Controls.SetChildIndex(this.bteNguoiVanChuyen, 0);
            this.Controls.SetChildIndex(this.bteNguoiUyNhiem, 0);
            this.Controls.SetChildIndex(this.bteKhoDi, 0);
            this.Controls.SetChildIndex(this.bteNguoiKyDuyet, 0);
            this.Controls.SetChildIndex(this.chkKhoTong, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoNhanCuoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // tạm thời không cho phép xóa line
        private void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
            //    if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
            //        btnXoaSP.Enabled = false;
            //        btnCapNhat.Enabled = dgvChiTiet.Rows.Count > 0;
            //    }
            //}
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (bteKhoDi.Tag != null)
            {
                frmLookUp_SanPham frm = new frmLookUp_SanPham(((DMKhoInfo) bteKhoDi.Tag).IdKho, 0, true, true);
                if (frm.ShowDialog() == DialogResult.OK) //nếu kết quả trả về là form LookUp
                {
                    PickUpSanPhamInfo(frm.SelectedItem);
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Bạn chưa chọn kho đi !");
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<BaoCao_ChiTietDCInfor> list = DeNghiXuatDieuChuyenDataProvider.Instance.GetPhieuBCDieuChuyen(OID);
                BaoCao_ChiTietDCInfor info = list[0];
                rpt_HoaDonDieuChuyenGTGT rpt = new rpt_HoaDonDieuChuyenGTGT(info);
                if (String.IsNullOrEmpty(chungTuInfo.HoaDonDC) || CheckCungTrungTam()) rpt.BeforePrint += rpt_BeforePrint;
                //List<BaoCao_ChiTietDCInfor> lst = new List<BaoCao_ChiTietDCInfor>(list);
                rpt.DataSource = list;
                rpt.ShowPreview();
            }
            catch (ManagedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
                EventLogProvider.Instance.WriteLog(ex.ToString(), "In hoa don dieu chuyen");
#else
                MessageBox.Show(ex.Message);
                EventLogProvider.Instance.WriteLog(ex.ToString(), "In hoa don dieu chuyen");
#endif
            }
        }

        void rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                e.Cancel = true;

                if (CheckCungTrungTam())

                    throw new ManagedException("Điều chuyển trong cùng trung tâm không phải in hóa đơn!");

                if (String.IsNullOrEmpty(chungTuInfo.HoaDonDC))

                    throw new ManagedException("Bạn chưa điền số hóa đơn điều chuyển!");
            }
            catch (ManagedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}
