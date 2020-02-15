using DomainValidation.Validation;
using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Validations.Clientes
{
    public class ClienteEstaAptoParaCadastroValidation:Validator<Cliente>
    {
        
        public ClienteEstaAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {

            var clienteUnicoCPF = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var clienteUnicoEmail = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("clienteUnicoCPF", new Rule<Cliente>(clienteUnicoCPF, "Já existe um cliente com este CPF"));
            base.Add("clienteUnicoEmail", new Rule<Cliente>(clienteUnicoEmail, "Já existe um cliente com este email"));
        }
      

    }
}
