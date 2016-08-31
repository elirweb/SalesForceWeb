using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesForceWeb.Domain.Test.ValuesObject
{
    [TestClass]
    public class Cpf
    {
        private string v;

        public Cpf(string v)
        {
            this.Codigo = v;
        }

        public Cpf()
        {
        }

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
            var cpf = new Cpf(null); // cpf null
            Assert.IsNull(cpf.Codigo, "CPf é nulo");
        }

        [TestMethod]
        [TestCategory("Validar_CPF_Cliete")]
        public void CPF_ERRADO() {
            var cpf = new Cpf("35717357818");
            Assert.IsTrue(IsCpf(cpf.Codigo),"Erro no CPF");

        }


        public static bool IsCpf(string cpf)
        {
            while (cpf.Length < 11)
                cpf = "0" + cpf;

            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return cpf.EndsWith(digito);
        }
    }
    
}
