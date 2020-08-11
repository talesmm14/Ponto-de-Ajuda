using Microsoft.AspNetCore.Mvc;

namespace PontodeAjuda.Web.Controllers
{
    public class HomeController : PontodeAjudaControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}