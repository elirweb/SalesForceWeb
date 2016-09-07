using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SalesForceWeb.Domain.Entities;
using SalesForceWeb.Repository.Repositorys;

namespace SalesForceWeb.Api.Controllers
{
    [RoutePrefix("sales/Cadastrar")]

    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class UsuarioController : ApiController
    {
        private readonly RepositoryUsuario _usuario;
        private readonly RepositoryDocumento _documento;
        private readonly RepositoryEndereco _endereco;

        public UsuarioController(RepositoryUsuario usuario_, RepositoryDocumento documento_, RepositoryEndereco endereco_)
        {
            _usuario = usuario_;
            _documento = documento_;
            _endereco = endereco_;

        }

        [HttpPost]
        [Route("Usuario")]
        public HttpResponseMessage CadastrarUsuario(Usuario usuario_) {

            if (_usuario == null)
                return Request.CreateResponse<Usuario>(HttpStatusCode.BadRequest, usuario_);
            else {
                try
                {
                    _usuario.Add(usuario_);
                    _usuario.commit();

                    return Request.CreateResponse<Usuario>(HttpStatusCode.OK, usuario_);
                }
                catch (Exception)
                {
                    return Request.CreateResponse<Usuario>(HttpStatusCode.InternalServerError, usuario_);
                }
            }

        }

        [HttpPost]
        [Route("Documento")]
        public HttpResponseMessage CadastrarDocumento(Documento documento_) {

            if (documento_ == null)
                return Request.CreateResponse<Documento>(HttpStatusCode.BadRequest, documento_);
            else
            {
                try
                {
                    _documento.Add(documento_);
                    _documento.commit();

                    return Request.CreateResponse<Documento>(HttpStatusCode.OK, documento_);
                }
                catch (Exception)
                {
                    return Request.CreateResponse<Documento>(HttpStatusCode.InternalServerError, documento_);
                }
            }

        }

        [AcceptVerbs("GET")]
        [Route("Endereco")]
        public HttpResponseMessage CadastrarEndereco(Endereco endereco_)
        {
            if (endereco_ == null)
                return Request.CreateResponse<Endereco>(HttpStatusCode.BadRequest, endereco_);
            else {
                    try
                    {
                    _endereco.Add(endereco_);
                    _endereco.commit();

                    return Request.CreateResponse<Endereco>(HttpStatusCode.OK, endereco_);
                    
                    }
                    catch (Exception)
                    {

                    return Request.CreateResponse<Endereco>(HttpStatusCode.InternalServerError, endereco_);
                   }

                }
        }
    }
}
