using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NUS.StudentIntegrity.Configuration;

namespace NUS.StudentIntegrity.Web.Startup
{
    [DependsOn(typeof(StudentIntegrityWebCoreModule))]
    public class StudentIntegrityWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public StudentIntegrityWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<StudentIntegrityNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StudentIntegrityWebMvcModule).GetAssembly());
        }
    }
}
