using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NUS.StudentIntegrity.EntityFrameworkCore
{
    public static class StudentIntegrityDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<StudentIntegrityDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<StudentIntegrityDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
