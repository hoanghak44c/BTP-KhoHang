using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.DanhMuc.Infors;
using QLBanHang.Modules.KhoHang.Bussiness;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhapNoiBoDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuNhapNoiBoInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
        , IBussinessKeToanKhoProvider<ChungTuNhapNoiBoInfor, ChungTu_ChiTietInfo>
    {
        private static NhapNoiBoDataProvider instance;
        public static NhapNoiBoDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhapNoiBoDataProvider();
                return instance;
            }
        }
        public static List<ChungTuNhapNoiBoInfor> GetListNhapNoiBo()
        {
            return NhapNoiBoDAO.Instance.GetListNhapNoiBo();
        }

        public void UpdateChungTu(ChungTuNhapNoiBoInfor chungTu)
        {
            NhapNoiBoDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapNoiBoInfor chungTu)
        {
            return NhapNoiBoDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            NhapNoiBoDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAO.Instance.GetListXuatTieuHaoChiTietByIdChungTu(idChungTu));
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(XuatTieuHaoDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }
        
        //public ChungTu_ChiTietInfo GetSanPhamTrungMaVach(int idSanPham)
        //{
        //    return NhapNoiBoDAO.Instance.GetSanPhamTrungMaVach(idSanPham);
        //}

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAO.Instance.Delete(chiTietHangHoaInfo);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            XuatTieuHaoDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return XuatTieuHaoDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatTieuHaoDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            XuatTieuHaoDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<BaoCao_ChiTietInfor> GetPhieuNhapNoiBoDetail(int idChungTu)
        {
            return Origin(NhapNoiBoDAO.Instance.GetPhieuNhapNoiBoDetail(idChungTu));
        }
        /// <summary>
        /// Hàm này dùng trong form ChungTu_ChiTietHangHoaBase ,check mã vạch đã có trong bảng tbl_HangHoa_ChiTiet chưa
        /// </summary>
        /// <param name="maVach"></param>
        /// <returns></returns>
        public List<BaoCao_ChiTietInfor> GetTrungMaVach(string maVach)
        {
            return NhapNoiBoDAO.Instance.GetTrungMaVach(maVach);
        }

        public DMDoiTuongInfo GetIdDoiTuongByPO(string pO,string rE)
        {
            return NhapNoiBoDAO.Instance.GetIdDoiTuongByPO(pO,rE);
        }

        public int GetIdPhieuNhapMuaLanCuoi(string soPo, string soRe, int idKho, int idSanPham)
        {
            return NhapNoiBoDAO.Instance.GetIdPhieuNhapMuaLanCuoi(soPo, soRe, idKho, idSanPham);
        }
    }
}
