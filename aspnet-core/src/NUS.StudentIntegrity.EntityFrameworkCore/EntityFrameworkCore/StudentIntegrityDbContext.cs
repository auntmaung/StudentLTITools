using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NUS.StudentIntegrity.Authorization.Roles;
using NUS.StudentIntegrity.Authorization.Users;
using NUS.StudentIntegrity.MultiTenancy;

namespace NUS.StudentIntegrity.EntityFrameworkCore
{
    public class StudentIntegrityDbContext : AbpZeroDbContext<Tenant, Role, User, StudentIntegrityDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public StudentIntegrityDbContext(DbContextOptions<StudentIntegrityDbContext> options)
            : base(options)
        {
        }
    }
}
