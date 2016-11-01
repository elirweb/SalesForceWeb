using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.Repositorys;

namespace SalesForceWeb.Api.Controllers
{
    [RoutePrefix("sales/Veiculo")]
    public class TipoController : ApiController
    {
        private readonly RepositoryTipo _tipo;

        public TipoController(RepositoryTipo tipo_)
        {
            _tipo = tipo_;
        }

        [Route("Tipos")]
        // GET api/<controller>
        public IEnumerable<Tipo> Get()
        {
            return _tipo.GetAll();
        }

        

        
    }
}