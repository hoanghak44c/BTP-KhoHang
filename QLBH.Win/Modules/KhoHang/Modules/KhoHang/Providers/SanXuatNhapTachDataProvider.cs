using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBH.Common;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class SanXuatNhapTachDataProvider
    {
        private static SanXuatNhapTachDataProvider instance;
        public static SanXuatNhapTachDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new SanXuatNhapTachDataProvider();
                return instance;
            }
        }
        public void Insert(SanXuatNhapTachInfo chungTu)
        {
            XacNhanNhapThanhPhanDAO.Instance.Insert(chungTu);
        }
        public void Update(SanXuatNhapTachInfo chungTu)
        {
            XacNhanNhapThanhPhanDAO.Instance.Update(chungTu);
        }
        public void DeleteTachThanhPham(string orgcode)
        {
            XacNhanNhapThanhPhanDAO.Instance.Delete(orgcode, Convert.ToInt32(LoaiGiaoDichSanXuat.TACH_THANH_PHAM_SAN_XUAT));
        }

        public void DeleteNhapThanhPham(string orgcode)
        {
            XacNhanNhapThanhPhanDAO.Instance.Delete(orgcode, Convert.ToInt32(LoaiGiaoDichSanXuat.NHAP_THANH_PHAM_SAN_XUAT));
        }

        public int Check(string malenh,string mathanhpham,int transactionID)
        {
            return XacNhanNhapThanhPhanDAO.Instance.Exist(malenh,mathanhpham,transactionID);
        }
        public DateTime GetMaxDateNhapTach(string orgcode)
        {
            return XacNhanNhapThanhPhanDAO.Instance.GetMaxDate(orgcode);
        }
        public DMChungTuNhapInfo GetChungTuNhapThanhPhamBySoChungTuGoc(string soChungTuGoc)
        {
            return XacNhanNhapThanhPhanDAO.Instance.GetChungTuNhapThanhPhamBySoChungTuGoc(soChungTuGoc, Convert.ToInt32(TransactionType.XUAT_LINK_KIEN_SX));
        }
        public List<SanXuatNhapTachInfo> GetListAllSanXuatNhapTach(int loaigiaodich,int loaichungtu,string orgcode,int trangthai)
        {
            return XacNhanNhapThanhPhanDAO.Instance.SanXuatNhapTachSelectAll(loaigiaodich,loaichungtu,orgcode,trangthai);
        }
        public SanXuatNhapTachInfo SanXuatNhapTachGetByMaVach(string MaVach,string malenh)
        {
            return XacNhanNhapThanhPhanDAO.Instance.SanXuatNhapTachGetByMaVach(MaVach,malenh);
        }
        public List<SanXuatNhapTachInfo> GetListAllTmpSanXuatNhapTach(string orgcode, int loaigiaodich)
        {
            return XacNhanNhapThanhPhanDAO.Instance.TmpSanXuatNhapTachSelectAll(orgcode, loaigiaodich);
        }
        public List<SanXuatNhapTachInfo> SanXuatNhapTachGetByMaLenh(string MaLenh, string MaThanhPham,string OrgCode,int transacttionID)
        {
            return XacNhanNhapThanhPhanDAO.Instance.SanXuatNhapTachGetByMaLenh(MaLenh, MaThanhPham,OrgCode,transacttionID);
        }
        public List<ChungTuXuatNhapNccChiTietInfo> SanXuatNhapTachCTGetBySoChungTu(string sochungtu,int loaichungtu)
        {
            return XacNhanNhapThanhPhanDAO.Instance.SanXuatNhapTachCTGetBySoChungTu(sochungtu,loaichungtu);
        }
        public ChungTuXuatNhapNccChiTietInfo SanXuatNhapTachCheckMaVach(int loaichungtu,string mavach)
        {
            return XacNhanNhapThanhPhanDAO.Instance.SanXuatNhapTachCheckMaVach(loaichungtu,mavach);
        }

    }
}
