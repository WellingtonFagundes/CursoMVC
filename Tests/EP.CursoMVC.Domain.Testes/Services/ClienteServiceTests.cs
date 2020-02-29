using EP.CursoMVC.Domain.Interfaces;
using EP.CursoMVC.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Testes.Services
{
    [TestClass]
    public class ClienteServiceTests
    {
        [TestMethod]
        public void ClienteService_AdicionarCliente_RetornarComSucesso()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Eduardo",
                Email = "teste@teste.com",
                CPF = "32625116846",
                DataNascimento = new DateTime(1980, 10, 21)
            };

            var repo = MockRepository.GenerateStub<IClienteRepository>();
            var clienteService = new ClienteService(repo);

            //Act
            var result = clienteService.Adicionar(cliente);

            //Assert
            Assert.IsTrue(result.ValidationResult.IsValid);

        }
    }
}
