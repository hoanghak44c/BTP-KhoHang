using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_PhieuNhapTieuHao : DevExpress.XtraEditors.XtraForm
    {
        private int OID, IdNhanVienGiao, idChungTuChiTiet;
        private int idChungTuGoc;
        private int trangThai;
        private string NguoiLap;
        private string SoChungTu;
        private string TenKho;
        private string NguoiXuat;
        private string TenTrungTam;
        private string GhiChu;
        public string DonViTinh;
        protected string NgayXuat,NgayLap;
        protected string ReportTitle;
        public string SoPO;
        public int IdSanPham;
        public int InDex;
        private int SumChiTietMaVach = 0;
        private int SumChiTietChungTu = 0;
        ArrayList arTran = new ArrayList();
        private NhapKhoTieuHaoBusiness business;
        List<DMPhongBanInfor> liPhongBan = new List<DMPhongBanInfor>();
        List<DMChiPhiInfo> liChiPhi = new List<DMChiPhiInfo>();
        List<SegmentChildInfo> liNganh = new List<SegmentChildInfo>();
        private List<ChungTu_ChiTietHangHoaXTHInfo> liChiTiet =new List<ChungTu_ChiTietHangHoaXTHInfo>();
        public ChungTuCTHanghoaBasePairInfo HangHoa = new ChungTuCTHanghoaBasePairInfo();
        public frm_PhieuNhapTieuHao()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        public frm_PhieuNhapTieuHao(int oid, string sochungtu, string ngaylap, string sopo)
        {
            InitializeComponent();
            ChungTuXuatTieuHaoInfornew chungTuXuatTieuHaoInfor =
                XuatTieuHaoProvider.Instance.GetChungTuBySoChungTu<ChungTuXuatTieuHaoInfornew>(sochungtu);
            if (chungTuXuatTieuHaoInfor != null)
            {
                chungTuXuatTieuHaoInfor.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_TIEU_HAO);
                business = new NhapKhoTieuHaoBusiness(chungTuXuatTieuHaoInfor);
            }
            else
            {
                throw new ManagedException(String.Format("Chứng từ số {0} không tồn tại.", sochungtu));
            }
        }
        public frm_PhieuNhapTieuHao(int oid, string sochungtu, string ngayxuat, string sopo, int idChungTuGoc, int trangThai, string nguoiLap, string TenTrungTam, string TenKho, string NguoiXuat, string GhiChu, int IdNhanVienGiao, string ngayLap, int idKho)
        {
            InitializeComponent();
            this.OID = oid;
            this.TenTrungTam = TenTrungTam;
            this.TenKho = TenKho;
            this.SoChungTu = sochungtu;
            this.NgayXuat = ngayxuat;
            this.idChungTuGoc = idChungTuGoc;
            this.trangThai = trangThai;
            this.NguoiLap = nguoiLap;
            this.NguoiXuat = NguoiXuat;
            this.GhiChu = GhiChu;
            this.IdNhanVienGiao = IdNhanVienGiao;
            this.NgayLap = ngayLap;
            ChungTuXuatTieuHaoInfornew chungTuXuatTieuHaoInfor =
                XuatTieuHaoProvidernew.Instance.GetChungTuBySoChungTu<ChungTuXuatTieuHaoInfornew>(sochungtu);
            if (chungTuXuatTieuHaoInfor != null)
            {
                chungTuXuatTieuHaoInfor.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_TIEU_HAO);
                business = new NhapKhoTieuHaoBusiness(chungTuXuatTieuHaoInfor);
            }
        }
        private void LoadPhongBan()
        {
            liPhongBan = DMPhongBanDataProvider.Instance.GetListPhongBanInfor();
            if (liPhongBan.Count > 0)
            {
                repPhongBan.DataSource = liPhongBan;
            }
        }
        private void LoadChiPhi()
        {
            liChiPhi = DMChiPhiDataProvider.Instance.GetListChiPhiInfo();
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
                repNganh.DataSource = liNganh;
            }
        }
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        #region bteTVX
        private void bteTVX_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_NhanVien frmLookUpNhanVien = new frmLookUp_NhanVien(String.Format("%{0}%", bteTVX.Text));
            if (frmLookUpNhanVien.ShowDialog() == DialogResult.OK)
            {
                bteTVX.Tag = frmLookUpNhanVien.SelectedItem;
                bteTVX.Text = frmLookUpNhanVien.SelectedItem.HoTen;
            }
        }

        private void bteTVX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_NhanVien frmLookUpNhanVien = new frmLookUp_NhanVien(String.Format("%{0}%", bteTVX.Text));
                if (frmLookUpNhanVien.ShowDialog() == DialogResult.OK)
                {
                    bteTVX.Tag = frmLookUpNhanVien.SelectedItem;
                    bteTVX.Text = frmLookUpNhanVien.SelectedItem.HoTen;
                }
            }
        }

        private void bteTVX_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteTVX.Text)) bteTVX.Tag = null;
        }
        #endregion
        protected void GetValueInstance(int e)
        {
            if (e < 0)
            {
                HangHoa = null;
                return;
            }
            SoPO = business.ChungTu.SoChungTuGoc;
            HangHoa.IdSanPham = business.ListChiTietChungTu[e].IdSanPham;
            HangHoa.TenSanPham = business.ListChiTietChungTu[e].TenSanPham;
            HangHoa.SoLuong = business.ListChiTietChungTu[e].SoLuong;
            HangHoa.TrungMaVach = business.ListChiTietChungTu[e].TrungMaVach;
            HangHoa.DonGia = business.ListChiTietChungTu[e].DonGia;
            HangHoa.DonViTinh = business.ListChiTietChungTu[e].TenDonViTinh;
            InDex = e;
            DonViTinh = business.ListChiTietChungTu[e].TenDonViTinh;
            HangHoa.IdPhongBan = business.ListChiTietChungTu[e].IdPhongBan;
            HangHoa.IdChiPhi = business.ListChiTietChungTu[e].IdChiPhi;
            idChungTuChiTiet = business.ListChiTietChungTu[e].IdChungTuChiTiet;
            liChiTiet = business.GetListChiTietHangHoaByIdSanPham(business.ListChiTietChungTu[e].IdSanPham);
            //liChiTiet = business.GetListChiTietHangHoaByConjunction(
            //    delegate(ChungTu_ChiTietHangHoaXTHInfo match)
            //    {
            //        return business.Conjunction(business.ListChiTietChungTu[e],
            //            match);
            //    });
            //btnChiTiet.Enabled = HangHoa.IdSanPham > 0;
            //btnCapNhat.Enabled = HangHoa.IdSanPham > 0;
        }
        #region Evens

        private bool Check()
        {
            if (Equals(bteTVX.Tag, null))
            {
                throw new ManagedException("Bạn chưa chọn thương viên nhập!");
            }
            //foreach (ChungTu_ChiTietInfonew pt in business.ListChiTietChungTu)
            //{
            //    if (pt.IdSanPham == 0)
            //    {
            //        throw new InvalidOperationException("Trong danh sách có sản phẩm bạn chưa thêm vào!");
            //    }
            //}
            int SumChiTietMaVach = 0;
            
            int SumChiTietChungTu = 0;

            foreach (ChungTu_ChiTietHangHoaXTHInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
            {
                SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
            }
            foreach (ChungTu_ChiTietInfonew chungTuChiTietInfo in business.ListChiTietChungTu)
            {
                SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
            }
            if (SumChiTietChungTu > SumChiTietMaVach)
            {
                throw new InvalidExpressionException("Bạn chưa nhập đủ số mã vạch!");
            }
            return true;
        }

        protected void SaveChungTu()
        {
            if (Check())
            {
                //if (business.ChungTu.IdNhanVien == 0)
                business.ChungTu.IdNhanVienGiao = ((DMNhanVienInfo) bteTVX.Tag).IdNhanVien;
                business.ChungTu.SoChungTu = txtSoPhieu.Text.Trim();
                business.ChungTu.GhiChu = txtGhiChu.Text.Trim();
                if (Convert.ToDateTime(dteNgay.Text) >= Convert.ToDateTime(NgayLap))
                {
                    business.ChungTu.NgayLap = Convert.ToDateTime(dteNgay.Text);
                }
                else { throw new InvalidOperationException("Ngày nhập phải lớn hơn hoặc bằng ngày lập phiếu!"); }
                business.ChungTu.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_TIEU_HAO);
                foreach (ChungTu_ChiTietHangHoaXTHInfo chungTuChiTietHangHoaBaseInfo in business.ListChiTietHangHoa)
                {
                    SumChiTietMaVach += chungTuChiTietHangHoaBaseInfo.SoLuong;
                }
                foreach (ChungTu_ChiTietInfonew chungTuChiTietInfo in business.ListChiTietChungTu)
                {
                    SumChiTietChungTu += chungTuChiTietInfo.SoLuong;
                }
                if (SumChiTietChungTu == SumChiTietMaVach)
                {
                    business.ChungTu.TrangThai = Convert.ToInt32(TrangThaiDuyet.DA_NHAP);
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAll();
                    MessageBox.Show("Cập nhật thành công !");
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
        private void SaveAll()
        {
            try
            {
                List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());
                if (li.Count > 0 && OID == 0)
                {
                    txtSoPhieu.Focus();
                    throw new ManagedException("Số phiếu đã tồn tại trong hệ thống.Xin hãy kiểm tra lại!");
                }
                ConnectionUtil.Instance.BeginTransaction();
                SaveChungTu();
                business.SaveChungTu();
                ConnectionUtil.Instance.CommitTransaction();
            }
            catch (Exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw;
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grcList_DoubleClick(object sender, EventArgs e)
        {
            if (HangHoa != null)
            {
                GetValueInstance(grvList.FocusedRowHandle);
                frm_ChiTietMaVachNhapTieuHao frm = new frm_ChiTietMaVachNhapTieuHao(this,HangHoa, liChiTiet, idChungTuChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //ChungTu_ChiTietInfonew ct = business.ListChiTietChungTu[InDex];
                    //business.MergeChiTietHangHoa(frm.liChiTiet,
                    //                                delegate(ChungTu_ChiTietHangHoaXTHInfo match)
                    //                                {
                    //                                    return business.Conjunction(
                    //                                        business.ListChiTietChungTu[
                    //                                            business.ListChiTietChungTu.IndexOf(ct)],
                    //                                        match);
                    //                                });
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            if (HangHoa != null)
            {
                GetValueInstance(grvList.FocusedRowHandle);
                frm_ChiTietMaVachNhapTieuHao frm = new frm_ChiTietMaVachNhapTieuHao(this,HangHoa, liChiTiet, idChungTuChiTiet);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //ChungTu_ChiTietInfonew ct = business.ListChiTietChungTu[InDex];
                    //business.MergeChiTietHangHoa(frm.liChiTiet,
                    //                                delegate(ChungTu_ChiTietHangHoaXTHInfo match)
                    //                                {
                    //                                    return business.Conjunction(
                    //                                        business.ListChiTietChungTu[
                    //                                            business.ListChiTietChungTu.IndexOf(ct)],
                    //                                        match);
                    //                                });
                    business.MergeChiTietHangHoa(frm.liChiTiet);
                }
            }
        }
        #endregion

        private void grcList_Enter(object sender, EventArgs e)
        {
            btnChiTietMaVach.Enabled = true;
        }

        private void frm_PhieuNhapTieuHao_KeyDown(object sender, KeyEventArgs e)
        {
            QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void frm_PhieuNhapTieuHao_Load(object sender, EventArgs e)
        {
            business.ListChiTietChungTu = XuatTieuHaoProvidernew.Instance.GetListChiTietChungTuByIdChungTu(OID != 0 ? OID : idChungTuGoc);
            grcList.DataSource = business.ListChiTietChungTu;
            if (NgayXuat == Convert.ToString(DateTime.MinValue))
            {
                dteNgay.Text = Convert.ToString(CommonProvider.Instance.GetSysDate());
            }
            else
            {
                dteNgay.Text = NgayXuat;
            }
            bteTVDN.Text = NguoiLap;
            bteTrungTam.Text = TenTrungTam;
            bteKho.Text = TenKho;
            txtGhiChu.Text = GhiChu;
            bteTVX.Text = NguoiXuat;
            bteTVX.Tag = DmNhanVienDataProvider.GetListDmNhanVienInfoFromOid(IdNhanVienGiao);
            txtSoPhieu.Text = SoChungTu;
            bteTVDN.Enabled = IsSupperUser();
            bteTrungTam.Enabled = false;
            bteKho.Enabled = false;
            dteNgay.Enabled = false;
            if (trangThai == Convert.ToInt32(TrangThaiDuyet.DA_NHAP))
            {
                btnCapNhat.Enabled = false;
                txtGhiChu.Enabled = false;
                dteNgay.Enabled = false;
                bteTVX.Enabled = false;
            }
            else
            {
                //colSoLuong.RealColumnEdit = false;
            }
            LoadChiPhi();
            LoadPhongBan();
            LoadNganh();
        }
    }
}