using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.EFDataBase;

namespace SalesForceWeb.Api.Controllers
{
    [RoutePrefix("sales/Veiculo")]
    public class ModeloController : ApiController
    {
        
        [Route("Modelos")] // http://localhost:61154/sales/Modelos
        // GET api/<controller>
        public IEnumerable<Object> Get()
        {
            var _contexto = new Contexto();

            var modelos = (from p in _contexto.Modelo
                          select new {
                              IDModelo = p.Id,
                              Nome = p.Nome
                          }).ToList();
            return modelos.AsQueryable();
        }
        //teste

        
    }
}
