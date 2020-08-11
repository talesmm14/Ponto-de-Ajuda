using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontoDeAjuda.Authorization;

namespace PontoDeAjuda
{
    [DependsOn(
        typeof(PontoDeAjudaCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PontoDeAjudaApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PontoDeAjudaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(PontoDeAjudaApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
