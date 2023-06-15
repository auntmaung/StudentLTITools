using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NUS.TestProject.Authorization.Roles;
using NUS.TestProject.Authorization.Users;
using NUS.TestProject.MultiTenancy;

namespace NUS.TestProject.EntityFrameworkCore
{
    public class TestProjectDbContext : AbpZeroDbContext<Tenant, Role, User, TestProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options)
            : base(options)
        {
        }
    }
}
