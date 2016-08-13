using System;

namespace SalesForceWeb.Domain.ValuesObject
{
    public class Email
    {
        public string Endereco { get; set; }

        protected Email() { }

        public Email(string endereco) {
            SetEmail(endereco);
        }

        public void SetEmail(string email)
        {
            if (email == null)
                throw new Exception("E-mail Obrigatório");
            Endereco = email;
        }

    }
}
