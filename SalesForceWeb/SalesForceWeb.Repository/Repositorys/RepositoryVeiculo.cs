namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryVeiculo: RepositoryBase<SalesForceWeb.Domain.Entities.Veiculo>,
        SalesForceWeb.Domain.Interfaces.IVeiculo
    {
        public RepositoryVeiculo():base(new EFDataBase.Contexto()) 
        {

        }
    }
}
