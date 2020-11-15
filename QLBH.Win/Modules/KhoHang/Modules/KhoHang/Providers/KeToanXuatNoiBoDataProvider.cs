using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    //public class KeToanXuatNoiBoDataProvider: WrapOrigin,IBussinessKeToanKhoProvider<ChungTuXuatTieuHaoInfor, ChungTu_ChiTietInfo>
    //{
    //    private static KeToanXuatNoiBoDataProvider instance;
    //    public static KeToanXuatNoiBoDataProvider Instance
    //    {
    //        get
    //        {
    //            if (instance == null) instance = new KeToanXuatNoiBoDataProvider();
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

    //    public int InsertChiTietChungTu<T1>(T1 chiTietChungTu)
    //    {
    //        return XuatTieuHaoDAO.Instance.InsertChiTietChungTu(chiTietChungTu as ChungTu_ChiTietInfo);
    //    }

    //    public void DeleteChiTietChungTu<T1>(T1 chiTietChungTu)
    //    {
    //        XuatTieuHaoDAO.Instance.Delete(chiTietChungTu as ChungTu_ChiTietInfo);
    //    }

    //    public void UpdateChiTietChungTu<T1>(T1 chiTietChungTu)
    //    {
    //        XuatTieuHaoDAO.Instance.UpdateCTCT(chiTietChungTu as ChungTu_ChiTietInfo);
    //    }
    //}
}
