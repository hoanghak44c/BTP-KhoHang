using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Form;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frmBaoCaoTongHopSanXuat : DevExpress.XtraEditors.XtraForm
    {
        List<MaVachSXReportInfo> lichitiet = new List<MaVachSXReportInfo>();
        List<LookUp> lst = new List<LookUp>();
        private string MaTrungTam;
        private int MaKho;
        private int IdTrungTam;
        public frmBaoCaoTongHopSanXuat()
        {
            InitializeComponent();
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadLoaiSanXuat()
        {
            lst.Add(new LookUp { OID = 7, Name = "Xuất linh kiện sản xuất" });
            lst.Add(new LookUp { OID = 44, Name = "Xuất ComBo" });
            lst.Add(new LookUp { OID = 46, Name = "Xuất đổi mã" });
            lst.Add(new LookUp { OID = 30, Name = "Tách thành phẩm sản xuất" });
            lst.Add(new LookUp { OID = 2, Name = "Nhập thành phẩm sản xuất" });
            lst.Add(new LookUp { OID = 43, Name = "Nhập ComBo" });
            lst.Add(new LookUp { OID = 45, Name = "Nhập đổi mã" });
            lst.Add(new LookUp { OID = 31, Name = "Nhập linh kiện sản xuất" });
            repLoaiSX.DataSource = null;
            repLoaiSX.DataSource = lst;
        }
        private void LoadLoaiGiaoDich()
        {
            List<LookUp> ligiaodich = new List<LookUp>();
            ligiaodich.Add(new LookUp { OID = 7, Name = "Xuất linh kiện sản xuất" });
            ligiaodich.Add(new LookUp { OID = 44, Name = "Xuất ComBo" });
            ligiaodich.Add(new LookUp { OID = 46, Name = "Xuất đổi mã" });
            ligiaodich.Add(new LookUp { OID = 30, Name = "Tách thành phẩm sản xuất" });
            ligiaodich.Add(new LookUp { OID = 2, Name = "Nhập thành phẩm sản xuất" });
            ligiaodich.Add(new LookUp { OID = 43, Name = "Nhập ComBo" });
            ligiaodich.Add(new LookUp { OID = 45, Name = "Nhập đổi mã" });
            ligiaodich.Add(new LookUp { OID = 31, Name = "Nhập linh kiện sản xuất" });
            lueLoaiGiaoDich.Properties.DataSource = null;
            lueLoaiGiaoDich.Properties.DataSource = ligiaodich;
            lueLoaiGiaoDich.EditValue = ligiaodich[0].OID;
        }
        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
                IdTrungTam = frm.SelectedItem.IdTrungTam;
                bteKho.Text = "";
            }
        }

        private void bteTrungTam_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frm.SelectedItem;
                bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                MaTrungTam = frm.SelectedItem.MaTrungTam;
                IdTrungTam = frm.SelectedItem.IdTrungTam;
                bteKho.Text = "";
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frm = new frmLookUp_TrungTam(false, String.Format("%{0}%", bteTrungTam.Text), Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Tag = frm.SelectedItem;
                    bteTrungTam.Text = frm.SelectedItem.TenTrungTam;
                    MaTrungTam = frm.SelectedItem.MaTrungTam;
                    IdTrungTam = frm.SelectedItem.IdTrungTam;
                    bteKho.Text = "";
                }
            }
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.IdKho;
            }
        }

        private void bteKho_DoubleClick(object sender, EventArgs e)
        {
            frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bteKho.Tag = frm.SelectedItem;
                bteKho.Text = frm.SelectedItem.TenKho;
                MaKho = frm.SelectedItem.IdKho;
            }
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frm = new frmLookUp_Kho(false, String.Format("%{0}%", bteKho.Text), IdTrungTam, Declare.IdNhanVien);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Tag = frm.SelectedItem;
                    bteKho.Text = frm.SelectedItem.TenKho;
                    MaKho = frm.SelectedItem.IdKho;
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            frmProgress.Instance.Text = "Tổng hợp dữ liệu sản xuất";
            frmProgress.Instance.Description = "Đang load dữ liệu ...";
            frmProgress.Instance.Value = 0;

            DateTime ngayLapFrom, ngayLapTo, ngayNxFrom, ngayNxTo, calcFrom, calcTo;
            DateTime currentDate = CommonProvider.Instance.GetSysDate();
            ngayLapFrom = deFrom.DateTime == DateTime.MinValue ? new DateTime(2013, 5, 1) : deFrom.DateTime;
            ngayLapTo = deTo.DateTime == DateTime.MinValue ? currentDate : deTo.DateTime;
            ngayNxFrom = NXfrom.DateTime == DateTime.MinValue ? new DateTime(2013, 5, 1) : NXfrom.DateTime;
            ngayNxTo = NXto.DateTime == DateTime.MinValue ? currentDate : NXto.DateTime;
            TimeSpan ngayLapTimeSpan = ngayLapTo - ngayLapFrom;
            TimeSpan ngayNxTimeSpan = ngayNxTo - ngayNxFrom;
            bool isCalcByNgayLap = false;
            
            calcFrom = ngayNxFrom;
            calcTo = ngayNxTo;
            if (ngayLapTimeSpan.TotalDays < ngayNxTimeSpan.TotalDays)
            {
                calcFrom = ngayLapFrom;
                calcTo = ngayLapTo;
                isCalcByNgayLap = true;
            }

            frmProgress.Instance.MaxValue = isCalcByNgayLap
                                                ? Convert.ToInt32(ngayLapTimeSpan.TotalDays)
                                                : Convert.ToInt32(ngayNxTimeSpan.TotalDays);

            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 7
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 44
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 46
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 31)
            {
                clThuKho.Caption = "Thủ kho xuất";
                clMa.Caption = "Mã linh kiện";
                clTen.Caption = "Tên linh kiện";
            }

            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 2
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 43
                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 45)
            {
                clThuKho.Caption = "Thủ kho nhập";
                clMa.Caption = "Mã thành phẩm";
                clTen.Caption = "Tên thành phẩm";
            }

            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 30)
            {
                clThuKho.Caption = "Thủ kho nhập";
                clMa.Caption = "Mã thành phẩm";
                clTen.Caption = "Tên thành phẩm";
            }


            lichitiet.Clear();

            grcBCHangChuyenKho.DataSource = lichitiet;
            grcBCHangChuyenKho.RefreshDataSource();

            frmProgress.Instance.DoWork(
                delegate()
                    {
                        while (calcTo >= calcFrom)
                        {
                            List<MaVachSXReportInfo> liTmp = new List<MaVachSXReportInfo>();
                            frmProgress.Instance.Description = "Đang load dữ liệu ngày " + calcTo.ToString("dd/MM/yyyy");

                            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 7
                                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 44
                                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 46
                                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 31)
                            {
                                liTmp = NhapReportDataProvider.Instance.GetTongHopLinhKien(
                                    isCalcByNgayLap ? ngayLapTo.AddDays(-1) : ngayLapFrom,
                                    ngayLapTo, IdTrungTam, MaKho,
                                    isCalcByNgayLap ? ngayNxFrom : ngayNxTo.AddDays(-1),
                                    ngayNxTo, Convert.ToInt32(lueLoaiGiaoDich.EditValue));

                            }

                            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 2
                                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 43
                                || Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 45)
                            {
                                liTmp = NhapReportDataProvider.Instance.GetTongHopThanhPham(
                                    isCalcByNgayLap ? ngayLapTo.AddDays(-1) : ngayLapFrom,
                                    ngayLapTo, IdTrungTam, MaKho,
                                    isCalcByNgayLap ? ngayNxFrom : ngayNxTo.AddDays(-1),
                                    ngayNxTo, Convert.ToInt32(lueLoaiGiaoDich.EditValue));
                            }

                            if (Convert.ToInt32(lueLoaiGiaoDich.EditValue) == 30)
                            {
                                liTmp = NhapReportDataProvider.Instance.GetTongHopTachThanhPham(
                                    isCalcByNgayLap ? ngayLapTo.AddDays(-1) : ngayLapFrom,
                                    ngayLapTo, IdTrungTam, MaKho, 
                                    isCalcByNgayLap ? ngayNxFrom : ngayNxTo.AddDays(-1),
                                    ngayNxTo);
                            }
                            
                            lichitiet.AddRange(liTmp);

                            Invoke((MethodInvoker)
                               delegate
                               {
                                   grcBCHangChuyenKho.RefreshDataSource();
                               });

                            calcTo = calcTo.AddDays(-1);
                            if (isCalcByNgayLap)
                                ngayLapTo = calcTo;
                            else
                                ngayNxTo = calcTo;
                            frmProgress.Instance.Value += 1;
                        }
                        frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                        frmProgress.Instance.IsCompleted = true;
                    });

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(grvBCHangChuyenKho);
            Common.Export2ExcelFromDevGrid<MaVachSXReportInfo>(grvBCHangChuyenKho, "BCTongHopSX");
        }

        private void frm_BaoCaoChiTietGiaoDichNhapHang_Load(object sender, EventArgs e)
        {
            clsUtils.NullColumnDateTimeGrid(repdtNgayLap);
            LoadLoaiGiaoDich();
            LoadLoaiSanXuat();
        }
    }
}