using Abp.Authorization;
using NUS.TestProject.Authorization.Roles;
using NUS.TestProject.Authorization.Users;

namespace NUS.TestProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
