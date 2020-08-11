using Abp.Modules;
using Abp.Reflection.Extensions;
using PontodeAjuda.Localization;

namespace PontodeAjuda
{
    public class PontodeAjudaCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            PontodeAjudaLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontodeAjudaCoreModule).GetAssembly());
        }
    }
}