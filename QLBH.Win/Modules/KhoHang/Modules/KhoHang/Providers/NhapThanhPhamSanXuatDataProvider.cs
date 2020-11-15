using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhapThanhPhamSanXuatDataProvider : BusinessProviderBase,IBussinessKeToanKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo>
    {
        private static NhapThanhPhamSanXuatDataProvider instance;
        public static NhapThanhPhamSanXuatDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhapThanhPhamSanXuatDataProvider();
                return instance;
            }
        }
        public void UpdateChungTu(ChungTuXuatNhapNccInfo chungTu)
        {
            XuatNhapNccDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuXuatNhapNccInfo chungTu)
        {
            return XuatNhapNccDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            XuatNhapNccDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTuXuatNhapNccChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatNhapNccDAO.Instance.ChungTuChiTietGetByIdChungTu(idChungTu));
        }

        public int InsertChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
            return NhapThanhPhamSanXuatDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
            XuatNhapNccDAO.Instance.DeleteChiTietChungTu(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
           NhapThanhPhamSanXuatDAO.Instance.UpdateChiTietChungTu(chiTietChungTu);
        }
        public int CheckMaVach(int IdSanPham,string MaVach)
        {
           return NhapThanhPhamSanXuatDAO.Instance.CheckMaVach(IdSanPham,MaVach);
        }
        public int CheckXacNhanNhapMaVachTP(int idChungTu, int idSanPham, string maVach)
        {
            return NhapThanhPhamSanXuatDAO.Instance.CheckXacNhanNhapMaVachTP(idChungTu, idSanPham, maVach);
        }
        public int CheckMaVachByKho(int IdSanPham, string MaVach, int soluong)
        {
            return NhapThanhPhamSanXuatDAO.Instance.CheckMaVachByKho(IdSanPham, MaVach, soluong);
        }
        public int CheckMaVachTP(int IdSanPham, string MaVach)
        {
            return NhapThanhPhamSanXuatDAO.Instance.CheckMaVachTP(IdSanPham, MaVach);
        }
        public int CheckMaVachNTP(int IdSanPham, string MaVach)
        {
            return NhapThanhPhamSanXuatDAO.Instance.CheckMaVachNTP(IdSanPham, MaVach);
        }
    }
}
