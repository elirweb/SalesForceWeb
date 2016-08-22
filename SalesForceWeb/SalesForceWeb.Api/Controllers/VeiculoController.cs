using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.EFDataBase;
using SalesForceWeb.Repository.Repositorys;

namespace SalesForceWeb.Api.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "GET")] // definindo o cabecalho de origens para receber metodo get 

    public class VeiculoController : ApiController
    {
        private readonly RepositoryVeiculo _veiculo;
        public VeiculoController(RepositoryVeiculo veiculo_)
        {
            _veiculo = veiculo_;
        }

        [Route("sales/veiculo") ]
        public IEnumerable<Object> Get() {

            // inner join com mais de uma tabela 
            var contexto_ = new Contexto();
            
            var selecao = (from tp in contexto_.Tipo
                           from vc in contexto_.veiculo.Where(vc => vc.CodigoTipo == tp.Id).DefaultIfEmpty()
                           from mod in contexto_.Modelo.Where(mod=>mod.Id == vc.CodigoModelo).DefaultIfEmpty()
                           from mc in contexto_.Marca.Where(mc=>mc.Id == mod.IDMarca).DefaultIfEmpty()
                           select new {
                               tp.TipoVeiculo,
                               vc.Cor,
                               vc.Placa,
                               NomeCarro = mod.Nome, // para não dar duplicidade nos valores 
                               MarcaCarro = mc.Nome,
                               mc.DtInclusao
                           }
                           
                           ).ToList();
            return selecao.AsQueryable(); 
        }

    }
}
