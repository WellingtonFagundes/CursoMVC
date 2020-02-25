using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EP.CursoMVC.REST.ClienteAPI.Controllers
{
    [MyCorsPolicy]
    //headers - dentro do domínio pode fazer tudo
    //methods - fora do domínio só pode por exemplo GET e POST
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        // GET: api/Clientes
        public IEnumerable<ClienteViewModel> ObterClientes()
        {
            return _clienteAppService.ObterAtivos();
        }

        [HttpGet]
        // GET: api/Clientes/5
        public ClienteViewModel ObterPorId(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        [HttpPost]
        // POST: api/Clientes
        public IHttpActionResult Adicionar([FromBody]ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return BadRequest();

            _clienteAppService.Adicionar(clienteEndereco);

            return Ok();
        }

        [HttpPut]
        // PUT: api/Clientes/5
        public IHttpActionResult Atualizar(Guid id,[FromBody]ClienteViewModel cliente)
        {

            if (!ModelState.IsValid) return BadRequest();

            _clienteAppService.Atualizar(id, cliente);

            return Ok();
        }

        [HttpDelete]
        // DELETE: api/Clientes/5
        public IHttpActionResult Delete(Guid id)
        {
            _clienteAppService.Remover(id);

            return Ok();
        }
    }
}
