using DomainValidation.Validation;
using EP.CursoMVC.Domain.Specifications;
using EP.CursoMVC.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Validations.Clientes
{

    public class ClienteEstaConsistenteValidation:Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCPFValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();
            var clienteNomeCurto = new GenericSpecification<Cliente>(c => c.Nome.Length >= 2);

            Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido"));
            Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um email inválido"));
            Add("clienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente menor de idade não pode"));
            Add("clienteNomeCurto", new Rule<Cliente>(clienteNomeCurto, "O nome do cliente precisa ter mais de 2 caracteres"));
        }
    }
}
