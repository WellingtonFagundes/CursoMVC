using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Validations.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//O Domínio não pode acessar nenhuma camada
namespace EP.CursoMVC.Domain.Services
{
    //O Serviço não é obrigado saber como se faz a instância,
    //mesmo não conhecendo se basea num contrato
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        //Injeção de Dependência (DI)
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido()) return cliente;

            cliente.ValidationResult = new ClienteEstaAptoParaCadastroValidation(_clienteRepository).Validate(cliente);

            if (!cliente.ValidationResult.IsValid) _clienteRepository.Adicionar(cliente);

            return cliente;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido()) return cliente;

            _clienteRepository.Atualizar(cliente);
            return cliente;
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
