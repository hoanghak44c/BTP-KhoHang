using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules
{
    public class frm_PhieuDeNghiNhanDieuChuyenNew : frm_DieuChuyenBase
    {
        //private DeNghiNhanDieuChuyenBussiness business;
        //private List<DeNghiNhanDieuChuyenInfor> liChiTiet; 
        private DeNghiNhanDieuChuyenBussiness business;
        private int idChungTuGoc;
        private int trangThai;
        private string TenKho;
        private int IdKhoDieuChuyen;
        private int LoaiChungTu;
        private QLBH.Core.Form.GtidTextBox txtSoCTG;
        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn clTenSanPham;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn clDonGia;
        private DataGridViewTextBoxColumn clThanhTien;
        private Label lblKhoHang;
        private Label lblChungTuGoc;

        public frm_PhieuDeNghiNhanDieuChuyenNew()
            : base(Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiNhanDieuChuyenBussiness();
        }

        public frm_PhieuDeNghiNhanDieuChuyenNew(ChungTuNhapDieuChuyenInfor info)
            : base(info, Declare.Prefix.PhieuNhanDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.SoCTG = info.SoChungTuGoc;
            this.NguoiLap = info.NguoiLap;
            this.TenKho = info.TenKho;
            this.IdKhoDieuChuyen = info.IdKhoDieuChuyen;
            this.trangThai = info.TrangThai;
            this.SoChungTu = info.SoChungTu;
            this.LoaiChungTu = info.LoaiChungTu;
            dgvChiTiet.AutoGenerateColumns = false;
            business = new DeNghiNhanDieuChuyenBussiness(info);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDeNghiNhanDieuChuyenNew));
            this.lblChungTuGoc = new System.Windows.Forms.Label();
            this.txtSoCTG = new QLBH.Core.Form.GtidTextBox();
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblKhoHang = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // bteKhoDen
            // 
            // 
            // bteKhodi
            // 
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            this.btnThemSP.TabIndex = 6;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.TabIndex = 7;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.TabIndex = 9;
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSanPham,
            this.clTenSanPham,
            this.clSoLuong,
            this.clDonGia,
            this.clThanhTien});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 176);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 304);
            this.dgvChiTiet.TabIndex = 5;
            this.dgvChiTiet.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvChiTiet_UserDeletingRow);
            this.dgvChiTiet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTiet_CellClick);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(113, 149);
            this.txtGhiChu.Size = new System.Drawing.Size(828, 21);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(457, 21);
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 149);
            this.label4.TabIndex = 14;
            // 
            // btnDong
            // 
            this.btnDong.TabIndex = 10;
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            // 
            // lblChungTuGoc
            // 
            this.lblChungTuGoc.AutoSize = true;
            this.lblChungTuGoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChungTuGoc.Location = new System.Drawing.Point(20, 130);
            this.lblChungTuGoc.Name = "lblChungTuGoc";
            this.lblChungTuGoc.Size = new System.Drawing.Size(54, 16);
            this.lblChungTuGoc.TabIndex = 15;
            this.lblChungTuGoc.Text = "Số CTG";
            // 
            // txtSoCTG
            // 
            this.txtSoCTG.Location = new System.Drawing.Point(117, 125);
            this.txtSoCTG.Name = "txtSoCTG";
            this.txtSoCTG.Size = new System.Drawing.Size(336, 21);
            this.txtSoCTG.TabIndex = 4;
            this.txtSoCTG.Leave += new System.EventHandler(this.txtSoCTG_Leave);
            // 
            // clMaSanPham
            // 
            this.clMaSanPham.DataPropertyName = "MaSanPham";
            this.clMaSanPham.HeaderText = "Mã sản phẩm";
            this.clMaSanPham.MinimumWidth = 150;
            this.clMaSanPham.Name = "clMaSanPham";
            this.clMaSanPham.ReadOnly = true;
            this.clMaSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clMaSanPham.Width = 150;
            // 
            // clTenSanPham
            // 
            this.clTenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clTenSanPham.DataPropertyName = "TenSanPham";
            this.clTenSanPham.HeaderText = "Tên sản phẩm";
            this.clTenSanPham.MinimumWidth = 200;
            this.clTenSanPham.Name = "clTenSanPham";
            this.clTenSanPham.ReadOnly = true;
            this.clTenSanPham.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clSoLuong
            // 
            this.clSoLuong.DataPropertyName = "SoLuong";
            this.clSoLuong.HeaderText = "Số lượng";
            this.clSoLuong.MinimumWidth = 100;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clDonGia
            // 
            this.clDonGia.DataPropertyName = "DonGia";
            this.clDonGia.HeaderText = "Đơn giá";
            this.clDonGia.MinimumWidth = 50;
            this.clDonGia.Name = "clDonGia";
            this.clDonGia.ReadOnly = true;
            this.clDonGia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDonGia.Width = 150;
            // 
            // clThanhTien
            // 
            this.clThanhTien.DataPropertyName = "ThanhTien";
            this.clThanhTien.HeaderText = "Thành tiền";
            this.clThanhTien.MinimumWidth = 50;
            this.clThanhTien.Name = "clThanhTien";
            this.clThanhTien.ReadOnly = true;
            this.clThanhTien.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(460, 47);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(56, 16);
            this.lblKhoHang.TabIndex = 41;
            this.lblKhoHang.Text = "Kho đến";
            // 
            // frm_PhieuDeNghiNhanDieuChuyenNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.lblKhoHang);
            this.Controls.Add(this.txtSoCTG);
            this.Controls.Add(this.lblChungTuGoc);
            this.Name = "frm_PhieuDeNghiNhanDieuChuyenNew";
            this.Text = "Phiếu đề nghị nhận điều chuyển";
            this.Controls.SetChildIndex(this.bteKhoDen, 0);
            this.Controls.SetChildIndex(this.bteKhoDi, 0);
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.lblChungTuGoc, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.txtSoCTG, 0);
            this.Controls.SetChildIndex(this.lblKhoHang, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteKhoDi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        protected override void LoadDataInstance()
        {
            base.LoadDataInstance();
            if (chungTuInfo.IdChungTu == 0)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                dtNgayLap.Enabled = false;
            }
            else
            {
                dtNgayLap.Text = Convert.ToString(chungTuInfo.NgayLap);
                dtNgayLap.Enabled = false;
            }

            bteKhoDen.Enabled = false;
            bteKhoDi.Enabled = false;
            //txtNguoiLap.Text = NguoiLap;

            if (business.ListChiTietChungTu != null)
                dgvChiTiet.DataSource =
                    new BindingList<DeNghiNhanDieuChuyenInfor>(business.ListChiTietChungTu)
                    {
                        AllowEdit = true,
                        AllowNew = true,
                        AllowRemove = true,
                        RaiseListChangedEvents = true
                    };
            if(LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN)|| LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN))
            {
                txtSoCTG.Text = ((ChungTuNhapDieuChuyenInfor)chungTuInfo).SoChungTuGoc;
                LoadSoCTG();
            }
            else
            {
                txtSoCTG.Text = ((ChungTuNhapDieuChuyenInfor)chungTuInfo).SoChungTuGoc;
                business.ListChiTietChungTu = DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNhanDieuChuyenBySoCT(SoChungTu);
                ((BindingList<DeNghiNhanDieuChuyenInfor>)dgvChiTiet.DataSource).ResetBindings();
                btnChiTietMaVach.Enabled = false;
                btnXoaSP.Enabled = false;
            }
            btnXoaSP.Enabled = false;
            btnThemSP.Enabled = false;
            btnInPhieu.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN) ||
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT) || 
                trangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN))
            {  
                //btnXoaSP.Enabled = IsSupperUser();
                btnChiTietMaVach.Enabled = IsSupperUser();
                btnThemSP.Enabled = false;
                txtNguoiLap.Enabled = false;
                btnCapNhat.Enabled = IsSupperUser();
                txtGhiChu.Enabled = IsSupperUser();
                dtNgayLap.Enabled = IsSupperUser();
                txtSoCTG.Enabled = IsSupperUser();
                clSoLuong.ReadOnly = true;
            }
            else
            {
                //btnXoaSP.Enabled = IsSupperUser();
                btnChiTietMaVach.Enabled = false;
                btnThemSP.Enabled = false; 
                btnCapNhat.Enabled = true;
                clSoLuong.ReadOnly = true;
            }
        }

        protected override void GetValuesInstance(int e)
        {
            btnChiTietMaVach.Enabled = false;
            btnXoaSP.Enabled = false;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }

        private bool Check()
        {
            int User = 0;
            if(dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Chưa có sản phẩm nào cả!");
            }
            foreach (DMKhoCBOLoadInfo nguoiDungInfor in ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung)
            {
                if (((DMKhoInfo)bteKhoDen.Tag).IdKho == nguoiDungInfor.IdKho)
                {
                    User = 1;
                }
            }
            if(User!=1)
            {
                throw new Exception("Bạn không có quyền nhận chứng từ này!");
            }

            //@HanhBD: khong cho phep tao nhieu phieu nhan cho cung 1 phieu xuat
            string sSoChungTuNhap =
                DeNghiNhanDieuChuyenDataProvider.Instance.ChungTuDaXacNhanNhapKho(txtSoCTG.Text);
            if (!String.IsNullOrEmpty(sSoChungTuNhap) && sSoChungTuNhap != txtSoPhieu.Text)
            {
                throw new Exception("Chứng từ này đã được xác nhận nhập kho bởi chứng từ số " + sSoChungTuNhap);
            }

            foreach (DeNghiNhanDieuChuyenInfor pt in business.ListChiTietChungTu)
            {
                if (pt.IdSanPham == 0)
                {
                    throw new InvalidOperationException("Trong danh sách có sản phẩm bạn chưa thêm vào!");
                }
            }
            return true;
        }

        protected override void SaveChungTuInstance()
        {
            if (Check())
            {
                if(Convert.ToDateTime(dtNgayLap.Text) < chungTuInfo.NgayLap)
                {
                    throw new InvalidOperationException("Ngày đề nghị nhập phải lớn hơn hoặc bằng ngày đề nghị xuất!");
                }
                business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue, new CultureInfo("vi-VN"));
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                if (business.ChungTu.IdChungTu == 0)
                {
                    business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                    business.ChungTu.SoChungTuGoc = txtSoCTG.Text.Trim();
                    business.ChungTu.IdNhanVien = Declare.IdNhanVien;
                    business.ChungTu.IdKho = ((DMKhoInfo)bteKhoDen.Tag).IdKho;
                    business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_NHAN_DIEU_CHUYEN);

                    if (DeNghiNhanDieuChuyenDataProvider.Instance.ChungTuDaXuatHang(business.ChungTu.SoChungTuGoc))
                    {
                        business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN);                        
                    } 
                    else
                    {
                        business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT);                        
                    }
                }
            }
        }

        protected override void AfterSaveChungTuInstance()
        {
            base.AfterSaveChungTuInstance();
        }

        protected override void OnDeleteChungTu()
        {
            if (!IsSupperUser())
            {
                throw new Exception("Bạn không có quyền xóa");
            }
        }

        private void dgvChiTiet_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            btnChiTietMaVach.Enabled = false;
        }

        private void dgvChiTiet_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
        private void LoadSoCTG()
        {
            business.ListChiTietChungTu.Clear();
            if(!string.IsNullOrEmpty(txtSoCTG.Text))
            {
                ChungTuXuatDieuChuyenInfor chungTuXuatDieuChuyenInfor = DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
                List<DeNghiNhanDieuChuyenInfor> frm =
                    DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNhanDieuChuyenBySoCT(txtSoCTG.Text);
                //Lay ve chung tu xuat dieu chuyen info theo so chung tu nhap vao
                //kiem tra chung tu info theo cac dk sau:
                //- Loaichungtu la loai xuatdieuchuyen
                //- Trangthai la da xuat
                //- Khodieuchuyen == nằm trong kho của người dùng
                //Cac truong hop khac throw exception
                //Chi nhap mot lan luc them moi, sau do disable
                if ((chungTuXuatDieuChuyenInfor.LoaiChungTu == Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)
                    || chungTuXuatDieuChuyenInfor.LoaiChungTu == Convert.ToInt32(TransactionType.DE_NGHI_XUAT_DIEU_CHUYEN))
                    && (chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDuyet.CHUA_XUAT)
                    || chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT)
                    ||chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_NHAN)
                    || chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.CHO_THUKHO_XUAT)
                    ||chungTuXuatDieuChuyenInfor.TrangThai == Convert.ToInt32(TrangThaiDieuChuyen.DA_NHAN)))
                    //&& (chungTuXuatDieuChuyenInfor.IdKhoDieuChuyen == Declare.IdKho || IsSupperUser()))
                {
                    for (int i = 0; i < frm.Count; i++)
                    {
                        business.ListChiTietChungTu.Add(new DeNghiNhanDieuChuyenInfor
                        {
                            IdSanPham = frm[i].IdSanPham,
                            MaSanPham = frm[i].MaSanPham,
                            TenSanPham = frm[i].TenSanPham,
                            SoLuong = frm[i].SoLuong,
                            DonGia = frm[i].DonGia,
                            Thanhtien = frm[i].Thanhtien
                        });
                    }
                    ((BindingList<DeNghiNhanDieuChuyenInfor>)dgvChiTiet.DataSource).ResetBindings();
                    btnChiTietMaVach.Enabled = false;
                    btnXoaSP.Enabled = false;
                }
                else
                {
                    throw new InvalidExpressionException("Số chứng từ nhập không thỏa mãn!");
                }
            }
            txtSoCTG.Enabled = true;
        }
        private void txtSoCTG_Leave(object sender, EventArgs e)
        {
            LoadSoCTG();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = DeNghiNhanDieuChuyenDataProvider.Instance.GetPhieuDeNghiNhanDieuChuyenDetail(OID);
            ChungTuXuatDieuChuyenInfor chungTuXuatDieuChuyenInfor =
           DeNghiNhanDieuChuyenDataProvider.Instance.GetListDNNDCBySoCT(txtSoCTG.Text);
            rpt_BC_PhieuDeNghiNhanDieuChuyen rpt = new rpt_BC_PhieuDeNghiNhanDieuChuyen(chungTuXuatDieuChuyenInfor.IdKho);
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }
    }
}
