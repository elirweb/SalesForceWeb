using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalesForceWeb.Domain.Test.ValuesObject
{

    [TestClass]
    public class Email
    {
        private string v;

        public Email(string v)
        {
            this.Endereco = v;
        }

        public Email()
        {

        }

        public string Endereco { get; set; }

        
        

        [TestMethod]
        [TestCategory("Validar_Email")]
        public void Email_Cliente() {
            var email = new Email("elirweb@gmail.com");
            email.Endereco = "elirweb@gmail.com";
            Assert.IsTrue(ValidarEmail(email.Endereco), "Email informado está errado");

        }




     
        public static bool ValidarEmail(string email)
        {
            bool validEmail = false;
            int indexArr = email.IndexOf('@');
            if (indexArr > 0)
            {
                int indexDot = email.IndexOf('.', indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < email.Length)
                    {
                        string indexDot2 = email.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }



    }
}
