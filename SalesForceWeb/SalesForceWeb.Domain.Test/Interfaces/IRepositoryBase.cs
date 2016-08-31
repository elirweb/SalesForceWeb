using System.Collections.Generic;

namespace SalesForceWeb.Domain.Test.Interfaces
{
    public interface IRepositoryBase<TEntity> 
    {
        bool Commit(TEntity entidade);
        void Adcionar(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Deletar(TEntity entidade);
        
    }
}
