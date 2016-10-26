using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesForceWeb.Domain.ValuesObject
{
    [ComplexType]
    public class Email
    {
        public string v;
        public string Endereco { get; set; }

        // receber o email vindo do banco de dados 
        public Email(string v)
        {
            this.Endereco = v;
        }

        public Email()
        {
                  
        }

      
      
        

    }
}
