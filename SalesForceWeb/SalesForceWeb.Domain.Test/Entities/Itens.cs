namespace SalesForceWeb.Domain.Test.Entities
{
    public class Itens:Base.EntidadeBase
    {
       
        public int CodigoVeiculo { get; set; }
        public int CodigoVenda { get; set; }
      
        public decimal Preco { get; set; }

        public virtual Entities.Veiculo VeiculoModel { get; set; }
        public virtual Entities.Venda VendaModel { get; set; }



    }
}
