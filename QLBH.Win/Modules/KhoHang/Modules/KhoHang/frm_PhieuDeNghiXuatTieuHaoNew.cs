﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_PhieuDeNghiXuatTieuHaoNew : DevExpress.XtraEditors.XtraForm
    {
        private int trangThai;
        private int IdTrungTam;
        private bool IsAdd = false;
        private DeNghiXuatTieuHaoNewBusiness business;
        List<DMPhongBanInfor> liPhongBan = new List<DMPhongBanInfor>();
        List<DMChiPhiInfo> liChiPhi = new List<DMChiPhiInfo>();
        List<SegmentChildInfo> liNganh = new List<SegmentChildInfo>();
        private readonly ChungTuDeNghiXuatTieuHaoInfornew chungTuInfo;

        public frm_PhieuDeNghiXuatTieuHaoNew()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            business = new DeNghiXuatTieuHaoNewBusiness();
            txtNguoiLap.Text = Declare.UserName;
        }
        
        public frm_PhieuDeNghiXuatTieuHaoNew(int Oid)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            chungTuInfo = DeNghiXuatTieuHaoProvidernew.Instance.GetPhieuDeNghiXuatTieuHao(Oid);
            txtNguoiLap.Text = chungTuInfo.NguoiTao;
            business = new DeNghiXuatTieuHaoNewBusiness(chungTuInfo);
        }

        //public frm_PhieuDeNghiXuatTieuHaoNew(int OID, string PhieuNhap, string NgayLap, string PO, int TrangThai,string DienGiai, string NguoiXuat, string TenTrungTam,
        //    string TenKho, int IdTrungTam, int IdKho, int IdNhanVien, int loaiChungTu,int idNguoiQuanLy, string nguoiQuanLy)
        //{
        //    InitializeComponent();
        //    Common.LoadStyle(this);
        //    this.OID = OID;
        //    this.SoChungTu = PhieuNhap;
        //    this.trangThai = TrangThai;
        //    this.GhiChu = DienGiai;
        //    this.NguoiLap = NguoiXuat;
        //    this.IdTrungTam = IdTrungTam;
        //    this.IdKho = IdKho;
        //    this.IdNhanVien = IdNhanVien;
        //    this.TenTrungTam = TenTrungTam;
        //    this.TenKho = TenKho;
        //    this.LoaiChungTu = loaiChungTu;
        //    this.IdNguoiQuanLy = idNguoiQuanLy;
        //    this.NguoiQuanLy = nguoiQuanLy;
        //    business = new DeNghiXuatTieuHaoNewBusiness(new ChungTuDeNghiXuatTieuHaoInfornew()
        //    {
        //        LoaiChungTu = loaiChungTu,
        //        TrangThai = trangThai,
        //        IdChungTu = OID,
        //        SoChungTu = PhieuNhap,
        //        NgayLap = Convert.ToDateTime(NgayLap),
        //    });
        //}
        public frm_PhieuDeNghiXuatTieuHaoNew(ChungTuDeNghiXuatTieuHaoInfornew xuatTieuHaoInfor)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            business = new DeNghiXuatTieuHaoNewBusiness(xuatTieuHaoInfor);
            chungTuInfo = business.ChungTu;
        }
        private void LoadPhongBan()
        {
            liPhongBan = DMPhongBanDataProvider.Instance.GetListActivedPhongBanInfor();
            if (liPhongBan.Count > 0)
            {
                repPhongBan.DataSource = liPhongBan;
            }
        }
        private void LoadChiPhi()
        {
            liChiPhi = DMChiPhiDataProvider.Instance.GetListActivedChiPhiInfo();
            if (liChiPhi.Count > 0)
            {
                repChiPhi.DataSource = liChiPhi;
            }
            else
            {
                //cboChiPhi.DataSource = null;
            }
        }
        private void LoadNganh()
        {
            liNganh = DmNganhDataProvider.Instance.GetListSegmentChildInfor();
            if (liNganh.Count > 0)
            {
                repoNganh.DataSource = liNganh;
            }
        }

        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        private BindingSource bdSource;

        void bdSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (grvList.RowCount == bdSource.Count)
            {
                bdSource.RemoveAt(bdSource.Count - 1);
                return;
            }
        }
        #region Evens
        private void frm_PhieuDeNghiXuatTieuHaoNew_Load(object sender, EventArgs e)
        {
            if (chungTuInfo == null || chungTuInfo.IdChungTu == 0)
            {
                dteNgay.Text = Convert.ToString(CommonProvider.Instance.GetSysDate());
                dteNgay.BackColor = Color.White;
                dteNgay.ForeColor = Color.Black;
                //bteTVDN.Text = Declare.UserName;
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu("PXTH");
                txtNguoiLap.Text = Declare.UserName;
                IsAdd = true;
            }
            else
            {
                txtSoPhieu.Text = business.ChungTu.SoChungTu;
                txtNguoiLap.Text = business.ChungTu.NguoiTao;
                dteNgay.DateTime = business.ChungTu.NgayLap;
                bteNguoiQuanLy.Text = business.ChungTu.NguoiQuanLy;
                bteTVDN.Text = business.ChungTu.HoTen;
                bteTVDN.Tag = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(business.ChungTu.IdNhanVien);
                bteTVDN.Enabled = false;
                bteTrungTam.Text = business.ChungTu.TenTrungTam;
                bteTrungTam.Tag = DMTrungTamDataProvider.GetTrungTamByIdInfo(business.ChungTu.IdTrungTam);
                bteNguoiQuanLy.Tag = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(business.ChungTu.IdNguoiQuanLy);
                bteKho.Text = business.ChungTu.TenKho;
                bteKho.Tag = DMKhoDataProvider.GetKhoByIdInfo(business.ChungTu.IdKho);
                txtGhiChu.Text = business.ChungTu.GhiChu;
                txtGhiChu.Enabled = false;
                btnCapNhat.Enabled = false;
                btnThemSP.Enabled = false;
                btnXoaSP.Enabled = false;
                bteKho.Enabled = false;
                bteTrungTam.Enabled = false;
            }

            bdSource = new BindingSource();
            if (business.ListChiTietChungTu != null)
            {
                bdSource.DataSource = new BindingList<DeNghiXuatTieuHaoChiTietInfonew>(business.ListChiTietChungTu);
                bdSource.AddingNew += new AddingNewEventHandler(bdSource_AddingNew);
                grcList.DataSource = bdSource;
            }
            dteNgay.Enabled = false;
            LoadChiPhi();
            LoadPhongBan();
            LoadNganh();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bteTrungTam.Text) || string.IsNullOrEmpty(bteKho.Text))
            {
                clsUtils.MsgCanhBao("Bạn chưa chọn trung tâm/kho!");
                return;
            }
            frmLookUp_SanPham frm = new frmLookUp_SanPham(((DMKhoInfo)bteKho.Tag).IdKho, 0, true, true);
            if (frm.ShowDialog() == DialogResult.OK)//nếu kết quả trả về là form LookUp
            {
                PickUpSanPhamInfo(frm.SelectedItem);
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (grvList.FocusedRowHandle == null) return;
            if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Delete(grvList.FocusedRowHandle);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietXTHInfor> list = DeNghiXuatTieuHaoProvider.Instance.GetInPhieuDeNghiXuatTieuHao(business.ChungTu.IdChungTu);
            rpt_BC_PhieuDeNghiXuatTieuHao rpt = new rpt_BC_PhieuDeNghiXuatTieuHao();
            List<BaoCao_ChiTietXTHInfor> lst = new List<BaoCao_ChiTietXTHInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAll();

                DialogResult = DialogResult.OK;
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_PhieuDeNghiXuatTieuHaoNew_KeyDown(object sender, KeyEventArgs e)
        {
            QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }
        #endregion

        protected void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        {
            if (bteKho.Tag == null)
            {
                clsUtils.MsgThongBao("Bạn chưa chọn kho xuất nên chưa thể chọn sản phẩm được!");
                return;
            }
            List<TonDauKyInfo> item = DeNghiDieuChuyenDataProvider.Instance.GetListHangTonKhoByIdSanPham(((DMKhoInfo)bteKho.Tag).IdKho, sanPhamInfo.IdSanPham);
            if (item.Count > 0)
            {
                MessageBox.Show("Sản phẩm đã hết tồn kho xin mời bạn chọn hàng khác!");
                return;
            }
            business.ListChiTietChungTu.Add(new DeNghiXuatTieuHaoChiTietInfonew()
            {
                MaSanPham = sanPhamInfo.MaSanPham,
                IdSanPham = sanPhamInfo.IdSanPham,
                TenSanPham = sanPhamInfo.TenSanPham,
                DonGia = sanPhamInfo.GiaNhap,
                TrungMaVach = sanPhamInfo.TrungMaVach,
                Nganh = sanPhamInfo.Nganh,
                SoLuong = 1,
            });
            //((BindingSource)grvList.DataSource).ResetBindings(false);
            grcList.DataSource = null;
            grcList.DataSource = business.ListChiTietChungTu;
            btnCapNhat.Enabled = business.ListChiTietChungTu.Count > 0;
        }
        //protected DataGridViewTextBoxColumn ColumnMaSanPham
        //{
        //    get
        //    {
        //        return colMaSanPham;
        //    }
        //}
        private bool Check()
        {
            if (grvList.RowCount <= 0)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm!");
            }
            if (Equals(bteTrungTam.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn trung tâm !");
            }
            if (Equals(bteKho.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn kho !");
            }
            if (Equals(bteTVDN.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn thương viên!");
            }
            if (Equals(bteNguoiQuanLy.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn người quản lý!");
            }
            DeNghiXuatTieuHaoChiTietInfonew pt = business.ListChiTietChungTu.Find(delegate(DeNghiXuatTieuHaoChiTietInfonew match)
            {
                return match.IdSanPham == 0;
            });
            if (pt != null)
            {
                business.ListChiTietChungTu.Remove(pt);
            }
            business.ListChiTietChungTu.ForEach(delegate(DeNghiXuatTieuHaoChiTietInfonew ap)
            {
                if (ap.SoLuong <= 0)
                {
                    throw new ManagedException("Số lượng phải lớn hơn 0 !");
                }
            });
            business.ListChiTietChungTu.ForEach(delegate(DeNghiXuatTieuHaoChiTietInfonew ap)
                                                    {
                                                        if (ap.IdChiPhi == 0 || ap.IdPhongBan == 0)
                                                        {
                                                            throw new ManagedException("Bạn chưa chọn phòng ban , chi phí!"); 
                                                        }
                                                    });
            business.ListChiTietChungTu.ForEach(delegate(DeNghiXuatTieuHaoChiTietInfonew ap)
                                                    {
                                                        if (ap.Nganh != null && ap.Nganh.Length > 2)
                                                        {
                                                            throw new ManagedException("Bạn chưa chọn ngành!");
                                                        }
                                                    });
            business.ListChiTietChungTu.ForEach(delegate(DeNghiXuatTieuHaoChiTietInfonew itm)
                                                    {
                                                        if (business.ListChiTietChungTu.FindAll(
                                                            delegate(DeNghiXuatTieuHaoChiTietInfonew math)
                                                            {
                                                                return
                                                                    math.IdSanPham ==
                                                                    itm.IdSanPham &&
                                                                    math.IdChiPhi == itm.IdChiPhi &&
                                                                    math.IdPhongBan == itm.IdPhongBan;
                                                            }).Count > 1) { throw new ManagedException("Mã sản phẩm - Phòng ban - Chi Phí bị lặp!"); }
                                                    });
            return true;
        }

        protected void SaveChungTu()
        {
            if (Check())
            {
                if (business.ChungTu.IdNhanVien == 0)
                    business.ChungTu.IdNhanVien = bteTVDN.Tag != null ? ((DMNhanVienInfo)bteTVDN.Tag).IdNhanVien : 0;
                business.ChungTu.IdKho = bteKho.Tag != null ? ((DMKhoInfo)bteKho.Tag).IdKho : 0;
                business.ChungTu.NgayLap = Convert.ToDateTime(dteNgay.Text);
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                business.ChungTu.IdTrungTam =  bteTrungTam.Tag!= null ? ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam : 0;
                business.ChungTu.IdNguoiQuanLy = bteNguoiQuanLy.Tag != null ? ((DMNhanVienInfo)bteNguoiQuanLy.Tag).IdNhanVien : 0;
                //nếu thêm mới
                if (business.ChungTu.IdChungTu == 0)
                {
                    business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.DE_NGHI_TIEU_HAO);
                    business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDuyet.CHUA_XUAT);
                }
            }
        }

        private void SaveAll()
        {
            try
            {
                List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());
                if (li.Count > 0 && business.ChungTu.IdChungTu == 0)
                {
                    txtSoPhieu.Focus();
                    throw new ManagedException("Số phiếu đã tồn tại trong hệ thống.Xin hãy kiểm tra lại!");
                }
                SaveChungTu();
                
                frmProgress.Instance.Caption = Text;
                frmProgress.Instance.Description = "Đang thực hiện ...";
                frmProgress.Instance.MaxValue = 100;
                frmProgress.Instance.Value = 0;

                frmProgress.Instance.DoWork(
                    delegate
                        {
                            try
                            {
                                frmProgress.Instance.MaxValue = 10;

                                ConnectionUtil.Instance.BeginTransaction();

                                DeNghiXuatTieuHaoNewBusiness businessCloned = (DeNghiXuatTieuHaoNewBusiness)business.Clone();

                                frmProgress.Instance.Value += 1;

                                if (businessCloned.ChungTu.IdChungTu == 0 &&
                                    !dteNgay.Enabled) businessCloned.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();

                                frmProgress.Instance.Value += 1;

                                businessCloned.SaveChungTu();

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
                                    EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Đề nghị xuất tiêu hao");
                                }
                            }
                        });
                
                //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
                //    delegate
                //        {
                //            frmProgress.Instance.MaxValue = 10;

                //            DeNghiXuatTieuHaoNewBusiness businessCloned = (DeNghiXuatTieuHaoNewBusiness)business.Clone();

                //            frmProgress.Instance.Value += 1;

                //            if (businessCloned.ChungTu.IdChungTu == 0 &&
                //                !dteNgay.Enabled) businessCloned.ChungTu.NgayLap = CommonProvider.Instance.GetSysDate();

                //            frmProgress.Instance.Value += 1;

                //            businessCloned.SaveChungTu();

                //            frmProgress.Instance.Value += 1;
                //        }
                //    );                
            }
            catch (Exception)
            {
                //ConnectionUtil.Instance.RollbackTransaction();
                throw;
            }
        }
        private void Delete(int rowhandle)
        {
            if (grvList.RowCount > 0)
            {
                DeNghiXuatTieuHaoChiTietInfonew item = (DeNghiXuatTieuHaoChiTietInfonew)grvList.GetRow(rowhandle);
                business.ListChiTietChungTu.RemoveAt(business.ListChiTietChungTu.IndexOf(item));
                grcList.DataSource = null;
                grcList.DataSource = business.ListChiTietChungTu;
            }
        }

        #region bteTrungTam
        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frmLookUpTrungTam = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);

            if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                bteKho.Text = String.Empty;
                bteKho.Tag = null;
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var frmLookUpTrungTam = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);

                if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                    bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.TenTrungTam;
                    bteKho.Text = String.Empty;
                    bteKho.Tag = null;
                }
            }
        }
        private void bteTrungTam_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteTrungTam.Text))
            {
                bteTrungTam.Tag = null;
                bteKho.Text = String.Empty;
                bteKho.Tag = null;
            }
        }
        #endregion

        #region bteKho
        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frmLookUpKho = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text),
                                                 ((DMTrungTamInfor) bteTrungTam.Tag).IdTrungTam,
                                                 Declare.IdNhanVien);

            if (frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frmLookUpKho.SelectedItem;
                bteKho.Text = frmLookUpKho.SelectedItem.TenKho;
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var frmLookUpKho = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text),
                                                     ((DMTrungTamInfor) bteTrungTam.Tag).IdTrungTam,
                                                     Declare.IdNhanVien);

                if (frmLookUpKho.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frmLookUpKho.SelectedItem;
                    bteKho.Text = frmLookUpKho.SelectedItem.TenKho;
                }
            }
        }

        private void bteKho_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKho.Text)) bteKho.Tag = null;
        }
        #endregion

        #region bteTVDN
        private void bteTVDN_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frmLookUpNhanVien = new frmLookUp_NhanVien(String.Format("%{0}%", bteTVDN.Text));

            if (frmLookUpNhanVien.ShowDialog() == DialogResult.OK)
            {
                bteTVDN.Tag = frmLookUpNhanVien.SelectedItem;
                bteTVDN.Text = frmLookUpNhanVien.SelectedItem.HoTen;
            }
        }

        private void bteTVDN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var frmLookUpNhanVien = new frmLookUp_NhanVien(String.Format("%{0}%", bteTVDN.Text));

                if (frmLookUpNhanVien.ShowDialog() == DialogResult.OK)
                {
                    bteTVDN.Tag = frmLookUpNhanVien.SelectedItem;
                    bteTVDN.Text = frmLookUpNhanVien.SelectedItem.HoTen;
                }
            }
        }

        private void bteTVDN_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteTVDN.Text)) bteTVDN.Tag = null;
        }
        #endregion

        #region bteNguoiQuanLy
        private void bteNguoiQuanLy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var frmLookUpNhanVien = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiQuanLy.Text));

            if (frmLookUpNhanVien.ShowDialog() == DialogResult.OK)
            {
                bteNguoiQuanLy.Tag = frmLookUpNhanVien.SelectedItem;
                bteNguoiQuanLy.Text = frmLookUpNhanVien.SelectedItem.HoTen;
            }
        }

        private void bteNguoiQuanLy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var frmLookUpNhanVien = new frmLookUp_NhanVien(String.Format("%{0}%", bteNguoiQuanLy.Text));

                if (frmLookUpNhanVien.ShowDialog() == DialogResult.OK)
                {
                    bteNguoiQuanLy.Tag = frmLookUpNhanVien.SelectedItem;
                    bteNguoiQuanLy.Text = frmLookUpNhanVien.SelectedItem.HoTen;
                }
            }
        }

        private void bteNguoiQuanLy_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteNguoiQuanLy.Text)) bteNguoiQuanLy.Tag = null;
        }
        #endregion
    }
}