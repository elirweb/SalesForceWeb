namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryTipo: RepositoryBase<SalesForceWeb.Domain.Entities.Tipo>,
        SalesForceWeb.Domain.Interfaces.ITipo
    {
        public RepositoryTipo(): base (new EFDataBase.Contexto())
        {

        }
    }
}
