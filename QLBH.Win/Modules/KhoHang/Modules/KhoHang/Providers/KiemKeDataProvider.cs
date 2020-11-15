using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class KiemKeDataProvider
    {
        private static KiemKeDataProvider instance;

        private KiemKeDataProvider() { }

        public static KiemKeDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new KiemKeDataProvider();
                return instance;
            }
        }
        public int  InsertSoPhieuKiemKe(KiemKeInfor chiTietKiemKeInfor)
        {
            return KiemKeDAO.Instance.InsertSoPhieuKiemKe(chiTietKiemKeInfor);
        }
        public int InsertKiemKe(KiemKeInfor chiTietKiemKeInfor)
        {
            return KiemKeDAO.Instance.InsertKiemKe(chiTietKiemKeInfor);
        }
        public int InsertKiemKeChiTiet(KiemKeChiTietInfor chiTietKiemKeInfor)
        {
            return KiemKeDAO.Instance.InsertKiemKeChiTiet(chiTietKiemKeInfor);
        }
        public int InsertKiemKeChiTietHangHoa(KiemKeChiTietHangHoaInfor chungTuChiTietHangHoaKiemKeInfor)
        {
            return KiemKeDAO.Instance.InsertKiemKeChiTietHangHoa(chungTuChiTietHangHoaKiemKeInfor);
        }
        public void InsertKiemKeChiTietKhongMaVach(KiemKeChiTietKhongMaVachInfor chungTuChiTietHangHoaKiemKeInfor)
        {
             KiemKeDAO.Instance.InsertKiemKeChiTietKhongMaVach(chungTuChiTietHangHoaKiemKeInfor);
        }
        public void UpdateKiemKe(KiemKeInfor chiTietKiemKeInfor)
        {
             KiemKeDAO.Instance.UpdateKiemKe(chiTietKiemKeInfor);
        }
        public void UpdateKiemKeChiTiet(KiemKeChiTietInfor chiTietKiemKeInfor)
        {
            KiemKeDAO.Instance.UpdateKiemKeChiTiet(chiTietKiemKeInfor);
        }
        public void UpdateKiemKeChiTietHangHoa(KiemKeChiTietHangHoaInfor chungTuChiTietHangHoaKiemKeInfor)
        {
            KiemKeDAO.Instance.UpdateKiemKeChiTietHangHoa(chungTuChiTietHangHoaKiemKeInfor);
        }
        public void UpdateKiemKeChiTietKhongMaVach(KiemKeChiTietKhongMaVachInfor chungTuChiTietHangHoaKiemKeInfor)
        {
            KiemKeDAO.Instance.UpdateKiemKeChiTietKhongMaVach(chungTuChiTietHangHoaKiemKeInfor);
        }
        public void DeleteKiemKe(int idKiemKe)
        {
            KiemKeDAO.Instance.Delete(idKiemKe);
        }
        public void DeleteKiemKe2(int idKiemKe)
        {
            KiemKeDAO.Instance.Delete2(idKiemKe);
        }
        public List<KiemKeInfor> GetListKiemKe(int idKho)
        {
            return KiemKeDAO.Instance.GetListKiemKe(idKho);
        }
        public KiemKeInfor GetKiemKeInfoById(int idKiemKe)
        {
            return KiemKeDAO.Instance.GetKiemKeInfoById(idKiemKe);
        }
        public List<KiemKeInfor> GetListKiemKe2()
        {
            return KiemKeDAO.Instance.GetListKiemKe2();
        }
        public List<KiemKeChiTietHangHoaInfor> GetListChiTietKiemKeCo(int OidCo)
        {
            return KiemKeDAO.Instance.GetListChiTietKiemKeCo(OidCo);
        }
        public List<KiemKeChiTietKhongMaVachInfor> GetListChiTietKiemKeKhong(int OidKhong)
        {
            return KiemKeDAO.Instance.GetListChiTietKiemKeKhong(OidKhong);
        }
        public void InsertChiTietKiemKeBoSung(int Oid, int idkho)
        {
             KiemKeDAO.Instance.InsertChiTietKiemKeBoSung(Oid, idkho);
        }
        public void InsertChiTietHangHoaKiemKeBoSung(int Oid,int idchitietkiemke, int idkho)
        {
             KiemKeDAO.Instance.InsertChiTietHangHoaKiemKeBoSung(Oid,idchitietkiemke, idkho);
        }
        public List<ChungTu_ChiTietHangHoaKiemKeInfor> GetIdSanPhamByMaVach(string maVach, string maTrungTam, string maKho, string maNganh, int idDotKiemKe)
        {
            return KiemKeDAO.Instance.GetIdSanPhamByMaVach(maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
        }
        public static List<KiemKeInfor> Search(string sophieu)
        {
            return KiemKeDAO.Instance.Search(sophieu);
        }
        public void UpdateTrangThaiKiemKe(int Oid,int TrangThai)
        {
            KiemKeDAO.Instance.UpdateTrangThaiKiemKe(Oid,TrangThai);
        }
        public void UpdateGhiChuKiemKe(int Oid, string ghiChu)
        {
            KiemKeDAO.Instance.UpdateGhiChuKiemKe(Oid, ghiChu);
        }
        public bool CheckMaVach(string MaKho, int IdSanPham, string maVach,string maNganh, string maTrungTam, int idDotKiemKe)
        {
            return KiemKeDAO.Instance.CheckMaVach(MaKho, IdSanPham, maVach, maNganh, maTrungTam, idDotKiemKe);
        }
        public List<DMSanPhamInfoEx> GetLookUpSanPhamTrungMV(string maVach, string maTrungTam, string maKho, string maNganh, int idDotKiemKe)
        {
            return KiemKeDAO.Instance.GetLookUpSanPhamTrungMV(maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
        }
        public ChungTu_ChiTietHangHoaKiemKeInfor GetSanPhamById_MaVach(int idsanpham,string maVach, string maTrungTam, string maKho, string maNganh, int idDotKiemKe)
        {
            return KiemKeDAO.Instance.GetSanPhamById_MaVach(idsanpham, maVach, maTrungTam, maKho, maNganh, idDotKiemKe);
        }
        public KiemKeInfor GetTrangThaiBysoPhieu(string soPhieu)
        {
            return KiemKeDAO.Instance.GetMaVachBySoPhieu(soPhieu);
        }
        public List<BCKiemKeChungTuLienQuanTon> GetListKiemKeChungTuLienQuanTon(BCChiTietKiemKeInfo kiemKeChiTietInfor)
        {
            return KiemKeDAO.Instance.GetListKiemKeChungTuLienQuanTon(kiemKeChiTietInfor.MaKho, kiemKeChiTietInfor.MaSanPham, kiemKeChiTietInfor.IdDotKiemKe);
        }
        public List<BCKiemKeChungTuLienQuanMaVach> GetListKiemKeChungTuLienQuanMaVach(string maKho, string maVach, int idDotKiemKe)
        {
            return KiemKeDAO.Instance.GetListKiemKeChungTuLienQuanMaVach( maKho, maVach, idDotKiemKe);
        }
        public void UpdateKiemKeKhoKhach(int Oid, int khoKhach)
        {
            KiemKeDAO.Instance.UpdateKiemKekhoKhach(Oid, khoKhach);
        }
        public void DeleteRowKiemKeCoMaVach(int idChiTietKiemKe, int idSanPham, int idChitietHangHoa)
        {
            KiemKeDAO.Instance.DeleteRowKiemKeCoMaVach(idChiTietKiemKe,idSanPham,idChitietHangHoa);
        }
        public void DeleteRowKiemKeKhongMaVach(int idChiTietKiemKe, int idSanPham, string maVach)
        {
            KiemKeDAO.Instance.DeleteRowKiemKeKhongMaVach(idChiTietKiemKe, idSanPham, maVach);
        }
        public List<InPhieuKiemKeInfor> GetBCPhieuKiemKe(int idKiemKe)
        {
            return KiemKeDAO.Instance.GetBCPhieuKiemKe(idKiemKe);
        }
    }
}
