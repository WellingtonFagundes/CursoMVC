using EP.CursoMVC.Domain.Value_Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Domain.Testes.ValueObjects
{
    [TestClass]
    public class CPFValidation
    {
        [TestMethod]
        public void CPF_Valido_True()
        {
            //Arrange
            var cpfTest = "32625116846";

            //Act
            var result = CPF.Validar(cpfTest);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        [DataRow("326.251.168-46")]
        [DataRow("30399923421")]
        [DataRow("11111111111")]
        public void CPF_Valido_False(string cpf)
        {
       
            //Act
            var result = CPF.Validar(cpf);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
