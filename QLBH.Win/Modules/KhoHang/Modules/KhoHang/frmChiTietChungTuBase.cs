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
using QLBH.Core.Business;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;
using QLBH.Core.Providers;

// form frmChiTiet_ChungTunNhap
// Người tạo: Trần Tuấn Cường
// Ngày tạo : 25/05/2012
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmChiTietChungTuBase : DevExpress.XtraEditors.XtraForm
    {
        public string DonViTinh;
        public int OID;
        protected string SoChungTu;
        protected string NgayLap;
        public string SoPO;
        public int IdSanPham;
        public int InDex;
        private bool IsAdd = false;
        /// <summary>
        /// lấy các thông tin từ form ChiTiet_ChungTuNhapBase sang form ChungTuNhap_ChiTietHangHoaBase
        /// </summary>
        public List<ChungTu_ChiTietHangHoaBaseInfo> LiHangHoa = new List<ChungTu_ChiTietHangHoaBaseInfo>();
        /// <summary>
        /// list ra danh sách tất cả các bản ghi trong bang tbl_ChungTu_Chitiet qua IdChungTu
        /// </summary>
        public List<tmp_NhapHang_UserChiTietInfo> liChiTietChungTu = new List<tmp_NhapHang_UserChiTietInfo>();
        /// <summary>
        /// dùng add vào dcMaVach theo IdSanPham 
        /// </summary>
        public List<ChiTietHangHoaGridInfo> LiMaVach = new List<ChiTietHangHoaGridInfo>();
        /// <summary>
        /// list ra danh sách tất mã vạch có qua IdChungTu hoặc SoPO
        /// </summary>
        protected BindingList<ChungTu_ChiTietHangHoaBaseInfo> listChungTuChiTietHangHoa = new BindingList<ChungTu_ChiTietHangHoaBaseInfo>();
        /// <summary>
        /// lưu trữ mã vạch thông qua IdSanPham
        /// </summary>
        public Dictionary<int, object> dcMaVach = new Dictionary<int, object>();

        protected ChungTuBusinessBase Business;

        public frmChiTietChungTuBase()
        {
            InitializeComponent();
        }
        public frmChiTietChungTuBase(int oid, string sochungtu, string ngaylap, string SoPO)
        {
            InitializeComponent();
            this.OID = oid;
            this.SoChungTu = sochungtu;
            this.NgayLap = ngaylap;
            this.SoPO = SoPO;
        }


        #region Action

        #region LoadData
        protected virtual void LoadDataInstance() { }
        private void LoadData()
        {
            LoadDataInstance();

            #region Lấy và lưu trữ thông tin chi tiết hàng hóa vào dictionary theo Id sản phẩm
            if (OID > 0)
            {
                listChungTuChiTietHangHoa =
                new BindingList<ChungTu_ChiTietHangHoaBaseInfo>(
                    tblChungTu_ChiTietDataProvider.ChungTuChiTietHangHoaGetByIdChungTu(OID));
            }
            dcMaVach.Clear();
            if (listChungTuChiTietHangHoa.Count > 0)
            {

                for (int i = 0; i < liChiTietChungTu.Count; i++)
                {
                    BindingList<ChungTu_ChiTietHangHoaBaseInfo> liMaVach = new BindingList<ChungTu_ChiTietHangHoaBaseInfo>();
                    for (int j = 0; j < listChungTuChiTietHangHoa.Count; j++)
                    {
                        listChungTuChiTietHangHoa[j].ThanhTien = listChungTuChiTietHangHoa[j].SoLuong *
                                                                 listChungTuChiTietHangHoa[j].DonGia;
                        if (listChungTuChiTietHangHoa[j].IdSanPham == liChiTietChungTu[i].IdSanPham)
                        {
                            liMaVach.Add(listChungTuChiTietHangHoa[j]);
                        }
                    }
                    if (liMaVach.Count > 0)
                    {
                        dcMaVach.Add(liChiTietChungTu[i].IdSanPham, liMaVach);
                    }
                }
            }
            #endregion

            if (OID == 0)
            {
                IsAdd = true; 
            }
            else
            {
                txtSoPhieu.Text = SoChungTu;
            }

            #region Trong trường hợp phải nhập chi tiết hàng hóa thì phải set trạng thái đã nhập/chưa nhập của chi tiết chứng từ
            //hah đưa dòng này vào chức năng instance vì không phải lúc nào cũng edit được
            //dgvChiTiet.DataSource = new BindingList<tmp_NhapHang_UserChiTietInfo>(liChiTietChungTu) { AllowEdit = true, AllowNew = true, AllowRemove = true, RaiseListChangedEvents = true };
            if (liChiTietChungTu.Count > 0)
            {
                btnChiTiet.Enabled = true;
                //hah chuyển dòng này lên trên if vì một số nghiệp vụ nội dung chi tiết được tạo sau khi load 
                //dgvChiTiet.DataSource = new BindingList<tmp_NhapHang_UserChiTietInfo>(liChiTietChungTu){AllowEdit = true, AllowNew = true, AllowRemove = true, RaiseListChangedEvents = true};
                for (int i = 0; i < liChiTietChungTu.Count; i++)
                {
                    if (listChungTuChiTietHangHoa.Count > 0 && OID > 0)
                    {
                        foreach (ChungTu_ChiTietHangHoaBaseInfo pt in listChungTuChiTietHangHoa)
                        {
                            if (pt.IdSanPham == liChiTietChungTu[i].IdSanPham)
                            {
                                liChiTietChungTu[i].TrangThai = "Đã nhập đủ";
                            }
                        }
                        if (liChiTietChungTu[i].TrangThai == null)
                        {
                            liChiTietChungTu[i].TrangThai = "Chưa nhập";
                        }
                    }
                    else
                    {
                        liChiTietChungTu[i].TrangThai = "Chưa nhập";
                    }
                }
            }
            #endregion
        }
        #endregion

        #region SetChungTuInfo

        protected virtual void SetChungTuInstance(DMChungTuNhapInfo dm) { }

        private DMChungTuNhapInfo SetChungTuInfo()
        {
            DMChungTuNhapInfo dm = new DMChungTuNhapInfo();
            dm.SoChungTu = txtSoPhieu.Text;
            dm.IdKho = Declare.IdKho;
            dm.IdNhanVien = Declare.IdNhanVien;
            SetChungTuInstance(dm);

            return dm;
        }
        #endregion

        #region ReLoad
        public void ReLoad()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.DataSource = null;
            dgvChiTiet.DataSource = liChiTietChungTu;
        }
        #endregion

        #region SaveChungTu
        private void SaveChungTu()
        {
            List<DMChungTuNhapInfo> li = tblChungTuDataProvider.Search(txtSoPhieu.Text.Trim());
            if (li.Count > 0 && OID == 0)
            {
                throw new ManagedException("Số phiếu đã tồn tại trong hệ thống.Xin hãy kiểm tra lại !");
            }
            SaveChungTuInstance();
            Business.SaveChungTu();
        }
        #endregion
        protected virtual void SaveChungTuInstance() { }

        //#region RollBackSoLuong
        //private void RollBackSoLuong()
        //{
        //    for (int i = 0; i < liChiTietChungTu.Count; i++)
        //    {
        //        if (liChiTietChungTu[i].TrangThai == "Đã nhập đủ")
        //        {
        //            HangTonKhoInfo TonKho =
        //             HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, liChiTietChungTu[i].IdSanPham);
        //            SaveTonKhoInstance(TonKho, -liChiTietChungTu[i].SoLuong, liChiTietChungTu[i].IdSanPham);
        //        }
        //    }
        //    List<ChungTuChiTietMaVachInfo> liChungTuChiTietMaVach =
        //        tblChungTu_ChiTiet_HangHoaDataProvider.ChungTuChiTietGetByIdSanPham(OID);
        //    for (int i = 0; i < liChungTuChiTietMaVach.Count; i++)
        //    {
        //        HangHoa_ChiTietInfo liHangHoaChiTiet =
        //        tblHangHoa_ChiTietDataProvider.GetHangHoaChiTietByMaVach(liChungTuChiTietMaVach[i].MaVach);
        //        SaveChungTuChiTietHangHoaInstance(liHangHoaChiTiet, -liChungTuChiTietMaVach[i].SoLuong);
        //        tblChungTu_ChiTiet_HangHoaDataProvider.Delete(liChungTuChiTietMaVach[i].IdChiTietChungTu, liChungTuChiTietMaVach[i].IdChiTietHangHoa);
        //    }
        //    tblChungTu_ChiTietDataProvider.Delete(OID);
        //}
        //#endregion
        //test
        //#region SaveTonKho
        //protected virtual void SaveTonKhoInstance(HangTonKhoInfo tonKho, int soLuongMoi, int idSanPham) { }
        //private int SaveTonKho(int i)
        //{
        //    HangTonKhoInfo TonKho =
        //        HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, liChiTietChungTu[i].IdSanPham);
        //    if (TonKho == null)
        //    {
        //        TonKho = new HangTonKhoInfo { IdKho = Declare.IdKho, IdSanPham = liChiTietChungTu[i].IdSanPham, SoLuong = liChiTietChungTu[i].SoLuong, TonAo = liChiTietChungTu[i].SoLuong };
        //#region SaveTonKho
        //protected virtual void SaveTonKhoInstance(HangTonKhoInfo tonKho, int soLuongMoi, int idSanPham) { }
        //private int SaveTonKho(int i)
        //{
        //    HangTonKhoInfo TonKho = HangTonKhoDataProvider.GetHangTonKhoById(Declare.IdKho, liChiTietChungTu[i].IdSanPham);
        //    if (TonKho == null)
        //    {
        //        TonKho = new HangTonKhoInfo { IdKho = Declare.IdKho, IdSanPham = liChiTietChungTu[i].IdSanPham, SoLuong = liChiTietChungTu[i].SoLuong, TonAo = liChiTietChungTu[i].SoLuong };

        //    }
        ////    SaveTonKhoInstance(TonKho, liChiTietChungTu[i].SoLuong, liChiTietChungTu[i].IdSanPham);

        ////    //todo: @CuongTT TonKho.SoLuong < 0 || TonKho.TonAo < 0 trả về lỗi

        //    return TonKho.SoLuong;
        //}
        //#endregion

        //#region SaveTheKho
        //protected virtual void SaveTheKhoInstance(TheKhoInfo the, int soluong) { }

        //private void SaveTheKho(int i, int soLuongTon)
        //{
        //    //TheKhoDataProvider.Delete(Declare.IdKho, liChiTietChungTu[i].IdSanPham, liChiTietChungTu[i].SoPhieuNhap);
        //    //TheKhoInfo the = new TheKhoInfo();
        //    //the.IdSanPham = liChiTietChungTu[i].IdSanPham;
        //    //the.SoChungTu = liChiTietChungTu[i].SoPhieuNhap;
        //    //the.Ton = soLuongTon;
        //    //the.NgayChungTu = Convert.ToDateTime(dtNgayLap.Text.Trim());
        //    ////todo: @CuongTT(bên trong SaveTheKhoInstance()) thiếu thông tin NgayChungTu, IdKho của thẻ kho
        //    ////todo: @CuongTT các thông tin này anh nghĩ nếu set ở form base thì sẽ gọn hơn
        //    //SaveTheKhoInstance(the, liChiTietChungTu[i].SoLuong);
        //    //TheKhoDataProvider.Insert(the);
        //}
        //#endregion

        #region SetChungTuChiTietInfo
        private ChungTu_ChiTietInfo SetChungTuChiTietInfo(int i)
        {
            ChungTu_ChiTietInfo chungTuChiTietInfo = new ChungTu_ChiTietInfo();
            chungTuChiTietInfo.IdSanPham = liChiTietChungTu[i].IdSanPham;
            chungTuChiTietInfo.SoLuong = liChiTietChungTu[i].SoLuong;
            chungTuChiTietInfo.DonGia = liChiTietChungTu[i].DonGia;
            chungTuChiTietInfo.ThanhTien = liChiTietChungTu[i].Thanhtien;

            return chungTuChiTietInfo;
        }
        #endregion

        //#region SaveChungTuChiTiet
        //protected void SaveChungTuChiTiet(int Oid)
        //{
        //    BindingList<ChungTu_ChiTietHangHoaBaseInfo> liChungTuChiTietHangHoa;
        //    for (int i = 0; i < liChiTietChungTu.Count; i++)
        //    {
        //        //todo: @CuongTT(DONE) tên biến không đúng chuẩn
        //        string mavach;
        //        //todo: @CuongTT(DONE) tên biến không đúng chuẩn
        //        int oidchitiet;
        //        ChungTu_ChiTietInfo chungTuChiTietInfo = SetChungTuChiTietInfo(i);
        //        chungTuChiTietInfo.IdChungTu = Oid;
        //        oidchitiet = tblChungTu_ChiTietDataProvider.Insert(chungTuChiTietInfo);
        //        if (dcMaVach.ContainsKey(liChiTietChungTu[i].IdSanPham))
        //        {
        //            liChungTuChiTietHangHoa = (BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dcMaVach[liChiTietChungTu[i].IdSanPham];

        //            if (liChungTuChiTietHangHoa.Count > 0)
        //            {
        //                for (int j = 0; j < liChungTuChiTietHangHoa.Count; j++)
        //                {
        //                    mavach = liChungTuChiTietHangHoa[j].MaVach;
        //                    SaveChungTuChiTietHangHoa(oidchitiet, mavach, chungTuChiTietInfo.IdSanPham, liChungTuChiTietHangHoa[j].SoLuong);
        //                }
        //                int soton = SaveTonKho(i);
        //                SaveTheKho(i, soton);
        //            }
        //        }
        //    }
        //}
        //#endregion

        #region SaveChungTuChiTietHangHoa
        protected virtual void SaveChungTuChiTietHangHoaInstance(HangHoa_ChiTietInfo ct, int soLuongMoi) { }

        protected void SaveChungTuChiTietHangHoa(int oid, string maVach, int idSanPham, int soLuongMoi)
        {
            //HangHoa_ChiTietInfo hangHoaChiTietInfo =
            //    tblHangHoa_ChiTietDataProvider.GetHangHoaChiTietByMaVach(maVach);
            //if (hangHoaChiTietInfo == null)
            //    hangHoaChiTietInfo = new HangHoa_ChiTietInfo { IdKho = Declare.IdKho, IdSanPham = idSanPham, MaVach = maVach, SoLuong = soLuongMoi };

            //SaveChungTuChiTietHangHoaInstance(hangHoaChiTietInfo, soLuongMoi);

            ////todo: @CuongTT hangHoaChiTietInfo.SoLuong < 0 trả về lỗi

            //ChungTu_ChiTiet_HangHoaInfo cthh = new ChungTu_ChiTiet_HangHoaInfo();
            //cthh.IdChiTietChungTu = oid;
            //cthh.IdChiTietHangHoa = hangHoaChiTietInfo.IdChiTiet;
            //cthh.SoLuong = soLuongMoi;
            //tblChungTu_ChiTiet_HangHoaDataProvider.Insert(cthh);
        }
        #endregion

        #region Click
        /// <summary>
        /// hàm này chỉ sử dụng khi cần thao tác với form ChungTuNhap_ChiTietHangHoaBase
        /// </summary>
        /// <param name="e"></param>
        protected virtual void ClickInstance(int e) { }

        private void GetValues(int e)
        {
            GetValuesInstance(e);
        }

        protected virtual void GetValuesInstance(int e)
        {
            //hah chỗ này không throw exception vì có một số nghiệp vụ không cần đến chi tiết hàng hóa
            //throw new NotImplementedException();
        }
        protected virtual void DoubleClickInstance() { }
        #endregion

        #endregion
        private void frmChiTiet_ChungTuNhap_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode) LoadData();
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetValues(e.RowIndex);
        }

        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DoubleClickInstance();
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

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                DoubleClickInstance();
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SaveChungTu();
                if (IsAdd)
                {
                    MessageBox.Show("Thêm mới thành công !");
                }
                else
                {
                    MessageBox.Show("Cập nhật thành công !");
                }
                DialogResult = DialogResult.OK;
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
            if (MessageBox.Show("Dữ liệu chưa được lưu có thể sẽ bị mất. Bạn có chắc chán muốn thoát ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
