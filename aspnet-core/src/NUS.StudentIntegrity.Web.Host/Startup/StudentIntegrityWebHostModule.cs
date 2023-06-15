using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NUS.StudentIntegrity.Configuration;

namespace NUS.StudentIntegrity.Web.Host.Startup
{
    [DependsOn(
       typeof(StudentIntegrityWebCoreModule))]
    public class StudentIntegrityWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public StudentIntegrityWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StudentIntegrityWebHostModule).GetAssembly());
        }
    }
}
