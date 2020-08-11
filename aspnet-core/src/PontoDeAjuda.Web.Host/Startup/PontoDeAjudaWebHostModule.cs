using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontoDeAjuda.Configuration;

namespace PontoDeAjuda.Web.Host.Startup
{
    [DependsOn(
       typeof(PontoDeAjudaWebCoreModule))]
    public class PontoDeAjudaWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PontoDeAjudaWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontoDeAjudaWebHostModule).GetAssembly());
        }
    }
}
