using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontodeAjuda.Configuration;
using PontodeAjuda.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace PontodeAjuda.Web.Startup
{
    [DependsOn(
        typeof(PontodeAjudaApplicationModule), 
        typeof(PontodeAjudaEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class PontodeAjudaWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PontodeAjudaWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(PontodeAjudaConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<PontodeAjudaNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(PontodeAjudaApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontodeAjudaWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PontodeAjudaWebModule).Assembly);
        }
    }
}