using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.EFDataBase;
using SalesForceWeb.Repository.Repositorys;
using SalesForceWeb.Workflow;

namespace SalesForceWeb.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    [RoutePrefix("sales/Login")]

    public class LoginController : ApiController
    {
        private readonly RepositoryUsuario _usuario;
        public LoginController(RepositoryUsuario usuario_)
        {
            _usuario = usuario_;
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
                    user.Login = info.Login; 
                }
                GravarAlteracoes(user.Login, token);
                email_usuario.Email(valor,token);
            }
            return dados.AsEnumerable();
        }

        public void GravarAlteracoes(string login,string token) {
            
            Usuario user = new Usuario();
            user.Login = login;
            user.TokenAlteracaoDeSenha = token;
           
            _usuario.Update(user);
            _usuario.commit(); 
        }

    }
}
