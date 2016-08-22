using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.EFDataBase;
namespace SalesForceWeb.Api.Controllers
{
    public class MarcaController : ApiController
    {

        List<Marca> marcas = new List<Marca>();
        List<Modelo> modelos = new List<Modelo>();

     
        public MarcaController()
        {
            marcas.Add(new Marca { Id = 1, Nome = "Pegeout", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 2, Nome = "Chevrolet", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 3, Nome = "Volskwagen", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 4, Nome = "Fiat", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 5, Nome = "Mercebens Bens", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 6, Nome = "Renault", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 7, Nome = "Citrôen", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 8, Nome = "Hiundai", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 9, Nome = "Honda", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });
            marcas.Add(new Marca { Id = 10, Nome = "Ford", DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, });

            modelos.Add(new Modelo { Id = 1 , DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, IDMarca = 2, Nome = "Corsa Classic"  });
            modelos.Add(new Modelo { Id = 2, DtAlteracao = DateTime.Now.Date, DtInclusao = DateTime.Now.Date, IDMarca = 2, Nome = "Vectra" });

        }

        public List<ModeloSelecao> Get()
        {
            // trabalhando com inner join 
            List<ModeloSelecao> dados = new List<ModeloSelecao>(); // criei uma segunda list para ajuntar dados das duas tabelas
            var selecao = from p in marcas
                          join r in modelos 
                          on p.Id equals r.IDMarca
                       select new { p.Nome, Name = r.Nome };

                foreach (var t in selecao) {
                    dados.Add(new ModeloSelecao { Marca = t.Nome, Modelo = t.Name });
                }

            return dados; // retornando uma lista de marcas e modelos 
        }

        // GET api/values/5
        public string Get(int id)
        {
            return marcas.Find(x => x.Id == id).Nome;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
