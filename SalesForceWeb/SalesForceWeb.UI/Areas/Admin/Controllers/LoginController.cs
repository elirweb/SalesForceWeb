using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SalesForceWeb.Domain.Entities;

namespace SalesForceWeb.UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            // usar um http client para consumir o serviço sales/Login/AuthenticarUsuario
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Usuario usuario) {

            Uri url;
            HttpClient client = null;
            string retorno = string.Empty;
            if (client == null) { 
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:61154/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resultado = 
                    client.GetAsync("sales/Login/Authenticar/" + usuario.Login + "/" + "/" + usuario.Senha).Result;

                retorno = resultado.Content.ReadAsStringAsync().Result;

                if (retorno == "")
                    ViewBag.mensagem = "Usuário não cadastrado";
                else {
                    FormsAuthentication.SetAuthCookie(usuario.Login, false);
                    return Redirect("/Relatorio");
                }
            }
            return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}