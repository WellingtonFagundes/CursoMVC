using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace EP.CursoMVC.Infra.CrossCutting.Filters
{
    public class ClaimsAuthorize:AuthorizeAttribute
    {
        private static string _claimName;
        private static string _claimValue;

        public ClaimsAuthorize(string claimName,string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /*
             * Rotina com abordagem de cookie
             * Não precisa de muita requisição do banco
            */
            var userClaims = (ClaimsIdentity)httpContext.User.Identity;
            return ClaimsHelper.ValidarClaimsUsuario(userClaims, _claimName, _claimValue);
        }

        //Manipular requests não autorizados
        //Se ele já está logado 
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                //Muda o comportamento
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Forbidden);
            }
            else 
            {
                //Não muda o comportamento da filter
                base.HandleUnauthorizedRequest(filterContext);
            }
            
        }

       

    }
}
