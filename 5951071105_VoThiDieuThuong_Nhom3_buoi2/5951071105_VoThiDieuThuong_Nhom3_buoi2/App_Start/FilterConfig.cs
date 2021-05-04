using System.Web;
using System.Web.Mvc;

namespace _5951071105_VoThiDieuThuong_Nhom3_buoi2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
