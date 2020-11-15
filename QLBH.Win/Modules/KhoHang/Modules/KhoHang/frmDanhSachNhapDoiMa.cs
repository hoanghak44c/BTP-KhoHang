using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.DongBoERP;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Properties;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmDanhSachNhapDoiMa : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        private DMTrungTamInfor currentTrungTam;
        private DMKhoInfo currentKho;
        SanXuatLenhInfo sx = new SanXuatLenhInfo();
        SanXuatCTietLenhInfo sxct = new SanXuatCTietLenhInfo();
        //private bool success;
        List<SanXuatLenhInfo> litmpSX = new List<SanXuatLenhInfo>();
        List<SanXuatLenhInfo> liChiTiet;
        List<SanXuatCTietLenhInfo> litmpCT = new List<SanXuatCTietLenhInfo>();
        public string MaLenh = "";
        public string MaThanhPham;
        public string TenThanhPham;
        public int idThanhPham;
        public int SoLuongYC;
        public int SoLuongCT;
        private string MaTrungTam;
        private string MaKho;
        private int Trangthai;
        private int status;
        public DateTime NgayLap;
        #endregion


        #region frmDanhSachNhapDoiMa
        public frmDanhSachNhapDoiMa()
        {
            InitializeComponent();
            //tsbTimKiem.Visible = false;
            clsUtils.NullColumnDateTimeGrid(repdtngaylap);
            tsbTimKiem.Text = Resources.btnSearch;
            tsbEdit.Text = Resources.btnInfor;
            liChiTiet = new List<SanXuatLenhInfo>();
            dgvChiTiet.DataSource = liChiTiet;
            LoadTrangthai();
        }
        #endregion
        #region Action
        private string GetMaTrungTam()
        {
            currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
            return currentTrungTam.MaTrungTam;
        }
        private string GetMaKho()
        {
            currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);
            return currentKho.MaKho;
        }

        private void SynsNhapDoiMa()
        {
            try
            {
                frmProgress.Instance.Text = "Đồng bộ dữ liệu";

                frmProgress.Instance.MaxValue = 3;

                ConnectionUtil.Instance.BeginTransaction();

                currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);

                currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);

                string inventoryOrg = currentTrungTam.MaTrungTam;

                string inventorySub = currentKho.MaKho;

                frmProgress.Instance.Description = "Đang xóa dữ liệu tạm...";

                SanXuatLenhProvier.tmpSanXuatDelete(inventoryOrg);

                SanXuatLenhProvier.tmpSanXuatCTietDelete(inventoryOrg);

                frmProgress.Instance.Value += 1;

                frmProgress.Instance.Description = "Đang đồng bộ dữ liệu...";

                bool success = false;

                DateTime sysDate = CommonProvider.Instance.GetSysDate();

                if (dteLastSync.DateTime.AddDays(31) < sysDate)
                {
                    //note: từ 1/6/2013 về trước có dữ liệu lặp trên ORC, nên nếu phải lấy dữ liệu lại từ đầu
                    //note: thì chỉ có thể lấy về từ ngày này, cần hết sức lưu ý.
                    dteLastSync.EditValue = sysDate.AddDays(-31);
                }

                success = BusinessSynchronize.Instance.LenhSanXuatSyncV2(dteLastSync.DateTime.ToString("yyyy/MM/dd hh:mm:ss"), inventoryOrg, "NXDM");

                if (success)
                {
                    frmProgress.Instance.Value += 1;

                    frmProgress.Instance.Description = "Đang cập nhật lại lịch sử...";

                    litmpSX = SanXuatLenhProvier.GetAlltmpSanXuatLenh(MaTrungTam, "NXDM");

                    litmpCT = SanXuatLenhProvier.GetAlltmpCTSanXuatLenh(MaTrungTam);

                    for (int i = 0; i < litmpSX.Count; i++)
                    {
                        sx.MaLenh = litmpSX[i].MaLenh;
                        sx.MaThanhPham = litmpSX[i].MaThanhPham;
                        sx.NgayLap = litmpSX[i].NgayLap;
                        sx.NguoiLap = litmpSX[i].NguoiLap;
                        sx.OrgCode = litmpSX[i].OrgCode;
                        sx.SoLuongTP = litmpSX[i].SoLuongTP;
                        sx.Status = litmpSX[i].Status;
                        sx.Loai_Ma_Lenh = litmpSX[i].Loai_Ma_Lenh;
                        sx.Description = litmpSX[i].Description;
                        sx.Last_update_date = litmpSX[i].Last_update_date;

                        int SoLuongHT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                        Convert.ToInt32(TransactionType.NHAP_DOIMA), litmpSX[i].MaLenh, currentTrungTam.MaTrungTam);

                        if (SoLuongHT == 0)
                        {
                            sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.ChoXuat);
                        }

                        if (SoLuongHT > 0 && SoLuongHT < litmpSX[i].SoLuongTP &&
                            (litmpSX[i].Status != 2 || litmpSX[i].Status != 3))
                        {
                            sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX);
                        }

                        if (SoLuongHT == litmpSX[i].SoLuongTP && litmpSX[i].Status != 2)
                        {
                            sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.DaSanXuatXong);
                        }

                        if (litmpSX[i].Status == 2)
                        {
                            sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.HuyLenh);
                        }

                        if (SoLuongHT != litmpSX[i].SoLuongTP && litmpSX[i].Status == 3)
                        {
                            sx.TrangThai = Convert.ToInt32(TrangThaiSanXuat.NgungSanXuat);
                        }

                        if (SanXuatLenhProvier.CheckMaLenh(litmpSX[i].MaLenh, litmpSX[i].MaThanhPham, currentTrungTam.MaTrungTam) == 0)
                        {
                            SanXuatLenhProvier.Insert(sx);
                        }
                        else
                        {
                            SanXuatLenhProvier.Update(sx);
                        }
                    }

                    for (int i = 0; i < litmpSX.Count; i++)
                    {
                        SanXuatCTietLenhProvider.Delete(litmpSX[i].MaLenh, currentTrungTam.MaTrungTam);
                    }

                    for (int i = 0; i < litmpCT.Count; i++)
                    {
                        sxct.MaLenh = litmpCT[i].MaLenh;
                        sxct.MaLinhKien = litmpCT[i].MaLinhKien;
                        sxct.NgayCanXuat = litmpCT[i].NgayCanXuat;
                        sxct.OrgCode = litmpCT[i].OrgCode;
                        sxct.SoLuongCanXuat = litmpCT[i].SoLuongCanXuat;
                        sxct.SoLuongDaXuat = litmpCT[i].SoLuongDaXuat;
                        sxct.SoLuongTrenTPham = litmpCT[i].SoLuongTrenTPham;
                        sxct.KhoXuat = litmpCT[i].KhoXuat;
                        if (SanXuatLenhProvier.CheckCtietMaLenh(litmpCT[i].MaLenh, currentTrungTam.MaTrungTam, litmpCT[i].MaLinhKien) == 0)
                        {
                            SanXuatCTietLenhProvider.Insert(sxct);
                        }
                        else
                        {
                            SanXuatCTietLenhProvider.Update(sxct);
                        }

                    }

                    ConnectionUtil.Instance.CommitTransaction();

                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                    frmProgress.Instance.Description = "Đã hoàn thành.";

                    frmProgress.Instance.IsCompleted = true;

                    LockControl.Unlock("SynsNhapDoiMa");

                }
                else
                {
                    ConnectionUtil.Instance.RollbackTransaction();

                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                    frmProgress.Instance.Description = "Không hoàn thành.";

                    frmProgress.Instance.IsCompleted = true;

                    LockControl.Unlock("SynsNhapDoiMa");

                    MessageBox.Show("Gọi webservice không thành công!");

                    return;
                }
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();

                LockControl.Unlock("SynsNhapDoiMa");

                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);

                MessageBox.Show(ex.Message);

                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;

                frmProgress.Instance.Description = "Không hoàn thành.";

                frmProgress.Instance.IsCompleted = true;
            }
        }

        private void GetValue()
        {
            if (grvChiTiet.FocusedRowHandle == null) throw new ManagedException("Xin hãy chọn dữ liệu!");
            SanXuatLenhInfo sx = (SanXuatLenhInfo)grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);
            MaLenh = liChiTiet[liChiTiet.IndexOf(sx)].MaLenh;
            MaThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].MaThanhPham;
            TenThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].TenThanhPham;
            SoLuongYC = liChiTiet[liChiTiet.IndexOf(sx)].SoLuongTP;
            idThanhPham = liChiTiet[liChiTiet.IndexOf(sx)].idThanhPham;
            Trangthai = liChiTiet[liChiTiet.IndexOf(sx)].TrangThai;
            status = liChiTiet[liChiTiet.IndexOf(sx)].Status;
            NgayLap = liChiTiet[liChiTiet.IndexOf(sx)].NgayLap;
            SoLuongCT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                Convert.ToInt32(TransactionType.NHAP_DOIMA), liChiTiet[liChiTiet.IndexOf(sx)].MaLenh,
                currentTrungTam.MaTrungTam);
        }

        private void CheckTrangthai()
        {
            dgvChiTiet.RefreshDataSource();

            dgvChiTiet.SuspendLayout();

            int currentProgress = frmProgress.Instance.Value;

            frmProgress.Instance.Value = 0;

            frmProgress.Instance.MaxValue = liChiTiet.Count;

            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (liChiTiet[i].TrangThai == 0 ||
                    liChiTiet[i].TrangThai == Convert.ToInt32(TrangThaiSanXuat.ChoXuat) ||
                    liChiTiet[i].TrangThai == Convert.ToInt32(TrangThaiSanXuat.DangSX))
                {
                    liChiTiet[i].SoLuongHT = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                        Convert.ToInt32(TransactionType.NHAP_DOIMA), liChiTiet[i].MaLenh, currentTrungTam.MaTrungTam);

                    if (liChiTiet[i].SoLuongHT == 0)
                    {
                        liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.ChoXuat);
                    }
                    if (liChiTiet[i].SoLuongHT > 0 && liChiTiet[i].SoLuongHT < liChiTiet[i].SoLuongTP &&
                        (liChiTiet[i].Status != 2 || liChiTiet[i].Status != 3))
                    {
                        liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.DangSX);
                    }
                    if (liChiTiet[i].SoLuongHT == liChiTiet[i].SoLuongTP && liChiTiet[i].Status != 2)
                    {
                        liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.DaSanXuatXong);
                    }
                    if (liChiTiet[i].Status == 2)
                    {
                        liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.HuyLenh);
                    }
                    if (liChiTiet[i].SoLuongHT != liChiTiet[i].SoLuongTP && liChiTiet[i].Status == 3)
                    {
                        liChiTiet[i].TrangThai = Convert.ToInt32(TrangThaiSanXuat.NgungSanXuat);
                    }

                    SanXuatLenhProvier.Update1(liChiTiet[i]);
                }
                
                frmProgress.Instance.Value += 1;

            }

            dgvChiTiet.RefreshDataSource();

            dgvChiTiet.ResumeLayout();

            frmProgress.Instance.Value = currentProgress;

        }

        public void LoadTrangthai()
        {
            List<LookUp> lst = new List<LookUp>();
            lst.Add(new LookUp { OID = 1, Name = "Chờ xuất" });
            lst.Add(new LookUp { OID = 2, Name = "Đang xuất" });
            lst.Add(new LookUp { OID = 3, Name = "Đã xuất đủ" });
            lst.Add(new LookUp { OID = 4, Name = "Ngừng sản xuất" });
            lst.Add(new LookUp { OID = 5, Name = "Phiếu đã hủy" });
            repTrangThai.DataSource = lst;
        }

        #endregion
        
        public void LoadDuLieu()
        {
            frmProgress.Instance.Caption = Text;
            frmProgress.Instance.Description = "Đang nạp dữ liệu";
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.MaxValue = 6;
            liChiTiet.Clear();
            dgvChiTiet.RefreshDataSource();
            frmProgress.Instance.Value += 1;
            MaTrungTam = GetMaTrungTam();
            frmProgress.Instance.Value += 1;
            MaKho = GetMaKho();
            frmProgress.Instance.Value += 1;
            
            if (!dteLastSync.InvokeRequired)
                dteLastSync.DateTime = SanXuatLenhProvier.GetMaxDateSanXuatLenh(MaTrungTam);
            else
                Invoke(
                    (MethodInvoker)
                    delegate { dteLastSync.DateTime = SanXuatLenhProvier.GetMaxDateSanXuatLenh(MaTrungTam); });

            frmProgress.Instance.Value += 1;
            liChiTiet.AddRange(SanXuatLenhProvier.GetRecentSanXuatLenh(txtMaLenhSX.Text, MaKho, MaTrungTam, "NXDM"));
            frmProgress.Instance.Value += 1;
            CheckTrangthai();
            frmProgress.Instance.Value += 1;
            dgvChiTiet.RefreshDataSource();
            frmProgress.Instance.Description = "Đã xong";
            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
            frmProgress.Instance.IsCompleted = true;

        }

        private void frmDanhSachNhapThanhPham_Load(object sender, EventArgs e)
        {
            frmProgress.Instance.DoWork(LoadDuLieu);
        }

        private void btnDongBo_Click(object sender, EventArgs e)
        {
            string functionName = "SynsNhapDoiMa";

            LockControl.Lock(functionName);
            frmProgress.Instance.DoWork(SynsNhapDoiMa);
            frmProgress.Instance.DoWork(LoadDuLieu);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            LockControl.Unlock("SynsNhapDoiMa");
            this.Close();
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            GetValue();
            if (status != 2)
            {
                if (MaLenh != "")
                {
                    frmChiTietNhapDoiMa frm = new frmChiTietNhapDoiMa(this, MaLenh, 1,currentTrungTam.MaTrungTam);
                    frm.ShowDialog();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Phiếu đã hủy không thể nhập cho phiếu này !");
                return;
            }
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            GetValue();
            if (status != 2)
            {
                if (MaLenh != "")
                {
                    frmChiTietNhapDoiMa frm = new frmChiTietNhapDoiMa(this, MaLenh, 1,currentTrungTam.MaTrungTam);
                    frm.ShowDialog();
                }
            }
            else
            {
                clsUtils.MsgCanhBao("Phiếu đã hủy không thể nhập cho phiếu này !");
                return;
            }
        }

        private void Tim(string MaVach)
        {
            //string MaLenh;
            //string MaThanhPham;
            //string TenThanhPham;
            string MaVachThanhPham;
            //int SoLuongYC;
            int SoLuongDN;
            List<DMChungTuNhapInfo> liTim = new List<DMChungTuNhapInfo>();
            List<ChungTuNhapNccChiTietHangHoaInfo> liMaVach = new List<ChungTuNhapNccChiTietHangHoaInfo>();
            List<SanXuatLenhInfo> liSX = new List<SanXuatLenhInfo>();
            DMChungTuNhapInfo liChungTu = new DMChungTuNhapInfo();
            ChungTuXuatNhapNccInfo ct;
            liTim = tblChungTuDataProvider.GetChungTuByMaVach(MaVach);

            if (liTim.Count > 0)
            {
                ct = new ChungTuXuatNhapNccInfo
                {
                    IdChungTu = liTim[0].IdChungTu,
                    LoaiChungTu = liTim[0].LoaiChungTu,
                    IdKho = liTim[0].IdKho,
                    IdNhanVien = liTim[0].IdNhanVien,
                    NgayLap = liTim[0].NgayLap,
                    SoChungTu = liTim[0].SoChungTu,
                    SoPO = liTim[0].SoChungTuGoc
                };
                if (liTim[0].LoaiChungTu == Convert.ToInt32(TransactionType.NHAP_DOIMA))
                {
                    liSX = SanXuatLenhProvier.GetSanXuatLenhByMaLenh(liTim[0].SoChungTuGoc, liTim[0].IdChungTu);
                    MaVachThanhPham = liSX[0].MaVachThanhPham;
                    MaThanhPham = liSX[0].MaThanhPham;
                    TenThanhPham = liSX[0].TenThanhPham;
                    SoLuongYC = liSX[0].SoLuongTP;
                    MaLenh = liTim[0].SoChungTuGoc;
                    SoLuongDN = SanXuatLenhProvier.GetSoLuongDNSanXuatLenh(
                        Convert.ToInt32(TransactionType.NHAP_DOIMA), liTim[0].SoChungTuGoc, this.MaTrungTam);
                    liMaVach = tblChungTuDataProvider.GetMaVachByChungTuGoc(liTim[0].SoChungTu);
                }
                else
                {
                    throw new ManagedException("Không tìm thấy dữ liệu phù hợp !");
                }

                Form frm = new frmChiTietNhapThanhPham(MaLenh, MaThanhPham, TenThanhPham, MaTrungTam,
                                                                          MaVachThanhPham, SoLuongYC, SoLuongDN,
                                                                          liMaVach, ct, 2);
                frm.ShowDialog();
            }
            else
            {
                throw new ManagedException("Không tìm thấy dữ liệu phù hợp !");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtMaVach.Text))
                {
                    if (liChiTiet.Count > 0)
                    {
                        Tim(txtMaVach.Text);
                    }
                }
                else
                {
                    frmProgress.Instance.DoWork(LoadDuLieu);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void frmDanhSachNhapThanhPham_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this, e.KeyCode);
        }

        private void btnListXLK_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvChiTiet.FocusedRowHandle == null) throw new ManagedException("Xin hãy chọn dữ liệu !");
                SanXuatLenhInfo sx = (SanXuatLenhInfo)grvChiTiet.GetRow(grvChiTiet.FocusedRowHandle);

                frmDanhSachXuatLinhKien frm = new frmDanhSachXuatLinhKien(sx.MaLenh, TransactionType.XUAT_DOIMA);
                frm.ShowDialog();
            }
            catch(ManagedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.DevExport2Excel(grvChiTiet);
        }
    }
}