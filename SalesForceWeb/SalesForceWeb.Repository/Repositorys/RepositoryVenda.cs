﻿namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryVenda: RepositoryBase<SalesForceWeb.Domain.Entities.Venda>,
        SalesForceWeb.Domain.Interfaces.IVenda
    {
        public RepositoryVenda(): base (new EFDataBase.Contexto())
        {
                
        }
    }
}
