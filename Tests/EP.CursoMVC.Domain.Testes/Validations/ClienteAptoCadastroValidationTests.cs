using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Validations.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Testes.Validations
{
    [TestClass]
    public class ClienteAptoCadastroValidationTests
    {
        [TestMethod]
        public void ClienteAptoCadastro_Validation_DeveRetornarTrue()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Wellington",
                CPF = "32625116846",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //MOCK - fingir que não é aquele objeto, fingir de forma realista
            //Ferramenta RhinoMocks
            //Stub -> ensinar o que o método deve retornar sem precisar tem acesso efetivamente na base
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(null);

            var cliValidation = new ClienteEstaAptoParaCadastroValidation(repo);
            

            //Act
            var result = cliValidation.Validate(cliente);

            //Assert
            Assert.IsTrue(result.IsValid);

        }

        [TestMethod]
        //Resultado reverso
        public void ClienteAptoCadastro_Validation_DeveRetornarFalse()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Wellington",
                CPF = "32625116846",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //MOCK - fingir que não é aquele objeto, fingir de forma realista
            //Ferramenta RhinoMocks
            //Stub -> ensinar o que o método deve retornar sem precisar tem acesso efetivamente na base
            var repo = MockRepository.GenerateStub<IClienteRepository>();
            repo.Stub(s => s.ObterPorEmail(cliente.Email)).Return(cliente);
            repo.Stub(s => s.ObterPorCpf(cliente.CPF)).Return(cliente);

            var cliValidation = new ClienteEstaAptoParaCadastroValidation(repo);


            //Act
            var result = cliValidation.Validate(cliente);

            //Assert
            Assert.IsFalse(result.IsValid);
            //Tem que falhar por esses dois motivos
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Já existe um cliente com este CPF"));
            Assert.IsTrue(result.Erros.Any(e => e.Message == "Já existe um cliente com este email"));

        }
    }
}
