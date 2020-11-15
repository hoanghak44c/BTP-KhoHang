using System;
using System.Collections.Generic;
using QLBanHang.Modules.KhoHang.DAO;
using QLBanHang.Modules.KhoHang.Infors;

namespace QLBanHang.Modules.KhoHang.Providers
{
    public class DotKiemKeDataProvider
    {

        private static DotKiemKeDataProvider instance;

        private DotKiemKeDataProvider()
        {
        }

        public static DotKiemKeDataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DotKiemKeDataProvider();
                return instance;
            }
        }

        public List<DotKiemKeInfor> GetListByDate(DateTime ngayThucHien)
        {
            return DotKiemKeDAO.Instance.GetListByDate(ngayThucHien);
        }

        public List<DotKiemKeInfor> GetListAll(int kyKiemKe, int namKiemKe, string maDotKiemKe)
        {
            return DotKiemKeDAO.Instance.GetListAll(kyKiemKe, namKiemKe, maDotKiemKe);
        }

        public int Insert(DotKiemKeInfor info)
        {
            return DotKiemKeDAO.Instance.Insert(info);
        }
        /// <summary>
        /// Kết thúc đợt kiểm kê.
        /// </summary>
        /// <param name="info"></param>
        public void Update(DotKiemKeInfor info)
        {
            DotKiemKeDAO.Instance.Update(info);
        }

        public List<DotKiemKeInfor> GetLookUpDKK()
        {
            return DotKiemKeDAO.Instance.GetLookUpDKK();
        }

        public List<DotKiemKeInfor> GetLookUpDKKEnd()
        {
            return DotKiemKeDAO.Instance.GetLookUpDKKEnd();
        }

        public DotKiemKeInfor GetListDotKiemkeById(int idDotKiemKe)
        {
            return DotKiemKeDAO.Instance.GetListDotKiemKeById(idDotKiemKe);
        }

        public bool CanBeFinished(int idDotKiemKe)
        {
            return DotKiemKeDAO.Instance.CanBeFinished(idDotKiemKe);
        }

        public bool MaDotKiemKeUnique(string maDotKiemKe)
        {
            return DotKiemKeDAO.Instance.MaDotKiemKeUnique(maDotKiemKe);
        }

        /// <summary>
        /// Tổng hợp kiểm kê
        /// </summary>
        /// <param name="info"></param>
        public void Update2(DotKiemKeInfor info)
        {
            DotKiemKeDAO.Instance.Update2(info);
        }

        public void ChotSoTon(DotKiemKeInfor info)
        {
            DotKiemKeDAO.Instance.ChotSoTon(info);
        }

        public bool DaChotSoTon(DotKiemKeInfor info)
        {
            return DotKiemKeDAO.Instance.DaChotSoTon(info);
        }

        internal bool UpdateThoiGianChotTon(DotKiemKeInfor info)
        {
            return DotKiemKeDAO.Instance.UpdateThoiGianChotTon(info) > 0;
        }
    }
}