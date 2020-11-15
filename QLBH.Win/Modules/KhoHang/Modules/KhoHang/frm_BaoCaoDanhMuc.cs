using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.HeThong.Infors;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.DanhMuc.Providers;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Common;
using QLBH.Core.Exceptions;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang
{
    public partial class frm_BaoCaoDanhMuc : DevExpress.XtraEditors.XtraForm
    {
        private DateTime fromDate;
        private DateTime toDate;
        private string MaTrungTam;
        private string MaKho;
        private List<BCChiTietXuatTieuHaoInfo> lstBC;
        List<LookUp> lst = new List<LookUp>();
        List<DMSanPhamInfo> liSP = new List<DMSanPhamInfo>();
        List<DMNhanVienInfo> liNV = new List<DMNhanVienInfo>();
        List<DMDoiTuongInfo> liDT = new List<DMDoiTuongInfo>();
        [Serializable]
        public class LookUp
        {
            public int OID { get; set; }
            public string Name { get; set; }
        }
        protected bool IsSupperUser()
        {
            if (((NguoiDungInfor)Declare.USER_INFOR).SupperUser == 1)
                return true;
            return false;
        }
        public frm_BaoCaoDanhMuc()
        {
            InitializeComponent();
            if (IsSupperUser())
            { grcBase.ContextMenuStrip = new ContextMenuStrip(); }
        }

        private void LoadDanhMuc()
        {
            List<LookUp> lidanhmuc = new List<LookUp>();
            lidanhmuc.Add(new LookUp { OID = 0, Name = "Danh mục hàng hóa" });
            lidanhmuc.Add(new LookUp { OID = 1, Name = "Danh mục nhân viên" });
            lidanhmuc.Add(new LookUp { OID = 2, Name = "Danh mục nhà cung cấp" });
            lueDanhMuc.Properties.DataSource = null;
            lueDanhMuc.Properties.DataSource = lidanhmuc;
            lueDanhMuc.EditValue = lidanhmuc[0].OID;
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lueDanhMuc.EditValue) == 0)
                {
                    liSP = QLBanHang.Modules.DanhMuc.Providers.DmSanPhamProvider.GetListDmSanPhamInfo();
                    grcBase.DataSource = null;
                    grcBase.DataSource = liSP;
                }
                else if (Convert.ToInt32(lueDanhMuc.EditValue) == 1)
                {
                    liNV = QLBanHang.Modules.DanhMuc.Providers.DmNhanVienDataProvider.GetListDmNhanVienInfor();
                    grcBase.DataSource = null;
                    grcBase.DataSource = liNV;
                }
                else if (Convert.ToInt32(lueDanhMuc.EditValue) == 2)
                {
                    liDT = QLBanHang.Modules.DanhMuc.Providers.DmDoiTuongProvider.GetListDmDoiTuongInfo();
                    grcBase.DataSource = null;
                    grcBase.DataSource = liDT;
                }
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //Common.DevExport2Excel(gridView1);
            
            try
            {
                if (Convert.ToInt32(lueDanhMuc.EditValue) == 0)
                {
                    Common.Export2ExcelFromDevGrid<DMSanPhamInfo>(gridView1, "BCDMSanPham");
                }
                else if (Convert.ToInt32(lueDanhMuc.EditValue) == 1)
                {
                    Common.Export2ExcelFromDevGrid<DMNhanVienInfo>(gridView1, "BCDMNhanVien");
                }
                else if (Convert.ToInt32(lueDanhMuc.EditValue) == 2)
                {
                    Common.Export2ExcelFromDevGrid<DMDoiTuongInfo>(gridView1, "BCDMDoiTuong");
                }
            }
            catch (ManagedException ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void frm_BaoCaoDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }
    }
}