using SalesForceWeb.Domain.Test.ValuesObject;

namespace SalesForceWeb.Domain.Test.Entities
{
    public  class Documento:Base.EntidadeBase
    {
        

        public RG RG { get; set; }
        public Cpf CPF { get; set; }

        public int IDUsuario { get; set; }

        public virtual Usuario UsuarioModel { get; set; }

    
    }
}