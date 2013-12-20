using System.Web;
using System.Web.Mvc;

namespace Fibonacci.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Removed this to allow custom 404 and 500 error pages
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
