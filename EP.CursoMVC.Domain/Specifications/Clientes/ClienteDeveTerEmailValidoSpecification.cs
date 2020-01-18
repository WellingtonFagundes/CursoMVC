using DomainValidation.Interfaces.Specification;
using EP.CursoMVC.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Specifications.Clientes
{
    class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return Email.Validar(cliente.Email);
        }
    }
}
