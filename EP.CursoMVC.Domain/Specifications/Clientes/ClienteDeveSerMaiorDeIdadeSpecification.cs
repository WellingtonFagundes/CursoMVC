﻿using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Specifications.Clientes
{
    public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}
