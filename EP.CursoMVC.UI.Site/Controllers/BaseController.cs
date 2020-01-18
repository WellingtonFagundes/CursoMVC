using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainValidation.Validation;
using System.Web.Mvc;

namespace EP.CursoMVC.UI.Site.Controllers
{
    public abstract class BaseController : Controller
    {
        // GET: Base
        protected void PopularModelStateComErros(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }

        }
    }
}