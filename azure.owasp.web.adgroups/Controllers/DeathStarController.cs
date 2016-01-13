using System.Web.Mvc;

namespace azure.owasp.web.adgroups.Controllers
{
   // [Authorize(Roles = "Empire")]
    public class DeathStarController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}