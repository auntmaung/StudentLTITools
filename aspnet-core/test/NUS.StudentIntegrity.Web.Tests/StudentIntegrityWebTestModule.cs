using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NUS.StudentIntegrity.EntityFrameworkCore;
using NUS.StudentIntegrity.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace NUS.StudentIntegrity.Web.Tests
{
    [DependsOn(
        typeof(StudentIntegrityWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class StudentIntegrityWebTestModule : AbpModule
    {
        public StudentIntegrityWebTestModule(StudentIntegrityEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StudentIntegrityWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(StudentIntegrityWebMvcModule).Assembly);
        }
    }
}