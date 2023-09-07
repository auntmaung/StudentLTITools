using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NUS.StudentIntegrity.Authorization.Roles;
using NUS.StudentIntegrity.Authorization.Users;
using NUS.StudentIntegrity.MultiTenancy;
using NUS.StudentIntegrity.LTICanvas;

namespace NUS.StudentIntegrity.EntityFrameworkCore
{
    public class StudentIntegrityDbContext : AbpZeroDbContext<Tenant, Role, User, StudentIntegrityDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Platform> Platforms { get; set; }
        public StudentIntegrityDbContext(DbContextOptions<StudentIntegrityDbContext> options)
            : base(options)
        {
        }
    }
}
