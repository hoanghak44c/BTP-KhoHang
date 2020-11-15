using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.DongBoERP;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_ChiTietTongHopKiemKe : DevExpress.XtraEditors.XtraForm
    {
        private DotKiemKeInfor info;
        private List<LookUp> lst = new List<LookUp>();
        public frm_ChiTietTongHopKiemKe(DotKiemKeInfor info)
        {
            InitializeComponent();
            this.info = info;
        }
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        
        private void LoadKyKiemKe()
        {
            lst.Add(new LookUp { OID = 1, Name = "Tháng 1" });
            lst.Add(new LookUp { OID = 2, Name = "Tháng 2" });
            lst.Add(new LookUp { OID = 3, Name = "Tháng 3" });
            lst.Add(new LookUp { OID = 4, Name = "Tháng 4" });
            lst.Add(new LookUp { OID = 5, Name = "Tháng 5" });
            lst.Add(new LookUp { OID = 6, Name = "Tháng 6" });
            lst.Add(new LookUp { OID = 7, Name = "Tháng 7" });
            lst.Add(new LookUp { OID = 8, Name = "Tháng 8" });
            lst.Add(new LookUp { OID = 9, Name = "Tháng 9" });
            lst.Add(new LookUp { OID = 10, Name = "Tháng 10" });
            lst.Add(new LookUp { OID = 11, Name = "Tháng 11" });
            lst.Add(new LookUp { OID = 12, Name = "Tháng 12" });
            lueKyKiemKe.Properties.DataSource = null;
            lueKyKiemKe.Properties.DataSource = lst;
            //lueKyKiemKe.EditValue = lst[0].OID;
        }
        
        private void frm_ChiTietTongHopKiemKe_Load(object sender, EventArgs e)
        {
            btnBatDau.Enabled = info == null || info.NgayBatDau == DateTime.MinValue;
            btnBatDau.Text = info == null ? "Ghi" : btnBatDau.Text;

            btnTongHop.Visible = btnKetThuc.Visible = info != null;
            btnTongHop.Enabled = btnKetThuc.Enabled =
                info != null && info.NgayBatDau != DateTime.MinValue && info.NgayKetThuc == DateTime.MinValue;

            LoadKyKiemKe();
            lueKyKiemKe.Enabled = false;
            if(info != null)
            {
                txtMaDotKiemKe.Text = info.MaDotKiemKe;
                txtGhiChu.Text = info.GhiChu;
                bteTrungTam.Text = info.TrungTam;
                bteKho.Text = info.Kho;
                bteNganh.Text = info.TenNganh;
                lueKyKiemKe.EditValue = info.KyKiemKe;
            }
            else
            {
                lueKyKiemKe.EditValue = CommonProvider.Instance.GetSysDate().Month;
            }
        }

        private bool Check()
        {
            if(bteTrungTam.Tag == null)
            {
                throw new ManagedException("Bạn chưa chọn trung tâm!");
            }
            //if(bteNganh.Tag == null)
            //{
            //    throw new ManagedException("Bạn chưa chọn Ngành!");
            //}
            return true;
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                if (info == null && Check())
                {
                    if(Declare.UserName != "truongpq1174" && Declare.UserName != "superuser" && !Declare.IS_SUPPER_USER)
                    {
                        throw new ManagedException("Bạn không có quyền thực hiện chức năng này.");
                    }

                    if (bteNganh.Tag == null && MessageBox.Show("Đợt kiểm kê này không theo ngành nào cả, bạn có chắc chắn không?", 
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                        MessageBoxDefaultButton.Button2) == DialogResult.No) return;

                    info = new DotKiemKeInfor
                    {
                        MaDotKiemKe = txtMaDotKiemKe.Text,
                        GhiChu = txtGhiChu.Text,
                        TrungTam = bteTrungTam.Text,
                        Kho = bteKho.Text,
                        Nganh = bteNganh.Tag == null ? String.Empty : ((SegmentInfo)bteNganh.Tag).Ma,
                        NgayBatDau = CommonProvider.Instance.GetSysDate(),
                        KyKiemKe = Convert.ToInt32(lueKyKiemKe.EditValue)
                    };

                    if (!DotKiemKeDataProvider.Instance.MaDotKiemKeUnique(info.MaDotKiemKe))
                    {
                        throw new ManagedException("Mã đợt kiểm kê đã được sử dụng. Bạn hãy chọn mã khác!");
                    }

                    DotKiemKeDataProvider.Instance.Insert(info);
                } 
                else
                {
                    if (MessageBox.Show("Số tồn sổ sách của đợt kiểm kê sẽ được chốt tính từ thời điểm này, bạn có chắc chắn không?", 
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                    
                    if(DotKiemKeDataProvider.Instance.DaChotSoTon(info))
                    {
                        btnBatDau.Enabled = false;

                        throw new ManagedException("Đợt kiểm kê này đã được chốt số tồn.");
                    }

                    info.NgayBatDau = CommonProvider.Instance.GetSysDate();

                    try
                    {
                        frmProgress.Instance.Caption = "Chốt số liệu kiểm kê";
                        frmProgress.Instance.MaxValue = 2;
                        frmProgress.Instance.Value = 0;
                        frmProgress.Instance.DoWork(delegate()
                        {
                            try
                            {
                                ConnectionUtil.Instance.BeginTransaction();
                                frmProgress.Instance.Description = "Đang chốt số tồn POS ...";
                                DotKiemKeDataProvider.Instance.ChotSoTon(info);
                                frmProgress.Instance.Value += 1;

                                try
                                {
                                    frmProgress.Instance.Description = "Đang lấy dữ liệu tồn ORC ...";

                                    if (String.IsNullOrEmpty(info.Kho))
                                    {
                                        BusinessSynchronize.Instance.QuantityOnHandSync(info.TrungTam, info.Kho, info.Nganh,
                                                                                        info.MaDotKiemKe);
                                    } 
                                    else
                                    {
                                        var khos = info.Kho.Replace(" ", "").Split(',');

                                        foreach (var kho in khos)
                                        {
                                            BusinessSynchronize.Instance.QuantityOnHandSync(info.TrungTam, kho, info.Nganh,
                                                                                            info.MaDotKiemKe);
                                        }
                                    }

                                    frmProgress.Instance.Value += 1;
                                }
                                catch (Exception)
                                {
                                    if(ConnectionUtil.Instance.IsUAT == 1) throw;
                                }

                                if (!DotKiemKeDataProvider.Instance.UpdateThoiGianChotTon(info))
                                {
                                    throw new ManagedException("Đợt kiểm kê này đã được chốt số tồn.");
                                }

                                ConnectionUtil.Instance.CommitTransaction();
                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                                frmProgress.Instance.IsCompleted = true;
                            }
                            catch (Exception ex)
                            {
                                ConnectionUtil.Instance.RollbackTransaction();
                                MessageBox.Show(ex.Message);
                                frmProgress.Instance.Description = "Không hoàn thành";
                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                                frmProgress.Instance.IsCompleted = true;
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        frmProgress.Instance.Description = "Không hoàn thành";
                        frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                        frmProgress.Instance.IsCompleted = true;
                    }
                }

                btnBatDau.Enabled = false;
                DialogResult = DialogResult.OK;
            }
            catch (ManagedException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {
                if (info == null) throw new ManagedException("Đợt kiểm kê này chưa được thiết lập.");

                if(!DotKiemKeDataProvider.Instance.CanBeFinished(info.IdDotKiemKe)) {
                    
                    if(MessageBox.Show(@"Đang còn phiếu kiểm kê trong đợt này chưa được xác nhận. \r\n 
                    Các phiếu này sẽ được xác nhận tự động. Bạn có đồng ý không?", 
                     "Xác nhận", 
                     MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                
                } else if(MessageBox.Show("Đợt kiểm kê sẽ kết thúc. Bạn có chắc chắn không?", "Xác nhận",MessageBoxButtons.YesNo) == DialogResult.No)

                    return;

                info.NgayKetThuc = CommonProvider.Instance.GetSysDate();
                
                frmProgress.Instance.Caption = "Kiểm kê";
                frmProgress.Instance.Description = "Đang tổng hợp dữ liệu";
                frmProgress.Instance.MaxValue = 1;
                frmProgress.Instance.Value = 0;
                frmProgress.Instance.DoWork(
                    delegate
                    {
                        try
                        {
                            DotKiemKeDataProvider.Instance.Update(info);
                            frmProgress.Instance.Description = "Đã xong";
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                            frmProgress.Instance.IsCompleted = true;
                        }
                        catch (Exception)
                        {
                            frmProgress.Instance.Description = "Không hoàn thành";
                            frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                            frmProgress.Instance.IsCompleted = true;
                            throw;
                        }
                    });

                btnKetThuc.Enabled = false;

                DialogResult = DialogResult.OK;
            }
            catch (ManagedException ex)
            {
                frmProgress.Instance.Description = "Không hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;

                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                frmProgress.Instance.Description = "Không hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bteTrungTam_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (info != null) return;
            frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(String.Format("%{0}%", bteTrungTam.Text));
            if(frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
            {
                bteTrungTam.Tag = frmLookUpTrungTam.SelectedItem;
                bteTrungTam.Text = frmLookUpTrungTam.SelectedItem.MaTrungTam;
            }
        }

        private void bteTrungTam_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_TrungTam frmLookUpTrungTam = new frmLookUp_TrungTam(true);
                if (frmLookUpTrungTam.ShowDialog() == DialogResult.OK)
                {
                    bteTrungTam.Text = String.Empty;
                    bteTrungTam.Tag = frmLookUpTrungTam.SelectedItems;
                    foreach (DMTrungTamInfor dmTrungTamInfor in frmLookUpTrungTam.SelectedItems)
                    {
                        bteTrungTam.Text += (String.IsNullOrEmpty(bteTrungTam.Text)
                                                ? String.Empty
                                                : ", ") + dmTrungTamInfor.MaTrungTam;
                    }
                }                
            }
        }

        private void bteTrungTam_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(bteTrungTam.Text)) bteTrungTam.Tag = null;
        }

        private void bteKho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (info != null) return;
            frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true, String.Empty, bteTrungTam.Tag == null ? -1 : ((DMTrungTamInfor)bteTrungTam.Tag).IdTrungTam, Declare.IdNhanVien);
            if (frmLookUpKho.ShowDialog() == DialogResult.OK)
            {
                bteKho.Text = String.Empty;
                bteKho.Tag = frmLookUpKho.SelectedItems;
                foreach (DMKhoInfo dmKhoInfo in frmLookUpKho.SelectedItems)
                {
                    bteKho.Text += (String.IsNullOrEmpty(bteKho.Text)
                                            ? String.Empty
                                            : ", ") + dmKhoInfo.MaKho;
                }
            } 
        }

        private void bteKho_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_Kho frmLookUpKho = new frmLookUp_Kho(true);
                if (frmLookUpKho.ShowDialog() == DialogResult.OK)
                {
                    bteKho.Text = String.Empty;
                    bteKho.Tag = frmLookUpKho.SelectedItems;
                    foreach (DMKhoInfo dmKhoInfo in frmLookUpKho.SelectedItems)
                    {
                        bteKho.Text += (String.IsNullOrEmpty(bteKho.Text)
                                                ? String.Empty
                                                : ", ") + dmKhoInfo.MaKho;
                    }
                }                 
            }
        }

        private void bteKho_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteKho.Text)) bteKho.Tag = null;
        }

        private void bteNganh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (info != null) return;

            frmLookUp_Nganh frmLookUpNganh = new frmLookUp_Nganh(String.Format("%{0}%", bteNganh.Text));

            if (frmLookUpNganh.ShowDialog() == DialogResult.OK)
            {
                bteNganh.Tag = frmLookUpNganh.SelectedItem;
                bteNganh.Text = frmLookUpNganh.SelectedItem.Ten;
            } 
        }

        private void bteNganh_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                frmLookUp_Nganh frmLookUpNganh = new frmLookUp_Nganh(String.Format("%{0}%", bteNganh.Text));

                if (frmLookUpNganh.ShowDialog() == DialogResult.OK)
                {
                    bteNganh.Tag = frmLookUpNganh.SelectedItem;
                    bteNganh.Text = frmLookUpNganh.SelectedItem.Ten;
                }
            }
        }

        private void bteNganh_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteNganh.Text)) bteNganh.Tag = null;
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            try
            {
                if (info == null) throw new ManagedException("Đợt kiểm kê này chưa được thiết lập.");

                if (!DotKiemKeDataProvider.Instance.CanBeFinished(info.IdDotKiemKe))
                {

                    if (MessageBox.Show(@"Đang còn phiếu kiểm kê trong đợt này chưa được xác nhận. Bạn có đồng ý không?",
                     "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }

                frmProgress.Instance.Caption = "Kiểm kê";
                frmProgress.Instance.Description = "Đang tổng hợp dữ liệu";
                frmProgress.Instance.MaxValue = 1;
                frmProgress.Instance.Value = 0;
                frmProgress.Instance.DoWork(
                    delegate
                        {
                            try
                            {
                                DotKiemKeDataProvider.Instance.Update2(info);
                                frmProgress.Instance.Description = "Đã xong";
                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                                frmProgress.Instance.IsCompleted = true;
                            }
                            catch (Exception)
                            {
                                frmProgress.Instance.Description = "Không hoàn thành";
                                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                                frmProgress.Instance.IsCompleted = true;
                                throw;
                            }
                        });

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                frmProgress.Instance.Description = "Không hoàn thành";
                frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                frmProgress.Instance.IsCompleted = true;
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}