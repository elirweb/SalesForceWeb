using SalesForceWeb.Domain.ValuesObject;

namespace SalesForceWeb.Domain.Entities
{
    public  class Documento:Base.EntidadeBase
    {
        
        public RG RG { get; set; }
        public Cpf CPF { get; set; }

        public int IDUsuario { get; set; }

        public virtual Usuario UsuarioModel { get; set; }

    
    }
}