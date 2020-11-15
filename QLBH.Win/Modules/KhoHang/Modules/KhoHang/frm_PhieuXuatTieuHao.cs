using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;

// form frm_PhieuXuatTieuHao
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 16/06/2012
// Người sửa cuối:
// Ngày sửa cuối: 
//todo: @HanhBD form_PhieuXuatTieuHao
namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuXuatTieuHao : frmChiTiet_ChungTuNhapBase
    {
        public List<ChungTu_ChiTietHangHoaBaseInfo> liChungTuChiTietHangHoa = new List<ChungTu_ChiTietHangHoaBaseInfo>();
        public int idSanPham = 0;
        private int idChungTuGoc;
        private int trangThai;
        private frm_DanhSachPhieuXuatTieuHao frm;
        private XuatKhoTieuHaoBusiness business;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
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
        private List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuXuatTieuHao));
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Enabled = false;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Text = "Kết thúc";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
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
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // dtNgayLap
            // 
            //this.dtNgayLap.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            //this.dtNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaSanPham";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã sản phẩm";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 150;
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
            this.clSoLuong.MinimumWidth = 100;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
            this.clSoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            // frm_PhieuXuatTieuHao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Name = "frm_PhieuXuatTieuHao";
            this.Text = "Phiếu xuất tiêu hao";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 

        public frm_PhieuXuatTieuHao(int oid, string sochungtu, string ngaylap, string sopo)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuXuatTieuHao)
        {
            InitializeComponent();
            ChungTuXuatTieuHaoInfor chungTuXuatTieuHaoInfor =
                XuatTieuHaoProvider.Instance.GetChungTuBySoChungTu<ChungTuXuatTieuHaoInfor>(sochungtu);
            if (chungTuXuatTieuHaoInfor != null)
            {
                chungTuXuatTieuHaoInfor.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO);
                business = new XuatKhoTieuHaoBusiness(chungTuXuatTieuHaoInfor);
            }
            else
            {
                throw new ManagedException(String.Format("Chứng từ số {0} không tồn tại.", sochungtu));
            }
        } 

        public frm_PhieuXuatTieuHao(int oid, string sochungtu, string ngaylap, string sopo, int idChungTuGoc, int trangThai,string nguoiLap)
            : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuXuatTieuHao)
        {
            InitializeComponent();
            this.idChungTuGoc = idChungTuGoc;
            this.trangThai = trangThai;
            this.NguoiLap = nguoiLap;
            ChungTuXuatTieuHaoInfor chungTuXuatTieuHaoInfor =
                XuatTieuHaoProvider.Instance.GetChungTuBySoChungTu<ChungTuXuatTieuHaoInfor>(sochungtu);
            if (chungTuXuatTieuHaoInfor != null)
            {
                chungTuXuatTieuHaoInfor.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO);
                business = new XuatKhoTieuHaoBusiness(chungTuXuatTieuHaoInfor);
            }
        } 

        public frm_PhieuXuatTieuHao() : base(Declare.Prefix.PhieuXuatTieuHao)
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount < 1)
            {
                throw new InvalidExpressionException("Bạn chưa thêm sản phẩm!");
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
                {
                    throw new InvalidExpressionException("Bạn chưa nhập số lượng!");
                }
            }
            return true;
        }

        protected override void SaveChungTuInstance()
        {
            Check();
            business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
            business.ChungTu.IdNhanVien = Declare.IdNhanVien;
            business.ChungTu.IdKho = Declare.IdKho;
            business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
            business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue);
            business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_HUY_TIEU_HAO);
            int SumChiTietMaVach =0;
            int SumChiTietChungTu= 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu == SumChiTietMaVach)
            {
                business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDuyet.DA_XUAT);
            }
        }

        protected override void LoadDataInstance()
        {
            //liChiTietChungTu.Clear();
            //load theo id của sản phẩm
            business.ListChiTietChungTu = XuatTieuHaoProvider.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
            dgvChiTiet.DataSource = business.ListChiTietChungTu;
            //dtNgayLap.Text = NgayLap;
            //txtNguoiLap.Text = Declare.UserName;
            //txtNguoiLap.Text = NguoiLap;
            DateTime Ngaylap = business.ChungTu.NgayLap;
            if (Ngaylap < dtNgayLap.Properties.MinValue)
            {
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                txtNguoiLap.Text = Declare.UserName;
            }
            else
            {
                dtNgayLap.Text = Ngaylap.ToString();
                txtNguoiLap.Text = NguoiLap;
            }
            btnXoaSP.Enabled = false;
            //btnInPhieu.Enabled = false;
            btnThemSP.Enabled = false;
            if(trangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT))
            {
                btnXoaSP.Enabled = false;
                //btnInPhieu.Enabled = false;
                btnThemSP.Enabled = false;
                btnCapNhat.Enabled = false;
                btnThemSP.Enabled = false;
                txtNguoiLap.Enabled = false;
                txtGhiChu.Enabled = false;
                dtNgayLap.Enabled = false;
                clSoLuong.ReadOnly = true;
            }
            else
            {
                //clSoLuong.ReadOnly = false;
            }
        } 

        protected override void GetValuesInstance(int e)
        {
            if(e < 0)
            {
                HangHoa = null;
                return;
            }
            HangHoa.IdSanPham = business.ListChiTietChungTu[e].IdSanPham;
            HangHoa.TenSanPham = business.ListChiTietChungTu[e].TenSanPham;
            HangHoa.SoLuong = business.ListChiTietChungTu[e].SoLuong;
            HangHoa.TrungMaVach = business.ListChiTietChungTu[e].TrungMaVach;
            HangHoa.DonGia = business.ListChiTietChungTu[e].DonGia;
            HangHoa.DonViTinh = business.ListChiTietChungTu[e].TenDonViTinh;
            InDex = e;
            DonViTinh = business.ListChiTietChungTu[e].TenDonViTinh;
            liChiTiet = business.GetListChiTietHangHoaByIdSanPham(business.ListChiTietChungTu[e].IdSanPham);
            btnThemSP.Enabled = HangHoa.IdSanPham<0;
            btnXoaSP.Enabled = HangHoa.IdSanPham < 0;
            btnChiTietMaVach.Enabled = HangHoa.IdSanPham > 0;
            btnCapNhat.Enabled = HangHoa.IdSanPham > 0;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }
        
        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && dgvChiTiet.CurrentRow != null )
            {
                frm_ChiTietMaVach frm = new frm_ChiTietMaVach(this, HangHoa, liChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                    //business.ListChiTietChungTu[InDex].TrangThai = Convert.ToString(TrangThaiDuyet.DA_XUAT);
                }
            }
        }

        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            myParams.Clear();
            SetParameterReport(myParams, "pTrungTam", Declare.TenTrungTam);
            SetParameterReport(myParams, "pKho", Declare.TenKho);
            SetParameterReport(myParams, "pSoSeri", txtSoPhieu.Text);
            SetParameterReport(myParams, "pNhanVien", Declare.TenNhanVien);
            SetParameterReport(myParams, "pSoPhieu", txtSoPhieu.Text);
        }

        protected override void OnLoadReport()
        {
            //ReportTitle = "Phiếu xuất tiêu hao";
            //rpt = new rpt_BC_XuatHuyTieuHao();
            //base.SetParameterFields();
            //base.SetDataSource();
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

        private void btnChiTietMaVach_Click(object sender, EventArgs e)
        {
            if (HangHoa != null)
            {
                frm_ChiTietMaVach frm = new frm_ChiTietMaVach(this, HangHoa, liChiTiet);
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                business.MergeChiTietHangHoa(frm.liChiTiet);
                //}
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietXTHInfor> list = XuatTieuHaoProvider.Instance.GetDeNghiTieuHaoDetail(OID);
            rpt_BC_PhieuXuatTieuHao rpt = new rpt_BC_PhieuXuatTieuHao();
            List<BaoCao_ChiTietXTHInfor> lst = new List<BaoCao_ChiTietXTHInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

    }
}
