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
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Infors;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmDoiMaLinhKien : DevExpress.XtraEditors.XtraForm
    {
        private List<ChungTuChiTietHangHoaBaseInfo> lstThanhPham;
        private HangHoa_ChiTietInfo linhKienLoi, linhKienMoi;
        private XuatDoiLinhKienLoiBusiness xuatDoiLinhKienLoiBusiness;
        private NhapDoiLinhKienLoiBusiness nhapDoiLinhKienLoiBusiness;
        private ChungTuBaseInfo donHangBan;
        private int idCTCTietNhapThanhPham;
        private string soPhieuNhapDLK;

        public frmDoiMaLinhKien()
        {
            InitializeComponent();
            btnXacNhan.Enabled = false;
            bteKhoThucHien.Tag = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);
            bteKhoThucHien.Text = ((DMKhoInfo) bteKhoThucHien.Tag).MaKho;
            soPhieuNhapDLK = CommonProvider.Instance.GetSoPhieu("PNDLK", "tbl_chungtu", "sochungtu");
        }

        private void frmDoiMaLinhKien_Load(object sender, EventArgs e)
        {
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (bteKhoThucHien.Tag == null)
            {
                MessageBox.Show("Bạn chưa chọn kho thực hiện!");
                return;
            }

            if (bteLyDoTraHang.Tag == null)
            {
                MessageBox.Show("Bạn chưa chọn lý do trả hàng!");
                return;
            }

            try
            {
                XuatLinhKienMoi();
                NhapLinhKienLoi();

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

                            frmProgress.Instance.MaxValue = 17;

                            ChungTuBusinessBase businessCloned = xuatDoiLinhKienLoiBusiness.Clone();

                            frmProgress.Instance.Value += 1;

                            (businessCloned as XuatDoiLinhKienLoiBusiness).ChungTu.NgayLap =
                                CommonProvider.Instance.GetSysDate();

                            frmProgress.Instance.Value += 1;

                            (businessCloned as XuatDoiLinhKienLoiBusiness).ChungTu.NgayXuatHang =
                                CommonProvider.Instance.GetSysDate();

                            frmProgress.Instance.Value += 1;

                            businessCloned.SaveChungTu();

                            frmProgress.Instance.Value += 1;

                            //cập nhật lại mã linh kiện mới vào phiếu xuất linh kiện.
                            DoiLinhKienLoiDataProvider.Instance.
                                UpdatePhieuXuatLinhKien(linhKienMoi.IdChiTiet,
                                                        linhKienLoi.IdChiTiet,
                                                        (businessCloned as XuatDoiLinhKienLoiBusiness).
                                                            ChungTu.SoChungTuGoc);

                            frmProgress.Instance.Value += 1;

                            businessCloned = nhapDoiLinhKienLoiBusiness.Clone();

                            frmProgress.Instance.Value += 1;

                            (businessCloned as NhapDoiLinhKienLoiBusiness).ChungTu.NgayLap =
                                CommonProvider.Instance.GetSysDate();

                            frmProgress.Instance.Value += 1;

                            (businessCloned as NhapDoiLinhKienLoiBusiness).ChungTu.NgayXuatHang =
                                CommonProvider.Instance.GetSysDate();

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
                                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Đổi mã linh kiện");
                            }
                        }
                    });

                //ConnectionUtil.Instance.DoSerializableWorkInTransaction(
                //    delegate
                //        {
                //            frmProgress.Instance.MaxValue = 17;
                            
                //            ChungTuBusinessBase businessCloned = xuatDoiLinhKienLoiBusiness.Clone();
                            
                //            frmProgress.Instance.Value += 1;

                //            (businessCloned as XuatDoiLinhKienLoiBusiness).ChungTu.NgayLap =
                //                CommonProvider.Instance.GetSysDate();

                //            frmProgress.Instance.Value += 1;

                //            (businessCloned as XuatDoiLinhKienLoiBusiness).ChungTu.NgayXuatHang =
                //                CommonProvider.Instance.GetSysDate();

                //            frmProgress.Instance.Value += 1;

                //            businessCloned.SaveChungTu();

                //            frmProgress.Instance.Value += 1;

                //            //cập nhật lại mã linh kiện mới vào phiếu xuất linh kiện.
                //            DoiLinhKienLoiDataProvider.Instance.
                //                UpdatePhieuXuatLinhKien(linhKienMoi.IdChiTiet,
                //                                        linhKienLoi.IdChiTiet,
                //                                        (businessCloned as XuatDoiLinhKienLoiBusiness).
                //                                            ChungTu.SoChungTuGoc);

                //            frmProgress.Instance.Value += 1;

                //            businessCloned = nhapDoiLinhKienLoiBusiness.Clone();

                //            frmProgress.Instance.Value += 1;

                //            (businessCloned as NhapDoiLinhKienLoiBusiness).ChungTu.NgayLap =
                //                CommonProvider.Instance.GetSysDate();

                //            frmProgress.Instance.Value += 1;

                //            (businessCloned as NhapDoiLinhKienLoiBusiness).ChungTu.NgayXuatHang =
                //                CommonProvider.Instance.GetSysDate();

                //            frmProgress.Instance.Value += 1;

                //            businessCloned.SaveChungTu();

                //            frmProgress.Instance.Value += 1;
                //        });

                this.Close();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
            }
        }

        private void XuatLinhKienMoi()
        {
            xuatDoiLinhKienLoiBusiness = new XuatDoiLinhKienLoiBusiness();
            xuatDoiLinhKienLoiBusiness.ChungTu =
                new ChungTuDoiLinhKienLoiInfo()
                {
                    IdKho = ((DMKhoInfo)bteKhoThucHien.Tag).IdKho,
                    NgayLap = CommonProvider.Instance.GetSysDate(),
                    NgayXuatHang = CommonProvider.Instance.GetSysDate(),
                    SoChungTu = ucCodeGenerate.Text,
                    SoChungTuGoc = DoiLinhKienLoiDataProvider.Instance.GetSoPhieuXuatLinhKien(idCTCTietNhapThanhPham),
                    LoaiChungTu = Convert.ToInt32(TransactionType.XUAT_DOI_LINHKIEN_LOI),
                    LyDoGiaoDich = ((DMLyDoTraHangInfo)bteLyDoTraHang.Tag).IdLyDoTH,
                    GhiChu = txtDienGiai.Text,
                    TrangThai = 1
                };

            xuatDoiLinhKienLoiBusiness.ListChiTietChungTu.
                Add(new ChungTuChiTietBaseInfo
                {
                    IdSanPham = linhKienMoi.IdSanPham,
                    MaSanPham = linhKienMoi.MaSanPham,
                    SoLuong = 1
                });

            xuatDoiLinhKienLoiBusiness.ListChiTietHangHoa.
                Add(new ChungTuChiTietHangHoaBaseInfo
                {
                    IdSanPham = linhKienMoi.IdSanPham,
                    SoLuong = 1,
                    MaVach = linhKienMoi.MaVach
                });

            //xuatDoiLinhKienLoiBusiness.SaveChungTu();

            //cập nhật lại mã linh kiện mới vào phiếu xuất linh kiện.
            //DoiLinhKienLoiDataProvider.Instance.UpdatePhieuXuatLinhKien(linhKienMoi.IdChiTiet, linhKienLoi.IdChiTiet,
            //                                                            xuatDoiLinhKienLoiBusiness.ChungTu.SoChungTuGoc);

        }

        private void NhapLinhKienLoi()
        {
            nhapDoiLinhKienLoiBusiness = new NhapDoiLinhKienLoiBusiness();
            nhapDoiLinhKienLoiBusiness.ChungTu =
                new ChungTuDoiLinhKienLoiInfo()
                {
                    IdKho = ((DMKhoInfo)bteKhoThucHien.Tag).IdKho,
                    NgayLap = CommonProvider.Instance.GetSysDate(),
                    NgayXuatHang = CommonProvider.Instance.GetSysDate(),
                    SoChungTu = soPhieuNhapDLK,
                    SoChungTuGoc = ucCodeGenerate.Text,
                    LoaiChungTu = Convert.ToInt32(TransactionType.NHAP_DOI_LINHKIEN_LOI),
                    LyDoGiaoDich = ((DMLyDoTraHangInfo)bteLyDoTraHang.Tag).IdLyDoTH,
                    GhiChu = txtDienGiai.Text,
                    TrangThai = 1
                };

            nhapDoiLinhKienLoiBusiness.ListChiTietChungTu.
                Add(new ChungTuChiTietBaseInfo
                {
                    IdSanPham = linhKienLoi.IdSanPham,
                    MaSanPham = linhKienLoi.MaSanPham,
                    SoLuong = 1
                });

            nhapDoiLinhKienLoiBusiness.ListChiTietHangHoa.
                Add(new ChungTuChiTietHangHoaBaseInfo
                {
                    IdSanPham = linhKienLoi.IdSanPham,
                    SoLuong = 1,
                    MaVach = linhKienLoi.MaVach
                });

            //nhapDoiLinhKienLoiBusiness.SaveChungTu();
            
        }

        private void txtSerialCu_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSerialCu.Text))
            {
                btnXacNhan.Enabled = false;
                return;
            }
            //kiem tra ma linh kien hong nay co ton tai trong phieu xuat linh kien khong? trong thanh pham nao?
            //thanh pham chua duoc tach
            lstThanhPham = DoiLinhKienLoiDataProvider.Instance.GetListThanhPham(txtSerialCu.Text.Trim());

            if(lstThanhPham.Count == 0)
            {
                MessageBox.Show("Không tìm thấy serial thành phẩm thỏa mãn.");
                btnXacNhan.Enabled = false;
                return;
            }

            //hien thi len serial thanh pham tuong ung, neu co nhieu thanh pham phai cho phep chon serial thanh pham tuong ung
            
            if (lstThanhPham.Count == 1)
            {
                linhKienLoi = DoiLinhKienLoiDataProvider.Instance.
                    GetLinhKienLoi(txtSerialCu.Text.Trim(),lstThanhPham[0].MaVach);
                
                idCTCTietNhapThanhPham = lstThanhPham[0].IdChungTuChiTiet;

                txtSerialThanhPham.Text = lstThanhPham[0].MaVach;
                txtSerialThanhPham.ReadOnly = true;
                return;
            }

            btnXacNhan.Enabled = false;
            MessageBox.Show("Yêu cầu thêm serial thành phẩm tương ứng.");
            txtSerialThanhPham.ReadOnly = false;
            txtSerialThanhPham.Focus();
            txtSerialThanhPham.SelectAll();
            return;

        }

        private void txtSerialThanhPham_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSerialThanhPham.Text.Trim()))
            {
                btnXacNhan.Enabled = false;
                return;
            }
            if(txtSerialThanhPham.Text.Trim().ToLower() == txtSerialCu.Text.Trim().ToLower())
            {
                btnXacNhan.Enabled = false;
                MessageBox.Show("Serial thành phẩm trùng với serial linh kiện hỏng.");
                txtSerialThanhPham.SelectAll();
                return;                
            }

            //thanh pham nay co phu hop voi linh kien hong khong?

            if(!lstThanhPham.Exists(delegate (ChungTuChiTietHangHoaBaseInfo match)
                                       {
                                           idCTCTietNhapThanhPham = match.IdChungTuChiTiet;

                                           return match.MaVach.ToLower() == txtSerialThanhPham.Text.Trim().ToLower();
                                       }))
            {
                btnXacNhan.Enabled = false;
                MessageBox.Show("Serial thành phẩm không cùng bộ với serial linh kiện hỏng.");
                txtSerialThanhPham.SelectAll();
                return;
            }

            linhKienLoi = DoiLinhKienLoiDataProvider.Instance.
                GetLinhKienLoi(txtSerialCu.Text.Trim(), txtSerialThanhPham.Text.Trim());

            //thanh pham nay da ban chua? ban gan nhat vao ngay nao? co thuc hien doi loi hay khong?
            donHangBan = DoiLinhKienLoiDataProvider.Instance.GetDonHangBan(txtSerialThanhPham.Text.Trim());

            if(donHangBan != null &&
                MessageBox.Show(String.Format("Thành phẩm này đã được xuất bán vào ngày {0}. Bạn có muốn tiếp tục không?", 
                    donHangBan.NgayLap.ToString("dd/MM/yyyy")), "Xác nhận", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

                btnXacNhan.Enabled = false;
                txtSerialThanhPham.SelectAll();
                return;                
            }
        }

        private void txtSerialMoi_Leave(object sender, EventArgs e)
        {
            if (bteKhoThucHien.Tag == null)
            {
                MessageBox.Show("Bạn chưa chọn kho thực hiện!");
                btnXacNhan.Enabled = false;
                return;                                
            }

            if(String.IsNullOrEmpty(txtSerialMoi.Text.Trim()))
            {
                btnXacNhan.Enabled = false;
                return;                                
            }
            //Serial linh kien moi co cung loai voi serial loi khong? co con ton khong?
            if ((linhKienMoi = DoiLinhKienLoiDataProvider.Instance.GetLinhKienMoi(txtSerialMoi.Text.Trim(), linhKienLoi.IdSanPham, ((DMKhoInfo)bteKhoThucHien.Tag).IdKho)) == null)
            {
                MessageBox.Show("Serial mới không cùng loại với serial linh kiện hỏng.");
                btnXacNhan.Enabled = false;
                return;                
            }

            if(linhKienMoi.SoLuong <= 0)
            {
                MessageBox.Show("Serial mới không còn tồn.");
                btnXacNhan.Enabled = false;
                return;                                
            }

            btnXacNhan.Enabled = true;
        }

        private void bteKhoThucHien_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(false, "%%", -1, Declare.IdNhanVien);
            if(frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKhoThucHien.Tag = frmLookUpKho.SelectedItem;
                bteKhoThucHien.Text = frmLookUpKho.SelectedItem.MaKho;
            }
        }

        private void bteLyDoTraHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_LyDoTraHang frmLookUpLyDoTraHang = new frmLookUp_LyDoTraHang("%%");
            if(frmLookUpLyDoTraHang.ShowDialog() == DialogResult.OK)
            {
                bteLyDoTraHang.Tag = frmLookUpLyDoTraHang.SelectedItem;
                bteLyDoTraHang.Text = frmLookUpLyDoTraHang.SelectedItem.Ten;
            }
        }
    }
}