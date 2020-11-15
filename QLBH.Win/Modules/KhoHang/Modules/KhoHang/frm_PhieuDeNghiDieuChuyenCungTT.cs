using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using QLBanHang.Modules.BanHang.Reports;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDeNghiDieuChuyenCungTT : frm_DieuChuyenBase
    {
        private string SoPhieuNhanDC;
        private DeNghiDieuChuyenBussiness business;
        DeNghiNhanDieuChuyenBussiness deNghiNhanDieuChuyenBussiness;
        private int IdKho;
        private string PhieuNhap;
        private string TenKho;
        private int IdKhoDieuChuyen;
        private int trangThai;
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

        public frm_PhieuDeNghiDieuChuyenCungTT()
            : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiDieuChuyenBussiness();
            chungTuInfo = business.ChungTu;
        }

        public frm_PhieuDeNghiDieuChuyenCungTT(ChungTuDieuChuyenInfor info)
            : base(info, Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiDieuChuyenBussiness(info);
            trangThai = business.ChungTu.TrangThai;
        }
        //Check IdKho hiện tại với IdKho điều chuyển
        //Nếu khác trung tâm thì làm điều chuyển như bình thường
        //Nếu cùng trung tâm thì thêm 1 business nhập mới 
        //Save Chungtu khi cùng trung tâm thì save thêm 1 business nhập

        #region Event bteKhoDi
        private void bteKhoDi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho2 frmLookUp = new frmLookUp_Kho2(Declare.IdNhanVien);
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                if(bteKhoDi.Tag != frmLookUp.SelectedItem)
                {
                    bteKhoDi.Tag = frmLookUp.SelectedItem;
                    bteKhoDi.Text = frmLookUp.SelectedItem.TenKho;
                    if(business !=null && business.ListChiTietChungTu.Count > 0)
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
        private void bteKhoDi_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKhoDi.Text)) bteKhoDi.Tag = null;
        }

        private void bteKhoDi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho2 frmLookUp = new frmLookUp_Kho2(Declare.IdNhanVien);
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    if (bteKhoDi.Tag != frmLookUp.SelectedItem)
                    {
                        bteKhoDi.Tag = frmLookUp.SelectedItem;
                        bteKhoDi.Text = frmLookUp.SelectedItem.TenKho;
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
            DMKhoInfo pt = DeNghiDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKho);
            DMKhoInfo gt = DeNghiDieuChuyenDataProvider.Instance.GetIdTrungTamByIdKho(chungTuInfo.IdKhoDieuChuyen);
            return pt.IdTrungTam == gt.IdTrungTam;
        }

        protected override int GetIdKho()
        {
            if (bteKhoDi.Tag == null)
            {
                bteKhoDi.Focus();
                throw new ManagedException("Bạn chưa chọn kho đi.");
            }
            return ((DMKhoInfo)bteKhoDi.Tag).IdKho;
        }

        protected override void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            foreach (DeNghiDieuChuyenInfor pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == sanPhamInfo.IdSanPham)
                {
                    MessageBox.Show("Không được nhập 2 mã sản phẩm giống nhau trên cùng 1 phiếu !");
                    return;
                }
            }
            if(bteKhoDi.Tag == null)
            {
                clsUtils.MsgThongBao("Bạn chưa chọn kho đi nên chưa thể chọn sản phẩm được!");
                return;
            }
            List<TonDauKyInfo> item = DeNghiDieuChuyenDataProvider.Instance.GetListHangTonKhoByIdSanPham(((DMKhoInfo)bteKhoDi.Tag).IdKho, sanPhamInfo.IdSanPham);
            if (item.Count > 0)
            {
                MessageBox.Show("Sản phẩm đã hết tồn kho xin mời bạn chọn hàng khác!");
                return;
            }
                business.ListChiTietChungTu[dgvChiTiet.Rows.IndexOf(dgvChiTiet.CurrentRow)] = new DeNghiDieuChuyenInfor()
                    {
                        MaSanPham = sanPhamInfo.MaSanPham,
                        IdSanPham = sanPhamInfo.IdSanPham,
                        TenSanPham = sanPhamInfo.TenSanPham,
                        DonGia = sanPhamInfo.GiaNhap,
                        TrungMaVach = sanPhamInfo.TrungMaVach,
                        SoLuong = 1
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
            SoPhieuNhanDC = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhanDieuChuyen, true);
            DateTime Ngaylap = chungTuInfo.NgayLap;
            if (Ngaylap <= dtNgayLap.Properties.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                dtNgayLap.Enabled = false;
            }
            else
            {
                dtNgayLap.Text = Convert.ToString(chungTuInfo.NgayLap);
                dtNgayLap.Enabled = false;
            }
            bdSource = new BindingSource();
            if (business.ListChiTietChungTu != null)
                bdSource.DataSource = new BindingList<DeNghiDieuChuyenInfor>(business.ListChiTietChungTu);
            bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);
            dgvChiTiet.DataSource = bdSource;
            btnCapNhat.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_XUAT)|| trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN)
                || trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN) || trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT))
            {
                btnThemSP.Enabled = IsSupperUser();
                btnCapNhat.Enabled = IsSupperUser();
                txtNguoiLap.Enabled = IsSupperUser();
                txtGhiChu.Enabled = IsSupperUser();
                dtNgayLap.Enabled = IsSupperUser();
                //btnXoaSP.Enabled = IsSupperUser();
                clSoLuong.ReadOnly = !IsSupperUser();
            }
            else
            {
                dtNgayLap.Enabled = false;
                //btnXoaSP.Enabled = true;
                btnThemSP.Enabled = true;
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = false;
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
            if (Equals(bteKhoDi.Text, null))
            {
                throw new ManagedException("Bạn chưa chọn kho hàng xuất đi !");
            }
            if (Equals(bteKhoDen.Text, null))
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
            DeNghiDieuChuyenInfor pt = business.ListChiTietChungTu.Find(delegate(DeNghiDieuChuyenInfor match)
                                                                            {
                                                                                return match.IdSanPham == 0;
                                                                            });
            if (pt !=null)
            {
                business.ListChiTietChungTu.Remove(pt);
            }
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
                chungTuInfo.NgayLap = Convert.ToDateTime(dtNgayLap.Text);

                business.ChungTu = chungTuInfo;

                //nếu thêm mới
                if (chungTuInfo.IdChungTu == 0)
                {
                    business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN);
                }

                if (CheckCungTrungTam())
                {
                    ChungTuNhapDieuChuyenInfor chungTuNhapDieuChuyenInfor = DeNghiNhanDieuChuyenDataProvider.Instance.GetChungTuNhanDCBySoCTGoc(chungTuInfo.SoChungTu);

                    if (chungTuNhapDieuChuyenInfor == null)
                        deNghiNhanDieuChuyenBussiness = new DeNghiNhanDieuChuyenBussiness(new ChungTuNhapDieuChuyenInfor
                        {
                            //detail của phiếu đề nghị nhận điều chuyển
                            LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN),
                            IdChungTu = OID,
                            IdNhanVien = Declare.IdNhanVien,
                            SoChungTu = SoPhieuNhanDC,
                            SoChungTuGoc = txtSoPhieu.Text.Trim(),
                            GhiChu = txtGhiChu.Text.Trim(),
                            NgayLap = Convert.ToDateTime(dtNgayLap.EditValue,new CultureInfo("vi-VN")),
                            IdKho = chungTuInfo.IdKhoDieuChuyen,
                            HoaDonDC = chungTuInfo.HoaDonDC,
                            PhuongTien = chungTuInfo.PhuongTien,
                            IdNguoiUyNhiem = chungTuInfo.IdNguoiUyNhiem,
                            IdNguoiVC = chungTuInfo.IdNguoiVC,
                            IdNguoiKyDuyet = chungTuInfo.IdNguoiKyDuyet
                        });
                    else
                        deNghiNhanDieuChuyenBussiness = new DeNghiNhanDieuChuyenBussiness(chungTuNhapDieuChuyenInfor);

                    deNghiNhanDieuChuyenBussiness.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);

                    foreach (DeNghiDieuChuyenInfor deNghiDieuChuyenInfor in business.ListChiTietChungTu)
                    {
                        DeNghiNhanDieuChuyenInfor deNghiNhanDieuChuyenInfor =
                            deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Find(
                                delegate(DeNghiNhanDieuChuyenInfor match)
                                    {
                                        return match.IdSanPham == deNghiDieuChuyenInfor.IdSanPham;
                                    });

                        if(deNghiNhanDieuChuyenInfor != null)
                        {
                            deNghiNhanDieuChuyenInfor.SoLuong = deNghiDieuChuyenInfor.SoLuong;
                            deNghiNhanDieuChuyenInfor.DonGia = deNghiDieuChuyenInfor.DonGia;
                            deNghiNhanDieuChuyenInfor.Thanhtien = deNghiDieuChuyenInfor.Thanhtien;
                        } 
                        else
                            deNghiNhanDieuChuyenBussiness.ListChiTietChungTu.Add(
                                new DeNghiNhanDieuChuyenInfor
                                    {
                                        IdSanPham = deNghiDieuChuyenInfor.IdSanPham,
                                        SoLuong = deNghiDieuChuyenInfor.SoLuong,
                                        MaSanPham = deNghiDieuChuyenInfor.MaSanPham,
                                        TenSanPham = deNghiDieuChuyenInfor.TenSanPham,
                                        DonGia = deNghiDieuChuyenInfor.DonGia,
                                        Thanhtien = deNghiDieuChuyenInfor.Thanhtien,
                                    });
                    }

                    if (deNghiNhanDieuChuyenBussiness.ChungTu.IdChungTu == 0)
                        deNghiNhanDieuChuyenBussiness.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);

                    deNghiNhanDieuChuyenBussiness.SaveChungTu();

                    business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);
                }
            }
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
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiDieuChuyenCungTT));
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
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
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
            // 
            // bteNguoiUyNhiem
            // 
            // 
            // bteNguoiKyDuyet
            // 
            this.bteNguoiKyDuyet.TabIndex = 11;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.TabIndex = 13;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 14;
            this.btnXoaSP.Text = "Xóa ";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 18;
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
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 155);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 325);
            this.dgvChiTiet.TabIndex = 12;
            this.dgvChiTiet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvChiTiet_UserDeletingRow);
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.Location = new System.Drawing.Point(525, 20);
            this.dtNgayLap.TabIndex = 1;
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(117, 128);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 15;
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
            this.label3.Location = new System.Drawing.Point(696, 20);
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 128);
            this.label4.TabIndex = 14;
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 19;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.TabIndex = 16;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.TabIndex = 17;
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Location = new System.Drawing.Point(117, 20);
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.TabIndex = 0;
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
            // frm_PhieuDeNghiDieuChuyenCungTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Name = "frm_PhieuDeNghiDieuChuyenCungTT";
            this.Text = "Phiếu đề nghị xuất điều chuyển";
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiVanChuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiUyNhiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNguoiKyDuyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgvChiTiet.CurrentRow == null || dgvChiTiet.CurrentRow.IsNewRow) return;
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
                    btnXoaSP.Enabled = false;
                    btnCapNhat.Enabled = dgvChiTiet.Rows.Count > 0;
                }
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmLookUp_SanPham frm = new frmLookUp_SanPham(((DMKhoInfo)bteKhoDi.Tag).IdKho, 0, true, true);
            if (frm.ShowDialog() == DialogResult.OK)//nếu kết quả trả về là form LookUp
            {
                PickUpSanPhamInfo(frm.SelectedItem);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if(chungTuInfo.HoaDonDC != null)
            {
                List<BaoCao_ChiTietDCInfor> list = DeNghiDieuChuyenDataProvider.Instance.GetPhieuBCDieuChuyen(OID);
                BaoCao_ChiTietDCInfor info = list[0];
                rpt_HoaDonDieuChuyenGTGT rpt = new rpt_HoaDonDieuChuyenGTGT(info);
                List<BaoCao_ChiTietDCInfor> lst = new List<BaoCao_ChiTietDCInfor>(list);
                rpt.DataSource = lst;
                rpt.ShowPreview();
            }
            else
            {
                clsUtils.MsgThongBao("Bạn chưa điền số hóa đơn điều chuyển!");
            }
        }

        //private void bteKhoDen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoDen.Text));
        //    if (frmLookUp.ShowDialog() == DialogResult.OK)
        //    {
        //        bteKhoDen.Tag = frmLookUp.SelectedItem;
        //        bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
        //    }
        //}

        //private void bteKhoDen_DoubleClick(object sender, EventArgs e)
        //{
        //    frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoDen.Text));
        //    if (frmLookUp.ShowDialog() == DialogResult.OK)
        //    {
        //        bteKhoDen.Tag = frmLookUp.SelectedItem;
        //        bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
        //    }
        //}

        //private void bteKhoDen_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        frmLookUp_Kho frmLookUp = new frmLookUp_Kho(String.Format("%{0}%", bteKhoDen.Text));
        //        if (frmLookUp.ShowDialog() == DialogResult.OK)
        //        {
        //            bteKhoDen.Tag = frmLookUp.SelectedItem;
        //            bteKhoDen.Text = frmLookUp.SelectedItem.TenKho;
        //        }
        //    }
        //}

        //private void bteKhoDen_TextChanged(object sender, EventArgs e)
        //{
        //    if (String.IsNullOrEmpty(bteKhoDen.Text))
        //    {
        //        bteKhoDen.Tag = null;
        //    }
        //}
    }
}
