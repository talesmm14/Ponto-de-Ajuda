using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace PontodeAjuda
{
    [DependsOn(
        typeof(PontodeAjudaCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PontodeAjudaApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontodeAjudaApplicationModule).GetAssembly());
        }
    }
}