using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EP.CursoMVC.Infra.CrossCutting.Filters
{
    //Uma classe de extensão
    //Quando se quer colocar mais funcionalidades na View
    public static class ClaimsHelper
    {
        /*
         * Quando this está ali como parâmetro quer dizer que tudo
         * que for implementado no método será injetado na classe do MVc,
         * não se tem o código fonte do Mvc mais vc consegue modificar inserindo
         * dessa forma seu método personalizado na classe MVC
         * value representa uma instância que será injetado durante a compilação
        */
        public static MvcHtmlString IfClaimHelper(this MvcHtmlString value, string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return ValidarClaimsUsuario(identity, claimName, claimValue) ? value : MvcHtmlString.Empty;
        }

        public static bool IfClaim(this WebViewPage value, string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return ValidarClaimsUsuario(identity, claimName, claimValue);
        }

        public static string IfClaimShow(this WebViewPage value, string claimName, string claimValue)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return ValidarClaimsUsuario(identity, claimName, claimValue) ? "" : "disabled";
        }

        public static bool ValidarClaimsUsuario(ClaimsIdentity claimsIdentity, string claimName, string claimValue)
        {
            var claim = claimsIdentity.Claims.FirstOrDefault(c => c.Value == claimValue);

            return claim != null && claim.Value.Contains(claimValue);
        }
    }
}
