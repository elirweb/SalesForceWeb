using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesForceWeb.Helper
{
    public static class Validador
    {
        public static void ForNullOrEmptyDefaultMessage(string value, string propName)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(propName + " é obrigatório!");
        }
    }
}
