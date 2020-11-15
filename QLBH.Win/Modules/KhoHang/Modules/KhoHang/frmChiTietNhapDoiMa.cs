using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Providers;
using DmSanPhamProvider = QLBanHang.Modules.DanhMuc.Providers.DmSanPhamProvider;
using QLBH.Core.Exceptions;

//using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTietNhapDoiMa : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        private XuatDoiMaBussiness XDMBussiness;
        private NhapDoiMaBussiness NDMBussiness;
        List<ChungTuNhapNccChiTietHangHoaInfo> lstCheck = new List<ChungTuNhapNccChiTietHangHoaInfo>();
        private BangGiaReportInfo sanpham;
        private string MaSanPham;
        public string MaTrungTam;
        public int Index;
        private bool isXuatLoi = false;
        private string MaLenh;
        frmDanhSachNhapDoiMa frmDM = new frmDanhSachNhapDoiMa();
        frmDanhSachNhapComBo frmCB = new frmDanhSachNhapComBo();
        frmTimKiemMaVach frm1 = new frmTimKiemMaVach();
        List<SanXuatCTietLenhInfo> lisx = new List<SanXuatCTietLenhInfo>();
        List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach = new List<ChungTuNhapNccChiTietHangHoaInfo>();
        public ChungTuCTHanghoaBasePairInfo HangHoa = new ChungTuCTHanghoaBasePairInfo();
        public List<ChungTuNhapNccChiTietHangHoaInfo> liChiTiet;
        private int SLCT;
        private int check;
        private int SoLuongTPham = 0;
        private int SoLuongMaVach = 0;
        private string soPhieuXuat, soPhieuNhap;
        #endregion

        #region frmChiTietNhapDoiMa
        public frmChiTietNhapDoiMa(frmDanhSachNhapDoiMa frm,string MaLenh,int check,string MaTrungTam)
        {
            this.MaTrungTam = MaTrungTam;
            this.frmDM = frm;
            this.MaLenh = MaLenh;
            this.check = check;
            InitializeComponent();
            XDMBussiness = new XuatDoiMaBussiness(new ChungTuXuatNhapNccInfo());
            NDMBussiness = new NhapDoiMaBussiness(new ChungTuXuatNhapNccInfo());
            if (check == 0)
            {
                soPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatComBo);
                soPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapComBo);
            }
            else if (check == 1)
            {
                soPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDoiMa);
                soPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapDoiMa);
            }
        }
        public frmChiTietNhapDoiMa(frmDanhSachNhapComBo frm, string MaLenh, int check,string MaTrungTam)
        {
            this.MaTrungTam = MaTrungTam;
            this.frmCB = frm;
            this.MaLenh = MaLenh;
            this.check = check;
            InitializeComponent();
            XDMBussiness = new XuatDoiMaBussiness(new ChungTuXuatNhapNccInfo());
            NDMBussiness = new NhapDoiMaBussiness(new ChungTuXuatNhapNccInfo());
            if (check == 0)
            {
                soPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatComBo);
                soPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapComBo);
            }
            else if (check == 1)
            {
                soPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDoiMa);
                soPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapDoiMa);
            }
        }
        public frmChiTietNhapDoiMa(frmTimKiemMaVach frm, string MaLenh, List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach, ChungTuXuatNhapNccInfo ct, int check)
        {
            InitializeComponent();
            this.frm1 = frm;
            this.MaLenh = MaLenh;
            this.liMaVach = liMaVach;
            this.check = check;
            XDMBussiness = new XuatDoiMaBussiness(ct);
            NDMBussiness = new NhapDoiMaBussiness(ct);
            if (check == 0)
            {
                soPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatComBo);
                soPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapComBo);
            }
            else if (check == 1)
            {
                soPhieuXuat = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuXuatDoiMa);
                soPhieuNhap = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuNhapDoiMa);
            }
        }
        #endregion

        #region Action
        private void LoadData()
        {
            txtMaVach.Focus();
            lisx = SanXuatCTietLenhProvider.GetSanXuatLenhByMaLenh(MaLenh,MaTrungTam);
            if (lisx.Count == 0)
            {
                throw new ManagedException("Mã linh kiện không có trong hệ thống !");
            }
            txtMaVachTP.Enabled = false;
            if (check == 0)
            {
                btnXacNhan.Visible = false;
                txtMaLenh.Text = frmCB.MaLenh;
                txtMaThanhPham.Text = frmCB.MaThanhPham;
                txtTenThanhPham.Text = frmCB.TenThanhPham;
                txtSoLuongYC.Text = frmCB.SoLuongYC.ToString();
                SLCT = frmCB.SoLuongCT;
            }
            else if (check == 1)
            {
                btnXacNhan.Visible = true;
                txtMaLenh.Text = frmDM.MaLenh;
                txtMaThanhPham.Text = frmDM.MaThanhPham;
                txtTenThanhPham.Text = frmDM.TenThanhPham;
                txtSoLuongYC.Text = frmDM.SoLuongYC.ToString();
                SLCT = frmDM.SoLuongCT;
                if (Convert.ToInt32(txtSoLuongYC.Text) == SLCT)
                {
                    btnXacNhan.Enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < lisx.Count; i++)
                {
                    lisx[i].SoLuongDaQuet = lisx[i].SoLuongTrenTPham;
                }
                txtMaLenh.Text = frm1.MaLenh;
                txtMaThanhPham.Text = frm1.MaThanhPham;
                txtTenThanhPham.Text = frm1.TenThanhPham;
                txtSoLuongYC.Text = frm1.SoLuongYC.ToString();
                SLCT = frm1.SoLuongDN;
                txtMaVachTP.Text = frm1.MaVachThanhPham;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
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
            liChiTiet = XDMBussiness.GetListChiTietHangHoaByIdSanPham(lisx[0].IdLinhKien);
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
            XDMBussiness = new XuatDoiMaBussiness(new ChungTuXuatNhapNccInfo());
            NDMBussiness = new NhapDoiMaBussiness(new ChungTuXuatNhapNccInfo());
            for (int i = 0; i < lisx.Count; i++)
            {
                lisx[i].SoLuongDaQuet = 0;
            }
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = lisx;
            txtMaVach.Focus();
        }

        private void SaveXuatDoiMa(string NhapThanhPhan)
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = XDMBussiness.ChungTu;
            chungTuXuatNhapNccInfo.SoPO = NhapThanhPhan;
            chungTuXuatNhapNccInfo.SoPhieuNhap = NhapThanhPhan;

            if (check == 0)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_COMBO);
            }
            else if (check == 1)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DOIMA);
            }
            chungTuXuatNhapNccInfo.SoChungTu = soPhieuXuat;
            chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
            chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
            chungTuXuatNhapNccInfo.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue);
            chungTuXuatNhapNccInfo.TrangThai = 1;
            chungTuXuatNhapNccInfo.NgayXuatHang = Convert.ToDateTime(dtNgayLap.EditValue);

            XDMBussiness.ListChiTietChungTu.Clear();
            XDMBussiness.ListChiTietHangHoa.Clear();
            for (int i = 0; i < lisx.Count; i++)
            {
                XDMBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                {
                    IdSanPham = lisx[i].IdLinhKien,
                    TenSanPham = lisx[i].TenLinhKien,
                    MaSanPham = lisx[i].MaLinhKien,
                    TenDonViTinh = lisx[i].DonViTinh,
                    SoLuong = lisx[i].SoLuongTrenTPham
                });
            }
            for (int i = 0; i < liMaVach.Count; i++)
            {
                XDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                {
                    IdSanPham = liMaVach[i].IdSanPham,
                    SoLuong = liMaVach[i].SoLuong,
                    MaVach = liMaVach[i].MaVach
                });
            }
            XDMBussiness.SaveChungTu();
        }

        private void SaveXuatDoiMaImport(string NhapThanhPhan,DataTable dt,int soluong)
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = XDMBussiness.ChungTu;
            chungTuXuatNhapNccInfo.SoPO = NhapThanhPhan;
            chungTuXuatNhapNccInfo.SoPhieuNhap = NhapThanhPhan;

            if (check == 0)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_COMBO);
            }
            else if (check == 1)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DOIMA);
            }

            chungTuXuatNhapNccInfo.SoChungTu = soPhieuXuat;
            chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
            chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
            chungTuXuatNhapNccInfo.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue);
            chungTuXuatNhapNccInfo.TrangThai = 1;
            chungTuXuatNhapNccInfo.NgayXuatHang = Convert.ToDateTime(dtNgayLap.EditValue);

            XDMBussiness.ListChiTietChungTu.Clear();
            XDMBussiness.ListChiTietHangHoa.Clear();
            for (int i = 0; i < lisx.Count; i++)
            {
                XDMBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                {
                    IdSanPham = lisx[i].IdLinhKien,
                    TenSanPham = lisx[i].TenLinhKien,
                    MaSanPham = lisx[i].MaLinhKien,
                    TenDonViTinh = lisx[i].DonViTinh,
                    SoLuong = soluong
                });
            }
            if (dt.Rows.Count > 0)
            {
                lstCheck.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int soluonglk = 0;
                    dt.DefaultView.RowFilter = String.Format("MaVachLK = '{0}'",dt.Rows[i]["MaVachLK"]);
                    DataTable tableTemp = dt.DefaultView.ToTable("Temp");
                    for (int j = 0; j < tableTemp.Rows.Count; j++)
                    {
                        soluonglk += Convert.ToInt32(tableTemp.Rows[j]["SoLuongLK"]);
                    }
                    if (lstCheck.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
                        {
                            return ct.MaVach == dt.Rows[i]["MaVachLK"].ToString() && ct.MaSanPham == dt.Rows[i]["MaLinhKien"].ToString();
                        }).Count == 0)
                    {
                        XDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                        {
                            IdSanPham = lisx[0].IdLinhKien,
                            SoLuong = soluonglk,
                            MaVach = dt.Rows[i]["MaVachLK"].ToString().Trim()
                        });
                        lstCheck.Add(new ChungTuNhapNccChiTietHangHoaInfo { MaSanPham = dt.Rows[i]["MaLinhKien"].ToString(), MaVach = dt.Rows[i]["MaVachLK"].ToString() });
                    }
                }
            }
            //else if (dt.Rows.Count == 1)
            //{
            //    XDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
            //    {
            //        IdSanPham = lisx[0].IdLinhKien,
            //        SoLuong = soluong,
            //        MaVach = dt.Rows[0]["MaVachLK"].ToString().Trim()
            //    });
            //}
            XDMBussiness.SaveChungTu();
        }

        private string SaveNhapDoiMa()
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = NDMBussiness.ChungTu;
            chungTuXuatNhapNccInfo.SoPO = txtMaLenh.Text.Trim();
            chungTuXuatNhapNccInfo.SoPhieuNhap = txtMaLenh.Text.Trim();

            if (check == 0)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_COMBO);
            }
            else if (check == 1)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_DOIMA);
            }

            chungTuXuatNhapNccInfo.SoChungTu = soPhieuNhap;
            chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
            chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
            chungTuXuatNhapNccInfo.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue);
            chungTuXuatNhapNccInfo.TrangThai = 1;
            chungTuXuatNhapNccInfo.NgayXuatHang = Convert.ToDateTime(dtNgayLap.EditValue);

            NDMBussiness.ListChiTietChungTu.Clear();
            NDMBussiness.ListChiTietHangHoa.Clear();
            if (check == 0)
            {
                NDMBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                {
                    IdSanPham = frmCB.idThanhPham,
                    MaSanPham = frmCB.MaThanhPham,
                    SoLuong = 1,
                    DanhSachMaVach = txtMaVachTP.Text.Trim()
                });
                NDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                {
                    IdSanPham = frmCB.idThanhPham,
                    SoLuong =1,
                    MaVach = txtMaVachTP.Text.Trim()
                });
            }
            else
            {
                NDMBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                {
                    IdSanPham = frmDM.idThanhPham,
                    MaSanPham = frmDM.MaThanhPham,
                    SoLuong = 1,
                    DanhSachMaVach = txtMaVachTP.Text.Trim()
                });
                NDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                {
                    IdSanPham = frmDM.idThanhPham,
                    SoLuong = 1,
                    MaVach = txtMaVachTP.Text.Trim()
                });
            }
            NDMBussiness.SaveChungTu();
            return chungTuXuatNhapNccInfo.SoChungTu;
        }

        private string SaveNhapDoiMaImport(DataTable dt,int soluong)
        {
            ChungTuXuatNhapNccInfo chungTuXuatNhapNccInfo = NDMBussiness.ChungTu;
            chungTuXuatNhapNccInfo.SoPO = txtMaLenh.Text.Trim();
            chungTuXuatNhapNccInfo.SoPhieuNhap = txtMaLenh.Text.Trim();

            if (check == 0)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_COMBO);
            }
            else if (check == 1)
            {
                chungTuXuatNhapNccInfo.LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_DOIMA);
            }
            chungTuXuatNhapNccInfo.SoChungTu = soPhieuNhap;
            chungTuXuatNhapNccInfo.IdKho = Declare.IdKho;
            chungTuXuatNhapNccInfo.IdNhanVien = Declare.IdNhanVien;
            chungTuXuatNhapNccInfo.NgayLap = Convert.ToDateTime(dtNgayLap.EditValue);
            chungTuXuatNhapNccInfo.TrangThai = 1;
            chungTuXuatNhapNccInfo.NgayXuatHang = Convert.ToDateTime(dtNgayLap.EditValue);

            NDMBussiness.ListChiTietChungTu.Clear();
            NDMBussiness.ListChiTietHangHoa.Clear();
            if (check == 0)
            {
                NDMBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                {
                    IdSanPham = frmCB.idThanhPham,
                    MaSanPham = frmCB.MaThanhPham,
                    SoLuong = soluong,
                    DanhSachMaVach = txtMaVachTP.Text.Trim()
                });
                //if (dt.Rows.Count > 1)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        NDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                //        {
                //            IdSanPham = frmCB.idThanhPham,
                //            SoLuong = Convert.ToInt32(dt.Rows[i]["SoLuongTP"].ToString()),
                //            MaVach = dt.Rows[i]["MaVachTP"].ToString().Trim()
                //        });
                //    }
                //}
                //else if (dt.Rows.Count == 1)
                //{
                //    NDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                //    {
                //        IdSanPham = frmCB.idThanhPham,
                //        SoLuong = soluong,
                //        MaVach = dt.Rows[0]["MaVachTP"].ToString().Trim()
                //    });
                //}
                if (dt.Rows.Count > 0)
                {
                    lstCheck.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int soluonglk = 0;
                        dt.DefaultView.RowFilter = String.Format("MaVachTP = '{0}'", dt.Rows[i]["MaVachTP"]);
                        DataTable tableTemp = dt.DefaultView.ToTable("Temp");
                        for (int j = 0; j < tableTemp.Rows.Count; j++)
                        {
                            soluonglk += Convert.ToInt32(tableTemp.Rows[i]["SoLuongTP"]);
                        }
                        if (lstCheck.FindAll(delegate(ChungTuNhapNccChiTietHangHoaInfo ct)
                        {
                            return ct.MaVach == dt.Rows[i]["MaVachTP"].ToString() && ct.MaSanPham == dt.Rows[i]["MaThanhPham"].ToString();
                        }).Count == 0)
                        {
                            XDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                            {
                                IdSanPham = lisx[0].IdLinhKien,
                                SoLuong = soluonglk,
                                MaVach = dt.Rows[i]["MaVachTP"].ToString().Trim()
                            });
                            lstCheck.Add(new ChungTuNhapNccChiTietHangHoaInfo { MaSanPham = dt.Rows[i]["MaThanhPham"].ToString(), MaVach = dt.Rows[i]["MaVachTP"].ToString() });
                        }
                    }
                }
            }
            else
            {
                NDMBussiness.ListChiTietChungTu.Add(new ChungTuXuatNhapNccChiTietInfo
                {
                    IdSanPham = frmDM.idThanhPham,
                    MaSanPham = frmDM.MaThanhPham,
                    SoLuong = soluong,
                    DanhSachMaVach = txtMaVachTP.Text.Trim()
                });
                if (dt.Rows.Count > 1)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                        {
                            IdSanPham = frmDM.idThanhPham,
                            SoLuong = Convert.ToInt32(dt.Rows[i]["SoLuongTP"].ToString()),
                            MaVach = dt.Rows[i]["MaVachTP"].ToString().Trim()
                        });
                    }
                }
                else if (dt.Rows.Count == 1)
                {
                    NDMBussiness.ListChiTietHangHoa.Add(new ChungTuNhapNccChiTietHangHoaInfo
                    {
                        IdSanPham = frmDM.idThanhPham,
                        SoLuong = soluong,
                        MaVach = dt.Rows[0]["MaVachTP"].ToString().Trim()
                    });
                }
            }
            NDMBussiness.SaveChungTu();
            return chungTuXuatNhapNccInfo.SoChungTu;
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

            //hah: check số lượng hoàn thành vượt quá số lượng yêu cầu
            int SoLuongCT = 0;
            if (check == 0)
            {
                SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(Convert.ToInt32(TransactionType.NHAP_COMBO),
                MaLenh, MaTrungTam);
            }
            if (check == 1)
            {
                SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(Convert.ToInt32(TransactionType.NHAP_DOIMA),
                MaLenh, MaTrungTam);
            }
            //if (Convert.ToInt32(txtSoLuongYC.Text) == Convert.ToInt32(txtSoLuongCT.Text))
            if (Convert.ToInt32(txtSoLuongYC.Text) <= SoLuongCT)
            {
                throw new ManagedException("Số lượng yêu cầu đã đủ, bạn không thể nhập thêm");
            }

            if ( isXuatLoi == false)
            {
                if (check == 0)
                {
                    //if (TblHangHoaChiTietDataProvider.IsUsedForAnotherProduct(txtMaVachTP.Text.Trim(), frmCB.idThanhPham))
                    //{
                    //    throw new InvalidOperationException("Mã vạch thành phẩm đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    //}
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachTP(frmCB.idThanhPham, txtMaVachTP.Text.Trim()) > 0)
                    {
                        throw new ManagedException("Mã vạch thành phẩm đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(frmCB.idThanhPham, txtMaVachTP.Text.Trim()) > 0)
                    {
                        throw new ManagedException("Mã vạch thành phẩm đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                }
                else if (check == 1)
                {
                    //if (TblHangHoaChiTietDataProvider.IsUsedForAnotherProduct(txtMaVachTP.Text.Trim(), frmCB.idThanhPham))
                    //{
                    //    throw new InvalidOperationException("Mã vạch thành phẩm đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    //}
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachTP(frmDM.idThanhPham, txtMaVachTP.Text.Trim()) > 0)
                    {
                        throw new ManagedException("Mã vạch thành phẩm đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(frmDM.idThanhPham, txtMaVachTP.Text.Trim()) > 0)
                    {
                        throw new ManagedException("Mã vạch thành phẩm đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
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
            if (check == 0)
            {
                if (Convert.ToDateTime(dtNgayLap.EditValue) < frmCB.NgayLap)
                {
                    dtNgayLap.Focus();
                    throw new ManagedException("Ngày xuất linh kiện không được nhỏ hơn ngày lập của mã lệnh !");
                }
            }
            if (check == 1)
            {
                if (Convert.ToDateTime(dtNgayLap.EditValue) < frmCB.NgayLap)
                {
                    dtNgayLap.Focus();
                    throw new ManagedException("Ngày xuất linh kiện không được nhỏ hơn ngày lập của mã lệnh !");
                } 
            }
            try
            {
                ConnectionUtil.Instance.BeginTransaction();
                SaveXuatDoiMa(SaveNhapDoiMa());
                SLCT++;
                txtSoLuongCT.Text = SLCT.ToString();

                //hah: check số lượng hoàn thành vượt quá số lượng yêu cầu
                if (check == 0)
                {
                    SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(Convert.ToInt32(TransactionType.NHAP_COMBO),
                    MaLenh, MaTrungTam);
                }
                if (check == 1)
                {
                    SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(Convert.ToInt32(TransactionType.NHAP_DOIMA),
                    MaLenh, MaTrungTam);
                }

                //if (Convert.ToInt32(txtSoLuongYC.Text) == Convert.ToInt32(txtSoLuongCT.Text))
                if (Convert.ToInt32(txtSoLuongYC.Text) < SoLuongCT)
                {
                    throw new ManagedException("Số lượng yêu cầu đã đủ, bạn không thể nhập thêm");
                }

                //UpdateSoLuongDaXuat();
                if (check == 0)
                {
                    if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.NHAP_COMBO), txtMaLenh.Text.Trim(), 0) > 0)
                    {
                        SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo { MaLenh = txtMaLenh.Text.Trim(), MaThanhPham = txtMaThanhPham.Text.Trim(), TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX) });
                    }
                    
                }
                else if (check == 1)
                {
                    if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.NHAP_DOIMA), txtMaLenh.Text.Trim(), 0) > 0)
                    {
                        SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo { MaLenh = txtMaLenh.Text.Trim(), MaThanhPham = txtMaThanhPham.Text.Trim(), TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX) });
                    }
                    
                }
                ConnectionUtil.Instance.CommitTransaction();
                if (check == 0)
                {
                    Clear();
                    frmCB.Reload();
                }
                else if (check == 1)
                {
                    Clear();
                    frmDM.LoadDuLieu();
                }
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw ex;
            }

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
                throw new ManagedException("Số lượng mã vạch linh kiện : " + lisx[index].MaLinhKien + " đã đủ. Không thể nhập thêm !");
            }
            for (int i = 0; i < liMaVach.Count; i++)
            {
                if (txtMaVach.Text.Trim() == liMaVach[i].MaVach && lisx[index].IdLinhKien != liMaVach[i].IdSanPham)
                {
                    throw new ManagedException("Mã vạch đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                }
            }

        }

        private void CheckMaThanhPhan()
        {
            if (isXuatLoi == false)
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
            //if (HangHoa == null)
            //{
            //    throw new InvalidOperationException("Xin hãy chọn linh kiện để nhập mã vạch !");
            //}
            if (txtMaVach.Text == "")
            {
                throw new ManagedException("Mã vạch không được để trống !");
            }
            else
            {
                
                MaVach = txtMaVach.Text.Trim();
                if (liMaVach.Count > 0)
                {
                    foreach (ChungTuNhapNccChiTietHangHoaInfo pt in liMaVach)
                    {
                        if (pt.SoLuong <lisx[Index].SoLuongDaQuet &&  pt.MaVach == txtMaVach.Text.Trim() && pt.TrungMaVach == 1 )
                        {
                            pt.SoLuong = pt.SoLuong + 1;
                            lisx[Index].SoLuongDaQuet = lisx[Index].SoLuongDaQuet + 1;
                            CheckMaThanhPhan();
                            return;
                        }
                        if (pt.MaVach == txtMaVach.Text.Trim() && pt.TrungMaVach == 0)
                        {
                            throw new ManagedException("Mã vạch không được trùng nhau !");
                        }
                    }
                }
                sanpham = BangGiaReportDataProvider.Instance.SanPhamGetByMaVach(txtMaVach.Text.Trim());
                if (sanpham != null)
                {
                    int check = 0;
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
                                TrungMaVach = lisx[i].TrungMaVach
                            });
                            lisx[i].SoLuongDaQuet = lisx[i].SoLuongDaQuet + 1;
                            break;
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
            CheckMaThanhPhan();
        }

        private int CheckSoLuongTP(DataSet ds,string malinhkien,int SoLuongYeuCau)
        {
            int SoLuongImport = 0;
            ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaThanhPham='{0}'", malinhkien);
            DataTable tableTemp = ds.Tables["HangHoaChiTiet"].DefaultView.ToTable("Temp");
            ds.Tables["CheckTrungMaVachTP"].DefaultView.RowFilter = String.Format("MaThanhPham='{0}' and SoLuongTP > 1", malinhkien);
            DataTable tblCheck = ds.Tables["CheckTrungMaVachTP"].DefaultView.ToTable("Temp");
            DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(malinhkien);
            if (sp != null)
            {
                if (sp.TrungMaVach == 0)
                {
                    if (tblCheck.Rows.Count > 0)
                    {
                        throw new InvalidOperationException("Mã sản phẩm : " + sp.MaSanPham + " có mã vạch " + tblCheck.Rows[0]["MaVach"] + " bị trùng. Xin hãy kiểm tra lại !");
                    }
                }
                if (sp.SuDung == 0)
                {
                    throw new InvalidOperationException("Sản phẩm " + sp.MaSanPham + " không được sử dụng trong hệ thống !");
                }
            }
            else
            {
                throw new InvalidOperationException("Mã sản phẩm : " + malinhkien + " không có trong hệ thống.Xin hãy kiểm tra lại !");
            }
            if (tableTemp.Rows.Count > 0)
            {
                int soluongconlai = (Convert.ToInt32(txtSoLuongYC.Text) - Convert.ToInt32(txtSoLuongCT.Text))*
                                    SoLuongYeuCau;
                for (int j = 0; j < tableTemp.Rows.Count; j++)
                {
                    SoLuongImport += Convert.ToInt32(tableTemp.Rows[j]["SoLuongTP"]);
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachTP(frmDM.idThanhPham, tableTemp.Rows[j]["MaVachTP"].ToString()) > 0)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[j]["MaVachTP"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                    if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVach(frmDM.idThanhPham, tableTemp.Rows[j]["MaVachTP"].ToString()) > 0)
                    {
                        throw new InvalidOperationException("Mã vạch " + tableTemp.Rows[j]["MaVachTP"] + " đã sử dụng cho 1 sản phẩm khác. Xin hãy kiểm tra lại !");
                    }
                }
                if (SoLuongImport > soluongconlai)
                {
                    throw new InvalidOperationException("Số lượng mã vạch của mã sản phẩm : "+malinhkien+" trong file import không khớp !");
                }
            }
            else
            {
                throw new ManagedException("Không tìm thấy mã vạch của mã sản phẩm " + malinhkien + " trong file import !");
            }
            return SoLuongImport/SoLuongYeuCau;
        }

        private int CheckSoLuongLK(DataSet ds, string malinhkien, int SoLuongYeuCau)
        {
            int SoLuongImport = 0;
            ds.Tables["HangHoaChiTiet"].DefaultView.RowFilter = String.Format("MaLinhKien='{0}'", malinhkien);
            DataTable tableTemp = ds.Tables["HangHoaChiTiet"].DefaultView.ToTable("Temp");
            ds.Tables["CheckTrungMaVachLK"].DefaultView.RowFilter = String.Format("MaLinhKien='{0}' and SoLuongLK > 1", malinhkien);
            DataTable tblCheck = ds.Tables["CheckTrungMaVachLK"].DefaultView.ToTable("Temp");
            DMSanPhamInfo sp = DmSanPhamProvider.Instance.GetSanPhamByMa(malinhkien);
            if (sp != null)
            {
                if (sp.TrungMaVach == 0)
                {
                    if (tblCheck.Rows.Count > 0)
                    {
                        throw new InvalidOperationException("Mã sản phẩm : " + sp.MaSanPham + " có mã vạch " + tblCheck.Rows[0]["MaVach"] + " bị trùng. Xin hãy kiểm tra lại !");
                    }
                }
                if (sp.SuDung == 0)
                {
                    throw new InvalidOperationException("Sản phẩm " + sp.MaSanPham + " không được sử dụng trong hệ thống !");
                }
            }
            else
            {
                throw new InvalidOperationException("Mã sản phẩm : " + malinhkien + " không có trong hệ thống.Xin hãy kiểm tra lại !");
            }
            if (tableTemp.Rows.Count > 0)
            {
                int soluongconlai = (Convert.ToInt32(txtSoLuongYC.Text) - Convert.ToInt32(txtSoLuongCT.Text)) *
                                    SoLuongYeuCau;
                for (int j = 0; j < tableTemp.Rows.Count; j++)
                {
                    SoLuongImport += Convert.ToInt32(tableTemp.Rows[j]["SoLuongLK"]);
                    if (KhoXuatNccDataProvider.Instance.CheckSoLuong(Declare.IdKho, lisx[0].IdLinhKien, tableTemp.Rows[j]["MaVachLK"].ToString()) == false)
                    {
                        throw new ManagedException("Mã vạch " + tableTemp.Rows[j]["MaVachLK"] + " hiện không có trong kho. Xin hãy kiểm tra lại !");
                    }
                }
                if (SoLuongImport > soluongconlai)
                {
                    throw new InvalidOperationException("Số lượng mã vạch của mã sản phẩm : " + malinhkien + " trong file import không khớp !");
                }
            }
            else
            {
                throw new ManagedException("Không tìm thấy mã vạch của mã sản phẩm " + malinhkien + " trong file import !");
            }
            return SoLuongImport / SoLuongYeuCau;
        }

        private void GetText(DataTable dt,int soluong)
        {
            try
            {
                ConnectionUtil.Instance.BeginTransaction();
                SaveXuatDoiMaImport(SaveNhapDoiMaImport(dt, soluong), dt, soluong);
                if (check == 0)
                {
                    if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.NHAP_COMBO), txtMaLenh.Text.Trim(), 0) > 0)
                    {
                        SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo { MaLenh = txtMaLenh.Text.Trim(), MaThanhPham = txtMaThanhPham.Text.Trim(), TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX) });
                    }
                    Clear();
                    frmCB.Reload();
                }
                else if (check == 1)
                {
                    if (SanXuatLenhProvier.GetSoLuongSanXuatLenh(Declare.IdKho, Convert.ToInt32(TransactionType.NHAP_DOIMA), txtMaLenh.Text.Trim(), 0) > 0)
                    {
                        SanXuatLenhProvier.UpdateTrangThai(new SanXuatLenhInfo { MaLenh = txtMaLenh.Text.Trim(), MaThanhPham = txtMaThanhPham.Text.Trim(), TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX) });
                    }
                    Clear();
                    frmDM.LoadDuLieu();
                }
                txtSoLuongCT.Text = soluong.ToString();
                ConnectionUtil.Instance.CommitTransaction();
                clsUtils.MsgThongBao("Xuất thành công !");
            }
            catch (Exception)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                throw;
            }
        }

        private void Import(DataSet ds)
        {
            int soluongLK=0, soluongTP=0;
            if (check == 0)
            {
                soluongTP = CheckSoLuongTP(ds, frmCB.MaThanhPham,1);
            }
            else if (check == 1)
            {
                soluongTP = CheckSoLuongTP(ds, frmDM.MaThanhPham, 1);
            }
            for (int i = 0; i < lisx.Count; i++)
            {
                soluongLK = CheckSoLuongLK(ds,lisx[i].MaLinhKien,lisx[i].SoLuongTrenTPham);
            }
            if (soluongTP > Convert.ToInt32(txtSoLuongYC.Text)-Convert.ToInt32(txtSoLuongCT.Text) ||
                soluongLK > Convert.ToInt32(txtSoLuongYC.Text) - Convert.ToInt32(txtSoLuongCT.Text))
            {
                clsUtils.MsgCanhBao("Số lượng mã vạch thành phẩm/linh kiện trong file import vượt quá số lượng yêu cầu sản xuất !");
                return;
            }
            if (soluongTP != soluongLK)
            {
                clsUtils.MsgCanhBao("Số lượng mã vạch thành phẩm/linh kiện trong file import không khớp nhau !");
                return;
            }
            else
            {
                if (clsUtils.MsgXoa("số lượng mã vạch đủ để sản xuất "+ soluongLK+ "bộ ! bạn có đồng ý sản xuất ?") == DialogResult.Yes)
                {
                    GetText(ds.Tables["HangHoaChiTiet"],soluongLK);
                }
            }
        }
        #endregion

        #region Event
        private void frmChiTietNhapDoiMa_Load(object sender, EventArgs e)
        {
            try
            {
                btnXacNhan.Visible = false;
                txtMaVach.Focus();
                btnNhap.Text = Resources.btnSave;
                LoadData();
                dtNgayLap.EditValue = CommonProvider.Instance.GetSysDate();
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

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtSoLuongCT.Text) <= Convert.ToInt32(txtSoLuongYC.Text))
                {
                    Save();
                    clsUtils.MsgThongBao("Xuất thành công !");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
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
                    liMaVach.RemoveAt(dgvMaVach.CurrentRow.Index);
                }
                //dgvMaVach.DataSource = null;
                //dgvMaVach.DataSource = liMaVach;
                //if (dgvMaVach.DataSource != null)
                //    (dgvMaVach.DataSource as BindingList<ChungTuNhapNccChiTietHangHoaInfo>).ResetBindings();
                dgvMaVach.DataSource = null;
                dgvMaVach.DataSource = liMaVach;

                CheckMaThanhPhan();
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Them();
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

        private void frmChiTietNhapDoiMa_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void btnNhap_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }
        #endregion

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
                        oConn.ConnectionString =
                            String.Format(
                                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"",
                                opf.FileName);
                        oConn.Open();

                        sql =
                            "Select [MA_LINH_KIEN] as MaLinhKien, [SERIAL_LINHKIEN] as MaVachLK, [SO_LUONG_LK] as SoLuongLK,[MA_THANH_PHAM] as MaThanhPham, [SERIAL_THANHPHAM] as MaVachTP, [SO_LUONG_TP] as SoLuongTP from [Items$] where [MA_LINH_KIEN] is not null and [MA_THANH_PHAM] is not null";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "HangHoaChiTiet");
                        }
                        sql =
                            "Select [MA_THANH_PHAM] as MaThanhPham, [SERIAL_THANHPHAM] as MaVachTP, sum([SO_LUONG_TP]) as SoLuongTP from [Items$] group by [MA_THANH_PHAM],[SERIAL_THANHPHAM] having [MA_THANH_PHAM] is not null";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "CheckTrungMaVachTP");
                        }
                        sql =
                            "Select [MA_LINH_KIEN] as MaLinhKien, [SERIAL_LINHKIEN] as MaVachLK, sum([SO_LUONG_LK]) as SoLuongLK from [Items$] group by [MA_LINH_KIEN],[SERIAL_LINHKIEN] having [MA_LINH_KIEN] is not null";
                        using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, oConn))
                        {
                            ad.Fill(ds, "CheckTrungMaVachLK");
                        }
                        Import(ds);
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

        
    }
}
