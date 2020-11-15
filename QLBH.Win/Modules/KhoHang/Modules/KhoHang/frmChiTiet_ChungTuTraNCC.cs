using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

// form frmChiTiet_ChungTuTraNCC
// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang
{
    public class frmChiTiet_ChungTuTraNCC : frmChiTiet_ChungTuNhapBase
    {
        private KhoXuatNccBusiness business;
        private KhoXuatNccBusiness clonedBusiness;
        List<ChungTuXuatNhapNccChiTietInfo> listCTChungTu;
        ArrayList arTran = new ArrayList();
        private List<ChungTuXuatNccChiTietHangHoaInfo> liChiTiet;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn clNganh;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private TextBox txtNCC;
        private Label label5;
        private DateTime ngaylap;
        private TextBox txtSoPO;
        private DevExpress.XtraEditors.DateEdit dteNgayNhap;
        private TextBox txtSoRE;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtKhoXuat;
        private Label label9;
        private DevExpress.XtraEditors.SimpleButton btnInTH;
        private frm_ListChungTuTraNCC frm;

        public frmChiTiet_ChungTuTraNCC(frm_ListChungTuTraNCC frm,ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo,DateTime ngaylap)
            : base(chungTuXuatNhapNccInfo.IdChungTu, chungTuXuatNhapNccInfo.SoChungTu, chungTuXuatNhapNccInfo.NgayLap.ToString(), chungTuXuatNhapNccInfo.SoPO, Declare.Prefix.PhieuTraHangMua)
        {
            InitializeComponent();
            business = new KhoXuatNccBusiness(chungTuXuatNhapNccInfo);
            this.ngaylap = ngaylap;
            this.frm = frm;
        }

        public frmChiTiet_ChungTuTraNCC(int OID, string sophieu, string ngaylap, string sopo)
            : base(OID, sophieu, ngaylap, sopo, Declare.Prefix.PhieuTraHangMua)
        {
            InitializeComponent();
            business = new KhoXuatNccBusiness(new ChungTuXuatNhapNccInfo { IdChungTu = OID, SoChungTu = sophieu, NgayLap = Convert.ToDateTime(ngaylap), SoPO = sopo });
            this.ngaylap = Convert.ToDateTime(ngaylap);
        }

        protected override void LoadDataInstance()
        {
            btnXacNhan.Visible = true;
            if (OID == 0)
            {
                listCTChungTu = KeToanNhapNccDataProvider.Instance.GetListNhapHangUserInfoFromOid(SoPO, business.ChungTu.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP), ngaylap, OID);
                //business.ListChiTietChungTu = KeToanNhapNccDataProvider.Instance.GetListNhapHangUserInfoFromOid(SoPO, business.ChungTu.SoPhieuNhap, Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP), business.ChungTu.NgayLap);
            }
            else
            {
                business.ListChiTietChungTu = KhoXuatNccDataProvider.Instance.GetListChiTietChungTuByIdChungTu(OID);
                
                listCTChungTu = KeToanNhapNccDataProvider.Instance
                    .GetListNhapHangUserInfoFromOid(SoPO, business.ChungTu.SoPhieuNhap, 
                    Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP), ngaylap, business.ChungTu.IdChungTu);

                for (int i = 0; i < business.ListChiTietChungTu.Count; i++)
                {
                    arTran.Add(business.ListChiTietChungTu[i].TransactionID);
                }
            }

            for (int i = 0; i < listCTChungTu.Count; i++)
            {
                if (listCTChungTu.Count > 0 && OID > 0)
                {
                    foreach (ChungTuXuatNccChiTietHangHoaInfo pt in business.ListChiTietHangHoa)
                    {
                        if (pt.IdSanPham == listCTChungTu[i].IdSanPham && pt.TransactionID == listCTChungTu[i].TransactionID)
                        {
                            listCTChungTu[i].TrangThai = "Đã nhập đủ";
                        }
                    }
                    if (String.IsNullOrEmpty(listCTChungTu[i].TrangThai))
                    {
                        listCTChungTu[i].TrangThai = "Chưa nhập";
                    }
                }
                else
                {
                    listCTChungTu[i].TrangThai = "Chưa nhập";
                }
            }

            txtSoPhieu.Text = business.ChungTu.SoChungTu;
            txtNguoiLap.Text = business.ChungTu.NguoiNhap;
            txtNCC.Text = business.ChungTu.NCC;
            txtSoPO.Text = business.ChungTu.SoPO;
            txtSoRE.Text = business.ChungTu.SoPhieuNhap;
            if (business.ChungTu.IdChungTu != 0)
            {
                dtNgayLap.Text = business.ChungTu.NgayLap.ToString();
                dteNgayNhap.Text = business.ChungTu.NgayHenGiaoHang.ToString();
            }
            else
            {
                dtNgayLap.Text = CommonProvider.Instance.GetSysDate().ToString();
                dteNgayNhap.Text = "";
            }
            if (business.ChungTu.IdKho != 0)
            {
                DMKhoInfo dmKho = DMKhoDataProvider.GetKhoByIdInfo(business.ChungTu.IdKho);
                txtKhoXuat.Text = dmKho.TenKho;
                txtKhoXuat.Enabled = false;
                btnCapNhat.Enabled = false;
            } 

            btnXoaSP.Visible = false;
            btnChiTietMaVach.Visible = false;
            btnThemSP.Visible = false;
            txtNguoiLap.Enabled = false;
            dtNgayLap.Enabled = false;
            dgvChiTiet.DataSource = listCTChungTu;
        }

        protected override ChungTuBusinessBase GetBussiness()
        {
            return business;
        }
        protected override void AfterSaveChungTuInstance()
        {
            int count = 0;
            for (int i = 0; i < liChiTietChungTu.Count; i++)
            {
                if (liChiTietChungTu[i].TrangThai == "Đã nhập đủ")
                {
                    count++;
                }
            }
            if (liChiTietChungTu.Count == count)
            {
                KhoNhapNccDataProvider.Instance.UpdateTrangThaiChungTu(new ChungTuXuatNhapNccInfo { IdChungTu = clonedBusiness.ChungTu.IdChungTu, TrangThai = 2 });
            }
        }
        protected override void Reload()
        {
            frm.Reload();
        }

        protected override void SaveChungTu()
        {
            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());
            if (li.Count > 0 && OID == 0)
            {
                txtSoPhieu.Focus();
                throw new ManagedException("Số phiếu đã tồn tại trong hệ thống. Xin hãy kiểm tra lại!");
            }
            if (this.Business == null) this.Business = GetBussiness();

            SaveChungTuInstance();

            frmProgress.Instance.Caption = Text;
            frmProgress.Instance.Description = "Đang thực hiện ...";
            frmProgress.Instance.MaxValue = 100;
            frmProgress.Instance.Value = 0;

            frmProgress.Instance.DoWork(
                delegate
                {
                    try
                    {
                        ConnectionUtil.Instance.BeginTransaction();

                        frmProgress.Instance.MaxValue = 15;
                        clonedBusiness = (KhoXuatNccBusiness)Business.Clone();
                        frmProgress.Instance.Value += 1;
                        clonedBusiness.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();
                        frmProgress.Instance.Value += 1;
                        clonedBusiness.ChungTu.NgayXuatHang = CommonProvider.Instance.GetSysDate();
                        frmProgress.Instance.Value += 1;
                        clonedBusiness.SaveChungTu();
                        frmProgress.Instance.Value += 1;
                        AfterSaveChungTuInstance();
                        frmProgress.Instance.Value += 1;

                        ConnectionUtil.Instance.CommitTransaction();

                        frmProgress.Instance.Description = "Đã xong!";

                        frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                        frmProgress.Instance.IsCompleted = true;

                    }
                    catch (Exception ex)
                    {
                        ConnectionUtil.Instance.RollbackTransaction();

                        MessageBox.Show(ex.Message);

                        frmProgress.Instance.Description = "Giao dịch không thành công!";

                        frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                        frmProgress.Instance.IsCompleted = true;

                        if (!(ex is ManagedException))
                        {
                            EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Chứng từ trả NCC");
                        }
                    }
                });

            //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
            //    delegate
            //    {
            //        frmProgress.Instance.MaxValue = 15;
            //        clonedBusiness = (KhoXuatNccBusiness)Business.Clone();
            //        frmProgress.Instance.Value += 1;
            //        clonedBusiness.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();
            //        frmProgress.Instance.Value += 1;
            //        clonedBusiness.ChungTu.NgayXuatHang = CommonProvider.Instance.GetSysDate();
            //        frmProgress.Instance.Value += 1;
            //        clonedBusiness.SaveChungTu();
            //        frmProgress.Instance.Value += 1;
            //        AfterSaveChungTuInstance();
            //        frmProgress.Instance.Value += 1;
            //    });

            Reload();

        }

        protected override void SaveChungTuInstance()
        {
            if (business.ChungTu.IdChungTu == 0)
            {
                business.ChungTu.IdKho = Declare.IdKho;
                business.ChungTu.IdNhanVien = Declare.IdNhanVien;
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.TRA_LAI_PO);
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                business.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();
                business.ChungTu.NgayXuatHang = CommonProvider.Instance.GetSysDate();
                business.ChungTu.NgayHenGiaoHang = ngaylap;
            }
            for (int i = 0; i < listCTChungTu.Count; i++)
            {
                if (listCTChungTu[i].TrangThai == "Chưa nhập")
                {
                    throw new ManagedException("Bạn chưa nhập đủ số lượng trong phiếu nhập !");
                }
            }
        }
        protected override void DoubleClickInstance()
        {
            if (HangHoa != null && HangHoa.IdSanPham != 0)
            {
                frmChungTuXuat_ChiTietHangHoa frm = new frmChungTuXuat_ChiTietHangHoa(this, HangHoa, liChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ChungTuXuatNhapNccChiTietInfo ct = listCTChungTu[InDex];
                    if (!arTran.Contains(ct.TransactionID))
                    {
                        business.ListChiTietChungTu.Add(ct);
                        arTran.Add(ct.TransactionID);
                        business.MergeChiTietHangHoa(frm.liChiTiet,
                                                    delegate(ChungTuXuatNccChiTietHangHoaInfo match)
                                                    {
                                                        return business.Conjunction(
                                                            business.ListChiTietChungTu[business.ListChiTietChungTu.IndexOf(ct)],
                                                            match);
                                                    });
                        business.ListChiTietChungTu[business.ListChiTietChungTu.IndexOf(ct)].TrangThai = "Đã nhập đủ";
                    }
                    else
                    {
                        ChungTuXuatNhapNccChiTietInfo chiTietMaVach = business.ListChiTietChungTu.Find(
                                delegate(ChungTuXuatNhapNccChiTietInfo match)
                                {
                                    return match.TransactionID == ct.TransactionID;
                                });
                        business.MergeChiTietHangHoa(frm.liChiTiet,
                                                    delegate(ChungTuXuatNccChiTietHangHoaInfo match)
                                                    {
                                                        return business.Conjunction(
                                                            business.ListChiTietChungTu[business.ListChiTietChungTu.IndexOf(chiTietMaVach)],
                                                            match);
                                                    });
                        business.ListChiTietChungTu[business.ListChiTietChungTu.IndexOf(chiTietMaVach)].TrangThai = "Đã nhập đủ";
                    }
                    listCTChungTu[listCTChungTu.IndexOf(ct)].TrangThai = "Đã nhập đủ";
                    dgvChiTiet.DataSource = null;
                    dgvChiTiet.DataSource = listCTChungTu;
                }
            }
        }
        protected override void GetValuesInstance(int e)
        {
            HangHoa.IdSanPham = listCTChungTu[e].IdSanPham;
            HangHoa.TenSanPham = listCTChungTu[e].TenSanPham;
            HangHoa.SoLuong = listCTChungTu[e].SoLuong;
            HangHoa.TrungMaVach = 1;
            HangHoa.DonGia = listCTChungTu[e].DonGia;
            HangHoa.DonViTinh = listCTChungTu[e].TenDonViTinh;
            HangHoa.TransactionID = listCTChungTu[e].TransactionID;
            IdSanPham = listCTChungTu[e].IdSanPham;
            DonViTinh = listCTChungTu[e].TenDonViTinh;
            InDex = e;
            //liChiTiet = business.GetListChiTietHangHoaByIdSanPham(business.ListChiTietChungTu[e].IdSanPham);
            liChiTiet = business.GetListChiTietHangHoaByConjunction(
                delegate(ChungTuXuatNccChiTietHangHoaInfo match)
                    {
                        return
                            business.Conjunction(
                                listCTChungTu[e], match);
                    });
        }
        private void InitializeComponent()
        {
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNganh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNCC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoPO = new System.Windows.Forms.TextBox();
            this.dteNgayNhap = new DevExpress.XtraEditors.DateEdit();
            this.txtSoRE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKhoXuat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInTH = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayNhap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayNhap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.clNganh,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 107);
            this.dgvChiTiet.Size = new System.Drawing.Size(929, 373);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Size = new System.Drawing.Size(556, 21);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Text = "Import mã";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtSoPhieu
            // 
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtSoPhieu.Properties.AppearanceReadOnly.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtSoPhieu.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            this.txtSoPhieu.Size = new System.Drawing.Size(303, 20);
            // 
            // dtNgayLap
            // 
            this.dtNgayLap.EditValue = new System.DateTime(2013, 6, 9, 14, 48, 53, 281);
            this.dtNgayLap.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgayLap.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss tt";
            this.dtNgayLap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtNgayLap.Size = new System.Drawing.Size(148, 20);
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // clNganh
            // 
            this.clNganh.DataPropertyName = "TenNganhHang";
            this.clNganh.HeaderText = "Ngành hàng";
            this.clNganh.MinimumWidth = 200;
            this.clNganh.Name = "clNganh";
            this.clNganh.ReadOnly = true;
            this.clNganh.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TrangThai";
            this.dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // txtNCC
            // 
            this.txtNCC.Enabled = false;
            this.txtNCC.Location = new System.Drawing.Point(117, 73);
            this.txtNCC.Name = "txtNCC";
            this.txtNCC.Size = new System.Drawing.Size(303, 21);
            this.txtNCC.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nhà cung cấp";
            // 
            // txtSoPO
            // 
            this.txtSoPO.Enabled = false;
            this.txtSoPO.Location = new System.Drawing.Point(768, 47);
            this.txtSoPO.Name = "txtSoPO";
            this.txtSoPO.Size = new System.Drawing.Size(58, 21);
            this.txtSoPO.TabIndex = 21;
            // 
            // dteNgayNhap
            // 
            this.dteNgayNhap.EditValue = null;
            this.dteNgayNhap.Location = new System.Drawing.Point(525, 74);
            this.dteNgayNhap.Name = "dteNgayNhap";
            this.dteNgayNhap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNgayNhap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteNgayNhap.Size = new System.Drawing.Size(148, 20);
            this.dteNgayNhap.TabIndex = 22;
            // 
            // txtSoRE
            // 
            this.txtSoRE.Enabled = false;
            this.txtSoRE.Location = new System.Drawing.Point(878, 47);
            this.txtSoRE.Name = "txtSoRE";
            this.txtSoRE.Size = new System.Drawing.Size(63, 21);
            this.txtSoRE.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(715, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Số PO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(826, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Số RE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(426, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Ngày nhập PO";
            // 
            // txtKhoXuat
            // 
            this.txtKhoXuat.Enabled = false;
            this.txtKhoXuat.Location = new System.Drawing.Point(768, 73);
            this.txtKhoXuat.Name = "txtKhoXuat";
            this.txtKhoXuat.Size = new System.Drawing.Size(173, 21);
            this.txtKhoXuat.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(696, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Kho Xuất";
            // 
            // btnInTH
            // 
            this.btnInTH.Location = new System.Drawing.Point(439, 488);
            this.btnInTH.Name = "btnInTH";
            this.btnInTH.Size = new System.Drawing.Size(95, 23);
            this.btnInTH.TabIndex = 29;
            this.btnInTH.Text = "In phiếu tổng hợp";
            this.btnInTH.Click += new System.EventHandler(this.btnInTH_Click);
            // 
            // frmChiTiet_ChungTuTraNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(953, 524);
            this.Controls.Add(this.btnInTH);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtKhoXuat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSoRE);
            this.Controls.Add(this.txtNCC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dteNgayNhap);
            this.Controls.Add(this.txtSoPO);
            this.Name = "frmChiTiet_ChungTuTraNCC";
            this.Controls.SetChildIndex(this.txtSoPO, 0);
            this.Controls.SetChildIndex(this.dteNgayNhap, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtNCC, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dgvChiTiet, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.txtNguoiLap, 0);
            this.Controls.SetChildIndex(this.btnThemSP, 0);
            this.Controls.SetChildIndex(this.btnXoaSP, 0);
            this.Controls.SetChildIndex(this.btnChiTietMaVach, 0);
            this.Controls.SetChildIndex(this.btnCapNhat, 0);
            this.Controls.SetChildIndex(this.btnDong, 0);
            this.Controls.SetChildIndex(this.btnInPhieu, 0);
            this.Controls.SetChildIndex(this.btnXacNhan, 0);
            this.Controls.SetChildIndex(this.txtSoPhieu, 0);
            this.Controls.SetChildIndex(this.dtNgayLap, 0);
            this.Controls.SetChildIndex(this.txtSoRE, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtKhoXuat, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.btnInTH, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayLap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayNhap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNgayNhap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = tblChungTuDataProvider.GetPhieuTraNCC(OID);
            rpt_BC_PhieuTraHangNCC rpt = new rpt_BC_PhieuTraHangNCC();
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                if (business.ListChiTietHangHoa.Count == 0)
                {
                    tmp_NhapHang_LogDataProvider.Delete(business.ChungTu.SoPO, business.ChungTu.SoPhieuNhap,
                                                        Convert.ToInt32(LoaiGiaoDichPO.TRA_HANG_NHA_CUNG_CAP),
                                                        Declare.IdKho);
                }
                base.OnClosing(e);
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

        private void CheckTrungMaVach(ChungTuXuatNhapNccChiTietInfo chungTuChiTietInfor, DataSet ds)
        {
            int TrungMaVach = 0;
            int SoLuongMaVach = 0;
            ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
            DataTable tableTemp = ds.Tables["HangHoaChiTiet"].DefaultView.ToTable("Temp");
            ds.Tables["CheckTrungMaVach"].DefaultView.RowFilter = String.Format("MaSanPham='{0}' and SoLuong > 1", chungTuChiTietInfor.MaSanPham);
            DataTable tblCheck = ds.Tables["CheckTrungMaVach"].DefaultView.ToTable("Temp");
            DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(chungTuChiTietInfor.MaSanPham);
            if (sp != null)
            {
                TrungMaVach = sp.TrungMaVach;
            }
            for (int i = 0; i < tableTemp.Rows.Count; i++)
            {
                SoLuongMaVach += Convert.ToInt32(tableTemp.Rows[i]["SoLuong"]);
            }
            if (SoLuongMaVach < chungTuChiTietInfor.SoLuong && SoLuongMaVach > 0)
            {
                throw new ManagedException("số lượng mã vạch của mã hàng :" + chungTuChiTietInfor.MaSanPham + " không khớp trong file import . Xin hãy kiểm tra lại!");
            }
            if (TrungMaVach == 0)
            {

                for (int i = 0; i < tableTemp.Rows.Count; i++)
                {
                    ChungTuXuatNccChiTietHangHoaInfo chiTietMaVach = business.ListChiTietHangHoa.Find(
                    delegate(ChungTuXuatNccChiTietHangHoaInfo match)
                    {
                        return match.MaVach == tableTemp.Rows[i]["MaVach"].ToString();
                    });
                    if (string.IsNullOrEmpty(tableTemp.Rows[i]["MaVach"].ToString().Trim()))
                    {
                        throw new InvalidOperationException("Mã vạch của mã sản phẩm " + tableTemp.Rows[i]["MaSanPham"] + " đang để trống !");
                    }
                    if (chiTietMaVach != null)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[i]["MaVach"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachTP(sp.IdSanPham, tableTemp.Rows[i]["MaVach"].ToString()) > 0)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[i]["MaVach"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                }
                if (tblCheck.Rows.Count > 0)
                {
                    throw new InvalidOperationException("Mã sản phẩm : " + sp.MaSanPham + " có mã vạch " + tblCheck.Rows[0]["MaVach"] + " bị trùng. Xin hãy kiểm tra lại !");
                }
            }
        }

        private List<ChungTuXuatNhapNccChiTietInfo> check(List<ChungTuXuatNhapNccChiTietInfo> lst, DataSet ds)
        {
            List<ChungTuXuatNhapNccChiTietInfo> lichitiet = new List<ChungTuXuatNhapNccChiTietInfo>();
            if (lst.Count > 0)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    ChungTuXuatNccChiTietHangHoaInfo chiTietMaVach = business.ListChiTietHangHoa.Find(
                                    delegate(ChungTuXuatNccChiTietHangHoaInfo match)
                                    {
                                        return
                                            match.TransactionID == lst[i].TransactionID;
                                    });
                    if (chiTietMaVach == null)
                    {
                        lichitiet.Add(lst[i]);
                    }
                }
            }
            else
            {
                lichitiet.AddRange(lst);
            }
            for (int i = 0; i < lichitiet.Count; i++)
            {
                CheckTrungMaVach(lichitiet[i], ds);
            }
            lichitiet.Sort(delegate(ChungTuXuatNhapNccChiTietInfo item1, ChungTuXuatNhapNccChiTietInfo item2)
            {
                return item1.MaSanPham.CompareTo(item2.MaSanPham);

            });
            return lichitiet;
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

                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, [SO_LUONG] as SoLuong from [Items$] where [SERIAL] is not null and [MA_HANG_HOA] is not null";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "HangHoaChiTiet");
                        }
                        sql = "Select [MA_HANG_HOA] as MaSanPham, [SERIAL] as MaVach, sum([SO_LUONG]) as SoLuong from [Items$] group by [MA_HANG_HOA],[SERIAL]";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "CheckTrungMaVach");
                        }
                    }

                    int x = 0;
                    string MaSP = "";
                    foreach (ChungTuXuatNhapNccChiTietInfo chungTuChiTietInfor in check(listCTChungTu, ds))
                    {
                        //int TrungMaVach = 0;
                        //DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(chungTuChiTietInfor.MaSanPham);
                        //if (sp != null)
                        //{
                        //    TrungMaVach = sp.TrungMaVach;
                        //}
                        int count = 0;
                        //ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        //DataTable tableTemp = ds.Tables["HangHoaChiTiet"].DefaultView.ToTable("Temp");
                        ds.Tables["CheckTrungMaVach"].DefaultView.RowFilter = String.Format("MaSanPham='{0}'", chungTuChiTietInfor.MaSanPham);
                        DataTable tblCheck = ds.Tables["CheckTrungMaVach"].DefaultView.ToTable("Temp");
                        #region
                        //foreach (DataRow dataRow in tblCheck.Rows)
                        //{
                        //    if (dataRow["MaVach"] == DBNull.Value || String.IsNullOrEmpty(Convert.ToString(dataRow["MaVach"])))
                        //    {
                        //        throw new ManagedException("Đang có dòng không được nhập mã vạch.");
                        //    }

                        //    ChungTuNhapNccChiTietHangHoaInfo chiTietMaVach = khoBusiness.ListChiTietHangHoa.Find(
                        //        delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                        //            {
                        //                return match.MaVach == Convert.ToString(dataRow["MaVach"]);
                        //            });
                        //    ChungTuNhapNccChiTietHangHoaInfo chiTietTransactionID = khoBusiness.ListChiTietHangHoa.Find(
                        //        delegate(ChungTuNhapNccChiTietHangHoaInfo match)
                        //        {
                        //            return match.MaVach == Convert.ToString(dataRow["MaVach"]) 
                        //                && match.TransactionID == chungTuChiTietInfor.TransactionID;
                        //        });
                        //    if (count < chungTuChiTietInfor.SoLuong)
                        //    {
                        //        if (TrungMaVach == 0)
                        //        {
                        //            // không cho trùng mã vạch
                        //            if (chiTietTransactionID == null && chiTietMaVach == null)
                        //            {
                        //                khoBusiness.ListChiTietHangHoa.Add(
                        //                new ChungTuNhapNccChiTietHangHoaInfo
                        //                {
                        //                    IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //                    IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //                    MaVach = Convert.ToString(dataRow["MaVach"]),
                        //                    SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                        //                    TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //                    TransactionID = chungTuChiTietInfor.TransactionID
                        //                });
                        //                count += Convert.ToInt32(dataRow["SoLuong"]);
                        //            }
                        //            //if (chiTietTransactionID != null && chiTietMaVach != null)
                        //            //{
                        //            //    khoBusiness.ListChiTietHangHoa.Add(
                        //            //    new ChungTuNhapNccChiTietHangHoaInfo
                        //            //    {
                        //            //        IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //            //        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //            //        MaVach = Convert.ToString(dataRow["MaVach"]),
                        //            //        SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                        //            //        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //            //        TransactionID = chungTuChiTietInfor.TransactionID
                        //            //    });
                        //            //    count += Convert.ToInt32(dataRow["SoLuong"]);
                        //            //}
                        //        }
                        //        else
                        //        {
                        //            //cho trùng mã vạch
                        //            if (chiTietTransactionID == null)
                        //            {
                        //                if (Convert.ToInt32(dataRow["SoLuong"]) > chungTuChiTietInfor.SoLuong)
                        //                {
                        //                    khoBusiness.ListChiTietHangHoa.Add(
                        //                    new ChungTuNhapNccChiTietHangHoaInfo
                        //                    {
                        //                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //                        MaVach = Convert.ToString(dataRow["MaVach"]),
                        //                        SoLuong = chungTuChiTietInfor.SoLuong,
                        //                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //                        TransactionID = chungTuChiTietInfor.TransactionID
                        //                    });
                        //                    count += chungTuChiTietInfor.SoLuong;
                        //                }
                        //                else
                        //                {
                        //                    khoBusiness.ListChiTietHangHoa.Add(
                        //                    new ChungTuNhapNccChiTietHangHoaInfo
                        //                    {
                        //                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                        //                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                        //                        MaVach = Convert.ToString(dataRow["MaVach"]),
                        //                        SoLuong = Convert.ToInt32(dataRow["SoLuong"]),
                        //                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                        //                        TransactionID = chungTuChiTietInfor.TransactionID
                        //                    });
                        //                    count += Convert.ToInt32(dataRow["SoLuong"]);
                        //                }
                        //            }
                        //            else
                        //            {
                        //                if (Convert.ToInt32(dataRow["SoLuong"]) > chungTuChiTietInfor.SoLuong)
                        //                {
                        //                    chiTietTransactionID.SoLuong = chungTuChiTietInfor.SoLuong;
                        //                }
                        //                else
                        //                {
                        //                    chiTietTransactionID.SoLuong += Convert.ToInt32(dataRow["SoLuong"]);
                        //                    count += Convert.ToInt32(dataRow["SoLuong"]);
                        //                }
                        //            }
                        //        }
                        //        if (count == chungTuChiTietInfor.SoLuong)
                        //        {
                        //            khoBusiness.ListChiTietChungTu.Add(chungTuChiTietInfor);
                        //            listCTChungTu[listCTChungTu.IndexOf(chungTuChiTietInfor)].TrangThai = "Đã nhập đủ";
                        //            dgvChiTiet.DataSource = null;
                        //            dgvChiTiet.DataSource = listCTChungTu;
                        //        }
                        //    }
                        //}
                        #endregion

                        if (!string.IsNullOrEmpty(MaSP))
                        {
                            if (!MaSP.Equals(chungTuChiTietInfor.MaSanPham))
                            {
                                x = 0;
                            }
                        }
                        else
                        {
                            x = 0;
                        }

                        MaSP = chungTuChiTietInfor.MaSanPham;

                        for (int i = x; i < tblCheck.Rows.Count; i++)
                        {

                            if (count < chungTuChiTietInfor.SoLuong)
                            {
                                if (Convert.ToInt32(tblCheck.Rows[i]["SoLuong"]) > chungTuChiTietInfor.SoLuong)
                                {
                                    business.ListChiTietHangHoa.Add(
                                    new ChungTuXuatNccChiTietHangHoaInfo
                                        {
                                            IdSanPham = chungTuChiTietInfor.IdSanPham,
                                            IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                                            MaVach = Convert.ToString(tblCheck.Rows[i]["MaVach"]),
                                            SoLuong = chungTuChiTietInfor.SoLuong,
                                            TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                                            TransactionID = chungTuChiTietInfor.TransactionID
                                        });
                                    count += chungTuChiTietInfor.SoLuong;
                                    x = i;
                                }
                                else
                                {
                                    business.ListChiTietHangHoa.Add(
                                    new ChungTuXuatNccChiTietHangHoaInfo
                                    {
                                        IdSanPham = chungTuChiTietInfor.IdSanPham,
                                        IdChungTuChiTiet = chungTuChiTietInfor.IdChungTuChiTiet,
                                        MaVach = Convert.ToString(tblCheck.Rows[i]["MaVach"]),
                                        SoLuong = Convert.ToInt32(tblCheck.Rows[i]["SoLuong"]),
                                        TrungMaVach = chungTuChiTietInfor.TrungMaVach,
                                        TransactionID = chungTuChiTietInfor.TransactionID
                                    });
                                    count += Convert.ToInt32(tblCheck.Rows[i]["SoLuong"]);
                                    x = i + 1;
                                }
                                if (count == chungTuChiTietInfor.SoLuong)
                                {
                                    business.ListChiTietChungTu.Add(chungTuChiTietInfor);
                                    listCTChungTu[listCTChungTu.IndexOf(chungTuChiTietInfor)].TrangThai = "Đã nhập đủ";
                                    dgvChiTiet.DataSource = null;
                                    dgvChiTiet.DataSource = listCTChungTu;
                                    arTran.Add(chungTuChiTietInfor.TransactionID);
                                }
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
                //throw;
            }
        }

        private void btnInTH_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = tblChungTuDataProvider.GetPhieuTraNCC_TH(OID);
            rpt_BC_PhieuTraHangNCC_TH rpt = new rpt_BC_PhieuTraHangNCC_TH();
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }
    }
}
