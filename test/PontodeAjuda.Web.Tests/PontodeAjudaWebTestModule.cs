using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontodeAjuda.Web.Startup;
namespace PontodeAjuda.Web.Tests
{
    [DependsOn(
        typeof(PontodeAjudaWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class PontodeAjudaWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontodeAjudaWebTestModule).GetAssembly());
        }
    }
}