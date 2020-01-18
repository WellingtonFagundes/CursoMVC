using DomainValidation.Interfaces.Specification;
using EP.CursoMVC.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCPFValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPF.Validar(cliente.CPF);
        }
    }
}
