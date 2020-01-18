using EP.CursoMVC.Application.Interfaces;
using EP.CursoMVC.Application.ViewModels;
using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EP.CursoMVC.Domain;
using EP.CursoMVC.Domain.Models;
using EP.CursoMVC.Domain.Services;

namespace EP.CursoMVC.Application.Services
{
    public class ClienteAppService : AppServiceBase, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;

        /*
         * Injeção de Dependência (DI - está em princípio de SOLID)
         * não precisa saber como se instancia
        */
        public ClienteAppService(IClienteRepository clienteRepository,
                                IClienteService clienteService)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }     
        public IEnumerable<ClienteViewModel> ObterAtivos()
        {
            //Implementar AutoMapper para conversão
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterAtivos());
        }

        public ClienteViewModel ObterPorCPF(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel.Cliente);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel.Endereco);

            cliente.DefinirComoAtivo();
            cliente.AdicionarEndereco(endereco);

            //Repassando a responsabilidade para camada de domínio
            var clienteReturn =  _clienteService.Adicionar(cliente);
            
            if (!clienteReturn.ValidationResult.IsValid)
            {
                //Devolver validações para a camada de apresentação
                clienteEnderecoViewModel.Cliente.ValidationResult =
                               clienteReturn.ValidationResult;
            }


            return clienteEnderecoViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            if (!cliente.EhValido()) return clienteViewModel;

            //Repassando a responsabilidade para camada de domínio
            _clienteService.Atualizar(cliente);

            return clienteViewModel;
        }

        public void Remover(Guid id)
        {
            //Repassando a responsabilidade para camada de domínio
            _clienteService.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
