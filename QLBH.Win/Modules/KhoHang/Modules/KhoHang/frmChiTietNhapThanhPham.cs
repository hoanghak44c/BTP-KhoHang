using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBH.Core.Data;
using QLBH.Core.Providers;
using QLBanHang.Properties;
using QLBanHang.Modules.BanHang.Reports;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTietNhapThanhPham : DevExpress.XtraEditors.XtraForm
    {
        #region Declare

        private NhapThanhPhamSanXuatBussiness NTPBussiness;
        private XuatLinhKienSanXuatBussiness XLKBussiness;
        private XacNhanNhapThanhPhanSanXuatBussiness XNNTPBussiness;
        private BangGiaReportInfo sanpham;
        private string MaLenh, MaSanPham, MaThanhPham, TenThanhPham, MaTrungTam, MaVachThanhPham;
        public int Index;
        private bool isXuatLoi = false;
        frmDanhSachXuatLKSX frm = new frmDanhSachXuatLKSX();
        frmTimKiemMaVach frm1 = new frmTimKiemMaVach();
        List<SanXuatCTietLenhInfo> lisx = new List<SanXuatCTietLenhInfo>();
        List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach = new List<ChungTuNhapNccChiTietHangHoaInfo>();
        public ChungTuCTHanghoaBasePairInfo HangHoa = new ChungTuCTHanghoaBasePairInfo();
        public List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet;
        private int SLCT, SoLuongYC;
        private int check;
        private int SoLuongTPham = 0;
        private int SoLuongMaVach = 0;
        private string SoPhieuXuat;
        private string SoPhieuNhap;
        #endregion
        #region frmChiTietNhapThanhPham
        public frmChiTietNhapThanhPham()
        {
            InitializeComponent();
        }
        public frmChiTietNhapThanhPham(frmDanhSachXuatLKSX frm, string maLenh, int check)
        {
            InitializeComponent();
            this.frm = frm;
            this.MaLenh = maLenh;
            this.MaThanhPham = frm.MaThanhPham;
            this.MaTrungTam = frm.MaTrungTam;
            this.TenThanhPham = frm.TenThanhPham;
            this.SoLuongYC = frm.SoLuongYC;
            this.SLCT = frm.SoLuongCT;
            this.check = check; //0: them moi, 2: sua
            XLKBussiness = new XuatLinhKienSanXuatBussiness(new ChungTuXuatNhapNccInfo());
            NTPBussiness = new NhapThanhPhamSanXuatBussiness(new ChungTuXuatNhapNccInfo());
        }

        public frmChiTietNhapThanhPham(frmTimKiemMaVach frm, string maLenh, List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach,ChungTuXuatNhapNccInfo ct, int check)
        {
            InitializeComponent();
            this.frm1 = frm;
            this.MaLenh = maLenh;
            this.MaThanhPham = frm.MaThanhPham;
            this.MaTrungTam = frm.MaTrungTam;
            this.TenThanhPham = frm.TenThanhPham;
            this.SoLuongYC = frm.SoLuongYC;
            this.SLCT = frm.SoLuongDN;
            this.MaVachThanhPham = frm.MaVachThanhPham;
            this.liMaVach = liMaVach;
            this.check = check; //0: them moi, 2: sua
            XLKBussiness = new XuatLinhKienSanXuatBussiness(new ChungTuXuatNhapNccInfo{IdChungTu = liMaVach[0].IdChungTu,SoChungTu = liMaVach[0].SoChungTu,IdKho = liMaVach[0].IdKho});
            NTPBussiness = new NhapThanhPhamSanXuatBussiness(ct);
            XNNTPBussiness = new XacNhanNhapThanhPhanSanXuatBussiness(ct);
        }

        public frmChiTietNhapThanhPham(string maLenh, string maThanhPham, string tenThanhPham, string maTrungTam, string maVachThanhPham, int soLuongYc, int soLuongCt, List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach, ChungTuXuatNhapNccInfo ct, int check)
        {
            InitializeComponent();
            this.MaLenh = maLenh;
            this.MaThanhPham = maThanhPham;
            this.MaTrungTam = maTrungTam;
            this.TenThanhPham = tenThanhPham;
            this.SoLuongYC = soLuongYc;
            this.SLCT = soLuongCt;
            this.MaVachThanhPham = maVachThanhPham;
            this.liMaVach = liMaVach;
            this.check = check; //0: them moi, 2: sua
            XLKBussiness = new XuatLinhKienSanXuatBussiness(new ChungTuXuatNhapNccInfo { IdChungTu = liMaVach[0].IdChungTu, SoChungTu = liMaVach[0].SoChungTu, IdKho = liMaVach[0].IdKho });
            NTPBussiness = new NhapThanhPhamSanXuatBussiness(ct);
            XNNTPBussiness = new XacNhanNhapThanhPhanSanXuatBussiness(ct);
        }
        #endregion

        #region Action

        private void LoadData()
        {
            txtMaVachTP.Enabled = false;
            if (check == 0)
            {
                lisx = SanXuatCTietLenhProvider.GetSanXuatLenhByMaLenh(MaLenh, MaTrungTam);
                txtMaLenh.Text = MaLenh;
                txtMaThanhPham.Text = MaThanhPham;
                txtTenThanhPham.Text = TenThanhPham;
                txtSoLuongYC.Text = SoLuongYC.ToString();
                //SLCT = frm.SoLuongCT;
            }
            else
            {
                lisx = SanXuatCTietLenhProvider.GetSanXuatLenhByMaLenh(MaLenh, MaTrungTam);
                for (int i = 0; i < lisx.Count; i++)
                {
                    lisx[i].SoLuongDaQuet = lisx[i].SoLuongTrenTPham;
                }
                txtMaLenh.Text = MaLenh;
                txtMaThanhPham.Text = MaThanhPham;
                txtTenThanhPham.Text = TenThanhPham;
                txtSoLuongYC.Text = SoLuongYC.ToString();
                //SLCT = frm1.SoLuongDN;
                txtMaVachTP.Text = MaVachThanhPham;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnNhap.Enabled = false;
            } 
            if (lisx.Count == 0)
            {
                this.Close();
                throw new ManagedException("Mã linh kiện không có trong hệ thống !");
            }
           
            
            txtSoLuongCT.Text = SLCT.ToString();
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.DataSource = lisx;
            dgvMaVach.AutoGenerateColumns = false;
            dgvMaVach.DataSource = new BindingList<ChungTuNhapNccChiTietHangHoaInfo>(liMaVach);
            MaSanPham = lisx[0].MaLinhKien;
            HangHoa.IdSanPham = lisx[0].IdLinhKien;
            HangHoa.TenSanPham = lisx[0].TenLinhKien;
            HangHoa.SoLuong = lisx[0].SoLuongCanXuat;
            HangHoa.TrungMaVach = lisx[0].TrungMaVach;
            HangHoa.DonGia = 0;
            HangHoa.DonViTinh = lisx[0].DonViTinh;
            liChiTiet = XLKBussiness.GetListChiTietHangHoaByIdSanPham(lisx[0].IdLinhKien);
            if (XLKBussiness.ChungTu.IdChungTu == 0)
            {
                for (int i = 0; i < lisx.Count; i++)
                {
                    XLKBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                    {
                        IdSanPham = lisx[i].IdLinhKien,
                        TenSanPham = lisx[i].TenLinhKien,
                        MaSanPham = lisx[i].MaLinhKien,
                        TenDonViTinh = lisx[i].DonViTinh,
                        SoLuong = lisx[i].SoLuongTrenTPham
                    });
                }
            }
        }

        private void Clear()
        {
            txtMaVach.Text = "";
            txtMaVachTP.Text = "";
            txtMaVachTP.Enabled = false;
            liMaVach.Clear();
            dgvMaVach.DataSource = null;
            dgvMaVach.DataSource = liMaVach;
            //if (dgvMaVach.DataSource != null)
            //    (dgvMaVach.DataSource as BindingList<ChungTuNhapNccChiTietHangHoaInfo>).ResetBindings();
            NTPBussiness = new NhapThanhPhamSanXuatBussiness(new ChungTuXuatNhapNccInfo());
            XLKBussiness = new XuatLinhKienSanXuatBussiness(new ChungTuXuatNhapNccInfo());
            for (int i = 0; i < lisx.Count; i++)
            {
                lisx[i].SoLuongDaQuet = 0;
            }
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = lisx;
            txtMaVach.Focus();
            GetSoPhieu();
        }

        private void UpdateNhapThanhPham()
        {
            SaveXuatLinhKien(NTPBussiness.ChungTu.SoChungTu);
        }

        private string SaveNhapThanhPham()
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = NTPBussiness.ChungTu;

            chungTuXuatNhapNccInfo.SoPO = txtMaLenh.Text.Trim();
            chungTuXuatNhapNccInfo.SoPhieuNhap = txtMaLenh.Text.Trim();
            chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX);
            if (check == 0)
            {
                chungTuXuatNhapNccInfo.SoChungTu = SoPhieuNhap;
            }
            chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
            chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
            chungTuXuatNhapNccInfo.TrangThai = 0;
            chungTuXuatNhapNccInfo.NgayLap = CommonProvider.Instance.GetSysDate();
            //chungTuXuatNhapNccInfo.NgayXuatHang = Convert.ToDateTime(dtNgayLap.EditValue);

            NTPBussiness.ListChiTietChungTu.Clear();
            NTPBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                                                    {
                                                        IdSanPham = frm.idThanhPham,
                                                        SoLuong = 1,
                                                        DanhSachMaVach = txtMaVachTP.Text.Trim()
                                                    });
            NTPBussiness.SaveChungTu();
            SaveMaVach(txtMaVachTP.Text.Trim(),frm.idThanhPham);
            return chungTuXuatNhapNccInfo.SoChungTu;
        }


        private void SaveXuatLinhKien(string NhapThanhPhan)
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = XLKBussiness.ChungTu;
            chungTuXuatNhapNccInfo.SoPO = NhapThanhPhan;
            chungTuXuatNhapNccInfo.SoPhieuNhap = NhapThanhPhan;
            chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX);
            if (check == 0)
            {
                chungTuXuatNhapNccInfo.SoChungTu = SoPhieuXuat;
            }
            chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
            chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
            chungTuXuatNhapNccInfo.NgayLap = CommonProvider.Instance.GetSysDate();
            chungTuXuatNhapNccInfo.TrangThai = 1;
            chungTuXuatNhapNccInfo.NgayXuatHang = CommonProvider.Instance.GetSysDate();

            //XLKBussiness.ListChiTietChungTu.Clear();
            //XLKBussiness.ListChiTietHangHoa.Clear();
            //for (int i = 0; i < lisx.Count; i++)
            //{
            //    XLKBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
            //    {
            //        IdSanPham = lisx[i].IdLinhKien,
            //        TenSanPham = lisx[i].TenLinhKien,
            //        MaSanPham = lisx[i].MaLinhKien,
            //        TenDonViTinh = lisx[i].DonViTinh,
            //        SoLuong = lisx[i].SoLuongTrenTPham
            //    });
            //}
            //for (int i = 0; i < liMaVach.Count; i++)
            //{
            //    XLKBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
            //                                            {
            //                                                IdSanPham = liMaVach[i].IdSanPham,
            //                                                SoLuong = liMaVach[i].SoLuong,
            //                                                MaVach = liMaVach[i].MaVach
            //                                            });
            //}
            XLKBussiness.SaveChungTu();
        }

        private void UpdateSoLuongDaXuat()
        {
            for (int i = 0; i < lisx.Count; i++)
            {
                SanXuatCTietLenhInfo sx = new SanXuatCTietLenhInfo();
                sx.SoLuongDaXuat = Convert.ToInt32(txtSoLuongCT.Text)*lisx[i].SoLuongTrenTPham;
                sx.MaLenh = frm.MaLenh;
                sx.MaLinhKien = lisx[i].MaLinhKien;
                SanXuatCTietLenhProvider.UpdateSL(sx);
            }
            
        }

        private void Save()
        {
            if (txtMaVachTP.Text == "")
            {
                throw new ManagedException("Mã vạch cho thành phẩm không được để trống !");
            }
            for (int i = 0; i < lisx.Count; i++)
            {
                if (lisx[i].SoLuongDaQuet < lisx[i].SoLuongTrenTPham)
                {
                    throw new ManagedException("Linh kiện " + lisx[i].TenLinhKien + " chưa nhập đủ số lượng mã vạch !");
                }
            }
            if (check == 0)
            {
                int SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX), txtMaLenh.Text.Trim(),Declare.MaTrungTam);
                if (Convert.ToInt32(txtSoLuongYC.Text) <= SoLuongCT)
                {
                    throw new ManagedException("Số lượng yêu cầu đã đủ, bạn không thể nhập thêm");
                }
            }
            if (check == 0 && isXuatLoi == false)
            {
                if (TblHangHoaChiTietDataProvider.IsUsedForAnotherProduct(txtMaVachTP.Text.Trim(), frm.idThanhPham))
                {
                    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                }
                if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachNTP(frm.idThanhPham, txtMaVachTP.Text.Trim()) > 0)
                {
                    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                }
                if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(frm.idThanhPham, txtMaVachTP.Text.Trim()) > 0)
                {
                    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                }
            }
            for (int i = 0; i < lisx.Count; i++)
            {
                if (lisx[i].SoLuongDaQuet < lisx[i].SoLuongTrenTPham)
                {
                    throw new ManagedException("Bạn chưa nhập đủ số lượng mã vạch cho linh kiện " + lisx[i].MaLinhKien + " !");
                }
            }
            if (string.IsNullOrEmpty(dtNgayLap.Text))
            {
                dtNgayLap.Focus();
                throw new ManagedException("Bạn chưa chọn ngày lập !");
            }
            if (Convert.ToDateTime(dtNgayLap.EditValue) < frm.NgayLap)
            {
                dtNgayLap.Focus();
                throw new ManagedException("Ngày xuất linh kiện không được nhỏ hơn ngày lập của mã lệnh !");
            }
            try
            {
                ConnectionUtil.Instance.BeginTransaction();
                if (check == 0)
                {
                    SaveXuatLinhKien(SaveNhapThanhPham());
                    SLCT++;
                }
                else
                {
                    XLKBussiness.SaveChungTu();
                }
                txtSoLuongCT.Text = SLCT.ToString();
                UpdateSoLuongDaXuat();
                if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX), txtMaLenh.Text.Trim(), 0) > 0)
                {
                    SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo { MaLenh = txtMaLenh.Text.Trim(), MaThanhPham = txtMaThanhPham.Text.Trim(), TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX) });
                }
                if (check == 0)
                {
                    int SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                    Convert.ToInt32(TransactionType.NHAP_THANH_PHAM_SX), txtMaLenh.Text.Trim(), Declare.MaTrungTam);
                    if (Convert.ToInt32(txtSoLuongYC.Text) < SoLuongCT)
                    {
                        throw new ManagedException("Số lượng yêu cầu đã đủ,bạn không thể nhập thêm");
                    }
                }
                ConnectionUtil.Instance.CommitTransaction();
                clsUtils.MsgThongBao("Xuất thành công !");
                if (clsUtils.MsgXoa("Bạn có muốn in phiếu bảo hành cho bộ linh kiện không ?") == System.Windows.Forms.DialogResult.Yes)
                {
                    List<ChungTuNhapNccChiTietHangHoaInfo> lst = new List<ChungTuNhapNccChiTietHangHoaInfo>();
                    lst.AddRange(liMaVach);
                    frmChonBaoCao frm1 = new frmChonBaoCao(true);
                    frm1.ShowDialog();
                    if (frm1.DialogResult == DialogResult.OK)
                    {
                        if (frm1.Value == 1)
                        {
                            DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(txtMaThanhPham.Text.Trim());
                            foreach (ChungTuNhapNccChiTietHangHoaInfo pt in lst)
                            {
                                pt.ThoiHanBH = sp.BaoHanhHang;
                            }
                            rptInPhieuBHSX rpt = new rptInPhieuBHSX(txtTenThanhPham.Text.Trim(), txtMaLenh.Text.Trim(), txtMaVachTP.Text.Trim());
                            rpt.DataSource = lst;
                            rpt.ShowPreview();
                        }
                        else
                        {
                            rptInPhieuBHSX rpt = new rptInPhieuBHSX(txtTenThanhPham.Text.Trim(), txtMaLenh.Text.Trim(), txtMaVachTP.Text.Trim());
                            rpt.DataSource = lst;
                            rpt.ShowPreview();
                        }
                    }
                }
                Clear();
                frm.LoadDuLieu();
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw ex;
            }
            
        }

        private void SaveMaVach(string MaVach,int IdSanPham)
        {
            SanXuatLenhProvier.InsertHangHoaChiTiet(new HangHoaChiTietInfo{IdSanPham = IdSanPham,MaVach = MaVach,SoLuong = 0,IdKho = Declare.IdKho});
        }

        private void Check(int index)
        {
            if (KhoXuatNccDataProvider.Instance.CheckSoLuong(Declare.IdKho, lisx[index].IdLinhKien, txtMaVach.Text.Trim()) == false)
            {
                throw new ManagedException("Mã vạch hiện không có trong kho. Xin hãy kiểm tra lại !");
            }
            //if (TblHangHoaChiTietDataProvider.IsUsedForAnotherProduct(txtMaVach.Text.Trim(), lisx[index].IdLinhKien))
            //{
            //    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
            //}
            //if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(lisx[index].IdLinhKien, txtMaVach.Text.Trim()) > 0)
            //{
            //    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
            //}
            if (lisx[index].SoLuongDaQuet >= Convert.ToInt32(lisx[index].SoLuongTrenTPham))
            {
                throw new ManagedException("Số lượng mã vạch của linh kiện : " + lisx[index].TenLinhKien + " đã đủ. Không thể nhập thêm !");
            }
            for (int i = 0; i < liMaVach.Count; i++)
            {
                if (txtMaVach.Text.Trim() == liMaVach[i].MaVach && lisx[index].IdLinhKien != liMaVach[i].IdSanPham)
                {
                    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                }
            }
           
        }

        private void CheckMaThanhPham()
        {
            if (check == 0 && isXuatLoi == false)
            {
                SoLuongTPham = 0;
                SoLuongMaVach = 0;
                for (int i = 0; i < lisx.Count; i++)
                {
                    SoLuongTPham = SoLuongTPham + lisx[i].SoLuongTrenTPham;
                }
                for (int i = 0; i < liMaVach.Count; i++)
                {
                    SoLuongMaVach = SoLuongMaVach + liMaVach[i].SoLuong;
                }
                if (SoLuongTPham == SoLuongMaVach)
                {
                    txtMaVachTP.Enabled = true;
                    txtMaVachTP.Focus();
                }
                else
                {
                    txtMaVachTP.Enabled = false;
                }
            }
        }

        private void Them()
        {
            string MaVach = "";
            if (HangHoa == null)
            {
                throw new ManagedException("Xin hãy chọn linh kiện để nhập mã vạch !");
            }
            if (txtMaVach.Text == "")
            {
                throw new ManagedException("Mã vạch không được để trống !");
            }
            else
            {
                sanpham = BangGiaReportDataProvider.Instance.SanPhamGetByMaVach(txtMaVach.Text.Trim());
                //if (sanpham != null)
                //{
                //    if (sanpham.TrungMaVach == 1)
                //    {
                //        colSoLuong.ReadOnly = false;
                //    }
                //}
                MaVach = txtMaVach.Text.Trim();
                if (liMaVach.Count > 0)
                {
                    foreach (ChungTuNhapNccChiTietHangHoaInfo pt in liMaVach)
                    {
                        SanXuatCTietLenhInfo info = lisx.Find(
                            delegate(SanXuatCTietLenhInfo match)
                            {
                                return match.MaLinhKien == pt.MaSanPham;
                            });

                        if (pt.SoLuong < info.SoLuongTrenTPham && pt.MaVach == txtMaVach.Text.Trim() && pt.TrungMaVach == 1)
                        {
                            pt.SoLuong = pt.SoLuong + 1;
                            info.SoLuongDaQuet = info.SoLuongDaQuet + 1;
                            ChungTuNhapNccChiTietHangHoaInfo ct = XLKBussiness.ListChiTietHangHoa.Find(delegate (ChungTuNhapNccChiTietHangHoaInfo marth)
                                                                                                           {
                                                                                                               return marth.MaVach == pt.MaVach 
                                                                                                                   && marth.IdSanPham == pt.IdSanPham;
                                                                                                           });
                            XLKBussiness.ListChiTietHangHoa[XLKBussiness.ListChiTietHangHoa.IndexOf(ct)].SoLuong =
                            XLKBussiness.ListChiTietHangHoa[XLKBussiness.ListChiTietHangHoa.IndexOf(ct)].SoLuong + 1;
                            CheckMaThanhPham();
                            txtMaVach.Text = "";
                            txtMaVach.Focus(); 
                            return;
                        }
                        if (pt.MaVach == txtMaVach.Text.Trim() && pt.TrungMaVach == 0)
                        {
                            throw new ManagedException("Mã vạch không được trùng nhau !");
                        }
                    }
                }
                if (sanpham != null)
                {
                    int check =0;
                    for (int i = 0; i < lisx.Count; i++)
                    {
                        if (sanpham.IdSanPham == lisx[i].IdLinhKien)
                        {
                            check = 1;
                            Check(i);
                            liMaVach.Add(new ChungTuNhapNccChiTietHangHoaInfo
                            {
                                MaVach = txtMaVach.Text.Trim(),
                                TenDonViTinh = lisx[i].DonViTinh,
                                SoLuong = 1,
                                IdSanPham = lisx[i].IdLinhKien,
                                TenSanPham = lisx[i].TenLinhKien,
                                MaSanPham = lisx[i].MaLinhKien,
                                TrungMaVach = lisx[i].TrungMaVach,
                                ThoiHanBH = lisx[i].thoiHanBH
                            });
                            XLKBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                            {
                                MaVach = txtMaVach.Text.Trim(),
                                TenDonViTinh = lisx[i].DonViTinh,
                                SoLuong = 1,
                                IdSanPham = lisx[i].IdLinhKien,
                                TenSanPham = lisx[i].TenLinhKien,
                                MaSanPham = lisx[i].MaLinhKien,
                                TrungMaVach = lisx[i].TrungMaVach,
                                ThoiHanBH = lisx[i].thoiHanBH
                            });
                            lisx[i].SoLuongDaQuet = lisx[i].SoLuongDaQuet + 1;
                        }
                    }
                    if (check == 0)
                    {
                        txtMaVach.Text = "";
                        txtMaVach.Focus();
                        throw new ManagedException("Không tồn tại linh kiện nào trong thành phẩm có mã vạch là : " + MaVach + " !");
                    }
                    txtMaVach.Text = "";
                    txtMaVach.Focus();
                }
                else
                {
                    txtMaVach.Text = "";
                    txtMaVach.Focus();
                    throw new ManagedException("Không tồn tại mã vạch : " + MaVach + " hoặc mã vạch đã hết tồn !");
                }
            }
            dgvMaVach.DataSource = null;
            dgvMaVach.DataSource = liMaVach;
            //if (dgvMaVach.DataSource != null)
            //    (dgvMaVach.DataSource as BindingList<ChungTuNhapNccChiTietHangHoaInfo>).ResetBindings();

            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = lisx;
            CheckMaThanhPham();
        }

        private void GetSoPhieu()
        {
            SoPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatLinhKien);
            SoPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapTP);
        }

        private void checkLinhKien()
        {
            ChungTu_ChiTietInfo chungtu =
                SanXuatLenhProvier.ChungTuCTGetByMaVach(Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX),
                                                        txtMaVach.Text.Trim());
            sanpham = BangGiaReportDataProvider.Instance.SanPhamGetByMaVach(txtMaVach.Text.Trim());
            if (sanpham != null)
            {
                if (chungtu != null && sanpham.TrungMaVach == 0)
                {
                    ChungTuNhapNccChiTietHangHoaInfo ct = SanXuatLenhProvier.ChungTuGetSoChungTuGoc(chungtu.IdChungTu);
                    if (ct != null)
                    {
                        if (ct.SoChungTugoc.Equals(txtMaLenh.Text.Trim()))
                        {
                            ChungTuNhapNccChiTietHangHoaInfo mv = SanXuatLenhProvier.CheckMaVach(txtMaVach.Text.Trim());
                            if (mv != null)
                            {
                                if (clsUtils.MsgXoa("Mã vạch linh kiện đã tồn tại trong 1 thành phẩm ! bạn có muốn hiện thị thành phẩm này không ?") == DialogResult.Yes)
                                {
                                    isXuatLoi = true;
                                    liMaVach.Clear();
                                    liMaVach = SanXuatLenhProvier.GetLinhKiemSXbyIdChungTu(chungtu.IdChungTu);
                                    dgvMaVach.DataSource = null;
                                    dgvMaVach.DataSource = liMaVach;
                                    txtMaVachTP.Text = liMaVach[0].MaVachThanhPham;
                                    for (int i = 0; i < lisx.Count; i++)
                                    {
                                        for (int j = 0; j < liMaVach.Count; j++)
                                        {
                                            if (lisx[i].IdLinhKien == liMaVach[j].IdSanPham)
                                            {
                                                lisx[i].SoLuongDaQuet = lisx[i].SoLuongDaQuet + liMaVach[j].SoLuong;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    txtMaVach.Text = "";
                                    txtMaVach.Focus();
                                }
                            }
                            else
                            {
                                txtMaVach.Text = "";
                                txtMaVach.Focus();
                                throw new ManagedException("Mã vạch đã hết tồn trong kho !");
                            }
                        }
                        else
                        {
                            Them();
                        }
                    }
                    else
                    {
                        Them();
                    }
                }
                else
                {
                    Them();
                }
            }
            else
            {
                Them();
            }
        }


        #endregion

        private void frmChiTietNhapThanhPham_Load(object sender, EventArgs e)
        {
            try
            {
                txtMaVach.Focus();
                btnNhap.Text = Resources.btnSave;
                LoadData();
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
                dtNgayLap.Enabled = false;
                GetSoPhieu();
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

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            HangHoa.IdSanPham = lisx[e.RowIndex].IdLinhKien;
            HangHoa.TenSanPham = lisx[e.RowIndex].TenLinhKien;
            HangHoa.SoLuong = lisx[e.RowIndex].SoLuongTrenTPham;
            HangHoa.TrungMaVach = lisx[e.RowIndex].TrungMaVach;
            HangHoa.DonGia = 0;
            HangHoa.DonViTinh = lisx[e.RowIndex].DonViTinh;
            Index = e.RowIndex;
            liChiTiet = XLKBussiness.GetListChiTietHangHoaByIdSanPham(lisx[e.RowIndex].IdLinhKien);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtSoLuongCT.Text) <= Convert.ToInt32(txtSoLuongYC.Text))
                {
                    Save();
                }
                else
                {
                    throw new ManagedException("Số lượng yêu cầu đã đủ, không thể nhập thêm!");
                }
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //checkLinhKien();
                Them();
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

        private void frmChiTietNhapThanhPham_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsUtils.MsgXoa("Bạn có chắc chắn xóa không ?") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (dgvMaVach.CurrentRow != null)
                    {
                        int idsanpham = liMaVach[dgvMaVach.CurrentRow.Index].IdSanPham;
                        int soluongdaxuat = liMaVach[dgvMaVach.CurrentRow.Index].SoLuong;
                        for (int i = 0; i < lisx.Count; i++)
                        {
                            if (lisx[i].IdLinhKien == idsanpham)
                            {
                                lisx[i].SoLuongDaQuet = lisx[i].SoLuongTrenTPham - soluongdaxuat;
                            }
                        }
                        ChungTuNhapNccChiTietHangHoaInfo ct =
                            XLKBussiness.ListChiTietHangHoa.Find(delegate(ChungTuNhapNccChiTietHangHoaInfo math)
                            {
                                return math.MaVach == liMaVach[dgvMaVach.CurrentRow.Index].MaVach &&
                                    math.IdSanPham == liMaVach[dgvMaVach.CurrentRow.Index].
                                        IdSanPham;
                            });
                        XLKBussiness.ListChiTietHangHoa.Remove(ct);
                        liMaVach.RemoveAt(dgvMaVach.CurrentRow.Index);
                    }
                    //dgvMaVach.DataSource = null;
                    //dgvMaVach.DataSource = liMaVach;
                    //if (dgvMaVach.DataSource != null)
                    //    (dgvMaVach.DataSource as BindingList<ChungTuNhapNccChiTietHangHoaInfo>).ResetBindings();
                    dgvMaVach.DataSource = null;
                    dgvMaVach.DataSource = liMaVach;

                    CheckMaThanhPham();
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteLog(ex.ToString()
                    + "\nUser: " + Declare.UserName
                    + "\nKho: " + Declare.IdKho,
                    this.Name);
            }
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Them();
                    //checkLinhKien();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }
        }

        private void btnNhap_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            frmChonBaoCao frm = new frmChonBaoCao(true);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                if (frm.Value == 1)
                {
                    DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(txtMaThanhPham.Text.Trim());
                    foreach (ChungTuNhapNccChiTietHangHoaInfo pt in liMaVach)
                    {
                        if (pt.ThoiHanBH != 0) pt.ThoiHanBH = sp.BaoHanhHang;
                    }
                    rptInPhieuBHSX rpt = new rptInPhieuBHSX(txtTenThanhPham.Text.Trim(), txtMaLenh.Text.Trim(), txtMaVachTP.Text.Trim());
                    rpt.DataSource = liMaVach;
                    rpt.ShowPreview();
                }
                else
                {
                    rptInPhieuBHSX rpt = new rptInPhieuBHSX(txtTenThanhPham.Text.Trim(), txtMaLenh.Text.Trim(), txtMaVachTP.Text.Trim());
                    rpt.DataSource = liMaVach;
                    rpt.ShowPreview();
                }
            }
        }

        private void btnDoiLinhKien_Click(object sender, EventArgs e)
        {
            try
            {
                throw new ManagedException("Chức năng này chưa được thực hiện.");

                if(dgvMaVach.CurrentRow == null)
                    throw new ManagedException("Bạn chưa chọn serial cần đổi.");

                ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo =
                    (ChungTuNhapNccChiTietHangHoaInfo) dgvMaVach.CurrentRow.DataBoundItem;
                
                //frmDoiMaLinhKien frmDoiMaLinhKien = new frmDoiMaLinhKien(chiTietHangHoaInfo);
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