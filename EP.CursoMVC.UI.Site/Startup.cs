using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EP.CursoMVC.UI.Site.Startup))]
namespace EP.CursoMVC.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
