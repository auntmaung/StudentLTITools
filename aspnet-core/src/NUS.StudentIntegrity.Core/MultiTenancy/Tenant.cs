using Abp.MultiTenancy;
using NUS.StudentIntegrity.Authorization.Users;

namespace NUS.StudentIntegrity.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
