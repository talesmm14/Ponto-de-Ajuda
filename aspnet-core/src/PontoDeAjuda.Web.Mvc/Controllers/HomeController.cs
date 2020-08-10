using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using PontoDeAjuda.Controllers;

namespace PontoDeAjuda.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PontoDeAjudaControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
