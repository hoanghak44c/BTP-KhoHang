using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    //public class KhoXuatNoiBoDataProvider:WrapOrigin, IBussinessKhoProvider<ChungTuXuatTieuHaoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    //{
    //    private static KhoXuatNoiBoDataProvider instance;
    //    public static KhoXuatNoiBoDataProvider Instance
    //    {
    //        get
    //        {
    //            if (instance == null) instance = new KhoXuatNoiBoDataProvider();
    //            return instance;
    //        }
    //    }
    //    public void UpdateChungTu(ChungTuXuatTieuHaoInfor chungTu)
    //    {
    //        XuatTieuHaoDAO.Instance.Update(chungTu);
    //    }

    //    public int InsertChungTu(ChungTuXuatTieuHaoInfor chungTu)
    //    {
    //        return XuatTieuHaoDAO.Instance.Insert(chungTu);
    //    }

    //    public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
    //    {
    //        return Origin(XuatTieuHaoDAO.Instance.GetListXuatTieuHaoChiTietByIdChungTu(idChungTu));
    //    }

    //    public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
    //    {
    //        return Origin(XuatTieuHaoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
    //    }

    //    public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
    //    {
    //        XuatTieuHaoDAO.Instance.Delete(chiTietHangHoaInfo);
    //    }

    //    public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
    //    {
    //        XuatTieuHaoDAO.Instance.Insert(chiTietHangHoaInfo);
    //    }

    //    public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
    //    {
    //        XuatTieuHaoDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
    //    }
    //}
}
