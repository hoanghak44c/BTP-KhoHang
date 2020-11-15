using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

// form frm_ChiTietMaVach
// Người tạo: Bùi Đức Hạnh
// Ngày tạo : 25/06/2012
// Người sửa cuối:
// Ngày sửa cuối:
//@HanhBD form_ChiTietMaVach
namespace QLBanHang.Modules.KhoHang
{
    public class frm_ChiTietMaVachNhapTieuHao : frmChungTuNhap_ChiTietHangHoaBase
    {
        private int Idkho;
        public int IdChungTuChiTiet;
        private frm_PhieuNhapTieuHao frm;
        List<BaoCao_ChiTietInfor> mv = new List<BaoCao_ChiTietInfor>();
        private ChungTuCTHanghoaBasePairInfo liHangHoa;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        public List<ChungTu_ChiTietHangHoaXTHInfo> liChiTiet;

        //public frm_ChiTietMaVachNhapTieuHao(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaXTHInfo> liChiTiet,int idChungTuChiTiet)
        //    : base(frm,li)
        //{
        //    this.liHangHoa = li;
        //    this.liChiTiet = liChiTiet;
        //    this.IdChungTuChiTiet = idChungTuChiTiet;
        //    btnThem.Enabled = false;
        //}
        public frm_ChiTietMaVachNhapTieuHao(ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaXTHInfo> liChiTiet, int idChungTuChiTiet)
            : base(li)
        {
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
            this.IdChungTuChiTiet = idChungTuChiTiet;
            btnThem.Enabled = false;
        }
        public frm_ChiTietMaVachNhapTieuHao(frm_PhieuNhapTieuHao frm,ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaXTHInfo> liChiTiet, int idChungTuChiTiet)
            : base(li)
        {
            this.frm = frm;
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
            this.IdChungTuChiTiet = idChungTuChiTiet;
        } 

        protected override void AddNewInstance()
        {
            if (liChiTiet.Count > 0)
            {
                foreach (ChungTu_ChiTietHangHoaXTHInfo pt in liChiTiet)
                {
                    if (pt.MaVach == txtMaVach.Text.Trim())
                    {
                        pt.SoLuong = pt.SoLuong + 1;
                        pt.ThanhTien = pt.ThanhTien + pt.DonGia;
                        lblTongSoLuong.Text = "";
                        lblthanhtien.Text = "";
                        lblTongSoLuong.Text = count.ToString();
                        lblthanhtien.Text = SoLuongTong.ToString();
                        ((BindingList<ChungTu_ChiTietHangHoaXTHInfo>)dgvList.DataSource).ResetBindings();
                        return;
                    }
                }
            }
            liChiTiet.Add(new ChungTu_ChiTietHangHoaXTHInfo { MaVach = txtMaVach.Text.Trim(), DonGia = liHangHoa.DonGia, TenDonViTinh = liHangHoa.DonViTinh, SoLuong = 1, ThanhTien = liHangHoa.DonGia, IdSanPham = liHangHoa.IdSanPham,IdChiPhi = liHangHoa.IdChiPhi,IdPhongBan = liHangHoa.IdPhongBan});
            ((BindingList<ChungTu_ChiTietHangHoaXTHInfo>)dgvList.DataSource).ResetBindings();
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
        }
        protected override void DeleteInstance()
        {
            dgvList.Rows.Remove(dgvList.CurrentRow);
            count--;
            SoLuongTong = count * liHangHoa.DonGia;
            //btnXoaDong.Enabled = false;
            lblTongSoLuong.Text = "";
            lblthanhtien.Text = "";
            lblTongSoLuong.Text = count.ToString();
            lblthanhtien.Text = SoLuongTong.ToString();
        }
        protected override void Check()
        {
            int soluong = 0;
            if (liChiTiet.Count != null)
            {
                for (int i = 0; i < liChiTiet.Count; i++)
                {
                    soluong = soluong + liChiTiet[i].SoLuong;
                }
            }
            if (soluong >= Convert.ToInt32(lblSoLuongTon.Text))
            {
                throw new ManagedException("Số lượng mã vạch đã nhập đủ. Không thể nhập thêm !");
            }
            List<ChungTu_ChiTietHangHoaXTHInfo> ListNTH = 
                NhapTieuHaoProvider.Instance.GetListNhanTieuHaoBySoPhieu(frm.SoPO);
            //if(liChiTiet.Count > 0)
            //{
            //    liChiTiet.ForEach(delegate(ChungTu_ChiTietHangHoaXTHInfo itm)
            //    {
                    if (ListNTH.FindAll(delegate(ChungTu_ChiTietHangHoaXTHInfo math)
                    {
                        return math.MaVach == txtMaVach.Text.Trim() && math.IdSanPham == liHangHoa.IdSanPham;
                    }).Count == 0) { throw new ManagedException("Mã vạch không có trong danh sách mã vạch đã xuất!"); }
            //    });
            //}
            
            //mv = NhapNoiBoDataProvider.Instance.GetTrungMaVach(txtMaVach.Text.Trim());
            //if (mv.Count != 0)
            //{
            //    throw new InvalidOperationException("Mã vạch đã có trong hệ thống. Xin mời bạn kiểm tra lại!");
            //}
                
            //if (!KhoXuatNccDataProvider.Instance.CheckSoLuong(Idkho, liHangHoa.IdSanPham, txtMaVach.Text.Trim()))
            //{
            //    throw new ManagedException("Mã vạch hiện không có trong kho. Xin hãy kiểm tra lại !");
            //}
        }  

