using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using PontoDeAjuda.Configuration;
using PontoDeAjuda.EntityFrameworkCore;
using PontoDeAjuda.Migrator.DependencyInjection;

namespace PontoDeAjuda.Migrator
{
    [DependsOn(typeof(PontoDeAjudaEntityFrameworkModule))]
    public class PontoDeAjudaMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PontoDeAjudaMigratorModule(PontoDeAjudaEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(PontoDeAjudaMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PontoDeAjudaConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PontoDeAjudaMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
