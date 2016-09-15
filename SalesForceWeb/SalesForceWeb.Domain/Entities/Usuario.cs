using System;
using SalesForceWeb.Domain.ValuesObject;
using SalesForceWeb.Helper;

namespace SalesForceWeb.Domain.Entities
{
    public  class Usuario:Base.EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Sexo { get; set; }
        public string Idade { get; set; }
        public Email Email { get; set; }
        public string Login { get; set; }
      
        public string Senha  { get; set; }
        public string Hora { get; set; }
        public string TokenAlteracaoDeSenha { get; set; }

        

    }
}
