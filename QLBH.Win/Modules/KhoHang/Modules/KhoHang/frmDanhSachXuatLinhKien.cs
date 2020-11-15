using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;
using QLBH.Core;
using QLBH.Core.Infors;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmDanhSachXuatLinhKien : DevExpress.XtraEditors.XtraForm
    {
        private int OID, oldOID;
        private readonly string maLenh;
        private readonly DataGridViewColumn[] arrMaThanhPhamColumns;
        private readonly DataGridViewColumn[] arrMaLinhKienColumns;
        private HangHoa_ChiTietInfo[] arrMaThanhPhamRows, arrMaLinhKienRows;
        private List<HangHoa_ChiTietInfo> listMaVach;
        private TransactionType transactionType;
        public frmDanhSachXuatLinhKien(string malenh, TransactionType transactionType)
        {
            InitializeComponent();
            this.transactionType = transactionType;
            dgvListXLK.Columns.Clear();
            dgvListXLK.AutoGenerateColumns = false;
            arrMaThanhPhamColumns =
                new[]
                    {
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "MaVach",
                                HeaderText = "Thành phẩm",
                                ReadOnly = true,
                                Width = 200,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "SoLuong",
                                HeaderText = "S.lượng",
                                ReadOnly = true,
                                Width = 70,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "ChungTuXuatLinhKien",
                                HeaderText = "Phiếu xuất",
                                ReadOnly = true,
                                Width = 100,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "ChungTuNhapThanhPham",
                                HeaderText = "Phiếu nhập",
                                ReadOnly = true,
                                Width = 100,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "NgayXuatLinhKien",
                                HeaderText = "Ngày xuất",
                                ReadOnly = true,
                                Width = 150,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "TrangThai",
                                HeaderText = "Trạng thái",
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                                ReadOnly = true,
                            },
                    };

            arrMaLinhKienColumns =
                new[]
                    {
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "MaVach",
                                HeaderText = "Linh kiện",
                                ReadOnly = true,
                                Width = 200,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "SoLuong",
                                HeaderText = "S.lượng",
                                ReadOnly = true,
                                Width = 70,
                            },
                        new DataGridViewTextBoxColumn
                            {
                                DataPropertyName = "TenSanPham",
                                HeaderText = "Tên linh kiện",
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                                ReadOnly = true,
                            }
                    };
            dgvListXLK.Columns.AddRange(arrMaThanhPhamColumns);
            dgvListXLK.MultiSelect = false;
            if (dgvListXLK.ContextMenu == null) dgvListXLK.ContextMenu = new ContextMenu();
            this.maLenh = malenh;
        }

        private void frmDanhSachXuatLinhKien_Load(object sender, EventArgs e)
        {
            listMaVach = tblChungTuDataProvider.GetListXLK1(maLenh, transactionType);
            arrMaThanhPhamRows = new HangHoa_ChiTietInfo[listMaVach.Count];
            listMaVach.CopyTo(arrMaThanhPhamRows);
            Reset<ChiTietMaVachThanhPham>(arrMaThanhPhamColumns, arrMaThanhPhamRows);
        }

        private BindingList<T>GetDataSource<T>() where T : class
        {
            return new BindingList<T>(
                listMaVach.ConvertAll(
                    delegate(HangHoa_ChiTietInfo item)
                        {
                            return item as T;
                        }));
        }

        private void btnInphieu_Click(object sender, EventArgs e)
        {
            List<BaoCao_ChiTietInfor> list = tblChungTuDataProvider.GetPhieuXuatLKDetail(OID);
            rpt_BC_PhieuXuatLK rpt = new rpt_BC_PhieuXuatLK();
            List<BaoCao_ChiTietInfor> lst = new List<BaoCao_ChiTietInfor>(list);
            rpt.DataSource = lst;
            rpt.ShowPreview();
        }

        private void dgvListXLK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !(dgvListXLK.Rows[e.RowIndex].DataBoundItem is ChiTietMaVachThanhPham)) return;

            OID = ((ChiTietMaVachThanhPham)dgvListXLK.Rows[e.RowIndex].DataBoundItem).IdChungTu;
            
        }

        private void Reset<T>(DataGridViewColumn[] columns, HangHoa_ChiTietInfo[] listData) where T : class
        {
            Reset<T>(columns, listData, -1);
        }

        private void Reset<T>(DataGridViewColumn[] columns, HangHoa_ChiTietInfo[] listData, int rowIndex) where T : class
        {
            if (listMaVach.Count > 0 && listMaVach[0] is ChiTietMaVachThanhPham && dgvListXLK.SelectedRows.Count > 0)
            {
                rowIndex = dgvListXLK.SelectedRows[0].Index;
            }

            listMaVach.Clear();

            dgvListXLK.ResetBindings();

            dgvListXLK.Columns.Clear();

            dgvListXLK.Columns.AddRange(columns);

            if ((listData == null || listData[0] is ChiTietMaVachLinhKien) && oldOID != OID)
            {
                listMaVach.AddRange(tblChungTuDataProvider.GetPhieuXuatLKDetail1(OID));

                arrMaLinhKienRows = new HangHoa_ChiTietInfo[listMaVach.Count];

                listMaVach.CopyTo(arrMaLinhKienRows);

                oldOID = OID;
            }
            else if (listData != null)
            {
                listMaVach.AddRange(listData);
            }

            dgvListXLK.DataSource = GetDataSource<T>();

            dgvListXLK.ResetBindings();

            if (listMaVach.Count > 0 && listMaVach[0] is ChiTietMaVachThanhPham && rowIndex >= 0 && rowIndex < dgvListXLK.Rows.Count)
            {
                dgvListXLK.Rows[rowIndex].Selected = true;
                dgvListXLK.FirstDisplayedScrollingRowIndex = rowIndex;
            }

            dgvListXLK.ContextMenu.MenuItems.Clear();

            if (listMaVach[0] is ChiTietMaVachLinhKien)
            {
                dgvListXLK.ContextMenu.MenuItems.
                    Add("Quay lại",
                        delegate
                            {
                                Reset<ChiTietMaVachThanhPham>(arrMaThanhPhamColumns, arrMaThanhPhamRows, rowIndex);
                            });
            } 
            else
            {
                dgvListXLK.ContextMenu.MenuItems.
                    Add("Chi tiết linh kiện lắp ráp",
                        delegate
                        {
                            Reset<ChiTietMaVachLinhKien>(arrMaLinhKienColumns, arrMaLinhKienRows);
                        });
            }

            this.dgvListXLK.ContextMenu.MenuItems.Add("In phiếu", btnInphieu_Click);
        }

        private void dgvListXLK_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.dgvListXLK.ContextMenu != null)
            {
                int rowIndex = dgvListXLK.HitTest(e.X, e.Y).RowIndex;

                if (rowIndex < 0 && dgvListXLK.SelectedRows.Count == 1)
                {
                    rowIndex = dgvListXLK.SelectedRows[0].Index;
                }
                
                if (rowIndex >= 0 && (dgvListXLK.Rows[rowIndex].DataBoundItem is ChiTietMaVachThanhPham))
                {
                    dgvListXLK.Rows[rowIndex].Selected = true;

                    OID = ((ChiTietMaVachThanhPham)dgvListXLK.Rows[rowIndex].DataBoundItem).IdChungTu;
                }

                this.dgvListXLK.ContextMenu.Show(dgvListXLK, e.Location);
            }
        }
    }
}