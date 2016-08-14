using SalesForceWeb.Domain.Test.Enum;

namespace SalesForceWeb.Domain.Test.Entities
{
    public  class Endereco: Base.EntidadeBase
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public Uf Uf { get; set; }

        public int IDUsuario { get; set; }

        public virtual Usuario UsuarioModel {get;set;}


    }
}