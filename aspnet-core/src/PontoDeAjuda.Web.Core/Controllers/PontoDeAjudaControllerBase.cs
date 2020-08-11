using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace PontoDeAjuda.Controllers
{
    public abstract class PontoDeAjudaControllerBase: AbpController
    {
        protected PontoDeAjudaControllerBase()
        {
            LocalizationSourceName = PontoDeAjudaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
