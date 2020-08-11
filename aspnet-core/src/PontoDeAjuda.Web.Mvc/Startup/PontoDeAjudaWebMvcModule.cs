using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontoDeAjuda.Configuration;

namespace PontoDeAjuda.Web.Startup
{
    [DependsOn(typeof(PontoDeAjudaWebCoreModule))]
    public class PontoDeAjudaWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PontoDeAjudaWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<PontoDeAjudaNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontoDeAjudaWebMvcModule).GetAssembly());
        }
    }
}
