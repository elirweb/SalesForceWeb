namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryUsuario: RepositoryBase<SalesForceWeb.Domain.Entities.Usuario>,
        SalesForceWeb.Domain.Interfaces.IUsuario
    {
        public RepositoryUsuario(): base (new EFDataBase.Contexto())
        {

        }
    }
}
