using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_PhieuDieuChuyen : frmChiTiet_ChungTuNhapBase
    {
        private int idChungTuGoc;
        private int trangThai;
        private int idKhoDieuChuyen;
        private frm_DanhSachDieuChuyen frm;
        private XuatDieuChuyenBusiness business;
        private ComboBox cboKho;
        private Label lblKhoHang;
        private List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        private DataGridViewTextBoxColumn clMaSanPham;
        private DataGridViewTextBoxColumn clTenSanPham;
        private DataGridViewTextBoxColumn clSoLuong;
        private DataGridViewTextBoxColumn clDonGia;
        private DataGridViewTextBoxColumn clThanhTien;
        List<DMKhoInfo> litype = new List<DMKhoInfo>();
        public frm_PhieuDieuChuyen(frm_DanhSachDieuChuyen frm)
            : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            this.frm = frm;
            dgvChiTiet.AutoGenerateColumns = false;
        } 

        //public frm_PhieuDieuChuyen(int oid, string sochungtu, string ngaylap, string sopo)
        //    : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuXuatDieuChuyen)
        //{
        //    InitializeComponent();
        //    business = new XuatDieuChuyenBusiness(new ChungTuDieuChuyenInfor
        //    {
        //        IdChungTu = oid,
        //        SoChungTu = sochungtu,
        //        NgayLap = Convert.ToDateTime(ngaylap)
        //        });
        //} 

        //public frm_PhieuDieuChuyen(int oid, string sochungtu, string ngaylap, string sopo, int idChungTuGoc,int trangThai, int idKhoDieuChuyen)
        //    : base(oid, sochungtu, ngaylap, sopo, Declare.Prefix.PhieuXuatDieuChuyen)
        //{
        //    InitializeComponent();
        //    dgvChiTiet.AutoGenerateColumns = false;
        //    this.idChungTuGoc = idChungTuGoc;
        //    this.trangThai = trangThai;
        //    this.idKhoDieuChuyen = idKhoDieuChuyen;
        //    LoadKho();
        //    business = new XuatDieuChuyenBusiness(new ChungTuDieuChuyenInfor
        //    {
        //        IdChungTu = oid,
        //        SoChungTu = sochungtu,
        //        NgayLap = Convert.ToDateTime(ngaylap), 
        //        //IdKho = idKho,
        //        LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN)});
        //}

        public frm_PhieuDieuChuyen()
            : base(Declare.Prefix.PhieuXuatDieuChuyen)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            dgvChiTiet.AutoGenerateColumns = false;
        } 
        private void LoadKho()
        {
            litype = DMKhoDataProvider.GetListDMKhoInfor();
            if (litype.Count > 0)
            {
                cboKho.DataSource = litype;
                cboKho.DisplayMember = "TenKho";
                cboKho.ValueMember = "IdKho";
                cboKho.SelectedValue = idKhoDieuChuyen;
            }
            else
            {
                cboKho.DataSource = null;
            }
        }
        
        protected override void LoadDataInstance()
        {
            business.ListChiTietChungTu = XuatDieuChuyenDataProvider.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
            dgvChiTiet.DataSource = business.ListChiTietChungTu;
            dtNgayLap.Text = NgayLap;
            cboKho.Enabled = false;
            btnXoaSP.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            btnThemSP.Enabled = false;
            btnCapNhat.Enabled = false;
            btnChiTietMaVach.Enabled = false;
            if(trangThai == Convert.ToInt32(TrangThaiDuyet.DA_XUAT))
            {
                btnXoaSP.Enabled = false;
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
                clSoLuong.ReadOnly = false;
            }
        }

        private bool Check()
        {
            if (dgvChiTiet.RowCount < 1)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            for (int i = 0; i < dgvChiTiet.RowCount; i++)
            {
                if (Convert.ToInt32(dgvChiTiet.Rows[i].Cells[2].Value) <= 0 && dgvChiTiet.Rows[i].Cells[2].Value != null)
                {
                    throw new ManagedException("Bạn chưa nhập số lượng!");
                }
            }
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
            foreach (ChungTu_ChiTietHangHoaBaseInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfo chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu > SumChiTietMaVach)
            {
                throw new InvalidExpressionException("Bạn chưa nhập đủ số mã vạch!");
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
            business.ChungTu.NgayLap = Convert.ToDateTime(dtNgayLap.Text);
            business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DIEU_CHUYEN);
            int SumChiTietMaVach = 0;
            int SumChiTietChungTu = 0;
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
                business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDieuChuyen.DA_XUAT);
            }
        }

        protected override void GetValuesInstance(int e)
        {
            if (e < 0)
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
            btnThemSP.Enabled = HangHoa.IdSanPham < 0;
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
            if (HangHoa != null && dgvChiTiet.CurrentRow != null)
            {
                frm_ChiTietPhieuDieuChuyen frm = new frm_ChiTietPhieuDieuChuyen(this, HangHoa, liChiTiet);
                if (frm.ShowDialog()== DialogResult.OK)
                {
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PhieuDieuChuyen));
            this.cboKho = new System.Windows.Forms.ComboBox();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.clMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThemSP
            // 
            this.btnThemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSP.Image")));
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaSanPham,
            this.clTenSanPham,
            this.clSoLuong,
            this.clDonGia,
            this.clThanhTien});
            this.dgvChiTiet.RowHeadersWidth = 25;
            this.dgvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvChiTiet_KeyDown);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Size = new System.Drawing.Size(337, 21);
            // 
            // btnChiTietMaVach
            // 
            this.btnChiTietMaVach.Click += new System.EventHandler(this.btnChiTietMaVach_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Text = "Import Mã";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            // 
            // cboKho
            // 
            this.cboKho.Enabled = false;
            this.cboKho.FormattingEnabled = true;
            this.cboKho.Location = new System.Drawing.Point(529, 47);
            this.cboKho.Name = "cboKho";
            this.cboKho.Size = new System.Drawing.Size(412, 21);
            this.cboKho.TabIndex = 16;
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.Location = new System.Drawing.Point(460, 51);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(63, 16);
            this.lblKhoHang.TabIndex = 17;
            this.lblKhoHang.Text = "Kho hàng";
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
            this.clSoLuong.MinimumWidth = 50;
            this.clSoLuong.Name = "clSoLuong";
            this.clSoLuong.ReadOnly = true;
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
            // frm_PhieuDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.cboKho);
            this.Controls.Add(this.lblKhoHang);
            this.Name = "frm_PhieuDieuChuyen";
            this.Text = "Phiếu xuất điều chuyển";
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.lblKhoHang, 0);
            this.Controls.SetChildIndex(this.cboKho, 0);
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
       
        private void btnChiTietMaVach_Click(object sender, EventArgs e)
        {
            if (HangHoa != null)
            {
                    frm_ChiTietPhieuDieuChuyen frm = new frm_ChiTietPhieuDieuChuyen(this, HangHoa, liChiTiet);
                    //if (frm.ShowDialog() == DialogResult.OK)
                    //{
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                    //}
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = XuatDieuChuyenDataProvider.Instance.GetPhieuXuatDieuChuyenDetail(OID);
            rpt_BC_PhieuXuatDieuChuyen rpt = new rpt_BC_PhieuXuatDieuChuyen(idKhoDieuChuyen);
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    DataSet ds;
                    string sql = String.Empty;

                    using (OleDbConnection oConn = new OleDbConnection())
                    {
                        ds = new DataSet();
                        oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", opf.FileName);
                        oConn.Open();

                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, [SO_LUONG] as SoLuong from [Items$]";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "HangHoaChiTiet");
                        }
                    }

                    business.ListChiTietHangHoa.Clear();

                    foreach (ChungTu_ChiTietInfo chungTuChiTietInfor in business.ListChiTietChungTu)
                    {
                        ds.Tables[0].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        DataTable tableTemp = ds.Tables[0].DefaultView.ToTable("Temp");
                        foreach (DataRow dataRow in tableTemp.Rows)
                        {
                            if (dataRow["MaVach"] == DBNull.Value || String.IsNullOrEmpty(Convert.ToString(dataRow["MaVach"])))
                            {
                                throw new ManagedException("Đang có dòng không được nhập mã vạch.");
                            }

                            ChungTu_ChiTietHangHoaBaseInfo chiTietMaVach = business.ListChiTietHangHoa.Find(
                                delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                                {
                                    return
                                        match.MaVach == Convert.ToString(dataRow["MaVach"]);
                                });
                            if (chiTietMaVach == null)
                            {
                                business.ListChiTietHangHoa.Add(
                                    new ChungTu_ChiTietHangHoaBaseInfo
                                        {
                                            IdSanPham = chungTuChiTietInfor.IdSanPham,
                                            IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                                            MaVach = Convert.ToString(dataRow["MaVach"]),
                                            SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                                            TrungMaVach = chungTuChiTietInfor.TrungMaVach
                                        });
                            } 
                            else
                            {
                                chiTietMaVach.SoLuong += Convert.ToInt32(dataRow["SoLuong"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                throw;
            }
        }
    }
}
