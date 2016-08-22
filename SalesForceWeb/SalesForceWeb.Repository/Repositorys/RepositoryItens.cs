using System;

namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryItens : RepositoryBase<SalesForceWeb.Domain.Entities.Itens>,
        SalesForceWeb.Domain.Interfaces.IItens
    {

        public RepositoryItens(): base (new EFDataBase.Contexto())
        {
                
        }

        public decimal Desconto(decimal preco, decimal desconto)
        {
            return decimal.Parse(string.Format("{0:n2}",(desconto / 100) * preco));
        }
    }
}
