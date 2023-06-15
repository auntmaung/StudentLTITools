using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NUS.StudentIntegrity.Configuration;
using NUS.StudentIntegrity.EntityFrameworkCore;
using NUS.StudentIntegrity.Migrator.DependencyInjection;

namespace NUS.StudentIntegrity.Migrator
{
    [DependsOn(typeof(StudentIntegrityEntityFrameworkModule))]
    public class StudentIntegrityMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public StudentIntegrityMigratorModule(StudentIntegrityEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(StudentIntegrityMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                StudentIntegrityConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(StudentIntegrityMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
