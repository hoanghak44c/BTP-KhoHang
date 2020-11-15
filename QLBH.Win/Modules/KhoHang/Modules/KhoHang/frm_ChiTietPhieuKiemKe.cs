using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QLBanHang.Modules.BaoHanh.Form.ThietLapHeThongBH;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

// <Remarks>
// Tạo ChiTietPhieuKiemKe
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 21/10/2012
// Người sửa cuối:
// </remarks>
namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ChiTietPhieuKiemKe : DevExpress.XtraEditors.XtraForm
    {
        private int KhoHienTai;
        private frm_DanhSachPhieuKiemKe frmPKK;
        public int i,trangThai;
        private DateTime NgayLap;
        private int idDotKiemKe, IdNhanVien;
        public int IdKiemKe;
        private string MaNganh, maKho, MaTrungTam;
        List<KiemKeChiTietHangHoaInfor> liCo = new List<KiemKeChiTietHangHoaInfor>();
        List<KiemKeChiTietHangHoaInfor> liCoDeleted = new List<KiemKeChiTietHangHoaInfor>();
        List<KiemKeChiTietKhongMaVachInfor> liKhong = new List<KiemKeChiTietKhongMaVachInfor>();
        List<KiemKeChiTietKhongMaVachInfor> liKhongDeleted = new List<KiemKeChiTietKhongMaVachInfor>();
        public ChungTuChiTietHangHoaKiemKePairInfor HangHoa = new ChungTuChiTietHangHoaKiemKePairInfor();
        
        public frm_ChiTietPhieuKiemKe()
        {
            InitializeComponent();
            KhoHienTai = Declare.IdKho;
        }

        public frm_ChiTietPhieuKiemKe(frm_DanhSachPhieuKiemKe frm)
        {
            InitializeComponent();
            KhoHienTai = Declare.IdKho;
            this.frmPKK = frm;
            this.IdNhanVien = Declare.IdNhanVien;
            //dgvSanPhamCo.AutoGenerateColumns = false;
            //dgvSanPhamKhong.AutoGenerateColumns = false;
        }

        public frm_ChiTietPhieuKiemKe(frm_DanhSachPhieuKiemKe frm,int idKiemKe,int idDotKiemKe,int trangThai, int idNhanVien)
        {
            InitializeComponent();
            KhoHienTai = Declare.IdKho;
            this.frmPKK = frm;
            this.IdKiemKe = idKiemKe;
            this.trangThai = trangThai;
            this.idDotKiemKe = idDotKiemKe;
            this.IdNhanVien = idNhanVien;
            //dgvSanPhamCo.AutoGenerateColumns = false;
            //dgvSanPhamKhong.AutoGenerateColumns = false;
        }

        public string MaKho
        {
            get
            {
                if (chkKhoKhach.Checked) return "KHOKHACH";
                return maKho;
            }

            set { maKho = value; }
        }

        #region bteDotKiemKe
        private void bteDotKiemKe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookup_DotKiemKe frm = new frmLookup_DotKiemKe(String.Format("%{0}%", bteDotKiemKe.Text));
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (bteDotKiemKe.Tag != frm.SelectedItem && (liKhong.Count > 0 || liCo.Count > 0))
                {
                    if (MessageBox.Show("Các serial sẽ bị xóa đi để bắn lại. Bạn có đồng ý không?", "Xác nhận", 
                        MessageBoxButtons.YesNo) == DialogResult.No) return;
                    
                    liKhong.Clear();
                    if (grvDanhSachKhong.DataSource != null)
                        ((BindingList<KiemKeChiTietKhongMaVachInfor>) grvDanhSachKhong.DataSource).ResetBindings();

                    liCo.Clear();
                    if (grvDanhSachCo.DataSource != null)
                        ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();
                }
                bteDotKiemKe.Text = "";
                bteDotKiemKe.Tag = frm.SelectedItem;
                bteDotKiemKe.Text = frm.SelectedItem.MaDotKiemKe;
                idDotKiemKe = frm.SelectedItem.IdDotKiemKe;
                MaNganh = frm.SelectedItem.Nganh;
                MaKho = frm.SelectedItem.Kho;
                MaTrungTam = frm.SelectedItem.TrungTam;
                //if (frmPKK.isAdd && IdKiemKe == 0)
                //{
                //    IdKiemKe = KiemKeDataProvider.Instance.InsertKiemKe(SetKiemKeInfo());
                //}
                //else
                //{
                //    KiemKeDataProvider.Instance.UpdateKiemKe(SetKiemKeInfo());
                //}
            }
        }

        private void bteDotKiemKe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookup_DotKiemKe frm = new frmLookup_DotKiemKe(String.Format("%{0}%", bteDotKiemKe.Text));
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (bteDotKiemKe.Tag != frm.SelectedItem && (liKhong.Count > 0 || liCo.Count > 0))
                    {
                        if (MessageBox.Show("Các serial sẽ bị xóa đi để bắn lại. Bạn có đồng ý không?", "Xác nhận",
                            MessageBoxButtons.YesNo) == DialogResult.No) return;

                        liKhong.Clear();
                        if (grvDanhSachKhong.DataSource != null)
                            ((BindingList<KiemKeChiTietKhongMaVachInfor>)grvDanhSachKhong.DataSource).ResetBindings();

                        liCo.Clear();
                        if (grvDanhSachCo.DataSource != null)
                            ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();
                    }
                    bteDotKiemKe.Tag = frm.SelectedItem;
                    bteDotKiemKe.Text = frm.SelectedItem.MaDotKiemKe;
                    MaNganh = frm.SelectedItem.Nganh;
                    MaKho = frm.SelectedItem.Kho;
                    MaTrungTam = frm.SelectedItem.TrungTam;
                    //if (frmPKK.isAdd && IdKiemKe == 0)
                    //    IdKiemKe = KiemKeDataProvider.Instance.InsertKiemKe(SetKiemKeInfo());
                    //else
                    //{
                    //    KiemKeDataProvider.Instance.UpdateKiemKe(SetKiemKeInfo());
                    //}
                }
            }
        }
        private void bteDotKiemKe_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteDotKiemKe.Text)) bteDotKiemKe.Tag = null;
        }
        #endregion

        private void SaveMaVachKhongCo(List<KiemKeChiTietInfor> listChiTiet)
        {
            if (liKhong.Count > 0)
            {
                foreach (KiemKeChiTietKhongMaVachInfor kiemKeChiTietKhongMaVachInfor in liKhong)
                {
                    if (kiemKeChiTietKhongMaVachInfor.MaSanPham == null || kiemKeChiTietKhongMaVachInfor.IdSanPham == 0)
                    {
                        throw new ManagedException(
                           String.Format("Bạn chưa gán mã sản phẩm cho mã vạch '{0}'!", kiemKeChiTietKhongMaVachInfor.MaVach));
                        //MessageBox.Show("Bạn chưa gán mã sản phẩm cho mã vạch!", "Thông báo");
                        //return;
                    }
                    if (kiemKeChiTietKhongMaVachInfor.IdChiTiet == 0)
                    {
                        kiemKeChiTietKhongMaVachInfor.IdChiTiet =
                            listChiTiet.Find(delegate(KiemKeChiTietInfor match)
                                                 {
                                                     return match.IdSanPham ==
                                                            kiemKeChiTietKhongMaVachInfor
                                                                .IdSanPham;
                                                 }).IdChiTiet;
                        KiemKeDataProvider.Instance.InsertKiemKeChiTietKhongMaVach(kiemKeChiTietKhongMaVachInfor);
                    }
                    else
                        KiemKeDataProvider.Instance.UpdateKiemKeChiTietKhongMaVach(kiemKeChiTietKhongMaVachInfor);
                    
                }
            }
        }

        private void SaveMaVachCo(List<KiemKeChiTietInfor> listChiTiet)
        {
            if (liCo.Count > 0)
            {
                foreach (KiemKeChiTietHangHoaInfor kiemKeChiTietHangHoaInfor in liCo)
                {
                    if (kiemKeChiTietHangHoaInfor.IdChiTietKiemKe==0)
                    {
                        kiemKeChiTietHangHoaInfor.IdChiTietKiemKe = listChiTiet.Find(delegate(KiemKeChiTietInfor match)
                        {
                            return match.IdSanPham == kiemKeChiTietHangHoaInfor.IdSanPham &&
                                   match.IdKho == kiemKeChiTietHangHoaInfor.IdKho;

                        }).IdChiTiet;
                        KiemKeDataProvider.Instance.InsertKiemKeChiTietHangHoa(kiemKeChiTietHangHoaInfor);                        
                    }
                    else
                        KiemKeDataProvider.Instance.UpdateKiemKeChiTietHangHoa(kiemKeChiTietHangHoaInfor);
                }
                //KiemKeDataProvider.Instance.InsertChiTietHangHoaKiemKeBoSung(idKK, 1, Declare.IdKho);  

            }
        }

        private KiemKeInfor SetKiemKeInfo()
        {
            return new KiemKeInfor()
                       {
                           IdKiemKe = IdKiemKe,
                           IdNhanVien = IdNhanVien,
                           IdKho = KhoHienTai,
                           NgayKiemKe = dtNgayKiemKe.Value,
                           SoPhieu = txtSoPhieu.Text.Trim(),
                           //NguoiTao = Convert.ToInt32(Declare.UserName),
                           GhiChu = txtGhiChu.Text.Trim(),
                           KhoKhach = Convert.ToInt32(chkKhoKhach.Checked),
                           IdDotKiemKe = bteDotKiemKe.Tag != null ? ((DotKiemKeInfor) bteDotKiemKe.Tag).IdDotKiemKe : 0,
                           TrangThai = Convert.ToInt32(TrangThaiKiemKe.CHUA_XAC_NHAN)
                       };
        }

        private void SaveAll()
        {
            try
            {
                ConnectionUtil.Instance.BeginTransaction();

                var objTT = KiemKeDataProvider.Instance.GetTrangThaiBysoPhieu(txtSoPhieu.Text);
                if (objTT!= null)
                {
                    if(objTT.TrangThai == Convert.ToInt32(TrangThaiKiemKe.XAC_NHAN))
                    {
                        throw new ManagedException("Phiếu này đã được xác nhận nên không thể lưu!");
                    }
                }
                else
                {
                    //insert vao tbl_kiem ke.
                    IdKiemKe = KiemKeDataProvider.Instance.InsertKiemKe(SetKiemKeInfo());
                    
                    CommonProvider.Instance.Lock_KiemKe(SetKiemKeInfo());

                    liKhong.ForEach(delegate(KiemKeChiTietKhongMaVachInfor action)
                    {
                        action.NguoiTao = Declare.IdNhanVien;
                        action.IdChiTiet = 0;
                    });

                    liCo.ForEach(delegate(KiemKeChiTietHangHoaInfor action)
                                     {
                                         action.IdChiTietKiemKe = 0;
                                     });
                }

                foreach (var obj in liCoDeleted)
                {
                    KiemKeDataProvider.Instance.DeleteRowKiemKeCoMaVach(obj.IdChiTietKiemKe, obj.IdSanPham, obj.IdChiTietHangHoa);
                }

                foreach (var obj in liKhongDeleted)
                {
                    KiemKeDataProvider.Instance.DeleteRowKiemKeKhongMaVach(obj.IdChiTiet, obj.IdSanPham, obj.MaVach);
                }

                var liKiemKeChiTiet= new List<KiemKeChiTietInfor>();

                foreach (var infor in liCo)
                {
                    var tmpInfo = liKiemKeChiTiet.Find(delegate(KiemKeChiTietInfor match)
                                             {
                                                 return match.IdSanPham == infor.IdSanPham && match.IdKho == infor.IdKho;
                                             });
                    
                    if(tmpInfo == null)
                    {
                        liKiemKeChiTiet.Add(new KiemKeChiTietInfor
                                                {
                                                    IdChiTiet = infor.IdChiTietKiemKe,
                                                    IdKiemKe = IdKiemKe,//frmPKK.Oid,
                                                    IdSanPham = infor.IdSanPham,
                                                    SoLuong = infor.SoLuong,
                                                    IdKho = infor.IdKho
                                                });
                    } 
                    else
                    {
                        tmpInfo.IdKiemKe = IdKiemKe;
                        tmpInfo.SoLuong += infor.SoLuong;
                    }
                }

                foreach (var infor in liKhong)
                {
                    var tmpInfo = liKiemKeChiTiet.Find(delegate(KiemKeChiTietInfor match)
                    {
                        return match.IdSanPham == infor.IdSanPham && match.IdKho == infor.IdKho;
                    });

                    if (tmpInfo == null)
                    {
                        liKiemKeChiTiet.Add(new KiemKeChiTietInfor
                        {
                            IdChiTiet = infor.IdChiTiet,
                            IdKiemKe = IdKiemKe,//frmPKK.Oid,
                            IdSanPham = infor.IdSanPham,
                            SoLuong = infor.SoLuong,
                            IdKho = infor.IdKho
                        });
                    }
                    else
                    {
                        tmpInfo.IdKiemKe = IdKiemKe;
                        tmpInfo.SoLuong += infor.SoLuong;
                    }
                }

                if (frmPKK.isAdd)
                {
                    //int OidKK = KiemKeDataProvider.Instance.InsertKiemKe(SetKiemKeInfo());
                    liKiemKeChiTiet.ForEach(delegate(KiemKeChiTietInfor action)
                                                {
                                                    action.IdKiemKe = IdKiemKe;
                                                    action.NguoiTao = Declare.IdNhanVien;
                                                    action.IdChiTiet = KiemKeDataProvider.Instance.InsertKiemKeChiTiet(action);
                                                });
                    //KiemKeDataProvider.Instance.InsertChiTietKiemKeBoSung(OidKK,Declare.IdKho);
                    liKhong.ForEach(delegate (KiemKeChiTietKhongMaVachInfor action)
                                        {
                                            action.NguoiTao = Declare.IdNhanVien;
                                        });

                    SaveMaVachKhongCo(liKiemKeChiTiet);
                    SaveMaVachCo(liKiemKeChiTiet);
                    KiemKeDataProvider.Instance.UpdateGhiChuKiemKe(IdKiemKe,txtGhiChu.Text);
                    frmPKK.isAdd = false;
                }
                else
                {
                    KiemKeDataProvider.Instance.UpdateKiemKe(SetKiemKeInfo());

                    liKiemKeChiTiet.ForEach(delegate(KiemKeChiTietInfor action)
                                                {
                                                    action.IdKiemKe = IdKiemKe;// frmPKK.Oid;
                                                    action.NguoiTao = Declare.IdNhanVien;
                                                    if (action.IdChiTiet == 0)
                                                        action.IdChiTiet = KiemKeDataProvider.Instance.InsertKiemKeChiTiet(action);
                                                });
                    liKhong.ForEach(delegate(KiemKeChiTietKhongMaVachInfor action)
                    {
                        action.NguoiTao = Declare.IdNhanVien;
                    });
                    
                    if (liKiemKeChiTiet.Count > 0)
                    {
                        foreach (var kiemKeChiTietInfor in liKiemKeChiTiet)
                        {
                            KiemKeDataProvider.Instance.UpdateKiemKeChiTiet(kiemKeChiTietInfor);
                        }
                    }
                    SaveMaVachCo(liKiemKeChiTiet);
                    SaveMaVachKhongCo(liKiemKeChiTiet);
                    KiemKeDataProvider.Instance.UpdateGhiChuKiemKe(IdKiemKe, txtGhiChu.Text);
                }
                ConnectionUtil.Instance.CommitTransaction();
               
            }
            catch (Exception ex)
            {
                ConnectionUtil.Instance.RollbackTransaction();
                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
                throw;
            }
        }

        //protected  void PickUpSanPhamInfo(DMSanPhamInfo sanPhamInfo)
        //{
        //    likhong[dgvSanPhamKhong.Rows.IndexOf(dgvSanPhamKhong.CurrentRow)].MaSanPham = sanPhamInfo.MaSanPham;
        //    likhong[dgvSanPhamKhong.Rows.IndexOf(dgvSanPhamKhong.CurrentRow)].TenSanPham = sanPhamInfo.TenSanPham;
        //    likhong[dgvSanPhamKhong.Rows.IndexOf(dgvSanPhamKhong.CurrentRow)].TrungMaVach = sanPhamInfo.TrungMaVach;
        //    likhong[dgvSanPhamKhong.Rows.IndexOf(dgvSanPhamKhong.CurrentRow)].IdSanPham = sanPhamInfo.IdSanPham;
        //    if (dgvSanPhamKhong.DataSource == null)
        //        dgvSanPhamKhong.DataSource = new BindingList<KiemKeChiTietKhongMaVachInfor>(likhong);
        //    else
        //    {
        //        ((BindingList<KiemKeChiTietKhongMaVachInfor>)dgvSanPhamKhong.DataSource).ResetBindings();
        //    }
        //}
        
       // private bool isKeyPressed;
        
        //void Control_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    isKeyPressed = true;
        //}

        //void Control_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ColumnMaSanPham == null) return;
        //        if (!isKeyPressed || dgvSanPhamKhong.CurrentCell.ColumnIndex != dgvSanPhamKhong.Columns.IndexOf(ColumnMaSanPham) ||
        //            ((TextBox)sender).Text == String.Empty || ((TextBox)sender).Text == (string)dgvSanPhamKhong.CurrentCell.Value) return;

        //        frmLookUp_SanPham frm = new frmLookUp_SanPham(String.Format("%{0}%", ((TextBox)sender).Text));

        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            isKeyPressed = false;
        //            PickUpSanPhamInfo(frm.SelectedItem);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLogProvider.Instance.WriteLog(ex.ToString(), "frmLookUp_SanPham");
        //    }
        //}
        //private void dgvSanPhamKhong_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    if (ColumnMaSanPham == null) return;
        //    if (dgvSanPhamKhong.CurrentCell != null && dgvSanPhamKhong.CurrentCell.ColumnIndex == dgvSanPhamKhong.Columns.IndexOf(ColumnMaSanPham))
        //    {
        //        e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        //        e.Control.TextChanged += new EventHandler(Control_TextChanged);
        //    }
        //}
        //protected  DataGridViewTextBoxColumn ColumnMaSanPham
        //{
        //    get
        //    {
        //        return clMaSanPhamKhong;
        //    }
        //}
        private void Them()
        {
            if(trangThai == 1)
            {
                throw new ManagedException("Phiếu này đã được xác nhận!");
            }

            if (txtMaVach.Text == "")
            {
                throw new ManagedException("Mã vạch không được để trống !");
            }
            if (bteDotKiemKe.Tag == null)
            {
                throw new ManagedException("Bạn chưa chọn đợt kiểm kê!");
            }

            txtMaVach.Text = txtMaVach.Text.Trim();

            List<DMSanPhamInfoEx> listsp = KiemKeDataProvider.Instance.
                GetLookUpSanPhamTrungMV(txtMaVach.Text, MaTrungTam, MaKho, MaNganh,
                                        ((DotKiemKeInfor)bteDotKiemKe.Tag).IdDotKiemKe);

            List<ChungTu_ChiTietHangHoaKiemKeInfor> frm =
                KiemKeDataProvider.Instance.GetIdSanPhamByMaVach(txtMaVach.Text, MaTrungTam, MaKho, MaNganh,
                                                                 ((DotKiemKeInfor) bteDotKiemKe.Tag).IdDotKiemKe);

            if (frm != null && frm.Count != 0)
            {
                for (int i = 0; i < frm.Count; i++)
                {
                    HangHoa.IdChiTietHangHoa = frm[i].IdChiTietHangHoa;
                    HangHoa.IdSanPham = frm[i].IdSanPham;
                    HangHoa.MaSanPham = frm[i].MaSanPham;
                    HangHoa.TenSanPham = frm[i].TenSanPham;
                    HangHoa.SoLuongSS = frm[i].SoLuong;
                    HangHoa.GhiChu = frm[i].GhiChu;
                    HangHoa.TrungMaVach = frm[i].TrungMaVach;
                    HangHoa.IdKho = frm[i].IdKho;
                    HangHoa.MaKho = frm[i].MaKho;
                    //HangHoa.DonViTinh = frm[0].TenDonViTinh;}
                }
            }

            if (frm != null && frm.Count == 0 || 
                !chkAutoRegSub.Checked || //&& HangHoa.TrungMaVach == 1 ||
                KiemKeDataProvider.Instance.CheckMaVach(MaKho, HangHoa.IdSanPham, txtMaVach.Text.Trim(), MaNganh, MaTrungTam,
                    ((DotKiemKeInfor)bteDotKiemKe.Tag).IdDotKiemKe) == false)
            {
                if (MessageBox.Show(
                    !chkAutoRegSub.Checked && HangHoa.TrungMaVach == 1 ?
                    "Bạn có chắc chắn là serial thừa không?" :
                    "Mã vạch hiện không tìm thấy.\nBạn có muốn thêm mã vạch này không?",
                                    "Xác nhận",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    KiemKeChiTietKhongMaVachInfor matchInfo = new KiemKeChiTietKhongMaVachInfor();

                    DMTrungTamInfor trungTamInfor = DMTrungTamDataProvider.GetTrungTamByMa(((DotKiemKeInfor)bteDotKiemKe.Tag).TrungTam);


                    frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(false, String.Format("%{0}%", ((DotKiemKeInfor)bteDotKiemKe.Tag).TrungTam), trungTamInfor.IdTrungTam, -1);

                    if (frmLookUpKho.ShowDialog() == DialogResult.OK)
                    {
                        matchInfo.IdKho = frmLookUpKho.SelectedItem.IdKho;
                        matchInfo.MaKho = frmLookUpKho.SelectedItem.MaKho;
                    }
                    else
                    {
                        return;
                    }

                    frmLookUp_SanPham frmLookUpSanPham = new frmLookUp_SanPham("%%");
                    if(frmLookUpSanPham.ShowDialog() == DialogResult.OK)
                    {
                        matchInfo.IdSanPham = frmLookUpSanPham.SelectedItem.IdSanPham;
                        matchInfo.MaSanPham = frmLookUpSanPham.SelectedItem.MaSanPham;
                        matchInfo.TenSanPham = frmLookUpSanPham.SelectedItem.TenSanPham;
                    }
                    else
                    {
                        return;
                    }

                    foreach (KiemKeChiTietKhongMaVachInfor pt in liKhong)
                    {
                        if (pt.MaVach.ToLower() == txtMaVach.Text.Trim().ToLower() && 
                            pt.IdKho == matchInfo.IdKho && pt.IdSanPham == matchInfo.IdSanPham)
                        {
                            pt.SoLuong = pt.SoLuong + 1;

                            ((BindingList<KiemKeChiTietKhongMaVachInfor>)grvDanhSachKhong.DataSource).ResetBindings();
                            
                            txtMaVach.Clear();

                            grvDanhSachKhong.TopRowIndex = liKhong.IndexOf(pt);

                            grvDanhSachKhong.ClearSelection();
                            grvDanhSachKhong.FocusedRowHandle = liKhong.IndexOf(pt);
                            return;
                        }
                    }
                    
                    liKhong.Add(new KiemKeChiTietKhongMaVachInfor()
                                    {
                                        MaVach = txtMaVach.Text.Trim(),
                                        SoLuong = 1,
                                        IdSanPham = matchInfo.IdSanPham,
                                        MaSanPham = matchInfo.MaSanPham,
                                        TenSanPham = matchInfo.TenSanPham,
                                        IdKho = matchInfo.IdKho,
                                        MaKho = matchInfo.MaKho
                                    });
                    
                    ((BindingList<KiemKeChiTietKhongMaVachInfor>)grvDanhSachKhong.DataSource).ResetBindings();
                    
                    txtMaVach.Clear();
                    
                    grvDanhSachKhong.TopRowIndex = liKhong.Count - 1;

                    grvDanhSachKhong.ClearSelection();
                    grvDanhSachKhong.FocusedRowHandle = liKhong.Count - 1;
                }

                txtMaVach.Clear();
            }
            else
            {
                if (listsp.Count < 2)
                {
                    foreach (KiemKeChiTietHangHoaInfor pt in liCo)
                    {
                        if (pt.MaVach.ToLower() == txtMaVach.Text.Trim().ToLower() && 
                            pt.TrungMaVach == 1 &&
                            pt.MaKho == HangHoa.MaKho &&
                            pt.MaSanPham == HangHoa.MaSanPham)
                        {
                            pt.SoLuong = pt.SoLuong + 1;
                            pt.SoLuongSs = pt.SoLuongSs;

                            ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();

                            txtTenSanPham.Text = HangHoa.TenSanPham;
                            txtMaVach.Clear();

                            grvDanhSachCo.TopRowIndex = liCo.IndexOf(pt);

                            grvDanhSachCo.ClearSelection();
                            grvDanhSachCo.FocusedRowHandle = liCo.IndexOf(pt);
                            return;
                        }
                        if (pt.MaVach.ToLower() == txtMaVach.Text.Trim().ToLower() && pt.TrungMaVach == 0)
                        {
                            throw new ManagedException("Mã vạch không được trùng nhau!");
                        }
                    }
                    liCo.Add(new KiemKeChiTietHangHoaInfor
                                 {
                                     MaVach = txtMaVach.Text.Trim(),
                                     SoLuong = 1,
                                     TenDonViTinh = HangHoa.DonViTinh,
                                     IdSanPham = HangHoa.IdSanPham,
                                     IdChiTietHangHoa = HangHoa.IdChiTietHangHoa,
                                     TenSanPham = HangHoa.TenSanPham,
                                     MaSanPham = HangHoa.MaSanPham,
                                     SoLuongSs = HangHoa.SoLuongSS,
                                     GhiChu = HangHoa.GhiChu,
                                     TrungMaVach = HangHoa.TrungMaVach,
                                     IdKho = HangHoa.IdKho,
                                     MaKho = HangHoa.MaKho
                                 });
                    ((BindingList<KiemKeChiTietHangHoaInfor>) grvDanhSachCo.DataSource).ResetBindings();

                    txtTenSanPham.Text = HangHoa.TenSanPham;
                    txtMaVach.Clear();
                    
                    grvDanhSachCo.TopRowIndex = liCo.Count - 1;

                    grvDanhSachCo.ClearSelection();
                    grvDanhSachCo.FocusedRowHandle = liCo.Count - 1;

                }
                else
                {
                    frmLookup_SanPhamTrungMaVach frmsp = new frmLookup_SanPhamTrungMaVach(txtMaVach.Text, MaKho, MaTrungTam, MaNganh,
                        ((DotKiemKeInfor)bteDotKiemKe.Tag).IdDotKiemKe);
                    if (frmsp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int idsanpham = frmsp.item.IdSanPham;
                        ChungTu_ChiTietHangHoaKiemKeInfor obj = KiemKeDataProvider.Instance.
                            GetSanPhamById_MaVach(idsanpham, txtMaVach.Text, MaTrungTam, frmsp.item.MaKho, MaNganh,
                                                  ((DotKiemKeInfor) bteDotKiemKe.Tag).IdDotKiemKe);

                        foreach (KiemKeChiTietHangHoaInfor pt in liCo)
                        {
                            if (pt.MaVach.ToLower() == txtMaVach.Text.Trim().ToLower() && 
                                pt.TrungMaVach == 1 &&
                                pt.MaKho == obj.MaKho &&
                                pt.MaSanPham == obj.MaSanPham)
                            {
                                pt.SoLuong = pt.SoLuong + 1;
                                pt.SoLuongSs = pt.SoLuongSs;

                                ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();

                                txtTenSanPham.Text = HangHoa.TenSanPham;
                                txtMaVach.Clear();

                                grvDanhSachCo.TopRowIndex = liCo.IndexOf(pt);

                                grvDanhSachCo.ClearSelection();
                                grvDanhSachCo.FocusedRowHandle = liCo.IndexOf(pt);

                                return;
                            }
                            if (pt.MaVach.ToLower() == txtMaVach.Text.Trim().ToLower() && 
                                pt.TrungMaVach == 0 &&
                                pt.MaKho == obj.MaKho &&
                                pt.MaSanPham == obj.MaSanPham)
                            {
                                throw new ManagedException("Mã vạch không được trùng nhau!");
                            }
                        }

                        liCo.Add(new KiemKeChiTietHangHoaInfor
                        {
                            MaVach = txtMaVach.Text.Trim(),
                            SoLuong = 1,
                            TenDonViTinh = obj.TenDonViTinh,
                            IdSanPham = obj.IdSanPham,
                            IdChiTietHangHoa = obj.IdChiTietHangHoa,
                            TenSanPham = obj.TenSanPham,
                            MaSanPham = obj.MaSanPham,
                            //SoLuongSs = obj.SoLuongSS,
                            GhiChu = obj.GhiChu,
                            TrungMaVach = obj.TrungMaVach,
                            IdKho = obj.IdKho,
                            MaKho = obj.MaKho
                        });
                        
                        ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();
                        
                        txtTenSanPham.Text = obj.TenSanPham;
                        txtMaVach.Clear();
                        
                        grvDanhSachCo.TopRowIndex = liCo.Count - 1;

                        grvDanhSachCo.ClearSelection();
                        grvDanhSachCo.FocusedRowHandle = liCo.Count - 1;
                            
                    } 
                }
            }
        }

        private bool Check()
        {
            if (bteDotKiemKe.Tag == null)
            {
                throw new ManagedException("Bạn chưa chọn đợt kiểm kê!");
            }

            if (grvDanhSachCo.RowCount == 0 && grvDanhSachKhong.RowCount == 0)
            {
                throw new ManagedException("Bạn chưa thêm sản phẩm kiểm kê!");
            }
            
            return true;
        }

        private void frm_ChiTietPhieuKiemKe_Load(object sender, EventArgs e)
        {
            dtNgayKiemKe.Enabled = false;
            btnInPhieu.Enabled = false;
            if (frmPKK.Oid == 0)
            {
                txtSoPhieu.Text = CommonProvider.Instance.GetSoPhieu(Declare.Prefix.PhieuKiemKe);
                txtNguoiKiem.Text = Declare.UserName;
                dtNgayKiemKe.Value = CommonProvider.Instance.GetSysDate();
            }
            else
            {
                txtSoPhieu.Text = frmPKK.SoPhieu;
                txtGhiChu.Text = frmPKK.GhiChu;
                dtNgayKiemKe.Value = frmPKK.NgayLap;
                chkKhoKhach.Checked = Convert.ToBoolean(frmPKK.KhoKhach);
                chkKhoKhach.Enabled = false;
                if (idDotKiemKe != 0)
                {
                    DotKiemKeInfor dmNv = DotKiemKeDataProvider.Instance.GetListDotKiemkeById(idDotKiemKe);
                    bteDotKiemKe.Tag = dmNv;
                    bteDotKiemKe.Text = dmNv.MaDotKiemKe;
                    MaNganh = dmNv.Nganh;
                    MaKho = dmNv.Kho;
                    MaTrungTam = dmNv.TrungTam;
                }
            }
            if(trangThai == Convert.ToInt32(TrangThaiKiemKe.XAC_NHAN))
            {
                btnSave.Enabled = false;
                btnXacNhan.Enabled = false;
                btnXoaCoMaVach.Enabled = false;
                btnXoaKhongCoMaVach.Enabled = false;
                btnThemHang.Enabled = false;
                txtSoPhieu.Enabled = false;
                txtGhiChu.Enabled = false;
                bteDotKiemKe.Enabled = false;
                chkKhoKhach.Enabled = false;
                btnInPhieu.Enabled = true;
            }

            liCo = KiemKeDataProvider.Instance.GetListChiTietKiemKeCo(frmPKK.Oid);
            grcDanhSachCo.DataSource = new BindingList<KiemKeChiTietHangHoaInfor>(liCo);

            liKhong = KiemKeDataProvider.Instance.GetListChiTietKiemKeKhong(frmPKK.Oid);
            grcDanhSachKhong.DataSource = new BindingList<KiemKeChiTietKhongMaVachInfor>(liKhong);
            if(frmPKK.Oid!=0)
            {
                if (liCo.Count == 0 && liKhong.Count != 0)
                {
                    txtNguoiKiem.Text = liKhong[0].HoTen;
                }
                else if(liKhong.Count == 0 && liCo.Count!= 0)
                {
                    txtNguoiKiem.Text = liCo[0].HoTen;
                }
                else
                {
                    txtNguoiKiem.Text = Declare.TenNhanVien;
                }
            }
            //dgvSanPhamCo.AutoGenerateColumns = false;
            //dgvSanPhamKhong.AutoGenerateColumns = false;
        }

        private void btnThemHang_Click(object sender, EventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Dữ liệu chưa được lưu có thể sẽ bị mất. Bạn có chắc chắn muốn thoát ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                //DialogResult = DialogResult.Cancel;
            //}
            //return;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    SaveAll();
                    MessageBox.Show("Cập nhật thành công!");
                    txtMaVach.Focus();
                    //this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void frm_ChiTietPhieuKiemKe_KeyDown(object sender, KeyEventArgs e)
        {
            QLBH.Core.QLBHUtils.PerformShortCutKey(this,e.KeyCode);
        }

        private void btnXoaCoMaVach_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSachCo.FocusedRowHandle >= 0)
                {
                    var objTT = KiemKeDataProvider.Instance.GetTrangThaiBysoPhieu(txtSoPhieu.Text);
                    if (objTT != null)
                    {
                        if (objTT.TrangThai == Convert.ToInt32(TrangThaiKiemKe.XAC_NHAN))
                        {
                            throw new ManagedException("Phiếu này đã được xác nhận nên không thể lưu!");
                        }
                    }

                    var obj = (KiemKeChiTietHangHoaInfor)grvDanhSachCo.GetRow(grvDanhSachCo.FocusedRowHandle);

                    if (obj != null)
                    {
                        var buffer = new KiemKeChiTietHangHoaInfor[1];
                        
                        liCo.CopyTo(liCo.IndexOf(obj), buffer, 0, 1);

                        liCoDeleted.AddRange(buffer);

                        //KiemKeDataProvider.Instance.DeleteRowKiemKeCoMaVach(obj.IdChiTietKiemKe, obj.IdSanPham, obj.IdChiTietHangHoa);

                        liCo.RemoveAt(liCo.IndexOf(obj));
                        
                        ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();
                    }
                    else
                    {
                        liCo.RemoveAt(liCo.IndexOf(obj));

                        ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaKhongCoMaVach_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDanhSachKhong.FocusedRowHandle >= 0)
                {
                    var objTT = KiemKeDataProvider.Instance.GetTrangThaiBysoPhieu(txtSoPhieu.Text);
                    if (objTT != null)
                    {
                        if (objTT.TrangThai == Convert.ToInt32(TrangThaiKiemKe.XAC_NHAN))
                        {
                            throw new ManagedException("Phiếu này đã được xác nhận nên không thể lưu!");
                        }
                    }

                    var obj =
                        ((KiemKeChiTietKhongMaVachInfor)grvDanhSachKhong.GetRow(grvDanhSachKhong.FocusedRowHandle));
                    if (obj != null)
                    {
                        var buffer = new KiemKeChiTietKhongMaVachInfor[1];

                        liKhong.CopyTo(liKhong.IndexOf(obj), buffer, 0, 1);

                        liKhongDeleted.AddRange(buffer);

                        //KiemKeDataProvider.Instance.DeleteRowKiemKeKhongMaVach(obj.IdChiTiet, obj.IdSanPham, obj.MaVach);
                        
                        liKhong.RemoveAt(liKhong.IndexOf(obj));
                        
                        ((BindingList<KiemKeChiTietKhongMaVachInfor>)grvDanhSachKhong.DataSource).ResetBindings();
                    }
                    else
                    {
                        liKhong.RemoveAt(liKhong.IndexOf(obj));
                        
                        ((BindingList<KiemKeChiTietKhongMaVachInfor>)grvDanhSachKhong.DataSource).ResetBindings();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkKhoKhach_CheckedChanged(object sender, EventArgs e)
        {
            if(chkKhoKhach.Checked)
            {
                KhoHienTai = 0;
            }
            else
            {
                KhoHienTai = Declare.IdKho;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xác nhận?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Check())
                    {
                        SaveAll();
                        KiemKeDataProvider.Instance.UpdateTrangThaiKiemKe(IdKiemKe, Convert.ToInt32(TrangThaiKiemKe.XAC_NHAN));
                        MessageBox.Show("Xác nhận thành công!");
                        btnSave.Enabled = false;
                        btnXacNhan.Enabled = false;
                        btnXoaCoMaVach.Enabled = false;
                        btnXoaKhongCoMaVach.Enabled = false;
                        btnThemHang.Enabled = false;
                        txtSoPhieu.Enabled = false;
                        txtGhiChu.Enabled = false;
                        bteDotKiemKe.Enabled = false;
                        chkKhoKhach.Enabled = false;                        
                    }
                }
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
//        private void dgvSanPhamCo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
//        {
//            try
//            {
//                KiemKeChiTietHangHoaInfor info =
//                    (KiemKeChiTietHangHoaInfor) grvDanhSachCo.GetRow(grvDanhSachCo.FocusedRowHandle);

//                if (info.TrungMaVach == 0 && grvDanhSachCo.Columns[e.ColumnIndex].Name == "clSoLuongCo")
//                {
//                    e.Cancel = true;
//                }
//            }
//            catch (Exception ex)
//            {
//                // e.Cancel = true;
//#if DEBUG
//                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#else
//                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
//#endif
//            }
//        }

        private void chkKhoKhach_Click(object sender, EventArgs e)
        {
            if (grvDanhSachCo.RowCount > 0 || grvDanhSachKhong.RowCount > 0)
            {
                if (MessageBox.Show("Danh sách mã vạch đã bắn sẽ bị xóa! Bạn có chắc chắn không?", "Xác nhận",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    
                    liKhong.Clear();
                    ((BindingList<KiemKeChiTietKhongMaVachInfor>)grvDanhSachKhong.DataSource).ResetBindings();
                    
                    liCo.Clear();
                    ((BindingList<KiemKeChiTietHangHoaInfor>)grvDanhSachCo.DataSource).ResetBindings();

                    if(chkKhoKhach.Checked)
                    {
                        chkKhoKhach.Checked = false;
                    }
                    else
                    {
                        chkKhoKhach.Checked = true;
                    }
                    KiemKeDataProvider.Instance.UpdateKiemKeKhoKhach(IdKiemKe, Convert.ToInt32(chkKhoKhach.Checked));
                }
                //return;
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            List<InPhieuKiemKeInfor> list = KiemKeDataProvider.Instance.GetBCPhieuKiemKe(IdKiemKe);
            //InPhieuKiemKeInfor info = list[0];
            rpt_BC_PhieuKiemKe rpt = new rpt_BC_PhieuKiemKe();
            List<InPhieuKiemKeInfor> lst = new List<InPhieuKiemKeInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.Export2ExcelFromDevGrid<KiemKeChiTietHangHoaInfor>(grvDanhSachCo, "DanhSachMaVachCoTrongKho");
        }

        private void btnExportKhong_Click(object sender, EventArgs e)
        {
            Common.Export2ExcelFromDevGrid<KiemKeChiTietKhongMaVachInfor>(grvDanhSachKhong, "DanhSachMaVachKhongTimThay");
        }

        private void grvDanhSachCo_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                KiemKeChiTietHangHoaInfor info =
                    (KiemKeChiTietHangHoaInfor) grvDanhSachCo.GetRow(grvDanhSachCo.FocusedRowHandle);

                if (info.TrungMaVach == 0 && grvDanhSachCo.FocusedColumn.FieldName == "SoLuong")
                {
                    e.Cancel = true;
                }
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

        private string message = String.Empty;
        private DateTime start, stop;

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    stop = DateTime.Now;
                    
                    string countChar = String.Empty;
                    
                    foreach (char c in message.ToLower())
                    {
                        if (String.IsNullOrEmpty(countChar) ||
                            !countChar.Contains(c.ToString())) countChar += c;
                    }

                    if (String.IsNullOrEmpty(message) ||
                        message.Length <= 5)
                    {
                        message = String.Empty;
                        start = DateTime.MinValue;
                        throw new ManagedException("Bạn chưa nhập mã vạch");
                    }
                    
                    var tocdonhaptrungbinh = (stop - start).TotalMilliseconds/message.Length;

                    if (tocdonhaptrungbinh > 55 || countChar.Length < 5)
                    {
                        message = String.Empty;
                        start = DateTime.MinValue;
                        throw new ManagedException("Bạn chưa nhập mã vạch");                        
                    }

                    txtMaVach.Text = message;

                    start = DateTime.MinValue;

                    message = String.Empty;

                    Them();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                    MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                    txtMaVach.Focus();
                }
            }
            else
            {
                if (start == DateTime.MinValue) start = DateTime.Now;
            }
        }


        private void txtMaVach_KeyPress(object sender, KeyPressEventArgs e)
        {
            message += e.KeyChar.ToString();

            e.Handled = true;
        }
    }
}