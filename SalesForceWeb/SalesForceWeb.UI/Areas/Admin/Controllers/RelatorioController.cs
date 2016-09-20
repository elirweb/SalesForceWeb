using System.Web.Mvc;

namespace SalesForceWeb.UI.Areas.Admin.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Admin/Relatorio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Veiculo() {
            return View();
        }

        public ActionResult AlteracaoDadosCliente() {
            return View();
        }
    }
}