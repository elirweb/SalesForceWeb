using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace SalesForceWeb.Domain.ValuesObject
{
    [ComplexType]

    public class RG
    {
        public string CodigoRG { get; set; }
        public RG() { }

        public RG(string RGCompleto){

            try
            {
                CodigoRG = Convert.ToString(RGCompleto);
            }
            catch (Exception)
            {
                throw new Exception("RG inválido: " + RGCompleto);
            }
        }

        public string CodigoRGJson(string v)
        {
            var resultado = string.Empty;
            JArray usuarioarrray = JArray.Parse(v);
            foreach (JObject obj in usuarioarrray.Children<JObject>())
            {
                foreach (JProperty prop in obj.Properties())
                {
                    switch (prop.Name)
                    {
                        case "codigoRG":
                            resultado = prop.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
            return resultado;
        }


    }
}
