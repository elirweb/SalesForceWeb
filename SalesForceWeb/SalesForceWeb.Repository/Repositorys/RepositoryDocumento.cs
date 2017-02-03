using System.Linq;
using SalesForceWeb.Domain.Interfaces;
using SalesForceWeb.Domain.ValuesObject;
using SalesForceWeb.Repository.EFDataBase;

namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryDocumento : 
        RepositoryBase<SalesForceWeb.Domain.Entities.Documento>, IDocumento
    {

        public RepositoryDocumento(Contexto contexto_): base (new Contexto())
        {
     
        }
        
      
    }
}
