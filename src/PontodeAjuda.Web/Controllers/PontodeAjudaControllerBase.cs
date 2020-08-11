using Abp.AspNetCore.Mvc.Controllers;

namespace PontodeAjuda.Web.Controllers
{
    public abstract class PontodeAjudaControllerBase: AbpController
    {
        protected PontodeAjudaControllerBase()
        {
            LocalizationSourceName = PontodeAjudaConsts.LocalizationSourceName;
        }
    }
}