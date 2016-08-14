using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesForceWeb.Domain.Test.ValuesObject
{
    [TestClass]
    public class Cpf
    {
        public string Codigo { get; set; }

        
        
        

        [TestMethod]
        [TestCategory("Validar_CPF")]
        public void CPF_Validar_Nao_Nulo()
        {
            var cpf = new Cpf();
            cpf.Codigo = "fdfdffdf";
            Assert.IsNotNull(cpf.Codigo, "favor preencher o Email");
        }

        [TestMethod]
        [TestCategory("Validar_CPF")]
        public void CPF_Validar_Igual()
        {
            var cpf = new Cpf();
            cpf.Codigo = "fdfdffdf";
            Assert.AreEqual(cpf.Codigo, "fdfdffdf");
        }

        [TestMethod]
        [TestCategory("Validar_CPF")]
        public void CPF_Validar_Nulo()
        {
            var cpf = new Cpf();
            cpf.Codigo = "";
            Assert.IsNull(cpf.Codigo, "Favor Informar o CPF");
        }
    }
    
}
