using System;

namespace SalesForceWeb.Domain.Test.ValuesObject
{
    public class RG
    {
        public string CodigoRG { get; set; }
        protected RG() { }

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

        
    }
}
