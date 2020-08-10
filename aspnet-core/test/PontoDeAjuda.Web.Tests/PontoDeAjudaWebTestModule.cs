using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontoDeAjuda.EntityFrameworkCore;
using PontoDeAjuda.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace PontoDeAjuda.Web.Tests
{
    [DependsOn(
        typeof(PontoDeAjudaWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class PontoDeAjudaWebTestModule : AbpModule
    {
        public PontoDeAjudaWebTestModule(PontoDeAjudaEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontoDeAjudaWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(PontoDeAjudaWebMvcModule).Assembly);
        }
    }
}