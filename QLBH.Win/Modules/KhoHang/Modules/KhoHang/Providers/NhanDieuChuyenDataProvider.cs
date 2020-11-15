using System;
using System.Collections.Generic;
using System.Text;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;
using QLBH.Common;
using QLBH.Core.Business;
using QLBH.Core.Providers;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class NhanDieuChuyenDataProvider : BusinessProviderBase, IBussinessKhoProvider<ChungTuNhapDieuChuyenInfor, ChungTu_ChiTietInfo, ChungTu_ChiTietHangHoaBaseInfo>
    {
        private static NhanDieuChuyenDataProvider instance;
        public static NhanDieuChuyenDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new NhanDieuChuyenDataProvider();
                return instance;
            }
        }
        public static List<ChungTuNhapDieuChuyenInfor> GetListNhanDieuChuyen(string IdKho)
        {
            return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyen(IdKho);
        }

        public void UpdateChungTu(ChungTuNhapDieuChuyenInfor chungTu)
        {
            NhanDieuChuyenDAO.Instance.Update(chungTu);
        }

        public int InsertChungTu(ChungTuNhapDieuChuyenInfor chungTu)
        {
            return NhanDieuChuyenDAO.Instance.Insert(chungTu);
        }

        public void DeleteChungTu(int idChungTu)
        {
            NhanDieuChuyenDAO.Instance.Delete(idChungTu);
        }

        public List<ChungTu_ChiTietInfo> GetListChiTietChungTuByIdChungTu(int idChungTu)
        {
            return Origin(NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu));
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListNhanDieuChuyenBySoPhieu(string soPhieu)
        {
            return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenBySoPhieu(soPhieu);
        }

        public List<ChungTu_ChiTietInfo>GetListChiTietNhanDieuChuyen(int idChungTu)
        {
            return NhanDieuChuyenDAO.Instance.GetListNhanDieuChuyenChiTietByIdChungTu(idChungTu);
        }

        public int InsertChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            return NhanDieuChuyenDAO.Instance.InsertChiTietChungTu(chiTietChungTu);
        }

        public void DeleteChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhanDieuChuyenDAO.Instance.Delete(chiTietChungTu);
        }

        public void UpdateChiTietChungTu(ChungTu_ChiTietInfo chiTietChungTu)
        {
            NhanDieuChuyenDAO.Instance.UpdateCTCT(chiTietChungTu);
        }

        public List<ChungTu_ChiTietHangHoaBaseInfo> GetListChiTietHangHoaByIdChungTu(int idChungTu)
        {
            return Origin(NhanDieuChuyenDAO.Instance.ChiTietHangHoaGetByIdChungtu(idChungTu));
        }

        public void DeleteChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhanDieuChuyenDAO.Instance.DeleteChungTuChiTietHangHoa(chiTietHangHoaInfo.IdChungTuChiTiet, chiTietHangHoaInfo.IdChiTietHangHoa);
        }

        public void InsertChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhanDieuChuyenDAO.Instance.Insert(chiTietHangHoaInfo);
        }

        public void UpdateChiTietHangHoa(ChungTu_ChiTietHangHoaBaseInfo chiTietHangHoaInfo)
        {
            NhanDieuChuyenDAO.Instance.UpdateCTHH(chiTietHangHoaInfo);
        }
        public List<BaoCao_ChiTietInfor> GetPhieuNhanDieuChuyenDetail(int idChungTu)
        {
            return Origin(NhanDieuChuyenDAO.Instance.GetPhieuNhanDieuChuyenDetail(idChungTu));
        }
        public void InsertDieuChuyenHangBan(ChungTu_ChiTietHangHoaDCDHInfo chungTu)
        {
             NhanDieuChuyenDAO.Instance.InsertDieuChuyenHangBan(chungTu);
        }

        public void DieuChuyenHangBanDelete(string soChungTu)
        {
            NhanDieuChuyenDAO.Instance.DieuChuyenHangBanDelete(soChungTu);
        }

        public static ChungTuDeNghiNhanDieuChuyenInfor GetChungTuBySoCtg(string soCtg)
        {
            return NhanDieuChuyenDAO.Instance.GetChungTuBySoCtg(soCtg);
        }
        /// <summary>
        /// Báo cáo chi tiết nhập chuyển kho
        /// </summary>
        /// <param name="trungtam"></param>
        /// <param name="kho"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<BCChiTietHangChuyenKhoInfo> GetBCChiTietNhanChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtungay, DateTime nxdenngay)
        {
            return NhanDieuChuyenDAO.Instance.GetBCChiTietNhanChuyenKho(trungtam, kho, tuNgay, denNgay, nxtungay, nxdenngay);
        }
        /// <summary>
        /// Báo cáo tổng hợp nhập chuyển kho
        /// </summary>
        /// <param name="trungtam"></param>
        /// <param name="kho"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <returns></returns>
        public List<BCTongHopHangChuyenKhoInfo> GetBCTongHopNhapChuyenKho(string trungtam, string kho, DateTime tuNgay, DateTime denNgay, DateTime nxtungay, DateTime nxdenngay)
        {
            return NhanDieuChuyenDAO.Instance.GetBCTongHopNhanChuyenKho(trungtam, kho, tuNgay, denNgay, nxtungay, nxdenngay);
        }

        public static List<ChungTuNhapDieuChuyenInfor> GetFillterDeNghiNhanDieuChuyen(string idKho, string soGiaoDich, DateTime ngayThucHien, string trangThai)
        {
            return NhanDieuChuyenDAO.Instance.GetFillterDeNghiNhanDieuChuyen(idKho, soGiaoDich, ngayThucHien, trangThai);
        }
        /// <summary>
        /// Báo cáo phiếu điều chuyển chờ nhận
        /// </summary>
        /// <param name="trungtam"></param>
        /// <param name="kho"></param>
        /// <param name="tuNgay"></param>
        /// <param name="denNgay"></param>
        /// <param name="nxtungay"></param>
        /// <param name="nxdenngay"></param>
        /// <returns></returns>
        public List<BCTongHopHangChuyenKhoInfo> GetBCPhieuDieuChuyenChoNhan(string trungtam, string kho, DateTime tuNgay, DateTime denNgay)
        {
            return NhanDieuChuyenDAO.Instance.GetBCPhieuDieuChuyenChoNhan(trungtam, kho, tuNgay, denNgay);
        }
    }
}
