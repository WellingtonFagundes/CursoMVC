using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace EP.CursoMVC.REST.ClienteAPI.Controllers
{
    public class MyCorsPolicy : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public MyCorsPolicy()
        {
            _policy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true
            };

            //Add allowed origins
            _policy.Origins.Add("http//myclient.azurewebsites.net");
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}