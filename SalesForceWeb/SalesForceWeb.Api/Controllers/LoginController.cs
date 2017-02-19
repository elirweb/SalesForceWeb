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
using SalesForceWeb.Workflow;

namespace SalesForceWeb.Api.Controllers
{
    [RoutePrefix("sales/Login")]

    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 


    public class LoginController : ApiController
    {
        private readonly RepositoryUsuario _usuario;
        private readonly RepositoryDocumento _documento;
        private readonly RepositoryEndereco _endereco;
        public LoginController(RepositoryUsuario usuario_, RepositoryDocumento documento_, RepositoryEndereco endereco_)
        {
            _usuario = usuario_;
            _documento = documento_;
            _endereco = endereco_;
        }


        [AcceptVerbs("GET")]
        [Route("AuthenticarUsuario/{login}/{senha}")]
        public IEnumerable<Usuario> VerificarUsuario(string login, string senha) {

            var contexto = new Contexto();

            var dados = from p in contexto.Usuario.Where(p => p.Login.Equals(login) &&
                    p.Senha.Equals(senha))
                        select p;
            return dados.AsEnumerable();
        }

        [AcceptVerbs("GET")]
        [Route("Buscar/{valor}/email")]
        public IEnumerable<Usuario> Email(string valor)
        {
            EmailUsuario email_usuario = new EmailUsuario();
            // criando o token de authenticação Guid.NewGuid().ToString()
            var token = Guid.NewGuid().ToString();
            Usuario user = new Usuario();

            var dados = _usuario.Localizar(x => x.Email.Endereco.Equals(valor.Trim()));
            if (dados != null)
            {
                foreach (var info in dados) {
                    user.Id = info.Id;
                }

                email_usuario.Email(valor, token + "|" + user.Id);
            }
            return dados.AsEnumerable();
        }

        [HttpPost]
        [Route("AtualizarSenha")]
        public HttpResponseMessage AtualizarSenha(Usuario user) {
            Contexto db = new Contexto();
            if (user == null)
                return Request.CreateResponse<Usuario>(HttpStatusCode.BadRequest, user);
            else
            {
                try
                {

                    user.Email =
                        new Domain.ValuesObject.Email(user.Email.Endereco); // "elirweb@gmail.com" email chumbado
                    // erro alterando a data de inclusao na alteracao de dados o certo e alterar apenas a data de alteracao 
                    _usuario.AddOrUpdate(user);
                    _usuario.commit();
                    var resposta = user;
                    return Request.CreateResponse<Usuario>(HttpStatusCode.OK, resposta);
                }
                catch (Exception f)
                {
                    throw new Exception(f.Message);
                }
            }
        }

        [AcceptVerbs("GET")]
        [Route("DadosUsuario/{idusuario}")]
        public IEnumerable<Usuario> DadosUsuario(int idusuario) {
            Usuario users = new Usuario();
            var dados = _usuario.Localizar(p => p.Id == idusuario);
            return dados.AsEnumerable();

        }

        [AcceptVerbs("GET")]
        [Route("DocumentosUsuario/{idusuario}")]
        public IEnumerable<Documento> DocumentosUsuario(int idusuario) {
          
            var dados = _documento.Localizar(p=>p.IDUsuario == idusuario);
            return dados.AsEnumerable();

        }  

        [AcceptVerbs("GET")]
        [Route("EnderecoUsuario/{idusuario}")]
        public IEnumerable<Endereco> EnderecoUsuario(int idusuario) {

            var dados = _endereco.Localizar(p => p.IDUsuario == idusuario);
            return dados.AsEnumerable();

        }

        [HttpPost]
        [Route("AtualizarDocumento")]
        public HttpResponseMessage AtualizarDocumento(Documento doc)
        {
            Contexto db = new Contexto();
            if (doc == null)
                return Request.CreateResponse<Documento>(HttpStatusCode.BadRequest, doc);
            else
            {
                try
                {

                   
                    _documento.AddOrUpdate(doc);
                    _documento.commit();
                    var resposta = doc;
                    return Request.CreateResponse<Documento>(HttpStatusCode.OK, resposta);
                }
                catch (Exception f)
                {
                    throw new Exception(f.Message);
                    

                }
            }
        }

        [HttpPost]
        [Route("AtualizarEndereco")]
        public HttpResponseMessage AtualizarEndereco(Endereco end)
        {
            Contexto db = new Contexto();
            if (end == null)
                return Request.CreateResponse<Endereco>(HttpStatusCode.BadRequest, end);
            else
            {
                try
                {

                    _endereco.AddOrUpdate(end);
                    _endereco.commit();
                    var resposta = end;
                    return Request.CreateResponse<Endereco>(HttpStatusCode.OK, resposta);
                }
                catch (Exception f)
                {
                    

                    List<string> error = new List<string>();

                    if (string.IsNullOrEmpty(end.Logradouro))
                        error.Add("logradouro");
                    if (end.DtInclusao == null)
                        error.Add("Erro na Data de Inclusçao" + end.DtInclusao);

                    if (string.IsNullOrEmpty(end.Numero))
                        error.Add("Erro na numero");

                    
                    if (string.IsNullOrEmpty(end.Cidade))
                        error.Add("Erro no cidade");

                    if (end.Id == 0)
                        error.Add("Erro no Codigo Modelo " + end.Id);

                    if (end.IDUsuario == 0)
                        error.Add("Erro no Codigo Tipo " + end.IDUsuario);

                    return Request.CreateResponse<List<string>>(HttpStatusCode.BadRequest, error);


                }
            }
        }

    }
}
