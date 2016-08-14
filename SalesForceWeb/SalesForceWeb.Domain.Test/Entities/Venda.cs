namespace SalesForceWeb.Domain.Test.Entities
{
    public  class Venda: Base.EntidadeBase
    {
        public string TokenVenda { get; set; }
        public virtual Usuario UsuarioModel { get; set; }
        public int IDUsuario { get; set; }

        public decimal PrecoVenda { get; set; }

    }
}
