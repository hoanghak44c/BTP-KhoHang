using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using CrystalDecisions.Shared;
using System.Data.OleDb;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.DongBoERP.Reports;
using QLBH.Common;
using QLBH.Core.Data;
using QLBH.Core.Form;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBH.Core.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.DongBoERP
{
    public partial class frm_ChungTuNhap : frmBCBase
    {
        DataTable dtSoPhieuNhap;
        DateTime lanDongBoTruoc;
        ArrayList ArrTemp = null;
        int CurrentIndex = 0;
        int _IdChungTu = 0;
        bool isFinished = false;
        bool isNotEnough = false;
        string notYetAvailable = "Chưa nhập chi tiết";
        DataTable dtTempNhapHang;
        string inventoryOrg, inventorySub;
        private DMKhoInfo currentKho;
        private DMTrungTamInfor currentTrungTam;
        Utils ut = new Utils();
        public frm_ChungTuNhap()
        {
            InitializeComponent();
            Common.LoadStyle(this);
            currentKho = DMKhoDataProvider.GetKhoByIdInfo(Declare.IdKho);
            currentTrungTam = DMTrungTamDataProvider.GetTrungTamByIdInfo(Declare.IdTrungTam);
        }

        private void LoadComboTrungTam()
        {
            cboTrungTam.DisplayMember = "TenTrungTam";
            cboTrungTam.ValueMember = "MaTrungTam";
            cboTrungTam.DataSource = DMTrungTamDataProvider.GetListTrungTamPairInfo();
            cboTrungTam.SelectedValue = Declare.IdTrungTam;
        }

        private void LoadComboKho(){
            cboKho.DisplayMember = "TenKho";
            cboKho.ValueMember = "MaKho";
            cboKho.DataSource = DMKhoDataProvider.GetListKhoByTrungTamPairInfo(Declare.IdTrungTam);
            cboKho.SelectedValue = Declare.IdKho;
        }

        private void EnableButton() {
            btnPhieuTiepTheo.Enabled = CurrentIndex < dtSoPhieuNhap.Rows.Count - 1;
            btnPhieuTruocDo.Enabled = CurrentIndex > 0;
            btnDong.Enabled = CurrentIndex == dtSoPhieuNhap.Rows.Count - 1;
            btnGoTo.Enabled = dtSoPhieuNhap.Rows.Count > 0;
            btnPrint.Enabled = dtSoPhieuNhap.Rows.Count > 0;
        }

        private void DisplayForm(int index)
        {
            try
            {
                if (dtSoPhieuNhap.Rows[index]["IdChungTu"] == DBNull.Value)
                    _IdChungTu = 0;
                else
                    _IdChungTu = Convert.ToInt32(dtSoPhieuNhap.Rows[index]["IdChungTu"]);
                string sql = String.Format(@"SELECT * FROM vTmpNhapHang WHERE InventoryOrg='{0}' AND InventorySub='{1}'
                    AND ThoiGian < '{2}' AND ThoiGian > '{3}' AND SoPhieuNhap=N'{4}' AND TrangThai=N'{5}'",
                    currentTrungTam.MaTrungTam,
                    currentKho.MaKho,
                    dtNgayDongBo.Value.ToString(new CultureInfo("en-US")),
                    lanDongBoTruoc.ToString(new CultureInfo("en-US")),
                    dtSoPhieuNhap.Rows[index]["SoPhieuNhap"],
                    dtSoPhieuNhap.Rows[index]["TrangThai"]);

                //string sql = String.Format("SELECT t2.IdChiTiet, t1.*, sp.IdSanPham, sp.TenSanPham, dvt.TenDonViTinh FROM tbl_Tmp_NhapHang t1 "
                //    + "INNER JOIN tbl_SanPham sp ON t1.MaSanPham = sp.MaSanPham "
                //    + "INNER JOIN tbl_DM_DonViTinh dvt ON sp.IdDonViTinh = dvt.IdDonViTinh "
                //    + "LEFT OUTER JOIN (SELECT ctct.IdChiTiet, ctct.IdSanPham, ctct.DonGia, ct.SoChungTu FROM tbl_ChungTu ct INNER JOIN tbl_ChungTu_ChiTiet ctct "
                //    + "ON ct.IdChungTu = ctct.IdChungTu WHERE ct.SoChungTu='{0}' AND ct.LoaiChungTu={1}) t2 ON t2.SoChungTu = t1.SoPhieuNhap AND t2.IdSanPham = sp.IdSanPham "
                //    + "AND t1.DonGia= t2.DonGia "
                //    + "WHERE t1.InventoryOrg={2} AND t1.InventorySub={3} AND t1.ThoiGian < '{4}' AND t1.ThoiGian > '{5}' AND t1.SoPhieuNhap=N'{6}'",
                //    dtSoPhieuNhap.Rows[index]["SoPhieuNhap"],
                //    (int)TransactionType.NHAP,
                //    getMaTrungTam(Declare.IdTrungTam),
                //    getMaKho(Declare.IdKho),
                //    dtNgayDongBo.Value.ToString(new CultureInfo("en-US")),
                //    lanDongBoTruoc.ToString(new CultureInfo("en-US")),
                //    dtSoPhieuNhap.Rows[index]["SoPhieuNhap"]);
                dtTempNhapHang = DBTools.getData("vPhieuNhapKho", sql).Tables["vPhieuNhapKho"];
                dtTempNhapHang.Columns.Add("colGhiChu", typeof(String));
                if (dtSoPhieuNhap.Rows.Count > 0)
                {
                    isNotEnough = false;
                    foreach (DataRow dr in dtTempNhapHang.Rows)
                    {
                        dr["colGhiChu"] = notYetAvailable;
                        if (dr["IdChiTiet"] != DBNull.Value)
                        {
                            sql = String.Format("SELECT SUM(SoLuong) FROM tbl_ChungTu_ChiTiet_HangHoa WHERE IdChiTietChungTu={0}", dr["IdChiTiet"]);
                            object sum = DBTools.ExecuteScalar(sql);
                            if (int.Equals(sum, dr["SoLuong"]))
                                dr["colGhiChu"] = "Đã nhập đủ hàng chi tiết";
                            else
                                isNotEnough = true;
                        }
                    }
                    cboTrungTam.SelectedValue = dtTempNhapHang.Rows[0]["InventoryOrg"];
                    cboKho.SelectedValue = dtTempNhapHang.Rows[0]["InventorySub"];
                    txtGhiChu.Text = dtTempNhapHang.Rows[0]["GhiChu"].ToString();
                    txtSoPO.Text = dtTempNhapHang.Rows[0]["SoPO"].ToString();
                    txtPhieuNhap.Text = dtTempNhapHang.Rows[0]["SoPhieuNhap"].ToString();
                    txtNgayNhap.Text = dtTempNhapHang.Rows[0]["NgayNhap"].ToString();
                    txtThoiGianTaoGD.Text = dtTempNhapHang.Rows[0]["ThoiGian"].ToString();
                    lblContent.Text = String.Format("Có tổng số {0} phiếu mua hàng. Phiếu số {1}", dtSoPhieuNhap.Rows.Count, index + 1);
                    double sum1 = 0;
                    foreach (DataRow dr in dtTempNhapHang.Rows)
                    {
                        sum1 += Common.DoubleValue(dr["ThanhTien"]);
                    }
                    txtTongTienHang.Text = Common.Double2Str(sum1);
                }
                else
                    lblContent.Text = "Không có phiếu mua hàng nào";
                this.ArrTemp = null;
                dgvList.DataSource = dtTempNhapHang;
                dgvList.Refresh();
                EnableButton();
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private bool IsValid() {
            foreach (DataGridViewRow dgr in dgvList.Rows) {
                if (String.Equals(dgr.Cells["colGhiChu"].Value.ToString(), notYetAvailable) && this.ArrTemp != null) {
                    return MessageBox.Show("Phiếu mua hàng này vẫn chưa nhập đủ, bạn có muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                }
            }
            return true;
        }
         
        private void frm_ChungTuNhap_Load(object sender, EventArgs e)
        {
            try {
                LoadComboTrungTam();
                LoadComboKho();
                LoadLanDongBoTruoc();
                cboConditionName.SelectedIndex = 0;
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void LoadLanDongBoTruoc()
        {
            try
            {
                if (currentKho.LanDongBoTruoc != DateTime.MinValue)
                    lanDongBoTruoc = currentKho.LanDongBoTruoc;
                else
                    lanDongBoTruoc = Declare.NgayDuDau;

                dtLanDongBoTruoc.Value = lanDongBoTruoc;
                dtLanDongBoTruoc.MinDate = Declare.NgayDuDau;
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            try {
                if (dtSoPhieuNhap != null && dtSoPhieuNhap.Rows.Count > 0) {
                    btnGhi_Click(sender, e);
                    GtidCommand sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                    sqlCmd.CommandTimeout = 0;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = String.Format("SELECT ct.IdChungTu, ct.SoChungTu, t1.ThucTe, t2.SoSach FROM tbl_ChungTu ct "
                        + "INNER JOIN (SELECT IdChungTu, SUM(ctcthh.SoLuong) as ThucTe FROM tbl_ChungTu_ChiTiet_HangHoa ctcthh "
                            + "INNER JOIN tbl_ChungTu_ChiTiet ctct ON ctct.IdChiTiet = ctcthh.IdChiTietChungTu "
                            + "GROUP BY IdChungTu) t1 ON ct.IdChungTu = t1.IdChungTu AND ct.LoaiChungTu={0} AND ct.IdKho={1} AND ct.ThoigianTao < '{2}' AND ct.ThoigianTao > '{3}' "

                        + "RIGHT OUTER JOIN (SELECT t1.SoPhieuNhap, t1.SoPO, ct.IdChungTu, SUM(SoLuong) as SoSach FROM tbl_Tmp_NhapHang t1 "
                            + "LEFT OUTER JOIN tbl_ChungTu ct ON ct.SoChungTu=t1.SoPhieuNhap AND ct.SoSeri=t1.SoPO AND ct.LoaiChungTu={0} AND ct.IdKho={1} "
                            + "AND (SELECT TOP (1) soluong FROM tbl_chungtu_chitiet WHERE tbl_chungtu_chitiet.idchungtu = ct.idchungtu)>=0 "
                            + "WHERE InventoryOrg='{4}' AND InventorySub='{5}' AND ThoiGian < '{2}' AND ThoiGian > '{3}' AND SoLuong >= 0 GROUP BY SoPhieuNhap, SoPO, IdChungTu "
                            + "UNION ALL "
                            + "SELECT t1.SoPhieuNhap, t1.SoPO, ct.IdChungTu, SUM(SoLuong) as SoSach FROM tbl_Tmp_NhapHang t1 "
                            + "LEFT OUTER JOIN tbl_ChungTu ct ON ct.SoChungTu=t1.SoPhieuNhap AND ct.SoSeri=t1.SoPO AND ct.LoaiChungTu={0} AND ct.IdKho={1} "
                            + "AND (SELECT TOP (1) soluong FROM tbl_chungtu_chitiet WHERE tbl_chungtu_chitiet.idchungtu = ct.idchungtu)<0 "
                            + "WHERE InventoryOrg='{4}' AND InventorySub='{5}' AND ThoiGian < '{2}' AND ThoiGian > '{3}' AND SoLuong < 0 GROUP BY SoPhieuNhap, SoPO, IdChungTu " 
                            + ") t2 ON ct.IdChungTu = t2.IdChungTu",
                        (int)TransactionType.NHAP_PO,
                        Declare.IdKho,
                        DateTime.Now.ToString(new CultureInfo("en-US")),
                        //dtNgayDongBo.Value.ToString(new CultureInfo("en-US")),
                        lanDongBoTruoc.ToString(new CultureInfo("en-US")),
                        inventoryOrg,
                        inventorySub);
                    DataTable dt = DBTools.getData(sqlCmd, "Temp").Tables["Temp"];
                    if(dt.Rows.Count == 0){
                        MessageBox.Show("Bạn chưa nhập đủ số lượng hàng trong các phiếu mua này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    foreach (DataRow dr in dt.Rows) {
                        if (!int.Equals(dr["ThucTe"], dr["SoSach"])) {
                            MessageBox.Show("Bạn chưa nhập đủ số lượng hàng trong các phiếu mua này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    sqlCmd.CommandText = String.Format("Update tbl_DM_Kho set LanDongBoTruoc='{0}' WHERE IdKho={1}", dtNgayDongBo.Value.ToString(new CultureInfo("en-US")), DBTools.getValue(String.Format("SELECT IdKho FROM tbl_DM_Kho WHERE MaKho='{0}'", cboKho.SelectedValue)));
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Đã cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                isFinished = true;
                this.Close();
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnNapDuLieu_Click(object sender, EventArgs e)
        {
//            Cursor.Current = Cursors.WaitCursor;
//            try {
//                string sql;
//                inventoryOrg = currentTrungTam.MaTrungTam;
//                inventorySub = currentKho.MaKho;
//                lanDongBoTruoc = dtLanDongBoTruoc.Value;
//                sql = String.Format("DELETE FROM tbl_Tmp_NhapHang WHERE InventoryOrg='{0}' AND InventorySub='{1}'", inventoryOrg, inventorySub);
//                SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

//                bool success = false;
//                WebReference.Main service = new QLBanHang.WebReference.Main();
//                service.GetDataOM(inventoryOrg, inventorySub, lanDongBoTruoc.ToString(new CultureInfo("en-US")), ref success);
//                //Common.CallWebservice("GetDataOM", getMaTrungTam(Declare.IdTrungTam), getMaKho(Declare.IdKho), lanDongBoTruoc, success);
//                if (!success)
//                {
//                    MessageBox.Show("Gọi webservice không thành công!");
//                    return;
//                }

//                sql = String.Format("DELETE FROM tbl_LichSu_NhapHang WHERE SoPO IN (SELECT SoPO FROM tbl_Tmp_NhapHang WHERE InventoryOrg='{0}' AND InventorySub='{1}')", inventoryOrg, inventorySub);
//                SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

//                sql = String.Format("INSERT INTO tbl_LichSu_NhapHang SELECT * FROM tbl_Tmp_NhapHang WHERE InventoryOrg='{0}' AND InventorySub='{1}'", inventoryOrg, inventorySub);
//                SqlHelper.ExecuteNonQuery(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);

//                sql = String.Format("SELECT COUNT(*) FROM tbl_Tmp_NhapHang WHERE MaSanPham NOT IN (SELECT MaSanPham FROM tbl_SanPham WHERE sudung=1) AND InventoryOrg='{0}' AND InventorySub='{1}'", inventoryOrg, inventorySub);
//                //sql += String.Format("AND SoPO=N'{0}' AND SoPhieuNhap=N'{1}'", txtSoPO.Text, txtPhieuNhap.Text);
//                object countNotMa = SqlHelper.ExecuteScalar(ConnectionUtil.Instance.GetConnection(), CommandType.Text, sql);
//                cmdShowNotMa.Visible = false;
//                if (Convert.ToInt32(countNotMa) > 0)
//                {
//                    cmdShowNotMa.Visible = true;
//                    cmdShowNotMa.Text = String.Format("{0} mặt hàng có mã không hợp lệ", countNotMa);
//                }

//                sql = String.Format("SELECT t1.SoPhieuNhap, t1.SoPO, ct.IdChungTu, SUM(SoLuong) AS TongSoLuong, N'Hàng bán' AS TrangThai FROM tbl_Tmp_NhapHang t1 "
//                    + "LEFT OUTER JOIN tbl_ChungTu ct ON ct.SoChungTu=t1.SoPhieuNhap AND ct.SoSeri=t1.SoPO AND ct.LoaiChungTu={0} AND ct.IdKho={5} "
//                    + "AND (SELECT TOP (1) soluong FROM tbl_chungtu_chitiet WHERE tbl_chungtu_chitiet.idchungtu = ct.idchungtu)>=0 "
//                    + "WHERE InventoryOrg='{1}' AND InventorySub='{2}' AND ThoiGian < '{3}' AND ThoiGian > '{4}' AND SoLuong >= 0 GROUP BY SoPhieuNhap, SoPO, IdChungTu "
//                    + "UNION ALL "
//                    + "SELECT t1.SoPhieuNhap, t1.SoPO, ct.IdChungTu, SUM(SoLuong) AS TongSoLuong, N'Hàng trả lại' AS TrangThai FROM tbl_Tmp_NhapHang t1 "
//                    + "LEFT OUTER JOIN tbl_ChungTu ct ON ct.SoChungTu=t1.SoPhieuNhap AND ct.SoSeri=t1.SoPO AND ct.LoaiChungTu={0} AND ct.IdKho={5} "
//                    + "AND (SELECT TOP (1) soluong FROM tbl_chungtu_chitiet WHERE tbl_chungtu_chitiet.idchungtu = ct.idchungtu)<0 "
//                    + "WHERE InventoryOrg='{1}' AND InventorySub='{2}' AND ThoiGian < '{3}' AND ThoiGian > '{4}' AND SoLuong < 0 GROUP BY SoPhieuNhap, SoPO, IdChungTu "
//                    + "ORDER BY SoPhieuNhap, SoPO, TongSoLuong DESC",
//                    (int)TransactionType.NHAP,
//                    inventoryOrg,
//                    inventorySub,
//                    dtNgayDongBo.Value.ToString(new CultureInfo("en-US")),
//                    lanDongBoTruoc.ToString(new CultureInfo("en-US")),
//                    Declare.IdKho);
//                dtSoPhieuNhap = DBTools.getData("Tmp", sql).Tables["Tmp"];
//                ArrTemp= null;
//                if (dtSoPhieuNhap.Rows.Count > 0) {
//                    CurrentIndex = 0;
//                    DisplayForm(CurrentIndex);
//                }else{
//                    MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                Common.LogERPSync("Nạp dữ liệu nhập hàng", "Số chứng từ nạp về " + dtSoPhieuNhap.Rows.Count, Declare.IdKho, "", "Nạp dữ liệu thành công", this.dtNgayDongBo.Value);
//            }
//            catch (System.Exception ex) {
//                Common.LogERPSync("Nạp dữ liệu nhập hàng", "Nạp dữ liệu thất bại", Declare.IdKho, "", "Nạp dữ liệu thất bại", this.dtNgayDongBo.Value);
//#if DEBUG
//                MessageBox.Show(ex.ToString());
//#else
//                MessageBox.Show(ex.Message);
//#endif
//            }
//            Cursor.Current = Cursors.Default;
        }

        private void btnPhieuTiepTheo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try {
                if (!IsValid()) return;
                btnGhi_Click(sender, e);
                if(CurrentIndex < dtSoPhieuNhap.Rows.Count - 1) CurrentIndex++;
                DisplayForm(CurrentIndex);
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnPhieuTruocDo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try {
                if (!IsValid()) return;
                btnGhi_Click(sender, e);
                if (CurrentIndex > 0) CurrentIndex--;
                DisplayForm(CurrentIndex);
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnNhapChiTietHangHoa_Click(object sender, EventArgs e)
        {
            try {
                if (dgvList.CurrentRow == null) return;
                if (ArrTemp == null) ArrTemp = new ArrayList();
                if (!dgvList.CurrentRow.IsNewRow) {
                    int _idChiTiet = dgvList.CurrentRow.Cells["IdChungTuChiTiet"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvList.CurrentRow.Cells["IdChungTuChiTiet"].Value);
                    int _idSanPham = dgvList.CurrentRow.Cells["IdSanPham"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvList.CurrentRow.Cells["IdSanPham"].Value);
                    int _soLuong = dgvList.CurrentRow.Cells["SoLuong"].Value == DBNull.Value ? 0 : Convert.ToInt32(dgvList.CurrentRow.Cells["SoLuong"].Value);
                    int _idKho = Common.IntValue(DBTools.getValue("SELECT idkho from tbl_dm_kho WHERE makho='" + cboKho.SelectedValue + "'"));
                    string status = dgvList.CurrentRow.Cells["TrangThai"].Value == DBNull.Value ? "":dgvList.CurrentRow.Cells["TrangThai"].Value.ToString();
                    Form frm=null;
                    if (status.Equals("Hàng trả lại"))
                        frm = new frm_ChungTuNhap_ChiTietHangHoa_TraLai(_idChiTiet, _idSanPham, _soLuong, dgvList.CurrentRow.Cells["TenDonViTinh"].Value.ToString(), Convert.ToDouble(dgvList.CurrentRow.Cells["DonGia"].Value), dgvList.CurrentRow.Cells["colGhiChu"], ArrTemp, inventoryOrg, inventorySub, txtPhieuNhap.Text, txtSoPO.Text);
                    else
                        frm = new frm_ChungTuNhap_ChiTietHangHoa(_idChiTiet, _idSanPham, _soLuong, dgvList.CurrentRow.Cells["TenDonViTinh"].Value.ToString(), Convert.ToDouble(dgvList.CurrentRow.Cells["DonGia"].Value), dgvList.CurrentRow.Cells["colGhiChu"], ArrTemp, _idKho);
                        
                    frm.ShowDialog();
                }
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try {
                if (this.ArrTemp != null && this.ArrTemp.Count > 0)
                {
                    GtidCommand sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = 0;
                    sqlCmd.Transaction = ConnectionUtil.Instance.BeginTransaction();
                    if (_IdChungTu == 0)
                        sqlCmd.CommandText = "sp_ChungTu_NhapHang_Insert";
                    else
                        sqlCmd.CommandText = "sp_ChungTu_NhapHang_Update";
                    sqlCmd.Parameters.AddWithValue("@IdChungTu", _IdChungTu).Direction = ParameterDirection.InputOutput;
                    sqlCmd.Parameters.AddWithValue("@LoaiChungTu", (int)TransactionType.NHAP_PO);
                    sqlCmd.Parameters.AddWithValue("@SoSeri", txtSoPO.Text);
                    sqlCmd.Parameters.AddWithValue("@SoChungTu", txtPhieuNhap.Text);
                    sqlCmd.Parameters.AddWithValue("@NgayLap", DateTime.Parse(txtNgayNhap.Text));
                    sqlCmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                    sqlCmd.Parameters.AddWithValue("@IdNhanVien", Declare.IdNhanVien);
                    sqlCmd.Parameters.AddWithValue("@TongTienHang", Common.DoubleValue(txtTongTienHang.Text));
                    sqlCmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                    sqlCmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName);
                    sqlCmd.Parameters.AddWithValue("@ThoiGianTao", DateTime.Parse(txtThoiGianTaoGD.Text));
                    sqlCmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay);
                    sqlCmd.ExecuteNonQuery();

                    if (_IdChungTu == 0) {
                        _IdChungTu = Convert.ToInt32(sqlCmd.Parameters["@IdChungTu"].Value);
                        dtSoPhieuNhap.Rows[CurrentIndex]["IdChungTu"] = _IdChungTu;
                    }
                    foreach (DataGridViewRow dgr in dgvList.Rows) {
                        foreach (DataTable dt in this.ArrTemp) {
                            if (dt.TableName == dgr.Cells["IdSanPham"].Value.ToString()) {
                                int _IdChungTuChiTiet = dgr.Cells["IdChungTuChiTiet"].Value != DBNull.Value ? Convert.ToInt32(dgr.Cells["IdChungTuChiTiet"].Value) : 0;
                                if (_IdChungTuChiTiet == 0)
                                    sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_Insert";
                                else
                                    sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_Update";
                                sqlCmd.Parameters.Clear();
                                sqlCmd.Parameters.AddWithValue("@IdChiTiet", _IdChungTuChiTiet).Direction = ParameterDirection.InputOutput;
                                sqlCmd.Parameters.AddWithValue("@IdChungTu", _IdChungTu);
                                sqlCmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                                sqlCmd.Parameters.AddWithValue("@SoLuong", dgr.Cells["SoLuong"].Value);
                                sqlCmd.Parameters.AddWithValue("@DonGia", dgr.Cells["DonGia"].Value);
                                sqlCmd.Parameters.AddWithValue("@ThanhTien", dgr.Cells["ThanhTien"].Value);
                                sqlCmd.ExecuteNonQuery();
                                if (_IdChungTuChiTiet == 0)
                                    dgr.Cells["IdChungTuChiTiet"].Value = Convert.ToInt32(sqlCmd.Parameters["@IdChiTiet"].Value);

                                sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_HangHoa_Delete";
                                sqlCmd.Parameters.Clear();
                                sqlCmd.Parameters.AddWithValue("@IdChiTietChungTu", dgr.Cells["IdChungTuChiTiet"].Value);
                                sqlCmd.ExecuteNonQuery();

                                foreach (DataRow dr in dt.Rows) {
                                    if (dr.RowState == DataRowState.Deleted) continue;
                                    sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_HangHoa_Insert";
                                    sqlCmd.Parameters.Clear();
                                    sqlCmd.Parameters.AddWithValue("@IdChiTietChungTu", dgr.Cells["IdChungTuChiTiet"].Value);
                                    sqlCmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                                    sqlCmd.Parameters.AddWithValue("@IdSanPham", dgr.Cells["IdSanPham"].Value);
                                    sqlCmd.Parameters.AddWithValue("@MaVach", dr["MaVach"]);
                                    sqlCmd.Parameters.AddWithValue("@SoLuong", dr["SoLuong"]);
                                    sqlCmd.ExecuteNonQuery();
                                }
                                break;
                            }
                        }
                    }
                    this.ArrTemp = null;
                    Common.LogERPSync("Đồng bộ chứng từ nhập", "IdChungTu = " + _IdChungTu + "; Số chứng từ " + txtPhieuNhap.Text, Declare.IdKho, String.Empty, "Completed", DateTime.Now);
                    ConnectionUtil.Instance.CommitTransaction();
                }
            }
            catch (System.Exception ex) {
                ConnectionUtil.Instance.RollbackTransaction();
                Common.LogERPSync("Đồng bộ chứng từ nhập", ex.Message, Declare.IdKho, String.Empty, "Failed", DateTime.Now);
                throw ex;
            }
        }

        private void frm_ChungTuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                if (dtSoPhieuNhap != null && dtSoPhieuNhap.Rows.Count > 0 && !isFinished && e.CloseReason == CloseReason.UserClosing) {
                    if (MessageBox.Show("Các phiếu mua hàng chưa được cập nhật hết, bạn có thực sự muốn đóng lại không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                        e.Cancel = true;
                        return;
                    }
                    if (!IsValid()) return;
                    btnGhi_Click(sender, e);
                }

                GtidCommand sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                sqlCmd.CommandText = "sp_LockFunction_Update";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FormName", this.GetType().Name);
                sqlCmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                sqlCmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) {
                EventLogProvider.Instance.WriteLog(ex.ToString(), this.Name);
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            try {
                int ind = 0;
                for (ind = 0; ind < dtSoPhieuNhap.Rows.Count; ind++)
                {
                    DataRow row = dtSoPhieuNhap.Rows[ind];
                    if (row["SoPhieuNhap"].ToString().Equals(txtFilterSoHD.Text) && (cboConditionName.SelectedIndex == 0) ||
                        row["SoPO"].ToString().Equals(txtFilterSoHD.Text) && (cboConditionName.SelectedIndex == 1))
                    {
                        if (!IsValid()) return;
                        btnGhi_Click(sender, e);
                        CurrentIndex = ind;
                        DisplayForm(CurrentIndex);
                        break;
                    }
                }
                if (ind == dtSoPhieuNhap.Rows.Count)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào như vậy");
                    return;
                }

            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        protected override object OnSetDataSource()
        {
            DataSet ds = null;
            switch (base.Key) {
                case "Phiếu nhập":
                    ds = dtTempNhapHang.DataSet;
                    break;
                case "Phiếu nhập chi tiết imei":
                    if (this.ArrTemp == null)
                        ds = DBTools.getData("vPhieuNhapKhoChiTietImei", String.Format("SELECT * from vPhieuNhapKhoChiTietImei WHERE SoChungTu=N'{0}'", txtPhieuNhap.Text));
                    else {
                        string tempId = String.Empty;
                        foreach (DataTable dt in this.ArrTemp) {
                            tempId += String.IsNullOrEmpty(tempId) ? dt.TableName : String.Format(",{0}", dt.TableName);
                        }
                        ds = DBTools.getData("vPhieuNhapKhoChiTietImei", String.Format("SELECT * from vPhieuNhapKhoChiTietImei WHERE SoChungTu=N'{0}' AND IdSanPham not in ({1})", txtPhieuNhap.Text, tempId));
                        foreach (DataTable dt in this.ArrTemp) {
                            ds.Tables[0].Merge(dt);
                        }
                    }
                    break;
                case "Các mã sản phẩm không hợp lệ":
                    ds = DBTools.getData("vMaSanPhamKhongHopLe", String.Format("SELECT * from vMaSanPhamKhongHopLe WHERE InventoryOrg=N'{0}' AND InventorySub=N'{1}'", cboTrungTam.SelectedValue, cboKho.SelectedValue));
                    break;
            }
            return ds;
        }
        protected override void OnSetParameterFields(ParameterFields myParams)
        {
            myParams.Clear();
            switch(base.Key){
                case "Phiếu nhập":
                    ut.SetParameterReport(myParams, "TrungTam", cboTrungTam.Text);
                    ut.SetParameterReport(myParams, "Ngay", txtNgayNhap.Text);
                    ut.SetParameterReport(myParams, "SoPhieuNhap", txtPhieuNhap.Text);
                    ut.SetParameterReport(myParams, "Kho", cboKho.Text);
                    ut.SetParameterReport(myParams, "GhiChu", txtGhiChu.Text);
                    ut.SetParameterReport(myParams, "SoTienChu", Common.ReadNumner_(txtTongTienHang.Text));
                    break;
                case "Phiếu nhập chi tiết imei":
                    ut.SetParameterReport(myParams, "TrungTam", cboTrungTam.Text);
                    ut.SetParameterReport(myParams, "Ngay", txtNgayNhap.Text);
                    ut.SetParameterReport(myParams, "SoPhieuNhap", txtPhieuNhap.Text);
                    ut.SetParameterReport(myParams, "Kho", cboKho.Text);
                    ut.SetParameterReport(myParams, "GhiChu", txtGhiChu.Text);
                    break;
                case "Các mã sản phẩm không hợp lệ":
                    ut.SetParameterReport(myParams, "TrungTam", cboTrungTam.Text);
                    ut.SetParameterReport(myParams, "Kho", cboKho.Text);
                    break;
            }
        }
        protected override void OnLoadReport()
        {
            switch(base.Key){
                case "Phiếu nhập":
                    rpt = new rpt_PhieuNhapKho();
                    break;
                case "Phiếu nhập chi tiết imei":
                    rpt = new rpt_PhieuNhapKhoChiTietImei();
                    break;
                case "Các mã sản phẩm không hợp lệ":
                    rpt = new rpt_BC_MatHangChuaCoMa();
                    break;
            }
            base.SetDataSource();
            base.SetParameterFields();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //bool[] options = new bool[] { false, isNotEnough };
                bool[] options = new bool[] { false, false };
                Form frm = new frm_ChungTuNhap_LuaChonIn(options);
                if (frm.ShowDialog() == DialogResult.OK) {
                    if (options[0]) {//chon in phieu nhap kho
                        ShowReport("Phiếu nhập");
                    }
                    if (options[1]) {//chon in phieu nhap kho chi tiet
                        ShowReport("Phiếu nhập chi tiết imei");
                    }
                }                
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif      	
            }
        }

        private void cmdShowNotMa_Click(object sender, EventArgs e)
        {
            try {
                ShowReport("Các mã sản phẩm không hợp lệ");
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnImportNoiDungChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                string[] columns = new string[] { "Số PO", "Số phiếu nhập", "Mã sản phẩm", "Tên sản phẩm", "Mã vạch", "Số lượng", "Đơn giá" };
                string sql, inventoryOrg = currentTrungTam.MaTrungTam, inventorySub = currentKho.MaKho;
                int _IdChungTuChiTiet = 0, _IdSanPham = 0;
                GtidCommand sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                sqlCmd.CommandTimeout = 0;
                DataSet ds = null;
                if (dtSoPhieuNhap == null || dtSoPhieuNhap.Rows.Count == 0) throw new ManagedException("Chưa nạp dữ liệu");
                openFileDialog1.FileName = String.Empty;
                //openFileDialog1.Filter = "*.xls|*.xlsx";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (OleDbConnection oConn = new OleDbConnection())
                    {
                        oConn.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes\"", openFileDialog1.FileName);
                        oConn.Open();
                        string fields = String.Empty;
                        Array.ForEach(columns,
                        delegate(string s)
                        {
                            fields += String.IsNullOrEmpty(fields) ? String.Format("[{0}]", s) : String.Format(", [{0}]", s);
                        });

                        using (OleDbDataAdapter ad = new OleDbDataAdapter(String.Format("SELECT {0} from [{1}$]", fields, "Sheet1"), oConn))
                        {
                            if (ds == null) ds = new DataSet();
                            ad.Fill(ds, "ImportTable");
                            sql = "SELECT [Số phiếu nhập] as SoPhieuNhap, [Số PO] as SoPO, SUM([Số lượng]) as TongSoLuong,"
                                + " SUM([Số lượng]*[Đơn giá]) as ThanhTien FROM [Sheet1$] "
                                + " GROUP BY [Số phiếu nhập], [Số PO]"
                                + " ORDER BY [Số phiếu nhập], [Số PO]";
                            ad.SelectCommand.CommandText = sql;
                            ad.Fill(ds, "PhieuNhap");
                            ad.SelectCommand.CommandText = "SELECT [Số phiếu nhập] as SoPhieuNhap, [Số PO] as SoPO, [Mã sản phẩm] as MaSanPham, SUM([Số lượng]) as SoLuong,"
                                + " (SELECT TOP 1 [Đơn giá] FROM [Sheet1$] t2 WHERE t2.[Số phiếu nhập] = t1.[Số phiếu nhập]"
                                + " AND t2.[Số PO] = t1.[Số PO] AND t2.[Mã sản phẩm] = t1.[Mã sản phẩm]) as DonGia"
                                + " FROM [Sheet1$] as t1"
                                + " GROUP BY [Số phiếu nhập], [Số PO], [Mã sản phẩm]"
                                + " ORDER BY [Số phiếu nhập], [Số PO]";
                            ad.Fill(ds, "PhieuNhapChiTiet");
                        }
                        oConn.Close();
                    }
                    if (dtSoPhieuNhap.Rows.Count != ds.Tables["PhieuNhap"].Rows.Count)
                    {
                        throw new Exception("Tổng số phiếu nhập không khớp, hãy kiểm tra lại file import");
                    }
                    for (int i = 0; i <= ds.Tables["PhieuNhap"].Rows.Count - 1; i++)
                    {
                        if (!Object.Equals(dtSoPhieuNhap.Rows[i]["SoPhieuNhap"], ds.Tables["PhieuNhap"].Rows[i]["SoPhieuNhap"]))
                            throw new Exception(String.Format("Số phiếu nhập {0} không hợp lệ", ds.Tables["PhieuNhap"].Rows[i]["SoPhieuNhap"]));
                        if (!Object.Equals(dtSoPhieuNhap.Rows[i]["SoPO"], ds.Tables["PhieuNhap"].Rows[i]["SoPO"]))
                            throw new Exception(String.Format("Số PO {0} không hợp lệ", ds.Tables["PhieuNhap"].Rows[i]["SoPO"]));
                        if (!Object.Equals(dtSoPhieuNhap.Rows[i]["TongSoLuong"], int.Parse(ds.Tables["PhieuNhap"].Rows[i]["TongSoLuong"].ToString())))
                            throw new Exception(String.Format("Phiếu nhập {0} có tổng số lượng sản phẩm không hợp lệ", ds.Tables["PhieuNhap"].Rows[i]["SoPhieuNhap"]));
                    }

                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i <= ds.Tables["PhieuNhap"].Rows.Count - 1; i++)
                    {
                        sqlCmd.Transaction = ConnectionUtil.Instance.BeginTransaction();
                        DataRow[] foundRows = ds.Tables["PhieuNhapChiTiet"].Select(String.Format("SoPO ='{0}'", ds.Tables["PhieuNhap"].Rows[i]["SoPO"]));
                        if (foundRows.Length > 0)
                        {
                            if (dtSoPhieuNhap.Rows[i]["IdChungTu"] == DBNull.Value)
                            {
                                sqlCmd.CommandText = "sp_ChungTu_NhapHang_Insert";
                            }
                            else
                            {
                                sqlCmd.CommandText = "sp_ChungTu_NhapHang_Update";
                            }
                            sql = "SELECT TOP 1 * FROM tbl_Tmp_NhapHang WHERE SoPO =N'{0}' AND SoPhieuNhap=N'{1}' AND InventoryOrg=N'{2}' AND InventorySub=N'{3}'";
                            sql = String.Format(sql, dtSoPhieuNhap.Rows[i]["SoPO"], dtSoPhieuNhap.Rows[i]["SoPhieuNhap"], inventoryOrg, inventorySub);
                            DataTable dtTemp = DBTools.getData("Temp", sql).Tables["Temp"];

                            sqlCmd.Parameters.Clear();
                            sqlCmd.Parameters.AddWithValue("@IdChungTu", dtSoPhieuNhap.Rows[i]["IdChungTu"]).Direction = ParameterDirection.InputOutput;
                            sqlCmd.Parameters.AddWithValue("@LoaiChungTu", (int)TransactionType.NHAP_PO);
                            sqlCmd.Parameters.AddWithValue("@SoSeri", dtSoPhieuNhap.Rows[i]["SoPO"]);
                            sqlCmd.Parameters.AddWithValue("@SoChungTu", dtSoPhieuNhap.Rows[i]["SoPhieuNhap"]);
                            sqlCmd.Parameters.AddWithValue("@NgayLap", dtTemp.Rows[0]["NgayNhap"]);
                            sqlCmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                            sqlCmd.Parameters.AddWithValue("@IdNhanVien", Declare.IdNhanVien);
                            sqlCmd.Parameters.AddWithValue("@TongTienHang", ds.Tables["PhieuNhap"].Rows[i]["ThanhTien"]);
                            sqlCmd.Parameters.AddWithValue("@GhiChu", dtTemp.Rows[0]["GhiChu"]);
                            sqlCmd.Parameters.AddWithValue("@NguoiTao", Declare.UserName);
                            sqlCmd.Parameters.AddWithValue("@ThoiGianTao", dtTemp.Rows[0]["ThoiGian"]);
                            sqlCmd.Parameters.AddWithValue("@TenMayTao", Declare.TenMay);
                            sqlCmd.ExecuteNonQuery();

                            if (dtSoPhieuNhap.Rows[i]["IdChungTu"] == DBNull.Value)
                            {
                                dtSoPhieuNhap.Rows[i]["IdChungTu"] = sqlCmd.Parameters["@IdChungTu"].Value;
                            }
                            _IdChungTuChiTiet = 0;
                            foreach (DataRow dr in foundRows)
                            {
                                sqlCmd.Parameters.Clear();
                                _IdSanPham = int.Parse(DBTools.getValue(String.Format("SELECT IdSanPham FROM tbl_SanPham WHERE MaSanPham=N'{0}'", dr["MaSanPham"])));
                                //string tmp =DBTools.getValue(String.Format("SELECT IdChiTiet FROM tbl_ChungTu_ChiTiet " +
                                //    "WHERE IdChungTu={0} AND IdSanPham = {1}",
                                //    dtSoPhieuNhap.Rows[i]["IdChungTu"], _IdSanPham));
                                if (int.TryParse(DBTools.getValue(String.Format("SELECT IdChiTiet FROM tbl_ChungTu_ChiTiet " +
                                    "WHERE IdChungTu={0} AND IdSanPham = {1}",
                                    dtSoPhieuNhap.Rows[i]["IdChungTu"], _IdSanPham)), out _IdChungTuChiTiet))
                                {
                                    sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_Update";
                                }
                                else
                                {
                                    sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_Insert";
                                }
                                sqlCmd.Parameters.AddWithValue("@IdChiTiet", _IdChungTuChiTiet).Direction = ParameterDirection.InputOutput;
                                sqlCmd.Parameters.AddWithValue("@IdChungTu", dtSoPhieuNhap.Rows[i]["IdChungTu"]);
                                sqlCmd.Parameters.AddWithValue("@IdSanPham", _IdSanPham);
                                sqlCmd.Parameters.AddWithValue("@SoLuong", dr["SoLuong"]);
                                sqlCmd.Parameters.AddWithValue("@DonGia", dr["DonGia"]);
                                sqlCmd.Parameters.AddWithValue("@ThanhTien", int.Parse(dr["SoLuong"].ToString()) * int.Parse(dr["DonGia"].ToString()));
                                sqlCmd.ExecuteNonQuery();

                                if (_IdChungTuChiTiet == 0)
                                    _IdChungTuChiTiet = Convert.ToInt32(sqlCmd.Parameters["@IdChiTiet"].Value);

                                sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_HangHoa_Delete";
                                sqlCmd.Parameters.Clear();
                                sqlCmd.Parameters.AddWithValue("@IdChiTietChungTu", _IdChungTuChiTiet);
                                sqlCmd.ExecuteNonQuery();

                                DataRow[] foundRows1 = ds.Tables["ImportTable"].Select(String.Format("[Số PO] ='{0}' AND [Số phiếu nhập]='{1}' AND [Mã sản phẩm]='{2}'"
                                    , dr["SoPO"]
                                    , dr["SoPhieuNhap"]
                                    , dr["MaSanPham"]));
                                foreach (DataRow dr1 in foundRows1)
                                {
                                    sqlCmd.CommandText = "sp_ChungTu_NhapHang_ChiTiet_HangHoa_Insert";
                                    sqlCmd.Parameters.Clear();
                                    sqlCmd.Parameters.AddWithValue("@IdChiTietChungTu", _IdChungTuChiTiet);
                                    sqlCmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                                    sqlCmd.Parameters.AddWithValue("@IdSanPham", _IdSanPham);
                                    sqlCmd.Parameters.AddWithValue("@MaVach", dr1["Mã vạch"]);
                                    sqlCmd.Parameters.AddWithValue("@SoLuong", dr1["Số lượng"]);
                                    sqlCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        ConnectionUtil.Instance.CommitTransaction();
                    }

                }
            }
            catch (System.Exception ex)
            {
                try
                {
                    ConnectionUtil.Instance.RollbackTransaction();
                }
                catch { };
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }

    public class ChungTuNhapInfo
    {
        public string SoPhieuNhap { get; set; }
        public string SoPO { get; set; }
        public int IdChungTu { get; set; }
        public int TongSoLuong { get; set; }
        public string TrangThai { get; set; }
    }
}