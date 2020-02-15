using DomainValidation.Interfaces.Specification;
using EP.CursoMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirCPFUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCPFUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null;
        }
    }
}
