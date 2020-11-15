using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

// form frmChungTuXuat_ChiTietHangHoa
// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:


namespace QLBanHang.Modules.KhoHang
{
    public class frmChungTuXuat_ChiTietHangHoa:frmChungTuNhap_ChiTietHangHoaBase
    {
        private BindingList<ChungTuXuatNccChiTietHangHoaInfo> liNhap;
        private frmChiTiet_ChungTuNhapBase frm;
        private bool isFirst = true;
        private ChungTuCTHanghoaBasePairInfo HangHoa;
        public List<ChungTuXuatNccChiTietHangHoaInfo> liChiTiet;
        public frmChungTuXuat_ChiTietHangHoa(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo HangHoa, List<ChungTuXuatNccChiTietHangHoaInfo> liChiTiet)
            : base(frm, HangHoa)
        {
            InitializeComponent();
            this.frm = frm;
            this.liChiTiet = liChiTiet;
            this.HangHoa = HangHoa;

            #region GenCode
            //lblSL.Text = "Số lượng xuất";
            //dgvList.AutoGenerateColumns = false;
            //dgvList.Columns["clSoLuong"].ReadOnly = true;
            //dgvList.Columns["clSoLuong"].HeaderText = "Số lượng nhập";
            //dgvList.Columns["clSoLuong"].DataPropertyName = "SoLuongNhap";
            //dgvList.Columns["clSoLuong"].DisplayIndex = 4;
            //dgvList.Columns["clDonGia"].DisplayIndex = 6;
            //dgvList.Columns["clThanhtien"].DisplayIndex = 7;
            
            //DataGridViewTextBoxColumn clSoLuongTT = new DataGridViewTextBoxColumn();
            //clSoLuongTT.Name = "clSoLuongTT";
            //clSoLuongTT.HeaderText = "Số lượng thực tế";
            //clSoLuongTT.ReadOnly = true;
            //clSoLuongTT.DisplayIndex = 3;
            //clSoLuongTT.DataPropertyName = "SoLuongTT";
            //dgvList.Columns.Add(clSoLuongTT);

            //DataGridViewTextBoxColumn clSoLuongXuat = new DataGridViewTextBoxColumn();
            //clSoLuongXuat.Name = "clSoLuongXuat";
            //clSoLuongXuat.HeaderText = "Số lượng đã quét";
            //clSoLuongXuat.ReadOnly = false;
            //clSoLuongXuat.DisplayIndex = 5;
            //clSoLuongXuat.DataPropertyName = "SoLuong";
            //dgvList.Columns.Add(clSoLuongXuat);

            //DataGridViewCheckBoxColumn clCheck = new DataGridViewCheckBoxColumn();
            //clCheck.Name = "clCheck";
            //clCheck.DataPropertyName = "TrangThai";
            //clCheck.HeaderText = "Trạng thái";
            //clCheck.DisplayIndex = 0;
            //clCheck.ReadOnly = true;
            //clCheck.Width = 50;
            //dgvList.Columns.Add(clCheck);
            #endregion

            //btnXoaDong.Visible = false;

        }

        protected override void Check()
        {
            //kiem tra ma vach duoc xuat tra co thuoc ve so PO da nhap hay khong
            if (Declare.UserName != "anhdtn1174" && Declare.UserName != "truongpq1174" &&
                KhoXuatNccDataProvider.Instance.CheckMaVach(frm.SoPO,
                    txtMaVach.Text.Trim(),
                    Convert.ToInt32(TransactionType.NHAP_PO),
                    Declare.IdKho) == false)
            {
                throw new ManagedException("Mã vạch không thuộc đơn hàng hoặc đã hết tồn. Xin hãy kiểm tra lại !");
            }
            int soluong = 0;
            for (int i = 0; i < liChiTiet.Count; i++)
            {
                if (liChiTiet[i].TrangThai)
                {
                    soluong = soluong + liChiTiet[i].SoLuong;
                }
            }
            if (soluong >= Convert.ToInt32(lblSoLuongTon.Text))
            {
                throw new InvalidOperationException("Số lượng mã vạch đã đủ. Không thể nhập thêm !");
            }
            //foreach (ChungTu_ChiTietHangHoaTraNCCInfo pt in liChiTiet)
            //{
            //    if (pt.SoLuongThucTe < pt.SoLuong)
            //    {
            //        throw new InvalidOperationException("Số lượng tồn không đủ để xuất !");
            //    }
            //}
        }

        protected override void DeleteInstance()
        {
            if (NhapThanhPhamSanXuatDataProvider.Instance.CheckMaVachByKho(Convert.ToInt32(dgvList.CurrentRow.Cells["clidsanpham"].Value), dgvList.CurrentRow.Cells["clMaVach"].Value.ToString(), Convert.ToInt32(dgvList.CurrentRow.Cells["clSoLuong"].Value)) > 0)
            {
                dgvList.Rows.Remove(dgvList.CurrentRow);
                count--;
                SoLuongTong = count * HangHoa.DonGia;
                //btnXoaDong.Enabled = false;
                lblTongSoLuong.Text = "";
                lblthanhtien.Text = "";
                lblTongSoLuong.Text = count.ToString();
                lblthanhtien.Text = SoLuongTong.ToString();
            }
            else
            {
                clsUtils.MsgCanhBao("Mã vạch đã hết tồn không thể xóa được !");
            }
        }

