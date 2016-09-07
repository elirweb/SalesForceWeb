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
    [RoutePrefix("sales")]
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

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}