using EP.CursoMVC.Domain.Specifications.Clientes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Testes.Specifications
{
    [TestClass]
    public class CpfSpecificationTests
    {
        [TestMethod]
        public void CpfSpecification_Valido_True()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Wellington",
                CPF = "32625116846",
                Email = "wellington.fag@gmail.com",
                DataNascimento = new DateTime(1983, 10, 21)
            };

            var cpfSpec = new ClienteDeveTerCPFValidoSpecification();

            //Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CpfSpecification_Valido_False()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Wellington",
                CPF = "32625116841",
                Email = "wellington.fag@gmail.com",
                DataNascimento = new DateTime(1983, 10, 21)
            };

            var cpfSpec = new ClienteDeveTerCPFValidoSpecification();

            //Act
            var result = cpfSpec.IsSatisfiedBy(cliente);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
