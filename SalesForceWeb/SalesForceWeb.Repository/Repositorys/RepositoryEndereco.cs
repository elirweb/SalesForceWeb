namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryEndereco: RepositoryBase<SalesForceWeb.Domain.Entities.Endereco>,
        SalesForceWeb.Domain.Interfaces.IEndereco
    {
        public RepositoryEndereco(): base (new EFDataBase.Contexto())
        {
        }
    }
}
