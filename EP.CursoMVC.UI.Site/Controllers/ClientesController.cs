using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainValidation.Validation;
using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.Services;
using EP.CursoMVC.Application.ViewModels;
using EP.CursoMVC.Infra.CrossCutting.Filters;
using EP.CursoMVC.UI.Site.Models;

namespace EP.CursoMVC.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : BaseController
    {
        //LI,DE,IN,ED,EX
        private readonly IClienteAppService _clienteAppService;

        /*
         * Usar Simple Injector
         * No MVC é necessário baixar:
         * https://simpleinjector.org
         * No .NET CORE já vem nativo só MVC que não
         * O mesmo efetua o depara o instanciamento para que como no caso
         * o parâmetro clienteAppService seja abastecido
         * Comando no package da camada UI
         * Install-Package SimpleInjector.MVC3
        */
        public ClientesController(IClienteAppService clienteAppService)
        {
            /*
             * Não dá pra criar instância então podemos usar DI aqui na Controller
             * também
            _clienteAppService = new ClienteAppService();
             */

            _clienteAppService = clienteAppService;
                 
        }

        [ClaimsAuthorize("Clientes","LI")]
        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        //Passando um datatype se alguém tentar passar algum valor pela url para acessar,
        //com esta tipagem sendo uma proteção
        [ClaimsAuthorize("Clientes", "DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            clienteEndereco = _clienteAppService.Adicionar(clienteEndereco);

            if (clienteEndereco.Cliente.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(clienteEndereco.Cliente.ValidationResult);

            return View(clienteEndereco);
        }

        private void PopularModelStateComErros(ValidationResult validationResult)
        {

            foreach (var erro in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, erro.Message);
            }

        }

        [ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            _clienteAppService.Atualizar(clienteEndereco.Id,clienteEndereco);

            return RedirectToAction("Index");
        }


        [ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _clienteAppService.Dispose(); 
        }
    }
}
