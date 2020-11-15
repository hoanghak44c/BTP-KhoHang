using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using QLBanHang.Class;
using System.Collections;
using QLBanHang.Properties;
using QLBH.Common;

namespace QLBanHang.Forms
{
    public partial class frmCapNhatTonDauKy_ChiTietHangHoa : Form
    {
        int _IdSanPham = 0;
        int _IdDuDauKy = 0;
        double _DonGia = 0;
        string _dvt = String.Empty;
        List<int> _DeletedTemp = null;
        DataGridViewCell SoluongCell;
        DataGridViewCell ThanhTienCell;
        DataGridViewCell TenDonViTinhCell;
        DataTable dtChungTuChiTietHangHoa;
        ArrayList arrTemp;
        bool TrungMaVach = false;
        int iSoLuongKhaiBao;
        int _IdKho;

        public frmCapNhatTonDauKy_ChiTietHangHoa()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }

        public frmCapNhatTonDauKy_ChiTietHangHoa(int pIdSanPham, int pIdDuDauKy, DataGridViewCell pSoluong, DataGridViewCell pThanhTien,
            DataGridViewCell pTenDonViTinh, ArrayList pArrTemp, List<int> pDeletedTemp, double pGiaNhap, int pSoLuongKhaiBao)
        {
            InitializeComponent();
            this._IdSanPham = pIdSanPham;
            this._IdDuDauKy = pIdDuDauKy;
            this.SoluongCell = pSoluong;
            this.ThanhTienCell = pThanhTien;
            this._DonGia = pGiaNhap;
            this.TenDonViTinhCell = pTenDonViTinh;
            this.arrTemp = pArrTemp;
            _DeletedTemp = pDeletedTemp;
            iSoLuongKhaiBao = pSoLuongKhaiBao;
            Common.LoadStyle(this);
        }

        public frmCapNhatTonDauKy_ChiTietHangHoa(int pIdSanPham, int pIdDuDauKy, DataGridViewCell pSoluong, DataGridViewCell pThanhTien,
            DataGridViewCell pTenDonViTinh, ArrayList pArrTemp, List<int> pDeletedTemp, double pGiaNhap, int pSoLuongKhaiBao, int pIdKho)
        {
            InitializeComponent();
            this._IdSanPham = pIdSanPham;
            this._IdDuDauKy = pIdDuDauKy;
            this.SoluongCell = pSoluong;
            this.ThanhTienCell = pThanhTien;
            this._DonGia = pGiaNhap;
            this.TenDonViTinhCell = pTenDonViTinh;
            this.arrTemp = pArrTemp;
            _DeletedTemp = pDeletedTemp;
            iSoLuongKhaiBao = pSoLuongKhaiBao;
            Common.LoadStyle(this);
            _IdKho = pIdKho;
        }
        private void frmCapNhatTonDauKy_ChiTietHangHoa_Load(object sender, EventArgs e)
        {
            string sql = "select sp.MaSanPham, sp.TenSanPham, sp.GiaNhap, dvt.TenDonViTinh from tbl_SanPham sp";
            sql += " inner join tbl_DM_DonViTinh dvt on dvt.IdDonViTinh= sp.IdDonViTinh";
            sql += " where sp.IdSanPham= " + _IdSanPham;
            DataTable dt = DBTools.getData("Temp", sql).Tables["Temp"];
            if (dt != null & dt.Rows.Count > 0) {
                lblMa.Text = dt.Rows[0]["MaSanPham"].ToString() + " - " + dt.Rows[0]["TenSanPham"].ToString();
                _dvt = dt.Rows[0]["TenDonViTinh"].ToString();
                //_DonGia = Convert.ToDouble(dt.Rows[0]["GiaNhap"]);
                lblSoLuongTon.Text = iSoLuongKhaiBao.ToString();

                lblTongSoLuong.Text = "0";

            }

            object tmp = DBTools.ExecuteScalar(String.Format("select TrungMaVach from tbl_SanPham where IdSanPham={0}", _IdSanPham));
            if (tmp != DBNull.Value) {
                TrungMaVach = (bool)tmp;
                if (TrungMaVach)
                    dgvList.Columns["SoLuong"].ReadOnly = false;
            }
            if (this.arrTemp != null) {
                foreach (DataTable dtTemp in this.arrTemp) {
                    if (dtTemp.TableName == _IdSanPham.ToString()) {
                        dtChungTuChiTietHangHoa = dtTemp;
                        break;
                    }
                }
            }
            if (dtChungTuChiTietHangHoa != null) {
                dgvList.DataSource = dtChungTuChiTietHangHoa;
                dgvList.Refresh();
            }
            lblTongSoLuong.Text = TongSoLuong().ToString();
            lblTongThanhTien.Text = Common.Double2Str(TongThanhTien());
            SelectText();

            EnableFunctions();
        }