        protected override void LoadDataInstance()
        {
            //if (liChiTiet.Count == 0)
            //{
            //    List<ChungTu_ChiTietHangHoaXTHInfo> ListNTH =
            //        NhapTieuHaoProvider.Instance.GetListNhanTieuHaoBySoPhieu(frm.SoPO);
            //    for (int i = 0; i < ListNTH.Count; i++)
            //    {
            //        //chỉ những mã vạch nào của sản phẩm này thì mới add vào
            //        if (liHangHoa.IdSanPham == ListNTH[i].IdSanPham)
            //        {
            //            liChiTiet.Add(new ChungTu_ChiTietHangHoaXTHInfo
            //            {
            //                MaVach = ListNTH[i].MaVach,
            //                //TenDonViTinh = ListNDC[i].TenDonViTinh,
            //                SoLuong = ListNTH[i].SoLuong,
            //                DonGia = ListNTH[i].DonGia,
            //                ThanhTien = ListNTH[i].ThanhTien,
            //                IdChiTietHangHoa = ListNTH[i].IdChiTietHangHoa,
            //                //lay idchitiethanghoa theo chung tu hien tai chu khong phai theo so PO
            //                IdChungTuChiTiet = IdChungTuChiTiet,
            //                IdSanPham = ListNTH[i].IdSanPham,
            //                IdChiPhi = ListNTH[i].IdChiPhi,
            //                IdPhongBan = ListNTH[i].IdPhongBan
            //            });
            //        }
            //    }
            //}
            dgvList.DataSource = new BindingList<ChungTu_ChiTietHangHoaXTHInfo>(liChiTiet)
                                         {
                                             AllowEdit = true,
                                             AllowNew = true,
                                             AllowRemove = true,
                                             RaiseListChangedEvents = true
                                         };
                btnXoaDong.Enabled = true;
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
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
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
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
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaVach";
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã vạch";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenDonViTinh";
            this.dataGridViewTextBoxColumn2.HeaderText = "Đơn vị tính";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn3.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DonGia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ThanhTien";
            this.dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "IdSanPham";
            this.dataGridViewTextBoxColumn6.HeaderText = "idsanpham";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TenSanPham";
            this.dataGridViewTextBoxColumn7.HeaderText = "tensanpham";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "MaSanPham";
            this.dataGridViewTextBoxColumn8.HeaderText = "masanpham";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // frm_ChiTietMaVach
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.Name = "frm_ChiTietMaVach";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
