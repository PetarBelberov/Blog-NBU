using System.Web;
using System.Web.Mvc;

namespace Blog_Petar_Belberov
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
