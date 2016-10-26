using System.Web.Mvc;

namespace SalesForceWeb.UI.Areas.Admin.Controllers
{
    public class RelatorioController : Controller
    {
        [Authorize]
        // GET: Admin/Relatorio
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Veiculo() {
            return View();
        }

    }
}