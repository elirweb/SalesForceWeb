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
    [RoutePrefix("sales")]

    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 
    
    public class VeiculoController : ApiController
    {
        private readonly RepositoryVeiculo _veiculo;
        public VeiculoController(RepositoryVeiculo veiculo_)
        {
            _veiculo = veiculo_;
        }

        [AcceptVerbs("GET")]
        [Route("Veiculos") ]
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
                               vc.DtInclusao
                           }
                           
                           ).ToList();
            return selecao.AsQueryable().OrderBy(x=>x.NomeCarro); 
        }

        [AcceptVerbs("GET")]
        [Route("PeloModelo/{modelo}")] // sales/PeloModelo/honda = honda é o parametro
        public IEnumerable<Object> PeloModelo(string modelo) {

            var contexto_ = new Contexto();

            var selecao = (from tp in contexto_.Tipo
                           from vc in contexto_.veiculo.Where(vc => vc.CodigoTipo == tp.Id).DefaultIfEmpty()
                           from mod in contexto_.Modelo.Where(mod => mod.Id == vc.CodigoModelo).DefaultIfEmpty()
                           from mc in contexto_.Marca.Where(mc => mc.Id == mod.IDMarca).DefaultIfEmpty()
                           select new
                           {
                               tp.TipoVeiculo,
                               vc.Cor,
                               vc.Placa,
                               NomeCarro = mod.Nome, // para não dar duplicidade nos valores 
                               MarcaCarro = mc.Nome,
                               vc.DtInclusao
                           }

                           ).ToList().Where(c=>c.NomeCarro.Equals(modelo));
            return selecao.AsQueryable().OrderBy(x => x.NomeCarro);
        }


        [AcceptVerbs("GET")]
        [Route("PelaMarca/{nomemarca}")]
        public IEnumerable<Object> PelaMarca(string nomemarca) {

            var contexto_ = new Contexto();
            
            var selecao = (from tp in contexto_.Tipo
                           from vc in contexto_.veiculo.Where(vc => vc.CodigoTipo == tp.Id).DefaultIfEmpty()
                           from mod in contexto_.Modelo.Where(mod => mod.Id == vc.CodigoModelo).DefaultIfEmpty()
                           from mc in contexto_.Marca.Where(mc => mc.Id == mod.IDMarca).DefaultIfEmpty()
                           select new
                           {
                               tp.TipoVeiculo,
                               vc.Cor,
                               vc.Placa,
                               NomeCarro = mod.Nome, // para não dar duplicidade nos valores 
                               MarcaCarro = mc.Nome,
                               vc.DtInclusao
                           }

                           ).ToList().Where(c=>c.MarcaCarro.Equals(nomemarca));
            return selecao.AsQueryable().OrderBy(c=>c.MarcaCarro);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public HttpResponseMessage PostCadastro(Veiculo veiculo_) {

            // criando uma api testada usando postman para o cadastro de veiculos está ok
            // CreateResponse cria mensagem customizada  
            // trabalhando com HttpResponseMessage retorna uma mensagem customizada 
            var cadastrar = new RepositoryVeiculo();
            
            if (veiculo_ == null) 
                return Request.CreateResponse<Veiculo>(HttpStatusCode.BadRequest, veiculo_);
            else
            {
                try
                {
                    cadastrar.Add(veiculo_);
                    cadastrar.commit();

                    var resposta = veiculo_;
                    return Request.CreateResponse<Veiculo>(HttpStatusCode.OK, resposta);
                }
                catch (Exception e)
                {
                    // Verificando onde está o erro na api 

                    List<string> error = new List<string>();

                    if (string.IsNullOrEmpty(veiculo_.Ano))
                        error.Add("Error no Ano" + veiculo_.Ano);
                    if (veiculo_.DtInclusao == null)
                        error.Add("Erro na Data de Inclusçao" + veiculo_.DtInclusao);

                    if (string.IsNullOrEmpty(veiculo_.Cor))
                        error.Add("Erro na cor");
                    if(string.IsNullOrEmpty(veiculo_.Renavam))
                        error.Add("Erro no Renavam" + veiculo_.Renavam);
                    if (string.IsNullOrEmpty(veiculo_.Placa))
                        error.Add("Erro no Placa " + veiculo_.Placa);

                    if (veiculo_.CodigoModelo == 0)
                        error.Add("Erro no Codigo Modelo " + veiculo_.CodigoModelo);

                    if (veiculo_.CodigoTipo == 0)
                        error.Add("Erro no Codigo Tipo " + veiculo_.CodigoTipo);
                  
                    return Request.CreateResponse<List<string>>(HttpStatusCode.BadRequest, error);

                }

            }
         }


    }
}
