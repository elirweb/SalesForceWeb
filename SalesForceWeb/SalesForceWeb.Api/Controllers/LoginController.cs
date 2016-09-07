using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.Repositorys;

namespace SalesForceWeb.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    [RoutePrefix("sales")]

    public class LoginController : ApiController
    {
        private readonly RepositoryUsuario _usuario;
        public LoginController(RepositoryUsuario usuario_)
        {
            _usuario = usuario_;
        }


        [AcceptVerbs("GET")]
        [Route("AuthenticarUsuario/{login}/{senha}")]
        public HttpResponseMessage VerificarUsuario(string login, string senha) {

            var cad = new Usuario(login,senha);
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(senha))
                return Request.CreateResponse<Usuario>(HttpStatusCode.BadRequest, cad);
            else {
                    try
                    {
                    
                        var dados = _usuario.Localizar(x => x.Login.Equals(login) && x.Senha.Equals(cad.SetCriptgrafarSenha(senha)));
                        if (dados == null)
                            return Request.CreateResponse<Usuario>(HttpStatusCode.BadRequest, cad);
                        else
                            return Request.CreateResponse<Usuario>(HttpStatusCode.OK, cad);
                    }
                    catch (Exception)
                    {
                        return Request.CreateResponse<Usuario>(HttpStatusCode.InternalServerError, cad);

                    }
            }
        }
    }
}