        private void EnableFunctions()
        {
            bool status = Common.IsEnableNhapDauKy(_IdKho);
            btnGhi.Enabled = status;
            btnThem.Enabled = status;
            btnRemove.Enabled = status;
            txtMaVach.Enabled = status;
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            try {
                int sum = TongSoLuong();
                if (sum != iSoLuongKhaiBao) {
                    //if (MessageBox.Show("Số lượng nhập vào sẽ lớn hơn số lượng tồn ban đầu, bạn có muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    //    return;

                    MessageBox.Show("Số lượng nhập phải bằng số lượng tồn ban đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (dtChungTuChiTietHangHoa != null && dtChungTuChiTietHangHoa.Rows.Count > 0) {
                    foreach (DataTable dt in this.arrTemp) {
                        if (dt.TableName == _IdSanPham.ToString()) {
                            this.arrTemp.Remove(dt);
                            break;
                        }
                    }
                    this.arrTemp.Add(dtChungTuChiTietHangHoa);
                }

                this.SoluongCell.Value = TongSoLuong();
                this.ThanhTienCell.Value = TongThanhTien();
                this.TenDonViTinhCell.Value = _dvt;

                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show(ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try {
                txtMaVach.Text = txtMaVach.Text.Replace("'", "");
                SelectText();
                if (txtMaVach.Text == String.Empty) return;
                string sql = "select ct.IdSanPham, sp.MaSanPham, sp.TenSanPham " +
                            "from tbl_HangHoa_Chitiet ct inner join tbl_SanPham sp on ct.IdSanPham = sp.IdSanPham " +
                            " where ct.MaVach=N'" + txtMaVach.Text + "' and (ct.IdSanPham <> " + _IdSanPham + " or (ct.IdSanPham = " + _IdSanPham +
                            " and ct.IdKho = " + _IdKho + " and ct.SoLuong > 0 and (sp.TrungMaVach = 0 or sp.TrungMaVach is null)))";

                DataTable dtTmp = DBTools.getData("Tmp", sql).Tables["Tmp"];
                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {
                    string msg = String.Format("Mã vạch này đã được sử dụng cho sản phẩm mã:\n{0} - {1} hoặc đã tồn tại trong rồi.\nNhập mã vạch khác hoặc xóa mã vạch đã sử dụng",
                                    dtTmp.Rows[0]["MaSanPham"], dtTmp.Rows[0]["TenSanPham"]);
                    MessageBox.Show(msg);
                    return;
                }

                foreach (DataTable dtemp in this.arrTemp) {
                    if (dtemp != null && dtemp.TableName != _IdSanPham.ToString() && dtemp.Select("MaVach='" + txtMaVach.Text + "'").Length > 0) {
                        string msg = DBTools.getValue("Select MaSanpham + ' - ' + TenSanPham From tbl_SanPham Where IdSanPham = " + dtemp.TableName);
                        MessageBox.Show(String.Format("Mã vạch này đã được sử dụng cho sản phẩm:\n{0}.\nNhập mã vạch khác hoặc xóa mã vạch đã sử dụng",msg));
                        return;
                    }
                }
                //if (TongSoLuong() != iSoLuongKhaiBao) {
                //    //if (MessageBox.Show("Số lượng nhập vào sẽ lớn hơn số lượng tồn ban đầu, bạn có muốn tiếp tục không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                //    //    return;

                //    MessageBox.Show("Số lượng nhập phải bằng số lượng tồn ban đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                foreach (DataGridViewRow dgr in dgvList.Rows) {
                    if (dgr.Cells["MaVach"].Value.ToString().Equals(txtMaVach.Text)) {
                        if(!TrungMaVach){
                            MessageBox.Show("Loại sản phẩm này không được phép nhập trùng mã vạch");
                            return;
                        }
                        dgvList.CurrentCell = dgr.Cells["SoLuong"];
                        int sl = TongSoLuong();
                        if (sl == iSoLuongKhaiBao)
                        {
                            MessageBox.Show("Số lượng sản phẩm đã nhập đủ!");
                            return;
                        }
                        dgvList.CurrentCell.Value = Common.IntValue(dgvList.CurrentCell.Value.ToString()) + 1;
                        return;
                    }
                }

                object[] fields = {
                        txtMaVach.Text,
                        _dvt,
                        1,
                        _DonGia,
                        _DonGia,
                        0
                    };
                DataTable currentTable = null;
                foreach (DataTable dtemp in this.arrTemp) {
                    if (dtemp != null && dtemp.TableName == _IdSanPham.ToString()) {
                        currentTable = dtemp;
                        break;
                    }
                }
                if (currentTable != null) {
                    currentTable.Rows.Add(fields);
                    dgvList.DataSource = currentTable;
                    dgvList.Refresh();
                }
                else {
                    DataTable dt = new DataTable(_IdSanPham.ToString());
                    dt.Columns.Add("MaVach", typeof(String));
                    dt.Columns.Add("TenDonViTinh", typeof(String));
                    dt.Columns.Add("SoLuong", typeof(Double));
                    dt.Columns.Add("GiaNhap", typeof(Double));
                    dt.Columns.Add("ThanhTien", typeof(Double));
                    dt.Columns.Add("IdChiTietHangHoa", typeof(int));
                    dt.Rows.Add(fields);
                    this.arrTemp.Add(dt);
                    dgvList.DataSource = dt;
                    dgvList.Refresh();
                }
                lblTongSoLuong.Text = TongSoLuong().ToString();
                lblTongThanhTien.Text = Common.Double2Str(TongThanhTien());
            }
            catch (System.Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "SoLuong") {
                int sum = TongSoLuong();
                if (sum > iSoLuongKhaiBao) {
                    MessageBox.Show("Số lượng nhập phải bằng số lượng tồn ban đầu", Resources.WaringTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                dgvList.CurrentRow.Cells["ThanhTien"].Value = Convert.ToInt32(dgvList.CurrentRow.Cells["SoLuong"].Value) * _DonGia;
                lblTongSoLuong.Text = sum.ToString();
                lblTongThanhTien.Text = Common.Double2Str(TongThanhTien());
                foreach (DataTable dt in this.arrTemp) {
                    if (dt.TableName == _IdSanPham.ToString()) {
                        dt.Rows[e.RowIndex]["SoLuong"] = dgvList.CurrentRow.Cells["SoLuong"].Value;
                        break;
                    }
                }
            }
        }

        private int TongSoLuong() {
            int result = 0;
            foreach (DataGridViewRow dgr in dgvList.Rows) {
                result += int.Parse(dgr.Cells["SoLuong"].Value.ToString());
            }
            return result;
        }

        private double TongThanhTien()
        {
            double result = 0;
            foreach (DataGridViewRow dgr in dgvList.Rows) {
                if (dgr.Cells["ThanhTien"].Value != System.DBNull.Value) {
                    result += Convert.ToDouble(dgr.Cells["ThanhTien"].Value);
                }
            }
            return result;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow == null) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                DataTable currentTable = null;
                foreach (DataTable dtemp in this.arrTemp) {
                    if (dtemp.TableName == _IdSanPham.ToString()) {
                        currentTable = dtemp;
                        break;
                    }
                }
                if (currentTable != null) {
                    foreach (DataRow dr in currentTable.Rows) {
                        if (dr["MaVach"].ToString() == dgvList.CurrentRow.Cells["MaVach"].Value.ToString()) {
                            _DeletedTemp.Add(Convert.ToInt32(dr["IdChiTietHangHoa"]));
                            currentTable.Rows.Remove(dr);
                            //dgvList.Rows.Remove(dgvList.CurrentRow);
                            break;
                        }
                    }
                    dgvList.DataSource = currentTable;
                    dgvList.Refresh();
                }

                lblTongSoLuong.Text = TongSoLuong().ToString();
                lblTongThanhTien.Text = Common.Double2Str(TongThanhTien());

            }
        }

        private void SelectText()
        {
            txtMaVach.SelectionStart = 0;
            txtMaVach.SelectionLength = txtMaVach.Text.Length;
        }

        private void txtMaVach_Enter(object sender, EventArgs e)
        {
            SelectText();
        }

        private void txtMaVach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) {
                if (txtMaVach.Text.Trim() != "")
                    btnThem_Click(sender, null);
            }

        }

        private void txtMaVach_DoubleClick(object sender, EventArgs e)
        {
            SelectText();
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvList.Rows[e.RowIndex].IsNewRow) return;
            if (dgvList.Columns[e.ColumnIndex].Name == "SoLuong") {
                if (!Common.IsInteger32(e.FormattedValue.ToString())) {
                    e.Cancel = true;
                    MessageBox.Show("Chưa nhập đúng định dạng kiểu số nguyên");
                }
            }
            //int sl = TongSoLuong();
            //if (sl > iSoLuongKhaiBao)
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("Số sản phẩm nhập không được vượt quá số lượng khai báo");
            //}
        }

    }
}