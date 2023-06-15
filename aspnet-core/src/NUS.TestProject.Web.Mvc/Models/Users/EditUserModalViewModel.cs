using System.Collections.Generic;
using System.Linq;
using NUS.TestProject.Roles.Dto;
using NUS.TestProject.Users.Dto;

namespace NUS.TestProject.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
