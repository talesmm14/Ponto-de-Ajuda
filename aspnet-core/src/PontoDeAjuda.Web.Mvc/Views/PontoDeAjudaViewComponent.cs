using Abp.AspNetCore.Mvc.ViewComponents;

namespace PontoDeAjuda.Web.Views
{
    public abstract class PontoDeAjudaViewComponent : AbpViewComponent
    {
        protected PontoDeAjudaViewComponent()
        {
            LocalizationSourceName = PontoDeAjudaConsts.LocalizationSourceName;
        }
    }
}
