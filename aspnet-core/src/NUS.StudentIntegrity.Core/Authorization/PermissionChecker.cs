using Abp.Authorization;
using NUS.StudentIntegrity.Authorization.Roles;
using NUS.StudentIntegrity.Authorization.Users;

namespace NUS.StudentIntegrity.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
