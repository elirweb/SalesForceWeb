using System;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace SalesForceWeb.UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection usuario) {

            HttpClient client = null;
            string retorno = string.Empty;
            if (client == null) { 
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:61154/");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage resultado = 
                    client.GetAsync("sales/Login/AuthenticarUsuario/"+usuario["Login"]+"/"+"/"+usuario["Senha"]).Result;
                
                retorno = resultado.Content.ReadAsStringAsync().Result;

                if (retorno == "[]")
                    ViewBag.mensagem = "Erro! Usuário ou Senha não cadastrado";
                else 
                    FormsAuthentication.SetAuthCookie(usuario["Login"], false);
            }
            if (ViewBag.mensagem != null)
                return Json(ViewBag.mensagem, JsonRequestBehavior.AllowGet); // retornando arquivo json 
            else
                return JavaScript("window.location.href = '/Admin/Relatorio/Index' ");// trabalhando com javascript dentro do controller
        }

        public ActionResult RedefinirSenha() {
            return View();
        }


        public ActionResult Deslogar() {
            FormsAuthentication.SignOut();
            return RedirectToAction("/Index");
        }
    }
}