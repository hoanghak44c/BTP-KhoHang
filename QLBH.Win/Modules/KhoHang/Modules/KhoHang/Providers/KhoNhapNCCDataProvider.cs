using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.Infors;
using QLBanHang.Modules.KhoHang.DAO;
using QLBH.Core.Business;
using QLBH.Core.Providers;

// Người tạo: Trần Tuấn Cường
// Ngày tạo :
// Ngày sửa cuối:

namespace QLBanHang.Modules.KhoHang.Providers
{
    class KhoNhapNccDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuNhapNccChiTietHangHoaInfo>
        , IBussinessKeToanKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo>
    {
        private static KhoNhapNccDataProvider instance;
        public static KhoNhapNccDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new KhoNhapNccDataProvider();
                return instance;
            }
        }

        public void UpdateChungTu(ChungTuXuatNhapNccInfo chungTu)
        {
            XuatNhapNccDAO.Instance.Update(chungTu);
        }
        public void UpdateTrangThaiChungTu(ChungTuXuatNhapNccInfo chungTu)
        {
            XuatNhapNccDAO.Instance.UpdateTrangThai(chungTu.IdChungTu,chungTu.TrangThai);
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
            return XuatNhapNccDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>
        public void DeleteChiTietChungTu(ChungTuXuatNhapNccChiTietInfo info)
        {
            XuatNhapNccDAO.Instance.DeleteChiTietChungTu(info);
        }

        public void UpdateChiTietChungTu(ChungTuXuatNhapNccChiTietInfo info)
        {
            XuatNhapNccDAO.Instance.UpdateChiTietChungTu(info);
        }

        public List<ChungTuXuatNhapNccChiTietInfo> GetListNhapHangUserInfoFromOid(string PO, string PhieuNhap, int LoaiGiaoDich, DateTime ngaynhap, int idChungTu)
        {
            return XuatNhapNccDAO.Instance.GetNhapHangUserByIdInfo(PO, PhieuNhap, LoaiGiaoDich, ngaynhap, idChungTu);
        }

        public List<ChungTuNhapNccChiTietHangHoaInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatNhapNccDAO.Instance.ChiTietHangHoaGetNhapNccByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.DeleteHangHoaChiTietNhapNcc(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.InsertChungTuChiTietHangHoaNhapNcc(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.UpdateChiTietHangHoaNhapNcc(chiTietHangHoaInfo);
        }

        public List<ChungTuXuatNccChiTietHangHoaInfo> ChungTuChiTietHangHoaGetBySoPO(string PO,int loaichungtu)
        {
            return XuatNhapNccDAO.Instance.ChungTuChiTietHHGetBySoPO(PO,loaichungtu);
        }
    }

    class XacNhanNhapThanhPhamSXDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo, ChungTuNhapNccChiTietHangHoaInfo>
    {
        private static XacNhanNhapThanhPhamSXDataProvider instance;
        public static XacNhanNhapThanhPhamSXDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new XacNhanNhapThanhPhamSXDataProvider();
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
        
        public List<ChungTuNhapNccChiTietHangHoaInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatNhapNccDAO.Instance.ChiTietHangHoaGetNhapNccByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.DeleteHangHoaChiTietNhapNcc(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.InsertChungTuChiTietHangHoaNhapNcc(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTuNhapNccChiTietHangHoaInfo chiTietHangHoaInfo)
        {
            XuatNhapNccDAO.Instance.UpdateChiTietHangHoaNhapNcc(chiTietHangHoaInfo);
        }
    }

    class XuatNhapNccDataProvider : BusinessProviderBase
    {
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
    }

    class KeToanNhapNccDataProvider : XuatNhapNccDataProvider, IBussinessKeToanKhoProvider<ChungTuXuatNhapNccInfo, ChungTuXuatNhapNccChiTietInfo>
    {
        private static KeToanNhapNccDataProvider instance;
        public static KeToanNhapNccDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new KeToanNhapNccDataProvider();
                return instance;
            }
        }

        public int InsertChiTietChungTu(ChungTuXuatNhapNccChiTietInfo chiTietChungTu)
        {
            return XuatNhapNccDAO.Instance.InsertChiTietChungTu(chiTietChungTu as ChungTuXuatNhapNccChiTietInfo);
        }

        /// <summary>
        /// Chú ý khi implement hàm này là chỉ xóa theo IdChungTuChiTiet
        /// </summary>
        public void DeleteChiTietChungTu(ChungTuXuatNhapNccChiTietInfo info)
        {
            XuatNhapNccDAO.Instance.DeleteChiTietChungTu(info);
        }

        public void UpdateChiTietChungTu(ChungTuXuatNhapNccChiTietInfo info)
        {
            XuatNhapNccDAO.Instance.UpdateChiTietChungTu(info);
        }

        public List<ChungTuXuatNhapNccChiTietInfo> GetListNhapHangUserInfoFromOid(string PO, string PhieuNhap, int LoaiGiaoDich, DateTime NgayNhap, int idChungTu)
        {
            return XuatNhapNccDAO.Instance.GetNhapHangUserByIdInfo(PO, PhieuNhap, LoaiGiaoDich, NgayNhap, idChungTu);
        }

        public List<ChungTuXuatNhapNccChiTietInfo> GetListNhapHangUserInfoFromOid(string PO, string PhieuNhap, int LoaiGiaoDich, int idKho)
        {
            return XuatNhapNccDAO.Instance.GetNhapHangUserByIdInfo(PO, PhieuNhap, LoaiGiaoDich, idKho);
        }

    }
}
