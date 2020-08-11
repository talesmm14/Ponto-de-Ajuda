using Abp.AspNetCore.Mvc.Views;

namespace PontodeAjuda.Web.Views
{
    public abstract class PontodeAjudaRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected PontodeAjudaRazorPage()
        {
            LocalizationSourceName = PontodeAjudaConsts.LocalizationSourceName;
        }
    }
}
