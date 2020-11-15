using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using QLBanHang.Modules.DanhMuc;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.Providers;
using QLBanHang.Modules.KhoHang.Reports;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_InNoteSanPham : DevExpress.XtraEditors.XtraForm
    {
        private objGridMarkSelection selector =new objGridMarkSelection();
         List<NoteSanPhamReportInfor> list = new List<NoteSanPhamReportInfor>();
        List<NoteSanPhamReportInfor> lstSP = new List<NoteSanPhamReportInfor>();
        public frm_InNoteSanPham()
        {
            InitializeComponent();
        }
        [Serializable]
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        private void LoadKhoIn()
        {
            List<LookUp> lidanhmuc = new List<LookUp>();
            lidanhmuc.Add(new LookUp { OID = 0, Name = "A5" });
            lidanhmuc.Add(new LookUp { OID = 1, Name = "A6" });
            lidanhmuc.Add(new LookUp { OID = 2, Name = "A7" });
            lueKhoIn.Properties.DataSource = null;
            lueKhoIn.Properties.DataSource = lidanhmuc;
            lueKhoIn.EditValue = lidanhmuc[0].OID;
            //lueKhoIn.Width = 100;
            //lueKhoIn.Height = 70;

        }

        #region Event bteSanPham
        private void bteSanPham_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmLookUp_SanPham_CauHinh frmLookUp = new frmLookUp_SanPham_CauHinh(true, String.Format("%{0}%", bteSanPham.Text));
            if (frmLookUp.ShowDialog() == DialogResult.OK)
            {
                bteSanPham.EditValue = String.Empty; 
                bteSanPham.Tag = frmLookUp.SelectedItems;
                foreach (DMSanPhamInfo selectedItem in frmLookUp.SelectedItems)
                {
                    bteSanPham.EditValue += selectedItem.MaSanPham + ",";
                }
                LoadDataGridSanPham();
            }
        }
        private void bteSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmLookUp_SanPham_CauHinh frmLookUp = new frmLookUp_SanPham_CauHinh(true, String.Format("%{0}%", bteSanPham.Text));
                if (frmLookUp.ShowDialog() == DialogResult.OK)
                {
                    bteSanPham.Tag = frmLookUp.SelectedItems;
                    foreach (DMSanPhamInfo selectedItem in frmLookUp.SelectedItems)
                    {
                        bteSanPham.EditValue += selectedItem.MaSanPham + ",";
                    }
                    LoadDataGridSanPham();
                }
            }
        }
        private void bteSanPham_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bteSanPham.Text)) bteSanPham.Tag = null;
        }
        #endregion 

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            if(rdoA4.Checked)
            {
                List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>)bteSanPham.Tag;
                string Id = String.Empty;
                foreach (DMSanPhamInfo dmSanPhamInfo in listSP)
                {
                    Id += dmSanPhamInfo.IdSanPham + ",";
                }
                SaveTenVietTat();
                //DeleteSTT();
                if (Convert.ToInt32(lueKhoIn.EditValue) == 2)
                {
                    string Thongtin = String.Empty;
                    foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
                    {
                        Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
                    }
                    list =
                       NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
                    if (list.Count == 0)
                    {
                        clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
                        return;
                    }
                    rpt_BC_NoteSanPhamA7Sub rpt = new rpt_BC_NoteSanPhamA7Sub(Thongtin, listSP[0].Hang, chkInGia.Checked);
                    rpt.DataSource = rpt.GetListHeaderInfors(Id, Declare.IdTrungTam);
                    rpt.BindHeader();
                    rpt.SetDiemThuong(Declare.IdTrungTam);
                    //rpt.CreateDocument();
                    rpt.ShowPreview();
                }
                else if (Convert.ToInt32(lueKhoIn.EditValue) == 1)
                {
                    string Thongtin = String.Empty;
                    foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
                    {
                        Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
                    }
                    List<NoteSanPhamReportInfor> list =
                        NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
                    if (list.Count == 0)
                    {
                        clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
                        return;
                    }
                    rpt_BC_NoteSanPhamA6new rpt = new rpt_BC_NoteSanPhamA6new(Thongtin, listSP[0].Hang,chkInGia.Checked);
                    rpt.DataSource = rpt.GetListHeaderInfors(Id, Declare.IdTrungTam);
                    rpt.BindHeader();
                    rpt.SetDiemThuong(Declare.IdTrungTam);
                    rpt.ShowPreview();
                }
                else if (Convert.ToInt32(lueKhoIn.EditValue) == 0)
                {
                    string Thongtin = String.Empty;
                    foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
                    {
                        Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
                    }
                    List<NoteSanPhamReportInfor> list =
                        NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
                    if (list.Count == 0)
                    {
                        clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
                        return;
                    }
                    rpt_BC_NoteSanPhamA5 rpt = new rpt_BC_NoteSanPhamA5(Thongtin, listSP[0].Hang, chkInGia.Checked);
                    rpt.DataSource = rpt.GetListHeaderInfors(Id, Declare.IdTrungTam);
                    rpt.BindHeader();
                    rpt.SetDiemThuong(Declare.IdTrungTam);
                    rpt.ShowPreview();
                }
            }
            else if(rdoA5.Checked)
            {
                List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>)bteSanPham.Tag;
                string Id = String.Empty;
                foreach (DMSanPhamInfo dmSanPhamInfo in listSP)
                {
                    Id += dmSanPhamInfo.IdSanPham + ",";
                }
                SaveTenVietTat();
                //DeleteSTT();
                if (Convert.ToInt32(lueKhoIn.EditValue) == 2)
                {
                    string Thongtin = String.Empty;
                    foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
                    {
                        Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
                    }
                    list =
                       NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
                    if (list.Count == 0)
                    {
                        clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
                        return;
                    }
                    rpt_BC_NoteSanPhamA75 rpt = new rpt_BC_NoteSanPhamA75(Thongtin, listSP[0].Hang, chkInGia.Checked);
                    rpt.DataSource = rpt.GetListHeaderInfors(Id, Declare.IdTrungTam);
                    rpt.BindHeader();
                    rpt.SetDiemThuong(Declare.IdTrungTam);
                    //rpt.CreateDocument();
                    rpt.ShowPreview();
                }
                else if (Convert.ToInt32(lueKhoIn.EditValue) == 1)
                {
                    string Thongtin = String.Empty;
                    foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
                    {
                        Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
                    }
                    List<NoteSanPhamReportInfor> list =
                        NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
                    if (list.Count == 0)
                    {
                        clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
                        return;
                    }
                    rpt_BC_NoteSanPhamA65 rpt = new rpt_BC_NoteSanPhamA65(Thongtin, listSP[0].Hang, chkInGia.Checked);
                    rpt.DataSource = rpt.GetListHeaderInfors(Id, Declare.IdTrungTam);
                    rpt.BindHeader();
                    rpt.SetDiemThuong(Declare.IdTrungTam);
                    rpt.ShowPreview();
                }
                else if (Convert.ToInt32(lueKhoIn.EditValue) == 0)
                {
                    string Thongtin = String.Empty;
                    foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
                    {
                        Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
                    }
                    List<NoteSanPhamReportInfor> list =
                        NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
                    if (list.Count == 0)
                    {
                        clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
                        return;
                    }
                    rpt_BC_NoteSanPhamA5Single rpt = new rpt_BC_NoteSanPhamA5Single(Thongtin, listSP[0].Hang, chkInGia.Checked);
                    rpt.DataSource = rpt.GetListHeaderInfors(Id,Declare.IdTrungTam);
                    rpt.BindHeader();
                    rpt.SetDiemThuong(Declare.IdTrungTam);
                    rpt.ShowPreview();
                }
            }
            //else if(rdoA6.Checked)
            //{
            //    List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>)bteSanPham.Tag;
            //    string Id = String.Empty;
            //    foreach (DMSanPhamInfo dmSanPhamInfo in listSP)
            //    {
            //        Id += dmSanPhamInfo.IdSanPham + ",";
            //    }
            //    SaveTenVietTat();
            //    //DeleteSTT();
            //    if (Convert.ToInt32(lueKhoIn.EditValue) == 2)
            //    {
            //        string Thongtin = String.Empty;
            //        foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
            //        {
            //            Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
            //        }
            //        list =
            //           NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
            //        if (list.Count == 0)
            //        {
            //            clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
            //            return;
            //        }
            //        rpt_BC_NoteSanPhamA7Single rpt = new rpt_BC_NoteSanPhamA7Single(Thongtin, listSP[0].Hang);
            //        rpt.DataSource = rpt.GetListHeaderInfors(Id);
            //        rpt.BindHeader();
            //        //rpt.CreateDocument();
            //        rpt.ShowPreview();
            //    }
            //    else if (Convert.ToInt32(lueKhoIn.EditValue) == 1)
            //    {
            //        string Thongtin = String.Empty;
            //        foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
            //        {
            //            Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
            //        }
            //        List<NoteSanPhamReportInfor> list =
            //            NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
            //        if (list.Count == 0)
            //        {
            //            clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
            //            return;
            //        }
            //        rpt_BC_NoteSanPhamA6Single rpt = new rpt_BC_NoteSanPhamA6Single(Thongtin, listSP[0].Hang);
            //        rpt.DataSource = rpt.GetListHeaderInfors(Id);
            //        rpt.BindHeader();
            //        rpt.ShowPreview();
            //    }
            //    else if (Convert.ToInt32(lueKhoIn.EditValue) == 0)
            //    {
            //        string Thongtin = String.Empty;
            //        foreach (NoteSanPhamReportInfor noteSanPhamReportInfor in selector.selection)
            //        {
            //            Thongtin += noteSanPhamReportInfor.TenCauHinh + ",";
            //        }
            //        List<NoteSanPhamReportInfor> list =
            //            NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Id, Thongtin);
            //        if (list.Count == 0)
            //        {
            //            clsUtils.MsgCanhBao("Sản phẩm không có thông tin cấu hình!");
            //            return;
            //        }
            //        rpt_BC_NoteSanPhamA5Single rpt = new rpt_BC_NoteSanPhamA5Single(Thongtin, listSP[0].Hang);
            //        rpt.DataSource = rpt.GetListHeaderInfors(Id);
            //        rpt.BindHeader();
            //        rpt.ShowPreview();
            //    }
            //}
            
        }
        private void LoadDataGridvew()
        {
            if (bteSanPham.Tag != null)
            {
                List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>) bteSanPham.Tag;
                list =
                    NoteReportDataProvider.Instance.SanPhamGetCauHinhByIdSanPham(Convert.ToString(listSP[0].IdSanPham),
                                                                                 String.Empty);
                grcNoteSanPham.DataSource = null;
                grcNoteSanPham.DataSource = list;
            }
            else
            {
                clsUtils.MsgThongBao("Bạn chưa chọn sản phẩm!");
            }
        }

        private void LoadDataGridSanPham()
        {
            if (bteSanPham.Tag != null)
            {
                List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>)bteSanPham.Tag;
                string Id = String.Empty;
                foreach (DMSanPhamInfo dmSanPhamInfo in listSP)
                {
                    Id += dmSanPhamInfo.IdSanPham + ",";
                }
                lstSP = NoteReportDataProvider.Instance.SanPhamGetTenByIdSanPham(Id);
                grcSanPham.DataSource = null;
                grcSanPham.DataSource = lstSP;
            }
            else
            {
                clsUtils.MsgThongBao("Bạn chưa chọn sản phẩm!");
            }
        }
        private void frm_InNoteSanPham_Load(object sender, EventArgs e)
        {
            LoadKhoIn();
            rdoA4.Checked = true;
            chkInGia.Checked = true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDataGridvew();
            selector.View = grvNoteSanPham;
            selector.CheckMarkColumn.Fixed = FixedStyle.None;
            selector.CheckMarkColumn.Caption = "Chọn";
            selector.ClearSelection();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            List<DMSanPhamInfo> listSP = (List<DMSanPhamInfo>)bteSanPham.Tag;
            string Id = String.Empty;
            foreach (DMSanPhamInfo dmSanPhamInfo in listSP)
            {
                Id += dmSanPhamInfo.IdSanPham + ",";
            }
            for (int i = 0; i < list.Count; i++)
            {
                //if (list.FindAll(delegate(NoteSanPhamReportInfor math)
                //{
                //    return math.IdSanPham == list[i].IdSanPham
                //                            && math.STT == list[i].STT;
                //}).Count > 1)
                //{
                //    clsUtils.MsgCanhBao("Số thứ tự không được trùng nhau !");
                //    return;
                //}
                NoteSanPhamReportInfor infor = list[i];
                NoteReportDataProvider.Instance.UpdateCauHinhSanPham(Id,infor.STT,infor.TenCauHinh);
            }
            LoadDataGridvew();
        }
        private void SaveTenVietTat()
        {
            for (int i = 0; i < lstSP.Count; i++)
            {
                NoteSanPhamReportInfor infor = lstSP[i];
                NoteReportDataProvider.Instance.UpdateTenVietTatSanPham(infor.IdSanPham,infor.TenSanPham);
            }
        }
        private void DeleteSTT()
        {
            for (int i = 0; i < lstSP.Count; i++)
            {
                NoteSanPhamReportInfor infor = lstSP[i];
                NoteReportDataProvider.Instance.DeleteCauHinhSanPham(infor.IdSanPham);
            }
        }
    }
}