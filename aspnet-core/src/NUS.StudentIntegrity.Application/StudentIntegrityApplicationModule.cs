using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NUS.StudentIntegrity.Authorization;

namespace NUS.StudentIntegrity
{
    [DependsOn(
        typeof(StudentIntegrityCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class StudentIntegrityApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<StudentIntegrityAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(StudentIntegrityApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
