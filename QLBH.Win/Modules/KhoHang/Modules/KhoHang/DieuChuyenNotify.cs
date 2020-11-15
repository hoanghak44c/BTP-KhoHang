using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QLBanHang.Modules.KhoHang.Providers;
using QLBH.Core;
using QLBH.Core.Providers;
using QLBH.Core.UserControls;

namespace QLBanHang.Modules.KhoHang
{
    public class DieuChuyenNotify : NotifiyBase
    {
        public DieuChuyenNotify()
        {
            FunctionCode = new List<string>
                               {
                                   "bbiYCauChuyenKho",
                                   "bbiXuatChuyenKho",
                                   "bbiXNhanChuyenKho",
                                   "bbiNhapChuyenKho"
                               };
            if (instance == null) instance = this;
        }

        private static DieuChuyenNotify instance;

        public static DieuChuyenNotify Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DieuChuyenNotify();
                }
                return instance;
            }
        }

        public override void Start(object sender)
        {
            this.TaskbarNotifier.TitleText = "Điều chuyển kho";
            this.TaskbarNotifier.ContentText = "Có {0} phiếu điều chuyển vừa được tạo tại kho {1}.";

            base.Start(sender);
        }

        public override int HasChanged(DateTime checkPoint)
        {
            string maKhos = String.Empty;

            int result = DieuChuyenNotifyProvider.Instance.HasChanged(checkPoint, ref maKhos);

            if (maKhos != null)
            {
                this.TaskbarNotifier.ContentText = "Có {0} phiếu điều chuyển vừa được tạo."; //" tại kho {1}.";

                //this.TaskbarNotifier.ContentText = String.Format(this.TaskbarNotifier.ContentText, "{0}", maKhos);
                
            }

            return result;
        }
    }
}
