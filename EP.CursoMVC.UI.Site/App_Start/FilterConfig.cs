using EP.CursoMVC.Infra.CrossCutting.Filters;
using System.Web;
using System.Web.Mvc;

namespace EP.CursoMVC.UI.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
