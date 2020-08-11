using Abp.Application.Services;

namespace PontodeAjuda
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class PontodeAjudaAppServiceBase : ApplicationService
    {
        protected PontodeAjudaAppServiceBase()
        {
            LocalizationSourceName = PontodeAjudaConsts.LocalizationSourceName;
        }
    }
}