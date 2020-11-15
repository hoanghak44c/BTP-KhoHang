using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core.Exceptions;

namespace QLBanHang.Modules.KhoHang
{
    public class frm_ChiTietPhieuNhapDieuChuyen : frmChungTuNhap_ChiTietHangHoaBase
    {
        public string soCTG;
        public int IdChungTuChiTiet;
        private NhanDieuChuyenBussiness nhanDieuChuyenBusiness;
        private frmChiTiet_ChungTuNhapBase frm;
        private ChungTuCTHanghoaBasePairInfo liHangHoa;
        public List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet;
        private List<ChungTu_ChiTietHangHoaBaseInfo> ListNTH;
        public frm_ChiTietPhieuNhapDieuChuyen(frmChiTiet_ChungTuNhapBase frm, ChungTuCTHanghoaBasePairInfo li, List<ChungTu_ChiTietHangHoaBaseInfo> liChiTiet, int idChungTuChiTiet)
            : base(frm,li)
        {
            this.frm = frm;
            this.liHangHoa = li;
            this.liChiTiet = liChiTiet;
            this.IdChungTuChiTiet = idChungTuChiTiet;
            ListNTH = NhanDieuChuyenDataProvider.Instance.GetListNhanDieuChuyenBySoPhieu(frm.SoPO);
            //btnThem.Enabled = false;
        }
        protected override bool CellValidating(object objValidating, int colIndex, int rowIndex)
        {
            if (dgvList.Columns[colIndex].Name == "clSoLuong")
            {
                ChungTu_ChiTietHangHoaBaseInfo info =
                ((ChungTu_ChiTietHangHoaBaseInfo)dgvList.CurrentRow.DataBoundItem);
                if (info == null) return true;
                int SLMoi = Convert.ToInt32(objValidating);
                ListNTH.ForEach(delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                {
                    if (match.MaVach == info.MaVach.Trim() && match.IdSanPham == liHangHoa.IdSanPham && match.SoLuong < SLMoi)
                    {
                        throw new ManagedException("Số lượng mã vạch này đã vượt quá số lượng mã vạch đã xuất!");
                    }
                });

                //if (info.SoLuongTT < SLMoi)
                //{
                //    e.Cancel = true;
                //    throw new ManagedException("Số lượng tồn không đủ để xuất !");
                //}
            }
            return base.CellValidating(objValidating, colIndex, rowIndex);
        }
        protected override void AddNewInstance()
        {
            txtMaVach.Text = txtMaVach.Text.Trim();
            if (liChiTiet.Count > 0)
            {
                foreach (ChungTu_ChiTietHangHoaBaseInfo pt in liChiTiet)
                {
                    if (pt.MaVach == txtMaVach.Text)
                    {
                        liChiTiet.ForEach(delegate(ChungTu_ChiTietHangHoaBaseInfo action)
                        {
                            ListNTH.ForEach(delegate(ChungTu_ChiTietHangHoaBaseInfo match)
                            {
                                if (action.IdSanPham == match.IdSanPham &&
                                    action.MaVach == match.MaVach &&
                                    action.SoLuong + 1 > match.SoLuong)
                                {
                                    throw new ManagedException("Số lượng mã vạch này đã vượt quá số lượng mã vạch đã xuất!");
                                }
                            });
                        });
                        pt.SoLuong = pt.SoLuong + 1;
                        pt.ThanhTien = pt.ThanhTien + pt.DonGia;
                        lblTongSoLuong.Text = "";
                        lblthanhtien.Text = "";
                        lblTongSoLuong.Text = count.ToString();
                        lblthanhtien.Text = SoLuongTong.ToString();
                        ((BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dgvList.DataSource).ResetBindings();
                        return;
                    }
                }
            }
            liChiTiet.Add(new ChungTu_ChiTietHangHoaBaseInfo { MaVach = txtMaVach.Text, DonGia = liHangHoa.DonGia, TenDonViTinh = liHangHoa.DonViTinh, SoLuong = 1, ThanhTien = liHangHoa.DonGia, IdSanPham = liHangHoa.IdSanPham });
            ((BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dgvList.DataSource).ResetBindings();
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
                throw new ManagedException("Số lượng mã vạch đã nhập đủ. Không thể xuất thêm !");
            }
            //if (!KhoXuatNccDataProvider.Instance.CheckSoLuong(IdKhoDi, liHangHoa.IdSanPham, txtMaVach.Text))
            //{
            //    throw new ManagedException("Mã vạch hiện không có trong kho. Xin hãy kiểm tra lại !");
            //}
            if (ListNTH.FindAll(delegate(ChungTu_ChiTietHangHoaBaseInfo math)
            {
                return math.MaVach == txtMaVach.Text.Trim() && math.IdSanPham == liHangHoa.IdSanPham;
            }).Count == 0)
            {
                throw new ManagedException("Mã vạch không có trong danh sách mã vạch đã xuất hoặc không đúng với sản phẩm này!");
            }
        }
        protected override void LoadDataInstance()
        {
            //if (liChiTiet.Count == 0)
            //{
            //    List<ChungTu_ChiTietHangHoaBaseInfo> ListNDC =
            //        NhanDieuChuyenDataProvider.Instance.GetListNhanDieuChuyenBySoPhieu(frm.SoPO);
            //    for (int i = 0; i < ListNDC.Count; i++)
            //    {
            //        //chỉ những mã vạch nào của sản phẩm này thì mới add vào
            //        if (liHangHoa.IdSanPham == ListNDC[i].IdSanPham)
            //        {
            //            liChiTiet.Add(new ChungTu_ChiTietHangHoaBaseInfo
            //            {
            //                MaVach = ListNDC[i].MaVach,
            //                //TenDonViTinh = ListNDC[i].TenDonViTinh,
            //                SoLuong = ListNDC[i].SoLuong,
            //                DonGia = ListNDC[i].DonGia,
            //                ThanhTien = ListNDC[i].ThanhTien,
            //                IdChiTietHangHoa = ListNDC[i].IdChiTietHangHoa,
            //                //lay idchitiethanghoa theo chung tu hien tai chu khong phai theo so PO
            //                IdChungTuChiTiet = IdChungTuChiTiet,
            //                IdSanPham = ListNDC[i].IdSanPham
            //            });                        
            //        }
            //    }

            //}
            //dgvList.DataSource = null;
            //((BindingList<ChungTu_ChiTietHangHoaBaseInfo>)dgvList.DataSource).ResetBindings();
            //dgvList.DataSource = liChiTiet;
            dgvList.DataSource = new BindingList<ChungTu_ChiTietHangHoaBaseInfo>(liChiTiet)
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
            // txtMaVach
            // 
            this.txtMaVach.Visible = false;
            // 
            // frm_ChiTietPhieuNhanDieuChuyen
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(657, 490);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChiTietPhieuNhanDieuChuyen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        } 
    }
}
