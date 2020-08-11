using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PontodeAjuda.EntityFrameworkCore
{
    [DependsOn(
        typeof(PontodeAjudaCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class PontodeAjudaEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontodeAjudaEntityFrameworkCoreModule).GetAssembly());
        }
    }
}