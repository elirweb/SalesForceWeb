using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

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
           Endereco = v;
        }

        public string EmailJson(string v) {
            var resultado = v;
            JArray usuarioarrray = JArray.Parse(v);
            foreach (JObject obj in usuarioarrray.Children<JObject>())
            {
                foreach (JProperty prop in obj.Properties())
                {
                    switch (prop.Name) {
                        case "endereco":
                            v = prop.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            return Endereco = v;
         }

        public Email()
        {
                  
        }

      
      
        

    }
}
