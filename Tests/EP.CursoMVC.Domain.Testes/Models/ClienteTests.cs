using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Testes.Models
{
    [TestClass]
    public class ClienteTests
    {
        // AAA => Arrange (Arranjar estado do objeto - Classe)
        //        Act     (A ação)
        //        Assert  (o resultado esperado)
        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarTrue()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "Wellington",
                CPF = "32625116846",
                Email = "teste@teste.com",
                DataNascimento = new DateTime(1980, 01, 01)
            };

            //Act
            var result = cliente.EhValido();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Cliente_EstaConsistente_DeveRetornarFalse()
        {
            //Arrange
            var cliente = new Cliente
            {
                Nome = "W",
                CPF = "326211116846",
                Email = "teste.com",
                DataNascimento = DateTime.Now
            };

            //Act
            var result = cliente.EhValido();

            //Assert
            //Nesse caso para ter certeza que está dando erro por esses quatro motivos informados dados
            //errados no Arrange
            Assert.IsFalse(result);
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um CPF inválido"));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente informou um email inválido"));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "Cliente menor de idade não pode"));
            Assert.IsTrue(cliente.ValidationResult.Erros.Any(e => e.Message == "O nome do cliente precisa ter mais de 2 caracteres"));
            
        }
    }
}