        protected override void LoadDataInstance()
        {
            //liNhap =
            //   new BindingList<ChungTuXuatNccChiTietHangHoaInfo>(
            //       KhoNhapNccDataProvider.Instance.ChungTuChiTietHangHoaGetBySoPO(frm.SoPO,Convert.ToInt32(TransactionType.TRA_LAI_PO)));
            //if (liChiTiet.Count > 0)
            //{
            //    foreach (ChungTuXuatNccChiTietHangHoaInfo pt in liNhap)
            //    {
            //        for (int i = 0; i < liChiTiet.Count; i++)
            //        {
            //            if (pt.MaVach == liChiTiet[i].MaVach && pt.IdSanPham == liChiTiet[i].IdSanPham)
            //            {
            //                pt.SoLuong = liChiTiet[i].SoLuong;
            //            }
            //        }
            //    }
            //}
            //liChiTiet.Clear();
            //foreach (ChungTuXuatNccChiTietHangHoaInfo pt in liNhap)
            //{
            //    if (pt.IdSanPham == frm.IdSanPham)
            //    {
            //        liChiTiet.Add(pt);
            //    }
            //}
            dgvList.DataSource = new BindingList<ChungTuXuatNccChiTietHangHoaInfo>(liChiTiet)
            {
                AllowEdit = true,
                AllowNew = true,
                AllowRemove = true,
                RaiseListChangedEvents = true
            };
            foreach (ChungTuXuatNccChiTietHangHoaInfo pt in liChiTiet)
            {
                count = count + pt.SoLuongNhap;
                SoLuongTong = count * pt.DonGia;
            }
            lblTongSoLuong.Text = SoLuongTong.ToString();
            lblthanhtien.Text = count.ToString();
        }

        protected override void AddNewInstance()
        {
            if (liChiTiet.Count > 0)
            {
                foreach (ChungTuXuatNccChiTietHangHoaInfo pt in liChiTiet)
                {
                    if (pt.MaVach == txtMaVach.Text.Trim())
                    {
                        pt.SoLuong = pt.SoLuong + 1;
                        pt.ThanhTien = pt.ThanhTien + pt.DonGia;
                        lblTongSoLuong.Text = "";
                        lblthanhtien.Text = "";
                        lblTongSoLuong.Text = count.ToString();
                        lblthanhtien.Text = SoLuongTong.ToString();
                        ((BindingList<ChungTuXuatNccChiTietHangHoaInfo>)dgvList.DataSource).ResetBindings();
                        return;
                    }
                }
            }
            liChiTiet.Add(new ChungTuXuatNccChiTietHangHoaInfo { MaVach = txtMaVach.Text.Trim(), DonGia = HangHoa.DonGia, TenDonViTinh = HangHoa.DonViTinh, SoLuong = 1, ThanhTien = HangHoa.DonGia, IdSanPham = HangHoa.IdSanPham,TransactionID = HangHoa.TransactionID});
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
            ((BindingList<ChungTuXuatNccChiTietHangHoaInfo>)dgvList.DataSource).ResetBindings();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaVach
            // 
            this.txtMaVach.TextChanged += new System.EventHandler(this.txtMaVach_TextChanged);
            // 
            // dgvList
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            this.dgvList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvList_CellValidating);
            //this.dgvList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellEnter);
            this.dgvList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvList_DataBindingComplete);
            // 
            // frmChungTuXuat_ChiTietHangHoa
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.Name = "frmChungTuXuat_ChiTietHangHoa";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //foreach (DataGridViewRow dataGridViewRow in dgvList.Rows)
            //{
            //    if (!dataGridViewRow.IsNewRow)
            //    {
            //        dataGridViewRow.Cells["clSoLuongTT"].Value =
            //            ((ChungTu_ChiTietHangHoaTraNCCInfo)dataGridViewRow.DataBoundItem).SoLuongThucTe;
            //        dataGridViewRow.Cells["clSoLuong"].Value =
            //            ((ChungTu_ChiTietHangHoaTraNCCInfo)dataGridViewRow.DataBoundItem).SoLuongNhap;
            //    }
            //}
        }

        private void txtMaVach_TextChanged(object sender, EventArgs e)
        {
            if(isFirst)
            {
                //do something
                isFirst = false;
            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "clSoLuongXuat")
            {
                ChungTu_ChiTietHangHoaTraNCCInfo info =
                ((ChungTu_ChiTietHangHoaTraNCCInfo)dgvList.CurrentRow.DataBoundItem);
                info.SoLuongThucTe = SLCu - info.SoLuong;
            }
        }

        private void dgvList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                ChungTuXuatNccChiTietHangHoaInfo info =
                ((ChungTuXuatNccChiTietHangHoaInfo)dgvList.CurrentRow.DataBoundItem);
                if (dgvList.Columns[e.ColumnIndex].Name == "clSoLuongXuat")
                {
                    int SLMoi = Convert.ToInt32(e.FormattedValue);
                    if (SLMoi > SLCu)
                    {
                        if (info.SoLuongTT < SLMoi)
                        {
                            e.Cancel = true;
                            throw new ManagedException("Số lượng tồn không đủ để xuất !");
                        }
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

    }
}
