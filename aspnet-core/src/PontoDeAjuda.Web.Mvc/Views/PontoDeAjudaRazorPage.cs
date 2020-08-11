using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace PontoDeAjuda.Web.Views
{
    public abstract class PontoDeAjudaRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PontoDeAjudaRazorPage()
        {
            LocalizationSourceName = PontoDeAjudaConsts.LocalizationSourceName;
        }
    }
}
